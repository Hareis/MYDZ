﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Goods;

namespace MYDZ.Interface.Item
{
    public interface ISkus : BaseInterface
    {
        /// <summary>
        /// 添加一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddSkus(Skus model);

        /// <summary>
        /// 更新一行数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateSkus(Skus model);
        
        /// <summary>
        ///删除一行数据
        /// </summary>
        /// <param name="SkusId"></param>
        /// <returns></returns>
        bool DeleteSkus(string SkusId);

        /// <summary>
        /// 获取一行数据
        /// </summary>
        /// <param name="SkusId"></param>
        /// <returns></returns>
        IList<Skus> GetSkus(string SkusId);
    }
}
