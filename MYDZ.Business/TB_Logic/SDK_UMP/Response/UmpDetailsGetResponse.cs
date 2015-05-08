using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using System.Xml.Serialization;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    public class UmpDetailsGetResponse : TopResponse
    {
        /// <summary>
        /// 活动详情的信息
        /// </summary>
        [XmlArrayItem("string")]
        [XmlArray("contents")]
        public List<string> Contents { get; set; }
        /// <summary>
        /// 记录总数
        /// </summary>
        [XmlElement("total_count")]
        public int TotalCount { get; set; }
    }
}
