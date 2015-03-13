using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Goods;

namespace MYDZ.Interface.Item
{
    /// <summary>
    /// 发货时间接口
    /// </summary>
    public interface IDeliveryTime : BaseInterface
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int AddDeliveryTime(DeliveryTime model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateDeliveryTime(DeliveryTime model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="DeliveryTimeID"></param>
        /// <returns></returns>
        bool DeleteDeliveryTime(string DeliveryTimeID);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="DeliveryTimeID"></param>
        /// <returns></returns>
        IList<DeliveryTime> GetDeliveryTime(string DeliveryTimeID);

    }
}
