using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MYDZ.Entity.Goods
{
    /// <summary>
    /// 宝贝描述规范化模块锚点信息
    /// </summary>
    [Serializable]
    public class DescModuleInfo : Response
    {
        /// <summary>
        /// 系统数据库
        /// </summary>
        public int DescModuleInfoID { get; set; }

        /// <summary>
        /// 代表宝贝描述中规范化打标使用到的模块id列表，以逗号分隔。
        /// </summary>
        [XmlElement("anchor_module_ids")]
        public string AnchorModuleIds { get; set; }

        /// <summary>
        /// 类型代表规范化打标的类型：人工或自动化
        /// </summary>
        [XmlElement("type")]
        public long Type { get; set; }
    }
}
