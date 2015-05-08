using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Marketing;
using UMPSDKPHP.marketing;

namespace MYDZ.Business.TB_Logic.UMP
{
    public class CommonActivity
    {
        /// <summary>
        /// 对工具设置活动，包括活动名称，描述，活动的参与范围类型，活动时间范围等  生成json格式字符串
        /// </summary>
        /// <param name="toolId"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public string buildMjjActivity(CommonActivityEntity ActivitySet)
        {
            UMPGet UG = new UMPGet();
            string errormsg = null;
            string activityJson = null;
            MarketingBuilder builder = new MarketingBuilder();
            //根据ID查询工具详情
            string toolJson = UG.findToolByToolId(ActivitySet.ToolId, out errormsg);
            if (string.IsNullOrEmpty(errormsg) && !string.IsNullOrEmpty(toolJson))
            {
                //将json反序列化为MarketingTool实体
                MarketingTool tool = builder.loadTool(toolJson);

                if (errormsg == null && tool != null)
                {
                    MarketingActivity activity = builder.createActivity(tool);

                    activity.setName(ActivitySet.Name);

                    activity.setDescription(ActivitySet.Description);

                    activity.setStartTime(DateTime.Parse(ActivitySet.StartTime));

                    activity.setEndTime(DateTime.Parse(ActivitySet.EndTime));

                    activity.setTarget(ActivitySet.Target);

                    activity.setType(ActivitySet.Type.ToString());//活动类型            

                    //当部分参加或者部分不参加时，需指定添加范围"range"
                    activity.setParticipateRange(ActivitySet.ParticipateRange.ToString());

                    //只优惠一次，注：OPTIONS_MANYTIMES：多次优惠；OPTIONS_ONCE：一次优惠
                    activity.setOptions(ActivitySet.Options.GetHashCode());

                    activityJson = builder.buildActivity(activity);
                }
            }
            return activityJson;
        }
    }
}
