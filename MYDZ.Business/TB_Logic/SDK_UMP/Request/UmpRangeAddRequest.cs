using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api.Request;
using MYDZ.Business.TB_Logic.SDK_UMP.Response;
using Top.Api;
using Top.Api.Util;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Request
{
    internal class UmpRangeAddRequest : ITopRequest<UmpRangeAddResponse>
    {
        /// <summary>
        /// 活动id
        /// </summary>
        public int ActId { get; set; }

        /// <summary>
        /// 范围的类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// id列表，当范围类型为商品时，该id为商品id；当范围类型为类目时，该id为类目id.多个id用逗号隔开，一次不超过50个
        /// </summary>
        public string Ids { get; set; }

        public string GetApiName()
        {
            return "taobao.ump.range.add";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("act_id", this.ActId);
            parameters.Add("type", this.Type);
            parameters.Add("ids", this.Ids);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("tool_id", this.ActId);
            RequestValidator.ValidateRequired("page_no", this.Type);
            RequestValidator.ValidateRequired("page_size", this.Ids);
        }
    }
}
