using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Common;
using System.Web.Mvc;
using MYDZ.Entity.ClientUser;

namespace MYDZ.WebUI.UserControl
{
    public class UserControlController : BaseController
    {
        public ViewResult Feedback() {
            return View();
        }

        /// <summary>
        /// 保存用户反馈信息
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Feedback(tbFeedback feedback) {
            bool isok = false;
            return Json(new { Status = isok, Msg = isok ? "感谢您给我们的宝贵意见" : "提交失败，请刷新后重试" });
        }
    }
}
