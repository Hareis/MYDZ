﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MYDZ.Entity.Goods
{
    /// <summary>
    /// 宝贝主图视频
    /// </summary>
    [Serializable]
    public class MpicVideo : Response
    {
        /// <summary>
        /// 系统数据库
        /// </summary>
        public int MpicVideoID { get; set; }
        /// <summary>
        /// 主图视频记录所关联的商品的数字id
        /// </summary>
        [XmlElement("num_iid")]
        public long NumIid { get; set; }

        /// <summary>
        /// 主图视频的时长，单位：秒
        /// </summary>
        [XmlElement("video_duaration")]
        public long VideoDuaration { get; set; }

        /// <summary>
        /// 主图视频的在淘视频中的ID
        /// </summary>
        [XmlElement("video_id")]
        public long VideoId { get; set; }

        /// <summary>
        /// 主图视频的缩略图URL
        /// </summary>
        [XmlElement("video_pic")]
        public string VideoPic { get; set; }

        /// <summary>
        /// 主图视频的状态
        /// </summary>
        [XmlElement("video_status")]
        public long VideoStatus { get; set; }
    }
}
