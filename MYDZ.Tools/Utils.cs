using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Security;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using System.Xml;
using Newtonsoft.Json;

namespace MYDZ.Tools
{
    /// <summary>
    /// 工具类
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// 返回URL中结尾的文件名
        /// </summary>
        /// <param name="Url">URL地址</param>
        /// <returns></returns>
        public static string GetFileName(string Url)
        {
            if (String.IsNullOrEmpty(Url)) { return ""; }

            string[] strs = Url.Split(new char[] { '/' });
            return strs[strs.Length - 1].Split(new char[] { '?' })[0].Split('.')[0];
        }

        /// <summary>
        /// 字符串如果超过指定长度则将超出部分用指定字符串代替
        /// </summary>
        /// <param name="P_SrcString">要检查的字符串</param>
        /// <param name="P_Length">指定长度</param>
        /// <param name="P_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(string P_SrcString, int P_Length, string P_TailString)
        {
            return GetSubString(P_SrcString, 0, P_Length, P_TailString);
        }

        /// <summary>
        /// 字符串如果超过指定长度则将超出部分用指定字符串代替
        /// </summary>
        /// <param name="P_SrcString">要检查的字符串</param>
        /// <param name="P_StartIndex">起始位置</param>
        /// <param name="P_Length">指定长度</param>
        /// <param name="P_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(string P_SrcString, int P_StartIndex, int P_Length, string P_TailString)
        {
            string MyResult = P_SrcString;

            Byte[] bComments = Encoding.UTF8.GetBytes(P_SrcString);

            foreach (char c in Encoding.UTF8.GetChars(bComments))
            {
                if ((c > '\u0800' && c < '\u4e00') || (c > '\xAC00' && c < '\xD7A3'))
                {
                    if (P_StartIndex >= P_SrcString.Length)
                    {
                        return "";
                    }
                    else
                    {
                        return P_SrcString.Substring(P_StartIndex, ((P_Length + P_StartIndex) > P_SrcString.Length) ? (P_SrcString.Length - P_StartIndex) : P_Length);
                    }
                }
            }

            if (P_Length >= 0)
            {
                byte[] bsSrcString = Encoding.Default.GetBytes(P_SrcString);

                //当字符串长度大于起始位置
                if (bsSrcString.Length > P_StartIndex)
                {
                    int P_EndIndex = bsSrcString.Length;

                    //当要截取的长度在字符串的有效长度范围内
                    if (bsSrcString.Length > (P_StartIndex + P_Length))
                    {
                        P_EndIndex = P_Length + P_StartIndex;
                    }
                    else
                    {
                        //当不再有效范围内时，只取到字符串的结尾
                        P_Length = bsSrcString.Length - P_StartIndex;
                        P_TailString = "";
                    }

                    int nRealLength = P_Length;
                    int[] anResultFlag = new int[P_Length];
                    byte[] bsResult = null;

                    int nFlag = 0;
                    for (int i = P_StartIndex; i < P_EndIndex; i++)
                    {
                        if (bsSrcString[i] > 127)
                        {
                            nFlag++;
                            if (nFlag == 3)
                            {
                                nFlag = 1;
                            }
                        }
                        else
                        {
                            nFlag = 0;
                        }
                    }

                    if ((bsSrcString[P_EndIndex - 1] > 127) && (anResultFlag[P_Length - 1] == 1))
                    {
                        nRealLength = P_Length + 1;
                    }

                    bsResult = new byte[nRealLength];

                    Array.Copy(bsSrcString, P_StartIndex, bsResult, 0, nRealLength);
                    MyResult = Encoding.Default.GetString(bsResult);
                    MyResult = MyResult + P_TailString;
                }
            }

            return MyResult;
        }

        /// <summary>
        /// 根据字符串获取枚举值
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="value">字符串枚举值</param>
        /// <param name="DefValue">缺省值</param>
        /// <returns></returns>
        public static T GetEnum<T>(string value, T DefValue)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            catch (ArgumentException)
            {
                return DefValue;
            }
        }

        /// <summary>
        /// 将枚举名称转换成字符串数组
        /// </summary>
        /// <param name="MenuType">类型</param>
        /// <returns></returns>
        public static string[] GetEnumName(Type MenuType)
        {
            return Enum.GetNames(MenuType);
        }

        /// <summary>
        /// 将枚举值转换成数组
        /// </summary>
        /// <param name="MenuType">类型</param>
        /// <returns></returns>
        public static Array GetEnumValue(Type MenuType)
        {
            return Enum.GetValues(MenuType);
        }

        /// <summary>
        /// Javascript escape加密算法，可被Javascript unescape()方法进行解密
        /// </summary>
        /// <param name="s"></param>
        /// <returns>已编码的 string 的副本。其中某些字符被替换成了十六进制的转义序列</returns>
        public static string Escape(string s)
        {
            StringBuilder sb = new StringBuilder();
            byte[] ba = System.Text.Encoding.Unicode.GetBytes(s);
            for (int i = 0; i < ba.Length; i += 2)
            {
                if (ba[i + 1] == 0)
                {
                    if (
                          (ba[i] >= 48 && ba[i] <= 57)
                        || (ba[i] >= 64 && ba[i] <= 90)
                        || (ba[i] >= 97 && ba[i] <= 122)
                        || (ba[i] == 42 || ba[i] == 43 || ba[i] == 45 || ba[i] == 46 || ba[i] == 47 || ba[i] == 95)
                        )
                    {
                        sb.Append(Encoding.Unicode.GetString(ba, i, 2));
                    }
                    else
                    {
                        sb.Append("%");
                        sb.Append(ba[i].ToString("X2"));
                    }
                }
                else
                {
                    sb.Append("%u");
                    sb.Append(ba[i + 1].ToString("X2"));
                    sb.Append(ba[i].ToString("X2"));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 计算字符串长度，区分中英文字符，中文算两个长度，英文算一个长度
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static int GetStringLength(string Text)
        {
            int len = 0;
            for (int i = 0; i < Text.Length; i++)
            {
                byte[] byte_len = System.Text.Encoding.Default.GetBytes(Text.Substring(i, 1));
                if (byte_len.Length > 1)
                    len += 2;  //如果长度大于1，是中文，占两个字节，+2
                else
                    len += 1;  //如果长度等于1，是英文，占一个字节，+1
            }
            return len;
        }

        /// <summary>  
        /// 根据GUID获取16位的唯一字符串  
        /// </summary>
        /// <returns></returns>  
        public static string GuidTo16String()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
                i *= ((int)b + 1);
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        /// <summary>  
        /// 根据GUID获取19位的唯一数字序列  
        /// </summary>  
        /// <returns></returns>  
        public static long GuidToLongID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>
        /// 获取服务器对应的物理文件路径
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public static string MapPath(string strPath)
        {
            if (System.Web.HttpContext.Current != null)
            {
                return System.Web.HttpContext.Current.Server.MapPath(strPath);
            }
            else
            { //非web程序引用
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("~"))
                {
                    strPath = strPath.TrimStart('~');
                }
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }

        /// <summary>
        /// 生成指定位数的数字随机验证码
        /// </summary>
        /// <param name="Length">验证码位数</param>
        /// <returns></returns>
        public static string RandomCode(int Length = 4)
        {
            string checkCode = "";
            Random rad = new Random();

            for (int i = 0; i < Length; i++)
            {
                checkCode += (rad.Next(0, 9) % Length).ToString();
            }

            return checkCode;
        }

        /// <summary>
        /// 获取文件的真实媒体类型。目前只支持JPG, GIF, PNG, BMP四种图片文件。
        /// </summary>
        /// <param name="fileData">文件字节流</param>
        /// <returns>媒体类型</returns>
        public static string GetMimeType(byte[] fileData)
        {
            string suffix = GetFileSuffix(fileData);
            string mimeType;

            switch (suffix)
            {
                case "JPG": mimeType = "image/jpeg"; break;
                case "GIF": mimeType = "image/gif"; break;
                case "PNG": mimeType = "image/png"; break;
                case "BMP": mimeType = "image/bmp"; break;
                default: mimeType = "application/octet-stream"; break;
            }

            return mimeType;
        }

        /// <summary>
        /// 获取文件的真实后缀名。目前只支持JPG, GIF, PNG, BMP四种图片文件。
        /// </summary>
        /// <param name="fileData">文件字节流</param>
        /// <returns>JPG, GIF, PNG or null</returns>
        public static string GetFileSuffix(byte[] fileData)
        {
            if (fileData == null || fileData.Length < 10)
            {
                return null;
            }

            if (fileData[0] == 'G' && fileData[1] == 'I' && fileData[2] == 'F')
            {
                return "GIF";
            }
            else if (fileData[1] == 'P' && fileData[2] == 'N' && fileData[3] == 'G')
            {
                return "PNG";
            }
            else if (fileData[6] == 'J' && fileData[7] == 'F' && fileData[8] == 'I' && fileData[9] == 'F')
            {
                return "JPG";
            }
            else if (fileData[0] == 'B' && fileData[1] == 'M')
            {
                return "BMP";
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据文件后缀名获取文件的媒体类型。
        /// </summary>
        /// <param name="fileName">带后缀的文件名或文件全名</param>
        /// <returns>媒体类型</returns>
        public static string GetMimeType(string fileName)
        {
            string mimeType;
            fileName = fileName.ToLower();
            if (fileName.EndsWith(".bmp", StringComparison.CurrentCulture))
            {
                mimeType = "image/bmp";
            }
            else if (fileName.EndsWith(".gif", StringComparison.CurrentCulture))
            {
                mimeType = "image/gif";
            }
            else if (fileName.EndsWith(".jpg", StringComparison.CurrentCulture) || fileName.EndsWith(".jpeg", StringComparison.CurrentCulture))
            {
                mimeType = "image/jpeg";
            }
            else if (fileName.EndsWith(".png", StringComparison.CurrentCulture))
            {
                mimeType = "image/png";
            }
            else
            {
                mimeType = "application/octet-stream";
            }

            return mimeType;
        }

        /// <summary>
        /// 将弱类型转换成强类型
        /// </summary>
        /// <typeparam name="T">强类型</typeparam>
        /// <param name="obj">弱类型</param>
        /// <param name="t">强类型</param>
        /// <returns></returns>
        public static T TypeConversion<T>(object obj, T t)
        {
            return (T)obj;
        }

        /// <summary>
        /// 请求网页数据
        /// </summary>
        /// <param name="url">网页地址</param>
        /// <param name="IsPost">是否为post请求</param>
        /// <param name="Data">需要提交的数据</param>
        /// <param name="Referer">Referer Http标头的值</param>
        /// <param name="Accept">Accept Http标头的值</param>
        /// <param name="ContentType">Content-Type Http标头的值</param>
        /// <param name="UserAgent">UserAgent Http标头的值</param>
        /// <param name="Host">Host 标头值</param>
        /// <param name="Timeout">超时时间(以毫秒为单位)</param>
        /// <param name="encoding">编码</param>
        /// <returns></returns>
        public static string Request(
            string url,
            bool IsPost,
            IDictionary<string, string> Data = null,
            string Referer = "",
            string Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*",
            string ContentType = "application/x-www-form-urlencoded",
            string UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; InfoPath.3)",
            string Host = "",
            int Timeout = 100000,
            Encoding encoding = null)
        {

            string Content = "";
            try
            {
                string RequestData = "";
                if (Data != null) { RequestData = BuildQuery(Data); }

                if (!String.IsNullOrEmpty(RequestData) && !IsPost)
                {
                    url = url.Contains("?") ? url + "&" + RequestData : url + "?" + RequestData;
                }

                HttpWebRequest request = null;
                if (url.StartsWith("https", StringComparison.CurrentCultureIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((o, x, c, e) => { return true; });
                    request = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
                }
                else
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                }

                request.KeepAlive = false;
                request.ServicePoint.Expect100Continue = false;
                request.Method = IsPost ? "post" : "get";
                request.Timeout = Timeout;

                if (!String.IsNullOrEmpty(Accept)) { request.Accept = Accept; }
                if (!String.IsNullOrEmpty(UserAgent)) { request.UserAgent = UserAgent; }
                if (!String.IsNullOrEmpty(Referer)) { request.Referer = Referer; }
                if (!String.IsNullOrEmpty(Host)) { request.Host = Host; }
                if (!String.IsNullOrEmpty(ContentType)) { request.ContentType = ContentType; }
                if (encoding == null) { encoding = Encoding.GetEncoding("UTF-8"); }

                if (!String.IsNullOrEmpty(RequestData) && IsPost)
                {
                    byte[] buffer = encoding.GetBytes(RequestData);
                    request.ContentLength = buffer.Length;
                    request.GetRequestStream().Write(buffer, 0, buffer.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    Content = reader.ReadToEnd().Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                }
            }
            catch { }

            return Content;
        }

        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <param name="Ignore">是否忽略空值</param>
        /// <returns>URL编码后的请求数据</returns>
        public static string BuildQuery(IDictionary<string, string> parameters, bool Ignore = false)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;

            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;

                if (!(Ignore && string.IsNullOrEmpty(value)))
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }

                    postData.Append(name);
                    postData.Append("=");
                    postData.Append(HttpUtility.UrlEncode(value, Encoding.UTF8));
                    hasParam = true;
                }
            }

            return postData.ToString();
        }

        /// <summary>
        /// 获取Url参数列表
        /// </summary>
        /// <param name="ParamList">Url参数</param>
        /// <returns></returns>
        public static IDictionary<string, string> Request(string ParamList)
            {
            if (!String.IsNullOrEmpty(ParamList))
            {
              /*  try
                {
                    IDictionary<string, string> Param = Regex.Matches(ParamList, @"\s*(?<key>[^=]+)\s*=\s*((?<value>[^'][^&]*)|'(?<value>[^']*)')")
                                .Cast<Match>()
                                .ToDictionary(
                                    m => m.Groups["key"].Value.Replace("&", ""),
                                    m => m.Groups["value"].Value
                                );
                    return Param;
                }
                catch { }*/

                try
                {
                    string UrlParmam = Encrypt.Encrypting.Decode(ParamList.Trim().Replace("$", "+").Replace("-", "=").Replace("_", "/"), Encrypt.EncryptMode.Page);
                    IDictionary<string, string> Param = new Dictionary<string, string>();
                    string[] strs = UrlParmam.Split(',');
                    foreach (string str in strs)
                    {
                        string[] temp = str.Split('=');
                        Param.Add(temp[0].Trim(), temp[1].Trim());
                    }
                    return Param;
                }
                catch { }
            }

            return new Dictionary<string, string>();
        }

        /// <summary>
        /// 正则表达式取值
        /// </summary>
        /// <param name="Text">文本</param>
        /// <param name="RegexString">正则表达式</param>
        /// <param name="GroupKey">正则表达式分组关键字</param>
        /// <param name="RightToLeft">是否从右到左</param>
        /// <returns></returns>
        public static List<string> GetRegValue(string Text, string RegexString, string GroupKey = "", bool RightToLeft = false)
        {
            List<string> list = new List<string>();
            MatchCollection m;
            Regex r;

            if (RightToLeft == true)
            {
                r = new Regex(RegexString, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.RightToLeft);
            }
            else
            {
                r = new Regex(RegexString, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            }

            m = r.Matches(Text);

            for (int i = 0; i < m.Count; i++)
            {
                if (!String.IsNullOrEmpty(GroupKey))
                {
                    list.Add(m[i].Groups[GroupKey].Value.Trim());
                }
                else
                {
                    list.Add(m[i].Value.Trim());
                }
            }

            return list;
        }

        /// <summary>
        /// 分词
        /// </summary>
        /// <param name="text">需要分词的字符串</param>
        /// <param name="format">响应结果格式(json/xml，默认json)</param>
        /// <param name="charset">字符串编码(gbk/utf8，默认是utf8)</param>
        /// <param name="ignore">是否忽略标点符号(默认为true)</param>
        /// <param name="duality">是否散字自动二元(默认为false)</param>
        /// <param name="traditional">是否采用繁体字库(默认为false，仅当charset为utf8时有效)</param>
        /// <param name="multi">复合分词的级别(整数值 1~15：0x01-最短词；0x02-二元；0x04-重要单字；0x08-全部单字) 默认为0，如有需要建议设置为 3</param>
        /// <returns></returns>
        public static List<string> Segment(string text, string format = "json", string charset = "utf8", bool ignore = true, bool duality = false, bool traditional = false, int multi = 0)
        {
            List<string> list = new List<string>();
            IDictionary<string, string> param = new Dictionary<string, string>() { 
                { "data", text.Trim() },
                { "respond", format.Trim() },
                { "charset", charset.Trim() },
                { "ignore", (ignore ? "yes" : "no") },
                { "duality", (duality ? "yes" : "no") },
                { "traditional", (traditional ? "yes" : "no") },
                { "multi", multi.ToString() }
            };

            string Content = Request(Config.PathConfig.SegmentPath, true, param);

            try
            {
                if (format == "json")
                {
                    Newtonsoft.Json.Linq.JObject results = Newtonsoft.Json.Linq.JObject.Parse(Content);
                    string status = results.Value<string>("status");
                    if (!String.IsNullOrEmpty(status) && status == "ok")
                    {
                        foreach (var item in results["words"].Children())
                        {
                            list.Add(item.Value<string>("word"));
                        }
                    }
                }
                else
                {
                    if (format == "xml")
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(Content);

                        foreach (XmlNode item in xmlDoc.GetElementsByTagName("word"))
                        {
                            list.Add(item.InnerText.Trim());
                        }
                    }
                }
            }
            catch { }

            return list;
        }
        /// <summary>
        /// 将类转化为Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToJsonStr<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// 将json 转化为类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sJson"></param>
        /// <returns></returns>
        public static T JsonStrToObject<T>(string sJson) where T : class
        {
            return JsonConvert.DeserializeObject<T>(sJson);
        }
    }
}
