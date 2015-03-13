using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Order;

namespace MYDZ.Interface.Order
{
    public interface IStoreLogistics : BaseInterface
    {
        /// <summary>
        /// 根据店铺编号查询店铺物流关系信息列表
        /// </summary>
        /// <param name="ShopId">店铺编号</param>
        /// <returns></returns>
        IList<StoreLogistics> Select(int ShopId);

        /// <summary>
        /// 根据店铺编号列表查询店铺物流编号列表
        /// </summary>
        /// <param name="IdList">店铺编号列表</param>
        /// <returns></returns>
        string Select(string IdList);

        /// <summary>
        /// 根据店铺编号查询店铺物流关系信息和物流信息列表
        /// </summary>
        /// <param name="ShopId">店铺编号</param>
        /// <returns></returns>
        IList<StoreLogistics> SelectInfo(int ShopId);

        /// <summary>
        /// 根据用户编号查询店铺物流关系信息和物流信息列表
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <returns></returns>
        IList<StoreLogistics> SelectByUser(int UserId);

        /// <summary>
        /// 添加店铺物流关系信息
        /// </summary>
        /// <param name="ShopLogistics">店铺物流关系表</param>
        /// <returns></returns>
        bool Insert(List<StoreLogistics> ListShopLogistics);

        /// <summary>
        /// 根据店铺编号删除店铺物流关系信息
        /// </summary>
        /// <param name="ShopId">店铺编号</param>
        /// <returns></returns>
        bool Delete(int ShopId);
    }
}
