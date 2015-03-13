using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MYDZ.Entity.Menu
{
    /// <summary>
    /// 角色信息表
    /// </summary>
    [DataContract(Namespace = "", Name = "role")]
    public class tbRoleInfo : Response
    {
        /// <summary>
        /// 角色编号,主键,自动编号
        /// </summary>
        [DataMember(Name = "role_id", Order = 0)]
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [DataMember(Name = "role_name", Order = 1)]
        public string RoleName { get; set; }

        /// <summary>
        /// 是否系统角色
        /// </summary>
        [DataMember(Name = "is_system", Order = 2)]
        public bool IsSystem { get; set; }

        /// <summary>
        /// 是否默认角色
        /// </summary>
        [DataMember(Name = "is_default", Order = 3)]
        public bool IsDetault { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        [DataMember(Name = "user_id", Order = 4)]
        public int UserId { get; set; }

        /// <summary>
        /// 录入日期
        /// </summary>
        [DataMember(Name = "input_date", Order = 5)]
        public DateTime InputDate { get; set; }

        /// <summary>
        /// 菜单列表
        /// </summary>
        [DataMember(Name = "menus", Order = 6)]
        public IList<tbMenuInfo> Menus { get; set; }
    }
}
