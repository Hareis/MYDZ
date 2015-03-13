using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.Print
{
    /// <summary>
    /// 打印面单模板明细表
    /// </summary>
    [Serializable]
    public class tbPrintPlaneSingleDetail
    {
        /// <summary>
        /// 面单模板明细编号
        /// </summary>
        public int DetailId { get; set; }

        /// <summary>
        /// 面单模板编号
        /// </summary>
        public int PlaneId { get; set; }

        /// <summary>
        /// 打印内容编号
        /// </summary>
        public int ContentId { get; set; }

        /// <summary>
        /// 打印内容名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 打印字体
        /// </summary>
        public int Font { get; set; }

        /// <summary>
        /// 字体尺寸
        /// </summary>
        public int FontSize { get; set; }

        /// <summary>
        /// 是否加粗
        /// </summary>
        public bool Bold { get; set; }

        /// <summary>
        /// 子项列表
        /// </summary>
        public string SubList { get; set; }

        /// <summary>
        /// 打印条数
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 居左距离
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        /// 居上距离
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 对齐方式
        /// </summary>
        public int Align { get; set; }
    }
}
