using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Order;
using MYDZ.Entity.Order;
using MYDZ.DALFactory;

namespace MYDZ.Business.DataBase_BLL.Order
{
    public class BuyerInfo
    {
        private static readonly IBuyerInfo BuyerInfoDal = DataAccess.Create("Order.BuyerInfo") as IBuyerInfo;

        /// <summary>
        /// 根据订单编号查询买家信息
        /// </summary>
        /// <param name="OrdersNumber">订单编号</param>
        /// <returns></returns>
        public static tbBuyerInfo Select(string OrdersNumber)
        {
            return BuyerInfoDal.Select(OrdersNumber);
        }

        /// <summary>
        /// 添加买家信息
        /// </summary>
        /// <param name="Buyer">买家信息</param>
        /// <returns></returns>
        public static bool Insert(tbBuyerInfo Buyer)
        {
            return BuyerInfoDal.Insert(Buyer);
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="listBuyer"></param>
        /// <returns></returns>
        public static bool InsertListBuyerInfo(List<tbBuyerInfo> listBuyer)
        {
            return BuyerInfoDal.InsertListBuyerInfo(listBuyer);
        }
    }
}
