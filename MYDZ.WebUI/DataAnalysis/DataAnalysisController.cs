using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Common;
using System.Web.Mvc;
using MYDZ.Entity;
using MYDZ.Business.DataBase_BLL.DataAnalysis;
using MYDZ.Entity.ClientUser;
using MYDZ.Entity.DataAnalysis;

namespace MYDZ.WebUI.DataAnalysis
{
    public class DataAnalysisController : BaseController
    {
        BAnalysisOrderData bao = new BAnalysisOrderData();

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ViewResult Index(string selectType = "", string SelectDay = "")
        {
            // 日期（X轴）、内容（Y轴）、提示内容、曲线名、数据点
            /*取数据算法(选择日期的前后共七天)，
             * 当前日期减去选中日期，
             * 向后取： DateTime.Parse(SelectDay).AddDays(DateTime.Now.data-SelectDay ),
             * 向前取： DateTime.Parse(SelectDay).AddDays(DateTime.Now.data-SelectDay - 7)*/

            ListShopData lsd = new ListShopData();   
            tbClientUser clientuser = GetUser("UserInfo");

            if (string.IsNullOrEmpty(selectType))
            {
                selectType = "OrderPrice";
            }
            if (string.IsNullOrEmpty(SelectDay))
            {
                SelectDay = DateTime.Now.Date.ToString();
            }

            DateTime selecttime = new DateTime();
            if (DateTime.TryParse(SelectDay, out selecttime))
            {
                if (selecttime.CompareTo(DateTime.Now.Date) <= 0)
                {
                    DateTime starttime = new DateTime();
                    DateTime endtime = new DateTime();

                    //算间隔时间
                    int jgtime = DateTime.Now.Date.Subtract(selecttime).Days;

                    if (jgtime <= 7)
                    {
                        endtime = selecttime.AddDays(jgtime);
                        starttime = selecttime.AddDays(jgtime - 7);
                    }
                    else
                    {
                        endtime = selecttime.AddDays(3);
                        starttime = selecttime.AddDays(-3);
                    }

                    /*测试数据*/
                    endtime = DateTime.Now.Date.AddDays(-2);
                    starttime = DateTime.Now.Date.AddDays(-10);

                    //取数据库中的店铺数据根据起始日期
                    lsd = GetDbShopData(clientuser.UserShops[0].Shop.ShopId, starttime, endtime);

                    // 在对lsd 赋值后实例化下面的容器
                    lsd.LinsNames = new List<string>();
                    lsd.List_Y_Key = new List<string>();
                    lsd.List_Y_Value = new List<float>();

                    lsd.Table_Title = "店铺日报";
                    
                    switch (selectType)
                    {
                        case "OrderPrice":
                            {
                                lsd.LinsNames.Add("订单金额");
                                lsd.SelectTime = selecttime;
                                lsd.List_Y_Key.Add("金额");
                                lsd.TipsContent = "￥(元)";
                                lsd.List_Y_Value = Array.ConvertAll<Shopdata, float>(lsd.List_X_Value.ToArray(), (evt) => { return evt.OrderPrice; }).ToList<float>();
                            }
                            break;
                        case "TransactionPrice":
                            {
                                lsd.LinsNames.Add("成交金额");
                                lsd.SelectTime = selecttime;
                                lsd.List_Y_Key.Add("金额");
                                lsd.TipsContent = "￥(元)";
                                lsd.List_Y_Value = Array.ConvertAll<Shopdata, float>(lsd.List_X_Value.ToArray(), (evt) => { return evt.TransactionCountPrice; }).ToList<float>();
                            }
                            break;
                        case "TransactionCount":
                            {
                                lsd.LinsNames.Add("成交笔数");
                                lsd.SelectTime = selecttime;
                                lsd.List_Y_Key.Add("单");
                                lsd.TipsContent = "(单)";
                                lsd.List_Y_Value = Array.ConvertAll<Shopdata, float>(lsd.List_X_Value.ToArray(), (evt) => { return evt.TransactionCount; }).ToList<float>();
                            }
                            break;
                        case "OrderCount":
                            {
                                lsd.LinsNames.Add("订单单数");
                                lsd.SelectTime = selecttime;
                                lsd.List_Y_Key.Add("单");
                                lsd.TipsContent = "(单)";
                                lsd.List_Y_Value = Array.ConvertAll<Shopdata, float>(lsd.List_X_Value.ToArray(), (evt) => { return evt.OrderCount; }).ToList<float>();
                            }
                            break;
                        default:
                            {
                                lsd.LinsNames.Add("订单金额");
                                lsd.SelectTime = selecttime;
                                lsd.List_Y_Key.Add("金额");
                                lsd.TipsContent = "￥(元)";
                                lsd.List_Y_Value = Array.ConvertAll<Shopdata, float>(lsd.List_X_Value.ToArray(), (evt) => { return evt.OrderPrice; }).ToList<float>();
                            }
                            break;
                    }
                   
                    //声明匿名类
                    var chartdata = new
                    {
                        title = new { text = lsd.Table_Title, x = -20 },
                        xAxis = new { categories = lsd.List_X_Key },
                        yAxis = new { title = new { text = lsd.List_Y_Key[0] }, plotLines = new[] { new { value = 0, width = 1, color = "#808080" } }.ToArray() },
                        tooltip = new { valueSuffix = lsd.TipsContent },
                        legend = new { layout = "horizontal", verticalAlign = "bottom", borderWidth = 0 },
                        series = (new[] { 1 }).Select(x => new { name = lsd.LinsNames[0], data = lsd.List_Y_Value }).ToList()
                    };

                    //将数据带过去
                    ViewData["chartdate"] = chartdata;
                }
                else
                {

                }
            }

            return View(lsd);
        }
        private ListShopData GetDbShopData(int ShopId, DateTime starttime, DateTime endtime)
        {
            IList<Shopdata> listadily = new List<Shopdata>();
            ListShopData lsd = new ListShopData();
            lsd.List_X_Key = new List<string>();
            lsd.List_X_Value = new List<Shopdata>();

            try
            {
                listadily = bao.DailyHighlights(ShopId, starttime, endtime);

                for (int i = 0; i < 7; i++)
                {
                    Shopdata shopd = listadily.FirstOrDefault((e) => { return e.Paydate == starttime.AddDays(i); });
                    if (shopd == null)
                    {
                        shopd = new Shopdata();
                        shopd.Paydate = starttime.AddDays(i);
                        shopd.OrderCount = 0;
                        shopd.OrderPrice = 0;
                        shopd.TransactionCount = 0;
                        shopd.TransactionCountPrice = 0;
                    }
                    lsd.List_X_Key.Add(starttime.AddDays(i).Day.ToString());
                    lsd.List_X_Value.Add(shopd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lsd;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public JsonResult OnloadDatainfo(string selectType, string SelectDay = null)
        {
            IList<string> bb = new List<string>() { "aa", "bb", "cc" };

            for (var i = 0; i < 7; i++)
            {
                string aa = bb.FirstOrDefault((e) => { return e == "aa"; });


            }
            return Json("");
        }

    }
}
