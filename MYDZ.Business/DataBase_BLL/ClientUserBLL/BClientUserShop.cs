﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.ClientUser;
using MYDZ.Entity.ClientUser;

namespace MYDZ.Business.DataBase_BLL.ClientUserBLL
{
    public class BClientUserShop
    {
        public static IClientUserShop SetUserShop = (IClientUserShop)DALFactory.DataAccess.Create("ClientUser.ClientUserShop");

        public static int InsertUserShop(tbClientUserShop model)
        {
            return SetUserShop.InsertUserShop(model);
        }

        public static bool UpdateUserShop(tbClientUserShop model)
        {
            return SetUserShop.UpdateUserShop(model);
        }

        public static tbClientUserShop SelectUserShopByUserId(string UserId)
        {
            return SetUserShop.SelectUserShopByUserId(UserId);
        }

        public static IList<tbClientUserShop> SelectUserShopByShopId(string ShopId)
        {
            return SetUserShop.SelectUserShopByShopId(ShopId);
        }
    }
}
