using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api.Request;
using MYDZ.Business.TB_Logic.SDK_UMP.Response;
using Top.Api;
using Top.Api.Util;

namespace MYDZ.Business.TB_Logic.SDK_UMP.Request
{
    /// <summary>
    /// 创建无条件单品优惠活动
    /// </summary>
    internal class PromotionmiscItemActivityAddRequest : ITopRequest<PromotionmiscItemActivityAddResponse>
    {
        /// <summary>
        /// 活动名称，超过5个汉字时，商品详情中显示的优惠名称为：卖家优惠。
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 活动范围：0表示全部参与； 1表示部分商品参与。
        /// </summary>
        public int ParticipateRange { get; set; }
        /// <summary>
        /// 活动开始时间。
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 活动结束时间。
        /// </summary>
        public string EndTime { get; set; }
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

        private IDictionary<string, string> otherParameters;

        public string GetApiName()
        {
            return "taobao.promotionmisc.item.activity.add";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("name", this.Name);
            parameters.Add("participate_range", this.ParticipateRange);
            parameters.Add("start_time", this.StartTime);
            parameters.Add("end_time", this.EndTime);
            parameters.Add("is_user_tag", this.IsUserTag);
            parameters.Add("user_tag", this.UserTag);
            parameters.Add("is_decrease_money", this.IsDecreaseMoney);
            parameters.Add("decrease_amount", this.DecreaseAmount);
            parameters.Add("is_discount", this.IsDiscount);
            parameters.Add("discount_rate", this.DiscountRate);
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("name", this.Name);
            RequestValidator.ValidateRequired("participate_range", this.ParticipateRange);
            RequestValidator.ValidateRequired("start_time", this.StartTime);
            RequestValidator.ValidateRequired("end_time", this.EndTime);
        }

        public void AddOtherParameter(string key, string value)
        {
            if (this.otherParameters == null)
            {
                this.otherParameters = new TopDictionary();
            }
            this.otherParameters.Add(key, value);
        }
    }
}
