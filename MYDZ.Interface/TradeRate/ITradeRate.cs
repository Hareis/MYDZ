using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Traderate;

namespace MYDZ.Interface.TradeRate
{
    public interface ITradeRate : BaseInterface
    {
        /// <summary>
        /// 店铺是否已经设置了评价模板
        /// </summary>
        /// <param name="shopid"></param>
        bool ExitRateByShopId(int shopid);

        /// <summary>
        /// 添加一条评价内容
        /// </summary>
        /// <param name="TTradeRate"></param>
        /// <returns></returns>
        bool AddRate(Tb_TradeRate tTradeRate);

        /// <summary>
        /// 更新评价内容
        /// </summary>
        /// <param name="tTradeRate"></param>
        /// <returns></returns>
        bool UpdateRate(Tb_TradeRate tTradeRate);

        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="TradeRateId"></param>
        /// <returns></returns>
        bool DeleteRate(int TradeRateId);
        /// <summary>
        /// 查询评价 by sorid
        /// </summary>
        /// <param name="RateId"></param>
        /// <returns></returns>
        Tb_TradeRate GetTradeRateByRateId(int sortId, int shopid);

        /// <summary>
        /// 查询评价by shopid
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        List<Tb_TradeRate> GetTradeRateByShopId(int shopId);
    }
}
