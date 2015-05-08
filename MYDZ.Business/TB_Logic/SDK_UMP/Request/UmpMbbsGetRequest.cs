using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api.Request;
using MYDZ.Business.TB_Logic.SDK_UMP.Response;
using Top.Api;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Request
{
    internal class UmpMbbsGetRequest : ITopRequest<UmpMbbsGetResponse>
    {
        /// <summary>
        /// 积木块类型。如果该字段为空表示查出所有类型的 现在有且仅有如下几种：resource,condition,action,target
        /// </summary>
        public string Type { get; set; }

        private IDictionary<string, string> otherParameters;

        public string GetApiName()
        {
            return "taobao.ump.mbbs.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("type", this.Type);
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
