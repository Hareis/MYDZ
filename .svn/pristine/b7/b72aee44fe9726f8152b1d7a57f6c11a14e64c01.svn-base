using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Order;

namespace MYDZ.Interface.Order
{
    public interface IOrderShipping : BaseInterface
    {
        /// <summary>
        /// 根据订单编号查询发货单信息列表
        /// </summary>
        /// <param name="OrdersNumber">订单编号</param>
        /// <returns></returns>
        IList<tbOrderShipping> Select(string OrdersNumber);

        /// <summary>
        /// 添加发货单信息
        /// </summary>
        /// <param name="OrderShipping">发货单表</param>
        /// <returns></returns>
        bool Insert(tbOrderShipping OrderShipping);
    }
}
