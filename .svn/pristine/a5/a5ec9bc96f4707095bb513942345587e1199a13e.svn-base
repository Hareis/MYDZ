using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Order;

namespace MYDZ.Interface.Order
{
    public interface IBuyerInfo : BaseInterface
    {
        /// <summary>
        /// 根据订单编号查询买家信息
        /// </summary>
        /// <param name="OrdersNumber">订单编号</param>
        /// <returns></returns>
        tbBuyerInfo Select(string OrdersNumber);

        /// <summary>
        /// 添加买家信息
        /// </summary>
        /// <param name="Buyer">买家信息</param>
        /// <returns></returns>
        bool Insert(tbBuyerInfo Buyer);

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="listBuyer"></param>
        /// <returns></returns>
        bool InsertListBuyerInfo(List<tbBuyerInfo> listBuyer);

    }
}
