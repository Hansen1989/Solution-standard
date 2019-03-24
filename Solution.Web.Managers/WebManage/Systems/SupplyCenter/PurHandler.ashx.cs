using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Solution.Logic.Managers;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;

namespace Solution.Web.Managers.WebManage.Systems.SupplyCenter
{
    /// <summary>
    /// PurHandler 的摘要说明
    /// </summary>
    public class PurHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string Prod_ID = context.Request["value"];
            string Shop_ID = context.Request["value1"];
            

            string resultJson = V_Product01_PRCAREABll.GetInstence().GetSingleV_Product01_PRCAREAInfos(Prod_ID,Shop_ID);

            context.Response.Write(resultJson);
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