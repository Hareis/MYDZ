using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Common;
using System.Web.Mvc;
using MYDZ.Entity.ClientUser;
using MYDZ.Business.InitUser;

namespace MYDZ.WebUI.Member
{
    // Controller--->BaseController
    public class MemberController : Controller
    {
        public ViewResult Index()
        {
            // 仅做测试之用
            tbClientUser User = new tbClientUser();
            tbClientUserShop sh = new tbClientUserShop();
            sh.SessionKey = "6200e0453754ZZ5127019d690095fc64a3129b54725e52f2054718375";
            sh.UserId = 11;
            sh.Shop = new Entity.Shop.tbShopInfo();
            sh.Shop.ShopId = 16;
            User.UserNick = "sandbox_b_28";
            User.UserShops = new List<tbClientUserShop>();
            User.UserShops.Add(sh);
            User.UserId = 11;
            //tbClientUser User = new UserInfo().FromCodeToGetAccesToken(code);
            Session["UserInfo"] = User;

            /*
             // 仅做测试之用
            tbClientUser User = new tbClientUser();
            tbClientUserShop sh = new tbClientUserShop();
            sh.SessionKey = "6201c17bf598b4b36944c656dfh13ed3612557f581ece70366";
            sh.UserId = 17;
            sh.Shop = new Entity.Shop.tbShopInfo();
            sh.Shop.ShopId = 20;
            User.UserNick = "sandbox_lili_ab0";
            User.UserShops = new List<tbClientUserShop>();
            User.UserShops.Add(sh);
            User.UserId = 17;
            //tbClientUser User = new UserInfo().FromCodeToGetAccesToken(code);
            Session["UserInfo"] = User;
             */
            return View();

        }
    }
}
