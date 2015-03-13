using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MYDZ.Entity.ItemCats
{
    [Serializable]
    public class SellerAuthorize : Response
    {
        /// <summary>
        /// 品牌列表
        /// </summary>
        [XmlArray("brands")]
        [XmlArrayItem("brand")]
        public List<Brand> Brands { get; set; }

        /// <summary>
        /// 类目列表
        /// </summary>
        [XmlArray("item_cats")]
        [XmlArrayItem("item_cat")]
        public List<ItemCat> ItemCats { get; set; }

        /// <summary>
        /// 被授权的新品类目列表
        /// </summary>
        [XmlArray("xinpin_item_cats")]
        [XmlArrayItem("item_cat")]
        public List<ItemCat> XinpinItemCats { get; set; }
    }
}
