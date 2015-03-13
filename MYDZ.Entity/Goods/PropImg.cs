using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MYDZ.Entity.Goods
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PropImg : Response
    {
        /// <summary>
        /// 系统数据库
        /// </summary>
        public int PropImgId { get; set; }

        /// <summary>
        /// 图片创建时间 时间格式：yyyy-MM-dd HH:mm:ss
        /// </summary>
        [XmlElement("created")]
        public string Created { get; set; }

        /// <summary>
        /// 属性图片的id，和商品相对应
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 图片放在第几张（多图时可设置）
        /// </summary>
        [XmlElement("position")]
        public long Position { get; set; }

        /// <summary>
        /// 图片所对应的属性组合的字符串
        /// </summary>
        [XmlElement("properties")]
        public string Properties { get; set; }

        /// <summary>
        /// 图片链接地址
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }
    }
}
