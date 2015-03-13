using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Print;
using MYDZ.Interface.Print;
using MYDZ.DALFactory;

namespace MYDZ.Business.DataBase_BLL.Print
{
    public class PrintPlaneSingle
    {
        private static readonly IPrintPlaneSingle PrintPlaneSingleDal = DataAccess.Create("Print.PrintPlaneSingle") as IPrintPlaneSingle;

        /// <summary>
        /// 根据物流编号和用户编号查询打印面单模板信息
        /// </summary>
        /// <param name="LogisticsId">物流编号</param>
        /// <param name="UserId">用户编号</param>
        /// <returns></returns>
        public static tbPrintPlaneSingle Select(int LogisticsId, int UserId) {
            return PrintPlaneSingleDal.Select(LogisticsId, UserId);
        }

        /// <summary>
        /// 根据用户编号和模板状态查询打印面单模板信息
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <param name="IsSingle">是否面单模板</param>
        /// <returns></returns>
        public static tbPrintPlaneSingle Select(int UserId, bool IsSingle) {
            return PrintPlaneSingleDal.Select(UserId, IsSingle);
        }

        /// <summary>
        /// 添加打印面单模板信息
        /// </summary>
        /// <param name="PrintPlaneSingle">打印面单模板信息表</param>
        /// <returns></returns>
        public static int Insert(tbPrintPlaneSingle PrintPlaneSingle) {
            return PrintPlaneSingleDal.Insert(PrintPlaneSingle);
        }

        /// <summary>
        /// 修改打印面单模板信息
        /// </summary>
        /// <param name="PrintPlaneSingle">打印面单模板信息表</param>
        /// <returns></returns>
        public static bool Update(tbPrintPlaneSingle PrintPlaneSingle) {
            return PrintPlaneSingleDal.Update(PrintPlaneSingle);
        }

        /// <summary>
        /// 根据打印面单模板编号删除打印单面模板信息
        /// </summary>
        /// <param name="PlaneId">打印面单模板编号</param>
        /// <returns></returns>
        public static bool Delete(int PlaneId) {
            return PrintPlaneSingleDal.Delete(PlaneId);
        }
    }
}
