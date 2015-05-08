using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Business.TB_Logic.SDK_UMP.Response;
using Top.Api.Request;
using Top.Api;
using Top.Api.Util;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Request
{
    /// <summary>
    ///  新增优惠工具
    /// </summary>
    internal class UmpToolAddRequest : ITopRequest<UmpToolAddResponse>
    {
        /// <summary>
        /// 工具内容，由sdk里面的MarketingTool生成的json字符串
        /// </summary>
        public string Content { get; set; }

        private IDictionary<string, string> otherParameters;

        public string GetApiName()
        {
            return "taobao.ump.tool.add";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("content", this.Content);
            return parameters;
        }

        public void Validate()
        {
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
