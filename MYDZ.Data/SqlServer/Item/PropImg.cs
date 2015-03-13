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
    public class PropImg : IPropImg
    {
        public bool AddPropImg(Entity.Goods.PropImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PropImg(");
            strSql.Append("PropImgID,ID,Position,Properties,Url");
            strSql.Append(") values (");
            strSql.Append("@PropImgID,@ID,@Position,@Properties,@Url");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@PropImgID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Position", SqlDbType.Int,4) ,            
                        new SqlParameter("@Properties", SqlDbType.VarChar,1000) ,            
                        new SqlParameter("@Url", SqlDbType.VarChar,200)             
              
            };

            parameters[0].Value = model.PropImgId;
            parameters[1].Value = model.Id;
            parameters[2].Value = model.Position;
            parameters[3].Value = model.Properties;
            parameters[4].Value = model.Url;
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

        public bool UpdatePropImg(Entity.Goods.PropImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PropImg set ");

            strSql.Append(" PropImgID = @PropImgID , ");
            strSql.Append(" ID = @ID , ");
            strSql.Append(" Position = @Position , ");
            strSql.Append(" Properties = @Properties , ");
            strSql.Append(" Url = @Url  ");
            strSql.Append(" where PropImgID=@PropImgID");

            SqlParameter[] parameters = {
			            new SqlParameter("@PropImgID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Position", SqlDbType.Int,4) ,            
                        new SqlParameter("@Properties", SqlDbType.VarChar,1000) ,            
                        new SqlParameter("@Url", SqlDbType.VarChar,200)             
              
            };

            parameters[5].Value = model.PropImgId;
            parameters[6].Value = model.Id;
            parameters[7].Value = model.Position;
            parameters[8].Value = model.Properties;
            parameters[9].Value = model.Url;
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

        public bool DeletePropImg(string PropImgId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PropImg ");
            strSql.Append(" where PropImgID=@PropImgID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PropImgID", SqlDbType.Int,4)
                         };
            parameters[0].Value = PropImgId;
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

        public IList<Entity.Goods.PropImg> GetPropImg(string PropImgId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PropImgID, ID, Position, Properties, Url  ");
            strSql.Append("  from PropImg ");
            strSql.Append(" where PropImgID=@PropImgID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PropImgID", SqlDbType.Int,4)
                  };
            parameters[0].Value = PropImgId;
            return DBHelper.ExecuteIList<Entity.Goods.PropImg>(CommandType.Text, strSql.ToString(), parameters);  
        }
    }
}
