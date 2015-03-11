using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Print;

namespace MYDZ.Interface.Print
{
    public interface IPrintPlaneSingle : BaseInterface
    {
        /// <summary>
        /// 根据物流编号和用户编号查询打印面单模板信息
        /// </summary>
        /// <param name="LogisticsId">物流编号</param>
        /// <param name="UserId">用户编号</param>
        /// <returns></returns>
        tbPrintPlaneSingle Select(int LogisticsId, int UserId);

        /// <summary>
        /// 根据用户编号和模板状态查询打印面单模板信息
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <param name="IsSingle">是否面单模板</param>
        /// <returns></returns>
        tbPrintPlaneSingle Select(int UserId, bool IsSingle);

        /// <summary>
        /// 添加打印面单模板信息
        /// </summary>
        /// <param name="PrintPlaneSingle">打印面单模板信息表</param>
        /// <returns></returns>
        int Insert(tbPrintPlaneSingle PrintPlaneSingle);

        /// <summary>
        /// 修改打印面单模板信息
        /// </summary>
        /// <param name="PrintPlaneSingle">打印面单模板信息表</param>
        /// <returns></returns>
        bool Update(tbPrintPlaneSingle PrintPlaneSingle);

        /// <summary>
        /// 根据打印面单模板编号删除打印单面模板信息
        /// </summary>
        /// <param name="PlaneId">打印面单模板编号</param>
        /// <returns></returns>
        bool Delete(int PlaneId);
    }
}
