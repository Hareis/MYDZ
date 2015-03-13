using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Item;

namespace MYDZ.Business.DataBase_BLL.GoodsBLL
{
    public class BDeliveryTime
    {
        public static IDeliveryTime SetDeliveryTime = (IDeliveryTime)DALFactory.DataAccess.Create("Item.DeliveryTime");
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddDeliveryTime(MYDZ.Entity.Goods.DeliveryTime model)
        {
            return SetDeliveryTime.AddDeliveryTime(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateDeliveryTime(MYDZ.Entity.Goods.DeliveryTime model)
        {
            return SetDeliveryTime.UpdateDeliveryTime(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="DeliveryTimeID"></param>
        /// <returns></returns>
        public bool DeleteDeliveryTime(string DeliveryTimeID)
        {
            return SetDeliveryTime.DeleteDeliveryTime(DeliveryTimeID);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="DeliveryTimeID"></param>
        /// <returns></returns>
        public IList<MYDZ.Entity.Goods.DeliveryTime> GetDeliveryTime(string DeliveryTimeID)
        {
            return SetDeliveryTime.GetDeliveryTime(DeliveryTimeID);
        }
    }
}
