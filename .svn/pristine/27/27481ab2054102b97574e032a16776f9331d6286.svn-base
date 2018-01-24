using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json.Linq;
using Solution.Web.Managers.WebManage.Application;
using FineUI;
using Solution.Logic.Managers;
using Solution.DataAccess.DataModel;

namespace Solution.Web.Managers.WebManage.Systems.SupplyCenter
{
    /// <summary>
    /// test 的摘要说明
    /// </summary>
    public class test : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string Prod_ID = context.Request["value"];



            context.Response.Write("商品名字1");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}