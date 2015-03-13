using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MYDZ.Entity.Shop
{
    /// <summary>
    /// 店铺动态评分表
    /// </summary>
    [DataContract(Namespace = "", Name = "shop_score")]
    public class tbShopScore : Response
    {
        /// <summary>
        /// 评分编号,主键,自动编号
        /// </summary>
        [DataMember(Name = "score_id", Order = 0)]
        public int ScoreId { get; set; }

        /// <summary>
        /// 商品描述评分
        /// </summary>
        [DataMember(Name = "item_score", Order = 1)]
        public string ItemScore { get; set; }

        /// <summary>
        /// 服务态度评分
        /// </summary>
        [DataMember(Name = "service_score", Order = 2)]
        public string ServiceScore { get; set; }

        /// <summary>
        /// 发货速度评分
        /// </summary>
        [DataMember(Name = "delivery_score", Order = 3)]
        public string DeliveryScore { get; set; }
    }
}
