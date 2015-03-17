using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Common;
using System.Web.Mvc;
using MYDZ.Entity;

namespace MYDZ.WebUI.DataAnalysis
{
    public class DataAnalysisController : BaseController
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnloadDatainfo()
        { 
        
        }

    }
}
