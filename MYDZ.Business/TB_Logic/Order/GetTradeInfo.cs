using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using MYDZ.Entity.Order;
using System.Xml.Serialization;
using Top.Api.Parser;
using MYDZ.Entity.ClientUser;
using MYDZ.Entity.Shop;

namespace MYDZ.Business.TB_Logic.Order
{
    internal class GetTradeInfo
    {

        /// <summary>
        /// 查询卖家已卖出的交易数据（根据创建时间）
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="TradesSold"></param>
        /// <param name="ErrorMsg">错误信息</param>
        /// <param name="HasNext">是否存在下一页</param>
        /// <param name="TotalResults">总行数</param>
        /// <returns></returns>
        internal List<Trade> GetTradesSold(string sessionKey, TradesSoldGet TradesSold, out string ErrorMsg, out bool HasNext, out long TotalResults)
        {
            ErrorMsg = null;
            HasNext = false;
            TotalResults = 0;
            List<Trade> ListTrades = new List<Trade>();
            try
            {
                ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
                TradesSoldGetRequest req = new TradesSoldGetRequest();
                req.Fields = "tid,created,pay_time,end_time,status,price,buyer_nick";

                if (TradesSold.StartCreated != null)
                {
                    string startt = TradesSold.StartCreated.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    DateTime dateTime = DateTime.Parse(startt);
                    req.StartCreated = dateTime;
                }
                if (TradesSold.EndCreated != null)
                {
                    string endt = TradesSold.EndCreated.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    DateTime dateTime = DateTime.Parse(endt);
                    req.EndCreated = dateTime;
                }
                if (TradesSold.Status != null)
                    req.Status = TradesSold.Status;
                if (TradesSold.BuyerNick != null)
                    req.BuyerNick = TradesSold.BuyerNick;
                /* fixed(一口价) auction(拍卖) guarantee_trade(一口价、拍卖) step(分阶段付款，万人团，阶梯团订单） 
                 * independent_simple_trade(旺店入门版交易) independent_shop_trade(旺店标准版交易) 
                 * auto_delivery(自动发货) ec(直冲) cod(货到付款) game_equipment(游戏装备) shopex_trade(ShopEX交易)
                 * netcn_trade(万网交易) external_trade(统一外部交易) instant_trade (即时到账) b2c_cod(大商家货到付款) 
                 * hotel_trade(酒店类型交易) super_market_trade(商超交易) super_market_cod_trade(商超货到付款交易)
                 * taohua(淘花网交易类型） waimai(外卖交易类型） o2o_offlinetrade（O2O交易） nopaid（即时到帐/趣味猜交易类型）
                 * step (万人团) eticket(电子凭证) tmall_i18n（天猫国际）;nopaid （无付款交易）insurance_plus（保险）
                 * finance（基金） 注：guarantee_trade是一个组合查询条件，并不是一种交易类型，获取批量或单个订单中不会返回此种类型的订单。
                 * pre_auth_type(预授权0元购)
                 */
                TradesSold.Type += "guarantee_trade, step," +
                                   " independent_simple_trade, independent_shop_trade, " +
                                   " auto_delivery, ec,cod, game_equipment, shopex_trade," +
                                   " netcn_trade, external_trade, instant_trade , b2c_cod," +
                                   " hotel_trade, super_market_trade, super_market_cod_trade," +
                                   " taohua,waimai, o2o_offlinetrade, nopaid,pre_auth_type," +
                                   " step, eticket, tmall_i18n,nopaid ,insurance_plus, finance";

                if (TradesSold.Type != null)
                    req.Type = TradesSold.Type;
                if (TradesSold.ExtType != null)
                    req.ExtType = TradesSold.ExtType;
                if (TradesSold.RateStatus != null)
                    req.RateStatus = TradesSold.RateStatus;
                if (TradesSold.Tag != null)
                    req.Tag = TradesSold.Tag;
                if (TradesSold.PageNo != null)
                    req.PageNo = TradesSold.PageNo;
                if (TradesSold.PageSize != null)
                    req.PageSize = TradesSold.PageSize;
                if (TradesSold.UseHasNext != null)
                    req.UseHasNext = TradesSold.UseHasNext;
                TradesSoldGetResponse response = client.Execute(req, sessionKey);
                if (response.IsError)
                {
                    ErrorMsg = response.SubErrMsg;
                }
                else
                {
                    TopJsonParser topjson = new TopJsonParser();
                    TradesSoldGetResponse1 resp = topjson.Parse<TradesSoldGetResponse1>(response.Body);
                    ListTrades = resp.Trades;
                    if (TradesSold.UseHasNext == true)
                    {
                        HasNext = resp.HasNext;
                    }
                    else
                    {
                        TotalResults = resp.TotalResults;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListTrades;
        }

        /// <summary>
        /// 交易转化类
        /// </summary>
        internal class TradesSoldGetResponse1 : TopResponse
        {
            [XmlElement("has_next")]
            public bool HasNext { get; set; }
            [XmlElement("total_results")]
            public long TotalResults { get; set; }
            [XmlArray("trades")]
            [XmlArrayItem("trade")]
            public List<Trade> Trades { get; set; }
        }

        /// <summary>
        /// 查询卖家已卖出的增量交易数据（根据修改时间）
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="TradesSold"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        internal List<Trade> GetTradesSoldIncrement(string sessionKey, TradesSoldGet TradesSold, out string ErrorMsg)
        {
            ErrorMsg = null;
            List<Trade> ListTrades = new List<Trade>();
            DateTime starttime = new DateTime();
            DateTime endtime = new DateTime();
            try
            {
                ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
                TradesSoldIncrementGetRequest req = new TradesSoldIncrementGetRequest();
                req.Fields = "tid,created,pay_time,end_time,status,snapshot_url,buyer_message,price,buyer_nick,seller_memo,seller_flag,orders";
                if (TradesSold.StartCreated != null)
                {

                    string startt = TradesSold.StartModified.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    starttime = DateTime.Parse(startt);
                    req.StartModified = starttime;
                }
                if (TradesSold.EndCreated != null)
                {
                    string startt = TradesSold.EndModified.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    endtime = DateTime.Parse(startt);
                    req.EndModified = endtime;
                }
                //这里修正结束时间与开始时间间隔超一天,自动修改时间为开始时间的后一天
                if (starttime != new DateTime() && endtime != new DateTime())
                {
                    if (endtime.Subtract(starttime).Days > 1)
                    {
                        req.EndModified = starttime.AddDays(1);
                    }
                }
                if (TradesSold.Status != null)
                    req.Status = TradesSold.Status;
                if (TradesSold.Type != null)
                    req.Type = TradesSold.Type;
                if (TradesSold.ExtType != null)
                    req.ExtType = TradesSold.ExtType;
                if (TradesSold.Tag != null)
                    req.Tag = TradesSold.Tag;
                if (TradesSold.PageNo != null)
                    req.PageNo = TradesSold.PageNo;
                if (TradesSold.PageSize != null)
                    req.PageSize = TradesSold.PageSize;
                if (TradesSold.UseHasNext != null)
                    req.UseHasNext = TradesSold.UseHasNext;
                TradesSoldIncrementGetResponse response = client.Execute(req, sessionKey);
                if (response.IsError)
                {
                    ErrorMsg = response.SubErrMsg;
                }
                else
                {
                    TopJsonParser topjson = new TopJsonParser();
                    TradesSoldGetResponse1 resp = topjson.Parse<TradesSoldGetResponse1>(response.Body);
                    ListTrades = resp.Trades;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ListTrades;
        }

        /// <summary>
        /// 获取单笔交易的部分信息(性能高) 
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="tid"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        internal Trade GetTrade(string sessionKey, string tid, out string ErrorMsg)
        {
            ErrorMsg = null;
            List<Trade> ListTrades = new List<Trade>();
            try
            {
                ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
                TradeGetRequest req = new TradeGetRequest();
                req.Fields = "tid,created,pay_time,end_time,status,snapshot_url,buyer_message,price,buyer_nick ,seller_nick, buyer_nick, title, type, created, tid, seller_rate,seller_can_rate, buyer_rate,can_rate, status, payment, discount_fee, adjust_fee, post_fee, total_fee, pay_time, end_time, modified, consign_time, buyer_obtain_point_fee, point_fee, real_point_fee, received_payment, pic_path, num_iid, num, price, cod_fee, cod_status, shipping_type, receiver_name, receiver_state, receiver_city, receiver_district, receiver_address, receiver_zip, receiver_mobile, receiver_phone,seller_flag,alipay_id,alipay_no,is_lgtype,is_force_wlb,is_brand_sale,buyer_area,has_buyer_message, credit_card_fee, lg_aging_type, lg_aging, step_trade_status,step_paid_fee,mark_desc,has_yfx,yfx_fee,yfx_id,yfx_type,trade_source,send_time,is_daixiao,is_wt,is_part_consign,zero_purchase,orders";
                if (tid == null)
                {
                    ErrorMsg = "交易编号不能为空！";
                    return null;
                }
                req.Tid = long.Parse(tid);
                TradeGetResponse response = client.Execute(req, sessionKey);
                if (response.IsError)
                {
                    ErrorMsg = response.SubErrMsg;
                    return null;
                }
                else
                {
                    TopJsonParser topjson = new TopJsonParser();
                    TradeMemoAddResponse1 resp = topjson.Parse<TradeMemoAddResponse1>(response.Body);
                    return resp.Trade;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取单笔交易的详细信息
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="tid"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        internal tbOrdersInfo GetTradeFullinfo(string sessionKey, string tid, int ShopId, out string ErrorMsg)
        {
            //show_ext 这个字段导致接口报错
            tbOrdersInfo newtrade = null;
            try
            {
                ErrorMsg = null;
                ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
                TradeFullinfoGetRequest req = new TradeFullinfoGetRequest();
                req.Fields += "seller_nick, buyer_nick, title, type, created, tid, seller_rate, buyer_rate,";
                req.Fields += " status, payment, adjust_fee, post_fee, total_fee, pay_time, end_time, modified, ";
                req.Fields += "consign_time, buyer_obtain_point_fee, point_fee, real_point_fee, received_payment, commission_fee,";
                req.Fields += "seller_memo, alipay_no,alipay_id,buyer_message, pic_path, num_iid, num, price, ";
                req.Fields += "receiver_name, receiver_state, receiver_city, receiver_district, receiver_address,";
                req.Fields += "receiver_zip, receiver_mobile, receiver_phone,seller_flag, seller_alipay_no, seller_mobile, ";
                req.Fields += "seller_phone, seller_name, seller_email, available_confirm_fee, has_post_fee, timeout_action_time,";
                req.Fields += "snapshot_url, cod_fee, cod_status, shipping_type, trade_memo, buyer_email,buyer_area,";
                req.Fields += "trade_from,is_lgtype,is_force_wlb,is_brand_sale,buyer_cod_fee,discount_fee,seller_cod_fee,";
                req.Fields += "express_agency_fee,invoice_name,service_orders,credit_cardfee,step_trade_status,step_paid_fee,";
                req.Fields += "mark_desc,has_yfx,yfx_fee,yfx_id,yfx_type,trade_source,eticket_ext,send_time, is_daixiao,";
                req.Fields += "is_part_consign, arrive_interval, arrive_cut_time, consign_interval,zero_purchase,alipay_point,pcc_af,";
                req.Fields += "orders,promotion_details,invoice_name,orders.is_www,orders.store_code,service_tags";
                if (!string.IsNullOrEmpty(tid))
                {
                    req.Tid = long.Parse(tid);
                }
                else
                {
                    ErrorMsg = "订单编号不能为空";
                    return null;
                }
                TradeFullinfoGetResponse response = client.Execute(req, sessionKey);
                if (response.IsError)
                {
                    ErrorMsg = response.SubErrMsg;
                    return null;
                }
                else
                {
                    Top.Api.Domain.Trade trade = new Top.Api.Domain.Trade();
                    newtrade = new tbOrdersInfo();
                    //订单信息转化
                    newtrade = ChangeLocationType(response.Trade, ShopId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return newtrade;
        }

        /// <summary>
        /// 将淘宝的交易信息转化为本地类型
        /// </summary>
        /// <param name="trade"></param>
        /// <returns></returns>
        private tbOrdersInfo ChangeLocationType(Top.Api.Domain.Trade trade, int ShopId)
        {
            try
            {
                tbOrdersInfo newtrade = new tbOrdersInfo();
                tbConsigneeInfo Consignee = new tbConsigneeInfo();
                tbBuyerInfo Buyer = new tbBuyerInfo();
                List<tbOrdersDetail> Details = new List<tbOrdersDetail>();

                if (!String.IsNullOrEmpty(trade.PayTime))
                {
                    newtrade.PayDate = Convert.ToDateTime(Comm.DataChange(trade.PayTime, TypeChange.DATETIME));//付款时间
                }
                else
                {
                    newtrade.PayDate = DateTime.Now;
                }

                newtrade.CustomerServiceId = 1;
                newtrade.CashOndelivery = false;
                newtrade.Invoice = false;
                newtrade.NickName = trade.BuyerNick.Trim();//会员名
                Buyer.NickName = trade.BuyerNick.Trim();//会员名
                newtrade.Commission = Convert.ToDecimal(Comm.DataChange(trade.CommissionFee, TypeChange.DECIMAL));
                newtrade.OrdersOutNumber = trade.Tid.ToString().Trim();//淘宝订单号
                newtrade.Logistics = new Logistic();

                newtrade.LogisticsStr = trade.ShippingType;//暂存物流
                newtrade.OrdersFreight = Convert.ToInt32(Comm.DataChange(trade.PostFee, TypeChange.DECIMAL));

                newtrade.OrdersProductTotal = Convert.ToDecimal(Comm.DataChange(trade.TotalFee, TypeChange.DECIMAL));//商品总金额
                newtrade.OrdersDate = Convert.ToDateTime(Comm.DataChange(trade.Created, TypeChange.DATETIME));//交易创建时间
                Consignee.Name = Comm.DataChange(trade.ReceiverName, TypeChange.STRING).ToString();//收件人姓名
                Buyer.BuyerName = Consignee.Name;
                Consignee.OrdersNumber = trade.Tid == null ? "" : trade.Tid.ToString();
                Consignee.Provice = Comm.DataChange(trade.ReceiverState, TypeChange.STRING).ToString();//收件人所在省
                Consignee.City = Comm.DataChange(trade.ReceiverCity, TypeChange.STRING).ToString();//收件人所在市
                Consignee.District = Comm.DataChange(trade.ReceiverDistrict, TypeChange.STRING).ToString();//收件人所在区
                Consignee.ConsigneeAddress = Comm.DataChange(trade.ReceiverAddress, TypeChange.STRING).ToString();//收件人地址
                Consignee.PostCode = Comm.DataChange(trade.ReceiverZip, TypeChange.STRING).ToString();//收件人邮编
                Consignee.Mobile = Comm.DataChange(trade.ReceiverMobile, TypeChange.STRING).ToString();//收件人手机
                Buyer.Mobile = Consignee.Mobile;
                Consignee.Phone = Comm.DataChange(trade.ReceiverPhone, TypeChange.STRING).ToString();//收件人电话
                Buyer.Phone = Consignee.Phone;
                newtrade.Status = new tbOrdersStatus() { OrdersStatusId = 3 };//订单状态(默认买家已付款，等待卖家发货状态)
                decimal Payment = Convert.ToDecimal(Comm.DataChange(trade.Payment, TypeChange.DECIMAL));//订单实收金额
                newtrade.OrdersAccounts = Payment;
                newtrade.OrdersPaid = Payment;
                newtrade.IsOrdersReFund = false;//是否有退款
                newtrade.OrdersDiscount = newtrade.OrdersPaid - newtrade.OrdersProductTotal - newtrade.OrdersFreight;//订单折扣
                newtrade.OrdersWeight = 0;
                newtrade.OrdersNotes = "";
                newtrade.OrdersFlag = "0";
                newtrade.OrdersInputDate = DateTime.Now;
                Consignee.InputDate = newtrade.OrdersInputDate;
                //买家留言&卖家备注&备注旗帜&邮件地址
                newtrade.ServiceNotes = trade.SellerMemo;//客服备注
                newtrade.ServiceFlag = trade.SellerFlag.ToString();//客服备注旗帜样式
                newtrade.BuyerMsg = string.IsNullOrEmpty(trade.BuyerMessage) ? "" : trade.BuyerMessage;//买家留言
                Buyer.BuyerEmail = trade.BuyerEmail;
                newtrade.CodFee = Convert.ToDecimal(Comm.DataChange(trade.CodFee, TypeChange.DECIMAL));//货到付款服务费
                newtrade.BuyerRemark = "";
                newtrade.DeliveryDate = "";
                newtrade.RemarkFlag = "";
                newtrade.Shop = new tbShopInfo() { ShopId = ShopId };
                if (trade.Orders != null)
                {
                    foreach (Top.Api.Domain.Order order in trade.Orders)
                    {
                        if (Convert.ToInt32(order.Num) <= 0) { continue; }

                        tbOrdersDetail Detail = new tbOrdersDetail();
                        Detail.OrdersNumber = trade.Tid.ToString();
                        Detail.ProductEncoding = !String.IsNullOrEmpty(order.OuterSkuId) ? order.OuterSkuId.Trim() : "";
                        Detail.ProductName = !String.IsNullOrEmpty(order.Title) ? order.Title.Trim() : "";
                        Detail.ProductSku = !String.IsNullOrEmpty(order.SkuPropertiesName) ? order.SkuPropertiesName.Trim() : "";
                        Detail.ProductId = Convert.ToInt32(order.NumIid);
                        Detail.ProductProId = 0;
                        Detail.SalesCommissionId = 1;
                        Detail.ProductImg = String.IsNullOrEmpty(order.PicPath) ? "" : order.PicPath.Trim();//商品图片
                        Detail.ProductPrice = Convert.ToDecimal(Comm.DataChange(order.Price, TypeChange.DECIMAL));//商品价格
                        Detail.ProductNumber = (int)order.Num;//商品数量
                        Detail.PackageName = String.IsNullOrEmpty(order.ItemMealName) ? "" : order.ItemMealName;//商品套餐值
                        Detail.OutNumberIId = order.NumIid == null ? "" : order.NumIid.ToString();//商品外部编号
                        Detail.SubOrderNumber = order.Oid.ToString() == null ? "" : order.Oid.ToString();//子订单编号
                        Detail.InputDate = newtrade.OrdersInputDate;
                        Detail.ProductTotal = Convert.ToDecimal(Comm.DataChange(order.TotalFee, TypeChange.DECIMAL));//商品总价
                        Detail.Details = "";
                        Detail.ProductCost = 0;
                        Detail.OrdersDiscount = Convert.ToDecimal(Comm.DataChange(order.DiscountFee, TypeChange.DECIMAL));//优惠金额;
                        Detail.OrdersAdjust = Convert.ToDecimal(Comm.DataChange(order.AdjustFee, TypeChange.DECIMAL));//手动调整金额;
                        Detail.OrdersAccounts = Detail.ProductTotal;

                        //订单被取消
                        if (order.Status == "TRADE_CLOSED_BY_TAOBAO")
                        {
                            Detail.IsCanceled = true;
                        }

                        //商品退款
                        if (order.RefundId == 0)
                        {
                            Detail.ReFundNumber = "";
                            Detail.IsProductReFund = false;
                            Detail.ReFundStatusId = 0;
                            Detail.ReFundStatusName = order.RefundStatus;
                        }
                        else
                        {
                            Detail.ReFundNumber = order.RefundId.ToString();
                            Detail.IsProductReFund = true;
                            newtrade.IsOrdersReFund = true;
                            Detail.ReFundStatusId = 0;
                            Detail.ReFundStatusName = "";
                        }

                        Details.Add(Detail);
                    }
                }

                newtrade.Consignee = Consignee;
                newtrade.Details = Details;
                newtrade.Buyer = Buyer;
                return newtrade;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 添加一条备注
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="Tid">交易编号</param>
        /// <param name="Memo">交易备注。最大长度: 1000个字节</param>
        /// <param name="Flag">交易备注旗帜，可选值为：0(灰色), 1(红色), 2(黄色), 3(绿色), 4(蓝色), 5(粉红色)，默认值为0</param>
        /// <param name="ErrorMsg">错误信息</param>
        /// <returns></returns>
        internal Trade AddTradeMemo(string sessionKey, string Tid, string Memo, int Flag, out string ErrorMsg)
        {
            ErrorMsg = null;
            Trade newtrade = new Trade();
            try
            {
                ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
                TradeMemoAddRequest req = new TradeMemoAddRequest();
                if (!string.IsNullOrEmpty(Tid))
                {
                    req.Tid = long.Parse(Tid);
                }
                else
                {
                    ErrorMsg = "订单编号不能为空！";
                    return null;
                }
                req.Memo = Memo;
                req.Flag = Flag;
                TradeMemoAddResponse response = client.Execute(req, sessionKey);
                if (response.IsError)
                {
                    ErrorMsg = response.SubErrMsg;
                    return null;
                }
                else
                {
                    TopJsonParser topjson = new TopJsonParser();
                    TradeMemoAddResponse1 resp = topjson.Parse<TradeMemoAddResponse1>(response.Body);
                    if (!response.IsError)
                    {
                        newtrade = resp.Trade;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return newtrade;
        }

        /// <summary>
        /// 修改一笔交易备注 
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="tid"></param>
        /// <param name="memo"></param>
        /// <param name="flag"></param>
        /// <param name="reset"></param>
        internal void UpdateTradeMemo(string sessionKey, string tid, string memo, int flag, bool? reset)
        {
            try
            {
                ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
                TradeMemoUpdateRequest req = new TradeMemoUpdateRequest();
                if (!string.IsNullOrEmpty(tid))
                {
                    req.Tid = long.Parse(tid);
                }
                else
                {
                    return;
                }
                req.Memo = memo;
                req.Flag = flag;
                req.Reset = reset;
                TradeMemoUpdateResponse response = client.Execute(req, sessionKey);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 临时转化类
        /// </summary>
        internal class TradeMemoAddResponse1 : TopResponse
        {
            [XmlElement("trade")]
            public Trade Trade { get; set; }
        }

        /// <summary>
        /// 更改交易的收货地址 
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="TradeShipping"></param>
        /// <param name="ErrorMsg"></param>
        internal Trade UpdateTradeShippingAddress(string sessionKey, TradeShippingaddressUpdate TradeShipping, out string ErrorMsg)
        {
            ErrorMsg = null;
            Trade newtrade = new Trade();
            try
            {
                ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
                TradeShippingaddressUpdateRequest req = new TradeShippingaddressUpdateRequest();
                if (TradeShipping.Tid != null)
                {
                    req.Tid = 2755739791L;
                }
                else
                {
                    ErrorMsg = "交易编号不能为空！";
                    return null;
                }
                req.ReceiverName = TradeShipping.ReceiverName;
                req.ReceiverPhone = TradeShipping.ReceiverPhone;
                req.ReceiverMobile = TradeShipping.ReceiverMobile;
                req.ReceiverState = TradeShipping.ReceiverState;
                req.ReceiverCity = TradeShipping.ReceiverCity;
                req.ReceiverDistrict = TradeShipping.ReceiverDistrict;
                req.ReceiverAddress = TradeShipping.ReceiverAddress;
                req.ReceiverZip = TradeShipping.ReceiverZip;
                TradeShippingaddressUpdateResponse response = client.Execute(req, sessionKey);
                if (response.IsError)
                {
                    ErrorMsg = response.SubErrMsg;
                    return null;
                }
                else
                {
                    TopJsonParser topjson = new TopJsonParser();
                    TradeMemoAddResponse1 resp = topjson.Parse<TradeMemoAddResponse1>(response.Body);
                    if (!response.IsError)
                    {
                        newtrade = resp.Trade;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return newtrade;
        }

        /// <summary>
        /// 修改订单邮费价格
        /// </summary>
        /// <returns></returns>
        internal Trade UpdateTradePostage(string sessionKey, string Tid, string PostFee, out string ErrorMsg)
        {
            ErrorMsg = null;
            Trade newtrade = new Trade();
            try
            {
                ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
                TradePostageUpdateRequest req = new TradePostageUpdateRequest();
                if (!string.IsNullOrEmpty(Tid))
                {
                    req.Tid = long.Parse(Tid);
                }
                else
                {
                    ErrorMsg = "交易编号不能为空！";
                    return null;
                }
                req.PostFee = PostFee;
                TradePostageUpdateResponse response = client.Execute(req, sessionKey);
                if (response.IsError)
                {
                    ErrorMsg = response.SubErrMsg;
                    return null;
                }
                else
                {
                    TopJsonParser topjson = new TopJsonParser();
                    TradeMemoAddResponse1 resp = topjson.Parse<TradeMemoAddResponse1>(response.Body);
                    if (!response.IsError)
                    {
                        newtrade = resp.Trade;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return newtrade;
        }

        /// <summary>
        /// 关闭一笔交易
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="Tid">交易ID</param>
        /// <param name="CloseReason">关闭原因</param>
        /// <param name="ErrorMsg">错误原因</param>
        /// <returns></returns>
        public bool CloseTrade(string sessionKey, string Tid, string CloseReason, out string ErrorMsg)
        {
            ErrorMsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            TradeCloseRequest req = new TradeCloseRequest();
            if (string.IsNullOrEmpty(Tid))
            {
                ErrorMsg = "订单编号不能为空！";
                return false;
            }
            else
            {
                req.Tid = 2231978090L;
            }
            req.CloseReason = CloseReason;
            TradeCloseResponse response = client.Execute(req, sessionKey);
            if (response.IsError)
            {
                ErrorMsg = response.SubErrMsg;
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 查询地址区域
        /// </summary>
        /// <returns></returns>
        public List<Area> GetAreas()
        {
            List<Area> AreaList = new List<Area>();
            try
            {
                ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
                AreasGetRequest req = new AreasGetRequest();
                req.Fields = "id,type,name";
                AreasGetResponse response = client.Execute(req);
                if (!response.IsError)
                {
                    Area newarea = null;
                    if (response.Areas != null)
                    {
                        foreach (Top.Api.Domain.Area area in response.Areas)
                        {
                            newarea = new Area();
                            newarea.Id = area.Id;
                            newarea.Name = area.Name;
                            newarea.ParentId = area.ParentId;
                            newarea.Type = area.Type;
                            newarea.Zip = area.Zip;
                            AreaList.Add(newarea);
                        }
                    }
                }
            }
            catch { }

            return AreaList;
        }

        /// <summary>
        /// 查询支持起始地到目的地范围的物流公司
        /// </summary>
        /// <param name="ServiceType">服务类型，</param>
        /// <param name="SourceId">物流公司揽货地地区码</param>
        /// <param name="TargetId">物流公司派送地地区码（</param>
        /// <param name="GoodsValue">货物价格</param>
        /// <param name="IsNeedCarriage">是否需要揽收资费信息</param>
        /// <returns></returns>
        public List<LogisticsPartner> GetLogisticsPartners(string ServiceType, bool? IsNeedCarriage, string SourceId = null, string TargetId = null, string GoodsValue = null)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            LogisticsPartnersGetRequest req = new LogisticsPartnersGetRequest();
            req.ServiceType = ServiceType;
            if (SourceId != null)
                req.SourceId = SourceId;
            if (TargetId != null)
                req.TargetId = TargetId;
            req.IsNeedCarriage = false;
            LogisticsPartnersGetResponse response = client.Execute(req);
            if (!response.IsError)
            {
                TopJsonParser topjson = new TopJsonParser();
                LogisticsPartnersGetResponse1 resp = topjson.Parse<LogisticsPartnersGetResponse1>(response.Body);
                return resp.LogisticsPartners;
            }
            else
            {
                return null;
            }
        }
        private class LogisticsPartnersGetResponse1 : TopResponse
        {
            [XmlArray("logistics_partners")]
            [XmlArrayItem("logistics_partner")]
            public List<LogisticsPartner> LogisticsPartners { get; set; }
        }

        /// <summary>
        /// 查询第三方平台订单物流信息
        /// </summary>
        /// <param name="SessionKey">SessionKey</param>
        /// <param name="OutNumber">外部订单号</param>
        /// <returns></returns>
        internal StatusTable SelectDelivery(string SessionKey, string TradeId)
        {
            StatusTable st = new StatusTable() { Msg = "" };

            try
            {
                ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
                LogisticsOrdersGetRequest req = new LogisticsOrdersGetRequest();
                req.Fields = "out_sid,company_name";
                if (string.IsNullOrEmpty(TradeId))
                {
                    return null;
                }
                else
                {
                    req.Tid = long.Parse(TradeId);
                }
                LogisticsOrdersGetResponse response = client.Execute(req, SessionKey);
                if (!response.IsError)
                {
                    if (response.Shippings.Count > 0)
                    {
                        st.IsSuccess = true;
                        string str = "";
                        foreach (Top.Api.Domain.Shipping ship in response.Shippings)
                        {
                            str = ship.CompanyName + " <font color='red'>" + ship.OutSid + "</font>";
                        }
                        st.Msg = "订单已发货,发货信息[" + str + "]";
                    }
                    else
                    {
                        st.IsSuccess = false;
                        st.Msg = "未查询到该订单的物流信息";
                    }
                }
            }
            catch
            {
                st.IsSuccess = false;
                st.IsError = true;
                st.Msg = "查询该订单物流信息失败";
            }

            return st;
        }

        /// <summary>
        /// 订单发货
        /// </summary>
        /// <param name="SessionKey">SessionKey</param>
        /// <param name="OutNumber">订单编号</param>
        /// <param name="CompanyCode">物流编码</param>
        /// <param name="DeliveryNumber">发货单号</param>
        /// <returns></returns>
        internal StatusTable ToDelivery(string SessionKey, string OutNumber, string CompanyCode, string DeliveryNumber)
        {
            StatusTable st = new StatusTable() { Msg = "" };

            if (!String.IsNullOrEmpty(CompanyCode))
            {
                ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
                LogisticsOfflineSendRequest req = new LogisticsOfflineSendRequest();
                req.Tid = long.Parse(OutNumber);
                req.OutSid = DeliveryNumber;
                req.CompanyCode = CompanyCode;
                LogisticsOfflineSendResponse response = client.Execute(req, SessionKey);
                if (response.Shipping == null)
                {
                    st.Msg = "解析淘宝发货数据失败，可能该订单状态不允许发货";
                }
                else
                {
                    st.IsSuccess = response.Shipping.IsSuccess;
                    if (!st.IsSuccess)
                    {
                        st.Msg = "淘宝发货失败";
                    }
                }
            }
            else
            {
                st.IsSuccess = false;
                st.Msg = "解析淘宝物流公司编码失败";
            }
            return st;
        }

        /// <summary>
        /// 查询卖家已卖出的交易数据（根据创建时间）
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="TradesSold"></param>
        /// <param name="ErrorMsg">错误信息</param>
        /// <param name="HasNext">是否存在下一页</param>
        /// <param name="TotalResults">总行数</param>
        /// <returns></returns>
        internal List<Trade> GetTradesSoldToTradeRate(string sessionKey, TradesSoldGet TradesSold, out string ErrorMsg, out bool HasNext, out long TotalResults)
        {
            ErrorMsg = null;
            HasNext = false;
            TotalResults = 0;
            List<Trade> ListTrades = new List<Trade>();
            try
            {
                ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
                TradesSoldGetRequest req = new TradesSoldGetRequest();
                req.Fields = "seller_nick, buyer_nick, title, type, created, tid, seller_rate,seller_can_rate, buyer_rate,can_rate, status, payment, discount_fee, adjust_fee, post_fee, total_fee, pay_time, end_time, modified, consign_time, buyer_obtain_point_fee, point_fee, real_point_fee, received_payment, pic_path, num_iid, num, price, cod_fee, cod_status, shipping_type, receiver_name, receiver_state, receiver_city, receiver_district, receiver_address, receiver_zip, receiver_mobile, receiver_phone,seller_flag,alipay_id,alipay_no,is_lgtype,is_force_wlb,is_brand_sale,buyer_area,has_buyer_message, credit_card_fee, lg_aging_type, lg_aging, step_trade_status,step_paid_fee,mark_desc,has_yfx,yfx_fee,yfx_id,yfx_type,trade_source,send_time,is_daixiao,is_wt,is_part_consign,zero_purchase,orders";

                if (TradesSold.StartCreated != null)
                {
                    string startt = TradesSold.StartCreated.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    DateTime dateTime = DateTime.Parse(startt);
                    req.StartCreated = dateTime;
                }
                if (TradesSold.EndCreated != null)
                {
                    string endt = TradesSold.EndCreated.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    DateTime dateTime = DateTime.Parse(endt);
                    req.EndCreated = dateTime;
                }
                if (TradesSold.Status != null)
                    req.Status = TradesSold.Status;
                if (TradesSold.BuyerNick != null)
                    req.BuyerNick = TradesSold.BuyerNick;
                /* fixed(一口价) auction(拍卖) guarantee_trade(一口价、拍卖) step(分阶段付款，万人团，阶梯团订单） 
                 * independent_simple_trade(旺店入门版交易) independent_shop_trade(旺店标准版交易) 
                 * auto_delivery(自动发货) ec(直冲) cod(货到付款) game_equipment(游戏装备) shopex_trade(ShopEX交易)
                 * netcn_trade(万网交易) external_trade(统一外部交易) instant_trade (即时到账) b2c_cod(大商家货到付款) 
                 * hotel_trade(酒店类型交易) super_market_trade(商超交易) super_market_cod_trade(商超货到付款交易)
                 * taohua(淘花网交易类型） waimai(外卖交易类型） o2o_offlinetrade（O2O交易） nopaid（即时到帐/趣味猜交易类型）
                 * step (万人团) eticket(电子凭证) tmall_i18n（天猫国际）;nopaid （无付款交易）insurance_plus（保险）
                 * finance（基金） 注：guarantee_trade是一个组合查询条件，并不是一种交易类型，获取批量或单个订单中不会返回此种类型的订单。
                 * pre_auth_type(预授权0元购)
                 */
                TradesSold.Type += "guarantee_trade, step," +
                                   " independent_simple_trade, independent_shop_trade, " +
                                   " auto_delivery, ec,cod, game_equipment, shopex_trade," +
                                   " netcn_trade, external_trade, instant_trade , b2c_cod," +
                                   " hotel_trade, super_market_trade, super_market_cod_trade," +
                                   " taohua,waimai, o2o_offlinetrade, nopaid,pre_auth_type," +
                                   " step, eticket, tmall_i18n,nopaid ,insurance_plus, finance";

                if (TradesSold.Type != null)
                    req.Type = TradesSold.Type;
                if (TradesSold.ExtType != null)
                    req.ExtType = TradesSold.ExtType;
                if (TradesSold.RateStatus != null)
                    req.RateStatus = TradesSold.RateStatus;
                if (TradesSold.Tag != null)
                    req.Tag = TradesSold.Tag;
                if (TradesSold.PageNo != null)
                    req.PageNo = TradesSold.PageNo;
                if (TradesSold.PageSize != null)
                    req.PageSize = TradesSold.PageSize;
                if (TradesSold.UseHasNext != null)
                    req.UseHasNext = TradesSold.UseHasNext;
                TradesSoldGetResponse response = client.Execute(req, sessionKey);
                if (response.IsError)
                {
                    ErrorMsg = response.SubErrMsg;
                }
                else
                {
                    TopJsonParser topjson = new TopJsonParser();
                    TradesSoldGetResponse1 resp = topjson.Parse<TradesSoldGetResponse1>(response.Body);
                    ListTrades = resp.Trades;
                    if (TradesSold.UseHasNext == true)
                    {
                        HasNext = resp.HasNext;
                    }
                    else
                    {
                        TotalResults = resp.TotalResults;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListTrades;
        }


    }
}
