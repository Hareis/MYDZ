using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Common;
using System.Web.Mvc;
using MYDZ.Business.Business_Logic.Order;
using MYDZ.Entity.ClientUser;
using MYDZ.Entity.Order;
using MYDZ.Entity.Print;
using MYDZ.Business.DataBase_BLL.Print;
using MYDZ.Business.DataBase_BLL.Order;
using System.Collections;
using MYDZ.Config.Font;
using MYDZ.Business.DataBase_BLL.Shop;
using MYDZ.Entity.Shop;
using System.Threading.Tasks;
using MYDZ.Business.DataBase_BLL.ClientUserBLL;
using System.Web.UI;
using System.Text.RegularExpressions;

namespace MYDZ.WebUI.OrderManagement
{
    public class OrderManagementController : BaseController
    {
        InitTradeInfo iti = new InitTradeInfo();

              

       


        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        // [OutputCache(Duration = 1000 * 1, Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult OrderIndex(string param = "")
        {
            tbClientUser clientuser = GetUser("UserInfo");
            IList<StoreLogistics> ListStoreLogistics = BStoreLogistics.SelectInfo(clientuser.UserShops[0].Shop.ShopId);
            if (ListStoreLogistics.Count <= 0)
            {
                Response.Write("<script>document.location.href='/OrderManagement/Delivery.html';</script>");
            }

            IList<tbOrdersStatus> listOrdersStatus = new List<tbOrdersStatus>();
            listOrdersStatus = OrdersStatus.Select();

            tbOrderSync orderSync = new tbOrderSync();
            orderSync = OrderSync.Select(clientuser.UserId, 1);

            Hashtable ht = new Hashtable();

            ht.Add("ListStoreLogistics", ListStoreLogistics);
            ht.Add("listOrdersStatus", listOrdersStatus);
            ht.Add("orderSync", orderSync);
            ViewData["InitInfo"] = ht;

            int UserId = clientuser.UserId; int PageIndex = 1; int ShopId = 0; int LogisId = 0;
            int StatusId = 0; int CateId = 0; int RefundId = 0; int FreeId = 0; int FlagId = 0;
            int SortId = 0; int PrintId = 0; int InvoiceId = 0; string UserNick = ""; string OutNumber = "";
            string Code = ""; string Name = ""; string CName = ""; string Province = ""; string City = "";
            string District = ""; string Tel = ""; string Mobile = ""; string Addr = ""; string Msg = "";
            string SDetail = ""; string ODetail = ""; string CStart = ""; string CEnd = ""; string PStart = "";
            string PEnd = ""; string IStart = ""; string IEnd = "";

            IDictionary<string, string> UrlParams = Tools.Utils.Request(param);

            if (UrlParams.Count > 0)
            {
                foreach (KeyValuePair<string, string> kvp in UrlParams)
                {
                    switch (kvp.Key.Trim())
                    {
                        case "PageIndex":
                            PageIndex = int.Parse(kvp.Value.Trim());
                            break;
                        case "ShopId":
                            ShopId = int.Parse(kvp.Value.Trim());
                            break;
                        case "LogisId":
                            LogisId = int.Parse(kvp.Value.Trim());
                            break;
                        case "StatusId":
                            StatusId = int.Parse(kvp.Value.Trim());
                            break;
                        case "CateId":
                            CateId = int.Parse(kvp.Value.Trim());
                            break;
                        case "RefundId":
                            RefundId = int.Parse(kvp.Value.Trim());
                            break;
                        case "FreeId":
                            FreeId = int.Parse(kvp.Value.Trim());
                            break;
                        case "FlagId":
                            FlagId = int.Parse(kvp.Value.Trim());
                            break;
                        case "SortId":
                            SortId = int.Parse(kvp.Value.Trim());
                            break;
                        case "PrintId":
                            PrintId = int.Parse(kvp.Value.Trim());
                            break;
                        case "InvoiceId":
                            InvoiceId = int.Parse(kvp.Value.Trim());
                            break;
                        case "UserNick":
                            UserNick = kvp.Value.Trim();
                            break;
                        case "OutNumber":
                            OutNumber = kvp.Value.Trim();
                            break;
                        case "Code":
                            Code = kvp.Value.Trim();
                            break;
                        case "Name":
                            Name = kvp.Value.Trim();
                            break;
                        case "CName":
                            CName = kvp.Value.Trim();
                            break;
                        case "Province":
                            Province = kvp.Value.Trim();
                            break;
                        case "City":
                            City = kvp.Value.Trim();
                            break;
                        case "District":
                            District = kvp.Value.Trim();
                            break;
                        case "Tel":
                            Tel = kvp.Value.Trim();
                            break;
                        case "Mobile":
                            Mobile = kvp.Value.Trim();
                            break;
                        case "Addr":
                            Addr = kvp.Value.Trim();
                            break;
                        case "Msg":
                            Msg = kvp.Value.Trim();
                            break;
                        case "SDetail":
                            SDetail = kvp.Value.Trim();
                            break;
                        case "ODetail":
                            ODetail = kvp.Value.Trim();
                            break;
                        case "CStart":
                            CStart = kvp.Value.Trim();
                            break;
                        case "CEnd":
                            CEnd = kvp.Value.Trim();
                            break;
                        case "PStart":
                            PStart = kvp.Value.Trim();
                            break;
                        case "PEnd":
                            PEnd = kvp.Value.Trim();
                            break;
                        case "IStart":
                            IStart = kvp.Value.Trim();
                            break;
                        case "IEnd":
                            IEnd = kvp.Value.Trim();
                            break;
                        default:
                            break;
                    }
                }
            }

            if (PageIndex <= 0) { PageIndex = 1; }

            Hashtable Otherinfo = new Hashtable();
            Otherinfo.Add("PageIndex", PageIndex); Otherinfo.Add("StatusId", StatusId);
            Otherinfo.Add("UserId", UserId); Otherinfo.Add("CateId", CateId);
            Otherinfo.Add("ShopId", ShopId); Otherinfo.Add("RefundId", RefundId);
            Otherinfo.Add("LogisId", LogisId); Otherinfo.Add("FreeId", FreeId);
            Otherinfo.Add("FlagId", FlagId); Otherinfo.Add("SortId", SortId);
            Otherinfo.Add("PrintId", PrintId); Otherinfo.Add("InvoiceId", InvoiceId);
            Otherinfo.Add("UserNick", UserNick); Otherinfo.Add("OutNumber", OutNumber);
            Otherinfo.Add("Code", Code); Otherinfo.Add("Name", Name);
            Otherinfo.Add("CName", CName); Otherinfo.Add("Province", Province);
            Otherinfo.Add("City", City); Otherinfo.Add("District", District);
            Otherinfo.Add("Tel", Tel); Otherinfo.Add("Mobile", Mobile);
            Otherinfo.Add("Addr", Addr); Otherinfo.Add("Msg", Msg);
            Otherinfo.Add("SDetail", SDetail); Otherinfo.Add("ODetail", ODetail);
            Otherinfo.Add("CStart", CStart); Otherinfo.Add("CEnd", CEnd);
            Otherinfo.Add("PStart", PStart); Otherinfo.Add("PEnd", PEnd);
            Otherinfo.Add("IStart", IStart); Otherinfo.Add("IEnd", IEnd);
            ViewData["Otherinfo"] = Otherinfo;
            return View();
        }

        /// <summary>
        /// 检查用户是否设置物流
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CheckLogis()
        {
            bool isOk = false;
            tbClientUser clientuser = GetUser("UserInfo");
            if (clientuser != null)
            {
                //判断用户是否已经设置物流
                IList<StoreLogistics> list = BStoreLogistics.Select(clientuser.UserShops[0].Shop.ShopId);
                if (list != null && list.Count > 0) { isOk = true; }
            }
            return Json(new { status = isOk });
        }

        /*
         taobao.trades.sold.get - 获取三个月内已卖出的在线订单，适用于用户初始化的时候使用，ISV不应该用此接口来获取增量订单。不建议使用或尽量少用此接口。
         taobao.trades.sold.increment.get – 获取增量订单，适用于用户初始化后，增量同步发生变更的订单，ISV不应该用此接口来获取三个月内的订单。
         taobao.trade.fullinfo.get - 获取单笔订单详情。
        */

        /// <summary>
        /// 三个月内订单（未完成）
        /// </summary>
        /// <param name="TradesSold"></param>
        /// <param name="Tid">查询时交易ID</param>
        /// <returns></returns>
        [HttpGet]
        public void BacklogOrders(TradesSoldGet TradesSold)
        {
            tbClientUser clientuser = new tbClientUser();
            clientuser = GetUser("UserInfo");

            /*
            if (TradesSold.StartCreated == null)
            {
                TradesSold.StartCreated = Convert.ToDateTime(DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd HH:mm:ss"));
            }
            if (TradesSold.EndCreated == null)
            {
                TradesSold.EndCreated = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            */
            /*
             *用户第一次使用get, 返回一个是否完成执行前二十条的的状态，不做任何操作
             * 
             */

            Task.Factory.StartNew(() =>
             {
                 clientuser.StartIndex = 0;
                 RequestOrder(TradesSold, clientuser);
             });

            while (true)
            {
                //clientuser.StartIndex 三种状态 1 完成 0进行中或未开始 -1结束 
                if (clientuser.StartIndex == 1)
                {
                    Response.ContentType = "application/json";
                    Response.Write("{\"Result\":" + true + "}");
                    Response.End();
                    break;
                }
                else if (clientuser.StartIndex == -1)
                {
                    Response.ContentType = "application/json";
                    Response.Write("{\"Result\":" + true + "}");
                    Response.End();
                    break;
                }
            }
            /* IList<tbOrdersInfo> list = new List<tbOrdersInfo>();
            list = OnloadOrderInfo(clientuser);
            ViewData["ListOrdersInfo"] = list;*/
        }


        /// <summary>
        /// 批量打印发货
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ViewResult PrintSender(string param = "")
        {
            tbClientUser User = GetUser("UserInfo");
            int LId = 0;
            int State = 0;
            string Number = "";
            string NumberList = "";
            bool IsJump = false;
            string Msg = "";

            IDictionary<string, string> UrlParams = Tools.Utils.Request(param);

            if (UrlParams.Count > 0)
            {
                foreach (KeyValuePair<string, string> kvp in UrlParams)
                {
                    switch (kvp.Key.Trim())
                    {
                        case "id":
                            LId = int.Parse(kvp.Value.Trim());
                            break;
                        case "state":
                            int.TryParse(kvp.Value.Trim(), out State);
                            break;
                        case "num":
                            Number = kvp.Value.Trim();
                            break;
                        case "nums":
                            NumberList = kvp.Value.Trim().Replace("@", ",");
                            break;
                        default:
                            break;
                    }
                }
            }

            tbSenderInfo Sender = BSenderInfo.SelectByUserId(User.UserId);
            if (Sender.SenderId <= 0)
            {
                IsJump = true;
                Msg = "请先设置寄件人信息";
            }
            else
            {
                if (LId == 38 && String.IsNullOrEmpty(Sender.ShopCode))
                {
                    IsJump = true;
                    Msg = "请先设置商家编码";
                }
            }

            ViewBag.LId = LId;
            ViewBag.State = State;
            ViewBag.Number = Number;
            ViewBag.NumberList = NumberList;
            ViewBag.IsJump = IsJump;
            ViewBag.Msg = Msg;

            return View();
        }


        /// <summary>
        /// 解析订单打印数据
        /// </summary>
        /// <param name="LId">物流编号</param>
        /// <param name="State">是否发货</param>
        /// <param name="Number">物流单号</param>
        /// <param name="NumberList">订单编号列表</param>
        [HttpPost]
        public void PrintSender(int LId, int State, string Number, string NumberList)
        {
            bool IsOk = false;
            string JsonStr = "";
            tbClientUser User = GetUser("UserInfo");
            int UserId = User.UserId;
            try
            {
                tbPrintPlaneSingle Print = PrintPlaneSingle.Select(LId, UserId);
                if (Print.PlaneId <= 0)
                {
                    Print = PrintPlaneSingle.Select(LId, 0);
                }

                if (Print.PlaneId > 0)
                {
                    tbPrintPlaneSingle IPrint = PrintPlaneSingle.Select(UserId, false);
                    IList<tbPrintPlaneSingleDetail> IDetailList = PrintPlaneSingleDetail.Select(IPrint.PlaneId);

                    IList<tbPrintPlaneSingleDetail> DetailList = PrintPlaneSingleDetail.Select(Print.PlaneId);
                    JsonStr = ResolvePrint(Print, DetailList, IPrint, IDetailList, Number, NumberList, User, State);
                    IsOk = true;
                }

            }
            catch { }
            Response.ContentType = "application/json";
            Response.Write("{\"Status\":" + (IsOk ? 1 : 0) + "" + JsonStr + "}");
            Response.End();
        }



        /// <summary>
        /// 初始化一些订单，用于页面显示
        /// </summary>
        /// <param name="clientuser"></param>
        /// <returns></returns>
        private IList<tbOrdersInfo> OnloadOrderInfo(tbClientUser clientuser)
        {
            int MaxRow = 0; int MaxPage = 0; int PageIndex = 0;
            int ShopId = 0; int LogisId = 0; int StatusId = 0;
            int CateId = 0; int RefundId = 0; int FreeId = 0;
            int FlagId = 0; int SortId = 0; int PrintId = 0;
            int InvoiceId = 0; string UserNick = null; string OutNumber = null;
            string Code = null; string Name = null; string CName = null;
            string Province = null; string City = null; string District = null;
            string Tel = null; string Mobile = null; string Addr = null;
            string Msg = null; string SDetail = null; string ODetail = null;
            string CStart = null; string CEnd = null; string PStart = null;
            string PEnd = null; string IStart = null; string IEnd = null;


            int MPrint = 0;
            int NPrint = 0;
            int YPrint = 0;
            int UserId = clientuser.UserId;
            DateTime date = DateTime.Now;
            List<string> Where = new List<string>();
            string ShopIdList = string.Empty;

            if (ShopId == 0)
            {
                List<tbClientUserShop> ShopList = new List<tbClientUserShop>();
                ShopList.Add(BClientUserShop.SelectUserShopByUserId(UserId.ToString()));
                if (ShopList != null)
                {
                    List<string> listid = new List<string>();
                    foreach (tbClientUserShop item in ShopList)
                    {
                        listid.Add(item.Shop.ShopId.ToString());
                    }
                    ShopIdList = string.Join(",", listid.ToArray());
                }
                Where.Add(" tbOrdersInfo.ShopId in (" + ShopIdList + ") ");
            }
            else
            {
                Where.Add(" tbOrdersInfo.ShopId = " + ShopId + " ");
            }

            if (LogisId > 0) { Where.Add(" tbOrdersInfo.LogisticsId = " + LogisId + " "); }
            else
            {
                string LogisIdList = BStoreLogistics.Select((String.IsNullOrEmpty(ShopIdList) ? ShopId.ToString() : ShopIdList));
                if (!String.IsNullOrEmpty(LogisIdList))
                {
                    Where.Add(" tbOrdersInfo.LogisticsId in (" + LogisIdList + ") ");
                }
                else
                {
                    Where.Add(" tbOrdersInfo.LogisticsId = 0 ");
                }
            }
            if (StatusId > 0) { Where.Add(" tbOrdersInfo.OrdersStatusId = " + StatusId + " "); }
            if (CateId > 0) { Where.Add(" CashOndelivery = '" + (CateId == 1 ? "false" : "true") + "' "); }
            if (RefundId > 0) { Where.Add(" IsOrdersReFund = '" + (RefundId == 1 ? "true" : "false") + "' "); }
            if (FreeId > 0) { Where.Add(" IsFree = '" + (FreeId == 1 ? "true" : "false") + "' "); }
            if (FlagId > 0) { Where.Add(" ServiceFlag = 'op_memo_" + (FlagId - 1) + ".png' "); }
            if (InvoiceId > 0) { Where.Add(" Invoice = '" + (InvoiceId == 1 ? "true" : "false") + "' "); }
            if (!String.IsNullOrEmpty(UserNick)) { Where.Add(" tbOrdersInfo.NickName like '%" + UserNick.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(OutNumber)) { Where.Add(" OrdersOutNumber like '%" + OutNumber.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(Code)) { Where.Add(" tbOrdersDetail.ProductEncoding like '%" + Code.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(Name)) { Where.Add(" tbOrdersDetail.ProductName like '%" + Name.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(CName)) { Where.Add(" tbConsigneeInfo.Name like '%" + CName.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(Province)) { Where.Add(" tbConsigneeInfo.Provice like '%" + Province.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(City)) { Where.Add(" tbConsigneeInfo.City like '%" + City.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(District)) { Where.Add(" tbConsigneeInfo.District like '%" + District.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(Tel)) { Where.Add(" tbConsigneeInfo.Phone like '%" + Tel.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(Mobile)) { Where.Add(" tbConsigneeInfo.Mobile like '%" + Mobile.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(Addr)) { Where.Add(" tbConsigneeInfo.ConsigneeAddress like '%" + Addr.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(Msg)) { Where.Add(" tbOrdersInfo.BuyerMsg like '%" + Msg.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(SDetail)) { Where.Add(" tbOrdersInfo.ServiceNotes like '%" + SDetail.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(ODetail)) { Where.Add(" tbOrdersInfo.OrdersNotes like '%" + ODetail.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(CStart)) { if (DateTime.TryParse(CStart, out date)) { Where.Add(" tbOrdersInfo.OrdersDate >= '" + CStart.Trim() + "' "); }; }
            if (!String.IsNullOrEmpty(CEnd)) { if (DateTime.TryParse(CEnd, out date)) { Where.Add(" tbOrdersInfo.OrdersDate <= '" + CEnd.Trim() + "' "); };}
            if (!String.IsNullOrEmpty(PStart)) { if (DateTime.TryParse(PStart, out date)) { Where.Add(" tbOrdersInfo.PayDate >= '" + PStart.Trim() + "' "); };}
            if (!String.IsNullOrEmpty(PEnd)) { if (DateTime.TryParse(PEnd, out date)) { Where.Add(" tbOrdersInfo.PayDate <= '" + PEnd.Trim() + "' "); }; }
            if (String.IsNullOrEmpty(IStart) && String.IsNullOrEmpty(IEnd)) { Where.Add(" tbOrdersInfo.OrdersInputDate >= '" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd HH:mm:ss") + "' And tbOrdersInfo.OrdersInputDate <= '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' "); }
            if (!String.IsNullOrEmpty(IStart)) { if (DateTime.TryParse(IStart, out date)) { Where.Add(" tbOrdersInfo.OrdersInputDate >= '" + IStart.Trim() + "' "); }; }
            if (!String.IsNullOrEmpty(IEnd)) { if (DateTime.TryParse(IEnd, out date)) { Where.Add(" tbOrdersInfo.OrdersInputDate <= '" + IEnd.Trim() + "' "); };}

            string PrintWhere = Where.Count > 0 ? " And " + String.Join(" And ", Where) : "";

            if (PrintId > 0) { Where.Add(" IsOrdersPrint = '" + (PrintId == 1 ? "false" : "true") + "' "); }
            string where = Where.Count > 0 ? " And " + String.Join(" And ", Where) : "";

            string Sort = " min(OrdersInputDate) desc ";
            switch (SortId)
            {
                case 1:
                    Sort = " min(OrdersInputDate) asc ";
                    break;
                case 2:
                    Sort = " min(PayDate) desc ";
                    break;
                case 3:
                    Sort = " min(PayDate) asc ";
                    break;
                case 4:
                    Sort = " min(OrdersDate) desc ";
                    break;
                case 5:
                    Sort = " min(OrdersDate) asc ";
                    break;
                case 6:
                    Sort = " min(tbOrdersInfo.NickName) desc ";
                    break;
                case 7:
                    Sort = " min(tbOrdersInfo.NickName) asc ";
                    break;
                case 8:
                    Sort = " min(tbOrdersInfo.OrdersAccounts) desc ";
                    break;
                case 9:
                    Sort = " min(tbOrdersInfo.OrdersAccounts) asc ";
                    break;
            }
            IList<tbOrdersInfo> List = OrdersInfo.Select(out MaxRow, out MaxPage, PageIndex, Where: where, Order: Sort);
            IList<tbOrdersInfo> OrderList = new List<tbOrdersInfo>();
            try
            {
                String IdList = String.Join(",", Array.ConvertAll<tbOrdersInfo, string>(List.ToArray(), (evt) => { return evt.OrdersNumber; }));
                if (!String.IsNullOrEmpty(IdList))
                {
                    OrderList = OrdersInfo.Select(IdList);
                    if (OrderList != null && OrderList.Count > 0)
                    {
                        switch (SortId)
                        {
                            case 0:
                                OrderList = (from e in OrderList orderby e.OrdersInputDate descending select e).ToList();
                                break;
                            case 1:
                                OrderList = (from e in OrderList orderby e.OrdersInputDate ascending select e).ToList();
                                break;
                            case 2:
                                OrderList = (from e in OrderList orderby e.PayDate descending select e).ToList();
                                break;
                            case 3:
                                OrderList = (from e in OrderList orderby e.PayDate ascending select e).ToList();
                                break;
                            case 4:
                                OrderList = (from e in OrderList orderby e.OrdersDate descending select e).ToList();
                                break;
                            case 5:
                                OrderList = (from e in OrderList orderby e.OrdersDate ascending select e).ToList();
                                break;
                            case 6:
                                OrderList = (from e in OrderList orderby e.NickName descending select e).ToList();
                                break;
                            case 7:
                                OrderList = (from e in OrderList orderby e.NickName ascending select e).ToList();
                                break;
                            case 8:
                                OrderList = (from e in OrderList orderby e.OrdersAccounts descending select e).ToList();
                                break;
                            case 9:
                                OrderList = (from e in OrderList orderby e.OrdersAccounts ascending select e).ToList();
                                break;
                        }
                    }
                    if (OrderList != null)
                    {
                        foreach (tbOrdersInfo item in OrderList)
                        {
                            item.Details = new List<tbOrdersDetail>();
                            item.Details = OrdersDetail.Select(item.OrdersOutNumber) as List<tbOrdersDetail>;
                        }
                    }
                }

                int[] PrintCount = OrdersInfo.SelectPrint(PrintWhere);
                NPrint = PrintCount[0];
                YPrint = PrintCount[1];
                MPrint = PrintCount[2];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return OrderList;
        }

        /// <summary>
        /// 修改订单是否打印发货单
        /// </summary>
        /// <param name="Num">订单编号</param>
        /// <param name="State">发货单状态</param>
        [HttpPost]
        public JsonResult ChangeInvoice(string Num, int State)
        {
            bool IsOk = false;
            try
            {
                IsOk = OrdersInfo.UpdateInvoice(Num, State == 1);
            }
            catch { }
            return Json(new { Status = (IsOk ? 1 : 0) });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult MergeOrder(string param = "")
        {
            string NumberList = "";
            IDictionary<string, string> UrlParams = Tools.Utils.Request(param);

            if (UrlParams.Count > 0)
            {
                foreach (KeyValuePair<string, string> kvp in UrlParams)
                {
                    switch (kvp.Key.Trim())
                    {
                        case "nums":
                            NumberList = kvp.Value.Trim().Replace("@", ",");
                            break;
                        default:
                            break;
                    }
                }
            }

            ViewBag.NumberList = NumberList;

            return View();
        }

        [HttpPost]
        public ContentResult UrlEncrypt(string ParamList)
        {
            string Param = "";

            if (!String.IsNullOrEmpty(ParamList))
            {
                Param = Tools.Encrypt.Encrypting.Encode(ParamList.Trim(), Tools.Encrypt.EncryptMode.Page).Replace("+", "$").Replace("/", "_").Replace("=", "-");
            }
            return Content(Param);
        }

        [HttpPost]
        public ContentResult ChangeStatus(string Number, int Status)
        {
            bool IsOk = false;

            try
            {
                IsOk = OrdersInfo.UpdateStatus(Number, Status);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Content("{\"Status\":" + (IsOk ? 1 : 0) + "}");
        }

        /// <summary>
        /// 订单批量发货
        /// </summary>
        /// <returns></returns>
        public ViewResult BatchDeliver(string param)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            int LId = 0;
            string Number = "";
            string NumberList = "";
            bool IsJump = false;
            string Msg = "";

            IDictionary<string, string> UrlParams = Tools.Utils.Request(param);

            if (UrlParams.Count > 0)
            {
                foreach (KeyValuePair<string, string> kvp in UrlParams)
                {
                    switch (kvp.Key.Trim())
                    {
                        case "id":
                            LId = int.Parse(kvp.Value.Trim());
                            break;
                        case "num":
                            Number = kvp.Value.Trim();
                            break;
                        case "nums":
                            NumberList = kvp.Value.Trim().Replace("@", ",");
                            break;
                        default:
                            break;
                    }
                }
            }

            tbSenderInfo Sender = BSenderInfo.SelectByUserId(clientuser.UserId);
            if (LId == 38 && String.IsNullOrEmpty(Sender.ShopCode))
            {
                IsJump = true;
                Msg = "请先设置商家编码";
            }

            ViewBag.LId = LId;
            ViewBag.Number = Number;
            ViewBag.NumberList = NumberList;
            ViewBag.IsJump = IsJump;
            ViewBag.Msg = Msg;

            return View();
        }

        /// <summary>
        /// 订单批量发货
        /// </summary>
        /// <param name="LId">物流单号</param>
        /// <param name="Number">初始发货单号</param>
        /// <param name="NumberList">订单编号列表</param>
        [HttpPost]
        public void BatchDeliver(int LId, string Number, string NumberList)
        {
            bool IsOk = false;
            List<string> Json = new List<string>();
            string reg = "";
            try
            {
                IList<tbOrdersInfo> OrderList = OrdersInfo.Select(NumberList);
                Logistic Logistics = BLogistic.Select(LId);
                reg = Logistics.LogisticsReg.Trim();
                string DeliveryNumber = Number;
                foreach (var item in OrderList)
                {
                    if (!String.IsNullOrEmpty(DeliveryNumber))
                    {
                        Json.Add("{\"order\":\"" + item.OrdersNumber + "\",\"id\":\"" + item.OrdersOutNumber.Split(',')[0] + "\",\"nick\":\"" + item.NickName + "\",\"number\":\"" + DeliveryNumber.Trim() + "\"}");
                        DeliveryNumber = CalculateNumber(item.Logistics.LogisticsId, DeliveryNumber);
                    }
                }
                IsOk = true;
            }
            catch { }

            Response.ContentType = "application/json";
            Response.Write("{\"Status\":" + (IsOk ? 1 : 0) + ",\"reg\":\"" + reg + "\",\"List\":[" + String.Join(",", Json) + "]}");
            Response.End();
        }

        /// <summary>
        /// 订单发货
        /// </summary>
        /// <param name="param">物流编号</param>
        /// <returns></returns>
        public ViewResult OrderSend(string param = "")
        {
            return View(BLogistic.Select(int.Parse(param)));
        }

        /// <summary>
        /// 订单发货
        /// </summary>
        /// <param name="ParamList">参数列表</param>
        [HttpPost]
        public void OrderSend(string ParamList, string Status)
        {
            bool IsOk = false;

            try
            {
                tbClientUser User = GetUser("UserInfo");
                string[] list = ParamList.Split('/');
                List<string> IdList = new List<string>();
                List<string> NumberList = new List<string>();
                foreach (string str in list)
                {
                    string[] strs = str.Split(',');
                    IdList.Add(strs[0].Trim());
                    NumberList.Add(strs[1].Trim());
                }

                IList<tbOrdersInfo> OrderList = OrdersInfo.Select(String.Join(",", IdList));
                int Count = 0;
                foreach (var item in OrderList)
                {
                    tbOrderShipping Ship = new tbOrderShipping()
                    {
                        Operator = "",
                        ShippingDate = DateTime.Now,
                        Logistics = new Logistic() { LogisticsId = item.Logistics.LogisticsId },
                        IsSuccess = false,
                        OrdersNumber = item.OrdersNumber,
                        ShippingDetail = "",
                        LogisticsNumber = NumberList[Count]
                    };

                    //是否改变订单状态
                    bool ChangeStatus = true;

                    tbSenderInfo Sender = null;
                    tbConsigneeInfo Consignee = null;
                    if (item.Logistics.LogisticsId == 38)
                    {
                        Sender = BSenderInfo.Select(item.Shop.ShopId);
                        Consignee = ConsigneeInfo.Select(item.OrdersNumber);
                    }
                    //GetUser("UserInfo");

                    IDictionary<string, IDictionary<bool, string>> result = Trade_Ship(User.UserShops[0].SessionKey, item.Logistics.LogisticsId, item.OrdersOutNumber, NumberList[Count], Sender, Consignee);

                    foreach (KeyValuePair<string, IDictionary<bool, string>> kvp in result)
                    {
                        foreach (KeyValuePair<bool, string> k in kvp.Value)
                        {
                            if (!k.Key)
                            {
                                ChangeStatus = false;
                                Ship.ShippingDetail += kvp.Key + "：发货失败  描述：" + k.Value + "     ";
                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(k.Value))
                                {
                                    Ship.ShippingDetail += kvp.Key + "：发货成功  描述：" + k.Value + "     ";
                                }
                            }
                        }
                    }

                    bool isok = OrderShipping.Insert(Ship);
                    Ship.IsSuccess = ChangeStatus;

                    if (ChangeStatus && isok)
                    {
                        IsOk = OrdersInfo.UpdateStatus(Ship.OrdersNumber, 4);
                    }

                    Count++;
                }
            }
            catch { }

            Response.ContentType = "application/json";
            Response.Write("{\"Status\":" + (IsOk ? 1 : 0) + "}");
            Response.End();
        }



        /// <summary>
        /// 查询能配送的物流公司信息列表
        /// </summary>
        /// <param name="param">参数列表</param>
        /// <returns></returns>
        public ViewResult Rang(string param = "")
        {
            tbClientUser User = GetUser("UserInfo");
            string OrdersNumber = "";
            string type = "online";
            string Address = "";
            List<LogisticsPartner> CompanyList = new List<LogisticsPartner>();
            try
            {
                string[] Strs = param.Split(',');
                OrdersNumber = Strs[0].Trim();
                int cash = 0;
                int.TryParse(Strs[1].Trim(), out cash);
                if (cash == 1) { type = "cod"; }
                tbConsigneeInfo Consignee = ConsigneeInfo.Select(OrdersNumber);
                Address = Consignee.Provice + " " + Consignee.City + " " + Consignee.District + " " + Consignee.ConsigneeAddress;
                string target = String.IsNullOrEmpty(Consignee.District) ? Consignee.City : Consignee.District;
                if (!String.IsNullOrEmpty(target))
                {
                    //GetLogisticsPartners
                    // CompanyList = ApiData.CreateInstance(Business.Service.Entity.PlatFormEnum.TaoBao).GetLogistics(type, "", target.Trim());
                    CompanyList = iti.GetLogisticsPartners(type, false, "", target.Trim());
                }
            }
            catch { }
            ViewBag.Addr = Address;
            return View(CompanyList);
        }

        /// <summary>
        /// 保存订单导入设置
        /// </summary>
        /// <param name="OrdersConfig">订单获取配置表</param>
        [HttpPost]
        public void OrderConfig(tbOrdersConfig OrdersConfig)
        {
            bool IsOk = false;
            try
            {
                OrdersConfig.Remark = String.IsNullOrEmpty(OrdersConfig.Remark) ? "" : OrdersConfig.Remark.Trim();
                OrdersConfig.CashDelivery = String.IsNullOrEmpty(OrdersConfig.CashDelivery) ? "" : OrdersConfig.CashDelivery.Trim();

                if (Request.Form["JudgePay"] != null)
                {
                    if (Request.Form["JudgePay"].ToString().ToLower().Trim() == "on")
                    {
                        OrdersConfig.JudgePay = true;
                    }
                }

                if (Request.Form["MergerOrder"] != null)
                {
                    if (Request.Form["MergerOrder"].ToString().ToLower().Trim() == "on")
                    {
                        OrdersConfig.MergerOrder = true;
                    }
                }

                if (Request.Form["RefundPrint"] != null)
                {
                    if (Request.Form["RefundPrint"].ToString().ToLower().Trim() == "on")
                    {
                        OrdersConfig.RefundPrint = true;
                    }
                }

                if (Request.Form["LogisticsDis"] != null)
                {
                    if (Request.Form["LogisticsDis"].ToString().ToLower().Trim() == "on")
                    {
                        OrdersConfig.LogisticsDis = true;
                    }
                }

                int Id = MYDZ.Business.DataBase_BLL.Order.OrdersConfig.Update(OrdersConfig);
                if (Id > 0)
                {
                    IsOk = MYDZ.Business.DataBase_BLL.Order.ConfigDetail.Delete(Id);

                    if (IsOk)
                    {
                        if (OrdersConfig.DetailList != null)
                        {
                            foreach (var item in OrdersConfig.DetailList)
                            {
                                item.ConfigId = Id;
                                IsOk = MYDZ.Business.DataBase_BLL.Order.ConfigDetail.Insert(item);
                            }
                        }
                    }
                }
            }
            catch { }

            Response.Redirect("/OrderManagement/OrderConfig.html", true);
        }

        /// <summary>
        /// 订单导入设置
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ViewResult OrderConfig(string param = "")
        {
            tbClientUser User = GetUser("UserInfo");
            int Status = -1;
            tbOrdersConfig Config = null;
            IList<StoreLogistics> ShopLogisticsList = null;
            IList<tbOrdersStatus> OrdersStatusList = null;
            IList<tbConfigDetail> DetailList = null;
            int shopid = User.UserShops[0].Shop.ShopId;

            if (!String.IsNullOrEmpty(param))
            {
                IDictionary<string, string> UrlParams = Tools.Utils.Request(param);
                if (UrlParams.Count > 0)
                {
                    foreach (KeyValuePair<string, string> kvp in UrlParams)
                    {
                        switch (kvp.Key.Trim())
                        {
                            case "Status":
                                int.TryParse(kvp.Value.Trim(), out Status);
                                break;
                        }
                    }
                }
            }

            Config = new tbOrdersConfig();
            Config = OrdersConfig.Select(shopid);

            ShopLogisticsList = new List<StoreLogistics>();
            ShopLogisticsList = BStoreLogistics.SelectInfo(shopid);

            if (ShopLogisticsList.Count <= 0)
            {
                Response.Redirect("/OrderManagement/Delivery.cshtml", true);
            }
            OrdersStatusList = new List<tbOrdersStatus>();
            OrdersStatusList = OrdersStatus.Select();
            if (Config.ConfigId > 0)
            {
                DetailList = new List<tbConfigDetail>();
                DetailList = ConfigDetail.Select(Config.ConfigId);
            }
            else
            {
                DetailList = new List<tbConfigDetail>();
            }

            ViewData["Config"] = Config;
            ViewData["ShopLogisticsList"] = ShopLogisticsList;
            ViewData["OrdersStatusList"] = OrdersStatusList;
            ViewData["DetailList"] = DetailList;
            ViewBag.Status = Status;
            ViewBag.ShopId = shopid;

            return View();
        }


        /// <summary>
        /// 合并订单
        /// </summary>
        /// <param name="OrderNumberList">订单编号列表</param>
        [HttpPost]
        public ContentResult MergeOrder(string OrderNumber, string OrderNumberList, int count)
        {
            string Json = "{\"Status\":\"false\",\"Msg\":\"保存失败,请刷新后重试\"}";

            if (count > 1)
            {
                try
                {
                    Json = OrdersInfo.Update(OrderNumber, OrderNumberList, count);
                }
                catch { }
            }

            return Content(Json);
        }

        /// <summary>
        /// 订单详情
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ViewResult OrderDetail(string param = "")
        {
            IList<tbOrdersInfo> ListOrder = OrdersInfo.Select(param);
            IList<tbOrderShipping> listordership = null;
            IList<tbOrderPrint> listorderprint = null;
            IList<tbOrdersDetail> listorderderail = null;
            tbShopInfo shopinfp = null;
            tbConsigneeInfo tci = null;
            try
            {
                if (ListOrder != null)
                {
                    shopinfp = new tbShopInfo();
                    listordership = new List<tbOrderShipping>();
                    listorderprint = new List<tbOrderPrint>();
                    listorderderail = new List<tbOrdersDetail>();
                    tci = new tbConsigneeInfo();
                    tci = ConsigneeInfo.Select(ListOrder[0].OrdersOutNumber);
                    listordership = OrderShipping.Select(ListOrder[0].OrdersOutNumber);
                    listorderprint = OrderPrint.Select(ListOrder[0].OrdersOutNumber);
                    listorderderail = OrdersDetail.Select(ListOrder[0].OrdersOutNumber);
                    shopinfp = BShopInfo.SelecttbShopInfoByShopId(ListOrder[0].Shop.ShopId.ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            ViewData["ConsigneeInfo"] = tci;
            ViewData["orderinfo"] = ListOrder[0];
            ViewData["listordership"] = listordership;
            ViewData["listorderprint"] = listorderprint;
            ViewData["listorderderail"] = listorderderail;
            ViewData["ShopName"] = shopinfp == null ? "无数据" : shopinfp.Title;
            return View();
        }

        /// <summary>
        /// 获取订单
        /// </summary>
        private void RequestOrder(TradesSoldGet TradesSold, tbClientUser ClientUser)
        {
            bool IsOk = false;
            tbOrderSync Sync = OrderSync.Select(ClientUser.UserId, 1);
            OrdersInfo oi = new OrdersInfo();
            DateTime lastdatetime = DateTime.Now;
            if (!Sync.Sync)
            {
                Sync.Sync = true;
                Sync.SyncEnum = 1;
                if (Sync.UserId > 0)
                {
                    OrderSync.Update(Sync);
                }
                else
                {
                    Sync.UserId = ClientUser.UserId;
                    OrderSync.Insert(Sync);
                }

                try
                {
                    tbClientUserShop ShopList = new tbClientUserShop();
                    ShopList = MYDZ.Business.DataBase_BLL.ClientUserBLL.BClientUserShop.SelectUserShopByUserId(ClientUser.UserId.ToString());

                    if (ShopList != null)
                    {
                        int shopId = ShopList.Shop.ShopId;

                        tbOrdersConfig ordersConfig = OrdersConfig.Select(shopId);
                        IList<StoreLogistics> ShopLogistics = MYDZ.Business.DataBase_BLL.Order.BStoreLogistics.SelectInfo(shopId);
                        //导入淘宝订单数据
                        oi.GetResquestBacklogOrder(TradesSold, ClientUser, ShopLogistics, ordersConfig, Sync.LastModifyTime);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Sync.Sync = false;
                    Sync.LastModifyTime = lastdatetime;
                    OrderSync.Update(Sync);
                    ClientUser.StartIndex = -1;
                }
            }
            else
            {
                ClientUser.StartIndex = -1;
            }
        }

        /// <summary>
        /// 获取未完成订单
        /// </summary>
        /// <param name="TradesSold"></param>
        /// <param name="PostType"></param>
        /// <param name="TQC"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BacklogOrders(TradesSoldGet TradesSold, string PostType, TradeQueryClass TQC)
        {
            tbClientUser User = GetUser("UserInfo");
            int MaxRow = 0;
            int MaxPage = 0;
            int MPrint = 0;
            int NPrint = 0;
            int YPrint = 0;
            int UserId = User.UserId;
            DateTime date = DateTime.Now;
            List<string> Where = new List<string>();
            string ShopIdList = string.Empty;

            if (TQC.ShopId == 0)
            {
                List<tbClientUserShop> ShopList = new List<tbClientUserShop>();
                ShopList.Add(BClientUserShop.SelectUserShopByUserId(User.UserId.ToString()));
                if (ShopList != null)
                {
                    List<string> listid = new List<string>();
                    foreach (tbClientUserShop item in ShopList)
                    {
                        listid.Add(item.Shop.ShopId.ToString());
                    }
                    ShopIdList = string.Join(",", listid.ToArray());
                }
                Where.Add(" tbOrdersInfo.ShopId in (" + ShopIdList + ") ");
            }
            else
            {
                Where.Add(" tbOrdersInfo.ShopId = " + TQC.ShopId + " ");
            }

            if (TQC.LogisId > 0) { Where.Add(" tbOrdersInfo.LogisticsId = " + TQC.LogisId + " "); }
            else
            {
                string LogisIdList = BStoreLogistics.Select((String.IsNullOrEmpty(ShopIdList) ? TQC.ShopId.ToString() : ShopIdList));
                if (!String.IsNullOrEmpty(LogisIdList))
                {
                    Where.Add(" tbOrdersInfo.LogisticsId in (" + LogisIdList + ") ");
                }
                else
                {
                    Where.Add(" tbOrdersInfo.LogisticsId = 0 ");
                }
            }
            if (TQC.StatusId > 0) { Where.Add(" tbOrdersInfo.OrdersStatusId = " + TQC.StatusId + " "); }
            if (TQC.CateId > 0) { Where.Add(" CashOndelivery = '" + (TQC.CateId == 1 ? "false" : "true") + "' "); }
            if (TQC.RefundId > 0) { Where.Add(" IsOrdersReFund = '" + (TQC.RefundId == 1 ? "true" : "false") + "' "); }
            if (TQC.FreeId > 0) { Where.Add(" IsFree = '" + (TQC.FreeId == 1 ? "true" : "false") + "' "); }
            if (TQC.FlagId > 0) { Where.Add(" ServiceFlag = 'op_memo_" + (TQC.FlagId - 1) + ".png' "); }
            if (TQC.InvoiceId > 0) { Where.Add(" Invoice = '" + (TQC.InvoiceId == 1 ? "true" : "false") + "' "); }
            if (!String.IsNullOrEmpty(TQC.UserNick)) { Where.Add(" tbOrdersInfo.NickName like '%" + TQC.UserNick.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(TQC.OutNumber)) { Where.Add(" OrdersOutNumber like '%" + TQC.OutNumber.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(TQC.Code)) { Where.Add(" tbOrdersDetail.ProductEncoding like '%" + TQC.Code.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(TQC.Name)) { Where.Add(" tbOrdersDetail.ProductName like '%" + TQC.Name.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(TQC.CName)) { Where.Add(" tbConsigneeInfo.Name like '%" + TQC.CName.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(TQC.Province)) { Where.Add(" tbConsigneeInfo.Provice like '%" + TQC.Province.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(TQC.City)) { Where.Add(" tbConsigneeInfo.City like '%" + TQC.City.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(TQC.District)) { Where.Add(" tbConsigneeInfo.District like '%" + TQC.District.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(TQC.Tel)) { Where.Add(" tbConsigneeInfo.Phone like '%" + TQC.Tel.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(TQC.Mobile)) { Where.Add(" tbConsigneeInfo.Mobile like '%" + TQC.Mobile.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(TQC.Addr)) { Where.Add(" tbConsigneeInfo.ConsigneeAddress like '%" + TQC.Addr.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(TQC.Msg)) { Where.Add(" tbOrdersInfo.BuyerMsg like '%" + TQC.Msg.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(TQC.SDetail)) { Where.Add(" tbOrdersInfo.ServiceNotes like '%" + TQC.SDetail.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(TQC.ODetail)) { Where.Add(" tbOrdersInfo.OrdersNotes like '%" + TQC.ODetail.Trim() + "%' "); }
            if (!String.IsNullOrEmpty(TQC.CStart)) { if (DateTime.TryParse(TQC.CStart, out date)) { Where.Add(" tbOrdersInfo.OrdersDate >= '" + TQC.CStart.Trim() + "' "); }; }
            if (!String.IsNullOrEmpty(TQC.CEnd)) { if (DateTime.TryParse(TQC.CEnd, out date)) { Where.Add(" tbOrdersInfo.OrdersDate <= '" + TQC.CEnd.Trim() + "' "); };}
            if (!String.IsNullOrEmpty(TQC.PStart)) { if (DateTime.TryParse(TQC.PStart, out date)) { Where.Add(" tbOrdersInfo.PayDate >= '" + TQC.PStart.Trim() + "' "); };}
            if (!String.IsNullOrEmpty(TQC.PEnd)) { if (DateTime.TryParse(TQC.PEnd, out date)) { Where.Add(" tbOrdersInfo.PayDate <= '" + TQC.PEnd.Trim() + "' "); }; }
            if (String.IsNullOrEmpty(TQC.IStart) && String.IsNullOrEmpty(TQC.IEnd)) { Where.Add(" tbOrdersInfo.OrdersInputDate >= '" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd HH:mm:ss") + "' And tbOrdersInfo.OrdersInputDate <= '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' "); }
            if (!String.IsNullOrEmpty(TQC.IStart)) { if (DateTime.TryParse(TQC.IStart, out date)) { Where.Add(" tbOrdersInfo.OrdersInputDate >= '" + TQC.IStart.Trim() + "' "); }; }
            if (!String.IsNullOrEmpty(TQC.IEnd)) { if (DateTime.TryParse(TQC.IEnd, out date)) { Where.Add(" tbOrdersInfo.OrdersInputDate <= '" + TQC.IEnd.Trim() + "' "); };}

            string PrintWhere = Where.Count > 0 ? " And " + String.Join(" And ", Where) : "";

            if (TQC.PrintId > 0) { Where.Add(" IsOrdersPrint = '" + (TQC.PrintId == 1 ? "false" : "true") + "' "); }
            string where = Where.Count > 0 ? " And " + String.Join(" And ", Where) : "";

            string Sort = " min(OrdersInputDate) desc ";
            switch (TQC.SortId)
            {
                case 1:
                    Sort = " min(OrdersInputDate) asc ";
                    break;
                case 2:
                    Sort = " min(PayDate) desc ";
                    break;
                case 3:
                    Sort = " min(PayDate) asc ";
                    break;
                case 4:
                    Sort = " min(OrdersDate) desc ";
                    break;
                case 5:
                    Sort = " min(OrdersDate) asc ";
                    break;
                case 6:
                    Sort = " min(tbOrdersInfo.NickName) desc ";
                    break;
                case 7:
                    Sort = " min(tbOrdersInfo.NickName) asc ";
                    break;
                case 8:
                    Sort = " min(tbOrdersInfo.OrdersAccounts) desc ";
                    break;
                case 9:
                    Sort = " min(tbOrdersInfo.OrdersAccounts) asc ";
                    break;
            }

            IList<tbOrdersInfo> List = OrdersInfo.Select(out MaxRow, out MaxPage, TQC.PageIndex, Where: where, Order: Sort);
            IList<tbOrdersInfo> OrderList = new List<tbOrdersInfo>();
            try
            {
                String IdList = String.Join(",", Array.ConvertAll<tbOrdersInfo, string>(List.ToArray(), (evt) => { return evt.OrdersNumber; }));
                if (!String.IsNullOrEmpty(IdList))
                {
                    OrderList = OrdersInfo.Select(IdList);
                    if (OrderList != null && OrderList.Count > 0)
                    {
                        switch (TQC.SortId)
                        {
                            case 0:
                                OrderList = (from e in OrderList orderby e.OrdersInputDate descending select e).ToList();
                                break;
                            case 1:
                                OrderList = (from e in OrderList orderby e.OrdersInputDate ascending select e).ToList();
                                break;
                            case 2:
                                OrderList = (from e in OrderList orderby e.PayDate descending select e).ToList();
                                break;
                            case 3:
                                OrderList = (from e in OrderList orderby e.PayDate ascending select e).ToList();
                                break;
                            case 4:
                                OrderList = (from e in OrderList orderby e.OrdersDate descending select e).ToList();
                                break;
                            case 5:
                                OrderList = (from e in OrderList orderby e.OrdersDate ascending select e).ToList();
                                break;
                            case 6:
                                OrderList = (from e in OrderList orderby e.NickName descending select e).ToList();
                                break;
                            case 7:
                                OrderList = (from e in OrderList orderby e.NickName ascending select e).ToList();
                                break;
                            case 8:
                                OrderList = (from e in OrderList orderby e.OrdersAccounts descending select e).ToList();
                                break;
                            case 9:
                                OrderList = (from e in OrderList orderby e.OrdersAccounts ascending select e).ToList();
                                break;
                        }
                    }
                    if (OrderList != null)
                    {
                        foreach (tbOrdersInfo item in OrderList)
                        {
                            item.Details = new List<tbOrdersDetail>();
                            item.Details = OrdersDetail.Select(item.OrdersOutNumber) as List<tbOrdersDetail>;
                        }
                    }
                }

                int[] PrintCount = OrdersInfo.SelectPrint(PrintWhere);
                NPrint = PrintCount[0];
                YPrint = PrintCount[1];
                MPrint = PrintCount[2];
            }
            catch { }

            ViewBag.PageIndex = TQC.PageIndex;
            ViewBag.MaxRow = MaxRow;
            ViewBag.MaxPage = MaxPage;
            ViewBag.MPrint = MPrint;
            ViewBag.NPrint = NPrint;
            ViewBag.YPrint = YPrint;
            ViewData["ListOrdersInfo"] = OrderList;
            return View();
        }

        /// <summary>
        /// 收件人信息
        /// </summary>
        /// <param name="param">订单编号</param>
        /// <returns></returns>
        public ViewResult Consignee(string param = "")
        {
            tbConsigneeInfo tci = null;
            //使用正则验证 只能是数字
            Regex reg = new Regex(@"^\+?[1-9][0-9]*$");
            if (reg.IsMatch(param))
            {
                tci = new tbConsigneeInfo();
                tci = ConsigneeInfo.Select(param.Trim());
            }
            return View(tci);
        }

        /// <summary>
        /// 修改收件人信息
        /// </summary>
        /// <param name="Consignee">收件人信息</param>
        [HttpPost]
        public JsonResult Consignee(tbConsigneeInfo Consignee)
        {
            bool IsOk = false;
            try
            {
                Consignee.Phone = String.IsNullOrEmpty(Consignee.Phone) ? "" : Consignee.Phone.Trim();
                Consignee.Mobile = String.IsNullOrEmpty(Consignee.Mobile) ? "" : Consignee.Mobile.Trim();
                Consignee.PostCode = String.IsNullOrEmpty(Consignee.PostCode) ? "" : Consignee.PostCode.Trim();
                Consignee.District = String.IsNullOrEmpty(Consignee.District) ? "" : Consignee.District.Trim();
                //使用正则验证 只能是数字
                Regex reg = new Regex(@"^\+?[1-9][0-9]*$");
                if (reg.IsMatch(Consignee.OrdersNumber))
                {
                    IsOk = ConsigneeInfo.Update(Consignee);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new { Status = (IsOk ? 1 : 0) });
        }

        /// <summary>
        /// 修改备注信息
        /// </summary>
        /// <param name="Number">订单编号</param>
        /// <param name="fid">旗帜编号</param>
        /// <param name="txt">备注内容</param>
        [HttpPost]
        public JsonResult EDetail(string Number, string fid, string txt)
        {
            bool IsOk = false;

            try
            {
                txt = String.IsNullOrEmpty(txt) ? "" : txt.Trim();
                IsOk = OrdersInfo.UpdateDetail(Number, fid, txt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new { Status = (IsOk ? 1 : 0) });
        }

        /// <summary>
        /// 单号联想
        /// </summary>
        /// <param name="param">物流编号</param>
        /// <returns></returns>
        public ViewResult DeliverNum(string param = "")
        {
            return View(BLogistic.Select(int.Parse(param)));
        }


        /// <summary>
        /// 给订单添加备注
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddTradeDesc(string Tid, string Memo, string Flag)
        {
            string errorMsg = null;
            tbClientUser clientuser = GetUser("UserInfo");
            int intflag = 0;
            if (string.IsNullOrEmpty(Flag))
            {
                intflag = 0;
            }
            else
            {
                intflag = int.Parse(Flag);
            }
            if (iti.AddTradeMemo(clientuser.UserShops[0].SessionKey, Tid, Memo, intflag, out errorMsg) != null)
            {
                return Json(new { Result = true, ErrorMsg = "" });
            }
            else
            {
                return Json(new { Result = false, ErrorMsg = errorMsg });
            }
        }

        /// <summary>
        /// 修改收货地址
        /// </summary>
        /// <param name="TradeShipping"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateReciveAddress(TradeShippingaddressUpdate TradeShipping) //public Trade UpdateTradeShippingAddress(string token, TradeShippingaddressUpdate TradeShipping, out string ErrorMsg)
        {
            string errorMsg = null;
            tbClientUser clientuser = GetUser("UserInfo");
            if (iti.UpdateTradeShippingAddress(clientuser.UserShops[0].SessionKey, TradeShipping, out errorMsg) != null)
            {
                return Json(new { Result = true, ErrorMsg = "" });
            }
            else
            {
                return Json(new { Result = false, ErrorMsg = errorMsg });
            }
        }

        /// <summary>
        /// 打印模板
        /// </summary>
        /// <returns></returns>
        public ViewResult Template(string param = "")
        {
            int LId = 0;
            IList<MYDZ.Entity.Order.StoreLogistics> list = new List<MYDZ.Entity.Order.StoreLogistics>();
            tbPrintPlaneSingle Print = new tbPrintPlaneSingle();
            tbPrintPlaneSingle TPrint = new tbPrintPlaneSingle();
            StoreLogistics slt = null;

            tbClientUser clientuser = GetUser("UserInfo");
            if (!String.IsNullOrEmpty(param))
            {
                int.TryParse(param, out LId);
            }
            list = BStoreLogistics.SelectByUser(clientuser.UserId);
            if (list.Count > 0)
            {
                slt = new StoreLogistics();
                slt = list.FirstOrDefault((e => { return e.Logistics.LogisticsId == LId; }));
                LId = slt != null ? LId : list.First().Logistics.LogisticsId;
                slt = slt != null ? slt : list.First();
            }
            else
            {
                // Response.Redirect("/Delivery.html");
            }

            Print = PrintPlaneSingle.Select(LId, clientuser.UserId);
            TPrint = Print.PlaneId <= 0 ? PrintPlaneSingle.Select(LId, 0) : new tbPrintPlaneSingle();

            Hashtable ht = new Hashtable();
            ht.Add("List_StoreLogistics", list);
            ht.Add("Print", Print);
            ht.Add("TPrint", TPrint);
            ht.Add("LId", LId);
            ht.Add("slt", slt);
            ht.Add("fontConfig", FontConfigs.GetConfig().FontInfo);
            ViewBag.HashTable_Info = ht;

            return View();
        }

        /// <summary>
        /// 保存打印模板
        /// </summary>
        /// <param name="Print">打印单面模板信息</param>
        [HttpPost]
        public JsonResult Template(tbPrintPlaneSingle Print)
        {
            bool IsOk = false;
            tbClientUser clientuser = GetUser("UserInfo");
            try
            {
                if (Print != null)
                {
                    if (Print.UserId == 0)
                    {
                        Print.UserId = clientuser.UserId;
                    }
                    int Id = 0;
                    if (Print.PlaneId > 0)
                    {
                        IsOk = PrintPlaneSingle.Update(Print);
                        if (IsOk)
                        {
                            Id = Print.PlaneId;
                        }
                    }
                    else
                    {
                        Id = PrintPlaneSingle.Insert(Print);
                    }
                    if (Id > 0)
                    {
                        PrintPlaneSingleDetail.Delete(Id);
                        if (Print.DetailList != null)
                        {
                            foreach (var item in Print.DetailList)
                            {
                                if (item.Width != 0 && item.Height != 0)
                                {
                                    item.PlaneId = Id;
                                    item.SubList = String.IsNullOrEmpty(item.SubList) ? "" : item.SubList;
                                    item.Title = String.IsNullOrEmpty(item.Title) ? "" : item.Title;
                                    IsOk = PrintPlaneSingleDetail.Insert(item);
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new { Status = (IsOk ? 1 : 0) });
        }


        /// <summary>
        /// 打印内容信息
        /// </summary>
        /// <param name="ParentId">父类编号</param>
        [HttpPost]
        public void PrintContent(int ParentId = 0)
        {
            List<string> list = new List<string>();
            try
            {
                IList<tbPrintContent> ContentList = MYDZ.Business.DataBase_BLL.Print.PrintContent.SelectByParentIdAndDisplay(ParentId);
                foreach (var content in ContentList)
                {
                    list.Add("{\"Id\":" + content.ContentId + ",\"PId\":" + content.ParentId + ",\"Name\":\"" + content.Name + "\"}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Response.ContentType = "application/json";
            Response.Write("{\"List\":[" + String.Join(",", list) + "]}");
            Response.End();
        }

        [HttpPost]
        public void PrintDetail(int Id)
        {
            List<string> list = new List<string>();
            try
            {
                if (Id == null)
                {
                    Id = 0;
                }
                IList<tbPrintPlaneSingleDetail> DetailList = PrintPlaneSingleDetail.Select(Id);
                foreach (var item in DetailList)
                {
                    list.Add("{\"Id\":" + item.ContentId + ",\"Title\":\"" + item.Title + "\",\"Font\":" + item.Font + ",\"FontSize\":" + item.FontSize + ",\"Bold\":\"" + item.Bold.ToString().ToLower() + "\",\"Sub\":\"" + item.SubList + "\",\"Num\":" + item.Number + ",\"Left\":" + item.Left + ",\"Top\":" + item.Top + ",\"Width\":" + item.Width + ",\"Height\":" + item.Height + ",\"Align\":" + item.Align + "}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Response.ContentType = "application/json";
            Response.Write("{\"List\":[" + String.Join(",", list) + "]}");
            Response.End();
        }

        [HttpPost]
        public JsonResult restore(int PId)
        {
            bool IsOk = false;

            try
            {
                if (GetUser("UserInfo") != null)
                {
                    if (PId > 0)
                    {
                        IsOk = PrintPlaneSingle.Delete(PId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new { Status = (IsOk ? 1 : 0) });
        }

        /// <summary>
        /// 物流设置
        /// </summary>
        /// <param name="param">参数列表</param>
        /// <returns></returns>
        public ViewResult Delivery(string param = "")
        {
            tbClientUser clientuser = GetUser("UserInfo");
            IList<Logistic> List = new List<Logistic>();
            IList<StoreLogistics> LogisticsList = new List<StoreLogistics>();
            tbShopInfo Shop = new tbShopInfo();

            Shop = BShopInfo.SelecttbShopInfoByShopId(clientuser.UserShops[0].Shop.ShopId.ToString());
            if (Shop != null)
            {
                LogisticsList = BStoreLogistics.Select(Shop.ShopId);
            }
            List = BLogistic.Select();

            Hashtable ht = new Hashtable();
            ht.Add("Shop", Shop);
            ht.Add("LogisticsList", LogisticsList);
            ht.Add("List", List);
            ViewData["DeliveryInfo"] = ht;
            #region

            int Status = -1;
            if (!String.IsNullOrEmpty(param))
            {
                IDictionary<string, string> UrlParams = Tools.Utils.Request(param);
                if (UrlParams.Count > 0)
                {
                    foreach (KeyValuePair<string, string> kvp in UrlParams)
                    {
                        switch (kvp.Key.Trim())
                        {
                            case "Status":
                                int.TryParse(kvp.Value.Trim(), out Status);
                                break;
                        }
                    }
                }
            }

            ViewBag.Status = Status;
            ViewBag.UserId = GetUser("UserInfo").UserId;
            #endregion
            return View();
        }

        /// <summary>
        /// 物流信息列表
        /// </summary>
        [HttpPost]
        public void Logistics()
        {
            List<string> list = new List<string>();
            try
            {
                IList<Logistic> LogisticsList = BLogistic.Select();
                foreach (var item in LogisticsList)
                {
                    list.Add("{\"Id\":" + item.LogisticsId + ",\"Name\":\"" + item.LogisticsName + "\"}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Response.ContentType = "application/json";
            Response.Write("{\"List\":[" + String.Join(",", list) + "]}");
            Response.End();
        }

        /// <summary>
        /// 保存物流设置信息
        /// </summary>
        /// <param name="ShopLogistics">物流设置信息列表</param>
        /// <param name="ShopId">店铺编号</param>
        [HttpPost]
        public ActionResult Delivery(List<StoreLogistics> LogisticsList)
        {
            if (LogisticsList != null)
            {
                bool IsOk = false;
                tbClientUser clientuser = GetUser("UserInfo");
                if (clientuser != null)
                {
                    try
                    {
                        int ShopId = clientuser.UserShops[0].Shop.ShopId;
                        if (ShopId > 0)
                        {
                            int count = 1;
                            for (var i = LogisticsList.Count - 1; i >= 0; i--)
                            {
                                LogisticsList[i].ShopId = ShopId;
                                LogisticsList[i].Sort = count;
                                count++;
                            }
                            IsOk = MYDZ.Business.DataBase_BLL.Order.BStoreLogistics.Insert(LogisticsList);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            Response.Redirect("/OrderManagement/Delivery.html", true);
            return View();
        }

        /// <summary>
        /// 清单模板设置
        /// </summary>
        /// <returns></returns>
        public ActionResult Inventory()
        {
            tbClientUser clientuser = GetUser("UserInfo");
            MYDZ.Entity.Print.tbPrintPlaneSingle Print = PrintPlaneSingle.Select(clientuser.UserId, false);
            Hashtable ht = new Hashtable();
            ht.Add("Print", Print);
            ht.Add("fontConfig", FontConfigs.GetConfig().FontInfo);
            ht.Add("UId", clientuser.UserId);
            ViewData["InventoryInfo"] = ht;
            return View();
        }

        /// <summary>
        /// 关闭一笔交易
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CloseTrade(string Tid, string CloseReason)
        {
            string errorMsg = null;
            tbClientUser clientuser = GetUser("UserInfo");
            bool result = iti.CloseTrade(clientuser.UserShops[0].SessionKey, Tid, CloseReason, out errorMsg);
            return Json(new { Result = result, ErrorMsg = errorMsg });
        }



        /// <summary>
        /// 订单物流信息
        /// </summary>
        /// <param name="param">订单编号</param>
        /// <returns></returns>
        public ViewResult ShopConsignee(string param = "")
        {
            IList<StoreLogistics> tci = null;
            if (!string.IsNullOrEmpty(param))
            {
                string[] ps = param.Split(',');
                ViewBag.LId = int.Parse(ps[0]);

                //使用正则验证 只能是数字
                Regex reg = new Regex(@"^\+?[1-9][0-9]*$");
                if (reg.IsMatch(ps[1]))
                {
                    tci = new List<StoreLogistics>();
                    tci = BStoreLogistics.SelectInfo(int.Parse(ps[1].Trim()));
                }
            }
            return View(tci);
        }


        /// <summary>
        /// 批量修改订单配送方式
        /// </summary>
        /// <param name="param">参数列表</param>
        public ViewResult BatchLogistics(string param = "")
        {
            tbClientUserShop tus = null;
            IList<StoreLogistics> lst = null;
            if (!string.IsNullOrEmpty(param))
            {
                tus = new tbClientUserShop();
                lst = new List<StoreLogistics>();
                string[] ps = param.Split(',');
                ViewBag.LId = int.Parse(ps[0]);
                //使用正则验证 只能是数字
                Regex reg = new Regex(@"^\+?[1-9][0-9]*$");
                if (reg.IsMatch(ps[0]))
                {
                    tus = BClientUserShop.SelectUserShopByUserId(ps[0]);
                    int ShopId = tus.Shop.ShopId;
                    lst = BStoreLogistics.SelectInfo(ShopId);
                }
            }

            return View(lst);
        }

        /// <summary>
        /// 批量修改订单配送方式
        /// </summary>
        /// <param name="lid">物流编号</param>
        /// <param name="IdList">订单编号列表</param>
        [HttpPost]
        public JsonResult BatchLogistics(int lid, string IdList)
        {
            bool IsOk = false;
            try
            {
                IsOk = OrdersInfo.UpdateLogisticsByIdList(IdList, lid);
            }
            catch { }

            return Json(new { Status = (IsOk ? 1 : 0) });
        }

        /// <summary>
        /// 修改订单物流信息
        /// </summary>
        /// <param name="Number">订单编号</param>
        /// <param name="Lid">物编号流</param>
        [HttpPost]
        public void ShopConsignee(string Number, int Lid)
        {
            bool IsOk = false;

            try
            {
                IsOk = OrdersInfo.UpdateLogistics(Number, Lid);
            }
            catch { }

            Response.ContentType = "application/json";
            Response.Write("{\"Status\":" + (IsOk ? 1 : 0) + "}");
            Response.End();
        }

        /// <summary>
        /// 解析打印面单数据
        /// </summary>
        /// <param name="Print">面单模板</param>
        /// <param name="DetailList">面单详情模板</param>
        /// <param name="IPrint">清单模板</param>
        /// <param name="IDetailList">清单详情模板</param>
        /// <param name="Number">物流单号</param>
        /// <param name="NumberList">订单编号列表</param>
        /// <param name="User">用户信息</param>
        /// <param name="State">是否发货</param>
        /// <returns></returns>
        private string ResolvePrint(tbPrintPlaneSingle Print, IList<tbPrintPlaneSingleDetail> DetailList, tbPrintPlaneSingle IPrint, IList<tbPrintPlaneSingleDetail> IDetailList, string Number, string NumberList, tbClientUser User, int State)
        {

            StringBuilder Json = new StringBuilder();
            List<string> PJson = new List<string>();
            List<string> IJson = new List<string>();
            List<string> NJson = new List<string>();
            List<string> SJson = new List<string>();
            List<string> BJson = new List<string>();
            List<Distribution> DisList = new List<Distribution>();//配货单
            IList<tbOrdersInfo> OrderList = OrdersInfo.Select(NumberList);
            int ShopId = OrderList[0].Shop.ShopId;
            tbSenderInfo Sender = BSenderInfo.Select(ShopId);
            FontConfig fontConfig = FontConfigs.GetConfig();
            tbOrdersConfig orderConfig = OrdersConfig.Select(ShopId);
            Logistic Logistics = BLogistic.Select(OrderList[0].Logistics.LogisticsId);
            List<string> DeliveryList = new List<string>();
            tbOtherConfig otherConfig = OtherConfig.Select(User.UserId);
            if (Logistics.LogisticsId == 38)
            {
                DeliveryList = new List<string>();
            }

            int Count = 0;

            foreach (tbOrdersInfo item in OrderList)
            {
                string DeliveryNumber = "";
                decimal ShouldPay = 0m;
                if (DeliveryList != null && DeliveryList.Count > Count)
                {
                    DeliveryNumber = DeliveryList[Count];
                }

                if (Logistics.LogisticsId == 38)
                {
                    ShouldPay = 0m;
                }

                IList<tbOrdersDetail> Details = OrdersDetail.Select(item.OrdersNumber);
                tbConsigneeInfo Consignee = ConsigneeInfo.Select(item.OrdersNumber);
                StringBuilder psb = new StringBuilder();
                StringBuilder isb = new StringBuilder();

                int MaxNumber = 0;//商品总数
                int MaxRows = 0;//商品总条数
                foreach (var d in Details)
                {
                    if (!d.IsCanceled)
                    {
                        if (!orderConfig.RefundPrint)
                        {
                            if (!d.IsProductReFund)
                            {
                                MaxNumber += d.ProductNumber;
                                MaxRows++;

                                Distribution TmpDis = DisList.FirstOrDefault((e) => { return e.ProductName == d.ProductName.Trim() && e.ProductCode == d.ProductEncoding.Trim() && e.ProductAtt == d.ProductSku.Trim(); });
                                if (TmpDis != null)
                                {
                                    TmpDis.ProductNumber += d.ProductNumber;
                                }
                                else
                                {
                                    DisList.Add(new Distribution()
                                    {
                                        ProductName = d.ProductName.Trim(),
                                        ProductCode = d.ProductEncoding.Trim(),
                                        ProductAtt = d.ProductSku.Trim(),
                                        ProductNumber = d.ProductNumber
                                    });
                                }
                            }
                        }
                        else { MaxNumber += d.ProductNumber; MaxRows++; }
                    }
                }



                //打印清单中，商品列表总高度
                int MaxHeight = 30 + 71 * MaxRows;
                //模块高度
                int ModulerHeight = 0;

                psb.Append("<div style='width:" + (Print.Width / 10) + "cm;height:" + ((Print.Height - 1) / 10) + "cm;overflow:hidden;'>");
                int PrintNumber = 0;
                foreach (tbPrintPlaneSingleDetail subitem in DetailList)
                {
                    psb.Append(ResolvePrintDetail(subitem, item, Sender, Details, fontConfig, orderConfig, Consignee, ref PrintNumber, ref ModulerHeight, MaxNumber, MaxRows, DeliveryNumber: DeliveryNumber, ShouldPay: ShouldPay));
                }
                psb.Append("</div>");
                PJson.Add(Tools.Utils.Escape(psb.ToString()));

                //页面高度
                int PageHeight = 0;

                if (item.IsInventory)
                {
                    var tmp = (from p in IDetailList where p.ContentId == 0 select p).First();
                    MaxHeight = MaxHeight + tmp.Top;
                    int PListTop = tmp.Top;//商品列表的居上距离
                    int PListHeight = tmp.Height;

                    isb.Append("<div style='width:" + (IPrint.Width / 10) + "cm;height:" + ((IPrint.Height - 1) / 10) + "cm;overflow:hidden;'>");
                    foreach (tbPrintPlaneSingleDetail subitem in IDetailList)
                    {
                        isb.Append(ResolvePrintDetail(subitem, item, Sender, Details, fontConfig, orderConfig, Consignee, ref PrintNumber, ref ModulerHeight, MaxNumber, MaxRows, MaxHeight, PListTop, DeliveryNumber: DeliveryNumber, ShouldPay: ShouldPay, PListHeight: PListHeight));
                        if (PageHeight < ModulerHeight)
                        {
                            PageHeight = ModulerHeight;
                        }
                    }
                    isb.Append("</div>");
                    IJson.Add("{\"content\":\"" + Tools.Utils.Escape(isb.ToString()) + "\",\"height\":" + (otherConfig.AutoHeight ? PageHeight : 0) + "}");
                }

                if (State == 1)
                {
                    if (!String.IsNullOrEmpty(DeliveryNumber))
                    {
                        NJson.Add("{\"order\":\"" + item.OrdersNumber + "\",\"reg\":\"" + Logistics.LogisticsReg.Trim() + "\",\"id\":\"" + item.OrdersOutNumber.Split(',')[0] + "\",\"nick\":\"" + item.NickName + "\",\"name\":\"" + Consignee.Name + "\",\"number\":\"" + DeliveryNumber.Trim() + "\"}");
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(Number))
                        {
                            NJson.Add("{\"order\":\"" + item.OrdersNumber + "\",\"reg\":\"" + Logistics.LogisticsReg.Trim() + "\",\"id\":\"" + item.OrdersOutNumber.Split(',')[0] + "\",\"nick\":\"" + item.NickName + "\",\"name\":\"" + Consignee.Name + "\",\"number\":\"" + Number.Trim() + "\"}");
                            Number = CalculateNumber(item.Logistics.LogisticsId, Number);
                        }
                    }
                }

                SJson.Add("\"" + item.OrdersNumber + ";" + (!String.IsNullOrEmpty(DeliveryNumber) ? "京东快递打印单号为：" + DeliveryNumber.Trim() : "") + "\"");

                Count++;
            }

            if (otherConfig.Invoice)
            {
                foreach (var item in DisList)
                {
                    BJson.Add("{\"name\":\"" + item.ProductName + "\",\"code\":\"" + item.ProductCode + "\",\"att\":\"" + item.ProductAtt + "\",\"num\":" + item.ProductNumber + "}");
                }
            }

            Json.Append(",\"bList\":[" + String.Join(",", BJson) + "]");
            Json.Append(",\"pList\":{\"list\":[" + (PJson.Count > 0 ? "\"" + String.Join("\",\"", PJson) + "\"" : "") + "],\"width\":" + Print.Width + ",\"height\":" + Print.Height + "}");
            Json.Append(",\"iList\":{\"list\":[" + String.Join(",", IJson) + "],\"width\":" + IPrint.Width + ",\"height\":" + IPrint.Height + "}");
            Json.Append(",\"dList\":[" + String.Join(",", NJson) + "]");
            Json.Append(",\"sList\":[" + String.Join(",", SJson) + "]");

            return Json.ToString();
        }

        /// <summary>
        /// 解析打印详情数据
        /// </summary>
        /// <param name="Detail">打印详情模板</param>
        /// <param name="Order">订单信息</param>
        /// <param name="Sender">寄件人信息</param>
        /// <param name="Details">订单详情列表</param>
        /// <param name="fontConfig">字体配置信息</param>
        /// <param name="orderConfig">订单配置信息</param>
        /// <param name="Consignee">收件人信息</param>
        /// <param name="PrintNumber">商品已经打印数量</param>
        /// <param name="ModulerHeight">模块高度</param>
        /// <param name="MaxNumber">商品总数</param>
        /// <param name="MaxRows">商品总条数</param>
        /// <param name="MaxHeight">商品列表总高度</param>
        /// <param name="PListTop">商品列表的居上距离</param>
        /// <param name="DeliveryNumber">京东快递物流单号</param>
        /// <param name="ShouldPay">代付金额</param>
        /// <param name="PListHeight">原商品列表高度</param>
        /// <returns></returns>
        private string ResolvePrintDetail(tbPrintPlaneSingleDetail Detail, tbOrdersInfo Order, tbSenderInfo Sender, IList<tbOrdersDetail> Details, FontConfig fontConfig, tbOrdersConfig orderConfig, tbConsigneeInfo Consignee, ref int PrintNumber, ref int ModulerHeight, int MaxNumber, int MaxRows, int MaxHeight = 0, int PListTop = 0, string DeliveryNumber = "", decimal ShouldPay = 0m, int PListHeight = 0)
        {
            StringBuilder sb = new StringBuilder();

            string font = "宋体";
            int FontSize = 12;
            int Align = Detail.Align;

            if (Detail.ContentId != 44)
            {
                var Font = fontConfig.FontInfo.FirstOrDefault((e) => { return e.FontId == Detail.Font; });
                font = Font != null ? Font.FontName : "宋体";
                FontSize = Detail.FontSize;
            }

            sb.Append("");

            ModulerHeight = Detail.Top + Detail.Height;

            if (MaxHeight > 0)
            {
                if (Detail.ContentId == 0)
                {
                    sb.Append("<div style=\"text-align:" + (Align == 1 ? "left" : Align == 2 ? "center" : Align == 3 ? "right" : "left") + ";font:" + (Detail.Bold ? "700" : "normal") + " " + FontSize + "px '" + font + "';width:" + Detail.Width + "px;height:" + (MaxHeight - Detail.Top) + "px;left:" + Detail.Left + "px;top:" + Detail.Top + "px;position:absolute;overflow:hidden;\">");
                    ModulerHeight = Detail.Top + (MaxHeight - Detail.Top);
                }
                else
                {
                    int Top = Detail.Top;
                    int TmpPadding = 22;//间距
                    int OldTop = PListHeight + TmpPadding + PListTop;
                    if (Detail.Top >= OldTop)
                    {
                        Top = Detail.Top - OldTop + MaxHeight;
                    }
                    ModulerHeight = Top + Detail.Height;
                    sb.Append("<div style=\"text-align:" + (Align == 1 ? "left" : Align == 2 ? "center" : Align == 3 ? "right" : "left") + ";font:" + (Detail.Bold ? "700" : "normal") + " " + FontSize + "px '" + font + "';width:" + Detail.Width + "px;height:" + Detail.Height + "px;left:" + Detail.Left + "px;top:" + Top + "px;position:absolute;overflow:hidden;\">");
                }
            }
            else
            {
                sb.Append("<div style=\"text-align:" + (Align == 1 ? "left" : Align == 2 ? "center" : Align == 3 ? "right" : "left") + ";font:" + (Detail.Bold ? "700" : "normal") + " " + FontSize + "px '" + font + "';width:" + Detail.Width + "px;height:" + Detail.Height + "px;left:" + Detail.Left + "px;top:" + Detail.Top + "px;position:absolute;overflow:hidden;\">");
            }

            switch (Detail.ContentId)
            {
                case 0:
                    List<string> IStrs = new List<string>();
                    IStrs.Add("<table cellpadding='0' cellspacing='0' border='0' width='100%'>");
                    string[] subList = Detail.SubList.Split(',');
                    List<int> chooseIdList = new List<int>();
                    Dictionary<int, List<string>> pTitleList = new Dictionary<int, List<string>>() { { 1, new List<string>() { "序号", "30" } }, { 2, new List<string>() { "商品图片", "70" } }, { 3, new List<string>() { "商品名称", "0" } }, { 4, new List<string>() { "商家编码", "100" } }, { 5, new List<string>() { "商品简称", "100" } }, { 6, new List<string>() { "销售属性", "100" } }, { 7, new List<string>() { "数量", "60" } }, { 8, new List<string>() { "单价", "80" } }, { 9, new List<string>() { "优惠", "80" } }, { 10, new List<string>() { "小计", "80" } } };
                    IStrs.Add("<thead>");
                    foreach (string str in subList)
                    {
                        int id = 0;
                        if (int.TryParse(str, out id))
                        {
                            if (pTitleList.ContainsKey(id))
                            {
                                List<string> vls = pTitleList[id];
                                int width = int.Parse(vls[1]);
                                string style = "text-align:" + (Align == 1 ? "left" : Align == 2 ? "center" : Align == 3 ? "right" : "left") + ";font:" + (Detail.Bold ? "700" : "normal") + " " + FontSize + "px '" + font + "';" + (width > 0 ? "width:" + width + "px;" : "") + "";
                                IStrs.Add("<th style=\"" + style + "\">" + vls[0] + "</th>");
                                chooseIdList.Add(id);
                            }
                        }
                    }
                    IStrs.Add("</thead>");
                    IStrs.Add("<tbody>");

                    for (int i = 0; i < Details.Count; i++)
                    {
                        IStrs.Add("<tr>");
                        foreach (var id in chooseIdList)
                        {
                            switch (id)
                            {
                                case 1:
                                    IStrs.Add("<td>" + (i + 1) + ".</td>");
                                    break;
                                case 2:
                                    IStrs.Add("<td><img src='" + Details[i].ProductImg + "' style='width:60px;height:60px;'></td>");
                                    break;
                                case 3:
                                    IStrs.Add("<td style='text-align:left;'>" + Details[i].ProductName + "</td>");
                                    break;
                                case 4:
                                    IStrs.Add("<td>" + Details[i].ProductEncoding.Trim() + "</td>");
                                    break;
                                case 5:
                                    // string OutProductId = Order.Shop.PfId == 1 || Order.Shop.PfId == 3 ? Details[i].OutNumberIId.Trim() : Details[i].SubOrderNumber.Trim();
                                    // IStrs.Add("<td>" + Business.Product.ProductAbb.Select(Order.Shop.ShopId, OutProductId) + "</td>");
                                    break;
                                case 6:
                                    IStrs.Add("<td>" + GetProductSku(Details[i].ProductSku.Trim()) + "</td>");
                                    break;
                                case 7:
                                    IStrs.Add("<td>" + Details[i].ProductNumber.ToString() + "</td>");
                                    break;
                                case 8:
                                    IStrs.Add("<td>" + Details[i].ProductPrice + "</td>");
                                    break;
                                case 9:
                                    IStrs.Add("<td>" + (Details[i].ProductPrice * Details[i].ProductNumber - Details[i].OrdersAccounts) + "</td>");
                                    break;
                                case 10:
                                    IStrs.Add("<td>" + Details[i].OrdersAccounts + "</td>");
                                    break;
                                default: break;
                            }
                        }
                        IStrs.Add("</tr>");
                    }

                    /*IStrs.Add("<thead><tr><th width='30'>序号</th><th width='70'>图片</th><th>商品名称</th><th width='120'>商家编码</th><th width='120'>销售属性</th><th width='60'>数量</th><th width='80'>单价</th><th width='80'>金额</th><th width='80'>优惠</th></thead><tbody>");
                    
                    for (int i = 0; i < Details.Count; i++) {
                        IStrs.Add("<tr><td>" + (i + 1) + ".</td><td><img src='" + Details[i].ProductImg + "' style='width:60px;height:60px;'></td><td style='text-align:left;'>" + Details[i].ProductName + "</td><td>Q334286</td><td>" + GetProductSku(Details[i].ProductSku.Trim()) + "</td><td>" + Details[i].ProductNumber + "</td><td>" + Details[i].ProductPrice + "</td><td>" + (Details[i].ProductPrice * Details[i].ProductNumber) + "</td><td>" + (Details[i].ProductPrice * Details[i].ProductNumber - Details[i].OrdersAccounts) + "</td></tr>");
                    }*/

                    IStrs.Add("</tbody></table>");
                    sb.Append(String.Join("", IStrs));
                    break;
                case 1://店铺名称
                    sb.Append(Sender.ShopName.Trim());
                    break;
                case 2://寄件人姓名
                    sb.Append(Sender.SenderName.Trim());
                    break;
                case 3://寄件人电话
                    sb.Append(Sender.SenderTel.Trim());
                    break;
                case 4://寄件人手机
                    sb.Append(Sender.SenderMobile.Trim());
                    break;
                case 5://寄件人地址
                    sb.Append(Sender.SenderAdd.Trim());
                    break;
                case 7://打印日期
                    sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    break;
                case 8://商品信息
                    if (!Order.IsInventory)
                    {
                        IList<tbPrintContent> GList = MYDZ.Business.DataBase_BLL.Print.PrintContent.Select(Detail.SubList.Trim());
                        int EndNumber = PrintNumber + Detail.Number;
                        if (EndNumber > Details.Count) { EndNumber = Details.Count; }
                        List<string> GItems = new List<string>();
                        for (var i = PrintNumber; i < EndNumber; i++)
                        {
                            List<string> GStrs = new List<string>();
                            foreach (var item in GList)
                            {
                                switch (item.ContentId)
                                {
                                    case 9://销售属性
                                        GStrs.Add(GetProductSku(Details[i].ProductSku.Trim()));
                                        break;
                                    case 10://商品数量
                                        GStrs.Add(Details[i].ProductNumber.ToString());
                                        break;
                                    case 12://商品金额
                                        GStrs.Add(Details[i].ProductTotal.ToString());
                                        break;
                                    case 23://商家编码
                                        GStrs.Add(Details[i].ProductEncoding.Trim());
                                        break;
                                    case 24://商品名称
                                        GStrs.Add(Details[i].ProductName.Trim());
                                        break;
                                    case 41://优惠金额
                                        GStrs.Add(Details[i].OrdersDiscount.ToString());
                                        break;
                                    case 50://商品简称
                                        //string OutProductId = Order.Shop.PfId == 1 || Order.Shop.PfId == 3 ? Details[i].OutNumberIId.Trim() : Details[i].SubOrderNumber.Trim();
                                        //GStrs.Add(Business.Product.ProductAbb.Select(Order.Shop.ShopId, OutProductId));
                                        break;
                                }
                            }
                            PrintNumber++;
                            GItems.Add(String.Join(" ", GStrs));
                        }
                        sb.Append(String.Join("<br />", GItems));
                    }
                    break;
                case 11://商品数量总计
                    sb.Append(MaxNumber.ToString());
                    break;
                case 13://订单金额
                    sb.Append(Order.OrdersAccounts.ToString());
                    break;
                case 14://收件人姓名
                    sb.Append(Consignee.Name);
                    break;
                case 15://收件人地址
                    sb.Append(Consignee.ConsigneeAddress);
                    break;
                case 16://收件人邮编
                    sb.Append(Consignee.PostCode);
                    break;
                case 17://收件人电话
                    sb.Append(Consignee.Phone);
                    break;
                case 18://收件人手机
                    sb.Append(Consignee.Mobile);
                    break;
                case 19://自定义内容
                    sb.Append(Detail.Title);
                    break;
                case 20://买家留言
                    sb.Append(Order.BuyerMsg.Trim());
                    break;
                case 21://卖家备注
                    sb.Append(Order.ServiceNotes.Trim());
                    break;
                case 22://商品总计
                    decimal MaxPrice = 0m;
                    foreach (var item in Details)
                    {
                        if (!item.IsCanceled)
                        {
                            if (!orderConfig.RefundPrint)
                            {
                                if (!item.IsProductReFund)
                                {
                                    MaxPrice += item.OrdersAccounts;
                                }
                            }
                            else { MaxPrice += item.OrdersAccounts; }
                        }
                    }
                    sb.Append(MaxPrice.ToString());
                    break;
                case 25://寄件人邮编
                    sb.Append(Sender.PostCode.Trim());
                    break;
                case 26://始发地
                    IList<tbPrintContent> SList = MYDZ.Business.DataBase_BLL.Print.PrintContent.Select(Detail.SubList.Trim());
                    List<string> SStrs = new List<string>();
                    foreach (var item in SList)
                    {
                        switch (item.ContentId)
                        {
                            case 34://始发地省
                                SStrs.Add(Sender.Province.Trim());
                                break;
                            case 35://始发地市
                                SStrs.Add(Sender.City.Trim());
                                break;
                            case 36://始发地区/县
                                SStrs.Add(Sender.District.Trim());
                                break;
                        }
                    }
                    sb.Append(String.Join(" ", SStrs));
                    break;
                case 27://目的地
                    if (string.IsNullOrEmpty(Detail.SubList))
                    {
                        break;
                    }
                    IList<tbPrintContent> EList = MYDZ.Business.DataBase_BLL.Print.PrintContent.Select(Detail.SubList.Trim());
                    List<string> EStrs = new List<string>();
                    foreach (var item in EList)
                    {
                        switch (item.ContentId)
                        {
                            case 37://目的地省
                                EStrs.Add(Consignee.Provice.Trim());
                                break;
                            case 38://目的地市
                                EStrs.Add(Consignee.City.Trim());
                                break;
                            case 39://目的地区/县
                                EStrs.Add(Consignee.District.Trim());
                                break;
                        }
                    }
                    sb.Append(String.Join(" ", EStrs));
                    break;
                case 28://收件人昵称
                    sb.Append(Order.NickName.Trim());
                    break;
                case 29://收件人省
                    sb.Append(Consignee.Provice.Trim());
                    break;
                case 30://收件人市
                    sb.Append(Consignee.City.Trim());
                    break;
                case 31://收件人区/县
                    sb.Append(Consignee.District.Trim());
                    break;
                case 32://订单编号
                    sb.Append(Order.OrdersOutNumber.Trim());
                    break;
                case 33://√
                    sb.Append("√");
                    break;
                case 40://付款日期
                    sb.Append(Order.PayDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    break;
                case 42://优惠总额
                    sb.Append(Order.OrdersDiscount.ToString());
                    break;
                case 43://运费
                    sb.Append(Order.OrdersFreight.ToString());
                    break;
                case 44://图片
                    sb.Append("<img src='" + Detail.SubList + "' style='width:" + Detail.Font + "px;height:" + Detail.FontSize + "px;' />");
                    break;
                case 46://代收金额
                    sb.Append(ShouldPay);
                    break;
                case 47://运单号条形码
                    if (!String.IsNullOrEmpty(DeliveryNumber))
                    {
                        string DeliveryCode = DeliveryNumber.Trim() + "-1-1-";
                        sb.Append("<img src='/barcode.html?ParamList=" + DeliveryCode + "&ShowFont=true&Height=60' alt='BarCode' />");
                    }
                    break;
                case 48://运单号
                    sb.Append(DeliveryNumber);
                    break;
                case 49://收件人地址 包含省市区
                    sb.Append(Consignee.Provice.Trim() + " " + Consignee.City.Trim() + " " + Consignee.District.Trim() + " " + Consignee.ConsigneeAddress.Trim());
                    break;
                case 51://订单备注
                    sb.Append(Order.OrdersNotes.Trim());
                    break;
                default: break;
            }

            sb.Append("</div>");

            return sb.ToString();
        }

        /// <summary>
        /// 解析商品Sku信息
        /// </summary>
        /// <param name="Sku"></param>
        /// <returns></returns>
        private string GetProductSku(string Sku)
        {
            List<string> rtnValue = new List<string>();
            try
            {
                string[] Strs = Sku.Split(';');
                foreach (string str in Strs)
                {
                    string[] strs = str.Split(':');
                    if (strs.Length > 1)
                    {
                        rtnValue.Add(strs[1]);
                    }
                    else
                    {
                        rtnValue.Add(strs[0]);
                    }
                }
            }
            catch { }

            return rtnValue.Count > 0 ? String.Join(" ", rtnValue) : Sku;
        }

        /// <summary>
        /// 联想单号
        /// </summary>
        /// <param name="LId">配送方式</param>
        /// <param name="Number">物流单号</param>
        /// <returns></returns>
        private string CalculateNumber(int LId, string Number)
        {
            string Num = "";
            try
            {
                switch (LId)
                {
                    case 37://申通E物流
                    case 36://圆通速递
                    case 35://中通速递
                    case 32://韵达快递
                    case 14://国通快递
                    case 51://百世汇通
                    case 34://汇通快递
                    case 30://天天快递
                    case 27://中国邮政小包
                        Num = (long.Parse(Number) + 1).ToString();
                        break;
                    case 33://顺丰速运
                        string s = Number.Substring(0, Number.Length - 1);
                        string sb = (long.Parse(s) + 1).ToString();
                        string ls = "";
                        if (int.Parse(sb[10].ToString()) == 9)
                        {
                            int ten = int.Parse(sb[9].ToString());
                            if (ten == 0 || ten == 1 || ten == 2 || ten == 4 || ten == 5 || ten == 7 || ten == 8)
                            {
                                ls = ((int.Parse(Number[11].ToString()) + 6) % 10).ToString();
                            }
                            else
                            {
                                if (ten == 3 || ten == 6)
                                {
                                    ls = ((int.Parse(Number[11].ToString()) + 5) % 10).ToString();
                                }
                                else
                                {
                                    int nine = int.Parse(sb[8].ToString());
                                    if (nine == 0 || nine == 2 || nine == 4 || nine == 6 || nine == 8)
                                    {
                                        ls = ((int.Parse(Number[11].ToString()) + 3) % 10).ToString();
                                    }
                                    else
                                    {
                                        if (nine == 1 || nine == 3 || nine == 5 || nine == 7)
                                        {
                                            ls = ((int.Parse(Number[11].ToString()) + 2) % 10).ToString();
                                        }
                                        else
                                        {
                                            int eight = int.Parse(sb[7].ToString());
                                            if (eight == 0 || eight == 3 || eight == 6)
                                            {
                                                ls = ((int.Parse(Number[11].ToString()) + 0) % 10).ToString();
                                            }
                                            else
                                            {
                                                if (eight == 1 || eight == 2 || eight == 4 || eight == 5 || eight == 7 || eight == 8)
                                                {
                                                    ls = ((int.Parse(Number[11].ToString()) + 9) % 10).ToString();
                                                }
                                                else
                                                {
                                                    int seven = int.Parse(sb[6].ToString());
                                                    if (seven == 0)
                                                    {
                                                        ls = ((int.Parse(Number[11].ToString()) + 7) % 10).ToString();
                                                    }
                                                    else
                                                    {
                                                        if (seven == 1 || seven == 2 || seven == 3 || seven == 4 || seven == 5 || seven == 6 || seven == 7 || seven == 8)
                                                        {
                                                            ls = ((int.Parse(Number[11].ToString()) + 6) % 10).ToString();
                                                        }
                                                        else
                                                        {
                                                            int six = int.Parse(sb[5].ToString());
                                                            if (six < 9 && six >= 0)
                                                            {
                                                                ls = ((int.Parse(Number[11].ToString()) + 3) % 10).ToString();
                                                            }
                                                            else
                                                            {
                                                                int five = int.Parse(sb[4].ToString());
                                                                if (five == 0 || five == 1 || five == 2 || five == 4 || five == 5 || five == 7 || five == 8)
                                                                {
                                                                    ls = ((int.Parse(Number[11].ToString()) + 9) % 10).ToString();
                                                                }
                                                                else
                                                                {
                                                                    if (five == 3 || five == 6)
                                                                    {
                                                                        ls = ((int.Parse(Number[11].ToString()) + 8) % 10).ToString();
                                                                    }
                                                                    else
                                                                    {
                                                                        int four = int.Parse(sb[3].ToString());
                                                                        if (four == 0 || four == 2 || four == 4 || four == 6 || four == 8)
                                                                        {
                                                                            ls = ((int.Parse(Number[11].ToString()) + 5) % 10).ToString();
                                                                        }
                                                                        else
                                                                        {
                                                                            if (four == 1 || four == 3 || four == 5 || four == 7)
                                                                            {
                                                                                ls = ((int.Parse(Number[11].ToString()) + 4) % 10).ToString();
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            ls = ((int.Parse(Number[11].ToString()) + 9) % 10).ToString();
                        }
                        Num = sb + ls;
                        break;
                    case 28://EMS
                    case 29://EMS经济快递
                        string start = Number.Substring(0, 2);
                        string end = Number.Substring(Number.Length - 2, 2);
                        string b = Number.Substring(2, Number.Length - 5);
                        b = (long.Parse(b) + 1).ToString();
                        int sum = 0;
                        for (var i = 0; i < b.Length; i++)
                        {
                            int n = int.Parse(b[i].ToString());
                            switch (i)
                            {
                                case 0:
                                    sum += n * 8;
                                    break;
                                case 1:
                                    sum += n * 6;
                                    break;
                                case 2:
                                    sum += n * 4;
                                    break;
                                case 3:
                                    sum += n * 2;
                                    break;
                                case 4:
                                    sum += n * 3;
                                    break;
                                case 5:
                                    sum += n * 5;
                                    break;
                                case 6:
                                    sum += n * 9;
                                    break;
                                case 7:
                                    sum += n * 7;
                                    break;
                            }
                        }
                        sum = 11 - (sum % 11);
                        if (sum == 10) { sum = 0; }
                        if (sum == 11) { sum = 5; }
                        Num = start + b + sum.ToString() + end;
                        break;
                }
            }
            catch { }

            return Num;
        }

        /// <summary>
        /// 打印完成操作
        /// </summary>
        /// <param name="NumberList">订单编号列表</param>
        /// <returns></returns>
        [HttpPost]
        public void Print(string NumberList)
        {
            bool IsOk = false;

            try
            {
                string[] List = NumberList.Split(',');
                foreach (var item in List)
                {
                    string[] Strs = item.Split(';');
                    IsOk = OrderPrint.Insert(new tbOrderPrint()
                    {
                        OrdersNumber = Strs[0],
                        Operator = "",
                        OrderPrintDate = DateTime.Now,
                        Detail = Strs[1]
                    });
                }
            }
            catch { }

            Response.ContentType = "application/json";
            Response.Write("{\"Status\":" + (IsOk ? 1 : 0) + "}");
            Response.End();
        }

        /// <summary>
        /// 订单发货
        /// </summary>
        /// <param name="SessionKey">用户授权</param>
        /// <param name="LogisticsId">物流编号</param>
        /// <param name="OutNumber">淘宝订单号</param>
        /// <param name="DeliveryNumber">发货单号</param>
        /// <param name="Sender">寄件人信息</param>
        /// <param name="Consignee">收件人信息</param>
        /// <returns></returns>
        public IDictionary<string, IDictionary<bool, string>> Trade_Ship(string SessionKey, int LogisticsId, string OutNumber, string DeliveryNumber, tbSenderInfo Sender = null, tbConsigneeInfo Consignee = null)
        {
            IDictionary<string, IDictionary<bool, string>> dic = new Dictionary<string, IDictionary<bool, string>>();
            Logistic Logistics = BLogistic.Select(LogisticsId);

            if (String.IsNullOrEmpty(OutNumber))
            {
                dic.Add(OutNumber, new Dictionary<bool, string>() { { true, "" } });
            }
            else
            {
                string[] strs = OutNumber.Split(',');

                foreach (string str in strs)
                {
                    string errormsg = null;

                    StatusTable st = GetOrderStatus(SessionKey, str);
                    if (st.IsError)
                    {
                        dic.Add(str, new Dictionary<bool, string>() { { false, st.Msg } });
                        continue;
                    }

                    //淘宝是否已经发货
                    if (st.IsSuccess)
                    {
                        StatusTable st1 = iti.SelectDelivery(SessionKey, str);
                        dic.Add(str, new Dictionary<bool, string>() { { st1.IsSuccess, st1.Msg } });
                        continue;
                    }
                    else
                    {
                        StatusTable st2 = iti.ToDelivery(SessionKey, str, Logistics.LogisticsCode, DeliveryNumber);
                        dic.Add(str, new Dictionary<bool, string>() { { st2.IsSuccess, st2.Msg } });
                        continue;
                    }
                }
            }

            return dic;
        }


        /// <summary>
        /// 寄件人信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ViewResult Sender(string param = "")
        {
            int Status = -1;
            tbClientUser clientuser = GetUser("UserInfo");
            if (!String.IsNullOrEmpty(param))
            {
                IDictionary<string, string> UrlParams = Tools.Utils.Request(param);
                if (UrlParams.Count > 0)
                {
                    foreach (KeyValuePair<string, string> kvp in UrlParams)
                    {
                        switch (kvp.Key.Trim())
                        {
                            case "Status":
                                int.TryParse(kvp.Value.Trim(), out Status);
                                break;
                        }
                    }
                }
            }
            tbShopInfo shopinfo = new tbShopInfo();
            shopinfo = BShopInfo.SelecttbShopInfoByShopId(clientuser.UserShops[0].Shop.ShopId.ToString());
            ViewData["Shop"] = shopinfo.Title;
            ViewData["ShopId"] = clientuser.UserShops[0].Shop.ShopId;
            tbSenderInfo senderInfo = new tbSenderInfo();
            senderInfo = BSenderInfo.Select(clientuser.UserShops[0].Shop.ShopId);
            ViewData["senderInfo"] = senderInfo;

            ViewBag.Status = Status;
            ViewBag.UserId = clientuser.UserId;

            return View();
        }

        /// <summary>
        /// 保存寄件人信息
        /// </summary>
        /// <param name="Sender">寄件人信息</param>
        [HttpPost]
        public void Sender(tbSenderInfo Sender)
        {
            bool IsOk = false;
            try
            {
                Sender.SenderTel = String.IsNullOrEmpty(Sender.SenderTel) ? "" : Sender.SenderTel.Trim();
                Sender.SenderMobile = String.IsNullOrEmpty(Sender.SenderMobile) ? "" : Sender.SenderMobile.Trim();
                Sender.CompanyName = String.IsNullOrEmpty(Sender.CompanyName) ? "" : Sender.CompanyName.Trim();
                Sender.Province = String.IsNullOrEmpty(Sender.Province) ? "" : Sender.Province.Trim();
                Sender.City = String.IsNullOrEmpty(Sender.City) ? "" : Sender.City.Trim();
                Sender.District = String.IsNullOrEmpty(Sender.District) ? "" : Sender.District.Trim();
                Sender.PostCode = String.IsNullOrEmpty(Sender.PostCode) ? "" : Sender.PostCode.Trim();
                Sender.ShopCode = String.IsNullOrEmpty(Sender.ShopCode) ? "" : Sender.ShopCode.Trim();
                IsOk = BSenderInfo.Update(Sender);
            }
            catch { }
            Response.Redirect("/OrderManagement/Sender.html", true);
        }


        private StatusTable GetOrderStatus(string token, string TradeId)
        {
            string Errormsg = null;
            StatusTable statustable = new StatusTable() { Msg = "" };
            try
            {
                Trade listtrade = new Trade();
                listtrade = iti.GetTrade(token, TradeId, out Errormsg);
                if (listtrade != null)
                {
                    bool isok = false;
                    if (listtrade.Status.Equals("WAIT_BUYER_CONFIRM_GOODS") || listtrade.Status.Equals("TRADE_FINISHED") || listtrade.Status.Equals("TRADE_CLOSED"))
                    {
                        isok = true;
                    }
                    statustable.IsSuccess = isok;
                }
            }
            catch (Exception)
            {
                statustable.IsError = true;
                statustable.Msg = "获取淘宝订单的状态失败";
            }
            return statustable;
        }

    }
}
