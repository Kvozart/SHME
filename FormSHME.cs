using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LibPNGsharp;

namespace SHME
{
    public partial class FormSHME : Form
    {
        #region Constants
        const int gridColor0 = -0x7FAAAAAA; // Dark gray
        const int gridColor1 = -0x7F555555; // Light gray
        const String xySpliter = " x ";
        const String pointerSpliter = " x ";
        List<String> exportExts = new List<String>{
            ".bmp",
            ".png",
            ".jpg",
            ".jpeg",
            ".gif",
            ".tiff"};
        readonly ImageFormat[] exportFormats = {
            ImageFormat.Bmp,
            ImageFormat.Png,
            ImageFormat.Jpeg,
            ImageFormat.Jpeg,
            ImageFormat.Gif,
            ImageFormat.Tiff};
        readonly Color[] ColorPresets = { Color.White, Color.Red, Color.Yellow, Color.Green, Color.Cyan, Color.Blue, Color.Magenta };
        readonly String[,] BytePresets = {
            { "000001", "000100", "010000", "000001", "000001", "000100", "000100", "010000", "010000" },
            { "010100", "010001", "000101", "010000", "000100", "000001", "010000", "000100", "000001" }
        };
        readonly Color[,] SpectrumPresets = {
             { Color.Black, Color.Blue,  Color.Cyan,    Color.Green, Color.Yellow,  Color.Red,   Color.Magenta, Color.White, Color.Black },
             { Color.Black, Color.Green, Color.Yellow,  Color.Red,   Color.Magenta, Color.Blue,  Color.Cyan,    Color.White, Color.Black },
             { Color.Black, Color.Red,   Color.Magenta, Color.Blue,  Color.Cyan,    Color.Green, Color.Yellow,  Color.White, Color.Black },
             { Color.Black, Color.Blue,  Color.Cyan,    Color.Red,   Color.Magenta, Color.Green, Color.Yellow,  Color.White, Color.Black },
             { Color.Black, Color.Red,   Color.Magenta, Color.Green, Color.Yellow,  Color.Blue,  Color.Cyan,    Color.White, Color.Black },
             { Color.Black, Color.Green, Color.Yellow,  Color.Blue,  Color.Cyan,    Color.Red,   Color.Magenta, Color.White, Color.Black }
        };
        Button[] btnSpectrumColor;
        const int zoomMax = 6; // x64
        #endregion

        Color[] SpectrumColors = { Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, Color.Black };

        List<int> toolPresets = new List<int>(); // [5xTool (R M L)]
        Button[] toolControls;

        bool lockMouse = false;
        bool lockDrawing = true;
        int zoom = 0; // 1:1 (2^zoom)
        byte[] bBuffer; // Raw byte data
        HeightMap HMap;
        List<HistoryRecord> historyBackward = new List<HistoryRecord>();
        List<HistoryRecord> historyForward = new List<HistoryRecord>();
        HistoryRecord historyRecord;

        public FormSHME()
        {
            InitializeComponent();

            cbbZoom.SelectedIndex = zoomMax;

            // Bind and give Tool buttons ID
            toolControls = new Button[]{
                btnToolMove,
                btnToolSwitch,
                btnToolProbe1,  // 2
                btnToolProbe2,
                btnToolProbe3,
                btnToolPencil1, // 5
                btnToolPencil2,
                btnToolPencil3,
                btnToolLevel1,  // 8
                btnToolLevel2,
                btnToolLevel3,
                btnToolAdd1,    // 11
                btnToolAdd2,
                btnToolAdd3,
                btnToolSub1,    // 14
                btnToolSub2,
                btnToolSub3,
                btnToolSmooth1, // 17
                btnToolSmooth2,
                btnToolSmooth3};
            for (int i = 0; i < 20; i++)
                toolControls[i].Tag = i;
            AddToolSet((int)btnToolPencil1.Tag, (int)btnToolMove.Tag, (int)btnToolProbe1.Tag,  (int)btnToolAdd1.Tag,   (int)btnToolSub1.Tag);
            AddToolSet((int)btnToolAdd1.Tag,    (int)btnToolMove.Tag, (int)btnToolSub1.Tag,    (int)btnToolLevel1.Tag, (int)btnToolSmooth1.Tag);
            AddToolSet((int)btnToolLevel1.Tag,  (int)btnToolMove.Tag, (int)btnToolSmooth1.Tag, (int)btnToolAdd1.Tag,   (int)btnToolSub1.Tag);

            // Bind spectrum color boxes
            btnSpectrumColor = new Button[]{
                btnSpectrumColor0, btnSpectrumColor1, btnSpectrumColor2,
                btnSpectrumColor3, btnSpectrumColor4, btnSpectrumColor5,
                btnSpectrumColor6, btnSpectrumColor7, btnSpectrumColor8 };
            for (int i = 0; i < 9; i ++)
                btnSpectrumColor[i].Tag = i;

            /* TODO: load */

            // Do presets
            cbbSpectrumStyle.SelectedIndex    = 0; // K..B..G..R..W>K
            // File level Format
            cbbLevelFormat16bit.SelectedIndex = 0;
            cbbLevelFormat8bit.SelectedIndex  = 0;
            cbbToolPreset.SelectedIndex = 0;

            // Create HMap
            HMap = new HeightMap(true);
            GeneratePDA(HMap.Width, HMap.Height);
            /*PDA*/

            // Start
            lockDrawing = false;
            FinishHMapLoading();
        }

        #region Theme pages
        private void cbb_LevelFormat_Changed(object sender, EventArgs e)//
        {
            if (lockDrawing) return;
            if (HMap == null) return;
            if (bBuffer == null) return;
            BuildLevels();
            HMap.BuildStatistics(0, -1);
            ShowStatistics();
            HMapOption_Changed(null, null);
        }

        private void cbbMonochromePresets_SelectedIndexChanged(object sender, EventArgs e) =>
            btnMonochromeColor.BackColor = ColorPresets[(sender as ComboBox).SelectedIndex];

        private void PickColor_Click(object sender, EventArgs e)//Ok
        {
            if (dlgColor.ShowDialog() != DialogResult.OK)
                return;
            (sender as Panel).BackColor = dlgColor.Color;
            if ((sender as Panel).Tag != null)
            {
                SpectrumColors[(int)(sender as Panel).Tag] = dlgColor.Color;
                DrawSpectrumSample();
            }
            HMapOption_Changed(null, null);
        }

        private void cbbBytePresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            lockDrawing = true;
            tbByteLo.Text = BytePresets[0, (sender as ComboBox).SelectedIndex];
            tbByteHi.Text = BytePresets[1, (sender as ComboBox).SelectedIndex];
            lockDrawing = false;
            BuildSpectrum(0, 0, -1, -1);
            Invalidate();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            HexTextCheck(sender as TextBox, 6, null, textBox_TextChanged);
            HMapOption_Changed(null, null);
        }

        private void cbbSpectrumPresets_SelectedIndexChanged(object sender, EventArgs e)//
        {
            lockDrawing = true;
            int p = cbbSpectrumStyle.SelectedIndex;
            for (int i = 0; i < 9; i ++)
                btnSpectrumColor[i].BackColor = SpectrumColors[i] = SpectrumPresets[p, i];
            DrawSpectrumSample();
            lockDrawing = false;
            BuildSpectrum(0, 0, -1, -1);
            Invalidate();
        }

        private void DrawSpectrumSample()//O
        {
            const int steps = 20;
            var img = new Bitmap(8 * steps, 1);
            byte step;
            for (int c = 0; c < 8; c++)
                for (step = 0; step < steps; step++)
                    img.SetPixel(c * steps + step, 0, Color.FromArgb(HeightMap.MixColor(SpectrumColors[c], SpectrumColors[c + 1], step, steps)));
            pbSpectrum.BackgroundImage = img;
        }

        private void HMapOption_Changed(object sender, EventArgs e)
        {
            if (lockDrawing) return;
            BuildSpectrum(0, 0, -1, -1);
            Invalidate();
        }
        #endregion

        #region Controls
        private void SwitchView(object sender, EventArgs e)
        {
            CheckBox A = sender as CheckBox;
            if (A.CheckState == CheckState.Indeterminate) return;
            CheckBox B = (A == chbShowHMap) ? chbShowPDA : chbShowHMap;
            if (A.CheckState == CheckState.Checked)
                B.CheckState = CheckState.Unchecked;
            else
            {
                B.CheckState = CheckState.Indeterminate;
                pbPDA.Visible = chbShowPDA.Checked;
            }
        }

        private void cbbZoom_SelectedIndexChanged(object sender, EventArgs e) => SetZoom(zoomMax - cbbZoom.SelectedIndex, false);
        private void pbZoomIn_Click   (object sender, MouseEventArgs e) => SetZoom(zoom + 1, false);
        private void pbZoomReset_Click(object sender, MouseEventArgs e) => SetZoom(0, false);
        private void pbZoomOut_Click  (object sender, MouseEventArgs e) => SetZoom(zoom - 1, false);

        private void SetZoom(int z, bool forced = true)//
        {
            if (lockDrawing) return;
            if (HMap == null) return;
            z = (z < 0) ? 0 : (zoomMax < z) ? zoomMax : z;
            if (zoom == z && !forced) return;
            zoom = z;
            ZoomFinish(
                (hScrollBar.Value + hScrollBar.LargeChange / 2) / (float)hScrollBar.Maximum,
                (vScrollBar.Value + vScrollBar.LargeChange / 2) / (float)vScrollBar.Maximum
                );
        }

        private void ZoomFinish(float scrollX, float scrollY)//
        {
            ResizeScrollBars();
            hScrollBar.Value = (int)((hScrollBar.Maximum - hScrollBar.LargeChange) * scrollX);
            vScrollBar.Value = (int)((vScrollBar.Maximum - vScrollBar.LargeChange) * scrollY);
            cbbZoom.SelectedIndex = zoomMax - zoom;
            // Resize Boxes
            pbPDA.Width  = HMap.Width  << zoom;
            pbPDA.Height = HMap.Height << zoom;
            ScrollBar_Scroll(null, null);
        }

        private void BuildLevels()//Ok
        {
            if (HMap == null) return;
            if (bBuffer == null) return;
            int loIdx = (cbbLevelFormat8bit.Visible)
                ? cbbLevelFormat8bit.SelectedIndex / 2
                : (cbbLevelFormat16bit.Visible)
                    ? 2 * cbbLevelFormat8bit.SelectedIndex
                    : 0;
            int hiIdx = (cbbLevelFormat8bit.Visible)
                ? 2 - cbbLevelFormat8bit.SelectedIndex % 3
                : (cbbLevelFormat16bit.Visible)
                    ? 2 * cbbLevelFormat8bit.SelectedIndex + 1
                    : 1;
            HMap.Init(bBuffer, (int)chbLevelByteBigLittleIndian.Tag,
                chbLevelByteBigLittleIndian.Checked ? hiIdx : loIdx,
                chbLevelByteBigLittleIndian.Checked ? loIdx : hiIdx,
                chbLevelPixelBigLittleIndian.Checked);
        }

        private void ShowStatistics()//Ok
        {
            lblHeightMin.Text = HMap.MinLevel.ToString() + " x" + HMap.MinLevel.ToString("X4");
            lblHeightAvg.Text = HMap.AvgLevel.ToString() + " x" + HMap.AvgLevel.ToString("X4");
            lblHeightMax.Text = HMap.MaxLevel.ToString() + " x" + HMap.MaxLevel.ToString("X4");
            var s = (HMap.MinLevel + HMap.MaxLevel) >> 1;
            lblHeightMid.Text = s + " x" + s.ToString("X4");
        }

        private void BuildSpectrum(int left, int top, int right, int bottom)//Ok
        {
            if (lockDrawing) return;
            if (HMap == null) return;
            //
            int smax = (chbLimitMax.Checked) ? HMap.MaxLevel : 65535;
            int smin = (chbLimitMin.Checked) ? HMap.MinLevel : 0;
            // Call builder
            if (tcThemes.SelectedTab == tpMonochrome)
                HMap.BuildMonochrome(left, top, right, bottom,
                    btnMonochromeColor.BackColor,
                    smin, smax,
                    (int)nudMonochromeRepeat.Value
                    );
            else if (tcThemes.SelectedTab == tpBytes)
                HMap.BuildHLBytes(left, top, right, bottom,
                    Convert.ToInt32(tbByteHi.Text, 16),
                    Convert.ToInt32(tbByteLo.Text, 16),
                    smin, smax,
                    (int)nudByte.Value
                    );
            else if (tcThemes.SelectedTab == tpSpectrum)
                HMap.BuildSpectrum(left, top, right, bottom,
                    SpectrumColors,
                    smin, smax,
                    (int)nudSpectrumRepeat.Value
                    );
        }

        private void btnLoadHMap_Click(object sender, EventArgs e)//
        {
            if (dlgOpen.ShowDialog() != DialogResult.OK)
                return;
            lockDrawing = true;

            int width  = 0;
            int height = 0;
            int channels = 0;
            int bitDepth = 0;
            // PNG
            PngReader PNG = null;
            try
            {
                PNG = new PngReader(dlgOpen.FileName);
                width  = PNG.Width;
                height = PNG.Height;
                channels = PNG.Channels;
                bitDepth = PNG.BitDepth;
                bBuffer = PNG.ScanLine;
                PNG.Dispose();
            }
            // Other formats
            catch (Exception exc)
            {
                PNG?.Dispose();
                try
                {
                    var img = new Bitmap(dlgOpen.FileName);
                    width  = img.Width;
                    height = img.Height;
                    channels = (img.PixelFormat == PixelFormat.Format32bppArgb) ? 4 : (img.PixelFormat == PixelFormat.Format24bppRgb) ? 3 : 1;
                    bitDepth = (img.PixelFormat == PixelFormat.Format16bppRgb565 || img.PixelFormat == PixelFormat.Format16bppRgb555 || img.PixelFormat == PixelFormat.Format16bppGrayScale || img.PixelFormat == PixelFormat.Format16bppArgb1555)
                        ? 16
                        : (img.PixelFormat == PixelFormat.Format32bppArgb || img.PixelFormat == PixelFormat.Format24bppRgb || img.PixelFormat == PixelFormat.Format8bppIndexed)
                            ? 8
                            : (img.PixelFormat == PixelFormat.Format4bppIndexed)
                                ? 4
                                : (img.PixelFormat == PixelFormat.Format1bppIndexed)
                                ? 1
                                : 0; // unknown
                    if (bitDepth == 0)
                        throw new ArgumentException("Unacceptable format");
                    // Prepare buffer
                    var imgData = img.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, img.PixelFormat);
                    int rowBytes = width * channels * bitDepth;
                    rowBytes = rowBytes / 8 + ((0 < rowBytes % 8) ? 1 : 0); // Odd byte
                    bBuffer = new byte[rowBytes * height];
                    // Grab data
                    IntPtr rowPtr = imgData.Scan0;
                    for (int y = 0; y < height; y++)
                    {
                        Marshal.Copy(rowPtr, bBuffer, y * rowBytes, rowBytes);
                        rowPtr += imgData.Stride;
                    }
                    img.UnlockBits(imgData);
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to open file:" + "\r\n" + dlgOpen.FileName + "\r\n" + exc.Message, "Open HMap error");
                    return;
                }
            }
            // Show controls
            lblFileFormat.Visible                = (bitDepth !=  8 || 1 < channels);
            cbbLevelFormat8bit.Visible           = (bitDepth ==  8 && 1 < channels);
            chbLevelByteBigLittleIndian.Visible  = (bitDepth !=  8 && 1 < bitDepth);
            chbLevelPixelBigLittleIndian.Visible = (bitDepth <   8);
            // Store Channels and BlockSize
            chbLevelByteBigLittleIndian.Tag = channels * bitDepth; // Store block size
            // Unpack
            HMap = new HeightMap(width, height);
            BuildLevels();
            lockMouse = true;
            lockDrawing = false;
            HistoryClear();
            FinishHMapLoading();
        }

        private void FinishHMapLoading()
        {
            lblHMapSizes.Text = HMap.Width + xySpliter + HMap.Height;
            HMap.BuildStatistics(0, -1);
            ShowStatistics();
            BuildSpectrum(0, 0, -1, -1);
            chbShowHMap.Checked = true;
            // Limit scrolls
            hScrollBar.Maximum = HMap.Width  - 1;
            vScrollBar.Maximum = HMap.Height - 1;
            zoom = 0;
            ZoomFinish(0, 0);
        }

        private void btnLoadPDA_Click(object sender, EventArgs e)//Ok
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
                try
                {
                    FinishPDALoading(Image.FromFile(dlgOpen.FileName));
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Unable to load file" + "\r\n" + dlgOpen.FileName + "\r\n" + exc.Message, "Open PDA error");
                }
        }

        private void btnPDAGenerate_Click(object sender, EventArgs e) => GeneratePDA(HMap.Width, HMap.Height);
        private void GeneratePDA(int width, int height)
        {
            Bitmap img = new Bitmap(width, height);
            var graphics = Graphics.FromImage(img);
            graphics.Clear(Color.DimGray);
            var pen = new Pen(Color.DarkGray);
            for (int x = 0; x < width; x += 10)
                graphics.DrawLine(pen, x, 0, x, height);
            for (int y = 0; y < height; y += 10)
                graphics.DrawLine(pen, 0, y, width, y);
            pen = new Pen(Color.LightGray);
            for (int x = 0; x < width; x += 100)
                graphics.DrawLine(pen, x, 0, x, height);
            for (int y = 0; y < height; y += 100)
                graphics.DrawLine(pen, 0, y, width, y);
            // Apply
            FinishPDALoading(img);
        }

        private void FinishPDALoading(Image img)
        {
            pbPDA.Image = img;
            lblPDASizes.Text = img.Width + xySpliter + img.Height;
            chbShowPDA.Checked = true;
        }

        private void tsmCreateEmpty_Click(object sender, EventArgs e)
        {
            var dlgCreate = new FormCreate();
            if (dlgCreate.ShowDialog() != DialogResult.OK)
                return;
            HMap = new HeightMap(dlgCreate.mapWidth, dlgCreate.mapHeight);
            lblFileFormat.Visible =
            cbbLevelFormat8bit.Visible =
            cbbLevelFormat16bit.Visible =
            chbLevelByteBigLittleIndian.Visible = false;
            HistoryClear();
            FinishHMapLoading();
        }

        private void tsmCreat_Click(object sender, EventArgs e)
        {
            HMap = (sender == tsmCreateScanline)
                ? new HeightMap(false)
                : new HeightMap(true);
            lblFileFormat.Visible =
            cbbLevelFormat8bit.Visible =
            cbbLevelFormat16bit.Visible =
            chbLevelByteBigLittleIndian.Visible = false;
            FinishHMapLoading();
        }

        private void SavePNG(bool full)
        {
            int i = 0;
            byte[] buffer = new byte[(HMap.Width * HMap.Height) << (full ? 1 : 0)];
            for (int y = 0; y < HMap.Height; y++)
                for (int x = 0; x < HMap.Width; x++)
                {
                    buffer[i++] = (byte)(HMap.Level[x, y] >> 8);
                    if (full)
                        buffer[i++] = (byte)(HMap.Level[x, y] & 255);
                }
            PngWriter png = new PngWriter(dlgSave.FileName, buffer, HMap.Width, HMap.Height, 1, (full ? 16 : 8), PngColorType.Gray);
        }

        private void btnSaveHMap_Click(object sender, EventArgs e)//Ok
        {
            // Choose file name
            dlgSave.FileName = Path.GetFileNameWithoutExtension(dlgSave.FileName);
            dlgSave.Filter = "All files (*.*)|*.*|Portable Network Graphics (*.png)|*.png";
            dlgSave.FilterIndex = 2;
            if (dlgSave.ShowDialog() != DialogResult.OK)
                return;
            // Pack
            SavePNG(sender == btnSaveHMap);
        }

        private void tsmiExportView_Click(object sender, EventArgs e)
        {
            // Choose file name
            dlgSave.FileName = Path.GetFileNameWithoutExtension(dlgSave.FileName);
            dlgSave.Filter = "All files|*.*" 
                + "|Windows Bitmap (.bmp)|*.bmp"
                + "|Portable Network Graphics (.png)|*.png"
                + "|Joint Photographic Experts Group (.jpg, .jpeg)|*.jpg"
                + "|Compuserve GIF (.gif)|*.gif"
                + "|Tagged Image File Format (.tiff)|*.tiff";
            dlgSave.FilterIndex = 3;
            if (dlgSave.ShowDialog() != DialogResult.OK)
                return;
            // Check extention
            int extIdx = exportExts.IndexOf(Path.GetExtension(dlgSave.FileName));
            if (extIdx < 0)
                extIdx = 1; // Ok, lets play this game

            // Create image
            int i = 0;
            int bytesPerRow = (HMap.Width * 3 + 3) & 0xFFFFFC; // block by 4 bytes
            byte[] buffer = new byte[bytesPerRow * HMap.Height];
            for (int y = 0; y < HMap.Height; y++)
            {
                i = y * bytesPerRow; // byte to block correction
                for (int x = 0; x < HMap.Width; x++)
                {
                    buffer[i++] = (byte)( HMap.Pixel[x, y]       );
                    buffer[i++] = (byte)((HMap.Pixel[x, y] >>  8));
                    buffer[i++] = (byte)((HMap.Pixel[x, y] >> 16));
                }
            }
            // Save
            Bitmap img = new Bitmap(HMap.Width, HMap.Height, bytesPerRow, PixelFormat.Format24bppRgb, Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0));
            img.Save(dlgSave.FileName, exportFormats[extIdx]);
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            var dlgResize = new FormResize(HMap.Width, HMap.Height);
            if (dlgResize.ShowDialog() != DialogResult.OK)
                return;
            if (HMap.Width == dlgResize.mapWidth && HMap.Height == dlgResize.mapHeight)
                return;
            // Register
            historyRecord = new HistoryRecord(HMap, 0, 0, HMap.Width - 1, HMap.Height - 1);
            HistoryAdd(HistoryRecord.ActionResize, true);
            // Prepare
            int w = (HMap.Width  < dlgResize.mapWidth ) ? HMap.Width  : dlgResize.mapWidth,
                h = (HMap.Height < dlgResize.mapHeight) ? HMap.Height : dlgResize.mapHeight,
                x;
            HeightMap buffer = HMap;
            HMap = new HeightMap(dlgResize.mapWidth, dlgResize.mapHeight);
            // Copy
            for (int y = 0; y < h; y++)
                for (x = 0; x < w; x++)
                    HMap.Level[x, y] = buffer.Level[x, y];
            // Finish
            lblFileFormat.Visible =
            cbbLevelFormat8bit.Visible =
            cbbLevelFormat16bit.Visible =
            chbLevelByteBigLittleIndian.Visible = false;
            FinishHMapLoading();
        }
        #endregion

        #region Mouse
        int scX0, scY0;
        int msX0, msY0;

        private void pbHMap_MouseDown(object sender, MouseEventArgs e)//O
        {
            msX0 = e.X;
            msY0 = e.Y;
            scX0 = hScrollBar.Value;
            scY0 = vScrollBar.Value;
            ToolAction(sender, e, false);
        }

        private void pbHMap_MouseMove(object sender, MouseEventArgs e) => ToolAction(sender, e, true);

        private void ToolAction(object sender, MouseEventArgs e, bool moving)
        {
            // Get tool, Pan, Switch
            int toolID = 0;
            if (e.Button != MouseButtons.None)
            {
                object oID =            (e.Button == MouseButtons.Left)
                    ? btnToolLMB.Tag  : (e.Button == MouseButtons.Right)
                    ? btnToolRMB.Tag  : (e.Button == MouseButtons.Middle)
                    ? btnToolMMB.Tag  : (e.Button == MouseButtons.XButton1)
                    ? btnToolX1MB.Tag : (e.Button == MouseButtons.XButton2)
                    ? btnToolX2MB.Tag
                    : null;
                if (oID != null) toolID = (int)oID;

                // Pan
                if (toolID == 0)//Ok
                {
                    if (moving)
                    {
                        // Calculate shift
                        int scX = scX0 + ((msX0 - e.X) >> zoom);
                        int scY = scY0 + ((msY0 - e.Y) >> zoom);
                        bool h = ScrollValueCheckAndSet(hScrollBar, ref scX);
                        bool v = ScrollValueCheckAndSet(vScrollBar, ref scY);
                        // Apply
                        if (h | v)
                        {
                            // Compensate for image
                            if (pbPDA == sender)
                            {
                                msX0 = msX0 + ((scX - hScrollBar.Value) << zoom);
                                msY0 = msY0 + ((scY - vScrollBar.Value) << zoom);
                            }
                            hScrollBar.Value = scX;
                            vScrollBar.Value = scY;
                            ScrollBar_Scroll(null, null);
                        }
                    }
                    return;
                }
                // Switching active layer
                else if (toolID == 1)//Ok
                {
                    if (!moving)
                        chbShowHMap.Checked = !chbShowHMap.Checked;
                    return;
                }
            }
            // Calculate point on map
            int mapX = (pbPDA.Visible) ? e.X : e.X - hScrollBar.Left;
                mapX = ( mapX                    >> zoom) + hScrollBar.Value;
            int mapY = ((e.Y  - vScrollBar.Top ) >> zoom) + vScrollBar.Value;
            // Skip outside
            if (mapX < 0 || mapY < 0 || HMap.Width <= mapX || HMap.Height <= mapY)
            {
                if (moving && lblPointerLevel.Visible)
                    FormSHME_MouseLeave(sender, e);
                return;
            }
            // Show level under pointer
            if (moving)
            {
                if (!lblPointerLevel.Visible) lblPointerLevel.Visible = true;
                lblPointerPosition.Text = mapX + pointerSpliter + mapY;
                lblPointerLevel.Text = HMap.Level[mapX, mapY].ToString() + " x" + HMap.Level[mapX, mapY].ToString("X4");
            }

            // No drawing?
            if (toolID < 2 || lockMouse) return;

            // Recalculate tool ID and Index
            toolID -= 2;
            int toolIdx = toolID % 3;
            toolID /= 3;
            // Get tool shape
            bool bar = (toolIdx == 0)
                ? chbTool1Shape.Checked
                : (toolIdx == 1)
                    ? chbTool2Shape.Checked
                    : chbTool3Shape.Checked;
            // Get tool value
            UInt16 value = (toolIdx == 0)
                ? (UInt16)nudTool1Value.Value
                : (toolIdx == 1)
                    ? (UInt16)nudTool2Value.Value
                    : (UInt16)nudTool3Value.Value;
            // Get tool size
            int y, x, size = (toolIdx == 0)
                ? (int)nudTool1Size.Value
                : (toolIdx == 1)
                    ? (int)nudTool2Size.Value
                    : (int)nudTool3Size.Value;
            // Get region
            int mapR = mapX + size / 2;
            int mapB = mapY + size / 2;
            int mapL = mapR - size + 1;
            int mapT = mapB - size + 1;
            int mapC = (mapL + mapR); // x2
            int mapM = (mapT + mapB); // x2
            int sqrR = (size * size); // Radius x4
            // Limit region
            if (mapL < 0) mapL = 0;
            if (mapT < 0) mapT = 0;
            if (HMap.Width  <= mapR) mapR = HMap.Width  - 1;
            if (HMap.Height <= mapB) mapB = HMap.Height - 1;
            int cX, cY, r;

            // History
            if (historyRecord == null)
                historyRecord = new HistoryRecord(HMap, mapL, mapT, mapL, mapT);

            // Probe, Pencil/Level
            if (toolID < 3)
            {
                // Probe +(Level)
                if (toolID == 0 || (toolID == 2 && !moving))//Ok
                {
                    value = HMap.Level[mapX, mapY];
                         if (toolIdx == 0) nudTool1Value.Value = value;
                    else if (toolIdx == 1) nudTool2Value.Value = value;
                    else                   nudTool3Value.Value = value;
                    if (toolID == 0) return;
                }
                // Bar
                if (bar || size < 3)
                    for (y = mapT; y <= mapB; y++)
                        for (x = mapL; x <= mapR; x++)
                            HMap.Level[x, y] = value;
                // Circle
                else
                    for (y = mapT; y <= mapB; y++)
                        for (x = mapL; x <= mapR; x++)
                        {
                            cX = mapC - (x << 1);
                            cY = mapM - (y << 1);
                            if (cX * cX + cY * cY + 1 < sqrR) // +1 - correction for r3, "+" shape
                                HMap.Level[x, y] = value;
                        }
            }
            // Add, Sub, Smooth
            else
            {
                double k;
                // Get average
                long h = 0;
                for (y = mapT; y <= mapB; y++)
                    for (x = mapL; x <= mapR; x++)
                        h += HMap.Level[x, y];
                h /= (mapR - mapL + 1) * (mapB - mapT + 1);
                // Add
                if (toolID == 3) h = (h + value < 65535) ? h + value : 65535;
                // Sub
                else if (toolID == 4) h = (0 < h - value) ? h - value : 0;
                // Not Soos
                else if (toolID > 5) return;
                // Smooth
                if (bar || size < 3)
                    for (y = mapT; y <= mapB; y++)
                        for (x = mapL; x <= mapR; x++)
                            HMap.Level[x, y] = (UInt16)((
                                (UInt32)(h * value) +
                                (UInt32)(HMap.Level[x, y] * (65535 - value))
                                ) / 65535);
                // Circle
                else
                    for (y = mapT; y <= mapB; y++)
                        for (x = mapL; x <= mapR; x++)
                        {
                            cX = mapC - (x << 1);
                            cY = mapM - (y << 1);
                            r = cX * cX + cY * cY + 1;
                            if (r < sqrR) // +1 - correction for r3, "+" shape
                            {
                                k = (Math.Sqrt((double)(sqrR - r) / sqrR) * ((double)(value) / 65535));
                                HMap.Level[x, y] = (UInt16)((
                                    HMap.Level[x, y] * (1 - k) +
                                    h * k
                                    ));
                            }
                        }
            }

            historyRecord.Check(mapL, mapT, mapR, mapB);
            // Update map
            BuildSpectrum(mapL, mapT, mapR, mapB);
            Invalidate(new Rectangle(
                ((mapL - hScrollBar.Value) << zoom) + hScrollBar.Left,
                ((mapT - vScrollBar.Value) << zoom) + vScrollBar.Top,
                size << zoom,
                size << zoom));
            HMap.BuildStatistics(mapT, mapB);
            ShowStatistics();
        }

        private void FormSHME_MouseUp(object sender, MouseEventArgs e)
        {
            lockMouse = false;
            HistoryAdd(HistoryRecord.ActionEdit);
        }

        private void FormSHME_MouseEnter(object sender, EventArgs e)
        {
            pnlToolSelect.Visible = false;
            cbbZoom.Focus();
        }

        private void FormSHME_MouseLeave(object sender, EventArgs e)//Ok
        {
            lblPointerPosition.Text = "-" + pointerSpliter + "-";
            lblPointerLevel.   Text = "-";
            lblPointerLevel.Visible = false;
        }
        #endregion

        #region Form
        private void cbbGrid_CheckedChanged(object sender, EventArgs e) => Invalidate();

        private void FormSHME_Paint(object sender, PaintEventArgs e)
        {
            int l = e.ClipRectangle.Left   - hScrollBar.Left,
                t = e.ClipRectangle.Top    - vScrollBar.Top,
                r = e.ClipRectangle.Right  - hScrollBar.Left,
                b = e.ClipRectangle.Bottom - vScrollBar.Top ;
            // Limit
            if (l < 0) l = 0;
            if (t < 0) t = 0;
            if (HMap.Width  <= (r >> zoom) + hScrollBar.Value) r = (HMap.Width  - hScrollBar.Value) << zoom;
            if (HMap.Height <= (b >> zoom) + vScrollBar.Value) b = (HMap.Height - vScrollBar.Value) << zoom;
            int w = r - l,
                h = b - t;
            // Optimisation
            if (w < 1 || h < 1) return;
            int iy, x,
                offset = 0,
                mask = 63 >> (zoomMax - zoom);
            bool grid = chbGrid.Checked && 2 < zoom;
            // Get image
            int[] buffer = new int[w * h];
            for (int y = t; y < b; y++)
            {
                iy = (y >> zoom) + vScrollBar.Value;
                for (x = l; x < r; x++)
                {
                    if (grid)
                    {
                        if (mask == (y & mask))
                            if (0 < (x & 1))
                            {
                                buffer[offset++] = (0 < (x & 2)) ? gridColor0 : gridColor1;
                                continue;
                            }
                        if (mask == (x & mask))
                            if (0 < (y & 1))
                            {
                                buffer[offset++] = (0 < (y & 2)) ? gridColor0 : gridColor1;
                                continue;
                            }
                    }
                    buffer[offset++] = HMap.Pixel[(x >> zoom) + hScrollBar.Value, iy];
                }
            }
            // Draw
            Bitmap img = new Bitmap(w, h, w << 2, PixelFormat.Format32bppRgb, Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0));
            e.Graphics.DrawImageUnscaled(img, l + hScrollBar.Left, t + vScrollBar.Top);
        }

        private void FormSHME_Resize(object sender, EventArgs e)
        {
            if (ResizeScrollBars())
                ScrollBar_Scroll(null, null);
        }

        private bool ResizeScrollBars()
        {
            bool h = ResizeScrollBar(hScrollBar, hScrollBar.Width );
            bool v = ResizeScrollBar(vScrollBar, vScrollBar.Height);
            return h | v;
        }

        private bool ResizeScrollBar(ScrollBar scrollBar, int largeChange)
        {
            scrollBar.LargeChange = largeChange >> zoom;
            scrollBar.Enabled = (scrollBar.Maximum >= scrollBar.LargeChange);
            int v = scrollBar.Value;
            return ScrollValueCheckAndSet(scrollBar, ref v, true);
        }

        /// <summary>
        /// Check range of value, apply if needed and returns if it's new
        /// </summary>
        /// <returns>Value not equal</returns>
        private bool ScrollValueCheckAndSet(ScrollBar scrollBar, ref int value, bool apply = false)
        {
            if (scrollBar.Maximum + 1 < value + scrollBar.LargeChange) value = scrollBar.Maximum - scrollBar.LargeChange + 1;
            if (value < 0)
                value = 0;
            if (value == scrollBar.Value) return false;
            if (apply) scrollBar.Value = value;
            return true;
        }

        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (e != null)
                if (e.OldValue == e.NewValue)
                    return;
            pbPDA.Left = -(hScrollBar.Value << zoom) + hScrollBar.Left;
            pbPDA.Top  = -(vScrollBar.Value << zoom) + vScrollBar.Top;
            Invalidate();
        }
        #endregion

        #region Tools
        private int AddToolSet(int toolL, int toolM, int toolR, int toolX1, int toolX2)//Ok
        {
            int t = toolL + (toolM << 5) + (toolR << 10) + (toolX1 << 15) + (toolX2 << 20);
            if (!toolPresets.Contains(t)) toolPresets.Add(t);
            return toolPresets.IndexOf(t);
        }

        private bool RemoveToolSet(int idx)//Ok
        {
            if (idx < 0 || toolPresets.Count - 1 < idx) return false;
            toolPresets.RemoveAt(idx);
            return true;
        }

        private void cbbToolPreset_SelectedIndexChanged(object sender, EventArgs e)//
        {
            if (cbbToolPreset.SelectedIndex < 0)
                return;
            int IDs = toolPresets[cbbToolPreset.SelectedIndex];
            ToolXMBSelect(btnToolX2MB, IDs >> 20);
            ToolXMBSelect(btnToolX1MB, IDs >> 15);
            ToolXMBSelect(btnToolRMB,  IDs >> 10);
            ToolXMBSelect(btnToolMMB,  IDs >>  5);
            ToolXMBSelect(btnToolLMB,  IDs      );
        }

        private void ToolXMBSelect(Button btnXMB, int ID)//O
        {
            ID = ID & 31;
            if (19 < ID) ID = 0; // Unknown
            btnXMB.Image = toolControls[ID].Image;
            btnXMB.Text = toolControls[ID].Text;
            btnXMB.Tag = ID;
        }

        private void btnToolXMB_Click(object sender, EventArgs e)//Ok
        {
            Button btn = sender as Button;
            pnlToolSelect.Tag = sender;
            var r = btn.PointToClient(btn.Location);
            pnlToolSelect.Left = btn.Left + gbTools.Left - (btnToolMove.Left + 1);
            pnlToolSelect.Top  = btn.Top  + gbTools.Top  - (btnToolMove.Top  + 1) - btnToolMove.Height;
            pnlToolSelect.Visible = true;
            pnlToolSelect.Focus();
        }

        private void nudTool1Value_ValueChanged(object sender, EventArgs e) => tbTool1Hex.Text = ((int)nudTool1Value.Value).ToString("X4");
        private void nudTool2Value_ValueChanged(object sender, EventArgs e) => tbTool2Hex.Text = ((int)nudTool2Value.Value).ToString("X4");
        private void nudTool3Value_ValueChanged(object sender, EventArgs e) => tbTool3Hex.Text = ((int)nudTool3Value.Value).ToString("X4");

        private void tbTool1Hex_TextChanged(object sender, EventArgs e) => HexTextCheck(tbTool1Hex, 4, nudTool1Value, tbTool1Hex_TextChanged);
        private void tbTool2Hex_TextChanged(object sender, EventArgs e) => HexTextCheck(tbTool2Hex, 4, nudTool2Value, tbTool2Hex_TextChanged);
        private void tbTool3Hex_TextChanged(object sender, EventArgs e) => HexTextCheck(tbTool3Hex, 4, nudTool3Value, tbTool3Hex_TextChanged);

        private void HexTextCheck(TextBox tb, int size, NumericUpDown nud, EventHandler e)//Ok
        {
            String s = tb.Text;
            int lIn = s.Length;
            int cursor = lIn - tb.SelectionStart; // position from end
            // Check
            s = s.ToUpper();
            char[] csOut = new char[size];
            int lOut = size - 1;
            for (int i = lIn - 1; 0 <= i && 0 <= lOut; i--)
            {
                char c = s[i];
                if (('0' <= c && c <= '9') || ('A' <= c && c <= 'F'))
                    csOut[lOut--] = c;
            }
            for (; 0 <= lOut; lOut--)
                csOut[lOut] = '0';
            // Save
            tb.TextChanged -= e;
            tb.Text = new String(csOut);
            tb.SelectionStart = size - cursor;
            if (nud != null) nud.Value = Convert.ToInt32(tb.Text, 16);
            tb.TextChanged += e;
        }

        private void btnTool_Click(object sender, EventArgs e)//Ok
        {
            ToolXMBSelect(pnlToolSelect.Tag as Button, (int)((sender as Button).Tag));
            cbbToolPreset.SelectedIndex = -1;
            pnlToolSelect.Visible = false;
        }

        private void chbToolShape_CheckedChanged(object sender, EventArgs e) => //Ok
            (sender as CheckBox).BackgroundImage = ilToolShape.Images[(sender as CheckBox).Checked ? 1 : 0];

        private void pnlToolSelect_Click(object sender, EventArgs e) => pnlToolSelect.Visible = false;

        private void ToolXSetSize(NumericUpDown nudX, int size)//???
        {
            size = size & 31;
            if (0 == size) return; // Don't change
            nudX.Value = size;
        }

        private void lblTool1Hex_Click(object sender, EventArgs e) => lblToolXHex_Click(tbTool1Hex, lblTool1Hex);
        private void lblTool2Hex_Click(object sender, EventArgs e) => lblToolXHex_Click(tbTool2Hex, lblTool2Hex);
        private void lblTool3Hex_Click(object sender, EventArgs e) => lblToolXHex_Click(tbTool3Hex, lblTool3Hex);

        private void lblToolXHex_Click(TextBox tb, Label lb) => lb.Text = (tb.Visible = !tb.Visible) ? "0x" : "D";
        #endregion

        #region History
        private void btnHistoryBackward_Click(object sender, EventArgs e) => HistoryRoll(historyBackward, historyForward);
        private void btnHistoryForward_Click (object sender, EventArgs e) => HistoryRoll(historyForward,  historyBackward);

        private void HistoryAdd(byte action, bool fast = false)//O
        {
            if (historyRecord == null) return;
            // Clear rofward
            if (0 < historyForward.Count)
            {
                btnHistoryForward.Enabled = false;
                historyForward.Clear();
            }
            historyRecord.Finish(action, fast);
            HistoryRoll(null, historyBackward);
        }

        private void HistoryRoll(List<HistoryRecord> src, List<HistoryRecord> dest)
        {
            if (src != null)
                if (0 < src.Count)
                {
                    historyRecord = src[0];
                    src.RemoveAt(0);
                    // Rollback
                    historyRecord.Rollback(ref HMap);
                    if (historyRecord.Action == HistoryRecord.ActionResize)
                        FinishHMapLoading();
                }
                else return;
            dest.Insert(0, historyRecord);
            if (100 < dest.Count) dest.RemoveAt(100); // Limit history
            // Update
            btnHistoryBackward.Text = historyBackward.Count.ToString();
            btnHistoryForward. Text = historyForward. Count.ToString();
            btnHistoryBackward.Enabled = (0 < historyBackward.Count);
            btnHistoryForward. Enabled = (0 < historyForward.Count);
            // Show
            if (src != null && historyRecord.Action == HistoryRecord.ActionEdit)
            {
                BuildSpectrum(historyRecord.Left, historyRecord.Top, historyRecord.Right, historyRecord.Bottom);
                HMap.BuildStatistics(historyRecord.Top, historyRecord.Bottom);
                ShowStatistics();
                Invalidate();
            }
            historyRecord = null;
        }

        private void HistoryClear()//O
        {
            btnHistoryForward. Text =
            btnHistoryBackward.Text = "0";
            historyForward. Clear();
            historyBackward.Clear();
            btnHistoryBackward.Enabled = btnHistoryForward.Enabled = false;
        }
        #endregion
    }
}
