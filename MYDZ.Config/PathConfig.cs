using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;
using System.IO;
using System.Configuration;

namespace MYDZ.Config
{
    /// <summary>
    /// 配置文件地址管理类
    /// </summary>
    public sealed class PathConfig
    {
        #region 变量

        /// <summary>
        /// 获取数据库配置文件地址
        /// </summary>
        internal static readonly string DataBasePath = GetMapPath("~/App_Data/DataBase/Config.xml");

        /// <summary>
        /// 获取加密配置文件地址
        /// </summary>
        internal static readonly string EncryptPath = GetMapPath("~/App_Data/Encrypt/Config.xml");

        /// <summary>
        /// 获取皮肤配置文件地址
        /// </summary>
        internal static readonly string ThemePath = GetMapPath("~/App_Data/Theme/Config.xml");

        /// <summary>
        /// 获取分词Url
        /// </summary>
        public static readonly string SegmentPath = ConfigurationManager.AppSettings["SEGMENT_URL"];

        /// <summary>
        /// 获取程序基本信息（appkey 、授权地址等）
        /// </summary>
        internal static readonly string AuthorizePath = GetMapPath("~/App_Data/SoftInfo/Config.xml");

        /// <summary>
        /// 获取程序基本信息（appkey 、授权地址等）
        /// </summary>
        internal static readonly string FontPath = GetMapPath("~/App_Data/Font/Config.xml");

        #endregion

        #region 属性访问器

        /// <summary>
        /// 获取数据库配置信息
        /// </summary>
        public static XmlNode DataBaseConfig {
            get { return GetConfig(DataBasePath, "/DataBaseConfig"); }
        }

        /// <summary>
        /// 获取加密配置信息
        /// </summary>
        public static XmlNode EncryptConfig {
            get { return GetConfig(EncryptPath, "/EncryptConfig"); }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取节点信息
        /// </summary>
        /// <param name="Path">xml文档文件地址</param>
        /// <param name="XmlPath">节点路径</param>
        /// <returns></returns>
        private static XmlNode GetConfig(string Path, string XmlPath) {
            XmlDocument xd = new XmlDocument();
            xd.Load(Path);
            XmlNode xn = xd.SelectSingleNode(XmlPath);
            return xn;
        }

        /// <summary>
        /// 获取文件绝对路径
        /// </summary>
        /// <param name="StrPath">指定路径</param>
        /// <returns></returns>
        private static string GetMapPath(string StrPath) {
            if (HttpContext.Current != null) {
                return HttpContext.Current.Server.MapPath(StrPath);
            } else {
                StrPath = StrPath.Replace("~", "").Replace("../", "").Replace("./", "").Replace("/", "\\");

                if (StrPath.StartsWith("\\")) {
                    StrPath = StrPath.Substring(StrPath.IndexOf('\\', 1)).TrimStart('\\');
                }

                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, StrPath);
            }
        }

        #endregion
    }
}
