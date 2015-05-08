using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using System.Xml.Serialization;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    public class PromotionmiscMjsActivityAddResponse : TopResponse
    {
        /// <summary>
        /// 是否保存成功。
        /// </summary>
        [XmlElement("is_success")]
        public Boolean IsSuccess { get; set; }

        /// <summary>
        /// 活动id。
        /// </summary>
        [XmlElement("activity_id")]
        public int ActivityId { get; set; }
    }
}
