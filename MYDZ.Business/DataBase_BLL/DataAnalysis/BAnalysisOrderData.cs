using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.DataAnalysis;
using MYDZ.Entity.DataAnalysis;
using MYDZ.Entity.Order;
using System.Collections;

namespace MYDZ.Business.DataBase_BLL.DataAnalysis
{
    public class BAnalysisOrderData
    {
        public static IAnalysisOrderData SetAnalysisOrderData = (IAnalysisOrderData)DALFactory.DataAccess.Create("DataAnalysis.AnalysisOrderData");

        /// <summary>
        /// 每日要闻
        /// </summary>
        public IList<Shopdata> DailyHighlights(int shopId, DateTime StartTime, DateTime EndtTime)
        {
            return SetAnalysisOrderData.DailyHighlights(shopId, StartTime, EndtTime);
        }

        /// <summary>
        /// 商品销售量分析
        /// </summary>
        public IList<tbOrdersDetail> ProductAnalysis(int shopId, DateTime StartTime, DateTime EndtTime)
        {
            return SetAnalysisOrderData.ProductAnalysis(shopId, StartTime, EndtTime);
        }


        /// <summary>
        /// 订单支付人数(每小时)
        /// </summary>
        public IList<Shopdata> payForOrder(int shopId, DateTime StartTime, DateTime EndtTime)
        {
            return SetAnalysisOrderData.payForOrder(shopId, StartTime, EndtTime);
        }

        /// <summary>
        /// 地区访问人数
        /// </summary>
        public Hashtable GetShopAreaData(int shopId, DateTime StartTime, DateTime EndtTime)
        {
            return SetAnalysisOrderData.GetShopAreaData(shopId, StartTime, EndtTime);
        }
    }
}
