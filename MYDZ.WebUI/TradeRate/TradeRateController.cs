using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Common;
using System.Web.Mvc;
using MYDZ.Business.Business_Logic.TradeRates;
using MYDZ.Entity.Traderate;
using MYDZ.Entity.ClientUser;
using MYDZ.Business.Business_Logic.Order;
using MYDZ.Entity.Order;
using MYDZ.Business.DataBase_BLL.TradeRate;

namespace MYDZ.WebUI.TradeRate
{
    public class TradeRateController : BaseController
    {
        InitTraderates iit = new InitTraderates();
        InitTradeInfo iiti = new InitTradeInfo();
        BTradeRate br = new BTradeRate();

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            return View();
        }

        /// <summary>
        /// 加载评价数据
        /// </summary>
        /// <returns></returns>
        public ViewResult OnloadRate(tradeRateQueryCls tradeRatestr)
        {
            #region
            /* tradeRatestr.RateType = "get";
             tradeRatestr.Role = "buyer";
             tradeRatestr.PageNo = tradeRatestr.PageNo == null ? 1 : tradeRatestr.PageNo;
             tradeRatestr.PageSize = tradeRatestr.PageSize > 0 ? tradeRatestr.PageSize : 40;
             //获取最近一个月评价记录
             List<Entity.Traderate.TradeRate> listrate = new List<Entity.Traderate.TradeRate>();
             listrate = iit.GetTraderateList(clientuser.UserShops[0].SessionKey, tradeRatestr);*/
            #endregion
            tbClientUser clientuser = GetUser("UserInfo");
            string errorMsg = string.Empty;
            bool hasnext = false;
            long TotalResults = 0;
            TradesSoldGet TradesSold = new TradesSoldGet();
            List<Trade> listtrade = new List<Trade>();
            if (tradeRatestr.StartDate != null || tradeRatestr.EndDate != null)
            {
                tradeRatestr.RateType = "get";
                tradeRatestr.Role = "buyer";
                List<Entity.Traderate.TradeRate> listrate = new List<Entity.Traderate.TradeRate>();
                listrate = iit.GetTraderateList(clientuser.UserShops[0].SessionKey, tradeRatestr);
                if (listrate != null)
                {
                    foreach (Entity.Traderate.TradeRate item in listrate)
                    {
                        tradeRatestr.Tid = item.Oid;
                        listtrade.AddRange(GetListtrade(tradeRatestr));
                    }
                }
            }
            else
            {
                listtrade = GetListtrade(tradeRatestr);
            }
            return View(listtrade);
        }

        private List<Trade> GetListtrade(tradeRateQueryCls tradeRatestr)
        {
            string errorMsg = string.Empty;
            bool hasnext = false;
            long TotalResults = 0;
            tbClientUser clientuser = GetUser("UserInfo");

            TradesSoldGet TradesSold = new TradesSoldGet();
            TradesSold.Tid = tradeRatestr.Tid == 0 ? null : tradeRatestr.Tid.ToString();
            //获取买家已评,卖家未评价订单信息
            if (string.IsNullOrEmpty(tradeRatestr.RateStatus))
                TradesSold.RateStatus = "RATE_UNSELLER";
            else
                TradesSold.RateStatus = tradeRatestr.RateStatus;
            TradesSold.BuyerNick = tradeRatestr.BuyerNick;
            TradesSold.PageNo = tradeRatestr.PageNo;
            tradeRatestr.PageSize = tradeRatestr.PageSize;
            if (tradeRatestr.Tid == null)
            {
                return iiti.GetTradesSoldToTradeRate(clientuser.UserShops[0].SessionKey, TradesSold, out errorMsg, out hasnext, out TotalResults);
            }
            else
            {
                List<Trade> lisaa = new List<Trade>();
                Trade trade = new Trade();
                trade = iiti.GetTrade(clientuser.UserShops[0].SessionKey, tradeRatestr.Tid.ToString(), out errorMsg);
                lisaa.Add(trade);
                return lisaa;
            }
        }

        public ViewResult SaveRate()
        {
            return View();
        }

        /// <summary>
        /// 评价模板
        /// </summary>
        /// <returns></returns>
        public ViewResult RateTemple()
        {
            tbClientUser clientuser = GetUser("UserInfo");
            //取系统默认评价模板
            ViewData["systemtemper"] = br.GetTradeRateByShopId(-1);
            return View(br.GetTradeRateByShopId(clientuser.UserShops[0].Shop.ShopId));
        }

        /// <summary>
        ///添加订单评价
        /// </summary>
        /// <param name="traderatestr"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveRate(traderateAddQueryCls traderatestr)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            string errorMsg = string.Empty;
            Trade listtrade = new Trade();
            listtrade = iiti.GetTrade(clientuser.UserShops[0].SessionKey, traderatestr.Oid.ToString(), out errorMsg);
            if (listtrade != null || errorMsg == null)
            {
                if (DateTime.Now.Date.AddDays(-15).CompareTo(DateTime.Parse(listtrade.EndTime).Date) <= 0)
                    iit.AddTradeRate(clientuser.UserShops[0].SessionKey, traderatestr);
            }
            return Json(new { Result = true });
        }

        /// <summary>
        /// 批量订单评价
        /// </summary>
        /// <returns></returns>
        public JsonResult batchUpdateRate(string OidList)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            if (string.IsNullOrEmpty(OidList))
            {
                try
                {
                    Tb_TradeRate ttr = new Tb_TradeRate();
                    ttr = br.GetTradeRateBySortId(0, clientuser.UserShops[0].Shop.ShopId);
                    string[] oiditems = OidList.Split(',');
                    traderateAddQueryCls traderatestr = new traderateAddQueryCls();
                    traderatestr.Content = ttr.Content;
                    traderatestr.Result = ttr.Result;
                    foreach (string item in oiditems)
                    {
                        traderatestr.Oid = Convert.ToInt32(item);
                        iit.AddTradeRate(clientuser.UserShops[0].SessionKey, traderatestr);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Json(new { Result = true });
        }

        /// <summary>
        /// 父子订单批量评价
        /// </summary>
        /// <param name="traderatestr"></param>
        /// <returns></returns>
        public JsonResult ParentRateList(tradeRateQueryCls traderatestr)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            string errorMsg = string.Empty;
            Trade listtrade = new Trade();
            listtrade = iiti.GetTrade(clientuser.UserShops[0].SessionKey, traderatestr.Tid.ToString(), out errorMsg);
            if (listtrade != null || errorMsg == null)
            {
                if (DateTime.Now.Date.AddDays(-15).CompareTo(DateTime.Parse(listtrade.EndTime).Date) <= 0)
                    iit.AddTradeRateList(clientuser.UserShops[0].SessionKey, traderatestr);
            }
            return Json(new { Result = true });

        }

        /// <summary>
        /// 商场评价解释接口
        /// </summary>
        /// <param name="Oid"></param>
        /// <param name="Reply"></param>
        /// <returns></returns>
        public JsonResult TraderateExplain(long Oid, string Reply)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            tradeRateQueryCls tradeRatestr = new tradeRateQueryCls();
            List<Entity.Traderate.TradeRate> listrate = new List<Entity.Traderate.TradeRate>();
            tradeRatestr.Tid = Oid;
            listrate = iit.GetTraderateList(clientuser.UserShops[0].SessionKey, tradeRatestr);
            if (listrate != null)
            {
                if (DateTime.Now.Date.AddDays(-15).CompareTo(DateTime.Parse(listrate[0].Created).Date) <= 0)
                    iit.AddTradeRateExplain(clientuser.UserShops[0].SessionKey, Oid, Reply);
            }
            return Json("");
        }

    }
}
