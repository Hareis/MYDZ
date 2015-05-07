using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using System.Xml.Serialization;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    internal class TmallPromotagTaguserJudgeResponse : TopResponse
    {
        /// <summary>
        /// 是否设置成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 优惠标签ID
        /// </summary>
        [XmlElement("has_tag")]
        public bool HasTag { get; set; }
    }
}
