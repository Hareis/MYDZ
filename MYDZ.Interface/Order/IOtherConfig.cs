using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Order;

namespace MYDZ.Interface.Order
{
    public interface IOtherConfig : BaseInterface
    {
        /// <summary>
        /// 查询系统其他设置信息
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <returns></returns>
        tbOtherConfig Select(int UserId);

        /// <summary>
        /// 保存系统其他设置信息
        /// </summary>
        /// <param name="OtherConfig">系统其他设置信息</param>
        /// <returns></returns>
        bool Save(tbOtherConfig OtherConfig);
    }
}
