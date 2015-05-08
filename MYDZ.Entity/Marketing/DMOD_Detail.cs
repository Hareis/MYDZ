using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MYDZ.Entity.Marketing
{
    /// <summary>
    ///限时打折包邮 活动详情
    /// </summary>
    public class DMOD_Detail : Response
    {
        /// <summary>
        /// 是否减钱
        /// </summary>
        public bool IsDecrease { get; set; }
        /// <summary>
        /// 是否打折
        /// </summary>
        public bool IsDiscount { get; set; }
        /// <summary>
        /// 是否包邮
        /// </summary>
        public bool IsFreePostage { get; set; }
        /// <summary>
        /// 是否全部减钱
        /// </summary>
        public bool IsCalcDecrMultiple { get; set; }
        /// <summary>
        /// 减钱金额 单位是分
        /// </summary>
        public string DecreaseMoney { get; set; }
        /// <summary>
        /// 折扣率 不打折则赋值1000
        /// </summary>
        public string DiscountRate { get; set; }
        /// <summary>
        /// 优惠范围 类型应该为枚举
        /// </summary>
        public object ParticipateType { get; set; }
        /// <summary>
        /// 工具ID
        /// </summary>
        public int ToolId { get; set; }
        /// <summary>
        /// 活动ID
        /// </summary>
        public long ActId { get; set; }

    }
}
