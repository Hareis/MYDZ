using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MYDZ.Entity.Shop
{
    /// <summary>
    /// 店铺信息表
    /// </summary>
    [DataContract(Namespace = "", Name = "shop")]
    public class tbShopInfo : Response
    {
        /// <summary>
        /// 店铺编号,主键,自动编号
        /// </summary>
        [DataMember(Name = "shop_id", Order = 0)]
        public int ShopId { get; set; }

        /// <summary>
        /// 淘宝店铺编号
        /// </summary>
        [DataMember(Name = "tb_shop_id", Order = 1)]
        public int TbShopId { get; set; }

        /// <summary>
        /// 店铺评分
        /// </summary>
        [DataMember(Name = "score", Order = 2)]
        public tbShopScore Score { get; set; }

        /// <summary>
        /// 店铺所属类目编号
        /// </summary>
        [DataMember(Name = "cate_id", Order = 3)]
        public int CateId { get; set; }

        /// <summary>
        /// 卖家昵称
        /// </summary>
        [DataMember(Name = "nick_name", Order = 4)]
        public string NickName { get; set; }

        /// <summary>
        /// 店铺标题
        /// </summary>
        [DataMember(Name = "shop_title", Order = 5)]
        public string Title { get; set; }

        /// <summary>
        /// 店铺描述
        /// </summary>
        [DataMember(Name = "shop_desc", Order = 6)]
        public string Desc { get; set; }

        /// <summary>
        /// 店铺公告
        /// </summary>
        [DataMember(Name = "bulletin", Order = 7)]
        public string Bulletin { get; set; }
        
        /// <summary>
        /// 店标地址
        /// </summary>
        [DataMember(Name = "pic_path", Order = 8)]
        public string PicPath { get; set; }

        /// <summary>
        /// 开店日期
        /// </summary>
        [DataMember(Name = "created", Order = 9)]
        public DateTime Created { get; set; }

        /// <summary>
        /// 最后修改日期
        /// </summary>
        [DataMember(Name = "modified", Order = 10)]
        public DateTime Modified { get; set; }
    }
}
