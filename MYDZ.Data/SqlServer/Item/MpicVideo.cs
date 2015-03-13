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
    public class MpicVideo : IMpicVideo
    {
        public bool AddMpicVideo(Entity.Goods.MpicVideo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MpicVideo(");
            strSql.Append("NumIid,VideoDuaration,VideoId,VideoPic,VideoStatus");
            strSql.Append(") values (");
            strSql.Append("@NumIid,@VideoDuaration,@VideoId,@VideoPic,@VideoStatus");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@NumIid", SqlDbType.Int,4) ,            
                        new SqlParameter("@VideoDuaration", SqlDbType.Int,4) ,            
                        new SqlParameter("@VideoId", SqlDbType.Int,4) ,            
                        new SqlParameter("@VideoPic", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@VideoStatus", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.NumIid;
            parameters[1].Value = model.VideoDuaration;
            parameters[2].Value = model.VideoId;
            parameters[3].Value = model.VideoPic;
            parameters[4].Value = model.VideoStatus;

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

        public bool UpdateMpicVideo(Entity.Goods.MpicVideo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MpicVideo set ");

            strSql.Append(" NumIid = @NumIid , ");
            strSql.Append(" VideoDuaration = @VideoDuaration , ");
            strSql.Append(" VideoId = @VideoId , ");
            strSql.Append(" VideoPic = @VideoPic , ");
            strSql.Append(" VideoStatus = @VideoStatus  ");
            strSql.Append(" where MpicVideoID=@MpicVideoID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@MpicVideoID", SqlDbType.Int,4) ,            
                        new SqlParameter("@NumIid", SqlDbType.Int,4) ,            
                        new SqlParameter("@VideoDuaration", SqlDbType.Int,4) ,            
                        new SqlParameter("@VideoId", SqlDbType.Int,4) ,            
                        new SqlParameter("@VideoPic", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@VideoStatus", SqlDbType.Int,4)             
              
            };

            parameters[5].Value = model.MpicVideoID;
            parameters[6].Value = model.NumIid;
            parameters[7].Value = model.VideoDuaration;
            parameters[8].Value = model.VideoId;
            parameters[9].Value = model.VideoPic;
            parameters[10].Value = model.VideoStatus;
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

        public bool DeleteMpicVideo(string MpicVideoID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MpicVideo ");
            strSql.Append(" where MpicVideoID=@MpicVideoID");
            SqlParameter[] parameters = {
					new SqlParameter("@MpicVideoID", SqlDbType.Int,4)
			};
            parameters[0].Value = MpicVideoID;

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

        public IList<Entity.Goods.MpicVideo> GetMpicVideo(string MpicVideoID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MpicVideoID, NumIid, VideoDuaration, VideoId, VideoPic, VideoStatus  ");
            strSql.Append("  from MpicVideo ");
            strSql.Append(" where MpicVideoID=@MpicVideoID");
            SqlParameter[] parameters = {
					new SqlParameter("@MpicVideoID", SqlDbType.Int,4)
			};
            parameters[0].Value = MpicVideoID;


            return DBHelper.ExecuteIList<Entity.Goods.MpicVideo>(CommandType.Text, strSql.ToString(), parameters);   
            
        }
    }
}
