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
    internal class UmpDetailGetRequest : ITopRequest<UmpDetailGetResponse>
    {
        /// <summary>
        /// 活动详情的id
        /// </summary>
        public long DetailId { get; set; }

        public string GetApiName()
        {
            return "taobao.ump.detail.get";
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
