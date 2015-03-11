using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.GoodsImage
{
    /// <summary>
    /// 商品关联图片
    /// </summary>
    public class ItemJointImg : Response
    {
        /// <summary>
        /// 商品图片id(如果是更新图片，则需要传该参数)
        /// </summary>
        public long? Id { get; set; }
        /// <summary>
        /// 上传的图片是否关联为商品主图（如果需更新主图，则需要传人true）
        /// </summary>
        public bool? IsMajor { get; set; }
        /// <summary>
        /// 商品数字ID，必选
        /// </summary>
        public long? NumIid { get; set; }
        /// <summary>
        /// 图片URL,图片空间图片的相对地址
        /// </summary>
        public string PicPath { get; set; }
        /// <summary>
        /// 图片序号
        /// </summary>
        public long? Position { get; set; }
    }
}
