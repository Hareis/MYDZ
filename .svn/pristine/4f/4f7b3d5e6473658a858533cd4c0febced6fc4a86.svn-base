using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using MYDZ.Entity.Goods;
using Top.Api.Util;

namespace MYDZ.Business.TB_Logic.Goods
{
    internal class SetGoods
    {
        /// <summary>
        /// 下架商品
        /// </summary>
        /// <param name="SessionKey"></param>
        /// <param name="GoodId"></param>
        internal void UnShelve(string SessionKey, long GoodId)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ItemUpdateDelistingRequest req = new ItemUpdateDelistingRequest();
            req.NumIid = GoodId;
            ItemUpdateDelistingResponse response = client.Execute(req, SessionKey);
        }

        /// <summary>
        /// 更新商品信息
        /// </summary>
        internal bool UpdateGood(string sessionKey, ItemUpdate goods, out string ErrorMsg)
        {
            ErrorMsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ItemUpdateRequest req = new ItemUpdateRequest();
            #region 将页面数据填充到request中
            if (goods.NumIid == null)
            {
                ErrorMsg = "商品ID不能为空";
                return false;
            }
            else
            {
                req.NumIid = goods.NumIid;
            }
            if (goods.Cid != null)
            {
                req.Cid = goods.Cid;
            }
            if (goods.Props != null)
            {
                req.Props = goods.Props;
            }
            if (goods.Num != null)
            {
                req.Num = goods.Num;
            }
            if (goods.Price != null)
            {
                req.Price = goods.Price;
            }
            if (goods.Title != null)
            {
                req.Title = goods.Title;
            }
            if (goods.Desc != null)
            {
                req.Desc = goods.Desc;
            }
            if (goods.LocationState != null)
            {
                req.LocationState = goods.LocationState;
            }
            if (goods.LocationCity != null)
            {
                req.LocationCity = goods.LocationCity;
            }
            if (goods.PostFee != null)
            {
                req.PostFee = goods.PostFee;
            }
            if (goods.ExpressFee != null)
            {
                req.ExpressFee = goods.ExpressFee;
            }
            if (goods.EmsFee != null)
            {
                req.EmsFee = goods.EmsFee;
            }
            if (goods.ListTime != null)
            {
                DateTime dateTime = DateTime.Parse("2000-01-01 00:00:00");
                req.ListTime = dateTime;
            }
            if (goods.Cid != null)
            {
                req.Increment = goods.Increment;
            }
            if (goods.Image != null)
            {
                //括号中中填文件路径
                FileItem fItem = new FileItem(goods.Image[0].ToString());
                req.Image = fItem;
            }
            if (goods.StuffStatus != null)
            {
                req.StuffStatus = goods.StuffStatus;
            }
            if (goods.AuctionPoint != null)
            {
                req.AuctionPoint = goods.AuctionPoint;
            }
            if (goods.PropertyAlias != null)
            {
                req.PropertyAlias = goods.PropertyAlias;
            }
            if (goods.InputPids != null)
            {
                req.InputPids = goods.InputPids;
            }
            if (goods.SkuQuantities != null)
            {
                req.SkuQuantities = goods.SkuQuantities;
            }
            if (goods.SkuPrices != null)
            {
                req.SkuPrices = goods.SkuPrices;
            }
            if (goods.SkuProperties != null)
            {
                req.SkuProperties = "pid:vid;pid:vid";
            }
            if (goods.SellerCids != null)
            {
                req.SellerCids = goods.SellerCids;
            }
            if (goods.PostageId != null)
            {
                req.PostageId = goods.PostageId;
            }
            if (goods.OuterId != null)
            {
                req.OuterId = goods.OuterId;
            }
            if (goods.ProductId != null)
            {
                req.ProductId = goods.ProductId;
            }
            if (goods.PicPath != null)
            {
                req.PicPath = goods.PicPath;
            }
            if (goods.AutoFill != null)
            {
                req.AutoFill = goods.AutoFill;
            }
            if (goods.SkuOuterIds != null)
            {
                req.SkuOuterIds = goods.SkuOuterIds;
            }
            if (goods.IsTaobao != null)
            {
                req.IsTaobao = goods.IsTaobao;
            }
            if (goods.IsEx != null)
            {
                req.IsEx = goods.IsEx;
            }
            if (goods.Is3D != null)
            {
                req.Is3D = goods.Is3D;
            }
            if (goods.IsReplaceSku != null)
            {
                req.IsReplaceSku = goods.IsReplaceSku;
            }
            if (goods.InputStr != null)
            {
                req.InputStr = goods.InputStr;
            }
            if (goods.Lang != null)
            {
                req.Lang = goods.Lang;
            }
            if (goods.HasDiscount != null)
            {
                req.HasDiscount = goods.HasDiscount;
            }
            if (goods.HasShowcase != null)
            {
                req.HasShowcase = goods.HasShowcase;
            }
            if (goods.ApproveStatus != null)
            {
                req.ApproveStatus = goods.ApproveStatus;
            }
            if (goods.FreightPayer != null)
            {
                req.FreightPayer = goods.FreightPayer;
            }
            if (goods.ValidThru != null)
            {
                req.ValidThru = goods.ValidThru;
            }
            if (goods.HasInvoice != null)
                req.HasInvoice = goods.HasInvoice;
            if (goods.HasWarranty != null)
                req.HasWarranty = goods.HasWarranty;
            if (goods.AfterSaleId != null)
                req.AfterSaleId = goods.AfterSaleId;
            if (goods.SellPromise != null)
                req.SellPromise = goods.SellPromise;
            if (goods.CodPostageId != null)
                req.CodPostageId = goods.CodPostageId;
            if (goods.IsLightningConsignment != null)
                req.IsLightningConsignment = goods.IsLightningConsignment;
            if (goods.Weight != null)
                req.Weight = goods.Weight;
            if (goods.IsXinpin != null)
                req.IsXinpin = goods.IsXinpin;
            if (goods.SubStock != null)
                req.SubStock = goods.SubStock;
            if (goods.FoodSecurityPrdLicenseNo != null)
                req.FoodSecurityPrdLicenseNo = goods.FoodSecurityPrdLicenseNo;
            if (goods.FoodSecurityDesignCode != null)
                req.FoodSecurityDesignCode = goods.FoodSecurityDesignCode;
            if (goods.FoodSecurityFactory != null)
                req.FoodSecurityFactory = goods.FoodSecurityFactory;
            if (goods.FoodSecurityFactorySite != null)
                req.FoodSecurityFactorySite = goods.FoodSecurityFactorySite;
            if (goods.FoodSecurityContact != null)
                req.FoodSecurityContact = goods.FoodSecurityContact;
            if (goods.FoodSecurityMix != null)
                req.FoodSecurityMix = goods.FoodSecurityMix;
            if (goods.FoodSecurityPlanStorage != null)
                req.FoodSecurityPlanStorage = goods.FoodSecurityPlanStorage;
            if (goods.FoodSecurityPeriod != null)
                req.FoodSecurityPeriod = goods.FoodSecurityPeriod;
            if (goods.FoodSecurityFoodAdditive != null)
                req.FoodSecurityFoodAdditive = goods.FoodSecurityFoodAdditive;
            if (goods.FoodSecuritySupplier != null)
                req.FoodSecuritySupplier = goods.FoodSecuritySupplier;
            if (goods.FoodSecurityProductDateStart != null)
                req.FoodSecurityProductDateStart = goods.FoodSecurityProductDateStart;
            if (goods.FoodSecurityProductDateEnd != null)
                req.FoodSecurityProductDateEnd = goods.FoodSecurityProductDateEnd;
            if (goods.FoodSecurityStockDateStart != null)
                req.FoodSecurityStockDateStart = goods.FoodSecurityStockDateStart;
            if (goods.FoodSecurityStockDateEnd != null)
                req.FoodSecurityStockDateEnd = goods.FoodSecurityStockDateEnd;
            if (goods.SkuSpecIds != null)
                req.SkuSpecIds = goods.SkuSpecIds;
            if (goods.ItemSize != null)
                req.ItemSize = goods.ItemSize;
            if (goods.ItemWeight != null)
                req.ItemWeight = goods.ItemWeight;
            if (goods.ChangeProp != null)
                req.ChangeProp = goods.ChangeProp;
            if (goods.SellPoint != null)
                req.SellPoint = goods.SellPoint;
            if (goods.DescModules != null)
                req.DescModules = goods.DescModules;
            if (goods.FoodSecurityHealthProductNo != null)
                req.FoodSecurityHealthProductNo = goods.FoodSecurityHealthProductNo;
            if (goods.Barcode != null)
                req.Barcode = goods.Barcode;
            if (goods.SkuBarcode != null)
                req.SkuBarcode = goods.SkuBarcode;
            if (goods.Newprepay != null)
                req.Newprepay = goods.Newprepay;
            if (goods.IsOffline != null)
                req.IsOffline = goods.IsOffline;
            if (goods.ChaoshiExtendsInfo != null)
                req.ChaoshiExtendsInfo = goods.ChaoshiExtendsInfo;
            if (goods.SkuHdLength != null)
                req.SkuHdLength = goods.SkuHdLength;
            if (goods.SkuHdHeight != null)
                req.SkuHdHeight = goods.SkuHdHeight;
            if (goods.SkuHdLampQuantity != null)
                req.SkuHdLampQuantity = goods.SkuHdLampQuantity;
            if (goods.Qualification != null)
                req.Qualification = goods.Qualification;
            if (goods.O2oBindService != null)
                req.O2oBindService = goods.O2oBindService;
            if (goods.Ignorewarning != null)
                req.Ignorewarning = goods.Ignorewarning;
            if (goods.EmptyFields != null)
                req.EmptyFields = goods.EmptyFields;
            if (goods.LocalityLifeExpirydate != null)
                req.LocalityLifeExpirydate = goods.LocalityLifeExpirydate;
            if (goods.LocalityLifeNetworkId != null)
                req.LocalityLifeNetworkId = goods.LocalityLifeNetworkId;
            if (goods.LocalityLifeMerchant != null)
                req.LocalityLifeMerchant = goods.LocalityLifeMerchant;
            if (goods.LocalityLifeVerification != null)
                req.LocalityLifeVerification = goods.LocalityLifeVerification;
            if (goods.LocalityLifeRefundRatio != null)
                req.LocalityLifeRefundRatio = goods.LocalityLifeRefundRatio;
            if (goods.LocalityLifeChooseLogis != null)
                req.LocalityLifeChooseLogis = goods.LocalityLifeChooseLogis;
            if (goods.LocalityLifeOnsaleAutoRefundRatio != null)
                req.LocalityLifeOnsaleAutoRefundRatio = goods.LocalityLifeOnsaleAutoRefundRatio;
            if (goods.LocalityLifeRefundmafee != null)
                req.LocalityLifeRefundmafee = goods.LocalityLifeRefundmafee;
            if (goods.ScenicTicketPayWay != null)
                req.ScenicTicketPayWay = goods.ScenicTicketPayWay;
            if (goods.ScenicTicketBookCost != null)
                req.ScenicTicketBookCost = goods.ScenicTicketBookCost;
            if (goods.PaimaiInfoMode != null)
                req.PaimaiInfoMode = goods.PaimaiInfoMode;
            if (goods.PaimaiInfoDeposit != null)
                req.PaimaiInfoDeposit = goods.PaimaiInfoDeposit;
            if (goods.PaimaiInfoInterval != null)
                req.PaimaiInfoInterval = goods.PaimaiInfoInterval;
            if (goods.PaimaiInfoReserve != null)
                req.PaimaiInfoReserve = goods.PaimaiInfoReserve;
            if (goods.PaimaiInfoValidHour != null)
                req.PaimaiInfoValidHour = goods.PaimaiInfoValidHour;
            if (goods.PaimaiInfoValidMinute != null)
                req.PaimaiInfoValidMinute = goods.PaimaiInfoValidMinute;
            if (goods.GlobalStockType != null)
                req.GlobalStockType = goods.GlobalStockType;
            if (goods.GlobalStockCountry != null)
                req.GlobalStockCountry = goods.GlobalStockCountry;
            #endregion
            ItemUpdateResponse response = client.Execute(req, sessionKey);
            if (!response.IsError)
            {
                return true;
            }
            else
            {
                ErrorMsg = response.SubErrMsg;
                return false;
            }
        }
        /// <summary>
        /// 添加商品数据
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="goods"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        internal string AddGoods(string sessionKey, ItemAdd goods, out string ErrorMsg)
        {
            ErrorMsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ItemAddRequest req = new ItemAddRequest();
            #region 将页面数据填充到request中
            if (goods.Type != null)
            {
                req.Type = goods.Type;
            }
            else
            {
                ErrorMsg += "发布商品类型不能为空；";

            }
            if (goods.Cid != null)
            {
                req.Cid = goods.Cid;
            }
            else
            {
                ErrorMsg += "商品类目不能为空；";
                return null;
            }
            if (goods.Props != null)
            {
                req.Props = goods.Props;
            }

            if (goods.Num != null)
            {
                req.Num = goods.Num;
            }
            else
            {
                ErrorMsg += "商品数量不能为空；";
                return null;
            }
            if (goods.StuffStatus != null)
            {
                req.StuffStatus = goods.StuffStatus;
            }
            else
            {
                ErrorMsg += "商品新旧程度不能为空；";
                return null;
            }
            if (goods.Price != null)
            {
                req.Price = goods.Price;
            }
            else
            {
                ErrorMsg += "商品价格不能为空；";
                return null;
            }
            if (goods.Title != null)
            {
                req.Title = goods.Title;
            }
            else
            {
                ErrorMsg += "商品标题不能为空；";
                return null;
            }

            if (goods.Desc != null)
            {
                req.Desc = goods.Desc;
            }
            else
            {
                ErrorMsg += "商品描述不能为空；";
                return null;
            }
            if (goods.LocationState != null)
            {
                req.LocationState = goods.LocationState;
            }
            else
            {
                ErrorMsg += "商品所在地省份不能为空；";
                return null;
            }
            if (goods.LocationCity != null)
            {
                req.LocationCity = goods.LocationCity;
            }
            else
            {
                ErrorMsg += "商品所在地城市不能为空；";
                return null;
            }
            if (goods.PostFee != null)
            {
                req.PostFee = goods.PostFee;
            }
            if (goods.ExpressFee != null)
            {
                req.ExpressFee = goods.ExpressFee;
            }
            if (goods.EmsFee != null)
            {
                req.EmsFee = goods.EmsFee;
            }
            if (goods.ListTime != null)
            {
                req.ListTime = goods.ListTime;
            }
            if (goods.Cid != null)
            {
                req.Increment = goods.Increment;
            }
            if (goods.Image != null)
            {
                //括号中中填文件路径
                FileItem fItem = new FileItem(goods.Image[0].ToString());
                req.Image = fItem;
            }
            if (goods.StuffStatus != null)
            {
                req.StuffStatus = goods.StuffStatus;
            }
            if (goods.AuctionPoint != null)
            {
                req.AuctionPoint = goods.AuctionPoint;
            }
            if (goods.PropertyAlias != null)
            {
                req.PropertyAlias = goods.PropertyAlias;
            }
            if (goods.InputPids != null)
            {
                req.InputPids = goods.InputPids;
            }
            if (goods.SkuQuantities != null)
            {
                req.SkuQuantities = goods.SkuQuantities;
            }
            if (goods.SkuPrices != null)
            {
                req.SkuPrices = goods.SkuPrices;
            }
            if (goods.SkuProperties != null)
            {
                req.SkuProperties = "pid:vid;pid:vid";
            }
            if (goods.SellerCids != null)
            {
                req.SellerCids = goods.SellerCids;
            }
            if (goods.PostageId != null)
            {
                req.PostageId = goods.PostageId;
            }
            if (goods.OuterId != null)
            {
                req.OuterId = goods.OuterId;
            }
            if (goods.ProductId != null)
            {
                req.ProductId = goods.ProductId;
            }
            if (goods.PicPath != null)
            {
                req.PicPath = goods.PicPath;
            }
            if (goods.AutoFill != null)
            {
                req.AutoFill = goods.AutoFill;
            }
            if (goods.SkuOuterIds != null)
            {
                req.SkuOuterIds = goods.SkuOuterIds;
            }
            if (goods.IsTaobao != null)
            {
                req.IsTaobao = goods.IsTaobao;
            }
            if (goods.IsEx != null)
            {
                req.IsEx = goods.IsEx;
            }
            if (goods.Is3D != null)
            {
                req.Is3D = goods.Is3D;
            }
            if (goods.InputStr != null)
            {
                req.InputStr = goods.InputStr;
            }
            if (goods.Lang != null)
            {
                req.Lang = goods.Lang;
            }
            if (goods.HasDiscount != null)
            {
                req.HasDiscount = goods.HasDiscount;
            }
            if (goods.HasShowcase != null)
            {
                req.HasShowcase = goods.HasShowcase;
            }
            if (goods.ApproveStatus != null)
            {
                req.ApproveStatus = goods.ApproveStatus;
            }
            if (goods.FreightPayer != null)
            {
                req.FreightPayer = goods.FreightPayer;
            }
            if (goods.ValidThru != null)
            {
                req.ValidThru = goods.ValidThru;
            }
            if (goods.HasInvoice != null)
                req.HasInvoice = goods.HasInvoice;
            if (goods.HasWarranty != null)
                req.HasWarranty = goods.HasWarranty;
            if (goods.AfterSaleId != null)
                req.AfterSaleId = goods.AfterSaleId;
            if (goods.SellPromise != null)
                req.SellPromise = goods.SellPromise;
            if (goods.CodPostageId != null)
                req.CodPostageId = goods.CodPostageId;
            if (goods.IsLightningConsignment != null)
                req.IsLightningConsignment = goods.IsLightningConsignment;
            if (goods.Weight != null)
                req.Weight = goods.Weight;
            if (goods.IsXinpin != null)
                req.IsXinpin = goods.IsXinpin;
            if (goods.SubStock != null)
                req.SubStock = goods.SubStock;
            if (goods.FoodSecurityPrdLicenseNo != null)
                req.FoodSecurityPrdLicenseNo = goods.FoodSecurityPrdLicenseNo;
            if (goods.FoodSecurityDesignCode != null)
                req.FoodSecurityDesignCode = goods.FoodSecurityDesignCode;
            if (goods.FoodSecurityFactory != null)
                req.FoodSecurityFactory = goods.FoodSecurityFactory;
            if (goods.FoodSecurityFactorySite != null)
                req.FoodSecurityFactorySite = goods.FoodSecurityFactorySite;
            if (goods.FoodSecurityContact != null)
                req.FoodSecurityContact = goods.FoodSecurityContact;
            if (goods.FoodSecurityMix != null)
                req.FoodSecurityMix = goods.FoodSecurityMix;
            if (goods.FoodSecurityPlanStorage != null)
                req.FoodSecurityPlanStorage = goods.FoodSecurityPlanStorage;
            if (goods.FoodSecurityPeriod != null)
                req.FoodSecurityPeriod = goods.FoodSecurityPeriod;
            if (goods.FoodSecurityFoodAdditive != null)
                req.FoodSecurityFoodAdditive = goods.FoodSecurityFoodAdditive;
            if (goods.FoodSecuritySupplier != null)
                req.FoodSecuritySupplier = goods.FoodSecuritySupplier;
            if (goods.FoodSecurityProductDateStart != null)
                req.FoodSecurityProductDateStart = goods.FoodSecurityProductDateStart;
            if (goods.FoodSecurityProductDateEnd != null)
                req.FoodSecurityProductDateEnd = goods.FoodSecurityProductDateEnd;
            if (goods.FoodSecurityStockDateStart != null)
                req.FoodSecurityStockDateStart = goods.FoodSecurityStockDateStart;
            if (goods.FoodSecurityStockDateEnd != null)
                req.FoodSecurityStockDateEnd = goods.FoodSecurityStockDateEnd;
            if (goods.SkuSpecIds != null)
                req.SkuSpecIds = goods.SkuSpecIds;
            if (goods.ItemSize != null)
                req.ItemSize = goods.ItemSize;
            if (goods.ItemWeight != null)
                req.ItemWeight = goods.ItemWeight;
            if (goods.ChangeProp != null)
                req.ChangeProp = goods.ChangeProp;
            if (goods.SellPoint != null)
                req.SellPoint = goods.SellPoint;
            if (goods.DescModules != null)
                req.DescModules = goods.DescModules;
            if (goods.FoodSecurityHealthProductNo != null)
                req.FoodSecurityHealthProductNo = goods.FoodSecurityHealthProductNo;
            if (goods.Barcode != null)
                req.Barcode = goods.Barcode;
            if (goods.SkuBarcode != null)
                req.SkuBarcode = goods.SkuBarcode;
            if (goods.Newprepay != null)
                req.Newprepay = goods.Newprepay;
            if (goods.IsOffline != null)
                req.IsOffline = goods.IsOffline;
            if (goods.SkuHdLength != null)
                req.SkuHdLength = goods.SkuHdLength;
            if (goods.SkuHdHeight != null)
                req.SkuHdHeight = goods.SkuHdHeight;
            if (goods.SkuHdLampQuantity != null)
                req.SkuHdLampQuantity = goods.SkuHdLampQuantity;
            if (goods.Qualification != null)
                req.Qualification = goods.Qualification;
            if (goods.O2oBindService != null)
                req.O2oBindService = goods.O2oBindService;
            if (goods.LocalityLifeExpirydate != null)
                req.LocalityLifeExpirydate = goods.LocalityLifeExpirydate;
            if (goods.LocalityLifeNetworkId != null)
                req.LocalityLifeNetworkId = goods.LocalityLifeNetworkId;
            if (goods.LocalityLifeMerchant != null)
                req.LocalityLifeMerchant = goods.LocalityLifeMerchant;
            if (goods.LocalityLifeVerification != null)
                req.LocalityLifeVerification = goods.LocalityLifeVerification;
            if (goods.LocalityLifeRefundRatio != null)
                req.LocalityLifeRefundRatio = goods.LocalityLifeRefundRatio;
            if (goods.LocalityLifeChooseLogis != null)
                req.LocalityLifeChooseLogis = goods.LocalityLifeChooseLogis;
            if (goods.LocalityLifeOnsaleAutoRefundRatio != null)
                req.LocalityLifeOnsaleAutoRefundRatio = goods.LocalityLifeOnsaleAutoRefundRatio;
            if (goods.LocalityLifeRefundmafee != null)
                req.LocalityLifeRefundmafee = goods.LocalityLifeRefundmafee;
            if (goods.ScenicTicketPayWay != null)
                req.ScenicTicketPayWay = goods.ScenicTicketPayWay;
            if (goods.ScenicTicketBookCost != null)
                req.ScenicTicketBookCost = goods.ScenicTicketBookCost;
            if (goods.PaimaiInfoMode != null)
                req.PaimaiInfoMode = goods.PaimaiInfoMode;
            if (goods.PaimaiInfoDeposit != null)
                req.PaimaiInfoDeposit = goods.PaimaiInfoDeposit;
            if (goods.PaimaiInfoInterval != null)
                req.PaimaiInfoInterval = goods.PaimaiInfoInterval;
            if (goods.PaimaiInfoReserve != null)
                req.PaimaiInfoReserve = goods.PaimaiInfoReserve;
            if (goods.PaimaiInfoValidHour != null)
                req.PaimaiInfoValidHour = goods.PaimaiInfoValidHour;
            if (goods.PaimaiInfoValidMinute != null)
                req.PaimaiInfoValidMinute = goods.PaimaiInfoValidMinute;
            if (goods.GlobalStockType != null)
                req.GlobalStockType = goods.GlobalStockType;
            if (goods.GlobalStockCountry != null)
                req.GlobalStockCountry = goods.GlobalStockCountry;
            #endregion
            ItemAddResponse response = client.Execute(req, sessionKey);
            if (!response.IsError)
            {
                string Result = response.Item.NumIid.ToString();
                return Result;
            }
            else
            {
                ErrorMsg = response.SubErrMsg;
                return null;
            }
        }

        /// <summary>
        /// 更新商品价格 
        /// </summary>
        internal bool UpdateGoodsPrice(string sessionKey, ItemUpdate goods, out string ErrorMsg)
        {
            ErrorMsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ItemPriceUpdateRequest req = new ItemPriceUpdateRequest();
            #region 将页面数据填充到request中
            if (goods.NumIid != null)
            {
                req.NumIid = goods.NumIid;
            }
            else
            {
                ErrorMsg += "商品ID不能为空；";
                return false;
            }

            if (goods.Cid != null)
            {
                req.Cid = goods.Cid;
            }

            if (goods.Props != null)
            {
                req.Props = goods.Props;
            }

            if (goods.Num != null)
            {
                req.Num = goods.Num;
            }
            if (goods.StuffStatus != null)
            {
                req.StuffStatus = goods.StuffStatus;
            }
            if (goods.Price != null)
            {
                req.Price = goods.Price;
            }
            if (goods.Title != null)
            {
                req.Title = goods.Title;
            }

            if (goods.Desc != null)
            {
                req.Desc = goods.Desc;
            }
            if (goods.LocationState != null)
            {
                req.LocationState = goods.LocationState;
            }
            if (goods.LocationCity != null)
            {
                req.LocationCity = goods.LocationCity;
            }
            if (goods.PostFee != null)
            {
                req.PostFee = goods.PostFee;
            }
            if (goods.ExpressFee != null)
            {
                req.ExpressFee = goods.ExpressFee;
            }
            if (goods.EmsFee != null)
            {
                req.EmsFee = goods.EmsFee;
            }
            if (goods.ListTime != null)
            {
                req.ListTime = goods.ListTime;
            }
            if (goods.Cid != null)
            {
                req.Increment = goods.Increment;
            }
            if (goods.Image != null)
            {
                //括号中中填文件路径
                FileItem fItem = new FileItem(goods.Image[0].ToString());
                req.Image = fItem;
            }
            if (goods.StuffStatus != null)
            {
                req.StuffStatus = goods.StuffStatus;
            }
            if (goods.AuctionPoint != null)
            {
                req.AuctionPoint = goods.AuctionPoint;
            }
            if (goods.PropertyAlias != null)
            {
                req.PropertyAlias = goods.PropertyAlias;
            }
            if (goods.InputPids != null)
            {
                req.InputPids = goods.InputPids;
            }
            if (goods.SkuQuantities != null)
            {
                req.SkuQuantities = goods.SkuQuantities;
            }
            if (goods.SkuPrices != null)
            {
                req.SkuPrices = goods.SkuPrices;
            }
            if (goods.SkuProperties != null)
            {
                req.SkuProperties = "pid:vid;pid:vid";
            }
            if (goods.SellerCids != null)
            {
                req.SellerCids = goods.SellerCids;
            }
            if (goods.PostageId != null)
            {
                req.PostageId = goods.PostageId;
            }
            if (goods.OuterId != null)
            {
                req.OuterId = goods.OuterId;
            }
            if (goods.ProductId != null)
            {
                req.ProductId = goods.ProductId;
            }
            if (goods.PicPath != null)
            {
                req.PicPath = goods.PicPath;
            }
            if (goods.AutoFill != null)
            {
                req.AutoFill = goods.AutoFill;
            }
            if (goods.SkuOuterIds != null)
            {
                req.SkuOuterIds = goods.SkuOuterIds;
            }
            if (goods.IsTaobao != null)
            {
                req.IsTaobao = goods.IsTaobao;
            }
            if (goods.IsEx != null)
            {
                req.IsEx = goods.IsEx;
            }
            if (goods.Is3D != null)
            {
                req.Is3D = goods.Is3D;
            }
            if (goods.InputStr != null)
            {
                req.InputStr = goods.InputStr;
            }
            if (goods.Lang != null)
            {
                req.Lang = goods.Lang;
            }
            if (goods.HasDiscount != null)
            {
                req.HasDiscount = goods.HasDiscount;
            }
            if (goods.HasShowcase != null)
            {
                req.HasShowcase = goods.HasShowcase;
            }
            if (goods.ApproveStatus != null)
            {
                req.ApproveStatus = goods.ApproveStatus;
            }
            if (goods.FreightPayer != null)
            {
                req.FreightPayer = goods.FreightPayer;
            }
            if (goods.ValidThru != null)
            {
                req.ValidThru = goods.ValidThru;
            }
            if (goods.HasInvoice != null)
                req.HasInvoice = goods.HasInvoice;
            if (goods.HasWarranty != null)
                req.HasWarranty = goods.HasWarranty;
            if (goods.AfterSaleId != null)
                req.AfterSaleId = goods.AfterSaleId;
            if (goods.SellPromise != null)
                req.SellPromise = goods.SellPromise;
            if (goods.CodPostageId != null)
                req.CodPostageId = goods.CodPostageId;
            if (goods.IsLightningConsignment != null)
                req.IsLightningConsignment = goods.IsLightningConsignment;
            if (goods.Weight != null)
                req.Weight = goods.Weight;
            if (goods.IsXinpin != null)
                req.IsXinpin = goods.IsXinpin;
            if (goods.SubStock != null)
                req.SubStock = goods.SubStock;

            #endregion
            ItemPriceUpdateResponse response = client.Execute(req, sessionKey);
            if (!response.IsError)
            {
                return true;
            }
            else
            {
                ErrorMsg = response.SubErrMsg;
                return false;
            }
        }

        /// <summary>
        /// 更新库存
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="goods"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        internal bool UpdateGoodsStoke(string sessionKey, ItemQuantityUpdate goods, out string ErrorMsg)
        {
            ErrorMsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ItemQuantityUpdateRequest req = new ItemQuantityUpdateRequest();
            if (goods.NumIid != null)
                req.NumIid = goods.NumIid;
            if (goods.SkuId != null)
                req.SkuId = goods.SkuId;
            if (goods.OuterId != null)
                req.OuterId = goods.OuterId;
            if (goods.Quantity != null)
                req.Quantity = goods.Quantity;
            if (goods.Type != null)
                req.Type = goods.Type;
            ItemQuantityUpdateResponse response = client.Execute(req, sessionKey);
            if (!response.IsError)
            {
                return true;
            }
            else
            {
                ErrorMsg = response.SubErrMsg;
                return false;
            }
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        internal bool DelGoods(string sessionKey, string GoodsId)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ItemDeleteRequest req = new ItemDeleteRequest();
            req.NumIid = long.Parse(GoodsId);
            ItemDeleteResponse response = client.Execute(req, sessionKey);
            return response.IsError;
        }

        /// <summary>
        /// 一口價商品上架
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="GoodsId"></param>
        /// <param name="ShelfGoodsNum"></param>
        /// <returns></returns>
        internal bool GoodsShelf(string sessionKey, string GoodsId, string ShelfGoodsNum, out string errorMsg)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ItemUpdateListingRequest req = new ItemUpdateListingRequest();
            req.NumIid = long.Parse(GoodsId);
            req.Num = long.Parse(ShelfGoodsNum);
            ItemUpdateListingResponse response = client.Execute(req, sessionKey);
            errorMsg = response.SubErrMsg;
            return response.IsError;
        }

    }
}
