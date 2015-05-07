﻿using System;
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
    /// 给用户移除优惠标签
    /// </summary>
    internal class TmallPromotagTaguserRemoveRequest : ITopRequest<TmallPromotagTaguserRemoveResponse>
    {
        /// <summary>
        /// 标签ID
        /// </summary>
        public long TagId { get; set; }
        /// <summary>
        /// 买家昵称
        /// </summary>
        public string Nick { get; set; }

        public string GetApiName()
        {
            return "tmall.promotag.taguser.remove";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("tag_id", this.TagId);
            parameters.Add("nick", this.Nick);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("tag_id", this.TagId);
            RequestValidator.ValidateRequired("nick", this.Nick);
        }
    }
}