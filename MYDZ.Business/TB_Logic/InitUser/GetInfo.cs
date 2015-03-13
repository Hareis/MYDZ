﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Config.Soft;
using System.Collections;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using System.Net;

namespace MYDZ.Business.TB_Logic
{
    public class GetInfo
    {
        static SoftInfoConfig soft = null;
        /// <summary>
        /// 返回授权的URL
        /// </summary>
        /// <returns></returns>
        public static string ReturnUrl()
        {
            SoftInfoConfigs a = new SoftInfoConfigs();
            soft = SoftInfoConfigs.GetConfig();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("response_type", "code");
            dic.Add("client_id", soft.AppKey);
            dic.Add("redirect_uri", soft.CallBackUrl);
            dic.Add("state", "TB");
            dic.Add("view", "web");
            Top.Api.Util.WebUtils WebUtil = new Top.Api.Util.WebUtils();
            return WebUtil.BuildGetUrl(soft.ZSHJ, dic);
        }

        /// <summary>
        /// 通过code获取Token和ExpiresTime
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static object GetAccesstoken(string code)
        {
            try
            {
                List<string> AccessToken = new List<string>();
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("client_secret", soft.AppSecret);
                dic.Add("client_id", soft.AppKey);
                dic.Add("redirect_uri", soft.CallBackUrl);
                dic.Add("grant_type", "authorization_code");
                dic.Add("code", code);
                dic.Add("state", "TB");
                dic.Add("view", "web");
                Top.Api.Util.WebUtils WebUtil = new Top.Api.Util.WebUtils();
                IDictionary usertoken = Top.Api.Util.TopUtils.ParseJson(WebUtil.DoPost(soft.AccessTokenURL, dic));
                return new { AccessToken = usertoken["access_token"].ToString(), ExpiresIn = DateTime.Now.AddSeconds(double.Parse(usertoken["expires_in"].ToString())) };
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 从淘宝获取订用户信息
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <returns></returns>
        public static Top.Api.Domain.User GetUser(string AccessToken)
        {
            ITopClient client = new DefaultTopClient(soft.ApiURL, soft.AppKey, soft.AppSecret, "Json");
            UserSellerGetRequest req = new UserSellerGetRequest();
            req.Fields = "user_id,nick,sex,seller_credit,type,has_more_pic,item_img_num,item_img_size,prop_img_num,prop_img_size,auto_repost,promoted_type,status,alipay_bind,consumer_protection,avatar,liangpin,sign_food_seller_promise,has_shop,is_lightning_consignment,has_sub_stock,is_golden_seller,vip_info,magazine_subscribe,vertical_market,online_gaming";
            UserSellerGetResponse response = client.Execute(req, AccessToken.ToString());
            return response.User;
        }

    }
}
