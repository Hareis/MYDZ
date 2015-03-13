using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Goods;

namespace MYDZ.Interface.Item
{
    public interface IPropImg : BaseInterface
    {
        /// <summary>
        /// 添加一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddPropImg(PropImg model);

        /// <summary>
        /// 更新一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdatePropImg(PropImg model);

        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="PropImgId"></param>
        /// <returns></returns>
        bool DeletePropImg(string PropImgId);

        /// <summary>
        /// 获取一行数据
        /// </summary>
        /// <param name="PropImgId"></param>
        /// <returns></returns>
        IList<PropImg> GetPropImg(string PropImgId);

    }
}
