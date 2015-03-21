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
            strSql.Append("SELECT  Convert ( VARCHAR(10),  OrdersDate,  120)  AS  Paydate, /*日期*/");
            strSql.Append(" SUM(OrdersAccounts) AS PaymentCountPrice,/*订单金额*/");
            strSql.Append(" SUM(OrdersPaid) AS TransactionCountPrice,/*支付金额*/ ");
            strSql.Append(" COUNT(PayDate) AS TransactionCount,/*支付笔数*/");
            strSql.Append(" COUNT(OrdersId)  AS  PaymentCount /*订单数*/");
            strSql.Append(" FROM (SELECT OrdersDate,OrdersAccounts,OrdersPaid, PayDate,OrdersId FROM tbOrdersInfo WHERE ShopId=@ShopId AND OrdersDate BETWEEN @StartTime AND @EndtTime) AS tbOrdersInfo ");
            strSql.Append("GROUP BY Convert ( VARCHAR(10),  OrdersDate,  120) order by Paydate ");
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
                        Paydate = Convert.ToDateTime(MyReader.GetString(0)),
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
        public IList<tbOrdersDetail> ProductAnalysis(int shopId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select top 5 ProductId,ProductImg,ProductPrice, count(ProductId) as sums from  ");
            strSql.Append("(select ProductId,ProductImg,ProductPrice from tbOrdersDetail a, tbOrdersInfo b ");
            strSql.Append("where a.OrdersNumber=b.OrdersOutNumber and b.ShopId=@ShopId )as c");
            strSql.Append("group by ProductId  order by  sums desc");
            SqlParameter[] parameters = {
			            new SqlParameter("@ShopId", SqlDbType.Int,4)    
                        };
            parameters[0].Value = shopId;
            IList<tbOrdersDetail> listdetail = new List<tbOrdersDetail>();
            listdetail = DBHelper.ExecuteIList<tbOrdersDetail>(CommandType.Text, strSql.ToString(), parameters);
            return listdetail;
        }

        /// <summary>
        /// 订单支付人数
        /// </summary>
        /// <param name="shopId"></param>
        public void payForOrder(int shopId)
        {
            throw new NotImplementedException();
        }
    }
}
