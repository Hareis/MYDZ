using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Shop;
using System.Data.SqlClient;
using MYDZ.DBUtility;
using MYDZ.Entity.Shop;
using System.Data;

namespace MYDZ.Data.SqlServer.Shop
{
    internal class ShopScore : IShopScore
    {
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertShopScore(tbShopScore model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbShopScore(");
            strSql.Append("ItemScore,ServiceScore,DeliveryScore)");
            strSql.Append(" values (");
            strSql.Append("@ItemScore,@ServiceScore,@DeliveryScore)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemScore", SqlDbType.VarChar,50),
					new SqlParameter("@ServiceScore", SqlDbType.VarChar,50),
					new SqlParameter("@DeliveryScore", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ItemScore;
            parameters[1].Value = model.ServiceScore;
            parameters[2].Value = model.DeliveryScore;

            object obj = DBHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateShopScore(tbShopScore model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbShopScore set ");
            strSql.Append("ItemScore=@ItemScore,");
            strSql.Append("ServiceScore=@ServiceScore,");
            strSql.Append("DeliveryScore=@DeliveryScore");
            strSql.Append(" where ScoreId=@ScoreId");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemScore", SqlDbType.VarChar,50),
					new SqlParameter("@ServiceScore", SqlDbType.VarChar,50),
					new SqlParameter("@DeliveryScore", SqlDbType.VarChar,50),
					new SqlParameter("@ScoreId", SqlDbType.Int,4)};
            parameters[0].Value = model.ItemScore;
            parameters[1].Value = model.ServiceScore;
            parameters[2].Value = model.DeliveryScore;
            parameters[3].Value = model.ScoreId;

            return DBHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0 ? true : false;

        }
        /// <summary>
        /// 查询一条数据
        /// </summary>
        /// <param name="ScoreId"></param>
        /// <returns></returns>
        public tbShopScore SelecttbShopScoreByShopId(string ScoreId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ScoreId,ItemScore,ServiceScore,DeliveryScore from tbShopScore ");
            strSql.Append(" where ScoreId=@ScoreId");
            SqlParameter[] parameters = {
					new SqlParameter("@ScoreId", SqlDbType.Int,4)
			};
            parameters[0].Value = ScoreId;

            tbShopScore model = new tbShopScore();
            DataSet ds = DBHelper.ExecuteDataSet(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ScoreId"].ToString() != "")
                {
                    model.ScoreId = int.Parse(ds.Tables[0].Rows[0]["ScoreId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ItemScore"] != null)
                {
                    model.ItemScore = ds.Tables[0].Rows[0]["ItemScore"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ServiceScore"] != null)
                {
                    model.ServiceScore = ds.Tables[0].Rows[0]["ServiceScore"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DeliveryScore"] != null)
                {
                    model.DeliveryScore = ds.Tables[0].Rows[0]["DeliveryScore"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
