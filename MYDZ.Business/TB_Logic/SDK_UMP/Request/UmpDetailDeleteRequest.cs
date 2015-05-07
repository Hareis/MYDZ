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
    internal class UmpDetailDeleteRequest : ITopRequest<UmpDetailDeleteResponse>
    {
        /// <summary>
        /// 活动详情id
        /// </summary>
        public long DetailId { get; set; }

        private IDictionary<string, string> otherParameters;

        public string GetApiName()
        {
            return "taobao.ump.detail.delete";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("detail_id", this.DetailId);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("detail_id", this.DetailId);
        }
    }
}
