using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Goods;

namespace MYDZ.Interface.Item
{
    public interface IFoodSecurity : BaseInterface
    {
        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddFoodSecurity(FoodSecurity model);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateFoodSecurity(FoodSecurity model);

        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="ItemImgID"></param>
        /// <returns></returns>
        bool DeleteFoodSecurity(string FoodSecurityID);

        /// <summary>
        /// 获得一行数据
        /// </summary>
        /// <param name="ItemImgID"></param>
        /// <returns></returns>
        IList<FoodSecurity> GetItemImg(string FoodSecurityID);
    }
}
