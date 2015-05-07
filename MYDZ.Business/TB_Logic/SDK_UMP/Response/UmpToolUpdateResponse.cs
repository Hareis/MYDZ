using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using System.Xml.Serialization;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    public class UmpToolUpdateResponse : TopResponse
    {
        /// <summary>
        /// 更新后生成的新的工具id
        /// </summary>
        [XmlElement("tool_id")]
        public long ToolId { get; set; }
    }
}
