using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Order;

namespace MYDZ.Interface.Order
{
    public interface IOrderPrint : BaseInterface
    {
        /// <summary>
        /// 根据订单编号查询订单打印信息列表
        /// </summary>
        /// <param name="OrdersNumber">订单编号</param>
        /// <returns></returns>
        IList<tbOrderPrint> Select(string OrdersNumber);

        /// <summary>
        /// 添加订单打印信息
        /// </summary>
        /// <param name="OrderPrint">订单打印表</param>
        /// <returns></returns>
        bool Insert(tbOrderPrint OrderPrint);
    }
}
