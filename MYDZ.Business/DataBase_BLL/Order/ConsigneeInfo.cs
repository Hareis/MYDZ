using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Order;
using MYDZ.DALFactory;
using MYDZ.Entity.Order;

namespace MYDZ.Business.DataBase_BLL.Order
{
    public class ConsigneeInfo
    {
        private static readonly IConsigneeInfo ConsigneeInfoDal = DataAccess.Create("Order.ConsigneeInfo") as IConsigneeInfo;

        /// <summary>
        /// 根据订单编号查询收件人信息
        /// </summary>
        /// <param name="OrdersNumber">订单编号</param>
        /// <returns></returns>
        public static tbConsigneeInfo Select(string OrdersNumber)
        {
            return ConsigneeInfoDal.Select(OrdersNumber);
        }

        /// <summary>
        /// 添加收件人信息
        /// </summary>
        /// <param name="ConsigneeInfo">收件人信息表</param>
        /// <returns></returns>
        public static bool Insert(tbConsigneeInfo ConsigneeInfo)
        {
            return ConsigneeInfoDal.Insert(ConsigneeInfo);
        }

        /// <summary>
        /// 修改收件人信息
        /// </summary>
        /// <param name="ConsigneeInfo">收件人信息表</param>
        /// <returns></returns>
        public static bool Update(tbConsigneeInfo ConsigneeInfo)
        {
            return ConsigneeInfoDal.Update(ConsigneeInfo);
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="ListConsigneeInfo"></param>
        /// <returns></returns>
        public static bool InsertListConsigneeInfo(List<tbConsigneeInfo> ListConsigneeInfo)
        {
            return ConsigneeInfoDal.InsertListConsigneeInfo(ListConsigneeInfo);
        }
    }
}
