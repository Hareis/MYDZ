using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.Marketing
{
    /// <summary>
    /// 创建无条件单品优惠活动 实体类
    /// </summary>
    public class PromotionmiscItem : Response
    {
        private int _ParticipateRange = 1;
        /// <summary>
        /// 活动名称，超过5个汉字时，商品详情中显示的优惠名称为：卖家优惠。
        /// </summary>
        public string Name { get; set; }
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
        ///  是否指定用户标签。
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

    }
}
