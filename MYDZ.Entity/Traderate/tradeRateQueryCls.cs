using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.Traderate
{
    /// <summary>
    /// 评价信息请求类
    /// </summary>
    [Serializable]
    public class tradeRateQueryCls : Response
    {
        /// <summary>
        /// 买家昵称
        /// </summary>
        public string BuyerNick { get; set; }

        /// <summary>
        /// 评价状态
        /// </summary>
        public string RateStatus { get; set; }

        /// <summary>
        /// 是否匿名，卖家评不能匿名。可选值:true(匿名),false(非匿名)。 注意：如果买家匿名购买，那么买家的评价默认匿名
        /// </summary>
        public bool? Anony { get; set; }

        /// <summary>
        /// 评价内容,最大长度: 500个汉字 .注意：当评价结果为good时就不用输入评价内容.评价内容为neutral/bad的时候需要输入评价内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 评价结束时间。如果只输入结束时间，那么全部返回所有评价数据。 2011-01-02 00:00:00
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 商品的数字ID
        /// </summary>
        public long? NumIid { get; set; }

        /// <summary>
        /// 页码。取值范围:大于零的整数最大限制为200; 默认值:1
        /// </summary>
        public long? PageNo { get; set; }

        /// <summary>
        /// 每页获取条数。默认值40，最小值1，最大值150。<br /> 支持最大值为：150<br /> 支持最小值为：1
        /// </summary>
        public long? PageSize { get; set; }

        /// <summary>
        /// 评价类型。可选值:get(得到),give(给出)
        /// </summary>
        public string RateType { get; set; }

        /// <summary>
        /// 评价结果。可选值:good(好评),neutral(中评),bad(差评)
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 评价者角色即评价的发起方。可选值:seller(卖家),buyer(买家)。 当 give buyer 以买家身份给卖家的评价； 当 get seller 以买家身份得到卖家给的评价； 当 give seller 以卖家身份给买家的评价； 当 get buyer 以卖家身份得到买家给的评价。
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// 评价开始时。如果只输入开始时间，那么能返回开始时间之后的评价数据。
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 交易订单id，可以是父订单id号，也可以是子订单id号
        /// </summary>
        public long? Tid { get; set; }

        /// <summary>
        /// 是否启用has_next的分页方式，如果指定true,则返回的结果中不包含总记录数，但是会新增一个是否存在下一页的的字段，通过此种方式获取评价信息，效率在原有的基础上有80%的提升。
        /// </summary>
        public bool? UseHasNext { get; set; }
    }
}
