using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.Marketing
{
    public class LP_Detail : Response
    {
        /// <summary>
        /// 工具ID
        /// </summary>
        public int ToolId { get; set; }
        /// <summary>
        /// 活动ID
        /// </summary>
        public int ActId { get; set; }
        /// <summary>
        /// 限购数量
        /// </summary>
        public int LimitCount { get; set; }
        /// <summary>
        /// 不包邮地区
        /// </summary>
        public string ExcludeAreaData { get; set; }
        /// <summary>
        /// 是否有不包邮
        /// </summary>
        public bool IsexcludeArea { get; set; }
        /// <summary>
        /// 是否包邮
        /// </summary>
        public bool EnableFreePostage { get; set; }
    }
}
