using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.DataAnalysis;
using System.Data.SqlClient;
using System.Data;
using MYDZ.DBUtility;
using MYDZ.Entity.DataAnalysis;
using MYDZ.Entity.Order;
using System.Collections;

namespace MYDZ.Data.SqlServer.DataAnalysis
{
    public class AnalysisOrderData : IAnalysisOrderData
    {
        /// <summary>
        /// 每日要闻
        /// </summary>
        /// <param name="shopId"></param>
        public IList<Shopdata> DailyHighlights(int shopId, DateTime StartTime, DateTime EndtTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT  Convert ( VARCHAR(10),  OrdersDate,  120)  AS  Paydate, /*日期*/");
            strSql.Append(" SUM(OrdersAccounts) AS PaymentCountPrice,/*订单金额*/");
            strSql.Append(" SUM(OrdersPaid) AS TransactionCountPrice,/*支付金额*/ ");
            strSql.Append(" COUNT(PayDate) AS TransactionCount,/*支付笔数*/");
            strSql.Append(" COUNT(OrdersId)  AS  PaymentCount /*订单数*/");
            strSql.Append(" FROM (SELECT OrdersDate,OrdersAccounts,OrdersPaid, PayDate,OrdersId FROM tbOrdersInfo WHERE ShopId=@ShopId AND OrdersDate BETWEEN @StartTime AND @EndtTime) AS tbOrdersInfo ");
            strSql.Append(" GROUP BY Convert ( VARCHAR(10),  OrdersDate,  120) order by Paydate ");
            SqlParameter[] parameters = {
			            new SqlParameter("@ShopId", SqlDbType.Int,4),
                        new SqlParameter("@StartTime", SqlDbType.DateTime),  
                        new SqlParameter("@EndtTime", SqlDbType.DateTime)   
                        };
            parameters[0].Value = shopId;
            parameters[1].Value = StartTime;
            parameters[2].Value = EndtTime;
            IList<Shopdata> listdaily = new List<Shopdata>();
            Shopdata daily = null;
            using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (MyReader.Read())
                {
                    daily = new Shopdata()
                    {
                        Paydate = MyReader.GetString(0).ToString(),
                        OrderPrice = Convert.ToInt64(MyReader.GetValue(1)),
                        TransactionCountPrice = Convert.ToInt64(MyReader.GetValue(2)),
                        TransactionCount = Convert.ToInt32(MyReader.GetValue(3)),
                        OrderCount = Convert.ToInt32(MyReader.GetValue(4))
                    };
                    listdaily.Add(daily);
                }
            }
            return listdaily;
        }

        /// <summary>
        /// 商品销售量分析
        /// </summary>
        /// <param name="shopId"></param>
        public IList<tbOrdersDetail> ProductAnalysis(int shopId, DateTime StartTime, DateTime EndtTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select top 5 ProductId,ProductImg,ProductPrice, count(ProductId) as sums from  ");
            strSql.Append("( select ProductId,ProductImg,ProductPrice from tbOrdersDetail a, tbOrdersInfo b ");
            strSql.Append(" where b.ShopId=@ShopId and  a.OrdersNumber=b.OrdersOutNumber and b.OrdersDate between @StartTime and @EndtTime )as c");
            strSql.Append(" group by ProductId,ProductImg,ProductPrice  order by  sums desc");
            SqlParameter[] parameters = {
			            new SqlParameter("@ShopId", SqlDbType.Int,4),
                        new SqlParameter("@StartTime", SqlDbType.DateTime),  
                        new SqlParameter("@EndtTime", SqlDbType.DateTime)    
                        };
            parameters[0].Value = shopId;
            parameters[1].Value = StartTime;
            parameters[2].Value = EndtTime;
            IList<tbOrdersDetail> listdetail = new List<tbOrdersDetail>();
            tbOrdersDetail orderdetail = null;
            using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (MyReader.Read())
                {
                    orderdetail = new tbOrdersDetail()
                    {
                        ProductId = Convert.ToInt32(MyReader.GetValue(0)),
                        ProductImg = Convert.ToString(MyReader.GetValue(1)),
                        ProductPrice = Convert.ToDecimal(MyReader.GetValue(2)),
                        Sums = Convert.ToInt64(MyReader.GetValue(3)),
                    };
                    listdetail.Add(orderdetail);
                }
            }
            return listdetail;
        }

        /// <summary>
        /// 订单支付人数（按小时）
        /// </summary>
        /// <param name="shopId"></param>
        public IList<Shopdata> payForOrder(int shopId, DateTime StartTime, DateTime EndtTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT   OrdersDate as PayDate,");
            strSql.Append(" SUM(OrdersAccounts) AS PaymentCountPrice,/*订单金额*/");
            strSql.Append(" SUM(OrdersPaid) as TransactionCountPrice,/*支付金额*/");
            strSql.Append(" COUNT(PayDate) as TransactionCount,/*支付笔数 */");
            strSql.Append(" COUNT(OrdersId)  AS  PaymentCount /*订单数*/");
            strSql.Append(" FROM ( SELECT ");
            strSql.Append(" datepart(hh,OrdersDate) AS  OrdersDate,/*直接转化为小时*/");
            strSql.Append(" OrdersAccounts,OrdersPaid, PayDate,OrdersId ");
            strSql.Append(" FROM tbOrdersInfo ");
            strSql.Append(" WHERE ShopId=@ShopId AND OrdersDate BETWEEN @StartTime AND @EndtTime ");
            strSql.Append(" )AS #tbOrdersInfo");
            strSql.Append(" GROUP BY  OrdersDate");
            SqlParameter[] parameters = {
			            new SqlParameter("@ShopId", SqlDbType.Int,4),
                        new SqlParameter("@StartTime", SqlDbType.DateTime),  
                        new SqlParameter("@EndtTime", SqlDbType.DateTime)    
                        };
            parameters[0].Value = shopId;
            parameters[1].Value = StartTime;
            parameters[2].Value = EndtTime;
            IList<Shopdata> listdaily = new List<Shopdata>();
            Shopdata daily = null;
            using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (MyReader.Read())
                {
                    daily = new Shopdata()
                    {
                        Paydate = Convert.ToString(MyReader.GetValue(0)),
                        OrderPrice = Convert.ToInt64(MyReader.GetValue(1)),
                        TransactionCountPrice = Convert.ToInt64(MyReader.GetValue(2)),
                        TransactionCount = Convert.ToInt32(MyReader.GetValue(3)),
                        OrderCount = Convert.ToInt32(MyReader.GetValue(4))
                    };
                    listdaily.Add(daily);
                }
            }
            return listdaily;
        }

        /// <summary>
        ///  地区购买人数
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndtTime"></param>
        /// <returns></returns>
        public Hashtable GetShopAreaData(int shopId, DateTime StartTime, DateTime EndtTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select Provice, COUNT(OrdersNumber) Viewcount from ( ");
            strSql.Append(" select a.OrdersNumber,b.Provice  ");
            strSql.Append(" from tbOrdersInfo a,tbConsigneeInfo b  ");
            strSql.Append(" where a.ShopId=@ShopId and ");
            strSql.Append(" a.OrdersOutNumber=b.OrdersNumber and");
            strSql.Append(" a.OrdersDate between @StartTime AND @EndtTime ");
            strSql.Append(" ) as c group by  Provice");

            SqlParameter[] parameters = {
			            new SqlParameter("@ShopId", SqlDbType.Int,4),
                        new SqlParameter("@StartTime", SqlDbType.DateTime),  
                        new SqlParameter("@EndtTime", SqlDbType.DateTime)    
                        };
            parameters[0].Value = shopId;
            parameters[1].Value = StartTime;
            parameters[2].Value = EndtTime;

            Hashtable ht = null;
            using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (MyReader.Read())
                {
                    ht = new Hashtable();
                    ht.Add(Convert.ToString(MyReader.GetValue(0)), Convert.ToInt32(MyReader.GetValue(1)));
                }
            }
            return ht;
        }

    }
}
