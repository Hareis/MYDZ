using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.Order
{
    /// <summary>
    /// 订单同步状态表
    /// </summary>
    [Serializable]
    public class tbOrderSync
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 是否正在同步
        /// </summary>
        public bool Sync { get; set; }

        /// <summary>
        /// 同步类型
        /// </summary>
        public int SyncEnum { get; set; }

        /// <summary>
        /// 最后同步时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }
    }
}
