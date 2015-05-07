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
    internal class UmpRangeDeleteRequest : ITopRequest<UmpRangeDeleteResponse>
    {
        /// <summary>
        /// 活动id
        /// </summary>
        public int ActId { get; set; }

        /// <summary>
        /// 范围的类型，比如是全店，商品，类目见：MarketingConstants.PARTICIPATE_TYPE_*
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// id列表，当范围类型为商品时，该id为商品id；当范围类型为类目时，该id为类目id
        /// </summary>
        public string Ids { get; set; }

        public string GetApiName()
        {
            return "taobao.ump.range.delete";
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
            RequestValidator.ValidateRequired("act_id", this.ActId);
            RequestValidator.ValidateRequired("type", this.Type);
            RequestValidator.ValidateRequired("ids", this.Ids);
        }
    }
}
