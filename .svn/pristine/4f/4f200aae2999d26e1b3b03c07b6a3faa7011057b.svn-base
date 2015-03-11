using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Order;

namespace MYDZ.Interface.Order
{
    public interface IConsigneeInfo : BaseInterface
    {        
        /// <summary>
        /// 根据订单编号查询收件人信息
        /// </summary>
        /// <param name="OrdersNumber">订单编号</param>
        /// <returns></returns>
        tbConsigneeInfo Select(string OrdersNumber);

        /// <summary>
        /// 添加收件人信息
        /// </summary>
        /// <param name="ConsigneeInfo">收件人信息表</param>
        /// <returns></returns>
        bool Insert(tbConsigneeInfo ConsigneeInfo);

        /// <summary>
        /// 修改收件人信息
        /// </summary>
        /// <param name="ConsigneeInfo">收件人信息表</param>
        /// <returns></returns>
        bool Update(tbConsigneeInfo ConsigneeInfo);

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="ListConsigneeInfo"></param>
        /// <returns></returns>
        bool InsertListConsigneeInfo(List<tbConsigneeInfo> ListConsigneeInfo);
    }
}
