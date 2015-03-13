using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Goods;

namespace MYDZ.Interface.Item
{
    /// <summary>
    /// 商品接口
    /// </summary>
    public interface Iitems : BaseInterface
    {
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        bool AddItems(MYDZ.Entity.Goods.Item model);

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        bool UpdateItems(MYDZ.Entity.Goods.Item model);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="model"></param>
        void DeleteItems(string NumId);

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="NumId"></param>
        /// <returns></returns>
        IList<MYDZ.Entity.Goods.Item> GetItems(string NumId);

    }
}
