using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Order;
using MYDZ.DALFactory;
using MYDZ.Entity.Order;

namespace MYDZ.Business.DataBase_BLL.Order
{
    public class OrderShipping
    {
        private static readonly IOrderShipping OrderShippingDal = DataAccess.Create("Order.OrderShipping") as IOrderShipping;

        /// <summary>
        /// 根据订单编号查询发货单信息列表
        /// </summary>
        /// <param name="OrdersNumber">订单编号</param>
        /// <returns></returns>
        public static IList<tbOrderShipping> Select(string OrdersNumber) {
            return OrderShippingDal.Select(OrdersNumber);
        }

        /// <summary>
        /// 添加发货单信息
        /// </summary>
        /// <param name="OrderShipping">发货单表</param>
        /// <returns></returns>
        public static bool Insert(tbOrderShipping OrderShipping) {
            return OrderShippingDal.Insert(OrderShipping);
        }
    }
}
