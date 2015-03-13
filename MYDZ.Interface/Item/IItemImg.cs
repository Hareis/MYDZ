using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Goods;

namespace MYDZ.Interface.Item
{
    public interface IItemImg : BaseInterface
    {
       /// <summary>
       /// 增加数据
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       bool AddItemImg(ItemImg model);

       /// <summary>
       /// 更新数据
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       bool UpdateItemImg(ItemImg model);

       /// <summary>
       /// 删除一行数据
       /// </summary>
       /// <param name="ItemImgID"></param>
       /// <returns></returns>
       bool DeleteItemImg(string ItemImgID);

       /// <summary>
       /// 获得一行数据
       /// </summary>
       /// <param name="ItemImgID"></param>
       /// <returns></returns>
       IList<ItemImg> GetItemImg(string ItemImgID);
    }
}
