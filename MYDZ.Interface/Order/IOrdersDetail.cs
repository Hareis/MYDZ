using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Order;

namespace MYDZ.Interface.Order
{
    public interface IOrdersDetail : BaseInterface
    {
        /// <summary>
        /// 根据订单编号查询订单详情信息列表
        /// </summary>
        /// <param name="OrdersNumber">订单编号</param>
        /// <returns></returns>
        IList<tbOrdersDetail> Select(string OrdersNumber);

        /// <summary>
        /// 添加订单详情信息
        /// </summary>
        /// <param name="OrdersDetail">订单详情表</param>
        /// <returns></returns>
        bool Insert(tbOrdersDetail OrdersDetail);

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="ListOrdersDetail"></param>
        /// <returns></returns>
        bool InsertListOrdersDetail(List<tbOrdersDetail> ListOrdersDetail);
    }
}
