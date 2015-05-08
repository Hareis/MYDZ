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
    /// 满件或满元打折工具
    /// </summary>
    public class ItemCountOverOrAmountOver
    {
        UMPGet UG = new UMPGet();

        /// <summary>
        /// 拼接数组
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<ParameterValue> array(params ParameterValue[] list)
        {
            List<ParameterValue> newlist = new List<ParameterValue>();
            foreach (var item in list)
            {
                newlist.Add(item);
            }
            return newlist;
        }

        // 创建工具
        public string buildMJJTool()
        {
            MarketingBuilder builder = new MarketingBuilder();

            //当前订单购买量满多少件 com.taobao.ump.meta.condition.itemCountOver
            ConditionDef countConditionDef = new ConditionDef(116);
            MetaData countMetaData = builder.bind(countConditionDef, new List<ParameterValue>() { builder.newUndefineParameter("count"), builder.newUndefineParameter("enableCountMultiple") });

            //获得订单价格 com.taobao.ump.meta.resource.getOrderPriceResource
            ResourceDef orderPriceDef = new ResourceDef(127);
            MetaData orderPriceMetaData = builder.bind(orderPriceDef, array(builder.newBooleanParameter(true)));

            //满多少元 com.taobao.ump.meta.condition.amountOver
            ConditionDef amountConditionDef = new ConditionDef(113);
            MetaData amountMetaData = builder.bind(amountConditionDef, array(builder.newResourceParameter(orderPriceMetaData), builder.newUndefineParameter("totalPrice"), builder.newUndefineParameter("enableMultiple")));

            // ACTION 减钱 com.taobao.ump.meta.action.decreaseMoney
            ActionDef decreaseActionDef = new ActionDef(102);
            MetaData decreaseMetaData = builder.bind(decreaseActionDef, array(builder.newUndefineParameter("decreaseMoney")));
            builder.bindTradeStatus(decreaseMetaData, MetaDef.TRADE_STATUS_BEFORE_CREATE_ORDER);
            decreaseMetaData = builder.bindConditional(decreaseMetaData, "decrease");

            // ACTION 打折 com.taobao.ump.meta.action.discount
            ActionDef discountActionDef = new ActionDef(103);
            MetaData discountMetaData = builder.bind(discountActionDef, array(builder.newUndefineParameter("discountRate"), builder.newResourceParameter(orderPriceMetaData)));
            builder.bindTradeStatus(discountMetaData, MetaDef.TRADE_STATUS_BEFORE_CREATE_ORDER);
            discountMetaData = builder.bindConditional(discountMetaData, "discount");

            // ACTION 送礼物 com.taobao.ump.meta.action.sendGift
            ActionDef sendGiftActionDef = new ActionDef(110);
            MetaData sendGiftMetaData = builder.bind(sendGiftActionDef, array(builder.newUndefineParameter("giftName"), builder.newUndefineParameter("giftId"), builder.newUndefineParameter("giftUrl")));
            builder.bindTradeStatus(sendGiftMetaData, MetaDef.TRADE_STATUS_BEFORE_CREATE_ORDER);
            sendGiftMetaData = builder.bindConditional(sendGiftMetaData, "sendGift");

            //ACTION 包邮  //com.taobao.ump.meta.action.freePostage
            ActionDef freePostageActionDef = new ActionDef(104);
            MetaData freePostageMetaData = builder.bind(freePostageActionDef);
            builder.bindTradeStatus(freePostageMetaData, MetaDef.TRADE_STATUS_BEFORE_CREATE_ORDER);
            freePostageMetaData = builder.bindConditional(freePostageMetaData, "enablefreePostage");

            LogicAndMetaData operationMetaData = decreaseMetaData.logicAnd(discountMetaData);
            operationMetaData = operationMetaData.logicAnd(sendGiftMetaData);

            LogicOrMetaData operationMetaData2 = countMetaData.logicOr(amountMetaData);
            MetaData promotionMetaData = builder.bindAction(operationMetaData2, operationMetaData);

            MarketingTool tool = new MarketingTool();
            tool.setName("满件或满元促销工具");
            tool.setDescription("满件或满元减钱、打折、送礼、包邮促销工具");
            tool.setToolCode("MoYunOnlineTool" + DateTime.Now.ToString("yyyyMMddHHss"));
            tool.setType(MarketingTool.TOOL_TYPE_ORDER);
            tool.setPrivilege(MarketingTool.PRIVILEGE_TYPE_PUBLIC);
            tool.setOrderType(MarketingTool.ORDER_TYPE_ORADERABLE);
            tool.setOperationMeta(promotionMetaData);

            return builder.buildTool(tool);

        }


        // 创建活动详情
        public string bulidZJDZDetail(ICOOAO_Detail DetailSet, string sessionkey)
        {
            string errormsg = null;
            MarketingBuilder builder = new MarketingBuilder();

            string toolJson = UG.findToolByToolId(DetailSet.ToolId, out errormsg);
            MarketingTool tool = builder.loadTool(toolJson);

            string activityJson = UG.findActivityByActId(DetailSet.ActId, sessionkey, out errormsg);
            MarketingActivity activity = builder.loadActivity(tool, activityJson);
            MarketingDetail detail = builder.createDetail(activity);

            detail.define("count", DetailSet.Count, ParameterDef.VALUE_TYPE_LONG); // 满1件，只要是初次交易都能满足
            detail.define("enableCountMultiple", null, ParameterDef.VALUE_TYPE_BOOLEAN, DetailSet.IsenableCountMultiple);

            detail.define("totalPrice", DetailSet.TotalPrice, ParameterDef.VALUE_TYPE_LONG); // 满多少元
            detail.define("enableMultiple", null, ParameterDef.VALUE_TYPE_BOOLEAN, DetailSet.IsEnableMultiple);

            detail.define("decreaseMoney", DetailSet.DecreaseMoney, ParameterDef.VALUE_TYPE_LONG); // 减钱
            detail.define("decrease", null, ParameterDef.VALUE_TYPE_BOOLEAN, DetailSet.IsDecrease);

            detail.define("enablefreePostage", null, ParameterDef.VALUE_TYPE_BOOLEAN, DetailSet.IsFreePostage); //包邮

            detail.define("discountRate", DetailSet.DiscountRate, ParameterDef.VALUE_TYPE_LONG); // 打折
            detail.define("discount", null, ParameterDef.VALUE_TYPE_BOOLEAN, DetailSet.IsDiscount);

            detail.define("giftId", DetailSet.GiftId, ParameterDef.VALUE_TYPE_LONG);
            detail.define("giftName", DetailSet.GiftName, ParameterDef.VALUE_TYPE_STRING);
            detail.define("giftUrl", DetailSet.GiftUrl, ParameterDef.VALUE_TYPE_STRING);
            detail.define("sendGift", null, ParameterDef.VALUE_TYPE_BOOLEAN, DetailSet.IsSendGift);
            return builder.buildDetail(detail);
        }


    }
}
