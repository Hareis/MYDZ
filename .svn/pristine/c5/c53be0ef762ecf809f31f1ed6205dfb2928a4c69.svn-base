using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Collections;
using System.IO;
using Svg;
using System.Drawing.Imaging;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MYDZ.Business.InitUser;

namespace MYDZ.WebUI.Front
{
    public class FrontController : Controller
    {
        public ViewResult Index()
        {
            Response.Redirect(UserInfo.GetAuthorize());
            return View();
        }

        /// <summary>
        /// 导出报表数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="svg"></param>
        /// <param name="filename"></param>
        /// <param name="width"></param>
        [HttpPost]
        public void HighchartsExport(string type = "", string svg = "", string filename = "", string width = "")
        {
            if (!String.IsNullOrEmpty(type) && !String.IsNullOrEmpty(svg))
            {
                if (String.IsNullOrEmpty(filename)) { filename = "chart"; }

                MemoryStream tData = new MemoryStream(Encoding.UTF8.GetBytes(svg));
                MemoryStream tStream = new MemoryStream();
                string tTmp = new Random().Next().ToString();

                string tExt = "";
                string tTypeString = "";

                switch (type)
                {
                    case "image/png":
                        tTypeString = "-m image/png";
                        tExt = "png";
                        break;
                    case "image/jpeg":
                        tTypeString = "-m image/jpeg";
                        tExt = "jpg";
                        break;
                    case "application/pdf":
                        tTypeString = "-m application/pdf";
                        tExt = "pdf";
                        break;
                    case "image/svg+xml":
                        tTypeString = "-m image/svg+xml";
                        tExt = "svg";
                        break;
                }

                if (tTypeString != "")
                {
                    SvgDocument tSvgObj = SvgDocument.Open(tData);
                    switch (tExt)
                    {
                        case "jpg":
                            tSvgObj.Draw().Save(tStream, ImageFormat.Jpeg);
                            break;
                        case "png":
                            tSvgObj.Draw().Save(tStream, ImageFormat.Png);
                            break;
                        case "pdf":
                            PdfWriter tWriter = null;
                            Document tDocumentPdf = null;
                            try
                            {
                                tSvgObj.Draw().Save(tStream, ImageFormat.Png);
                                tDocumentPdf = new Document(new Rectangle((float)tSvgObj.Width, (float)tSvgObj.Height));
                                tDocumentPdf.SetMargins(0.0f, 0.0f, 0.0f, 0.0f);
                                iTextSharp.text.Image tGraph = iTextSharp.text.Image.GetInstance(tStream.ToArray());
                                tGraph.ScaleToFit((float)tSvgObj.Width, (float)tSvgObj.Height);

                                tStream = new MemoryStream();
                                tWriter = PdfWriter.GetInstance(tDocumentPdf, tStream);
                                tDocumentPdf.Open();
                                tDocumentPdf.NewPage();
                                tDocumentPdf.Add(tGraph);
                                tDocumentPdf.CloseDocument();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                tDocumentPdf.Close();
                                tDocumentPdf.Dispose();
                                tWriter.Close();
                                tWriter.Dispose();
                                tData.Dispose();
                                tData.Close();

                            }
                            break;

                        case "svg":
                            tStream = tData;
                            break;
                    }

                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.ContentType = type;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "." + tExt + "");
                    Response.BinaryWrite(tStream.ToArray());
                    Response.End();
                }
            }
        }
    }
}
