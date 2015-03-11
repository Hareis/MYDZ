using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Shop;
using System.Runtime.Serialization;

namespace MYDZ.Entity.ClientUser
{
    /// <summary>
    /// 用户店铺关系表
    /// </summary>
    [DataContract(Namespace = "", Name = "user_shop")]
    public class tbClientUserShop : Response
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        [DataMember(Name = "user_id", Order = 0)]
        public int UserId { get; set; }

        /// <summary>
        /// 店铺信息
        /// </summary>
        [DataMember(Name = "shop", Order = 1)]
        public tbShopInfo Shop { get; set; }

        /// <summary>
        /// 用户授权
        /// </summary>
        [DataMember(Name = "sessionkey", Order = 2)]
        public string SessionKey { get; set; }
    }
}
