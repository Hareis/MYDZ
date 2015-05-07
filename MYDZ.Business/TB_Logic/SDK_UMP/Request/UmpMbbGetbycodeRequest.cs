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
    internal class UmpMbbGetbycodeRequest : ITopRequest<UmpMbbGetbycodeResponse>
    {
        /// <summary>
        /// 营销积木块code  示例：com.taobao.ump.meta.action.discount
        /// </summary>
        public string Code { get; set; }

        public string GetApiName()
        {
            return "taobao.ump.mbb.getbycode";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("code", this.Code);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("code", this.Code);
        }
    }
}
