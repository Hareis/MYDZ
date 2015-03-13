using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Item;
using MYDZ.Entity.Goods;

namespace MYDZ.Business.DataBase_BLL.GoodsBLL
{
    public class BVideo
    {
        public static IVideo SetVideo = (IVideo)DALFactory.DataAccess.Create("Item.Video");

        /// <summary>
        /// 添加一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddVideo(Video model)
        {
            return SetVideo.AddVideo(model);
        }

        /// <summary>
        /// 更新一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateVideo(Video model)
        {
            return SetVideo.UpdateVideo(model);
        }

        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="Video_Id"></param>
        /// <returns></returns>
        bool DeleteVideo(string Video_Id)
        {
            return SetVideo.DeleteVideo(Video_Id);
        }

        /// <summary>
        /// 获取一行数据
        /// </summary>
        /// <param name="Video_Id"></param>
        /// <returns></returns>
        IList<Video> GetVideo(string Video_Id)
        {
            return SetVideo.GetVideo(Video_Id);
        }
    }
}
