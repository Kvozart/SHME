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
        const int GridColor0 = -0x7FAAAAAA; // Dark gray
        const int GridColor1 = -0x7F555555; // Light gray

        const String XYSpliter = " x ";
        const String PointerSpliter = " x ";

        List<String> ExportExts = new List<String>{
            ".bmp",
            ".png",
            ".jpg",
            ".jpeg",
            ".gif",
            ".tiff"};
        readonly ImageFormat[] ExportFormats = {
            ImageFormat.Bmp,
            ImageFormat.Png,
            ImageFormat.Jpeg,
            ImageFormat.Jpeg,
            ImageFormat.Gif,
            ImageFormat.Tiff};

        readonly Color[] MonochromePresets = { Color.White, Color.Red, Color.Yellow, Color.Green, Color.Cyan, Color.Blue, Color.Magenta };
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

        const int HistoryMax = 99;
        const int ZoomMax = 6; // x64
        #endregion

        // Fast access
        int monochromeColor  = -1; // White
        int hiByteMultiplier = 0x000100;
        int loByteMultiplier = 0x000001;
        int[] spectrumColors = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Button[] SpectrumColorControls;
        List<int> toolsetPresets = new List<int>(); // [5xTool (R M L X1 X2)]
        Button[] ToolControls;

        bool lockMouse = false;
        bool lockDrawing = true;
        int zoom = 0; // 1:1 (2^zoom)
        byte[] bBuffer; // Raw byte data
        HeightMap HMap = new HeightMap();
        TopologicalMap TMap = new TopologicalMap();

        List<HistoryRecord> historyBackward = new List<HistoryRecord>();
        List<HistoryRecord> historyForward  = new List<HistoryRecord>();
        HistoryRecord historyRecord;

        // Drawing
        float[,] tool1ForceMask;
        float[,] tool2ForceMask;
        float[,] tool3ForceMask;
        int[,] tool1Brush;
        int[,] tool2Brush;
        int[,] tool3Brush;

        public FormSHME()
        {
            InitializeComponent();

            hScrollBar.LargeChange = hScrollBar.Width;
            vScrollBar.LargeChange = vScrollBar.Height;

            // Bind and give Tool buttons ID
            ToolControls = new Button[]{
                btnToolPan,
                btnToolSwitch,
                btnToolUndo,
                btnToolRedo,
                btnToolProbe1,  // 4
                btnToolProbe2,
                btnToolProbe3,
                btnToolPencil1, // 7
                btnToolPencil2,
                btnToolPencil3,
                btnToolLevel1,  // 10
                btnToolLevel2,
                btnToolLevel3,
                btnToolAdd1,    // 13
                btnToolAdd2,
                btnToolAdd3,
                btnToolSub1,    // 16
                btnToolSub2,
                btnToolSub3,
                btnToolSmooth1, // 19
                btnToolSmooth2,
                btnToolSmooth3};
            for (int i = 0; i < ToolControls.Length; i++)
                ToolControls[i].Tag = i;

            // Bind spectrum color boxes
            SpectrumColorControls = new Button[]{
                btnSpectrumColor0, btnSpectrumColor1, btnSpectrumColor2,
                btnSpectrumColor3, btnSpectrumColor4, btnSpectrumColor5,
                btnSpectrumColor6, btnSpectrumColor7, btnSpectrumColor8 };
            for (int i = 0; i < 9; i++)
                SpectrumColorControls[i].Tag = i;

            //* Preload presets
            cbbLevelFormat16bit.SelectedIndex = 0;
            cbbLevelFormat8bit. SelectedIndex = 0;
            // Tools
            ToolXMBSelect(btnToolLMB,  (int)btnToolPencil1.Tag);
            ToolXMBSelect(btnToolMMB,  (int)btnToolPan.Tag);
            ToolXMBSelect(btnToolRMB,  (int)btnToolProbe1.Tag);
            ToolXMBSelect(btnToolX1MB, (int)btnToolAdd1.Tag);
            ToolXMBSelect(btnToolX2MB, (int)btnToolSub1.Tag);

            //* Load options
            OptionsLoad();

            //* Postload checks
            DrawSpectrumSample();
            cbbZoom.SelectedIndex = ZoomMax;
            // Tool presets
            if (cbbToolsetPreset.Items.Count < 1)
            {
                AddToolset((int)btnToolPencil1.Tag, (int)btnToolPan.Tag, (int)btnToolProbe1.Tag,  (int)btnToolAdd1.Tag,   (int)btnToolSub1.Tag);
                AddToolset((int)btnToolAdd1.Tag,    (int)btnToolPan.Tag, (int)btnToolSub1.Tag,    (int)btnToolLevel1.Tag, (int)btnToolSmooth1.Tag);
                AddToolset((int)btnToolLevel1.Tag,  (int)btnToolPan.Tag, (int)btnToolSmooth1.Tag, (int)btnToolAdd1.Tag,   (int)btnToolSub1.Tag);
            }

            // Create tool force shape
            CreateToolForceMask(ref tool1ForceMask, ref tool1Brush, btnSlot1Force.ImageIndex, nudSlot1Size, chbSlot1Shape);
            CreateToolForceMask(ref tool2ForceMask, ref tool2Brush, btnSlot2Force.ImageIndex, nudSlot2Size, chbSlot2Shape);
            CreateToolForceMask(ref tool3ForceMask, ref tool3Brush, btnSlot3Force.ImageIndex, nudSlot3Size, chbSlot3Shape);

            // Load HMap
            bool loaded = false;
            if (HMap.URL != "")
                loaded = LoadHMap(HMap.URL);
            if (!loaded)
            {
                CreateGradientMap(true);
                lockDrawing = false;
                FinishHMapLoading();
            }
            // Load TMap
            loaded = false;
            if (TMap.URL != "")
                loaded = LoadTMap(TMap.URL, false);
            if (!loaded)
                GenerateTMap(HMap.Width, HMap.Height, false);
        }

        #region Theme pages
        private void cbb_LevelFormat_Changed(object sender, EventArgs e)//
        {
            if (lockDrawing) return;
            if (bBuffer == null) return;
            BuildLevels();
            HMap.BuildStatistics(0, -1);
            ShowStatistics();
            HMapOption_Changed(null, null);
        }

        private void cbbMonochromePresets_SelectedIndexChanged(object sender, EventArgs e) =>
            btnMonochromeColor.BackColor = MonochromePresets[cbbMonochromePresets.SelectedIndex];

        private void btnMonochromeColor_BackColorChanged(object sender, EventArgs e) =>
            monochromeColor = btnMonochromeColor.BackColor.ToArgb();

        private void PickColor_Click(object sender, EventArgs e)//Ok
        {
            if (dlgColor.ShowDialog() != DialogResult.OK)
                return;
            (sender as Control).BackColor = dlgColor.Color;
            if ((sender as Button).Tag != null)
                DrawSpectrumSample();
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
            if (sender == tbByteHi)
                hiByteMultiplier = Convert.ToInt32(tbByteHi.Text, 16);
            else
                loByteMultiplier = Convert.ToInt32(tbByteLo.Text, 16);
            HMapOption_Changed(null, null);
        }

        private void cbbSpectrumPresets_SelectedIndexChanged(object sender, EventArgs e)//
        {
            lockDrawing = true;
            int p = cbbSpectrumStyle.SelectedIndex;
            for (int i = 0; i < 9; i++)
                spectrumColors[i] = (SpectrumColorControls[i].BackColor = SpectrumPresets[p, i]).ToArgb();
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
                    img.SetPixel(c * steps + step, 0, Color.FromArgb(HeightMap.MixColor(spectrumColors[c], spectrumColors[c + 1], step, steps)));
            pbSpectrum.BackgroundImage = img;
        }

        private void btnSpectrumColor_BackColorChanged(object sender, EventArgs e) =>
            spectrumColors[(int)(sender as Button).Tag] = (sender as Button).BackColor.ToArgb();

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
            CheckBox B = (A == chbShowHMap) ? chbShowTMap : chbShowHMap;
            if (A.CheckState == CheckState.Checked)
                B.CheckState = CheckState.Unchecked;
            else
            {
                B.CheckState = CheckState.Indeterminate;
                Invalidate();
            }
        }

        private void cbbZoom_SelectedIndexChanged(object sender, EventArgs e) => SetZoom(ZoomMax - cbbZoom.SelectedIndex, false);
        private void pbZoomIn_Click (object sender, MouseEventArgs e) => SetZoom(zoom + 1, false);
        private void pbZoomOut_Click(object sender, MouseEventArgs e) => SetZoom(zoom - 1, false);

        private void SetZoom(int z, bool forced = true)//
        {
            if (lockDrawing) return;
            z = (z < 0) ? 0 : (ZoomMax < z) ? ZoomMax : z;
            if (zoom == z && !forced) return;
            int oldZoom = zoom;
            zoom = z;
            if (lblPointerLevel.Enabled)
                ZoomFinish(
                    (mapX + (((hScrollBar.Width  >> 1) - msX) >> zoom)) / (float)HMap.Width,
                    (mapY + (((vScrollBar.Height >> 1) - msY) >> zoom)) / (float)HMap.Height
                    );
            else
                ZoomFinish(
                    (hScrollBar.Value + (hScrollBar.LargeChange >> 1)) / (float)hScrollBar.Maximum,
                    (vScrollBar.Value + (vScrollBar.LargeChange >> 1)) / (float)vScrollBar.Maximum
                    );
        }

        private void ZoomFinish(float scrollX, float scrollY)//
        {
            hScrollBar.Maximum = (HMap.Width  << zoom) - 1;
            vScrollBar.Maximum = (HMap.Height << zoom) - 1;
            hScrollBar.Enabled = (hScrollBar.Maximum >= hScrollBar.LargeChange);
            vScrollBar.Enabled = (vScrollBar.Maximum >= vScrollBar.LargeChange);
            int x = (int)(hScrollBar.Maximum * (scrollX - ((float)hScrollBar.LargeChange / hScrollBar.Maximum / 2)));
            int y = (int)(vScrollBar.Maximum * (scrollY - ((float)vScrollBar.LargeChange / vScrollBar.Maximum / 2)));
            ScrollValueCheckAndSet(hScrollBar, ref x, true);
            ScrollValueCheckAndSet(vScrollBar, ref y, true);
            cbbZoom.SelectedIndex = ZoomMax - zoom;
            // Redraw
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
            HMap.SetLevels(bBuffer, (int)chbLevelByteBigLittleIndian.Tag,
                chbLevelByteBigLittleIndian.Checked ? hiIdx : loIdx,
                chbLevelByteBigLittleIndian.Checked ? loIdx : hiIdx,
                chbLevelPixelBigLittleIndian.Checked);
        }

        private void CreateGradientMap(bool serpantine)
        {
            int x, y;
            HMap.SetSize(256, 256);
            for (x = 0; x < 256; x++)
                for (y = 0; y < 256; y++)
                {
                    HMap.Levels[x, y] = (UInt16)((y << 8) + x);
                    if (serpantine)
                        HMap.Levels[x, ++y] = (UInt16)((y << 8) - x + 255);
                }
        }

        private void ShowStatistics()//Ok
        {
            lblHeightMin.Text = HMap.MinLevel.ToString() + " x" + HMap.MinLevel.ToString("X4");
            lblHeightMax.Text = HMap.MaxLevel.ToString() + " x" + HMap.MaxLevel.ToString("X4");
            lblHeightAvg.Text = HMap.AvgLevel.ToString() + " x" + HMap.AvgLevel.ToString("X4");
            var s = (HMap.MinLevel + HMap.MaxLevel) >> 1;
            lblHeightMid.Text = s + " x" + s.ToString("X4");
        }

        private void BuildSpectrum(int left, int top, int right, int bottom)//Ok
        {
            if (lockDrawing) return;
            // Get limits
            int smin = (chbLimitMin.Checked) ? ((HMap.MinLevel < 65535) ? HMap.MinLevel : 65534) :     0;
            int smax = (chbLimitMax.Checked) ? ((HMap.MaxLevel >     0) ? HMap.MaxLevel :     1) : 65535;
            // Call builder
            if (tcThemes.SelectedTab == tpMonochrome)
                HMap.BuildMonochrome(left, top, right, bottom,
                    monochromeColor,
                    smin, smax,
                    (int)nudMonochromeRepeat.Value
                    );
            else if (tcThemes.SelectedTab == tpBytes)
                HMap.BuildHLBytes(left, top, right, bottom,
                    hiByteMultiplier,
                    loByteMultiplier,
                    smin, smax,
                    (int)nudByteRepeat.Value
                    );
            else
                HMap.BuildSpectrum(left, top, right, bottom,
                    spectrumColors,
                    smin, smax,
                    (int)nudSpectrumRepeat.Value
                    );
        }

        private void btnLoadHMap_Click(object sender, EventArgs e)//Ok
        {
            dlgOpen.FileName = Path.GetFileName(HMap.URL);
            if (HMap.URL != "")
                dlgOpen.InitialDirectory = Path.GetFullPath(HMap.URL).Replace(Path.GetFileName(HMap.URL), "");
            if (dlgOpen.ShowDialog() != DialogResult.OK)
                return;
            lockMouse = true;
            LoadHMap(dlgOpen.FileName);
        }

        private bool LoadHMap(String fileName, bool switchto = true)//
        {
            lockDrawing = true;

            int width    = 0;
            int height   = 0;
            int channels = 0;
            int bitDepth = 0;
            // PNG
            PngReader PNG = null;
            try
            {
                PNG = new PngReader(fileName);
                width    = PNG.Width;
                height   = PNG.Height;
                channels = PNG.Channels;
                bitDepth = PNG.BitDepth;
                bBuffer  = PNG.ScanLine;
                PNG.Dispose();
            }
            // Other formats
            catch (Exception exc)
            {
                PNG?.Dispose();
                try
                {
                    var img = new Bitmap(fileName);
                    width = img.Width;
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
                    MessageBox.Show("Unable to open file:\r\n" + exc.Message, "Load height map error");
                    return false;
                }
            }
            // Show controls
            lblFileFormat.Visible                = (bitDepth != 8 || 1 < channels);
            cbbLevelFormat8bit.Visible           = (bitDepth == 8 && 1 < channels);
            chbLevelByteBigLittleIndian.Visible  = (bitDepth != 8 && 1 < bitDepth);
            chbLevelPixelBigLittleIndian.Visible = (bitDepth <  8);
            // Store Channels and BlockSize
            chbLevelByteBigLittleIndian.Tag = channels * bitDepth; // Store block size
            // Unpack
            HMap.SetSize(width, height);
            HMap.URL = fileName;
            BuildLevels();
            HistoryClear();
            lockDrawing = false;
            FinishHMapLoading(switchto);
            return true;
        }

        private void FinishHMapLoading(bool switchto = true)
        {
            lblHMapSizes.Text = HMap.Width + XYSpliter + HMap.Height;
            HMap.BuildStatistics(0, -1);
            ShowStatistics();
            BuildSpectrum(0, 0, -1, -1);
            if (switchto)
                chbShowHMap.Checked = true;
            zoom = 0;
            ZoomFinish(0, 0);
        }

        private void btnLoadTMap_Click(object sender, EventArgs e)//Ok
        {
            dlgOpen.FileName = Path.GetFileName(TMap.URL);
            if (TMap.URL != "")
                dlgOpen.InitialDirectory = Path.GetFullPath(TMap.URL).Replace(Path.GetFileName(TMap.URL), "");
            if (dlgOpen.ShowDialog() == DialogResult.OK)
                LoadTMap(dlgOpen.FileName);
        }

        private bool LoadTMap(String fileName, bool switchTo = true)
        {
            try
            {
                var img = Image.FromFile(fileName);
                var bmp = new Bitmap(img);
                TMap.SetSize(bmp.Width, bmp.Height);
                var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
                Marshal.Copy(data.Scan0, TMap.Pixels, 0, bmp.Width * bmp.Height);
                bmp.UnlockBits(data);
                TMap.URL = fileName;
                FinishTMapLoading(switchTo);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Unable to load file:\r\n\"" + fileName + "\"\r\n" + exc.Message, "Load topological map error");
                return false;
            }
            return true;
        }

        private void btnTMapGenerate_Click(object sender, EventArgs e) => GenerateTMap(HMap.Width, HMap.Height, true);
        private void GenerateTMap(int width, int height, bool switchTo)
        {
            TMap.SetSize(width, height);
            int x, y;
            // Clear
            for (y = 0; y < height; y++)
                for (x = 0; x < width; x++)
                    TMap.Pixels[x + y * width] = -0x7F696968;
            // 10x10
            for (x = 0; x < width;  x += 10) for (y = 0; y < height; y++) TMap.Pixels[x + y * TMap.Width] = -0x7FA9A9A8;
            for (y = 0; y < height; y += 10) for (x = 0; x < width;  x++) TMap.Pixels[x + y * TMap.Width] = -0x7FA9A9A8;
            // 100x100
            for (x = 0; x < width;  x += 100) for (y = 0; y < height; y++) TMap.Pixels[x + y * TMap.Width] = -0x7FD3D3D2;
            for (y = 0; y < height; y += 100) for (x = 0; x < width;  x++) TMap.Pixels[x + y * TMap.Width] = -0x7FD3D3D2;
            // Apply
            TMap.URL = "";
            FinishTMapLoading(switchTo);
        }

        private void FinishTMapLoading(bool switchTo = true)
        {
            lblTMapSizes.Text = TMap.Width + XYSpliter + TMap.Height;
            if (switchTo)
                if (chbShowTMap.Checked)
                    Invalidate();
                else
                    chbShowTMap.Checked = true;
        }

        private void tsmCreat_Click(object sender, EventArgs e)
        {
            if (sender == tsmCreateEmpty)
            {
                var dlgCreate = new FormCreate();
                if (dlgCreate.ShowDialog() != DialogResult.OK)
                    return;
                HMap.SetSize(dlgCreate.mapWidth, dlgCreate.mapHeight);
            }
            else
                CreateGradientMap(sender == tsmCreateSerpantine);
            HistoryClear();
            lblFileFormat.Visible =
            cbbLevelFormat8bit.Visible =
            cbbLevelFormat16bit.Visible =
            chbLevelByteBigLittleIndian.Visible = false;
            FinishHMapLoading();
        }

        private void tsmiClear_Click(object sender, EventArgs e)
        {
            int x, y;
            historyRecord = new HistoryRecord(HMap, 0, 0, HMap.Width - 1, HMap.Height - 1);
            HistoryAdd();
            for (y = 0; y < HMap.Height; y++)
                for (x = 0; x < HMap.Width; x++)
                    HMap.Levels[x, y] = 0;
            FinishHMapLoading();
        }

        private void btnSaveHMap_Click(object sender, EventArgs e)//Ok
        {
            // Choose file name
            dlgSave.FileName = Path.GetFileNameWithoutExtension(HMap.URL);
            dlgSave.Filter = "All files (*.*)|*.*|Portable Network Graphics (*.png)|*.png";
            dlgSave.FilterIndex = 2;
            if (HMap.URL != "")
                dlgSave.InitialDirectory = Path.GetFullPath(HMap.URL).Replace(Path.GetFileName(HMap.URL), "");
            if (dlgSave.ShowDialog() != DialogResult.OK)
                return;
            // Pack
            SavePNG(sender == btnSaveHMap);
            HMap.URL = dlgSave.FileName;
        }

        private void SavePNG(bool full)
        {
            int x, y, i = 0;
            byte[] buffer = new byte[(HMap.Width * HMap.Height) << (full ? 1 : 0)];
            for (y = 0; y < HMap.Height; y++)
                for (x = 0; x < HMap.Width; x++)
                {
                    buffer[i++] = (byte)(HMap.Levels[x, y] >> 8);
                    if (full)
                        buffer[i++] = (byte)(HMap.Levels[x, y] & 255);
                }
           new PngWriter(dlgSave.FileName, buffer, HMap.Width, HMap.Height, 1, (full ? 16 : 8), PngColorType.Gray);
        }

        private void tsmiExportView_Click(object sender, EventArgs e)
        {
            // Choose file name
            dlgSave.FileName = Path.GetFileNameWithoutExtension(HMap.URL);
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
            int extIdx = ExportExts.IndexOf(Path.GetExtension(dlgSave.FileName));
            if (extIdx < 0)
                extIdx = 1; // Ok, lets play this game

            // Create image
            int x, y, b, p = 0;
            int bytesPerRow = (HMap.Width * 3 + 3) & 0xFFFFFC; // block by 4 bytes
            byte[] buffer = new byte[bytesPerRow * HMap.Height];
            for (y = 0; y < HMap.Height; y++)
            {
                b = y * bytesPerRow; // byte to block correction
                for (x = HMap.Width; 0 < x; x--)
                {
                    buffer[b++] = (byte)(HMap.Pixels[p]      );
                    buffer[b++] = (byte)(HMap.Pixels[p] >>  8);
                    buffer[b++] = (byte)(HMap.Pixels[p] >> 16);
                    p++;
                }
            }
            // Save
            Bitmap img = new Bitmap(HMap.Width, HMap.Height, bytesPerRow, PixelFormat.Format24bppRgb, Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0));
            img.Save(dlgSave.FileName, ExportFormats[extIdx]);
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            var dlgResize = new FormResize(HMap.Width, HMap.Height);
            if (dlgResize.ShowDialog() != DialogResult.OK)
                return;
            if (HMap.Width == dlgResize.mapWidth && HMap.Height == dlgResize.mapHeight)
                return;
            // Register
            historyRecord = new HistoryRecord(HMap, 0, 0, HMap.Width - 1, HMap.Height - 1, true);
            HistoryAdd();
            // Transit
            HMap.SetSize(dlgResize.mapWidth, dlgResize.mapHeight, null, true);
            // Finish
            lblFileFormat.Visible =
            cbbLevelFormat8bit.Visible =
            cbbLevelFormat16bit.Visible =
            chbLevelByteBigLittleIndian.Visible = false;
            FinishHMapLoading();
        }
        #endregion

        #region Mouse
        int msX0, msX, mapX;
        int msY0, msY, mapY;
        UInt16 levelValue;

        private void pbHMap_MouseDown(object sender, MouseEventArgs e)//O
        {
            msX0 = e.X;
            msY0 = e.Y;
            lockMouse = false;
            ToolAction(sender, e, false);
        }

        private void pbHMap_MouseMove(object sender, MouseEventArgs e)
        {
            msX = e.X - hScrollBar.Left;
            msY = e.Y - vScrollBar.Top;
            mapX = (msX + hScrollBar.Value) >> zoom;
            mapY = (msY + vScrollBar.Value) >> zoom;
            ToolAction(sender, e, true);
        }

        private void ToolAction(object sender, MouseEventArgs e, bool moving)
        {
            if (lockMouse) return;
            // Get tool, Pan, Switch
            int toolID = 0;
            if (e.Button != MouseButtons.None)
            {
                object oID =
                    (e.Button == MouseButtons.Left)     ? btnToolLMB.Tag  :
                    (e.Button == MouseButtons.Right)    ? btnToolRMB.Tag  :
                    (e.Button == MouseButtons.Middle)   ? btnToolMMB.Tag  :
                    (e.Button == MouseButtons.XButton1) ? btnToolX1MB.Tag :
                    (e.Button == MouseButtons.XButton2) ? btnToolX2MB.Tag :
                    null;
                if (oID != null) toolID = (int)oID;

                if (toolID < 4)
                {
                    if (moving)
                    {
                        // Pan
                        if (toolID == 0)
                        {
                            // Calculate shift
                            int scX = hScrollBar.Value + (msX0 - e.X);
                            int scY = vScrollBar.Value + (msY0 - e.Y);
                            bool h = ScrollValueCheckAndSet(hScrollBar, ref scX);
                            bool v = ScrollValueCheckAndSet(vScrollBar, ref scY);
                            // Apply
                            if (h | v)
                            {
                                msX0 = e.X;
                                msY0 = e.Y;
                                hScrollBar.Value = scX;
                                vScrollBar.Value = scY;
                                ScrollBar_Scroll(null, null);
                            }
                        }
                    }
                    // Switching active layer
                    else if (toolID == 1)
                        chbShowHMap.Checked = !chbShowHMap.Checked;
                    // Undo
                    else if (toolID == 2)
                        btnHistoryBackward_Click(null, null);
                    // Redo
                    else if (toolID == 3)
                        btnHistoryForward_Click(null, null);
                    return;
                }
            }
            // Calculate point on map
            int mapW = HMap.Width  - 1;
            int mapH = HMap.Height - 1;
            // Skip outside
            if (mapX < 0 || mapY < 0 || mapW < mapX || mapH < mapY)
            {
                if (moving && lblPointerLevel.Enabled)
                    FormSHME_MouseLeave(sender, e);
                return;
            }
            else
                lblPointerLevel.Enabled = true;
            // Show level under pointer
            UInt16 mapXYLevel = HMap.Levels[mapX, mapY];
            if (moving)
            {
                lblPointerPosition.Text = mapX + PointerSpliter + mapY;
                lblPointerLevel.Text = mapXYLevel.ToString() + " x" + mapXYLevel.ToString("X4");
                if (e.Button == MouseButtons.None)
                {
                    int sz = Math.Max((int)nudSlot1Size.Value, Math.Max((int)nudSlot2Size.Value, (int)nudSlot3Size.Value)) << zoom;
                    Invalidate(new Rectangle(
                        hScrollBar.Left,
                        vScrollBar.Top,
                        hScrollBar.Right,
                        vScrollBar.Bottom));
                }
            }

            // No drawing?
            if (toolID < 4 || chbShowTMap.Checked) return;

            // Recalculate tool ID and Index
            toolID -= 4;
            int toolIdx = toolID % 3;
            toolID /= 3;

            // Probe
            if (toolID == 0)//Ok
            {
                     if (toolIdx == 0) nudSlot1Value.Value = mapXYLevel;
                else if (toolIdx == 1) nudSlot2Value.Value = mapXYLevel;
                else                   nudSlot3Value.Value = mapXYLevel;
                return;
            }

            int y, x;
            // Start history record
            if (historyRecord == null)
            {
                for (y = 0; y < HMap.Height; y++)
                    for (x = 0; x < HMap.Width; x++)
                        HMap.Changed[x, y] = 0;
                historyRecord = new HistoryRecord(HMap, mapX, mapY, mapX, mapY);
            }

            // Get brush
            int[,] brush = (toolIdx == 0)
                ? tool1Brush : (toolIdx == 1)
                ? tool2Brush
                : tool3Brush;
            // Get tool value
            UInt16 value = (toolIdx == 0)
                ? (UInt16)nudSlot1Value.Value : (toolIdx == 1)
                ? (UInt16)nudSlot2Value.Value
                : (UInt16)nudSlot3Value.Value;
            // Get tool size
            int size = (toolIdx == 0)
                ? (int)nudSlot1Size.Value : (toolIdx == 1)
                ? (int)nudSlot2Size.Value
                : (int)nudSlot3Size.Value;

            // Get region
            int iR = mapX + (size >> 1);
            int iB = mapY + (size >> 1);
            int mapL = iR - size + 1;
            int mapT = iB - size + 1;
            // Limit region
            int iL = (mapL < 0) ? 0 : mapL;
            int iT = (mapT < 0) ? 0 : mapT;
            if (mapW < iR) iR = mapW;
            if (mapH < iB) iB = mapH;

            // Pencil, Level
            if (toolID < 3)
            {
                // Level probe
                if (toolID == 2)
                    value = (moving)
                        ? levelValue
                        : (levelValue = mapXYLevel); // Store at first contact and use
                for (y = 0; y < size; y++)
                    for (x = 0; x < size; x++)
                        brush[x, y] = value;
            }
            // Add, Sub
            else if (toolID < 5)
            {
                int v, d = (toolID == 4) ? -value : value;
                for (y = iT; y <= iB; y++)
                    for (x = iL; x <= iR; x++)
                    {
                        v = historyRecord.Clip[x, y] + d;
                        brush[x - mapL, y - mapT] = (65535 < v) ? 65535 : (v < 0) ? 0 : v;
                    }
            }
            // Smooth
            else
            {
                int v, h;
                for (y = iT; y <= iB; y++)
                    for (x = iL; x <= iR; x++)
                    {
                        v = h = historyRecord.Clip[x, y];
                        v += (0 <    x) ? historyRecord.Clip[x - 1, y    ] : h;
                        v += (0 <    y) ? historyRecord.Clip[x,     y - 1] : h;
                        v += (x < mapW) ? historyRecord.Clip[x + 1, y    ] : h;
                        v += (y < mapH) ? historyRecord.Clip[x,     y + 1] : h;
                        brush[x - mapL, y - mapT] = (v + 2) / 5; // +2 for roundup
                    }
            }

            // Get tool shape
            bool bar = (toolIdx == 0)
                ? chbSlot1Shape.Checked : (toolIdx == 1)
                ? chbSlot2Shape.Checked
                : chbSlot3Shape.Checked;
            // Get mask
            float[,] mask = (toolIdx == 0)
                ? tool1ForceMask : (toolIdx == 1)
                ? tool2ForceMask
                : tool3ForceMask;

            // Put brush
            float k, f = (toolID == 5) ? (float)value / 65535 : 1;
            for (y = iT; y <= iB; y++)
                for (x = iL; x <= iR; x++)
                    if (HMap.Changed[x, y] < mask[x - mapL, y - mapT])
                    {
                        k = mask[x - mapL, y - mapT] * f;
                        HMap.Levels[x, y] = (UInt16)(brush[x - mapL, y - mapT] * k + historyRecord.Clip[x, y] * (1 - k));
                        HMap.Changed[x, y] = mask[x - mapL, y - mapT];
                    }

            // Update map
            historyRecord.Check(iL, iT, iR, iB);
            x = HMap.MaxLevel;
            y = HMap.MinLevel;
            HMap.BuildStatistics(iT, iB);
            if ((chbLimitMax.Checked || chbLimitMin.Checked) && (x != HMap.MaxLevel || y != HMap.MinLevel))
            {
                BuildSpectrum(0, 0, -1, -1);
                Invalidate(new Rectangle(
                    hScrollBar.Left,
                    vScrollBar.Top,
                    hScrollBar.Right,
                    vScrollBar.Bottom));
            }
            else
            {
                BuildSpectrum(iL, iT, iR, iB);
                Invalidate(/*new Rectangle(
                    hScrollBar.Left + (iL << zoom) - hScrollBar.Value,
                    vScrollBar.Top  + (iT << zoom) - vScrollBar.Value,
                    size << zoom,
                    size << zoom)*/);
            }
            ShowStatistics();
        }

        private void FormSHME_MouseUp(object sender, MouseEventArgs e) => HistoryAdd();

        private void FormSHME_MouseEnter(object sender, EventArgs e)
        {
            pnlToolSelect.Visible = false;
            cbbZoom.Focus();
        }

        private void FormSHME_MouseLeave(object sender, EventArgs e)//Ok
        {
            lblPointerPosition.Text = "-" + PointerSpliter + "-";
            lblPointerLevel.Enabled = false;
            lblPointerLevel.Text = "-";
            Invalidate(new Rectangle(
                hScrollBar.Left,
                vScrollBar.Top,
                hScrollBar.Right,
                vScrollBar.Bottom));
        }
        #endregion

        #region Form
        private int CheckInteger(String value, int min, int max, int def) => (Int32.TryParse(value, out int v)) ? (min <= v && v <= max) ? v : def : def;

        private String OptionsLoad()
        {
            try
            {
                using (StreamReader file = File.OpenText("SHME.ini"))
                {
                    int v, i;
                    while (!file.EndOfStream)
                    {
                        String line = file.ReadLine();
                        //Decompress
                        String[] rec = line.Split('\t');
                        // Skip empty
                        if (rec.Length < 2)
                            continue;
                        String option = rec[0],
                               value = rec[1];
                        switch (option)
                        {
                            //* Pages
                            case "Theme":
                                i = tcThemes.TabPages.Count - 1;
                                for (; 0 < i; i--)
                                    if (tcThemes.TabPages[i].Name.Contains(value))
                                        break;
                                tcThemes.SelectedIndex = i;
                                break;
                            case "MonochromeRepeat": nudMonochromeRepeat.Value   = CheckInteger(value, 1, 32, 1); break;
                            case "HiLoByteRepeat":   nudByteRepeat.Value         = CheckInteger(value, 1, 32, 1); break;
                            case "SpectrumRepeat":   nudSpectrumRepeat.Value     = CheckInteger(value, 1, 32, 1); break;
                            case "MonochromeColor": btnMonochromeColor.BackColor = (Int32.TryParse(value, out v)) ? Color.FromArgb(v) : Color.White;   break;
                            case "SpectrumColor0":  btnSpectrumColor0.BackColor  = (Int32.TryParse(value, out v)) ? Color.FromArgb(v) : Color.Black;   break;
                            case "SpectrumColor1":  btnSpectrumColor1.BackColor  = (Int32.TryParse(value, out v)) ? Color.FromArgb(v) : Color.Blue;    break;
                            case "SpectrumColor2":  btnSpectrumColor2.BackColor  = (Int32.TryParse(value, out v)) ? Color.FromArgb(v) : Color.Cyan;    break;
                            case "SpectrumColor3":  btnSpectrumColor3.BackColor  = (Int32.TryParse(value, out v)) ? Color.FromArgb(v) : Color.Green;   break;
                            case "SpectrumColor4":  btnSpectrumColor4.BackColor  = (Int32.TryParse(value, out v)) ? Color.FromArgb(v) : Color.Yellow;  break;
                            case "SpectrumColor5":  btnSpectrumColor5.BackColor  = (Int32.TryParse(value, out v)) ? Color.FromArgb(v) : Color.Red;     break;
                            case "SpectrumColor6":  btnSpectrumColor6.BackColor  = (Int32.TryParse(value, out v)) ? Color.FromArgb(v) : Color.Magenta; break;
                            case "SpectrumColor7":  btnSpectrumColor7.BackColor  = (Int32.TryParse(value, out v)) ? Color.FromArgb(v) : Color.White;   break;
                            case "SpectrumColor8":  btnSpectrumColor8.BackColor  = (Int32.TryParse(value, out v)) ? Color.FromArgb(v) : Color.Black;   break;
                            // Hi/Lo Byte
                            case "HiLoByteHiHex": tbByteHi.Text = value; break;
                            case "HiLoByteLoHex": tbByteLo.Text = value; break;

                            //* Tools
                            // Preset
                            case "Toolset":
                                int toolL = 0, toolM = 0, toolR = 0, toolX1 = 0, toolX2 = 0;
                                rec = value.Split(new String[] { ", " }, StringSplitOptions.None);
                                for (i = 0; i < ToolControls.Length; i++)
                                {
                                    if (ToolControls[i].Name.Contains(rec[1])) toolL  = i;
                                    if (ToolControls[i].Name.Contains(rec[2])) toolM  = i;
                                    if (ToolControls[i].Name.Contains(rec[3])) toolR  = i;
                                    if (ToolControls[i].Name.Contains(rec[4])) toolX1 = i;
                                    if (ToolControls[i].Name.Contains(rec[5])) toolX2 = i;
                                }
                                if (rec[0] == "0")
                                {
                                    ToolXMBSelect(btnToolLMB,  toolL);
                                    ToolXMBSelect(btnToolMMB,  toolM);
                                    ToolXMBSelect(btnToolRMB,  toolR);
                                    ToolXMBSelect(btnToolX1MB, toolX1);
                                    ToolXMBSelect(btnToolX2MB, toolX2);
                                }
                                else
                                    AddToolset(toolL, toolM, toolR, toolX1, toolX2);
                                break;
                            // Slots
                            case "Slot1Value": nudSlot1Value.Value      = CheckInteger(value, 0, 65535, 0); break;
                            case "Slot2Value": nudSlot2Value.Value      = CheckInteger(value, 0, 65535, 0); break;
                            case "Slot3Value": nudSlot3Value.Value      = CheckInteger(value, 0, 65535, 0); break;
                            case "Slot1Size":  nudSlot1Size.Value       = CheckInteger(value, 1, (int)nudSlot1Size.Maximum, 1); break;
                            case "Slot2Size":  nudSlot2Size.Value       = CheckInteger(value, 1, (int)nudSlot2Size.Maximum, 1); break;
                            case "Slot3Size":  nudSlot3Size.Value       = CheckInteger(value, 1, (int)nudSlot3Size.Maximum, 1); break;
                            case "Slot1Force": btnSlot1Force.ImageIndex = CheckInteger(value, 0, ilToolForce.Images.Count - 1, 0); break;
                            case "Slot2Force": btnSlot2Force.ImageIndex = CheckInteger(value, 0, ilToolForce.Images.Count - 1, 0); break;
                            case "Slot3Force": btnSlot3Force.ImageIndex = CheckInteger(value, 0, ilToolForce.Images.Count - 1, 0); break;
                            case "Slot1Shape": chbSlot1Shape.Checked    = (value == "True"); break;
                            case "Slot2Shape": chbSlot2Shape.Checked    = (value == "True"); break;
                            case "Slot3Shape": chbSlot3Shape.Checked    = (value == "True"); break;

                            //* Files
                            case "FileHMap": HMap.URL = value; break;
                            case "FileTMap": TMap.URL = value; break;
                            case "Level8bit":  cbbLevelFormat8bit. SelectedIndex = CheckInteger(value, 0, cbbLevelFormat8bit.Items.Count  - 1, 0); break;
                            case "Level16bit": cbbLevelFormat16bit.SelectedIndex = CheckInteger(value, 0, cbbLevelFormat16bit.Items.Count - 1, 0); break;
                            case "LevelBLIByte":  chbLevelByteBigLittleIndian.Checked  = (value == "True"); break;
                            case "LevelBLIPixel": chbLevelPixelBigLittleIndian.Checked = (value == "True"); break;

                            case "ViewGrid": chbGrid.Checked = (value == "True"); break;

                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
            return "";
        }

        private void cbbGrid_CheckedChanged(object sender, EventArgs e) => Invalidate();

        private void FormSHME_Paint(object sender, PaintEventArgs e)
        {
            if (lockDrawing) return;
            int l = e.ClipRectangle.Left   - hScrollBar.Left,
                t = e.ClipRectangle.Top    - vScrollBar.Top,
                r = e.ClipRectangle.Right  - hScrollBar.Left + hScrollBar.Value,
                b = e.ClipRectangle.Bottom - vScrollBar.Top  + vScrollBar.Value;
            // Limit
            if (l < 0) l = 0;
            if (t < 0) t = 0;
            l += hScrollBar.Value;
            t += vScrollBar.Value;
            if ((HMap.Width  << zoom) <= r) r = (HMap.Width  << zoom) - 1;
            if ((HMap.Height << zoom) <= b) b = (HMap.Height << zoom) - 1;
            int w = r - l + 1,
                h = b - t + 1;
            // Optimisation
            if (w < 1 || h < 1) return;

            int x, y, ix, iy, offset = 0;
            int[] buffer = new int[w * h];
            // Draw TMap
            if (chbShowTMap.Checked)
            {
                int tw = TMap.Width,  hw = HMap.Width  - 1,
                    th = TMap.Height, hh = HMap.Height - 1;
                int zhw = hw << zoom,
                    zhh = hh << zoom;
                // Normal (TMapSize * proportion + 1)
                if (((tw % hw == 0) && (th % hh == 0)) || ((hw % tw == 0) && (hh % th == 0)))
                {
                    int delta = 1 << zoom >> 1;
                    int ld = (l < delta) ? delta : l;
                    int rd = (r - delta < zhw) ? r : zhw + delta - 1;
                    int bd = (b - delta < zhh) ? b : zhh + delta - 1;
                    if (t < delta)
                        offset += ((y = delta) - t) * w;
                    else
                        y = t;
                    for (; y <= bd; y++)
                    {
                        iy = ((y - delta) * th / zhh) * tw;
                        offset += ld - l;
                        for (x = ld; x <= rd; x++)
                            buffer[offset++] = TMap.Pixels[((x - delta) * tw / zhw) + iy];
                        offset += r - rd;
                    }
                }
                // Other
                else
                {
                    hw++;
                    hh++;
                    for (y = t; y <= b; y++)
                    {
                        iy = (y * th / hh >> zoom) * tw;
                        for (x = l; x <= r; x++)
                            buffer[offset++] = TMap.Pixels[((x * tw / hw) >> zoom) + iy];
                    }
                }
            }
            // Draw HMap
            else
                for (y = t; y <= b; y++)
                {
                    iy = (y >> zoom) * HMap.Width;
                    for (x = l; x <= r; x++)
                        buffer[offset++] = HMap.Pixels[(x >> zoom) + iy];
                }
            // Add grid
            if (chbGrid.Checked && (2 < zoom))
            {
                int step = 1 << zoom,
                    mask = step - 1;
                // Horizontal
                for (y = mask - t & mask; y < h; y += step)
                {
                    offset = y * w;
                    for (x = l & 1; x < w; x += 2)
                        buffer[offset + x] = (0 < (x & 2)) ? GridColor0 : GridColor1;
                }
                // Vertical
                for (y = t & 1; y < h; y += 2)
                {
                    offset = y * w;
                    for (x = mask - l & mask; x < w; x += step)
                        buffer[offset + x] = (0 < (y & 2)) ? GridColor0 : GridColor1;
                }
            }
            // Transfer
            Bitmap img = new Bitmap(w, h, w << 2, PixelFormat.Format32bppRgb, Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0));
            e.Graphics.DrawImageUnscaled(img,
                l + hScrollBar.Left - hScrollBar.Value,
                t + vScrollBar.Top  - vScrollBar.Value
                );
            /**/
            if (!lblPointerLevel.Enabled)
                return;
            DrawBrushContour(e.Graphics, (int)nudSlot1Size.Value, chbSlot1Shape.Checked);
            DrawBrushContour(e.Graphics, (int)nudSlot2Size.Value, chbSlot2Shape.Checked);
            DrawBrushContour(e.Graphics, (int)nudSlot3Size.Value, chbSlot3Shape.Checked);
            /**/
        }

        private void DrawBrushContour(Graphics g, int size, bool shape)
        {
            int ix = ((mapX - ((size - 1) >> 1)) << zoom) - hScrollBar.Value;
            int iy = ((mapY - ((size - 1) >> 1)) << zoom) - vScrollBar.Value;
            if (shape)
                g.DrawRectangle(
                    new Pen(Color.Black),
                    ix + hScrollBar.Left,
                    iy + vScrollBar.Top,
                    (size << zoom) - 1, (size << zoom) - 1);
            else
                g.DrawEllipse(
                    new Pen(Color.Black),
                    ix + hScrollBar.Left,
                    iy + vScrollBar.Top,
                    (size << zoom) - 1, (size << zoom) - 1
                    );
        }

        private void FormSHME_Resize(object sender, EventArgs e)//
        {
            bool h = ResizeScrollBar(hScrollBar, hScrollBar.Width);
            bool v = ResizeScrollBar(vScrollBar, vScrollBar.Height);
            if (h | v)
                ScrollBar_Scroll(null, null);
        }

        private bool ResizeScrollBar(ScrollBar scrollBar, int largeChange)
        {
            scrollBar.LargeChange = largeChange;
            scrollBar.Enabled = (scrollBar.Maximum >= scrollBar.LargeChange);
            int v = scrollBar.Value;
            return ScrollValueCheckAndSet(scrollBar, ref v, true);
        }

        /// <summary>
        /// Check range of value, apply if needed and returns if it's new
        /// </summary>
        /// <returns>Value not equal</returns>
        private bool ScrollValueCheckAndSet(ScrollBar scrollBar, ref int value, bool apply = false)//Ok
        {
            if (scrollBar.Maximum + 1 < value + scrollBar.LargeChange) value = scrollBar.Maximum - scrollBar.LargeChange + 1;
            if (value < 0)
                value = 0;
            if (value == scrollBar.Value) return false;
            if (apply) scrollBar.Value = value;
            return true;
        }

        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)//
        {
            if (e != null)
                if (e.OldValue == e.NewValue)
                    return;
            Invalidate();
        }

        private void pnlCorner_DoubleClick(object sender, EventArgs e) => new AboutBox().ShowDialog();

        private void FormSHME_FormClosed(object sender, FormClosedEventArgs e) => OptionsSave();

        private void OptionsSave()
        {
            using (StreamWriter file = File.CreateText("SHME.ini"))
            {
                //* Pages
                file.WriteLine("Theme\t" + tcThemes.SelectedTab.Name.Remove(0,2));
                // Monochrome
                file.WriteLine("MonochromeRepeat\t" + nudMonochromeRepeat.Value);
                file.WriteLine("MonochromeColor\t" + btnMonochromeColor.BackColor.ToArgb());
                // Hi/Lo Byte
                file.WriteLine("HiLoByteRepeat\t" + nudByteRepeat.Value);
                file.WriteLine("HiLoByteHiHex\t" + tbByteHi.Text);
                file.WriteLine("HiLoByteLoHex\t" + tbByteLo.Text);
                // Spectrum
                file.WriteLine("SpectrumRepeat\t" + nudSpectrumRepeat.Value);
                file.WriteLine("SpectrumColor0\t" + btnSpectrumColor0.BackColor.ToArgb());
                file.WriteLine("SpectrumColor1\t" + btnSpectrumColor1.BackColor.ToArgb());
                file.WriteLine("SpectrumColor2\t" + btnSpectrumColor2.BackColor.ToArgb());
                file.WriteLine("SpectrumColor3\t" + btnSpectrumColor3.BackColor.ToArgb());
                file.WriteLine("SpectrumColor4\t" + btnSpectrumColor4.BackColor.ToArgb());
                file.WriteLine("SpectrumColor5\t" + btnSpectrumColor5.BackColor.ToArgb());
                file.WriteLine("SpectrumColor6\t" + btnSpectrumColor6.BackColor.ToArgb());
                file.WriteLine("SpectrumColor7\t" + btnSpectrumColor7.BackColor.ToArgb());
                file.WriteLine("SpectrumColor8\t" + btnSpectrumColor8.BackColor.ToArgb());

                //* Tools
                file.WriteLine("Toolset\t0, " + (
                    ToolControls[(int)btnToolLMB.Tag ].Name + ", " +
                    ToolControls[(int)btnToolMMB.Tag ].Name + ", " +
                    ToolControls[(int)btnToolRMB.Tag ].Name + ", " +
                    ToolControls[(int)btnToolX1MB.Tag].Name + ", " +
                    ToolControls[(int)btnToolX2MB.Tag].Name
                    ).Replace("btnTool", ""));
                // Preset
                for (int i = 0; i < cbbToolsetPreset.Items.Count; i++)
                    file.WriteLine("Toolset\t" + (i + 1) + ", " + cbbToolsetPreset.Items[i].ToString());
                // Slots
                file.WriteLine("Slot1Value\t" + nudSlot1Value.Value);
                file.WriteLine("Slot2Value\t" + nudSlot2Value.Value);
                file.WriteLine("Slot3Value\t" + nudSlot3Value.Value);
                file.WriteLine("Slot1Size\t"  + nudSlot1Size.Value);
                file.WriteLine("Slot2Size\t"  + nudSlot2Size.Value);
                file.WriteLine("Slot3Size\t"  + nudSlot3Size.Value);
                file.WriteLine("Slot1Force\t" + btnSlot1Force.ImageIndex);
                file.WriteLine("Slot2Force\t" + btnSlot2Force.ImageIndex);
                file.WriteLine("Slot3Force\t" + btnSlot3Force.ImageIndex);
                file.WriteLine("Slot1Shape\t" + chbSlot1Shape.Checked);
                file.WriteLine("Slot2Shape\t" + chbSlot2Shape.Checked);
                file.WriteLine("Slot3Shape\t" + chbSlot3Shape.Checked);

                //* Files
                file.WriteLine("FileHMap\t" + HMap.URL);
                file.WriteLine("FileTMap\t" + TMap.URL);
                file.WriteLine("Level8bit\t" + cbbLevelFormat16bit.SelectedIndex);
                file.WriteLine("Level16bit\t" + cbbLevelFormat16bit.SelectedIndex);
                file.WriteLine("LevelBLIByte\t" + chbLevelByteBigLittleIndian.Checked);
                file.WriteLine("LevelBLIPixel\t" + chbLevelPixelBigLittleIndian.Checked);

                file.WriteLine("ViewGrid\t" + chbGrid.Checked);
            }
        }
        #endregion

        #region Tools
        private void btnToolsetAdd_Click(object sender, EventArgs e) => cbbToolsetPreset.SelectedIndex = AddToolset(
                (int)btnToolLMB.Tag,
                (int)btnToolMMB.Tag,
                (int)btnToolRMB.Tag,
                (int)btnToolX1MB.Tag,
                (int)btnToolX2MB.Tag);
        private int AddToolset(int toolL, int toolM, int toolR, int toolX1, int toolX2)//Ok
        {
            int t = toolL + (toolM << 5) + (toolR << 10) + (toolX1 << 15) + (toolX2 << 20);
            if (!toolsetPresets.Contains(t))
            {
                cbbToolsetPreset.Items.Add((
                    ToolControls[toolL].Name  + ", " + 
                    ToolControls[toolM].Name  + ", " + 
                    ToolControls[toolR].Name  + ", " + 
                    ToolControls[toolX1].Name + ", " +
                    ToolControls[toolX2].Name
                    ).Replace("btnTool", ""));
                toolsetPresets.Add(t);
            }
            return toolsetPresets.IndexOf(t);
        }

        private void btnToolsetRemove_Click(object sender, EventArgs e) => RemoveToolset(cbbToolsetPreset.SelectedIndex);
        private bool RemoveToolset(int idx)//Ok
        {
            if (idx < 0 || toolsetPresets.Count <= idx) return false;
            cbbToolsetPreset.Items.RemoveAt(idx);
            btnToolsetRemove.Enabled = false;
            toolsetPresets.RemoveAt(idx);
            return true;
        }

        private void cbbToolsetPreset_SelectedIndexChanged(object sender, EventArgs e)//
        {
            btnToolsetRemove.Enabled = false;
            if (cbbToolsetPreset.SelectedIndex < 0)
                return;
            int IDs = toolsetPresets[cbbToolsetPreset.SelectedIndex];
            ToolXMBSelect(btnToolLMB,  IDs      );
            ToolXMBSelect(btnToolMMB,  IDs >>  5);
            ToolXMBSelect(btnToolRMB,  IDs >> 10);
            ToolXMBSelect(btnToolX1MB, IDs >> 15);
            ToolXMBSelect(btnToolX2MB, IDs >> 20);
            btnToolsetRemove.Enabled = true;
        }

        private void ToolXMBSelect(Button btnXMB, int ID)//O
        {
            ID = ID & 31;
            if (ToolControls.Length <= ID) ID = 0; // Unknown
            btnXMB.Image = ToolControls[ID].Image;
            btnXMB.Text = ToolControls[ID].Text;
            btnXMB.Tag = ID;
        }

        private void btnToolXMB_Click(object sender, EventArgs e)//Ok
        {
            Button btn = sender as Button;
            pnlToolSelect.Tag = sender;
            var r = btn.PointToClient(btn.Location);
            pnlToolSelect.Left = btn.Left + gbTools.Left - (btnToolPan.Left + 1);
            pnlToolSelect.Top  = btn.Top  + gbTools.Top  - (btnToolPan.Top  + 1) - btnToolPan.Height;
            pnlToolSelect.Visible = true;
            pnlToolSelect.Focus();
        }

        private void pnlToolSelect_Click(object sender, EventArgs e) => pnlToolSelect.Visible = false;
        private void btnTool_Click(object sender, EventArgs e)//Ok
        {
            ToolXMBSelect(pnlToolSelect.Tag as Button, (int)((sender as Button).Tag));
            cbbToolsetPreset.SelectedIndex = -1;
            pnlToolSelect.Visible = false;
        }

        private void nudTool1Value_ValueChanged(object sender, EventArgs e) => tbSlot1Hex.Text = ((int)nudSlot1Value.Value).ToString("X4");
        private void nudTool2Value_ValueChanged(object sender, EventArgs e) => tbSlot2Hex.Text = ((int)nudSlot2Value.Value).ToString("X4");
        private void nudTool3Value_ValueChanged(object sender, EventArgs e) => tbSlot3Hex.Text = ((int)nudSlot3Value.Value).ToString("X4");

        private void tbTool1Hex_TextChanged(object sender, EventArgs e) => HexTextCheck(tbSlot1Hex, 4, nudSlot1Value, tbTool1Hex_TextChanged);
        private void tbTool2Hex_TextChanged(object sender, EventArgs e) => HexTextCheck(tbSlot2Hex, 4, nudSlot2Value, tbTool2Hex_TextChanged);
        private void tbTool3Hex_TextChanged(object sender, EventArgs e) => HexTextCheck(tbSlot3Hex, 4, nudSlot3Value, tbTool3Hex_TextChanged);

        private void HexTextCheck(TextBox tb, int size, NumericUpDown nud, EventHandler e)//Ok
        {
            String s = tb.Text.ToUpper();
            int cursor = s.Length - tb.SelectionStart; // position from end
            // Check
            char[] csOut = new char[size];
            int lOut = size - 1;
            for (int i = s.Length - 1; 0 <= i && 0 <= lOut; i--)
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

        private void chbSlotXShape_CheckedChanged(object sender, EventArgs e) => (sender as CheckBox).BackgroundImage = ilToolShape.Images[(sender as CheckBox).Checked ? 1 : 0];

        private void lblTool1Hex_Click(object sender, EventArgs e) => lblSlot1Hex.Text = (tbSlot1Hex.Visible = !tbSlot1Hex.Visible) ? "0x" : "D";
        private void lblTool2Hex_Click(object sender, EventArgs e) => lblSlot2Hex.Text = (tbSlot2Hex.Visible = !tbSlot2Hex.Visible) ? "0x" : "D";
        private void lblTool3Hex_Click(object sender, EventArgs e) => lblSlot3Hex.Text = (tbSlot3Hex.Visible = !tbSlot3Hex.Visible) ? "0x" : "D";

        private void nudSlot1Size_ValueChanged(object sender, EventArgs e) => CreateToolForceMask(ref tool1ForceMask, ref tool1Brush, btnSlot1Force.ImageIndex, nudSlot1Size, chbSlot1Shape);
        private void nudSlot2Size_ValueChanged(object sender, EventArgs e) => CreateToolForceMask(ref tool2ForceMask, ref tool2Brush, btnSlot2Force.ImageIndex, nudSlot2Size, chbSlot2Shape);
        private void nudSlot3Size_ValueChanged(object sender, EventArgs e) => CreateToolForceMask(ref tool3ForceMask, ref tool3Brush, btnSlot3Force.ImageIndex, nudSlot3Size, chbSlot3Shape);

        private void btnTool1Force_Click(object sender, EventArgs e) => CreateToolForceMask(ref tool1ForceMask, ref tool1Brush, btnSlot1Force.ImageIndex += (1 < btnSlot1Force.ImageIndex) ? -2 : 1, nudSlot1Size, chbSlot1Shape);
        private void btnTool2Force_Click(object sender, EventArgs e) => CreateToolForceMask(ref tool2ForceMask, ref tool2Brush, btnSlot2Force.ImageIndex += (1 < btnSlot2Force.ImageIndex) ? -2 : 1, nudSlot2Size, chbSlot2Shape);
        private void btnTool3Force_Click(object sender, EventArgs e) => CreateToolForceMask(ref tool3ForceMask, ref tool3Brush, btnSlot3Force.ImageIndex += (1 < btnSlot3Force.ImageIndex) ? -2 : 1, nudSlot3Size, chbSlot3Shape);

        private void CreateToolForceMask(ref float[,] mask, ref int[,] brush, int forceShape, NumericUpDown nudSize, CheckBox chbShape)
        {
            int x, cx, size = (int)nudSize.Value;
            int y, cy, qr = size * size;
            int sz = size - 1;
            int hsize = sz >> 1;
            mask  = new float[size, size];
            brush = new   int[size, size];

            // Fast out
            if (size < 3 || (forceShape == 0 && chbShape.Checked))
            {
                for (y = 0; y < size; y++)
                    for (x = 0; x < size; x++)
                        mask[x, y] = 1;
                return;
            }

            // Square front
            if (forceShape == 0)
            {
                int r;
                for (y = 0; y <= hsize; y++)
                    for (x = 0; x <= hsize; x++)
                    {
                        cx = sz - (x << 1);
                        cy = sz - (y << 1);
                        r = (cx * cx + cy * cy);
                        if (r + 1 < qr)
                            mask[     x,      y] =
                            mask[     x, sz - y] =
                            mask[sz - x,      y] =
                            mask[sz - x, sz - y] = 1;
                    }
            }
            // Shere
            else if (forceShape == 1)
            {
                int r;
                for (y = 0; y <= hsize; y++)
                    for (x = 0; x <= hsize; x++)
                    {
                        cx = sz - (x << 1);
                        cy = sz - (y << 1);
                        r = (cx * cx + cy * cy);
                        if (r < qr)
                            mask[     x,      y] =
                            mask[     x, sz - y] =
                            mask[sz - x,      y] =
                            mask[sz - x, sz - y] = (float)(qr - r) / qr;
                    }
            }
            // Gaussian
            else
            {
                float r;
                for (y = 0; y <= hsize; y++)
                    for (x = 0; x <= hsize; x++)
                    {
                        cx = hsize - x;
                        cy = hsize - y;
                        r = (float)((cx * cx + cy * cy) << 2) / qr;
                        mask[     x,      y] =
                        mask[     x, sz - y] =
                        mask[sz - x,      y] =
                        mask[sz - x, sz - y] = (float)Math.Exp(-24 * r * r);
                    }
            }

            // Make square
            if (chbShape.Checked)
                for (y = 0; y < hsize; y++)
                    for (x = 0; x < hsize; x++)
                        mask[     x,      y] =
                        mask[     x, sz - y] =
                        mask[sz - x,      y] =
                        mask[sz - x, sz - y] = mask[Math.Min(x, y), hsize];
        }
        #endregion

        #region History
        private void btnHistoryBackward_Click(object sender, EventArgs e) => HistoryRoll(historyBackward, historyForward);

        private void btnHistoryForward_Click (object sender, EventArgs e) => HistoryRoll(historyForward,  historyBackward);

        private void HistoryAdd()//O
        {
            if (historyRecord == null) return;
            // Clear rofward
            if (0 < historyForward.Count)
            {
                btnHistoryForward.Enabled = false;
                historyForward.Clear();
            }
            if (!historyRecord.ResizeAction)
                historyRecord.Crop();
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
                    historyRecord.Rollback(HMap);
                    if (historyRecord.ResizeAction)
                        FinishHMapLoading();
                }
                else return;
            dest.Insert(0, historyRecord);
            if (HistoryMax < dest.Count) dest.RemoveAt(HistoryMax); // Limit history
            // Update
            btnHistoryBackward.Text = historyBackward.Count.ToString();
            btnHistoryForward. Text = historyForward. Count.ToString();
            btnHistoryBackward.Enabled = (0 < historyBackward.Count);
            btnHistoryForward. Enabled = (0 < historyForward. Count);
            // Show
            if (src != null && !historyRecord.ResizeAction)
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
            btnHistoryBackward.Enabled =
            btnHistoryForward. Enabled = false;
        }
        #endregion
    }
}
