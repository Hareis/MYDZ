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
    internal class UmpToolGetRequest : ITopRequest<UmpToolGetResponse>
    {
        /// <summary>
        /// 工具的id
        /// </summary>
        public int ToolId { get; set; }

        private IDictionary<string, string> otherParameters;

        public string GetApiName()
        {
            return "taobao.ump.tool.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("tool_id", this.ToolId);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("tool_id", this.ToolId);
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
