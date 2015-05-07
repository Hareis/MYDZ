using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using System.Xml.Serialization;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    public class UmpDetailAddResponse : TopResponse
    {
        /// <summary>
        /// 活动详情的id
        /// </summary>
        [XmlElement("detail_id")]
        public int DetailId { get; set; }
    }
}
