using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Order;
using MYDZ.DALFactory;
using MYDZ.Entity.Order;

namespace MYDZ.Business.DataBase_BLL.Order
{
    public class OtherConfig
    {
        private static readonly IOtherConfig OtherConfigDal = DataAccess.Create("Order.OtherConfig") as IOtherConfig;

        /// <summary>
        /// 查询系统其他设置信息
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <returns></returns>
        public static tbOtherConfig Select(int UserId) {
            return OtherConfigDal.Select(UserId);
        }

        /// <summary>
        /// 保存系统其他设置信息
        /// </summary>
        /// <param name="OtherConfig">系统其他设置信息</param>
        /// <returns></returns>
        public static bool Save(tbOtherConfig OtherConfig) {
            return OtherConfigDal.Save(OtherConfig);
        }
    }
}
