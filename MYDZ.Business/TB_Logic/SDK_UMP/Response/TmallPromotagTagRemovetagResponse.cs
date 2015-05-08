using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using System.Xml.Serialization;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    internal class TmallPromotagTagRemovetagResponse : TopResponse
    {
        /// <summary>
        /// 删除操作是否成功
        /// </summary>
        [XmlElement("is_success")]
        public Boolean IsSuccess { get; set; }
    }
}
