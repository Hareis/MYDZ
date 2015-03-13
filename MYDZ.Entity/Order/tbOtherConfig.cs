using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.Order
{
    /// <summary>
    /// 系统其他设置表
    /// </summary>
    [Serializable]
    public class tbOtherConfig
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 是否打印配货单
        /// </summary>
        public bool Invoice { get; set; }

        /// <summary>
        /// 是否自动计算发货单高度
        /// </summary>
        public bool AutoHeight { get; set; }
    }
}
