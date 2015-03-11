<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Web;
using System.IO;
public class ImageHandler : System.Web.IHttpHandler
{

    public void ProcessRequest(System.Web.HttpContext context)
    {        
        context.Response.ContentType = "text/plain";
        context.Response.Charset = "utf-8";

        HttpPostedFile file = context.Request.Files["Filedata"];
        string uploadPath = HttpContext.Current.Server.MapPath(@context.Request["folder"]) + "\\";

        if (file != null)
        {
            if (File.Exists(uploadPath + file.FileName))
            {
                context.Response.Write("3");            //文件已经存在
                return;
            }

            string[] fn = file.FileName.Split('.');
            string ext = fn[fn.Length - 1];
            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "." + ext;
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            file.SaveAs(uploadPath + filename);
            context.Response.Write(filename);
        }
        else
        {
            context.Response.Write("0");
        } 
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
