using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.Goods
{
    /// <summary>
    /// 查询条件类 仓库中
    /// </summary>
    public class QueryCriteriaForInventory : Response
    {
        /// <summary>
        /// 分类字段。可选值:<br> regular_shelved(定时上架)<br> never_on_shelf(从未上架)<br> off_shelf(我下架的)<br> <font color='red'>for_shelved(等待所有上架)<br> sold_out(全部卖完)<br> violation_off_shelf(违规下架的)<br> 默认查询for_shelved(等待所有上架)这个状态的商品<br></font> 注：for_shelved(等待所有上架)=regular_shelved(定时上架)+never_on_shelf(从未上架)+off_shelf(我下架的)
        /// </summary>
        public string Banner { get; set; }

        /// <summary>
        /// 商品类目ID。ItemCat中的cid字段。可以通过taobao.itemcats.get取到<br /> 支持最小值为：0
        /// </summary>
        public Nullable<long> Cid { get; set; }

        /// <summary>
        /// 商品结束修改时间
        /// </summary>
        public Nullable<DateTime> EndModified { get; set; }

        /// <summary>
        /// 是否参与会员折扣。可选值：true，false。默认不过滤该条件
        /// </summary>
        public Nullable<bool> HasDiscount { get; set; }

        /// <summary>
        /// 是否挂接了达尔文标准产品体系。
        /// </summary>
        public Nullable<bool> IsCspu { get; set; }

        /// <summary>
        /// 商品是否在外部网店显示
        /// </summary>
        public Nullable<bool> IsEx { get; set; }

        /// <summary>
        /// 商品是否在淘宝显示
        /// </summary>
        public Nullable<bool> IsTaobao { get; set; }

        /// <summary>
        /// 排序方式。格式为column:asc/desc ，column可选值:list_time(上架时间),delist_time(下架时间),num(商品数量)，modified(最近修改时间);默认上架时间降序(即最新上架排在前面)。如按照上架时间降序排序方式为list_time:desc
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// 页码。取值范围:大于零小于等于101的整数;默认值为1，即返回第一页数据。当页码超过101页时系统就会报错，故请大家在用此接口获取数据时尽可能的细化自己的搜索条件，例如根据修改时间分段获取商品。<br /> 支持最大值为：101
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页条数。取值范围:大于零的整数;最大值：200；默认值：40。
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 搜索字段。搜索商品的title。
        /// </summary>
        public string Q { get; set; }

        /// <summary>
        /// 卖家店铺内自定义类目ID。多个之间用“,”分隔。可以根据taobao.sellercats.list.get获得.(<font color="red">注：目前最多支持32个ID号传入</font>)
        /// </summary>
        public string SellerCids { get; set; }

        /// <summary>
        /// 商品起始修改时间
        /// </summary>
        public Nullable<DateTime> StartModified { get; set; }
    }
    /// <summary>
    /// 查询条件类 在售
    /// </summary>
    public class QueryCriteriaForOnSales: Response
    {
        /// <summary>
        /// 商品类目ID。ItemCat中的cid字段。可以通过taobao.itemcats.get取到<br /> 支持最小值为：0
        /// </summary>
        public Nullable<long> Cid { get; set; }

        /// <summary>
        /// 结束的修改时间
        /// </summary>
        public Nullable<DateTime> EndModified { get; set; }

        /// <summary>
        /// 是否参与会员折扣。可选值：true，false。默认不过滤该条件
        /// </summary>
        public Nullable<bool> HasDiscount { get; set; }

        /// <summary>
        /// 是否橱窗推荐。 可选值：true，false。默认不过滤该条件
        /// </summary>
        public Nullable<bool> HasShowcase { get; set; }

        /// <summary>
        /// 是否挂接了达尔文标准产品体系。
        /// </summary>
        public Nullable<bool> IsCspu { get; set; }

        /// <summary>
        /// 商品是否在外部网店显示
        /// </summary>
        public Nullable<bool> IsEx { get; set; }

        /// <summary>
        /// 商品是否在淘宝显示
        /// </summary>
        public Nullable<bool> IsTaobao { get; set; }

        /// <summary>
        /// 排序方式。格式为column:asc/desc ，column可选值:list_time(上架时间),delist_time(下架时间),num(商品数量)，modified(最近修改时间)，sold_quantity（商品销量）,;默认上架时间降序(即最新上架排在前面)。如按照上架时间降序排序方式为list_time:desc
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// 页码。取值范围:大于零的整数。默认值为1,即默认返回第一页数据。用此接口获取数据时，当翻页获取的条数（page_no*page_size）超过10万,为了保护后台搜索引擎，接口将报错。所以请大家尽可能的细化自己的搜索条件，例如根据修改时间分段获取商品
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页条数。取值范围:大于零的整数;最大值：200；默认值：40。用此接口获取数据时，当翻页获取的条数（page_no*page_size）超过2万,为了保护后台搜索引擎，接口将报错。所以请大家尽可能的细化自己的搜索条件，例如根据修改时间分段获取商品
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 搜索字段。搜索商品的title。
        /// </summary>
        public string Q { get; set; }

        /// <summary>
        /// 卖家店铺内自定义类目ID。多个之间用“,”分隔。可以根据taobao.sellercats.list.get获得.(<font color="red">注：目前最多支持32个ID号传入</font>)
        /// </summary>
        public string SellerCids { get; set; }

        /// <summary>
        /// 起始的修改时间
        /// </summary>
        public Nullable<DateTime> StartModified { get; set; }

        /// <summary>
        /// 商品列表
        /// </summary>
        public string GoodsIdList { get; set; }

        /// <summary>
        /// 商家编码
        /// </summary>
        public string OuterId { get; set; }
    }
}
