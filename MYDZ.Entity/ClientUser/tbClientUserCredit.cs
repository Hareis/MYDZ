using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MYDZ.Entity.ClientUser
{
    /// <summary>
    /// 用户信用表
    /// </summary>
    [DataContract(Namespace = "", Name = "user_credit")]
    public class tbClientUserCredit : Response
    {
        /// <summary>
        /// 信用编号,主键,自动编号
        /// </summary>
        [DataMember(Name = "credit_id", Order = 0)]
        public int CreditId { get; set; }

        /// <summary>
        /// 信用等级
        /// </summary>
        [DataMember(Name = "credit_level", Order = 1)]
        public int Level { get; set; }

        /// <summary>
        /// 信用评分
        /// </summary>
        [DataMember(Name = "credit_score", Order = 2)]
        public int Score { get; set; }

        /// <summary>
        /// 收到的评价总条数
        /// </summary>
        [DataMember(Name = "total_num", Order = 3)]
        public int TotalNum { get; set; }

        /// <summary>
        /// 收到的好评总条数
        /// </summary>
        [DataMember(Name = "good_num", Order = 4)]
        public int GoodNum { get; set; }
    }
}
