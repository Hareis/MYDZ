using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Config.DataBase;
using System.Configuration;
using MYDZ.Interface;
using System.Reflection;

namespace MYDZ.DALFactory
{
    public sealed class DataAccess
    {
        private static readonly DataBaseConfig Config = DBConfigs.GetConfig();

        private static readonly string[] path = (Config.DataBaseType == DbType.ACCESS ? ConfigurationManager.AppSettings["ACCESS"] : Config.DataBaseType == DbType.MYSQL ? ConfigurationManager.AppSettings["MYSQL"] : Config.DataBaseType == DbType.SQLSERVER ? ConfigurationManager.AppSettings["SQLSERVER"] : ConfigurationManager.AppSettings["ORACLE"]).Split(',');

        public static BaseInterface Create(string ClsName) {
            string ClassName = path[1] + "." + ClsName;
            return (BaseInterface)Assembly.Load(path[0]).CreateInstance(ClassName);
        }
    }
}
