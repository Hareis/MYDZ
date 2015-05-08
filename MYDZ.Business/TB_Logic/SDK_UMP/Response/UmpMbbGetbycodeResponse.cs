using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using System.Xml.Serialization;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    public class UmpMbbGetbycodeResponse : TopResponse
    {
        /// <summary>
        /// 营销积木块的内容，通过ump sdk来进行处理
        /// </summary>
        [XmlElement("mbb")]
        public string Mbb { get; set; }
    }
}
