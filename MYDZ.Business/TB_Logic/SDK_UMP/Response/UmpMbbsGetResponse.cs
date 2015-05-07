using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using System.Xml.Serialization;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Response
{
    public class UmpMbbsGetResponse : TopResponse
    {
        /// <summary>
        /// 营销积木块内容列表，内容为json格式的，可以通过ump sdk里面的MBB.fromJson来处理
        /// </summary>
        [XmlArrayItem("Mbb")]
        [XmlArray("mbbs")]
        public List<string> Mbbs { get; set; }
    }
}
