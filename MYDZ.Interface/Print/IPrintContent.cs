using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Print;

namespace MYDZ.Interface.Print
{
    public interface IPrintContent : BaseInterface
    {
        /// <summary>
        /// 查询打印内容信息列表
        /// </summary>
        /// <returns></returns>
        IList<tbPrintContent> Select();

        /// <summary>
        /// 根据显示状态查询打印内容信息列表
        /// </summary>
        /// <param name="Display">显示状态</param>
        /// <returns></returns>
        IList<tbPrintContent> SelectByDisplay(bool Display);

        /// <summary>
        /// 根据父类编号查询打印内容信息列表
        /// </summary>
        /// <param name="ParentId">父类编号</param>
        /// <returns></returns>
        IList<tbPrintContent> SelectByParentId(int ParentId);

        /// <summary>
        /// 根据父类编号和显示状态查询打印内容信息列表
        /// </summary>
        /// <param name="ParentId">父类编号</param>
        /// <param name="Display">显示状态</param>
        /// <returns></returns>
        IList<tbPrintContent> SelectByParentIdAndDisplay(int ParentId, bool Display);

        /// <summary>
        /// 根据打印编号列表查询打印内容信息列表
        /// </summary>
        /// <param name="IdList">打印编号列表</param>
        /// <returns></returns>
        IList<tbPrintContent> Select(string IdList);
    }
}
