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
            this.btnFileReload = new System.Windows.Forms.Button();
            this.btnFileLoad = new System.Windows.Forms.Button();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbGroup = new System.Windows.Forms.GroupBox();
            this.btnSaveGroup = new System.Windows.Forms.Button();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.lblGroupID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.btnSaveRoute = new System.Windows.Forms.Button();
            this.btnReloadRoute = new System.Windows.Forms.Button();
            this.gbMarker = new System.Windows.Forms.GroupBox();
            this.btnSaveMarker = new System.Windows.Forms.Button();
            this.btnDeleteMarker = new System.Windows.Forms.Button();
            this.cbbMarkerPoint = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbMarkerGroup = new System.Windows.Forms.ComboBox();
            this.tbMarkerName = new System.Windows.Forms.TextBox();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.gbEdit = new System.Windows.Forms.GroupBox();
            this.btnSavePoint = new System.Windows.Forms.Button();
            this.chbFlag = new System.Windows.Forms.CheckBox();
            this.btnDeletePoint = new System.Windows.Forms.Button();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.nudZ = new System.Windows.Forms.NumericUpDown();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.gbLimit = new System.Windows.Forms.GroupBox();
            this.btnPositionAlign = new System.Windows.Forms.Button();
            this.nudPositionOffset = new System.Windows.Forms.NumericUpDown();
            this.cbLimitZ = new System.Windows.Forms.CheckBox();
            this.nudPositionStep = new System.Windows.Forms.NumericUpDown();
            this.cbLimitY = new System.Windows.Forms.CheckBox();
            this.cbLimitX = new System.Windows.Forms.CheckBox();
            this.nudLimitZMin = new System.Windows.Forms.NumericUpDown();
            this.nudLimitZMax = new System.Windows.Forms.NumericUpDown();
            this.nudLimitYMin = new System.Windows.Forms.NumericUpDown();
            this.nudLimitYMax = new System.Windows.Forms.NumericUpDown();
            this.nudLimitXMin = new System.Windows.Forms.NumericUpDown();
            this.nudLimitXMax = new System.Windows.Forms.NumericUpDown();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.clbGroups = new System.Windows.Forms.CheckedListBox();
            this.clbMarkers = new System.Windows.Forms.CheckedListBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.clbWaypoints = new System.Windows.Forms.CheckedListBox();
            this.splitter = new System.Windows.Forms.Splitter();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.btnSaveRoutes = new System.Windows.Forms.Button();
            this.btnRouteInfoSave = new System.Windows.Forms.Button();
            this.tbRouteName = new System.Windows.Forms.TextBox();
            this.tvRoutes = new System.Windows.Forms.TreeView();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbGroup.SuspendLayout();
            this.gbMarker.SuspendLayout();
            this.pnlItems.SuspendLayout();
            this.gbEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            this.gbLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitZMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitZMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitYMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitYMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitXMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitXMax)).BeginInit();
            this.panel6.SuspendLayout();
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
            this.btnFileReload.Location = new System.Drawing.Point(992, 12);
            this.btnFileReload.Name = "btnFileReload";
            this.btnFileReload.Size = new System.Drawing.Size(20, 20);
            this.btnFileReload.TabIndex = 32;
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
            this.btnFileLoad.TabIndex = 30;
            this.btnFileLoad.UseVisualStyleBackColor = true;
            this.btnFileLoad.Click += new System.EventHandler(this.btnFileLoad_Click);
            // 
            // tbFile
            // 
            this.tbFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFile.Location = new System.Drawing.Point(38, 12);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(948, 20);
            this.tbFile.TabIndex = 31;
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Controls.Add(this.tableLayoutPanel1);
            this.pnlMain.Controls.Add(this.splitter);
            this.pnlMain.Controls.Add(this.pnlFilters);
            this.pnlMain.Location = new System.Drawing.Point(12, 38);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1000, 211);
            this.pnlMain.TabIndex = 33;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 352F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbMarker, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlItems, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.clbGroups, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.clbMarkers, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(232, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(768, 211);
            this.tableLayoutPanel1.TabIndex = 34;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbGroup);
            this.panel1.Controls.Add(this.btnSaveRoute);
            this.panel1.Controls.Add(this.btnReloadRoute);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(563, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 126);
            this.panel1.TabIndex = 34;
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
            this.gbGroup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbGroup.Enabled = false;
            this.gbGroup.Location = new System.Drawing.Point(0, 23);
            this.gbGroup.Name = "gbGroup";
            this.gbGroup.Size = new System.Drawing.Size(202, 103);
            this.gbGroup.TabIndex = 50;
            this.gbGroup.TabStop = false;
            this.gbGroup.Text = "Group";
            // 
            // btnSaveGroup
            // 
            this.btnSaveGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveGroup.BackgroundImage = global::SHME.Properties.Resources.toolPencil;
            this.btnSaveGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSaveGroup.FlatAppearance.BorderSize = 0;
            this.btnSaveGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveGroup.Location = new System.Drawing.Point(142, 76);
            this.btnSaveGroup.Name = "btnSaveGroup";
            this.btnSaveGroup.Size = new System.Drawing.Size(24, 24);
            this.btnSaveGroup.TabIndex = 51;
            this.btnSaveGroup.UseVisualStyleBackColor = true;
            this.btnSaveGroup.Visible = false;
            this.btnSaveGroup.Click += new System.EventHandler(this.btnGroupSave_Click);
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteGroup.BackgroundImage = global::SHME.Properties.Resources.delete;
            this.btnDeleteGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeleteGroup.FlatAppearance.BorderSize = 0;
            this.btnDeleteGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteGroup.Location = new System.Drawing.Point(172, 76);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteGroup.TabIndex = 50;
            this.btnDeleteGroup.UseVisualStyleBackColor = true;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnGroupDelete_Click);
            // 
            // lblGroupID
            // 
            this.lblGroupID.Location = new System.Drawing.Point(56, 43);
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
            this.tbGroupName.Location = new System.Drawing.Point(56, 17);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(140, 20);
            this.tbGroupName.TabIndex = 43;
            this.tbGroupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbGroupName_KeyPress);
            // 
            // btnSaveRoute
            // 
            this.btnSaveRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveRoute.BackgroundImage = global::SHME.Properties.Resources.save;
            this.btnSaveRoute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSaveRoute.FlatAppearance.BorderSize = 0;
            this.btnSaveRoute.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveRoute.Location = new System.Drawing.Point(153, 3);
            this.btnSaveRoute.Name = "btnSaveRoute";
            this.btnSaveRoute.Size = new System.Drawing.Size(20, 20);
            this.btnSaveRoute.TabIndex = 28;
            this.btnSaveRoute.UseVisualStyleBackColor = true;
            this.btnSaveRoute.Visible = false;
            this.btnSaveRoute.Click += new System.EventHandler(this.btnSaveRoute_Click);
            // 
            // btnReloadRoute
            // 
            this.btnReloadRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReloadRoute.AutoEllipsis = true;
            this.btnReloadRoute.BackgroundImage = global::SHME.Properties.Resources.reload;
            this.btnReloadRoute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReloadRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReloadRoute.Location = new System.Drawing.Point(179, 3);
            this.btnReloadRoute.Name = "btnReloadRoute";
            this.btnReloadRoute.Size = new System.Drawing.Size(20, 20);
            this.btnReloadRoute.TabIndex = 24;
            this.btnReloadRoute.UseVisualStyleBackColor = true;
            this.btnReloadRoute.Visible = false;
            this.btnReloadRoute.Click += new System.EventHandler(this.btnReloadRoute_Click);
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
            this.gbMarker.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbMarker.Enabled = false;
            this.gbMarker.Location = new System.Drawing.Point(355, 3);
            this.gbMarker.Name = "gbMarker";
            this.gbMarker.Size = new System.Drawing.Size(202, 124);
            this.gbMarker.TabIndex = 46;
            this.gbMarker.TabStop = false;
            this.gbMarker.Text = "Marker";
            // 
            // btnSaveMarker
            // 
            this.btnSaveMarker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMarker.BackgroundImage = global::SHME.Properties.Resources.toolPencil;
            this.btnSaveMarker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSaveMarker.FlatAppearance.BorderSize = 0;
            this.btnSaveMarker.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveMarker.Location = new System.Drawing.Point(142, 96);
            this.btnSaveMarker.Name = "btnSaveMarker";
            this.btnSaveMarker.Size = new System.Drawing.Size(24, 24);
            this.btnSaveMarker.TabIndex = 51;
            this.btnSaveMarker.UseVisualStyleBackColor = true;
            this.btnSaveMarker.Visible = false;
            this.btnSaveMarker.Click += new System.EventHandler(this.btnMarkerSave_Click);
            // 
            // btnDeleteMarker
            // 
            this.btnDeleteMarker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteMarker.BackgroundImage = global::SHME.Properties.Resources.delete;
            this.btnDeleteMarker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeleteMarker.FlatAppearance.BorderSize = 0;
            this.btnDeleteMarker.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteMarker.Location = new System.Drawing.Point(172, 96);
            this.btnDeleteMarker.Name = "btnDeleteMarker";
            this.btnDeleteMarker.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteMarker.TabIndex = 50;
            this.btnDeleteMarker.UseVisualStyleBackColor = true;
            this.btnDeleteMarker.Click += new System.EventHandler(this.btnMarkerDelete_Click);
            // 
            // cbbMarkerPoint
            // 
            this.cbbMarkerPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbMarkerPoint.FormattingEnabled = true;
            this.cbbMarkerPoint.Location = new System.Drawing.Point(56, 43);
            this.cbbMarkerPoint.Name = "cbbMarkerPoint";
            this.cbbMarkerPoint.Size = new System.Drawing.Size(140, 21);
            this.cbbMarkerPoint.TabIndex = 48;
            this.cbbMarkerPoint.SelectedIndexChanged += new System.EventHandler(this.Marker_ValueChanged);
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
            this.cbbMarkerGroup.Location = new System.Drawing.Point(56, 70);
            this.cbbMarkerGroup.Name = "cbbMarkerGroup";
            this.cbbMarkerGroup.Size = new System.Drawing.Size(140, 21);
            this.cbbMarkerGroup.TabIndex = 45;
            this.cbbMarkerGroup.SelectedIndexChanged += new System.EventHandler(this.Marker_ValueChanged);
            // 
            // tbMarkerName
            // 
            this.tbMarkerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMarkerName.Location = new System.Drawing.Point(56, 17);
            this.tbMarkerName.Name = "tbMarkerName";
            this.tbMarkerName.Size = new System.Drawing.Size(140, 20);
            this.tbMarkerName.TabIndex = 43;
            this.tbMarkerName.TextChanged += new System.EventHandler(this.Marker_ValueChanged);
            this.tbMarkerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMarkerName_KeyPress);
            // 
            // pnlItems
            // 
            this.pnlItems.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlItems.Controls.Add(this.gbEdit);
            this.pnlItems.Controls.Add(this.gbLimit);
            this.pnlItems.Controls.Add(this.lblZ);
            this.pnlItems.Controls.Add(this.lblY);
            this.pnlItems.Controls.Add(this.lblX);
            this.pnlItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItems.Location = new System.Drawing.Point(0, 0);
            this.pnlItems.Margin = new System.Windows.Forms.Padding(0);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(352, 132);
            this.pnlItems.TabIndex = 22;
            // 
            // gbEdit
            // 
            this.gbEdit.Controls.Add(this.btnSavePoint);
            this.gbEdit.Controls.Add(this.chbFlag);
            this.gbEdit.Controls.Add(this.btnDeletePoint);
            this.gbEdit.Controls.Add(this.nudX);
            this.gbEdit.Controls.Add(this.nudZ);
            this.gbEdit.Controls.Add(this.nudY);
            this.gbEdit.Location = new System.Drawing.Point(224, 3);
            this.gbEdit.Margin = new System.Windows.Forms.Padding(0);
            this.gbEdit.Name = "gbEdit";
            this.gbEdit.Size = new System.Drawing.Size(118, 124);
            this.gbEdit.TabIndex = 31;
            this.gbEdit.TabStop = false;
            this.gbEdit.Text = "Point";
            this.gbEdit.Visible = false;
            // 
            // btnSavePoint
            // 
            this.btnSavePoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavePoint.BackgroundImage = global::SHME.Properties.Resources.toolPencil;
            this.btnSavePoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSavePoint.FlatAppearance.BorderSize = 0;
            this.btnSavePoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSavePoint.Location = new System.Drawing.Point(88, 41);
            this.btnSavePoint.Name = "btnSavePoint";
            this.btnSavePoint.Size = new System.Drawing.Size(24, 24);
            this.btnSavePoint.TabIndex = 33;
            this.btnSavePoint.UseVisualStyleBackColor = true;
            this.btnSavePoint.Visible = false;
            this.btnSavePoint.Click += new System.EventHandler(this.btnSavePoint_Click);
            // 
            // chbFlag
            // 
            this.chbFlag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbFlag.Location = new System.Drawing.Point(6, 96);
            this.chbFlag.Name = "chbFlag";
            this.chbFlag.Size = new System.Drawing.Size(48, 20);
            this.chbFlag.TabIndex = 44;
            this.chbFlag.Text = "Flag";
            this.chbFlag.UseVisualStyleBackColor = true;
            this.chbFlag.CheckedChanged += new System.EventHandler(this.PointInfo_Changed);
            // 
            // btnDeletePoint
            // 
            this.btnDeletePoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeletePoint.BackgroundImage = global::SHME.Properties.Resources.delete;
            this.btnDeletePoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeletePoint.FlatAppearance.BorderSize = 0;
            this.btnDeletePoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeletePoint.Location = new System.Drawing.Point(88, 15);
            this.btnDeletePoint.Name = "btnDeletePoint";
            this.btnDeletePoint.Size = new System.Drawing.Size(24, 24);
            this.btnDeletePoint.TabIndex = 31;
            this.btnDeletePoint.UseVisualStyleBackColor = true;
            this.btnDeletePoint.Click += new System.EventHandler(this.btnDeletePoint_Click);
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
            this.nudX.ValueChanged += new System.EventHandler(this.PointInfo_Changed);
            // 
            // nudZ
            // 
            this.nudZ.DecimalPlaces = 2;
            this.nudZ.Location = new System.Drawing.Point(6, 70);
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
            this.nudZ.ValueChanged += new System.EventHandler(this.PointInfo_Changed);
            // 
            // nudY
            // 
            this.nudY.DecimalPlaces = 2;
            this.nudY.Location = new System.Drawing.Point(6, 43);
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
            this.nudY.ValueChanged += new System.EventHandler(this.PointInfo_Changed);
            // 
            // gbLimit
            // 
            this.gbLimit.Controls.Add(this.btnPositionAlign);
            this.gbLimit.Controls.Add(this.nudPositionOffset);
            this.gbLimit.Controls.Add(this.cbLimitZ);
            this.gbLimit.Controls.Add(this.nudPositionStep);
            this.gbLimit.Controls.Add(this.cbLimitY);
            this.gbLimit.Controls.Add(this.cbLimitX);
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
            this.gbLimit.Text = "Limit / Step / Offset";
            // 
            // btnPositionAlign
            // 
            this.btnPositionAlign.FlatAppearance.BorderSize = 0;
            this.btnPositionAlign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPositionAlign.Image = ((System.Drawing.Image)(resources.GetObject("btnPositionAlign.Image")));
            this.btnPositionAlign.Location = new System.Drawing.Point(95, 95);
            this.btnPositionAlign.Name = "btnPositionAlign";
            this.btnPositionAlign.Size = new System.Drawing.Size(22, 22);
            this.btnPositionAlign.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnPositionAlign, "Align position. Only X, Z axis");
            this.btnPositionAlign.UseVisualStyleBackColor = true;
            this.btnPositionAlign.Click += new System.EventHandler(this.btnPositionAlign_Click);
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
            this.nudPositionOffset.Location = new System.Drawing.Point(123, 96);
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
            this.nudPositionOffset.Size = new System.Drawing.Size(62, 20);
            this.nudPositionOffset.TabIndex = 10;
            this.nudPositionOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.nudPositionOffset, "Position increment step offset");
            // 
            // cbLimitZ
            // 
            this.cbLimitZ.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbLimitZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbLimitZ.Location = new System.Drawing.Point(6, 70);
            this.cbLimitZ.Name = "cbLimitZ";
            this.cbLimitZ.Size = new System.Drawing.Size(15, 20);
            this.cbLimitZ.TabIndex = 33;
            this.cbLimitZ.UseVisualStyleBackColor = true;
            this.cbLimitZ.CheckedChanged += new System.EventHandler(this.cbLimit_ValueChanged);
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
            this.nudPositionStep.Location = new System.Drawing.Point(27, 96);
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
            this.nudPositionStep.Size = new System.Drawing.Size(62, 20);
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
            // cbLimitY
            // 
            this.cbLimitY.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbLimitY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbLimitY.Location = new System.Drawing.Point(6, 43);
            this.cbLimitY.Name = "cbLimitY";
            this.cbLimitY.Size = new System.Drawing.Size(15, 20);
            this.cbLimitY.TabIndex = 32;
            this.cbLimitY.UseVisualStyleBackColor = true;
            this.cbLimitY.CheckedChanged += new System.EventHandler(this.cbLimit_ValueChanged);
            // 
            // cbLimitX
            // 
            this.cbLimitX.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbLimitX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbLimitX.Location = new System.Drawing.Point(6, 17);
            this.cbLimitX.Name = "cbLimitX";
            this.cbLimitX.Size = new System.Drawing.Size(15, 20);
            this.cbLimitX.TabIndex = 14;
            this.cbLimitX.UseVisualStyleBackColor = true;
            this.cbLimitX.CheckedChanged += new System.EventHandler(this.cbLimit_ValueChanged);
            // 
            // nudLimitZMin
            // 
            this.nudLimitZMin.DecimalPlaces = 2;
            this.nudLimitZMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudLimitZMin.Location = new System.Drawing.Point(27, 70);
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
            this.nudLimitZMin.Size = new System.Drawing.Size(76, 20);
            this.nudLimitZMin.TabIndex = 12;
            this.nudLimitZMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitZMin.Value = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            // 
            // nudLimitZMax
            // 
            this.nudLimitZMax.DecimalPlaces = 2;
            this.nudLimitZMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudLimitZMax.Location = new System.Drawing.Point(109, 70);
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
            this.nudLimitZMax.Size = new System.Drawing.Size(76, 20);
            this.nudLimitZMax.TabIndex = 12;
            this.nudLimitZMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitZMax.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // nudLimitYMin
            // 
            this.nudLimitYMin.DecimalPlaces = 2;
            this.nudLimitYMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudLimitYMin.Location = new System.Drawing.Point(27, 43);
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
            this.nudLimitYMin.Size = new System.Drawing.Size(76, 20);
            this.nudLimitYMin.TabIndex = 11;
            this.nudLimitYMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitYMin.Value = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            // 
            // nudLimitYMax
            // 
            this.nudLimitYMax.DecimalPlaces = 2;
            this.nudLimitYMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudLimitYMax.Location = new System.Drawing.Point(109, 43);
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
            this.nudLimitYMax.Size = new System.Drawing.Size(76, 20);
            this.nudLimitYMax.TabIndex = 11;
            this.nudLimitYMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitYMax.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // nudLimitXMin
            // 
            this.nudLimitXMin.DecimalPlaces = 2;
            this.nudLimitXMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.nudLimitXMin.Size = new System.Drawing.Size(76, 20);
            this.nudLimitXMin.TabIndex = 10;
            this.nudLimitXMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitXMin.Value = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            // 
            // nudLimitXMax
            // 
            this.nudLimitXMax.DecimalPlaces = 2;
            this.nudLimitXMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.nudLimitXMax.Size = new System.Drawing.Size(76, 20);
            this.nudLimitXMax.TabIndex = 10;
            this.nudLimitXMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitXMax.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // lblZ
            // 
            this.lblZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblZ.Location = new System.Drawing.Point(204, 73);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(14, 19);
            this.lblZ.TabIndex = 13;
            this.lblZ.Text = "Z";
            this.lblZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY
            // 
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblY.Location = new System.Drawing.Point(204, 46);
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
            // clbGroups
            // 
            this.clbGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbGroups.HorizontalScrollbar = true;
            this.clbGroups.IntegralHeight = false;
            this.clbGroups.Location = new System.Drawing.Point(563, 135);
            this.clbGroups.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.clbGroups.Name = "clbGroups";
            this.clbGroups.ScrollAlwaysVisible = true;
            this.clbGroups.Size = new System.Drawing.Size(202, 76);
            this.clbGroups.TabIndex = 33;
            this.clbGroups.SelectedIndexChanged += new System.EventHandler(this.clbGroup_SelectedIndexChanged);
            // 
            // clbMarkers
            // 
            this.clbMarkers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbMarkers.HorizontalScrollbar = true;
            this.clbMarkers.IntegralHeight = false;
            this.clbMarkers.Location = new System.Drawing.Point(355, 135);
            this.clbMarkers.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.clbMarkers.Name = "clbMarkers";
            this.clbMarkers.ScrollAlwaysVisible = true;
            this.clbMarkers.Size = new System.Drawing.Size(202, 76);
            this.clbMarkers.TabIndex = 32;
            this.clbMarkers.SelectedIndexChanged += new System.EventHandler(this.clbMarkers_SelectedIndexChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.clbWaypoints);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 135);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(346, 76);
            this.panel6.TabIndex = 24;
            // 
            // clbWaypoints
            // 
            this.clbWaypoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbWaypoints.HorizontalScrollbar = true;
            this.clbWaypoints.IntegralHeight = false;
            this.clbWaypoints.Location = new System.Drawing.Point(0, 0);
            this.clbWaypoints.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.clbWaypoints.Name = "clbWaypoints";
            this.clbWaypoints.ScrollAlwaysVisible = true;
            this.clbWaypoints.Size = new System.Drawing.Size(346, 76);
            this.clbWaypoints.TabIndex = 21;
            this.clbWaypoints.SelectedIndexChanged += new System.EventHandler(this.clbWaypoints_SelectedIndexChanged);
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
            this.btnSaveRoutes.Enabled = false;
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
            this.btnRouteInfoSave.Click += new System.EventHandler(this.btnRouteNameSave_Click);
            // 
            // tbRouteName
            // 
            this.tbRouteName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRouteName.Enabled = false;
            this.tbRouteName.Location = new System.Drawing.Point(0, 1);
            this.tbRouteName.Name = "tbRouteName";
            this.tbRouteName.Size = new System.Drawing.Size(192, 20);
            this.tbRouteName.TabIndex = 17;
            this.tbRouteName.TextChanged += new System.EventHandler(this.Route_ValueChanged);
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
            this.tvRoutes.Location = new System.Drawing.Point(0, 26);
            this.tvRoutes.Name = "tvRoutes";
            this.tvRoutes.ShowLines = false;
            this.tvRoutes.ShowPlusMinus = false;
            this.tvRoutes.ShowRootLines = false;
            this.tvRoutes.Size = new System.Drawing.Size(224, 185);
            this.tvRoutes.TabIndex = 16;
            this.tvRoutes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRoutes_AfterSelect);
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
            this.ClientSize = new System.Drawing.Size(1024, 261);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnFileReload);
            this.Controls.Add(this.btnFileLoad);
            this.Controls.Add(this.tbFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1040, 300);
            this.Name = "FormADrive";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "SHME: FS Auto Drive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormADrive_FormClosing);
            this.pnlMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbGroup.ResumeLayout(false);
            this.gbGroup.PerformLayout();
            this.gbMarker.ResumeLayout(false);
            this.gbMarker.PerformLayout();
            this.pnlItems.ResumeLayout(false);
            this.gbEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            this.gbLimit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPositionStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitZMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitZMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitYMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitYMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitXMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitXMax)).EndInit();
            this.panel6.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFileReload;
        private System.Windows.Forms.Button btnFileLoad;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlItems;
        private System.Windows.Forms.Button btnPositionAlign;
        private System.Windows.Forms.NumericUpDown nudPositionOffset;
        private System.Windows.Forms.NumericUpDown nudPositionStep;
        private System.Windows.Forms.GroupBox gbEdit;
        private System.Windows.Forms.Button btnSavePoint;
        private System.Windows.Forms.CheckBox chbFlag;
        private System.Windows.Forms.Button btnDeletePoint;
        private System.Windows.Forms.TextBox tbMarkerName;
        private System.Windows.Forms.NumericUpDown nudX;
        private System.Windows.Forms.NumericUpDown nudZ;
        private System.Windows.Forms.NumericUpDown nudY;
        private System.Windows.Forms.GroupBox gbLimit;
        private System.Windows.Forms.CheckBox cbLimitZ;
        private System.Windows.Forms.CheckBox cbLimitY;
        private System.Windows.Forms.CheckBox cbLimitX;
        private System.Windows.Forms.NumericUpDown nudLimitZMin;
        private System.Windows.Forms.NumericUpDown nudLimitZMax;
        private System.Windows.Forms.NumericUpDown nudLimitYMin;
        private System.Windows.Forms.NumericUpDown nudLimitYMax;
        private System.Windows.Forms.NumericUpDown nudLimitXMin;
        private System.Windows.Forms.NumericUpDown nudLimitXMax;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Button btnRouteInfoSave;
        private System.Windows.Forms.TextBox tbRouteName;
        private System.Windows.Forms.TreeView tvRoutes;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox cbbMarkerGroup;
        private System.Windows.Forms.GroupBox gbMarker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbMarkerPoint;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckedListBox clbGroups;
        private System.Windows.Forms.CheckedListBox clbMarkers;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnSaveRoute;
        private System.Windows.Forms.Button btnReloadRoute;
        private System.Windows.Forms.CheckedListBox clbWaypoints;
        private System.Windows.Forms.Button btnSaveMarker;
        private System.Windows.Forms.Button btnDeleteMarker;
        private System.Windows.Forms.Button btnSaveRoutes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbGroup;
        private System.Windows.Forms.Button btnSaveGroup;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.Label lblGroupID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbGroupName;
    }
}