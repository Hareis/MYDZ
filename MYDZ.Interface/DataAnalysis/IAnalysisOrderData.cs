using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.DataAnalysis;
using MYDZ.Entity.Order;
using System.Collections;

namespace MYDZ.Interface.DataAnalysis
{
    /// <summary>
    /// 分析订单数据
    /// </summary>
    public interface IAnalysisOrderData : BaseInterface
    {
        /// <summary>
        /// 每日要闻
        /// </summary>
        IList<Shopdata> DailyHighlights(int shopId, DateTime StartTime, DateTime EndtTime);

        /// <summary>
        /// 商品销售量分析
        /// </summary>
        IList<tbOrdersDetail> ProductAnalysis(int shopId, DateTime StartTime, DateTime EndtTime);

        /// <summary>
        /// 订单支付人数
        /// </summary>
        IList<Shopdata> payForOrder(int shopId, DateTime StartTime, DateTime EndtTime);

        /// <summary>
        /// 地区购买人数
        /// </summary>
        Hashtable GetShopAreaData(int shopId, DateTime StartTime, DateTime EndtTime);
    }
}
