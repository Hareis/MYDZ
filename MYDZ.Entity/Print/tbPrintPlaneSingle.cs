using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.Print
{
    /// <summary>
    /// 打印面单模板表
    /// </summary>
    [Serializable]
    public class tbPrintPlaneSingle
    {
        /// <summary>
        /// 面单模板编号
        /// </summary>
        public int PlaneId { get; set; }

        /// <summary>
        /// 物流编号
        /// </summary>
        public int LogisticsId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 模板图片
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 模板宽度(毫米)
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 模板高度(毫米)
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 是否面单模板
        /// </summary>
        public bool IsSingle { get; set; }

        /// <summary>
        /// 打印面单模板明细列表
        /// </summary>
        public List<tbPrintPlaneSingleDetail> DetailList { get; set; }
    }
}
