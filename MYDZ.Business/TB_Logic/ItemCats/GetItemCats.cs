using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.ItemCats;
using Top.Api;
using System.Xml.Serialization;
using Top.Api.Request;
using Top.Api.Response;
using Top.Api.Parser;
using MYDZ.Entity.Goods;

namespace MYDZ.Business.TB_Logic.ItemCats
{
    internal class GetItemCats
    {
        /// <summary>
        /// 查询商家被授权品牌列表和类目列表 
        /// </summary>
        internal SellerAuthorize GetAuthorizeItemcats(string sessionKey)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ItemcatsAuthorizeGetRequest req = new ItemcatsAuthorizeGetRequest();
            req.Fields = "brand.vid, brand.name, item_cat.cid, item_cat.name, item_cat.status,item_cat.sort_order,item_cat.parent_cid,item_cat.is_parent, xinpin_item_cat.cid, xinpin_item_cat.name, xinpin_item_cat.status, xinpin_item_cat.sort_order, xinpin_item_cat.parent_cid, xinpin_item_cat.is_parent";
            ItemcatsAuthorizeGetResponse response = client.Execute(req, sessionKey);

            TopJsonParser topjson = new TopJsonParser();
            ItemcatsAuthorizeGetResponse1 resp = topjson.Parse<ItemcatsAuthorizeGetResponse1>(response.Body);
            return resp.SellerAuthorize;
        }
        #region
        internal class ItemcatsAuthorizeGetResponse1 : TopResponse
        {
            /// <summary>
            /// 里面有3个数组：  Brand[]品牌列表,  ItemCat[] 类目列表  XinpinItemCat[] 针对于C卖家新品类目列表
            /// </summary>
            [XmlElement("seller_authorize")]
            public SellerAuthorize SellerAuthorize { get; set; }
        }
        #endregion

        /// <summary>
        /// 获取后台供卖家发布商品的标准商品类目
        /// </summary>
        internal List<ItemCat> GetItemcats(string Cids, string ParentCid)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ItemcatsGetRequest req = new ItemcatsGetRequest();
            req.Fields = "features,taosir_cat,cid,parent_cid,name,is_parent,status,sort_order";
            if (ParentCid != null)
            {
                req.ParentCid = long.Parse(ParentCid);
            }
            if (Cids != null)
            {
                req.Cids = Cids;
            }
            ItemcatsGetResponse response = client.Execute(req);
            List<ItemCat> ListItemCat = new List<ItemCat>();
            ItemCat newitem;
            if (response.ItemCats == null) { return null; }
            foreach (Top.Api.Domain.ItemCat item in response.ItemCats)
            {
                newitem = new ItemCat();
                newitem.Cid = item.Cid;
                newitem.Features = new List<Feature>();
                newitem.IsParent = item.IsParent;
                newitem.Name = item.Name;
                newitem.ParentCid = item.ParentCid;
                newitem.SortOrder = item.SortOrder;
                newitem.Status = item.Status;
                if (!item.IsParent)
                {
                    List<Feature> ListFeature = new List<Feature>();
                    Feature newfea;
                    if (item.Features != null)
                    {
                        foreach (Top.Api.Domain.Feature itemchid in item.Features)
                        {
                            newfea = new Feature();
                            newfea.AttrKey = itemchid.AttrKey;
                            newfea.AttrValue = itemchid.AttrValue;
                            ListFeature.Add(newfea);
                        }
                    }
                }
                ListItemCat.Add(newitem);
            }
            return ListItemCat;
        }


        /// <summary>
        /// 获取标准商品类目属性
        /// </summary>
        /// <param name="itemprop"></param>
        /// <returns></returns>
        internal List<ItemProp> GetItemprops(ItempropsGet itemprop)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ItempropsGetRequest req = new ItempropsGetRequest();
            req.Fields = "is_input_prop,type,modified_time,modified_type,cid,required,features,is_taosir,taosir_do,pid,parent_pid,parent_vid,name,is_key_prop,is_sale_prop,is_color_prop,is_enum_prop,is_item_prop,must,multi,prop_values,status,sort_order,child_template,is_allow_alias";
            req.Cid = itemprop.Cid;
            req.Pid = itemprop.Pid;
            req.ParentPid = itemprop.ParentPid;
            req.IsKeyProp = itemprop.IsKeyProp;
            req.IsSaleProp = itemprop.IsSaleProp;
            req.IsColorProp = itemprop.IsColorProp;
            req.IsEnumProp = itemprop.IsEnumProp;
            req.IsInputProp = itemprop.IsInputProp;
            req.IsItemProp = itemprop.IsItemProp;
            req.ChildPath = itemprop.ChildPath;
            req.Type = itemprop.Type;
            req.AttrKeys = itemprop.AttrKeys;
            ItempropsGetResponse response = client.Execute(req);

            TopJsonParser topjson = new TopJsonParser();
            ItempropsGetResponse1 resp = topjson.Parse<ItempropsGetResponse1>(response.Body);
            return resp.ItemProps;

        }
        #region
        /// <summary>
        /// 临时转化类
        /// </summary>
        private class ItempropsGetResponse1 : TopResponse
        {
            /// <summary>
            /// 类目属性信息(如果是取全量或者增量，不包括属性值),根据fields传入的参数返回相应的结果
            /// </summary>
            [XmlArray("item_props")]
            [XmlArrayItem("item_prop")]
            public List<ItemProp> ItemProps { get; set; }

            /// <summary>
            /// 最近修改时间(只有取全量或增量的时候会返回该字段)。格式:yyyy-MM-dd HH:mm:ss
            /// </summary>
            [XmlElement("last_modified")]
            public string LastModified { get; set; }
        }
        #endregion

        /// <summary>
        /// 获取标准类目属性值
        /// </summary>
        /// <param name="Cid">叶子类目ID </param>
        /// <param name="Pvs">属性和属性值 id串，格式例如(pid1;pid2)或(pid1:vid1;pid2:vid2)或(pid1;pid2:vid2)</param>
        /// <param name="Type">获取类目的类型：1代表集市、2代表天猫</param>
        /// <param name="AttrKeys">属性的Key，支持多条，以“,”分隔</param>
        /// <returns></returns>
        public List<PropValue> GetItemPropValues(string Cid, string Pvs, string Type, string AttrKeys)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            ItempropvaluesGetRequest req = new ItempropvaluesGetRequest();
            req.Fields = "cid,pid,prop_name,vid,name,name_alias,status,sort_order";
            if (Cid != null)
                req.Cid = long.Parse(Cid);
            else
            {
                return null;
            }
            if (Pvs != null)
            {
                req.Pvs = Pvs;
            }
            if (Type != null)
            {
                req.Type = long.Parse(Type);
            }
            if (AttrKeys != null)
            {
                req.AttrKeys = AttrKeys;
            }
            ItempropvaluesGetResponse response = client.Execute(req);

            TopJsonParser topjson = new TopJsonParser();
            ItempropvaluesGetResponse1 resp = topjson.Parse<ItempropvaluesGetResponse1>(response.Body);
            return resp.PropValues;
        }
        private class ItempropvaluesGetResponse1 : TopResponse
        {
            [XmlElement("last_modified")]
            public string LastModified { get; set; }
            [XmlArray("prop_values")]
            [XmlArrayItem("prop_value")]
            public List<PropValue> PropValues { get; set; }
        }
    }
}
