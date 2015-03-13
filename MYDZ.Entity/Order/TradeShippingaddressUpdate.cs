using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.Order
{
    /// <summary>
    /// 更改交易的收货地址 请求类
    /// </summary>
    public class TradeShippingaddressUpdate:Response
    {
        /// <summary>
        /// 收货地址。最大长度为228个字节。<br /> 支持最大长度为：228<br /> 支持的最大列表长度为：228
        /// </summary>
        public string ReceiverAddress { get; set; }

        /// <summary>
        /// 城市。最大长度为32个字节。如：杭州<br /> 支持最大长度为：32<br /> 支持的最大列表长度为：32
        /// </summary>
        public string ReceiverCity { get; set; }

        /// <summary>
        /// 区/县。最大长度为32个字节。如：西湖区<br /> 支持最大长度为：32<br /> 支持的最大列表长度为：32
        /// </summary>
        public string ReceiverDistrict { get; set; }

        /// <summary>
        /// 移动电话。最大长度为30个字节。<br /> 支持最大长度为：30<br /> 支持的最大列表长度为：30
        /// </summary>
        public string ReceiverMobile { get; set; }

        /// <summary>
        /// 收货人全名。最大长度为50个字节。<br /> 支持最大长度为：50<br /> 支持的最大列表长度为：50
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// 固定电话。最大长度为30个字节。<br /> 支持最大长度为：30<br /> 支持的最大列表长度为：30
        /// </summary>
        public string ReceiverPhone { get; set; }

        /// <summary>
        /// 省份。最大长度为32个字节。如：浙江<br /> 支持最大长度为：32<br /> 支持的最大列表长度为：32
        /// </summary>
        public string ReceiverState { get; set; }

        /// <summary>
        /// 邮政编码。必须由6个数字组成。<br /> 支持最大长度为：6<br /> 支持的最大列表长度为：6
        /// </summary>
        public string ReceiverZip { get; set; }

        /// <summary>
        /// 交易编号。
        /// </summary>
        public long? Tid { get; set; }
    }
}
