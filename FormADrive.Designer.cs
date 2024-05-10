namespace SHME
{
    partial class FormADrive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormADrive));
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Узел0");
            this.btnManagerFileReload = new System.Windows.Forms.Button();
            this.btnManagerFileLoad = new System.Windows.Forms.Button();
            this.tbManagerFile = new System.Windows.Forms.TextBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.btnRouteInfoSave = new System.Windows.Forms.Button();
            this.tbRouteName = new System.Windows.Forms.TextBox();
            this.tvRoutes = new System.Windows.Forms.TreeView();
            this.tcADrive = new System.Windows.Forms.TabControl();
            this.tpWaypoints = new System.Windows.Forms.TabPage();
            this.btnRouteClear = new System.Windows.Forms.Button();
            this.gbLimit = new System.Windows.Forms.GroupBox();
            this.nudPositionOffset = new System.Windows.Forms.NumericUpDown();
            this.cbLimitZ = new System.Windows.Forms.CheckBox();
            this.btnPositionAlign = new System.Windows.Forms.Button();
            this.nudPositionStep = new System.Windows.Forms.NumericUpDown();
            this.cbLimitY = new System.Windows.Forms.CheckBox();
            this.cbLimitX = new System.Windows.Forms.CheckBox();
            this.nudLimitZMin = new System.Windows.Forms.NumericUpDown();
            this.nudLimitZMax = new System.Windows.Forms.NumericUpDown();
            this.nudLimitYMin = new System.Windows.Forms.NumericUpDown();
            this.nudLimitYMax = new System.Windows.Forms.NumericUpDown();
            this.nudLimitXMin = new System.Windows.Forms.NumericUpDown();
            this.nudLimitXMax = new System.Windows.Forms.NumericUpDown();
            this.gbWaypoint = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbLnk = new System.Windows.Forms.GroupBox();
            this.tvLinks = new System.Windows.Forms.TreeView();
            this.ilLinkDirection = new System.Windows.Forms.ImageList(this.components);
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnLinkInsert = new System.Windows.Forms.Button();
            this.cbbLinkPoint = new System.Windows.Forms.ComboBox();
            this.btnLinkSave = new System.Windows.Forms.Button();
            this.btnLinkDelete = new System.Windows.Forms.Button();
            this.btnWaypointInsert = new System.Windows.Forms.Button();
            this.chbFlag = new System.Windows.Forms.CheckBox();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.nudZ = new System.Windows.Forms.NumericUpDown();
            this.btnPointSave = new System.Windows.Forms.Button();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.btnWaypointDelete = new System.Windows.Forms.Button();
            this.btnRouteReload = new System.Windows.Forms.Button();
            this.btnRouteSave = new System.Windows.Forms.Button();
            this.clbWaypoints = new System.Windows.Forms.CheckedListBox();
            this.tpMarkers = new System.Windows.Forms.TabPage();
            this.gbGroup = new System.Windows.Forms.GroupBox();
            this.btnSaveGroup = new System.Windows.Forms.Button();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.lblGroupID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.clbGroups = new System.Windows.Forms.CheckedListBox();
            this.clbMarkers = new System.Windows.Forms.CheckedListBox();
            this.gbMarker = new System.Windows.Forms.GroupBox();
            this.btnSaveMarker = new System.Windows.Forms.Button();
            this.btnDeleteMarker = new System.Windows.Forms.Button();
            this.cbbMarkerPoint = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbMarkerGroup = new System.Windows.Forms.ComboBox();
            this.tbMarkerName = new System.Windows.Forms.TextBox();
            this.btnManagerFileSave = new System.Windows.Forms.Button();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMain.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.tcADrive.SuspendLayout();
            this.tpWaypoints.SuspendLayout();
            this.gbLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitZMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitZMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitYMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitYMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitXMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitXMax)).BeginInit();
            this.gbWaypoint.SuspendLayout();
            this.gbLnk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            this.tpMarkers.SuspendLayout();
            this.gbGroup.SuspendLayout();
            this.gbMarker.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnManagerFileReload
            // 
            this.btnManagerFileReload.BackgroundImage = global::SHME.Properties.Resources.reload;
            this.btnManagerFileReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnManagerFileReload.FlatAppearance.BorderSize = 0;
            this.btnManagerFileReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagerFileReload.Location = new System.Drawing.Point(38, 12);
            this.btnManagerFileReload.Name = "btnManagerFileReload";
            this.btnManagerFileReload.Size = new System.Drawing.Size(20, 20);
            this.btnManagerFileReload.TabIndex = 32;
            this.btnManagerFileReload.UseVisualStyleBackColor = true;
            this.btnManagerFileReload.Click += new System.EventHandler(this.btnManagerReload_Click);
            // 
            // btnManagerFileLoad
            // 
            this.btnManagerFileLoad.BackgroundImage = global::SHME.Properties.Resources.load;
            this.btnManagerFileLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnManagerFileLoad.FlatAppearance.BorderSize = 0;
            this.btnManagerFileLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagerFileLoad.Location = new System.Drawing.Point(12, 12);
            this.btnManagerFileLoad.Name = "btnManagerFileLoad";
            this.btnManagerFileLoad.Size = new System.Drawing.Size(20, 20);
            this.btnManagerFileLoad.TabIndex = 30;
            this.btnManagerFileLoad.UseVisualStyleBackColor = true;
            this.btnManagerFileLoad.Click += new System.EventHandler(this.btnManagerLoad_Click);
            // 
            // tbManagerFile
            // 
            this.tbManagerFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbManagerFile.Location = new System.Drawing.Point(64, 12);
            this.tbManagerFile.Name = "tbManagerFile";
            this.tbManagerFile.Size = new System.Drawing.Size(582, 20);
            this.tbManagerFile.TabIndex = 31;
            this.toolTip.SetToolTip(this.tbManagerFile, "Path to manager file");
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Controls.Add(this.pnlFilters);
            this.pnlMain.Controls.Add(this.tcADrive);
            this.pnlMain.Location = new System.Drawing.Point(6, 38);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(673, 318);
            this.pnlMain.TabIndex = 33;
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.btnRouteInfoSave);
            this.pnlFilters.Controls.Add(this.tbRouteName);
            this.pnlFilters.Controls.Add(this.tvRoutes);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.pnlFilters.Size = new System.Drawing.Size(288, 318);
            this.pnlFilters.TabIndex = 15;
            // 
            // btnRouteInfoSave
            // 
            this.btnRouteInfoSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRouteInfoSave.BackgroundImage = global::SHME.Properties.Resources.toolPencil;
            this.btnRouteInfoSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRouteInfoSave.FlatAppearance.BorderSize = 0;
            this.btnRouteInfoSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRouteInfoSave.Location = new System.Drawing.Point(258, 3);
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
            this.tbRouteName.Location = new System.Drawing.Point(0, 3);
            this.tbRouteName.Name = "tbRouteName";
            this.tbRouteName.Size = new System.Drawing.Size(252, 20);
            this.tbRouteName.TabIndex = 17;
            this.tbRouteName.TextChanged += new System.EventHandler(this.RouteInfo_ValueChanged);
            this.tbRouteName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRouteName_KeyPress);
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
            this.tvRoutes.Location = new System.Drawing.Point(0, 29);
            this.tvRoutes.Name = "tvRoutes";
            this.tvRoutes.ShowLines = false;
            this.tvRoutes.ShowPlusMinus = false;
            this.tvRoutes.ShowRootLines = false;
            this.tvRoutes.Size = new System.Drawing.Size(284, 289);
            this.tvRoutes.TabIndex = 16;
            this.tvRoutes.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvRoutes_AfterLabelEdit);
            this.tvRoutes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRoutes_AfterSelect);
            // 
            // tcADrive
            // 
            this.tcADrive.Controls.Add(this.tpWaypoints);
            this.tcADrive.Controls.Add(this.tpMarkers);
            this.tcADrive.Dock = System.Windows.Forms.DockStyle.Right;
            this.tcADrive.Location = new System.Drawing.Point(288, 0);
            this.tcADrive.Margin = new System.Windows.Forms.Padding(0);
            this.tcADrive.Name = "tcADrive";
            this.tcADrive.SelectedIndex = 0;
            this.tcADrive.Size = new System.Drawing.Size(385, 318);
            this.tcADrive.TabIndex = 34;
            // 
            // tpWaypoints
            // 
            this.tpWaypoints.Controls.Add(this.btnRouteClear);
            this.tpWaypoints.Controls.Add(this.gbLimit);
            this.tpWaypoints.Controls.Add(this.gbWaypoint);
            this.tpWaypoints.Controls.Add(this.btnRouteReload);
            this.tpWaypoints.Controls.Add(this.btnRouteSave);
            this.tpWaypoints.Controls.Add(this.clbWaypoints);
            this.tpWaypoints.Location = new System.Drawing.Point(4, 22);
            this.tpWaypoints.Name = "tpWaypoints";
            this.tpWaypoints.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tpWaypoints.Size = new System.Drawing.Size(377, 292);
            this.tpWaypoints.TabIndex = 0;
            this.tpWaypoints.Text = "Waypoints";
            this.tpWaypoints.UseVisualStyleBackColor = true;
            // 
            // btnRouteClear
            // 
            this.btnRouteClear.AutoEllipsis = true;
            this.btnRouteClear.BackgroundImage = global::SHME.Properties.Resources.deleteAll;
            this.btnRouteClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRouteClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRouteClear.Location = new System.Drawing.Point(141, 130);
            this.btnRouteClear.Name = "btnRouteClear";
            this.btnRouteClear.Size = new System.Drawing.Size(20, 20);
            this.btnRouteClear.TabIndex = 33;
            this.toolTip.SetToolTip(this.btnRouteClear, "Delete selected");
            this.btnRouteClear.UseVisualStyleBackColor = true;
            this.btnRouteClear.Visible = false;
            // 
            // gbLimit
            // 
            this.gbLimit.Controls.Add(this.nudPositionOffset);
            this.gbLimit.Controls.Add(this.cbLimitZ);
            this.gbLimit.Controls.Add(this.btnPositionAlign);
            this.gbLimit.Controls.Add(this.nudPositionStep);
            this.gbLimit.Controls.Add(this.cbLimitY);
            this.gbLimit.Controls.Add(this.cbLimitX);
            this.gbLimit.Controls.Add(this.nudLimitZMin);
            this.gbLimit.Controls.Add(this.nudLimitZMax);
            this.gbLimit.Controls.Add(this.nudLimitYMin);
            this.gbLimit.Controls.Add(this.nudLimitYMax);
            this.gbLimit.Controls.Add(this.nudLimitXMin);
            this.gbLimit.Controls.Add(this.nudLimitXMax);
            this.gbLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbLimit.Location = new System.Drawing.Point(6, 3);
            this.gbLimit.Name = "gbLimit";
            this.gbLimit.Size = new System.Drawing.Size(174, 124);
            this.gbLimit.TabIndex = 23;
            this.gbLimit.TabStop = false;
            this.gbLimit.Text = "Limit / Align";
            // 
            // nudPositionOffset
            // 
            this.nudPositionOffset.DecimalPlaces = 2;
            this.nudPositionOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudPositionOffset.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudPositionOffset.Location = new System.Drawing.Point(103, 97);
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
            this.nudPositionOffset.Size = new System.Drawing.Size(65, 20);
            this.nudPositionOffset.TabIndex = 10;
            this.nudPositionOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.nudPositionOffset, "Position step offset");
            // 
            // cbLimitZ
            // 
            this.cbLimitZ.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbLimitZ.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbLimitZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbLimitZ.Location = new System.Drawing.Point(77, 71);
            this.cbLimitZ.Name = "cbLimitZ";
            this.cbLimitZ.Size = new System.Drawing.Size(20, 20);
            this.cbLimitZ.TabIndex = 33;
            this.cbLimitZ.Text = "Z";
            this.cbLimitZ.UseVisualStyleBackColor = true;
            this.cbLimitZ.Click += new System.EventHandler(this.Limit_ValueChanged);
            // 
            // btnPositionAlign
            // 
            this.btnPositionAlign.FlatAppearance.BorderSize = 0;
            this.btnPositionAlign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPositionAlign.Image = ((System.Drawing.Image)(resources.GetObject("btnPositionAlign.Image")));
            this.btnPositionAlign.Location = new System.Drawing.Point(77, 97);
            this.btnPositionAlign.Name = "btnPositionAlign";
            this.btnPositionAlign.Size = new System.Drawing.Size(20, 20);
            this.btnPositionAlign.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnPositionAlign, "Align position. Only X, Z axis");
            this.btnPositionAlign.UseVisualStyleBackColor = true;
            // 
            // nudPositionStep
            // 
            this.nudPositionStep.DecimalPlaces = 2;
            this.nudPositionStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudPositionStep.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudPositionStep.Location = new System.Drawing.Point(6, 97);
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
            this.nudPositionStep.Size = new System.Drawing.Size(65, 20);
            this.nudPositionStep.TabIndex = 10;
            this.nudPositionStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.nudPositionStep, "Position increment step");
            this.nudPositionStep.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            // 
            // cbLimitY
            // 
            this.cbLimitY.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbLimitY.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbLimitY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbLimitY.Location = new System.Drawing.Point(77, 45);
            this.cbLimitY.Name = "cbLimitY";
            this.cbLimitY.Size = new System.Drawing.Size(20, 20);
            this.cbLimitY.TabIndex = 32;
            this.cbLimitY.Text = "Y";
            this.cbLimitY.UseVisualStyleBackColor = true;
            this.cbLimitY.Click += new System.EventHandler(this.Limit_ValueChanged);
            // 
            // cbLimitX
            // 
            this.cbLimitX.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbLimitX.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbLimitX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbLimitX.Location = new System.Drawing.Point(77, 19);
            this.cbLimitX.Name = "cbLimitX";
            this.cbLimitX.Size = new System.Drawing.Size(20, 20);
            this.cbLimitX.TabIndex = 14;
            this.cbLimitX.Text = "X";
            this.cbLimitX.UseVisualStyleBackColor = true;
            this.cbLimitX.Click += new System.EventHandler(this.Limit_ValueChanged);
            // 
            // nudLimitZMin
            // 
            this.nudLimitZMin.DecimalPlaces = 2;
            this.nudLimitZMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudLimitZMin.Location = new System.Drawing.Point(6, 71);
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
            this.nudLimitZMin.Size = new System.Drawing.Size(65, 20);
            this.nudLimitZMin.TabIndex = 12;
            this.nudLimitZMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitZMin.Value = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudLimitZMin.ValueChanged += new System.EventHandler(this.Limit_ValueChanged);
            // 
            // nudLimitZMax
            // 
            this.nudLimitZMax.DecimalPlaces = 2;
            this.nudLimitZMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudLimitZMax.Location = new System.Drawing.Point(103, 71);
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
            this.nudLimitZMax.Size = new System.Drawing.Size(65, 20);
            this.nudLimitZMax.TabIndex = 12;
            this.nudLimitZMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitZMax.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudLimitZMax.ValueChanged += new System.EventHandler(this.Limit_ValueChanged);
            // 
            // nudLimitYMin
            // 
            this.nudLimitYMin.DecimalPlaces = 2;
            this.nudLimitYMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudLimitYMin.Location = new System.Drawing.Point(6, 45);
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
            this.nudLimitYMin.Size = new System.Drawing.Size(65, 20);
            this.nudLimitYMin.TabIndex = 11;
            this.nudLimitYMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitYMin.Value = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudLimitYMin.ValueChanged += new System.EventHandler(this.Limit_ValueChanged);
            // 
            // nudLimitYMax
            // 
            this.nudLimitYMax.DecimalPlaces = 2;
            this.nudLimitYMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudLimitYMax.Location = new System.Drawing.Point(103, 45);
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
            this.nudLimitYMax.Size = new System.Drawing.Size(65, 20);
            this.nudLimitYMax.TabIndex = 11;
            this.nudLimitYMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitYMax.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudLimitYMax.ValueChanged += new System.EventHandler(this.Limit_ValueChanged);
            // 
            // nudLimitXMin
            // 
            this.nudLimitXMin.DecimalPlaces = 2;
            this.nudLimitXMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudLimitXMin.Location = new System.Drawing.Point(6, 19);
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
            this.nudLimitXMin.Size = new System.Drawing.Size(65, 20);
            this.nudLimitXMin.TabIndex = 10;
            this.nudLimitXMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitXMin.Value = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudLimitXMin.ValueChanged += new System.EventHandler(this.Limit_ValueChanged);
            // 
            // nudLimitXMax
            // 
            this.nudLimitXMax.DecimalPlaces = 2;
            this.nudLimitXMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudLimitXMax.Location = new System.Drawing.Point(103, 19);
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
            this.nudLimitXMax.Size = new System.Drawing.Size(65, 20);
            this.nudLimitXMax.TabIndex = 10;
            this.nudLimitXMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitXMax.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudLimitXMax.ValueChanged += new System.EventHandler(this.Limit_ValueChanged);
            // 
            // gbWaypoint
            // 
            this.gbWaypoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbWaypoint.Controls.Add(this.label4);
            this.gbWaypoint.Controls.Add(this.gbLnk);
            this.gbWaypoint.Controls.Add(this.btnWaypointInsert);
            this.gbWaypoint.Controls.Add(this.chbFlag);
            this.gbWaypoint.Controls.Add(this.nudX);
            this.gbWaypoint.Controls.Add(this.nudZ);
            this.gbWaypoint.Controls.Add(this.btnPointSave);
            this.gbWaypoint.Controls.Add(this.nudY);
            this.gbWaypoint.Controls.Add(this.btnWaypointDelete);
            this.gbWaypoint.Enabled = false;
            this.gbWaypoint.Location = new System.Drawing.Point(186, 3);
            this.gbWaypoint.Margin = new System.Windows.Forms.Padding(0);
            this.gbWaypoint.Name = "gbWaypoint";
            this.gbWaypoint.Size = new System.Drawing.Size(185, 289);
            this.gbWaypoint.TabIndex = 31;
            this.gbWaypoint.TabStop = false;
            this.gbWaypoint.Text = "Waypoint";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(72, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 52;
            this.label4.Text = "Y";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbLnk
            // 
            this.gbLnk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLnk.Controls.Add(this.tvLinks);
            this.gbLnk.Controls.Add(this.checkBox2);
            this.gbLnk.Controls.Add(this.checkBox1);
            this.gbLnk.Controls.Add(this.btnLinkInsert);
            this.gbLnk.Controls.Add(this.cbbLinkPoint);
            this.gbLnk.Controls.Add(this.btnLinkSave);
            this.gbLnk.Controls.Add(this.btnLinkDelete);
            this.gbLnk.Location = new System.Drawing.Point(0, 71);
            this.gbLnk.Name = "gbLnk";
            this.gbLnk.Size = new System.Drawing.Size(185, 219);
            this.gbLnk.TabIndex = 34;
            this.gbLnk.TabStop = false;
            this.gbLnk.Text = "Links";
            // 
            // tvLinks
            // 
            this.tvLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvLinks.FullRowSelect = true;
            this.tvLinks.Location = new System.Drawing.Point(8, 72);
            this.tvLinks.Name = "tvLinks";
            treeNode2.Name = "Узел0";
            treeNode2.StateImageIndex = 3;
            treeNode2.Text = "Узел0";
            this.tvLinks.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvLinks.ShowLines = false;
            this.tvLinks.ShowPlusMinus = false;
            this.tvLinks.ShowRootLines = false;
            this.tvLinks.Size = new System.Drawing.Size(171, 141);
            this.tvLinks.StateImageList = this.ilLinkDirection;
            this.tvLinks.TabIndex = 53;
            this.tvLinks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvLinks_AfterSelect);
            // 
            // ilLinkDirection
            // 
            this.ilLinkDirection.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilLinkDirection.ImageStream")));
            this.ilLinkDirection.TransparentColor = System.Drawing.Color.Transparent;
            this.ilLinkDirection.Images.SetKeyName(0, "bulletEmpty.png");
            this.ilLinkDirection.Images.SetKeyName(1, "directionLeft.png");
            this.ilLinkDirection.Images.SetKeyName(2, "directionRight.png");
            this.ilLinkDirection.Images.SetKeyName(3, "directionBoth.png");
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(41, 46);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(27, 20);
            this.checkBox2.TabIndex = 52;
            this.checkBox2.Text = ">";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.cbbWaypointLink_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(8, 46);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(27, 20);
            this.checkBox1.TabIndex = 51;
            this.checkBox1.Text = "<";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.cbbWaypointLink_SelectedIndexChanged);
            // 
            // btnLinkInsert
            // 
            this.btnLinkInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkInsert.BackgroundImage = global::SHME.Properties.Resources.add;
            this.btnLinkInsert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLinkInsert.FlatAppearance.BorderSize = 0;
            this.btnLinkInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLinkInsert.Location = new System.Drawing.Point(107, 46);
            this.btnLinkInsert.Name = "btnLinkInsert";
            this.btnLinkInsert.Size = new System.Drawing.Size(20, 20);
            this.btnLinkInsert.TabIndex = 50;
            this.btnLinkInsert.UseVisualStyleBackColor = true;
            this.btnLinkInsert.Click += new System.EventHandler(this.btnLinkInsert_Click);
            // 
            // cbbLinkPoint
            // 
            this.cbbLinkPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbLinkPoint.FormattingEnabled = true;
            this.cbbLinkPoint.Location = new System.Drawing.Point(8, 19);
            this.cbbLinkPoint.Name = "cbbLinkPoint";
            this.cbbLinkPoint.Size = new System.Drawing.Size(171, 21);
            this.cbbLinkPoint.TabIndex = 49;
            this.cbbLinkPoint.SelectedIndexChanged += new System.EventHandler(this.cbbWaypointLink_SelectedIndexChanged);
            // 
            // btnLinkSave
            // 
            this.btnLinkSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkSave.BackgroundImage = global::SHME.Properties.Resources.toolPencil;
            this.btnLinkSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLinkSave.FlatAppearance.BorderSize = 0;
            this.btnLinkSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLinkSave.Location = new System.Drawing.Point(133, 46);
            this.btnLinkSave.Name = "btnLinkSave";
            this.btnLinkSave.Size = new System.Drawing.Size(20, 20);
            this.btnLinkSave.TabIndex = 34;
            this.btnLinkSave.UseVisualStyleBackColor = true;
            this.btnLinkSave.Visible = false;
            this.btnLinkSave.Click += new System.EventHandler(this.btnLinkSave_Click);
            // 
            // btnLinkDelete
            // 
            this.btnLinkDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkDelete.BackgroundImage = global::SHME.Properties.Resources.delete;
            this.btnLinkDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLinkDelete.FlatAppearance.BorderSize = 0;
            this.btnLinkDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLinkDelete.Location = new System.Drawing.Point(159, 46);
            this.btnLinkDelete.Name = "btnLinkDelete";
            this.btnLinkDelete.Size = new System.Drawing.Size(20, 20);
            this.btnLinkDelete.TabIndex = 32;
            this.btnLinkDelete.UseVisualStyleBackColor = true;
            this.btnLinkDelete.Click += new System.EventHandler(this.btnLinkDelete_Click);
            // 
            // btnWaypointInsert
            // 
            this.btnWaypointInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWaypointInsert.BackgroundImage = global::SHME.Properties.Resources.add;
            this.btnWaypointInsert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnWaypointInsert.FlatAppearance.BorderSize = 0;
            this.btnWaypointInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaypointInsert.Location = new System.Drawing.Point(107, 45);
            this.btnWaypointInsert.Name = "btnWaypointInsert";
            this.btnWaypointInsert.Size = new System.Drawing.Size(20, 20);
            this.btnWaypointInsert.TabIndex = 51;
            this.btnWaypointInsert.UseVisualStyleBackColor = true;
            this.btnWaypointInsert.Click += new System.EventHandler(this.btnWaypointInsert_Click);
            // 
            // chbFlag
            // 
            this.chbFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbFlag.Location = new System.Drawing.Point(71, 19);
            this.chbFlag.Name = "chbFlag";
            this.chbFlag.Size = new System.Drawing.Size(46, 20);
            this.chbFlag.TabIndex = 44;
            this.chbFlag.Text = "X       Z";
            this.chbFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbFlag.UseVisualStyleBackColor = true;
            this.chbFlag.CheckedChanged += new System.EventHandler(this.WaypointInfo_Changed);
            // 
            // nudX
            // 
            this.nudX.DecimalPlaces = 2;
            this.nudX.Location = new System.Drawing.Point(6, 19);
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
            this.nudX.Size = new System.Drawing.Size(65, 20);
            this.nudX.TabIndex = 34;
            this.nudX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudX.Value = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudX.ValueChanged += new System.EventHandler(this.WaypointInfo_Changed);
            // 
            // nudZ
            // 
            this.nudZ.DecimalPlaces = 2;
            this.nudZ.Location = new System.Drawing.Point(6, 45);
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
            this.nudZ.Size = new System.Drawing.Size(65, 20);
            this.nudZ.TabIndex = 36;
            this.nudZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudZ.Value = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudZ.ValueChanged += new System.EventHandler(this.WaypointInfo_Changed);
            // 
            // btnPointSave
            // 
            this.btnPointSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPointSave.BackgroundImage = global::SHME.Properties.Resources.toolPencil;
            this.btnPointSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPointSave.FlatAppearance.BorderSize = 0;
            this.btnPointSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPointSave.Location = new System.Drawing.Point(133, 45);
            this.btnPointSave.Name = "btnPointSave";
            this.btnPointSave.Size = new System.Drawing.Size(20, 20);
            this.btnPointSave.TabIndex = 33;
            this.btnPointSave.UseVisualStyleBackColor = true;
            this.btnPointSave.Visible = false;
            this.btnPointSave.Click += new System.EventHandler(this.btnWaypointSave_Click);
            // 
            // nudY
            // 
            this.nudY.DecimalPlaces = 2;
            this.nudY.Location = new System.Drawing.Point(117, 19);
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
            this.nudY.Size = new System.Drawing.Size(65, 20);
            this.nudY.TabIndex = 35;
            this.nudY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudY.Value = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.nudY.ValueChanged += new System.EventHandler(this.WaypointInfo_Changed);
            // 
            // btnWaypointDelete
            // 
            this.btnWaypointDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWaypointDelete.BackgroundImage = global::SHME.Properties.Resources.delete;
            this.btnWaypointDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnWaypointDelete.FlatAppearance.BorderSize = 0;
            this.btnWaypointDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaypointDelete.Location = new System.Drawing.Point(159, 45);
            this.btnWaypointDelete.Name = "btnWaypointDelete";
            this.btnWaypointDelete.Size = new System.Drawing.Size(20, 20);
            this.btnWaypointDelete.TabIndex = 31;
            this.btnWaypointDelete.UseVisualStyleBackColor = true;
            this.btnWaypointDelete.Click += new System.EventHandler(this.btnWaypointDelete_Click);
            // 
            // btnRouteReload
            // 
            this.btnRouteReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRouteReload.AutoEllipsis = true;
            this.btnRouteReload.BackgroundImage = global::SHME.Properties.Resources.reload;
            this.btnRouteReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRouteReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRouteReload.Location = new System.Drawing.Point(141, 253);
            this.btnRouteReload.Name = "btnRouteReload";
            this.btnRouteReload.Size = new System.Drawing.Size(20, 20);
            this.btnRouteReload.TabIndex = 24;
            this.btnRouteReload.UseVisualStyleBackColor = true;
            this.btnRouteReload.Visible = false;
            this.btnRouteReload.Click += new System.EventHandler(this.btnRouteReload_Click);
            // 
            // btnRouteSave
            // 
            this.btnRouteSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRouteSave.BackgroundImage = global::SHME.Properties.Resources.save;
            this.btnRouteSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRouteSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRouteSave.Location = new System.Drawing.Point(160, 272);
            this.btnRouteSave.Name = "btnRouteSave";
            this.btnRouteSave.Size = new System.Drawing.Size(20, 20);
            this.btnRouteSave.TabIndex = 28;
            this.btnRouteSave.UseVisualStyleBackColor = true;
            this.btnRouteSave.Visible = false;
            this.btnRouteSave.Click += new System.EventHandler(this.btnSaveRoute_Click);
            // 
            // clbWaypoints
            // 
            this.clbWaypoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clbWaypoints.HorizontalScrollbar = true;
            this.clbWaypoints.IntegralHeight = false;
            this.clbWaypoints.Location = new System.Drawing.Point(6, 130);
            this.clbWaypoints.Margin = new System.Windows.Forms.Padding(0);
            this.clbWaypoints.Name = "clbWaypoints";
            this.clbWaypoints.ScrollAlwaysVisible = true;
            this.clbWaypoints.Size = new System.Drawing.Size(174, 162);
            this.clbWaypoints.TabIndex = 32;
            // 
            // tpMarkers
            // 
            this.tpMarkers.Controls.Add(this.gbGroup);
            this.tpMarkers.Controls.Add(this.clbGroups);
            this.tpMarkers.Controls.Add(this.clbMarkers);
            this.tpMarkers.Controls.Add(this.gbMarker);
            this.tpMarkers.Location = new System.Drawing.Point(4, 22);
            this.tpMarkers.Name = "tpMarkers";
            this.tpMarkers.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tpMarkers.Size = new System.Drawing.Size(377, 292);
            this.tpMarkers.TabIndex = 1;
            this.tpMarkers.Text = "Markers / Groups";
            this.tpMarkers.UseVisualStyleBackColor = true;
            // 
            // gbGroup
            // 
            this.gbGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbGroup.Controls.Add(this.btnSaveGroup);
            this.gbGroup.Controls.Add(this.btnDeleteGroup);
            this.gbGroup.Controls.Add(this.lblGroupID);
            this.gbGroup.Controls.Add(this.label5);
            this.gbGroup.Controls.Add(this.label9);
            this.gbGroup.Controls.Add(this.tbGroupName);
            this.gbGroup.Enabled = false;
            this.gbGroup.Location = new System.Drawing.Point(189, 6);
            this.gbGroup.Name = "gbGroup";
            this.gbGroup.Size = new System.Drawing.Size(185, 75);
            this.gbGroup.TabIndex = 55;
            this.gbGroup.TabStop = false;
            this.gbGroup.Text = "Group";
            // 
            // btnSaveGroup
            // 
            this.btnSaveGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveGroup.BackgroundImage = global::SHME.Properties.Resources.toolPencil;
            this.btnSaveGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSaveGroup.FlatAppearance.BorderSize = 0;
            this.btnSaveGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveGroup.Location = new System.Drawing.Point(125, 45);
            this.btnSaveGroup.Name = "btnSaveGroup";
            this.btnSaveGroup.Size = new System.Drawing.Size(24, 24);
            this.btnSaveGroup.TabIndex = 51;
            this.btnSaveGroup.UseVisualStyleBackColor = true;
            this.btnSaveGroup.Visible = false;
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteGroup.BackgroundImage = global::SHME.Properties.Resources.delete;
            this.btnDeleteGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeleteGroup.FlatAppearance.BorderSize = 0;
            this.btnDeleteGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteGroup.Location = new System.Drawing.Point(155, 45);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteGroup.TabIndex = 50;
            this.btnDeleteGroup.UseVisualStyleBackColor = true;
            // 
            // lblGroupID
            // 
            this.lblGroupID.Location = new System.Drawing.Point(52, 43);
            this.lblGroupID.Name = "lblGroupID";
            this.lblGroupID.Size = new System.Drawing.Size(80, 20);
            this.lblGroupID.TabIndex = 49;
            this.lblGroupID.Text = "-";
            this.lblGroupID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 48;
            this.label5.Text = "#";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 20);
            this.label9.TabIndex = 46;
            this.label9.Text = "Name";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbGroupName
            // 
            this.tbGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGroupName.Location = new System.Drawing.Point(56, 19);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(123, 20);
            this.tbGroupName.TabIndex = 43;
            // 
            // clbGroups
            // 
            this.clbGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clbGroups.HorizontalScrollbar = true;
            this.clbGroups.IntegralHeight = false;
            this.clbGroups.Location = new System.Drawing.Point(189, 84);
            this.clbGroups.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.clbGroups.Name = "clbGroups";
            this.clbGroups.ScrollAlwaysVisible = true;
            this.clbGroups.Size = new System.Drawing.Size(188, 208);
            this.clbGroups.TabIndex = 54;
            // 
            // clbMarkers
            // 
            this.clbMarkers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clbMarkers.HorizontalScrollbar = true;
            this.clbMarkers.IntegralHeight = false;
            this.clbMarkers.Location = new System.Drawing.Point(3, 138);
            this.clbMarkers.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.clbMarkers.Name = "clbMarkers";
            this.clbMarkers.ScrollAlwaysVisible = true;
            this.clbMarkers.Size = new System.Drawing.Size(180, 154);
            this.clbMarkers.TabIndex = 49;
            // 
            // gbMarker
            // 
            this.gbMarker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbMarker.Controls.Add(this.btnSaveMarker);
            this.gbMarker.Controls.Add(this.btnDeleteMarker);
            this.gbMarker.Controls.Add(this.cbbMarkerPoint);
            this.gbMarker.Controls.Add(this.label3);
            this.gbMarker.Controls.Add(this.label2);
            this.gbMarker.Controls.Add(this.label1);
            this.gbMarker.Controls.Add(this.cbbMarkerGroup);
            this.gbMarker.Controls.Add(this.tbMarkerName);
            this.gbMarker.Enabled = false;
            this.gbMarker.Location = new System.Drawing.Point(3, 6);
            this.gbMarker.Name = "gbMarker";
            this.gbMarker.Size = new System.Drawing.Size(180, 129);
            this.gbMarker.TabIndex = 50;
            this.gbMarker.TabStop = false;
            this.gbMarker.Text = "Marker";
            // 
            // btnSaveMarker
            // 
            this.btnSaveMarker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMarker.BackgroundImage = global::SHME.Properties.Resources.toolPencil;
            this.btnSaveMarker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSaveMarker.FlatAppearance.BorderSize = 0;
            this.btnSaveMarker.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveMarker.Location = new System.Drawing.Point(123, 99);
            this.btnSaveMarker.Name = "btnSaveMarker";
            this.btnSaveMarker.Size = new System.Drawing.Size(24, 24);
            this.btnSaveMarker.TabIndex = 51;
            this.btnSaveMarker.UseVisualStyleBackColor = true;
            this.btnSaveMarker.Visible = false;
            // 
            // btnDeleteMarker
            // 
            this.btnDeleteMarker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteMarker.BackgroundImage = global::SHME.Properties.Resources.delete;
            this.btnDeleteMarker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeleteMarker.FlatAppearance.BorderSize = 0;
            this.btnDeleteMarker.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteMarker.Location = new System.Drawing.Point(153, 99);
            this.btnDeleteMarker.Name = "btnDeleteMarker";
            this.btnDeleteMarker.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteMarker.TabIndex = 50;
            this.btnDeleteMarker.UseVisualStyleBackColor = true;
            // 
            // cbbMarkerPoint
            // 
            this.cbbMarkerPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbMarkerPoint.FormattingEnabled = true;
            this.cbbMarkerPoint.Location = new System.Drawing.Point(56, 45);
            this.cbbMarkerPoint.Name = "cbbMarkerPoint";
            this.cbbMarkerPoint.Size = new System.Drawing.Size(118, 21);
            this.cbbMarkerPoint.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 47;
            this.label3.Text = "Point #";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 46;
            this.label2.Text = "Group";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbbMarkerGroup
            // 
            this.cbbMarkerGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbMarkerGroup.FormattingEnabled = true;
            this.cbbMarkerGroup.Location = new System.Drawing.Point(56, 72);
            this.cbbMarkerGroup.Name = "cbbMarkerGroup";
            this.cbbMarkerGroup.Size = new System.Drawing.Size(118, 21);
            this.cbbMarkerGroup.TabIndex = 45;
            // 
            // tbMarkerName
            // 
            this.tbMarkerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMarkerName.Location = new System.Drawing.Point(56, 19);
            this.tbMarkerName.Name = "tbMarkerName";
            this.tbMarkerName.Size = new System.Drawing.Size(118, 20);
            this.tbMarkerName.TabIndex = 43;
            // 
            // btnManagerFileSave
            // 
            this.btnManagerFileSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManagerFileSave.BackgroundImage = global::SHME.Properties.Resources.save;
            this.btnManagerFileSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnManagerFileSave.FlatAppearance.BorderSize = 0;
            this.btnManagerFileSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagerFileSave.Location = new System.Drawing.Point(652, 12);
            this.btnManagerFileSave.Name = "btnManagerFileSave";
            this.btnManagerFileSave.Size = new System.Drawing.Size(20, 20);
            this.btnManagerFileSave.TabIndex = 29;
            this.btnManagerFileSave.UseVisualStyleBackColor = true;
            this.btnManagerFileSave.Click += new System.EventHandler(this.btnRoutesSave_Click);
            // 
            // dlgOpen
            // 
            this.dlgOpen.DefaultExt = "xml";
            this.dlgOpen.Filter = "XML|routes.xml";
            // 
            // FormADrive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnManagerFileSave);
            this.Controls.Add(this.btnManagerFileReload);
            this.Controls.Add(this.btnManagerFileLoad);
            this.Controls.Add(this.tbManagerFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 1000);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "FormADrive";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SHME: FS Auto Drive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormADrive_FormClosing);
            this.pnlMain.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.tcADrive.ResumeLayout(false);
            this.tpWaypoints.ResumeLayout(false);
            this.gbLimit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitZMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitZMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitYMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitYMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitXMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitXMax)).EndInit();
            this.gbWaypoint.ResumeLayout(false);
            this.gbLnk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            this.tpMarkers.ResumeLayout(false);
            this.gbGroup.ResumeLayout(false);
            this.gbGroup.PerformLayout();
            this.gbMarker.ResumeLayout(false);
            this.gbMarker.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnManagerFileReload;
        private System.Windows.Forms.Button btnManagerFileLoad;
        private System.Windows.Forms.TextBox tbManagerFile;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Button btnRouteInfoSave;
        private System.Windows.Forms.TextBox tbRouteName;
        private System.Windows.Forms.TreeView tvRoutes;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnManagerFileSave;
        private System.Windows.Forms.ImageList ilLinkDirection;
        private System.Windows.Forms.TabControl tcADrive;
        private System.Windows.Forms.TabPage tpWaypoints;
        private System.Windows.Forms.Button btnRouteClear;
        private System.Windows.Forms.GroupBox gbLimit;
        private System.Windows.Forms.NumericUpDown nudPositionOffset;
        private System.Windows.Forms.CheckBox cbLimitZ;
        private System.Windows.Forms.Button btnPositionAlign;
        private System.Windows.Forms.NumericUpDown nudPositionStep;
        private System.Windows.Forms.CheckBox cbLimitY;
        private System.Windows.Forms.CheckBox cbLimitX;
        private System.Windows.Forms.NumericUpDown nudLimitZMin;
        private System.Windows.Forms.NumericUpDown nudLimitZMax;
        private System.Windows.Forms.NumericUpDown nudLimitYMin;
        private System.Windows.Forms.NumericUpDown nudLimitYMax;
        private System.Windows.Forms.NumericUpDown nudLimitXMin;
        private System.Windows.Forms.NumericUpDown nudLimitXMax;
        private System.Windows.Forms.GroupBox gbWaypoint;
        private System.Windows.Forms.GroupBox gbLnk;
        private System.Windows.Forms.TreeView tvLinks;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnLinkInsert;
        private System.Windows.Forms.ComboBox cbbLinkPoint;
        private System.Windows.Forms.Button btnLinkSave;
        private System.Windows.Forms.Button btnLinkDelete;
        private System.Windows.Forms.Button btnWaypointInsert;
        private System.Windows.Forms.CheckBox chbFlag;
        private System.Windows.Forms.NumericUpDown nudX;
        private System.Windows.Forms.NumericUpDown nudZ;
        private System.Windows.Forms.Button btnPointSave;
        private System.Windows.Forms.NumericUpDown nudY;
        private System.Windows.Forms.Button btnWaypointDelete;
        private System.Windows.Forms.Button btnRouteReload;
        private System.Windows.Forms.Button btnRouteSave;
        private System.Windows.Forms.CheckedListBox clbWaypoints;
        private System.Windows.Forms.TabPage tpMarkers;
        private System.Windows.Forms.GroupBox gbGroup;
        private System.Windows.Forms.Button btnSaveGroup;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.Label lblGroupID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.CheckedListBox clbGroups;
        private System.Windows.Forms.CheckedListBox clbMarkers;
        private System.Windows.Forms.GroupBox gbMarker;
        private System.Windows.Forms.Button btnSaveMarker;
        private System.Windows.Forms.Button btnDeleteMarker;
        private System.Windows.Forms.ComboBox cbbMarkerPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbMarkerGroup;
        private System.Windows.Forms.TextBox tbMarkerName;
        private System.Windows.Forms.Label label4;
    }
}