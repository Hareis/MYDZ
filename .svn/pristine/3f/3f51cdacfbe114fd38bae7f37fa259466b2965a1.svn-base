using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MYDZ.Entity.ClientUser
{
    /// <summary>
    /// 用户登录日志表
    /// </summary>
    [DataContract(Namespace = "", Name = "user_log")]
    public class tbClientUserLog : Response
    {
        /// <summary>
        /// 日志编号,主键,自动编号
        /// </summary>
        [DataMember(Name = "log_id", Order = 0)]
        public int LogId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        [DataMember(Name = "user_id", Order = 1)]
        public int UserId { get; set; }

        /// <summary>
        /// 登录IP
        /// </summary>
        [DataMember(Name = "ip", Order = 2)]
        public string Ip { get; set; }

        /// <summary>
        /// IP所在地
        /// </summary>
        [DataMember(Name = "location", Order = 3)]
        public string Location { get; set; }

        /// <summary>
        /// 登录日期
        /// </summary>
        [DataMember(Name = "login_date", Order = 4)]
        public DateTime LoginDate { get; set; }
    }
}
