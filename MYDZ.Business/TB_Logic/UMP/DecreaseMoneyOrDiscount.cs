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
    /// 减钱，打折(定向优惠) 即限时折扣
    /// </summary>
    internal class DecreaseMoneyOrDiscount
    {
        UMPGet UG = new UMPGet();

        /// <summary>
        /// 工具描述：（全店或非全店）减钱，打折、包邮(定向优惠)  生成json格式字符串
        /// </summary>
        /// <returns></returns>
        public string buildMjjTool()
        {
            MarketingBuilder builder = new MarketingBuilder();

            //获得订单价格
            ResourceDef orderPriceDef = new ResourceDef(127); //com.taobao.ump.meta.resource.getOrderPriceResource
            MetaData orderPriceMetaData = builder.bind(orderPriceDef, new List<ParameterValue>() { builder.newBooleanParameter(true) });

            //根据件数设置减价的倍数，用于每件都减价的场
            ActionDef calcDecrMultipleDef = new ActionDef(133); //com.taobao.ump.meta.action.calcMultiple
            MetaData calcDecrMultipleMetaData = builder.bind(calcDecrMultipleDef);
            builder.bindTradeStatus(calcDecrMultipleMetaData, MetaDef.TRADE_STATUS_BEFORE_CREATE_ORDER);
            calcDecrMultipleMetaData = builder.bindConditional(calcDecrMultipleMetaData, "calcDecrMultiple");

            //减X元
            ActionDef decreaseActionDef = new ActionDef(102); //com.taobao.ump.meta.action.decreaseMoney
            MetaData decreaseMetaData = builder.bind(decreaseActionDef, new List<ParameterValue>() { builder.newUndefineParameter("decreaseMoney") });
            builder.bindTradeStatus(decreaseMetaData, MetaDef.TRADE_STATUS_BEFORE_CREATE_ORDER);
            decreaseMetaData = builder.bindConditional(decreaseMetaData, "decrease");

            //包邮 
            ActionDef freePostageActionDef = new ActionDef(102); //com.taobao.ump.meta.action.freePostage
            MetaData freePostageMetaData = builder.bind(freePostageActionDef);
            builder.bindTradeStatus(freePostageMetaData, MetaDef.TRADE_STATUS_BEFORE_CREATE_ORDER);
            freePostageMetaData = builder.bindConditional(freePostageMetaData, "freePostage");

            //打折X折
            ActionDef discountActionDef = new ActionDef(103); //com.taobao.ump.meta.action.discount
            MetaData discountMetaData = builder.bind(discountActionDef,
                new List<ParameterValue>() {
                builder.newUndefineParameter("discountRate"), 
                builder.newResourceParameter(orderPriceMetaData)
                });
            builder.bindTradeStatus(discountMetaData, MetaDef.TRADE_STATUS_BEFORE_CREATE_ORDER);
            discountMetaData = builder.bindConditional(discountMetaData, "discount");            

            //拼接
            LogicAndMetaData operationMetaData = calcDecrMultipleMetaData.logicAnd(decreaseMetaData);
            operationMetaData = operationMetaData.logicAnd(discountMetaData);
            operationMetaData = operationMetaData.logicAnd(freePostageMetaData);

            MarketingTool tool = new MarketingTool();
            tool.setName("限时打折包邮工具");
            tool.setDescription("限时打折包邮促销工具");
            tool.setToolCode("MoYunOnlineTool" + DateTime.Now.ToString());
            //TOOL_TYPE_ORDER：店铺级别优惠；TOOL_TYPE_SUB_ORDER：商品级别优惠
            tool.setType(MarketingTool.TOOL_TYPE_SUB_ORDER); 
            tool.setOperationMeta(operationMetaData);

            return builder.buildTool(tool);
        }               

        /// <summary>
        /// 卖家设置好活动后,设置活动详情  生成json格式字符串
        /// </summary>
        /// <param name="toolId"></param>
        /// <param name="actId"></param>
        /// <param name="sessionkey"></param>
        public string bulidMjjDetail(DMOD_Detail DetailSet, string sessionkey)
        {
            string errormsg = null;
            string detailJson = null;
            MarketingBuilder builder = new MarketingBuilder();
            //根据工具ID查询详情
            string toolJson = UG.findToolByToolId(DetailSet.ToolId, out errormsg);
            //判读是否出错
            if (errormsg != null && !string.IsNullOrEmpty(toolJson))
            {
                //将json字符串反序列化为MarketingTool实体
                MarketingTool tool = builder.loadTool(toolJson);
                //获得活动详情json
                string activityJson = UG.findActivityByActId(DetailSet.ActId, sessionkey, out errormsg);
                //将json字符串反序列化为MarketingActivity实体
                MarketingActivity activity = builder.loadActivity(tool, activityJson);
                //将json字符串反序列化为MarketingDetail实体
                MarketingDetail detail = builder.createDetail(activity);

                // 开启减钱、打折、包邮       
                detail.define("decrease", null, ParameterDef.VALUE_TYPE_BOOLEAN, DetailSet.IsDecrease);
                detail.define("discount", null, ParameterDef.VALUE_TYPE_BOOLEAN, DetailSet.IsDiscount);
                detail.define("freePostage", null, ParameterDef.VALUE_TYPE_BOOLEAN, DetailSet.IsFreePostage);
                // 每件都减
                detail.define("calcDecrMultiple", null, ParameterDef.VALUE_TYPE_BOOLEAN, DetailSet.IsCalcDecrMultiple);
                //减钱金额10元，单位是分
                detail.define("decreaseMoney", DetailSet.DecreaseMoney, ParameterDef.VALUE_TYPE_LONG);
                // 不生效的打折，也需要赋值
                detail.define("discountRate", DetailSet.DiscountRate, ParameterDef.VALUE_TYPE_LONG);
                // 参加类型为全部参加  活动为部分商品参加于，此处必须为店铺
                detail.setParticipateType(DetailSet.ParticipateType.ToString());

                detailJson = builder.buildDetail(detail);
            }
            return detailJson;
        }


    }
}
