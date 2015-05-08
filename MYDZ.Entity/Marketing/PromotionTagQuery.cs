using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MYDZ.Entity.Marketing;

namespace MYDZ.Entity.Marketing
{
    public class PromotionTagQuery
    {
        /// <summary>
        /// 标签结果列表
        /// </summary>
        [XmlArrayItem("tag")]
        [XmlArray("tag_list")]
        public List<PromotionTag> TagList { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        [XmlElement("total_results")]
        public int TotalResults { get; set; }
    }
}
