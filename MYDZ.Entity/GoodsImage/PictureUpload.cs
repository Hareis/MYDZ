using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.GoodsImage
{
    /// <summary>
    /// 图片上传请求类
    /// </summary>
    public class PictureUpload : Response
    {
        /// <summary>
        /// 图片上传的来源，有电脑版本宝贝发布，手机版本宝贝发布  client:computer电脑版本宝贝使用  client:phone手机版本宝贝使用
        /// </summary>
        public string ClientType { get; set; }

        /// <summary>
        /// 包括后缀名的图片标题,不能为空，如Bule.jpg,有些卖家希望图片上传后取图片文件的默认名
        /// </summary>
        public string ImageInputTitle { get; set; }

        /// <summary>
        /// 图片二进制文件流,不能为空,允许png、jpg、gif图片格式,3M以内。
        /// </summary>
        public byte[] Img { get; set; }

        /// <summary>
        /// 图片分类ID，设置具体某个分类ID或设置0上传到默认分类，只能传入一个分类<br /> 支持最大值为：9223372036854775807<br /> 支持最小值为：0
        /// </summary>
        public long? PictureCategoryId { get; set; }

        /// <summary>
        /// 图片标题,如果为空,传的图片标题就取去掉后缀名的image_input_title,超过50字符长度会截取50字符,重名会在标题末尾加"(1)";标题末尾已经有"(数字)"了，则数字加1
        /// </summary>
        public string Title { get; set; }
    }
}
