using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api.Request;
using MYDZ.Business.TB_Logic.SDK_UMP.Response;
using Top.Api.Util;
using Top.Api;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Request
{
    internal class TmallPromotagTagRemovetagRequest : ITopRequest<TmallPromotagTagRemovetagResponse>
    {
        /// <summary>
        /// 需要删除的标签id
        /// </summary>
        public long TagId { get; set; }

        public string GetApiName()
        {
            return "tmall.promotag.tag.removetag";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("name", this.TagId);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("name", this.TagId);
        }
    }
}
