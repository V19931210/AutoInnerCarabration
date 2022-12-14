using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace weldDeviceProduct
{

    public partial class frmMain : Form
    {
        private static readonly Mutex mutex = new Mutex();//多线程情况下保证线程安全

        private static frmParaEdit frm2;//参数编辑界面
        private static frmExpert frm3;//专家模式验证密码界面

        //WeldTrack和BCS100
        private Process proWeldTrack;
        private IntPtr weldFormHandle = new IntPtr(0);
        private long mInitialWindowLong;
        private Process proBCS100;

        public static Socket sensorSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static Socket heightSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public static int id = 1000;//用于给寻缝器发指令的id
        public static JsonSerializerSettings jsonSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };//忽略结构体空值字段

        private double optViewDist;//记录最佳视距
        private double actualDist;//记录角点实际宽度
        private double[][] cornerPoints;//记录采集的标定数据
        private bool isGettingHeight = false;//标记是否处于获取调高器高度过程中
        private bool isCaliing = false;//标记是否处于自动标定过程中
        private bool isCaliSuccess = false;//标记标定完成后计算矩阵的误差是否满足要求
        private bool isAutoAdjustOptViewing = false;
        public static string start_time;//标定开始时间
        public static string end_time;//标定结束时间
        public static string testDetail;
        public static string errorDetail;

        private bool isErrorChecking = false;//标记是否处于误差验证过程中
        private double[][] errorVerifyPoints;//记录采集的误差验证数据

        private const int GWL_STYLE = (-16);
        private const long WS_CAPTION = 0xC00000;
        private const long WS_BORDER = 0x800000;
        private const long WS_THICKFRAME = 0x00040000;
        private const long WS_CHILDWINDOW = 0x40000000;
        private const uint WM_SYSCOMMAND = 0x0112;
        private const uint SC_CLOSE = 0xF060;

        [DllImport("USER32.DLL")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SetParent")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);   //将外部窗体嵌入程序

        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);                  //设置窗体属性

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, long dwNewLong);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern long GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]

        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", EntryPoint = "PostMessage")]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, uint wParam, uint lParam);

        /// <summary>
        /// 去除窗体边框
        /// </summary>
        /// <param name="vHandle">窗口句柄</param>
        public static void RemoveWindowBorder(IntPtr vHandle)
        {
            const int GWL_STYLE = (-16);
            const int WS_CAPTION = 0xC00000;
            const int WS_BORDER = 0x800000;
            const int WS_THICKFRAME = 0x00040000;
            const int WS_CHILDWINDOW = 0x40000000;

            long LStyle = GetWindowLong(vHandle, GWL_STYLE);

            LStyle = (LStyle & (~WS_CAPTION) & (~WS_BORDER) & (~WS_THICKFRAME)) | WS_CHILDWINDOW;
            SetWindowLong(vHandle, GWL_STYLE, LStyle);
        }

        /// <summary>
        /// 调整第三方应用窗体大小
        /// </summary>
        public void ResizeWindow()
        {
            ShowWindow(weldFormHandle, 0);  //先将窗口隐藏
            ShowWindow(weldFormHandle, 3);  //再将窗口最大化，可以让第三方窗口自适应容器的大小
        }

        void timerUpdateFrm_Tick(object sender, EventArgs e)
        {
            //第三方窗体句柄不为空
            if (weldFormHandle != IntPtr.Zero)
            {
                System.Threading.Thread t = new System.Threading.Thread(ResizeWindow);
                t.Start();  //开线程刷新第三方窗体大小
                System.Threading.Thread.Sleep(50); //略加延时
                timerUpdateFrm.Stop();  //停止定时器
            }
        }

        public frmMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            timerUpdateFrm.Tick += new EventHandler(timerUpdateFrm_Tick);  //绑定事件
            timerUpdateFrm.Interval = 200;

            //设置超时时间
            sensorSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 2000);
            heightSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 5000);

            cornerPoints = new double[10][];
            for (int i = 0; i < cornerPoints.Length; i++)
            {
                cornerPoints[i] = new double[5];
            }

            errorVerifyPoints = new double[3][];
            for (int i = 0; i < errorVerifyPoints.Length; i++)
            {
                errorVerifyPoints[i] = new double[5];
            }
            frm2 = new frmParaEdit(this);
            frm3 = new frmExpert();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //打开BCVWeldTrack.exe
            Process[] proWeldTrackArr = Process.GetProcessesByName("BCVWeldTrack");
            if (proWeldTrackArr.Length > 0)
            {
                proWeldTrack = proWeldTrackArr[0];
            }
            else
            {
                try
                {
                    proWeldTrack = new Process();
                    proWeldTrack.StartInfo.FileName = "C:\\Program Files (x86)\\Friendess\\BCVWeldTrack\\BCVWeldTrack.exe";
                    proWeldTrack.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    proWeldTrack.Start();
                }
                catch (Exception ex)
                {
                    AddLogWithTime("启动寻缝器软件失败!");
                    MessageBox.Show(ex.Message);
                }
            }

            //查找BCVWeldTrack.exe主窗口窗口句柄
            for (int i = 0; i < 30; i++)
            {
                weldFormHandle = FindWindow(null, "BCVWeldTrackMainForm");
                if (weldFormHandle != IntPtr.Zero)
                {
                    //MessageBox.Show("Find BCVWeldTrackMainForm!");
                    mInitialWindowLong = GetWindowLong(weldFormHandle, GWL_STYLE);
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(100);
                }
            }

            if (weldFormHandle == IntPtr.Zero)
            {
                MessageBox.Show("Not Find BCVWeldTrackMainForm!");
            }

            Thread.Sleep(1000);

            RemoveWindowBorder(weldFormHandle);  //移除边框
            SetParent(weldFormHandle, pnlMainFrom.Handle); //嵌入父容器
            ShowWindowAsync(weldFormHandle, 3);   //显示

            //打开BCS100APP.exe
            Process[] proBCS100Arr = Process.GetProcessesByName("BCS100APP");
            if (proBCS100Arr.Length > 0)
            {
                proBCS100 = proBCS100Arr[0];
            }
            else
            {
                try
                {
                    proBCS100 = new Process();
                    proBCS100.StartInfo.FileName = "C:\\Program Files (x86)\\Friendess\\BCVWeldTrack\\BCS100APP.exe";
                    proBCS100.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    proBCS100.Start();
                }
                catch (Exception ex)
                {
                    AddLogWithTime("启动调高器测试软件失败!");
                    MessageBox.Show(ex.Message);
                }
            }

            //连接寻缝器软件
            try
            {
                sensorSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5020));
            }
            catch (Exception ex)
            {
                AddLogWithTime("连接寻缝器失败!");
                MessageBox.Show(ex.Message);
            }

            //连接调高器软件
            try
            {
                heightSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 60001));
            }
            catch (Exception ex)
            {
                AddLogWithTime("连接调高器测试软件失败!");
                MessageBox.Show(ex.Message);
            }

            BanDisplaySomeLog();//屏蔽某些日志
            setParamBool("NeedPrintPlateWeldInfo", true);
            openCloseLaser();//打开激光
            cbbLaserHoldSpacePercent.SelectedIndex = 0;//设置默认激光占空比100%
            //tttest();
        }

        private void tttest()
        {
            btnAutoInterParaCali.Enabled = true;
            textStartPos.Text = "100";
            textEndPos.Text = "200";
            lineOptViewDist.Text = "505";
            start_time = "2022 - 11 - 24 09:57:42";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread.Sleep(100);

            //关闭激光
            openCloseLaser();

            sensorSocket.Close();
            heightSocket.Close();

            Process[] proWeldTrackArr = Process.GetProcessesByName("BCVWeldTrack");
            if (proWeldTrackArr.Length > 0)
            {
                SetWindowLong(weldFormHandle, GWL_STYLE, (uint)mInitialWindowLong);
                SetParent(weldFormHandle, IntPtr.Zero);
                PostMessage(weldFormHandle, WM_SYSCOMMAND, SC_CLOSE, 0);
                weldFormHandle = IntPtr.Zero;

                //proWeldTrackArr[0].Kill();
            }

            Process[] proBCS100Arr = Process.GetProcessesByName("BCS100APP");
            if (proBCS100Arr.Length > 0)
            {
                proBCS100Arr[0].Kill();
            }

        }

        private void pnlMainFrom_SizeChanged(object sender, EventArgs e)
        {
            timerUpdateFrm.Start();
        }

        //给寻缝器发指令
        public static bool sendCmdToSensor(ModelWeldTrack req, ref ModelWeldTrack resp)
        {
            id++;
            string sensor_input = JsonConvert.SerializeObject(req, jsonSetting);
            byte[] sensor_send_buf = Encoding.UTF8.GetBytes(sensor_input + "#Vision");
            sensorSocket.Send(sensor_send_buf);
            Console.WriteLine(sensor_input);

            byte[] sensor_recv_buf = new byte[1024];
            int len = sensorSocket.Receive(sensor_recv_buf);

            if (len > 0)
            {
                string msg = Encoding.UTF8.GetString(sensor_recv_buf);
                string[] jsonStrings = msg.Split('#');
                resp = JsonConvert.DeserializeObject<ModelWeldTrack>(jsonStrings[0]);
                Console.WriteLine(msg);
                return true;
            }

            return false;
        }

        //给调高器发指令
        private static bool sendCmdToHeight(ModelHeightAdjust req, ref ModelHeightAdjust resp)
        {
            string height_input = JsonConvert.SerializeObject(req, jsonSetting);
            byte[] hright_send_buf = Encoding.UTF8.GetBytes(height_input + "#Height");
            heightSocket.Send(hright_send_buf);
            //Console.WriteLine(height_input);

            byte[] height_recv_buf = new byte[1024];
            int len = heightSocket.Receive(height_recv_buf);

            if (len > 0)
            {
                string msg = Encoding.UTF8.GetString(height_recv_buf);
                string[] jsonStrings = msg.Split('#');
                resp = JsonConvert.DeserializeObject<ModelHeightAdjust>(jsonStrings[0]);
                //Console.WriteLine(msg);
                return true;
            }

            return false;
        }

        private bool sendHeight(ModelHeightAdjust req, ref ModelHeightAdjust resp)
        {
            bool flag = false;
            mutex.WaitOne();
            if (isGettingHeight)
            {
                mutex.ReleaseMutex();
                MessageBox.Show("获取调高器高度正在进行，请勿重复点击!");
                return false;
            }
            isGettingHeight = true;
            mutex.ReleaseMutex();

            try
            {
                if (!sendCmdToHeight(req, ref resp))
                {
                    AddLogWithTime("未接收到调高器返回数据!");
                    goto Label;
                }
                if (resp.CMDID == HeightAdjustState.HeightFailedConnect)
                {
                    AddLogWithTime("连接调高器失败!");
                    goto Label;
                }
                else
                {
                    flag = true;
                    goto Label;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        Label:
            mutex.WaitOne();
            isGettingHeight = false;
            mutex.ReleaseMutex();

            return flag;
        }

        public bool sendSensor(ModelWeldTrack req, ref ModelWeldTrack resp)
        {
            bool flag = false;

            try
            {
                if (!sendCmdToSensor(req, ref resp))
                {
                    AddLogWithTime("未接收到寻缝器返回数据!");
                    goto Label;
                }

                if (resp.Result != "true")
                {
                    AddLogWithTime($"指令{req.Cmd}执行失败!");
                    goto Label;
                }
                else
                {
                    flag = true;
                    //AddLogWithTime($"指令{req.Cmd}执行成功!");
                    goto Label;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        Label:
            return flag;
        }

        private bool isWorking()
        {
            if (isCaliing)
            {
                MessageBox.Show("自动标定正在进行，请勿进行其他操作!");
                return true;
            }
            if (isAutoAdjustOptViewing)
            {
                MessageBox.Show("自动调整最佳视距正在进行，请勿进行其他操作!");
                return true;
            }
            if (isErrorChecking)
            {
                MessageBox.Show("误差验证正在进行，请勿进行其他操作!");
                return true;
            }
            return false;
        }

        private bool setParamBool(String aKey, bool aFlag)
        {
            ModelWeldTrack req = new ModelWeldTrack(WeldTrackCMD.SetMapPara, ref id) { Key = aKey, Value = aFlag };
            ModelWeldTrack resp = new ModelWeldTrack();
            return sendSensor(req, ref resp);
        }

        private void btnOpenCloseLaser_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(openCloseLaser);
            t.IsBackground = true;
            t.Start();
        }

        private void openCloseLaser()
        {
            ModelWeldTrack req = new ModelWeldTrack(WeldTrackCMD.SwitchLaserStatus, ref id);
            ModelWeldTrack resp = new ModelWeldTrack();
            sendSensor(req, ref resp);
        }

        private void cbbLaserHoldSpacePercent_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread t = new Thread(setLaserHoldSpacePercent);
            t.IsBackground = true;
            t.Start();
        }

        private void setLaserHoldSpacePercent()
        {
            int dutyCycle = Convert.ToInt32(cbbLaserHoldSpacePercent.SelectedItem);
            ModelWeldTrack req = new ModelWeldTrack(WeldTrackCMD.SetLaserDutyCircle, ref id) { DutyCycle = dutyCycle };
            ModelWeldTrack resp = new ModelWeldTrack();
            sendSensor(req, ref resp);
        }

        private void btnReadOptViewDist_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(autoAdjustOptView);
            t.IsBackground = true;
            t.Start();
        }

        private void autoAdjustOptView()
        {
            if (!isOptViewParaAllRight())
            {
                return;
            }

            mutex.WaitOne();
            if (isWorking())
            {
                mutex.ReleaseMutex();
                return;
            }
            isAutoAdjustOptViewing = true;
            mutex.ReleaseMutex();

            AddLogWithTime("开始自动调整最佳视距");
            bool isAdjustDone = true;

            //根据当前位置 二分往中线移动 不停迭代
            double mid = 0, y0 = 0, y = 0, h0 = 0, h = 0;
            //获取中线位置
            ModelWeldTrack req_mid = new ModelWeldTrack(WeldTrackCMD.GetImageSize, ref frmMain.id);
            ModelWeldTrack resp_mid = new ModelWeldTrack();
            if (!sendSensor(req_mid, ref resp_mid))
            {
                isAdjustDone = false;
                goto Label;
            }
            mid = (double)resp_mid.Height / 2;
            //获取初始h0
            ModelHeightAdjust req_h = new ModelHeightAdjust(HeightAdjustState.HeightGet);
            ModelHeightAdjust resp_h = new ModelHeightAdjust();
            if (!sendHeight(req_h, ref resp_h))
            {
                isAdjustDone = false;
                goto Label;
            }
            h0 = resp_h.Zpos;
            //获取初始y0
            ModelWeldTrack req_y = new ModelWeldTrack(WeldTrackCMD.GetCurCoordinate, ref frmMain.id);
            ModelWeldTrack resp_y = new ModelWeldTrack();
            if (!sendSensor(req_y, ref resp_y))
            {
                isAdjustDone = false;
                goto Label;
            }
            y0 = (double)resp_y.Y;

            //调高器往任意方向移动10mm，注意不要超出调高器限程
            if (h0 + 10 >= 500)
            {
                h = h0 - 10;
            }
            else
            {
                h = h0 + 10;
            }
            if (!moveToHeight(h))
            {
                isAdjustDone = false;
                goto Label;
            }

            Thread.Sleep(1000);
            //获取当前y
            if (!sendSensor(req_y, ref resp_y))
            {
                isAdjustDone = false;
                goto Label;
            }
            y = (double)resp_y.Y;

            while (Math.Abs(y - mid) >= 1)
            {
                if (Math.Abs(y - y0) < 0.1)
                {
                    isAdjustDone = false;
                    break;
                }
                //计算理论h值 移动至该h处
                double hh = (h - h0) / (y - y0) * (mid - y) + h;
                if (!moveToHeight(hh))
                {
                    isAdjustDone = false;
                    goto Label;
                }

                h0 = h;
                h = hh;
                y0 = y;

                Thread.Sleep(1000);
                //获取当前y
                if (!sendSensor(req_y, ref resp_y))
                {
                    isAdjustDone = false;
                    goto Label;
                }
                y = (double)resp_y.Y;
            }

        Label:
            if (!isAdjustDone)
            {
                AddLogWithTime("自动调整最佳视距失败!");
            }
            else
            {
                AddLogWithTime("自动调整最佳视距完成!");
                double opt_view = Convert.ToDouble(lineTGQTotalTravel.Value + lineTGQMesaDist.Value - lineTGQSensorDist.Value) - h;
                lineOptViewDist.Text = opt_view.ToString();
            }
            mutex.WaitOne();
            isAutoAdjustOptViewing = false;
            mutex.ReleaseMutex();
        }

        private void btnReadStartPoint_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(readStartPoint);
            t.IsBackground = true;
            t.Start();
        }

        private void readStartPoint()
        {
            ModelHeightAdjust req = new ModelHeightAdjust(HeightAdjustState.HeightGet);
            ModelHeightAdjust resp = new ModelHeightAdjust();
            if (sendHeight(req, ref resp))
            {
                textStartPos.Text = resp.Zpos.ToString();
                btnReadEndPoint.Enabled = true;
            }
        }

        private void btnReadEndPoint_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(readEndPoint);
            t.IsBackground = true;
            t.Start();
        }

        private void readEndPoint()
        {
            ModelHeightAdjust req = new ModelHeightAdjust(HeightAdjustState.HeightGet);
            ModelHeightAdjust resp = new ModelHeightAdjust();
            if (sendHeight(req, ref resp))
            {
                textEndPos.Text = resp.Zpos.ToString();
                btnAutoInterParaCali.Enabled = true;
                btnErrorVerify.Enabled = true;
            }
        }

        private string getServerTime()
        {
            GetServerDateTimeResp resp = new GetServerDateTimeResp();
            try
            {
                MESApi.GetServerDateTime(ref resp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

            if (!resp.success)
            {
                AddLogWithTime("获取MES服务器时间失败");
                return null;
            }
            AddLogWithTime("获取MES服务器时间成功");
            return resp.result;
        }

        private bool moveToHeight(double h)
        {
            ModelHeightAdjust prevZ_resp = new ModelHeightAdjust() { Zpos = -10000 };
            ModelHeightAdjust move_req = new ModelHeightAdjust(HeightAdjustState.HeightMove, h);
            ModelHeightAdjust move_resp = new ModelHeightAdjust();
            if (!sendHeight(move_req, ref move_resp))
            {
                AddLogWithTime("移动验证过程中调高器移动失败!");
                return false;
            }

            //稍许等待让调高器运动 然后验证调高器是否到位
            Thread.Sleep(500);

            ModelHeightAdjust height_req = new ModelHeightAdjust(HeightAdjustState.HeightGet);
            ModelHeightAdjust curZ_resp = new ModelHeightAdjust();
            if (!sendHeight(height_req, ref curZ_resp))
            {
                AddLogWithTime("移动验证过程中调高器获取高度失败!");
                return false;
            }

            //判断调高器是否到达指定位置或一直到不了指定位置
            while (Math.Abs(curZ_resp.Zpos - h) > 0.08)
            {
                Thread.Sleep(250);
                if (!sendHeight(height_req, ref curZ_resp))
                {
                    AddLogWithTime("移动验证过程中调高器获取高度失败!");
                    return false;
                }
                if (Math.Abs(curZ_resp.Zpos - prevZ_resp.Zpos) < 0.04)
                {
                    AddLogWithTime("调高器无法运动到指定位置!");
                    return false;
                }
                prevZ_resp.Zpos = curZ_resp.Zpos;
            }

            return true;
        }

        private void btnAutoInterParaCali_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(autoInterParaCali);
            t.IsBackground = true;
            t.Start();
        }

        private void autoInterParaCali()
        {
            //验证全局参数合法性
            if (!isCaliParaAllRight())
            {
                return;
            }

            MessageBoxButtons msgButton = MessageBoxButtons.OKCancel;
            DialogResult res = MessageBox.Show("请确保图像中仅有两个角点且大致平均分布在左右两侧!!!", "Attention!", msgButton);
            if (res != DialogResult.OK)
            {
                return;
            }

            mutex.WaitOne();
            if (isWorking())
            {
                mutex.ReleaseMutex();
                return;
            }
            isCaliing = true;
            textShowIsCaliing.Text = "正在自动标定中...";
            mutex.ReleaseMutex();

            AddLogWithTime("开始自动标定");
            bool isCaliDone = true;//10组标定过程是否全部完成

            //记录开始标定的时间
            start_time = getServerTime();
            for (int i = 0; i < 5; i++)
            {
                if (start_time == null)
                {
                    Thread.Sleep(1000);
                    start_time = getServerTime();
                }
                else
                {
                    break;
                }
            }
            if (start_time == null)
            {
                AddLogWithTime("记录开始标定时间失败!");
                isCaliDone = false;
                goto Label;
            }

            //计算调高器步进距离
            double endPos = Convert.ToDouble(textEndPos.Text.ToString());
            double startPos = Convert.ToDouble(textStartPos.Text.ToString());
            double stepDist = (endPos - startPos) / 9;

            //获取图像尺寸 设置左右检测区域范围
            ModelWeldTrack image_req = new ModelWeldTrack(WeldTrackCMD.GetImageSize, ref id);
            ModelWeldTrack image_resp = new ModelWeldTrack();
            ModelWeldTrack detect_left_req = new ModelWeldTrack(WeldTrackCMD.SetDetectArea, ref id);
            ModelWeldTrack detect_right_req = new ModelWeldTrack(WeldTrackCMD.SetDetectArea, ref id);
            ModelWeldTrack detect_resp = new ModelWeldTrack();
            if (!sendSensor(image_req, ref image_resp))
            {
                isCaliDone = false;
                goto Label;
            }
            else
            {
                detect_left_req.X = 10;
                detect_left_req.Y = 10;
                detect_left_req.Width = image_resp.Width / 2 - 20;
                detect_left_req.Height = image_resp.Height - 20;
                detect_right_req.X = image_resp.Width / 2 + 10;
                detect_right_req.Y = 10;
                detect_right_req.Width = image_resp.Width / 2 - 20;
                detect_right_req.Height = image_resp.Height - 20;
            }

            //获取10组数据
            int cnt = cornerPoints.Length;
            testDetail = "";
            while (isCaliing && cnt-- > 0)
            {
                //控制调高器移动到cornerPoint[cnt]
                cornerPoints[cnt][0] = endPos - stepDist * (9 - cnt);
                if (!moveToHeight(cornerPoints[cnt][0]))
                {
                    isCaliDone = false;
                    break;
                }

                //调高器运动到位之后等待一定时间再取角点
                //Thread.Sleep(1500);

                //设置左侧检测区域
                if (!sendSensor(detect_left_req, ref detect_resp))
                {
                    AddLogWithTime($"第{10 - cnt}组标定设置左侧检测区域失败，标定终止!");
                    isCaliDone = false;
                    break;
                }

                //设置完检测区域后等待一定时间再取点
                Thread.Sleep(1500);

                //获取左侧寻缝器角点坐标
                bool isGetPoint_left = false;
                ModelWeldTrack coord_req = new ModelWeldTrack(WeldTrackCMD.GetCurCoordinate, ref id);
                ModelWeldTrack left_resp = new ModelWeldTrack();
                for (int j = 0; isCaliing && j < 5; j++)
                {
                    if (!sendSensor(coord_req, ref left_resp))
                    {
                        AddLogWithTime($"第{10 - cnt}组标定第{j + 1}次未捕获到左侧角点坐标");
                        Thread.Sleep(1000);
                        continue;
                    }
                    else
                    {
                        isGetPoint_left = true;
                        break;
                    }
                }

                if (!isGetPoint_left)
                {
                    isCaliDone = false;
                    break;
                }

                //设置右侧检测区域
                if (!sendSensor(detect_right_req, ref detect_resp))
                {
                    AddLogWithTime($"第{10 - cnt}组标定设置右侧检测区域失败，标定终止!");
                    isCaliDone = false;
                    break;
                }

                //设置完检测区域后等待一定时间再取点
                Thread.Sleep(1500);

                //获取右侧寻缝器角点坐标
                bool isGetPoint_right = false;
                ModelWeldTrack right_resp = new ModelWeldTrack();
                for (int j = 0; isCaliing && j < 5; j++)
                {
                    if (!sendSensor(coord_req, ref right_resp))
                    {
                        AddLogWithTime($"第{10 - cnt}组标定第{j + 1}次未捕获到右侧角点坐标");
                        Thread.Sleep(1000);
                        continue;
                    }
                    else
                    {
                        isGetPoint_right = true;
                        break;
                    }
                }

                if (!isGetPoint_right)
                {
                    isCaliDone = false;
                    break;
                }

                //保存该组数据
                cornerPoints[cnt][1] = (double)left_resp.X;
                cornerPoints[cnt][2] = (double)left_resp.Y;
                cornerPoints[cnt][3] = (double)right_resp.X;
                cornerPoints[cnt][4] = (double)right_resp.Y;

                //记录在testDetail中
                testDetail += $"0{10 - cnt}1:{cornerPoints[cnt][0]:F2},0{10 - cnt}2:{cornerPoints[cnt][1]:F2},0{10 - cnt}3:{cornerPoints[cnt][2]:F2},0{10 - cnt}4:{cornerPoints[cnt][3]:F2},0{10 - cnt}5:{cornerPoints[cnt][4]:F2}\r\n";

                AddLogWithTime($"第{10 - cnt}组标定数据获取成功!");
                AddLog($"调高器高度: {cornerPoints[cnt][0]:F2}");
                AddLog($"角点1X坐标: {cornerPoints[cnt][1]:F2}");
                AddLog($"角点1Y坐标: {cornerPoints[cnt][2]:F2}");
                AddLog($"角点2X坐标: {cornerPoints[cnt][3]:F2}");
                AddLog($"角点2Y坐标: {cornerPoints[cnt][4]:F2}");

            }

        Label:
            if (!isCaliing || !isCaliDone)
            {
                AddLogWithTime("自动标定失败!");
            }
            else
            {
                optViewDist = Convert.ToDouble(lineOptViewDist.Text);
                actualDist = Convert.ToDouble(lineActualDist.Text);
                AddLogWithTime("自动标定完成!");

                //记录标定结束时间
                end_time = getServerTime();
                for (int i = 0; i < 3; i++)
                {
                    if (end_time == null)
                    {
                        Thread.Sleep(1000);
                        end_time = getServerTime();
                    }
                    else
                    {
                        break;
                    }
                }

            }

            mutex.WaitOne();
            isCaliing = false;
            textShowIsCaliing.Text = "标定结束";
            mutex.ReleaseMutex();
        }

        private bool isCaliParaAllRight()
        {
            if (lineActualDist.Text == "" || lineActualDist.Value.Equals(0))
            {
                AddLogWithTime("未输入角点实际宽度或值为0!");
                return false;
            }
            if (String.IsNullOrEmpty(textStartPos.Text))
            {
                AddLogWithTime("未读取调高器起点!");
                return false;
            }
            if (String.IsNullOrEmpty(textEndPos.Text))
            {
                AddLogWithTime("未读取调高器终点!");
                return false;
            }

            return true;
        }

        private bool isOptViewParaAllRight()
        {
            if (lineTGQTotalTravel.Text == "" || lineTGQTotalTravel.Value.Equals(0))
            {
                AddLogWithTime("未输入调高器总行程或值为0!");
                return false;
            }
            if (lineTGQMesaDist.Text == "" || lineTGQMesaDist.Value.Equals(0))
            {
                AddLogWithTime("未输入调高器距台面距离或值为0!");
                return false;
            }
            if (lineTGQSensorDist.Text == "" || lineTGQSensorDist.Value.Equals(0))
            {
                AddLogWithTime("未输入调高器当前距寻缝器距离或值为0!");
                return false;
            }

            return true;
        }

        private void btnStopCaliing_Click(object sender, EventArgs e)
        {
            mutex.WaitOne();
            if (isCaliing)
            {
                isCaliing = false;
                textShowIsCaliing.Text = "正在终止标定...";
            }
            mutex.ReleaseMutex();
        }

        private void btnCalMat_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(calMat);
            t.IsBackground = true;
            t.Start();
        }

        private void calMat()
        {
            mutex.WaitOne();
            if (isWorking())
            {
                mutex.ReleaseMutex();
                return;
            }
            mutex.ReleaseMutex();

            //格式化指令为string字符串
            string sensor_send_str = "{\"Cmd\":12";
            sensor_send_str += ",\"Id\":" + Convert.ToString(id++);
            sensor_send_str += ",\"DataCnt\":10,\"MidZ\":" + Convert.ToString(optViewDist);
            for (int i = 0; i < cornerPoints.Length; i++)
            {
                sensor_send_str += ",\"LX" + i + "\":" + cornerPoints[i][1].ToString("0.00");
                sensor_send_str += ",\"LY" + i + "\":" + cornerPoints[i][2].ToString("0.00");
                sensor_send_str += ",\"RX" + i + "\":" + cornerPoints[i][3].ToString("0.00");
                sensor_send_str += ",\"RY" + i + "\":" + cornerPoints[i][4].ToString("0.00");
                sensor_send_str += ",\"Height" + i + "\":" + cornerPoints[i][0].ToString("0.00");
                sensor_send_str += ",\"Width" + i + "\":" + actualDist;
            }
            sensor_send_str += "}";

            ModelWeldTrack resp = new ModelWeldTrack();
            try
            {
                if (!sendCalMatToSensor(sensor_send_str, ref resp))
                {
                    AddLogWithTime("未接收到寻缝器返回数据!");
                    return;
                }

                if (resp.Result != "true")
                {
                    MessageBox.Show("计算内参矩阵失败!");
                    AddLogWithTime("计算内参矩阵失败!");
                    return;
                }
                else
                {
                    MessageBox.Show("计算内参矩阵成功!");
                    AddLogWithTime("计算内参成功!");

                    string detail = "";
                    detail += $"MinZ: {resp.MinZ:F2}\r\n";
                    detail += $"MidZ: {resp.MidZ:F2}\r\n";
                    detail += $"MaxZ: {resp.MaxZ:F2}\r\n";
                    detail += $"MinView: {resp.MinView:F2}\r\n";
                    detail += $"MidView: {resp.MidView:F2}\r\n";
                    detail += $"MaxView: {resp.MaxView:F2}\r\n";
                    detail += $"Dz: {resp.Dz:F2}\r\n";
                    detail += $"MeanError: {resp.MeanError:F2}\r\n";
                    detail += $"MeanZResolution: {resp.MeanZResolution:F2}\r\n";

                    testDetail += detail;
                    AddLog(detail);

                    string str = "";
                    if (resp.MeanError < 0.1 && resp.MeanZResolution < 0.3)
                    {
                        isCaliSuccess = true;
                        AddLogWithTime("平均误差符合要求!");
                        AddLogWithTime("Z向平均误差符合要求!");
                    }
                    else
                    {
                        isCaliSuccess = false;
                        if (resp.MeanError >= 0.1)
                        {
                            str += "平均误差不符合要求";
                            AddLogWithTime("平均误差不符合要求!");
                        }
                        if (resp.MeanZResolution >= 0.3)
                        {
                            str += ";Z向平均误差不符合要求";
                            AddLogWithTime("Z向平均误差不符合要求!");
                        }
                    }

                    //更新设备参数编辑界面
                    frm2.UpdateDevicePara(resp);
                    frm2.UpdateMESPara(isCaliSuccess, str);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private bool sendCalMatToSensor(string cmd, ref ModelWeldTrack resp)
        {
            //计算内参矩阵的指令发送格式不统一 单独用该函数处理
            byte[] sensor_send_buf = Encoding.UTF8.GetBytes(cmd + "#Vision");
            sensorSocket.Send(sensor_send_buf);

            byte[] sensor_recv_buf = new byte[1024];
            int len = sensorSocket.Receive(sensor_recv_buf);

            if (len > 0)
            {
                string msg = Encoding.UTF8.GetString(sensor_recv_buf);
                string[] jsonStrings = msg.Split('#');
                resp = JsonConvert.DeserializeObject<ModelWeldTrack>(jsonStrings[0]);
                return true;
            }

            return false;
        }

        private void btnErrorVerify_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(errorVerify);
            t.IsBackground = true;
            t.Start();
        }

        private void errorVerify()
        {
            //验证全局参数合法性
            if (!isCaliParaAllRight())
            {
                return;
            }

            mutex.WaitOne();
            if (isWorking())
            {
                mutex.ReleaseMutex();
                return;
            }
            isErrorChecking = true;
            textShowIsChecking.Text = "正在误差验证中...";
            mutex.ReleaseMutex();

            AddLogWithTime("开始误差验证");

            bool isCaliDone = true;//3组误差验证过程是否全部完成
            errorDetail = "";

            ModelWeldTrack req = new ModelWeldTrack(WeldTrackCMD.GetMechanicPara, ref frmMain.id);
            ModelWeldTrack resp = new ModelWeldTrack();
            if (!sendSensor(req, ref resp))
            {
                isCaliDone = false;
                goto Label;
            }
            string sn = resp.SN;
            errorDetail += $"SN:{sn}\r\n";

            //计算调高器步进距离
            double endPos = Convert.ToDouble(textEndPos.Text.ToString());
            double startPos = Convert.ToDouble(textStartPos.Text.ToString());
            double stepDist = (endPos - startPos) / 9;
            errorVerifyPoints[0][0] = startPos + 7.5 * stepDist;
            errorVerifyPoints[1][0] = startPos + 4.5 * stepDist;
            errorVerifyPoints[2][0] = startPos + 1.5 * stepDist;

            //获取图像尺寸 设置左右检测区域范围
            ModelWeldTrack image_req = new ModelWeldTrack(WeldTrackCMD.GetImageSize, ref id);
            ModelWeldTrack image_resp = new ModelWeldTrack();
            ModelWeldTrack detect_left_req = new ModelWeldTrack(WeldTrackCMD.SetDetectArea, ref id);
            ModelWeldTrack detect_right_req = new ModelWeldTrack(WeldTrackCMD.SetDetectArea, ref id);
            ModelWeldTrack detect_resp = new ModelWeldTrack();
            if (!sendSensor(image_req, ref image_resp))
            {
                isCaliDone = false;
                goto Label;
            }
            else
            {
                detect_left_req.X = 10;
                detect_left_req.Y = 10;
                detect_left_req.Width = image_resp.Width / 2 - 20;
                detect_left_req.Height = image_resp.Height - 20;
                detect_right_req.X = image_resp.Width / 2 + 10;
                detect_right_req.Y = 10;
                detect_right_req.Width = image_resp.Width / 2 - 20;
                detect_right_req.Height = image_resp.Height - 20;
            }

            //获取3组数据
            int cnt = errorVerifyPoints.Length;
            while (isErrorChecking && cnt-- > 0)
            {
                //控制调高器移动到errorVerifyPoints[cnt]
                if (!moveToHeight(errorVerifyPoints[cnt][0]))
                {
                    isCaliDone = false;
                    break;
                }

                //调高器运动到位之后等待一定时间再取角点
                //Thread.Sleep(1500);

                //设置左侧检测区域
                if (!sendSensor(detect_left_req, ref detect_resp))
                {
                    AddLogWithTime($"第{ 3 - cnt}组误差验证设置左侧检测区域失败，误差验证终止!");
                    isCaliDone = false;
                    break;
                }

                //设置完检测区域后等待一定时间再取点
                Thread.Sleep(1500);

                //获取左侧寻缝器相机坐标
                bool isGetPoint_left = false;
                ModelWeldTrack coord_req = new ModelWeldTrack(WeldTrackCMD.GetCameraPos, ref id);
                ModelWeldTrack left_resp = new ModelWeldTrack();
                for (int j = 0; isErrorChecking && j < 5; j++)
                {
                    if (!sendSensor(coord_req, ref left_resp))
                    {
                        AddLogWithTime($"第{3 - cnt}组误差验证第{j + 1}次未捕获到左侧相机坐标");
                        Thread.Sleep(1000);
                        continue;
                    }
                    else
                    {
                        isGetPoint_left = true;
                        break;
                    }
                }

                if (!isGetPoint_left)
                {
                    isCaliDone = false;
                    break;
                }

                //设置右侧检测区域
                if (!sendSensor(detect_right_req, ref detect_resp))
                {
                    AddLogWithTime($"第{3 - cnt}组误差验证设置右侧检测区域失败，误差验证终止!");
                    isCaliDone = false;
                    break;
                }

                //设置完检测区域后等待一定时间再取点
                Thread.Sleep(1500);

                //获取右侧寻缝器相机坐标
                bool isGetPoint_right = false;
                ModelWeldTrack right_resp = new ModelWeldTrack();
                for (int j = 0; isErrorChecking && j < 5; j++)
                {
                    if (!sendSensor(coord_req, ref right_resp))
                    {
                        AddLogWithTime($"第{3 - cnt}组误差验证第{j + 1}次未捕获到右侧相机坐标");
                        Thread.Sleep(1000);
                        continue;
                    }
                    else
                    {
                        isGetPoint_right = true;
                        break;
                    }
                }

                if (!isGetPoint_right)
                {
                    isCaliDone = false;
                    break;
                }

                //保存该组数据
                errorVerifyPoints[cnt][1] = (double)left_resp.Y;
                errorVerifyPoints[cnt][2] = (double)left_resp.Z;
                errorVerifyPoints[cnt][3] = (double)right_resp.Y;
                errorVerifyPoints[cnt][4] = (double)right_resp.Z;

                errorDetail += $"0{3 - cnt}1:{errorVerifyPoints[cnt][0]:F2},0{10 - cnt}2:{errorVerifyPoints[cnt][1]:F2},0{10 - cnt}3:{errorVerifyPoints[cnt][2]:F2},0{10 - cnt}4:{errorVerifyPoints[cnt][3]:F2},0{10 - cnt}5:{errorVerifyPoints[cnt][4]:F2}\r\n";

                AddLogWithTime($"第{3 - cnt}组误差验证数据获取成功!");
                AddLog($"调高器高度: {errorVerifyPoints[cnt][0]:F2}");
                AddLog($"相机坐标左Y坐标: {errorVerifyPoints[cnt][1]:F2}");
                AddLog($"相机坐标左Z坐标: {errorVerifyPoints[cnt][2]:F2}");
                AddLog($"相机坐标右Y坐标: {errorVerifyPoints[cnt][3]:F2}");
                AddLog($"相机坐标右Z坐标: {errorVerifyPoints[cnt][4]:F2}");

            }

        Label:
            if (!isErrorChecking || !isCaliDone)
            {
                AddLogWithTime("误差验证失败!");
            }
            else
            {
                optViewDist = Convert.ToDouble(lineOptViewDist.Text);
                actualDist = Convert.ToDouble(lineActualDist.Text);
                AddLogWithTime("误差验证完成!");

                double[] errorY = new double[3];
                double[] errorZ = new double[3];
                bool isYOK = true;
                bool isZOK = true;
                for (int i = 0; i < 3; i++)
                {
                    double gap = Math.Abs(errorVerifyPoints[i][3] - errorVerifyPoints[i][1]);
                    errorY[i] = Math.Abs((gap - actualDist) / actualDist);
                    errorZ[i] = Math.Abs(2 * (errorVerifyPoints[i][2] - errorVerifyPoints[i][4]) / (errorVerifyPoints[i][2] + errorVerifyPoints[i][4]));

                    string detail = "";
                    detail += $"0{i + 1}6:{gap:F2},0{i + 1}7:{actualDist:F2}\r\n";
                    detail += $"0{i + 1}8:{Math.Round(100 * errorY[i], 2)}%\r\n";
                    detail += $"0{i + 1}9:{Math.Round(100 * errorZ[i], 2)}%\r\n";
                    errorDetail += detail;

                    AddLog($"Gap: {gap:F2}, ActualDist: {actualDist:F2}");
                    AddLog($"坐标参数{i + 1}的间距相对误差{Math.Round(100 * errorY[i], 2)}%");
                    AddLog($"坐标参数{i + 1}的Z向误差{Math.Round(100 * errorZ[i], 2)}%");

                    if (errorY[i] > 0.01)
                    {
                        isYOK = false;
                    }
                    if (errorZ[i] > 0.0018)
                    {
                        isZOK = false;
                    }
                }
                double z = Math.Abs(errorVerifyPoints[2][4] - errorVerifyPoints[2][0] - (errorVerifyPoints[0][4] - errorVerifyPoints[0][0]));
                AddLog($"Z向误差为: {Math.Round(z, 2)}mm");
                errorDetail += $"Z向误差: {Math.Round(z, 2)}mm";

                string str = "";
                if (isYOK)
                {
                    AddLog("左右间距通过");
                }
                else
                {
                    str += "左右间距NG";
                    AddLog("左右间距NG");
                }
                if (isZOK)
                {
                    AddLog("Z向通过");
                }
                else
                {
                    str += ";Z向NG";
                    AddLog("Z向NG");
                }

                frm2.UpdateMESPara(isYOK && isZOK, str);

                //生成误差验证参数文档
                string path = Directory.GetCurrentDirectory();
                path += @"\ErrorCheck";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += $@"\ErrorCheck{System.DateTime.Now.ToString("-yyyy-MM-dd-HH-mm-ss")}.txt";
                try
                {
                    FileStream file = File.Create(path);
                    file.Close();
                    file.Dispose();
                    using (StreamWriter w = new StreamWriter(path, true))
                    {
                        w.Write(errorDetail);
                        w.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            mutex.WaitOne();
            isErrorChecking = false;
            textShowIsChecking.Text = "误差验证结束";
            mutex.ReleaseMutex();
        }

        private void btnStopChecking_Click(object sender, EventArgs e)
        {
            mutex.WaitOne();
            if (isErrorChecking)
            {
                isErrorChecking = false;
                textShowIsChecking.Text = "正在终止误差验证...";
            }
            mutex.ReleaseMutex();
        }

        private void btnParaEdit_Click(object sender, EventArgs e)
        {
            frm2.ShowDialog();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            Log.Clear();
        }

        private void btnBanDisplaySomeLog_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(BanDisplaySomeLog);
            t.IsBackground = true;
            t.Start();

        }

        private void BanDisplaySomeLog()
        {
            setParamBool("DisplayTimeStampCheck", false);
            setParamBool("DisplayReadInnerMatrixCheck", false);
            setParamBool("DisplayReadInnerMatrixLengthCheck", false);
            setParamBool("DisplayLoadInnerMatrixCheck", false);
        }

        public void AddLogWithTime(string str)
        {
            Log.AppendText(System.DateTime.Now + ": " + str + "\r\n");
        }
        public void AddLog(string str)
        {
            Log.AppendText(str + "\r\n");

        }

        private void menuExpertMode_Click(object sender, EventArgs e)
        {
            if (menuExpertMode.Checked)
            {
                menuExpertMode.Checked = false;
                labelTGQTotalTravel.Visible = false;
                labelTGQMesaDist.Visible = false;
                labelTGQSensorDist.Visible = false;
                lineTGQTotalTravel.Visible = false;
                lineTGQMesaDist.Visible = false;
                lineTGQSensorDist.Visible = false;
                frm2.labelOperationCode.Visible = false;
                frm2.labelWorkstationCode.Visible = false;
                frm2.textOperationCode.Visible = false;
                frm2.textWorkstationCode.Visible = false;
            }
            else
            {
                //输入密码
                frm3.ShowDialog();

                if (frm3.DialogResult == DialogResult.OK)
                {
                    menuExpertMode.Checked = true;
                    menuExpertMode.Checked = true;
                    labelTGQTotalTravel.Visible = true;
                    labelTGQMesaDist.Visible = true;
                    labelTGQSensorDist.Visible = true;
                    lineTGQTotalTravel.Visible = true;
                    lineTGQMesaDist.Visible = true;
                    lineTGQSensorDist.Visible = true;
                    frm2.labelOperationCode.Visible = true;
                    frm2.labelWorkstationCode.Visible = true;
                    frm2.textOperationCode.Visible = true;
                    frm2.textWorkstationCode.Visible = true;
                }
                else if (frm3.DialogResult == DialogResult.Retry)
                {
                    MessageBox.Show("密码错误!");
                }
                else if (frm3.DialogResult == DialogResult.Cancel)
                {
                    frm3.Close();
                }

            }
        }
    }
}
