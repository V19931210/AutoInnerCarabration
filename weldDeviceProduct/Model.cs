namespace weldDeviceProduct
{
    public struct ModelWeldTrack
    {
        public WeldTrackCMD Cmd;//指令ID
        public int Id;//识别ID
        public string Result;//指令是否执行成功

        //当前识别的像素坐标
        public double? X;//像素坐标X
        public double? Y;//像素坐标Y
        public double? Z;//像素坐标Z

        //寻缝器图像尺寸
        public int? Width;
        public int? Height;

        //寻缝器机械参数
        public string DeviceType;//设备型号
        public string SN;//设备SN号
        public double? MinZ;//最小视距
        public double? MidZ;//最佳视距
        public double? MaxZ;//最大视距
        public double? MinView;//最小视野
        public double? MidView;//最佳视野
        public double? MaxView;//最大视野
        public double? Dx;//寻缝器下表面相对于该参考点的距离
        public double? Dy;//寻缝器右表面相对于该参考点的距离
        public double? Dz;//寻缝器前表面相对于该参考点的距离
        public double? Wx;//寻缝器上下表面之差
        public double? Wy;//寻缝器左右表面之差
        public double? Wz;//寻缝器前后表面之差
        public double? Cam2LaserDis;//相机最右边点到激光器的距离
        public double? MeanError;//平均误差
        public double? MeanZResolution;//Z向平均误差
        public double? MeanYResolution;//Y向平均误差

        public int? DutyCycle;//激光占空比

        //底层MAP参数
        public string Key;
        public bool? Value;
        public ModelWeldTrack(WeldTrackCMD cmd, ref int id) : this()
        {
            Cmd = cmd;
            Id = id;
        }
    }

    public enum WeldTrackCMD
    {
        StartTrack = 1,//开始跟踪
        StopTrack,//结束跟踪
        ReqData,//请求数据
        OpenLaser,//开激光 弃用
        CloseLaser,//关激光 弃用
        GetView,//获取寻缝器视野
        SetSoftPartVisible,//设置软件界面的部分可见
        GetVisionType,//获取寻缝器品牌 弃用
        SwitchLaserStatus,//切换红光状态
        SetDetectArea,//设置检测区域
        GetCurCoordinate,//获取当前识别的像素坐标
        CalInterMat,//计算内参矩阵
        WriteMechanicPara,//写入机械参数到寻缝器
        GetImageSize,//获取图像尺寸
        SetCurTemplateID,//设置当前模板ID
        SetLaserDutyCircle,//设置激光占空比
        GetCameraPos,//获取当前识别的相机坐标
        GetCurStatus,//获取当前传感器的状态
        StartPointCloud,//线扫寻位：开始点云采集	
        StopPointCloud,//线扫寻位：结束点云采集	
        GetStartEndPoint,//线扫寻位：返回起点/端点信息	
        SetMapPara,//设置底层MAP参数	
        LineFit,//直线拟合
        GetMechanicPara,//获取寻缝器机械参数
    }

    public struct ModelHeightAdjust
    {
        public HeightAdjustState CMDID;
        public double Zpos;
        public int CMDSize;
        public int CheckoutNum;

        public ModelHeightAdjust(HeightAdjustState cmd)
        {
            CMDID = cmd;
            Zpos = -10000;
            CMDSize = 24;
            CheckoutNum = 1014;
        }
        public ModelHeightAdjust(HeightAdjustState cmd, double z)
        {
            CMDID = cmd;
            Zpos = z;
            CMDSize = 24;
            CheckoutNum = 1014;
        }
    }

    public enum HeightAdjustState
    {
        HeightMove = 1,
        HeightGet = 2,
        HeightMoveOK = 8,//指调高器执行了运动指令，不代表调高器已经运动就位
        HeightFailedConnect = 10
    }

}
