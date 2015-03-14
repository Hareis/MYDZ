using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.TradeRate;
using MYDZ.Entity.Traderate;

namespace MYDZ.Business.DataBase_BLL.TradeRate
{
    public class BTradeRate
    {
        public static ITradeRate SetTradeRate = (ITradeRate)DALFactory.DataAccess.Create("TradeRate.RateSet");

        /// <summary>
        /// 店铺是否已经设置了评价模板
        /// </summary>
        /// <param name="shopid"></param>
        public bool ExitRateByShopId(int shopid)
        {
            return SetTradeRate.ExitRateByShopId(shopid);
        }

        /// <summary>
        /// 添加一条评价内容
        /// </summary>
        /// <param name="TTradeRate"></param>
        /// <returns></returns>
        public bool AddRate(Tb_TradeRate tTradeRate)
        {
            return SetTradeRate.AddRate(tTradeRate);
        }

        /// <summary>
        /// 更新评价内容
        /// </summary>
        /// <param name="tTradeRate"></param>
        /// <returns></returns>
        public bool UpdateRate(Tb_TradeRate tTradeRate)
        {
            return SetTradeRate.UpdateRate(tTradeRate);
        }

        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="TradeRateId"></param>
        /// <returns></returns>
        public bool DeleteRate(int TradeRateId)
        {
            return SetTradeRate.DeleteRate(TradeRateId);
        }
        /// <summary>
        /// 查询评价 by sortid
        /// </summary>
        /// <param name="RateId"></param>
        /// <returns></returns>
        public Tb_TradeRate GetTradeRateBySortId(int sortId, int shopid)
        {
            return SetTradeRate.GetTradeRateByRateId(sortId, shopid);
        }

        /// <summary>
        /// 查询评价by shopid
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public List<Tb_TradeRate> GetTradeRateByShopId(int shopId)
        {
            return SetTradeRate.GetTradeRateByShopId(shopId);
        }

    }
}
