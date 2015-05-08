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
    internal class UmpRangeGetRequest : ITopRequest<UmpRangeGetResponse>
    {
        /// <summary>
        /// 活动id
        /// </summary>
        public int ActId { get; set; }

        public string GetApiName()
        {
            return "taobao.ump.range.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("act_id", this.ActId);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("act_id", this.ActId);
        }
    }
}
