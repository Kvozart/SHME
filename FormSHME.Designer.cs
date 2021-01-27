namespace SHME
{
    partial class FormSHME
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSHME));
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.gbStatistics = new System.Windows.Forms.GroupBox();
            this.chbLimitMin = new System.Windows.Forms.CheckBox();
            this.lblPointerPosition = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblPointerLevel = new System.Windows.Forms.Label();
            this.lblHeightAvg = new System.Windows.Forms.Label();
            this.lblHeightMid = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.chbLimitMax = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblHeightMax = new System.Windows.Forms.Label();
            this.lblHeightMin = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmsOpenFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmCreateEmpty = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCreateScanline = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCreateSerpantine = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefreash = new System.Windows.Forms.ToolStripMenuItem();
            this.tcThemes = new System.Windows.Forms.TabControl();
            this.tpMonochrome = new System.Windows.Forms.TabPage();
            this.btnMonochromeColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudMonochromeRepeat = new System.Windows.Forms.NumericUpDown();
            this.cbbMonochromePresets = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tpBytes = new System.Windows.Forms.TabPage();
            this.tbByteLo = new System.Windows.Forms.TextBox();
            this.tbByteHi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbBytePresets = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudByteRepeat = new System.Windows.Forms.NumericUpDown();
            this.tpSpectrum = new System.Windows.Forms.TabPage();
            this.btnSpectrumColor8 = new System.Windows.Forms.Button();
            this.btnSpectrumColor7 = new System.Windows.Forms.Button();
            this.btnSpectrumColor6 = new System.Windows.Forms.Button();
            this.btnSpectrumColor5 = new System.Windows.Forms.Button();
            this.btnSpectrumColor4 = new System.Windows.Forms.Button();
            this.btnSpectrumColor3 = new System.Windows.Forms.Button();
            this.btnSpectrumColor2 = new System.Windows.Forms.Button();
            this.btnSpectrumColor1 = new System.Windows.Forms.Button();
            this.btnSpectrumColor0 = new System.Windows.Forms.Button();
            this.nudSpectrumRepeat = new System.Windows.Forms.NumericUpDown();
            this.cbbSpectrumStyle = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pbSpectrum = new System.Windows.Forms.PictureBox();
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.gbFiles = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.cbbLevelFormat8bit = new System.Windows.Forms.ComboBox();
            this.chbLevelPixelBigLittleIndian = new System.Windows.Forms.CheckBox();
            this.lblFileFormat = new System.Windows.Forms.Label();
            this.cbbLevelFormat16bit = new System.Windows.Forms.ComboBox();
            this.chbLevelByteBigLittleIndian = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnHMapResize = new System.Windows.Forms.Button();
            this.lblHMapSizes = new System.Windows.Forms.Label();
            this.lblTMapSizes = new System.Windows.Forms.Label();
            this.btnSaveHMap = new System.Windows.Forms.Button();
            this.cmsSaveFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi8BitPNG = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportView = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadHMap = new System.Windows.Forms.Button();
            this.btnLoadTMap = new System.Windows.Forms.Button();
            this.chbShowHMap = new System.Windows.Forms.CheckBox();
            this.chbShowTMap = new System.Windows.Forms.CheckBox();
            this.btnTMapGenerate = new System.Windows.Forms.Button();
            this.tlpTools = new System.Windows.Forms.TableLayoutPanel();
            this.gbTools = new System.Windows.Forms.GroupBox();
            this.chbHexValues = new System.Windows.Forms.CheckBox();
            this.btnToolsetRemove = new System.Windows.Forms.Button();
            this.btnToolsetAdd = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.cbbToolsetPreset = new System.Windows.Forms.ComboBox();
            this.btnToolRMB = new System.Windows.Forms.Button();
            this.btnToolX2MB = new System.Windows.Forms.Button();
            this.btnToolX1MB = new System.Windows.Forms.Button();
            this.btnToolLMB = new System.Windows.Forms.Button();
            this.pnlTools = new System.Windows.Forms.Panel();
            this.pnlBrush3 = new System.Windows.Forms.Panel();
            this.chbBrush3FrameShow = new System.Windows.Forms.CheckBox();
            this.tbBrush3ForceHex = new System.Windows.Forms.TextBox();
            this.nudBrush3ForceDecimal = new System.Windows.Forms.NumericUpDown();
            this.nudBrush3Height = new System.Windows.Forms.NumericUpDown();
            this.tbBrush3ValueHex = new System.Windows.Forms.TextBox();
            this.btnBrush3Distribution = new System.Windows.Forms.Button();
            this.ilToolForce = new System.Windows.Forms.ImageList(this.components);
            this.label25 = new System.Windows.Forms.Label();
            this.nudBrush3Width = new System.Windows.Forms.NumericUpDown();
            this.nudBrush3ValueDecimal = new System.Windows.Forms.NumericUpDown();
            this.chbBrush3Shape = new System.Windows.Forms.CheckBox();
            this.ilToolShape = new System.Windows.Forms.ImageList(this.components);
            this.label27 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.pnlBrush2 = new System.Windows.Forms.Panel();
            this.chbBrush2FrameShow = new System.Windows.Forms.CheckBox();
            this.tbBrush2ForceHex = new System.Windows.Forms.TextBox();
            this.nudBrush2ForceDecimal = new System.Windows.Forms.NumericUpDown();
            this.nudBrush2Height = new System.Windows.Forms.NumericUpDown();
            this.tbBrush2ValueHex = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btnBrush2Distribution = new System.Windows.Forms.Button();
            this.nudBrush2ValueDecimal = new System.Windows.Forms.NumericUpDown();
            this.chbBrush2Shape = new System.Windows.Forms.CheckBox();
            this.nudBrush2Width = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.pnlBrush1 = new System.Windows.Forms.Panel();
            this.chbBrush1FrameShow = new System.Windows.Forms.CheckBox();
            this.nudBrush1Width = new System.Windows.Forms.NumericUpDown();
            this.tbBrush1ForceHex = new System.Windows.Forms.TextBox();
            this.nudBrush1Height = new System.Windows.Forms.NumericUpDown();
            this.btnBrush1Distribution = new System.Windows.Forms.Button();
            this.tbBrush1ValueHex = new System.Windows.Forms.TextBox();
            this.nudBrush1ValueDecimal = new System.Windows.Forms.NumericUpDown();
            this.nudBrush1ForceDecimal = new System.Windows.Forms.NumericUpDown();
            this.chbBrush1Shape = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnToolMMB = new System.Windows.Forms.Button();
            this.pbMouseButtons = new System.Windows.Forms.PictureBox();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cbbZoom = new System.Windows.Forms.ComboBox();
            this.btnHistoryForward = new System.Windows.Forms.Button();
            this.btnHistoryBackward = new System.Windows.Forms.Button();
            this.chbGrid = new System.Windows.Forms.CheckBox();
            this.pbZoomOut = new System.Windows.Forms.PictureBox();
            this.pbZoomIn = new System.Windows.Forms.PictureBox();
            this.btnToolSwitch = new System.Windows.Forms.Button();
            this.btnToolPan = new System.Windows.Forms.Button();
            this.btnToolProbe = new System.Windows.Forms.Button();
            this.btnToolPencil = new System.Windows.Forms.Button();
            this.btnToolSmooth = new System.Windows.Forms.Button();
            this.btnToolFlaten = new System.Windows.Forms.Button();
            this.btnToolAdd = new System.Windows.Forms.Button();
            this.btnToolSub = new System.Windows.Forms.Button();
            this.pnlCorner = new System.Windows.Forms.Panel();
            this.btnToolStretch = new System.Windows.Forms.Button();
            this.btnToolFlatenDown = new System.Windows.Forms.Button();
            this.btnToolFlatenUp = new System.Windows.Forms.Button();
            this.pnlZoomGrid = new System.Windows.Forms.Panel();
            this.pnlToolSelect = new System.Windows.Forms.Panel();
            this.rbToolUseBrush3 = new System.Windows.Forms.RadioButton();
            this.rbToolUseBrush2 = new System.Windows.Forms.RadioButton();
            this.rbToolUseBrush1 = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.btnToolUndo = new System.Windows.Forms.Button();
            this.btnToolRedo = new System.Windows.Forms.Button();
            this.tsmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.gbStatistics.SuspendLayout();
            this.cmsOpenFile.SuspendLayout();
            this.tcThemes.SuspendLayout();
            this.tpMonochrome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonochromeRepeat)).BeginInit();
            this.tpBytes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudByteRepeat)).BeginInit();
            this.tpSpectrum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpectrumRepeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpectrum)).BeginInit();
            this.gbFiles.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.cmsSaveFile.SuspendLayout();
            this.tlpTools.SuspendLayout();
            this.gbTools.SuspendLayout();
            this.pnlTools.SuspendLayout();
            this.pnlBrush3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush3ForceDecimal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush3Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush3Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush3ValueDecimal)).BeginInit();
            this.pnlBrush2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush2ForceDecimal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush2Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush2ValueDecimal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush2Width)).BeginInit();
            this.pnlBrush1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush1Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush1Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush1ValueDecimal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush1ForceDecimal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMouseButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZoomOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZoomIn)).BeginInit();
            this.pnlZoomGrid.SuspendLayout();
            this.pnlToolSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "openFileDialog";
            this.dlgOpen.RestoreDirectory = true;
            this.dlgOpen.Title = "Load Height Map";
            // 
            // dlgSave
            // 
            this.dlgSave.RestoreDirectory = true;
            this.dlgSave.SupportMultiDottedExtensions = true;
            this.dlgSave.Title = "Save as...";
            // 
            // gbStatistics
            // 
            this.gbStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStatistics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbStatistics.Controls.Add(this.chbLimitMin);
            this.gbStatistics.Controls.Add(this.lblPointerPosition);
            this.gbStatistics.Controls.Add(this.label12);
            this.gbStatistics.Controls.Add(this.lblPointerLevel);
            this.gbStatistics.Controls.Add(this.lblHeightAvg);
            this.gbStatistics.Controls.Add(this.lblHeightMid);
            this.gbStatistics.Controls.Add(this.label16);
            this.gbStatistics.Controls.Add(this.chbLimitMax);
            this.gbStatistics.Controls.Add(this.label13);
            this.gbStatistics.Controls.Add(this.lblHeightMax);
            this.gbStatistics.Controls.Add(this.lblHeightMin);
            this.gbStatistics.Controls.Add(this.label11);
            this.gbStatistics.Controls.Add(this.label5);
            this.gbStatistics.Controls.Add(this.label6);
            this.gbStatistics.Location = new System.Drawing.Point(3, 299);
            this.gbStatistics.Name = "gbStatistics";
            this.gbStatistics.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.gbStatistics.Size = new System.Drawing.Size(214, 96);
            this.gbStatistics.TabIndex = 3;
            this.gbStatistics.TabStop = false;
            this.gbStatistics.Text = "Statistics";
            // 
            // chbLimitMin
            // 
            this.chbLimitMin.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbLimitMin.BackgroundImage = global::SHME.Properties.Resources.limitDown;
            this.chbLimitMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chbLimitMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbLimitMin.Location = new System.Drawing.Point(84, 43);
            this.chbLimitMin.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.chbLimitMin.Name = "chbLimitMin";
            this.chbLimitMin.Size = new System.Drawing.Size(22, 22);
            this.chbLimitMin.TabIndex = 1;
            this.chbLimitMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbLimitMin.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolTip.SetToolTip(this.chbLimitMin, "Stretch levels to bottom for view");
            this.chbLimitMin.UseVisualStyleBackColor = true;
            this.chbLimitMin.CheckedChanged += new System.EventHandler(this.HMapOption_Changed);
            // 
            // lblPointerPosition
            // 
            this.lblPointerPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPointerPosition.BackColor = System.Drawing.Color.Transparent;
            this.lblPointerPosition.Location = new System.Drawing.Point(48, 68);
            this.lblPointerPosition.Margin = new System.Windows.Forms.Padding(1);
            this.lblPointerPosition.Name = "lblPointerPosition";
            this.lblPointerPosition.Size = new System.Drawing.Size(80, 28);
            this.lblPointerPosition.TabIndex = 23;
            this.lblPointerPosition.Text = "- x -";
            this.lblPointerPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(4, 12);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 28);
            this.label12.TabIndex = 14;
            this.label12.Text = "Max:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPointerLevel
            // 
            this.lblPointerLevel.Location = new System.Drawing.Point(168, 68);
            this.lblPointerLevel.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lblPointerLevel.Name = "lblPointerLevel";
            this.lblPointerLevel.Size = new System.Drawing.Size(40, 26);
            this.lblPointerLevel.TabIndex = 24;
            this.lblPointerLevel.Text = "-";
            this.lblPointerLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHeightAvg
            // 
            this.lblHeightAvg.Location = new System.Drawing.Point(168, 12);
            this.lblHeightAvg.Name = "lblHeightAvg";
            this.lblHeightAvg.Size = new System.Drawing.Size(40, 28);
            this.lblHeightAvg.TabIndex = 12;
            this.lblHeightAvg.Text = "32768 x8000";
            this.lblHeightAvg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHeightMid
            // 
            this.lblHeightMid.Location = new System.Drawing.Point(168, 40);
            this.lblHeightMid.Name = "lblHeightMid";
            this.lblHeightMid.Size = new System.Drawing.Size(40, 28);
            this.lblHeightMid.TabIndex = 13;
            this.lblHeightMid.Text = "32768 x8000";
            this.lblHeightMid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(124, 68);
            this.label16.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 28);
            this.label16.TabIndex = 26;
            this.label16.Text = "Level:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chbLimitMax
            // 
            this.chbLimitMax.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbLimitMax.BackgroundImage = global::SHME.Properties.Resources.limitUp;
            this.chbLimitMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chbLimitMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbLimitMax.Location = new System.Drawing.Point(84, 15);
            this.chbLimitMax.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.chbLimitMax.Name = "chbLimitMax";
            this.chbLimitMax.Size = new System.Drawing.Size(22, 22);
            this.chbLimitMax.TabIndex = 0;
            this.chbLimitMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbLimitMax.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolTip.SetToolTip(this.chbLimitMax, "Stretch levels to ceiling for view");
            this.chbLimitMax.UseVisualStyleBackColor = true;
            this.chbLimitMax.CheckedChanged += new System.EventHandler(this.HMapOption_Changed);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(4, 40);
            this.label13.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 28);
            this.label13.TabIndex = 14;
            this.label13.Text = "Min:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHeightMax
            // 
            this.lblHeightMax.Location = new System.Drawing.Point(44, 12);
            this.lblHeightMax.Name = "lblHeightMax";
            this.lblHeightMax.Size = new System.Drawing.Size(40, 28);
            this.lblHeightMax.TabIndex = 10;
            this.lblHeightMax.Text = "65535 xFFFF";
            this.lblHeightMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHeightMin
            // 
            this.lblHeightMin.Location = new System.Drawing.Point(44, 40);
            this.lblHeightMin.Name = "lblHeightMin";
            this.lblHeightMin.Size = new System.Drawing.Size(40, 28);
            this.lblHeightMin.TabIndex = 11;
            this.lblHeightMin.Text = "0 x0000";
            this.lblHeightMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(4, 68);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 28);
            this.label11.TabIndex = 22;
            this.label11.Text = "Pointer:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(124, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 28);
            this.label5.TabIndex = 15;
            this.label5.Text = "Mid:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(124, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 28);
            this.label6.TabIndex = 14;
            this.label6.Text = "Avg:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmsOpenFile
            // 
            this.cmsOpenFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCreateEmpty,
            this.tsmCreateScanline,
            this.tsmCreateSerpantine,
            this.tsmiClear,
            this.tsmiRefreash});
            this.cmsOpenFile.Name = "cmsOpenFile";
            this.cmsOpenFile.Size = new System.Drawing.Size(249, 114);
            this.cmsOpenFile.Opening += new System.ComponentModel.CancelEventHandler(this.cmsOpenFile_Opening);
            // 
            // tsmCreateEmpty
            // 
            this.tsmCreateEmpty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsmCreateEmpty.Image = global::SHME.Properties.Resources.blank;
            this.tsmCreateEmpty.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmCreateEmpty.Name = "tsmCreateEmpty";
            this.tsmCreateEmpty.Size = new System.Drawing.Size(248, 22);
            this.tsmCreateEmpty.Text = "Create empty...";
            this.tsmCreateEmpty.Click += new System.EventHandler(this.tsmCreat_Click);
            // 
            // tsmCreateScanline
            // 
            this.tsmCreateScanline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsmCreateScanline.Image = ((System.Drawing.Image)(resources.GetObject("tsmCreateScanline.Image")));
            this.tsmCreateScanline.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmCreateScanline.Name = "tsmCreateScanline";
            this.tsmCreateScanline.Size = new System.Drawing.Size(248, 22);
            this.tsmCreateScanline.Text = "Create gradient map (scanline)";
            this.tsmCreateScanline.Click += new System.EventHandler(this.tsmCreat_Click);
            // 
            // tsmCreateSerpantine
            // 
            this.tsmCreateSerpantine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsmCreateSerpantine.Image = ((System.Drawing.Image)(resources.GetObject("tsmCreateSerpantine.Image")));
            this.tsmCreateSerpantine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmCreateSerpantine.Name = "tsmCreateSerpantine";
            this.tsmCreateSerpantine.Size = new System.Drawing.Size(248, 22);
            this.tsmCreateSerpantine.Text = "Create gradient map (serpantine)";
            this.tsmCreateSerpantine.Click += new System.EventHandler(this.tsmCreat_Click);
            // 
            // tsmiClear
            // 
            this.tsmiClear.Image = global::SHME.Properties.Resources.delete;
            this.tsmiClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiClear.Name = "tsmiClear";
            this.tsmiClear.Size = new System.Drawing.Size(248, 22);
            this.tsmiClear.Text = "Clear";
            this.tsmiClear.Click += new System.EventHandler(this.tsmiClear_Click);
            // 
            // tsmiRefreash
            // 
            this.tsmiRefreash.Image = global::SHME.Properties.Resources.reload;
            this.tsmiRefreash.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiRefreash.Name = "tsmiRefreash";
            this.tsmiRefreash.Size = new System.Drawing.Size(248, 22);
            this.tsmiRefreash.Text = "Refreash";
            this.tsmiRefreash.Visible = false;
            this.tsmiRefreash.Click += new System.EventHandler(this.tsmiRefreash_Click);
            // 
            // tcThemes
            // 
            this.tcThemes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcThemes.Controls.Add(this.tpMonochrome);
            this.tcThemes.Controls.Add(this.tpBytes);
            this.tcThemes.Controls.Add(this.tpSpectrum);
            this.tcThemes.Location = new System.Drawing.Point(3, 163);
            this.tcThemes.Name = "tcThemes";
            this.tcThemes.SelectedIndex = 0;
            this.tcThemes.Size = new System.Drawing.Size(214, 130);
            this.tcThemes.TabIndex = 2;
            this.toolTip.SetToolTip(this.tcThemes, "View style");
            this.tcThemes.SelectedIndexChanged += new System.EventHandler(this.HMapOption_Changed);
            // 
            // tpMonochrome
            // 
            this.tpMonochrome.BackColor = System.Drawing.SystemColors.Control;
            this.tpMonochrome.Controls.Add(this.btnMonochromeColor);
            this.tpMonochrome.Controls.Add(this.label1);
            this.tpMonochrome.Controls.Add(this.nudMonochromeRepeat);
            this.tpMonochrome.Controls.Add(this.cbbMonochromePresets);
            this.tpMonochrome.Controls.Add(this.label14);
            this.tpMonochrome.Controls.Add(this.label9);
            this.tpMonochrome.Location = new System.Drawing.Point(4, 22);
            this.tpMonochrome.Name = "tpMonochrome";
            this.tpMonochrome.Padding = new System.Windows.Forms.Padding(3);
            this.tpMonochrome.Size = new System.Drawing.Size(206, 104);
            this.tpMonochrome.TabIndex = 0;
            this.tpMonochrome.Text = "Monochrome";
            // 
            // btnMonochromeColor
            // 
            this.btnMonochromeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMonochromeColor.BackColor = System.Drawing.Color.White;
            this.btnMonochromeColor.ForeColor = System.Drawing.Color.White;
            this.btnMonochromeColor.Location = new System.Drawing.Point(48, 56);
            this.btnMonochromeColor.Name = "btnMonochromeColor";
            this.btnMonochromeColor.Size = new System.Drawing.Size(25, 25);
            this.btnMonochromeColor.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnMonochromeColor, "Color of maximum (65,535)");
            this.btnMonochromeColor.UseVisualStyleBackColor = false;
            this.btnMonochromeColor.BackColorChanged += new System.EventHandler(this.btnMonochromeColor_BackColorChanged);
            this.btnMonochromeColor.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Preset";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudMonochromeRepeat
            // 
            this.nudMonochromeRepeat.Location = new System.Drawing.Point(48, 32);
            this.nudMonochromeRepeat.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudMonochromeRepeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMonochromeRepeat.Name = "nudMonochromeRepeat";
            this.nudMonochromeRepeat.Size = new System.Drawing.Size(60, 20);
            this.nudMonochromeRepeat.TabIndex = 1;
            this.nudMonochromeRepeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.nudMonochromeRepeat, "Count of loops on range of 0-65,535");
            this.nudMonochromeRepeat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMonochromeRepeat.ValueChanged += new System.EventHandler(this.HMapOption_Changed);
            // 
            // cbbMonochromePresets
            // 
            this.cbbMonochromePresets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbMonochromePresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMonochromePresets.FormattingEnabled = true;
            this.cbbMonochromePresets.Items.AddRange(new object[] {
            "White",
            "Red",
            "Yellow",
            "Green",
            "Cyan",
            "Blue",
            "Magenta"});
            this.cbbMonochromePresets.Location = new System.Drawing.Point(48, 8);
            this.cbbMonochromePresets.Name = "cbbMonochromePresets";
            this.cbbMonochromePresets.Size = new System.Drawing.Size(152, 21);
            this.cbbMonochromePresets.TabIndex = 0;
            this.toolTip.SetToolTip(this.cbbMonochromePresets, "Color theme presets");
            this.cbbMonochromePresets.SelectedIndexChanged += new System.EventHandler(this.cbbMonochromePresets_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(4, 60);
            this.label14.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 17);
            this.label14.TabIndex = 15;
            this.label14.Text = "Max";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(4, 32);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Repeat";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tpBytes
            // 
            this.tpBytes.BackColor = System.Drawing.SystemColors.Control;
            this.tpBytes.Controls.Add(this.tbByteLo);
            this.tpBytes.Controls.Add(this.tbByteHi);
            this.tpBytes.Controls.Add(this.label3);
            this.tpBytes.Controls.Add(this.label10);
            this.tpBytes.Controls.Add(this.label2);
            this.tpBytes.Controls.Add(this.cbbBytePresets);
            this.tpBytes.Controls.Add(this.label4);
            this.tpBytes.Controls.Add(this.nudByteRepeat);
            this.tpBytes.Location = new System.Drawing.Point(4, 22);
            this.tpBytes.Name = "tpBytes";
            this.tpBytes.Padding = new System.Windows.Forms.Padding(3);
            this.tpBytes.Size = new System.Drawing.Size(206, 104);
            this.tpBytes.TabIndex = 1;
            this.tpBytes.Text = "2 Bytes";
            // 
            // tbByteLo
            // 
            this.tbByteLo.Location = new System.Drawing.Point(64, 80);
            this.tbByteLo.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tbByteLo.MaxLength = 7;
            this.tbByteLo.Name = "tbByteLo";
            this.tbByteLo.Size = new System.Drawing.Size(44, 20);
            this.tbByteLo.TabIndex = 3;
            this.tbByteLo.Text = "000001";
            this.tbByteLo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.tbByteLo, "6 (3x2) hexadecimals (0-9, A-F) of RGB components");
            this.tbByteLo.WordWrap = false;
            this.tbByteLo.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // tbByteHi
            // 
            this.tbByteHi.Location = new System.Drawing.Point(64, 56);
            this.tbByteHi.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tbByteHi.MaxLength = 7;
            this.tbByteHi.Name = "tbByteHi";
            this.tbByteHi.Size = new System.Drawing.Size(44, 20);
            this.tbByteHi.TabIndex = 2;
            this.tbByteHi.Text = "000100";
            this.tbByteHi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.tbByteHi, "6 (3x2) hexadecimals (0-9, A-F) of RGB components");
            this.tbByteHi.WordWrap = false;
            this.tbByteHi.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(4, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Lower   0x";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.label3, "Color components multiplied by lower byte");
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(4, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "Repeat";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(4, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Higher   0x";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.label2, "Color components multiplied by higher byte");
            // 
            // cbbBytePresets
            // 
            this.cbbBytePresets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbBytePresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBytePresets.FormattingEnabled = true;
            this.cbbBytePresets.Items.AddRange(new object[] {
            "Hi*RG + Lo*B",
            "Hi*RB + Lo*G",
            "Hi*GB + Lo*R",
            "Hi*R + Lo*B",
            "Hi*G + Lo*B",
            "Hi*B + Lo*G",
            "Hi*R + Lo*G",
            "Hi*G + Lo*R",
            "Hi*B + Lo*R"});
            this.cbbBytePresets.Location = new System.Drawing.Point(48, 8);
            this.cbbBytePresets.Name = "cbbBytePresets";
            this.cbbBytePresets.Size = new System.Drawing.Size(152, 21);
            this.cbbBytePresets.TabIndex = 0;
            this.toolTip.SetToolTip(this.cbbBytePresets, "Multipliers presets");
            this.cbbBytePresets.SelectedIndexChanged += new System.EventHandler(this.cbbBytePresets_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(4, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Preset";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudByteRepeat
            // 
            this.nudByteRepeat.Location = new System.Drawing.Point(48, 32);
            this.nudByteRepeat.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudByteRepeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudByteRepeat.Name = "nudByteRepeat";
            this.nudByteRepeat.Size = new System.Drawing.Size(60, 20);
            this.nudByteRepeat.TabIndex = 1;
            this.nudByteRepeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.nudByteRepeat, "Count of loops on range of 0-65,535");
            this.nudByteRepeat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudByteRepeat.ValueChanged += new System.EventHandler(this.HMapOption_Changed);
            // 
            // tpSpectrum
            // 
            this.tpSpectrum.BackColor = System.Drawing.SystemColors.Control;
            this.tpSpectrum.Controls.Add(this.btnSpectrumColor8);
            this.tpSpectrum.Controls.Add(this.btnSpectrumColor7);
            this.tpSpectrum.Controls.Add(this.btnSpectrumColor6);
            this.tpSpectrum.Controls.Add(this.btnSpectrumColor5);
            this.tpSpectrum.Controls.Add(this.btnSpectrumColor4);
            this.tpSpectrum.Controls.Add(this.btnSpectrumColor3);
            this.tpSpectrum.Controls.Add(this.btnSpectrumColor2);
            this.tpSpectrum.Controls.Add(this.btnSpectrumColor1);
            this.tpSpectrum.Controls.Add(this.btnSpectrumColor0);
            this.tpSpectrum.Controls.Add(this.nudSpectrumRepeat);
            this.tpSpectrum.Controls.Add(this.cbbSpectrumStyle);
            this.tpSpectrum.Controls.Add(this.label7);
            this.tpSpectrum.Controls.Add(this.label8);
            this.tpSpectrum.Controls.Add(this.pbSpectrum);
            this.tpSpectrum.Location = new System.Drawing.Point(4, 22);
            this.tpSpectrum.Name = "tpSpectrum";
            this.tpSpectrum.Padding = new System.Windows.Forms.Padding(3);
            this.tpSpectrum.Size = new System.Drawing.Size(206, 104);
            this.tpSpectrum.TabIndex = 2;
            this.tpSpectrum.Text = "Spectrum";
            // 
            // btnSpectrumColor8
            // 
            this.btnSpectrumColor8.BackColor = System.Drawing.Color.Black;
            this.btnSpectrumColor8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpectrumColor8.Location = new System.Drawing.Point(176, 56);
            this.btnSpectrumColor8.Name = "btnSpectrumColor8";
            this.btnSpectrumColor8.Size = new System.Drawing.Size(16, 16);
            this.btnSpectrumColor8.TabIndex = 10;
            this.toolTip.SetToolTip(this.btnSpectrumColor8, "7-8 range color. Color of maximum");
            this.btnSpectrumColor8.UseVisualStyleBackColor = false;
            this.btnSpectrumColor8.BackColorChanged += new System.EventHandler(this.btnSpectrumColor_BackColorChanged);
            this.btnSpectrumColor8.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // btnSpectrumColor7
            // 
            this.btnSpectrumColor7.BackColor = System.Drawing.Color.White;
            this.btnSpectrumColor7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpectrumColor7.Location = new System.Drawing.Point(156, 56);
            this.btnSpectrumColor7.Name = "btnSpectrumColor7";
            this.btnSpectrumColor7.Size = new System.Drawing.Size(16, 16);
            this.btnSpectrumColor7.TabIndex = 9;
            this.toolTip.SetToolTip(this.btnSpectrumColor7, "6-7 range color");
            this.btnSpectrumColor7.UseVisualStyleBackColor = false;
            this.btnSpectrumColor7.BackColorChanged += new System.EventHandler(this.btnSpectrumColor_BackColorChanged);
            this.btnSpectrumColor7.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // btnSpectrumColor6
            // 
            this.btnSpectrumColor6.BackColor = System.Drawing.Color.Magenta;
            this.btnSpectrumColor6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpectrumColor6.Location = new System.Drawing.Point(136, 56);
            this.btnSpectrumColor6.Name = "btnSpectrumColor6";
            this.btnSpectrumColor6.Size = new System.Drawing.Size(16, 16);
            this.btnSpectrumColor6.TabIndex = 8;
            this.toolTip.SetToolTip(this.btnSpectrumColor6, "5-6 range color");
            this.btnSpectrumColor6.UseVisualStyleBackColor = false;
            this.btnSpectrumColor6.BackColorChanged += new System.EventHandler(this.btnSpectrumColor_BackColorChanged);
            this.btnSpectrumColor6.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // btnSpectrumColor5
            // 
            this.btnSpectrumColor5.BackColor = System.Drawing.Color.Red;
            this.btnSpectrumColor5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpectrumColor5.Location = new System.Drawing.Point(116, 56);
            this.btnSpectrumColor5.Name = "btnSpectrumColor5";
            this.btnSpectrumColor5.Size = new System.Drawing.Size(16, 16);
            this.btnSpectrumColor5.TabIndex = 7;
            this.toolTip.SetToolTip(this.btnSpectrumColor5, "4-5 range color");
            this.btnSpectrumColor5.UseVisualStyleBackColor = false;
            this.btnSpectrumColor5.BackColorChanged += new System.EventHandler(this.btnSpectrumColor_BackColorChanged);
            this.btnSpectrumColor5.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // btnSpectrumColor4
            // 
            this.btnSpectrumColor4.BackColor = System.Drawing.Color.Yellow;
            this.btnSpectrumColor4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpectrumColor4.Location = new System.Drawing.Point(96, 56);
            this.btnSpectrumColor4.Name = "btnSpectrumColor4";
            this.btnSpectrumColor4.Size = new System.Drawing.Size(16, 16);
            this.btnSpectrumColor4.TabIndex = 6;
            this.toolTip.SetToolTip(this.btnSpectrumColor4, "3-4 range color");
            this.btnSpectrumColor4.UseVisualStyleBackColor = false;
            this.btnSpectrumColor4.BackColorChanged += new System.EventHandler(this.btnSpectrumColor_BackColorChanged);
            this.btnSpectrumColor4.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // btnSpectrumColor3
            // 
            this.btnSpectrumColor3.BackColor = System.Drawing.Color.Green;
            this.btnSpectrumColor3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpectrumColor3.Location = new System.Drawing.Point(76, 56);
            this.btnSpectrumColor3.Name = "btnSpectrumColor3";
            this.btnSpectrumColor3.Size = new System.Drawing.Size(16, 16);
            this.btnSpectrumColor3.TabIndex = 5;
            this.toolTip.SetToolTip(this.btnSpectrumColor3, "2-3 range color");
            this.btnSpectrumColor3.UseVisualStyleBackColor = false;
            this.btnSpectrumColor3.BackColorChanged += new System.EventHandler(this.btnSpectrumColor_BackColorChanged);
            this.btnSpectrumColor3.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // btnSpectrumColor2
            // 
            this.btnSpectrumColor2.BackColor = System.Drawing.Color.Cyan;
            this.btnSpectrumColor2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpectrumColor2.Location = new System.Drawing.Point(56, 56);
            this.btnSpectrumColor2.Name = "btnSpectrumColor2";
            this.btnSpectrumColor2.Size = new System.Drawing.Size(16, 16);
            this.btnSpectrumColor2.TabIndex = 4;
            this.toolTip.SetToolTip(this.btnSpectrumColor2, "1-2 range color");
            this.btnSpectrumColor2.UseVisualStyleBackColor = false;
            this.btnSpectrumColor2.BackColorChanged += new System.EventHandler(this.btnSpectrumColor_BackColorChanged);
            this.btnSpectrumColor2.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // btnSpectrumColor1
            // 
            this.btnSpectrumColor1.BackColor = System.Drawing.Color.Blue;
            this.btnSpectrumColor1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpectrumColor1.Location = new System.Drawing.Point(36, 56);
            this.btnSpectrumColor1.Name = "btnSpectrumColor1";
            this.btnSpectrumColor1.Size = new System.Drawing.Size(16, 16);
            this.btnSpectrumColor1.TabIndex = 3;
            this.toolTip.SetToolTip(this.btnSpectrumColor1, "0-1 range color");
            this.btnSpectrumColor1.UseVisualStyleBackColor = false;
            this.btnSpectrumColor1.BackColorChanged += new System.EventHandler(this.btnSpectrumColor_BackColorChanged);
            this.btnSpectrumColor1.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // btnSpectrumColor0
            // 
            this.btnSpectrumColor0.BackColor = System.Drawing.Color.Black;
            this.btnSpectrumColor0.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpectrumColor0.Location = new System.Drawing.Point(16, 56);
            this.btnSpectrumColor0.Name = "btnSpectrumColor0";
            this.btnSpectrumColor0.Size = new System.Drawing.Size(16, 16);
            this.btnSpectrumColor0.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnSpectrumColor0, "0 color. Base color");
            this.btnSpectrumColor0.UseVisualStyleBackColor = false;
            this.btnSpectrumColor0.BackColorChanged += new System.EventHandler(this.btnSpectrumColor_BackColorChanged);
            this.btnSpectrumColor0.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // nudSpectrumRepeat
            // 
            this.nudSpectrumRepeat.Location = new System.Drawing.Point(48, 32);
            this.nudSpectrumRepeat.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudSpectrumRepeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpectrumRepeat.Name = "nudSpectrumRepeat";
            this.nudSpectrumRepeat.Size = new System.Drawing.Size(60, 20);
            this.nudSpectrumRepeat.TabIndex = 1;
            this.nudSpectrumRepeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.nudSpectrumRepeat, "Count of loops on range of 0-65,535");
            this.nudSpectrumRepeat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpectrumRepeat.ValueChanged += new System.EventHandler(this.HMapOption_Changed);
            // 
            // cbbSpectrumStyle
            // 
            this.cbbSpectrumStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbSpectrumStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSpectrumStyle.FormattingEnabled = true;
            this.cbbSpectrumStyle.Items.AddRange(new object[] {
            "KBCGYRMWK",
            "KGYRMBCWK",
            "KRMBCGYWK",
            "KBCRMGYWK",
            "KRMGYBCWK",
            "KGYBCRMWK"});
            this.cbbSpectrumStyle.Location = new System.Drawing.Point(48, 8);
            this.cbbSpectrumStyle.Name = "cbbSpectrumStyle";
            this.cbbSpectrumStyle.Size = new System.Drawing.Size(152, 21);
            this.cbbSpectrumStyle.TabIndex = 0;
            this.toolTip.SetToolTip(this.cbbSpectrumStyle, "Spectrum presets");
            this.cbbSpectrumStyle.SelectedIndexChanged += new System.EventHandler(this.cbbSpectrumPresets_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(4, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Preset";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(4, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Repeat";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbSpectrum
            // 
            this.pbSpectrum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbSpectrum.InitialImage = null;
            this.pbSpectrum.Location = new System.Drawing.Point(24, 76);
            this.pbSpectrum.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.pbSpectrum.Name = "pbSpectrum";
            this.pbSpectrum.Size = new System.Drawing.Size(162, 23);
            this.pbSpectrum.TabIndex = 2;
            this.pbSpectrum.TabStop = false;
            this.toolTip.SetToolTip(this.pbSpectrum, "Full 8 range spectrum");
            // 
            // gbFiles
            // 
            this.gbFiles.AutoSize = true;
            this.gbFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbFiles.Controls.Add(this.tableLayoutPanel6);
            this.gbFiles.Controls.Add(this.tableLayoutPanel4);
            this.gbFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFiles.Location = new System.Drawing.Point(3, 3);
            this.gbFiles.Name = "gbFiles";
            this.gbFiles.Padding = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.gbFiles.Size = new System.Drawing.Size(214, 154);
            this.gbFiles.TabIndex = 0;
            this.gbFiles.TabStop = false;
            this.gbFiles.Text = "Files";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.cbbLevelFormat8bit, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.chbLevelPixelBigLittleIndian, 2, 1);
            this.tableLayoutPanel6.Controls.Add(this.lblFileFormat, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbbLevelFormat16bit, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.chbLevelByteBigLittleIndian, 1, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 72);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(208, 77);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // cbbLevelFormat8bit
            // 
            this.cbbLevelFormat8bit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.cbbLevelFormat8bit, 2);
            this.cbbLevelFormat8bit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLevelFormat8bit.FormattingEnabled = true;
            this.cbbLevelFormat8bit.Items.AddRange(new object[] {
            "Hi*R + Lo*B",
            "Hi*G + Lo*B",
            "Hi*B + Lo*G",
            "Hi*R + Lo*G",
            "Hi*G + Lo*R",
            "Hi*B + Lo*R"});
            this.cbbLevelFormat8bit.Location = new System.Drawing.Point(48, 53);
            this.cbbLevelFormat8bit.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.cbbLevelFormat8bit.Name = "cbbLevelFormat8bit";
            this.cbbLevelFormat8bit.Size = new System.Drawing.Size(157, 21);
            this.cbbLevelFormat8bit.TabIndex = 11;
            this.toolTip.SetToolTip(this.cbbLevelFormat8bit, "Select which 2 8bit components will form height value");
            this.cbbLevelFormat8bit.Visible = false;
            this.cbbLevelFormat8bit.SelectedIndexChanged += new System.EventHandler(this.cbb_LevelFormat_Changed);
            // 
            // chbLevelPixelBigLittleIndian
            // 
            this.chbLevelPixelBigLittleIndian.AutoSize = true;
            this.chbLevelPixelBigLittleIndian.Checked = true;
            this.chbLevelPixelBigLittleIndian.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbLevelPixelBigLittleIndian.Location = new System.Drawing.Point(128, 30);
            this.chbLevelPixelBigLittleIndian.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chbLevelPixelBigLittleIndian.Name = "chbLevelPixelBigLittleIndian";
            this.chbLevelPixelBigLittleIndian.Size = new System.Drawing.Size(67, 17);
            this.chbLevelPixelBigLittleIndian.TabIndex = 10;
            this.chbLevelPixelBigLittleIndian.Text = "Pixel BLI";
            this.toolTip.SetToolTip(this.chbLevelPixelBigLittleIndian, "Big-Little indian sequence of pixels in byte");
            this.chbLevelPixelBigLittleIndian.UseVisualStyleBackColor = true;
            this.chbLevelPixelBigLittleIndian.Visible = false;
            this.chbLevelPixelBigLittleIndian.CheckedChanged += new System.EventHandler(this.cbb_LevelFormat_Changed);
            // 
            // lblFileFormat
            // 
            this.lblFileFormat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFileFormat.AutoSize = true;
            this.lblFileFormat.BackColor = System.Drawing.Color.Transparent;
            this.lblFileFormat.Location = new System.Drawing.Point(3, 32);
            this.lblFileFormat.Margin = new System.Windows.Forms.Padding(3);
            this.lblFileFormat.Name = "lblFileFormat";
            this.tableLayoutPanel6.SetRowSpan(this.lblFileFormat, 3);
            this.lblFileFormat.Size = new System.Drawing.Size(42, 13);
            this.lblFileFormat.TabIndex = 16;
            this.lblFileFormat.Text = "Format:";
            this.lblFileFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFileFormat.Visible = false;
            // 
            // cbbLevelFormat16bit
            // 
            this.cbbLevelFormat16bit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.cbbLevelFormat16bit, 2);
            this.cbbLevelFormat16bit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLevelFormat16bit.FormattingEnabled = true;
            this.cbbLevelFormat16bit.Items.AddRange(new object[] {
            "B",
            "G",
            "R"});
            this.cbbLevelFormat16bit.Location = new System.Drawing.Point(48, 3);
            this.cbbLevelFormat16bit.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.cbbLevelFormat16bit.Name = "cbbLevelFormat16bit";
            this.cbbLevelFormat16bit.Size = new System.Drawing.Size(157, 21);
            this.cbbLevelFormat16bit.TabIndex = 8;
            this.toolTip.SetToolTip(this.cbbLevelFormat16bit, "Select wich 16bit component will form height");
            this.cbbLevelFormat16bit.Visible = false;
            this.cbbLevelFormat16bit.SelectedIndexChanged += new System.EventHandler(this.cbb_LevelFormat_Changed);
            // 
            // chbLevelByteBigLittleIndian
            // 
            this.chbLevelByteBigLittleIndian.AutoSize = true;
            this.chbLevelByteBigLittleIndian.Checked = true;
            this.chbLevelByteBigLittleIndian.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbLevelByteBigLittleIndian.Location = new System.Drawing.Point(48, 30);
            this.chbLevelByteBigLittleIndian.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chbLevelByteBigLittleIndian.Name = "chbLevelByteBigLittleIndian";
            this.chbLevelByteBigLittleIndian.Size = new System.Drawing.Size(66, 17);
            this.chbLevelByteBigLittleIndian.TabIndex = 9;
            this.chbLevelByteBigLittleIndian.Text = "Byte BLI";
            this.toolTip.SetToolTip(this.chbLevelByteBigLittleIndian, "Big-Little indian sequence of bytes");
            this.chbLevelByteBigLittleIndian.UseVisualStyleBackColor = true;
            this.chbLevelByteBigLittleIndian.Visible = false;
            this.chbLevelByteBigLittleIndian.CheckedChanged += new System.EventHandler(this.cbb_LevelFormat_Changed);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.btnHMapResize, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblHMapSizes, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblTMapSizes, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnSaveHMap, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnLoadHMap, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnLoadTMap, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.chbShowHMap, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.chbShowTMap, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnTMapGenerate, 4, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(208, 56);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // btnHMapResize
            // 
            this.btnHMapResize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnHMapResize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHMapResize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnHMapResize.Image = global::SHME.Properties.Resources.resize;
            this.btnHMapResize.Location = new System.Drawing.Point(183, 1);
            this.btnHMapResize.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnHMapResize.Name = "btnHMapResize";
            this.btnHMapResize.Size = new System.Drawing.Size(25, 25);
            this.btnHMapResize.TabIndex = 7;
            this.btnHMapResize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.btnHMapResize, "Change canvas size");
            this.btnHMapResize.UseVisualStyleBackColor = true;
            this.btnHMapResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // lblHMapSizes
            // 
            this.lblHMapSizes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHMapSizes.BackColor = System.Drawing.Color.Transparent;
            this.lblHMapSizes.Location = new System.Drawing.Point(55, 7);
            this.lblHMapSizes.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lblHMapSizes.Name = "lblHMapSizes";
            this.lblHMapSizes.Size = new System.Drawing.Size(69, 13);
            this.lblHMapSizes.TabIndex = 16;
            this.lblHMapSizes.Text = "800 x 690";
            this.lblHMapSizes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTMapSizes
            // 
            this.lblTMapSizes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTMapSizes.BackColor = System.Drawing.Color.Transparent;
            this.lblTMapSizes.Location = new System.Drawing.Point(55, 35);
            this.lblTMapSizes.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lblTMapSizes.Name = "lblTMapSizes";
            this.lblTMapSizes.Size = new System.Drawing.Size(69, 13);
            this.lblTMapSizes.TabIndex = 22;
            this.lblTMapSizes.Text = "800 x 690";
            this.lblTMapSizes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveHMap
            // 
            this.btnSaveHMap.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSaveHMap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveHMap.BackgroundImage = global::SHME.Properties.Resources.markOption;
            this.btnSaveHMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSaveHMap.ContextMenuStrip = this.cmsSaveFile;
            this.btnSaveHMap.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveHMap.Image")));
            this.btnSaveHMap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveHMap.Location = new System.Drawing.Point(155, 1);
            this.btnSaveHMap.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnSaveHMap.Name = "btnSaveHMap";
            this.btnSaveHMap.Size = new System.Drawing.Size(28, 25);
            this.btnSaveHMap.TabIndex = 5;
            this.btnSaveHMap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveHMap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnSaveHMap, "Save as 16bit Portable Network Graphics (.png) or ...");
            this.btnSaveHMap.UseVisualStyleBackColor = true;
            this.btnSaveHMap.Click += new System.EventHandler(this.btnSaveHMap_Click);
            // 
            // cmsSaveFile
            // 
            this.cmsSaveFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSaveAs,
            this.tsmi8BitPNG,
            this.tsmiExportView});
            this.cmsSaveFile.Name = "cmsSaveFile";
            this.cmsSaveFile.Size = new System.Drawing.Size(175, 70);
            // 
            // tsmi8BitPNG
            // 
            this.tsmi8BitPNG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsmi8BitPNG.Image = ((System.Drawing.Image)(resources.GetObject("tsmi8BitPNG.Image")));
            this.tsmi8BitPNG.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmi8BitPNG.Name = "tsmi8BitPNG";
            this.tsmi8BitPNG.Size = new System.Drawing.Size(180, 22);
            this.tsmi8BitPNG.Text = "Save as 8 bit PNG...";
            this.tsmi8BitPNG.Click += new System.EventHandler(this.btnSaveHMap_Click);
            // 
            // tsmiExportView
            // 
            this.tsmiExportView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsmiExportView.Image = global::SHME.Properties.Resources.spectrum;
            this.tsmiExportView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiExportView.Name = "tsmiExportView";
            this.tsmiExportView.Size = new System.Drawing.Size(180, 22);
            this.tsmiExportView.Text = "Export view...";
            this.tsmiExportView.Click += new System.EventHandler(this.tsmiExportView_Click);
            // 
            // btnLoadHMap
            // 
            this.btnLoadHMap.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLoadHMap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoadHMap.BackgroundImage = global::SHME.Properties.Resources.markOption;
            this.btnLoadHMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLoadHMap.ContextMenuStrip = this.cmsOpenFile;
            this.btnLoadHMap.Image = global::SHME.Properties.Resources.load;
            this.btnLoadHMap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadHMap.Location = new System.Drawing.Point(127, 1);
            this.btnLoadHMap.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnLoadHMap.Name = "btnLoadHMap";
            this.btnLoadHMap.Size = new System.Drawing.Size(28, 25);
            this.btnLoadHMap.TabIndex = 3;
            this.btnLoadHMap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.btnLoadHMap, "Load height map (8/16bit PNG, bitmap,.. ) or ...");
            this.btnLoadHMap.UseVisualStyleBackColor = true;
            this.btnLoadHMap.Click += new System.EventHandler(this.btnLoadHMap_Click);
            // 
            // btnLoadTMap
            // 
            this.btnLoadTMap.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLoadTMap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoadTMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLoadTMap.Image = global::SHME.Properties.Resources.load;
            this.btnLoadTMap.Location = new System.Drawing.Point(127, 29);
            this.btnLoadTMap.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnLoadTMap.Name = "btnLoadTMap";
            this.btnLoadTMap.Size = new System.Drawing.Size(28, 25);
            this.btnLoadTMap.TabIndex = 4;
            this.btnLoadTMap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.btnLoadTMap, "Load topographic map");
            this.btnLoadTMap.UseVisualStyleBackColor = true;
            this.btnLoadTMap.Click += new System.EventHandler(this.btnLoadTMap_Click);
            // 
            // chbShowHMap
            // 
            this.chbShowHMap.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbShowHMap.Checked = true;
            this.chbShowHMap.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chbShowHMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbShowHMap.Location = new System.Drawing.Point(3, 3);
            this.chbShowHMap.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.chbShowHMap.Name = "chbShowHMap";
            this.chbShowHMap.Size = new System.Drawing.Size(49, 22);
            this.chbShowHMap.TabIndex = 0;
            this.chbShowHMap.Text = "HMap";
            this.chbShowHMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbShowHMap.ThreeState = true;
            this.toolTip.SetToolTip(this.chbShowHMap, "Switch between height and topographic map");
            this.chbShowHMap.UseVisualStyleBackColor = true;
            this.chbShowHMap.CheckStateChanged += new System.EventHandler(this.SwitchView);
            // 
            // chbShowTMap
            // 
            this.chbShowTMap.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbShowTMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbShowTMap.Location = new System.Drawing.Point(3, 31);
            this.chbShowTMap.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.chbShowTMap.Name = "chbShowTMap";
            this.chbShowTMap.Size = new System.Drawing.Size(49, 22);
            this.chbShowTMap.TabIndex = 1;
            this.chbShowTMap.Text = "TMap";
            this.chbShowTMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbShowTMap.ThreeState = true;
            this.toolTip.SetToolTip(this.chbShowTMap, "Switch between height and topographic map");
            this.chbShowTMap.UseVisualStyleBackColor = true;
            this.chbShowTMap.CheckStateChanged += new System.EventHandler(this.SwitchView);
            // 
            // btnTMapGenerate
            // 
            this.btnTMapGenerate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnTMapGenerate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTMapGenerate.BackColor = System.Drawing.Color.LightGray;
            this.btnTMapGenerate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTMapGenerate.Image = global::SHME.Properties.Resources.grid;
            this.btnTMapGenerate.Location = new System.Drawing.Point(183, 29);
            this.btnTMapGenerate.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnTMapGenerate.Name = "btnTMapGenerate";
            this.btnTMapGenerate.Size = new System.Drawing.Size(25, 25);
            this.btnTMapGenerate.TabIndex = 6;
            this.toolTip.SetToolTip(this.btnTMapGenerate, "Generate grid background");
            this.btnTMapGenerate.UseVisualStyleBackColor = false;
            this.btnTMapGenerate.Click += new System.EventHandler(this.btnTMapGenerate_Click);
            // 
            // tlpTools
            // 
            this.tlpTools.ColumnCount = 1;
            this.tlpTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTools.Controls.Add(this.tcThemes, 0, 1);
            this.tlpTools.Controls.Add(this.gbFiles, 0, 0);
            this.tlpTools.Controls.Add(this.gbTools, 0, 3);
            this.tlpTools.Controls.Add(this.gbStatistics, 0, 2);
            this.tlpTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlpTools.Location = new System.Drawing.Point(0, 0);
            this.tlpTools.Name = "tlpTools";
            this.tlpTools.RowCount = 4;
            this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTools.Size = new System.Drawing.Size(220, 662);
            this.tlpTools.TabIndex = 3;
            // 
            // gbTools
            // 
            this.gbTools.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbTools.Controls.Add(this.chbHexValues);
            this.gbTools.Controls.Add(this.btnToolsetRemove);
            this.gbTools.Controls.Add(this.btnToolsetAdd);
            this.gbTools.Controls.Add(this.label17);
            this.gbTools.Controls.Add(this.cbbToolsetPreset);
            this.gbTools.Controls.Add(this.btnToolRMB);
            this.gbTools.Controls.Add(this.btnToolX2MB);
            this.gbTools.Controls.Add(this.btnToolX1MB);
            this.gbTools.Controls.Add(this.btnToolLMB);
            this.gbTools.Controls.Add(this.pnlTools);
            this.gbTools.Controls.Add(this.btnToolMMB);
            this.gbTools.Controls.Add(this.pbMouseButtons);
            this.gbTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTools.Location = new System.Drawing.Point(3, 401);
            this.gbTools.Name = "gbTools";
            this.gbTools.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.gbTools.Size = new System.Drawing.Size(214, 258);
            this.gbTools.TabIndex = 4;
            this.gbTools.TabStop = false;
            this.gbTools.Text = "Tools";
            // 
            // chbHexValues
            // 
            this.chbHexValues.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbHexValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbHexValues.Location = new System.Drawing.Point(164, 66);
            this.chbHexValues.Margin = new System.Windows.Forms.Padding(0);
            this.chbHexValues.Name = "chbHexValues";
            this.chbHexValues.Size = new System.Drawing.Size(39, 23);
            this.chbHexValues.TabIndex = 26;
            this.chbHexValues.Text = "Hex";
            this.chbHexValues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.chbHexValues, "Switch: decimal / hexadecimal");
            this.chbHexValues.UseVisualStyleBackColor = true;
            this.chbHexValues.CheckedChanged += new System.EventHandler(this.chbHexValues_CheckedChanged);
            // 
            // btnToolsetRemove
            // 
            this.btnToolsetRemove.Enabled = false;
            this.btnToolsetRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolsetRemove.Image = global::SHME.Properties.Resources.delete;
            this.btnToolsetRemove.Location = new System.Drawing.Point(160, 40);
            this.btnToolsetRemove.Name = "btnToolsetRemove";
            this.btnToolsetRemove.Size = new System.Drawing.Size(23, 23);
            this.btnToolsetRemove.TabIndex = 25;
            this.btnToolsetRemove.UseVisualStyleBackColor = true;
            this.btnToolsetRemove.Click += new System.EventHandler(this.btnToolsetRemove_Click);
            // 
            // btnToolsetAdd
            // 
            this.btnToolsetAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolsetAdd.Image = global::SHME.Properties.Resources.add;
            this.btnToolsetAdd.Location = new System.Drawing.Point(184, 40);
            this.btnToolsetAdd.Name = "btnToolsetAdd";
            this.btnToolsetAdd.Size = new System.Drawing.Size(23, 23);
            this.btnToolsetAdd.TabIndex = 25;
            this.btnToolsetAdd.UseVisualStyleBackColor = true;
            this.btnToolsetAdd.Click += new System.EventHandler(this.btnToolsetAdd_Click);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(4, 16);
            this.label17.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 17);
            this.label17.TabIndex = 24;
            this.label17.Text = "Preset";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbToolsetPreset
            // 
            this.cbbToolsetPreset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbToolsetPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbToolsetPreset.DropDownWidth = 220;
            this.cbbToolsetPreset.FormattingEnabled = true;
            this.cbbToolsetPreset.Location = new System.Drawing.Point(48, 16);
            this.cbbToolsetPreset.Name = "cbbToolsetPreset";
            this.cbbToolsetPreset.Size = new System.Drawing.Size(160, 21);
            this.cbbToolsetPreset.TabIndex = 0;
            this.toolTip.SetToolTip(this.cbbToolsetPreset, "Toolset presets");
            this.cbbToolsetPreset.SelectedIndexChanged += new System.EventHandler(this.cbbToolsetPreset_SelectedIndexChanged);
            // 
            // btnToolRMB
            // 
            this.btnToolRMB.BackColor = System.Drawing.Color.Transparent;
            this.btnToolRMB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnToolRMB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolRMB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolRMB.Location = new System.Drawing.Point(84, 56);
            this.btnToolRMB.Name = "btnToolRMB";
            this.btnToolRMB.Size = new System.Drawing.Size(32, 32);
            this.btnToolRMB.TabIndex = 3;
            this.btnToolRMB.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.toolTip.SetToolTip(this.btnToolRMB, "Right mouse button");
            this.btnToolRMB.UseVisualStyleBackColor = false;
            this.btnToolRMB.Click += new System.EventHandler(this.btnToolXMB_Click);
            // 
            // btnToolX2MB
            // 
            this.btnToolX2MB.BackColor = System.Drawing.Color.Transparent;
            this.btnToolX2MB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnToolX2MB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolX2MB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolX2MB.Location = new System.Drawing.Point(8, 128);
            this.btnToolX2MB.Name = "btnToolX2MB";
            this.btnToolX2MB.Size = new System.Drawing.Size(32, 32);
            this.btnToolX2MB.TabIndex = 5;
            this.btnToolX2MB.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.toolTip.SetToolTip(this.btnToolX2MB, "X2 (side) mouse button");
            this.btnToolX2MB.UseVisualStyleBackColor = false;
            this.btnToolX2MB.Click += new System.EventHandler(this.btnToolXMB_Click);
            // 
            // btnToolX1MB
            // 
            this.btnToolX1MB.BackColor = System.Drawing.Color.Transparent;
            this.btnToolX1MB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnToolX1MB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolX1MB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolX1MB.Location = new System.Drawing.Point(8, 92);
            this.btnToolX1MB.Name = "btnToolX1MB";
            this.btnToolX1MB.Size = new System.Drawing.Size(32, 32);
            this.btnToolX1MB.TabIndex = 4;
            this.btnToolX1MB.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.toolTip.SetToolTip(this.btnToolX1MB, "X1 (side) mouse button");
            this.btnToolX1MB.UseVisualStyleBackColor = false;
            this.btnToolX1MB.Click += new System.EventHandler(this.btnToolXMB_Click);
            // 
            // btnToolLMB
            // 
            this.btnToolLMB.BackColor = System.Drawing.Color.Transparent;
            this.btnToolLMB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnToolLMB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolLMB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolLMB.Location = new System.Drawing.Point(10, 56);
            this.btnToolLMB.Name = "btnToolLMB";
            this.btnToolLMB.Size = new System.Drawing.Size(32, 32);
            this.btnToolLMB.TabIndex = 1;
            this.btnToolLMB.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.toolTip.SetToolTip(this.btnToolLMB, "Left mouse button");
            this.btnToolLMB.UseVisualStyleBackColor = false;
            this.btnToolLMB.Click += new System.EventHandler(this.btnToolXMB_Click);
            // 
            // pnlTools
            // 
            this.pnlTools.AutoSize = true;
            this.pnlTools.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlTools.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTools.Controls.Add(this.pnlBrush3);
            this.pnlTools.Controls.Add(this.pnlBrush2);
            this.pnlTools.Controls.Add(this.pnlBrush1);
            this.pnlTools.Controls.Add(this.label20);
            this.pnlTools.Controls.Add(this.label22);
            this.pnlTools.Controls.Add(this.label21);
            this.pnlTools.Location = new System.Drawing.Point(44, 92);
            this.pnlTools.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(169, 161);
            this.pnlTools.TabIndex = 22;
            // 
            // pnlBrush3
            // 
            this.pnlBrush3.AutoSize = true;
            this.pnlBrush3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlBrush3.Controls.Add(this.chbBrush3FrameShow);
            this.pnlBrush3.Controls.Add(this.tbBrush3ForceHex);
            this.pnlBrush3.Controls.Add(this.nudBrush3ForceDecimal);
            this.pnlBrush3.Controls.Add(this.nudBrush3Height);
            this.pnlBrush3.Controls.Add(this.tbBrush3ValueHex);
            this.pnlBrush3.Controls.Add(this.btnBrush3Distribution);
            this.pnlBrush3.Controls.Add(this.label25);
            this.pnlBrush3.Controls.Add(this.nudBrush3Width);
            this.pnlBrush3.Controls.Add(this.nudBrush3ValueDecimal);
            this.pnlBrush3.Controls.Add(this.chbBrush3Shape);
            this.pnlBrush3.Controls.Add(this.label27);
            this.pnlBrush3.Controls.Add(this.label30);
            this.pnlBrush3.Location = new System.Drawing.Point(0, 116);
            this.pnlBrush3.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBrush3.Name = "pnlBrush3";
            this.pnlBrush3.Size = new System.Drawing.Size(167, 43);
            this.pnlBrush3.TabIndex = 13;
            // 
            // chbBrush3FrameShow
            // 
            this.chbBrush3FrameShow.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbBrush3FrameShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.chbBrush3FrameShow.BackgroundImage = global::SHME.Properties.Resources.eye;
            this.chbBrush3FrameShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chbBrush3FrameShow.Checked = true;
            this.chbBrush3FrameShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbBrush3FrameShow.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chbBrush3FrameShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbBrush3FrameShow.Location = new System.Drawing.Point(4, 24);
            this.chbBrush3FrameShow.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.chbBrush3FrameShow.Name = "chbBrush3FrameShow";
            this.chbBrush3FrameShow.Size = new System.Drawing.Size(18, 14);
            this.chbBrush3FrameShow.TabIndex = 28;
            this.chbBrush3FrameShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.chbBrush3FrameShow, "Brush shape");
            this.chbBrush3FrameShow.UseVisualStyleBackColor = false;
            // 
            // tbBrush3ForceHex
            // 
            this.tbBrush3ForceHex.Location = new System.Drawing.Point(112, 20);
            this.tbBrush3ForceHex.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tbBrush3ForceHex.MaxLength = 7;
            this.tbBrush3ForceHex.Name = "tbBrush3ForceHex";
            this.tbBrush3ForceHex.Size = new System.Drawing.Size(36, 20);
            this.tbBrush3ForceHex.TabIndex = 25;
            this.tbBrush3ForceHex.Text = "0001";
            this.tbBrush3ForceHex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.tbBrush3ForceHex, "4 hexadecimals (0-9, A-F)");
            this.tbBrush3ForceHex.Visible = false;
            this.tbBrush3ForceHex.WordWrap = false;
            this.tbBrush3ForceHex.TabStopChanged += new System.EventHandler(this.tbBrush3ForceHex_TextChanged);
            // 
            // nudBrush3ForceDecimal
            // 
            this.nudBrush3ForceDecimal.Location = new System.Drawing.Point(112, 20);
            this.nudBrush3ForceDecimal.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudBrush3ForceDecimal.Name = "nudBrush3ForceDecimal";
            this.nudBrush3ForceDecimal.Size = new System.Drawing.Size(52, 20);
            this.nudBrush3ForceDecimal.TabIndex = 26;
            this.nudBrush3ForceDecimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudBrush3ForceDecimal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBrush3ForceDecimal.ValueChanged += new System.EventHandler(this.nudBrush3Force_ValueChanged);
            // 
            // nudBrush3Height
            // 
            this.nudBrush3Height.Location = new System.Drawing.Point(72, 0);
            this.nudBrush3Height.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudBrush3Height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBrush3Height.Name = "nudBrush3Height";
            this.nudBrush3Height.Size = new System.Drawing.Size(32, 20);
            this.nudBrush3Height.TabIndex = 24;
            this.nudBrush3Height.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.nudBrush3Height, "Brush size");
            this.nudBrush3Height.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudBrush3Height.ValueChanged += new System.EventHandler(this.nudBrush3Size_ValueChanged);
            // 
            // tbBrush3ValueHex
            // 
            this.tbBrush3ValueHex.Location = new System.Drawing.Point(112, 0);
            this.tbBrush3ValueHex.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tbBrush3ValueHex.MaxLength = 7;
            this.tbBrush3ValueHex.Name = "tbBrush3ValueHex";
            this.tbBrush3ValueHex.Size = new System.Drawing.Size(36, 20);
            this.tbBrush3ValueHex.TabIndex = 8;
            this.tbBrush3ValueHex.Text = "0001";
            this.tbBrush3ValueHex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.tbBrush3ValueHex, "4 hexadecimals (0-9, A-F)");
            this.tbBrush3ValueHex.Visible = false;
            this.tbBrush3ValueHex.WordWrap = false;
            this.tbBrush3ValueHex.TextChanged += new System.EventHandler(this.tbBrush3ValueHex_TextChanged);
            // 
            // btnBrush3Distribution
            // 
            this.btnBrush3Distribution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrush3Distribution.ImageIndex = 0;
            this.btnBrush3Distribution.ImageList = this.ilToolForce;
            this.btnBrush3Distribution.Location = new System.Drawing.Point(48, 20);
            this.btnBrush3Distribution.Name = "btnBrush3Distribution";
            this.btnBrush3Distribution.Size = new System.Drawing.Size(20, 20);
            this.btnBrush3Distribution.TabIndex = 11;
            this.toolTip.SetToolTip(this.btnBrush3Distribution, "Brush force shape");
            this.btnBrush3Distribution.UseVisualStyleBackColor = true;
            this.btnBrush3Distribution.Click += new System.EventHandler(this.btnBrush3Distribution_Click);
            // 
            // ilToolForce
            // 
            this.ilToolForce.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilToolForce.ImageStream")));
            this.ilToolForce.TransparentColor = System.Drawing.Color.Transparent;
            this.ilToolForce.Images.SetKeyName(0, "brushForceSquare.png");
            this.ilToolForce.Images.SetKeyName(1, "brushForceSphere.png");
            this.ilToolForce.Images.SetKeyName(2, "brushForceGauss.png");
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Location = new System.Drawing.Point(4, 4);
            this.label25.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(16, 16);
            this.label25.TabIndex = 20;
            this.label25.Text = "3:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudBrush3Width
            // 
            this.nudBrush3Width.Location = new System.Drawing.Point(28, 0);
            this.nudBrush3Width.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudBrush3Width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBrush3Width.Name = "nudBrush3Width";
            this.nudBrush3Width.Size = new System.Drawing.Size(32, 20);
            this.nudBrush3Width.TabIndex = 17;
            this.nudBrush3Width.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.nudBrush3Width, "Brush size");
            this.nudBrush3Width.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudBrush3Width.ValueChanged += new System.EventHandler(this.nudBrush3Size_ValueChanged);
            // 
            // nudBrush3ValueDecimal
            // 
            this.nudBrush3ValueDecimal.Location = new System.Drawing.Point(112, 0);
            this.nudBrush3ValueDecimal.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudBrush3ValueDecimal.Name = "nudBrush3ValueDecimal";
            this.nudBrush3ValueDecimal.Size = new System.Drawing.Size(52, 20);
            this.nudBrush3ValueDecimal.TabIndex = 8;
            this.nudBrush3ValueDecimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudBrush3ValueDecimal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBrush3ValueDecimal.ValueChanged += new System.EventHandler(this.nudBrush3Value_ValueChanged);
            // 
            // chbBrush3Shape
            // 
            this.chbBrush3Shape.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbBrush3Shape.BackColor = System.Drawing.SystemColors.Control;
            this.chbBrush3Shape.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chbBrush3Shape.BackgroundImage")));
            this.chbBrush3Shape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chbBrush3Shape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbBrush3Shape.ImageList = this.ilToolShape;
            this.chbBrush3Shape.Location = new System.Drawing.Point(28, 20);
            this.chbBrush3Shape.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.chbBrush3Shape.Name = "chbBrush3Shape";
            this.chbBrush3Shape.Size = new System.Drawing.Size(20, 20);
            this.chbBrush3Shape.TabIndex = 14;
            this.chbBrush3Shape.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.chbBrush3Shape, "Brush shape");
            this.chbBrush3Shape.UseVisualStyleBackColor = false;
            this.chbBrush3Shape.CheckedChanged += new System.EventHandler(this.chbBrushXShape_CheckedChanged);
            this.chbBrush3Shape.BackgroundImageChanged += new System.EventHandler(this.nudBrush3Size_ValueChanged);
            // 
            // ilToolShape
            // 
            this.ilToolShape.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilToolShape.ImageStream")));
            this.ilToolShape.TransparentColor = System.Drawing.Color.Transparent;
            this.ilToolShape.Images.SetKeyName(0, "circle.png");
            this.ilToolShape.Images.SetKeyName(1, "square.png");
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Location = new System.Drawing.Point(60, 0);
            this.label27.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(14, 16);
            this.label27.TabIndex = 23;
            this.label27.Text = "x";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Location = new System.Drawing.Point(76, 24);
            this.label30.Margin = new System.Windows.Forms.Padding(0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(37, 13);
            this.label30.TabIndex = 27;
            this.label30.Text = "Force:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.label30, "Force of pencil");
            // 
            // pnlBrush2
            // 
            this.pnlBrush2.AutoSize = true;
            this.pnlBrush2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlBrush2.Controls.Add(this.chbBrush2FrameShow);
            this.pnlBrush2.Controls.Add(this.tbBrush2ForceHex);
            this.pnlBrush2.Controls.Add(this.nudBrush2ForceDecimal);
            this.pnlBrush2.Controls.Add(this.nudBrush2Height);
            this.pnlBrush2.Controls.Add(this.tbBrush2ValueHex);
            this.pnlBrush2.Controls.Add(this.label24);
            this.pnlBrush2.Controls.Add(this.btnBrush2Distribution);
            this.pnlBrush2.Controls.Add(this.nudBrush2ValueDecimal);
            this.pnlBrush2.Controls.Add(this.chbBrush2Shape);
            this.pnlBrush2.Controls.Add(this.nudBrush2Width);
            this.pnlBrush2.Controls.Add(this.label26);
            this.pnlBrush2.Controls.Add(this.label29);
            this.pnlBrush2.Location = new System.Drawing.Point(0, 68);
            this.pnlBrush2.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBrush2.Name = "pnlBrush2";
            this.pnlBrush2.Size = new System.Drawing.Size(167, 43);
            this.pnlBrush2.TabIndex = 14;
            // 
            // chbBrush2FrameShow
            // 
            this.chbBrush2FrameShow.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbBrush2FrameShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.chbBrush2FrameShow.BackgroundImage = global::SHME.Properties.Resources.eye;
            this.chbBrush2FrameShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chbBrush2FrameShow.Checked = true;
            this.chbBrush2FrameShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbBrush2FrameShow.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chbBrush2FrameShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbBrush2FrameShow.Location = new System.Drawing.Point(4, 24);
            this.chbBrush2FrameShow.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.chbBrush2FrameShow.Name = "chbBrush2FrameShow";
            this.chbBrush2FrameShow.Size = new System.Drawing.Size(18, 14);
            this.chbBrush2FrameShow.TabIndex = 28;
            this.chbBrush2FrameShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.chbBrush2FrameShow, "Brush shape");
            this.chbBrush2FrameShow.UseVisualStyleBackColor = false;
            // 
            // tbBrush2ForceHex
            // 
            this.tbBrush2ForceHex.Location = new System.Drawing.Point(112, 20);
            this.tbBrush2ForceHex.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tbBrush2ForceHex.MaxLength = 7;
            this.tbBrush2ForceHex.Name = "tbBrush2ForceHex";
            this.tbBrush2ForceHex.Size = new System.Drawing.Size(36, 20);
            this.tbBrush2ForceHex.TabIndex = 25;
            this.tbBrush2ForceHex.Text = "0010";
            this.tbBrush2ForceHex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.tbBrush2ForceHex, "4 hexadecimals (0-9, A-F)");
            this.tbBrush2ForceHex.Visible = false;
            this.tbBrush2ForceHex.WordWrap = false;
            this.tbBrush2ForceHex.TextAlignChanged += new System.EventHandler(this.tbBrush2ForceHex_TextChanged);
            // 
            // nudBrush2ForceDecimal
            // 
            this.nudBrush2ForceDecimal.Location = new System.Drawing.Point(112, 20);
            this.nudBrush2ForceDecimal.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudBrush2ForceDecimal.Name = "nudBrush2ForceDecimal";
            this.nudBrush2ForceDecimal.Size = new System.Drawing.Size(52, 20);
            this.nudBrush2ForceDecimal.TabIndex = 26;
            this.nudBrush2ForceDecimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudBrush2ForceDecimal.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudBrush2ForceDecimal.ValueChanged += new System.EventHandler(this.nudBrush2Force_ValueChanged);
            // 
            // nudBrush2Height
            // 
            this.nudBrush2Height.Location = new System.Drawing.Point(72, 0);
            this.nudBrush2Height.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudBrush2Height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBrush2Height.Name = "nudBrush2Height";
            this.nudBrush2Height.Size = new System.Drawing.Size(32, 20);
            this.nudBrush2Height.TabIndex = 24;
            this.nudBrush2Height.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.nudBrush2Height, "Brush size");
            this.nudBrush2Height.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudBrush2Height.ValueChanged += new System.EventHandler(this.nudBrush2Size_ValueChanged);
            // 
            // tbBrush2ValueHex
            // 
            this.tbBrush2ValueHex.Location = new System.Drawing.Point(112, 0);
            this.tbBrush2ValueHex.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tbBrush2ValueHex.MaxLength = 7;
            this.tbBrush2ValueHex.Name = "tbBrush2ValueHex";
            this.tbBrush2ValueHex.Size = new System.Drawing.Size(36, 20);
            this.tbBrush2ValueHex.TabIndex = 7;
            this.tbBrush2ValueHex.Text = "0010";
            this.tbBrush2ValueHex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.tbBrush2ValueHex, "4 hexadecimals (0-9, A-F)");
            this.tbBrush2ValueHex.Visible = false;
            this.tbBrush2ValueHex.WordWrap = false;
            this.tbBrush2ValueHex.TextChanged += new System.EventHandler(this.tbBrush2ValueHex_TextChanged);
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Location = new System.Drawing.Point(4, 4);
            this.label24.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(16, 16);
            this.label24.TabIndex = 20;
            this.label24.Text = "2:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBrush2Distribution
            // 
            this.btnBrush2Distribution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrush2Distribution.ImageIndex = 0;
            this.btnBrush2Distribution.ImageList = this.ilToolForce;
            this.btnBrush2Distribution.Location = new System.Drawing.Point(48, 20);
            this.btnBrush2Distribution.Name = "btnBrush2Distribution";
            this.btnBrush2Distribution.Size = new System.Drawing.Size(20, 20);
            this.btnBrush2Distribution.TabIndex = 10;
            this.toolTip.SetToolTip(this.btnBrush2Distribution, "Brush force shape");
            this.btnBrush2Distribution.UseVisualStyleBackColor = true;
            this.btnBrush2Distribution.Click += new System.EventHandler(this.btnBrush2Distribution_Click);
            // 
            // nudBrush2ValueDecimal
            // 
            this.nudBrush2ValueDecimal.Location = new System.Drawing.Point(112, 0);
            this.nudBrush2ValueDecimal.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudBrush2ValueDecimal.Name = "nudBrush2ValueDecimal";
            this.nudBrush2ValueDecimal.Size = new System.Drawing.Size(52, 20);
            this.nudBrush2ValueDecimal.TabIndex = 7;
            this.nudBrush2ValueDecimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudBrush2ValueDecimal.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudBrush2ValueDecimal.ValueChanged += new System.EventHandler(this.nudBrush2Value_ValueChanged);
            // 
            // chbBrush2Shape
            // 
            this.chbBrush2Shape.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbBrush2Shape.BackColor = System.Drawing.SystemColors.Control;
            this.chbBrush2Shape.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chbBrush2Shape.BackgroundImage")));
            this.chbBrush2Shape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chbBrush2Shape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbBrush2Shape.ImageList = this.ilToolShape;
            this.chbBrush2Shape.Location = new System.Drawing.Point(28, 20);
            this.chbBrush2Shape.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.chbBrush2Shape.Name = "chbBrush2Shape";
            this.chbBrush2Shape.Size = new System.Drawing.Size(20, 20);
            this.chbBrush2Shape.TabIndex = 13;
            this.chbBrush2Shape.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.chbBrush2Shape, "Brush shape");
            this.chbBrush2Shape.UseVisualStyleBackColor = false;
            this.chbBrush2Shape.CheckedChanged += new System.EventHandler(this.chbBrushXShape_CheckedChanged);
            this.chbBrush2Shape.BackgroundImageChanged += new System.EventHandler(this.nudBrush2Size_ValueChanged);
            // 
            // nudBrush2Width
            // 
            this.nudBrush2Width.Location = new System.Drawing.Point(28, 0);
            this.nudBrush2Width.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudBrush2Width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBrush2Width.Name = "nudBrush2Width";
            this.nudBrush2Width.Size = new System.Drawing.Size(32, 20);
            this.nudBrush2Width.TabIndex = 16;
            this.nudBrush2Width.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.nudBrush2Width, "Brush size");
            this.nudBrush2Width.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudBrush2Width.ValueChanged += new System.EventHandler(this.nudBrush2Size_ValueChanged);
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Location = new System.Drawing.Point(60, 0);
            this.label26.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(14, 16);
            this.label26.TabIndex = 23;
            this.label26.Text = "x";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Location = new System.Drawing.Point(76, 24);
            this.label29.Margin = new System.Windows.Forms.Padding(0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(37, 13);
            this.label29.TabIndex = 27;
            this.label29.Text = "Force:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.label29, "Force of pencil");
            // 
            // pnlBrush1
            // 
            this.pnlBrush1.AutoSize = true;
            this.pnlBrush1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlBrush1.Controls.Add(this.chbBrush1FrameShow);
            this.pnlBrush1.Controls.Add(this.nudBrush1Width);
            this.pnlBrush1.Controls.Add(this.tbBrush1ForceHex);
            this.pnlBrush1.Controls.Add(this.nudBrush1Height);
            this.pnlBrush1.Controls.Add(this.btnBrush1Distribution);
            this.pnlBrush1.Controls.Add(this.tbBrush1ValueHex);
            this.pnlBrush1.Controls.Add(this.nudBrush1ValueDecimal);
            this.pnlBrush1.Controls.Add(this.nudBrush1ForceDecimal);
            this.pnlBrush1.Controls.Add(this.chbBrush1Shape);
            this.pnlBrush1.Controls.Add(this.label19);
            this.pnlBrush1.Controls.Add(this.label23);
            this.pnlBrush1.Controls.Add(this.label28);
            this.pnlBrush1.Location = new System.Drawing.Point(0, 20);
            this.pnlBrush1.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBrush1.Name = "pnlBrush1";
            this.pnlBrush1.Size = new System.Drawing.Size(167, 43);
            this.pnlBrush1.TabIndex = 12;
            // 
            // chbBrush1FrameShow
            // 
            this.chbBrush1FrameShow.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbBrush1FrameShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.chbBrush1FrameShow.BackgroundImage = global::SHME.Properties.Resources.eye;
            this.chbBrush1FrameShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chbBrush1FrameShow.Checked = true;
            this.chbBrush1FrameShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbBrush1FrameShow.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chbBrush1FrameShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbBrush1FrameShow.Location = new System.Drawing.Point(4, 24);
            this.chbBrush1FrameShow.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.chbBrush1FrameShow.Name = "chbBrush1FrameShow";
            this.chbBrush1FrameShow.Size = new System.Drawing.Size(18, 14);
            this.chbBrush1FrameShow.TabIndex = 26;
            this.chbBrush1FrameShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.chbBrush1FrameShow, "Brush shape");
            this.chbBrush1FrameShow.UseVisualStyleBackColor = false;
            // 
            // nudBrush1Width
            // 
            this.nudBrush1Width.Location = new System.Drawing.Point(28, 0);
            this.nudBrush1Width.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudBrush1Width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBrush1Width.Name = "nudBrush1Width";
            this.nudBrush1Width.Size = new System.Drawing.Size(32, 20);
            this.nudBrush1Width.TabIndex = 21;
            this.nudBrush1Width.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.nudBrush1Width, "Brush size");
            this.nudBrush1Width.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudBrush1Width.ValueChanged += new System.EventHandler(this.nudBrush1Size_ValueChanged);
            // 
            // tbBrush1ForceHex
            // 
            this.tbBrush1ForceHex.Location = new System.Drawing.Point(112, 20);
            this.tbBrush1ForceHex.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tbBrush1ForceHex.MaxLength = 7;
            this.tbBrush1ForceHex.Name = "tbBrush1ForceHex";
            this.tbBrush1ForceHex.Size = new System.Drawing.Size(36, 20);
            this.tbBrush1ForceHex.TabIndex = 23;
            this.tbBrush1ForceHex.Text = "0100";
            this.tbBrush1ForceHex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.tbBrush1ForceHex, "4 hexadecimals (0-9, A-F)");
            this.tbBrush1ForceHex.Visible = false;
            this.tbBrush1ForceHex.WordWrap = false;
            this.tbBrush1ForceHex.TextChanged += new System.EventHandler(this.tbBrush1ForceHex_TextChanged);
            // 
            // nudBrush1Height
            // 
            this.nudBrush1Height.Location = new System.Drawing.Point(72, 0);
            this.nudBrush1Height.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudBrush1Height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBrush1Height.Name = "nudBrush1Height";
            this.nudBrush1Height.Size = new System.Drawing.Size(32, 20);
            this.nudBrush1Height.TabIndex = 15;
            this.nudBrush1Height.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.nudBrush1Height, "Brush size");
            this.nudBrush1Height.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudBrush1Height.ValueChanged += new System.EventHandler(this.nudBrush1Size_ValueChanged);
            // 
            // btnBrush1Distribution
            // 
            this.btnBrush1Distribution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrush1Distribution.ImageIndex = 0;
            this.btnBrush1Distribution.ImageList = this.ilToolForce;
            this.btnBrush1Distribution.Location = new System.Drawing.Point(48, 20);
            this.btnBrush1Distribution.Name = "btnBrush1Distribution";
            this.btnBrush1Distribution.Size = new System.Drawing.Size(20, 20);
            this.btnBrush1Distribution.TabIndex = 9;
            this.toolTip.SetToolTip(this.btnBrush1Distribution, "Brush force shape");
            this.btnBrush1Distribution.UseVisualStyleBackColor = true;
            this.btnBrush1Distribution.Click += new System.EventHandler(this.btnBrush1Distribution_Click);
            // 
            // tbBrush1ValueHex
            // 
            this.tbBrush1ValueHex.Location = new System.Drawing.Point(112, 0);
            this.tbBrush1ValueHex.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tbBrush1ValueHex.MaxLength = 7;
            this.tbBrush1ValueHex.Name = "tbBrush1ValueHex";
            this.tbBrush1ValueHex.Size = new System.Drawing.Size(36, 20);
            this.tbBrush1ValueHex.TabIndex = 6;
            this.tbBrush1ValueHex.Text = "0100";
            this.tbBrush1ValueHex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.tbBrush1ValueHex, "4 hexadecimals (0-9, A-F)");
            this.tbBrush1ValueHex.Visible = false;
            this.tbBrush1ValueHex.WordWrap = false;
            this.tbBrush1ValueHex.TextChanged += new System.EventHandler(this.tbBrush1ValueHex_TextChanged);
            // 
            // nudBrush1ValueDecimal
            // 
            this.nudBrush1ValueDecimal.Location = new System.Drawing.Point(112, 0);
            this.nudBrush1ValueDecimal.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudBrush1ValueDecimal.Name = "nudBrush1ValueDecimal";
            this.nudBrush1ValueDecimal.Size = new System.Drawing.Size(52, 20);
            this.nudBrush1ValueDecimal.TabIndex = 6;
            this.nudBrush1ValueDecimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudBrush1ValueDecimal.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.nudBrush1ValueDecimal.ValueChanged += new System.EventHandler(this.nudBrush1Value_ValueChanged);
            // 
            // nudBrush1ForceDecimal
            // 
            this.nudBrush1ForceDecimal.Location = new System.Drawing.Point(112, 20);
            this.nudBrush1ForceDecimal.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudBrush1ForceDecimal.Name = "nudBrush1ForceDecimal";
            this.nudBrush1ForceDecimal.Size = new System.Drawing.Size(52, 20);
            this.nudBrush1ForceDecimal.TabIndex = 24;
            this.nudBrush1ForceDecimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudBrush1ForceDecimal.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // chbBrush1Shape
            // 
            this.chbBrush1Shape.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbBrush1Shape.BackColor = System.Drawing.SystemColors.Control;
            this.chbBrush1Shape.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chbBrush1Shape.BackgroundImage")));
            this.chbBrush1Shape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chbBrush1Shape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbBrush1Shape.ImageList = this.ilToolShape;
            this.chbBrush1Shape.Location = new System.Drawing.Point(28, 20);
            this.chbBrush1Shape.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.chbBrush1Shape.Name = "chbBrush1Shape";
            this.chbBrush1Shape.Size = new System.Drawing.Size(20, 20);
            this.chbBrush1Shape.TabIndex = 12;
            this.chbBrush1Shape.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.chbBrush1Shape, "Brush shape");
            this.chbBrush1Shape.UseVisualStyleBackColor = false;
            this.chbBrush1Shape.CheckedChanged += new System.EventHandler(this.chbBrushXShape_CheckedChanged);
            this.chbBrush1Shape.BackgroundImageChanged += new System.EventHandler(this.nudBrush1Size_ValueChanged);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(60, 0);
            this.label19.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(14, 16);
            this.label19.TabIndex = 22;
            this.label19.Text = "x";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Location = new System.Drawing.Point(4, 4);
            this.label23.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(16, 16);
            this.label23.TabIndex = 20;
            this.label23.Text = "1:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Location = new System.Drawing.Point(76, 24);
            this.label28.Margin = new System.Windows.Forms.Padding(0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(37, 13);
            this.label28.TabIndex = 25;
            this.label28.Text = "Force:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.label28, "Force of pencil");
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(128, 4);
            this.label20.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 13);
            this.label20.TabIndex = 20;
            this.label20.Text = "Value";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.label20, "Value to set, increment, decrement or Force of smoothing");
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Location = new System.Drawing.Point(0, 4);
            this.label22.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(34, 13);
            this.label22.TabIndex = 20;
            this.label22.Text = "Brush";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(32, 4);
            this.label21.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(95, 13);
            this.label21.TabIndex = 20;
            this.label21.Text = "Size/Shape/Force";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnToolMMB
            // 
            this.btnToolMMB.BackColor = System.Drawing.Color.Transparent;
            this.btnToolMMB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnToolMMB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolMMB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolMMB.Location = new System.Drawing.Point(47, 56);
            this.btnToolMMB.Name = "btnToolMMB";
            this.btnToolMMB.Size = new System.Drawing.Size(32, 32);
            this.btnToolMMB.TabIndex = 2;
            this.btnToolMMB.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.toolTip.SetToolTip(this.btnToolMMB, "Middle mouse button");
            this.btnToolMMB.UseVisualStyleBackColor = false;
            this.btnToolMMB.Click += new System.EventHandler(this.btnToolXMB_Click);
            // 
            // pbMouseButtons
            // 
            this.pbMouseButtons.Image = global::SHME.Properties.Resources.toolMouse;
            this.pbMouseButtons.Location = new System.Drawing.Point(0, 44);
            this.pbMouseButtons.Name = "pbMouseButtons";
            this.pbMouseButtons.Size = new System.Drawing.Size(128, 120);
            this.pbMouseButtons.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbMouseButtons.TabIndex = 21;
            this.pbMouseButtons.TabStop = false;
            // 
            // hScrollBar
            // 
            this.hScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar.LargeChange = 256;
            this.hScrollBar.Location = new System.Drawing.Point(220, 641);
            this.hScrollBar.Maximum = 255;
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(543, 21);
            this.hScrollBar.TabIndex = 10;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // vScrollBar
            // 
            this.vScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar.LargeChange = 256;
            this.vScrollBar.Location = new System.Drawing.Point(763, 0);
            this.vScrollBar.Maximum = 255;
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(21, 641);
            this.vScrollBar.TabIndex = 9;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // cbbZoom
            // 
            this.cbbZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbbZoom.IntegralHeight = false;
            this.cbbZoom.ItemHeight = 16;
            this.cbbZoom.Items.AddRange(new object[] {
            "x64",
            "x32",
            "x16",
            " x8",
            " x4",
            " x2",
            " x1"});
            this.cbbZoom.Location = new System.Drawing.Point(29, 1);
            this.cbbZoom.Margin = new System.Windows.Forms.Padding(1);
            this.cbbZoom.Name = "cbbZoom";
            this.cbbZoom.Size = new System.Drawing.Size(44, 24);
            this.cbbZoom.TabIndex = 5;
            this.toolTip.SetToolTip(this.cbbZoom, "Select zoom");
            this.cbbZoom.SelectedIndexChanged += new System.EventHandler(this.cbbZoom_SelectedIndexChanged);
            // 
            // btnHistoryForward
            // 
            this.btnHistoryForward.Enabled = false;
            this.btnHistoryForward.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHistoryForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnHistoryForward.Image = global::SHME.Properties.Resources.historyForwardHi;
            this.btnHistoryForward.Location = new System.Drawing.Point(124, 1);
            this.btnHistoryForward.Margin = new System.Windows.Forms.Padding(1);
            this.btnHistoryForward.Name = "btnHistoryForward";
            this.btnHistoryForward.Size = new System.Drawing.Size(24, 24);
            this.btnHistoryForward.TabIndex = 3;
            this.btnHistoryForward.Text = "0";
            this.btnHistoryForward.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHistoryForward.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolTip.SetToolTip(this.btnHistoryForward, "Redo");
            this.btnHistoryForward.UseVisualStyleBackColor = true;
            this.btnHistoryForward.Click += new System.EventHandler(this.btnHistoryForward_Click);
            // 
            // btnHistoryBackward
            // 
            this.btnHistoryBackward.Enabled = false;
            this.btnHistoryBackward.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHistoryBackward.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnHistoryBackward.Image = global::SHME.Properties.Resources.historyBackHi;
            this.btnHistoryBackward.Location = new System.Drawing.Point(96, 1);
            this.btnHistoryBackward.Margin = new System.Windows.Forms.Padding(1);
            this.btnHistoryBackward.Name = "btnHistoryBackward";
            this.btnHistoryBackward.Size = new System.Drawing.Size(24, 24);
            this.btnHistoryBackward.TabIndex = 2;
            this.btnHistoryBackward.Text = "0";
            this.btnHistoryBackward.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHistoryBackward.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolTip.SetToolTip(this.btnHistoryBackward, "Undo");
            this.btnHistoryBackward.UseVisualStyleBackColor = true;
            this.btnHistoryBackward.Click += new System.EventHandler(this.btnHistoryBackward_Click);
            // 
            // chbGrid
            // 
            this.chbGrid.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbGrid.BackColor = System.Drawing.Color.LightGray;
            this.chbGrid.BackgroundImage = global::SHME.Properties.Resources.grid;
            this.chbGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chbGrid.Location = new System.Drawing.Point(1, 1);
            this.chbGrid.Margin = new System.Windows.Forms.Padding(1);
            this.chbGrid.Name = "chbGrid";
            this.chbGrid.Size = new System.Drawing.Size(25, 25);
            this.chbGrid.TabIndex = 1;
            this.chbGrid.Text = "@";
            this.toolTip.SetToolTip(this.chbGrid, "Switch grid");
            this.chbGrid.UseVisualStyleBackColor = false;
            this.chbGrid.CheckedChanged += new System.EventHandler(this.cbbGrid_CheckedChanged);
            // 
            // pbZoomOut
            // 
            this.pbZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbZoomOut.Image = global::SHME.Properties.Resources.MoveDown;
            this.pbZoomOut.InitialImage = null;
            this.pbZoomOut.Location = new System.Drawing.Point(76, 13);
            this.pbZoomOut.Margin = new System.Windows.Forms.Padding(0);
            this.pbZoomOut.Name = "pbZoomOut";
            this.pbZoomOut.Size = new System.Drawing.Size(16, 12);
            this.pbZoomOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbZoomOut.TabIndex = 3;
            this.pbZoomOut.TabStop = false;
            this.toolTip.SetToolTip(this.pbZoomOut, "Zoom out");
            this.pbZoomOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbZoomOut_Click);
            // 
            // pbZoomIn
            // 
            this.pbZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbZoomIn.Image = global::SHME.Properties.Resources.MoveUp;
            this.pbZoomIn.InitialImage = null;
            this.pbZoomIn.Location = new System.Drawing.Point(76, 1);
            this.pbZoomIn.Margin = new System.Windows.Forms.Padding(0);
            this.pbZoomIn.Name = "pbZoomIn";
            this.pbZoomIn.Size = new System.Drawing.Size(16, 12);
            this.pbZoomIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbZoomIn.TabIndex = 1;
            this.pbZoomIn.TabStop = false;
            this.toolTip.SetToolTip(this.pbZoomIn, "Zoom in");
            this.pbZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbZoomIn_Click);
            // 
            // btnToolSwitch
            // 
            this.btnToolSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolSwitch.Image = global::SHME.Properties.Resources.viewSwitch;
            this.btnToolSwitch.Location = new System.Drawing.Point(36, 36);
            this.btnToolSwitch.Name = "btnToolSwitch";
            this.btnToolSwitch.Size = new System.Drawing.Size(32, 32);
            this.btnToolSwitch.TabIndex = 1;
            this.btnToolSwitch.Tag = "";
            this.toolTip.SetToolTip(this.btnToolSwitch, "Switch between height and topographic map");
            this.btnToolSwitch.UseVisualStyleBackColor = true;
            this.btnToolSwitch.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolPan
            // 
            this.btnToolPan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolPan.Image = global::SHME.Properties.Resources.toolMove;
            this.btnToolPan.Location = new System.Drawing.Point(4, 36);
            this.btnToolPan.Name = "btnToolPan";
            this.btnToolPan.Size = new System.Drawing.Size(32, 32);
            this.btnToolPan.TabIndex = 0;
            this.btnToolPan.Tag = "";
            this.toolTip.SetToolTip(this.btnToolPan, "Pan");
            this.btnToolPan.UseVisualStyleBackColor = true;
            this.btnToolPan.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolProbe
            // 
            this.btnToolProbe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolProbe.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolProbe.Image = global::SHME.Properties.Resources.toolProbe;
            this.btnToolProbe.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolProbe.Location = new System.Drawing.Point(72, 36);
            this.btnToolProbe.Name = "btnToolProbe";
            this.btnToolProbe.Size = new System.Drawing.Size(32, 32);
            this.btnToolProbe.TabIndex = 7;
            this.btnToolProbe.Tag = "";
            this.btnToolProbe.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.toolTip.SetToolTip(this.btnToolProbe, "Probe (slot 1)");
            this.btnToolProbe.UseVisualStyleBackColor = true;
            this.btnToolProbe.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolPencil
            // 
            this.btnToolPencil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolPencil.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolPencil.Image = global::SHME.Properties.Resources.toolPencil;
            this.btnToolPencil.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolPencil.Location = new System.Drawing.Point(72, 68);
            this.btnToolPencil.Name = "btnToolPencil";
            this.btnToolPencil.Size = new System.Drawing.Size(32, 32);
            this.btnToolPencil.TabIndex = 8;
            this.btnToolPencil.Tag = "";
            this.btnToolPencil.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.toolTip.SetToolTip(this.btnToolPencil, "Pencil");
            this.btnToolPencil.UseVisualStyleBackColor = true;
            this.btnToolPencil.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolSmooth
            // 
            this.btnToolSmooth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolSmooth.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolSmooth.Image = global::SHME.Properties.Resources.toolLevelSmooth;
            this.btnToolSmooth.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolSmooth.Location = new System.Drawing.Point(136, 36);
            this.btnToolSmooth.Name = "btnToolSmooth";
            this.btnToolSmooth.Size = new System.Drawing.Size(32, 32);
            this.btnToolSmooth.TabIndex = 11;
            this.btnToolSmooth.Tag = "";
            this.btnToolSmooth.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.toolTip.SetToolTip(this.btnToolSmooth, "Smooth");
            this.btnToolSmooth.UseVisualStyleBackColor = true;
            this.btnToolSmooth.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolFlaten
            // 
            this.btnToolFlaten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolFlaten.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolFlaten.Image = global::SHME.Properties.Resources.toolLevelFlaten;
            this.btnToolFlaten.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolFlaten.Location = new System.Drawing.Point(168, 4);
            this.btnToolFlaten.Name = "btnToolFlaten";
            this.btnToolFlaten.Size = new System.Drawing.Size(32, 32);
            this.btnToolFlaten.TabIndex = 13;
            this.btnToolFlaten.Tag = "";
            this.btnToolFlaten.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.toolTip.SetToolTip(this.btnToolFlaten, "Level");
            this.btnToolFlaten.UseVisualStyleBackColor = true;
            this.btnToolFlaten.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolAdd
            // 
            this.btnToolAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnToolAdd.Image")));
            this.btnToolAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolAdd.Location = new System.Drawing.Point(104, 36);
            this.btnToolAdd.Name = "btnToolAdd";
            this.btnToolAdd.Size = new System.Drawing.Size(32, 32);
            this.btnToolAdd.TabIndex = 9;
            this.btnToolAdd.Tag = "";
            this.btnToolAdd.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.toolTip.SetToolTip(this.btnToolAdd, "Add");
            this.btnToolAdd.UseVisualStyleBackColor = true;
            this.btnToolAdd.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolSub
            // 
            this.btnToolSub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolSub.Image = global::SHME.Properties.Resources.toolLevelSub;
            this.btnToolSub.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolSub.Location = new System.Drawing.Point(104, 68);
            this.btnToolSub.Name = "btnToolSub";
            this.btnToolSub.Size = new System.Drawing.Size(32, 32);
            this.btnToolSub.TabIndex = 10;
            this.btnToolSub.Tag = "";
            this.btnToolSub.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.toolTip.SetToolTip(this.btnToolSub, "Dig");
            this.btnToolSub.UseVisualStyleBackColor = true;
            this.btnToolSub.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // pnlCorner
            // 
            this.pnlCorner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCorner.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCorner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlCorner.BackgroundImage")));
            this.pnlCorner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlCorner.Location = new System.Drawing.Point(763, 641);
            this.pnlCorner.Name = "pnlCorner";
            this.pnlCorner.Size = new System.Drawing.Size(21, 21);
            this.pnlCorner.TabIndex = 11;
            this.toolTip.SetToolTip(this.pnlCorner, "Double click to open \"About\"");
            this.pnlCorner.DoubleClick += new System.EventHandler(this.pnlCorner_DoubleClick);
            // 
            // btnToolStretch
            // 
            this.btnToolStretch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolStretch.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolStretch.Image = global::SHME.Properties.Resources.toolLevelStretch;
            this.btnToolStretch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolStretch.Location = new System.Drawing.Point(136, 68);
            this.btnToolStretch.Name = "btnToolStretch";
            this.btnToolStretch.Size = new System.Drawing.Size(32, 32);
            this.btnToolStretch.TabIndex = 12;
            this.btnToolStretch.Tag = "";
            this.btnToolStretch.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.toolTip.SetToolTip(this.btnToolStretch, "Smooth inside");
            this.btnToolStretch.UseVisualStyleBackColor = true;
            this.btnToolStretch.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolFlatenDown
            // 
            this.btnToolFlatenDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolFlatenDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolFlatenDown.Image = global::SHME.Properties.Resources.toolLevelFlatenDown;
            this.btnToolFlatenDown.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolFlatenDown.Location = new System.Drawing.Point(168, 36);
            this.btnToolFlatenDown.Name = "btnToolFlatenDown";
            this.btnToolFlatenDown.Size = new System.Drawing.Size(32, 32);
            this.btnToolFlatenDown.TabIndex = 14;
            this.btnToolFlatenDown.Tag = "";
            this.btnToolFlatenDown.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.toolTip.SetToolTip(this.btnToolFlatenDown, "Level higher");
            this.btnToolFlatenDown.UseVisualStyleBackColor = true;
            this.btnToolFlatenDown.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolFlatenUp
            // 
            this.btnToolFlatenUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolFlatenUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolFlatenUp.Image = global::SHME.Properties.Resources.toolLevelFlatenUp;
            this.btnToolFlatenUp.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolFlatenUp.Location = new System.Drawing.Point(168, 68);
            this.btnToolFlatenUp.Name = "btnToolFlatenUp";
            this.btnToolFlatenUp.Size = new System.Drawing.Size(32, 32);
            this.btnToolFlatenUp.TabIndex = 15;
            this.btnToolFlatenUp.Tag = "";
            this.btnToolFlatenUp.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.toolTip.SetToolTip(this.btnToolFlatenUp, "Level lower");
            this.btnToolFlatenUp.UseVisualStyleBackColor = true;
            this.btnToolFlatenUp.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // pnlZoomGrid
            // 
            this.pnlZoomGrid.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlZoomGrid.AutoSize = true;
            this.pnlZoomGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlZoomGrid.BackColor = System.Drawing.SystemColors.Control;
            this.pnlZoomGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlZoomGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlZoomGrid.Controls.Add(this.btnHistoryForward);
            this.pnlZoomGrid.Controls.Add(this.btnHistoryBackward);
            this.pnlZoomGrid.Controls.Add(this.chbGrid);
            this.pnlZoomGrid.Controls.Add(this.cbbZoom);
            this.pnlZoomGrid.Controls.Add(this.pbZoomOut);
            this.pnlZoomGrid.Controls.Add(this.pbZoomIn);
            this.pnlZoomGrid.Location = new System.Drawing.Point(446, 4);
            this.pnlZoomGrid.Margin = new System.Windows.Forms.Padding(0);
            this.pnlZoomGrid.Name = "pnlZoomGrid";
            this.pnlZoomGrid.Padding = new System.Windows.Forms.Padding(1);
            this.pnlZoomGrid.Size = new System.Drawing.Size(152, 30);
            this.pnlZoomGrid.TabIndex = 1;
            // 
            // pnlToolSelect
            // 
            this.pnlToolSelect.AutoSize = true;
            this.pnlToolSelect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlToolSelect.BackColor = System.Drawing.SystemColors.Control;
            this.pnlToolSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlToolSelect.Controls.Add(this.rbToolUseBrush3);
            this.pnlToolSelect.Controls.Add(this.rbToolUseBrush2);
            this.pnlToolSelect.Controls.Add(this.rbToolUseBrush1);
            this.pnlToolSelect.Controls.Add(this.label15);
            this.pnlToolSelect.Controls.Add(this.btnToolFlatenUp);
            this.pnlToolSelect.Controls.Add(this.btnToolFlatenDown);
            this.pnlToolSelect.Controls.Add(this.btnToolStretch);
            this.pnlToolSelect.Controls.Add(this.btnToolUndo);
            this.pnlToolSelect.Controls.Add(this.btnToolRedo);
            this.pnlToolSelect.Controls.Add(this.btnToolPan);
            this.pnlToolSelect.Controls.Add(this.btnToolSwitch);
            this.pnlToolSelect.Controls.Add(this.btnToolSmooth);
            this.pnlToolSelect.Controls.Add(this.btnToolFlaten);
            this.pnlToolSelect.Controls.Add(this.btnToolSub);
            this.pnlToolSelect.Controls.Add(this.btnToolAdd);
            this.pnlToolSelect.Controls.Add(this.btnToolProbe);
            this.pnlToolSelect.Controls.Add(this.btnToolPencil);
            this.pnlToolSelect.Location = new System.Drawing.Point(224, 396);
            this.pnlToolSelect.Name = "pnlToolSelect";
            this.pnlToolSelect.Size = new System.Drawing.Size(205, 105);
            this.pnlToolSelect.TabIndex = 5;
            this.pnlToolSelect.Visible = false;
            this.pnlToolSelect.Click += new System.EventHandler(this.pnlToolSelect_Click);
            // 
            // rbToolUseBrush3
            // 
            this.rbToolUseBrush3.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbToolUseBrush3.BackColor = System.Drawing.Color.Silver;
            this.rbToolUseBrush3.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbToolUseBrush3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rbToolUseBrush3.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.rbToolUseBrush3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbToolUseBrush3.Location = new System.Drawing.Point(144, 10);
            this.rbToolUseBrush3.Name = "rbToolUseBrush3";
            this.rbToolUseBrush3.Size = new System.Drawing.Size(21, 21);
            this.rbToolUseBrush3.TabIndex = 6;
            this.rbToolUseBrush3.Text = "3";
            this.rbToolUseBrush3.UseVisualStyleBackColor = false;
            // 
            // rbToolUseBrush2
            // 
            this.rbToolUseBrush2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbToolUseBrush2.BackColor = System.Drawing.Color.Silver;
            this.rbToolUseBrush2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbToolUseBrush2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rbToolUseBrush2.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.rbToolUseBrush2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbToolUseBrush2.Location = new System.Drawing.Point(124, 10);
            this.rbToolUseBrush2.Name = "rbToolUseBrush2";
            this.rbToolUseBrush2.Size = new System.Drawing.Size(21, 21);
            this.rbToolUseBrush2.TabIndex = 5;
            this.rbToolUseBrush2.Text = "2";
            this.rbToolUseBrush2.UseVisualStyleBackColor = false;
            // 
            // rbToolUseBrush1
            // 
            this.rbToolUseBrush1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbToolUseBrush1.BackColor = System.Drawing.Color.Silver;
            this.rbToolUseBrush1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbToolUseBrush1.Checked = true;
            this.rbToolUseBrush1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rbToolUseBrush1.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.rbToolUseBrush1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbToolUseBrush1.Location = new System.Drawing.Point(104, 10);
            this.rbToolUseBrush1.Name = "rbToolUseBrush1";
            this.rbToolUseBrush1.Size = new System.Drawing.Size(21, 21);
            this.rbToolUseBrush1.TabIndex = 4;
            this.rbToolUseBrush1.TabStop = true;
            this.rbToolUseBrush1.Text = "1";
            this.rbToolUseBrush1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbToolUseBrush1.UseVisualStyleBackColor = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(72, 14);
            this.label15.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "Brush";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnToolUndo
            // 
            this.btnToolUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolUndo.Image = global::SHME.Properties.Resources.historyBack;
            this.btnToolUndo.Location = new System.Drawing.Point(4, 68);
            this.btnToolUndo.Name = "btnToolUndo";
            this.btnToolUndo.Size = new System.Drawing.Size(32, 32);
            this.btnToolUndo.TabIndex = 2;
            this.btnToolUndo.Tag = "";
            this.btnToolUndo.UseVisualStyleBackColor = true;
            this.btnToolUndo.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolRedo
            // 
            this.btnToolRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolRedo.Image = global::SHME.Properties.Resources.historyForward;
            this.btnToolRedo.Location = new System.Drawing.Point(36, 68);
            this.btnToolRedo.Name = "btnToolRedo";
            this.btnToolRedo.Size = new System.Drawing.Size(32, 32);
            this.btnToolRedo.TabIndex = 3;
            this.btnToolRedo.Tag = "";
            this.btnToolRedo.UseVisualStyleBackColor = true;
            this.btnToolRedo.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // tsmiSaveAs
            // 
            this.tsmiSaveAs.Image = global::SHME.Properties.Resources.blank;
            this.tsmiSaveAs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiSaveAs.Name = "tsmiSaveAs";
            this.tsmiSaveAs.Size = new System.Drawing.Size(180, 22);
            this.tsmiSaveAs.Text = "Save as...";
            this.tsmiSaveAs.Click += new System.EventHandler(this.btnSaveHMap_Click);
            // 
            // FormSHME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(784, 662);
            this.Controls.Add(this.pnlToolSelect);
            this.Controls.Add(this.pnlZoomGrid);
            this.Controls.Add(this.pnlCorner);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.tlpTools);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(480, 700);
            this.Name = "FormSHME";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Spectrum Height Map Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSHME_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormSHME_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbHMap_MouseDown);
            this.MouseEnter += new System.EventHandler(this.FormSHME_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.FormSHME_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbHMap_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormSHME_MouseUp);
            this.Resize += new System.EventHandler(this.FormSHME_Resize);
            this.gbStatistics.ResumeLayout(false);
            this.cmsOpenFile.ResumeLayout(false);
            this.tcThemes.ResumeLayout(false);
            this.tpMonochrome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMonochromeRepeat)).EndInit();
            this.tpBytes.ResumeLayout(false);
            this.tpBytes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudByteRepeat)).EndInit();
            this.tpSpectrum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSpectrumRepeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpectrum)).EndInit();
            this.gbFiles.ResumeLayout(false);
            this.gbFiles.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.cmsSaveFile.ResumeLayout(false);
            this.tlpTools.ResumeLayout(false);
            this.tlpTools.PerformLayout();
            this.gbTools.ResumeLayout(false);
            this.gbTools.PerformLayout();
            this.pnlTools.ResumeLayout(false);
            this.pnlTools.PerformLayout();
            this.pnlBrush3.ResumeLayout(false);
            this.pnlBrush3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush3ForceDecimal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush3Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush3Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush3ValueDecimal)).EndInit();
            this.pnlBrush2.ResumeLayout(false);
            this.pnlBrush2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush2ForceDecimal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush2Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush2ValueDecimal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush2Width)).EndInit();
            this.pnlBrush1.ResumeLayout(false);
            this.pnlBrush1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush1Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush1Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush1ValueDecimal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush1ForceDecimal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMouseButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZoomOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZoomIn)).EndInit();
            this.pnlZoomGrid.ResumeLayout(false);
            this.pnlZoomGrid.PerformLayout();
            this.pnlToolSelect.ResumeLayout(false);
            this.pnlToolSelect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.GroupBox gbStatistics;
        private System.Windows.Forms.Label lblHeightMin;
        private System.Windows.Forms.Label lblHeightMax;
        private System.Windows.Forms.CheckBox chbLimitMin;
        private System.Windows.Forms.CheckBox chbLimitMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblHeightMid;
        private System.Windows.Forms.Label lblHeightAvg;
        private System.Windows.Forms.TabControl tcThemes;
        private System.Windows.Forms.TabPage tpMonochrome;
        private System.Windows.Forms.TabPage tpBytes;
        private System.Windows.Forms.TabPage tpSpectrum;
        private System.Windows.Forms.ColorDialog dlgColor;
        private System.Windows.Forms.Label lblPointerLevel;
        private System.Windows.Forms.Label lblPointerPosition;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ContextMenuStrip cmsOpenFile;
        private System.Windows.Forms.ToolStripMenuItem tsmCreateEmpty;
        private System.Windows.Forms.ToolStripMenuItem tsmCreateScanline;
        private System.Windows.Forms.ToolStripMenuItem tsmCreateSerpantine;
        private System.Windows.Forms.GroupBox gbFiles;
        private System.Windows.Forms.TableLayoutPanel tlpTools;
        private System.Windows.Forms.Label lblFileFormat;
        private System.Windows.Forms.ComboBox cbbLevelFormat16bit;
        private System.Windows.Forms.ComboBox cbbLevelFormat8bit;
        private System.Windows.Forms.CheckBox chbLevelByteBigLittleIndian;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnSaveHMap;
        private System.Windows.Forms.PictureBox pbZoomOut;
        private System.Windows.Forms.PictureBox pbZoomIn;
        private System.Windows.Forms.Label lblHMapSizes;
        private System.Windows.Forms.Label lblTMapSizes;
        private System.Windows.Forms.Button btnLoadHMap;
        private System.Windows.Forms.Button btnLoadTMap;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.CheckBox chbLevelPixelBigLittleIndian;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip cmsSaveFile;
        private System.Windows.Forms.ToolStripMenuItem tsmi8BitPNG;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportView;
        private System.Windows.Forms.ComboBox cbbZoom;
        private System.Windows.Forms.Panel pnlZoomGrid;
        private System.Windows.Forms.CheckBox chbGrid;
        private System.Windows.Forms.GroupBox gbTools;
        private System.Windows.Forms.TextBox tbBrush1ValueHex;
        private System.Windows.Forms.TextBox tbBrush2ValueHex;
        private System.Windows.Forms.TextBox tbBrush3ValueHex;
        private System.Windows.Forms.NumericUpDown nudBrush1ValueDecimal;
        private System.Windows.Forms.NumericUpDown nudBrush2ValueDecimal;
        private System.Windows.Forms.NumericUpDown nudBrush3ValueDecimal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbByteLo;
        private System.Windows.Forms.ComboBox cbbBytePresets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudByteRepeat;
        private System.Windows.Forms.TextBox tbByteHi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudMonochromeRepeat;
        private System.Windows.Forms.ComboBox cbbMonochromePresets;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnMonochromeColor;
        private System.Windows.Forms.NumericUpDown nudSpectrumRepeat;
        private System.Windows.Forms.ComboBox cbbSpectrumStyle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pbSpectrum;
        private System.Windows.Forms.Button btnSpectrumColor3;
        private System.Windows.Forms.Button btnSpectrumColor2;
        private System.Windows.Forms.Button btnSpectrumColor1;
        private System.Windows.Forms.Button btnSpectrumColor0;
        private System.Windows.Forms.Button btnSpectrumColor6;
        private System.Windows.Forms.Button btnSpectrumColor5;
        private System.Windows.Forms.Button btnSpectrumColor4;
        private System.Windows.Forms.Button btnSpectrumColor8;
        private System.Windows.Forms.Button btnSpectrumColor7;
        private System.Windows.Forms.Panel pnlToolSelect;
        private System.Windows.Forms.Button btnToolSmooth;
        private System.Windows.Forms.Button btnToolSub;
        private System.Windows.Forms.Button btnToolAdd;
        private System.Windows.Forms.Button btnToolFlaten;
        private System.Windows.Forms.Button btnToolPencil;
        private System.Windows.Forms.Button btnToolProbe;
        private System.Windows.Forms.Button btnToolPan;
        private System.Windows.Forms.PictureBox pbMouseButtons;
        private System.Windows.Forms.Button btnToolRMB;
        private System.Windows.Forms.Button btnToolMMB;
        private System.Windows.Forms.Button btnToolLMB;
        private System.Windows.Forms.Panel pnlTools;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbbToolsetPreset;
        private System.Windows.Forms.NumericUpDown nudBrush1Height;
        private System.Windows.Forms.Button btnToolSwitch;
        private System.Windows.Forms.NumericUpDown nudBrush3Width;
        private System.Windows.Forms.NumericUpDown nudBrush2Width;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox chbBrush3Shape;
        private System.Windows.Forms.CheckBox chbBrush2Shape;
        private System.Windows.Forms.CheckBox chbBrush1Shape;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ImageList ilToolShape;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnToolX2MB;
        private System.Windows.Forms.Button btnToolX1MB;
        private System.Windows.Forms.Button btnHistoryForward;
        private System.Windows.Forms.Button btnHistoryBackward;
        private System.Windows.Forms.CheckBox chbShowHMap;
        private System.Windows.Forms.CheckBox chbShowTMap;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnHMapResize;
        private System.Windows.Forms.Button btnTMapGenerate;
        private System.Windows.Forms.ImageList ilToolForce;
        private System.Windows.Forms.Button btnBrush3Distribution;
        private System.Windows.Forms.Button btnBrush2Distribution;
        private System.Windows.Forms.Button btnBrush1Distribution;
        private System.Windows.Forms.ToolStripMenuItem tsmiClear;
        private System.Windows.Forms.Button btnToolsetRemove;
        private System.Windows.Forms.Button btnToolsetAdd;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel pnlCorner;
        private System.Windows.Forms.Button btnToolUndo;
        private System.Windows.Forms.Button btnToolRedo;
        private System.Windows.Forms.Button btnToolStretch;
        private System.Windows.Forms.Button btnToolFlatenUp;
        private System.Windows.Forms.Button btnToolFlatenDown;
        private System.Windows.Forms.RadioButton rbToolUseBrush3;
        private System.Windows.Forms.RadioButton rbToolUseBrush2;
        private System.Windows.Forms.RadioButton rbToolUseBrush1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nudBrush1Width;
        private System.Windows.Forms.TextBox tbBrush1ForceHex;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown nudBrush1ForceDecimal;
        private System.Windows.Forms.Panel pnlBrush1;
        private System.Windows.Forms.Panel pnlBrush3;
        private System.Windows.Forms.Panel pnlBrush2;
        private System.Windows.Forms.TextBox tbBrush3ForceHex;
        private System.Windows.Forms.NumericUpDown nudBrush3ForceDecimal;
        private System.Windows.Forms.NumericUpDown nudBrush3Height;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tbBrush2ForceHex;
        private System.Windows.Forms.NumericUpDown nudBrush2ForceDecimal;
        private System.Windows.Forms.NumericUpDown nudBrush2Height;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox chbHexValues;
        private System.Windows.Forms.CheckBox chbBrush1FrameShow;
        private System.Windows.Forms.CheckBox chbBrush3FrameShow;
        private System.Windows.Forms.CheckBox chbBrush2FrameShow;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreash;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAs;
    }
}

