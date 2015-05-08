using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using MYDZ.Business.TB_Logic.SDK_UMP.Request;
using MYDZ.Business.TB_Logic.SDK_UMP.Response;
using MYDZ.Business.TB_Logic.SDK_UMP.commonClass;
using MYDZ.Entity.Order;
using Top.Api.Request;
using Top.Api.Response;

namespace MYDZ.Business.TB_Logic.UMP
{
    internal class UMPGet
    {
        /// <summary>
        /// 根据积木块代码查询积木块详细
        /// </summary>
        /// <param name="code"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal string findMetaByCode(string code, out string Errormsg)
        {
            Errormsg = null;

            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpMbbGetbycodeRequest req = new UmpMbbGetbycodeRequest();
            req.Code = code;
            UmpMbbGetbycodeResponse response = client.Execute(req);
            if (!response.IsError)
            {
                return response.Mbb;
            }
            else
            {
                Errormsg = response.ErrMsg;
                return null;
            }

        }


        /// <summary>
        /// 根据工具ID获取工具详细
        /// </summary>
        /// <param name="ToolId"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal string findToolByToolId(int ToolId, out string Errormsg)
        {
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpToolGetRequest req = new UmpToolGetRequest();
            req.ToolId = ToolId;
            UmpToolGetResponse resp = client.Execute(req);
            if (!resp.IsError)
            {
                return resp.Content;
            }
            else
            {
                Errormsg = resp.ErrMsg;
                return null;
            }

        }


        /// <summary>
        /// 根据活动ID查询活动json字符串
        /// </summary>
        /// <param name="ActId"></param>
        /// <param name="SessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal string findActivityByActId(long ActId, string SessionKey, out string Errormsg)
        {
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpActivityGetRequest req = new UmpActivityGetRequest();
            req.ActId = ActId;
            UmpActivityGetResponse resp = client.Execute(req, SessionKey);
            if (!resp.IsError)
            {
                return resp.Content;
            }
            else
            {
                Errormsg = resp.ErrMsg;
                return null;
            }
        }


        /// <summary>
        /// 根据Id查询活动详情
        /// </summary>
        /// <param name="detailId"></param>
        /// <param name="SessionKey"></param>
        /// <param name="Errormsg"></param>
        /// <returns></returns>
        internal string findDetailByDetailId(int detailId, string SessionKey, out string Errormsg)
        {
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpDetailGetRequest req = new UmpDetailGetRequest();
            req.DetailId = detailId;
            UmpDetailGetResponse resp = client.Execute(req, SessionKey);
            if (!resp.IsError)
            {
                return resp.Content;
            }
            else
            {
                Errormsg = resp.ErrMsg;
                return null;
            }

        }


        /// <summary>
        /// 获取活动详情内容
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        internal string getMarketingActivity(int detail_id, string SessionKey, out string Errormsg)
        {

            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpDetailGetRequest req = new UmpDetailGetRequest();
            req.DetailId = detail_id;
            UmpDetailGetResponse resp = client.Execute(req, SessionKey);
            if (!resp.IsError)
            {
                return resp.Content;
            }
            else
            {
                Errormsg = resp.ErrMsg;
                return null;
            }
        }


        /// <summary>
        /// 获取活动范围内容
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        internal List<Range> getActivityRange(int ActId, string SessionKey, out string Errormsg)
        {
            Errormsg = null;
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            UmpRangeGetRequest req = new UmpRangeGetRequest();
            req.ActId = ActId;
            UmpRangeGetResponse resp = client.Execute(req, SessionKey);
            if (!resp.IsError)
            {
                return resp.Ranges;
            }
            else
            {
                Errormsg = resp.ErrMsg;
                return null;
            }
        }
        /// <summary>
        ///  查询地址区域
        /// </summary>
        /// <returns></returns>
        internal List<Area> GetAreas()
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret, "json");
            AreasGetRequest req = new AreasGetRequest();
            req.Fields = "id,type,name,parent_id";
            AreasGetResponse response = client.Execute(req);
            List<Area> list = new List<Area>();
            Area temp = null;
            foreach (var item in response.Areas)
            {
                temp = new Area();
                temp.Id = item.Id;
                temp.Type = item.Type;
                temp.Name = item.Name;
                temp.ParentId = item.ParentId;
                list.Add(temp);
            }
            return list;
        }

    }
}
