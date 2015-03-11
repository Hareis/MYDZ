using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using MYDZ.Entity.Goods;
using MYDZ.Tools;
using Top.Api.Parser;
using System.Xml.Serialization;

namespace MYDZ.Business.TB_Logic.Goods
{
    internal class GetGoods
    {
        /// <summary>
        /// 查询在售商品
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="Query"></param>
        internal IList<Item> SearchOnsalesByCriteria(string sessionKey, ref int TotalNum, QueryCriteriaForOnSales Query)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ItemsOnsaleGetRequest req = new ItemsOnsaleGetRequest();
            req.Fields = "approve_status,num_iid,title,nick,type,cid,pic_url,num,props,valid_thru,list_time,price,has_discount,has_invoice,has_warranty,has_showcase,modified,delist_time,postage_id,seller_cids,outer_id,sku";
            if (Query.Q != null)
                req.Q = Query.Q;
            if (Query.Cid != null)
                req.Cid = Query.Cid;
            if (Query.SellerCids != null)
                req.SellerCids = Query.SellerCids;
            if (Query.PageNo != null)
                req.PageNo = Query.PageNo;
            else
                req.PageNo = 1;
            if (Query.PageSize != null)
                req.PageSize = Query.PageSize;
            else
                req.PageSize = 10;
            if (Query.HasDiscount != null)
                req.HasDiscount = Query.HasDiscount;
            if (Query.HasShowcase != null)
                req.HasShowcase = Query.HasShowcase;
            if (Query.OrderBy != null)
                req.OrderBy = Query.OrderBy;
            if (Query.IsTaobao != null)
                req.IsTaobao = Query.IsTaobao;
            if (Query.IsEx != null)
                req.IsEx = Query.IsEx;
            if (Query.StartModified != null)
                req.StartModified = Query.StartModified;
            if (Query.EndModified != null)
                req.EndModified = Query.EndModified;
            if (Query.IsCspu != null)
                req.IsCspu = Query.IsCspu;
            ItemsOnsaleGetResponse response = client.Execute(req, sessionKey);
            TotalNum = (int)response.TotalResults;
            return ChangeTypeForItem(response.Body);
        }

        /// <summary>
        /// 查询仓库中的商品
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        internal IList<Item> SearchInventoryByCriteria(string sessionKey, ref int TotalNum, QueryCriteriaForInventory Query)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ItemsInventoryGetRequest req = new ItemsInventoryGetRequest();
            req.Fields = "approve_status,num_iid,title,nick,type,cid,pic_url,num,props,valid_thru, list_time,price,has_discount,has_invoice,has_warranty,has_showcase, modified,delist_time,postage_id,seller_cids,outer_id";
            if (Query.Q != null)
                req.Q = Query.Q;
            if (Query.Banner != null)
                req.Banner = Query.Banner;
            if (Query.Cid != null)
                req.Cid = Query.Cid;
            if (Query.SellerCids != null)
                req.SellerCids = Query.SellerCids;
            if (Query.PageNo != null)
                req.PageNo = Query.PageNo;
            else
                req.PageNo = 1;
            if (Query.PageSize != null)
                req.PageSize = Query.PageSize;
            else
                req.PageSize = 10;
            if (Query.HasDiscount != null)
                req.HasDiscount = Query.HasDiscount;
            if (Query.OrderBy != null)
                req.OrderBy = Query.OrderBy;
            if (Query.IsTaobao != null)
                req.IsTaobao = Query.IsTaobao;
            if (Query.IsEx != null)
                req.IsEx = Query.IsEx;
            if (Query.StartModified != null)
                req.StartModified = Query.StartModified;
            if (Query.EndModified != null)
                req.EndModified = Query.EndModified;
            if (Query.IsCspu != null)
                req.IsCspu = Query.IsCspu;
            ItemsInventoryGetResponse response = client.Execute(req, sessionKey);
            TotalNum = (int)response.TotalResults;
            return ChangeTypeForItem(response.Body);
        }

        /// <summary>
        /// 根据外部ID获取商品
        /// </summary>
        /// <param name="OuterId"></param>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        internal IList<Item> GetGoodsByOuterId(string OuterId, string sessionKey, ref int TotalNum)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");

            ItemsCustomGetRequest req = new ItemsCustomGetRequest();

            req.OuterId = OuterId;
            req.Fields = "approve_status,num_iid,title,nick,type,cid,pic_url,num,props,valid_thru,list_time,price,has_discount,has_invoice,has_warranty,has_showcase,modified,delist_time,postage_id,seller_cids,outer_id";
            ItemsCustomGetResponse response = client.Execute(req, sessionKey);
            TotalNum = 1;
            return ChangeTypeForItem(response.Body);
        }



        /// <summary>
        /// 将淘宝类型转化为本地类型
        /// </summary>
        /// <param name="str">获得的商品列表JSon </param>
        /// <returns></returns>
        internal IList<Item> ChangeTypeForItem(string str)
        {
            TopJsonParser topjson = new TopJsonParser();
            ItemsOnsaleGetResponse1 resp = topjson.Parse<ItemsOnsaleGetResponse1>(str);
            return resp.Items;
            //itemsresponse result = Utils.JsonStrToObject<itemsresponse>(str);
            #region    待验证的代码 （无用）
            //IList<Item> result = null;
            //foreach (Top.Api.Domain.Item item in Ilist)
            //{

            //Item proc = new Item();
            //proc.AfterSaleId = item.AfterSaleId;
            //proc.ApproveStatus = item.ApproveStatus;
            //proc.AuctionPoint = item.AuctionPoint;
            //proc.AutoFill = item.AutoFill;
            //proc.Barcode = item.Barcode;
            //proc.ChangeProp = item.ChangeProp;
            //proc.Cid = item.Cid;
            //proc.CodPostageId = item.CodPostageId;
            //proc.Created = item.Created;
            //proc.CustomMadeTypeId = item.CustomMadeTypeId;
            //proc.DelistTime = item.DelistTime;
            //proc.DeliveryTime = new DeliveryTime();
            //proc.DeliveryTime.DeliveryTime_ = item.DeliveryTime.DeliveryTime_;
            //proc.DeliveryTime.DeliveryTimeType = item.DeliveryTime.DeliveryTimeType;
            //proc.DeliveryTime.NeedDeliveryTime = item.DeliveryTime.NeedDeliveryTime;
            //proc.Desc = item.Desc;
            //proc.DescModuleInfo = new DescModuleInfo();
            //proc.DescModuleInfo.AnchorModuleIds = item.DescModuleInfo.AnchorModuleIds;
            //proc.DescModuleInfo.Type = item.DescModuleInfo.Type;
            //proc.DescModules = item.DescModules;
            //proc.DetailUrl = item.DetailUrl;
            //proc.EmsFee = item.EmsFee;
            //proc.ExpressFee = item.ExpressFee;
            //proc.Features = item.Features;
            //proc.FoodSecurity = new FoodSecurity();
            //proc.FoodSecurity.Contact = item.FoodSecurity.Contact;
            //proc.FoodSecurity.DesignCode = item.FoodSecurity.DesignCode;
            //proc.FoodSecurity.Factory = item.FoodSecurity.Factory;
            //proc.FoodSecurity.FactorySite = item.FoodSecurity.FactorySite;
            //proc.FoodSecurity.FoodAdditive = item.FoodSecurity.FoodAdditive;
            //proc.FoodSecurity.HealthProductNo = item.FoodSecurity.HealthProductNo;
            //proc.FoodSecurity.Mix = item.FoodSecurity.Mix;
            //proc.FoodSecurity.Period = item.FoodSecurity.Period;
            //proc.FoodSecurity.PlanStorage = item.FoodSecurity.PlanStorage;
            //proc.FoodSecurity.PrdLicenseNo = item.FoodSecurity.PrdLicenseNo;
            //proc.FoodSecurity.ProductDateEnd = item.FoodSecurity.ProductDateEnd;

            //  result.Add(proc);
            //}
            #endregion
            // return result.items_onsale_get_response.items.item;
        }

        internal class ItemsOnsaleGetResponse1 : TopResponse
        {
            /// <summary>
            /// 搜索到的商品列表，具体字段根据设定的fields决定，不包括desc字段
            /// </summary>
            [XmlArray("items")]
            [XmlArrayItem("item")]
            public List<MYDZ.Entity.Goods.Item> Items { get; set; }
        }

        /// <summary>
        /// 运费模板
        /// </summary>
        internal List<DeliveryTemplate> DeliveryTemplates(string sessionKey)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            DeliveryTemplatesGetRequest req = new DeliveryTemplatesGetRequest();
            req.Fields = "template_id,template_name,created,modified,supports,assumer,valuation,query_express,query_ems,query_cod,query_post";
            DeliveryTemplatesGetResponse response = client.Execute(req, sessionKey);
            List<Top.Api.Domain.DeliveryTemplate> list = new List<Top.Api.Domain.DeliveryTemplate>();
            list = response.DeliveryTemplates;
            List<DeliveryTemplate> result = new List<DeliveryTemplate>();
            foreach (Top.Api.Domain.DeliveryTemplate item in list)
            {
                DeliveryTemplate dt = new DeliveryTemplate();
                dt.Address = item.Address;
                dt.Assumer = item.Assumer;
                dt.ConsignAreaId = item.ConsignAreaId;
                dt.Created = item.Created;
                dt.FeeList = new List<TopFee>();
                foreach (Top.Api.Domain.TopFee child in item.FeeList)
                {
                    TopFee ft = new TopFee();
                    ft.AddFee = child.AddFee;
                    ft.AddStandard = child.AddStandard;
                    ft.Destination = child.Destination;
                    ft.ServiceType = child.ServiceType;
                    ft.StartFee = child.ServiceType;
                    ft.StartStandard = child.StartStandard;
                    dt.FeeList.Add(ft);
                }
                dt.Modified = item.Modified;
                dt.Name = item.Name;
                dt.Supports = item.Supports;
                dt.TemplateId = item.TemplateId;
                dt.Valuation = item.Valuation;
                result.Add(dt);
            }
            return result;
        }


        /// <summary>
        /// 批量获取商品信息
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        internal IList<Item> GetListItems(string sessionKey, string ListNumIids)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ItemsListGetRequest req = new ItemsListGetRequest();
            req.Fields = "approve_status,num_iid,title,nick,type,desc,skus,cid,pic_url,num,props,valid_thru, list_time,price,has_discount,has_invoice,has_warranty,has_showcase, modified,delist_time,postage_id,seller_cids,outer_id";
            req.NumIids = ListNumIids;
            ItemsListGetResponse response = client.Execute(req, sessionKey);
            return ChangeTypeForItem(response.Body);
        }

        /// <summary>
        /// 根据商品ID获取单个商品信息
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="GoodsId"></param>
        /// <returns></returns>
        internal IList<Item> Getitem(string sessionKey, string GoodsId)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ItemGetRequest req = new ItemGetRequest();
            req.Fields = "approve_status,num_iid,title,nick,type,desc,skus,cid,pic_url,num,props,valid_thru, list_time,price,has_discount,has_invoice,has_warranty,has_showcase, modified,delist_time,postage_id,seller_cids,outer_id";
            req.NumIid = long.Parse(GoodsId);
            ItemGetResponse response = client.Execute(req, sessionKey);
            return ChangeTypeForItem(response.Body);
        }

        /// <summary>
        /// 通过商品ID来获取SKU（可传多项ID，不能超过40！）
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="ItemNumId"></param>
        /// <returns></returns>
        internal IList<Skus> GetItemSkus(string sessionKey, string ItemNumId)
        {
            IList<Skus> list = new List<Skus>();
            Skus sku;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ItemSkusGetRequest req = new ItemSkusGetRequest();
            req.Fields = "properties_name,sku_spec_id,with_hold_quantity,sku_delivery_time,change_prop,outer_id,barcode,sku_id,iid,num_iid,properties,quantity,price,created,modified,status";
            if (string.IsNullOrEmpty(ItemNumId)) { return null; }
            req.NumIids = ItemNumId;
            ItemSkusGetResponse response = client.Execute(req, sessionKey);
            if (response.IsError)
            {
                return null;
            }
            else
            {
                if (response.Skus != null)
                {
                    foreach (Top.Api.Domain.Sku item in response.Skus)
                    {
                        sku = new Skus();
                        sku.Barcode = item.Barcode;
                        sku.ChangeProp = item.ChangeProp;
                        sku.Created = item.Created;
                        sku.Iid = item.Iid;
                        sku.Modified = item.Modified;
                        sku.NumIid = item.NumIid;
                        sku.OuterId = item.OuterId;
                        sku.Price = item.Price;
                        sku.Properties = item.Properties;
                        sku.PropertiesName = item.PropertiesName;
                        sku.Quantity = item.Quantity;
                        sku.SkuDeliveryTime = item.SkuDeliveryTime;
                        sku.SkuId = item.SkuId;
                        sku.SkuSpecId = item.SkuSpecId;
                        sku.Status = item.Status;
                        sku.WithHoldQuantity = item.WithHoldQuantity;
                        list.Add(sku);
                    }
                }
            }
            return list;
        }
    }
}
