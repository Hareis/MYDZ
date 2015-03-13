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
    internal class DescModuleInfo : IDescModuleInfo
    {
        public int AddDescModuleInfo(Entity.Goods.DescModuleInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DescModuleInfo(");
            strSql.Append("AnchorModuleIds,Type");
            strSql.Append(") values (");
            strSql.Append("@AnchorModuleIds,@Type");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@AnchorModuleIds", SqlDbType.VarChar,1000) ,            
                        new SqlParameter("@Type", SqlDbType.VarChar,50)             
              
            };
            parameters[0].Value = model.AnchorModuleIds;
            parameters[1].Value = model.Type;
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

        public bool UpdateDescModuleInfo(Entity.Goods.DescModuleInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DescModuleInfo set ");
            strSql.Append(" AnchorModuleIds = @AnchorModuleIds , ");
            strSql.Append(" Type = @Type  ");
            strSql.Append(" where DescModuleInfoID=@DescModuleInfoID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@DescModuleInfoID", SqlDbType.Int,4) ,            
                        new SqlParameter("@AnchorModuleIds", SqlDbType.VarChar,1000) ,            
                        new SqlParameter("@Type", SqlDbType.VarChar,50)             
              
            };
            parameters[2].Value = model.DescModuleInfoID;
            parameters[3].Value = model.AnchorModuleIds;
            parameters[4].Value = model.Type;
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

        public void DeleteDescModuleInfo(string DescModuleInfoID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DescModuleInfo ");
            strSql.Append(" where DescModuleInfoID=@DescModuleInfoID");
            SqlParameter[] parameters = {
					new SqlParameter("@DescModuleInfoID", SqlDbType.Int,4)
			};
            parameters[0].Value = DescModuleInfoID;
            int rows = DBHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        public IList<Entity.Goods.DescModuleInfo> GetDescModuleInfo(string DescModuleInfoID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DescModuleInfoID, AnchorModuleIds, Type  ");
            strSql.Append("  from DescModuleInfo ");
            strSql.Append(" where DescModuleInfoID=@DescModuleInfoID");
            SqlParameter[] parameters = {
					new SqlParameter("@DescModuleInfoID", SqlDbType.Int,4)
			};
            parameters[0].Value = DescModuleInfoID;
           return DBHelper.ExecuteIList < Entity.Goods.DescModuleInfo>(CommandType.Text,strSql.ToString(), parameters);
        }
    }
}
