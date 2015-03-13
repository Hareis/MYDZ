﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.DALFactory;
using MYDZ.Interface.Order;
using MYDZ.Entity.Order;

namespace MYDZ.Business.DataBase_BLL.Order
{
    public class OrdersConfig
    {
        private static readonly IOrdersConfig OrdersConfigDal = DataAccess.Create("Order.OrdersConfig") as IOrdersConfig;

        /// <summary>
        /// 根据店铺编号查询订单获取配置信息
        /// </summary>
        /// <param name="ShopId">店铺编号</param>
        /// <returns></returns>
        public static tbOrdersConfig Select(int ShopId) {
            tbOrdersConfig Config = OrdersConfigDal.Select(ShopId);

            if (Config.ConfigId > 0) {
                Config.DetailList = ConfigDetail.Select(Config.ConfigId) as List<tbConfigDetail>;
            }

            return Config;
        }

        /// <summary>
        /// 根据用户编号查询订单获取配置信息
        /// </summary>
        /// <param name="UserId">用户</param>
        /// <returns></returns>
        public static tbOrdersConfig SelectByUserId(int UserId) {
            tbOrdersConfig Config = OrdersConfigDal.SelectByUserId(UserId);

            if (Config.ConfigId > 0) {
                Config.DetailList = ConfigDetail.Select(Config.ConfigId) as List<tbConfigDetail>;
            }

            return Config;
        }

        /// <summary>
        /// 修改订单获取配置信息
        /// </summary>
        /// <param name="OrdersConfig">订单获取配置表</param>
        /// <returns></returns>
        public static int Update(tbOrdersConfig OrdersConfig) {
            return OrdersConfigDal.Update(OrdersConfig);
        }
    }
}
