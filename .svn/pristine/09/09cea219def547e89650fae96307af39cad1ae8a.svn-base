using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Item;
using MYDZ.Entity.Goods;

namespace MYDZ.Business.DataBase_BLL.GoodsBLL
{
    public class BLocation
    {
        public static ILocation SetLocation = (ILocation)DALFactory.DataAccess.Create("Item.Location");

        /// <summary>
        /// 添加一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddLocation(Location model)
        {
            return SetLocation.AddLocation(model);
        }

        /// <summary>
        /// 更新一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateLocation(Location model)
        {
            return SetLocation.UpdateLocation(model);
        }

        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="LocationId"></param>
        /// <returns></returns>
        bool DeleteLocation(string LocationId)
        {
            return SetLocation.DeleteLocation(LocationId);
        }

        /// <summary>
        /// 获取一行数据
        /// </summary>
        /// <param name="LocationId"></param>
        /// <returns></returns>
        IList<Location> GetLocation(string LocationId)
        {
            return SetLocation.GetLocation(LocationId);
        }
    }
}
