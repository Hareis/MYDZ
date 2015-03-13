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
    public class ItemImg : IItemImg
    {
        public bool AddItemImg(Entity.Goods.ItemImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ItemImg(");
            strSql.Append("ItemImgID,Created,Id,Position,Url");
            strSql.Append(") values (");
            strSql.Append("@ItemImgID,@Created,@Id,@Position,@Url");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ItemImgID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Created", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Position", SqlDbType.Int,4) ,            
                        new SqlParameter("@Url", SqlDbType.VarChar,200)             
              
            };
            parameters[0].Value = model.ItemImgID;
            parameters[1].Value = model.Created;
            parameters[2].Value = model.Id;
            parameters[3].Value = model.Position;
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

        public bool UpdateItemImg(Entity.Goods.ItemImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ItemImg set ");

            strSql.Append(" Created = @Created , ");
            strSql.Append(" Id = @Id , ");
            strSql.Append(" Position = @Position , ");
            strSql.Append(" Url = @Url  ");
            strSql.Append(" where ItemImgID=@ItemImgID");

            SqlParameter[] parameters = {
			            new SqlParameter("@ItemImgID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Created", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Position", SqlDbType.Int,4) ,            
                        new SqlParameter("@Url", SqlDbType.VarChar,200)             
              
            };

            parameters[1].Value = model.ItemImgID;
            parameters[2].Value = model.Created;
            parameters[3].Value = model.Id;
            parameters[4].Value = model.Position;
            parameters[5].Value = model.Url;
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

        public bool DeleteItemImg(string ItemImgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ItemImg ");
            strSql.Append(" where ItemImgID=@ItemImgID");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemImgID", SqlDbType.Int,4)
              };
            parameters[0].Value = ItemImgID;
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

        public IList<Entity.Goods.ItemImg> GetItemImg(string ItemImgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ItemImgID, Created, Id, Position, Url  ");
            strSql.Append("  from ItemImg ");
            strSql.Append(" where ItemImgID=@ItemImgID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemImgID", SqlDbType.Int,4)
               };
            parameters[0].Value = ItemImgID;
           return DBHelper.ExecuteIList<Entity.Goods.ItemImg>(CommandType.Text, strSql.ToString(), parameters);
        }
    }
}
