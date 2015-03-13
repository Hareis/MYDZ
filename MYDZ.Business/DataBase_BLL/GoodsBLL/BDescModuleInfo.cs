using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Item;
using MYDZ.Entity.Goods;

namespace MYDZ.Business.DataBase_BLL.GoodsBLL
{
    public class BDescModuleInfo
    {
        public static IDescModuleInfo SetDescModuleInfo = (IDescModuleInfo)DALFactory.DataAccess.Create("Item.DescModuleInfo");
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int AddDescModuleInfo(DescModuleInfo model)
        {
            return SetDescModuleInfo.AddDescModuleInfo(model);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateDescModuleInfo(DescModuleInfo model)
        {
            return SetDescModuleInfo.UpdateDescModuleInfo(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="DescModuleInfoID"></param>
        void DeleteDescModuleInfo(string DescModuleInfoID)
        {
            SetDescModuleInfo.DeleteDescModuleInfo(DescModuleInfoID);
        }

        /// <summary>
        /// 得到一条数据
        /// </summary>
        /// <param name="DescModuleInfoID"></param>
        /// <returns></returns>
        IList<DescModuleInfo> GetDescModuleInfo(string DescModuleInfoID)
        {
            return SetDescModuleInfo.GetDescModuleInfo(DescModuleInfoID);
        }
    }
}
