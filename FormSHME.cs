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
        float[,] brush1ForceMask;
        float[,] brush2ForceMask;
        float[,] brush3ForceMask;
        int[,] brush1Buffer;
        int[,] brush2Buffer;
        int[,] brush3Buffer;

        public FormSHME()
        {
            InitializeComponent();

            hScrollBar.LargeChange = hScrollBar.Width;
            vScrollBar.LargeChange = vScrollBar.Height;

            // Bind and give Tool buttons ID
            ToolControls = new Button[]{
                // Core tools
                btnToolPan,
                btnToolSwitch,
                btnToolUndo,
                btnToolRedo,
                // Map tools
                btnToolProbe,
                btnToolPencil,
                btnToolFlatenUp,
                btnToolFlatenDown,
                btnToolFlaten, // Must cover FlatenUp and FlatenDown
                //
                btnToolAdd,
                btnToolSub, // Cover branch
                //
                btnToolSmooth,
                btnToolStretch};
            for (int i = 0; i < ToolControls.Length; i++)
                ToolControls[i].Tag = i;

            // Bind spectrum color boxes
            SpectrumColorControls = new Button[]{
                btnSpectrumColor0, btnSpectrumColor1, btnSpectrumColor2,
                btnSpectrumColor3, btnSpectrumColor4, btnSpectrumColor5,
                btnSpectrumColor6, btnSpectrumColor7, btnSpectrumColor8 };
            for (int i = 0; i < 9; i++)
            {
                SpectrumColorControls[i].Tag = i;
                spectrumColors[i] = (SpectrumColorControls[i].BackColor = SpectrumPresets[0, i]).ToArgb();
            }

            //* Preload presets
            cbbLevelFormat16bit.SelectedIndex = 0;
            cbbLevelFormat8bit. SelectedIndex = 0;
            // Tools
            ToolXMBSelect(btnToolLMB,  (int)btnToolPencil.Tag << 2);
            ToolXMBSelect(btnToolMMB,  (int)btnToolPan   .Tag << 2);
            ToolXMBSelect(btnToolRMB,  (int)btnToolProbe .Tag << 2);
            ToolXMBSelect(btnToolX1MB, (int)btnToolAdd   .Tag << 2);
            ToolXMBSelect(btnToolX2MB, (int)btnToolSub   .Tag << 2);

            //* Load options
            OptionsLoad();

            //* Postload checks
            DrawSpectrumSample();
            cbbZoom.SelectedIndex = ZoomMax;
            // Tool presets
            if (cbbToolsetPreset.Items.Count < 1)
            {
                AddToolset((int)btnToolPencil.Tag << 2, (int)btnToolPan.Tag << 2, (int)btnToolProbe .Tag << 2, (int)btnToolAdd   .Tag << 2, (int)btnToolSub   .Tag << 2);
                AddToolset((int)btnToolAdd   .Tag << 2, (int)btnToolPan.Tag << 2, (int)btnToolSub   .Tag << 2, (int)btnToolFlaten.Tag << 2, (int)btnToolSmooth.Tag << 2);
                AddToolset((int)btnToolFlaten.Tag << 2, (int)btnToolPan.Tag << 2, (int)btnToolSmooth.Tag << 2, (int)btnToolAdd   .Tag << 2, (int)btnToolSub   .Tag << 2);
            }

            // Create tool force shape
            CreateToolForceMask(ref brush1ForceMask, ref brush1Buffer, btnBrush1Distribution.ImageIndex, nudBrush1Width, nudBrush1Height, chbBrush1Shape);
            CreateToolForceMask(ref brush2ForceMask, ref brush2Buffer, btnBrush2Distribution.ImageIndex, nudBrush2Width, nudBrush2Height, chbBrush2Shape);
            CreateToolForceMask(ref brush3ForceMask, ref brush3Buffer, btnBrush3Distribution.ImageIndex, nudBrush3Width, nudBrush3Height, chbBrush3Shape);

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

        private void btnMonochromeColor_BackColorChanged(object sender, EventArgs e)
        {
            monochromeColor = btnMonochromeColor.BackColor.ToArgb();
            HMapOption_Changed(null, null);
        }

        private void PickColor_Click(object sender, EventArgs e)//Ok
        {
            if (dlgColor.ShowDialog() != DialogResult.OK)
                return;
            (sender as Control).BackColor = dlgColor.Color;
            // Update spectrum bar
            if ((sender as Button).Tag == null) return;
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
            // Block zooming with active tool
            if (historyRecord != null)
            {
                cbbZoom.SelectedIndex = ZoomMax - zoom;
                return;
            }
            zoom = z;
            // Zoom to tool
            if (lblPointerLevel.Enabled)
                ZoomFinish(
                    (mapX + (((hScrollBar.Width  >> 1) - msX) >> zoom)) / (float)HMap.Width,
                    (mapY + (((vScrollBar.Height >> 1) - msY) >> zoom)) / (float)HMap.Height
                    );
            // Zoom to screan center
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
            int toolID    = 0,
                toolBrush = 0;
            if (e.Button != MouseButtons.None)
            {
                object oID =
                    (e.Button == MouseButtons.Left)     ? btnToolLMB .Tag :
                    (e.Button == MouseButtons.Right)    ? btnToolRMB .Tag :
                    (e.Button == MouseButtons.Middle)   ? btnToolMMB .Tag :
                    (e.Button == MouseButtons.XButton1) ? btnToolX1MB.Tag :
                    (e.Button == MouseButtons.XButton2) ? btnToolX2MB.Tag :
                    null;
                if (oID != null) toolID = (int)oID;
                // Split ID and brush number
                toolBrush = toolID & 3;
                toolID = toolID >> 2;

                if (toolID < 4)
                {
                    // Skip before actual move
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
                    //int szW = Math.Max((int)nudBrush1Width .Value, Math.Max((int)nudBrush2Width .Value, (int)nudBrush3Width .Value)) << zoom;
                    //int szH = Math.Max((int)nudBrush1Height.Value, Math.Max((int)nudBrush2Height.Value, (int)nudBrush3Height.Value)) << zoom;
                    Invalidate(new Rectangle(
                        hScrollBar.Left,
                        vScrollBar.Top,
                        hScrollBar.Right,
                        vScrollBar.Bottom));
                }
            }

            // No drawing?
            if (toolID < 4 || chbShowTMap.Checked) return;

            // Probe
            if (toolID == (int)btnToolProbe.Tag)//Ok
            {
                     if (toolBrush == 0) nudBrush1ValueDecimal.Value = mapXYLevel;
                else if (toolBrush == 1) nudBrush2ValueDecimal.Value = mapXYLevel;
                else                     nudBrush3ValueDecimal.Value = mapXYLevel;
                return;
            }

            int y, x;
            // Start history record
            if (historyRecord == null)
                historyRecord = new HistoryRecord(HMap, mapX, mapY, mapX, mapY);

            // Get brush 
            int[,] brush;
            float[,] mask;
            UInt16 value;
            float force;
            int sizeW, sizeH;
            if (toolBrush == 0)
            {
                brush = brush1Buffer;
                mask  = brush1ForceMask;
                value = (UInt16)nudBrush1ValueDecimal.Value;
                force = (UInt16)nudBrush1ForceDecimal.Value;
                sizeW = (int)nudBrush1Width .Value;
                sizeH = (int)nudBrush1Height.Value;
            }
            else if (toolBrush == 1)
            {
                brush = brush2Buffer;
                mask  = brush2ForceMask;
                value = (UInt16)nudBrush2ValueDecimal.Value;
                force = (UInt16)nudBrush2ForceDecimal.Value;
                sizeW = (int)nudBrush2Width .Value;
                sizeH = (int)nudBrush2Height.Value;
            }
            else
            {
                brush = brush3Buffer;
                mask  = brush3ForceMask;
                value = (UInt16)nudBrush3ValueDecimal.Value;
                force = (UInt16)nudBrush3ForceDecimal.Value;
                sizeW = (int)nudBrush3Width .Value;
                sizeH = (int)nudBrush3Height.Value;
            }
            force = force / 65535;

            // Get region
            int iR = mapX + (sizeW >> 1);
            int iB = mapY + (sizeH >> 1);
            int mapL = iR - sizeW + 1;
            int mapT = iB - sizeH + 1;
            // Limit region
            int iL = (mapL < 0) ? 0 : mapL;
            int iT = (mapT < 0) ? 0 : mapT;
            if (mapW < iR) iR = mapW;
            if (mapH < iB) iB = mapH;

            // Pencil, FlatenUp, FlatenDown, Flaten
            if (toolID <= (int)btnToolFlaten.Tag)
            {
                // Level probe
                if (toolID != (int)btnToolPencil.Tag)
                    value = (moving)
                        ? levelValue
                        : (levelValue = mapXYLevel); // Store at first contact and use
                // Apply FlatenUp, FlatenDown
                if (toolID == (int)btnToolFlatenUp.Tag)
                    for (y = iT; y <= iB; y++)
                        for (x = iL; x <= iR; x++)
                            brush[x - mapL, y - mapT] = (historyRecord.Clip[x, y] < value) ? value : historyRecord.Clip[x, y];
                else if (toolID == (int)btnToolFlatenDown.Tag)
                    for (y = iT; y <= iB; y++)
                        for (x = iL; x <= iR; x++)
                            brush[x - mapL, y - mapT] = (value < historyRecord.Clip[x, y]) ? value : historyRecord.Clip[x, y];
                // Pencil, Flaten
                else
                    for (y = 0; y < sizeH; y++)
                        for (x = 0; x < sizeW; x++)
                            brush[x, y] = value;
            }
            // Add, Sub
            else if (toolID <= (int)btnToolSub.Tag)
            {
                int v, delta = (toolID == (int)btnToolSub.Tag) ? -value : value;
                for (y = iT; y <= iB; y++)
                    for (x = iL; x <= iR; x++)
                    {
                        v = historyRecord.Clip[x, y] + delta;
                        brush[x - mapL, y - mapT] = (65535 < v) ? 65535 : (v < 0) ? 0 : v;
                    }
            }
            // Smooth
            else if (toolID == (int)btnToolSmooth.Tag)
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
            // Stretch (closed Smooth)
            else
            {
                int v, h;
                for (y = iT; y <= iB; y++)
                    for (x = iL; x <= iR; x++)
                    {
                        v = h = historyRecord.Clip[x, y];
                        v += (0 <    x && iL < x) ? historyRecord.Clip[x - 1, y    ] : h;
                        v += (0 <    y && iT < y) ? historyRecord.Clip[x,     y - 1] : h;
                        v += (x < mapW && x < iR) ? historyRecord.Clip[x + 1, y    ] : h;
                        v += (y < mapH && y < iB) ? historyRecord.Clip[x,     y + 1] : h;
                        brush[x - mapL, y - mapT] = (v + 2) / 5; // +2 for roundup
                    }
            }

            // Put brush
            float k;
            for (y = iT; y <= iB; y++)
                for (x = iL; x <= iR; x++)
                    if (HMap.Changed[x, y] < mask[x - mapL, y - mapT])
                    {
                        k = mask[x - mapL, y - mapT] * force;
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
                Invalidate(new Rectangle(
                    hScrollBar.Left,
                    vScrollBar.Top,
                    hScrollBar.Right,
                    vScrollBar.Bottom));
                /*Invalidate(new Rectangle(
                    hScrollBar.Left + (historyRecord.Left   << zoom) - hScrollBar.Value,
                    vScrollBar.Top  + (historyRecord.Top    << zoom) - vScrollBar.Value,
                    hScrollBar.Left + (historyRecord.Right  << zoom) - hScrollBar.Value,
                    vScrollBar.Top  + (historyRecord.Bottom << zoom) - vScrollBar.Value));*/
            }
            ShowStatistics();
        }

        private void FormSHME_MouseUp(object sender, MouseEventArgs e)
        {
            // Clear change level board
            if (historyRecord != null)
                for (int y = historyRecord.Top; y < historyRecord.Bottom; y++)
                    for (int x = historyRecord.Left; x < historyRecord.Right; x++)
                        HMap.Changed[x, y] = 0;
            // Fix record
            HistoryAdd();
        }

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

        private int ReadToolFromString(String s)
        {
            int i;
            s = "btnTool" + s;
            for (i = 0; i < ToolControls.Length; i++)
                if (s.StartsWith(ToolControls[i].Name))
                    return (i << 2) + CheckInteger(s.Substring(ToolControls[i].Name.Length, 1), 1, 3, 1) - 1;
            return 0;
        }

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
                                    toolL  = ReadToolFromString(rec[1]);
                                    toolM  = ReadToolFromString(rec[2]);
                                    toolR  = ReadToolFromString(rec[3]);
                                    toolX1 = ReadToolFromString(rec[4]);
                                    toolX2 = ReadToolFromString(rec[5]);
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
                            case "Slot1Value":        nudBrush1ValueDecimal.Value      = CheckInteger(value, 0, 65535, 0); break;
                            case "Slot2Value":        nudBrush2ValueDecimal.Value      = CheckInteger(value, 0, 65535, 0); break;
                            case "Slot3Value":        nudBrush3ValueDecimal.Value      = CheckInteger(value, 0, 65535, 0); break;
                            case "Slot1Force":        nudBrush1ForceDecimal.Value      = CheckInteger(value, 0, 65535, 0); break;
                            case "Slot2Force":        nudBrush2ForceDecimal.Value      = CheckInteger(value, 0, 65535, 0); break;
                            case "Slot3Force":        nudBrush3ForceDecimal.Value      = CheckInteger(value, 0, 65535, 0); break;
                            case "Slot1Width":        nudBrush1Width .Value            = CheckInteger(value, 1, (int)nudBrush1Width .Maximum, 1); break;
                            case "Slot1Height":       nudBrush1Height.Value            = CheckInteger(value, 1, (int)nudBrush1Height.Maximum, 1); break;
                            case "Slot2Width":        nudBrush2Width .Value            = CheckInteger(value, 1, (int)nudBrush2Width .Maximum, 1); break;
                            case "Slot2Height":       nudBrush2Height.Value            = CheckInteger(value, 1, (int)nudBrush2Height.Maximum, 1); break;
                            case "Slot3Width":        nudBrush3Width .Value            = CheckInteger(value, 1, (int)nudBrush3Width .Maximum, 1); break;
                            case "Slot3Height":       nudBrush3Height.Value            = CheckInteger(value, 1, (int)nudBrush3Height.Maximum, 1); break;
                            case "Slot1Distribution": btnBrush1Distribution.ImageIndex = CheckInteger(value, 0, ilToolForce.Images.Count - 1, 0); break;
                            case "Slot2Distribution": btnBrush2Distribution.ImageIndex = CheckInteger(value, 0, ilToolForce.Images.Count - 1, 0); break;
                            case "Slot3Distribution": btnBrush3Distribution.ImageIndex = CheckInteger(value, 0, ilToolForce.Images.Count - 1, 0); break;
                            case "Slot1Shape":        chbBrush1Shape.Checked           = (value == "True"); break;
                            case "Slot2Shape":        chbBrush2Shape.Checked           = (value == "True"); break;
                            case "Slot3Shape":        chbBrush3Shape.Checked           = (value == "True"); break;
                            case "Slot1FrameShow":    chbBrush1FrameShow.Checked       = (value == "True"); break;
                            case "Slot2FrameShow":    chbBrush2FrameShow.Checked       = (value == "True"); break;
                            case "Slot3FrameShow":    chbBrush3FrameShow.Checked       = (value == "True"); break;

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
            if (chbBrush1FrameShow.Checked) DrawBrushContour(e.Graphics, (int)nudBrush1Width.Value, (int)nudBrush1Height.Value, chbBrush1Shape.Checked);
            if (chbBrush2FrameShow.Checked) DrawBrushContour(e.Graphics, (int)nudBrush2Width.Value, (int)nudBrush2Height.Value, chbBrush2Shape.Checked);
            if (chbBrush3FrameShow.Checked) DrawBrushContour(e.Graphics, (int)nudBrush3Width.Value, (int)nudBrush3Height.Value, chbBrush3Shape.Checked);
            /**/
        }

        private void DrawBrushContour(Graphics g, int width, int height, bool shape)
        {
            int ix = ((mapX - ((width  - 1) >> 1)) << zoom) - hScrollBar.Value;
            int iy = ((mapY - ((height - 1) >> 1)) << zoom) - vScrollBar.Value;
            if (shape)
                g.DrawRectangle(
                    new Pen(Color.Black),
                    ix + hScrollBar.Left,
                    iy + vScrollBar.Top,
                    (width  << zoom) - 1,
                    (height << zoom) - 1);
            else
                g.DrawEllipse(
                    new Pen(Color.Black),
                    ix + hScrollBar.Left,
                    iy + vScrollBar.Top,
                    (width  << zoom) - 1,
                    (height << zoom) - 1
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
                    ToolControls[(int)btnToolLMB.Tag  >> 2].Name + (((int)btnToolLMB.Tag  & 3) + 1) + ", " +
                    ToolControls[(int)btnToolMMB.Tag  >> 2].Name + (((int)btnToolMMB.Tag  & 3) + 1) + ", " +
                    ToolControls[(int)btnToolRMB.Tag  >> 2].Name + (((int)btnToolRMB.Tag  & 3) + 1) + ", " +
                    ToolControls[(int)btnToolX1MB.Tag >> 2].Name + (((int)btnToolX1MB.Tag & 3) + 1) + ", " +
                    ToolControls[(int)btnToolX2MB.Tag >> 2].Name + (((int)btnToolX2MB.Tag & 3) + 1)
                    ).Replace("btnTool", ""));
                // Preset
                for (int i = 0; i < cbbToolsetPreset.Items.Count; i++)
                    file.WriteLine("Toolset\t" + (i + 1) + ", " + cbbToolsetPreset.Items[i].ToString());
                // Slots
                file.WriteLine("Slot1Value\t"        + nudBrush1ValueDecimal.Value);
                file.WriteLine("Slot2Value\t"        + nudBrush2ValueDecimal.Value);
                file.WriteLine("Slot3Value\t"        + nudBrush3ValueDecimal.Value);
                file.WriteLine("Slot1Force\t"        + nudBrush1ForceDecimal.Value);
                file.WriteLine("Slot2Force\t"        + nudBrush2ForceDecimal.Value);
                file.WriteLine("Slot3Force\t"        + nudBrush3ForceDecimal.Value);
                file.WriteLine("Slot1Width\t"        + nudBrush1Width .Value);
                file.WriteLine("Slot1Height\t"       + nudBrush1Height.Value);
                file.WriteLine("Slot2Width\t"        + nudBrush2Width .Value);
                file.WriteLine("Slot2Height\t"       + nudBrush2Height.Value);
                file.WriteLine("Slot3Width\t"        + nudBrush3Width .Value);
                file.WriteLine("Slot3Height\t"       + nudBrush3Height.Value);
                file.WriteLine("Slot1Distribution\t" + btnBrush1Distribution.ImageIndex);
                file.WriteLine("Slot2Distribution\t" + btnBrush2Distribution.ImageIndex);
                file.WriteLine("Slot3Distribution\t" + btnBrush3Distribution.ImageIndex);
                file.WriteLine("Slot1Shape\t"        + chbBrush1Shape.Checked);
                file.WriteLine("Slot2Shape\t"        + chbBrush2Shape.Checked);
                file.WriteLine("Slot3Shape\t"        + chbBrush3Shape.Checked);
                file.WriteLine("Slot1FrameShow\t"    + chbBrush1FrameShow.Checked);
                file.WriteLine("Slot2FrameShow\t"    + chbBrush2FrameShow.Checked);
                file.WriteLine("Slot3FrameShow\t"    + chbBrush3FrameShow.Checked);

                //* Files
                file.WriteLine("FileHMap\t" + HMap.URL);
                file.WriteLine("FileTMap\t" + TMap.URL);
                file.WriteLine("Level8bit\t"     + cbbLevelFormat16bit.SelectedIndex);
                file.WriteLine("Level16bit\t"    + cbbLevelFormat16bit.SelectedIndex);
                file.WriteLine("LevelBLIByte\t"  + chbLevelByteBigLittleIndian.Checked);
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
            int preset = toolL + (toolM << 6) + (toolR << 12) + (toolX1 << 18) + (toolX2 << 24);
            if (!toolsetPresets.Contains(preset))
            {
                cbbToolsetPreset.Items.Add((
                    ToolControls[toolL  >> 2].Name + ((toolL  & 3) + 1) + ", " + 
                    ToolControls[toolM  >> 2].Name + ((toolM  & 3) + 1) + ", " + 
                    ToolControls[toolR  >> 2].Name + ((toolR  & 3) + 1) + ", " + 
                    ToolControls[toolX1 >> 2].Name + ((toolX1 & 3) + 1) + ", " +
                    ToolControls[toolX2 >> 2].Name + ((toolX2 & 3) + 1)
                    ).Replace("btnTool", ""));
                toolsetPresets.Add(preset);
            }
            return toolsetPresets.IndexOf(preset);
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
            ToolXMBSelect(btnToolMMB,  IDs >>  6);
            ToolXMBSelect(btnToolRMB,  IDs >> 12);
            ToolXMBSelect(btnToolX1MB, IDs >> 18);
            ToolXMBSelect(btnToolX2MB, IDs >> 24);
            btnToolsetRemove.Enabled = true;
        }

        private void btnToolXMB_Click(object sender, EventArgs e)//Ok
        {
            pnlToolSelect.Tag = sender;
            Button btn = sender as Button;
            int useBrushNumber = (int)btn.Tag & 3;
            // Popup panel
            //var r = btn.PointToClient(btn.Location);
            pnlToolSelect.Left = btn.Left + gbTools.Left - (btnToolPan.Left + 1);
            pnlToolSelect.Top  = btn.Top  + gbTools.Top  - (btnToolPan.Top  + 1) - btnToolPan.Height;
            // Set brush selection
            rbToolUseBrush1.Checked = (useBrushNumber == 0);
            rbToolUseBrush2.Checked = (useBrushNumber == 1);
            rbToolUseBrush3.Checked = (useBrushNumber == 2);
            pnlToolSelect.Visible = true;
            pnlToolSelect.Focus();
        }

        private void pnlToolSelect_Click(object sender, EventArgs e) => pnlToolSelect.Visible = false;
        private void btnTool_Click(object sender, EventArgs e)//Ok
        {
            int useBrushNumber = (rbToolUseBrush1.Checked) ? 0:
                                 (rbToolUseBrush2.Checked) ? 1:
                                                             2;
            ToolXMBSelect(pnlToolSelect.Tag as Button, ((int)(sender as Button).Tag << 2) + useBrushNumber);
            cbbToolsetPreset.SelectedIndex = -1;
            pnlToolSelect.Visible = false;
        }

        private void ToolXMBSelect(Button btnXMB, int ID)//O
        {
            ID = ID & 63; // Filter out ID + brush (4 + 2 bits)
            if (ToolControls.Length <= ID >> 2) ID = 0; // Unknown tool, set pan
            btnXMB.Image = ToolControls[ID >> 2].Image;
            btnXMB.Text = (ID < 16) ? "" : ((ID & 3) + 1).ToString();
            btnXMB.Tag = ID;
        }

        private void nudBrush1Value_ValueChanged(object sender, EventArgs e) => tbBrush1ValueHex.Text = ((int)nudBrush1ValueDecimal.Value).ToString("X4");
        private void nudBrush2Value_ValueChanged(object sender, EventArgs e) => tbBrush2ValueHex.Text = ((int)nudBrush2ValueDecimal.Value).ToString("X4");
        private void nudBrush3Value_ValueChanged(object sender, EventArgs e) => tbBrush3ValueHex.Text = ((int)nudBrush3ValueDecimal.Value).ToString("X4");

        private void nudBrush1Force_ValueChanged(object sender, EventArgs e) => tbBrush1ForceHex.Text = ((int)nudBrush1ForceDecimal.Value).ToString("X4");
        private void nudBrush2Force_ValueChanged(object sender, EventArgs e) => tbBrush2ForceHex.Text = ((int)nudBrush2ForceDecimal.Value).ToString("X4");
        private void nudBrush3Force_ValueChanged(object sender, EventArgs e) => tbBrush3ForceHex.Text = ((int)nudBrush3ForceDecimal.Value).ToString("X4");

        private void tbBrush1ValueHex_TextChanged(object sender, EventArgs e) => HexTextCheck(tbBrush1ValueHex, 4, nudBrush1ValueDecimal, tbBrush1ValueHex_TextChanged);
        private void tbBrush2ValueHex_TextChanged(object sender, EventArgs e) => HexTextCheck(tbBrush2ValueHex, 4, nudBrush2ValueDecimal, tbBrush2ValueHex_TextChanged);
        private void tbBrush3ValueHex_TextChanged(object sender, EventArgs e) => HexTextCheck(tbBrush3ValueHex, 4, nudBrush3ValueDecimal, tbBrush3ValueHex_TextChanged);

        private void tbBrush1ForceHex_TextChanged(object sender, EventArgs e) => HexTextCheck(tbBrush1ForceHex, 4, nudBrush1ForceDecimal, tbBrush1ForceHex_TextChanged);
        private void tbBrush2ForceHex_TextChanged(object sender, EventArgs e) => HexTextCheck(tbBrush2ForceHex, 4, nudBrush2ForceDecimal, tbBrush2ForceHex_TextChanged);
        private void tbBrush3ForceHex_TextChanged(object sender, EventArgs e) => HexTextCheck(tbBrush3ForceHex, 4, nudBrush3ForceDecimal, tbBrush3ForceHex_TextChanged);

        private void HexTextCheck(TextBox tb, int size, NumericUpDown nud, EventHandler tbHandler)//Ok
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
            tb.TextChanged -= tbHandler;
            tb.Text = new String(csOut);
            tb.SelectionStart = size - cursor;
            if (nud != null) nud.Value = Convert.ToInt32(tb.Text, 16);
            tb.TextChanged += tbHandler;
        }

        private void chbBrushXShape_CheckedChanged(object sender, EventArgs e) => (sender as CheckBox).BackgroundImage = ilToolShape.Images[(sender as CheckBox).Checked ? 1 : 0];

        private void chbHexValues_CheckedChanged(object sender, EventArgs e) =>
            tbBrush1ValueHex.Visible = tbBrush1ForceHex.Visible =
            tbBrush2ValueHex.Visible = tbBrush2ForceHex.Visible =
            tbBrush3ValueHex.Visible = tbBrush3ForceHex.Visible = chbHexValues.Checked;

        private void nudBrush1Size_ValueChanged(object sender, EventArgs e) => CreateToolForceMask(ref brush1ForceMask, ref brush1Buffer, btnBrush1Distribution.ImageIndex, nudBrush1Width, nudBrush1Height, chbBrush1Shape);
        private void nudBrush2Size_ValueChanged(object sender, EventArgs e) => CreateToolForceMask(ref brush2ForceMask, ref brush2Buffer, btnBrush2Distribution.ImageIndex, nudBrush2Width, nudBrush2Height, chbBrush2Shape);
        private void nudBrush3Size_ValueChanged(object sender, EventArgs e) => CreateToolForceMask(ref brush3ForceMask, ref brush3Buffer, btnBrush3Distribution.ImageIndex, nudBrush3Width, nudBrush3Height, chbBrush3Shape);

        private void btnBrush1Distribution_Click(object sender, EventArgs e) => CreateToolForceMask(ref brush1ForceMask, ref brush1Buffer, btnBrush1Distribution.ImageIndex += (1 < btnBrush1Distribution.ImageIndex) ? -2 : 1, nudBrush1Width, nudBrush1Height, chbBrush1Shape);
        private void btnBrush2Distribution_Click(object sender, EventArgs e) => CreateToolForceMask(ref brush2ForceMask, ref brush2Buffer, btnBrush2Distribution.ImageIndex += (1 < btnBrush2Distribution.ImageIndex) ? -2 : 1, nudBrush2Width, nudBrush2Height, chbBrush2Shape);
        private void btnBrush3Distribution_Click(object sender, EventArgs e) => CreateToolForceMask(ref brush3ForceMask, ref brush3Buffer, btnBrush3Distribution.ImageIndex += (1 < btnBrush3Distribution.ImageIndex) ? -2 : 1, nudBrush3Width, nudBrush3Height, chbBrush3Shape);

        private void CreateToolForceMask(ref float[,] mask, ref int[,] brush, int distributionShape, NumericUpDown nudWidth, NumericUpDown nudHeight, CheckBox chbSquareShape)
        {
            int x, sizeW = (int)nudWidth .Value;
            int y, sizeH = (int)nudHeight.Value;
            // Create
            mask  = new float[sizeW, sizeH];
            brush = new   int[sizeW, sizeH];

            // Fast out
            if ((sizeW < 3 && sizeH < 3) || (distributionShape == 0 && chbSquareShape.Checked))
            {
                for (y = 0; y < sizeH; y++)
                    for (x = 0; x < sizeW; x++)
                        mask[x, y] = 1;
                return;
            }

            int szW = sizeW - 1, qr = sizeW * sizeH;
            int szH = sizeH - 1, qqr= qr * qr;
            int hsizeW = szW >> 1;
            int hsizeH = szH >> 1;
            int cx, cy;

            // Square distribution
            if (distributionShape == 0)
            {
                int r;
                for (y = 0; y <= hsizeH; y++)
                    for (x = 0; x <= hsizeW; x++)
                    {
                        cx = (szW - (x << 1)) * sizeH;
                        cy = (szH - (y << 1)) * sizeW;
                        r = (cx * cx + cy * cy);
                        if (r + 1 < qqr)
                            mask[      x,       y] =
                            mask[      x, szH - y] =
                            mask[szW - x,       y] =
                            mask[szW - x, szH - y] = 1;
                    }
            }
            // Half-shere distribution
            else if (distributionShape == 1)
            {
                int r;
                for (y = 0; y <= hsizeH; y++)
                    for (x = 0; x <= hsizeW; x++)
                    {
                        cx = (szW - (x << 1)) * sizeH;
                        cy = (szH - (y << 1)) * sizeW;
                        r = (cx * cx + cy * cy);
                        if (r < qqr)
                            mask[      x,       y] =
                            mask[      x, szH - y] =
                            mask[szW - x,       y] =
                            mask[szW - x, szH - y] = (float)(qqr - r) / qqr;
                    }
            }
            // Gaussian distribution
            else
            {
                float r;
                for (y = 0; y <= hsizeH; y++)
                    for (x = 0; x <= hsizeW; x++)
                    {
                        cx = hsizeW - x;
                        cy = hsizeH - y;
                        r = (float)((cx * cx + cy * cy) << 2) / qr;
                        mask[      x,       y] =
                        mask[      x, szH - y] =
                        mask[szW - x,       y] =
                        mask[szW - x, szH - y] = (float)Math.Exp(-24 * r * r);
                    }
            }

            // Make square
            if (chbSquareShape.Checked)
                for (y = 0; y < hsizeH; y++)
                    for (x = 0; x < hsizeW; x++)
                        mask[      x,       y] =
                        mask[      x, szH - y] =
                        mask[szW - x,       y] =
                        mask[szW - x, szH - y] = mask[Math.Min(x, y), hsizeH];
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
