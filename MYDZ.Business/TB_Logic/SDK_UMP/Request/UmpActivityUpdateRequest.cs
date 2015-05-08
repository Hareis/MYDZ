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
    internal class UmpActivityUpdateRequest : ITopRequest<UmpActivityUpdateResponse>
    {
        /// <summary>
        /// 活动id
        /// </summary>
        public long ActId { get; set; }

        /// <summary>
        /// 营销活动内容，json格式，通过ump sdk 的marketingTool来生成
        /// </summary>
        public string Content { get; set; }

        private IDictionary<string, string> otherParameters;

        public string GetApiName()
        {
            return "taobao.ump.activity.update";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("act_id", this.ActId);
            parameters.Add("content", this.Content);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("tool_id", this.ActId);
            RequestValidator.ValidateRequired("content", this.Content);
        }

        public void AddOtherParameter(string key, string value)
        {
            if (this.otherParameters == null)
            {
                this.otherParameters = new TopDictionary();
            }
            this.otherParameters.Add(key, value);
        }
    }
}
