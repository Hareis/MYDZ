using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.ClientUser;
using MYDZ.Entity.ClientUser;
using System.Data.SqlClient;
using System.Data;
using MYDZ.DBUtility;

namespace MYDZ.Data.SqlServer.ClientUser
{
    internal class ClientUserCredit : IClientUserCredit
    {
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="UserCredit"></param>
        /// <returns></returns>
        public int InsertUserCredit(tbClientUserCredit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbClientUserCredit(");
            strSql.Append("[Level],Score,TotalNum,GoodNum)");
            strSql.Append("values (");
            strSql.Append("@Level,@Score,@TotalNum,@GoodNum)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Level", SqlDbType.Int,4),
					new SqlParameter("@Score", SqlDbType.Int,4),
					new SqlParameter("@TotalNum", SqlDbType.Int,4),
					new SqlParameter("@GoodNum", SqlDbType.Int,4)};
            parameters[0].Value = model.Level;
            parameters[1].Value = model.Score;
            parameters[2].Value = model.TotalNum;
            parameters[3].Value = model.GoodNum;

            Object obj= DBHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            return  int.Parse(obj.ToString());
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="UserCredit"></param>
        /// <returns></returns>
        public bool UpdateUserCredit(tbClientUserCredit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbClientUserCredit set ");
            strSql.Append("[Level]=@Level,");
            strSql.Append("Score=@Score,");
            strSql.Append("TotalNum=@TotalNum,");
            strSql.Append("GoodNum=@GoodNum");
            strSql.Append(" where CreditId=@CreditId ");
            SqlParameter[] parameters = {
					new SqlParameter("@Level", SqlDbType.Int,4),
					new SqlParameter("@Score", SqlDbType.Int,4),
					new SqlParameter("@TotalNum", SqlDbType.Int,4),
					new SqlParameter("@GoodNum", SqlDbType.Int,4),
					new SqlParameter("@CreditId", SqlDbType.Int,4)};
            parameters[0].Value = model.Level;
            parameters[1].Value = model.Score;
            parameters[2].Value = model.TotalNum;
            parameters[3].Value = model.GoodNum;
            parameters[4].Value = model.CreditId;

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
        /// 查询一条数据
        /// </summary>
        /// <param name="CreditId"></param>
        /// <returns></returns>
        public tbClientUserCredit SelectUserCreditByCreditId(string CreditId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CreditId,Level,Score,TotalNum,GoodNum from tbClientUserCredit ");
            strSql.Append(" where CreditId=@CreditId ");
            SqlParameter[] parameters = {
					new SqlParameter("@CreditId", SqlDbType.Int,4)			};
            parameters[0].Value = CreditId;

            tbClientUserCredit model = new tbClientUserCredit();
            DataSet ds = DBHelper.ExecuteDataSet(CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CreditId"].ToString() != "")
                {
                    model.CreditId = int.Parse(ds.Tables[0].Rows[0]["CreditId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Level"].ToString() != "")
                {
                    model.Level = int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Score"].ToString() != "")
                {
                    model.Score = int.Parse(ds.Tables[0].Rows[0]["Score"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalNum"].ToString() != "")
                {
                    model.TotalNum = int.Parse(ds.Tables[0].Rows[0]["TotalNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GoodNum"].ToString() != "")
                {
                    model.GoodNum = int.Parse(ds.Tables[0].Rows[0]["GoodNum"].ToString());
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
