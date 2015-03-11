using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Item;

namespace MYDZ.Business.DataBase_BLL.GoodsBLL
{
    public class BItems
    {
        public static Iitems SetItem = (Iitems)DALFactory.DataAccess.Create("Item.Item");
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
       public bool AddItems(MYDZ.Entity.Goods.Item model)
        {
            return SetItem.AddItems(model);
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
      public  bool UpdateItems(MYDZ.Entity.Goods.Item model)
        {
            return SetItem.UpdateItems(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="model"></param>
      public  void DeleteItems(string NumId)
        {
            SetItem.DeleteItems(NumId);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="NumId"></param>
        /// <returns></returns>
      public  IList<MYDZ.Entity.Goods.Item> GetItems(string NumId)
        {
            return SetItem.GetItems(NumId);
        }
    }
}
