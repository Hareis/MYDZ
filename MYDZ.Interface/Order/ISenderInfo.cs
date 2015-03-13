using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Order;

namespace MYDZ.Interface.Order
{
    public interface ISenderInfo : BaseInterface
    {
        /// <summary>
        /// 根据店铺编号查询寄件人信息
        /// </summary>
        /// <param name="ShopId">店铺编号</param>
        /// <returns></returns>
        tbSenderInfo Select(int ShopId);

        /// <summary>
        /// 根据用户编号查询寄件人信息
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <returns></returns>
        tbSenderInfo SelectByUserId(int UserId);

        /// <summary>
        /// 修改寄件人信息
        /// </summary>
        /// <param name="Sender">寄件人信息表</param>
        /// <returns></returns>
        bool Update(tbSenderInfo Sender);
    }
}
