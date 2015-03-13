using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;

namespace MYDZ.Web.Views.Merchandise
{
    /// <summary>
    /// UploadImg 的摘要说明
    /// </summary>
    public class UploadImg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //获取前台的FILE  
            HttpPostedFile file = context.Request.Files["fileToUpload"];

            string path = "UploadImgs\\";
            //Bitmap map = new Bitmap(filePath);  
            string fileName = Path.GetFileName(file.FileName);
            string mapPath = context.Server.MapPath("~");
            string savePath = mapPath + "\\" + path + fileName;
            //map.Save(savePath);  
            file.SaveAs(savePath);
            //上传成功后显示IMG文件  
            StringBuilder sb = new StringBuilder();
            sb.Append("<img id=\"imgUpload\" src=\"" + path.Replace("\\", "/") + fileName + "\" />");
            context.Response.Write(sb.ToString());
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}