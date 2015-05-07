using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMPSDKPHP.marketing;
using UMPSDKPHP.marketing.meta;
using UMPSDKPHP.marketing.Internal;
using MYDZ.Entity.Marketing;

namespace MYDZ.Business.TB_Logic.UMP
{
    /// <summary>
    /// 限时限购、包邮
    /// </summary>
    public class LimitedPurchase
    {
        UMPGet UG = new UMPGet();

        // 创建工具
        public string buildXSZKTool()
        {    
            #region
            
            MarketingBuilder builder = new MarketingBuilder();

            //Condition购物车ISV弃单自定义条件 com.taobao.ump.meta.condition.cartVirginCondtion
            ConditionDef cartVirginCondtionDef = new ConditionDef(240401);
            MetaData cartVirginCondtionMetaData = builder.bind(cartVirginCondtionDef,
                                                                CommonFunc.array(builder.newUndefineParameter("beginAddCart"),
                                                                builder.newUndefineParameter("endAddCart")));

            //Condition限购 com.taobao.ump.meta.condition.limitCheck
            ConditionDef limitCheckDef = new ConditionDef(117);
            MetaData limitCheckMetaData = builder.bind(limitCheckDef,
                                                                CommonFunc.array(builder.newUndefineParameter("limitCount")));

            // 其中前者为区号，后者为地区名称，区号使用*加以分隔，两者通过#加以分隔。100000*310000#北京*浙江,前者为区号，
            //后者为地区名称，区号使用*加以分隔，两者通过#加以分隔,加上不包含的

            //Condition不免邮地区 com.taobao.ump.meta.condition.excludeArea
            ConditionDef excludeAreaDef = new ConditionDef(115);
            MetaData excludeAreaMetaData = builder.bind(excludeAreaDef,
                                                                CommonFunc.array(builder.newUndefineParameter("excludeAreaData")));
            //排除当前地区，即参数为不免邮地区
            excludeAreaMetaData = excludeAreaMetaData.logicNot();
            builder.bindConditional(excludeAreaMetaData, "isexcludeArea");

            //ACTION 包邮  com.taobao.ump.meta.action.freePostage
            ActionDef freePostageActionDef = new ActionDef(104);
            MetaData freePostageMetaData = builder.bind(freePostageActionDef);
            freePostageMetaData = builder.bindConditional(freePostageMetaData, "enablefreePostage");

            //打包成动作
            freePostageMetaData = builder.bindAction(excludeAreaMetaData, freePostageMetaData);
            builder.bindTradeStatus(freePostageMetaData, MetaDef.TRADE_STATUS_BEFORE_CREATE_ORDER);

            LogicAndMetaData operationMetaData = limitCheckMetaData.logicAnd(cartVirginCondtionMetaData);

            MetaData promotionMetaData = builder.bindAction(operationMetaData, freePostageMetaData);

            MarketingTool tool = new MarketingTool();
            tool.setName("限购包邮促销工具");
            tool.setDescription("限购包邮促销工具");
            tool.setToolCode("MoYunOnlineTool" + DateTime.Now.ToString());
            tool.setType(MarketingTool.TOOL_TYPE_ORDER);
            tool.setOrderType(MarketingTool.ORDER_TYPE_ORADERABLE);
            tool.setOperationMeta(promotionMetaData);

            return builder.buildTool(tool);
#endregion
        }


        // 创建活动详情 还需指定商品的ID taobao.ump.range.add
        public string bulidXSZKDetail(LP_Detail DetailSet, string sessionkey)
        {
            string errormsg = null;
            MarketingBuilder builder = new MarketingBuilder();

            string toolJson = UG.findToolByToolId(DetailSet.ToolId, out errormsg);
            MarketingTool tool = builder.loadTool(toolJson);

            string activityJson = UG.findActivityByActId(DetailSet.ActId, sessionkey, out errormsg);
            MarketingActivity activity = builder.loadActivity(tool, activityJson);
            MarketingDetail detail = builder.createDetail(activity);

            detail.define("limitCount", DetailSet.LimitCount.ToString(), ParameterDef.VALUE_TYPE_LONG); // 满1件，只要是初次交易都能满足
            detail.define("IsexcludeArea", null, ParameterDef.VALUE_TYPE_BOOLEAN, DetailSet.IsexcludeArea); //是否有不包邮地区
            detail.define("excludeAreaData", DetailSet.ExcludeAreaData, ParameterDef.VALUE_TYPE_BOOLEAN); //不包邮地区            
            detail.define("enablefreePostage", null, ParameterDef.VALUE_TYPE_BOOLEAN, DetailSet.EnableFreePostage); //包邮

            return builder.buildDetail(detail);
        }

    }
}
