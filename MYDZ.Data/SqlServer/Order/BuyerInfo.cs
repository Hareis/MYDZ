using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Order;
using MYDZ.Entity.Order;
using System.Data;
using MYDZ.DBUtility;
using System.Data.SqlClient;

namespace MYDZ.Data.SqlServer.Order
{
    public class BuyerInfo : IBuyerInfo
    {
        private const string SQL_SELECT = "SelectBuyerByOrdersNumber";                                      //根据订单编号查询买家信息
        private const string SQL_INSERT = "InsertBuyerInfo";                                                //添加买家信息

        private const string PARM_NUMBER = "@OrdersNumber";                                                 //订单编号
        private const string PARM_NNAME = "@NickName";                                                      //买家昵称
        private const string PARM_NAME = "@BuyerName";                                                      //买家姓名
        private const string PARM_MOBILE = "@Mobile";                                                       //买家手机
        private const string PARM_PHONE = "@Phone";                                                         //买家电话
        private const string PARM_EMAIL = "@BuyerEmail";                                                    //买家邮箱

        public tbBuyerInfo Select(string OrdersNumber)
        {
            tbBuyerInfo Buyer = null;
            IDbDataParameter[] parm = GetSelectNumberParam();
            parm[0].Value = OrdersNumber;

            using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT, parm))
            {
                if (MyReader.Read())
                {
                    Buyer = new tbBuyerInfo()
                    {
                        BuyerId = MyReader.GetInt32(0),
                        OrdersNumber = MyReader.GetString(1),
                        NickName = MyReader.GetString(2),
                        BuyerName = MyReader.GetString(3),
                        Mobile = MyReader.GetString(4),
                        Phone = MyReader.GetString(5),
                        BuyerEmail = MyReader.GetString(6)
                    };
                }
            }

            return Buyer == null ? new tbBuyerInfo() : Buyer;
        }

        public bool Insert(tbBuyerInfo Buyer)
        {
            bool IsOk = false;

            IDbDataParameter[] parm = GetInsertParam();
            parm[0].Value = Buyer.OrdersNumber;
            parm[1].Value = Buyer.NickName;
            parm[2].Value = Buyer.BuyerName;
            parm[3].Value = Buyer.Mobile;
            parm[4].Value = Buyer.Phone;
            parm[5].Value = Buyer.BuyerEmail;

            try
            {
                DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_INSERT, parm);
                IsOk = true;
            }
            catch { }

            return IsOk;
        }

        public bool InsertListBuyerInfo(List<tbBuyerInfo> listBuyer)
        {
            bool Result = false;
            try
            {
                //新建一张datatable
                DataTable dt = new DataTable("tbBuyerInfo_temp");
                DataColumn dc = null;


                dc = dt.Columns.Add("OrdersNumber", Type.GetType("System.String"));
                dc = dt.Columns.Add("NickName", Type.GetType("System.String"));
                dc = dt.Columns.Add("BuyerName", Type.GetType("System.String"));
                dc = dt.Columns.Add("Mobile", Type.GetType("System.String"));
                dc = dt.Columns.Add("Phone", Type.GetType("System.String"));
                dc = dt.Columns.Add("BuyerEmail", Type.GetType("System.String"));
                if (listBuyer != null)
                {
                    foreach (tbBuyerInfo BuyerInfo in listBuyer)
                    {
                        dt.Rows.Add(new object[]{
                          BuyerInfo.OrdersNumber,BuyerInfo.NickName,BuyerInfo.BuyerName,
                          BuyerInfo.Mobile,BuyerInfo.Phone,BuyerInfo.BuyerEmail
                          });
                    }
                    SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(DBHelper.ConnectionStr);
                    //要插入数据库的名称
                    sqlBulkCopy.DestinationTableName = "tbBuyerInfo_temp";

                    if (dt != null && dt.Rows.Count != 0)
                    {
                        sqlBulkCopy.WriteToServer(dt);
                    }
                    sqlBulkCopy.Close();
                    string SqlStr = string.Format(@" 
                                                  update [dbo].[tbBuyerInfo]  ---更新存在相同点数据
                                                   set [OrdersNumber]=B.OrdersNumber
                                                      ,[NickName]=B.NickName
                                                      ,[BuyerName]=B.BuyerName
                                                      ,[Mobile]=B.Mobile
                                                      ,[Phone]=B.Phone
                                                      ,[BuyerEmail]=B.BuyerEmail
                                                   from [dbo].[tbBuyerInfo] A,[dbo].[tbBuyerInfo_temp] B 
                                                   where  B.OrdersNumber=A.OrdersNumber 
                                                   and  B.NowDay >= convert(varchar(10),getdate(),120);                                               
                                                   ---插入不存在相同点数据
                                                   insert into [dbo].[tbBuyerInfo] 
                                                 (	  [OrdersNumber]
                                                      ,[NickName]
                                                      ,[BuyerName]
                                                      ,[Mobile]
                                                      ,[Phone]
                                                      ,[BuyerEmail])
                                                 select [OrdersNumber]
                                                      ,[NickName]
                                                      ,[BuyerName]
                                                      ,[Mobile]
                                                      ,[Phone]
                                                      ,[BuyerEmail]
                                                 from [dbo].[tbBuyerInfo_temp] A 
                                                 where   not exists(
                                                 select [OrdersNumber]
                                                 from [dbo].[tbBuyerInfo] B
                                                 where B.OrdersNumber= A.OrdersNumber)
                                                 and  A.NowDay >= convert(varchar(10),getdate(),120);
                                        ");

                    if (DBHelper.ExecuteNonQuery(CommandType.Text, SqlStr) > 0)
                        Result = true;

                }
            }
            catch (Exception EX)
            {
                Result = false;
                throw EX;
            }
            return Result;

                    
        }

        private static IDbDataParameter[] GetSelectNumberParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_SELECT);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_NUMBER,SqlDbType.VarChar,50)
                };

                DBHelper.CacheParameters(SQL_SELECT, parm);
            }

            return parm;
        }

        private static IDbDataParameter[] GetInsertParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_INSERT);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_NUMBER,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_NNAME,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_NAME,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_MOBILE,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_PHONE,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_EMAIL,SqlDbType.VarChar,50)
                };

                DBHelper.CacheParameters(SQL_INSERT, parm);
            }

            return parm;
        }
    }
}
