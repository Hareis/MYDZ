using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMPSDKPHP.marketing.meta;

namespace MYDZ.Entity.Marketing
{
    /// <summary>
    /// 创建活动实体类
    /// </summary>
    public class CommonActivityEntity : Response
    {
        private string _StartTime;
        private string _EndTime;
        private string _Type = UMPSDKPHP.marketing.MarketingActivity.ActivityType.NORMAL.ToString();
        private string _ParticipateRange = UMPSDKPHP.marketing.MarketingActivity.ParticipateRange.PART.ToString();
        private string _Options = UMPSDKPHP.marketing.MarketingActivity.Options.MANYTIMES.ToString();
        /// <summary>
        /// 打折工具ID
        /// </summary>
        public int ToolId { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///  开始时间 格式：yyyy-MM-dd hh:mm:ss
        /// </summary>
        public string StartTime
        {
            get { return _StartTime; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _StartTime = DateTime.Parse(value).ToString("yyyy-MM-dd hh:mm:ss");
                }
                else
                {
                    _StartTime = null;
                }
            }
        }

        /// <summary>
        /// 用户标签
        /// </summary>
        public MetaData Target { get; set; }

        /// <summary>
        /// 活动类型 枚举类型  MarketingActivity.ActivityType
        /// 不对外公开 对外公开 正常 冻结 删除  枚举类型
        /// 默认正常
        /// </summary>
        public string Type { get { return _Type; } set { _Type = value; } }


        /// <summary>
        /// 结束时间 格式：yyyy-MM-dd hh:mm:ss
        /// </summary>
        public string EndTime
        {
            get { return _EndTime; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _EndTime = DateTime.Parse(value).ToString("yyyy-MM-dd hh:mm:ss");
                }
                else
                {
                    _EndTime = null;
                }
            }
        }

        /// <summary>
        /// 活动参加范围  枚举类型  MarketingActivity.ParticipateRange
        /// 参数： PARTICIPATE_RANGE_ALL：全部参加；PARTICIPATE_RANGE_PART：部分参加；PARTICIPATE_RANGE_PART_NOT部分不参加
        /// 默认 部分参加
        /// </summary>
        public string ParticipateRange { get { return _ParticipateRange; } set { _ParticipateRange = value; } }

        /// <summary>
        /// 优惠次数 枚举类型 MarketingActivity.Options
        /// 注：OPTIONS_MANYTIMES：多次优惠；OPTIONS_ONCE：一次优惠
        /// 默认 一次优惠
        /// </summary>
        public string Options { get { return _Options; } set { _Options = value; } }

    }
}
