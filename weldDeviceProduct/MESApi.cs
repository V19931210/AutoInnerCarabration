using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;

namespace weldDeviceProduct
{
    public struct ERROR
    {
        public int code;
        public string message;
        public string details;
        public string validationErrors;
    }

    public struct TestLotSnReq
    {
        public string lotSn;//ID号
        public string operationCode;//工序号
        public string workstationCode;//工站号
        public string shiftCode;//班次编码
        public string testPersonCode;//人员编码
        public string testEq;//测试设备
        public string testProgram;//测试程序
        public string testStartTime;//开始时间
        public string testEndTime;//结束时间
        public string testResult;//测试结果 OK or NG
        public string testDetail;//测试明细
        public string ngRemark;//NG备注
        public string[] badDefectList;//不良代码列表
    }

    public struct TestLotSnResp
    {
        public ERROR? error;
        public string result;
        public string targetUrl;
        public bool success;
        public bool unAuthorizedRequest;
        public bool __abp;
    }

    public struct GetServerDateTimeResp
    {
        public ERROR? error;
        public string result;
        public string targetUrl;
        public bool success;
        public bool unAuthorizedRequest;
        public bool __abp;
    }

    public class MESApi
    {
        private static MESApi instance = null;
        private static object obj = new object();

        private const string GetServerDateTimeUrl8081 = "http://10.1.1.87:8081/api/services/app/WipApis/GetServerDateTime";
        private const string TestLotSnUrl8081 = "http://10.1.1.87:8081/api/services/app/WipApis/TestLotSn";
        private const string GetServerDateTimeUrl8082 = "http://10.1.1.87:8082/api/services/app/WipApis/GetServerDateTime";
        private const string TestLotSnUrl8082 = "http://10.1.1.87:8082/api/services/app/WipApis/TestLotSn";

        public static string GetServerDateTimeUrl = GetServerDateTimeUrl8081;
        public static string TestLotSnUrl = TestLotSnUrl8081;

        public static JsonSerializerSettings jsonSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };//忽略结构体空值字段

        private MESApi() { }

        public static MESApi GetInstance()
        {
            if (instance == null)
            {
                lock (obj)
                {
                    if (instance == null)
                    {
                        instance = new MESApi();
                    }
                }
            }
            return instance;

        }

        private static HttpWebRequest initHttpWebRequest(string url, string method)
        {
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
            webReq.Method = method;
            webReq.Proxy = null;
            webReq.Timeout = 3000;
            webReq.Accept = "*/*";
            webReq.ContentType = "application/json";
            webReq.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-CN");
            webReq.Headers.Add(".AspNetCore.Culture", "application/json");
            return webReq;
        }

        public static void TestLotSn(TestLotSnReq req, ref TestLotSnResp resp)
        {
            HttpWebRequest webReq = initHttpWebRequest(TestLotSnUrl, "POST");

            string jsonReq = JsonConvert.SerializeObject(req, jsonSetting);
            byte[] byteReq = Encoding.UTF8.GetBytes(jsonReq);
            using (Stream reqStream = webReq.GetRequestStream())
            {
                reqStream.Write(byteReq, 0, byteReq.Length);
            }

            HttpWebResponse webResp;
            try
            {
                webResp = (HttpWebResponse)webReq.GetResponse();
            }
            catch (WebException ex)
            {
                webResp = (HttpWebResponse)ex.Response;
            }

            if (webResp == null)
            {
                return;
            }

            using (Stream respStream = webResp.GetResponseStream())
            {
                using (StreamReader sReader = new StreamReader(respStream, Encoding.UTF8))
                {
                    resp = JsonConvert.DeserializeObject<TestLotSnResp>(sReader.ReadToEnd(), jsonSetting);

                }
            }

        }

        public static void GetServerDateTime(ref GetServerDateTimeResp resp)
        {
            HttpWebRequest webReq = initHttpWebRequest(GetServerDateTimeUrl, "GET");

            HttpWebResponse webResp;
            try
            {
                webResp = (HttpWebResponse)webReq.GetResponse();
            }
            catch (WebException ex)
            {
                webResp = (HttpWebResponse)ex.Response;
            }

            if (webResp == null)
            {
                return;
            }

            try
            {
                using (Stream respStream = webResp.GetResponseStream())
                {
                    using (StreamReader sReader = new StreamReader(respStream, Encoding.UTF8))
                    {
                        resp = JsonConvert.DeserializeObject<GetServerDateTimeResp>(sReader.ReadToEnd(), jsonSetting);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("GetResponseStream ERROR\r\n" + ex.Message);
            }
        }

        public static void SetMESPort(int port)
        {
            if (port == 8081)
            {
                GetServerDateTimeUrl = GetServerDateTimeUrl8081;
                TestLotSnUrl = TestLotSnUrl8081;
            }
            else if (port == 8082)
            {
                GetServerDateTimeUrl = GetServerDateTimeUrl8082;
                TestLotSnUrl = TestLotSnUrl8082;
            }
            else
            {
                GetServerDateTimeUrl = GetServerDateTimeUrl8081;
                TestLotSnUrl = TestLotSnUrl8081;
            }
        }
    }
}
