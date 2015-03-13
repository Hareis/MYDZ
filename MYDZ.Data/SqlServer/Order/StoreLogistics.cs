using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Order;
using System.Data;
using MYDZ.DBUtility;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MYDZ.Data.SqlServer.Order
{
    internal class StoreLogistics : IStoreLogistics
    {
        private const string SQL_SELECT_SID = "SelectShopLogisticsByShopId";                                                //根据店铺编号查询店铺物流关系信息列表
        private const string SQL_SELECT_IDLIST = "SelectShopLogisticsByIdList";                                             //根据店铺编号列表查询店铺物流编号列表
        private const string SQL_SELECT_INFO = "SelectShopLogisticsInfo";                                                   //根据店铺编号查询店铺物流关系信息和物流信息列表
        private const string SQL_SELECT_UID = "SelectShopLogisticsByUserId";                                                //根据用户编号查询店铺物流关系信息和物流信息列表
        private const string SQL_INSERT = "InsertShopLogistics";                                                            //添加店铺物流关系信息
        private const string SQL_DELETE_SID = "DeleteShopLogisticsByShopId";                                                //根据店铺编号删除店铺物流关系信息

        private const string PARM_SID = "@ShopId";                                                                          //店铺编号
        private const string PARM_LID = "@LogisticsId";                                                                     //物流编号
        private const string PARM_SORT = "@Sort";                                                                           //排序字段
        private const string PARM_NUMBER = "@Number";                                                                       //打印数量
        private const string PARM_UID = "@UserId";                                                                          //用户编号
        private const string PARM_IDLIST = "@IdList";                                                                       //店铺编号列表

        public IList<Entity.Order.StoreLogistics> Select(int ShopId)
        {
            IList<Entity.Order.StoreLogistics> MyList = new List<Entity.Order.StoreLogistics>();
            //IDbDataParameter[] parm = GetSelectBySIdParam();
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_SELECT_SID);
            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_SID,SqlDbType.Int)
                };
                DBHelper.CacheParameters(SQL_SELECT_SID, parm);
            }
            parm[0].Value = ShopId;
            using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_SID, parm))
            {
                while (MyReader.Read())
                {
                    MyList.Add(new Entity.Order.StoreLogistics()
                    {
                        SLID = MyReader.GetInt32(0),
                        ShopId = MyReader.GetInt32(1),
                        LogisticsId = MyReader.GetInt32(2),
                        Sort = MyReader.GetInt32(3),
                        Number = MyReader.GetInt32(4)
                    });
                }
            }

            return MyList;
        }

        public string Select(string IdList)
        {
            List<string> MyList = new List<string>();
            //IDbDataParameter[] parm = GetSelectByIdListParam();
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_SELECT_IDLIST);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_IDLIST,SqlDbType.VarChar,5000)
                };

                DBHelper.CacheParameters(SQL_SELECT_IDLIST, parm);
            }

            parm[0].Value = IdList;

            using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_IDLIST, parm))
            {
                while (MyReader.Read())
                {
                    MyList.Add(MyReader.GetInt32(0).ToString());
                }
            }

            return String.Join(",", MyList);
        }

        public IList<Entity.Order.StoreLogistics> SelectInfo(int ShopId)
        {
            IList<Entity.Order.StoreLogistics> MyList = new List<Entity.Order.StoreLogistics>();
            //IDbDataParameter[] parm = GetSelectInfoParam();
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_SELECT_INFO);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_SID,SqlDbType.Int)
                };

                DBHelper.CacheParameters(SQL_SELECT_INFO, parm);
            }
            parm[0].Value = ShopId;

            using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_INFO, parm))
            {
                while (MyReader.Read())
                {
                    MyList.Add(new Entity.Order.StoreLogistics()
                    {
                        SLID = MyReader.GetInt32(0),
                        ShopId = MyReader.GetInt32(1),
                        Logistics = new Entity.Order.Logistic()
                        {
                            LogisticsId = MyReader.GetInt32(2),
                            LogisticsName = MyReader.GetString(3),
                            LogisticsCode = MyReader.GetString(4),
                            LogisticsImg = MyReader.GetString(5),
                            LogisticsWdith = MyReader.GetInt32(6),
                            LogisticsHeight = MyReader.GetInt32(7)
                        },
                        Sort = MyReader.GetInt32(8),
                        Number = MyReader.GetInt32(9)
                    });
                }
            }

            return MyList;
        }

        public IList<Entity.Order.StoreLogistics> SelectByUser(int UserId)
        {
            IList<Entity.Order.StoreLogistics> MyList = new List<Entity.Order.StoreLogistics>();
            //IDbDataParameter[] parm = GetSelectByUserIdParam();
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_SELECT_UID);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_UID,SqlDbType.Int)
                };

                DBHelper.CacheParameters(SQL_SELECT_UID, parm);
            }

            parm[0].Value = UserId;

            using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_UID, parm))
            {
                while (MyReader.Read())
                {
                    MyList.Add(new Entity.Order.StoreLogistics()
                    {
                        SLID = MyReader.GetInt32(0),
                        ShopId = MyReader.GetInt32(1),
                        Logistics = new Entity.Order.Logistic()
                        {
                            LogisticsId = MyReader.GetInt32(2),
                            LogisticsName = MyReader.GetString(3),
                            LogisticsCode = MyReader.GetString(4),
                            LogisticsImg = MyReader.GetString(5),
                            LogisticsWdith = MyReader.GetInt32(6),
                            LogisticsHeight = MyReader.GetInt32(7)
                        },
                        Sort = MyReader.GetInt32(8),
                        Number = MyReader.GetInt32(9)
                    });
                }
            }
            return MyList;
        }

        public bool Insert(List<Entity.Order.StoreLogistics> ListShopLogistics)
        {
            bool IsOk = false;
            try
            {
                if (ListShopLogistics != null)
                {
                    string StrSql = string.Format("delete from tbShopLogistics where ShopId={0}", ListShopLogistics[0].ShopId);
                    if (DBHelper.ExecuteNonQuery(CommandType.Text, StrSql) > -1)
                    {
                        IsOk = SqlBulkCopyInsert(ListShopLogistics);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return IsOk;
        }


        /// <summary>  
        /// 使用SqlBulkCopy方式插入数据  
        /// </summary>  
        /// <returns></returns>  
        private static bool SqlBulkCopyInsert(List<Entity.Order.StoreLogistics> ListShopLogistics)
        {
            try
            {
                //新建一张datatable
                DataTable dt = new DataTable("tbShopLogistics");

                DataColumn dc = null;
                dc = dt.Columns.Add("SLID", Type.GetType("System.Int32"));
                dc.AutoIncrement = true;//自动增加
                dc.AutoIncrementSeed = 1;//起始为1
                dc.AutoIncrementStep = 1;//步长为1
                dc.AllowDBNull = false;//
                //新建列
                dc = dt.Columns.Add("ShopId", Type.GetType("System.Int32"));
                dc = dt.Columns.Add("LogisticsId", Type.GetType("System.Int32"));
                dc = dt.Columns.Add("Sort", Type.GetType("System.Int32"));
                dc = dt.Columns.Add("Number", Type.GetType("System.Int32"));

                foreach (Entity.Order.StoreLogistics item in ListShopLogistics)
                {
                    dt.Rows.Add(new object[] { null, item.ShopId, item.LogisticsId, item.Sort, item.Number });
                }
                SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(DBHelper.ConnectionStr);
                //要插入数据库的名称
                sqlBulkCopy.DestinationTableName = "tbShopLogistics";

                if (dt != null && dt.Rows.Count != 0)
                {
                    sqlBulkCopy.WriteToServer(dt);
                }
                sqlBulkCopy.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        public bool Delete(int ShopId)
        {
            bool IsOk = false;

            //IDbDataParameter[] parm = GetDeleteBySIdParam();
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_DELETE_SID);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_SID,SqlDbType.Int)
                };

                DBHelper.CacheParameters(SQL_DELETE_SID, parm);
            }

            parm[0].Value = ShopId;

            try
            {
                DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_DELETE_SID, parm);
                IsOk = true;
            }
            catch { }

            return IsOk;
        }
    }
}
