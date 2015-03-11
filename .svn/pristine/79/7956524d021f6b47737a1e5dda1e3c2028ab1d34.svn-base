using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MYDZ.Entity.ClientUser
{
    /// <summary>
    /// 用户类型表
    /// </summary>
    [DataContract(Namespace = "", Name = "user_type")]
    public class tbClientUserType : Response
    {
        /// <summary>
        /// 类型编号,主键,自动编号
        /// </summary>
        [DataMember(Name = "type_id", Order = 0)]
        public int TypeId { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        [DataMember(Name = "type_name", Order = 1)]
        public string TypeName { get; set; }
    }
}
