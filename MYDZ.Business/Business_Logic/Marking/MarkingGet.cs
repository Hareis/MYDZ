using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Business.TB_Logic.UMP;
using MYDZ.Business.TB_Logic.SDK_UMP.commonClass;
using MYDZ.Entity.Order;

namespace MYDZ.Business.Business_Logic.Marking
{
    public class MarkingGet
    {
        UMPGet UG = new UMPGet();

        /// <summary>
        /// 根据积木块代码查询积木块详细
        /// </summary>
        /// <param name="code"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public string findMetaByCode(string code, out string Errormsg)
        {
            return UG.findMetaByCode(code, out Errormsg);
        }
        /// <summary>
        /// 根据工具ID获取工具详细
        /// </summary>
        /// <param name="ToolId"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public string findToolByToolId(int ToolId, out string Errormsg)
        {
            return UG.findToolByToolId(ToolId, out Errormsg);
        }
        /// <summary>
        /// 根据活动ID查询活动json字符串
        /// </summary>
        /// <param name="ActId"></param>
        /// <param name="SessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public string findActivityByActId(long ActId, string SessionKey, out string Errormsg)
        {
            return UG.findActivityByActId(ActId, SessionKey, out Errormsg);
        }
        /// <summary>
        /// 根据Id查询活动详情
        /// </summary>
        /// <param name="detailId"></param>
        /// <param name="SessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        public string findDetailByDetailId(int detailId, string SessionKey, out string Errormsg)
        {
            return UG.findDetailByDetailId(detailId, SessionKey, out Errormsg);
        }

        /// <summary>
        /// 获取活动详情内容
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public string getMarketingActivity(int detail_id, string SessionKey, out string Errormsg)
        {
            return UG.getMarketingActivity(detail_id, SessionKey, out Errormsg);
        }

        /// <summary>
        /// 获取活动范围内容
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public List<Range> getActivityRange(int ActId, string SessionKey, out string Errormsg)
        {
            return UG.getActivityRange(ActId, SessionKey, out Errormsg);
        }
       /// <summary>
        ///  查询地址区域
        /// </summary>
        /// <returns></returns>
        public List<Area> GetAreas()
        {
            return UG.GetAreas();
        }
    }
}
