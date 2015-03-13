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
    internal class DeliveryTime : IDeliveryTime
    {
        public int AddDeliveryTime(Entity.Goods.DeliveryTime model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DeliveryTime(");
            strSql.Append("deliverytime,DeliveryTimeType,NeedDeliveryTime");
            strSql.Append(") values (");
            strSql.Append("@deliverytime,@DeliveryTimeType,@NeedDeliveryTime");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@deliverytime", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@DeliveryTimeType", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@NeedDeliveryTime", SqlDbType.VarChar,100)             
              
            };
            parameters[0].Value = model.DeliveryTime_;
            parameters[1].Value = model.DeliveryTimeType;
            parameters[2].Value = model.NeedDeliveryTime;
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

        public bool UpdateDeliveryTime(Entity.Goods.DeliveryTime model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DeliveryTime set ");

            strSql.Append(" deliverytime = @deliverytime , ");
            strSql.Append(" DeliveryTimeType = @DeliveryTimeType , ");
            strSql.Append(" NeedDeliveryTime = @NeedDeliveryTime  ");
            strSql.Append(" where DeliveryTimeID=@DeliveryTimeID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@DeliveryTimeID", SqlDbType.Int,4) ,            
                        new SqlParameter("@deliverytime", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@DeliveryTimeType", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@NeedDeliveryTime", SqlDbType.VarChar,100)             
              
            };

            parameters[0].Value = model.DeliveryTimeId;
            parameters[1].Value = model.DeliveryTime_;
            parameters[2].Value = model.DeliveryTimeType;
            parameters[3].Value = model.NeedDeliveryTime;
            int rows = DBHelper.ExecuteNonQuery(CommandType.Text,strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteDeliveryTime(string DeliveryTimeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DeliveryTime ");
            strSql.Append(" where DeliveryTimeID=@DeliveryTimeID");
            SqlParameter[] parameters = {
					new SqlParameter("@DeliveryTimeID", SqlDbType.Int,4)
			};
            parameters[0].Value = DeliveryTimeID;
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

        public IList<Entity.Goods.DeliveryTime> GetDeliveryTime(string DeliveryTimeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DeliveryTimeID, deliverytime, DeliveryTimeType, NeedDeliveryTime  ");
            strSql.Append("  from DeliveryTime ");
            strSql.Append(" where DeliveryTimeID=@DeliveryTimeID");
            SqlParameter[] parameters = {
					new SqlParameter("@DeliveryTimeID", SqlDbType.Int,4)
			};
            parameters[0].Value = DeliveryTimeID;

           return DBHelper.ExecuteIList<Entity.Goods.DeliveryTime>(CommandType.Text,strSql.ToString(), parameters);

        }
    }
}
