using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Order;

namespace MYDZ.Interface.Order
{
    public interface IConfigDetail : BaseInterface
    {
        /// <summary>
        /// 根据配置编号查询订单获取配置详情信息列表
        /// </summary>
        /// <param name="ConfigId">配置编号</param>
        /// <returns></returns>
        IList<tbConfigDetail> Select(int ConfigId);

        /// <summary>
        /// 添加订单获取配置详情信息
        /// </summary>
        /// <param name="ConfigDetail">订单获取详情信息表</param>
        /// <returns></returns>
        bool Insert(tbConfigDetail ConfigDetail);

        /// <summary>
        /// 根据配置编号删除订单获取配置详情信息
        /// </summary>
        /// <param name="ConfigId">配置编号</param>
        /// <returns></returns>
        bool Delete(int ConfigId);
    }
}
