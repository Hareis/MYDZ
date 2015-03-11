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
    public class Location : ILocation
    {
        public bool AddLocation(Entity.Goods.Location model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Location(");
            strSql.Append("Address,City,Country,District,State,Zip");
            strSql.Append(") values (");
            strSql.Append("@Address,@City,@Country,@District,@State,@Zip");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@Address", SqlDbType.VarChar,600) ,            
                        new SqlParameter("@City", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Country", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@District", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@State", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Zip", SqlDbType.VarChar,100)             
              
            };

            parameters[0].Value = model.Address;
            parameters[1].Value = model.City;
            parameters[2].Value = model.Country;
            parameters[3].Value = model.District;
            parameters[4].Value = model.State;
            parameters[5].Value = model.Zip;

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

        public bool UpdateLocation(Entity.Goods.Location model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Location set ");

            strSql.Append(" Address = @Address , ");
            strSql.Append(" City = @City , ");
            strSql.Append(" Country = @Country , ");
            strSql.Append(" District = @District , ");
            strSql.Append(" State = @State , ");
            strSql.Append(" Zip = @Zip  ");
            strSql.Append(" where LocationId=@LocationId ");

            SqlParameter[] parameters = {
			            new SqlParameter("@LocationId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Address", SqlDbType.VarChar,600) ,            
                        new SqlParameter("@City", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Country", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@District", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@State", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@Zip", SqlDbType.VarChar,100)             
              
            };

            parameters[6].Value = model.LocationId;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.City;
            parameters[9].Value = model.Country;
            parameters[10].Value = model.District;
            parameters[11].Value = model.State;
            parameters[12].Value = model.Zip;
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

        public bool DeleteLocation(string LocationId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Location ");
            strSql.Append(" where LocationId=@LocationId");
            SqlParameter[] parameters = {
					new SqlParameter("@LocationId", SqlDbType.Int,4)
			};
            parameters[0].Value = LocationId;


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

        public IList<Entity.Goods.Location> GetLocation(string LocationId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LocationId, Address, City, Country, District, State, Zip  ");
            strSql.Append("  from Location ");
            strSql.Append(" where LocationId=@LocationId");
            SqlParameter[] parameters = {
					new SqlParameter("@LocationId", SqlDbType.Int,4)
			};
            parameters[0].Value = LocationId;
            return DBHelper.ExecuteIList<Entity.Goods.Location>(CommandType.Text, strSql.ToString(), parameters);           
        }
    }
}
