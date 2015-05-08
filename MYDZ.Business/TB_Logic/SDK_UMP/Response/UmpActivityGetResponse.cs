using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using System.Xml.Serialization;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    public class UmpActivityGetResponse : TopResponse
    {
        /// <summary>
        /// 营销活动的内容
        /// </summary>
        [XmlElement("content")]
        public string Content { get; set; }
    }
}
