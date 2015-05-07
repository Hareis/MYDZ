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
    /// 优惠标签申请
    /// </summary>
    internal class TmallPromotagTagApplyRequest : ITopRequest<TmallPromotagTagApplyResponse>
    {
        /// <summary>
        /// 标签名称。 注意在UMP中使用新人群标签top变成大写的“NEW_” 如：老标签是top1234，新标签是NEW_1234 。
        /// </summary>
        public string TagName { get; set; }
        /// <summary>
        /// 标签用途描述
        /// </summary>
        public string TagDesc { get; set; }
        /// <summary>
        /// 标签开始时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 标签结束时间
        /// </summary>
        public string EndTime { get; set; }

        public string GetApiName()
        {
            return "tmall.promotag.tag.apply";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("tag_name", this.TagName);
            parameters.Add("tag_desc", this.TagDesc);
            parameters.Add("start_time", this.StartTime);
            parameters.Add("end_time", this.EndTime);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("tag_name", this.TagName);
            RequestValidator.ValidateRequired("tag_desc", this.TagDesc);
            RequestValidator.ValidateRequired("start_time", this.StartTime);
            RequestValidator.ValidateRequired("end_time", this.EndTime);
        }
    }
}
