using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Order;
using MYDZ.DALFactory;
using MYDZ.Entity.Order;

namespace MYDZ.Business.DataBase_BLL.Order
{
    public class OrderPrint
    {
        private static readonly IOrderPrint OrderPrintDal = DataAccess.Create("Order.OrderPrint") as IOrderPrint;

        /// <summary>
        /// 根据订单编号查询订单打印信息列表
        /// </summary>
        /// <param name="OrdersNumber">订单编号</param>
        /// <returns></returns>
        public static IList<tbOrderPrint> Select(string OrdersNumber) {
            return OrderPrintDal.Select(OrdersNumber);
        }

        /// <summary>
        /// 添加订单打印信息
        /// </summary>
        /// <param name="OrderPrint">订单打印表</param>
        /// <returns></returns>
        public static bool Insert(tbOrderPrint OrderPrint) {
            return OrderPrintDal.Insert(OrderPrint);
        }
    }
}
