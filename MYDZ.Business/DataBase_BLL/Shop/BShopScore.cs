using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Shop;
using MYDZ.Entity.Shop;

namespace MYDZ.Business.DataBase_BLL.Shop
{
    public class BShopScore
    {
        public static IShopScore SetShopScore = (IShopScore)DALFactory.DataAccess.Create("Shop.ShopScore");

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="ShopScore"></param>
        /// <returns></returns>
        public static int InsertShopScore(tbShopScore ShopScore)
        {
            return SetShopScore.InsertShopScore(ShopScore);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="ShopScore"></param>
        /// <returns></returns>
        public static bool UpdateShopScore(tbShopScore ShopScore)
        {
            return SetShopScore.UpdateShopScore(ShopScore);
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="ScoreId"></param>
        /// <returns></returns>
        public static tbShopScore SelecttbShopScoreByShopId(string ScoreId)
        {
            return SetShopScore.SelecttbShopScoreByShopId(ScoreId);
        }
    }
}
