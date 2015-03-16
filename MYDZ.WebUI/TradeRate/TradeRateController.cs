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
using System.Threading.Tasks;

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
                        tradeRatestr.Tid = item.Tid;
                        listtrade.AddRange(GetListtrade(tradeRatestr, out TotalResults));
                    }
                }
            }
            else
            {
                listtrade = GetListtrade(tradeRatestr, out TotalResults);
            }
            ViewData["totalpage"] = TotalResults % 40 == 0 ? TotalResults % 40 : Convert.ToInt32(TotalResults / 40) + 1;
            return View(listtrade);
        }

        private List<Trade> GetListtrade(tradeRateQueryCls tradeRatestr, out long TotalResults)
        {
            string errorMsg = string.Empty;
            bool hasnext = false;
            tbClientUser clientuser = GetUser("UserInfo");
            TotalResults = 0;
            TradesSoldGet TradesSold = new TradesSoldGet();
            TradesSold.Tid = tradeRatestr.Tid == 0 ? null : tradeRatestr.Tid.ToString();
            //获取买家已评,卖家未评价订单信息
            if (string.IsNullOrEmpty(tradeRatestr.RateStatus))
                TradesSold.RateStatus = null;
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
        /// 保存评价模板
        /// </summary>
        /// <param name="result"></param>
        /// <param name="content"></param>
        /// <param name="sortid"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveRateTmple(string result, string content, int sortid = 0)
        {
            bool res = false;
            tbClientUser clientuser = GetUser("UserInfo");
            Tb_TradeRate ttr = new Tb_TradeRate();
            ttr.Content = content;
            ttr.Result = result;
            ttr.Role = "seller";
            ttr.ShopId = clientuser.UserShops[0].Shop.ShopId;
            List<Tb_TradeRate> listtt = new List<Tb_TradeRate>();
            listtt = br.GetTradeRateByShopId(clientuser.UserShops[0].Shop.ShopId);
            if (listtt.Count > 0)
            {
                listtt.Sort((left, right) =>
                {
                    if (left.SortID > right.SortID)
                        return -1;
                    else if (left.SortID == right.SortID)
                        return 0;
                    else
                        return 1;
                });
                ttr.SortID = listtt[0].SortID + 1;
            }
            else
            {
                ttr.SortID = 1;
            }
            if (br.AddRate(ttr))
                res = true;
            return Json(new { Result = res });
        }

        /// <summary>
        /// 删除评价模板
        /// </summary>
        /// <param name="sortid"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteRateTemple(int sortid)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            return Json(new { Result = br.DeleteRate(sortid, clientuser.UserShops[0].Shop.ShopId) });
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
        [HttpPost]
        public Task<JsonResult> batchUpdateRate(string OidList, int sortid, bool IsSystemDefault = false)
        {
            tbClientUser clientuser = GetUser("UserInfo");

            return Task.Factory.StartNew(() =>
            {
                if (string.IsNullOrEmpty(OidList))
                {
                    try
                    {
                        Tb_TradeRate ttr = new Tb_TradeRate();
                        if (IsSystemDefault)
                        {
                            ttr = br.GetTradeRateBySortId(sortid, clientuser.UserShops[0].Shop.ShopId);
                        }
                        else
                        {
                            ttr = br.GetTradeRateBySortId(sortid, -1);
                        }
                        string[] oiditems = OidList.Split(',');
                        traderateAddQueryCls traderatestr = new traderateAddQueryCls();
                        traderatestr.Content = ttr.Content;
                        traderatestr.Result = ttr.Result;
                        foreach (string item in oiditems)
                        {
                            traderatestr.Oid = Convert.ToInt64(item);
                            iit.AddTradeRate(clientuser.UserShops[0].SessionKey, traderatestr);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }).ContinueWith<JsonResult>(task =>
            {
                return Json(new { Result = true });
            });
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
