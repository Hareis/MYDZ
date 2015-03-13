using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Order;
using MYDZ.Interface.Order;

namespace MYDZ.Business.DataBase_BLL.Order
{
    public class BLogistic
    {
        public static ILogistic SetLogistic = (ILogistic)DALFactory.DataAccess.Create("Order.Logistic");
        /// <summary>
        /// 查询物流信息列表
        /// </summary>
        /// <returns></returns>
        public static IList<Logistic> Select()
        {
            return SetLogistic.Select();
        }

        /// <summary>
        /// 根据物流编号查询物流信息
        /// </summary>
        /// <param name="LogisticsId">物流编号</param>
        /// <returns></returns>
        public static Logistic Select(int LogisticsId)
        {
            return SetLogistic.Select(LogisticsId);
        }
    }
}
