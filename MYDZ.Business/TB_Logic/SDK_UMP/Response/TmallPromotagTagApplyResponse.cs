using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using System.Xml.Serialization;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    /// <summary>
    /// 优惠标签申请
    /// </summary>
    public class TmallPromotagTagApplyResponse : TopResponse
    {
        /// <summary>
        /// 是否设置成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 优惠标签ID
        /// </summary>
        [XmlElement("tag_id")]
        public int TagId { get; set; }
    }
}
