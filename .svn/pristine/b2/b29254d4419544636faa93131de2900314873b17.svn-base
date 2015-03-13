using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Order;
using MYDZ.Entity.Order;

namespace MYDZ.Business.DataBase_BLL.Order
{
    public class BStoreLogistics
    {
        public static IStoreLogistics SetStoreLogistics = (IStoreLogistics)DALFactory.DataAccess.Create("Order.StoreLogistics");

        /// <summary>
        /// 根据店铺编号查询店铺物流关系信息列表
        /// </summary>
        /// <param name="ShopId">店铺编号</param>
        /// <returns></returns>
        public static IList<StoreLogistics> Select(int ShopId)
        {
            return SetStoreLogistics.Select(ShopId);
        }

        /// <summary>
        /// 根据店铺编号列表查询店铺物流编号列表
        /// </summary>
        /// <param name="IdList">店铺编号列表</param>
        /// <returns></returns>
        public static string Select(string IdList)
        {
            return SetStoreLogistics.Select(IdList);
        }

        /// <summary>
        /// 根据店铺编号查询店铺物流关系信息和物流信息列表
        /// </summary>
        /// <param name="ShopId">店铺编号</param>
        /// <returns></returns>
        public static IList<StoreLogistics> SelectInfo(int ShopId)
        {
            return SetStoreLogistics.SelectInfo(ShopId);
        }

        /// <summary>
        /// 根据用户编号查询店铺物流关系信息和物流信息列表
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <returns></returns>
        public static IList<StoreLogistics> SelectByUser(int UserId)
        {
            return SetStoreLogistics.SelectByUser(UserId);
        }

        /// <summary>
        /// 添加店铺物流关系信息
        /// </summary>
        /// <param name="ShopLogistics">店铺物流关系表</param>
        /// <returns></returns>
        public static bool Insert(List<StoreLogistics> ListShopLogistics)
        {
            return SetStoreLogistics.Insert(ListShopLogistics);
        }

        /// <summary>
        /// 根据店铺编号删除店铺物流关系信息
        /// </summary>
        /// <param name="ShopId">店铺编号</param>
        /// <returns></returns>
        public static bool Delete(int ShopId)
        {
            return SetStoreLogistics.Delete(ShopId);
        }
    }
}
