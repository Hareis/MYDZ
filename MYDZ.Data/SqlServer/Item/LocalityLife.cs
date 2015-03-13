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
    public class LocalityLife : ILocalityLife
    {

        public bool AddLocalityLife(Entity.Goods.LocalityLife model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LocalityLife(");
            strSql.Append("LocalityLifeID,Verification,ChooseLogis,Eticket,Expirydate,Merchant,NetworkId,OnsaleAutoRefundRatio,RefundRatio,Refundmafee");
            strSql.Append(") values (");
            strSql.Append("@LocalityLifeID,@Verification,@ChooseLogis,@Eticket,@Expirydate,@Merchant,@NetworkId,@OnsaleAutoRefundRatio,@RefundRatio,@Refundmafee");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@LocalityLifeID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Verification", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@ChooseLogis", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Eticket", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Expirydate", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Merchant", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@NetworkId", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@OnsaleAutoRefundRatio", SqlDbType.Int,4) ,            
                        new SqlParameter("@RefundRatio", SqlDbType.Int,4) ,            
                        new SqlParameter("@Refundmafee", SqlDbType.VarChar,100)             
              
            };

            parameters[0].Value = model.LocalityLifeID;
            parameters[1].Value = model.Verification;
            parameters[2].Value = model.ChooseLogis;
            parameters[3].Value = model.Eticket;
            parameters[4].Value = model.Expirydate;
            parameters[5].Value = model.Merchant;
            parameters[6].Value = model.NetworkId;
            parameters[7].Value = model.OnsaleAutoRefundRatio;
            parameters[8].Value = model.RefundRatio;
            parameters[9].Value = model.Refundmafee;
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

        public bool UpdateLocalityLife(Entity.Goods.LocalityLife model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LocalityLife set ");
            strSql.Append(" Verification = @Verification , ");
            strSql.Append(" ChooseLogis = @ChooseLogis , ");
            strSql.Append(" Eticket = @Eticket , ");
            strSql.Append(" Expirydate = @Expirydate , ");
            strSql.Append(" Merchant = @Merchant , ");
            strSql.Append(" NetworkId = @NetworkId , ");
            strSql.Append(" OnsaleAutoRefundRatio = @OnsaleAutoRefundRatio , ");
            strSql.Append(" RefundRatio = @RefundRatio , ");
            strSql.Append(" Refundmafee = @Refundmafee  ");
            strSql.Append(" where LocalityLifeID=@LocalityLifeID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@LocalityLifeID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Verification", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@ChooseLogis", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Eticket", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Expirydate", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Merchant", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@NetworkId", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@OnsaleAutoRefundRatio", SqlDbType.Int,4) ,            
                        new SqlParameter("@RefundRatio", SqlDbType.Int,4) ,            
                        new SqlParameter("@Refundmafee", SqlDbType.VarChar,100)             
              
            };

            parameters[0].Value = model.LocalityLifeID;
            parameters[1].Value = model.Verification;
            parameters[2].Value = model.ChooseLogis;
            parameters[3].Value = model.Eticket;
            parameters[4].Value = model.Expirydate;
            parameters[5].Value = model.Merchant;
            parameters[6].Value = model.NetworkId;
            parameters[7].Value = model.OnsaleAutoRefundRatio;
            parameters[8].Value = model.RefundRatio;
            parameters[9].Value = model.Refundmafee;
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

        public bool DeleteLocalityLife(string LocalityLifeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LocalityLife ");
            strSql.Append(" where LocalityLifeID=@LocalityLifeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@LocalityLifeID", SqlDbType.Int,4)
                };
            parameters[0].Value = LocalityLifeID;

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

        public IList<Entity.Goods.LocalityLife> GetLocalityLife(string LocalityLifeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LocalityLifeID, Verification, ChooseLogis, Eticket, Expirydate, Merchant, NetworkId, OnsaleAutoRefundRatio, RefundRatio, Refundmafee  ");
            strSql.Append("  from LocalityLife ");
            strSql.Append(" where LocalityLifeID=@LocalityLifeID");
            SqlParameter[] parameters = {
					new SqlParameter("@LocalityLifeID", SqlDbType.Int,4)
                     };
            parameters[0].Value = LocalityLifeID;
            return DBHelper.ExecuteIList<Entity.Goods.LocalityLife>(CommandType.Text, strSql.ToString(), parameters);

        }
    }
}
