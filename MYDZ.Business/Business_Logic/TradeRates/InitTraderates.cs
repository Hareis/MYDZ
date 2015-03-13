using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Business.TB_Logic.TradeRates;
using MYDZ.Entity.Traderate;

namespace MYDZ.Business.Business_Logic.TradeRates
{
    public class InitTraderates
    {
        GetTraderates gt = new GetTraderates();

        /// <summary>
        /// 搜索评价信息
        /// </summary>
        /// <param name="token"></param>
        /// <param name="tradeRatestr"></param>
        /// <returns></returns>
        public List<TradeRate> GetTraderateList(string token, tradeRateQueryCls tradeRatestr)
        {
            return gt.GetTraderateList(token, tradeRatestr);
        }

        /// <summary>
        /// 新增单个评价
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="traderatestr"></param>
        /// <returns></returns>
        public TradeRate AddTradeRate(string token, traderateAddQueryCls traderatestr)
        {
            return gt.AddTradeRate(token, traderatestr);
        }

        /// <summary>
        /// 商城评价解释接口
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="Oid">子订单ID</param>
        /// <param name="Reply">解释内容</param>
        /// <returns></returns>
        public bool AddTradeRateExplain(string sessionKey, long Oid, string Reply)
        {
            return gt.AddTradeRateExplain(sessionKey, Oid, Reply);
        }

        /// <summary>
        ///  针对父子订单新增批量评价
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="traderatestr"></param>
        /// <returns></returns>
        public TradeRate AddTradeRateList(string sessionKey, tradeRateQueryCls traderatestr)
        {
            return gt.AddTradeRateList(sessionKey, traderatestr);
        }
    }
}
