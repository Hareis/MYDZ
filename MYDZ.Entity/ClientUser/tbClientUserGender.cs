using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MYDZ.Entity.ClientUser
{
    /// <summary>
    /// 用户性别表
    /// </summary>
    [DataContract(Namespace = "", Name = "user_gender")]
    public class tbClientUserGender : Response
    {
        /// <summary>
        /// 性别编号,主键,自动编号
        /// </summary>
        [DataMember(Name = "gender_id", Order = 0)]
        public int GenderId { get; set; }

        /// <summary>
        /// 性别名称
        /// </summary>
        [DataMember(Name = "gender_name", Order = 1)]
        public string GenderName { get; set; }

        /// <summary>
        /// 性别图片
        /// </summary>
        [DataMember(Name = "gender_img", Order = 2)]
        public string GenderImg { get; set; }
    }
}
