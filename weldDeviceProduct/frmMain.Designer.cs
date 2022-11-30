
namespace weldDeviceProduct
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlOperator = new System.Windows.Forms.Panel();
            this.btnBanDisplaySomeLog = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnReadOptViewDist = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbbLaserHoldSpacePercent = new System.Windows.Forms.ComboBox();
            this.labelLaserHoldSpacePercent = new System.Windows.Forms.Label();
            this.btnOpenCloseLaser = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textShowIsChecking = new System.Windows.Forms.TextBox();
            this.btnStopChecking = new System.Windows.Forms.Button();
            this.btnErrorVerify = new System.Windows.Forms.Button();
            this.btnParaEdit = new System.Windows.Forms.Button();
            this.btnCalMat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textShowIsCaliing = new System.Windows.Forms.TextBox();
            this.btnAutoInterParaCali = new System.Windows.Forms.Button();
            this.btnReadStartPoint = new System.Windows.Forms.Button();
            this.btnReadEndPoint = new System.Windows.Forms.Button();
            this.btnStopCaliing = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.TextBox();
            this.groupBoxGlobalPara = new System.Windows.Forms.GroupBox();
            this.labelTGQSensorDist = new System.Windows.Forms.Label();
            this.lineTGQSensorDist = new System.Windows.Forms.NumericUpDown();
            this.labelTGQTotalTravel = new System.Windows.Forms.Label();
            this.lineTGQTotalTravel = new System.Windows.Forms.NumericUpDown();
            this.labelTGQMesaDist = new System.Windows.Forms.Label();
            this.lineTGQMesaDist = new System.Windows.Forms.NumericUpDown();
            this.textEndPos = new System.Windows.Forms.TextBox();
            this.textStartPos = new System.Windows.Forms.TextBox();
            this.labelEndPos = new System.Windows.Forms.Label();
            this.labelStartPos = new System.Windows.Forms.Label();
            this.labelActualDist = new System.Windows.Forms.Label();
            this.lineActualDist = new System.Windows.Forms.NumericUpDown();
            this.lableOptViewDist = new System.Windows.Forms.Label();
            this.lineOptViewDist = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.高级设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExpertMode = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMainFrom = new System.Windows.Forms.Panel();
            this.timerUpdateFrm = new System.Windows.Forms.Timer(this.components);
            this.pnlOperator.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxGlobalPara.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineTGQSensorDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineTGQTotalTravel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineTGQMesaDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineActualDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineOptViewDist)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOperator
            // 
            this.pnlOperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlOperator.Controls.Add(this.btnBanDisplaySomeLog);
            this.pnlOperator.Controls.Add(this.btnClearLog);
            this.pnlOperator.Controls.Add(this.groupBox5);
            this.pnlOperator.Controls.Add(this.groupBox4);
            this.pnlOperator.Controls.Add(this.groupBox3);
            this.pnlOperator.Controls.Add(this.groupBox1);
            this.pnlOperator.Controls.Add(this.Log);
            this.pnlOperator.Controls.Add(this.groupBoxGlobalPara);
            this.pnlOperator.Controls.Add(this.menuStrip1);
            this.pnlOperator.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlOperator.ForeColor = System.Drawing.SystemColors.Control;
            this.pnlOperator.Location = new System.Drawing.Point(921, 0);
            this.pnlOperator.Name = "pnlOperator";
            this.pnlOperator.Size = new System.Drawing.Size(300, 831);
            this.pnlOperator.TabIndex = 0;
            // 
            // btnBanDisplaySomeLog
            // 
            this.btnBanDisplaySomeLog.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBanDisplaySomeLog.Location = new System.Drawing.Point(144, 543);
            this.btnBanDisplaySomeLog.Name = "btnBanDisplaySomeLog";
            this.btnBanDisplaySomeLog.Size = new System.Drawing.Size(66, 52);
            this.btnBanDisplaySomeLog.TabIndex = 5;
            this.btnBanDisplaySomeLog.Text = "屏蔽某些日志打印";
            this.btnBanDisplaySomeLog.UseVisualStyleBackColor = false;
            this.btnBanDisplaySomeLog.Click += new System.EventHandler(this.btnBanDisplaySomeLog_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClearLog.Location = new System.Drawing.Point(216, 543);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(66, 52);
            this.btnClearLog.TabIndex = 5;
            this.btnClearLog.Text = "清空日志";
            this.btnClearLog.UseVisualStyleBackColor = false;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnReadOptViewDist);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox5.Location = new System.Drawing.Point(207, 233);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(81, 77);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "最佳视距";
            // 
            // btnReadOptViewDist
            // 
            this.btnReadOptViewDist.Location = new System.Drawing.Point(9, 19);
            this.btnReadOptViewDist.Name = "btnReadOptViewDist";
            this.btnReadOptViewDist.Size = new System.Drawing.Size(66, 52);
            this.btnReadOptViewDist.TabIndex = 13;
            this.btnReadOptViewDist.Text = "自动调整最佳视距";
            this.btnReadOptViewDist.UseVisualStyleBackColor = false;
            this.btnReadOptViewDist.Click += new System.EventHandler(this.btnReadOptViewDist_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbbLaserHoldSpacePercent);
            this.groupBox4.Controls.Add(this.labelLaserHoldSpacePercent);
            this.groupBox4.Controls.Add(this.btnOpenCloseLaser);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Location = new System.Drawing.Point(6, 233);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(195, 77);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "激光设置";
            // 
            // cbbLaserHoldSpacePercent
            // 
            this.cbbLaserHoldSpacePercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbbLaserHoldSpacePercent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLaserHoldSpacePercent.ForeColor = System.Drawing.SystemColors.Control;
            this.cbbLaserHoldSpacePercent.FormattingEnabled = true;
            this.cbbLaserHoldSpacePercent.Items.AddRange(new object[] {
            "100",
            "18"});
            this.cbbLaserHoldSpacePercent.Location = new System.Drawing.Point(86, 42);
            this.cbbLaserHoldSpacePercent.Name = "cbbLaserHoldSpacePercent";
            this.cbbLaserHoldSpacePercent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbbLaserHoldSpacePercent.Size = new System.Drawing.Size(92, 25);
            this.cbbLaserHoldSpacePercent.TabIndex = 16;
            this.cbbLaserHoldSpacePercent.SelectedIndexChanged += new System.EventHandler(this.cbbLaserHoldSpacePercent_SelectedIndexChanged);
            // 
            // labelLaserHoldSpacePercent
            // 
            this.labelLaserHoldSpacePercent.AutoSize = true;
            this.labelLaserHoldSpacePercent.Location = new System.Drawing.Point(86, 21);
            this.labelLaserHoldSpacePercent.Name = "labelLaserHoldSpacePercent";
            this.labelLaserHoldSpacePercent.Size = new System.Drawing.Size(92, 17);
            this.labelLaserHoldSpacePercent.TabIndex = 15;
            this.labelLaserHoldSpacePercent.Text = "设置激光占空比";
            // 
            // btnOpenCloseLaser
            // 
            this.btnOpenCloseLaser.Location = new System.Drawing.Point(6, 19);
            this.btnOpenCloseLaser.Name = "btnOpenCloseLaser";
            this.btnOpenCloseLaser.Size = new System.Drawing.Size(66, 52);
            this.btnOpenCloseLaser.TabIndex = 13;
            this.btnOpenCloseLaser.Text = "打开激光关闭激光";
            this.btnOpenCloseLaser.UseVisualStyleBackColor = false;
            this.btnOpenCloseLaser.Click += new System.EventHandler(this.btnOpenCloseLaser_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textShowIsChecking);
            this.groupBox3.Controls.Add(this.btnStopChecking);
            this.groupBox3.Controls.Add(this.btnErrorVerify);
            this.groupBox3.Controls.Add(this.btnParaEdit);
            this.groupBox3.Controls.Add(this.btnCalMat);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(6, 428);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(282, 109);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "计算矩阵与设备参数编辑";
            // 
            // textShowIsChecking
            // 
            this.textShowIsChecking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textShowIsChecking.ForeColor = System.Drawing.Color.Crimson;
            this.textShowIsChecking.Location = new System.Drawing.Point(6, 77);
            this.textShowIsChecking.Name = "textShowIsChecking";
            this.textShowIsChecking.ReadOnly = true;
            this.textShowIsChecking.Size = new System.Drawing.Size(270, 23);
            this.textShowIsChecking.TabIndex = 16;
            // 
            // btnStopChecking
            // 
            this.btnStopChecking.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStopChecking.Location = new System.Drawing.Point(210, 20);
            this.btnStopChecking.Name = "btnStopChecking";
            this.btnStopChecking.Size = new System.Drawing.Size(66, 52);
            this.btnStopChecking.TabIndex = 14;
            this.btnStopChecking.Text = "终止验证";
            this.btnStopChecking.UseVisualStyleBackColor = false;
            this.btnStopChecking.Click += new System.EventHandler(this.btnStopChecking_Click);
            // 
            // btnErrorVerify
            // 
            this.btnErrorVerify.Enabled = false;
            this.btnErrorVerify.ForeColor = System.Drawing.SystemColors.Control;
            this.btnErrorVerify.Location = new System.Drawing.Point(142, 20);
            this.btnErrorVerify.Name = "btnErrorVerify";
            this.btnErrorVerify.Size = new System.Drawing.Size(66, 52);
            this.btnErrorVerify.TabIndex = 6;
            this.btnErrorVerify.Text = "误差验证";
            this.btnErrorVerify.UseVisualStyleBackColor = false;
            this.btnErrorVerify.Click += new System.EventHandler(this.btnErrorVerify_Click);
            // 
            // btnParaEdit
            // 
            this.btnParaEdit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnParaEdit.Location = new System.Drawing.Point(74, 20);
            this.btnParaEdit.Name = "btnParaEdit";
            this.btnParaEdit.Size = new System.Drawing.Size(66, 52);
            this.btnParaEdit.TabIndex = 3;
            this.btnParaEdit.Text = "设备参数编辑";
            this.btnParaEdit.UseVisualStyleBackColor = false;
            this.btnParaEdit.Click += new System.EventHandler(this.btnParaEdit_Click);
            // 
            // btnCalMat
            // 
            this.btnCalMat.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCalMat.Location = new System.Drawing.Point(6, 20);
            this.btnCalMat.Name = "btnCalMat";
            this.btnCalMat.Size = new System.Drawing.Size(66, 52);
            this.btnCalMat.TabIndex = 4;
            this.btnCalMat.Text = "计算矩阵";
            this.btnCalMat.UseVisualStyleBackColor = false;
            this.btnCalMat.Click += new System.EventHandler(this.btnCalMat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textShowIsCaliing);
            this.groupBox1.Controls.Add(this.btnAutoInterParaCali);
            this.groupBox1.Controls.Add(this.btnReadStartPoint);
            this.groupBox1.Controls.Add(this.btnReadEndPoint);
            this.groupBox1.Controls.Add(this.btnStopCaliing);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(6, 313);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 109);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自动标定设置";
            // 
            // textShowIsCaliing
            // 
            this.textShowIsCaliing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textShowIsCaliing.ForeColor = System.Drawing.Color.Crimson;
            this.textShowIsCaliing.Location = new System.Drawing.Point(6, 77);
            this.textShowIsCaliing.Name = "textShowIsCaliing";
            this.textShowIsCaliing.ReadOnly = true;
            this.textShowIsCaliing.Size = new System.Drawing.Size(270, 23);
            this.textShowIsCaliing.TabIndex = 14;
            // 
            // btnAutoInterParaCali
            // 
            this.btnAutoInterParaCali.Enabled = false;
            this.btnAutoInterParaCali.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAutoInterParaCali.Location = new System.Drawing.Point(142, 19);
            this.btnAutoInterParaCali.Name = "btnAutoInterParaCali";
            this.btnAutoInterParaCali.Size = new System.Drawing.Size(66, 52);
            this.btnAutoInterParaCali.TabIndex = 15;
            this.btnAutoInterParaCali.Text = "开始标定";
            this.btnAutoInterParaCali.UseVisualStyleBackColor = false;
            this.btnAutoInterParaCali.Click += new System.EventHandler(this.btnAutoInterParaCali_Click);
            // 
            // btnReadStartPoint
            // 
            this.btnReadStartPoint.Location = new System.Drawing.Point(6, 19);
            this.btnReadStartPoint.Name = "btnReadStartPoint";
            this.btnReadStartPoint.Size = new System.Drawing.Size(66, 52);
            this.btnReadStartPoint.TabIndex = 11;
            this.btnReadStartPoint.Text = "读取调高器起始点";
            this.btnReadStartPoint.UseVisualStyleBackColor = false;
            this.btnReadStartPoint.Click += new System.EventHandler(this.btnReadStartPoint_Click);
            // 
            // btnReadEndPoint
            // 
            this.btnReadEndPoint.Enabled = false;
            this.btnReadEndPoint.Location = new System.Drawing.Point(74, 19);
            this.btnReadEndPoint.Name = "btnReadEndPoint";
            this.btnReadEndPoint.Size = new System.Drawing.Size(66, 52);
            this.btnReadEndPoint.TabIndex = 12;
            this.btnReadEndPoint.Text = "读取调高器终止点";
            this.btnReadEndPoint.UseVisualStyleBackColor = false;
            this.btnReadEndPoint.Click += new System.EventHandler(this.btnReadEndPoint_Click);
            // 
            // btnStopCaliing
            // 
            this.btnStopCaliing.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStopCaliing.Location = new System.Drawing.Point(210, 19);
            this.btnStopCaliing.Name = "btnStopCaliing";
            this.btnStopCaliing.Size = new System.Drawing.Size(66, 52);
            this.btnStopCaliing.TabIndex = 13;
            this.btnStopCaliing.Text = "终止标定";
            this.btnStopCaliing.UseVisualStyleBackColor = false;
            this.btnStopCaliing.Click += new System.EventHandler(this.btnStopCaliing_Click);
            // 
            // Log
            // 
            this.Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Log.ForeColor = System.Drawing.SystemColors.Control;
            this.Log.Location = new System.Drawing.Point(6, 601);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log.Size = new System.Drawing.Size(282, 223);
            this.Log.TabIndex = 5;
            // 
            // groupBoxGlobalPara
            // 
            this.groupBoxGlobalPara.Controls.Add(this.labelTGQSensorDist);
            this.groupBoxGlobalPara.Controls.Add(this.lineTGQSensorDist);
            this.groupBoxGlobalPara.Controls.Add(this.labelTGQTotalTravel);
            this.groupBoxGlobalPara.Controls.Add(this.lineTGQTotalTravel);
            this.groupBoxGlobalPara.Controls.Add(this.labelTGQMesaDist);
            this.groupBoxGlobalPara.Controls.Add(this.lineTGQMesaDist);
            this.groupBoxGlobalPara.Controls.Add(this.textEndPos);
            this.groupBoxGlobalPara.Controls.Add(this.textStartPos);
            this.groupBoxGlobalPara.Controls.Add(this.labelEndPos);
            this.groupBoxGlobalPara.Controls.Add(this.labelStartPos);
            this.groupBoxGlobalPara.Controls.Add(this.labelActualDist);
            this.groupBoxGlobalPara.Controls.Add(this.lineActualDist);
            this.groupBoxGlobalPara.Controls.Add(this.lableOptViewDist);
            this.groupBoxGlobalPara.Controls.Add(this.lineOptViewDist);
            this.groupBoxGlobalPara.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBoxGlobalPara.Location = new System.Drawing.Point(6, 35);
            this.groupBoxGlobalPara.Name = "groupBoxGlobalPara";
            this.groupBoxGlobalPara.Size = new System.Drawing.Size(282, 195);
            this.groupBoxGlobalPara.TabIndex = 0;
            this.groupBoxGlobalPara.TabStop = false;
            this.groupBoxGlobalPara.Text = "全局参数（单位：mm）";
            // 
            // labelTGQSensorDist
            // 
            this.labelTGQSensorDist.AutoSize = true;
            this.labelTGQSensorDist.Location = new System.Drawing.Point(6, 79);
            this.labelTGQSensorDist.Name = "labelTGQSensorDist";
            this.labelTGQSensorDist.Size = new System.Drawing.Size(140, 17);
            this.labelTGQSensorDist.TabIndex = 16;
            this.labelTGQSensorDist.Text = "调高器当前距寻缝器距离";
            this.labelTGQSensorDist.Visible = false;
            // 
            // lineTGQSensorDist
            // 
            this.lineTGQSensorDist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineTGQSensorDist.DecimalPlaces = 2;
            this.lineTGQSensorDist.ForeColor = System.Drawing.SystemColors.Control;
            this.lineTGQSensorDist.Location = new System.Drawing.Point(159, 77);
            this.lineTGQSensorDist.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.lineTGQSensorDist.Name = "lineTGQSensorDist";
            this.lineTGQSensorDist.Size = new System.Drawing.Size(105, 23);
            this.lineTGQSensorDist.TabIndex = 15;
            this.lineTGQSensorDist.Value = new decimal(new int[] {
            8311,
            0,
            0,
            131072});
            this.lineTGQSensorDist.Visible = false;
            // 
            // labelTGQTotalTravel
            // 
            this.labelTGQTotalTravel.AutoSize = true;
            this.labelTGQTotalTravel.Location = new System.Drawing.Point(6, 21);
            this.labelTGQTotalTravel.Name = "labelTGQTotalTravel";
            this.labelTGQTotalTravel.Size = new System.Drawing.Size(80, 17);
            this.labelTGQTotalTravel.TabIndex = 14;
            this.labelTGQTotalTravel.Text = "调高器总行程";
            this.labelTGQTotalTravel.Visible = false;
            // 
            // lineTGQTotalTravel
            // 
            this.lineTGQTotalTravel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineTGQTotalTravel.DecimalPlaces = 2;
            this.lineTGQTotalTravel.ForeColor = System.Drawing.SystemColors.Control;
            this.lineTGQTotalTravel.Location = new System.Drawing.Point(159, 19);
            this.lineTGQTotalTravel.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.lineTGQTotalTravel.Name = "lineTGQTotalTravel";
            this.lineTGQTotalTravel.Size = new System.Drawing.Size(105, 23);
            this.lineTGQTotalTravel.TabIndex = 13;
            this.lineTGQTotalTravel.Value = new decimal(new int[] {
            88935,
            0,
            0,
            131072});
            this.lineTGQTotalTravel.Visible = false;
            // 
            // labelTGQMesaDist
            // 
            this.labelTGQMesaDist.AutoSize = true;
            this.labelTGQMesaDist.Location = new System.Drawing.Point(6, 50);
            this.labelTGQMesaDist.Name = "labelTGQMesaDist";
            this.labelTGQMesaDist.Size = new System.Drawing.Size(140, 17);
            this.labelTGQMesaDist.TabIndex = 12;
            this.labelTGQMesaDist.Text = "调高器下限位距台面距离";
            this.labelTGQMesaDist.Visible = false;
            // 
            // lineTGQMesaDist
            // 
            this.lineTGQMesaDist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineTGQMesaDist.DecimalPlaces = 2;
            this.lineTGQMesaDist.ForeColor = System.Drawing.SystemColors.Control;
            this.lineTGQMesaDist.Location = new System.Drawing.Point(159, 48);
            this.lineTGQMesaDist.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.lineTGQMesaDist.Name = "lineTGQMesaDist";
            this.lineTGQMesaDist.Size = new System.Drawing.Size(105, 23);
            this.lineTGQMesaDist.TabIndex = 11;
            this.lineTGQMesaDist.Value = new decimal(new int[] {
            16271,
            0,
            0,
            131072});
            this.lineTGQMesaDist.Visible = false;
            // 
            // textEndPos
            // 
            this.textEndPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textEndPos.ForeColor = System.Drawing.SystemColors.Control;
            this.textEndPos.Location = new System.Drawing.Point(204, 165);
            this.textEndPos.Name = "textEndPos";
            this.textEndPos.ReadOnly = true;
            this.textEndPos.Size = new System.Drawing.Size(60, 23);
            this.textEndPos.TabIndex = 10;
            // 
            // textStartPos
            // 
            this.textStartPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textStartPos.ForeColor = System.Drawing.SystemColors.Control;
            this.textStartPos.Location = new System.Drawing.Point(74, 165);
            this.textStartPos.Name = "textStartPos";
            this.textStartPos.ReadOnly = true;
            this.textStartPos.Size = new System.Drawing.Size(60, 23);
            this.textStartPos.TabIndex = 9;
            // 
            // labelEndPos
            // 
            this.labelEndPos.AutoSize = true;
            this.labelEndPos.Location = new System.Drawing.Point(136, 168);
            this.labelEndPos.Name = "labelEndPos";
            this.labelEndPos.Size = new System.Drawing.Size(68, 17);
            this.labelEndPos.TabIndex = 8;
            this.labelEndPos.Text = "调高器终点";
            // 
            // labelStartPos
            // 
            this.labelStartPos.AutoSize = true;
            this.labelStartPos.Location = new System.Drawing.Point(6, 168);
            this.labelStartPos.Name = "labelStartPos";
            this.labelStartPos.Size = new System.Drawing.Size(68, 17);
            this.labelStartPos.TabIndex = 6;
            this.labelStartPos.Text = "调高器起点";
            // 
            // labelActualDist
            // 
            this.labelActualDist.AutoSize = true;
            this.labelActualDist.Location = new System.Drawing.Point(6, 137);
            this.labelActualDist.Name = "labelActualDist";
            this.labelActualDist.Size = new System.Drawing.Size(80, 17);
            this.labelActualDist.TabIndex = 4;
            this.labelActualDist.Text = "角点实际宽度";
            // 
            // lineActualDist
            // 
            this.lineActualDist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineActualDist.DecimalPlaces = 2;
            this.lineActualDist.ForeColor = System.Drawing.SystemColors.Control;
            this.lineActualDist.Location = new System.Drawing.Point(159, 135);
            this.lineActualDist.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.lineActualDist.Name = "lineActualDist";
            this.lineActualDist.Size = new System.Drawing.Size(105, 23);
            this.lineActualDist.TabIndex = 3;
            // 
            // lableOptViewDist
            // 
            this.lableOptViewDist.AutoSize = true;
            this.lableOptViewDist.Location = new System.Drawing.Point(6, 108);
            this.lableOptViewDist.Name = "lableOptViewDist";
            this.lableOptViewDist.Size = new System.Drawing.Size(86, 17);
            this.lableOptViewDist.TabIndex = 2;
            this.lableOptViewDist.Text = "最佳视距(Abs)";
            // 
            // lineOptViewDist
            // 
            this.lineOptViewDist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lineOptViewDist.DecimalPlaces = 2;
            this.lineOptViewDist.ForeColor = System.Drawing.SystemColors.Control;
            this.lineOptViewDist.Location = new System.Drawing.Point(159, 106);
            this.lineOptViewDist.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.lineOptViewDist.Name = "lineOptViewDist";
            this.lineOptViewDist.Size = new System.Drawing.Size(105, 23);
            this.lineOptViewDist.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.高级设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(300, 25);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 高级设置ToolStripMenuItem
            // 
            this.高级设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExpertMode});
            this.高级设置ToolStripMenuItem.Name = "高级设置ToolStripMenuItem";
            this.高级设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.高级设置ToolStripMenuItem.Text = "高级设置";
            // 
            // menuExpertMode
            // 
            this.menuExpertMode.Name = "menuExpertMode";
            this.menuExpertMode.Size = new System.Drawing.Size(124, 22);
            this.menuExpertMode.Text = "专家模式";
            this.menuExpertMode.Click += new System.EventHandler(this.menuExpertMode_Click);
            // 
            // pnlMainFrom
            // 
            this.pnlMainFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainFrom.Location = new System.Drawing.Point(0, 0);
            this.pnlMainFrom.Name = "pnlMainFrom";
            this.pnlMainFrom.Size = new System.Drawing.Size(921, 831);
            this.pnlMainFrom.TabIndex = 1;
            this.pnlMainFrom.SizeChanged += new System.EventHandler(this.pnlMainFrom_SizeChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1221, 831);
            this.Controls.Add(this.pnlMainFrom);
            this.Controls.Add(this.pnlOperator);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "AutoInterParaCaliForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlOperator.ResumeLayout(false);
            this.pnlOperator.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxGlobalPara.ResumeLayout(false);
            this.groupBoxGlobalPara.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineTGQSensorDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineTGQTotalTravel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineTGQMesaDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineActualDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineOptViewDist)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOperator;
        private System.Windows.Forms.Panel pnlMainFrom;
        private System.Windows.Forms.GroupBox groupBoxGlobalPara;
        private System.Windows.Forms.Label labelActualDist;
        private System.Windows.Forms.NumericUpDown lineActualDist;
        private System.Windows.Forms.Label lableOptViewDist;
        private System.Windows.Forms.NumericUpDown lineOptViewDist;
        private System.Windows.Forms.Button btnCalMat;
        private System.Windows.Forms.Button btnParaEdit;
        private System.Windows.Forms.Label labelStartPos;
        private System.Windows.Forms.Label labelEndPos;
        private System.Windows.Forms.TextBox textEndPos;
        private System.Windows.Forms.TextBox textStartPos;
        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.Timer timerUpdateFrm;
        private System.Windows.Forms.Button btnReadEndPoint;
        private System.Windows.Forms.Button btnReadStartPoint;
        private System.Windows.Forms.Button btnStopCaliing;
        private System.Windows.Forms.TextBox textShowIsCaliing;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnReadOptViewDist;
        private System.Windows.Forms.Label labelTGQTotalTravel;
        private System.Windows.Forms.NumericUpDown lineTGQTotalTravel;
        private System.Windows.Forms.Label labelTGQMesaDist;
        private System.Windows.Forms.NumericUpDown lineTGQMesaDist;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnOpenCloseLaser;
        private System.Windows.Forms.ComboBox cbbLaserHoldSpacePercent;
        private System.Windows.Forms.Label labelLaserHoldSpacePercent;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnErrorVerify;
        private System.Windows.Forms.Button btnAutoInterParaCali;
        private System.Windows.Forms.Button btnStopChecking;
        private System.Windows.Forms.TextBox textShowIsChecking;
        private System.Windows.Forms.Button btnBanDisplaySomeLog;
        private System.Windows.Forms.Label labelTGQSensorDist;
        private System.Windows.Forms.NumericUpDown lineTGQSensorDist;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 高级设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuExpertMode;
    }
}

