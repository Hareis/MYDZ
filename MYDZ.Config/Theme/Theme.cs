using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Config.Theme
{
    public class Theme
    {
        /// <summary>
        /// 皮肤名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 皮肤值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 皮肤背景颜色
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// 是否默认皮肤
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
