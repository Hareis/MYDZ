using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Shop;
using System.Data.SqlClient;
using System.Data;
using MYDZ.Entity.Shop;
using MYDZ.DBUtility;

namespace MYDZ.Data.SqlServer.Shop
{
    internal class ShopInfo : IShopInfo
    {
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertShopInfo(tbShopInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbShopInfo(");
            strSql.Append("TbShopId,ScoreId,CateId,NickName,Title,[Desc],Bulletin,PicPath,Created,Modified)");
            strSql.Append(" values (");
            strSql.Append("@TbShopId,@ScoreId,@CateId,@NickName,@Title,@Desc,@Bulletin,@PicPath,@Created,@Modified)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@TbShopId", SqlDbType.Int,4),
					new SqlParameter("@ScoreId", SqlDbType.Int,4),
					new SqlParameter("@CateId", SqlDbType.Int,4),
					new SqlParameter("@NickName", SqlDbType.VarChar,50),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@Desc", SqlDbType.VarChar,500),
					new SqlParameter("@Bulletin", SqlDbType.VarChar,200),
					new SqlParameter("@PicPath", SqlDbType.VarChar,200),
					new SqlParameter("@Created", SqlDbType.DateTime),
					new SqlParameter("@Modified", SqlDbType.DateTime)};
            parameters[0].Value = model.TbShopId;
            parameters[1].Value = model.Score.ScoreId;
            parameters[2].Value = model.CateId;
            parameters[3].Value = model.NickName;
            parameters[4].Value = model.Title;
            parameters[5].Value = model.Desc;
            parameters[6].Value = model.Bulletin;
            parameters[7].Value = model.PicPath;
            parameters[8].Value = model.Created;
            parameters[9].Value = model.Modified;

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
        public bool UpdateShopInfo(tbShopInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbShopInfo set ");
            strSql.Append("TbShopId=@TbShopId,");
            strSql.Append("ScoreId=@ScoreId,");
            strSql.Append("CateId=@CateId,");
            strSql.Append("NickName=@NickName,");
            strSql.Append("Title=@Title,");
            strSql.Append("[Desc]=@Desc,");
            strSql.Append("Bulletin=@Bulletin,");
            strSql.Append("PicPath=@PicPath,");
            strSql.Append("Created=@Created,");
            strSql.Append("Modified=@Modified");
            strSql.Append(" where ShopId=@ShopId");
            SqlParameter[] parameters = {
					new SqlParameter("@TbShopId", SqlDbType.Int,4),
					new SqlParameter("@ScoreId", SqlDbType.Int,4),
					new SqlParameter("@CateId", SqlDbType.Int,4),
					new SqlParameter("@NickName", SqlDbType.VarChar,50),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@Desc", SqlDbType.VarChar,500),
					new SqlParameter("@Bulletin", SqlDbType.VarChar,200),
					new SqlParameter("@PicPath", SqlDbType.VarChar,200),
					new SqlParameter("@Created", SqlDbType.DateTime),
					new SqlParameter("@Modified", SqlDbType.DateTime),
					new SqlParameter("@ShopId", SqlDbType.Int,4)};
            parameters[0].Value = model.TbShopId;
            parameters[1].Value = model.Score.ScoreId;
            parameters[2].Value = model.CateId;
            parameters[3].Value = model.NickName;
            parameters[4].Value = model.Title;
            parameters[5].Value = model.Desc;
            parameters[6].Value = model.Bulletin;
            parameters[7].Value = model.PicPath;
            parameters[8].Value = model.Created;
            parameters[9].Value = model.Modified;
            parameters[10].Value = model.ShopId;

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
        /// 查询数据（by ShopId）
        /// </summary>
        /// <param name="ShopId"></param>
        /// <returns></returns>
        public tbShopInfo SelecttbShopInfoByShopId(string ShopId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ShopId,TbShopId,ScoreId,CateId,NickName,Title,[Desc],Bulletin,PicPath,Created,Modified from tbShopInfo ");
            strSql.Append(" where ShopId=@ShopId");
            SqlParameter[] parameters = {
					new SqlParameter("@ShopId", SqlDbType.Int,4)
			};
            parameters[0].Value = ShopId;

            tbShopInfo model = new tbShopInfo();
            DataSet ds = DBHelper.ExecuteDataSet(CommandType.Text,strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ShopId"].ToString() != "")
                {
                    model.ShopId = int.Parse(ds.Tables[0].Rows[0]["ShopId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TbShopId"].ToString() != "")
                {
                    model.TbShopId = int.Parse(ds.Tables[0].Rows[0]["TbShopId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ScoreId"].ToString() != "")
                {
                    model.Score = new tbShopScore();
                    model.Score.ScoreId = int.Parse(ds.Tables[0].Rows[0]["ScoreId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CateId"].ToString() != "")
                {
                    model.CateId = int.Parse(ds.Tables[0].Rows[0]["CateId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NickName"] != null)
                {
                    model.NickName = ds.Tables[0].Rows[0]["NickName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Title"] != null)
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Desc"] != null)
                {
                    model.Desc = ds.Tables[0].Rows[0]["Desc"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Bulletin"] != null)
                {
                    model.Bulletin = ds.Tables[0].Rows[0]["Bulletin"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PicPath"] != null)
                {
                    model.PicPath = ds.Tables[0].Rows[0]["PicPath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Created"].ToString() != "")
                {
                    model.Created = DateTime.Parse(ds.Tables[0].Rows[0]["Created"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Modified"].ToString() != "")
                {
                    model.Modified = DateTime.Parse(ds.Tables[0].Rows[0]["Modified"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 查询数据（by TBShopId）
        /// </summary>
        /// <param name="TBShopId"></param>
        /// <returns></returns>
        public List<Entity.Shop.tbShopInfo> SelecttbShopInfoByTBShopId(string TBShopId)
        {
            throw new NotImplementedException();
        }
    }
}
