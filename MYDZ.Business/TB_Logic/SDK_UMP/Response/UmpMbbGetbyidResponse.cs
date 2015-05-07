using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Top.Api;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    public class UmpMbbGetbyidResponse : TopResponse
    {
        /// <summary>
        /// 营销积木块定义信息
        /// </summary>
        [XmlElement("detail_id")]
        public string Mbb { get; set; }
    }
}
