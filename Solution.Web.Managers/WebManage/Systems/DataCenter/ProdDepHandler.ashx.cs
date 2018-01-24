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
    /// ProdDepHandler 的摘要说明
    /// </summary>
    public class ProdDepHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string opt = context.Request["opt"];
            if (opt == null) opt = "";
            string result = "";
            switch (opt)
            {
                case "1":string dep_id = context.Request["dep_id"];
                    if (dep_id == null) dep_id = "";
                    result = PROD_DEPBll.GetInstence().GetProdDep(dep_id);
                    break;
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