using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MYDZ.Entity.Order
{
    /// <summary>
    /// 服务标签
    /// </summary>
    public class LogisticServiceTag : Response
    {
        /// <summary>
        /// 物流服务下的标签属性,多个标签之间有";"分隔
        /// </summary>
        [XmlElement("service_tag")]
        public string ServiceTag { get; set; }

        /// <summary>
        /// 服务类型=编码  平邮=POST  快递=FAST  EMS=EMS  消费者选快递时为FAST
        /// </summary>
        [XmlElement("service_type")]
        public string ServiceType { get; set; }
    }
}
