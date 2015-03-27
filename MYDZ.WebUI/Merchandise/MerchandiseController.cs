using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Common;
using System.Web.Mvc;
using MYDZ.Business.Business_Logic.Goods;
using MYDZ.Entity.Goods;
using MYDZ.Entity.ClientUser;
using MYDZ.Business.Business_Logic.Shop;
using MYDZ.Entity.Shop;
using MYDZ.Business.Business_Logic.ItemCats;
using MYDZ.Entity.ItemCats;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using MYDZ.Business.Business_Logic.GoodsImage;
using MYDZ.Entity.GoodsImage;
using System.Collections;
using MYDZ.Business.DataBase_BLL.GoodsBLL;

namespace MYDZ.WebUI.Merchandise
{
    public class MerchandiseController : BaseController
    {
        InitGoodsInfo goodsinfo = new InitGoodsInfo();
        InitShopInfo isi = new InitShopInfo();
        GetItemCat gic = new GetItemCat();
        SetGoodsPicturecs sgi = new SetGoodsPicturecs();
        /// <summary>
        /// 出售中的商品
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult OnSale()
        {
            tbClientUser clientuser = GetUser("UserInfo");
            ViewData["SPLM"] = isi.ReutrnSPLM(clientuser.UserNick);
            ViewData["DPLM"] = isi.ReturnDPLM();
            return View();
        }

        /// <summary>
        /// 仓库中的商品
        /// </summary>
        /// <returns></returns>
        public ViewResult InStock()
        {
            tbClientUser clientuser = GetUser("UserInfo");
            ViewData["SPLM"] = isi.ReutrnSPLM(clientuser.UserNick);
            ViewData["DPLM"] = isi.ReturnDPLM();
            return View();
        }
        #region 在售商品管理
        /// <summary>
        /// 批量下架商品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<ActionResult> SetBatchUnShelve(string ListGoodId)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            return Task.Factory.StartNew(() =>
            {
                goodsinfo.BatchUnShelve(clientuser.UserShops[0].SessionKey, ListGoodId);
                AsyncManager.Timeout = 5000;
            }).ContinueWith<ActionResult>(task =>
            {
                Response.Redirect("/Merchandise/OnSale.html");
                Response.End();
                return View();
            });
        }

        //选择类目属性
        public ViewResult ChooseItemprop(string Cids = null)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            SellerAuthorize sa = new SellerAuthorize();
            sa = gic.GetAuthorizeItemcat(clientuser.UserShops[0].SessionKey);
            if (sa != null)
            {
                ViewData["ListCats"] = sa.ItemCats;
            }
            else
            {
                ViewData["ListCats"] = null;
            }
            return View();
        }

        [HttpPost]
        /// <summary>
        /// 通过Cid获取属性
        /// </summary>
        /// <returns></returns>
        public JsonResult GetItencatsByCid(string Cids, string ParentCid)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            List<ItemCat> result = gic.GetItemcats(Cids, ParentCid);
            return Json(result);
        }


        /// <summary>
        /// 添加商品页面
        /// </summary>
        /// <returns></returns>
        public ViewResult AddGoods(string SelectItemCid, string Pvs, string Type, string AttrKeys)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            List<ItemProp> list = new List<ItemProp>();
            List<PropValue> listpropvalue = new List<PropValue>();
            if (string.IsNullOrEmpty(SelectItemCid))
            {
                Response.End();
                Response.Redirect("/Merchandise/ChooseItemprop.html", true);
            }
            Session["SelectItemCid"] = SelectItemCid;
            list = gic.GetItemprops(SelectItemCid);
            listpropvalue = gic.GetItemPropValues(SelectItemCid, null, "1", null);

            List<DeliveryTemplate> DeliveryTemplate = goodsinfo.GetDeliveryTemplates(clientuser.UserShops[0].SessionKey);
            ViewData["Cid"] = SelectItemCid;
            ViewData["SPLM"] = isi.ReutrnSPLM(clientuser.UserNick);
            ViewData["DeliveryTemplate"] = DeliveryTemplate;
            return View();
        }

        /// <summary>
        /// 商品属性
        /// </summary>
        /// <returns></returns>
        public ViewResult AddGoodsCommonAttribute()
        {
            List<ItemProp> list = new List<ItemProp>();
            if (Session["SelectItemCid"] != null)
            {
                string SelectItemCid = Session["SelectItemCid"].ToString();
                list = gic.GetItemprops(SelectItemCid);
                ViewData["ListItemProp"] = list;
            }
            return View();
        }

        /// <summary>
        /// 添加商品方法
        /// </summary>
        /// <param name="goods"></param>
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult AddItems(ItemAdd goods)
        {
            string errormsg = null;
            tbClientUser clientuser = GetUser("UserInfo");
            if (string.IsNullOrEmpty(goods.Desc) && goods.Desc.Length > 5) { return Json(new { ErrorMsg = "商品描述字数应大于5小于20000！" }); }
            string itemid = goodsinfo.addgoods(clientuser.UserShops[0].SessionKey, goods, out errormsg);
            if (itemid == null) { return Json(new { ErrorMsg = errormsg }); }
            string[] path = goods.ChildPicPath.Split('^');
            if (path == null) { return Json(new { ErrorMsg = "" }); }

            ItemJointImg itemjoin;
            for (int i = 0; i < path.Count(); i++)
            {
                if (string.IsNullOrEmpty(path[i]) && i.ToString().Length > 5)
                {
                    string str = "http://img03.tbsandbox.com/imgextra/";
                    itemjoin = new ItemJointImg();
                    itemjoin.NumIid = long.Parse(itemid);
                    itemjoin.PicPath = path[i].ToString().Substring(str.Length - 1, path[i].ToString().Length - str.Length + 1);
                    itemjoin.Position = long.Parse(path[i + 1]);
                    sgi.ImgItemJoint(clientuser.UserShops[0].SessionKey, itemjoin, out errormsg);
                }
            }
            return Json(new { ErrorMsg = errormsg });
        }


        /// <summary>
        /// 批量修改
        /// </summary>
        /// <returns></returns>
        public ViewResult SetBatchEdit()
        {
            return View();
        }

        /// <summary>
        /// 商品重量、简称设置
        /// </summary>
        /// <returns></returns>
        public ViewResult GoodsSetting(QueryCriteriaForOnSales QueryStr)
        {
            int TotalNum = 0;
            IList<Item> list = new List<Item>();
            IList<Skus> listSkus = new List<Skus>();
            List<string> ListSPID = new List<string>();

            tbClientUser clientuser = GetUser("UserInfo");
            list = SearchGoodsOnsales(ref  TotalNum, QueryStr);
            if (list != null)
            {
                foreach (Item item in list)
                {
                    ListSPID.Add(item.NumIid.ToString());
                }
                if (ListSPID != null)
                {
                    if (ListSPID.Count <= 40)
                        listSkus = goodsinfo.GetItemSkus(clientuser.UserShops[0].SessionKey, string.Join(",", ListSPID.ToArray()));
                    BSkus bs = new BSkus();
                    foreach (Skus item in listSkus)
                    {
                        IList<Skus> listsku = bs.GetSkus(item.SkuId.ToString());
                        if (listsku.Count > 0)
                        {
                            item.SPJC = listsku[0].SPJC;
                            item.SPZL = listsku[0].SPJC;
                            item.CBJ = listsku[0].CBJ;
                        }
                    }
                }
            }
            ViewData["listSkus"] = listSkus;

            return View(list);
        }

        /// <summary>
        /// 保存商品的简称和重量,成本价
        /// </summary>
        /// <param name="skuitems"></param>
        [HttpPost]
        public JsonResult SveGoodsSetting(Skus skuitems)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            IList<Item> listitem = new List<Item>();
            IList<Skus> listsku = new List<Skus>();
            try
            {
                listitem = goodsinfo.Getitem(clientuser.UserShops[0].SessionKey, skuitems.NumIid.ToString());
                listsku = goodsinfo.GetItemSkus(clientuser.UserShops[0].SessionKey, skuitems.SkuId.ToString());
                BItems bi = new BItems();
                BSkus bs = new BSkus();
                if (listitem != null)
                    if (bi.GetItems(skuitems.NumIid.ToString()).Count() <= 0)
                        bi.AddItems(listitem[0]);
                if (listsku != null)
                {
                    foreach (Skus item in listsku)
                    {
                        if (item.SkuId.Equals(skuitems.SkuId))
                        {
                            if (bs.GetSkus(skuitems.SkuId.ToString()).Count() <= 0)
                            {
                                bs.AddSkus(skuitems);
                            }
                            else
                            {
                                bs.UpdateSkus(skuitems);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json(new { Result = true });
        }


        /// <summary>
        /// 类目
        /// </summary>
        /// <returns></returns>
        public ViewResult Category()
        {
            tbClientUser clientuser = GetUser("UserInfo");
            ViewData["SPLM"] = isi.ReutrnSPLM(clientuser.UserNick);
            return View();
        }

        /// <summary>
        /// 编码
        /// </summary>
        /// <returns></returns>
        public ViewResult Coding()
        {
            return View();
        }

        /// <summary>
        /// 描述
        /// </summary>
        /// <returns></returns>
        public ViewResult Describe()
        {
            return View();
        }

        /// <summary>
        /// 价格
        /// </summary>
        /// <returns></returns>
        public ViewResult Price()
        {
            return View();
        }

        /// <summary>
        /// 修改商品价格
        /// </summary>
        /// <returns></returns>
        public JsonResult Updateprice()
        {
            // 根据选择的ID获取商品信息（价格）, 使用方法 SetupdateGoods(ItemUpdate goods)
            return Json("");
        }

        /// <summary>
        /// 运费
        /// </summary>
        /// <returns></returns>
        public ViewResult Freight()
        {
            tbClientUser clientuser = GetUser("UserInfo");
            List<DeliveryTemplate> list = goodsinfo.GetDeliveryTemplates(clientuser.UserShops[0].SessionKey);
            ViewData["list"] = list;
            return View();
        }

        /// <summary>
        /// 热点
        /// </summary>
        /// <returns></returns>
        public ViewResult HotDot()
        {
            return View();
        }


        /// <summary>
        /// 库存
        /// </summary>
        /// <returns></returns>
        public ViewResult Stock()
        {
            return View();
        }

        /// <summary>
        /// 标题
        /// </summary>
        /// <returns></returns>
        public ViewResult Title()
        {
            return View();
        }

        [HttpPost]
        /// <summary>
        /// 批量修改商品信息
        /// </summary>
        /// <returns></returns>
        public Task<ActionResult> SetupdateGoods(ItemUpdate goods)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            string ErrorMsg = string.Empty;
            return Task.Factory.StartNew(() =>
            {
                List<string> errorMsg = new List<string>();
                goodsinfo.simpleupdategoods(clientuser.UserShops[0].SessionKey, goods, out errorMsg);
                AsyncManager.Timeout = 5000;
                AsyncManager.Parameters["content"] = errorMsg;
            }).ContinueWith<ActionResult>(task =>
            {
                List<string> errorMsg = (List<string>)AsyncManager.Parameters["content"];
                return Json(new { ErrorMsg = errorMsg });
            });
        }

        [HttpPost]
        /// <summary>
        /// 批量修改商品库存
        /// </summary>
        /// <returns></returns>
        public Task<ActionResult> SetUpdateGoodsStoke(ItemQuantityUpdate goods)
        {

            tbClientUser clientuser = GetUser("UserInfo");
            return Task.Factory.StartNew(() =>
            {
                List<string> errorMsgs;
                goodsinfo.UpdateStoke(clientuser.UserShops[0].SessionKey, goods, out errorMsgs);
                AsyncManager.Timeout = 5000;
                AsyncManager.Parameters["content"] = errorMsgs;
            }).ContinueWith<ActionResult>(task =>
            {
                List<string> errorMsg = (List<string>)AsyncManager.Parameters["content"];
                return Json(new { ErrorMsg = errorMsg });
            });
        }

        /// <summary>
        /// 批量修改商品标题
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<ActionResult> updateGoodsTitle(ItemUpdate goods)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            string ErrorMsg = string.Empty;
            return Task.Factory.StartNew(() =>
            {
                List<string> errorMsg = new List<string>();
                goodsinfo.updateGoodsTitle(goods, clientuser.UserShops[0].SessionKey, out errorMsg);
                AsyncManager.Timeout = 5000;
                AsyncManager.Parameters["content"] = errorMsg;
            }).ContinueWith<ActionResult>(task =>
            {
                List<string> errorMsg = (List<string>)AsyncManager.Parameters["content"];
                return Json(new { ErrorMsg = errorMsg });
            });
        }
        /// <summary>
        /// 批量更新商家编码
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public Task<ActionResult> Updatecoding(ItemUpdate goods)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            List<string> errorMsg;
            return Task.Factory.StartNew(() =>
            {
                errorMsg = new List<string>();
                goodsinfo.Updatecoding(goods, clientuser.UserShops[0].SessionKey, out errorMsg);
                AsyncManager.Timeout = 5000;
                AsyncManager.Parameters["content"] = errorMsg;
            }).ContinueWith<ActionResult>(task =>
            {
                errorMsg = new List<string>();
                errorMsg = (List<string>)AsyncManager.Parameters["content"];
                return Json(new { ErrorMsg = errorMsg });
            });
        }
        /// <summary>
        /// 批量更新卖点信息
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public Task<ActionResult> Updatesellerpoint(ItemUpdate goods)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            List<string> errorMsg;
            return Task.Factory.StartNew(() =>
            {
                errorMsg = new List<string>();
                goodsinfo.UpdateHotdot(goods, clientuser.UserShops[0].SessionKey, out errorMsg);
                AsyncManager.Timeout = 5000;
                AsyncManager.Parameters["content"] = errorMsg;
            }).ContinueWith<ActionResult>(task =>
            {
                errorMsg = new List<string>();
                errorMsg = (List<string>)AsyncManager.Parameters["content"];
                return Json(new { ErrorMsg = errorMsg });
            });
        }

        /// <summary>
        /// 商品上架
        /// </summary>
        /// <param name="ListGoodsId"></param>
        /// <returns></returns>
        public Task<ActionResult> GoodsShelf(string ListGoodsId, string ShelfGoodsNum = "0")
        {
            tbClientUser clientuser = GetUser("UserInfo");
            List<string> errorMsgs;
            return Task.Factory.StartNew(() =>
            {
                errorMsgs = new List<string>();
                goodsinfo.GoodsShelf(clientuser.UserShops[0].SessionKey, ListGoodsId, ShelfGoodsNum, out errorMsgs);
                AsyncManager.Timeout = 5000;
                AsyncManager.Parameters["content"] = errorMsgs;
            }).ContinueWith<ActionResult>(task =>
            {
                errorMsgs = new List<string>();
                errorMsgs = (List<string>)AsyncManager.Parameters["content"];
                return Json(new { ErrorMsg = errorMsgs });
            });
        }

        /// <summary>
        /// 刪除商品
        /// </summary>
        /// <param name="ListGoodsId"></param>
        /// <returns></returns>
        public Task<ActionResult> GoodsDeleteGoods(string ListGoodsId)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            return Task.Factory.StartNew(() =>
            {
                goodsinfo.DeleteGoods(ListGoodsId, clientuser.UserShops[0].SessionKey);
                AsyncManager.Timeout = 5000;
            }).ContinueWith<ActionResult>(task =>
            {
                return Json("");
            });
        }

        /// <summary>
        /// 批量更新商品描述
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public Task<ActionResult> UpdateGoodsDesc(ItemUpdate goods)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            List<string> errorMsg;
            return Task.Factory.StartNew(() =>
            {
                errorMsg = new List<string>();
                goodsinfo.UpdateGoodsDesc(goods, clientuser.UserShops[0].SessionKey, out errorMsg);
                AsyncManager.Parameters["content"] = errorMsg;
            }).ContinueWith<ActionResult>(task =>
            {
                errorMsg = new List<string>();
                errorMsg = (List<string>)AsyncManager.Parameters["content"];
                return Json(new { ErrorMsg = errorMsg });
            });
        }
        /// <summary>
        /// 检查图片空间
        /// </summary>
        private string CheckPictureSpace(string PictureCategoryName)
        {
            string Result = null;
            tbClientUser clientuser = GetUser("UserInfo");
            PictureCategoryGet PicCategory = new PictureCategoryGet();
            PicCategory.PictureCategoryName = PictureCategoryName;
            List<PictureCategory> list = new List<PictureCategory>();
            list = sgi.GetPictureCategory(PicCategory, clientuser.UserShops[0].SessionKey);
            PictureCategory picc;
            //if (list != null)
            //{
            //    picc = new PictureCategory();
            //    picc = list[0];
            //    Result = picc.PictureCategoryId.ToString();
            //}
            //else
            //{
            //    picc = new PictureCategory();
            //    picc = sgi.AddImageCategroy(clientuser.UserShops[0].SessionKey, PictureCategoryName, "0");
            //    Result = picc.PictureCategoryId.ToString();
            //}
            return "1837616344513"; //Result;
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        [HttpPost]
        public JsonResult UploadGoodsImg()
        {
            byte[] byData = null;
            JsonResult result = null;
            tbClientUser clientuser = GetUser("UserInfo");
            string RootFilePath = MYDZ.Business.StaticSystemConfig.soft.RootFilePath;
            try
            {
                System.Web.HttpPostedFileBase file = Request.Files["fileToUpload"];
                if (file == null) { return null; }
                if (file.ContentLength > 500 * 1024)
                {
                    return Json(new { URL = "", ErrorMsg = "大于500KB，上传失败！" });
                }
                string hzm = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1).ToLower();
                if (hzm != "jpg" && hzm != "gif" && hzm != "png")
                {
                    return Json(new { URL = "", ErrorMsg = "选择的文件不是图片文件！" });
                }

                using (Stream stream = file.InputStream)
                {
                    byData = new Byte[stream.Length];
                    stream.Position = 0;
                    stream.Read(byData, 0, byData.Length);
                    stream.Close();
                }
                string PictureCategoryName = "商品图片-魔云店长";
                string cid = CheckPictureSpace(PictureCategoryName);
                if (cid == null) { return null; }
                string errormsg = null;
                PictureUpload pu = new PictureUpload();
                pu.ImageInputTitle = file.FileName;
                pu.PictureCategoryId = long.Parse(cid);
                pu.Img = byData;
                Picture picture = new Picture();
                picture = sgi.PictureUpload(pu, clientuser.UserShops[0].SessionKey, out errormsg);
                if (errormsg == null)
                {
                    result = Json(new { URL = picture.PicturePath, ErrorMsg = "" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 查找在线商品
        /// </summary>
        /// <param name="QueryStr"></param>
        /// <returns></returns>
        private IList<Item> SearchGoodsOnsales(ref int totalNum, MYDZ.Entity.Goods.QueryCriteriaForOnSales QueryStr = null)
        {
            IList<Item> list = null;
            tbClientUser clientuser = GetUser("UserInfo");
            string Type = null;
            list = goodsinfo.ReturnOnsalesByCriteria(clientuser.UserShops[0].SessionKey.ToString(), ref totalNum, QueryStr);
            return list;
        }

        /// <summary>
        /// 查找仓库商品
        /// </summary>
        /// <param name="QueryStr"></param>
        /// <returns></returns>
        private IList<Item> SearchGoodsInventory(ref int totalNum, MYDZ.Entity.Goods.QueryCriteriaForInventory QueryStr = null)
        {
            IList<Item> list = null;
            tbClientUser clientuser = GetUser("UserInfo");
            list = goodsinfo.ReturnInventoryByCriteria(clientuser.UserShops[0].SessionKey.ToString(), ref totalNum, QueryStr);
            return list;
        }

        /// <summary>
        /// 显示和查找在售商品
        /// </summary>
        /// <param name="QueryStr"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult SHowGoodsOnsales(MYDZ.Entity.Goods.QueryCriteriaForOnSales QueryStr = null)
        {
            if (QueryStr != null)
            {
                string SellerCids = Request.Form["SellerCids"];
                QueryStr.SellerCids = SellerCids;
            }
            IList<Item> result = null;
            int totalNum = 0;
            result = (SearchGoodsOnsales(ref totalNum, QueryStr));
            ViewBag.totalNum = totalNum;
            return View(result);
        }
        /// <summary>
        /// 显示和查找仓库中商品
        /// </summary>
        /// <param name="QueryStr"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult SHowGoodsInventory(MYDZ.Entity.Goods.QueryCriteriaForInventory QueryStr)
        {
            IList<Item> result = null;
            int totalNum = 0;
            result = (SearchGoodsInventory(ref totalNum, QueryStr));
            ViewBag.totalNum = totalNum;
            return View(result);
        }

        /// <summary>
        /// 返回授权的类目列表
        /// </summary>
        /// <returns></returns>
        public List<ItemCat> AuthorizeItemcat(string token)
        {
            tbClientUser clientuser = GetUser("UserInfo");
            SellerAuthorize cats = new SellerAuthorize();
            cats = gic.GetAuthorizeItemcat(token);
            return cats.ItemCats;
        }
        #endregion
    }
}
