using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MYDZ.Entity.Marketing
{
    /// <summary>
    /// 满减、满元包邮、打折、送礼物 活动详情
    /// </summary>
    public class ICOOAO_Detail : Response
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
        /// 满件的件数 int
        /// </summary>
        public string Count { get; set; }
        /// <summary>
        /// 是否开启满件
        /// </summary>
        public bool IsenableCountMultiple { get; set; }
        /// <summary>
        /// 满多少元
        /// </summary>
        public string TotalPrice { get; set; }
        /// <summary>
        /// 是否开启满元
        /// </summary>
        public bool IsEnableMultiple { get; set; }
        /// <summary>
        /// 减少多少元 单位：分
        /// </summary>
       [DefaultValue("0")]
        public string DecreaseMoney { get; set; }
        /// <summary>
        /// 是否开启减价
        /// </summary>
        public bool IsDecrease { get; set; }
        /// <summary>
        /// 打几折 默认值为1000
        /// </summary>
        [DefaultValue("1000")]
        public string DiscountRate { get; set; }
        /// <summary>
        /// 是否开启打折
        /// </summary>
        public bool IsDiscount { get; set; }
        /// <summary>
        /// 礼物商品ID
        /// </summary>
        public string GiftId { get; set; }
        /// <summary>
        /// 礼物名称
        /// </summary>
        public string GiftName { get; set; }
        /// <summary>
        /// 礼物链接
        /// </summary>
        public string GiftUrl { get; set; }
        /// <summary>
        /// 是否送礼物
        /// </summary>
        public bool IsSendGift { get; set; }
        /// <summary>
        /// 是否开启包邮
        /// </summary>
        public bool IsFreePostage { get; set; }
    }
}
