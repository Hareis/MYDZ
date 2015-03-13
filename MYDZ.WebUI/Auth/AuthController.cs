﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MYDZ.Entity.ClientUser;
using MYDZ.Business.InitUser;
using MYDZ.Common;

namespace MYDZ.WebUI.Auth
{
    public class AuthController : BaseController
    {
        public ViewResult Index(string code = "", string service_code = "", string item_code = "")
        {            
            string Msg = "授权失败，请重新授权";

            if (String.IsNullOrEmpty(code))
            {
                Msg = "<script>window.location.href='" + Business.TB_Logic.GetInfo.ReturnUrl() + "';</script>";
            }
            else
            {
                tbClientUser User = new UserInfo().FromCodeToGetAccesToken(code);
                SetUser("UserInfo", User);
                Msg = "<script>window.location.href='/Member/Index.html';</script>";
            }

            ViewBag.Msg = Msg;
            return View();
        }

        public ViewResult RestLogin()
        {
            return View();
        }
    }
}
