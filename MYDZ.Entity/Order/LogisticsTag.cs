using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MYDZ.Entity.Order
{
    /// <summary>
    /// 物流标签
    /// </summary>
    public class LogisticsTag : Response
    {
        /// <summary>
        /// 服务标签
        /// </summary>
        [XmlArray("logistic_service_tag_list")]
        [XmlArrayItem("logistic_service_tag")]
        public List<LogisticServiceTag> LogisticServiceTagList { get; set; }

        /// <summary>
        /// 主订单或子订单的订单号
        /// </summary>
        [XmlElement("order_id")]
        public string OrderId { get; set; }
    }
}
