using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Top.Api;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    public class UmpDetailDeleteResponse : TopResponse
    {
        /// <summary>
        /// 调用是否成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }
    }
}
