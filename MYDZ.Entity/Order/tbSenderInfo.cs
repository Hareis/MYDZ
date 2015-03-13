using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.Order
{
    [Serializable]
    public class tbSenderInfo : Response
    {
        /// <summary>
        /// 寄件人编号
        /// </summary>
        public int SenderId { get; set; }

        /// <summary>
        /// 店铺编号
        /// </summary>
        public int ShopId { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 寄件人名称
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// 寄件人电话
        /// </summary>
        public string SenderTel { get; set; }

        /// <summary>
        /// 寄件人手机
        /// </summary>
        public string SenderMobile { get; set; }

        /// <summary>
        /// 寄件人地址
        /// </summary>
        public string SenderAdd { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区/县
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// 商家编码
        /// </summary>
        public string ShopCode { get; set; }
    }
}
