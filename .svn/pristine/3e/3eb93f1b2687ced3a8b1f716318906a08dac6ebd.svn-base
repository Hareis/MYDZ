using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.ClientUser;

namespace MYDZ.Interface.ClientUser
{
    public interface IClientUserCredit : BaseInterface
    {
       /// <summary>
       /// 插入一条数据
       /// </summary>
       /// <param name="UserCredit"></param>
       /// <returns></returns>
       int InsertUserCredit(tbClientUserCredit UserCredit);
       /// <summary>
       /// 更新用户信用
       /// </summary>
       /// <param name="UserCredit"></param>
       /// <returns></returns>
       bool UpdateUserCredit(tbClientUserCredit UserCredit);
       /// <summary>
       /// 查询用户信用（by CreditId）
       /// </summary>
       /// <param name="CreditId"></param>
       /// <returns></returns>
       tbClientUserCredit SelectUserCreditByCreditId(string CreditId);
    }
}
