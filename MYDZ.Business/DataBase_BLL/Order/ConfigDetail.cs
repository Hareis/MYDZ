﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Order;
using MYDZ.DALFactory;
using MYDZ.Entity.Order;

namespace MYDZ.Business.DataBase_BLL.Order
{
    public class ConfigDetail
    {
        private static readonly IConfigDetail ConfigDetailDal = DataAccess.Create("Order.ConfigDetail") as IConfigDetail;

        /// <summary>
        /// 根据配置编号查询订单获取配置详情信息列表
        /// </summary>
        /// <param name="ConfigId">配置编号</param>
        /// <returns></returns>
        public static IList<tbConfigDetail> Select(int ConfigId) {
            return ConfigDetailDal.Select(ConfigId);
        }

        /// <summary>
        /// 添加订单获取配置详情信息
        /// </summary>
        /// <param name="ConfigDetail">订单获取详情信息表</param>
        /// <returns></returns>
        public static bool Insert(tbConfigDetail ConfigDetail) {
            return ConfigDetailDal.Insert(ConfigDetail);
        }

        /// <summary>
        /// 根据配置编号删除订单获取配置详情信息
        /// </summary>
        /// <param name="ConfigId">配置编号</param>
        /// <returns></returns>
        public static bool Delete(int ConfigId) {
            return ConfigDetailDal.Delete(ConfigId);
        }
    }
}
