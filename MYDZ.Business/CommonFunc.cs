using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Config;
using System.Collections;
using System.Text.RegularExpressions;

namespace MYDZ.Business
{
    /// <summary>
    /// 仅存在业务逻辑层
    /// </summary>
    internal class CommonFunc
    {
        public static Hashtable GetDataCache(string UserId)
        {
            return (Hashtable)DataCache.GetCache("UserInfo" + UserId);
        }
        /// <summary>
        /// 檢查是否是商品數字ID
        /// </summary>
        /// <returns></returns>
        public static bool CheckListGoodsId(string ListNumIids)
        {
            bool Result = false;
            try
            {
                Regex reg1 = new Regex(@"^[0-9,]+$");
                if (reg1.IsMatch(ListNumIids))
                {
                    Result = true;
                }
                return Result;
            }
            catch (Exception ex)
            {
                return Result;
            }

        }
    }
}
