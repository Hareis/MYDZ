using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using System.Xml.Serialization;
using MYDZ.Entity.GoodsImage;
using Top.Api.Parser;
using Top.Api.Util;

namespace MYDZ.Business.TB_Logic.GoodsImage
{
    public class SetGoodsImage
    {
        /// <summary>
        /// 新增图片分类信息 
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        internal PictureCategory AddImageCategroy(string sessionKey, string PictureCategoryName, string ParentId)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            PictureCategoryAddRequest req = new PictureCategoryAddRequest();
            req.PictureCategoryName = PictureCategoryName;
            req.ParentId = long.Parse(ParentId);
            PictureCategoryAddResponse response = client.Execute(req, sessionKey);
            PictureCategory newpc = new PictureCategory();
            Top.Api.Domain.PictureCategory pc = response.PictureCategory;
            newpc.Created = pc.Created;
            newpc.Modified = pc.Modified;
            newpc.ParentId = pc.ParentId;
            newpc.PictureCategoryId = pc.PictureCategoryId;
            newpc.PictureCategoryName = pc.PictureCategoryName;
            newpc.Position = pc.Position;
            newpc.Type = pc.Type;
            return newpc;
        }

        /// <summary>
        /// 获取图片分类信息
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        internal List<PictureCategory> GetPictureCategory(PictureCategoryGet PicCategory, string sessionKey)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            PictureCategoryGetRequest req = new PictureCategoryGetRequest();
            if (PicCategory.PictureCategoryId != null)
                req.PictureCategoryId = PicCategory.PictureCategoryId;
            if (PicCategory.PictureCategoryName != null)
                req.PictureCategoryName = PicCategory.PictureCategoryName;
            if (PicCategory.Type != null)
                req.Type = PicCategory.Type;
            if (PicCategory.ParentId != null)
                req.ParentId = PicCategory.ParentId;
            if (PicCategory.ModifiedTime != null)
            {
                DateTime dateTime = new DateTime();
                dateTime = DateTime.Parse(PicCategory.ModifiedTime.ToString());
                dateTime = DateTime.Parse(dateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                req.ModifiedTime = dateTime;
            }
            PictureCategoryGetResponse response = client.Execute(req, sessionKey);
            if (response.PictureCategories == null) { return null; }
            List<PictureCategory> newlist = new List<PictureCategory>();
            PictureCategory newitem = null;
            foreach (Top.Api.Domain.PictureCategory item in response.PictureCategories)
            {
                newitem = new PictureCategory();
                newitem.Modified = item.Modified;
                newitem.Created = item.Created;
                newitem.ParentId = item.ParentId;
                newitem.PictureCategoryId = item.PictureCategoryId;
                newitem.PictureCategoryName = item.PictureCategoryName;
                newitem.Position = item.Position;
                newitem.Type = item.Type;
                newlist.Add(newitem);
            }
            return newlist;
        }

        /// <summary>
        /// 上传单张图片
        /// </summary>
        /// <param name="PicUpload"></param>
        /// <param name="sessionKey"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        internal Picture PictureUpload(PictureUpload PicUpload, string sessionKey, out string errorMsg)
        {
            errorMsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            PictureUploadRequest req = new PictureUploadRequest();
            if (PicUpload.PictureCategoryId != null)
            {
                req.PictureCategoryId = PicUpload.PictureCategoryId;
            }
            else
            {
                errorMsg = "图片分类ID不能为空！";
                return null;
            }
            if (PicUpload.Img != null)
            {
                FileItem fItem = new FileItem("ImageName", PicUpload.Img);
                req.Img = fItem;
            }
            else
            {
                errorMsg = "上传图片内容不能为空！";
                return null;
            }
            if (PicUpload.ImageInputTitle != null)
            {
                req.ImageInputTitle = PicUpload.ImageInputTitle;
            }
            else
            {
                errorMsg = "图片标题不能为空！";
                return null;
            }
            if (PicUpload.Title != null)
            {
                req.Title = PicUpload.Title;
            }
            if (PicUpload.ClientType != null)
            {
                req.ClientType = PicUpload.ClientType;
            }
            PictureUploadResponse response = client.Execute(req, sessionKey);
            if (response.IsError)
            {
                errorMsg = response.SubErrMsg;
                return null;
            }
            Top.Api.Domain.Picture pic = response.Picture;
            Picture newpic = new Picture();
            newpic.ClientType = pic.ClientType;
            newpic.Created = pic.Created;
            newpic.Deleted = pic.Deleted;
            newpic.Md5 = pic.Md5;
            newpic.Modified = pic.Modified;
            newpic.PictureCategoryId = pic.PictureCategoryId;
            newpic.PictureId = pic.PictureId;
            newpic.PicturePath = pic.PicturePath;
            newpic.Pixel = pic.Pixel;
            newpic.Referenced = pic.Referenced;
            newpic.Sizes = pic.Sizes;
            newpic.Status = pic.Status;
            newpic.Title = pic.Title;
            newpic.Uid = pic.Uid;
            return newpic;
        }

        /// <summary>
        /// 商品关联子图 
        /// </summary>
        internal bool ImgItemJoint(string sessionKey,ItemJointImg itemjoin,out string errorMsg)
        {
            errorMsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ItemJointImgRequest req = new ItemJointImgRequest();
            req.Id = itemjoin.Id;
            req.NumIid = itemjoin.NumIid;
            req.PicPath = itemjoin.PicPath;
            req.IsMajor = itemjoin.IsMajor;
            req.Position = itemjoin.Position;
            ItemJointImgResponse response = client.Execute(req, sessionKey);
            if (response.IsError)
            {
                errorMsg = response.SubErrMsg;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
