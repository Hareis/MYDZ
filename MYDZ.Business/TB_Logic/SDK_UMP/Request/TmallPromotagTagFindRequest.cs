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
    /// <summary>
    /// 查询标签接口 
    /// </summary>
    internal class TmallPromotagTagFindRequest : ITopRequest<TmallPromotagTagFindResponse>
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageNo { get; set; }
        /// <summary>
        /// 每页显示个数  
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 标签名称，查询时可选项
        /// </summary>
        public string TagName { get; set; }
        /// <summary>
        /// 标签ID
        /// </summary>
        public int TagId { get; set; }

        private IDictionary<string, string> otherParameters;

        public string GetApiName()
        {
            return "tmall.promotag.tag.find";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("tag_name", this.TagName);
            parameters.Add("tag_id", this.TagId);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.AddAll(otherParameters);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("page_no", this.PageNo);
            RequestValidator.ValidateRequired("page_size", this.PageSize);
        }
    }
}
