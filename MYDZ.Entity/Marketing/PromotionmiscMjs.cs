﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.Marketing
{
    /// <summary>
    /// 满就送
    /// </summary>
    public class PromotionmiscMjs:Response
    {
        private int _ParticipateRange = 1;
        /// <summary>
        /// 活动名称。
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 活动类型： 1表示商品级别的活动；2表示店铺级别的活动
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 活动范围：0表示全部参与； 1表示部分商品参与。
        /// </summary>
        public int ParticipateRange { get { return _ParticipateRange; } set { _ParticipateRange = value; } }
        /// <summary>
        /// 活动开始时间。
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 活动结束时间。
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 是否有满元条件。
        /// </summary>
        public Boolean IsAmountOver { get; set; }
        /// <summary>
        /// 满多少元。当is_amount_over为true时，该才字段有意义。注意：单位是分，即10000表示100元。
        /// </summary>
        public int TotalPrice { get; set; }
        /// <summary>
        /// 满元是否上不封顶。当is_amount_over为true时，该值才有意义。当该值为true时，表示满元上不封顶，例如满100元减10元，当满200时，则减20元。。。默认为false
        /// </summary>
        public Boolean IsAmountMultiple { get; set; }
        /// <summary>
        /// 是否有满件条件。
        /// </summary>
        public Boolean IsItemCountOver { get; set; }
        /// <summary>
        /// 满多少件。当is_item_count_over为true时，该值才有意义。
        /// </summary>
        public int ItemCount { get; set; }
        /// <summary>
        /// 满件是否上不封顶。当is_amount_multiple为true时，该值才有意义。当该值为true时，表示满件上不封顶，例如满10件减2元，当满20件时，则减4元。。。 默认为false。
        /// </summary>
        public Boolean IsItemMultiple { get; set; }
        /// <summary>
        /// 是否有店铺会员等级条件。
        /// </summary>
        public Boolean IsShopMember { get; set; }
        /// <summary>
        /// 店铺会员等级，当is_shop_member为true时，该值才有意义。0：店铺客户；1：普通客户；2：高级会员；3：VIP会员； 4：至尊VIP会员。
        /// </summary>
        public int ShopMemberLevel { get; set; }
        /// <summary>
        /// 是否指定用户标签。
        /// </summary>
        public Boolean IsUserTag { get; set; }
        /// <summary>
        /// 用户标签。当is_user_tag为true时，该值才有意义。
        /// </summary>
        public string UserTag { get; set; }
        /// <summary>
        /// 是否有减钱行为。
        /// </summary>
        public Boolean IsDecreaseMoney { get; set; }
        /// <summary>
        /// 减多少钱。当is_decrease_money为true时，该值才有意义。注意：该值单位为分，即100表示1元。
        /// </summary>
        public int DecreaseAmount { get; set; }
        /// <summary>
        /// 是否有打折行为。
        /// </summary>
        public Boolean IsDiscount { get; set; }
        /// <summary>
        /// 折扣值。当is_discount为true时，该值才有意义。注意：800表示8折。
        /// </summary>
        public int DiscountRate { get; set; }
        /// <summary>
        /// 是否有送礼品行为。
        /// </summary>
        public Boolean IsSendGift { get; set; }
        /// <summary>
        /// 礼品名称。当is_send_gift为true时，该值才有意义。
        /// </summary>
        public string GiftName { get; set; }
        /// <summary>
        /// 礼品id，当is_send_gift为true时，该值才有意义。
        /// 1）只有填写真实的淘宝商品id时，才能生成物流单，并且在确定订单的页面上可以点击该商品名称跳转到商品详情页面。
        /// 2）当礼物为实物商品时(有宝贝id),礼物必须为上架商品,不能为虚拟商品,不能为拍卖商品,不能有sku,不符合条件的,不做为礼物。
        /// </summary>
        public int GiftId { get; set; }
        /// <summary>
        /// 商品详情的url，当is_send_gift为true时，该值才有效
        /// </summary>
        public string GiftUrl { get; set; }
        /// <summary>
        /// 是否有免邮行为。
        /// </summary>
        public Boolean IsFreePost { get; set; }
        /// <summary>
        /// 免邮的排除地区，即，除指定地区外，其他地区包邮。
        /// 当is_free_post为true时，该值才有意义。
        /// 代码使用*链接，代码为行政区划代码。
        /// </summary>
        public string ExcludeArea { get; set; }
    }
}
