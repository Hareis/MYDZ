using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.Traderate
{
    /// <summary>
    /// 数据库交易评价
    /// </summary>
    [Serializable]
    public class Tb_TradeRate : Response
    {
        /// <summary>
        ///序号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int ShopId { get; set; }

        /// <summary>
        /// 好评、中评、差评
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 评价者角色
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int SortID { get; set; }
    }
}
