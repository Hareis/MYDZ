using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Item;
using MYDZ.Entity.Goods;

namespace MYDZ.Business.DataBase_BLL.GoodsBLL
{
    public class BMpicVideo
    {
        public static IMpicVideo SetMpicVideo = (IMpicVideo)DALFactory.DataAccess.Create("Item.MpicVideo");

        /// <summary>
        /// 添加一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddMpicVideo(MpicVideo model)
        {
            return SetMpicVideo.AddMpicVideo(model);
        }

        /// <summary>
        /// 更新一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateMpicVideo(MpicVideo model)
        {
            return SetMpicVideo.UpdateMpicVideo(model);
        }

        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="MpicVideoID"></param>
        /// <returns></returns>
        bool DeleteMpicVideo(string MpicVideoID)
        {
            return SetMpicVideo.DeleteMpicVideo(MpicVideoID);
        }

        /// <summary>
        /// 获取一行数据
        /// </summary>
        /// <param name="MpicVideoID"></param>
        /// <returns></returns>
        IList<MpicVideo> GetMpicVideo(string MpicVideoID)
        {
            return SetMpicVideo.GetMpicVideo(MpicVideoID);
        }

    }
}
