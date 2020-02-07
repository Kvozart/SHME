﻿namespace SHME
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
            this.tcThemes = new System.Windows.Forms.TabControl();
            this.tpMonochrome = new System.Windows.Forms.TabPage();
            this.btnMonochromeColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudMonochromeRepeat = new System.Windows.Forms.NumericUpDown();
            this.cbbMonochromePresets = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tpBytes = new System.Windows.Forms.TabPage();
            this.tbByteLo = new System.Windows.Forms.TextBox();
            this.tbByteHi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbBytePresets = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudByte = new System.Windows.Forms.NumericUpDown();
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
            this.lblPDASizes = new System.Windows.Forms.Label();
            this.btnSaveHMap = new System.Windows.Forms.Button();
            this.cmsSaveFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi8BitPNG = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportView = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadHMap = new System.Windows.Forms.Button();
            this.btnLoadPDA = new System.Windows.Forms.Button();
            this.chbShowHMap = new System.Windows.Forms.CheckBox();
            this.chbShowPDA = new System.Windows.Forms.CheckBox();
            this.btnPDAGenerate = new System.Windows.Forms.Button();
            this.tlpTools = new System.Windows.Forms.TableLayoutPanel();
            this.gbTools = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbbToolPreset = new System.Windows.Forms.ComboBox();
            this.btnToolRMB = new System.Windows.Forms.Button();
            this.btnToolX2MB = new System.Windows.Forms.Button();
            this.btnToolX1MB = new System.Windows.Forms.Button();
            this.btnToolLMB = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbTool3Hex = new System.Windows.Forms.TextBox();
            this.tbTool2Hex = new System.Windows.Forms.TextBox();
            this.tbTool1Hex = new System.Windows.Forms.TextBox();
            this.nudTool3Size = new System.Windows.Forms.NumericUpDown();
            this.nudTool2Size = new System.Windows.Forms.NumericUpDown();
            this.nudTool1Size = new System.Windows.Forms.NumericUpDown();
            this.chbTool3Shape = new System.Windows.Forms.CheckBox();
            this.ilToolShape = new System.Windows.Forms.ImageList(this.components);
            this.chbTool2Shape = new System.Windows.Forms.CheckBox();
            this.chbTool1Shape = new System.Windows.Forms.CheckBox();
            this.nudTool3Value = new System.Windows.Forms.NumericUpDown();
            this.nudTool2Value = new System.Windows.Forms.NumericUpDown();
            this.nudTool1Value = new System.Windows.Forms.NumericUpDown();
            this.lblTool2Hex = new System.Windows.Forms.Label();
            this.lblTool3Hex = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblTool1Hex = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btnToolMMB = new System.Windows.Forms.Button();
            this.pbMouseButtons = new System.Windows.Forms.PictureBox();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.pnlCorner = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cbbZoom = new System.Windows.Forms.ComboBox();
            this.btnHistoryForward = new System.Windows.Forms.Button();
            this.btnHistoryBackward = new System.Windows.Forms.Button();
            this.chbGrid = new System.Windows.Forms.CheckBox();
            this.pbZoomOut = new System.Windows.Forms.PictureBox();
            this.pbZoomIn = new System.Windows.Forms.PictureBox();
            this.pnlZoomGrid = new System.Windows.Forms.Panel();
            this.pnlToolSelect = new System.Windows.Forms.Panel();
            this.btnToolSmooth3 = new System.Windows.Forms.Button();
            this.btnToolSmooth2 = new System.Windows.Forms.Button();
            this.btnToolLevel3 = new System.Windows.Forms.Button();
            this.btnToolLevel2 = new System.Windows.Forms.Button();
            this.btnToolSub3 = new System.Windows.Forms.Button();
            this.btnToolSub2 = new System.Windows.Forms.Button();
            this.btnToolAdd3 = new System.Windows.Forms.Button();
            this.btnToolAdd2 = new System.Windows.Forms.Button();
            this.btnToolSwitch = new System.Windows.Forms.Button();
            this.btnToolMove = new System.Windows.Forms.Button();
            this.btnToolProbe1 = new System.Windows.Forms.Button();
            this.btnToolProbe2 = new System.Windows.Forms.Button();
            this.btnToolPencil1 = new System.Windows.Forms.Button();
            this.btnToolSmooth1 = new System.Windows.Forms.Button();
            this.btnToolLevel1 = new System.Windows.Forms.Button();
            this.btnToolAdd1 = new System.Windows.Forms.Button();
            this.btnToolSub1 = new System.Windows.Forms.Button();
            this.btnToolProbe3 = new System.Windows.Forms.Button();
            this.btnToolPencil3 = new System.Windows.Forms.Button();
            this.btnToolPencil2 = new System.Windows.Forms.Button();
            this.pbPDA = new System.Windows.Forms.PictureBox();
            this.gbStatistics.SuspendLayout();
            this.cmsOpenFile.SuspendLayout();
            this.tcThemes.SuspendLayout();
            this.tpMonochrome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonochromeRepeat)).BeginInit();
            this.tpBytes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudByte)).BeginInit();
            this.tpSpectrum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpectrumRepeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpectrum)).BeginInit();
            this.gbFiles.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.cmsSaveFile.SuspendLayout();
            this.tlpTools.SuspendLayout();
            this.gbTools.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTool3Size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTool2Size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTool1Size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTool3Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTool2Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTool1Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMouseButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZoomOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZoomIn)).BeginInit();
            this.pnlZoomGrid.SuspendLayout();
            this.pnlToolSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPDA)).BeginInit();
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
            this.chbLimitMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbLimitMin.Image = global::SHME.Properties.Resources.limitDown;
            this.chbLimitMin.Location = new System.Drawing.Point(84, 44);
            this.chbLimitMin.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.chbLimitMin.Name = "chbLimitMin";
            this.chbLimitMin.Size = new System.Drawing.Size(23, 23);
            this.chbLimitMin.TabIndex = 1;
            this.chbLimitMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbLimitMin.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolTip.SetToolTip(this.chbLimitMin, "Stretch down levels for view");
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
            this.lblPointerPosition.Size = new System.Drawing.Size(72, 28);
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
            this.lblPointerLevel.Text = "65535 xFFFF";
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
            this.chbLimitMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbLimitMax.Image = global::SHME.Properties.Resources.limitUp;
            this.chbLimitMax.Location = new System.Drawing.Point(84, 16);
            this.chbLimitMax.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.chbLimitMax.Name = "chbLimitMax";
            this.chbLimitMax.Size = new System.Drawing.Size(23, 23);
            this.chbLimitMax.TabIndex = 0;
            this.chbLimitMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbLimitMax.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolTip.SetToolTip(this.chbLimitMax, "Stretch up levels for view");
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
            this.tsmCreateSerpantine});
            this.cmsOpenFile.Name = "cmsOpenFile";
            this.cmsOpenFile.Size = new System.Drawing.Size(249, 70);
            // 
            // tsmCreateEmpty
            // 
            this.tsmCreateEmpty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsmCreateEmpty.Image = global::SHME.Properties.Resources.blank;
            this.tsmCreateEmpty.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmCreateEmpty.Name = "tsmCreateEmpty";
            this.tsmCreateEmpty.Size = new System.Drawing.Size(248, 22);
            this.tsmCreateEmpty.Text = "Create empty...";
            this.tsmCreateEmpty.Click += new System.EventHandler(this.tsmCreateEmpty_Click);
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
            this.tsmCreateSerpantine.Name = "tsmCreateSerpantine";
            this.tsmCreateSerpantine.Size = new System.Drawing.Size(248, 22);
            this.tsmCreateSerpantine.Text = "Create gradient map (serpantine)";
            this.tsmCreateSerpantine.Click += new System.EventHandler(this.tsmCreat_Click);
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
            this.tcThemes.SelectedIndexChanged += new System.EventHandler(this.HMapOption_Changed);
            // 
            // tpMonochrome
            // 
            this.tpMonochrome.BackColor = System.Drawing.SystemColors.Control;
            this.tpMonochrome.Controls.Add(this.btnMonochromeColor);
            this.tpMonochrome.Controls.Add(this.label1);
            this.tpMonochrome.Controls.Add(this.nudMonochromeRepeat);
            this.tpMonochrome.Controls.Add(this.cbbMonochromePresets);
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
            this.btnMonochromeColor.Location = new System.Drawing.Point(176, 32);
            this.btnMonochromeColor.Name = "btnMonochromeColor";
            this.btnMonochromeColor.Size = new System.Drawing.Size(25, 25);
            this.btnMonochromeColor.TabIndex = 17;
            this.btnMonochromeColor.UseVisualStyleBackColor = false;
            this.btnMonochromeColor.BackColorChanged += new System.EventHandler(this.HMapOption_Changed);
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
            this.tpBytes.Controls.Add(this.nudByte);
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
            this.tbByteLo.TabIndex = 2;
            this.tbByteLo.Text = "000001";
            this.tbByteLo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.tbByteLo, "6 hexadecimals (0-9, A-F) for RGB");
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
            this.tbByteHi.TabIndex = 1;
            this.tbByteHi.Text = "000100";
            this.tbByteHi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.tbByteHi, "6 hexadecimals (0-9, A-F) for RGB");
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
            this.toolTip.SetToolTip(this.cbbBytePresets, "Multipliers theme presets");
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
            // nudByte
            // 
            this.nudByte.Location = new System.Drawing.Point(48, 32);
            this.nudByte.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudByte.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudByte.Name = "nudByte";
            this.nudByte.Size = new System.Drawing.Size(60, 20);
            this.nudByte.TabIndex = 18;
            this.nudByte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudByte.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudByte.ValueChanged += new System.EventHandler(this.HMapOption_Changed);
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
            this.btnSpectrumColor8.TabIndex = 23;
            this.btnSpectrumColor8.UseVisualStyleBackColor = false;
            this.btnSpectrumColor8.BackColorChanged += new System.EventHandler(this.HMapOption_Changed);
            this.btnSpectrumColor8.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // btnSpectrumColor7
            // 
            this.btnSpectrumColor7.BackColor = System.Drawing.Color.White;
            this.btnSpectrumColor7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpectrumColor7.Location = new System.Drawing.Point(156, 56);
            this.btnSpectrumColor7.Name = "btnSpectrumColor7";
            this.btnSpectrumColor7.Size = new System.Drawing.Size(16, 16);
            this.btnSpectrumColor7.TabIndex = 22;
            this.btnSpectrumColor7.UseVisualStyleBackColor = false;
            this.btnSpectrumColor7.BackColorChanged += new System.EventHandler(this.HMapOption_Changed);
            this.btnSpectrumColor7.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // btnSpectrumColor6
            // 
            this.btnSpectrumColor6.BackColor = System.Drawing.Color.Magenta;
            this.btnSpectrumColor6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpectrumColor6.Location = new System.Drawing.Point(136, 56);
            this.btnSpectrumColor6.Name = "btnSpectrumColor6";
            this.btnSpectrumColor6.Size = new System.Drawing.Size(16, 16);
            this.btnSpectrumColor6.TabIndex = 17;
            this.btnSpectrumColor6.UseVisualStyleBackColor = false;
            this.btnSpectrumColor6.BackColorChanged += new System.EventHandler(this.HMapOption_Changed);
            this.btnSpectrumColor6.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // btnSpectrumColor5
            // 
            this.btnSpectrumColor5.BackColor = System.Drawing.Color.Red;
            this.btnSpectrumColor5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpectrumColor5.Location = new System.Drawing.Point(116, 56);
            this.btnSpectrumColor5.Name = "btnSpectrumColor5";
            this.btnSpectrumColor5.Size = new System.Drawing.Size(16, 16);
            this.btnSpectrumColor5.TabIndex = 21;
            this.btnSpectrumColor5.UseVisualStyleBackColor = false;
            this.btnSpectrumColor5.BackColorChanged += new System.EventHandler(this.HMapOption_Changed);
            this.btnSpectrumColor5.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // btnSpectrumColor4
            // 
            this.btnSpectrumColor4.BackColor = System.Drawing.Color.Yellow;
            this.btnSpectrumColor4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpectrumColor4.Location = new System.Drawing.Point(96, 56);
            this.btnSpectrumColor4.Name = "btnSpectrumColor4";
            this.btnSpectrumColor4.Size = new System.Drawing.Size(16, 16);
            this.btnSpectrumColor4.TabIndex = 20;
            this.btnSpectrumColor4.UseVisualStyleBackColor = false;
            this.btnSpectrumColor4.BackColorChanged += new System.EventHandler(this.HMapOption_Changed);
            this.btnSpectrumColor4.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // btnSpectrumColor3
            // 
            this.btnSpectrumColor3.BackColor = System.Drawing.Color.Green;
            this.btnSpectrumColor3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpectrumColor3.Location = new System.Drawing.Point(76, 56);
            this.btnSpectrumColor3.Name = "btnSpectrumColor3";
            this.btnSpectrumColor3.Size = new System.Drawing.Size(16, 16);
            this.btnSpectrumColor3.TabIndex = 19;
            this.btnSpectrumColor3.UseVisualStyleBackColor = false;
            this.btnSpectrumColor3.BackColorChanged += new System.EventHandler(this.HMapOption_Changed);
            this.btnSpectrumColor3.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // btnSpectrumColor2
            // 
            this.btnSpectrumColor2.BackColor = System.Drawing.Color.Cyan;
            this.btnSpectrumColor2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpectrumColor2.Location = new System.Drawing.Point(56, 56);
            this.btnSpectrumColor2.Name = "btnSpectrumColor2";
            this.btnSpectrumColor2.Size = new System.Drawing.Size(16, 16);
            this.btnSpectrumColor2.TabIndex = 18;
            this.btnSpectrumColor2.UseVisualStyleBackColor = false;
            this.btnSpectrumColor2.BackColorChanged += new System.EventHandler(this.HMapOption_Changed);
            this.btnSpectrumColor2.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // btnSpectrumColor1
            // 
            this.btnSpectrumColor1.BackColor = System.Drawing.Color.Blue;
            this.btnSpectrumColor1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpectrumColor1.Location = new System.Drawing.Point(36, 56);
            this.btnSpectrumColor1.Name = "btnSpectrumColor1";
            this.btnSpectrumColor1.Size = new System.Drawing.Size(16, 16);
            this.btnSpectrumColor1.TabIndex = 17;
            this.btnSpectrumColor1.UseVisualStyleBackColor = false;
            this.btnSpectrumColor1.BackColorChanged += new System.EventHandler(this.HMapOption_Changed);
            this.btnSpectrumColor1.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // btnSpectrumColor0
            // 
            this.btnSpectrumColor0.BackColor = System.Drawing.Color.Black;
            this.btnSpectrumColor0.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpectrumColor0.Location = new System.Drawing.Point(16, 56);
            this.btnSpectrumColor0.Name = "btnSpectrumColor0";
            this.btnSpectrumColor0.Size = new System.Drawing.Size(16, 16);
            this.btnSpectrumColor0.TabIndex = 16;
            this.btnSpectrumColor0.UseVisualStyleBackColor = false;
            this.btnSpectrumColor0.BackColorChanged += new System.EventHandler(this.HMapOption_Changed);
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
            this.toolTip.SetToolTip(this.cbbSpectrumStyle, "Spectrum theme presets");
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
            this.cbbLevelFormat8bit.TabIndex = 8;
            this.toolTip.SetToolTip(this.cbbLevelFormat8bit, "Select wich 2 8bits components will form height");
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
            this.chbLevelPixelBigLittleIndian.TabIndex = 7;
            this.chbLevelPixelBigLittleIndian.Text = "Pixel BLI";
            this.toolTip.SetToolTip(this.chbLevelPixelBigLittleIndian, "Big-Little indian sequence of points in byte");
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
            this.cbbLevelFormat16bit.TabIndex = 5;
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
            this.chbLevelByteBigLittleIndian.TabIndex = 6;
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
            this.tableLayoutPanel4.Controls.Add(this.lblPDASizes, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnSaveHMap, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnLoadHMap, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnLoadPDA, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.chbShowHMap, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.chbShowPDA, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnPDAGenerate, 3, 1);
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
            this.btnHMapResize.TabIndex = 23;
            this.btnHMapResize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.btnHMapResize, "Load image as topology map");
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
            // lblPDASizes
            // 
            this.lblPDASizes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPDASizes.BackColor = System.Drawing.Color.Transparent;
            this.lblPDASizes.Location = new System.Drawing.Point(55, 35);
            this.lblPDASizes.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lblPDASizes.Name = "lblPDASizes";
            this.lblPDASizes.Size = new System.Drawing.Size(69, 13);
            this.lblPDASizes.TabIndex = 22;
            this.lblPDASizes.Text = "800 x 690";
            this.lblPDASizes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tsmi8BitPNG,
            this.tsmiExportView});
            this.cmsSaveFile.Name = "cmsSaveFile";
            this.cmsSaveFile.Size = new System.Drawing.Size(175, 48);
            // 
            // tsmi8BitPNG
            // 
            this.tsmi8BitPNG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsmi8BitPNG.Image = ((System.Drawing.Image)(resources.GetObject("tsmi8BitPNG.Image")));
            this.tsmi8BitPNG.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmi8BitPNG.Name = "tsmi8BitPNG";
            this.tsmi8BitPNG.Size = new System.Drawing.Size(174, 22);
            this.tsmi8BitPNG.Text = "Save as 8 bit PNG...";
            this.tsmi8BitPNG.Click += new System.EventHandler(this.btnSaveHMap_Click);
            // 
            // tsmiExportView
            // 
            this.tsmiExportView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsmiExportView.Image = global::SHME.Properties.Resources.spectrum;
            this.tsmiExportView.Name = "tsmiExportView";
            this.tsmiExportView.Size = new System.Drawing.Size(174, 22);
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
            this.toolTip.SetToolTip(this.btnLoadHMap, "Load image (8/16bit PNG, bitmap,.. ) as heigh map or ...");
            this.btnLoadHMap.UseVisualStyleBackColor = true;
            this.btnLoadHMap.Click += new System.EventHandler(this.btnLoadHMap_Click);
            // 
            // btnLoadPDA
            // 
            this.btnLoadPDA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLoadPDA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoadPDA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLoadPDA.Image = global::SHME.Properties.Resources.load;
            this.btnLoadPDA.Location = new System.Drawing.Point(127, 29);
            this.btnLoadPDA.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnLoadPDA.Name = "btnLoadPDA";
            this.btnLoadPDA.Size = new System.Drawing.Size(28, 25);
            this.btnLoadPDA.TabIndex = 4;
            this.btnLoadPDA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.btnLoadPDA, "Load image as topology map");
            this.btnLoadPDA.UseVisualStyleBackColor = true;
            this.btnLoadPDA.Click += new System.EventHandler(this.btnLoadPDA_Click);
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
            this.chbShowHMap.UseVisualStyleBackColor = true;
            this.chbShowHMap.CheckStateChanged += new System.EventHandler(this.SwitchView);
            // 
            // chbShowPDA
            // 
            this.chbShowPDA.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbShowPDA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbShowPDA.Location = new System.Drawing.Point(3, 31);
            this.chbShowPDA.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.chbShowPDA.Name = "chbShowPDA";
            this.chbShowPDA.Size = new System.Drawing.Size(49, 22);
            this.chbShowPDA.TabIndex = 1;
            this.chbShowPDA.Text = "PDA";
            this.chbShowPDA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbShowPDA.ThreeState = true;
            this.chbShowPDA.UseVisualStyleBackColor = true;
            this.chbShowPDA.CheckStateChanged += new System.EventHandler(this.SwitchView);
            // 
            // btnPDAGenerate
            // 
            this.btnPDAGenerate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPDAGenerate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPDAGenerate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnPDAGenerate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPDAGenerate.Image = global::SHME.Properties.Resources.grid;
            this.btnPDAGenerate.Location = new System.Drawing.Point(155, 29);
            this.btnPDAGenerate.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.btnPDAGenerate.Name = "btnPDAGenerate";
            this.btnPDAGenerate.Size = new System.Drawing.Size(25, 25);
            this.btnPDAGenerate.TabIndex = 23;
            this.btnPDAGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPDAGenerate.UseVisualStyleBackColor = false;
            this.btnPDAGenerate.Click += new System.EventHandler(this.btnPDAGenerate_Click);
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
            this.tlpTools.Size = new System.Drawing.Size(220, 592);
            this.tlpTools.TabIndex = 3;
            // 
            // gbTools
            // 
            this.gbTools.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbTools.Controls.Add(this.label17);
            this.gbTools.Controls.Add(this.cbbToolPreset);
            this.gbTools.Controls.Add(this.btnToolRMB);
            this.gbTools.Controls.Add(this.btnToolX2MB);
            this.gbTools.Controls.Add(this.btnToolX1MB);
            this.gbTools.Controls.Add(this.btnToolLMB);
            this.gbTools.Controls.Add(this.panel1);
            this.gbTools.Controls.Add(this.btnToolMMB);
            this.gbTools.Controls.Add(this.pbMouseButtons);
            this.gbTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTools.Location = new System.Drawing.Point(3, 401);
            this.gbTools.Name = "gbTools";
            this.gbTools.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.gbTools.Size = new System.Drawing.Size(214, 188);
            this.gbTools.TabIndex = 4;
            this.gbTools.TabStop = false;
            this.gbTools.Text = "Tools";
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
            // cbbToolPreset
            // 
            this.cbbToolPreset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbToolPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbToolPreset.FormattingEnabled = true;
            this.cbbToolPreset.Items.AddRange(new object[] {
            "Pencil, Pan, Probe",
            "Add, Pan, Subtract",
            "Level, Pan, Smooth"});
            this.cbbToolPreset.Location = new System.Drawing.Point(48, 16);
            this.cbbToolPreset.Name = "cbbToolPreset";
            this.cbbToolPreset.Size = new System.Drawing.Size(160, 21);
            this.cbbToolPreset.TabIndex = 23;
            this.toolTip.SetToolTip(this.cbbToolPreset, "Color theme presets");
            this.cbbToolPreset.SelectedIndexChanged += new System.EventHandler(this.cbbToolPreset_SelectedIndexChanged);
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
            this.btnToolRMB.TabIndex = 2;
            this.btnToolRMB.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.btnToolX2MB.TabIndex = 0;
            this.btnToolX2MB.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.btnToolX1MB.TabIndex = 0;
            this.btnToolX1MB.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.btnToolLMB.TabIndex = 0;
            this.btnToolLMB.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolLMB.UseVisualStyleBackColor = false;
            this.btnToolLMB.Click += new System.EventHandler(this.btnToolXMB_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbTool3Hex);
            this.panel1.Controls.Add(this.tbTool2Hex);
            this.panel1.Controls.Add(this.tbTool1Hex);
            this.panel1.Controls.Add(this.nudTool3Size);
            this.panel1.Controls.Add(this.nudTool2Size);
            this.panel1.Controls.Add(this.nudTool1Size);
            this.panel1.Controls.Add(this.chbTool3Shape);
            this.panel1.Controls.Add(this.chbTool2Shape);
            this.panel1.Controls.Add(this.chbTool1Shape);
            this.panel1.Controls.Add(this.nudTool3Value);
            this.panel1.Controls.Add(this.nudTool2Value);
            this.panel1.Controls.Add(this.nudTool1Value);
            this.panel1.Controls.Add(this.lblTool2Hex);
            this.panel1.Controls.Add(this.lblTool3Hex);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.lblTool1Hex);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Location = new System.Drawing.Point(44, 92);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 92);
            this.panel1.TabIndex = 22;
            // 
            // tbTool3Hex
            // 
            this.tbTool3Hex.Location = new System.Drawing.Point(36, 68);
            this.tbTool3Hex.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tbTool3Hex.MaxLength = 7;
            this.tbTool3Hex.Name = "tbTool3Hex";
            this.tbTool3Hex.Size = new System.Drawing.Size(36, 20);
            this.tbTool3Hex.TabIndex = 10;
            this.tbTool3Hex.Text = "0001";
            this.tbTool3Hex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.tbTool3Hex, "4 hexadecimals (0-9, A-F)");
            this.tbTool3Hex.Visible = false;
            this.tbTool3Hex.WordWrap = false;
            this.tbTool3Hex.TextChanged += new System.EventHandler(this.tbTool3Hex_TextChanged);
            // 
            // tbTool2Hex
            // 
            this.tbTool2Hex.Location = new System.Drawing.Point(36, 44);
            this.tbTool2Hex.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tbTool2Hex.MaxLength = 7;
            this.tbTool2Hex.Name = "tbTool2Hex";
            this.tbTool2Hex.Size = new System.Drawing.Size(36, 20);
            this.tbTool2Hex.TabIndex = 7;
            this.tbTool2Hex.Text = "0001";
            this.tbTool2Hex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.tbTool2Hex, "4 hexadecimals (0-9, A-F)");
            this.tbTool2Hex.Visible = false;
            this.tbTool2Hex.WordWrap = false;
            this.tbTool2Hex.TextChanged += new System.EventHandler(this.tbTool2Hex_TextChanged);
            // 
            // tbTool1Hex
            // 
            this.tbTool1Hex.Location = new System.Drawing.Point(36, 20);
            this.tbTool1Hex.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tbTool1Hex.MaxLength = 7;
            this.tbTool1Hex.Name = "tbTool1Hex";
            this.tbTool1Hex.Size = new System.Drawing.Size(36, 20);
            this.tbTool1Hex.TabIndex = 4;
            this.tbTool1Hex.Text = "0100";
            this.tbTool1Hex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.tbTool1Hex, "4 hexadecimals (0-9, A-F)");
            this.tbTool1Hex.Visible = false;
            this.tbTool1Hex.WordWrap = false;
            this.tbTool1Hex.TextChanged += new System.EventHandler(this.tbTool1Hex_TextChanged);
            // 
            // nudTool3Size
            // 
            this.nudTool3Size.Location = new System.Drawing.Point(128, 68);
            this.nudTool3Size.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudTool3Size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTool3Size.Name = "nudTool3Size";
            this.nudTool3Size.Size = new System.Drawing.Size(32, 20);
            this.nudTool3Size.TabIndex = 23;
            this.nudTool3Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTool3Size.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudTool2Size
            // 
            this.nudTool2Size.Location = new System.Drawing.Point(128, 44);
            this.nudTool2Size.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudTool2Size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTool2Size.Name = "nudTool2Size";
            this.nudTool2Size.Size = new System.Drawing.Size(32, 20);
            this.nudTool2Size.TabIndex = 22;
            this.nudTool2Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTool2Size.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudTool1Size
            // 
            this.nudTool1Size.Location = new System.Drawing.Point(128, 20);
            this.nudTool1Size.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudTool1Size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTool1Size.Name = "nudTool1Size";
            this.nudTool1Size.Size = new System.Drawing.Size(32, 20);
            this.nudTool1Size.TabIndex = 21;
            this.nudTool1Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTool1Size.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            // 
            // chbTool3Shape
            // 
            this.chbTool3Shape.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbTool3Shape.BackColor = System.Drawing.SystemColors.Control;
            this.chbTool3Shape.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chbTool3Shape.BackgroundImage")));
            this.chbTool3Shape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chbTool3Shape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbTool3Shape.ImageList = this.ilToolShape;
            this.chbTool3Shape.Location = new System.Drawing.Point(100, 68);
            this.chbTool3Shape.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.chbTool3Shape.Name = "chbTool3Shape";
            this.chbTool3Shape.Size = new System.Drawing.Size(20, 20);
            this.chbTool3Shape.TabIndex = 24;
            this.chbTool3Shape.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbTool3Shape.UseVisualStyleBackColor = false;
            this.chbTool3Shape.CheckedChanged += new System.EventHandler(this.chbToolShape_CheckedChanged);
            // 
            // ilToolShape
            // 
            this.ilToolShape.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilToolShape.ImageStream")));
            this.ilToolShape.TransparentColor = System.Drawing.Color.Transparent;
            this.ilToolShape.Images.SetKeyName(0, "circle.png");
            this.ilToolShape.Images.SetKeyName(1, "square.png");
            // 
            // chbTool2Shape
            // 
            this.chbTool2Shape.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbTool2Shape.BackColor = System.Drawing.SystemColors.Control;
            this.chbTool2Shape.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chbTool2Shape.BackgroundImage")));
            this.chbTool2Shape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chbTool2Shape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbTool2Shape.ImageList = this.ilToolShape;
            this.chbTool2Shape.Location = new System.Drawing.Point(100, 44);
            this.chbTool2Shape.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.chbTool2Shape.Name = "chbTool2Shape";
            this.chbTool2Shape.Size = new System.Drawing.Size(20, 20);
            this.chbTool2Shape.TabIndex = 24;
            this.chbTool2Shape.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbTool2Shape.UseVisualStyleBackColor = false;
            this.chbTool2Shape.CheckedChanged += new System.EventHandler(this.chbToolShape_CheckedChanged);
            // 
            // chbTool1Shape
            // 
            this.chbTool1Shape.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbTool1Shape.BackColor = System.Drawing.SystemColors.Control;
            this.chbTool1Shape.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chbTool1Shape.BackgroundImage")));
            this.chbTool1Shape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chbTool1Shape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chbTool1Shape.ImageList = this.ilToolShape;
            this.chbTool1Shape.Location = new System.Drawing.Point(100, 20);
            this.chbTool1Shape.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.chbTool1Shape.Name = "chbTool1Shape";
            this.chbTool1Shape.Size = new System.Drawing.Size(20, 20);
            this.chbTool1Shape.TabIndex = 24;
            this.chbTool1Shape.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbTool1Shape.UseVisualStyleBackColor = false;
            this.chbTool1Shape.CheckedChanged += new System.EventHandler(this.chbToolShape_CheckedChanged);
            // 
            // nudTool3Value
            // 
            this.nudTool3Value.Location = new System.Drawing.Point(36, 68);
            this.nudTool3Value.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudTool3Value.Name = "nudTool3Value";
            this.nudTool3Value.Size = new System.Drawing.Size(52, 20);
            this.nudTool3Value.TabIndex = 11;
            this.nudTool3Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTool3Value.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTool3Value.ValueChanged += new System.EventHandler(this.nudTool3Value_ValueChanged);
            // 
            // nudTool2Value
            // 
            this.nudTool2Value.Location = new System.Drawing.Point(36, 44);
            this.nudTool2Value.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudTool2Value.Name = "nudTool2Value";
            this.nudTool2Value.Size = new System.Drawing.Size(52, 20);
            this.nudTool2Value.TabIndex = 8;
            this.nudTool2Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTool2Value.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTool2Value.ValueChanged += new System.EventHandler(this.nudTool2Value_ValueChanged);
            // 
            // nudTool1Value
            // 
            this.nudTool1Value.Location = new System.Drawing.Point(36, 20);
            this.nudTool1Value.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudTool1Value.Name = "nudTool1Value";
            this.nudTool1Value.Size = new System.Drawing.Size(52, 20);
            this.nudTool1Value.TabIndex = 5;
            this.nudTool1Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTool1Value.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.nudTool1Value.ValueChanged += new System.EventHandler(this.nudTool1Value_ValueChanged);
            // 
            // lblTool2Hex
            // 
            this.lblTool2Hex.AutoSize = true;
            this.lblTool2Hex.BackColor = System.Drawing.Color.Transparent;
            this.lblTool2Hex.Location = new System.Drawing.Point(20, 48);
            this.lblTool2Hex.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblTool2Hex.Name = "lblTool2Hex";
            this.lblTool2Hex.Size = new System.Drawing.Size(18, 13);
            this.lblTool2Hex.TabIndex = 20;
            this.lblTool2Hex.Text = "D:";
            this.lblTool2Hex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.lblTool2Hex, "Switch: decimal / hexadecimal");
            this.lblTool2Hex.Click += new System.EventHandler(this.lblTool2Hex_Click);
            // 
            // lblTool3Hex
            // 
            this.lblTool3Hex.AutoSize = true;
            this.lblTool3Hex.BackColor = System.Drawing.Color.Transparent;
            this.lblTool3Hex.Location = new System.Drawing.Point(20, 72);
            this.lblTool3Hex.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblTool3Hex.Name = "lblTool3Hex";
            this.lblTool3Hex.Size = new System.Drawing.Size(18, 13);
            this.lblTool3Hex.TabIndex = 20;
            this.lblTool3Hex.Text = "D:";
            this.lblTool3Hex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.lblTool3Hex, "Switch: decimal / hexadecimal");
            this.lblTool3Hex.Click += new System.EventHandler(this.lblTool3Hex_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(28, 4);
            this.label20.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 13);
            this.label20.TabIndex = 20;
            this.label20.Text = "Value/Force";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Location = new System.Drawing.Point(0, 4);
            this.label22.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(26, 13);
            this.label22.TabIndex = 20;
            this.label22.Text = "Stot";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(96, 4);
            this.label21.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(34, 13);
            this.label21.TabIndex = 20;
            this.label21.Text = "Brush";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(132, 4);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(27, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "Size";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTool1Hex
            // 
            this.lblTool1Hex.AutoSize = true;
            this.lblTool1Hex.BackColor = System.Drawing.Color.Transparent;
            this.lblTool1Hex.Location = new System.Drawing.Point(20, 24);
            this.lblTool1Hex.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblTool1Hex.Name = "lblTool1Hex";
            this.lblTool1Hex.Size = new System.Drawing.Size(18, 13);
            this.lblTool1Hex.TabIndex = 20;
            this.lblTool1Hex.Text = "D:";
            this.lblTool1Hex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.lblTool1Hex, "Switch: decimal / hexadecimal");
            this.lblTool1Hex.Click += new System.EventHandler(this.lblTool1Hex_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Location = new System.Drawing.Point(0, 72);
            this.label25.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(16, 13);
            this.label25.TabIndex = 20;
            this.label25.Text = "3:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Location = new System.Drawing.Point(0, 48);
            this.label24.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(16, 13);
            this.label24.TabIndex = 20;
            this.label24.Text = "2:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Location = new System.Drawing.Point(0, 24);
            this.label23.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(16, 13);
            this.label23.TabIndex = 20;
            this.label23.Text = "1:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnToolMMB.TabIndex = 1;
            this.btnToolMMB.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.hScrollBar.Location = new System.Drawing.Point(220, 575);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(548, 17);
            this.hScrollBar.TabIndex = 10;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // vScrollBar
            // 
            this.vScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar.Location = new System.Drawing.Point(767, 0);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 575);
            this.vScrollBar.TabIndex = 9;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // pnlCorner
            // 
            this.pnlCorner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCorner.Location = new System.Drawing.Point(767, 575);
            this.pnlCorner.Name = "pnlCorner";
            this.pnlCorner.Size = new System.Drawing.Size(17, 17);
            this.pnlCorner.TabIndex = 11;
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
            this.btnHistoryForward.Image = global::SHME.Properties.Resources.historyForward;
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
            this.btnHistoryBackward.Image = global::SHME.Properties.Resources.historyBack;
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
            this.chbGrid.BackgroundImage = global::SHME.Properties.Resources.grid;
            this.chbGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chbGrid.Location = new System.Drawing.Point(1, 1);
            this.chbGrid.Margin = new System.Windows.Forms.Padding(1);
            this.chbGrid.Name = "chbGrid";
            this.chbGrid.Size = new System.Drawing.Size(25, 25);
            this.chbGrid.TabIndex = 1;
            this.toolTip.SetToolTip(this.chbGrid, "Switch grid");
            this.chbGrid.UseVisualStyleBackColor = true;
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
            this.pnlToolSelect.Controls.Add(this.btnToolSmooth3);
            this.pnlToolSelect.Controls.Add(this.btnToolSmooth2);
            this.pnlToolSelect.Controls.Add(this.btnToolLevel3);
            this.pnlToolSelect.Controls.Add(this.btnToolLevel2);
            this.pnlToolSelect.Controls.Add(this.btnToolSub3);
            this.pnlToolSelect.Controls.Add(this.btnToolSub2);
            this.pnlToolSelect.Controls.Add(this.btnToolAdd3);
            this.pnlToolSelect.Controls.Add(this.btnToolAdd2);
            this.pnlToolSelect.Controls.Add(this.btnToolSwitch);
            this.pnlToolSelect.Controls.Add(this.btnToolMove);
            this.pnlToolSelect.Controls.Add(this.btnToolProbe1);
            this.pnlToolSelect.Controls.Add(this.btnToolProbe2);
            this.pnlToolSelect.Controls.Add(this.btnToolPencil1);
            this.pnlToolSelect.Controls.Add(this.btnToolSmooth1);
            this.pnlToolSelect.Controls.Add(this.btnToolLevel1);
            this.pnlToolSelect.Controls.Add(this.btnToolAdd1);
            this.pnlToolSelect.Controls.Add(this.btnToolSub1);
            this.pnlToolSelect.Controls.Add(this.btnToolProbe3);
            this.pnlToolSelect.Controls.Add(this.btnToolPencil3);
            this.pnlToolSelect.Controls.Add(this.btnToolPencil2);
            this.pnlToolSelect.Location = new System.Drawing.Point(224, 396);
            this.pnlToolSelect.Name = "pnlToolSelect";
            this.pnlToolSelect.Size = new System.Drawing.Size(233, 105);
            this.pnlToolSelect.TabIndex = 5;
            this.pnlToolSelect.Visible = false;
            this.pnlToolSelect.Click += new System.EventHandler(this.pnlToolSelect_Click);
            // 
            // btnToolSmooth3
            // 
            this.btnToolSmooth3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolSmooth3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolSmooth3.Image = global::SHME.Properties.Resources.toolLevelSmooth;
            this.btnToolSmooth3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolSmooth3.Location = new System.Drawing.Point(196, 4);
            this.btnToolSmooth3.Name = "btnToolSmooth3";
            this.btnToolSmooth3.Size = new System.Drawing.Size(32, 32);
            this.btnToolSmooth3.TabIndex = 19;
            this.btnToolSmooth3.Tag = "";
            this.btnToolSmooth3.Text = "3";
            this.btnToolSmooth3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolSmooth3.UseVisualStyleBackColor = true;
            // 
            // btnToolSmooth2
            // 
            this.btnToolSmooth2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolSmooth2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolSmooth2.Image = global::SHME.Properties.Resources.toolLevelSmooth;
            this.btnToolSmooth2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolSmooth2.Location = new System.Drawing.Point(196, 36);
            this.btnToolSmooth2.Name = "btnToolSmooth2";
            this.btnToolSmooth2.Size = new System.Drawing.Size(32, 32);
            this.btnToolSmooth2.TabIndex = 18;
            this.btnToolSmooth2.Tag = "";
            this.btnToolSmooth2.Text = "2";
            this.btnToolSmooth2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolSmooth2.UseVisualStyleBackColor = true;
            // 
            // btnToolLevel3
            // 
            this.btnToolLevel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolLevel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolLevel3.Image = global::SHME.Properties.Resources.toolLevel;
            this.btnToolLevel3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolLevel3.Location = new System.Drawing.Point(164, 4);
            this.btnToolLevel3.Name = "btnToolLevel3";
            this.btnToolLevel3.Size = new System.Drawing.Size(32, 32);
            this.btnToolLevel3.TabIndex = 16;
            this.btnToolLevel3.Tag = "";
            this.btnToolLevel3.Text = "3";
            this.btnToolLevel3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolLevel3.UseVisualStyleBackColor = true;
            // 
            // btnToolLevel2
            // 
            this.btnToolLevel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolLevel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolLevel2.Image = global::SHME.Properties.Resources.toolLevel;
            this.btnToolLevel2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolLevel2.Location = new System.Drawing.Point(164, 36);
            this.btnToolLevel2.Name = "btnToolLevel2";
            this.btnToolLevel2.Size = new System.Drawing.Size(32, 32);
            this.btnToolLevel2.TabIndex = 15;
            this.btnToolLevel2.Tag = "";
            this.btnToolLevel2.Text = "2";
            this.btnToolLevel2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolLevel2.UseVisualStyleBackColor = true;
            // 
            // btnToolSub3
            // 
            this.btnToolSub3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolSub3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolSub3.Image = global::SHME.Properties.Resources.toolLevelSub;
            this.btnToolSub3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolSub3.Location = new System.Drawing.Point(132, 36);
            this.btnToolSub3.Name = "btnToolSub3";
            this.btnToolSub3.Size = new System.Drawing.Size(32, 32);
            this.btnToolSub3.TabIndex = 12;
            this.btnToolSub3.Tag = "";
            this.btnToolSub3.Text = "2";
            this.btnToolSub3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolSub3.UseVisualStyleBackColor = true;
            // 
            // btnToolSub2
            // 
            this.btnToolSub2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolSub2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolSub2.Image = global::SHME.Properties.Resources.toolLevelSub;
            this.btnToolSub2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolSub2.Location = new System.Drawing.Point(132, 4);
            this.btnToolSub2.Name = "btnToolSub2";
            this.btnToolSub2.Size = new System.Drawing.Size(32, 32);
            this.btnToolSub2.TabIndex = 13;
            this.btnToolSub2.Tag = "";
            this.btnToolSub2.Text = "3";
            this.btnToolSub2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolSub2.UseVisualStyleBackColor = true;
            // 
            // btnToolAdd3
            // 
            this.btnToolAdd3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolAdd3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolAdd3.Image = ((System.Drawing.Image)(resources.GetObject("btnToolAdd3.Image")));
            this.btnToolAdd3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolAdd3.Location = new System.Drawing.Point(100, 4);
            this.btnToolAdd3.Name = "btnToolAdd3";
            this.btnToolAdd3.Size = new System.Drawing.Size(32, 32);
            this.btnToolAdd3.TabIndex = 10;
            this.btnToolAdd3.Tag = "";
            this.btnToolAdd3.Text = "3";
            this.btnToolAdd3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolAdd3.UseVisualStyleBackColor = true;
            // 
            // btnToolAdd2
            // 
            this.btnToolAdd2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolAdd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolAdd2.Image = ((System.Drawing.Image)(resources.GetObject("btnToolAdd2.Image")));
            this.btnToolAdd2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolAdd2.Location = new System.Drawing.Point(100, 36);
            this.btnToolAdd2.Name = "btnToolAdd2";
            this.btnToolAdd2.Size = new System.Drawing.Size(32, 32);
            this.btnToolAdd2.TabIndex = 9;
            this.btnToolAdd2.Tag = "";
            this.btnToolAdd2.Text = "2";
            this.btnToolAdd2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolAdd2.UseVisualStyleBackColor = true;
            // 
            // btnToolSwitch
            // 
            this.btnToolSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolSwitch.Image = global::SHME.Properties.Resources.viewSwitch;
            this.btnToolSwitch.Location = new System.Drawing.Point(4, 4);
            this.btnToolSwitch.Name = "btnToolSwitch";
            this.btnToolSwitch.Size = new System.Drawing.Size(32, 32);
            this.btnToolSwitch.TabIndex = 1;
            this.btnToolSwitch.Tag = "";
            this.btnToolSwitch.UseVisualStyleBackColor = true;
            this.btnToolSwitch.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolMove
            // 
            this.btnToolMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolMove.Image = global::SHME.Properties.Resources.toolMove;
            this.btnToolMove.Location = new System.Drawing.Point(4, 36);
            this.btnToolMove.Name = "btnToolMove";
            this.btnToolMove.Size = new System.Drawing.Size(32, 32);
            this.btnToolMove.TabIndex = 0;
            this.btnToolMove.Tag = "";
            this.btnToolMove.UseVisualStyleBackColor = true;
            this.btnToolMove.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolProbe1
            // 
            this.btnToolProbe1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolProbe1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolProbe1.Image = global::SHME.Properties.Resources.toolProbe;
            this.btnToolProbe1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolProbe1.Location = new System.Drawing.Point(68, 68);
            this.btnToolProbe1.Name = "btnToolProbe1";
            this.btnToolProbe1.Size = new System.Drawing.Size(32, 32);
            this.btnToolProbe1.TabIndex = 5;
            this.btnToolProbe1.Tag = "";
            this.btnToolProbe1.Text = "1";
            this.btnToolProbe1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolProbe1.UseVisualStyleBackColor = true;
            this.btnToolProbe1.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolProbe2
            // 
            this.btnToolProbe2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolProbe2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolProbe2.Image = global::SHME.Properties.Resources.toolProbe;
            this.btnToolProbe2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolProbe2.Location = new System.Drawing.Point(68, 36);
            this.btnToolProbe2.Name = "btnToolProbe2";
            this.btnToolProbe2.Size = new System.Drawing.Size(32, 32);
            this.btnToolProbe2.TabIndex = 6;
            this.btnToolProbe2.Tag = "";
            this.btnToolProbe2.Text = "2";
            this.btnToolProbe2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolProbe2.UseVisualStyleBackColor = true;
            this.btnToolProbe2.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolPencil1
            // 
            this.btnToolPencil1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolPencil1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolPencil1.Image = global::SHME.Properties.Resources.toolPencil;
            this.btnToolPencil1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolPencil1.Location = new System.Drawing.Point(36, 68);
            this.btnToolPencil1.Name = "btnToolPencil1";
            this.btnToolPencil1.Size = new System.Drawing.Size(32, 32);
            this.btnToolPencil1.TabIndex = 2;
            this.btnToolPencil1.Tag = "";
            this.btnToolPencil1.Text = "1";
            this.btnToolPencil1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolPencil1.UseVisualStyleBackColor = true;
            this.btnToolPencil1.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolSmooth1
            // 
            this.btnToolSmooth1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolSmooth1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolSmooth1.Image = global::SHME.Properties.Resources.toolLevelSmooth;
            this.btnToolSmooth1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolSmooth1.Location = new System.Drawing.Point(196, 68);
            this.btnToolSmooth1.Name = "btnToolSmooth1";
            this.btnToolSmooth1.Size = new System.Drawing.Size(32, 32);
            this.btnToolSmooth1.TabIndex = 17;
            this.btnToolSmooth1.Tag = "";
            this.btnToolSmooth1.Text = "1";
            this.btnToolSmooth1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolSmooth1.UseVisualStyleBackColor = true;
            this.btnToolSmooth1.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolLevel1
            // 
            this.btnToolLevel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolLevel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolLevel1.Image = global::SHME.Properties.Resources.toolLevel;
            this.btnToolLevel1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolLevel1.Location = new System.Drawing.Point(164, 68);
            this.btnToolLevel1.Name = "btnToolLevel1";
            this.btnToolLevel1.Size = new System.Drawing.Size(32, 32);
            this.btnToolLevel1.TabIndex = 14;
            this.btnToolLevel1.Tag = "";
            this.btnToolLevel1.Text = "1";
            this.btnToolLevel1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolLevel1.UseVisualStyleBackColor = true;
            this.btnToolLevel1.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolAdd1
            // 
            this.btnToolAdd1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolAdd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolAdd1.Image = ((System.Drawing.Image)(resources.GetObject("btnToolAdd1.Image")));
            this.btnToolAdd1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolAdd1.Location = new System.Drawing.Point(100, 68);
            this.btnToolAdd1.Name = "btnToolAdd1";
            this.btnToolAdd1.Size = new System.Drawing.Size(32, 32);
            this.btnToolAdd1.TabIndex = 8;
            this.btnToolAdd1.Tag = "";
            this.btnToolAdd1.Text = "1";
            this.btnToolAdd1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolAdd1.UseVisualStyleBackColor = true;
            this.btnToolAdd1.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolSub1
            // 
            this.btnToolSub1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolSub1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolSub1.Image = global::SHME.Properties.Resources.toolLevelSub;
            this.btnToolSub1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolSub1.Location = new System.Drawing.Point(132, 68);
            this.btnToolSub1.Name = "btnToolSub1";
            this.btnToolSub1.Size = new System.Drawing.Size(32, 32);
            this.btnToolSub1.TabIndex = 11;
            this.btnToolSub1.Tag = "";
            this.btnToolSub1.Text = "1";
            this.btnToolSub1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolSub1.UseVisualStyleBackColor = true;
            this.btnToolSub1.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolProbe3
            // 
            this.btnToolProbe3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolProbe3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolProbe3.Image = global::SHME.Properties.Resources.toolProbe;
            this.btnToolProbe3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolProbe3.Location = new System.Drawing.Point(68, 4);
            this.btnToolProbe3.Name = "btnToolProbe3";
            this.btnToolProbe3.Size = new System.Drawing.Size(32, 32);
            this.btnToolProbe3.TabIndex = 7;
            this.btnToolProbe3.Tag = "";
            this.btnToolProbe3.Text = "3";
            this.btnToolProbe3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolProbe3.UseVisualStyleBackColor = true;
            this.btnToolProbe3.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolPencil3
            // 
            this.btnToolPencil3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolPencil3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolPencil3.Image = global::SHME.Properties.Resources.toolPencil;
            this.btnToolPencil3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolPencil3.Location = new System.Drawing.Point(36, 4);
            this.btnToolPencil3.Name = "btnToolPencil3";
            this.btnToolPencil3.Size = new System.Drawing.Size(32, 32);
            this.btnToolPencil3.TabIndex = 4;
            this.btnToolPencil3.Tag = "";
            this.btnToolPencil3.Text = "3";
            this.btnToolPencil3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolPencil3.UseVisualStyleBackColor = true;
            this.btnToolPencil3.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // btnToolPencil2
            // 
            this.btnToolPencil2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolPencil2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnToolPencil2.Image = global::SHME.Properties.Resources.toolPencil;
            this.btnToolPencil2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnToolPencil2.Location = new System.Drawing.Point(36, 36);
            this.btnToolPencil2.Name = "btnToolPencil2";
            this.btnToolPencil2.Size = new System.Drawing.Size(32, 32);
            this.btnToolPencil2.TabIndex = 3;
            this.btnToolPencil2.Tag = "";
            this.btnToolPencil2.Text = "2";
            this.btnToolPencil2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnToolPencil2.UseVisualStyleBackColor = true;
            this.btnToolPencil2.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // pbPDA
            // 
            this.pbPDA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPDA.InitialImage = null;
            this.pbPDA.Location = new System.Drawing.Point(220, 0);
            this.pbPDA.Name = "pbPDA";
            this.pbPDA.Size = new System.Drawing.Size(360, 312);
            this.pbPDA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPDA.TabIndex = 1;
            this.pbPDA.TabStop = false;
            this.pbPDA.Visible = false;
            this.pbPDA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbHMap_MouseDown);
            this.pbPDA.MouseLeave += new System.EventHandler(this.FormSHME_MouseLeave);
            this.pbPDA.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbHMap_MouseMove);
            // 
            // FormSHME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(784, 592);
            this.Controls.Add(this.pnlToolSelect);
            this.Controls.Add(this.pnlZoomGrid);
            this.Controls.Add(this.pnlCorner);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.tlpTools);
            this.Controls.Add(this.pbPDA);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(360, 550);
            this.Name = "FormSHME";
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
            ((System.ComponentModel.ISupportInitialize)(this.nudByte)).EndInit();
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTool3Size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTool2Size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTool1Size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTool3Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTool2Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTool1Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMouseButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZoomOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZoomIn)).EndInit();
            this.pnlZoomGrid.ResumeLayout(false);
            this.pnlZoomGrid.PerformLayout();
            this.pnlToolSelect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPDA)).EndInit();
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
        private System.Windows.Forms.PictureBox pbPDA;
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
        private System.Windows.Forms.Label lblPDASizes;
        private System.Windows.Forms.Button btnLoadHMap;
        private System.Windows.Forms.Button btnLoadPDA;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.Panel pnlCorner;
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
        private System.Windows.Forms.Label lblTool1Hex;
        private System.Windows.Forms.TextBox tbTool1Hex;
        private System.Windows.Forms.Label lblTool2Hex;
        private System.Windows.Forms.Label lblTool3Hex;
        private System.Windows.Forms.TextBox tbTool2Hex;
        private System.Windows.Forms.TextBox tbTool3Hex;
        private System.Windows.Forms.NumericUpDown nudTool1Value;
        private System.Windows.Forms.NumericUpDown nudTool2Value;
        private System.Windows.Forms.NumericUpDown nudTool3Value;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbByteLo;
        private System.Windows.Forms.ComboBox cbbBytePresets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudByte;
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
        private System.Windows.Forms.Button btnToolSmooth1;
        private System.Windows.Forms.Button btnToolSub1;
        private System.Windows.Forms.Button btnToolAdd1;
        private System.Windows.Forms.Button btnToolLevel1;
        private System.Windows.Forms.Button btnToolPencil1;
        private System.Windows.Forms.Button btnToolProbe1;
        private System.Windows.Forms.Button btnToolMove;
        private System.Windows.Forms.PictureBox pbMouseButtons;
        private System.Windows.Forms.Button btnToolRMB;
        private System.Windows.Forms.Button btnToolMMB;
        private System.Windows.Forms.Button btnToolLMB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbbToolPreset;
        private System.Windows.Forms.Button btnToolPencil3;
        private System.Windows.Forms.Button btnToolProbe3;
        private System.Windows.Forms.Button btnToolPencil2;
        private System.Windows.Forms.Button btnToolProbe2;
        private System.Windows.Forms.NumericUpDown nudTool1Size;
        private System.Windows.Forms.Button btnToolSwitch;
        private System.Windows.Forms.NumericUpDown nudTool3Size;
        private System.Windows.Forms.NumericUpDown nudTool2Size;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox chbTool3Shape;
        private System.Windows.Forms.CheckBox chbTool2Shape;
        private System.Windows.Forms.CheckBox chbTool1Shape;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ImageList ilToolShape;
        private System.Windows.Forms.Button btnToolAdd3;
        private System.Windows.Forms.Button btnToolAdd2;
        private System.Windows.Forms.Button btnToolSub3;
        private System.Windows.Forms.Button btnToolSub2;
        private System.Windows.Forms.Button btnToolSmooth3;
        private System.Windows.Forms.Button btnToolSmooth2;
        private System.Windows.Forms.Button btnToolLevel3;
        private System.Windows.Forms.Button btnToolLevel2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnToolX2MB;
        private System.Windows.Forms.Button btnToolX1MB;
        private System.Windows.Forms.Button btnHistoryForward;
        private System.Windows.Forms.Button btnHistoryBackward;
        private System.Windows.Forms.CheckBox chbShowHMap;
        private System.Windows.Forms.CheckBox chbShowPDA;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnHMapResize;
        private System.Windows.Forms.Button btnPDAGenerate;
    }
}

