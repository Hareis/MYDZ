using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.Goods.Enum
{
    /// <summary>
    /// 分类字段  regular_shelved(定时上架) never_on_shelf(从未上架) off_shelf(我下架的) for_shelved(等待所有上架) sold_out(全部卖完) violation_off_shelf(违规下架的) 默认查询for_shelved(等待所有上架)这个状态的商品
    /// </summary>
    public enum Banner
    {
        /// <summary>
        /// 定时上架
        /// </summary>
        regular_shelved,
        /// <summary>
        /// 从未上架
        /// </summary>
        never_on_shelf,
        /// <summary>
        /// 我下架的
        /// </summary>
        off_shelf,
        /// <summary>
        /// 等待所有上架
        /// </summary>
        for_shelved,
        /// <summary>
        /// 全部卖完
        /// </summary>
        sold_out,
        /// <summary>
        /// 违规下架的
        /// </summary>
        violation_off_shelf
    }
}
