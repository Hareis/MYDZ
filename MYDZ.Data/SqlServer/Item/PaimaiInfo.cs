using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Item;
using System.Data.SqlClient;
using System.Data;
using MYDZ.DBUtility;

namespace MYDZ.Data.SqlServer.Item
{
    public class PaimaiInfo : IPaimaiInfo
    {
        public bool AddPaimaiInfo(Entity.Goods.PaimaiInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PaimaiInfo(");
            strSql.Append("PaimaiInfoID,Deposit,Interval,Mode,Reserve,ValidHour,ValidMinute");
            strSql.Append(") values (");
            strSql.Append("@PaimaiInfoID,@Deposit,@Interval,@Mode,@Reserve,@ValidHour,@ValidMinute");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@PaimaiInfoID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Deposit", SqlDbType.Int,4) ,            
                        new SqlParameter("@Interval", SqlDbType.Int,4) ,            
                        new SqlParameter("@Mode", SqlDbType.Int,4) ,            
                        new SqlParameter("@Reserve", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@ValidHour", SqlDbType.Int,4) ,            
                        new SqlParameter("@ValidMinute", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.PaimaiInfoId;
            parameters[1].Value = model.Deposit;
            parameters[2].Value = model.Interval;
            parameters[3].Value = model.Mode;
            parameters[4].Value = model.Reserve;
            parameters[5].Value = model.ValidHour;
            parameters[6].Value = model.ValidMinute;
            int Ares = DBHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (Ares > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePaimaiInfo(Entity.Goods.PaimaiInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PaimaiInfo set ");

            strSql.Append(" PaimaiInfoID = @PaimaiInfoID , ");
            strSql.Append(" Deposit = @Deposit , ");
            strSql.Append(" Interval = @Interval , ");
            strSql.Append(" Mode = @Mode , ");
            strSql.Append(" Reserve = @Reserve , ");
            strSql.Append(" ValidHour = @ValidHour , ");
            strSql.Append(" ValidMinute = @ValidMinute  ");
            strSql.Append(" where PaimaiInfoID=@PaimaiInfoID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@PaimaiInfoID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Deposit", SqlDbType.Int,4) ,            
                        new SqlParameter("@Interval", SqlDbType.Int,4) ,            
                        new SqlParameter("@Mode", SqlDbType.Int,4) ,            
                        new SqlParameter("@Reserve", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@ValidHour", SqlDbType.Int,4) ,            
                        new SqlParameter("@ValidMinute", SqlDbType.Int,4)             
              
            };

            parameters[7].Value = model.PaimaiInfoId;
            parameters[8].Value = model.Deposit;
            parameters[9].Value = model.Interval;
            parameters[10].Value = model.Mode;
            parameters[11].Value = model.Reserve;
            parameters[12].Value = model.ValidHour;
            parameters[13].Value = model.ValidMinute;
            int Ares = DBHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (Ares > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeletePaimaiInfo(string PaimaiInfoId)
        {
           StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PaimaiInfo ");
			strSql.Append(" where PaimaiInfoID=@PaimaiInfoID ");
						SqlParameter[] parameters = {
					new SqlParameter("@PaimaiInfoID", SqlDbType.Int,4)
                  };
			parameters[0].Value = PaimaiInfoId;

            int Ares = DBHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            if (Ares > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
			
        }

        public IList<Entity.Goods.PaimaiInfo> GetPaimaiInfo(string PaimaiInfoId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PaimaiInfoID, Deposit, Interval, Mode, Reserve, ValidHour, ValidMinute  ");
            strSql.Append("  from PaimaiInfo ");
            strSql.Append(" where PaimaiInfoID=@PaimaiInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PaimaiInfoID", SqlDbType.Int,4)
                 };
            parameters[0].Value = PaimaiInfoId;
            return DBHelper.ExecuteIList <Entity.Goods.PaimaiInfo>(CommandType.Text, strSql.ToString(), parameters);
        }
    }
}
