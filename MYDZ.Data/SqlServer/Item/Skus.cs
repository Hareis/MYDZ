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
    public class Skus : ISkus
    {
        public bool AddSkus(Entity.Goods.Skus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Skus(");
            strSql.Append("SkusID,Properties,PropertiesName,Quantity,SkuDeliveryTime,SkuId,SkuSpecId,Status,WithHoldQuantity,Barcode,ChangeProp,Created,Iid,Modified,NumIid,OuterId,Price,SPZL,SPJC,CBJ");
            strSql.Append(") values (");
            strSql.Append("@SkusID,@Properties,@PropertiesName,@Quantity,@SkuDeliveryTime,@SkuId,@SkuSpecId,@Status,@WithHoldQuantity,@Barcode,@ChangeProp,@Created,@Iid,@Modified,@NumIid,@OuterId,@Price,@SPZL,@SPJC,@CBJ");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@SkusID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Properties", SqlDbType.VarChar,5000) ,            
                        new SqlParameter("@PropertiesName", SqlDbType.VarChar,5000) ,            
                        new SqlParameter("@Quantity", SqlDbType.Int,4) ,            
                        new SqlParameter("@SkuDeliveryTime", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@SkuId", SqlDbType.Int,4) ,            
                        new SqlParameter("@SkuSpecId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Status", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@WithHoldQuantity", SqlDbType.Int,4) ,            
                        new SqlParameter("@Barcode", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@ChangeProp", SqlDbType.VarChar,5000) ,            
                        new SqlParameter("@Created", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Iid", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Modified", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@NumIid", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@OuterId", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Price", SqlDbType.Decimal,9)   ,
                        new SqlParameter("@SPJC", SqlDbType.VarChar,200)  ,
                        new SqlParameter("@SPZL", SqlDbType.VarChar,100)  ,
                        new SqlParameter("@CBJ", SqlDbType.Decimal,13)  
            };

            parameters[0].Value = model.SkusId;
            parameters[1].Value = model.Properties;
            parameters[2].Value = model.PropertiesName;
            parameters[3].Value = model.Quantity;
            parameters[4].Value = model.SkuDeliveryTime;
            parameters[5].Value = model.SkuId;
            parameters[6].Value = model.SkuSpecId;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.WithHoldQuantity;
            parameters[9].Value = model.Barcode;
            parameters[10].Value = model.ChangeProp;
            parameters[11].Value = model.Created;
            parameters[12].Value = model.Iid;
            parameters[13].Value = model.Modified;
            parameters[14].Value = model.NumIid;
            parameters[15].Value = model.OuterId;
            parameters[16].Value = model.Price;
            parameters[17].Value = model.SPJC;
            parameters[18].Value = model.SPZL;
            parameters[19].Value = model.CBJ;
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

        public bool UpdateSkus(Entity.Goods.Skus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Skus set ");

            strSql.Append(" Properties = @Properties , ");
            strSql.Append(" PropertiesName = @PropertiesName , ");
            strSql.Append(" Quantity = @Quantity , ");
            strSql.Append(" SkuDeliveryTime = @SkuDeliveryTime , ");
            strSql.Append(" SkuId = @SkuId , ");
            strSql.Append(" SkuSpecId = @SkuSpecId , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" WithHoldQuantity = @WithHoldQuantity , ");
            strSql.Append(" Barcode = @Barcode , ");
            strSql.Append(" ChangeProp = @ChangeProp , ");
            strSql.Append(" Created = @Created , ");
            strSql.Append(" Iid = @Iid , ");
            strSql.Append(" Modified = @Modified , ");
            strSql.Append(" NumIid = @NumIid , ");
            strSql.Append(" OuterId = @OuterId , ");
            strSql.Append(" Price = @Price , ");
            strSql.Append(" SPJC = @SPJC  ,");
            strSql.Append(" SPZL = @SPZL ， ");
            strSql.Append(" CBJ = @CBJ  ");
            strSql.Append(" where SkusID=@SkusID ");


            SqlParameter[] parameters = {
			            new SqlParameter("@SkusID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Properties", SqlDbType.VarChar,5000) ,            
                        new SqlParameter("@PropertiesName", SqlDbType.VarChar,5000) ,            
                        new SqlParameter("@Quantity", SqlDbType.Int,4) ,            
                        new SqlParameter("@SkuDeliveryTime", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@SkuId", SqlDbType.Int,4) ,            
                        new SqlParameter("@SkuSpecId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Status", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@WithHoldQuantity", SqlDbType.Int,4) ,            
                        new SqlParameter("@Barcode", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@ChangeProp", SqlDbType.VarChar,5000) ,            
                        new SqlParameter("@Created", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Iid", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Modified", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@NumIid", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@OuterId", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Price", SqlDbType.Decimal,9),
                        new SqlParameter("@SPZL", SqlDbType.VarChar,100) ,  
                        new SqlParameter("@SPJC", SqlDbType.VarChar,200) ,
                        new SqlParameter("@CBJ", SqlDbType.Decimal,13)
              
            };

            parameters[0].Value = model.SkusId;
            parameters[1].Value = model.Properties;
            parameters[2].Value = model.PropertiesName;
            parameters[3].Value = model.Quantity;
            parameters[4].Value = model.SkuDeliveryTime;
            parameters[5].Value = model.SkuId;
            parameters[6].Value = model.SkuSpecId;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.WithHoldQuantity;
            parameters[9].Value = model.Barcode;
            parameters[10].Value = model.ChangeProp;
            parameters[11].Value = model.Created;
            parameters[12].Value = model.Iid;
            parameters[13].Value = model.Modified;
            parameters[14].Value = model.NumIid;
            parameters[15].Value = model.OuterId;
            parameters[16].Value = model.Price;
            parameters[17].Value = model.SPZL;
            parameters[18].Value = model.SPJC;
            parameters[19].Value = model.CBJ;
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

        public bool DeleteSkus(string SkusId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Skus ");
            strSql.Append(" where SkusID=@SkusID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SkusID", SqlDbType.Int,4)
                   };
            parameters[0].Value = SkusId;
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

        public IList<Entity.Goods.Skus> GetSkus(string SkusId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SkusID, Properties, PropertiesName, Quantity, SkuDeliveryTime, SkuId, SkuSpecId, [Status], WithHoldQuantity, Barcode, ChangeProp, Created, Iid, Modified, NumIid, OuterId, Price ,SPZL,SPJC,CBJ");
            strSql.Append(" from Skus where SkusID=@SkusID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SkusID", SqlDbType.Float,4)
            };
            parameters[0].Value = Int64.Parse(SkusId);
            return DBHelper.ExecuteIList<Entity.Goods.Skus>(CommandType.Text, strSql.ToString(), parameters);
        }
    }
}
