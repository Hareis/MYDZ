using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api.Request;
using Top.Api.Response;
using Top.Api;
using MYDZ.Entity.Traderate;

namespace MYDZ.Business.TB_Logic.TradeRates
{
    /// <summary>
    /// 评价
    /// </summary>
    public class GetTraderates
    {
        /// <summary>
        /// 搜索评价信息[搜索评价信息，只能获取距今180天内的评价记录(只支持查询卖家给出或得到的评价)。]
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="tradeRatestr"></param>
        /// <returns></returns>
        internal List<TradeRate> GetTraderateList(string sessionKey, tradeRateQueryCls tradeRatestr)
        {
            List<TradeRate> listrate = new List<TradeRate>();
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret);
            TraderatesGetRequest req = new TraderatesGetRequest();
            req.Fields = "tid,oid,role,nick,result,created,rated_nick,item_title,item_price,content,reply,num_iid";
            if (string.IsNullOrEmpty(tradeRatestr.RateType)) { return null; }
            req.RateType = tradeRatestr.RateType;
            if (string.IsNullOrEmpty(tradeRatestr.Role)) { return null; }
            req.Role = tradeRatestr.Role;
            req.Result = tradeRatestr.Result;
            req.PageNo = tradeRatestr.PageNo;
            req.PageSize = tradeRatestr.PageSize;

            DateTime dateTime = tradeRatestr.StartDate.HasValue ? tradeRatestr.StartDate.Value : DateTime.Now.AddMonths(-1);
            req.StartDate = DateTime.Parse(dateTime.Date.ToString("yyyy-MM-dd"));
            DateTime dateTime1 = tradeRatestr.EndDate.HasValue ? tradeRatestr.EndDate.Value : DateTime.Now;
            req.EndDate = DateTime.Parse(dateTime1.Date.ToString("yyyy-MM-dd"));

            req.Tid = tradeRatestr.Tid;
            req.UseHasNext = tradeRatestr.UseHasNext;
            req.NumIid = tradeRatestr.NumIid;
            TraderatesGetResponse response = client.Execute(req, sessionKey);
            if (response.IsError)
            {
                return null;
            }
            else
            {
                TradeRate tr = null;
                foreach (Top.Api.Domain.TradeRate item in response.TradeRates)
                {
                    tr = new TradeRate();
                    tr.Content = item.Content;
                    tr.Created = item.Created;
                    tr.ItemPrice = item.ItemPrice;
                    tr.ItemTitle = item.ItemTitle;
                    tr.Nick = item.Nick;
                    tr.NumIid = item.NumIid;
                    tr.Oid = item.Oid;
                    tr.RatedNick = item.RatedNick;
                    tr.Reply = item.Reply;
                    tr.Result = item.Result;
                    tr.Role = item.Role;
                    tr.Tid = tr.Tid;
                    tr.ValidScore = tr.ValidScore;
                    listrate.Add(tr);
                }
            }
            return listrate;
        }

        /// <summary>
        ///  新增单个评价[注：在评价之前需要对订单成功的时间进行判定（end_time）,如果超过15天，不能再通过该接口进行评价)]
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="traderatestr"></param>
        /// <returns></returns>
        internal TradeRate AddTradeRate(string sessionKey, traderateAddQueryCls traderatestr)
        {
            TradeRate tr = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret);
            TraderateAddRequest req = new TraderateAddRequest();
            if (traderatestr.Tid != null)
                req.Tid = traderatestr.Tid;
            else return null;
            req.Oid = traderatestr.Oid;
            if (!string.IsNullOrEmpty(traderatestr.Result))
                req.Result = traderatestr.Result;
            else return null;
            if (!string.IsNullOrEmpty(traderatestr.Role))
                req.Role = traderatestr.Role;
            else return null;
            req.Content = traderatestr.Content;
            req.Anony = traderatestr.Anony;
            TraderateAddResponse response = client.Execute(req, sessionKey);
            if (response.IsError)
            {
                return null;
            }
            else
            {
                tr = new TradeRate();
                tr.Content = response.TradeRate.Content;
                tr.Created = response.TradeRate.Created;
                tr.ItemPrice = response.TradeRate.ItemPrice;
                tr.ItemTitle = response.TradeRate.ItemTitle;
                tr.Nick = response.TradeRate.Nick;
                tr.NumIid = response.TradeRate.NumIid;
                tr.Oid = response.TradeRate.Oid;
                tr.RatedNick = response.TradeRate.RatedNick;
                tr.Reply = response.TradeRate.Reply;
                tr.Result = response.TradeRate.Result;
                tr.Role = response.TradeRate.Role;
                tr.Tid = response.TradeRate.Tid;
                tr.ValidScore = response.TradeRate.ValidScore;
            }
            return tr;
        }

        /// <summary>
        /// 商城评价解释接口[注：在评价之前需要对订单成功的时间进行判定（end_time）,如果超过30天，不能再通过该接口进行评价)]
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="Oid">子订单ID</param>
        /// <param name="Reply">评价解释内容,最大长度: 500个汉字</param>
        /// <returns>完成结果</returns>
        internal bool AddTradeRateExplain(string sessionKey, long Oid, string Reply)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret);
            TraderateExplainAddRequest req = new TraderateExplainAddRequest();
            if (Oid != null)
                req.Oid = Oid;
            else return false;
            if (!string.IsNullOrEmpty(Reply))
                req.Reply = Reply;
            else return false;
            TraderateExplainAddResponse response = client.Execute(req, sessionKey);
            if (response.IsError)
            {
                return false;
            }
            else
            {
                return response.IsSuccess;
            }
        }

        /// <summary>
        /// 针对父子订单新增批量评价[注：在评价之前需要对订单成功的时间进行判定（end_time）,如果超过15天，不用再通过该接口进行评价]
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="traderatestr"></param>
        /// <returns></returns>
        internal TradeRate AddTradeRateList(string sessionKey, tradeRateQueryCls traderatestr)
        {
            TradeRate tr = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret);
            TraderateListAddRequest req = new TraderateListAddRequest();
            if (traderatestr.Tid != null)
                req.Tid = traderatestr.Tid;
            else return null;
            if (!string.IsNullOrEmpty(traderatestr.Result))
                req.Result = traderatestr.Result;
            else return null;
            if (!string.IsNullOrEmpty(traderatestr.Role))
                req.Role = traderatestr.Role;
            else return null;
            req.Content = traderatestr.Content;
            req.Anony = traderatestr.Anony;
            TraderateListAddResponse response = client.Execute(req, sessionKey);
            if (response.IsError)
            {
                return null;
            }
            else
            {
                tr = new TradeRate();
                tr.Content = response.TradeRate.Content;
                tr.Created = response.TradeRate.Created;
                tr.ItemPrice = response.TradeRate.ItemPrice;
                tr.ItemTitle = response.TradeRate.ItemTitle;
                tr.Nick = response.TradeRate.Nick;
                tr.NumIid = response.TradeRate.NumIid;
                tr.Oid = response.TradeRate.Oid;
                tr.RatedNick = response.TradeRate.RatedNick;
                tr.Reply = response.TradeRate.Reply;
                tr.Result = response.TradeRate.Result;
                tr.Role = response.TradeRate.Role;
                tr.Tid = response.TradeRate.Tid;
                tr.ValidScore = response.TradeRate.ValidScore;
            }
            return tr;
        }


    }
}
