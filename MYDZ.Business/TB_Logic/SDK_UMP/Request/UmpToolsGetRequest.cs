using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api.Request;
using MYDZ.Business.TB_Logic.SDK_UMP.Response;
using Top.Api;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Request
{
    internal class UmpToolsGetRequest : ITopRequest<UmpToolsGetResponse>
    {
        /// <summary>
        ///工具编码
        /// </summary>
        public int ToolCode { get; set; }

        private IDictionary<string, string> otherParameters;

        public string GetApiName()
        {
           return "taobao.ump.tools.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("act_id", this.ToolCode);
            return parameters;
        }

        public void Validate()
        {
            throw new NotImplementedException();
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
