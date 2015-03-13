using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MYDZ.Entity.Menu
{
    /// <summary>
    /// 菜单信息表
    /// </summary>
    [DataContract(Namespace = "", Name = "menu")]
    public class tbMenuInfo : Response
    {
        /// <summary>
        /// 菜单编号,主键,自动编号
        /// </summary>
        [DataMember(Name = "menu_id", Order = 0)]
        public int MenuId { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [DataMember(Name = "menu_name", Order = 1)]
        public string MenuName { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        [DataMember(Name = "menu_icon", Order = 2)]
        public string MenuIcon { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        [DataMember(Name = "menu_link", Order = 3)]
        public string MenuLink { get; set; }

        /// <summary>
        /// 菜单级别
        /// </summary>
        [DataMember(Name = "menu_level", Order = 4)]
        public int MenuLevel { get; set; }

        /// <summary>
        /// 父菜单编号
        /// </summary>
        [DataMember(Name = "parentid", Order = 5)]
        public int ParentId { get; set; }
        
        /// <summary>
        /// 是否显示
        /// </summary>
        [DataMember(Name = "is_display", Order = 6)]
        public bool IsDisplay { get; set; }

        /// <summary>
        /// 含子菜单数
        /// </summary>
        [DataMember(Name = "menu_sub", Order = 7)]
        public int MenuSub { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        [DataMember(Name = "menu_sort", Order = 8)]
        public int MenuSort { get; set; }

        /// <summary>
        /// 录入日期
        /// </summary>
        [DataMember(Name = "input_date", Order = 9)]
        public DateTime InputDate { get; set; }
    }
}
