using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Order;
using MYDZ.Business.TB_Logic.Order;

namespace MYDZ.Business.Business_Logic.Order
{
    public class InitTradeInfo
    {
        GetTradeInfo gti = new GetTradeInfo();

        /// <summary>
        /// 查询卖家已卖出的交易数据（根据创建时间）
        /// </summary>
        /// <param name="token"></param>
        /// <param name="TradesSold"></param>
        /// <param name="ErrorMsg"></param>
        /// <param name="HasNext"></param>
        /// <param name="TotalResults"></param>
        /// <returns></returns>
        public List<Trade> GetTradesSold(string token, TradesSoldGet TradesSold, out string ErrorMsg, out bool HasNext, out long TotalResults)
        {
            return gti.GetTradesSold(token, TradesSold, out ErrorMsg, out HasNext, out TotalResults);
        }

        /// <summary>
        /// 获取单笔交易的部分信息(性能高) 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="tid"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        public Trade GetTrade(string token, string tid, out string ErrorMsg)
        {
            return gti.GetTrade(token, tid, out ErrorMsg);
        }

        /// <summary>
        /// 查询卖家已卖出的增量交易数据（根据修改时间）
        /// </summary>
        /// <param name="token"></param>
        /// <param name="TradesSold"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        public List<Trade> GetTradesSoldIncrement(string token, TradesSoldGet TradesSold, out string ErrorMsg)
        {
            return gti.GetTradesSoldIncrement(token, TradesSold, out ErrorMsg);
        }

        /// <summary>
        /// 添加备注
        /// </summary>
        /// <param name="token"></param>
        /// <param name="Tid"></param>
        /// <param name="Memo"></param>
        /// <param name="Flag"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        public Trade AddTradeMemo(string token, string Tid, string Memo, int Flag, out string ErrorMsg)
        {
            return gti.AddTradeMemo(token, Tid, Memo, Flag, out ErrorMsg);
        }

        /// <summary>
        /// 更改收货地址
        /// </summary>
        /// <param name="token"></param>
        /// <param name="TradeShipping"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        public Trade UpdateTradeShippingAddress(string token, TradeShippingaddressUpdate TradeShipping, out string ErrorMsg)
        {
            return gti.UpdateTradeShippingAddress(token, TradeShipping, out ErrorMsg);
        }

        /// <summary>
        /// 关闭交易
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="Tid"></param>
        /// <param name="CloseReason"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        public bool CloseTrade(string token, string Tid, string CloseReason, out string ErrorMsg)
        {
            return gti.CloseTrade(token, Tid, CloseReason, out ErrorMsg);
        }

        /// <summary>
        ///  获取单笔交易的详细信息
        /// </summary>
        /// <param name="token">sessionkey</param>
        /// <param name="tid">交易编号</param>
        /// <param name="ShopId">店铺ID</param>
        /// <param name="ShopLogistics">店铺物流</param>
        /// <param name="ErrorMsg">错误信息</param>
        /// <returns></returns>
        public tbOrdersInfo GetTradeFullinfo(string token, string tid, int ShopId, out string ErrorMsg)
        {
            return gti.GetTradeFullinfo(token, tid, ShopId, out ErrorMsg);
        }

        /// <summary>
        ///  查询支持起始地到目的地范围的物流公司
        /// </summary>
        /// <param name="ServiceType"></param>
        /// <param name="IsNeedCarriage"></param>
        /// <param name="SourceId"></param>
        /// <param name="TargetId"></param>
        /// <param name="GoodsValue"></param>
        /// <returns></returns>
        public List<LogisticsPartner> GetLogisticsPartners(string ServiceType, bool? IsNeedCarriage, string SourceId = null, string TargetId = null, string GoodsValue = null)
        {
            List<LogisticsPartner> List = new List<LogisticsPartner>();
            if (Comm.AreaList == null)
            {
                Comm.AreaList = gti.GetAreas();
            }
            if (Comm.AreaList != null && Comm.AreaList.Count > 0)
            {
                if (!String.IsNullOrEmpty(SourceId))
                {
                    Area area = Comm.AreaList.FirstOrDefault((e) => { return e.Name.Trim().Equals(SourceId.Trim()); });
                    if (area != null) { SourceId = area.Id.ToString(); } else { return List; }
                }

                if (!String.IsNullOrEmpty(TargetId))
                {
                    Area area = Comm.AreaList.FirstOrDefault((e) => { return e.Name.Trim().Equals(TargetId.Trim()); });
                    if (area != null) { TargetId = area.Id.ToString(); } else { return List; }
                }
            }
            else
            {
                return List;
            }
            return gti.GetLogisticsPartners(ServiceType, IsNeedCarriage, SourceId, TargetId, GoodsValue);
        }

        /// <summary>
        ///查询发货状态
        /// </summary>
        /// <param name="token"></param>
        /// <param name="TradeId"></param>
        /// <returns></returns>
        public StatusTable SelectDelivery(string token, string TradeId)
        {
            return gti.SelectDelivery(token, TradeId);
        }


         /// <summary>
        /// 订单发货
        /// </summary>
        /// <param name="SessionKey">SessionKey</param>
        /// <param name="OutNumber">订单编号</param>
        /// <param name="CompanyCode">物流编码</param>
        /// <param name="DeliveryNumber">发货单号</param>
        /// <returns></returns>
        public StatusTable ToDelivery(string token, string OutNumber, string CompanyCode, string DeliveryNumber)
        {
            return gti.ToDelivery(token, OutNumber, CompanyCode, DeliveryNumber);
        }

        /// <summary>
        /// 获取订单数据（订单评价）
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="TradesSold"></param>
        /// <param name="ErrorMsg"></param>
        /// <param name="HasNext"></param>
        /// <param name="TotalResults"></param>
        /// <returns></returns>
        public List<Trade> GetTradesSoldToTradeRate(string sessionKey, TradesSoldGet TradesSold, out string ErrorMsg, out bool HasNext, out long TotalResults)
        {
            return gti.GetTradesSoldToTradeRate(sessionKey, TradesSold, out ErrorMsg, out HasNext, out TotalResults);
        }
    }
}
