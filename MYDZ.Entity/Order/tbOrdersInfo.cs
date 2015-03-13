using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Shop;

namespace MYDZ.Entity.Order
{
    /// <summary>
    /// 订单信息表
    /// </summary>
    [Serializable]
    public class tbOrdersInfo
    {
        /// <summary>
        /// 主键，自动编号
        /// </summary>
        public int OrdersId { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrdersNumber { get; set; }

        /// <summary>
        /// 会员昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 配送方式(String)
        /// </summary>
        public string LogisticsStr { get; set; }

        /// <summary>
        /// 配送方式
        /// </summary>
        public Logistic Logistics { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public tbOrdersStatus Status { get; set; }

        /// <summary>
        /// 店铺编号
        /// </summary>
        public tbShopInfo Shop { get; set; }

        /// <summary>
        /// 客服编号
        /// </summary>
        public int CustomerServiceId { get; set; }

        /// <summary>
        /// 是否有退款
        /// </summary>
        public bool IsOrdersReFund { get; set; }

        /// <summary>
        /// 是否打印
        /// </summary>
        public bool IsOrdersPrint { get; set; }

        /// <summary>
        /// 是否有清单
        /// </summary>
        public bool IsInventory { get; set; }

        /// <summary>
        /// 是否包邮
        /// </summary>
        public bool IsFree { get; set; }

        /// <summary>
        /// 订单重量(g)
        /// </summary>
        public int OrdersWeight { get; set; }

        /// <summary>
        /// 订单运费
        /// </summary>
        public int OrdersFreight { get; set; }

        /// <summary>
        /// 商品总金额
        /// </summary>
        public decimal OrdersProductTotal { get; set; }

        /// <summary>
        /// 订单折扣
        /// </summary>
        public decimal OrdersDiscount { get; set; }

        /// <summary>
        /// 订单应收金额
        /// </summary>
        public decimal OrdersAccounts { get; set; }

        /// <summary>
        /// 订单实收金额
        /// </summary>
        public decimal OrdersPaid { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrdersDate { get; set; }

        /// <summary>
        /// 付款时间
        /// </summary>
        public DateTime PayDate { get; set; }

        /// <summary>
        /// 订单录入时间
        /// </summary>
        public DateTime OrdersInputDate { get; set; }

        /// <summary>
        /// 客服备注
        /// </summary>
        public string ServiceNotes { get; set; }

        /// <summary>
        /// 客服备注旗帜样式
        /// </summary>
        public string ServiceFlag { get; set; }

        /// <summary>
        /// 订单备注
        /// </summary>
        public string OrdersNotes { get; set; }

        /// <summary>
        /// 订单备注旗帜样式
        /// </summary>
        public string OrdersFlag { get; set; }

        /// <summary>
        /// 订单外部交易号
        /// </summary>
        public string OrdersOutNumber { get; set; }

        /// <summary>
        /// 是否为货到付款订单
        /// </summary>
        public bool CashOndelivery { get; set; }

        /// <summary>
        /// 是否开具发票
        /// </summary>
        public bool Invoice { get; set; }

        /// <summary>
        /// 配送日期
        /// </summary>
        public string DeliveryDate { get; set; }

        /// <summary>
        /// 买家留言
        /// </summary>
        public string BuyerMsg { get; set; }

        /// <summary>
        /// 买家备注
        /// </summary>
        public string BuyerRemark { get; set; }

        /// <summary>
        /// 买家备注旗帜样式
        /// </summary>
        public string RemarkFlag { get; set; }

        /// <summary>
        /// 交易佣金
        /// </summary>
        public decimal Commission { get; set; }

        /// <summary>
        /// 货到付款服务费
        /// </summary>
        public decimal CodFee { get; set; }

        /// <summary>
        /// 订单详情列表
        /// </summary>
        public List<tbOrdersDetail> Details;

        /// <summary>
        /// 收货信息
        /// </summary>
        public tbConsigneeInfo Consignee;

        /// <summary>
        /// 买家信息
        /// </summary>
        public tbBuyerInfo Buyer;
    }
}
