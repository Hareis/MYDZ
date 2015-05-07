using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using System.Xml.Serialization;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
   internal class TmallPromotagTaguserRemoveResponse:TopResponse
    {
       /// <summary>
        /// 打标结果是否成功    
       /// </summary>
       [XmlElement("is_success")]
       public Boolean IsSuccess { get; set; }
    }
}
