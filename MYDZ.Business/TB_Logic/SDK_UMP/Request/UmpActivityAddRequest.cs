using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Business.TB_Logic.SDK_UMP.Response;
using Top.Api;
using Top.Api.Util;
using Top.Api.Request;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Request
{
    /// <summary>
    /// 新增优惠活动
    /// </summary>
    internal class UmpActivityAddRequest : ITopRequest<UmpActivityAddResponse>
    {
        /// <summary>
        /// 工具id
        /// </summary>
        public long ToolId { get; set; }

        /// <summary>
        /// 活动内容，通过ump sdk里面的MarkeitngTool来生成
        /// </summary>
        public string Content { get; set; }

        private IDictionary<string, string> otherParameters;

        public string GetApiName()
        {
            return "taobao.ump.activity.add";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("tool_id", this.ToolId);
            parameters.Add("content", this.Content);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("tool_id", this.ToolId);
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
