using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.ClientUser;

namespace MYDZ.Interface.ClientUser
{
    public interface IClientUserLevel : BaseInterface
    {
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int InsertUserLevel(tbClientUserLevel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateUserLevel(tbClientUserLevel model);
    }
}
