using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.Order
{
    /// <summary>
    /// 物流公司信息
    /// </summary>
    [Serializable]
    public class DeliveryCompany : Response
    {
        /// <summary>
        /// 物流公司编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 物流公司编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 物流公司名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }
    }
}
