
namespace weldDeviceProduct
{
    partial class frmParaEdit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbDeviceType = new System.Windows.Forms.ComboBox();
            this.textDeviceType = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textDeviceSN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lineRightToLaserDist = new System.Windows.Forms.NumericUpDown();
            this.lineFrontRearDiff = new System.Windows.Forms.NumericUpDown();
            this.lineLeftRightDiff = new System.Windows.Forms.NumericUpDown();
            this.lineUpperLowerDiff = new System.Windows.Forms.NumericUpDown();
            this.lineFrontDist = new System.Windows.Forms.NumericUpDown();
            this.lineRightDist = new System.Windows.Forms.NumericUpDown();
            this.lineLowerDist = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lineNearestViewDist = new System.Windows.Forms.NumericUpDown();
            this.lineLongestViewDist = new System.Windows.Forms.NumericUpDown();
            this.lineOptView = new System.Windows.Forms.NumericUpDown();
            this.lineNearestView = new System.Windows.Forms.NumericUpDown();
            this.lineLongestView = new System.Windows.Forms.NumericUpDown();
            this.lineOptViewDist = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnWriteToDevice = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUploadToMES = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbbMESPort = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cbbResult = new System.Windows.Forms.ComboBox();
            this.textNGRemark = new System.Windows.Forms.TextBox();
            this.labeNGRemark = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.textEq = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textShiftCode = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textPersonCode = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textWorkstationCode = new System.Windows.Forms.TextBox();
            this.textOperationCode = new System.Windows.Forms.TextBox();
            this.labelWorkstationCode = new System.Windows.Forms.Label();
            this.labelOperationCode = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineRightToLaserDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineFrontRearDiff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineLeftRightDiff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineUpperLowerDiff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineFrontDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineRightDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineLowerDist)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineNearestViewDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineLongestViewDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineOptView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineNearestView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineLongestView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineOptViewDist)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbDeviceType);
            this.groupBox1.Controls.Add(this.textDeviceType);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(366, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备信息";
            // 
            // cbbDeviceType
            // 
            this.cbbDeviceType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbbDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDeviceType.ForeColor = System.Drawing.SystemColors.Control;
            this.cbbDeviceType.FormattingEnabled = true;
            this.cbbDeviceType.Items.AddRange(new object[] {
            "BCW500",
            "BCW500S"});
            this.cbbDeviceType.Location = new System.Drawing.Point(135, 22);
            this.cbbDeviceType.Name = "cbbDeviceType";
            this.cbbDeviceType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbbDeviceType.Size = new System.Drawing.Size(218, 25);
            this.cbbDeviceType.TabIndex = 6;
            this.cbbDeviceType.SelectedIndexChanged += new System.EventHandler(this.cbbDeviceType_SelectedIndexChanged);
            // 
            // textDeviceType
            // 
            this.textDeviceType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textDeviceType.ForeColor = System.Drawing.SystemColors.Control;
            this.textDeviceType.Location = new System.Drawing.Point(135, 51);
            this.textDeviceType.Name = "textDeviceType";
            this.textDeviceType.Size = new System.Drawing.Size(218, 23);
            this.textDeviceType.TabIndex = 3;
            this.textDeviceType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 17);
            this.label16.TabIndex = 5;
            this.label16.Text = "设备型号选择：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备型号：";
            // 
            // textDeviceSN
            // 
            this.textDeviceSN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textDeviceSN.ForeColor = System.Drawing.SystemColors.Control;
            this.textDeviceSN.Location = new System.Drawing.Point(135, 22);
            this.textDeviceSN.Name = "textDeviceSN";
            this.textDeviceSN.Size = new System.Drawing.Size(218, 23);
            this.textDeviceSN.TabIndex = 4;
            this.textDeviceSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "设备序列号(S/N)：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lineRightToLaserDist);
            this.groupBox2.Controls.Add(this.lineFrontRearDiff);
            this.groupBox2.Controls.Add(this.lineLeftRightDiff);
            this.groupBox2.Controls.Add(this.lineUpperLowerDiff);
            this.groupBox2.Controls.Add(this.lineFrontDist);
            this.groupBox2.Controls.Add(this.lineRightDist);
            this.groupBox2.Controls.Add(this.lineLowerDist);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(3, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 233);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "寻缝器机械参数（单位：mm）";
            // 
            // lineRightToLaserDist
            // 
            this.lineRightToLaserDist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineRightToLaserDist.DecimalPlaces = 3;
            this.lineRightToLaserDist.ForeColor = System.Drawing.SystemColors.Control;
            this.lineRightToLaserDist.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lineRightToLaserDist.Location = new System.Drawing.Point(237, 199);
            this.lineRightToLaserDist.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.lineRightToLaserDist.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.lineRightToLaserDist.Name = "lineRightToLaserDist";
            this.lineRightToLaserDist.Size = new System.Drawing.Size(116, 23);
            this.lineRightToLaserDist.TabIndex = 14;
            // 
            // lineFrontRearDiff
            // 
            this.lineFrontRearDiff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineFrontRearDiff.DecimalPlaces = 3;
            this.lineFrontRearDiff.ForeColor = System.Drawing.SystemColors.Control;
            this.lineFrontRearDiff.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lineFrontRearDiff.Location = new System.Drawing.Point(237, 170);
            this.lineFrontRearDiff.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.lineFrontRearDiff.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.lineFrontRearDiff.Name = "lineFrontRearDiff";
            this.lineFrontRearDiff.Size = new System.Drawing.Size(116, 23);
            this.lineFrontRearDiff.TabIndex = 13;
            // 
            // lineLeftRightDiff
            // 
            this.lineLeftRightDiff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineLeftRightDiff.DecimalPlaces = 3;
            this.lineLeftRightDiff.ForeColor = System.Drawing.SystemColors.Control;
            this.lineLeftRightDiff.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lineLeftRightDiff.Location = new System.Drawing.Point(237, 141);
            this.lineLeftRightDiff.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.lineLeftRightDiff.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.lineLeftRightDiff.Name = "lineLeftRightDiff";
            this.lineLeftRightDiff.Size = new System.Drawing.Size(116, 23);
            this.lineLeftRightDiff.TabIndex = 12;
            // 
            // lineUpperLowerDiff
            // 
            this.lineUpperLowerDiff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineUpperLowerDiff.DecimalPlaces = 3;
            this.lineUpperLowerDiff.ForeColor = System.Drawing.SystemColors.Control;
            this.lineUpperLowerDiff.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lineUpperLowerDiff.Location = new System.Drawing.Point(237, 112);
            this.lineUpperLowerDiff.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.lineUpperLowerDiff.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.lineUpperLowerDiff.Name = "lineUpperLowerDiff";
            this.lineUpperLowerDiff.Size = new System.Drawing.Size(116, 23);
            this.lineUpperLowerDiff.TabIndex = 11;
            // 
            // lineFrontDist
            // 
            this.lineFrontDist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineFrontDist.DecimalPlaces = 3;
            this.lineFrontDist.ForeColor = System.Drawing.SystemColors.Control;
            this.lineFrontDist.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lineFrontDist.Location = new System.Drawing.Point(237, 83);
            this.lineFrontDist.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.lineFrontDist.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.lineFrontDist.Name = "lineFrontDist";
            this.lineFrontDist.Size = new System.Drawing.Size(116, 23);
            this.lineFrontDist.TabIndex = 10;
            // 
            // lineRightDist
            // 
            this.lineRightDist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineRightDist.DecimalPlaces = 3;
            this.lineRightDist.ForeColor = System.Drawing.SystemColors.Control;
            this.lineRightDist.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lineRightDist.Location = new System.Drawing.Point(237, 54);
            this.lineRightDist.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.lineRightDist.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.lineRightDist.Name = "lineRightDist";
            this.lineRightDist.Size = new System.Drawing.Size(116, 23);
            this.lineRightDist.TabIndex = 9;
            // 
            // lineLowerDist
            // 
            this.lineLowerDist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineLowerDist.DecimalPlaces = 3;
            this.lineLowerDist.ForeColor = System.Drawing.SystemColors.Control;
            this.lineLowerDist.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lineLowerDist.Location = new System.Drawing.Point(237, 25);
            this.lineLowerDist.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.lineLowerDist.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.lineLowerDist.Name = "lineLowerDist";
            this.lineLowerDist.Size = new System.Drawing.Size(116, 23);
            this.lineLowerDist.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(227, 17);
            this.label15.TabIndex = 7;
            this.label15.Text = "寻缝器右表面相对于该参考点的距离Dy：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 115);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(146, 17);
            this.label14.TabIndex = 6;
            this.label14.Text = "寻缝器上下表面之差Wx：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 202);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(176, 17);
            this.label13.TabIndex = 5;
            this.label13.Text = "相机最右边点到激光器的距离：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(146, 17);
            this.label12.TabIndex = 4;
            this.label12.Text = "寻缝器前后表面之差Wz：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(227, 17);
            this.label11.TabIndex = 3;
            this.label11.Text = "寻缝器前表面相对于该参考点的距离Dz：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "寻缝器左右表面之差Wy：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "寻缝器下表面相对于该参考点的距离Dx：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lineNearestViewDist);
            this.groupBox3.Controls.Add(this.lineLongestViewDist);
            this.groupBox3.Controls.Add(this.lineOptView);
            this.groupBox3.Controls.Add(this.lineNearestView);
            this.groupBox3.Controls.Add(this.lineLongestView);
            this.groupBox3.Controls.Add(this.lineOptViewDist);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(3, 247);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(357, 203);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "寻缝器视距视野（单位：mm）";
            // 
            // lineNearestViewDist
            // 
            this.lineNearestViewDist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineNearestViewDist.DecimalPlaces = 2;
            this.lineNearestViewDist.ForeColor = System.Drawing.SystemColors.Control;
            this.lineNearestViewDist.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lineNearestViewDist.Location = new System.Drawing.Point(237, 54);
            this.lineNearestViewDist.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.lineNearestViewDist.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.lineNearestViewDist.Name = "lineNearestViewDist";
            this.lineNearestViewDist.Size = new System.Drawing.Size(116, 23);
            this.lineNearestViewDist.TabIndex = 20;
            // 
            // lineLongestViewDist
            // 
            this.lineLongestViewDist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineLongestViewDist.DecimalPlaces = 2;
            this.lineLongestViewDist.ForeColor = System.Drawing.SystemColors.Control;
            this.lineLongestViewDist.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lineLongestViewDist.Location = new System.Drawing.Point(237, 83);
            this.lineLongestViewDist.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.lineLongestViewDist.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.lineLongestViewDist.Name = "lineLongestViewDist";
            this.lineLongestViewDist.Size = new System.Drawing.Size(116, 23);
            this.lineLongestViewDist.TabIndex = 19;
            // 
            // lineOptView
            // 
            this.lineOptView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineOptView.DecimalPlaces = 2;
            this.lineOptView.ForeColor = System.Drawing.SystemColors.Control;
            this.lineOptView.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lineOptView.Location = new System.Drawing.Point(237, 112);
            this.lineOptView.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.lineOptView.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.lineOptView.Name = "lineOptView";
            this.lineOptView.Size = new System.Drawing.Size(116, 23);
            this.lineOptView.TabIndex = 18;
            // 
            // lineNearestView
            // 
            this.lineNearestView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineNearestView.DecimalPlaces = 2;
            this.lineNearestView.ForeColor = System.Drawing.SystemColors.Control;
            this.lineNearestView.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lineNearestView.Location = new System.Drawing.Point(237, 141);
            this.lineNearestView.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.lineNearestView.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.lineNearestView.Name = "lineNearestView";
            this.lineNearestView.Size = new System.Drawing.Size(116, 23);
            this.lineNearestView.TabIndex = 17;
            // 
            // lineLongestView
            // 
            this.lineLongestView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineLongestView.DecimalPlaces = 2;
            this.lineLongestView.ForeColor = System.Drawing.SystemColors.Control;
            this.lineLongestView.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lineLongestView.Location = new System.Drawing.Point(237, 170);
            this.lineLongestView.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.lineLongestView.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.lineLongestView.Name = "lineLongestView";
            this.lineLongestView.Size = new System.Drawing.Size(116, 23);
            this.lineLongestView.TabIndex = 16;
            // 
            // lineOptViewDist
            // 
            this.lineOptViewDist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineOptViewDist.DecimalPlaces = 2;
            this.lineOptViewDist.ForeColor = System.Drawing.SystemColors.Control;
            this.lineOptViewDist.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lineOptViewDist.Location = new System.Drawing.Point(237, 25);
            this.lineOptViewDist.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.lineOptViewDist.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.lineOptViewDist.Name = "lineOptViewDist";
            this.lineOptViewDist.Size = new System.Drawing.Size(116, 23);
            this.lineOptViewDist.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "最近视野：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "最佳视野：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "最近视距：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "最远视野：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "最远视距：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "最佳视距：";
            // 
            // btnWriteToDevice
            // 
            this.btnWriteToDevice.ForeColor = System.Drawing.SystemColors.Control;
            this.btnWriteToDevice.Location = new System.Drawing.Point(125, 306);
            this.btnWriteToDevice.Name = "btnWriteToDevice";
            this.btnWriteToDevice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnWriteToDevice.Size = new System.Drawing.Size(108, 30);
            this.btnWriteToDevice.TabIndex = 2;
            this.btnWriteToDevice.Text = "写入寻缝器";
            this.btnWriteToDevice.UseVisualStyleBackColor = false;
            this.btnWriteToDevice.Click += new System.EventHandler(this.btnWriteToDevice_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(239, 306);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancel.Size = new System.Drawing.Size(108, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUploadToMES
            // 
            this.btnUploadToMES.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUploadToMES.ForeColor = System.Drawing.Color.Red;
            this.btnUploadToMES.Location = new System.Drawing.Point(11, 306);
            this.btnUploadToMES.Name = "btnUploadToMES";
            this.btnUploadToMES.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnUploadToMES.Size = new System.Drawing.Size(108, 30);
            this.btnUploadToMES.TabIndex = 7;
            this.btnUploadToMES.Text = "上传至MES";
            this.btnUploadToMES.UseVisualStyleBackColor = false;
            this.btnUploadToMES.Click += new System.EventHandler(this.btnUploadToMES_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbbMESPort);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.cbbResult);
            this.groupBox4.Controls.Add(this.textNGRemark);
            this.groupBox4.Controls.Add(this.btnUploadToMES);
            this.groupBox4.Controls.Add(this.labeNGRemark);
            this.groupBox4.Controls.Add(this.btnCancel);
            this.groupBox4.Controls.Add(this.btnWriteToDevice);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.textEq);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.textShiftCode);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.textPersonCode);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.textDeviceSN);
            this.groupBox4.Controls.Add(this.textWorkstationCode);
            this.groupBox4.Controls.Add(this.textOperationCode);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.labelWorkstationCode);
            this.groupBox4.Controls.Add(this.labelOperationCode);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Location = new System.Drawing.Point(366, 101);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(357, 349);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "上传MES参数信息";
            // 
            // cbbMESPort
            // 
            this.cbbMESPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbbMESPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMESPort.ForeColor = System.Drawing.SystemColors.Control;
            this.cbbMESPort.FormattingEnabled = true;
            this.cbbMESPort.Items.AddRange(new object[] {
            "正式服8081",
            "测试服8082"});
            this.cbbMESPort.Location = new System.Drawing.Point(135, 254);
            this.cbbMESPort.Name = "cbbMESPort";
            this.cbbMESPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbbMESPort.Size = new System.Drawing.Size(218, 25);
            this.cbbMESPort.TabIndex = 15;
            this.cbbMESPort.SelectedIndexChanged += new System.EventHandler(this.cbbMESPort_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(19, 258);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(106, 17);
            this.label23.TabIndex = 16;
            this.label23.Text = "MES服务器端口：";
            // 
            // cbbResult
            // 
            this.cbbResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbResult.ForeColor = System.Drawing.SystemColors.Control;
            this.cbbResult.FormattingEnabled = true;
            this.cbbResult.Items.AddRange(new object[] {
            "OK",
            "NG"});
            this.cbbResult.Location = new System.Drawing.Point(135, 195);
            this.cbbResult.Name = "cbbResult";
            this.cbbResult.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbbResult.Size = new System.Drawing.Size(218, 25);
            this.cbbResult.TabIndex = 7;
            this.cbbResult.SelectedIndexChanged += new System.EventHandler(this.cbbResult_SelectedIndexChanged);
            // 
            // textNGRemark
            // 
            this.textNGRemark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textNGRemark.ForeColor = System.Drawing.SystemColors.Control;
            this.textNGRemark.Location = new System.Drawing.Point(135, 225);
            this.textNGRemark.MaxLength = 400;
            this.textNGRemark.Name = "textNGRemark";
            this.textNGRemark.Size = new System.Drawing.Size(218, 23);
            this.textNGRemark.TabIndex = 14;
            this.textNGRemark.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labeNGRemark
            // 
            this.labeNGRemark.AutoSize = true;
            this.labeNGRemark.Location = new System.Drawing.Point(19, 228);
            this.labeNGRemark.Name = "labeNGRemark";
            this.labeNGRemark.Size = new System.Drawing.Size(63, 17);
            this.labeNGRemark.TabIndex = 13;
            this.labeNGRemark.Text = "NG备注：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(19, 199);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(68, 17);
            this.label22.TabIndex = 11;
            this.label22.Text = "测试结果：";
            // 
            // textEq
            // 
            this.textEq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textEq.ForeColor = System.Drawing.SystemColors.Control;
            this.textEq.Location = new System.Drawing.Point(135, 167);
            this.textEq.Name = "textEq";
            this.textEq.Size = new System.Drawing.Size(218, 23);
            this.textEq.TabIndex = 10;
            this.textEq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(19, 170);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(68, 17);
            this.label21.TabIndex = 9;
            this.label21.Text = "测试设备：";
            // 
            // textShiftCode
            // 
            this.textShiftCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textShiftCode.ForeColor = System.Drawing.SystemColors.Control;
            this.textShiftCode.Location = new System.Drawing.Point(135, 109);
            this.textShiftCode.Name = "textShiftCode";
            this.textShiftCode.Size = new System.Drawing.Size(218, 23);
            this.textShiftCode.TabIndex = 8;
            this.textShiftCode.Text = "A";
            this.textShiftCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(19, 112);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 17);
            this.label20.TabIndex = 7;
            this.label20.Text = "班次编码：";
            // 
            // textPersonCode
            // 
            this.textPersonCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textPersonCode.ForeColor = System.Drawing.SystemColors.Control;
            this.textPersonCode.Location = new System.Drawing.Point(135, 138);
            this.textPersonCode.Name = "textPersonCode";
            this.textPersonCode.Size = new System.Drawing.Size(218, 23);
            this.textPersonCode.TabIndex = 6;
            this.textPersonCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(19, 141);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 17);
            this.label17.TabIndex = 5;
            this.label17.Text = "人员编码：";
            // 
            // textWorkstationCode
            // 
            this.textWorkstationCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textWorkstationCode.ForeColor = System.Drawing.SystemColors.Control;
            this.textWorkstationCode.Location = new System.Drawing.Point(135, 80);
            this.textWorkstationCode.Name = "textWorkstationCode";
            this.textWorkstationCode.Size = new System.Drawing.Size(218, 23);
            this.textWorkstationCode.TabIndex = 4;
            this.textWorkstationCode.Text = "WorkStation11";
            this.textWorkstationCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textWorkstationCode.Visible = false;
            // 
            // textOperationCode
            // 
            this.textOperationCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textOperationCode.ForeColor = System.Drawing.SystemColors.Control;
            this.textOperationCode.Location = new System.Drawing.Point(135, 51);
            this.textOperationCode.Name = "textOperationCode";
            this.textOperationCode.Size = new System.Drawing.Size(218, 23);
            this.textOperationCode.TabIndex = 3;
            this.textOperationCode.Text = "Process13";
            this.textOperationCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textOperationCode.Visible = false;
            // 
            // labelWorkstationCode
            // 
            this.labelWorkstationCode.AutoSize = true;
            this.labelWorkstationCode.Location = new System.Drawing.Point(19, 83);
            this.labelWorkstationCode.Name = "labelWorkstationCode";
            this.labelWorkstationCode.Size = new System.Drawing.Size(56, 17);
            this.labelWorkstationCode.TabIndex = 2;
            this.labelWorkstationCode.Text = "工站号：";
            this.labelWorkstationCode.Visible = false;
            // 
            // labelOperationCode
            // 
            this.labelOperationCode.AutoSize = true;
            this.labelOperationCode.Location = new System.Drawing.Point(19, 54);
            this.labelOperationCode.Name = "labelOperationCode";
            this.labelOperationCode.Size = new System.Drawing.Size(56, 17);
            this.labelOperationCode.TabIndex = 0;
            this.labelOperationCode.Text = "工序号：";
            this.labelOperationCode.Visible = false;
            // 
            // frmParaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(731, 456);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "frmParaEdit";
            this.Text = "设备参数编辑";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineRightToLaserDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineFrontRearDiff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineLeftRightDiff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineUpperLowerDiff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineFrontDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineRightDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineLowerDist)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineNearestViewDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineLongestViewDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineOptView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineNearestView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineLongestView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineOptViewDist)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textDeviceSN;
        private System.Windows.Forms.TextBox textDeviceType;
        private System.Windows.Forms.NumericUpDown lineRightToLaserDist;
        private System.Windows.Forms.NumericUpDown lineFrontRearDiff;
        private System.Windows.Forms.NumericUpDown lineLeftRightDiff;
        private System.Windows.Forms.NumericUpDown lineUpperLowerDiff;
        private System.Windows.Forms.NumericUpDown lineFrontDist;
        private System.Windows.Forms.NumericUpDown lineRightDist;
        private System.Windows.Forms.NumericUpDown lineLowerDist;
        private System.Windows.Forms.Button btnWriteToDevice;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.NumericUpDown lineNearestViewDist;
        public System.Windows.Forms.NumericUpDown lineLongestViewDist;
        public System.Windows.Forms.NumericUpDown lineOptView;
        public System.Windows.Forms.NumericUpDown lineNearestView;
        public System.Windows.Forms.NumericUpDown lineLongestView;
        public System.Windows.Forms.NumericUpDown lineOptViewDist;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbbDeviceType;
        private System.Windows.Forms.Button btnUploadToMES;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textNGRemark;
        private System.Windows.Forms.Label labeNGRemark;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textEq;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textShiftCode;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textPersonCode;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbbResult;
        private System.Windows.Forms.ComboBox cbbMESPort;
        private System.Windows.Forms.Label label23;
        public System.Windows.Forms.TextBox textWorkstationCode;
        public System.Windows.Forms.TextBox textOperationCode;
        public System.Windows.Forms.Label labelWorkstationCode;
        public System.Windows.Forms.Label labelOperationCode;
    }
}