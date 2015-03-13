using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Entity.Order
{
    /// <summary>
    ///订单信息交易请求类
    /// </summary>
    [Serializable]
    public class TradeQueryClass : Response
    {
        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ShopId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int LogisId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CateId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int RefundId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FreeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FlagId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SortId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PrintId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int InvoiceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserNick { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OutNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Addr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SDetail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ODetail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CEnd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PEnd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IEnd { get; set; }
    }
}
