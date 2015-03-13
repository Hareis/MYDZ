using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Item;
using MYDZ.Entity.Goods;

namespace MYDZ.Business.DataBase_BLL.GoodsBLL
{
    public class BPropImg
    {
        public static IPropImg SetPropImg = (IPropImg)DALFactory.DataAccess.Create("Item.PropImg");

        /// <summary>
        /// 添加一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddPropImg(PropImg model)
        {
            return SetPropImg.AddPropImg(model);
        }

        /// <summary>
        /// 更新一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdatePropImg(PropImg model)
        {
            return SetPropImg.UpdatePropImg(model);
        }

        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="PropImgId"></param>
        /// <returns></returns>
        bool DeletePropImg(string PropImgId)
        {
            return SetPropImg.DeletePropImg(PropImgId);
        }

        /// <summary>
        /// 获取一行数据
        /// </summary>
        /// <param name="PropImgId"></param>
        /// <returns></returns>
        IList<PropImg> GetPropImg(string PropImgId)
        {
            return SetPropImg.GetPropImg(PropImgId);
        }
    }
}
