namespace SHME
{
    partial class FormCPlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCPlay));
            this.btnFileReload = new System.Windows.Forms.Button();
            this.btnFileLoad = new System.Windows.Forms.Button();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.btnSaveRoute = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnReloadRoute = new System.Windows.Forms.Button();
            this.clbWaypoints = new System.Windows.Forms.CheckedListBox();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.gbStepOffset = new System.Windows.Forms.GroupBox();
            this.btnPositionAlign = new System.Windows.Forms.Button();
            this.btnRotationAlign = new System.Windows.Forms.Button();
            this.nudRotationStep = new System.Windows.Forms.NumericUpDown();
            this.nudPositionOffset = new System.Windows.Forms.NumericUpDown();
            this.nudRotationOffset = new System.Windows.Forms.NumericUpDown();
            this.nudPositionStep = new System.Windows.Forms.NumericUpDown();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.gbEdit = new System.Windows.Forms.GroupBox();
            this.btnSavePoint = new System.Windows.Forms.Button();
            this.chb14 = new System.Windows.Forms.CheckBox();
            this.btnDeletePoint = new System.Windows.Forms.Button();
            this.tb13 = new System.Windows.Forms.TextBox();
            this.tb11 = new System.Windows.Forms.TextBox();
            this.nud12 = new System.Windows.Forms.NumericUpDown();
            this.nud05 = new System.Windows.Forms.NumericUpDown();
            this.chb10 = new System.Windows.Forms.CheckBox();
            this.chb09 = new System.Windows.Forms.CheckBox();
            this.chb08 = new System.Windows.Forms.CheckBox();
            this.chb07 = new System.Windows.Forms.CheckBox();
            this.dudAction = new System.Windows.Forms.DomainUpDown();
            this.nudR = new System.Windows.Forms.NumericUpDown();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.nudZ = new System.Windows.Forms.NumericUpDown();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.tbReplace = new System.Windows.Forms.TextBox();
            this.lblR = new System.Windows.Forms.Label();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.gbLimit = new System.Windows.Forms.GroupBox();
            this.cbLimitZ = new System.Windows.Forms.CheckBox();
            this.cbLimitY = new System.Windows.Forms.CheckBox();
            this.cbLimitR = new System.Windows.Forms.CheckBox();
            this.cbLimitX = new System.Windows.Forms.CheckBox();
            this.nudLimitRMin = new System.Windows.Forms.NumericUpDown();
            this.nudLimitRMax = new System.Windows.Forms.NumericUpDown();
            this.nudLimitZMin = new System.Windows.Forms.NumericUpDown();
            this.nudLimitZMax = new System.Windows.Forms.NumericUpDown();
            this.nudLimitYMin = new System.Windows.Forms.NumericUpDown();
            this.nudLimitYMax = new System.Windows.Forms.NumericUpDown();
            this.nudLimitXMin = new System.Windows.Forms.NumericUpDown();
            this.nudLimitXMax = new System.Windows.Forms.NumericUpDown();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.splitter = new System.Windows.Forms.Splitter();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.btnSaveRoutes = new System.Windows.Forms.Button();
            this.chbRouteEnabled = new System.Windows.Forms.CheckBox();
            this.btnRouteInfoSave = new System.Windows.Forms.Button();
            this.tbRouteName = new System.Windows.Forms.TextBox();
            this.tvRoutes = new System.Windows.Forms.TreeView();
            this.il3State = new System.Windows.Forms.ImageList(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.pnlMain.SuspendLayout();
            this.pnlItems.SuspendLayout();
            this.gbStepOffset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRotationStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRotationOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionStep)).BeginInit();
            this.gbEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            this.gbLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitRMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitRMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitZMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitZMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitYMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitYMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitXMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitXMax)).BeginInit();
            this.pnlFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFileReload
            // 
            this.btnFileReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileReload.BackgroundImage = global::SHME.Properties.Resources.reload;
            this.btnFileReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFileReload.FlatAppearance.BorderSize = 0;
            this.btnFileReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileReload.Location = new System.Drawing.Point(832, 12);
            this.btnFileReload.Name = "btnFileReload";
            this.btnFileReload.Size = new System.Drawing.Size(20, 20);
            this.btnFileReload.TabIndex = 29;
            this.btnFileReload.UseVisualStyleBackColor = true;
            this.btnFileReload.Click += new System.EventHandler(this.btnFileReload_Click);
            // 
            // btnFileLoad
            // 
            this.btnFileLoad.BackgroundImage = global::SHME.Properties.Resources.load;
            this.btnFileLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFileLoad.FlatAppearance.BorderSize = 0;
            this.btnFileLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileLoad.Location = new System.Drawing.Point(12, 12);
            this.btnFileLoad.Name = "btnFileLoad";
            this.btnFileLoad.Size = new System.Drawing.Size(20, 20);
            this.btnFileLoad.TabIndex = 26;
            this.btnFileLoad.UseVisualStyleBackColor = true;
            this.btnFileLoad.Click += new System.EventHandler(this.btnFileLoad_Click);
            // 
            // tbFile
            // 
            this.tbFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFile.Location = new System.Drawing.Point(38, 12);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(788, 20);
            this.tbFile.TabIndex = 27;
            // 
            // btnSaveRoute
            // 
            this.btnSaveRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveRoute.BackgroundImage = global::SHME.Properties.Resources.save;
            this.btnSaveRoute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSaveRoute.FlatAppearance.BorderSize = 0;
            this.btnSaveRoute.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveRoute.Location = new System.Drawing.Point(820, 191);
            this.btnSaveRoute.Name = "btnSaveRoute";
            this.btnSaveRoute.Size = new System.Drawing.Size(20, 20);
            this.btnSaveRoute.TabIndex = 28;
            this.btnSaveRoute.UseVisualStyleBackColor = true;
            this.btnSaveRoute.Visible = false;
            this.btnSaveRoute.Click += new System.EventHandler(this.btnSaveRoute_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Controls.Add(this.btnSaveRoute);
            this.pnlMain.Controls.Add(this.btnReloadRoute);
            this.pnlMain.Controls.Add(this.clbWaypoints);
            this.pnlMain.Controls.Add(this.pnlItems);
            this.pnlMain.Controls.Add(this.splitter);
            this.pnlMain.Controls.Add(this.pnlFilters);
            this.pnlMain.Location = new System.Drawing.Point(12, 38);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(840, 211);
            this.pnlMain.TabIndex = 30;
            // 
            // btnReloadRoute
            // 
            this.btnReloadRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReloadRoute.AutoEllipsis = true;
            this.btnReloadRoute.BackgroundImage = global::SHME.Properties.Resources.reload;
            this.btnReloadRoute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReloadRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReloadRoute.Location = new System.Drawing.Point(801, 172);
            this.btnReloadRoute.Name = "btnReloadRoute";
            this.btnReloadRoute.Size = new System.Drawing.Size(20, 20);
            this.btnReloadRoute.TabIndex = 24;
            this.btnReloadRoute.UseVisualStyleBackColor = true;
            this.btnReloadRoute.Visible = false;
            this.btnReloadRoute.Click += new System.EventHandler(this.btnReloadRoute_Click);
            // 
            // clbWaypoints
            // 
            this.clbWaypoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbWaypoints.HorizontalScrollbar = true;
            this.clbWaypoints.IntegralHeight = false;
            this.clbWaypoints.Location = new System.Drawing.Point(232, 130);
            this.clbWaypoints.Name = "clbWaypoints";
            this.clbWaypoints.ScrollAlwaysVisible = true;
            this.clbWaypoints.Size = new System.Drawing.Size(608, 81);
            this.clbWaypoints.TabIndex = 21;
            this.clbWaypoints.SelectedIndexChanged += new System.EventHandler(this.clbWaypoints_SelectedIndexChanged);
            // 
            // pnlItems
            // 
            this.pnlItems.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlItems.Controls.Add(this.gbStepOffset);
            this.pnlItems.Controls.Add(this.btnFind);
            this.pnlItems.Controls.Add(this.btnReplace);
            this.pnlItems.Controls.Add(this.gbEdit);
            this.pnlItems.Controls.Add(this.tbReplace);
            this.pnlItems.Controls.Add(this.lblR);
            this.pnlItems.Controls.Add(this.tbFind);
            this.pnlItems.Controls.Add(this.gbLimit);
            this.pnlItems.Controls.Add(this.lblZ);
            this.pnlItems.Controls.Add(this.lblY);
            this.pnlItems.Controls.Add(this.lblX);
            this.pnlItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlItems.Location = new System.Drawing.Point(232, 0);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(608, 130);
            this.pnlItems.TabIndex = 22;
            // 
            // gbStepOffset
            // 
            this.gbStepOffset.Controls.Add(this.btnPositionAlign);
            this.gbStepOffset.Controls.Add(this.btnRotationAlign);
            this.gbStepOffset.Controls.Add(this.nudRotationStep);
            this.gbStepOffset.Controls.Add(this.nudPositionOffset);
            this.gbStepOffset.Controls.Add(this.nudRotationOffset);
            this.gbStepOffset.Controls.Add(this.nudPositionStep);
            this.gbStepOffset.Location = new System.Drawing.Point(424, 3);
            this.gbStepOffset.Name = "gbStepOffset";
            this.gbStepOffset.Size = new System.Drawing.Size(174, 72);
            this.gbStepOffset.TabIndex = 32;
            this.gbStepOffset.TabStop = false;
            this.gbStepOffset.Text = "Step / Offset";
            // 
            // btnPositionAlign
            // 
            this.btnPositionAlign.FlatAppearance.BorderSize = 0;
            this.btnPositionAlign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPositionAlign.Image = ((System.Drawing.Image)(resources.GetObject("btnPositionAlign.Image")));
            this.btnPositionAlign.Location = new System.Drawing.Point(6, 19);
            this.btnPositionAlign.Name = "btnPositionAlign";
            this.btnPositionAlign.Size = new System.Drawing.Size(21, 21);
            this.btnPositionAlign.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnPositionAlign, "Align position. Only X, Z axis");
            this.btnPositionAlign.UseVisualStyleBackColor = true;
            this.btnPositionAlign.Click += new System.EventHandler(this.btnAlign_Click);
            // 
            // btnRotationAlign
            // 
            this.btnRotationAlign.FlatAppearance.BorderSize = 0;
            this.btnRotationAlign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRotationAlign.Image = global::SHME.Properties.Resources.reload;
            this.btnRotationAlign.Location = new System.Drawing.Point(6, 42);
            this.btnRotationAlign.Name = "btnRotationAlign";
            this.btnRotationAlign.Size = new System.Drawing.Size(21, 21);
            this.btnRotationAlign.TabIndex = 2;
            this.btnRotationAlign.UseVisualStyleBackColor = true;
            this.btnRotationAlign.Click += new System.EventHandler(this.btnAlign_Click);
            // 
            // nudRotationStep
            // 
            this.nudRotationStep.DecimalPlaces = 2;
            this.nudRotationStep.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudRotationStep.Location = new System.Drawing.Point(33, 45);
            this.nudRotationStep.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudRotationStep.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.nudRotationStep.Name = "nudRotationStep";
            this.nudRotationStep.Size = new System.Drawing.Size(64, 20);
            this.nudRotationStep.TabIndex = 10;
            this.nudRotationStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.nudRotationStep, "Rotation increment step");
            this.nudRotationStep.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.nudRotationStep.ValueChanged += new System.EventHandler(this.nudRotationStep_ValueChanged);
            // 
            // nudPositionOffset
            // 
            this.nudPositionOffset.DecimalPlaces = 2;
            this.nudPositionOffset.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.nudPositionOffset.Location = new System.Drawing.Point(103, 19);
            this.nudPositionOffset.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nudPositionOffset.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.nudPositionOffset.Name = "nudPositionOffset";
            this.nudPositionOffset.Size = new System.Drawing.Size(64, 20);
            this.nudPositionOffset.TabIndex = 10;
            this.nudPositionOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.nudPositionOffset, "Position increment step offset");
            // 
            // nudRotationOffset
            // 
            this.nudRotationOffset.DecimalPlaces = 2;
            this.nudRotationOffset.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudRotationOffset.Location = new System.Drawing.Point(103, 45);
            this.nudRotationOffset.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudRotationOffset.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.nudRotationOffset.Name = "nudRotationOffset";
            this.nudRotationOffset.Size = new System.Drawing.Size(64, 20);
            this.nudRotationOffset.TabIndex = 10;
            this.nudRotationOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.nudRotationOffset, "Rotation increment step offset");
            // 
            // nudPositionStep
            // 
            this.nudPositionStep.DecimalPlaces = 2;
            this.nudPositionStep.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudPositionStep.Location = new System.Drawing.Point(33, 19);
            this.nudPositionStep.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nudPositionStep.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.nudPositionStep.Name = "nudPositionStep";
            this.nudPositionStep.Size = new System.Drawing.Size(64, 20);
            this.nudPositionStep.TabIndex = 10;
            this.nudPositionStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.nudPositionStep, "Position increment step");
            this.nudPositionStep.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.nudPositionStep.ValueChanged += new System.EventHandler(this.nudPositionStep_ValueChanged);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.BackgroundImage = global::SHME.Properties.Resources.compare;
            this.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFind.FlatAppearance.BorderSize = 0;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Location = new System.Drawing.Point(587, 77);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(21, 21);
            this.btnFind.TabIndex = 3;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplace.BackgroundImage = global::SHME.Properties.Resources.reuse;
            this.btnReplace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReplace.FlatAppearance.BorderSize = 0;
            this.btnReplace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplace.Location = new System.Drawing.Point(587, 103);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(21, 21);
            this.btnReplace.TabIndex = 3;
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // gbEdit
            // 
            this.gbEdit.Controls.Add(this.btnSavePoint);
            this.gbEdit.Controls.Add(this.chb14);
            this.gbEdit.Controls.Add(this.btnDeletePoint);
            this.gbEdit.Controls.Add(this.tb13);
            this.gbEdit.Controls.Add(this.tb11);
            this.gbEdit.Controls.Add(this.nud12);
            this.gbEdit.Controls.Add(this.nud05);
            this.gbEdit.Controls.Add(this.chb10);
            this.gbEdit.Controls.Add(this.chb09);
            this.gbEdit.Controls.Add(this.chb08);
            this.gbEdit.Controls.Add(this.chb07);
            this.gbEdit.Controls.Add(this.dudAction);
            this.gbEdit.Controls.Add(this.nudR);
            this.gbEdit.Controls.Add(this.nudX);
            this.gbEdit.Controls.Add(this.nudZ);
            this.gbEdit.Controls.Add(this.nudY);
            this.gbEdit.Location = new System.Drawing.Point(224, 3);
            this.gbEdit.Name = "gbEdit";
            this.gbEdit.Size = new System.Drawing.Size(194, 124);
            this.gbEdit.TabIndex = 31;
            this.gbEdit.TabStop = false;
            this.gbEdit.Text = "Values";
            this.gbEdit.Visible = false;
            // 
            // btnSavePoint
            // 
            this.btnSavePoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavePoint.BackgroundImage = global::SHME.Properties.Resources.toolPencil;
            this.btnSavePoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSavePoint.FlatAppearance.BorderSize = 0;
            this.btnSavePoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSavePoint.Location = new System.Drawing.Point(170, 69);
            this.btnSavePoint.Name = "btnSavePoint";
            this.btnSavePoint.Size = new System.Drawing.Size(24, 24);
            this.btnSavePoint.TabIndex = 33;
            this.btnSavePoint.UseVisualStyleBackColor = true;
            this.btnSavePoint.Visible = false;
            this.btnSavePoint.Click += new System.EventHandler(this.btnSavePoint_Click);
            // 
            // chb14
            // 
            this.chb14.Location = new System.Drawing.Point(159, 44);
            this.chb14.Name = "chb14";
            this.chb14.Size = new System.Drawing.Size(30, 20);
            this.chb14.TabIndex = 44;
            this.chb14.UseVisualStyleBackColor = true;
            this.chb14.CheckedChanged += new System.EventHandler(this.Waypoint_ValueChanged);
            // 
            // btnDeletePoint
            // 
            this.btnDeletePoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeletePoint.BackgroundImage = global::SHME.Properties.Resources.delete;
            this.btnDeletePoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeletePoint.FlatAppearance.BorderSize = 0;
            this.btnDeletePoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeletePoint.Location = new System.Drawing.Point(170, 98);
            this.btnDeletePoint.Name = "btnDeletePoint";
            this.btnDeletePoint.Size = new System.Drawing.Size(24, 24);
            this.btnDeletePoint.TabIndex = 31;
            this.btnDeletePoint.UseVisualStyleBackColor = true;
            this.btnDeletePoint.Click += new System.EventHandler(this.btnDeletePoint_Click);
            // 
            // tb13
            // 
            this.tb13.Location = new System.Drawing.Point(159, 17);
            this.tb13.Name = "tb13";
            this.tb13.Size = new System.Drawing.Size(29, 20);
            this.tb13.TabIndex = 43;
            this.tb13.TextChanged += new System.EventHandler(this.Waypoint_ValueChanged);
            // 
            // tb11
            // 
            this.tb11.Location = new System.Drawing.Point(124, 71);
            this.tb11.Name = "tb11";
            this.tb11.Size = new System.Drawing.Size(29, 20);
            this.tb11.TabIndex = 4;
            this.tb11.TextChanged += new System.EventHandler(this.Waypoint_ValueChanged);
            // 
            // nud12
            // 
            this.nud12.Location = new System.Drawing.Point(124, 98);
            this.nud12.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud12.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nud12.Name = "nud12";
            this.nud12.Size = new System.Drawing.Size(29, 20);
            this.nud12.TabIndex = 42;
            this.toolTip.SetToolTip(this.nud12, "Empty string as -1");
            this.nud12.ValueChanged += new System.EventHandler(this.Waypoint_ValueChanged);
            // 
            // nud05
            // 
            this.nud05.Location = new System.Drawing.Point(88, 17);
            this.nud05.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nud05.Name = "nud05";
            this.nud05.Size = new System.Drawing.Size(29, 20);
            this.nud05.TabIndex = 42;
            this.nud05.ValueChanged += new System.EventHandler(this.Waypoint_ValueChanged);
            // 
            // chb10
            // 
            this.chb10.Location = new System.Drawing.Point(123, 44);
            this.chb10.Name = "chb10";
            this.chb10.Size = new System.Drawing.Size(30, 20);
            this.chb10.TabIndex = 40;
            this.chb10.UseVisualStyleBackColor = true;
            this.chb10.CheckedChanged += new System.EventHandler(this.Waypoint_ValueChanged);
            // 
            // chb09
            // 
            this.chb09.Location = new System.Drawing.Point(123, 17);
            this.chb09.Name = "chb09";
            this.chb09.Size = new System.Drawing.Size(30, 20);
            this.chb09.TabIndex = 39;
            this.chb09.UseVisualStyleBackColor = true;
            this.chb09.CheckedChanged += new System.EventHandler(this.Waypoint_ValueChanged);
            // 
            // chb08
            // 
            this.chb08.Location = new System.Drawing.Point(88, 98);
            this.chb08.Name = "chb08";
            this.chb08.Size = new System.Drawing.Size(30, 20);
            this.chb08.TabIndex = 38;
            this.chb08.UseVisualStyleBackColor = true;
            this.chb08.CheckedChanged += new System.EventHandler(this.Waypoint_ValueChanged);
            // 
            // chb07
            // 
            this.chb07.Location = new System.Drawing.Point(88, 71);
            this.chb07.Name = "chb07";
            this.chb07.Size = new System.Drawing.Size(30, 20);
            this.chb07.TabIndex = 37;
            this.chb07.UseVisualStyleBackColor = true;
            this.chb07.CheckedChanged += new System.EventHandler(this.Waypoint_ValueChanged);
            // 
            // dudAction
            // 
            this.dudAction.Items.Add("");
            this.dudAction.Items.Add("Engage");
            this.dudAction.Items.Add("Stop");
            this.dudAction.Location = new System.Drawing.Point(88, 44);
            this.dudAction.Name = "dudAction";
            this.dudAction.Size = new System.Drawing.Size(29, 20);
            this.dudAction.TabIndex = 34;
            this.toolTip.SetToolTip(this.dudAction, "\"\"/Stop/Engage");
            this.dudAction.SelectedItemChanged += new System.EventHandler(this.Waypoint_ValueChanged);
            // 
            // nudR
            // 
            this.nudR.DecimalPlaces = 2;
            this.nudR.Location = new System.Drawing.Point(6, 98);
            this.nudR.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudR.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nudR.Name = "nudR";
            this.nudR.Size = new System.Drawing.Size(76, 20);
            this.nudR.TabIndex = 16;
            this.nudR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudR.Value = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nudR.ValueChanged += new System.EventHandler(this.Waypoint_ValueChanged);
            // 
            // nudX
            // 
            this.nudX.DecimalPlaces = 2;
            this.nudX.Location = new System.Drawing.Point(6, 17);
            this.nudX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudX.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(76, 20);
            this.nudX.TabIndex = 34;
            this.nudX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudX.Value = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudX.ValueChanged += new System.EventHandler(this.Waypoint_ValueChanged);
            // 
            // nudZ
            // 
            this.nudZ.DecimalPlaces = 2;
            this.nudZ.Location = new System.Drawing.Point(6, 71);
            this.nudZ.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudZ.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudZ.Name = "nudZ";
            this.nudZ.Size = new System.Drawing.Size(76, 20);
            this.nudZ.TabIndex = 36;
            this.nudZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudZ.Value = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudZ.ValueChanged += new System.EventHandler(this.Waypoint_ValueChanged);
            // 
            // nudY
            // 
            this.nudY.DecimalPlaces = 2;
            this.nudY.Location = new System.Drawing.Point(6, 44);
            this.nudY.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudY.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(76, 20);
            this.nudY.TabIndex = 35;
            this.nudY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudY.Value = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudY.ValueChanged += new System.EventHandler(this.Waypoint_ValueChanged);
            // 
            // tbReplace
            // 
            this.tbReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReplace.Location = new System.Drawing.Point(424, 104);
            this.tbReplace.Name = "tbReplace";
            this.tbReplace.Size = new System.Drawing.Size(157, 20);
            this.tbReplace.TabIndex = 1;
            // 
            // lblR
            // 
            this.lblR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblR.Location = new System.Drawing.Point(204, 101);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(14, 19);
            this.lblR.TabIndex = 31;
            this.lblR.Text = "↻";
            this.lblR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbFind
            // 
            this.tbFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFind.Location = new System.Drawing.Point(424, 78);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(157, 20);
            this.tbFind.TabIndex = 0;
            // 
            // gbLimit
            // 
            this.gbLimit.Controls.Add(this.cbLimitZ);
            this.gbLimit.Controls.Add(this.cbLimitY);
            this.gbLimit.Controls.Add(this.cbLimitR);
            this.gbLimit.Controls.Add(this.cbLimitX);
            this.gbLimit.Controls.Add(this.nudLimitRMin);
            this.gbLimit.Controls.Add(this.nudLimitRMax);
            this.gbLimit.Controls.Add(this.nudLimitZMin);
            this.gbLimit.Controls.Add(this.nudLimitZMax);
            this.gbLimit.Controls.Add(this.nudLimitYMin);
            this.gbLimit.Controls.Add(this.nudLimitYMax);
            this.gbLimit.Controls.Add(this.nudLimitXMin);
            this.gbLimit.Controls.Add(this.nudLimitXMax);
            this.gbLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbLimit.Location = new System.Drawing.Point(6, 3);
            this.gbLimit.Name = "gbLimit";
            this.gbLimit.Size = new System.Drawing.Size(192, 124);
            this.gbLimit.TabIndex = 23;
            this.gbLimit.TabStop = false;
            this.gbLimit.Text = "Limit";
            // 
            // cbLimitZ
            // 
            this.cbLimitZ.AutoSize = true;
            this.cbLimitZ.Location = new System.Drawing.Point(6, 74);
            this.cbLimitZ.Name = "cbLimitZ";
            this.cbLimitZ.Size = new System.Drawing.Size(15, 14);
            this.cbLimitZ.TabIndex = 33;
            this.cbLimitZ.UseVisualStyleBackColor = true;
            this.cbLimitZ.CheckedChanged += new System.EventHandler(this.cbLimit_ValueChanged);
            // 
            // cbLimitY
            // 
            this.cbLimitY.AutoSize = true;
            this.cbLimitY.Location = new System.Drawing.Point(6, 47);
            this.cbLimitY.Name = "cbLimitY";
            this.cbLimitY.Size = new System.Drawing.Size(15, 14);
            this.cbLimitY.TabIndex = 32;
            this.cbLimitY.UseVisualStyleBackColor = true;
            this.cbLimitY.CheckedChanged += new System.EventHandler(this.cbLimit_ValueChanged);
            // 
            // cbLimitR
            // 
            this.cbLimitR.AutoSize = true;
            this.cbLimitR.Location = new System.Drawing.Point(6, 101);
            this.cbLimitR.Name = "cbLimitR";
            this.cbLimitR.Size = new System.Drawing.Size(15, 14);
            this.cbLimitR.TabIndex = 15;
            this.cbLimitR.UseVisualStyleBackColor = true;
            this.cbLimitR.CheckedChanged += new System.EventHandler(this.cbLimit_ValueChanged);
            // 
            // cbLimitX
            // 
            this.cbLimitX.AutoSize = true;
            this.cbLimitX.Location = new System.Drawing.Point(6, 20);
            this.cbLimitX.Name = "cbLimitX";
            this.cbLimitX.Size = new System.Drawing.Size(15, 14);
            this.cbLimitX.TabIndex = 14;
            this.cbLimitX.UseVisualStyleBackColor = true;
            this.cbLimitX.CheckedChanged += new System.EventHandler(this.cbLimit_ValueChanged);
            // 
            // nudLimitRMin
            // 
            this.nudLimitRMin.DecimalPlaces = 2;
            this.nudLimitRMin.Location = new System.Drawing.Point(27, 98);
            this.nudLimitRMin.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudLimitRMin.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nudLimitRMin.Name = "nudLimitRMin";
            this.nudLimitRMin.Size = new System.Drawing.Size(76, 21);
            this.nudLimitRMin.TabIndex = 9;
            this.nudLimitRMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitRMin.Value = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nudLimitRMin.ValueChanged += new System.EventHandler(this.cbLimit_ValueChanged);
            // 
            // nudLimitRMax
            // 
            this.nudLimitRMax.DecimalPlaces = 2;
            this.nudLimitRMax.Location = new System.Drawing.Point(109, 98);
            this.nudLimitRMax.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudLimitRMax.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nudLimitRMax.Name = "nudLimitRMax";
            this.nudLimitRMax.Size = new System.Drawing.Size(76, 21);
            this.nudLimitRMax.TabIndex = 9;
            this.nudLimitRMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitRMax.Value = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudLimitRMax.ValueChanged += new System.EventHandler(this.cbLimit_ValueChanged);
            // 
            // nudLimitZMin
            // 
            this.nudLimitZMin.DecimalPlaces = 2;
            this.nudLimitZMin.Location = new System.Drawing.Point(27, 71);
            this.nudLimitZMin.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudLimitZMin.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudLimitZMin.Name = "nudLimitZMin";
            this.nudLimitZMin.Size = new System.Drawing.Size(76, 21);
            this.nudLimitZMin.TabIndex = 12;
            this.nudLimitZMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitZMin.Value = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudLimitZMin.ValueChanged += new System.EventHandler(this.cbLimit_ValueChanged);
            // 
            // nudLimitZMax
            // 
            this.nudLimitZMax.DecimalPlaces = 2;
            this.nudLimitZMax.Location = new System.Drawing.Point(109, 71);
            this.nudLimitZMax.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudLimitZMax.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudLimitZMax.Name = "nudLimitZMax";
            this.nudLimitZMax.Size = new System.Drawing.Size(76, 21);
            this.nudLimitZMax.TabIndex = 12;
            this.nudLimitZMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitZMax.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudLimitZMax.ValueChanged += new System.EventHandler(this.cbLimit_ValueChanged);
            // 
            // nudLimitYMin
            // 
            this.nudLimitYMin.DecimalPlaces = 2;
            this.nudLimitYMin.Location = new System.Drawing.Point(27, 44);
            this.nudLimitYMin.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudLimitYMin.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudLimitYMin.Name = "nudLimitYMin";
            this.nudLimitYMin.Size = new System.Drawing.Size(76, 21);
            this.nudLimitYMin.TabIndex = 11;
            this.nudLimitYMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitYMin.Value = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudLimitYMin.ValueChanged += new System.EventHandler(this.cbLimit_ValueChanged);
            // 
            // nudLimitYMax
            // 
            this.nudLimitYMax.DecimalPlaces = 2;
            this.nudLimitYMax.Location = new System.Drawing.Point(109, 44);
            this.nudLimitYMax.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudLimitYMax.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudLimitYMax.Name = "nudLimitYMax";
            this.nudLimitYMax.Size = new System.Drawing.Size(76, 21);
            this.nudLimitYMax.TabIndex = 11;
            this.nudLimitYMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitYMax.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudLimitYMax.ValueChanged += new System.EventHandler(this.cbLimit_ValueChanged);
            // 
            // nudLimitXMin
            // 
            this.nudLimitXMin.DecimalPlaces = 2;
            this.nudLimitXMin.Location = new System.Drawing.Point(27, 17);
            this.nudLimitXMin.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudLimitXMin.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudLimitXMin.Name = "nudLimitXMin";
            this.nudLimitXMin.Size = new System.Drawing.Size(76, 21);
            this.nudLimitXMin.TabIndex = 10;
            this.nudLimitXMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitXMin.Value = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudLimitXMin.ValueChanged += new System.EventHandler(this.cbLimit_ValueChanged);
            // 
            // nudLimitXMax
            // 
            this.nudLimitXMax.DecimalPlaces = 2;
            this.nudLimitXMax.Location = new System.Drawing.Point(109, 17);
            this.nudLimitXMax.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudLimitXMax.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudLimitXMax.Name = "nudLimitXMax";
            this.nudLimitXMax.Size = new System.Drawing.Size(76, 21);
            this.nudLimitXMax.TabIndex = 10;
            this.nudLimitXMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitXMax.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudLimitXMax.ValueChanged += new System.EventHandler(this.cbLimit_ValueChanged);
            // 
            // lblZ
            // 
            this.lblZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblZ.Location = new System.Drawing.Point(204, 74);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(14, 19);
            this.lblZ.TabIndex = 13;
            this.lblZ.Text = "Z";
            this.lblZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY
            // 
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblY.Location = new System.Drawing.Point(204, 47);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(14, 19);
            this.lblY.TabIndex = 13;
            this.lblY.Text = "Y";
            this.lblY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX
            // 
            this.lblX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblX.Location = new System.Drawing.Point(204, 20);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(14, 19);
            this.lblX.TabIndex = 13;
            this.lblX.Text = "X";
            this.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter
            // 
            this.splitter.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.splitter.Location = new System.Drawing.Point(224, 0);
            this.splitter.MinExtra = 450;
            this.splitter.MinimumSize = new System.Drawing.Size(6, 2);
            this.splitter.MinSize = 150;
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(8, 211);
            this.splitter.TabIndex = 23;
            this.splitter.TabStop = false;
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.btnSaveRoutes);
            this.pnlFilters.Controls.Add(this.chbRouteEnabled);
            this.pnlFilters.Controls.Add(this.btnRouteInfoSave);
            this.pnlFilters.Controls.Add(this.tbRouteName);
            this.pnlFilters.Controls.Add(this.tvRoutes);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(224, 211);
            this.pnlFilters.TabIndex = 15;
            // 
            // btnSaveRoutes
            // 
            this.btnSaveRoutes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveRoutes.BackgroundImage = global::SHME.Properties.Resources.save;
            this.btnSaveRoutes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSaveRoutes.FlatAppearance.BorderSize = 0;
            this.btnSaveRoutes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveRoutes.Location = new System.Drawing.Point(204, 191);
            this.btnSaveRoutes.Name = "btnSaveRoutes";
            this.btnSaveRoutes.Size = new System.Drawing.Size(20, 20);
            this.btnSaveRoutes.TabIndex = 29;
            this.btnSaveRoutes.UseVisualStyleBackColor = true;
            this.btnSaveRoutes.Visible = false;
            this.btnSaveRoutes.Click += new System.EventHandler(this.btnSaveRoutes_Click);
            // 
            // chbRouteEnabled
            // 
            this.chbRouteEnabled.AutoSize = true;
            this.chbRouteEnabled.Enabled = false;
            this.chbRouteEnabled.Location = new System.Drawing.Point(3, 3);
            this.chbRouteEnabled.Name = "chbRouteEnabled";
            this.chbRouteEnabled.Size = new System.Drawing.Size(15, 14);
            this.chbRouteEnabled.TabIndex = 19;
            this.toolTip.SetToolTip(this.chbRouteEnabled, "Is route used. Uncheck to disable it in manager (will lose name).");
            this.chbRouteEnabled.UseVisualStyleBackColor = true;
            this.chbRouteEnabled.CheckedChanged += new System.EventHandler(this.RouteInfo_Changed);
            // 
            // btnRouteInfoSave
            // 
            this.btnRouteInfoSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRouteInfoSave.BackgroundImage = global::SHME.Properties.Resources.toolPencil;
            this.btnRouteInfoSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRouteInfoSave.FlatAppearance.BorderSize = 0;
            this.btnRouteInfoSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRouteInfoSave.Location = new System.Drawing.Point(198, 0);
            this.btnRouteInfoSave.Name = "btnRouteInfoSave";
            this.btnRouteInfoSave.Size = new System.Drawing.Size(20, 20);
            this.btnRouteInfoSave.TabIndex = 18;
            this.btnRouteInfoSave.UseVisualStyleBackColor = true;
            this.btnRouteInfoSave.Visible = false;
            this.btnRouteInfoSave.Click += new System.EventHandler(this.btnRouteInfoSave_Click);
            // 
            // tbRouteName
            // 
            this.tbRouteName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRouteName.Enabled = false;
            this.tbRouteName.Location = new System.Drawing.Point(24, 1);
            this.tbRouteName.Name = "tbRouteName";
            this.tbRouteName.Size = new System.Drawing.Size(168, 20);
            this.tbRouteName.TabIndex = 17;
            this.tbRouteName.TextChanged += new System.EventHandler(this.RouteInfo_Changed);
            this.tbRouteName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRoute_KeyPress);
            // 
            // tvRoutes
            // 
            this.tvRoutes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvRoutes.CausesValidation = false;
            this.tvRoutes.FullRowSelect = true;
            this.tvRoutes.HideSelection = false;
            this.tvRoutes.LabelEdit = true;
            this.tvRoutes.Location = new System.Drawing.Point(0, 26);
            this.tvRoutes.Name = "tvRoutes";
            this.tvRoutes.ShowLines = false;
            this.tvRoutes.ShowPlusMinus = false;
            this.tvRoutes.ShowRootLines = false;
            this.tvRoutes.Size = new System.Drawing.Size(224, 185);
            this.tvRoutes.StateImageList = this.il3State;
            this.tvRoutes.TabIndex = 16;
            this.tvRoutes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRoutes_AfterSelect);
            this.tvRoutes.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvRoutes_NodeMouseClick);
            // 
            // il3State
            // 
            this.il3State.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il3State.ImageStream")));
            this.il3State.TransparentColor = System.Drawing.Color.Transparent;
            this.il3State.Images.SetKeyName(0, "bulletMinus.png");
            this.il3State.Images.SetKeyName(1, "execute.png");
            // 
            // dlgOpen
            // 
            this.dlgOpen.DefaultExt = "xml";
            this.dlgOpen.Filter = "XML|courseManager.xml";
            // 
            // FormCPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 261);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnFileReload);
            this.Controls.Add(this.btnFileLoad);
            this.Controls.Add(this.tbFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(880, 300);
            this.Name = "FormCPlay";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "SHME: FS CoursePlay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCPlay_FormClosing);
            this.pnlMain.ResumeLayout(false);
            this.pnlItems.ResumeLayout(false);
            this.pnlItems.PerformLayout();
            this.gbStepOffset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRotationStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRotationOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionStep)).EndInit();
            this.gbEdit.ResumeLayout(false);
            this.gbEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            this.gbLimit.ResumeLayout(false);
            this.gbLimit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitRMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitRMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitZMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitZMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitYMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitYMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitXMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitXMax)).EndInit();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFileReload;
        private System.Windows.Forms.Button btnFileLoad;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Button btnSaveRoute;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnReloadRoute;
        private System.Windows.Forms.CheckedListBox clbWaypoints;
        private System.Windows.Forms.Panel pnlItems;
        private System.Windows.Forms.GroupBox gbEdit;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.CheckBox cbLimitR;
        private System.Windows.Forms.NumericUpDown nudLimitRMin;
        private System.Windows.Forms.NumericUpDown nudLimitRMax;
        private System.Windows.Forms.GroupBox gbLimit;
        private System.Windows.Forms.CheckBox cbLimitX;
        private System.Windows.Forms.NumericUpDown nudLimitZMin;
        private System.Windows.Forms.NumericUpDown nudLimitZMax;
        private System.Windows.Forms.NumericUpDown nudLimitYMin;
        private System.Windows.Forms.NumericUpDown nudLimitYMax;
        private System.Windows.Forms.NumericUpDown nudLimitXMin;
        private System.Windows.Forms.NumericUpDown nudLimitXMax;
        private System.Windows.Forms.NumericUpDown nudPositionStep;
        private System.Windows.Forms.NumericUpDown nudRotationOffset;
        private System.Windows.Forms.NumericUpDown nudPositionOffset;
        private System.Windows.Forms.NumericUpDown nudRotationStep;
        private System.Windows.Forms.Button btnRotationAlign;
        private System.Windows.Forms.Button btnPositionAlign;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.TreeView tvRoutes;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.TextBox tbReplace;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.TextBox tbRouteName;
        private System.Windows.Forms.Button btnRouteInfoSave;
        private System.Windows.Forms.NumericUpDown nudY;
        private System.Windows.Forms.NumericUpDown nudX;
        private System.Windows.Forms.NumericUpDown nudR;
        private System.Windows.Forms.NumericUpDown nudZ;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.CheckBox cbLimitZ;
        private System.Windows.Forms.CheckBox cbLimitY;
        private System.Windows.Forms.DomainUpDown dudAction;
        private System.Windows.Forms.CheckBox chb10;
        private System.Windows.Forms.CheckBox chb09;
        private System.Windows.Forms.CheckBox chb08;
        private System.Windows.Forms.CheckBox chb07;
        private System.Windows.Forms.NumericUpDown nud05;
        private System.Windows.Forms.CheckBox chb14;
        private System.Windows.Forms.TextBox tb13;
        private System.Windows.Forms.TextBox tb11;
        private System.Windows.Forms.NumericUpDown nud12;
        private System.Windows.Forms.GroupBox gbStepOffset;
        private System.Windows.Forms.Button btnDeletePoint;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.CheckBox chbRouteEnabled;
        private System.Windows.Forms.Button btnSavePoint;
        private System.Windows.Forms.ImageList il3State;
        private System.Windows.Forms.Button btnSaveRoutes;
    }
}