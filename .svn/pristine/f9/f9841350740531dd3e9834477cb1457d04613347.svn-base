using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Item;
using MYDZ.Entity.Goods;

namespace MYDZ.Business.DataBase_BLL.GoodsBLL
{
    public class BPaimaiInfo
    {
        public static IPaimaiInfo SetPaimaiInfo = (IPaimaiInfo)DALFactory.DataAccess.Create("Item.PaimaiInfo");
        /// <summary>
        /// 添加一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddPaimaiInfo(PaimaiInfo model)
        {
            return SetPaimaiInfo.AddPaimaiInfo(model);
        }

        /// <summary>
        /// 更新一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdatePaimaiInfo(PaimaiInfo model)
        {
            return SetPaimaiInfo.UpdatePaimaiInfo(model);
        }

        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="PaimaiInfoId"></param>
        /// <returns></returns>
        bool DeletePaimaiInfo(string PaimaiInfoId)
        {
            return SetPaimaiInfo.DeletePaimaiInfo(PaimaiInfoId);
        }

        /// <summary>
        /// 获得一行数据
        /// </summary>
        /// <param name="PaimaiInfoId"></param>
        /// <returns></returns>
        IList<PaimaiInfo> GetPaimaiInfo(string PaimaiInfoId)
        {
            return SetPaimaiInfo.GetPaimaiInfo(PaimaiInfoId);
        }
    }
}
