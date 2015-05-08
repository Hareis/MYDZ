﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Common;
using System.Web.Mvc;
using MYDZ.Entity;
using MYDZ.Business.DataBase_BLL.DataAnalysis;
using MYDZ.Entity.ClientUser;
using MYDZ.Entity.DataAnalysis;
using MYDZ.Entity.Order;
using System.Collections;

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

            ListShopData listdatafor7 = new ListShopData();
            ListShopData listdatafor1 = new ListShopData();
            IList<tbOrdersDetail> listdetail = new List<tbOrdersDetail>();
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
                    starttime = DateTime.Now.Date.AddDays(-15);

                    IList<Shopdata> listadily7 = new List<Shopdata>();
                    listadily7 = bao.DailyHighlights(clientuser.UserShops[0].Shop.ShopId, starttime, endtime);
                    //取数据库中的店铺七天的订单数据数据根据起始日期
                    listdatafor7 = GetDbShopDataFor(starttime, listadily7);

                    //取数据库的商品销售的Top 5
                    listdetail = bao.ProductAnalysis(clientuser.UserShops[0].Shop.ShopId, starttime, endtime);

                    IList<Shopdata> listadily1 = new List<Shopdata>();
                    //一天内的销售数据（按小时）   
                    listadily1 = bao.payForOrder(clientuser.UserShops[0].Shop.ShopId, starttime, endtime);
                    //取数据库中的店铺七天的订单数据数据根据起始日期
                    listdatafor1 = GetDbShopDataFor24(listadily1);

                    Hashtable ht = new Hashtable();
                    //地区访问人数
                    ht = bao.GetShopAreaData(clientuser.UserShops[0].Shop.ShopId, starttime, endtime);

                    #region   店铺日报

                    // 在对lsd 赋值后实例化下面的容器
                    listdatafor7.LinsNames = new List<string>();
                    listdatafor7.List_Y_Key = new List<string>();
                    listdatafor7.List_Y_Value = new List<float>();
                    listdatafor7.Table_Title = "店铺日报";

                    switch (selectType)
                    {
                        case "OrderPrice":
                            {
                                listdatafor7.LinsNames.Add("订单金额");
                                listdatafor7.SelectTime = selecttime;
                                listdatafor7.List_Y_Key.Add("金额");
                                listdatafor7.TipsContent = "￥(元)";
                                listdatafor7.List_Y_Value = Array.ConvertAll<Shopdata, float>(listdatafor7.List_X_Value.ToArray(), (evt) => { return evt.OrderPrice; }).ToList<float>();
                            }
                            break;
                        case "TransactionPrice":
                            {
                                listdatafor7.LinsNames.Add("成交金额");
                                listdatafor7.SelectTime = selecttime;
                                listdatafor7.List_Y_Key.Add("金额");
                                listdatafor7.TipsContent = "￥(元)";
                                listdatafor7.List_Y_Value = Array.ConvertAll<Shopdata, float>(listdatafor7.List_X_Value.ToArray(), (evt) => { return evt.TransactionCountPrice; }).ToList<float>();
                            }
                            break;
                        case "TransactionCount":
                            {
                                listdatafor7.LinsNames.Add("成交笔数");
                                listdatafor7.SelectTime = selecttime;
                                listdatafor7.List_Y_Key.Add("单");
                                listdatafor7.TipsContent = "(单)";
                                listdatafor7.List_Y_Value = Array.ConvertAll<Shopdata, float>(listdatafor7.List_X_Value.ToArray(), (evt) => { return evt.TransactionCount; }).ToList<float>();
                            }
                            break;
                        case "OrderCount":
                            {
                                listdatafor7.LinsNames.Add("订单单数");
                                listdatafor7.SelectTime = selecttime;
                                listdatafor7.List_Y_Key.Add("单");
                                listdatafor7.TipsContent = "(单)";
                                listdatafor7.List_Y_Value = Array.ConvertAll<Shopdata, float>(listdatafor7.List_X_Value.ToArray(), (evt) => { return evt.OrderCount; }).ToList<float>();
                            }
                            break;
                        default:
                            {
                                listdatafor7.LinsNames.Add("订单金额");
                                listdatafor7.SelectTime = selecttime;
                                listdatafor7.List_Y_Key.Add("金额");
                                listdatafor7.TipsContent = "￥(元)";
                                listdatafor7.List_Y_Value = Array.ConvertAll<Shopdata, float>(listdatafor7.List_X_Value.ToArray(), (evt) => { return evt.OrderPrice; }).ToList<float>();
                            }
                            break;
                    }

                    
                    #endregion
                    
                    //声明匿名类(曲线)【七天数据】
                    var chartdata = new
                    {
                        title = new { text = listdatafor7.Table_Title, x = -20 },
                        xAxis = new { categories = listdatafor7.List_X_Key },
                        yAxis = new { title = new { text = listdatafor7.List_Y_Key[0] }, plotLines = new[] { new { value = 0, width = 1, color = "#808080" } }.ToArray() },
                        tooltip = new { valueSuffix = listdatafor7.TipsContent },
                        legend = new { layout = "horizontal", verticalAlign = "bottom", borderWidth = 0 },
                        series = (new[] { 1 }).Select(x => new { name = listdatafor7.LinsNames[0], data = listdatafor7.List_Y_Value }).ToList()
                    };

                    //声明匿名类(曲线)【24时数据】
                    var chartdata24 = new
                    {
                        title = new { text = "访问人数", x = -20 },
                        xAxis = new { categories = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" } },
                        yAxis = new { title = new { text = "购买人数" }, plotLines = new[] { new { value = 0, width = 1, color = "#808080" } }.ToArray() },
                        tooltip = new { valueSuffix = "人" },
                        legend = new { layout = "horizontal", verticalAlign = "bottom", borderWidth = 0 },
                        series = (new[] { 1 }).Select(x => new { name = "购买人数", data = Array.ConvertAll<Shopdata, float>(listdatafor1.List_X_Value.ToArray(), (evt) => { return evt.TransactionCount; }).ToList<float>() }).ToList()
                    };

                    //访问人数 饼状图
                    var basepiedata = new ArrayList();
                    foreach (DictionaryEntry item in ht)
                    {
                        basepiedata.Add(new { name = item.Key, y = item.Value, sliced = false, selected = false });
                    }
                    var piedata = new
                    {
                        chart = new { plotShadow = false  },
                        title = new  { text = "全国访问分布图" },
                        tooltip = new { pointFormat = "{series.name}: <b>{point.percentage:.1f}%</b>" },
                        plotOptions = new {  pie = new { allowPointSelect = true, cursor = "百分比", dataLabels = new  { enabled = false }, showInLegend = true } },
                        series = (new[] { 1 }).Select(x => new { type = "pie", name = "所占比例",  data = basepiedata  }).ToList()
                    };

                    //将数据带过去
                    ViewData["chart_line_date"] = chartdata;
                    ViewData["listdetailtop"] = listdetail;
                    ViewData["chart_line_datefor24"] = chartdata24;
                    ViewData["piedata"] = piedata;
                }
                else
                {

                }
            }

            return View();
        }

        /// <summary>
        /// 取店铺的数据(七天)
        /// </summary>
        /// <param name="ShopId"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        private ListShopData GetDbShopDataFor(DateTime starttime, IList<Shopdata> listadily)
        {

            ListShopData lsd = new ListShopData();
            lsd.List_X_Key = new List<string>();
            lsd.List_X_Value = new List<Shopdata>();

            try
            {
                for (int i = 0; i < 7; i++)
                {
                    Shopdata shopd = listadily.FirstOrDefault((e) => { return e.Paydate == starttime.AddDays(i).ToString(); });
                    if (shopd == null)
                    {
                        shopd = new Shopdata();
                        shopd.Paydate = starttime.AddDays(i).ToString();
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
        /// 取店铺的数据(24小时)
        /// </summary>
        /// <param name="ShopId"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        private ListShopData GetDbShopDataFor24(IList<Shopdata> listadily)
        {

            ListShopData lsd = new ListShopData();
            lsd.List_X_Key = new List<string>();
            lsd.List_X_Value = new List<Shopdata>();
            List<string> listhour = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" };
            try
            {
                for (int i = 0; i < 24; i++)
                {
                    Shopdata shopd = listadily.FirstOrDefault((e) => { return e.Paydate == listhour[i]; });
                    if (shopd == null)
                    {
                        shopd = new Shopdata();
                        shopd.Paydate = listhour[i];
                        shopd.OrderCount = 0;
                        shopd.OrderPrice = 0;
                        shopd.TransactionCount = 0;
                        shopd.TransactionCountPrice = 0;
                    }
                    lsd.List_X_Key.AddRange(listhour);
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
            /*IList<string> bb = new List<string>() { "aa", "bb", "cc" };

            for (var i = 0; i < 7; i++)
            {
                string aa = bb.FirstOrDefault((e) => { return e == "aa"; });


            }*/
            return Json("");
        }

    }
}
