using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.GoodsImage;
using MYDZ.Business.TB_Logic.GoodsImage;

namespace MYDZ.Business.Business_Logic.GoodsImage
{
    public class SetGoodsPicturecs
    {
        SetGoodsImage sgi = new SetGoodsImage();

        /// <summary>
        /// 新增图片分类信息
        /// </summary>
        /// <param name="token"></param>
        /// <param name="PictureCategoryName"></param>
        /// <param name="ParentId"></param>
        /// <returns></returns>
        public PictureCategory AddImageCategroy(string token, string PictureCategoryName, string ParentId)
        {
            return sgi.AddImageCategroy(token, PictureCategoryName, ParentId);
        }

        /// <summary>
        /// 获取图片分类信息
        /// </summary>
        /// <param name="PicCategory"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<PictureCategory> GetPictureCategory(PictureCategoryGet PicCategory, string token)
        {
            return sgi.GetPictureCategory(PicCategory, token);
        }

        /// <summary>
        /// 上传单张图片
        /// </summary>
        /// <param name="PicUpload"></param>
        /// <param name="token"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public Picture PictureUpload(PictureUpload PicUpload, string token, out string errorMsg)
        {
            return sgi.PictureUpload(PicUpload, token, out errorMsg);
        }

        /// <summary>
        /// 商品关联子图 
        /// </summary>
        public bool ImgItemJoint(string token, ItemJointImg itemjoin, out string errorMsg)
        {
            return sgi.ImgItemJoint(token, itemjoin, out errorMsg);
        }
    }
}
