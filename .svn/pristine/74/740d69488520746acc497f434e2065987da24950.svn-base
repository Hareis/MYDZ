using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.ClientUser;

namespace MYDZ.Interface.ClientUser
{
    public interface IClientUserShop : BaseInterface
    {
        /// <summary>
        /// 添加用户店铺关系表
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        int InsertUserShop(tbClientUserShop User);

        /// <summary>
        /// 更新用户店铺关系表
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        bool UpdateUserShop(tbClientUserShop User);

        /// <summary>
        /// 查询店铺信息(通过UserId)
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        tbClientUserShop SelectUserShopByUserId(string UserId);

        /// <summary>
        /// 查询店铺信息(通过ShopId)
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        IList<tbClientUserShop> SelectUserShopByShopId(string ShopId);
    }
}
