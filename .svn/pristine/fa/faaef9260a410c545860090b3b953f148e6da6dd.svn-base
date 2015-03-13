using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Item;
using MYDZ.Entity.Goods;

namespace MYDZ.Business.DataBase_BLL.GoodsBLL
{
    public class BItemImg
    {
        public static IItemImg SetItemImg = (IItemImg)DALFactory.DataAccess.Create("Item.ItemImg");
        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddItemImg(ItemImg model)
        {
            return SetItemImg.AddItemImg(model);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateItemImg(ItemImg model)
        {
            return SetItemImg.UpdateItemImg(model);
        }

        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="ItemImgID"></param>
        /// <returns></returns>
        bool DeleteItemImg(string ItemImgID)
        {
            return SetItemImg.DeleteItemImg(ItemImgID);
        }

        /// <summary>
        /// 获得一行数据
        /// </summary>
        /// <param name="ItemImgID"></param>
        /// <returns></returns>
        IList<ItemImg> GetItemImg(string ItemImgID)
        {
            return SetItemImg.GetItemImg(ItemImgID);
        }
    }
}
