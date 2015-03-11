using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.ItemCats;
using Top.Api;
using MYDZ.Business.TB_Logic.ItemCats;

namespace MYDZ.Business.Business_Logic.ItemCats
{
    public class GetItemCat
    {
        GetItemCats gic = new GetItemCats();
        /// <summary>
        /// 查询商家被授权品牌列表和类目列表 
        /// </summary>SellerAuthorize
        public SellerAuthorize GetAuthorizeItemcat(string sessionKey)
        {
            return gic.GetAuthorizeItemcats(sessionKey);
        }

        /// <summary>
        /// 获取后台供卖家发布商品的标准商品类目
        /// </summary>
        /// <param name="Cids"></param>
        /// <param name="ParentCid"></param>
        /// <returns></returns>
        public List<ItemCat> GetItemcats(string Cids, string ParentCid)
        {
            return gic.GetItemcats(Cids, ParentCid);
        }

        /// <summary>
        /// 获取标准商品类目属性
        /// </summary>
        /// <param name="itemprop"></param>
        /// <returns></returns>
        public List<ItemProp> GetItemprops(string cid)
        {
            ItempropsGet itemprop = new ItempropsGet();
            if (cid != null)
            {
                itemprop.Cid = long.Parse(cid);
            }
            return gic.GetItemprops(itemprop);
        }

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
            return gic.GetItemPropValues(Cid, Pvs, Type, AttrKeys);
        }
    }
}
