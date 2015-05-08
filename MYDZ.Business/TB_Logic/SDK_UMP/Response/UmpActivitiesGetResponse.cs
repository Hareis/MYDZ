using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Top.Api;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    public class UmpActivitiesGetResponse : TopResponse
    {
        /// <summary>
        /// 营销活动内容，可以通过ump sdk来进行处理
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
