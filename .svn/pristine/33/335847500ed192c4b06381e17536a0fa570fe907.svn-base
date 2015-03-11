
/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web.Mvc;

namespace MYDZ.WebUI
{
    /// <summary>
    /// URL重写
    /// </summary>
     public class UrlProvider:RouteBase
    {
        public override RouteData GetRouteData(System.Web.HttpContextBase httpContext)
        {
            string controller = "Home";
            string action = "Index";
            string Id = "test";
            var data = new RouteData(this, new MvcRouteHandler());

            data.Values.Add("controller", controller);
            data.Values.Add("action", action);
            var url = httpContext.Request.Url;
            if (url != null)
            {
                data.Values.Add("id", Id);
                return data;
            }
            string virtualpath = url.ToString();
            string param = virtualpath.Replace("http://", "").Split('.')[0];
            if (param.Equals("www"))
            {
                data.Values.Add("id", Id);
                return data;
            }
            Id = param;
            data.Values.Add("id", Id);
            return data;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            //判断请求是否来源于CategoryController.Showcategory(string id),不是则返回null,让匹配继续
            var categoryId = values["id"] as string;

            if (categoryId == null)//路由信息中缺少参数id，不是我们要处理的请求，返回null
                return null;

            //请求不是CategoryController发起的，不是我们要处理的请求，返回null
            if (!values.ContainsKey("controller") || !values["controller"].ToString().Equals("category", StringComparison.OrdinalIgnoreCase))
                return null;
            //请求不是CategoryController.Showcategory(string id)发起的，不是我们要处理的请求，返回null
            if (!values.ContainsKey("action") || !values["action"].ToString().Equals("showcategory", StringComparison.OrdinalIgnoreCase))
                return null;

            //至此，我们可以确定请求是CategoryController.Showcategory(string id)发起的，生成相应的URL并返回
            var category = CategoryManager.AllCategories.Find(c => c.CategoeyID == categoryId);

            if (category == null)
                throw new ArgumentNullException("category");//找不到分类抛出异常

            var path = "ca-" + category.CategoeyName.Trim();//生成URL

            return new VirtualPathData(this, path.ToLowerInvariant());
        }
    }
}*/
