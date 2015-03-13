using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.Order
{
    /// <summary>
    /// 订单获取配置表
    /// </summary>
    [Serializable]
    public class tbOrdersConfig
    {
        /// <summary>
        /// 配置编号
        /// </summary>
        public int ConfigId { get; set; }

        /// <summary>
        /// 店铺编号
        /// </summary>
        public int ShopId { get; set; }

        /// <summary>
        /// 判断付款
        /// </summary>
        public bool JudgePay { get; set; }

        /// <summary>
        /// 合并订单
        /// </summary>
        public bool MergerOrder { get; set; }

        /// <summary>
        /// 退款打印
        /// </summary>
        public bool RefundPrint { get; set; }

        /// <summary>
        /// 付款时间
        /// </summary>
        public int PayTime { get; set; }

        /// <summary>
        /// 备注旗帜
        /// </summary>
        public int RemarkFlag { get; set; }

        /// <summary>
        /// 备注内容
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 货到付款使用物流
        /// </summary>
        public string CashDelivery { get; set; }

        /// <summary>
        /// 物流自动分配
        /// </summary>
        public bool LogisticsDis { get; set; }

        /// <summary>
        /// 订单获取配置详情列表
        /// </summary>
        public List<tbConfigDetail> DetailList { get; set; }
    }
}
