using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Order;

namespace MYDZ.Interface.Order
{
    public interface IOrderSync : BaseInterface
    {
        /// <summary>
        /// 根据用户编号查询订单同步状态信息
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <param name="SyncEnum">同步类型</param>
        /// <returns></returns>
        tbOrderSync Select(int UserId, int SyncEnum);

        /// <summary>
        /// 添加订单同步状态信息
        /// </summary>
        /// <param name="OrderSync">订单同步状态表</param>
        /// <returns></returns>
        bool Insert(tbOrderSync OrderSync);

        /// <summary>
        /// 修改订单同步状态信息
        /// </summary>
        /// <param name="OrderSync">订单同步状态表</param>
        /// <returns></returns>
        bool Update(tbOrderSync OrderSync);
    }
}
