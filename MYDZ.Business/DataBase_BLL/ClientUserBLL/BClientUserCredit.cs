using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.ClientUser;
using MYDZ.Entity.ClientUser;

namespace MYDZ.Business.DataBase_BLL.ClientUserBLL
{
    public class BClientUserCredit
    {
        public static IClientUserCredit SetUserInfo = (IClientUserCredit)DALFactory.DataAccess.Create("ClientUser.ClientUserCredit");

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="UserCredit"></param>
        /// <returns></returns>
        public static int InsertUserCredit(tbClientUserCredit UserCredit)
        {
            return SetUserInfo.InsertUserCredit(UserCredit);
        }
        /// <summary>
        /// 更新用户信用
        /// </summary>
        /// <param name="UserCredit"></param>
        /// <returns></returns>
        public static bool UpdateUserCredit(tbClientUserCredit UserCredit)
        {
            return SetUserInfo.UpdateUserCredit(UserCredit);
        }
        /// <summary>
        /// 查询用户信用（by CreditId）
        /// </summary>
        /// <param name="CreditId"></param>
        /// <returns></returns>
        public static tbClientUserCredit SelectUserCreditByCreditId(string CreditId)
        {
            return SetUserInfo.SelectUserCreditByCreditId(CreditId);
        }
    }
}
