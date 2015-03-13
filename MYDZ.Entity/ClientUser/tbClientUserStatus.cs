using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MYDZ.Entity.ClientUser
{
    /// <summary>
    /// 用户状态表
    /// </summary>
    [DataContract(Namespace = "", Name = "user_status")]
    public class tbClientUserStatus : Response
    {
        /// <summary>
        /// 状态编号,主键,自动编号
        /// </summary>
        [DataMember(Name = "status_id", Order = 0)]
        public int StatusId { get; set; }

        /// <summary>
        /// 状态名称
        /// </summary>
        [DataMember(Name = "status_name", Order = 1)]
        public string Name { get; set; }

        /// <summary>
        /// 状态枚举
        /// </summary>
        [DataMember(Name = "enum_name", Order = 2)]
        public string EnumName { get; set; }

        /// <summary>
        /// 状态描述
        /// </summary>
        [DataMember(Name = "status_detail", Order = 3)]
        public string Detail { get; set; }

        /// <summary>
        /// 是否允许登陆
        /// </summary>
        [DataMember(Name = "is_login", Order = 4)]
        public bool IsLogin { get; set; }
    }
}
