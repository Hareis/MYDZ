using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using System.Xml.Serialization;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    public class UmpDetailGetResponse : TopResponse
    {
        /// <summary>
        /// 工具信息内容，格式为json，可以通过提供给的sdk里面的MarketingBuilder来处理这个内容
        /// </summary>
        [XmlElement("content")]
        public string Content { get; set; }
    }
}
