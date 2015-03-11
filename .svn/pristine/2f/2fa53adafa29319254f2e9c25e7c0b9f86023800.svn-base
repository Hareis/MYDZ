using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.DBUtility;
using System.Data;
using MYDZ.Interface.ClientUser;
using MYDZ.Entity;
using MYDZ.Entity.ClientUser;
using System.Data.SqlClient;

namespace MYDZ.Data.SqlServer.ClientUser
{
    internal class ClientUser : IClientUser
    {
        /// <summary>
        /// 往tbClientUser 表中插入一条数据
        /// </summary>
        /// <param name="ClientUser"></param>
        /// <returns></returns>
        public int InsertUser(tbClientUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbClientUser(");
            strSql.Append("TbUserId,ParentId,UserNick,GenderId,CreditId,TypeId,HasMorePic,ItemImgNum,ItemImgSize,PropImgNum,PropImgSize,AutoRepost,PromotedType,StatusId,LevelId,AlipayBind,Protection,Avatar,LiangPin,SignFoods,HasShop,IsLightning,HasSubStock,GoldenSeller,Subscribe,VerMarket,OnlineGaming,EmailNum,SMSNum,Currency,Validity,InputDate)");
            strSql.Append(" values (");
            strSql.Append("@TbUserId,@ParentId,@UserNick,@GenderId,@CreditId,@TypeId,@HasMorePic,@ItemImgNum,@ItemImgSize,@PropImgNum,@PropImgSize,@AutoRepost,@PromotedType,@StatusId,@LevelId,@AlipayBind,@Protection,@Avatar,@LiangPin,@SignFoods,@HasShop,@IsLightning,@HasSubStock,@GoldenSeller,@Subscribe,@VerMarket,@OnlineGaming,@EmailNum,@SMSNum,@Currency,@Validity,@InputDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@TbUserId", SqlDbType.Int,4),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@UserNick", SqlDbType.VarChar,50),
					new SqlParameter("@GenderId", SqlDbType.Int,4),
					new SqlParameter("@CreditId", SqlDbType.Int,4),
					new SqlParameter("@TypeId", SqlDbType.Int,4),
					new SqlParameter("@HasMorePic", SqlDbType.Bit,1),
					new SqlParameter("@ItemImgNum", SqlDbType.Int,4),
					new SqlParameter("@ItemImgSize", SqlDbType.Int,4),
					new SqlParameter("@PropImgNum", SqlDbType.Int,4),
					new SqlParameter("@PropImgSize", SqlDbType.Int,4),
					new SqlParameter("@AutoRepost", SqlDbType.Bit,1),
					new SqlParameter("@PromotedType", SqlDbType.Bit,1),
					new SqlParameter("@StatusId", SqlDbType.Int,4),
					new SqlParameter("@LevelId", SqlDbType.Int,4),
					new SqlParameter("@AlipayBind", SqlDbType.Bit,1),
					new SqlParameter("@Protection", SqlDbType.Bit,1),
					new SqlParameter("@Avatar", SqlDbType.VarChar,200),
					new SqlParameter("@LiangPin", SqlDbType.Bit,1),
					new SqlParameter("@SignFoods", SqlDbType.Bit,1),
					new SqlParameter("@HasShop", SqlDbType.Bit,1),
					new SqlParameter("@IsLightning", SqlDbType.Bit,1),
					new SqlParameter("@HasSubStock", SqlDbType.Bit,1),
					new SqlParameter("@GoldenSeller", SqlDbType.Bit,1),
					new SqlParameter("@Subscribe", SqlDbType.Bit,1),
					new SqlParameter("@VerMarket", SqlDbType.VarChar,200),
					new SqlParameter("@OnlineGaming", SqlDbType.Bit,1),
					new SqlParameter("@EmailNum", SqlDbType.Int,4),
					new SqlParameter("@SMSNum", SqlDbType.Int,4),
					new SqlParameter("@Currency", SqlDbType.Decimal,9),
					new SqlParameter("@Validity", SqlDbType.DateTime),
					new SqlParameter("@InputDate", SqlDbType.DateTime)};
            parameters[0].Value = model.TbUserId;
            parameters[1].Value = model.ParentId;
            parameters[2].Value = model.UserNick;
            parameters[3].Value = model.Gender.GenderId;
            parameters[4].Value = model.Credit.CreditId;
            parameters[5].Value = model.Type.TypeId;
            parameters[6].Value = model.HasMorePic;
            parameters[7].Value = model.ItemImgNum;
            parameters[8].Value = model.ItemImgSize;
            parameters[9].Value = model.PropImgNum;
            parameters[10].Value = model.PropImgSize;
            parameters[11].Value = model.AutoRepost;
            parameters[12].Value = model.PromotedType;
            parameters[13].Value = model.Status.StatusId;
            parameters[14].Value = model.Level.LevelId;
            parameters[15].Value = model.AlipayBind;
            parameters[16].Value = model.Protection;
            parameters[17].Value = model.Avatar;
            parameters[18].Value = model.LiangPin;
            parameters[19].Value = model.SignFoods;
            parameters[20].Value = model.HasShop;
            parameters[21].Value = model.IsLightning;
            parameters[22].Value = model.HasSubStock;
            parameters[23].Value = model.GoldenSeller;
            parameters[24].Value = model.Subscribe;
            parameters[25].Value = model.VerMarket;
            parameters[26].Value = model.OnlineGaming;
            parameters[27].Value = model.EmailNum;
            parameters[28].Value = model.SMSNum;
            parameters[29].Value = model.Currency;
            parameters[30].Value = model.Validity;
            parameters[31].Value = model.InputDate;

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
        /// 更新tbClientUser表中的一条数据
        /// </summary>
        /// <param name="ClientUser"></param>
        /// <returns></returns>
        public bool UpdateUser(tbClientUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbClientUser set ");
            strSql.Append("TbUserId=@TbUserId,");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("UserNick=@UserNick,");
            strSql.Append("GenderId=@GenderId,");
            strSql.Append("CreditId=@CreditId,");
            strSql.Append("TypeId=@TypeId,");
            strSql.Append("HasMorePic=@HasMorePic,");
            strSql.Append("ItemImgNum=@ItemImgNum,");
            strSql.Append("ItemImgSize=@ItemImgSize,");
            strSql.Append("PropImgNum=@PropImgNum,");
            strSql.Append("PropImgSize=@PropImgSize,");
            strSql.Append("AutoRepost=@AutoRepost,");
            strSql.Append("PromotedType=@PromotedType,");
            strSql.Append("StatusId=@StatusId,");
            strSql.Append("LevelId=@LevelId,");
            strSql.Append("AlipayBind=@AlipayBind,");
            strSql.Append("Protection=@Protection,");
            strSql.Append("Avatar=@Avatar,");
            strSql.Append("LiangPin=@LiangPin,");
            strSql.Append("SignFoods=@SignFoods,");
            strSql.Append("HasShop=@HasShop,");
            strSql.Append("IsLightning=@IsLightning,");
            strSql.Append("HasSubStock=@HasSubStock,");
            strSql.Append("GoldenSeller=@GoldenSeller,");
            strSql.Append("Subscribe=@Subscribe,");
            strSql.Append("VerMarket=@VerMarket,");
            strSql.Append("OnlineGaming=@OnlineGaming,");
            strSql.Append("EmailNum=@EmailNum,");
            strSql.Append("SMSNum=@SMSNum,");
            strSql.Append("Currency=@Currency,");
            strSql.Append("Validity=@Validity,");
            strSql.Append("InputDate=@InputDate");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@TbUserId", SqlDbType.Int,4),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@UserNick", SqlDbType.VarChar,50),
					new SqlParameter("@GenderId", SqlDbType.Int,4),
					new SqlParameter("@CreditId", SqlDbType.Int,4),
					new SqlParameter("@TypeId", SqlDbType.Int,4),
					new SqlParameter("@HasMorePic", SqlDbType.Bit,1),
					new SqlParameter("@ItemImgNum", SqlDbType.Int,4),
					new SqlParameter("@ItemImgSize", SqlDbType.Int,4),
					new SqlParameter("@PropImgNum", SqlDbType.Int,4),
					new SqlParameter("@PropImgSize", SqlDbType.Int,4),
					new SqlParameter("@AutoRepost", SqlDbType.Bit,1),
					new SqlParameter("@PromotedType", SqlDbType.Bit,1),
					new SqlParameter("@StatusId", SqlDbType.Int,4),
					new SqlParameter("@LevelId", SqlDbType.Int,4),
					new SqlParameter("@AlipayBind", SqlDbType.Bit,1),
					new SqlParameter("@Protection", SqlDbType.Bit,1),
					new SqlParameter("@Avatar", SqlDbType.VarChar,200),
					new SqlParameter("@LiangPin", SqlDbType.Bit,1),
					new SqlParameter("@SignFoods", SqlDbType.Bit,1),
					new SqlParameter("@HasShop", SqlDbType.Bit,1),
					new SqlParameter("@IsLightning", SqlDbType.Bit,1),
					new SqlParameter("@HasSubStock", SqlDbType.Bit,1),
					new SqlParameter("@GoldenSeller", SqlDbType.Bit,1),
					new SqlParameter("@Subscribe", SqlDbType.Bit,1),
					new SqlParameter("@VerMarket", SqlDbType.VarChar,200),
					new SqlParameter("@OnlineGaming", SqlDbType.Bit,1),
					new SqlParameter("@EmailNum", SqlDbType.Int,4),
					new SqlParameter("@SMSNum", SqlDbType.Int,4),
					new SqlParameter("@Currency", SqlDbType.Decimal,9),
					new SqlParameter("@Validity", SqlDbType.DateTime),
					new SqlParameter("@InputDate", SqlDbType.DateTime),
					new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = model.TbUserId;
            parameters[1].Value = model.ParentId;
            parameters[2].Value = model.UserNick;
            parameters[3].Value = model.Gender.GenderId;
            parameters[4].Value = model.Credit.CreditId;
            parameters[5].Value = model.Type.TypeId;
            parameters[6].Value = model.HasMorePic;
            parameters[7].Value = model.ItemImgNum;
            parameters[8].Value = model.ItemImgSize;
            parameters[9].Value = model.PropImgNum;
            parameters[10].Value = model.PropImgSize;
            parameters[11].Value = model.AutoRepost;
            parameters[12].Value = model.PromotedType;
            parameters[13].Value = model.Status.StatusId;
            parameters[14].Value = model.Level.LevelId;
            parameters[15].Value = model.AlipayBind;
            parameters[16].Value = model.Protection;
            parameters[17].Value = model.Avatar;
            parameters[18].Value = model.LiangPin;
            parameters[19].Value = model.SignFoods;
            parameters[20].Value = model.HasShop;
            parameters[21].Value = model.IsLightning;
            parameters[22].Value = model.HasSubStock;
            parameters[23].Value = model.GoldenSeller;
            parameters[24].Value = model.Subscribe;
            parameters[25].Value = model.VerMarket;
            parameters[26].Value = model.OnlineGaming;
            parameters[27].Value = model.EmailNum;
            parameters[28].Value = model.SMSNum;
            parameters[29].Value = model.Currency;
            parameters[30].Value = model.Validity;
            parameters[31].Value = model.InputDate.ToLocalTime();
            parameters[32].Value = model.UserId;

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
        /// 查询tbClientUser 中是否已经存在该用户,并返回用户信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public tbClientUser ExitisUser(string TBUserId, string UserNick)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserId,TbUserId,ParentId,UserNick,GenderId,CreditId,TypeId,HasMorePic,ItemImgNum,ItemImgSize,PropImgNum,PropImgSize,AutoRepost,PromotedType,StatusId,LevelId,AlipayBind,Protection,Avatar,LiangPin,SignFoods,HasShop,IsLightning,HasSubStock,GoldenSeller,Subscribe,VerMarket,OnlineGaming,EmailNum,SMSNum,Currency,Validity,InputDate from tbClientUser ");
            strSql.Append(" where TBUserId=@TBUserId");
            strSql.Append(" and UserNick=@UserNick");
            SqlParameter[] parameters = {
					new SqlParameter("@TBUserId", SqlDbType.Int,4),
                    new SqlParameter("@UserNick", SqlDbType.VarChar,50)
			};
            parameters[0].Value = TBUserId;
            parameters[1].Value = UserNick;

            tbClientUser model = new tbClientUser();
            DataSet ds = DBHelper.ExecuteDataSet(CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TbUserId"].ToString() != "")
                {
                    model.TbUserId = int.Parse(ds.Tables[0].Rows[0]["TbUserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserNick"] != null)
                {
                    model.UserNick = ds.Tables[0].Rows[0]["UserNick"].ToString();
                }
                if (ds.Tables[0].Rows[0]["GenderId"].ToString() != "")
                {
                    model.Gender = new tbClientUserGender();
                    model.Gender.GenderId = int.Parse(ds.Tables[0].Rows[0]["GenderId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreditId"].ToString() != "")
                {
                    model.Credit = new tbClientUserCredit();
                    model.Credit.CreditId = int.Parse(ds.Tables[0].Rows[0]["CreditId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeId"].ToString() != "")
                {
                    model.Type = new tbClientUserType();
                    model.Type.TypeId = int.Parse(ds.Tables[0].Rows[0]["TypeId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HasMorePic"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["HasMorePic"].ToString() == "1") || (ds.Tables[0].Rows[0]["HasMorePic"].ToString().ToLower() == "true"))
                    {
                        model.HasMorePic = true;
                    }
                    else
                    {
                        model.HasMorePic = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["ItemImgNum"].ToString() != "")
                {
                    model.ItemImgNum = int.Parse(ds.Tables[0].Rows[0]["ItemImgNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ItemImgSize"].ToString() != "")
                {
                    model.ItemImgSize = int.Parse(ds.Tables[0].Rows[0]["ItemImgSize"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PropImgNum"].ToString() != "")
                {
                    model.PropImgNum = int.Parse(ds.Tables[0].Rows[0]["PropImgNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PropImgSize"].ToString() != "")
                {
                    model.PropImgSize = int.Parse(ds.Tables[0].Rows[0]["PropImgSize"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AutoRepost"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["AutoRepost"].ToString() == "1") || (ds.Tables[0].Rows[0]["AutoRepost"].ToString().ToLower() == "true"))
                    {
                        model.AutoRepost = true;
                    }
                    else
                    {
                        model.AutoRepost = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PromotedType"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PromotedType"].ToString() == "1") || (ds.Tables[0].Rows[0]["PromotedType"].ToString().ToLower() == "true"))
                    {
                        model.PromotedType = true;
                    }
                    else
                    {
                        model.PromotedType = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["StatusId"].ToString() != "")
                {
                    model.Status = new tbClientUserStatus();
                    model.Status.StatusId = int.Parse(ds.Tables[0].Rows[0]["StatusId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LevelId"].ToString() != "")
                {
                    model.Level = new tbClientUserLevel();
                    model.Level.LevelId = int.Parse(ds.Tables[0].Rows[0]["LevelId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AlipayBind"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["AlipayBind"].ToString() == "1") || (ds.Tables[0].Rows[0]["AlipayBind"].ToString().ToLower() == "true"))
                    {
                        model.AlipayBind = true;
                    }
                    else
                    {
                        model.AlipayBind = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Protection"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Protection"].ToString() == "1") || (ds.Tables[0].Rows[0]["Protection"].ToString().ToLower() == "true"))
                    {
                        model.Protection = true;
                    }
                    else
                    {
                        model.Protection = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Avatar"] != null)
                {
                    model.Avatar = ds.Tables[0].Rows[0]["Avatar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LiangPin"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["LiangPin"].ToString() == "1") || (ds.Tables[0].Rows[0]["LiangPin"].ToString().ToLower() == "true"))
                    {
                        model.LiangPin = true;
                    }
                    else
                    {
                        model.LiangPin = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["SignFoods"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["SignFoods"].ToString() == "1") || (ds.Tables[0].Rows[0]["SignFoods"].ToString().ToLower() == "true"))
                    {
                        model.SignFoods = true;
                    }
                    else
                    {
                        model.SignFoods = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["HasShop"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["HasShop"].ToString() == "1") || (ds.Tables[0].Rows[0]["HasShop"].ToString().ToLower() == "true"))
                    {
                        model.HasShop = true;
                    }
                    else
                    {
                        model.HasShop = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsLightning"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsLightning"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsLightning"].ToString().ToLower() == "true"))
                    {
                        model.IsLightning = true;
                    }
                    else
                    {
                        model.IsLightning = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["HasSubStock"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["HasSubStock"].ToString() == "1") || (ds.Tables[0].Rows[0]["HasSubStock"].ToString().ToLower() == "true"))
                    {
                        model.HasSubStock = true;
                    }
                    else
                    {
                        model.HasSubStock = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["GoldenSeller"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["GoldenSeller"].ToString() == "1") || (ds.Tables[0].Rows[0]["GoldenSeller"].ToString().ToLower() == "true"))
                    {
                        model.GoldenSeller = true;
                    }
                    else
                    {
                        model.GoldenSeller = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Subscribe"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Subscribe"].ToString() == "1") || (ds.Tables[0].Rows[0]["Subscribe"].ToString().ToLower() == "true"))
                    {
                        model.Subscribe = true;
                    }
                    else
                    {
                        model.Subscribe = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["VerMarket"] != null)
                {
                    model.VerMarket = ds.Tables[0].Rows[0]["VerMarket"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OnlineGaming"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["OnlineGaming"].ToString() == "1") || (ds.Tables[0].Rows[0]["OnlineGaming"].ToString().ToLower() == "true"))
                    {
                        model.OnlineGaming = true;
                    }
                    else
                    {
                        model.OnlineGaming = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["EmailNum"].ToString() != "")
                {
                    model.EmailNum = int.Parse(ds.Tables[0].Rows[0]["EmailNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SMSNum"].ToString() != "")
                {
                    model.SMSNum = int.Parse(ds.Tables[0].Rows[0]["SMSNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Currency"].ToString() != "")
                {
                    model.Currency = decimal.Parse(ds.Tables[0].Rows[0]["Currency"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Validity"].ToString() != "")
                {
                    model.Validity = DateTime.Parse(ds.Tables[0].Rows[0]["Validity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InputDate"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["InputDate"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }

            return model;
        }

        /// <summary>
        /// 根据淘宝用户名 和用户昵称查询信息
        /// </summary>
        /// <param name="TbUserId"></param>
        /// <param name="UserNick"></param>
        /// <returns></returns>
        public tbClientUser SelectUser(string TbUserId, string UserNick)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select  top 1 UserId,TbUserId,ParentId,UserNick,GenderId,CreditId,TypeId,HasMorePic,ItemImgNum,ItemImgSize,PropImgNum,PropImgSize,AutoRepost,PromotedType,StatusId,LevelId,AlipayBind,Protection,Avatar,LiangPin,SignFoods,HasShop,IsLightning,HasSubStock,GoldenSeller,Subscribe,VerMarket,OnlineGaming,EmailNum,SMSNum,Currency,Validity,InputDate from tbClientUser ");
            //strSql.Append(" where UserId=@UserId");
            //strSql.Append(" and UserNick=@UserNick");
            strSql.Append("Select_UserInfo_By_UserId_And_UserNick");
            SqlParameter[] parameters = {
                    new SqlParameter("@TbUserId", SqlDbType.Int,4),
                    new SqlParameter("@UserNick", SqlDbType.VarChar,50)
            };
            parameters[0].Value = TbUserId;
            parameters[1].Value = UserNick;

            tbClientUser model = new tbClientUser();
            DataSet ds = DBHelper.ExecuteDataSet(CommandType.StoredProcedure, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TbUserId"].ToString() != "")
                {
                    model.TbUserId = int.Parse(ds.Tables[0].Rows[0]["TbUserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserNick"] != null)
                {
                    model.UserNick = ds.Tables[0].Rows[0]["UserNick"].ToString();
                }
                if (ds.Tables[0].Rows[0]["GenderId"].ToString() != "")
                {
                    model.Gender = new tbClientUserGender();
                    model.Gender.GenderId = int.Parse(ds.Tables[0].Rows[0]["GenderId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreditId"].ToString() != "")
                {
                    model.Credit = new tbClientUserCredit();
                    model.Credit.CreditId = int.Parse(ds.Tables[0].Rows[0]["CreditId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeId"].ToString() != "")
                {
                    model.Type = new tbClientUserType();
                    model.Type.TypeId = int.Parse(ds.Tables[0].Rows[0]["TypeId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HasMorePic"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["HasMorePic"].ToString() == "1") || (ds.Tables[0].Rows[0]["HasMorePic"].ToString().ToLower() == "true"))
                    {
                        model.HasMorePic = true;
                    }
                    else
                    {
                        model.HasMorePic = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["ItemImgNum"].ToString() != "")
                {
                    model.ItemImgNum = int.Parse(ds.Tables[0].Rows[0]["ItemImgNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ItemImgSize"].ToString() != "")
                {
                    model.ItemImgSize = int.Parse(ds.Tables[0].Rows[0]["ItemImgSize"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PropImgNum"].ToString() != "")
                {
                    model.PropImgNum = int.Parse(ds.Tables[0].Rows[0]["PropImgNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PropImgSize"].ToString() != "")
                {
                    model.PropImgSize = int.Parse(ds.Tables[0].Rows[0]["PropImgSize"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AutoRepost"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["AutoRepost"].ToString() == "1") || (ds.Tables[0].Rows[0]["AutoRepost"].ToString().ToLower() == "true"))
                    {
                        model.AutoRepost = true;
                    }
                    else
                    {
                        model.AutoRepost = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PromotedType"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PromotedType"].ToString() == "1") || (ds.Tables[0].Rows[0]["PromotedType"].ToString().ToLower() == "true"))
                    {
                        model.PromotedType = true;
                    }
                    else
                    {
                        model.PromotedType = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["StatusId"].ToString() != "")
                {
                    model.Status = new tbClientUserStatus();
                    model.Status.StatusId = int.Parse(ds.Tables[0].Rows[0]["StatusId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LevelId"].ToString() != "")
                {
                    model.Level = new tbClientUserLevel();
                    model.Level.LevelId = int.Parse(ds.Tables[0].Rows[0]["LevelId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AlipayBind"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["AlipayBind"].ToString() == "1") || (ds.Tables[0].Rows[0]["AlipayBind"].ToString().ToLower() == "true"))
                    {
                        model.AlipayBind = true;
                    }
                    else
                    {
                        model.AlipayBind = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Protection"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Protection"].ToString() == "1") || (ds.Tables[0].Rows[0]["Protection"].ToString().ToLower() == "true"))
                    {
                        model.Protection = true;
                    }
                    else
                    {
                        model.Protection = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Avatar"] != null)
                {
                    model.Avatar = ds.Tables[0].Rows[0]["Avatar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LiangPin"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["LiangPin"].ToString() == "1") || (ds.Tables[0].Rows[0]["LiangPin"].ToString().ToLower() == "true"))
                    {
                        model.LiangPin = true;
                    }
                    else
                    {
                        model.LiangPin = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["SignFoods"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["SignFoods"].ToString() == "1") || (ds.Tables[0].Rows[0]["SignFoods"].ToString().ToLower() == "true"))
                    {
                        model.SignFoods = true;
                    }
                    else
                    {
                        model.SignFoods = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["HasShop"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["HasShop"].ToString() == "1") || (ds.Tables[0].Rows[0]["HasShop"].ToString().ToLower() == "true"))
                    {
                        model.HasShop = true;
                    }
                    else
                    {
                        model.HasShop = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsLightning"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsLightning"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsLightning"].ToString().ToLower() == "true"))
                    {
                        model.IsLightning = true;
                    }
                    else
                    {
                        model.IsLightning = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["HasSubStock"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["HasSubStock"].ToString() == "1") || (ds.Tables[0].Rows[0]["HasSubStock"].ToString().ToLower() == "true"))
                    {
                        model.HasSubStock = true;
                    }
                    else
                    {
                        model.HasSubStock = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["GoldenSeller"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["GoldenSeller"].ToString() == "1") || (ds.Tables[0].Rows[0]["GoldenSeller"].ToString().ToLower() == "true"))
                    {
                        model.GoldenSeller = true;
                    }
                    else
                    {
                        model.GoldenSeller = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Subscribe"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Subscribe"].ToString() == "1") || (ds.Tables[0].Rows[0]["Subscribe"].ToString().ToLower() == "true"))
                    {
                        model.Subscribe = true;
                    }
                    else
                    {
                        model.Subscribe = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["VerMarket"] != null)
                {
                    model.VerMarket = ds.Tables[0].Rows[0]["VerMarket"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OnlineGaming"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["OnlineGaming"].ToString() == "1") || (ds.Tables[0].Rows[0]["OnlineGaming"].ToString().ToLower() == "true"))
                    {
                        model.OnlineGaming = true;
                    }
                    else
                    {
                        model.OnlineGaming = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["EmailNum"].ToString() != "")
                {
                    model.EmailNum = int.Parse(ds.Tables[0].Rows[0]["EmailNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SMSNum"].ToString() != "")
                {
                    model.SMSNum = int.Parse(ds.Tables[0].Rows[0]["SMSNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Currency"].ToString() != "")
                {
                    model.Currency = decimal.Parse(ds.Tables[0].Rows[0]["Currency"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Validity"].ToString() != "")
                {
                    model.Validity = DateTime.Parse(ds.Tables[0].Rows[0]["Validity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InputDate"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["InputDate"].ToString());
                }
                #region
                /*
                if (ds.Tables[0].Rows[0]["ShopId"].ToString() != "")
                {
                    model.UserShops usershop=new 
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["ShopId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SessionKey"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["SessionKey"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TbShopId"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["TbShopId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ScoreId"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["ScoreId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CateId"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["CateId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NickName"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["NickName"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["Title"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Desc"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["Desc"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Bulletin"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["Bulletin"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PicPath"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["PicPath"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Created"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["Created"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Modified"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["Modified"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreditId"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreditId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GoodNum"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["GoodNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Level"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Score"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["Score"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalNum"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["TotalNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GenderId"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["GenderId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GenderImg"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["GenderImg"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GenderName"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["GenderName"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EnumName"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["EnumName"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LevelId"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["LevelId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LevelImg"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["LevelImg"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LevelName"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["LevelName"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Priority"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["Priority"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DeliveryScore"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["DeliveryScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ItemScore"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["ItemScore"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ScoreId"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["ScoreId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ServiceScore"].ToString() != "")
                {
                    model.InputDate = DateTime.Parse(ds.Tables[0].Rows[0]["ServiceScore"].ToString());
                }*/
                #endregion
                return model;
            }
            else
            {
                return null;
            }

            return model;
        }
    }
}
