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
    public class UmpActivitiesGetRequest : ITopRequest<UmpActivitiesGetResponse>
    {
        /// <summary>
        /// 工具的id
        /// </summary>
        public long ToolId { get; set; }

        /// <summary>
        /// 分页的页码
        /// </summary>
        public int PageNo { get; set; }

        /// <summary>   
        /// 每页的最大条数
        /// </summary>
        public int PageSize { get; set; }

        private IDictionary<string, string> otherParameters;

        public string GetApiName()
        {
            return "taobao.ump.activities.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("tool_id", this.ToolId);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("tool_id", this.ToolId);
            RequestValidator.ValidateRequired("page_no", this.PageNo);
            RequestValidator.ValidateRequired("page_size", this.PageSize);
        }
    }
}
