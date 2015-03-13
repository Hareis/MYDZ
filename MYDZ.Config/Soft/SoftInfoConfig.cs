﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Config.IConfig;
using System.Xml.Serialization;

namespace MYDZ.Config.Soft
{
    [Serializable]
    public class SoftInfoConfig : IConfigInfo
    {
        #region 正式环境

        /// <summary>
        /// 正式环境URL
        /// </summary>
        public string ZSHJ { get; set; }
        /// <summary>
        /// Appkey
        /// </summary>
        public string AppKey { get; set; }
        /// <summary>
        /// 程序密钥
        /// </summary>
        public string AppSecret { get; set; }
        /// <summary>
        /// 回调地址
        /// </summary>
        public string CallBackUrl { get; set; }
        /// <summary>
        /// 访问令牌的地址
        /// </summary>
        public string AccessTokenURL { get; set; }
        /// <summary>
        /// API 访问地址
        /// </summary>
        public string ApiURL { get; set; }
        /// <summary>
        /// TQL 访问地址
        /// </summary>
        public string TQLURL { get; set; }
        /// <summary>
        /// 上传文件保存地址
        /// </summary>
        public string RootFilePath { get; set; }
        /// <summary>
        /// 消息服务访问地址
        /// </summary>
        public string messageUrl { get; set; }
        #endregion

        #region 测试环境

        /// <summary>
        /// 测试环境URL
        /// </summary>
        public string CSHJ { get; set; }
        /// <summary>
        /// 测试环境 Appkey
        /// </summary>
        public string CSHJ_AppKey { get; set; }
        /// <summary>
        /// 测试环境 app密钥
        /// </summary>
        public string CSHJ_AppSecret { get; set; }
        /// <summary>
        /// 测试环境 回调地址
        /// </summary>
        public string CSHJ_CallBackUrl { get; set; }
        /// <summary>
        /// 测试环境  访问授权地址
        /// </summary>
        public string CSHJ_AccessTokenURL { get; set; }
        #endregion
    }
}
