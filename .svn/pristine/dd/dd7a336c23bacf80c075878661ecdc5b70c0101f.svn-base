using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Print;
using MYDZ.Interface.Print;
using MYDZ.DALFactory;

namespace MYDZ.Business.DataBase_BLL.Print
{
    public class PrintContent
    {
        private static readonly IPrintContent PrintContentDal = DataAccess.Create("Print.PrintContent") as IPrintContent;

        /// <summary>
        /// 查询打印内容信息列表
        /// </summary>
        /// <returns></returns>
        public static IList<tbPrintContent> Select() {
            return PrintContentDal.Select();
        }

        /// <summary>
        /// 根据显示状态查询打印内容信息列表
        /// </summary>
        /// <param name="Display">显示状态</param>
        /// <returns></returns>
        public static IList<tbPrintContent> SelectByDisplay(bool Display = true) {
            return PrintContentDal.SelectByDisplay(Display);
        }

        /// <summary>
        /// 根据父类编号查询打印内容信息列表
        /// </summary>
        /// <param name="ParentId">父类编号</param>
        /// <returns></returns>
        public static IList<tbPrintContent> SelectByParentId(int ParentId) {
            return PrintContentDal.SelectByParentId(ParentId);
        }

        /// <summary>
        /// 根据父类编号和显示状态查询打印内容信息列表
        /// </summary>
        /// <param name="ParentId">父类编号</param>
        /// <param name="Display">显示状态</param>
        /// <returns></returns>
        public static IList<tbPrintContent> SelectByParentIdAndDisplay(int ParentId, bool Display = true) {
            return PrintContentDal.SelectByParentIdAndDisplay(ParentId, Display);
        }

        /// <summary>
        /// 根据打印编号列表查询打印内容信息列表
        /// </summary>
        /// <param name="IdList">打印编号列表</param>
        /// <returns></returns>
        public static IList<tbPrintContent> Select(string IdList) {
            return PrintContentDal.Select(IdList);
        }
    }
}
