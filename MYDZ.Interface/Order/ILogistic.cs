using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Order;

namespace MYDZ.Interface.Order
{
    public interface ILogistic : BaseInterface
    {
        /// <summary>
        /// 查询物流信息列表
        /// </summary>
        /// <returns></returns>
        IList<Logistic> Select();

        /// <summary>
        /// 根据物流编号查询物流信息
        /// </summary>
        /// <param name="LogisticsId">物流编号</param>
        /// <returns></returns>
        Logistic Select(int LogisticsId);
    }
}
