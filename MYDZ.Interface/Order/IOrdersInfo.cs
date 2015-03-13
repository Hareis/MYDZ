using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Entity.Order;

namespace MYDZ.Interface.Order
{
    public interface IOrdersInfo : BaseInterface
    {
        /// <summary>
        /// 查询订单信息列表（分页）
        /// </summary>
        /// <param name="PageCount">当前页码</param>
        /// <param name="pageSize">每页显示的条数</param>
        /// <param name="Where">查询条件</param>
        /// <param name="Order">排序字段</param>
        /// <param name="MaxRow">总行数</param>
        /// <param name="MaxPage">总页数</param>
        /// <returns></returns>
        IList<tbOrdersInfo> Select(int PageCount, int pageSize, string Where, string Order, out int MaxRow, out int MaxPage);

        /// <summary>
        /// 根据订单编号列表查询订单信息列表
        /// </summary>
        /// <param name="OrdersNumberList">订单编号列表</param>
        /// <returns></returns>
        IList<tbOrdersInfo> Select(string OrdersNumberList);

        /// <summary>
        /// 根据物流单号查询订单信息列表
        /// </summary>
        /// <param name="DeliverNumber">物流单号</param>
        /// <param name="ShopId">店铺编号</param>
        /// <returns></returns>
        IList<tbOrdersInfo> SelectByDeliver(string DeliverNumber, int ShopId);

        /// <summary>
        /// 查询已付款未发货的订单编号列表
        /// </summary>
        /// <param name="ShopId">店铺编号</param>
        /// <returns></returns>
        IDictionary<string, string> SelectOrdersNumber(int ShopId);

        /// <summary>
        /// 根据用户编号查询汇总信息
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <returns></returns>
        OrderCollect Select(int UserId);

        /// <summary>
        /// 根据查询条件查询订单打印汇总信息
        /// </summary>
        /// <param name="Where">查询条件</param>
        /// <returns></returns>
        int[] SelectPrint(string Where);

        /// <summary>
        /// 根据订单外部编号查询订单是否存在
        /// </summary>
        /// <param name="OrderOutNumber">订单外部编号</param>
        /// <param name="ShopId">店铺编号</param>
        /// <returns></returns>
        bool CheckOrder(string OrderOutNumber, int ShopId);

        /// <summary>
        /// 修改订单备注信息
        /// </summary>
        /// <param name="OrdersNumber">订单编号</param>
        /// <param name="Flag">备注旗帜</param>
        /// <param name="Detail">备注内容</param>
        /// <returns></returns>
        bool UpdateDetail(string OrdersNumber, string Flag, string Detail);

        /// <summary>
        /// 添加订单信息
        /// </summary>
        /// <param name="OrdersInfo">订单表</param>
        /// <returns></returns>
        bool Insert(tbOrdersInfo OrdersInfo);

        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="OrdersNumber">订单编号</param>
        /// <param name="OrderStatus">订单状态</param>
        /// <returns></returns>
        bool UpdateStatus(string OrdersNumber, int OrderStatus);

        /// <summary>
        /// 批量修改订单状态
        /// </summary>
        /// <param name="OrdersNumber">订单编号列表</param>
        /// <param name="OrderStatus">订单状态</param>
        /// <returns></returns>
        bool BatchUpdateStatus(string IdList, int OrderStatus);

        /// <summary>
        /// 修改订单物流
        /// </summary>
        /// <param name="OrdersNumber">订单编号</param>
        /// <param name="LogisticsId">物流编号</param>
        /// <returns></returns>
        bool UpdateLogistics(string OrdersNumber, int LogisticsId);

        /// <summary>
        /// 根据订单编号列表修改订单物流
        /// </summary>
        /// <param name="IdList">订单编号列表</param>
        /// <param name="LogisticsId">物流编号</param>
        /// <returns></returns>
        bool UpdateLogisticsByIdList(string IdList, int LogisticsId);

        /// <summary>
        /// 修改订单是否打印发货单
        /// </summary>
        /// <param name="OrdersNumber">订单编号</param>
        /// <param name="Invoice">是否打印发货单</param>
        /// <returns></returns>
        bool UpdateInvoice(string OrdersNumber, bool Invoice);

        /// <summary>
        /// 合并订单
        /// </summary>
        /// <param name="OrdersNumber">指定合并基准订单编号，以该订单编号为准，其他订单合并到该订单中</param>
        /// <param name="OrderNumberList">需要合并的订单编号列表</param>
        /// <param name="count">需要合并的总订单数</param>
        /// <returns>Json格式Status:状态,Msg描述</returns>
        string Update(string OrdersNumber, string OrderNumberList, int count);

        /// <summary>
        /// 批量插入订单数据
        /// </summary>
        /// <param name="OrdersInfo"></param>
        /// <returns></returns>
        bool InsertListOrdersInfo(List<tbOrdersInfo> OrdersInfo);
    }
}
