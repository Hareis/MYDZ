using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Business.TB_Logic.UMP;
using MYDZ.Entity.Marketing;

namespace MYDZ.Business.Business_Logic.Marking
{
    public class MarkingSet
    {
        UMPSet US = new UMPSet();

        /// <summary>
        /// 新增优惠活动 
        /// </summary>
        /// <param name="ToolId"></param>
        /// <param name="Content"></param>
        /// <param name="sessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public long AddActivity(long ToolId, string Content, string sessionKey, out string Errormsg)
        {
            return US.AddActivity(ToolId, Content, sessionKey, out Errormsg);
        }
        /// <summary>
        ///  修改活动信息 
        /// </summary>
        /// <param name="ActId"></param>
        /// <param name="Content"></param>
        /// <param name="sessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public bool UpdateActivity(int ActId, string Content, string sessionKey, out string Errormsg)
        {
            return US.UpdateActivity(ActId, Content, sessionKey, out Errormsg);
        }
        /// <summary>
        /// 查询营销活动 
        /// </summary>
        /// <param name="ActId"></param>
        /// <param name="sessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public string GetActivity(int ActId, string sessionKey, out string Errormsg)
        {
            return US.GetActivity(ActId, sessionKey, out Errormsg);
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
        public List<string> GetListActivity(long ToolId, int PageNo, int PageSize, string sessionKey, out int TotalCount, out string Errormsg)
        {
            return US.GetListActivity(ToolId, PageNo, PageSize, sessionKey, out TotalCount, out Errormsg);
        }
        /// <summary>
        /// 新增活动详情 
        /// </summary>
        /// <param name="ActId"></param>
        /// <param name="Content"></param>
        /// <param name="sessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public long AddDetail(long ActId, string Content, string sessionKey, out string Errormsg)
        {
            return US.AddDetail(ActId, Content, sessionKey, out Errormsg);
        }
        /// <summary>
        /// 修改活动详情
        /// </summary>
        /// <param name="DetailId"></param>
        /// <param name="Content"></param>
        /// <param name="sessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public bool UpdateDeatail(long DetailId, string Content, string sessionKey, out string Errormsg)
        {
            return US.UpdateDeatail(DetailId, Content, sessionKey, out Errormsg);
        }
        /// <summary>
        /// 查询活动详情
        /// </summary>
        /// <param name="DetailId"></param>
        /// <param name="sessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public string GetDeatail(long DetailId, string sessionKey, out string Errormsg)
        {
            return US.GetDeatail(DetailId, sessionKey, out Errormsg);
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
        public List<string> GetListDeatail(int ActId, int PageNo, int PageSize, string sessionKey, out int TotalCount, out string Errormsg)
        {
            return US.GetListDeatail(ActId, PageNo, PageSize, sessionKey, out TotalCount, out Errormsg);
        }
        /// <summary>
        /// 删除活动详情
        /// </summary>
        /// <param name="DetailId"></param>
        /// <param name="sessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public bool DeleteDeatatil(long DetailId, string sessionKey, out string Errormsg)
        {
            return US.DeleteDeatatil(DetailId, sessionKey, out Errormsg);
        }

        /// <summary>
        /// 删除营销活动
        /// </summary>
        /// <param name="ActId"></param>
        /// <param name="sessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public bool DeleteActivity(int ActId, string SessionKey, out string Errormsg)
        {
            return US.DeleteActivity(ActId, SessionKey, out Errormsg);
        }
        /// <summary>
        /// 删除活动范围
        /// </summary>
        /// <param name="actId"></param>
        /// <param name="Ids"></param>
        /// <param name="SessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public bool DeleteRange(int actId, string Ids, string SessionKey, out string Errormsg)
        {
            return US.DeleteRange(actId, Ids, SessionKey, out Errormsg);
        }

        /// <summary>
        /// 设置活动的范围
        /// </summary>
        /// <param name="actId"></param>
        /// <param name="Ids"></param>
        /// <param name="SessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public bool AddRange(int actId, string Ids, string SessionKey, out string Errormsg)
        {
            return US.AddRange(actId, Ids, SessionKey, out Errormsg);
        }

           /// <summary>
        /// 创建无条件单品优惠活动
        /// </summary>
        /// <param name="item"></param>
        /// <param name="SessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public long PromotionmiscItemActivityAdd(PromotionmiscItem item, string SessionKey, out string Errormsg)
        {
            return US.PromotionmiscItemActivityAdd(item, SessionKey, out Errormsg);
        }

         /// <summary>
        /// 创建满就送活动
        /// </summary>
        /// <param name="item"></param>
        /// <param name="SessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public long PromotionmiscMjsActivityAdd(PromotionmiscMjs item, string SessionKey, out string Errormsg)
        {
            return US.PromotionmiscMjsActivityAdd(item, SessionKey, out Errormsg);
        }


        
        /// <summary>
        /// 优惠标签申请 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="SessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public long PromotagTagApply(PromotionTag item, string SessionKey, out string Errormsg)
        {
            return US.PromotagTagApply(item, SessionKey, out Errormsg);
        }
          /// <summary>
        /// 用户标签判断接口
        /// </summary>
        /// <param name="TagId"></param>
        /// <param name="NickName"></param>
        /// <param name="SessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public bool PromotagTaguserJudge(long TagId, string NickName, string SessionKey, out string Errormsg)
        {
            return US.PromotagTaguserJudge(TagId, NickName, SessionKey, out Errormsg);
        }
        
        /// <summary>
        ///  给用户移除优惠标签
        /// </summary>
        /// <param name="TagId"></param>
        /// <param name="NickName"></param>
        /// <param name="SessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public bool PromotagTaguserRemove(long TagId, string NickName, string SessionKey, out string Errormsg)
        {
            return US.PromotagTaguserRemove(TagId, NickName, SessionKey, out Errormsg);
        }

        /// <summary>
        /// 给用户打上优惠标签 
        /// </summary>
        /// <param name="TagId"></param>
        /// <param name="NickName"></param>
        /// <param name="SessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public bool PromotagTaguserSave(long TagId, string NickName, string SessionKey, out string Errormsg)
        {
            return US.PromotagTaguserSave(TagId, NickName, SessionKey, out Errormsg);
        }

         /// <summary>
        /// 删除标签定义 
        /// </summary>
        /// <param name="TagId"></param>
        /// <param name="SessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public bool PromotagTagRemovetag(long TagId, string SessionKey, out string Errormsg)
        {
            return US.PromotagTagRemovetag(TagId, SessionKey, out Errormsg);
        }

        /// <summary>
        /// 查询标签接口 
        /// </summary>
        /// <param name="PageNo"></param>
        /// <param name="PageSize"></param>
        /// <param name="SessionKey"></param>
        /// <param name="TagName"></param>
        /// <param name="TagId"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public PromotionTagQuery PromotagTagFind(long PageNo, int PageSize, string SessionKey, string TagName = null, int TagId = 0, out string Errormsg)
        {
            return US.PromotagTagFind(PageNo, PageSize, SessionKey, TagName, TagId, out Errormsg);
        }
    }
}
