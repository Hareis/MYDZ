﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using MYDZ.Config.Theme;
using MYDZ.Entity;
using MYDZ.Entity.ClientUser;

namespace MYDZ.Common
{
    [MYDZAuthorize()]
    public class BaseController : Controller
    {
        /// <summary>
        /// 皮肤Cookie名称
        /// </summary>
        private readonly string ThemeCookieName = "SkinName";

        /// <summary>
        /// 获取当前皮肤名称
        /// </summary>
        /// <param name="Theme">皮肤列表</param>
        /// <returns></returns>
        protected string GetThemeName(ThemeConfig ThemeConfig = null)
        {
            if (ThemeConfig == null)
            {
                ThemeConfig = GetThemeList();
            }

            string ThemeName = "";

            if (HttpContext.Request.Cookies[ThemeCookieName] != null)
            {
                ThemeName = HttpUtility.UrlDecode(HttpContext.Request.Cookies[ThemeCookieName].Value);
            }

            if (!String.IsNullOrEmpty(ThemeName))
            {
                if (!CheckThemeName(ThemeName, ThemeConfig))
                {
                    ThemeName = "";
                }
            }

            if (String.IsNullOrEmpty(ThemeName)) { ThemeName = GetDefaultThemeName(ThemeConfig); }

            return ThemeName;
        }

        /// <summary>
        /// 获取默认皮肤名称
        /// </summary>
        /// <param name="Theme">皮肤列表</param>
        /// <returns></returns>
        protected string GetDefaultThemeName(ThemeConfig ThemeConfig = null)
        {
            string ThemeName = "";

            if (ThemeConfig == null)
            {
                ThemeConfig = GetThemeList();
            }

            Theme theme = ThemeConfig.ThemeList.FirstOrDefault((e) => { return e.IsDefault; });
            if (theme != null)
            {
                ThemeName = theme.Value;
            }

            return ThemeName;
        }

        /// <summary>
        /// 获取皮肤列表
        /// </summary>
        /// <returns></returns>
        protected ThemeConfig GetThemeList()
        {
            return ThemeConfigs.GetConfig();
        }

        /// <summary>
        /// 验证皮肤名称是否有效
        /// </summary>
        /// <param name="ThemeName">皮肤名称</param>
        /// <param name="Theme">皮肤列表</param>
        /// <returns></returns>
        protected bool CheckThemeName(string ThemeName, ThemeConfig Theme = null)
        {
            bool isok = false;

            if (Theme == null)
            {
                Theme = GetThemeList();
            }

            if (Theme.ThemeList.FirstOrDefault((e) => { return e.Value.Equals(ThemeName, StringComparison.CurrentCultureIgnoreCase); }) != null)
            {
                isok = true;
            }

            return isok;
        }

        /// <summary>
        /// 读取Session
        /// </summary>
        /// <param name="SessionName"></param>
        /// <returns></returns>
        protected tbClientUser GetUser(string SessionName)
        {
            return SessionManger.GetSession<tbClientUser>(SessionName);
        }
        /// <summary>
        /// 存入Session
        /// </summary>
        /// <param name="SessionName"></param>
        /// <param name="data"></param>
        protected void SetUser(string SessionName, object data)
        {
            SessionManger.SetSession(SessionName, data);
        }

        /*/// <summary>
        /// 获取会员信息
        /// </summary>
        /// <returns></returns>
        protected tbUserInfo GetUser() {
            tbUserInfo UserInfo = null;
            if (Session["User"] != null) {
                UserInfo = (tbUserInfo)Session["User"];
            } else {
                HttpContext.Response.Write("<script language=javascript>if(parent){parent.location.href= '/Management/Login.html';}else{window.location.href='/Management/Login.html'}</script> ");
                HttpContext.Response.End();
            }

            return UserInfo;
        }

        /// <summary>
        /// 获取会员编号
        /// </summary>
        protected int UserId {
            get {
                tbUserInfo User = GetUser();
                return User == null ? 0 : User.UserId;
            }
        }*/
    }

    /// <summary>
    /// 用户授权类
    /// </summary>
    public class MYDZAuthorize : AuthorizeAttribute
    {

        /// <summary>
        /// 用户授权类无参构造函数
        /// </summary>
        public MYDZAuthorize() { }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.RouteData.Values["controller"].ToString() != "Auth")
            {
                SessionManger.CheckSessionState("UserInfo");
            }
        }
    }
    /// <summary>
    /// Session的管理
    /// </summary>
    internal class SessionManger
    {

        /// <summary>
        /// 验证Session的有效性
        /// </summary>
        internal static void CheckSessionState(string SessionName)
        {
            try
            {
                if (!string.IsNullOrEmpty(SessionName))
                {
                    if (HttpContext.Current.Session[SessionName] == null )
                    {
                        HttpContext.Current.Response.Write("<script language=javascript>if(parent){parent.location.href= '/Auth/RestLogin.html';}else{window.location.href='/Management/Login.html'}</script> ");
                        HttpContext.Current.Response.End();
                    }
                }
            }
            catch (Exception)
            {                
                throw;
            }
            
        }

        /// <summary>
        /// 写入Session
        /// </summary>
        /// <param name="SessionName">Session名称</param>
        /// <param name="data">数据</param>
        internal static void SetSession(string SessionName, object data)
        {
            //if (HttpContext.Current.Session[SessionName] == null)
            //{
                HttpContext.Current.Session[SessionName] = data;
            //}
        }
        /// <summary>
        /// 获取Session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SessionName"></param>
        /// <returns></returns>
        internal static T GetSession<T>(string SessionName) where T : Response
        {
            CheckSessionState(SessionName);
            return (T)HttpContext.Current.Session[SessionName];
        }
    }
}
