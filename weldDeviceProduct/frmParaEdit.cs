using System;
using System.Threading;
using System.Windows.Forms;

namespace weldDeviceProduct
{
    public partial class frmParaEdit : Form
    {
        private frmMain frm1;
        private bool isMesing = false;

        private ModelWeldTrack BCW500 = new ModelWeldTrack()
        {
            Dx = 18.55,
            Dy = 23.55,
            Wx = 150,
            Wy = 46,
            Wz = 112,
            Cam2LaserDis = 115.55
        };
        private ModelWeldTrack BCW500S = new ModelWeldTrack()
        {
            Dx = 18.55,
            Dy = 23.55,
            Wx = 150,
            Wy = 46,
            Wz = 112,
            Cam2LaserDis = 115.55

        };
        public frmParaEdit(frmMain frm1)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            cbbResult.SelectedIndex = 0;
            cbbMESPort.SelectedIndex = 0;
            this.frm1 = frm1;
        }

        private void cbbDeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread t = new Thread(fillPara);
            t.IsBackground = true;
            t.Start();
        }

        private void fillPara()
        {
            switch (cbbDeviceType.SelectedIndex)
            {
                case 0:
                    {
                        textDeviceType.Text = "BCW500";
                        lineLowerDist.Value = Convert.ToDecimal(BCW500.Dx);
                        lineRightDist.Value = Convert.ToDecimal(BCW500.Dy);
                        lineUpperLowerDiff.Value = Convert.ToDecimal(BCW500.Wx);
                        lineLeftRightDiff.Value = Convert.ToDecimal(BCW500.Wy);
                        lineFrontRearDiff.Value = Convert.ToDecimal(BCW500.Wz);
                        lineRightToLaserDist.Value = Convert.ToDecimal(BCW500.Cam2LaserDis);
                        break;
                    }

                case 1:
                    {
                        textDeviceType.Text = "BCW500S";
                        lineLowerDist.Value = Convert.ToDecimal(BCW500S.Dx);
                        lineRightDist.Value = Convert.ToDecimal(BCW500S.Dy);
                        lineUpperLowerDiff.Value = Convert.ToDecimal(BCW500S.Wx);
                        lineLeftRightDiff.Value = Convert.ToDecimal(BCW500S.Wy);
                        lineFrontRearDiff.Value = Convert.ToDecimal(BCW500S.Wz);
                        lineRightToLaserDist.Value = Convert.ToDecimal(BCW500S.Cam2LaserDis);
                        break;
                    }

                default:
                    break;
            }

        }

        private void btnWriteToDevice_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(writeToDevice);
            t.IsBackground = true;
            t.Start();
        }

        private void writeToDevice()
        {
            //验证参数合法性
            if (!isParaAllRight())
            {
                return;
            }

            MessageBoxButtons msgButton = MessageBoxButtons.OKCancel;
            DialogResult res = MessageBox.Show("确定要将参数写入寻缝器吗?", "Attention!", msgButton);
            if (res == DialogResult.OK)
            {
                ModelWeldTrack req = new ModelWeldTrack(WeldTrackCMD.WriteMechanicPara, ref frmMain.id)
                {
                    DeviceType = textDeviceType.Text,
                    SN = textDeviceSN.Text,
                    MinZ = Convert.ToDouble(lineNearestViewDist.Text),
                    MidZ = Convert.ToDouble(lineOptViewDist.Text),
                    MaxZ = Convert.ToDouble(lineLongestViewDist.Text),
                    MinView = Convert.ToDouble(lineNearestView.Text),
                    MidView = Convert.ToDouble(lineOptView.Text),
                    MaxView = Convert.ToDouble(lineLongestView.Text),
                    Dx = Convert.ToDouble(lineLowerDist.Text),
                    Dy = Convert.ToDouble(lineRightDist.Text),
                    Dz = Convert.ToDouble(lineFrontDist.Text),
                    Wx = Convert.ToDouble(lineUpperLowerDiff.Text),
                    Wy = Convert.ToDouble(lineLeftRightDiff.Text),
                    Wz = Convert.ToDouble(lineFrontRearDiff.Text),
                    Cam2LaserDis = Convert.ToDouble(lineRightToLaserDist.Text)
                };
                ModelWeldTrack resp = new ModelWeldTrack();
                if (frm1.sendSensor(req, ref resp))
                {
                    frm1.AddLogWithTime("写入寻缝器成功!");
                }
            }
        }

        private bool isParaAllRight()
        {
            if (String.IsNullOrEmpty(textDeviceType.Text))
            {
                MessageBox.Show("未输入设备型号!\r\n");
                return false;
            }
            if (String.IsNullOrEmpty(textDeviceSN.Text))
            {
                MessageBox.Show("未输入设备序列号!\r\n");
                return false;
            }
            if (lineLowerDist.Value <= 0 || lineRightDist.Value <= 0 || lineUpperLowerDiff.Value <= 0 ||
                 lineLeftRightDiff.Value <= 0 || lineFrontRearDiff.Value <= 0 || lineRightToLaserDist.Value <= 0)
            {
                MessageBox.Show("寻缝器机械参数除DZ外必须大于0!\r\n");
                return false;
            }
            if (lineOptViewDist.Value.Equals(0) || lineNearestViewDist.Value.Equals(0) ||
                lineLongestViewDist.Value.Equals(0) || lineOptView.Value.Equals(0) ||
                lineNearestView.Value.Equals(0) || lineLongestView.Value.Equals(0))
            {
                MessageBox.Show("寻缝器视野视距必须大于0!\r\n");
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UpdateDevicePara(ModelWeldTrack para)
        {
            lineNearestViewDist.Value = Convert.ToDecimal(para.MinZ);
            lineOptViewDist.Value = Convert.ToDecimal(para.MidZ);
            lineLongestViewDist.Value = Convert.ToDecimal(para.MaxZ);
            lineNearestView.Value = Convert.ToDecimal(para.MinView);
            lineOptView.Value = Convert.ToDecimal(para.MidView);
            lineLongestView.Value = Convert.ToDecimal(para.MaxView);
            lineFrontDist.Value = Convert.ToDecimal(para.Dz);
        }

        public void UpdateMESPara(bool isOK, string str)
        {
            if (isOK)
            {
                cbbResult.SelectedIndex = 0;
                textNGRemark.Text = "";
            }
            else
            {
                cbbResult.SelectedIndex = 1;
                textNGRemark.Text = str;
            }
        }

        private void btnUploadToMES_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(UploadToMES);
            t.IsBackground = true;
            t.Start();
        }

        private void UploadToMES()
        {
            if (!isMESParaAllRight())
            {
                return;
            }

            if (isMesing)
            {
                MessageBox.Show("正在上传，请勿重复点击");
                return;
            }
            isMesing = true;

            TestLotSnReq req = new TestLotSnReq()
            {
                lotSn = textDeviceSN.Text,
                operationCode = textOperationCode.Text,
                workstationCode = textWorkstationCode.Text,
                shiftCode = textShiftCode.Text,
                testPersonCode = textPersonCode.Text,
                testEq = textEq.Text,
                testProgram = "weldDeviceProduct",
                testStartTime = frmMain.start_time,
                testEndTime = frmMain.end_time,
                testResult = cbbResult.SelectedItem as string,
                testDetail = frmMain.testDetail,

            };
            if (cbbResult.SelectedIndex == 1)
            {
                req.badDefectList = new string[] { "V04" };
                req.ngRemark = textNGRemark.Text;
            }
            TestLotSnResp resp = new TestLotSnResp();
            bool? flag = testLotSn(req, ref resp);
            for (int i = 0; i < 5; i++)
            {
                if (flag == null)
                {
                    Thread.Sleep(1000);
                    flag = testLotSn(req, ref resp);
                }
                else
                {
                    break;
                }
            }

            if (flag == null)
            {
                frm1.AddLogWithTime("上传MES失败，请检查网络情况后重试!");
                MessageBox.Show("上传MES失败!");
                isMesing = false;
                return;
            }
            if ((bool)flag)
            {
                MessageBox.Show("上传MES成功!");
            }
            else
            {
                if (resp.error != null)
                {
                    MessageBox.Show(resp.error.Value.message);
                }
            }
            isMesing = false;
        }

        private bool? testLotSn(TestLotSnReq req, ref TestLotSnResp resp)
        {
            try
            {
                MESApi.TestLotSn(req, ref resp);
            }
            catch (Exception ex)
            {
                frm1.AddLogWithTime(ex.Message);
                return null;
            }

            if (!resp.success)
            {
                frm1.AddLogWithTime("上传MES失败!");
                return false;
            }
            frm1.AddLogWithTime("上传MES成功!");
            return true;
        }

        private bool isMESParaAllRight()
        {
            if (String.IsNullOrEmpty(textDeviceSN.Text))
            {
                MessageBox.Show("未输入SN号!");
                return false;
            }
            if (String.IsNullOrEmpty(textOperationCode.Text))
            {
                MessageBox.Show("未输入工序号!");
                return false;
            }
            if (String.IsNullOrEmpty(textWorkstationCode.Text))
            {
                MessageBox.Show("未输入工站号!");
                return false;
            }
            if (String.IsNullOrEmpty(textShiftCode.Text))
            {
                MessageBox.Show("未输入班次编码!");
                return false;
            }
            if (String.IsNullOrEmpty(textPersonCode.Text))
            {
                MessageBox.Show("未输入人员编码!");
                return false;
            }
            if (frmMain.start_time == null)
            {
                MessageBox.Show("无测试开始时间!");
                return false;
            }
            //todo 不良代码列表
            if (cbbResult.SelectedIndex == 1 && String.IsNullOrEmpty(textNGRemark.Text))
            {
                MessageBox.Show("无不良代码列表!");
                return false;
            }

            return true;
        }

        private void cbbResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbResult.SelectedIndex == 0)
            {
                labeNGRemark.Visible = false;
                textNGRemark.Visible = false;
            }
            else
            {
                labeNGRemark.Visible = true;
                textNGRemark.Visible = true;
            }
        }

        private void cbbMESPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMESPort.SelectedIndex == 0)
            {
                MESApi.SetMESPort(8081);
            }
            else if (cbbMESPort.SelectedIndex == 1)
            {
                MESApi.SetMESPort(8082);
            }
            else
            {
                MESApi.SetMESPort(8081);
            }
        }
    }
}
