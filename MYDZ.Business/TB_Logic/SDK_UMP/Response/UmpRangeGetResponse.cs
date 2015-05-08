using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Business.TB_Logic.SDK_UMP.commonClass;
using System.Xml.Serialization;
using Top.Api;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    public class UmpRangeGetResponse : TopResponse
    {
        /// <summary>
        /// 营销范围类列表！
        /// </summary>
        [XmlArrayItem("range")]
        [XmlArray("ranges")]
        public List<Range> Ranges { get; set; }

    }
}
