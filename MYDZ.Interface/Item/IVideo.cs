using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Goods;

namespace MYDZ.Interface.Item
{
    public interface IVideo : BaseInterface
    {
        /// <summary>
        /// 添加一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddVideo(Video model);

        /// <summary>
        /// 更新一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateVideo(Video model);

        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="Video_Id"></param>
        /// <returns></returns>
        bool DeleteVideo(string Video_Id);

        /// <summary>
        /// 获取一行数据
        /// </summary>
        /// <param name="Video_Id"></param>
        /// <returns></returns>
        IList<Video> GetVideo(string Video_Id);
    }
}
