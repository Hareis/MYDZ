using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Business.TB_Logic.Shop;
using MYDZ.Entity.Shop;

namespace MYDZ.Business.Business_Logic.Shop
{
    public class InitShopInfo
    {
        GetShop gs = new GetShop();
        /// <summary>
        /// 返回商品类目
        /// </summary>
        /// <param name="NickName"></param>
        /// <returns></returns>
        public List<SellerCat> ReutrnSPLM(string NickName)
        {
            return  gs.GetSPLM(NickName);
        }

        /// <summary>
        /// 返回店铺类目
        /// </summary>
        /// <returns></returns>
        public List<ShopCat> ReturnDPLM()
        {
            return gs.GetDPLM();
        }
    }
}
