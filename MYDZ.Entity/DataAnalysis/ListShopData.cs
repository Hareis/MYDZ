using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.DataAnalysis
{
    [Serializable]
    public class ListShopData : Response
    {
        /// <summary>
        ///  X轴键(List)  [存入日期、月份 等]
        /// </summary>
        public List<string> List_X_Key { get; set; }

        /// <summary>
        ///  X轴值（List） [存入 此Key代表的完整数据]
        /// </summary>
        public List<Shopdata> List_X_Value { get; set; }

        /// <summary>
        ///  Y轴键（List）[ 存入 Y 轴要表示的名字 ]
        /// </summary>
        public List<string> List_Y_Key { get; set; }

        /// <summary>
        ///  Y轴值（List）[ 存入 Y 的一些数值]
        /// </summary>
        public List<float>  List_Y_Value { get; set; }

        /// <summary>
        /// 提示内容
        /// </summary>
        public string TipsContent { get; set; }

        /// <summary>
        /// 曲线名
        /// </summary>
        public List<string> LinsNames { get; set; }

        /// <summary>
        /// 表标题
        /// </summary>
        public string Table_Title { get; set; }

        /// <summary>
        /// 选中的时间
        /// </summary>
        public DateTime SelectTime { get; set; }
    }
}
