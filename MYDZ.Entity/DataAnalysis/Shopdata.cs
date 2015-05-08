using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.DataAnalysis
{
    /// <summary>
    /// 每日店报
    /// </summary>
    public class Shopdata : Response
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string Paydate { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public float OrderPrice { get; set; }


        /// <summary>
        /// 成交金额
        /// </summary>
        public float TransactionCountPrice { get; set; }

        /// <summary>
        /// 成交笔数
        /// </summary>
        public int TransactionCount { get; set; }

        /// <summary>
        /// 订单笔数
        /// </summary>
        public int OrderCount { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int ShopId { get; set; }
    }
}
