using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.TradeRate;
using MYDZ.Entity.Traderate;
using System.Data.SqlClient;
using System.Data;
using MYDZ.DBUtility;

namespace MYDZ.Data.SqlServer.TradeRate
{
    public class RateSet : ITradeRate
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shopid"></param>
        public bool ExitRateByShopId(int shopid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TradeRate");
            strSql.Append(" where ");
            strSql.Append(" shopid = @shopid  ");
            SqlParameter[] parameters = {
					new SqlParameter("@shopid", SqlDbType.Int,4)
			};
            parameters[0].Value = shopid;
            object obj = DBHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj != null)
            {
                if (int.Parse(obj.ToString()) > 0) return true; else return false;
            }
            else return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tTradeRate"></param>
        /// <returns></returns>
        public bool AddRate(Tb_TradeRate tTradeRate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TradeRate(");
            strSql.Append("ShopId,Result,Role,Content,SortID");
            strSql.Append(") values (");
            strSql.Append("@ShopId,@Result,@Role,@Content,@SortID");
            strSql.Append(") ");
            SqlParameter[] parameters = {
			            new SqlParameter("@ShopId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Result", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Role", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Content", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@SortID", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = tTradeRate.ShopId;
            parameters[1].Value = tTradeRate.Result;
            parameters[2].Value = tTradeRate.Role;
            parameters[3].Value = tTradeRate.Content;
            parameters[4].Value = tTradeRate.SortID;
            if (DBHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tTradeRate"></param>
        /// <returns></returns>
        public bool UpdateRate(Tb_TradeRate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TradeRate set ");

            strSql.Append(" Result = @Result , ");
            strSql.Append(" Role = @Role , ");
            strSql.Append(" Content = @Content , ");
            strSql.Append(" SortID = @SortID  ");
            strSql.Append(" where Id=@Id ");
            strSql.Append(" and ShopId = @ShopId  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@ShopId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Result", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Role", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Content", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@SortID", SqlDbType.Int,4)             
              
            };

            parameters[5].Value = model.Id;
            parameters[6].Value = model.ShopId;
            parameters[7].Value = model.Result;
            parameters[8].Value = model.Role;
            parameters[9].Value = model.Content;
            parameters[10].Value = model.SortID;
            int rows = DBHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteRate(int SortID, int shopid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TradeRate ");
            strSql.Append(" where SortID=@SortID");
            strSql.Append(" and ShopId = @ShopId  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ShopId", SqlDbType.Int,4) ,
					new SqlParameter("@SortID", SqlDbType.Int,4)
			};
            parameters[1].Value = SortID;
            parameters[0].Value = shopid;

            int rows = DBHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="RateId"></param>
        /// <returns></returns>
        public Tb_TradeRate GetTradeRateByRateId(int sortId, int shopid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, ShopId, Result, Role, Content, SortID  ");
            strSql.Append("  from TradeRate ");
            strSql.Append(" where sortId=@sortId");
            strSql.Append(" and ShopId=@ShopId");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@ShopId", SqlDbType.Int,4)
			};
            parameters[0].Value = sortId;
            parameters[1].Value = shopid;

            Tb_TradeRate model = new Tb_TradeRate();
            DataSet ds = DBHelper.ExecuteDataSet(CommandType.Text, strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShopId"].ToString() != "")
                {
                    model.ShopId = int.Parse(ds.Tables[0].Rows[0]["ShopId"].ToString());
                } model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["SortID"].ToString() != "")
                {
                    model.SortID = int.Parse(ds.Tables[0].Rows[0]["SortID"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public List<Tb_TradeRate> GetTradeRateByShopId(int shopId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, ShopId, Result, Role, Content, SortID  ");
            strSql.Append("  from TradeRate ");
            strSql.Append(" where ShopId=@ShopId");
            SqlParameter[] parameters = {
					new SqlParameter("@ShopId", SqlDbType.Int,4)
			};
            parameters[0].Value = shopId;
            List<Tb_TradeRate> listrate = new List<Tb_TradeRate>();
            IDataReader DataReader = DBHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters);
            while (DataReader.Read())
            {
                Tb_TradeRate rate = new Tb_TradeRate();
                rate.Id = DataReader["Id"] == null ? 0 : Convert.ToInt32(DataReader["Id"]);
                rate.ShopId = DataReader["ShopId"] == null ? 0 : Convert.ToInt32(DataReader["ShopId"]);
                rate.Result = DataReader["Result"] == null ? "good" : Convert.ToString(DataReader["Result"]);
                rate.Role = DataReader["Role"] == null ? "seller" : Convert.ToString(DataReader["Role"]);
                rate.Content = DataReader["Content"] == null ? "" : Convert.ToString(DataReader["Content"]);
                rate.SortID = DataReader["SortID"] == null ? 1 : Convert.ToInt32(DataReader["SortID"]);
                listrate.Add(rate);
            }
            return listrate;
        }



    }
}
