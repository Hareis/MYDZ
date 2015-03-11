using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MYDZ.Config;
using Top.Api.Request;
using Top.Api.Response;
using Top.Api;
using MYDZ.Config.Soft;

namespace MYDZ.Business.TB_Logic.InitUser
{
    internal class UserIP
    {
        /// <summary>
        /// 返回从前台获取的IP
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        internal string getIp( string ip)
        { 
            return ip;
        }

        internal string GetAddress(string IP, string UserId)
        {
            ITopClient client = new DefaultTopClient(StaticSystemConfig.soft.ApiURL, StaticSystemConfig.soft.AppKey, StaticSystemConfig.soft.AppSecret);
            AlibabaGeoipGetRequest req = new AlibabaGeoipGetRequest();
            req.Ip = IP;
            req.Language = "cn";
            AlibabaGeoipGetResponse response = client.Execute(req);
            return response.Country + " " + response.City + " " + response.County + " " + response.Isp;
        }
    }
}
