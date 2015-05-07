using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using System.Xml.Serialization;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    public class UmpToolAddResponse : TopResponse
    {
        /// <summary>
        /// 工具id  [示例值 : 12345]
        /// </summary>
        [XmlElement("tool_id")]
        public int ToolId { get; set; }
    }
}
