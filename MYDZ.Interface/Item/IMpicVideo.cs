using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Goods;

namespace MYDZ.Interface.Item
{
    public interface IMpicVideo : BaseInterface
    {
        /// <summary>
        /// 添加一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddMpicVideo(MpicVideo model);

        /// <summary>
        /// 更新一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateMpicVideo(MpicVideo model);

        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="MpicVideoID"></param>
        /// <returns></returns>
        bool DeleteMpicVideo(string MpicVideoID);

        /// <summary>
        /// 获取一行数据
        /// </summary>
        /// <param name="MpicVideoID"></param>
        /// <returns></returns>
        IList<MpicVideo> GetMpicVideo(string MpicVideoID);
    }
}
