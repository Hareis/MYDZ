using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Common;
using MYDZ.Business.TB_Logic.SDK_UMP;
using System.Web.Mvc;
using MYDZ.Entity.Marketing;
using MYDZ.Business.TB_Logic.UMP;
using MYDZ.Entity.ClientUser;
using MYDZ.Business.Business_Logic.Goods;
using MYDZ.Entity.Goods;
using MYDZ.Business.Business_Logic.Marking;

namespace MYDZ.WebUI.Marketing
{
    public class MarketingController : BaseController
    {
        MarkingSet MS = new MarkingSet();
        MarkingGet MG = new MarkingGet();
        CommonActivity CA = new CommonActivity();

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            //string toolstr = new LimitedPurchase().buildXSZKTool();
            return View();
        }

        /// <summary>
        /// 限时折扣
        /// </summary>
        public ViewResult LimitedTimeDiscount()
        {
            return View();
        }

        /// <summary>
        /// 限时折扣、减钱
        /// </summary>
        /// <param name="item"></param>
        [HttpPost]
        public JsonResult LimitedTimeDiscount(PromotionmiscItem item, string IdList)
        {
            bool result = false;
            string errormsg = null;
            try
            {
                tbClientUser clientuser = GetUser("UserInfo");
                long Actvitityid = MS.PromotionmiscItemActivityAdd(item, clientuser.UserShops[0].SessionKey, out errormsg);
                //部分商品参与
                if (item.ParticipateRange != 0)
                {
                    if (Actvitityid > 0 && string.IsNullOrEmpty(errormsg))
                        result = MS.AddRange(Convert.ToInt32(Actvitityid), IdList, clientuser.UserShops[0].SessionKey, out errormsg);
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new { Result = result, ErrorMsg = errormsg });

        }


        /// <summary>
        /// 满就送页面
        /// </summary>
        /// <returns></returns>
        public ViewResult FullDeliveryOrCut()
        {
            return View();
        }

        /// <summary>
        /// 满就送页面
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult FullDeliveryOrCut(PromotionmiscMjs item, string IdList)
        {
            string errormsg = null;
            bool result = false;
            tbClientUser clientuser = GetUser("UserInfo");
            try
            {
                long activitityid = MS.PromotionmiscMjsActivityAdd(item, clientuser.UserShops[0].SessionKey, out errormsg);
                //部分商品参与
                if (item.ParticipateRange != 0)
                {
                    if (activitityid > 0 && string.IsNullOrEmpty(errormsg))
                    {
                        result = MS.AddRange(Convert.ToInt32(activitityid), IdList, clientuser.UserShops[0].SessionKey, out errormsg);
                    }
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json(new { Result = result, ErrorMs = errormsg });
        }

        //限购包邮
        public ViewResult FlashSale()
        {
            return View();
        }

        /// <summary>
        /// 限购包邮
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult FlashSale(PromotionmiscMjs item, string IdList)
        {
            int tooliid = 8658004;
            string errormsg = null;
            bool result = false;
            tbClientUser clientuser = GetUser("UserInfo");
            try
            {

                //生成活动字符串
                string ActivityjsonStr = new CommonActivity().buildMjjActivity(new CommonActivityEntity()
                {
                    ToolId = tooliid,
                    Name = item.Name,
                    StartTime = item.StartTime.ToString("yyyy-MM-dd hh:mm:ss"),
                    EndTime = item.EndTime.ToString("yyyy-MM-dd hh:mm:ss"),
                    ParticipateRange = item.ParticipateRange == 0 ? "ALL" : "PART"
                });

                //上传活动
                long activitityid = MS.AddActivity(tooliid, ActivityjsonStr, clientuser.UserShops[0].SessionKey, out errormsg);

                if (activitityid > 0 && string.IsNullOrEmpty(errormsg))
                {
                    //生成活动详情字符串
                    string DetailjsonStr = new LimitedPurchase().bulidXSZKDetail(new LP_Detail()
                    {
                        ActId = Convert.ToInt32(activitityid),
                        EnableFreePostage = item.IsFreePost,
                        ToolId = tooliid,
                        LimitCount = item.ItemCount,
                        ExcludeAreaData = item.ExcludeArea
                    }, clientuser.UserShops[0].SessionKey);

                    //上传活动详情
                    MS.AddDetail(activitityid, DetailjsonStr, clientuser.UserShops[0].SessionKey, out errormsg);

                    //如果是部分商品参与
                    if (item.ParticipateRange != 0)
                    {
                        if (activitityid > 0 && string.IsNullOrEmpty(errormsg))
                        {
                            result = MS.AddRange(Convert.ToInt32(activitityid), IdList, clientuser.UserShops[0].SessionKey, out errormsg);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json(new { Result = result, ErrorMs = errormsg });
        }

        /// <summary>
        /// 指定宝贝送
        /// </summary>
        /// <returns></returns>
        public ViewResult SpecifiedGoodsDelivery()
        {

            return View();
        }

        /// <summary>
        /// 指定宝贝送
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SpecifiedGoodsDelivery(PromotionmiscMjs item, string IdList)
        {
            item.IsAmountOver = false;
            item.IsItemCountOver = false;
            item.IsUserTag = false;
            item.IsDecreaseMoney = false;
            item.IsDiscount = false;
            item.IsSendGift = true;
            item.Type = 1;
            item.ParticipateRange = 1;
            string errormsg = null;
            bool result = false;
            tbClientUser clientuser = GetUser("UserInfo");
            try
            {
                long activitityid = MS.PromotionmiscMjsActivityAdd(item, clientuser.UserShops[0].SessionKey, out errormsg);
                //部分商品参与
                if (item.ParticipateRange != 0)
                {
                    if (activitityid > 0 && string.IsNullOrEmpty(errormsg))
                    {
                        result = MS.AddRange(Convert.ToInt32(activitityid), IdList, clientuser.UserShops[0].SessionKey, out errormsg);
                    }
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json(new { Result = result, ErrorMs = errormsg });
        }

        /// <summary>
        /// 指定用户送
        /// </summary>
        /// <returns></returns>
        public ViewResult SpecifiedBuyerDelivery()
        {
            return View();
        }

        /// <summary>
        /// 指定用户送
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SpecifiedBuyerDelivery(PromotionmiscMjs item, string IdList, string ListNickName)
        {
            if (string.IsNullOrEmpty(ListNickName))
            {
                string[] lists = ListNickName.Split('#');
                foreach (var itemA in lists)
                {

                }
            }


            item.IsAmountOver = false;
            item.IsItemCountOver = false;
            item.IsUserTag = false;
            item.IsDecreaseMoney = false;
            item.IsDiscount = false;
            item.IsSendGift = true;
            item.Type = 1;
            item.ParticipateRange = 1;
            item.IsUserTag = true;
            item.IsShopMember = false;
            string errormsg = null;
            bool result = false;
            tbClientUser clientuser = GetUser("UserInfo");
            try
            {
                long activitityid = MS.PromotionmiscMjsActivityAdd(item, clientuser.UserShops[0].SessionKey, out errormsg);
                //部分商品参与
                if (item.ParticipateRange != 0)
                {
                    if (activitityid > 0 && string.IsNullOrEmpty(errormsg))
                    {
                        result = MS.AddRange(Convert.ToInt32(activitityid), IdList, clientuser.UserShops[0].SessionKey, out errormsg);
                    }
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json(new { Result = result, ErrorMs = errormsg });

        }

        /// <summary>
        /// 限时限购
        /// </summary>
        public ViewResult PurchaseLimit()
        {
            return View();
        }

        /// <summary>
        /// 首件优惠
        /// </summary>
        /// <returns></returns>
        public ViewResult FirstPreferentialPiece()
        {

            return View();
        }

        /// <summary>
        /// 首件优惠
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult FirstPreferentialPiece(PromotionmiscMjs item, string IdList)
        {
            item.IsAmountOver = false;
            item.IsItemCountOver = true;
            item.ItemCount = 1;
            item.IsItemMultiple = false;
            string errormsg = null;
            bool result = false;
            tbClientUser clientuser = GetUser("UserInfo");
            try
            {
                long activitityid = MS.PromotionmiscMjsActivityAdd(item, clientuser.UserShops[0].SessionKey, out errormsg);
                //部分商品参与
                if (item.ParticipateRange != 0)
                {
                    if (activitityid > 0 && string.IsNullOrEmpty(errormsg))
                    {
                        result = MS.AddRange(Convert.ToInt32(activitityid), IdList, clientuser.UserShops[0].SessionKey, out errormsg);
                    }
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json(new { Result = result, ErrorMs = errormsg });
        }

        /// <summary>
        /// 空模板页 
        /// </summary>
        /// <returns></returns>
        public ViewResult NullPageTemple()
        {
            return View();
        }

        /// <summary>
        /// 排除不包邮地区
        /// </summary>
        /// <returns></returns>
        public ViewResult excludearea()
        {
            return View(MG.GetAreas());
        }

        /// <summary>
        /// 优惠标签管理页面
        /// </summary>
        /// <returns></returns>
        public ViewResult TagsManagement()
        {

            return View();
        }

        /// <summary>
        /// 优惠标签列表
        /// </summary>
        /// <param name="PageNo"></param>
        /// <param name="PageSize"></param>
        /// <param name="TagName"></param>
        /// <param name="TagId"></param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Listtags(long PageNo, int PageSize, string TagName = null, int TagId = 0)
        {
            string SessionKey = null;
            string errormsg = null;
            PromotionTagQuery temp = MS.PromotagTagFind(PageNo, PageSize, SessionKey, TagName, TagId, out errormsg);
            return View(temp);
        }

        /*******************************************************************/
        #region  功能模块

        /// <summary>
        /// 返回运费模板
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult ReturnYunfei()
        {
            tbClientUser clientuser = GetUser("UserInfo");
            List<DeliveryTemplate> list = new InitGoodsInfo().GetDeliveryTemplates(clientuser.UserShops[0].SessionKey);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 返回商品数据
        /// </summary>  
        /// <param name="Query"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        private IList<Item> returngoods(QueryCriteriaForOnSales Query, out int total)
        {
            total = 0;
            tbClientUser clientuser = GetUser("UserInfo");
            InitGoodsInfo IGI = new InitGoodsInfo();
            IList<Item> listitems = null;
            //查询出售中的商品
            if (string.IsNullOrEmpty(Query.OuterId))
            {
                listitems = IGI.ReturnOnsalesByCriteria(clientuser.UserShops[0].SessionKey, ref total, Query);
            }
            else
            {
                listitems = IGI.GetGoodsByOuterId(Query.OuterId, clientuser.UserShops[0].SessionKey, ref total);
            }
            return listitems;
        }

        /// <summary>
        /// 选择商品
        /// </summary>
        /// <returns></returns>
        public ViewResult ChoiceGoods(string Ischeckbox = "false", string Iscaozuo = "false")
        {
            ViewData["Ischeckbox"] = Ischeckbox;
            ViewData["Iscaozuo"] = Iscaozuo;
            return View();
        }

        /// <summary>
        /// 添加活动范围
        /// </summary>
        /// <returns></returns>
        public ViewResult AddActivityRange(string Ischeckbox = "false", string Iscaozuo = "false")
        {
            ViewData["Ischeckbox"] = Ischeckbox;
            ViewData["Iscaozuo"] = Iscaozuo;
            return View();
        }

        /// <summary>
        /// 添加活动范围
        /// </summary>
        /// <returns></returns>        
        public JsonResult AddActivityRangePost(string IdList, string Actvitityid, string ParticipateRange)
        {
            bool result = false;
            string errormsg = null;
            tbClientUser clientuser = GetUser("UserInfo");
            ParticipateRange = ParticipateRange.Equals("1") ? "PART" : "PART_NOT";

            if (!string.IsNullOrEmpty(IdList) && !string.IsNullOrEmpty(Actvitityid))
            {
                result = MS.AddRange(int.Parse(Actvitityid), IdList, clientuser.UserShops[0].SessionKey, out errormsg);
            }
            return Json(new { Result = result, ErrorMsg = errormsg });
        }

        /// <summary>
        /// 加载商品数据
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public ViewResult LoadProduct(QueryCriteriaForOnSales Query)
        {
            int total = 0;
            IList<Item> listitems = new List<Item>();
            listitems = returngoods(Query, out total);
            ViewData["total"] = total;
            return View(listitems);
        }

        #endregion
    }
}
