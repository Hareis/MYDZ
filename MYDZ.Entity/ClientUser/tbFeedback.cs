using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MYDZ.Entity.ClientUser
{
    /// <summary>
    /// 意见反馈表
    /// </summary>
    [DataContract(Namespace = "", Name = "feedback")]
    public class tbFeedback : Response
    {
        /// <summary>
        /// 反馈编号,主键,自动编号
        /// </summary>
        [DataMember(Name = "feed_id", Order = 0)]
        public int FeedId { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        [DataMember(Name = "user", Order = 1)]
        public tbClientUser User { get; set; }

        /// <summary>
        /// 反馈内容
        /// </summary>
        [DataMember(Name = "content", Order = 2)]
        public string Content { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        [DataMember(Name = "mobile", Order = 3)]
        public string Mobile { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [DataMember(Name = "email", Order = 4)]
        public string Email { get; set; }
    }
}
