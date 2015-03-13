using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.Order
{
    /// <summary>
    /// 返回状态表
    /// </summary>
    public class StatusTable : Response
    {
        /// <summary>
        /// 状态信息
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 是否在执行过程中发生了错误
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Msg { get; set; }
    }
}
