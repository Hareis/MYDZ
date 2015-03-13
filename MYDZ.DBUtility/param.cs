using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MYDZ.DBUtility.DbProvider;

namespace MYDZ.DBUtility
{
    public class param
    {
        /// <summary>
        /// 分页存储过程
        /// </summary>
        public const string SQL_PAGE_SELECT = "PageCurrent";                                                    //查询分页信息

        private const string PARM_TABLENAME = "@TableName";                                                     //表名
        private const string PARM_FIELD = "@Fields";                                                            //字段名(全部字段为*)
        private const string PARM_ORDERFIELD = "@OrderField";                                                   //排序字段(必须!支持多字段)
        private const string PARM_WHERE = "@sqlWhere";                                                          //条件语句(不用加where)
        private const string PARM_PAGESIZE = "@pageSize";                                                       //每页多少条记录
        private const string PARM_PAGEINDEX = "@pageIndex";                                                     //指定当前为第几页
        private const string PARM_DISTINCT = "@distinct";                                                       //去除重复值，注意只能是一个字段
        private const string PARM_TOP = "@top";                                                                 //查询TOP,不传为全部

        public static IDbDataParameter[] GetSearchPageParam() {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_PAGE_SELECT);

            if (parm == null) {
                parm = new IDbDataParameter[] {
                    DBFactory.CreateParameter(PARM_TABLENAME, DbType.AnsiString, 5000),
                    DBFactory.CreateParameter(PARM_FIELD, DbType.AnsiString, 5000),
                    DBFactory.CreateParameter(PARM_ORDERFIELD, DbType.AnsiString, 5000),
                    DBFactory.CreateParameter(PARM_WHERE, DbType.AnsiString, 5000),
                    DBFactory.CreateParameter(PARM_PAGESIZE, DbType.Int32),
                    DBFactory.CreateParameter(PARM_PAGEINDEX, DbType.Int32),
                    DBFactory.CreateParameter(PARM_DISTINCT, DbType.AnsiString, 50),
                    DBFactory.CreateParameter(PARM_TOP, DbType.Int32)
                };

                DBHelper.CacheParameters(SQL_PAGE_SELECT, parm);
            }

            return parm;
        }
    }
}
