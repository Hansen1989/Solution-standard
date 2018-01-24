using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineUI;
using DotNet.Utilities;
using Solution.Logic.Managers;
using Solution.DataAccess.DbHelper;
using Solution.Web.Managers.WebManage.Application;
using Solution.DataAccess.DataModel;
using SubSonic.Query;
using System.Data;
using Newtonsoft.Json.Linq;

namespace Solution.Web.Managers.WebManage.Systems.DataCenter
{
    /// <summary>
    /// SUPPLIERSHander 的摘要说明
    /// </summary>
    public class SUPPLIERSHander : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string opt = context.Request["opt"];
            string result = "";
            switch (opt)
            {
                case "1": string SUP_ID = context.Request["SUP_ID"];
                          string columnName = context.Request["columnName"];
                          result=SUPPLIERSBll.GetInstence().GetModelSingleValue(columnName,x=>x.SUP_ID==SUP_ID) ; break;
                default: result = ""; break;
            }
            context.Response.Write(result);
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