using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Item;
using MYDZ.Entity.Goods;

namespace MYDZ.Business.DataBase_BLL.GoodsBLL
{
   public class BFoodSecurity
    {
       public static IFoodSecurity SetFoodSecurity = (IFoodSecurity)DALFactory.DataAccess.Create("Item.FoodSecurity");
       /// <summary>
       /// 增加数据
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       bool AddFoodSecurity(FoodSecurity model)
       {
           return SetFoodSecurity.AddFoodSecurity(model);
       }

       /// <summary>
       /// 更新数据
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       bool UpdateFoodSecurity(FoodSecurity model)
       {
         return  SetFoodSecurity.UpdateFoodSecurity(model);
       }

       /// <summary>
       /// 删除一行数据
       /// </summary>
       /// <param name="ItemImgID"></param>
       /// <returns></returns>
       bool DeleteFoodSecurity(string FoodSecurityID)
       {
           return SetFoodSecurity.DeleteFoodSecurity(FoodSecurityID);
       }

       /// <summary>
       /// 获得一行数据
       /// </summary>
       /// <param name="ItemImgID"></param>
       /// <returns></returns>
       IList<FoodSecurity> GetItemImg(string FoodSecurityID)
       {
           return SetFoodSecurity.GetItemImg(FoodSecurityID);
       }
    }
}
