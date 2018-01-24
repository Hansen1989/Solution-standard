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
    /// Prodcut00Handler 的摘要说明
    /// </summary>
    public class Prodcut00Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string opt = context.Request["opt"];
            string result = "";
            string PROD_ID = context.Request["PROD_ID"];
            switch (opt)
            {
                case "1": string columnName = context.Request["columnName"];
                    result = PRODUCT00Bll.GetInstence().GetModelSingleValue(columnName, x => x.PROD_ID == PROD_ID); break;
                case "2": string P_PRICE=context.Request["P_PRICE"];
                    string UNIT_TYPE = context.Request["UNIT_TYPE"];
                    result = PRODUCT00Bll.GetInstence().Tran_PRICE_UNIT(PROD_ID, P_PRICE, UNIT_TYPE);break;
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