using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Item;
using MYDZ.Entity.Goods;

namespace MYDZ.Business.DataBase_BLL.GoodsBLL
{
    public class BLocalityLife
    {
        public static ILocalityLife SetLocalityLife = (ILocalityLife)DALFactory.DataAccess.Create("Item.LocalityLife");

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddLocalityLife(LocalityLife model)
        {
            return SetLocalityLife.AddLocalityLife(model);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateLocalityLife(LocalityLife model)
        {
            return SetLocalityLife.UpdateLocalityLife(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="LocalityLifeID"></param>
        /// <returns></returns>
        bool DeleteLocalityLife(string LocalityLifeID)
        {
            return SetLocalityLife.DeleteLocalityLife(LocalityLifeID);
        }

        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <param name="LocalityLifeID"></param>
        /// <returns></returns>
        IList<LocalityLife> GetLocalityLife(string LocalityLifeID)
        {
            return SetLocalityLife.GetLocalityLife(LocalityLifeID);
        }
    }
}
