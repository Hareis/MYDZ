using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Order;

namespace MYDZ.Interface.Order
{
    public interface IOrdersConfig : BaseInterface
    {
        /// <summary>
        /// 根据店铺编号查询订单获取配置信息
        /// </summary>
        /// <param name="ShopId">店铺编号</param>
        /// <returns></returns>
        tbOrdersConfig Select(int ShopId);

        /// <summary>
        /// 根据用户编号查询订单获取配置信息
        /// </summary>
        /// <param name="UserId">用户</param>
        /// <returns></returns>
        tbOrdersConfig SelectByUserId(int UserId);

        /// <summary>
        /// 修改订单获取配置信息
        /// </summary>
        /// <param name="OrdersConfig">订单获取配置表</param>
        /// <returns></returns>
        int Update(tbOrdersConfig OrdersConfig);
    }
}
