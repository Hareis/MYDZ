using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Order;
using MYDZ.DALFactory;
using MYDZ.Entity.Order;

namespace MYDZ.Business.DataBase_BLL.Order
{
    public class OrderSync
    {
        private static readonly IOrderSync OrderSyncDal = DataAccess.Create("Order.OrderSync") as IOrderSync;

        /// <summary>
        /// 根据用户编号查询订单同步状态信息
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <param name="SyncEnum">同步类型</param>
        /// <returns></returns>
        public static tbOrderSync Select(int UserId, int SyncEnum) {
            return OrderSyncDal.Select(UserId, SyncEnum);
        }

        /// <summary>
        /// 添加订单同步状态信息
        /// </summary>
        /// <param name="OrderSync">订单同步状态表</param>
        /// <returns></returns>
        public static bool Insert(tbOrderSync OrderSync) {
            return OrderSyncDal.Insert(OrderSync);
        }

        /// <summary>
        /// 修改订单同步状态信息
        /// </summary>
        /// <param name="OrderSync">订单同步状态表</param>
        /// <returns></returns>
        public static bool Update(tbOrderSync OrderSync) {
            return OrderSyncDal.Update(OrderSync);
        }
    }
}
