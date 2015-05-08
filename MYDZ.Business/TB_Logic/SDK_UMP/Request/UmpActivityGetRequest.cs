using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using Top.Api.Util;
using Top.Api.Request;
using MYDZ.Business.TB_Logic.SDK_UMP.Response;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Request
{
    class UmpActivityGetRequest : ITopRequest<UmpActivityGetResponse>
    {
        /// <summary>
        /// 活动id
        /// </summary>
        public long ActId { get; set; }

        private IDictionary<string, string> otherParameters;

        public string GetApiName()
        {
            return "taobao.ump.activity.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("act_id", this.ActId);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("tool_id", this.ActId);
        }
    }
}
