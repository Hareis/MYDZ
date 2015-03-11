using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MYDZ.Config.IConfig;

namespace MYDZ.Config.Encrypt
{
    /// <summary>
    /// 加密信息类
    /// </summary>
    [Serializable]
    public class EncryptConfig : IConfigInfo
    {
        /// <summary>
        /// 加密信息列表
        /// </summary>
        [XmlArray("EncryptList")]
        public List<EncryptInfo> EncryptInfo { get; set; }
    }
}
