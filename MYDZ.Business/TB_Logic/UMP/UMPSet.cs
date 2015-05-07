using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using MYDZ.Business.TB_Logic.SDK_UMP.Request;
using MYDZ.Business.TB_Logic.SDK_UMP.Response;
using MYDZ.Business.TB_Logic.SDK_UMP.commonClass;
using UMPSDKPHP.marketing.meta;
using MYDZ.Entity.Marketing;

namespace MYDZ.Business.TB_Logic.UMP
{
    /// <summary>
    /// 
    /// </summary>
    internal class UMPSet
    {
        /// <summary>
        /// 新增优惠活动 
        /// </summary>
        /// <param name="ToolId"></param>
        /// <param name="Content"></param>
        /// <param name="sessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal long AddActivity(long ToolId, string Content, string sessionKey, out string Errormsg)
        {
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpActivityAddRequest req = new UmpActivityAddRequest();
            req.ToolId = ToolId;
            req.Content = Content;
            UmpActivityAddResponse resp = client.Execute(req, sessionKey);
            if (!resp.IsError)
            {
                return resp.ActId;
            }
            else
            {
                Errormsg = resp.ErrMsg;
                return 0;
            }
        }
        /// <summary>
        ///  修改活动信息 
        /// </summary>
        /// <param name="ActId"></param>
        /// <param name="Content"></param>
        /// <param name="sessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal bool UpdateActivity(int ActId, string Content, string sessionKey, out string Errormsg)
        {
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpActivityUpdateRequest req = new UmpActivityUpdateRequest();
            req.ActId = ActId;
            req.Content = Content;
            UmpActivityUpdateResponse resp = client.Execute(req, sessionKey);
            if (!resp.IsError)
            {
                return resp.IsSuccess;
            }
            else
            {
                Errormsg = resp.SubErrMsg;
                return false;
            }
        }

        /// <summary>
        /// 查询营销活动 
        /// </summary>
        /// <param name="ActId"></param>
        /// <param name="sessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal string GetActivity(int ActId, string sessionKey, out string Errormsg)
        {
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpActivityGetRequest req = new UmpActivityGetRequest();
            req.ActId = ActId;
            UmpActivityGetResponse resp = client.Execute(req, sessionKey);
            if (!resp.IsError)
            {
                return resp.Content;
            }
            else
            {
                Errormsg = resp.SubErrMsg;
                return null;
            }
        }

        /// <summary>
        /// 查询活动列表 
        /// </summary>
        /// <param name="ToolId"></param>
        /// <param name="PageNo"></param>
        /// <param name="PageSize"></param>
        /// <param name="sessionKey"></param>
        /// <param name="TotalCount"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal List<string> GetListActivity(long ToolId, int PageNo, int PageSize, string sessionKey, out int TotalCount, out string Errormsg)
        {
            TotalCount = 0;
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpActivitiesGetRequest req = new UmpActivitiesGetRequest();
            req.ToolId = ToolId;
            req.PageNo = PageNo;
            req.PageSize = PageSize;
            UmpActivitiesGetResponse resp = client.Execute(req, sessionKey);
            if (!resp.IsError)
            {
                TotalCount = resp.TotalCount;
                return resp.Contents;
            }
            else
            {
                Errormsg = resp.SubErrMsg;
                return null;
            }
        }

        /// <summary>
        /// 新增活动详情 
        /// </summary>
        /// <param name="ActId"></param>
        /// <param name="Content"></param>
        /// <param name="sessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal long AddDetail(long ActId, string Content, string sessionKey, out string Errormsg)
        {
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpDetailAddRequest req = new UmpDetailAddRequest();
            req.ActId = ActId;
            req.Content = Content;
            UmpDetailAddResponse resp = client.Execute(req, sessionKey);
            if (!resp.IsError)
            {
                return resp.DetailId;
            }
            else
            {
                Errormsg = resp.SubErrMsg;
                return 0;
            }
        }
        /// <summary>
        /// 修改活动详情
        /// </summary>
        /// <param name="DetailId"></param>
        /// <param name="Content"></param>
        /// <param name="sessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal bool UpdateDeatail(long DetailId, string Content, string sessionKey, out string Errormsg)
        {
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpDetailUpdateRequest req = new UmpDetailUpdateRequest();
            req.DetailId = DetailId;
            req.Content = Content;
            UmpDetailUpdateResponse resp = client.Execute(req, sessionKey);
            if (!resp.IsError)
            {
                return resp.IsSuccess;
            }
            else
            {
                Errormsg = resp.SubErrMsg;
                return false;
            }
        }
        /// <summary>
        /// 查询活动详情
        /// </summary>
        /// <param name="DetailId"></param>
        /// <param name="sessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal string GetDeatail(long DetailId, string sessionKey, out string Errormsg)
        {
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpDetailGetRequest req = new UmpDetailGetRequest();
            req.DetailId = DetailId;
            UmpDetailGetResponse resp = client.Execute(req, sessionKey);
            if (!resp.IsError)
            {
                return resp.Content;
            }
            else
            {
                Errormsg = resp.SubErrMsg;
                return null;
            }
        }
        /// <summary>
        /// 查询活动详情列表
        /// </summary>
        /// <param name="ActId"></param>
        /// <param name="PageNo"></param>
        /// <param name="PageSize"></param>
        /// <param name="sessionKey"></param>
        /// <param name="TotalCount"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal List<string> GetListDeatail(int ActId, int PageNo, int PageSize, string sessionKey, out int TotalCount, out string Errormsg)
        {
            TotalCount = 0;
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpDetailsGetRequest req = new UmpDetailsGetRequest();
            req.ActId = ActId;
            req.PageNo = PageNo;
            req.PageSize = PageSize;
            UmpDetailsGetResponse resp = client.Execute(req, sessionKey);
            if (!resp.IsError)
            {
                TotalCount = resp.TotalCount;
                return resp.Contents;
            }
            else
            {
                Errormsg = resp.SubErrMsg;
                return null;
            }
        }
        /// <summary>
        /// 删除活动详情
        /// </summary>
        /// <param name="DetailId"></param>
        /// <param name="sessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal bool DeleteDeatatil(long DetailId, string sessionKey, out string Errormsg)
        {
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpDetailDeleteRequest req = new UmpDetailDeleteRequest();
            req.DetailId = DetailId;
            UmpDetailDeleteResponse resp = client.Execute(req, sessionKey);
            if (!resp.IsError)
            {
                return resp.IsSuccess;
            }
            else
            {
                Errormsg = resp.SubErrMsg;
                return false;
            }
        }

        /// <summary>
        /// 删除营销活动
        /// </summary>
        /// <param name="ActId"></param>
        /// <param name="sessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal bool DeleteActivity(int ActId, string SessionKey, out string Errormsg)
        {
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpActivityDeleteRequest req = new UmpActivityDeleteRequest();
            req.ActId = ActId;
            UmpActivityDeleteResponse resp = client.Execute(req, SessionKey);
            if (!resp.IsError)
            {
                return resp.IsSuccess;
            }
            else
            {
                Errormsg = resp.SubErrMsg;
                return false;
            }
        }

        /// <summary>
        /// 删除活动范围
        /// </summary>
        /// <param name="actId"></param>
        /// <param name="Ids"></param>
        /// <param name="SessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal bool DeleteRange(int actId, string Ids, string SessionKey, out string Errormsg)
        {
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpRangeDeleteRequest req = new UmpRangeDeleteRequest();
            req.ActId = actId;
            req.Type = MetaConstants.PARAM_LOGIC_TYPE_ITEMID;
            req.Ids = Ids;
            UmpRangeDeleteResponse resp = client.Execute(req, SessionKey);
            if (resp.IsError)
            {
                Errormsg = resp.ErrMsg;
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// 设置活动的范围
        /// 接收商品ID
        /// </summary>
        /// <param name="actId"></param>
        /// <param name="Ids"></param>
        /// <param name="SessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal bool AddRange(int actId, string Ids, string SessionKey, out string Errormsg)
        {
            //MarketingConstants.PARTICIPATE_TYPE
            //PARAM_LOGIC_TYPE_ITEMID
            // 上例中设置的参与类型是全店参与。这种情况下是不需要设置范围的。
            // 如果是设置的部分参与或者部分不参与，就需要设置部分参加或不参加的具体的范围
            // 如果上例中设置的是部分商品参与，如：
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpRangeAddRequest req = new UmpRangeAddRequest();
            req.ActId = actId;
            req.Type = MetaConstants.PARAM_LOGIC_TYPE_ITEMID;
            req.Ids = Ids;
            UmpRangeAddResponse resp = client.Execute(req, SessionKey);
            if (resp.IsError)
            {
                Errormsg = resp.ErrMsg;
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 创建无条件单品优惠活动
        /// </summary>
        /// <param name="item"></param>
        /// <param name="SessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal long PromotionmiscItemActivityAdd(PromotionmiscItem item, string SessionKey, out string Errormsg)
        {
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            PromotionmiscItemActivityAddRequest req = new PromotionmiscItemActivityAddRequest();
            if (!string.IsNullOrEmpty(item.Name))
            {
                req.Name = item.Name;
            }
            else
            {
                Errormsg = "活动名称不能为空！";
                return 0;
            }

            req.ParticipateRange = item.ParticipateRange;

            if (item.StartTime != null)
            {
                req.StartTime = item.StartTime.ToString("yyyy-MM-dd hh:mm:ss");
            }
            if (item.EndTime != null)
            {
                req.EndTime = item.EndTime.ToString("yyyy-MM-dd hh:mm:ss");
            }
            req.IsUserTag = item.IsUserTag;
            req.UserTag = item.UserTag;
            req.IsDecreaseMoney = item.IsDecreaseMoney;
            req.DecreaseAmount = item.DecreaseAmount;
            req.IsDiscount = item.IsDiscount;
            req.DiscountRate = item.DiscountRate;
            PromotionmiscItemActivityAddResponse response = client.Execute(req, SessionKey);
            if (!response.IsError)
            {
                return response.ActivityId;
            }
            else
            {
                Errormsg = response.ErrMsg;
                return 0;
            }
        }
        /// <summary>
        /// 创建满就送活动
        /// </summary>
        /// <param name="item"></param>
        /// <param name="SessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal long PromotionmiscMjsActivityAdd(PromotionmiscMjs item, string SessionKey, out string Errormsg)
        {
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            PromotionmiscMjsActivityAddRequest req = new PromotionmiscMjsActivityAddRequest();
            if (!string.IsNullOrEmpty(item.Name))
            {
                req.Name = item.Name;
            }
            else
            {
                Errormsg = "活动名称不能为空";
                return 0;
            }
            req.Type = item.Type;
            req.ParticipateRange = item.ParticipateRange;
            if (item.StartTime != null)
                req.StartTime = item.StartTime.ToString("yyyy-MM-dd hh:mm:ss");
            if (item.EndTime != null)
                req.EndTime = item.EndTime.ToString("yyyy-MM-dd hh:mm:ss");
            req.IsAmountOver = item.IsAmountOver;
            req.TotalPrice = item.TotalPrice;
            req.IsAmountMultiple = item.IsAmountMultiple;
            req.IsItemCountOver = item.IsItemCountOver;
            req.ItemCount = item.ItemCount;
            req.IsItemMultiple = item.IsItemMultiple;
            req.IsShopMember = item.IsShopMember;
            req.ShopMemberLevel = item.ShopMemberLevel;
            req.IsUserTag = item.IsUserTag;
            req.UserTag = item.UserTag;
            req.IsDecreaseMoney = item.IsDecreaseMoney;
            req.DecreaseAmount = item.DecreaseAmount;
            req.IsDiscount = item.IsDiscount;
            req.DiscountRate = item.DiscountRate;
            req.IsSendGift = item.IsSendGift;
            req.GiftName = item.GiftName;
            req.GiftId = item.GiftId;
            req.GiftUrl = item.GiftUrl;
            req.IsFreePost = item.IsFreePost;
            req.ExcludeArea = item.ExcludeArea;
            PromotionmiscMjsActivityAddResponse resp = client.Execute(req, SessionKey);
            if (!resp.IsError)
            {
                return resp.ActivityId;
            }
            else
            {
                Errormsg = resp.ErrMsg;
                return 0;
            }
        }
        
    }
}
