using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MYDZ.Entity.Marketing
{
    /// <summary>
    /// 优惠标签对象
    /// </summary>
    [Serializable]
    public class PromotionTag : Response
    {
        /// <summary>
        /// 标签ID
        /// </summary>
        [XmlElement("tag_id")]
        public long TagId { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        [XmlElement("tag_name")]
        public string TagName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("tag_desc")]
        public string TagDesc { get; set; }
        /// <summary>
        /// 标签开始时间
        /// </summary>
        [XmlElement("start_time")]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 标签结束时间
        /// </summary>
        [XmlElement("end_time")]
        public DateTime EndTime { get; set; }
    }
}
