﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.ItemCats
{
    public class ItempropsGet : Response
    {
        /// <summary>
        /// 属性的Key，支持多条，以“,”分隔
        /// </summary>
        public string AttrKeys { get; set; }

        /// <summary>
        /// 类目子属性路径,由该子属性上层的类目属性和类目属性值组成,格式pid:vid;pid:vid.取类目子属性需要传child_path,cid
        /// </summary>
        public string ChildPath { get; set; }

        /// <summary>
        /// 叶子类目ID，如果只传cid，则只返回一级属性,通过taobao.itemcats.get获得叶子类目ID
        /// </summary>
        public long? Cid { get; set; }

        /// <summary>
        /// 需要返回的字段列表，见：ItemProp，默认返回：pid, name, must, multi, prop_values
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 是否颜色属性。可选值:true(是),false(否) (删除的属性不会匹配和返回这个条件)
        /// </summary>
        public bool? IsColorProp { get; set; }

        /// <summary>
        /// 是否枚举属性。可选值:true(是),false(否) (删除的属性不会匹配和返回这个条件)。如果返回true，属性值是下拉框选择输入，如果返回false，属性值是用户自行手工输入。
        /// </summary>
        public bool? IsEnumProp { get; set; }

        /// <summary>
        /// 在is_enum_prop是true的前提下，是否是卖家可以自行输入的属性（注：如果is_enum_prop返回false，该参数统一返回false）。可选值:true(是),false(否) (删除的属性不会匹配和返回这个条件)
        /// </summary>
        public bool? IsInputProp { get; set; }

        /// <summary>
        /// 是否商品属性，这个属性只能放于发布商品时使用。可选值:true(是),false(否)
        /// </summary>
        public bool? IsItemProp { get; set; }

        /// <summary>
        /// 是否关键属性。可选值:true(是),false(否)
        /// </summary>
        public bool? IsKeyProp { get; set; }

        /// <summary>
        /// 是否销售属性。可选值:true(是),false(否)
        /// </summary>
        public bool? IsSaleProp { get; set; }

        /// <summary>
        /// 父属性ID
        /// </summary>
        public long? ParentPid { get; set; }

        /// <summary>
        /// 属性id (取类目属性时，传pid，不用同时传PID和parent_pid)
        /// </summary>
        public long? Pid { get; set; }

        /// <summary>
        /// 获取类目的类型：1代表集市、2代表天猫<br /> 支持最大值为：2<br /> 支持最小值为：1
        /// </summary>
        public long? Type { get; set; }

    }
}
