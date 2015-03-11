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
    public class Video : IVideo
    {
        public bool AddVideo(Entity.Goods.Video model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Video(");
            strSql.Append("Video_ID,Created,Id,Iid,Modified,NumIid,Url,VideoId");
            strSql.Append(") values (");
            strSql.Append("@Video_ID,@Created,@Id,@Iid,@Modified,@NumIid,@Url,@VideoId");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Video_ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Created", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Iid", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Modified", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@NumIid", SqlDbType.Int,4) ,            
                        new SqlParameter("@Url", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@VideoId", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Video_ID;
            parameters[1].Value = model.Created;
            parameters[2].Value = model.Id;
            parameters[3].Value = model.Iid;
            parameters[4].Value = model.Modified;
            parameters[5].Value = model.NumIid;
            parameters[6].Value = model.Url;
            parameters[7].Value = model.VideoId;
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

        public bool UpdateVideo(Entity.Goods.Video model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Video set ");

            strSql.Append(" Video_ID = @Video_ID , ");
            strSql.Append(" Created = @Created , ");
            strSql.Append(" Id = @Id , ");
            strSql.Append(" Iid = @Iid , ");
            strSql.Append(" Modified = @Modified , ");
            strSql.Append(" NumIid = @NumIid , ");
            strSql.Append(" Url = @Url , ");
            strSql.Append(" VideoId = @VideoId  ");
            strSql.Append(" where Video_ID=@Video_ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Video_ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Created", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Iid", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Modified", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@NumIid", SqlDbType.Int,4) ,            
                        new SqlParameter("@Url", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@VideoId", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Video_ID;
            parameters[1].Value = model.Created;
            parameters[2].Value = model.Id;
            parameters[3].Value = model.Iid;
            parameters[4].Value = model.Modified;
            parameters[5].Value = model.NumIid;
            parameters[6].Value = model.Url;
            parameters[7].Value = model.VideoId;
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

        public bool DeleteVideo(string Video_Id)
        {
            StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Video ");
            strSql.Append(" where Video_ID=@Video_ID");
            SqlParameter[] parameters = {
			            new SqlParameter("@Video_ID", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = Video_Id;
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

        public IList<Entity.Goods.Video> GetVideo(string Video_Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Video_ID, Created, Id, Iid, Modified, NumIid, Url, VideoId  ");
            strSql.Append("  from Video ");
            strSql.Append(" where Video_ID=@Video_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Video_ID", SqlDbType.Int,4),
					new SqlParameter("@Created", SqlDbType.VarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@Iid", SqlDbType.VarChar,100),
					new SqlParameter("@Modified", SqlDbType.VarChar,100),
					new SqlParameter("@NumIid", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.VarChar,200),
					new SqlParameter("@VideoId", SqlDbType.Int,4)			};
            parameters[0].Value = Video_Id;
            return DBHelper.ExecuteIList<Entity.Goods.Video>(CommandType.Text, strSql.ToString(), parameters);
        }
    }
}
