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
    /// <summary>
    /// 修改活动详情 
    /// </summary>
    internal class UmpDetailUpdateRequest : ITopRequest<UmpDetailUpdateResponse>
    {
        /// <summary>
        /// 活动详情id
        /// </summary>
        public long DetailId { get; set; }

        /// <summary>
        /// 活动详情内容，json格式，通过ump sdk 的marketingTool来生成
        /// </summary>
        public string Content { get; set; }

        private IDictionary<string, string> otherParameters;

        public string GetApiName()
        {
            return "taobao.ump.detail.update";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("detail_id", this.DetailId);
            parameters.Add("content", this.Content);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("tool_id", this.DetailId);
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
