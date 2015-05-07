using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Business.TB_Logic.Goods;
using MYDZ.Entity.Goods;
using System.Collections;
using System.Threading;

namespace MYDZ.Business.Business_Logic.Goods
{
    public class InitGoodsInfo
    {
        GetGoods getgoods = new GetGoods();
        SetGoods setgoods = new SetGoods();
        /// <summary>
        /// 查询仓库中的商品
        /// </summary>
        /// <param name="SessionKey"></param>
        /// <param name="TotalNum"></param>
        /// <returns></returns>
        public IList<Item> ReturnInventoryByCriteria(string token, ref int TotalNum, QueryCriteriaForInventory Query)
        {
            IList<Item> list = getgoods.SearchInventoryByCriteria(token, ref TotalNum, Query);
            return list;
        }

        /// <summary>
        /// 查询出售中的商品
        /// </summary>
        /// <param name="SessionKey"></param>
        /// <param name="TotalNum"></param>
        /// <returns></returns>
        public IList<Item> ReturnOnsalesByCriteria(string token, ref int TotalNum, QueryCriteriaForOnSales Query)
        {
            IList<Item> list = getgoods.SearchOnsalesByCriteria(token, ref TotalNum, Query);
            return list;
        }

        /// <summary>
        /// 根据商品外部ID获取商品
        /// </summary>
        /// <param name="outerid"></param>
        /// <param name="token"></param>
        /// <param name="TotalNum"></param>
        /// <returns></returns>
        public IList<Item> GetGoodsByOuterId(string outerid, string token, ref int TotalNum)
        {
            return getgoods.GetGoodsByOuterId(outerid, token, ref TotalNum);
        }

        /// <summary>
        /// 批量获取商品信息 (接口有使用次数限制 5000/天的流量限制，非审核通过应用每天只能调用一次（正式环境）)
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="ListNumIids"></param>
        /// <returns></returns>
        public IList<Item> GetListItems(string sessionKey, string ListNumIids)
        {
            IList<Item> list = new List<Item>();
            try
            {
                if (!string.IsNullOrEmpty(ListNumIids))
                    if (ListNumIids.Trim().Length >= 1 && CommonFunc.CheckListGoodsId(ListNumIids))
                    {
                        list = getgoods.GetListItems(sessionKey, ListNumIids);
                        if (list == null)
                        {
                            string[] listgoodsid = ListNumIids.Split(',');
                            Item goods;
                            IList<Item> list1;
                            foreach (string item in listgoodsid)
                            {
                                if (string.IsNullOrEmpty(item)) { return null; }
                                goods = new Item();
                                list1 = new List<Item>();
                                list1 = getgoods.Getitem(sessionKey, item);
                                if (list1 != null)
                                {
                                    list.Add(list1[0]);
                                }
                            }
                        }
                    }
            }
            catch (Exception)
            {

                throw;
            }
            return list;

        }

        /// <summary>
        /// 获取单个商品信息（通过通过传入）
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="GoodsId"></param>
        /// <returns></returns>
        public IList<Item> Getitem(string sessionKey, string GoodsId)
        {
            return getgoods.Getitem(sessionKey, GoodsId);
        }

        /// <summary>
        /// 批量下架商品
        /// </summary>
        /// <param name="token"></param>
        /// <param name="list"></param>
        public void BatchUnShelve(string token, string ListGoodId)
        {
            if (CommonFunc.CheckListGoodsId(ListGoodId))
            {
                string[] list = ListGoodId.Split(',');
                foreach (string item in list)
                {
                    if (string.IsNullOrEmpty(item)) { return; }
                    setgoods.UnShelve(token, long.Parse(item));
                }
            }
        }

        /// <summary>
        /// 简单更新商品信息
        /// </summary>
        /// <param name="token"></param>
        /// <param name="goods"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        public void simpleupdategoods(string token, ItemUpdate goods, out List<string> errorMsgs)
        {
            try
            {
                IList<Item> listitems = null;
                errorMsgs = new List<string>();
                if (CommonFunc.CheckListGoodsId(goods.ListGoodsId))
                {
                    string[] ListGoodsId = goods.ListGoodsId.Split(',');
                    bool result = false;
                    List<string> listerrorMsgs = new List<string>();
                    string errorMsg;
                    foreach (string itemId in ListGoodsId)
                    {
                        if (string.IsNullOrEmpty(itemId)) { return; }
                        errorMsg = null;
                        goods.NumIid = long.Parse(itemId);

                        if (goods.Updatedtype.Equals("BatchPrice"))
                        {
                            string[] strs = goods.repalcword.Split(',');
                            double cheng = Convert.ToDouble(strs[0].Split(':')[1]);
                            double jia = Convert.ToDouble(strs[1].Split(':')[1]);
                            double jian = Convert.ToDouble(strs[2].Split(':')[1]);
                            listitems = new List<Item>();
                            listitems = getgoods.Getitem(token, itemId);
                            if (listitems.Count > 0)
                            {
                                switch (goods.repalcedword)
                                {
                                    case "0":
                                        goods.Price = (double.Parse(listitems[0].Price) * (cheng) / 100 + jia - jian).ToString();
                                        break;
                                    case "1":
                                        goods.Price = (double.Parse(listitems[0].Price) * (cheng) / 100 + jia - jian).ToString("0.0");
                                        break;
                                    case "2":
                                        goods.Price = (double.Parse(listitems[0].Price) * (cheng) / 100 + jia - jian).ToString("0");
                                        break;
                                    default:
                                        goods.Price = (double.Parse(listitems[0].Price) * (cheng) / 100 + jia - jian).ToString();
                                        break;
                                }
                            }
                        }
                        result = setgoods.UpdateGoodsPrice(token, goods, out errorMsg);
                        if (result == false)
                        {
                            string str;
                            str = "商品ID: " + goods.NumIid + ",状态: ";
                            str += result == true ? "更新成功" : "更新失败";
                            str += ",失败原因：";
                            str += errorMsg;
                            listerrorMsgs.Add(str);
                        }
                    }
                    errorMsgs = listerrorMsgs;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 批量更新商品库存
        /// </summary>
        /// <param name="token"></param>
        /// <param name="goods"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        public void UpdateStoke(string token, ItemQuantityUpdate goods, out List<string> errorMsgs)
        {
            errorMsgs = new List<string>();
            if (CommonFunc.CheckListGoodsId(goods.ListGoodsId))
            {
                string[] ListGoodsId = goods.ListGoodsId.Split(',');
                foreach (string itemId in ListGoodsId)
                {
                    string ErrorMsg = null;
                    if (string.IsNullOrEmpty(itemId)) { return; }
                    goods.NumIid = long.Parse(itemId.ToString());
                    bool result = setgoods.UpdateGoodsStoke(token, goods, out ErrorMsg);
                    if (result == false)
                    {
                        string str;
                        str = "商品ID: " + goods.NumIid + ",状态: ";
                        str += result == true ? "更新成功" : "更新失败";
                        str += ",失败原因：";
                        str += ErrorMsg;
                        errorMsgs.Add(str);
                    }
                }
            }
        }
        /// <summary>
        /// 批量更新商品
        /// </summary>
        /// <param name="token"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public void ListToUpdategoods(string token, List<ItemUpdate> list, out List<string> ErrorMsgs)
        {
            ErrorMsgs = new List<string>();
            foreach (ItemUpdate goods in list)
            {
                string ErrorMsg = null;
                bool result = setgoods.UpdateGoodsPrice(token, goods, out ErrorMsg);
                if (result == false)
                {
                    string str;
                    str = "商品ID: " + goods.NumIid + ",状态: ";
                    str += result == true ? "更新成功" : "更新失败";
                    str += ",失败原因：";
                    str += ErrorMsg;
                    ErrorMsgs.Add(str);
                }
            }
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="token"></param>
        /// <param name="goods"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        public string addgoods(string token, ItemAdd goods, out string ErrorMsg)
        {
            return setgoods.AddGoods(token, goods, out ErrorMsg);
        }

        /// <summary>
        /// 获取运费模板
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<DeliveryTemplate> GetDeliveryTemplates(string token)
        {
            return getgoods.DeliveryTemplates(token);
        }

        /// <summary>
        /// 批量修改商品标题
        /// </summary>
        /// <param name="outerid"></param>
        /// <param name="token"></param>
        /// <param name="TotalNum"></param>
        /// <returns></returns>
        public bool updateGoodsTitle(ItemUpdate goods, string token, out List<string> errorMsgs)
        {
            errorMsgs = null;
            IList<Item> list = new List<Item>();
            list = GetListItems(token, goods.ListGoodsId);
            foreach (Item item in list)
            {
                string str = item.Title;
                switch (goods.Updatedtype)
                {
                    case "1":
                        str = goods.repalcword + str;
                        break;
                    case "2":
                        str = str.Replace(goods.repalcword, goods.repalcedword);
                        break;
                    case "3":
                        str = str + goods.repalcword;
                        break;
                }
                goods.Title = str;
                goods.ListGoodsId = item.NumIid.ToString();
                simpleupdategoods(token, goods, out errorMsgs);
            }
            return true;
        }

        /// <summary>
        /// 批量修改商家编码
        /// </summary>
        /// <param name="goods"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool Updatecoding(ItemUpdate goods, string token, out List<string> errorMsgs)
        {
            errorMsgs = null;
            IList<Item> list = new List<Item>();
            list = GetListItems(token, goods.ListGoodsId);
            foreach (Item item in list)
            {
                string str = item.OuterId;
                switch (goods.Updatedtype)
                {
                    case "1":
                        str = goods.repalcword + str;
                        break;
                    case "3":
                        str = str + goods.repalcword;
                        break;
                }
                goods.OuterId = str;
                goods.ListGoodsId = item.NumIid.ToString();
                simpleupdategoods(token, goods, out errorMsgs);
            }
            return true;
        }

        /// <summary>
        /// 批量修改卖点
        /// </summary>
        /// <param name="goods"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool UpdateHotdot(ItemUpdate goods, string token, out List<string> errorMsgs)
        {
            errorMsgs = null;
            IList<Item> list = new List<Item>();
            list = GetListItems(token, goods.ListGoodsId);
            foreach (Item item in list)
            {
                string str = item.SellPoint;
                switch (goods.Updatedtype)
                {
                    case "1":
                        str = goods.repalcword + str;
                        break;
                    case "3":
                        str = str + goods.repalcword;
                        break;
                }
                goods.SellPoint = str;
                goods.ListGoodsId = item.NumIid.ToString();
                simpleupdategoods(token, goods, out errorMsgs);
            }
            return true;
        }
        /// <summary>
        /// 批量更新商品描述
        /// </summary>
        /// <param name="goods"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool UpdateGoodsDesc(ItemUpdate goods, string token, out List<string> errorMsgs)
        {
            errorMsgs = null;
            IList<Item> list = new List<Item>();
            list = GetListItems(token, goods.ListGoodsId);
            foreach (Item item in list)
            {
                string str = item.Desc;
                switch (goods.Updatedtype)
                {
                    case "1":
                        str = goods.repalcword + str;
                        break;
                    case "3":
                        str = str + goods.repalcword;
                        break;
                }
                goods.Desc = str;
                goods.ListGoodsId = item.NumIid.ToString();
                simpleupdategoods(token, goods, out errorMsgs);
            }
            return true;
        }

        /// <summary>
        /// 批量刪除商品
        /// </summary>
        /// <returns></returns>
        public void DeleteGoods(string ListGoodsId, string token)
        {
            if (CommonFunc.CheckListGoodsId(ListGoodsId))
            {
                string[] list = ListGoodsId.Split(',');

                foreach (string item in list)
                {
                    if (string.IsNullOrEmpty(item)) { return; }
                    bool result = setgoods.DelGoods(token, item);
                }
            }
        }

        /// <summary>
        /// 批量商品上架
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="GoodsId"></param>
        /// <param name="ShelfGoodsNum"></param>
        public void GoodsShelf(string token, string ListGoodsId, string ShelfGoodsNum, out List<string> errorMsgs)
        {
            errorMsgs = new List<string>();
            if (CommonFunc.CheckListGoodsId(ListGoodsId))
            {
                string[] list = ListGoodsId.Split(',');
                string erroemsg = null;
                foreach (string item in list)
                {
                    if (string.IsNullOrEmpty(item)) { return; }
                    bool result = setgoods.GoodsShelf(token, item, ShelfGoodsNum, out erroemsg);
                    if (result == true)
                    {
                        string str;
                        str = "商品ID: " + item + ",状态: ";
                        str += result == true ? "更新失败" : "更新成功";
                        str += ",失败原因：";
                        str += erroemsg;
                        errorMsgs.Add(str);
                    }
                }
            }
        }

        /// <summary>
        /// 根据商品来获取SKU，可传多项，不能超过40
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="ItemNumId"></param>
        /// <returns></returns>
        public IList<Skus> GetItemSkus(string sessionKey, string ItemNumId)
        {
            return getgoods.GetItemSkus(sessionKey, ItemNumId);
        }

        /// <summary>
        /// 将标题分词
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public string getGoodsTitlewords(string title)
        {
            List<string> result = null;
            if (!string.IsNullOrEmpty(title))
            {
                result = new List<string>();
                //将标题分词
                result = MYDZ.Tools.Utils.Segment(title);
            }
            return MYDZ.Tools.Utils.ObjectToJsonStr<List<string>>(result);
        }
    }
}
