using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Config;
using System.Collections;
using Top.Api.Request;
using Top.Api.Response;
using Top.Api;
using MYDZ.Entity.Shop;
using Top.Api.Parser;
using System.Xml.Serialization;
using MYDZ.Entity.ItemCats;

namespace MYDZ.Business.TB_Logic.Shop
{
    internal class GetShop
    {
        /// <summary>
        /// 获取店铺信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="ScoreId"></param>
        /// <returns></returns>
        internal tbShopInfo GetInfoFromTb(string NickName, int ScoreId)
        {
            tbShopInfo shopinfo = new tbShopInfo();
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret);
            ShopGetRequest req = new ShopGetRequest();
            req.Fields = "sid,cid,title,nick,desc,bulletin,pic_path,created,modified";
            req.Nick = NickName;
            ShopGetResponse response = client.Execute(req);
            Top.Api.Domain.Shop shop = response.Shop;

            shopinfo.Bulletin = shop.Bulletin;
            shopinfo.CateId = (int)shop.Cid;
            shopinfo.Created = DateTime.Parse(shop.Created);
            shopinfo.Desc = shop.Desc;
            shopinfo.Modified = DateTime.Parse(shop.Modified);
            shopinfo.NickName = shop.Nick;
            shopinfo.PicPath = shop.PicPath;
            shopinfo.Score = new tbShopScore();
            shopinfo.Score.ScoreId = ScoreId;
            if (shop.ShopScore != null)
            {
                shopinfo.Score.ItemScore = shop.ShopScore.ItemScore;
                shopinfo.Score.ServiceScore = shop.ShopScore.ServiceScore;
                shopinfo.Score.DeliveryScore = shop.ShopScore.DeliveryScore;
            }
            shopinfo.TbShopId = (int)shop.Sid;
            shopinfo.Title = shop.Title;

            return shopinfo;
        }
        /// <summary>
        /// 获取前台展示的店铺内卖家自定义商品类目
        /// </summary>
        /// <param name="NickName"></param>
        internal List<SellerCat> GetSPLM(string NickName)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            SellercatsListGetRequest req = new SellercatsListGetRequest();
            req.Nick = NickName;
            SellercatsListGetResponse response = client.Execute(req);
            TopJsonParser topjson = new TopJsonParser();
            SellercatsListGetResponse1 resp = topjson.Parse<SellercatsListGetResponse1>(response.Body);
            return resp.SellerCats;
        }
        internal class SellercatsListGetResponse1 : TopResponse
        {
            public SellercatsListGetResponse1() { }

            [XmlArray("seller_cats")]
            [XmlArrayItem("seller_cat")]
            public List<SellerCat> SellerCats { get; set; }
        }

        /// <summary>
        /// 获取前台展示的店铺类目
        /// </summary>
        internal List<ShopCat> GetDPLM()
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ShopcatsListGetRequest req = new ShopcatsListGetRequest();
            req.Fields = "cid,parent_cid,name,is_parent";
            ShopcatsListGetResponse response = client.Execute(req);
            List<Top.Api.Domain.ShopCat> listshopcat = response.ShopCats;
            List<ShopCat> Listshopcate = new List<ShopCat>();
            foreach (Top.Api.Domain.ShopCat item in listshopcat)
            {
                ShopCat shopcat = new ShopCat();
                shopcat.Cid = item.Cid;
                shopcat.IsParent = item.IsParent;
                shopcat.Name = item.Name;
                shopcat.ParentCid = item.ParentCid;
                Listshopcate.Add(shopcat);
            }
            return Listshopcate;
        }

    }
}
