using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MYDZ.Entity.ClientUser
{
    /// <summary>
    /// 用户级别表
    /// </summary>
    [DataContract(Namespace = "", Name = "user_level")]
    public class tbClientUserLevel : Response
    {
        /// <summary>
        /// 级别编号,主键,自动编号
        /// </summary>
        [DataMember(Name = "level_id", Order = 0)]
        public int LevelId { get; set; }

        /// <summary>
        /// 级别名称
        /// </summary>
        [DataMember(Name = "level_name", Order = 1)]
        public string LevelName { get; set; }

        /// <summary>
        /// 枚举名称
        /// </summary>
        [DataMember(Name = "enum_name", Order = 2)]
        public string EnumName { get; set; }

        /// <summary>
        /// 级别图片
        /// </summary>
        [DataMember(Name = "level_img", Order = 3)]
        public string LevelImg { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        [DataMember(Name = "priority", Order = 4)]
        public int Priority { get; set; }
    }
}
