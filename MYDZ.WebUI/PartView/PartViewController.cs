using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Common;
using System.Web.Mvc;
using MYDZ.Config.Theme;

namespace MYDZ.WebUI.PartView
{
    public class PartViewController : BaseController
    {
        public ActionResult Header() {
            ThemeConfig Theme = base.GetThemeList();
            ViewBag.ThemeName = base.GetThemeName(Theme);
            ViewBag.Theme = Theme;
            return View();
        }

        /// <summary>
        /// 验证皮肤是否存在
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public JsonResult ValiThemeName(string Name) {
            string ThemeName = "";
            ThemeConfig Theme = base.GetThemeList();

            if (base.CheckThemeName(Name, Theme)) {
                ThemeName = Name;
            } else {
                ThemeName = base.GetDefaultThemeName();
            }

            return Json(new { Name = ThemeName.ToLower().Trim() });
        }

        public ActionResult Footer() {
            return View();
        }

        public ActionResult Tools() {
            return View();
        }

        /// <summary>
        /// 快捷菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult QuickMenu() {
            return View();
        }
    }
}
