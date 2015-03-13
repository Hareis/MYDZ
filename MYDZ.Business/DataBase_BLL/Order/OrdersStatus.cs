﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Order;
using MYDZ.DALFactory;
using MYDZ.Entity.Order;

namespace MYDZ.Business.DataBase_BLL.Order
{
    public class OrdersStatus
    {
        private static readonly IOrdersStatus OrdersStatusDal = DataAccess.Create("Order.OrdersStatus") as IOrdersStatus;

        /// <summary>
        /// 查询订单状态信息列表
        /// </summary>
        /// <returns></returns>
        public static IList<tbOrdersStatus> Select() {
            return OrdersStatusDal.Select();
        }
    }
}
