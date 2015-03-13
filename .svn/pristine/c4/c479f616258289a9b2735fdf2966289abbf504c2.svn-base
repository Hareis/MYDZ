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
    public class FoodSecurity : IFoodSecurity
    {
        public bool AddFoodSecurity(Entity.Goods.FoodSecurity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FoodSecurity(");
            strSql.Append("FoodSecurityID,PlanStorage,PrdLicenseNo,ProductDateEnd,ProductDateStart,StockDateEnd,StockDateStart,Supplier,Contact,DesignCode,Factory,FactorySite,FoodAdditive,HealthProductNo,Mix,Period");
            strSql.Append(") values (");
            strSql.Append("@FoodSecurityID,@PlanStorage,@PrdLicenseNo,@ProductDateEnd,@ProductDateStart,@StockDateEnd,@StockDateStart,@Supplier,@Contact,@DesignCode,@Factory,@FactorySite,@FoodAdditive,@HealthProductNo,@Mix,@Period");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@FoodSecurityID", SqlDbType.Int,4) ,            
                        new SqlParameter("@PlanStorage", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@PrdLicenseNo", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@ProductDateEnd", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ProductDateStart", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@StockDateEnd", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@StockDateStart", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Supplier", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Contact", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@DesignCode", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Factory", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@FactorySite", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@FoodAdditive", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@HealthProductNo", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Mix", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@Period", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = model.FoodSecurityID;
            parameters[1].Value = model.PlanStorage;
            parameters[2].Value = model.PrdLicenseNo;
            parameters[3].Value = model.ProductDateEnd;
            parameters[4].Value = model.ProductDateStart;
            parameters[5].Value = model.StockDateEnd;
            parameters[6].Value = model.StockDateStart;
            parameters[7].Value = model.Supplier;
            parameters[8].Value = model.Contact;
            parameters[9].Value = model.DesignCode;
            parameters[10].Value = model.Factory;
            parameters[11].Value = model.FactorySite;
            parameters[12].Value = model.FoodAdditive;
            parameters[13].Value = model.HealthProductNo;
            parameters[14].Value = model.Mix;
            parameters[15].Value = model.Period;
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

        public bool UpdateFoodSecurity(Entity.Goods.FoodSecurity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FoodSecurity set ");

            strSql.Append(" FoodSecurityID = @FoodSecurityID , ");
            strSql.Append(" PlanStorage = @PlanStorage , ");
            strSql.Append(" PrdLicenseNo = @PrdLicenseNo , ");
            strSql.Append(" ProductDateEnd = @ProductDateEnd , ");
            strSql.Append(" ProductDateStart = @ProductDateStart , ");
            strSql.Append(" StockDateEnd = @StockDateEnd , ");
            strSql.Append(" StockDateStart = @StockDateStart , ");
            strSql.Append(" Supplier = @Supplier , ");
            strSql.Append(" Contact = @Contact , ");
            strSql.Append(" DesignCode = @DesignCode , ");
            strSql.Append(" Factory = @Factory , ");
            strSql.Append(" FactorySite = @FactorySite , ");
            strSql.Append(" FoodAdditive = @FoodAdditive , ");
            strSql.Append(" HealthProductNo = @HealthProductNo , ");
            strSql.Append(" Mix = @Mix , ");
            strSql.Append(" Period = @Period  ");
            strSql.Append(" where FoodSecurityID=@FoodSecurityID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@FoodSecurityID", SqlDbType.Int,4) ,            
                        new SqlParameter("@PlanStorage", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@PrdLicenseNo", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@ProductDateEnd", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ProductDateStart", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@StockDateEnd", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@StockDateStart", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Supplier", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Contact", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@DesignCode", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Factory", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@FactorySite", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@FoodAdditive", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@HealthProductNo", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Mix", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@Period", SqlDbType.VarChar,50)             
              
            };

            parameters[0].Value = model.FoodSecurityID;
            parameters[1].Value = model.PlanStorage;
            parameters[2].Value = model.PrdLicenseNo;
            parameters[3].Value = model.ProductDateEnd;
            parameters[4].Value = model.ProductDateStart;
            parameters[5].Value = model.StockDateEnd;
            parameters[6].Value = model.StockDateStart;
            parameters[7].Value = model.Supplier;
            parameters[8].Value = model.Contact;
            parameters[9].Value = model.DesignCode;
            parameters[10].Value = model.Factory;
            parameters[11].Value = model.FactorySite;
            parameters[12].Value = model.FoodAdditive;
            parameters[13].Value = model.HealthProductNo;
            parameters[14].Value = model.Mix;
            parameters[15].Value = model.Period;
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

        public bool DeleteFoodSecurity(string FoodSecurityID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FoodSecurity ");
            strSql.Append(" where FoodSecurityID=@FoodSecurityID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FoodSecurityID", SqlDbType.Int,4)
                 };
            parameters[0].Value = FoodSecurityID;
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

        public IList<Entity.Goods.FoodSecurity> GetItemImg(string FoodSecurityID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FoodSecurityID, PlanStorage, PrdLicenseNo, ProductDateEnd, ProductDateStart, StockDateEnd, StockDateStart, Supplier, Contact, DesignCode, Factory, FactorySite, FoodAdditive, HealthProductNo, Mix, Period  ");
            strSql.Append("  from FoodSecurity ");
            strSql.Append(" where FoodSecurityID=@FoodSecurityID ");
            SqlParameter[] parameters = {
					new SqlParameter("@FoodSecurityID", SqlDbType.Int,4)
               };
            parameters[0].Value = FoodSecurityID;
            return DBHelper.ExecuteIList<Entity.Goods.FoodSecurity>(CommandType.Text, strSql.ToString(), parameters);
        }
    }
}
