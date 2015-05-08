using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using System.Xml.Serialization;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    public class UmpActivityAddResponse : TopResponse
    {
        /// <summary>
        /// 活动id 
        /// </summary>
        [XmlElement("act_id")]
        public int ActId { get; set; }
    }
}
