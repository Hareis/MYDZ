using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Interface.Order;
using MYDZ.Entity.Order;
using System.Data;
using MYDZ.DBUtility;
using MYDZ.Entity.Order;
using MYDZ.Entity.Shop;
using System.Data.SqlClient;

namespace MYDZ.Data.SqlServer.Order
{
    public class OrdersInfo : IOrdersInfo
    {
        private const string SQL_PAGE_SELECT = "PageCurrent";                                               //查询订单信息列表（分页）
        private const string SQL_SELECT_LIST = "SelectOrdersInfoByNumberList";                              //根据订单编号列表查询订单信息列表
        private const string SQL_SELECT_DELIVER = "SelectOrdersInfoByDeliver";                              //根据物流单号查询订单信息列表
        private const string SQL_SELECT_COLLECT = "SelectOrderCollect";                                     //根据用户编号查询汇总信息
        private const string SQL_SELECT_WHERE = "SelectOrdersInfoByWhere";                                  //根据查询条件查询订单打印汇总信息
        private const string SQL_SELECT_NUMBERS = "SelectOrdersNumbersByShopId";                            //查询已付款未发货的订单编号列表
        private const string SQL_CHECK_OUTNUMBER = "CheckOrderOutNumber";                                   //根据订单外部编号查询订单是否存在
        private const string SQL_UPDATE_DETAIL = "UpdateOrdersInfoDetail";                                  //修改订单备注信息
        private const string SQL_INSERT = "InsertOrdersInfo";                                               //添加订单信息
        private const string SQL_UPDATE_STATUS = "UpdateOrdersInfoStatus";                                  //修改订单状态
        private const string SQL_BATCH_UPDATE_STATUS = "BatchUpdateOrdersInfoStatus";                       //批量修改订单状态
        private const string SQL_UPDATE_LOGIS = "UpdateOrdersInfoLogisticsId";                              //修改订单物流
        private const string SQL_UPDATE_LOGIS_IDS = "UpdateOrdersInfoLogisticsByIdList";                    //根据订单编号列表修改订单物流
        private const string SQL_UPDATE_INVOICE = "UpdateOrdersInfoInvoice";                                //修改订单是否打印发货单
        private const string SQL_UPDATE_MERGER = "UpdateOrdersInfoMerger";                                  //合并订单

        private const string PARM_TABLENAME = "@TableName";                                                 //表名
        private const string PARM_FIELD = "@Fields";                                                        //字段名(全部字段为*)
        private const string PARM_ORDERFIELD = "@OrderField";                                               //排序字段(必须!支持多字段)
        private const string PARM_WHERE = "@sqlWhere";                                                      //条件语句(不用加where)
        private const string PARM_PAGESIZE = "@pageSize";                                                   //每页多少条记录
        private const string PARM_PAGEINDEX = "@pageIndex";                                                 //指定当前为第几页
        private const string PARM_DISTINCT = "@distinct";                                                   //去除重复值，注意只能是一个字段
        private const string PARM_TOP = "@top";                                                             //查询TOP,不传为全部

        private const string PARM_NUMBER = "@OrdersNumber";                                                 //订单编号
        private const string PARM_NNAME = "@NickName";                                                      //会员昵称
        private const string PARM_LID = "@LogisticsId";                                                     //配送方式编号
        private const string PARM_OSID = "@OrdersStatusId";                                                 //订单状态
        private const string PARM_SID = "@ShopId";                                                          //店铺编号
        private const string PARM_CSID = "@CustomerServiceId";                                              //客服编号
        private const string PARM_FUND = "@IsOrdersReFund";                                                 //是否有退款
        private const string PARM_PRINT = "@IsOrdersPrint";                                                 //是否打印
        private const string PARM_INVERT = "@IsInventory";                                                  //是否有清单
        private const string PARM_FREE = "@IsFree";                                                         //是否包邮
        private const string PARM_WEIGHT = "@OrdersWeight";                                                 //订单重量(g)
        private const string PARM_FREIGHT = "@OrdersFreight";                                               //订单运费
        private const string PARM_TOTAL = "@OrdersProductTotal";                                            //商品总金额
        private const string PARM_DISCOUNT = "@OrdersDiscount";                                             //订单折扣
        private const string PARM_ACCOUNT = "@OrdersAccounts";                                              //订单应收金额
        private const string PARM_PAID = "@OrdersPaid";                                                     //订单实收金额
        private const string PARM_DATE = "@OrdersDate";                                                     //下单时间
        private const string PARM_PAYDATE = "@PayDate";                                                     //付款时间
        private const string PARM_IDATE = "@OrdersInputDate";                                               //订单录入时间  
        private const string PARM_SNOTE = "@ServiceNotes";                                                  //客服备注
        private const string PARM_SFLAG = "@ServiceFlag";                                                   //客服备注旗帜样式
        private const string PARM_ONOTE = "@OrdersNotes";                                                   //订单备注
        private const string PARM_OFLAG = "@OrdersFlag";                                                    //订单备注旗帜样式
        private const string PARM_OUTNUMBER = "@OrdersOutNumber";                                           //订单外部交易号
        private const string PARM_CASH = "@CashOndelivery";                                                 //是否为货到付款订单
        private const string PARM_INVOICE = "@Invoice";                                                     //是否开具发票
        private const string PARM_DDATE = "@DeliveryDate";                                                  //配送日期
        private const string PARM_BUYMSG = "@BuyerMsg";                                                     //买家留言
        private const string PARM_BUYREMARK = "@BuyerRemark";                                               //买家备注
        private const string PARM_REMARKFLAG = "@RemarkFlag";                                               //买家备注旗帜样式
        private const string PARM_COMM = "@Commission";                                                     //交易佣金
        private const string PARM_CODFREE = "@CodFee";                                                      //货到付款服务费
        private const string PARM_IDLIST = "@IdList";                                                       //订单编号列表
        private const string PARM_COUNT = "@count";                                                         //须合并的订单数

        private const string PARM_UID = "@UserId";                                                          //用户编号
        private const string PARM_LNUMBER = "@LogisticsNumber";                                             //物流单号

        public IList<tbOrdersInfo> Select(int PageCount, int pageSize, string Where, string Order, out int MaxRow, out int MaxPage)
        {
            IList<tbOrdersInfo> MyList = new List<tbOrdersInfo>();
            IDbDataParameter[] parm = GetPageSelectParam();
            parm[0].Value = "tbOrdersInfo,tbLogistics,tbOrdersStatus,tbShopInfo,tbOrdersDetail,tbConsigneeInfo";
            parm[1].Value = "tbOrdersInfo.OrdersNumber";
            parm[2].Value = String.IsNullOrEmpty(Order) ? "min(OrdersInputDate) desc" : Order.Trim();
            parm[3].Value = " tbOrdersInfo.LogisticsId = tbLogistics.LogisticsId And tbOrdersInfo.OrdersStatusId = tbOrdersStatus.OrdersStatusId And tbOrdersInfo.ShopId = tbShopInfo.ShopId And tbOrdersInfo.OrdersOutNumber = tbOrdersDetail.OrdersNumber And tbOrdersInfo.OrdersOutNumber = tbConsigneeInfo.OrdersNumber " + Where;
            parm[4].Value = pageSize == 0 ? 20 : pageSize;
            parm[5].Value = PageCount;
            parm[6].Value = "tbOrdersInfo.OrdersNumber";
            parm[7].Value = null;

            using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.StoredProcedure, SQL_PAGE_SELECT, parm))
            {
                if (MyReader.Read())
                {
                    MaxRow = MyReader.GetInt32(0);
                    MaxPage = MyReader.GetInt32(1);

                    if (MyReader.NextResult())
                    {
                        while (MyReader.Read())
                        {
                            MyList.Add(new tbOrdersInfo()
                            {
                                OrdersNumber = MyReader.GetString(0)
                            });
                        }
                    }
                }
                else
                {
                    MaxRow = 0;
                    MaxPage = 0;
                }
            }

            return MyList;
        }

        public IList<tbOrdersInfo> Select(string OrdersNumberList)
        {
            IList<tbOrdersInfo> MyList = new List<tbOrdersInfo>();
            IDbDataParameter[] parm = GetSelectListParam();
            parm[0].Value = OrdersNumberList;
            try
            {
                using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_LIST, parm))
                {
                    while (MyReader.Read())
                    {
                        MyList.Add(new tbOrdersInfo()
                        {
                            OrdersId = MyReader.GetInt32(0),
                            OrdersNumber = MyReader.GetString(1),
                            NickName = MyReader.GetString(2),
                            CustomerServiceId = MyReader.GetInt32(3),
                            IsOrdersReFund = MyReader.GetBoolean(4),
                            IsOrdersPrint = MyReader.GetBoolean(5),
                            IsInventory = MyReader.GetBoolean(6),
                            IsFree = MyReader.GetBoolean(7),
                            OrdersWeight = MyReader.GetInt32(8),
                            OrdersFreight = MyReader.GetInt32(9),
                            OrdersProductTotal = MyReader.GetDecimal(10),
                            OrdersDiscount = MyReader.GetDecimal(11),
                            OrdersAccounts = MyReader.GetDecimal(12),
                            OrdersPaid = MyReader.GetDecimal(13),
                            OrdersDate = MyReader.GetDateTime(14),
                            PayDate = MyReader.GetDateTime(15),
                            OrdersInputDate = MyReader.GetDateTime(16),
                            ServiceNotes = MyReader[17] == null ? "" : MyReader[17].ToString(),
                            ServiceFlag = MyReader[18] == null ? "" : MyReader[18].ToString(),
                            OrdersNotes = MyReader[19] == null ? "" : MyReader[19].ToString(),
                            OrdersFlag = MyReader.GetString(20),
                            OrdersOutNumber = MyReader.GetString(21),
                            CashOndelivery = MyReader.GetBoolean(22),
                            Invoice = MyReader.GetBoolean(23),
                            DeliveryDate = MyReader[24] == null ? "" : MyReader.GetString(24),
                            BuyerMsg = MyReader[25] == null ? "" : MyReader.GetString(25),
                            BuyerRemark = MyReader[26] == null ? "" : MyReader.GetString(26),
                            RemarkFlag = MyReader[27] == null ? "" : MyReader.GetString(27),
                            Commission = MyReader.GetDecimal(28),
                            CodFee = MyReader.GetDecimal(29),
                            Logistics = new Entity.Order.Logistic { LogisticsId = MyReader.GetInt32(30), LogisticsName = MyReader.GetString(31) },
                            Status = new tbOrdersStatus() { OrdersStatusId = MyReader.GetInt32(32), OrdersStatusName = MyReader.GetString(33) },
                            Shop = new tbShopInfo() { ShopId = MyReader.GetInt32(34) }
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return MyList;
        }

        public IList<tbOrdersInfo> SelectByDeliver(string DeliverNumber, int ShopId)
        {
            IList<tbOrdersInfo> MyList = new List<tbOrdersInfo>();
            IDbDataParameter[] parm = GetSelectDeliverParam();
            parm[0].Value = DeliverNumber;
            parm[1].Value = ShopId;

            using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_DELIVER, parm))
            {
                while (MyReader.Read())
                {
                    MyList.Add(new tbOrdersInfo()
                    {
                        OrdersId = MyReader.GetInt32(0),
                        OrdersNumber = MyReader.GetString(1),
                        NickName = MyReader.GetString(2),
                        CustomerServiceId = MyReader.GetInt32(3),
                        IsOrdersReFund = MyReader.GetBoolean(4),
                        IsOrdersPrint = MyReader.GetBoolean(5),
                        IsInventory = MyReader.GetBoolean(6),
                        IsFree = MyReader.GetBoolean(7),
                        OrdersWeight = MyReader.GetInt32(8),
                        OrdersFreight = MyReader.GetInt32(9),
                        OrdersProductTotal = MyReader.GetDecimal(10),
                        OrdersDiscount = MyReader.GetDecimal(11),
                        OrdersAccounts = MyReader.GetDecimal(12),
                        OrdersPaid = MyReader.GetDecimal(13),
                        OrdersDate = MyReader.GetDateTime(14),
                        PayDate = MyReader.GetDateTime(15),
                        OrdersInputDate = MyReader.GetDateTime(16),
                        ServiceNotes = MyReader.GetString(17),
                        ServiceFlag = MyReader.GetString(18),
                        OrdersNotes = MyReader.GetString(19),
                        OrdersFlag = MyReader.GetString(20),
                        OrdersOutNumber = MyReader.GetString(21),
                        CashOndelivery = MyReader.GetBoolean(22),
                        Invoice = MyReader.GetBoolean(23),
                        DeliveryDate = MyReader.GetString(24),
                        BuyerMsg = MyReader.GetString(25),
                        BuyerRemark = MyReader.GetString(26),
                        RemarkFlag = MyReader.GetString(27),
                        Commission = MyReader.GetDecimal(28),
                        CodFee = MyReader.GetDecimal(29),
                        Logistics = new MYDZ.Entity.Order.Logistic() { LogisticsId = MyReader.GetInt32(30), LogisticsName = MyReader.GetString(31) },
                        Status = new tbOrdersStatus() { OrdersStatusId = MyReader.GetInt32(32), OrdersStatusName = MyReader.GetString(33) },
                        Shop = new tbShopInfo() { ShopId = MyReader.GetInt32(34), Title = MyReader.GetString(36) }
                    });
                }
            }
            return MyList;
        }

        public IDictionary<string, string> SelectOrdersNumber(int ShopId)
        {
            IDictionary<string, string> MyList = new Dictionary<string, string>();
            IDbDataParameter[] parm = GetSelectNumbersParam();
            parm[0].Value = ShopId;

            using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_NUMBERS, parm))
            {
                while (MyReader.Read())
                {
                    MyList.Add(MyReader.GetString(0), MyReader.GetString(1));
                }
            }

            return MyList;
        }

        public OrderCollect Select(int UserId)
        {
            OrderCollect Collect = null;
            IDbDataParameter[] parm = GetSelectCollectParam();
            parm[0].Value = UserId;

            try
            {
                using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_COLLECT, parm))
                {
                    if (MyReader.Read())
                    {
                        Collect = new OrderCollect()
                        {
                            MaxUser = MyReader.GetInt32(0),
                            MaxOrder = MyReader.GetInt32(1),
                            NPrintOrder = MyReader.GetInt32(2),
                            YPrintOrder = MyReader.GetInt32(3),
                            MaxPrice = MyReader.GetDecimal(4)
                        };
                    }
                }
            }
            catch { }

            return Collect == null ? new OrderCollect() : Collect;
        }

        public int[] SelectPrint(string Where)
        {
            int[] Count = new int[] { 0, 0, 0 };
            IDbDataParameter[] parm = GetSelectWhereParam();
            parm[0].Value = Where;

            try
            {
                int Max = 0;
                using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.StoredProcedure, SQL_SELECT_WHERE, parm))
                {
                    while (MyReader.Read())
                    {
                        Count[MyReader.GetInt32(1)] = MyReader.GetInt32(0);
                        Max += MyReader.GetInt32(0);
                        
                    }
                }
                Count[2] = Max;
            }
            catch { }

            return Count;
        }

        public bool CheckOrder(string OrderOutNumber, int ShopId)
        {
            bool isok = false;
            IDbDataParameter[] parm = GetCheckOutNumberParam();
            parm[0].Value = OrderOutNumber;
            parm[1].Value = ShopId;

            using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.StoredProcedure, SQL_CHECK_OUTNUMBER, parm))
            {
                if (MyReader.Read())
                {
                    isok = MyReader.GetInt32(0) > 0 ? true : false;
                }
            }

            return isok;
        }

        public bool UpdateDetail(string OrdersNumber, string Flag, string Detail)
        {
            bool IsOk = false;

            IDbDataParameter[] parm = GetUpdateDetailParam();
            parm[0].Value = OrdersNumber;
            parm[1].Value = Flag;
            parm[2].Value = Detail;

            try
            {
                DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_UPDATE_DETAIL, parm);
                IsOk = true;
            }
            catch { }

            return IsOk;
        }

        public bool Insert(tbOrdersInfo OrdersInfo)
        {
            bool IsOk = false;

            IDbDataParameter[] parm = GetInsertParam();
            parm[0].Value = OrdersInfo.OrdersNumber;
            parm[1].Value = OrdersInfo.NickName;
            parm[2].Value = OrdersInfo.Logistics.LogisticsId;
            parm[3].Value = OrdersInfo.Status.OrdersStatusId;
            parm[4].Value = OrdersInfo.Shop.ShopId;
            parm[5].Value = OrdersInfo.CustomerServiceId;
            parm[6].Value = OrdersInfo.IsOrdersReFund;
            parm[7].Value = OrdersInfo.IsOrdersPrint;
            parm[8].Value = OrdersInfo.IsInventory;
            parm[9].Value = OrdersInfo.IsFree;
            parm[10].Value = OrdersInfo.OrdersWeight;
            parm[11].Value = OrdersInfo.OrdersFreight;
            parm[12].Value = OrdersInfo.OrdersProductTotal;
            parm[13].Value = OrdersInfo.OrdersDiscount;
            parm[14].Value = OrdersInfo.OrdersAccounts;
            parm[15].Value = OrdersInfo.OrdersPaid;
            parm[16].Value = OrdersInfo.OrdersDate;
            parm[17].Value = OrdersInfo.PayDate;
            parm[18].Value = OrdersInfo.OrdersInputDate;
            parm[19].Value = OrdersInfo.ServiceNotes;
            parm[20].Value = OrdersInfo.ServiceFlag;
            parm[21].Value = OrdersInfo.OrdersNotes;
            parm[22].Value = OrdersInfo.OrdersFlag;
            parm[23].Value = OrdersInfo.OrdersOutNumber;
            parm[24].Value = OrdersInfo.CashOndelivery;
            parm[25].Value = OrdersInfo.Invoice;
            parm[26].Value = OrdersInfo.DeliveryDate;
            parm[27].Value = OrdersInfo.BuyerMsg;
            parm[28].Value = OrdersInfo.BuyerRemark;
            parm[29].Value = OrdersInfo.RemarkFlag;
            parm[30].Value = OrdersInfo.Commission;
            parm[31].Value = OrdersInfo.CodFee;

            try
            {
                DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_INSERT, parm);
                IsOk = true;
            }
            catch { }

            return IsOk;
        }

        /// <summary>
        /// 批量插入到订单临时表
        /// </summary>
        /// <param name="OrdersInfo"></param>
        /// <returns></returns>
        public bool InsertListOrdersInfo(List<tbOrdersInfo> OrdersInfo)
        {
            bool Result = false;
            try
            {
                //新建一张datatable
                DataTable dt = new DataTable("tbOrdersInfo_temp");
                DataColumn dc = null;

                #region 新建临时表列
                dc = dt.Columns.Add("OrdersNumber", Type.GetType("System.String"));
                dc = dt.Columns.Add("BuyerMsg", Type.GetType("System.String"));
                dc = dt.Columns.Add("BuyerRemark", Type.GetType("System.String"));
                dc = dt.Columns.Add("CashOndelivery", Type.GetType("System.Boolean"));
                dc = dt.Columns.Add("Commission", Type.GetType("System.Decimal"));
                dc = dt.Columns.Add("CodFee", Type.GetType("System.Decimal"));

                dc = dt.Columns.Add("CustomerServiceId", Type.GetType("System.Int32"));
                dc = dt.Columns.Add("DeliveryDate", Type.GetType("System.String"));
                dc = dt.Columns.Add("Invoice", Type.GetType("System.Boolean"));
                dc = dt.Columns.Add("IsOrdersReFund", Type.GetType("System.Boolean"));
                dc = dt.Columns.Add("IsOrdersPrint", Type.GetType("System.Boolean"));
                dc = dt.Columns.Add("IsInventory", Type.GetType("System.Boolean"));

                dc = dt.Columns.Add("IsFree", Type.GetType("System.Boolean"));
                dc = dt.Columns.Add("NickName", Type.GetType("System.String"));
                dc = dt.Columns.Add("LogisticsId", Type.GetType("System.Int32"));
                dc = dt.Columns.Add("RemarkFlag", Type.GetType("System.String"));
                dc = dt.Columns.Add("OrdersWeight", Type.GetType("System.Int32"));
                dc = dt.Columns.Add("OrdersFreight", Type.GetType("System.Int32"));

                dc = dt.Columns.Add("OrdersProductTotal", Type.GetType("System.Decimal"));
                dc = dt.Columns.Add("OrdersDiscount", Type.GetType("System.Decimal"));
                dc = dt.Columns.Add("OrdersAccounts", Type.GetType("System.Decimal"));
                dc = dt.Columns.Add("OrdersPaid", Type.GetType("System.Decimal"));
                dc = dt.Columns.Add("OrdersDate", Type.GetType("System.DateTime"));
                dc = dt.Columns.Add("PayDate", Type.GetType("System.DateTime"));

                dc = dt.Columns.Add("OrdersInputDate", Type.GetType("System.DateTime"));
                dc = dt.Columns.Add("OrdersStatusId", Type.GetType("System.Int32"));
                dc = dt.Columns.Add("OrdersNotes", Type.GetType("System.String"));
                dc = dt.Columns.Add("OrdersFlag", Type.GetType("System.String"));
                dc = dt.Columns.Add("OrdersOutNumber", Type.GetType("System.String"));
                dc = dt.Columns.Add("ServiceNotes", Type.GetType("System.String"));
                dc = dt.Columns.Add("ServiceFlag", Type.GetType("System.String"));
                dc = dt.Columns.Add("ShopId", Type.GetType("System.Int32"));

                dc = dt.Columns.Add("Name", Type.GetType("System.String"));
                dc = dt.Columns.Add("Phone", Type.GetType("System.String"));
                dc = dt.Columns.Add("Mobile", Type.GetType("System.String"));
                dc = dt.Columns.Add("PostCode", Type.GetType("System.String"));
                dc = dt.Columns.Add("Provice", Type.GetType("System.String"));
                dc = dt.Columns.Add("City", Type.GetType("System.String"));
                dc = dt.Columns.Add("District", Type.GetType("System.String"));
                dc = dt.Columns.Add("ZoneId", Type.GetType("System.Int32"));

                dc = dt.Columns.Add("ProviceId", Type.GetType("System.Int32"));
                dc = dt.Columns.Add("CityId", Type.GetType("System.Int32"));
                dc = dt.Columns.Add("DistrictId", Type.GetType("System.Int32"));
                dc = dt.Columns.Add("ConsigneeAddress", Type.GetType("System.String"));
                dc = dt.Columns.Add("InputDate", Type.GetType("System.DateTime"));
                dc = dt.Columns.Add("BuyerName", Type.GetType("System.String"));
                dc = dt.Columns.Add("BuyerEmail", Type.GetType("System.String"));
                #endregion
                if (OrdersInfo == null) { return false; }
                foreach (Entity.Order.tbOrdersInfo item in OrdersInfo)
                {
                    dt.Rows.Add(new object[] { 
                        item.OrdersNumber, item.BuyerMsg, item.BuyerRemark, item.CashOndelivery, 
                        item.Commission,item.CodFee,item.CustomerServiceId,item.DeliveryDate,
                        item.Invoice,item.IsOrdersReFund,item.IsOrdersPrint,item.IsInventory,
                        item.IsFree,item.NickName,item.Logistics.LogisticsId,item.RemarkFlag,
                        item.OrdersWeight,item.OrdersFreight,item.OrdersProductTotal,item.OrdersDiscount,
                        item.OrdersAccounts,item.OrdersPaid, item.OrdersDate,item.PayDate,
                        item.OrdersInputDate, item.Status.OrdersStatusId,item.OrdersNotes,item.OrdersFlag,
                        item.OrdersOutNumber, item.ServiceNotes,item.ServiceFlag,item.Shop.ShopId,
                        item.Consignee.Name,item.Consignee.Phone,item.Consignee.Mobile,item.Consignee.PostCode,
                        item.Consignee.Provice,item.Consignee.City,item.Consignee.District,item.Consignee.ZoneId,
                        item.Consignee.ProviceId,item.Consignee.CityId,item.Consignee.DistrictId,item.Consignee.ConsigneeAddress, 
                        item.Consignee.InputDate,item.Buyer.BuyerName, item.Buyer.BuyerEmail });
                }
                SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(DBHelper.ConnectionStr);
                //要插入数据库的名称
                sqlBulkCopy.DestinationTableName = "tbOrdersInfo_temp";

                if (dt != null && dt.Rows.Count != 0)
                {
                    sqlBulkCopy.WriteToServer(dt);
                }
                sqlBulkCopy.Close();

                string SqlStr = string.Format(@"update [dbo].[tbOrdersInfo]  ---更新存在相同点数据
                                            set    [OrdersFreight]=B.OrdersFreight
                                                ,[OrdersNumber]=B.OrdersNumber,[NickName]=B.NickName
                                                ,[LogisticsId]=B.LogisticsId,[OrdersStatusId]=B.OrdersStatusId
                                                ,[ShopId]=B.ShopId,[CustomerServiceId]=B.CustomerServiceId
                                                ,[IsOrdersReFund]=B.IsOrdersReFund,[IsOrdersPrint]=B.IsOrdersPrint
                                                ,[IsInventory]=B.IsInventory,[IsFree]=B.IsFree
                                                ,[OrdersWeight]=B.OrdersWeight
                                                ,[OrdersProductTotal]=B.OrdersProductTotal,[OrdersDiscount]=B.OrdersDiscount
                                                ,[OrdersAccounts]=B.OrdersAccounts,[OrdersPaid]=B.OrdersPaid
                                                ,[OrdersDate]=B.OrdersDate,[PayDate]=B.PayDate
                                                ,[OrdersInputDate]=B.OrdersInputDate,[ServiceNotes]=B.ServiceNotes
                                                ,[ServiceFlag]=B.ServiceFlag,[OrdersNotes]=B.OrdersNotes
                                                ,[OrdersFlag]=B.OrdersFlag,[OrdersOutNumber]=B.OrdersOutNumber
                                                ,[CashOndelivery]=B.CashOndelivery,[Invoice]=B.Invoice
                                                ,[DeliveryDate]=B.DeliveryDate,[BuyerMsg]=B.BuyerMsg
                                                ,[BuyerRemark]=B.BuyerRemark,[RemarkFlag]=B.RemarkFlag
                                                ,[Commission]=B.Commission,[CodFee]=B.CodFee			
                                                from [dbo].[tbOrdersInfo] A,[dbo].[tbOrdersInfo_temp] B 
                                                where B.ShopId=A.ShopId
                                                and B.OrdersOutNumber=A.OrdersOutNumber 
                                                and  B.NowDay >= convert(varchar(10),getdate(),120);                                               
                                                ---插入不存在相同点数据
                                                insert into [dbo].[tbOrdersInfo] 
                                            (	[BuyerMsg],[BuyerRemark],[CashOndelivery],[Commission]
   	                                        ,[CodFee],[CustomerServiceId],[DeliveryDate],[Invoice]
   	                                        ,[IsOrdersReFund],[IsOrdersPrint],[IsInventory],[IsFree]
   	                                        ,[NickName],[LogisticsId],[RemarkFlag],[OrdersWeight],[OrdersNumber]
   	                                        ,[OrdersFreight],[OrdersProductTotal],[OrdersDiscount],[OrdersAccounts]
   	                                        ,[OrdersPaid],[OrdersDate],[PayDate],[OrdersInputDate]
   	                                        ,[OrdersStatusId],[OrdersNotes],[OrdersFlag],[OrdersOutNumber]
   	                                        ,[ServiceNotes],[ServiceFlag],[ShopId]) 
                                            select [BuyerMsg],[BuyerRemark],[CashOndelivery],[Commission]
   	                                            ,[CodFee],[CustomerServiceId],[DeliveryDate],[Invoice]
   	                                            ,[IsOrdersReFund],[IsOrdersPrint],[IsInventory],[IsFree]
   	                                            ,[NickName],[LogisticsId],[RemarkFlag],[OrdersWeight],[OrdersNumber]
   	                                            ,[OrdersFreight],[OrdersProductTotal],[OrdersDiscount],[OrdersAccounts]
   	                                            ,[OrdersPaid],[OrdersDate],[PayDate],[OrdersInputDate]
   	                                            ,[OrdersStatusId],[OrdersNotes],[OrdersFlag],[OrdersOutNumber]
   	                                            ,ISNULL([ServiceNotes],''),[ServiceFlag],[ShopId]
                                            from [dbo].[tbOrdersInfo_temp] A 
                                            where   not exists(
                                            select [OrdersOutNumber]
                                            from [dbo].[tbOrdersInfo] B
                                            where B.OrdersOutNumber= A.OrdersOutNumber and B.ShopId=A.ShopId)
                                            and  A.NowDay >= convert(varchar(10),getdate(),120);");

                if (DBHelper.ExecuteNonQuery(CommandType.Text, SqlStr) > 0)
                    Result = true;

            }
            catch (Exception EX)
            {
                Result = false;
                throw EX;
            }
            return Result;
        }

        public bool UpdateStatus(string OrdersNumber, int OrderStatus)
        {
            bool IsOk = false;

            IDbDataParameter[] parm = GetUpdateStatusParam();
            parm[0].Value = OrdersNumber;
            parm[1].Value = OrderStatus;

            try
            {
                DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_UPDATE_STATUS, parm);
                IsOk = true;
            }
            catch { }

            return IsOk;
        }

        public bool BatchUpdateStatus(string IdList, int OrderStatus)
        {
            bool IsOk = false;

            IDbDataParameter[] parm = GetBatchUpdateStatusParam();
            parm[0].Value = IdList;
            parm[1].Value = OrderStatus;

            try
            {
                DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_BATCH_UPDATE_STATUS, parm);
                IsOk = true;
            }
            catch { }

            return IsOk;
        }

        public bool UpdateInvoice(string OrdersNumber, bool Invoice)
        {
            bool IsOk = false;

            IDbDataParameter[] parm = GetUpdateInvoiceParam();
            parm[0].Value = OrdersNumber;
            parm[1].Value = Invoice;

            try
            {
                DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_UPDATE_INVOICE, parm);
                IsOk = true;
            }
            catch { }

            return IsOk;
        }

        public bool UpdateLogistics(string OrdersNumber, int LogisticsId)
        {
            bool IsOk = false;

            IDbDataParameter[] parm = GetUpdateLogisParam();
            parm[0].Value = OrdersNumber;
            parm[1].Value = LogisticsId;

            try
            {
                DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_UPDATE_LOGIS, parm);
                IsOk = true;
            }
            catch { }

            return IsOk;
        }

        public bool UpdateLogisticsByIdList(string IdList, int LogisticsId)
        {
            bool IsOk = false;

            IDbDataParameter[] parm = GetUpdateLogisIdsParam();
            parm[0].Value = IdList;
            parm[1].Value = LogisticsId;

            try
            {
                DBHelper.ExecuteNonQuery(CommandType.StoredProcedure, SQL_UPDATE_LOGIS_IDS, parm);
                IsOk = true;
            }
            catch { }

            return IsOk;
        }

        public string Update(string OrdersNumber, string OrderNumberList, int count)
        {
            bool Status = false;
            string Msg = "系统错误,请与管理员联系";

            IDbDataParameter[] parm = GetUpdateMergerParam();
            parm[0].Value = OrdersNumber;
            parm[1].Value = OrderNumberList;
            parm[2].Value = count;

            try
            {
                using (IDataReader MyReader = DBHelper.ExecuteReader(CommandType.StoredProcedure, SQL_UPDATE_MERGER, parm))
                {
                    if (MyReader.Read())
                    {
                        Status = MyReader.GetBoolean(0);
                        Msg = MyReader.GetString(1);
                    }
                }
            }
            catch { }

            return "{\"Status\":\"" + Status.ToString().ToLower() + "\",\"Msg\":\"" + Msg + "\"}";
        }

        private static IDbDataParameter[] GetPageSelectParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_PAGE_SELECT);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_TABLENAME,SqlDbType.VarChar,5000),
                     new SqlParameter(PARM_FIELD,SqlDbType.VarChar,5000),
                     new SqlParameter(PARM_ORDERFIELD,SqlDbType.VarChar,5000),
                     new SqlParameter(PARM_WHERE,SqlDbType.VarChar,5000),
                     new SqlParameter(PARM_PAGESIZE,SqlDbType.Int,4),
                     new SqlParameter(PARM_PAGEINDEX,SqlDbType.Int,4),
                     new SqlParameter(PARM_DISTINCT,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_TOP,SqlDbType.Int,4)
                };

                DBHelper.CacheParameters(SQL_PAGE_SELECT, parm);
            }

            return parm;
        }

        private static IDbDataParameter[] GetSelectListParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_SELECT_LIST);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_IDLIST,SqlDbType.VarChar,5000)
                };

                DBHelper.CacheParameters(SQL_SELECT_LIST, parm);
            }

            return parm;
        }

        private static IDbDataParameter[] GetSelectDeliverParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_SELECT_DELIVER);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_LNUMBER,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_SID,SqlDbType.Int,4)
                };

                DBHelper.CacheParameters(SQL_SELECT_DELIVER, parm);
            }

            return parm;
        }

        private static IDbDataParameter[] GetSelectNumbersParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_SELECT_NUMBERS);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_SID,SqlDbType.Int,4)
                };

                DBHelper.CacheParameters(SQL_SELECT_NUMBERS, parm);
            }

            return parm;
        }

        private static IDbDataParameter[] GetSelectCollectParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_SELECT_COLLECT);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_UID,SqlDbType.Int)
                };

                DBHelper.CacheParameters(SQL_SELECT_COLLECT, parm);
            }

            return parm;
        }

        private static IDbDataParameter[] GetSelectWhereParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_SELECT_WHERE);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_WHERE,SqlDbType.VarChar,5000)
                };

                DBHelper.CacheParameters(SQL_SELECT_WHERE, parm);
            }

            return parm;
        }

        private static IDbDataParameter[] GetCheckOutNumberParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_CHECK_OUTNUMBER);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_OUTNUMBER,SqlDbType.VarChar,500),
                     new SqlParameter(PARM_SID,SqlDbType.Int,4)
                };

                DBHelper.CacheParameters(SQL_CHECK_OUTNUMBER, parm);
            }

            return parm;
        }

        private static IDbDataParameter[] GetUpdateDetailParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_UPDATE_DETAIL);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_NUMBER,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_OFLAG,SqlDbType.VarChar,200),
                     new SqlParameter(PARM_ONOTE,SqlDbType.VarChar,500)
                };

                DBHelper.CacheParameters(SQL_UPDATE_DETAIL, parm);
            }

            return parm;
        }

        private static IDbDataParameter[] GetUpdateStatusParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_UPDATE_STATUS);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_NUMBER,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_OSID,SqlDbType.Int,4)
                };

                DBHelper.CacheParameters(SQL_UPDATE_STATUS, parm);
            }

            return parm;
        }

        private static IDbDataParameter[] GetBatchUpdateStatusParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_BATCH_UPDATE_STATUS);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_IDLIST,SqlDbType.VarChar,5000),
                     new SqlParameter(PARM_OSID,SqlDbType.Int,4)
                };

                DBHelper.CacheParameters(SQL_BATCH_UPDATE_STATUS, parm);
            }

            return parm;
        }

        private static IDbDataParameter[] GetUpdateInvoiceParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_UPDATE_INVOICE);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_NUMBER,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_INVERT,SqlDbType.Bit)
                };

                DBHelper.CacheParameters(SQL_UPDATE_INVOICE, parm);
            }

            return parm;
        }

        private static IDbDataParameter[] GetUpdateLogisParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_UPDATE_LOGIS);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_NUMBER,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_LID,SqlDbType.Int,4)
                };

                DBHelper.CacheParameters(SQL_UPDATE_LOGIS, parm);
            }

            return parm;
        }

        private static IDbDataParameter[] GetUpdateLogisIdsParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_UPDATE_LOGIS_IDS);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_IDLIST,SqlDbType.VarChar,5000),
                     new SqlParameter(PARM_LID,SqlDbType.Int,4)
                };

                DBHelper.CacheParameters(SQL_UPDATE_LOGIS_IDS, parm);
            }

            return parm;
        }

        private static IDbDataParameter[] GetUpdateMergerParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_UPDATE_MERGER);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_NUMBER,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_IDLIST,SqlDbType.VarChar,5000),
                     new SqlParameter(PARM_COUNT,SqlDbType.Int,4)
                };

                DBHelper.CacheParameters(SQL_UPDATE_MERGER, parm);
            }

            return parm;
        }

        private static IDbDataParameter[] GetInsertParam()
        {
            IDbDataParameter[] parm = DBHelper.GetCacheParameters(SQL_INSERT);

            if (parm == null)
            {
                parm = new SqlParameter[] {
                     new SqlParameter(PARM_NUMBER,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_NNAME,SqlDbType.VarChar,50),
                     new SqlParameter(PARM_LID,SqlDbType.Int,4),
                     new SqlParameter(PARM_OSID,SqlDbType.Int,4),
                     new SqlParameter(PARM_SID,SqlDbType.Int,4),
                     new SqlParameter(PARM_CSID,SqlDbType.Int,4),
                     new SqlParameter(PARM_FUND,SqlDbType.Bit),
                     new SqlParameter(PARM_PRINT,SqlDbType.Bit),
                     new SqlParameter(PARM_INVERT,SqlDbType.Bit),
                     new SqlParameter(PARM_FREE,SqlDbType.Bit),
                     new SqlParameter(PARM_WEIGHT,SqlDbType.Int,4),
                     new SqlParameter(PARM_FREIGHT,SqlDbType.Int,4),
                     new SqlParameter(PARM_TOTAL,SqlDbType.Decimal),
                     new SqlParameter(PARM_DISCOUNT,SqlDbType.Decimal),
                     new SqlParameter(PARM_ACCOUNT,SqlDbType.Decimal),
                     new SqlParameter(PARM_PAID,SqlDbType.Decimal),
                     new SqlParameter(PARM_DATE,SqlDbType.DateTime),
                     new SqlParameter(PARM_PAYDATE,SqlDbType.DateTime),
                     new SqlParameter(PARM_IDATE,SqlDbType.DateTime),
                     new SqlParameter(PARM_SNOTE,SqlDbType.VarChar,500),
                     new SqlParameter(PARM_SFLAG,SqlDbType.VarChar,200),
                     new SqlParameter(PARM_ONOTE,SqlDbType.VarChar,500),
                     new SqlParameter(PARM_OFLAG,SqlDbType.VarChar,200),
                     new SqlParameter(PARM_OUTNUMBER,SqlDbType.VarChar,500),
                     new SqlParameter(PARM_CASH,SqlDbType.Bit),
                     new SqlParameter(PARM_INVOICE,SqlDbType.Bit),
                     new SqlParameter(PARM_DDATE,SqlDbType.VarChar,200),
                     new SqlParameter(PARM_BUYMSG,SqlDbType.VarChar,500),
                     new SqlParameter(PARM_BUYREMARK,SqlDbType.VarChar,500),
                     new SqlParameter(PARM_REMARKFLAG,SqlDbType.VarChar,200),
                     new SqlParameter(PARM_COMM,SqlDbType.Decimal),
                     new SqlParameter(PARM_CODFREE,SqlDbType.Decimal)
                };

                DBHelper.CacheParameters(SQL_INSERT, parm);
            }

            return parm;
        }
    }
}
