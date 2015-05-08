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
    internal class UmpToolUpdateRequest : ITopRequest<UmpToolUpdateResponse>
    {
        /// <summary>
        /// 工具id
        /// </summary>
        public int ToolId { get; set; }
        /// <summary>
        /// 工具的内容
        /// </summary>
        public string Content { get; set; }

        public string GetApiName()
        {
            return "taobao.ump.tool.update";
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
    }
}
