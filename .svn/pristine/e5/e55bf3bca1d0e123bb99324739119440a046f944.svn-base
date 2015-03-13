using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MYDZ.Entity.ItemCats
{
    [Serializable]
    public class Brand : Response
    {
        /// <summary>
        /// vid的值
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 品牌的属性id
        /// </summary>
        [XmlElement("pid")]
        public long Pid { get; set; }

        /// <summary>
        /// 品牌的属性名
        /// </summary>
        [XmlElement("prop_name")]
        public string PropName { get; set; }

        /// <summary>
        /// 对应属性的 pid:vid 串中的vid
        /// </summary>
        [XmlElement("vid")]
        public long Vid { get; set; }
    }
}
