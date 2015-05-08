using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using System.Xml.Serialization;
using MYDZ.Entity.Marketing;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    internal class TmallPromotagTagFindResponse : TopResponse
    {
        /// <summary>
        /// 查询结果类型
        /// </summary>
        [XmlElement("query_result")]
        public PromotionTagQuery QueryResult { get; set; }
    }
}
