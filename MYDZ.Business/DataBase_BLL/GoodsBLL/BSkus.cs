using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Item;
using MYDZ.Entity.Goods;

namespace MYDZ.Business.DataBase_BLL.GoodsBLL
{
    public class BSkus
    {
        public static ISkus SetSkus = (ISkus)DALFactory.DataAccess.Create("Item.Skus");

        /// <summary>
        /// 添加一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddSkus(Skus model)
        {
            return SetSkus.AddSkus(model);
        }

        /// <summary>
        /// 更新一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateSkus(Skus model)
        {
            return SetSkus.UpdateSkus(model);
        }

        /// <summary>
        ///删除一行数据
        /// </summary>
        /// <param name="SkusId"></param>
        /// <returns></returns>
        public bool DeleteSkus(string SkusId)
        {
            return SetSkus.DeleteSkus(SkusId);
        }

        /// <summary>
        /// 获取一行数据
        /// </summary>
        /// <param name="SkusId"></param>
        /// <returns></returns>
        public IList<Skus> GetSkus(string SkusId)
        {
            return SetSkus.GetSkus(SkusId);
        }
    }
}
