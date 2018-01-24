using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Solution.Logic.Managers;
using System.Web.Script.Serialization;

namespace Solution.Web.Managers.WebManage.Systems.SupplyCenter
{
    /// <summary>
    /// OrdersListHandler 的摘要说明
    /// </summary>
    public class OrdersListHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string Prod_ID = context.Request["value"];
            string Shop_ID = context.Request["value1"];
            string Ordep_ID = context.Request["value2"];

            DataTable dt = PRODUCT00Bll.GetInstence().GET_PRODUCT00_PRODUCT01_LIST_(Prod_ID,Shop_ID);
            int d = dt.Rows.Count;

            string resultJson = Dtb2Json(dt);

            context.Response.Write(resultJson);
        }

        /// <summary>
       /// 将datatable转换为json  
       /// <param name="dtb">Dt</param>
        /// <returns>JSON字符串</returns>
        public static string Dtb2Json(DataTable dtb)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            System.Collections.ArrayList dic = new System.Collections.ArrayList();
            foreach (DataRow dr in dtb.Rows)
             {
                  System.Collections.Generic.Dictionary<string, object> drow = new System.Collections.Generic.Dictionary<string, object>();
                  foreach (DataColumn dc in dtb.Columns)
                  {
                    drow.Add(dc.ColumnName, dr[dc.ColumnName]);
                  }
                 dic.Add(drow);
 
             }
             //序列化  
             return jss.Serialize(dic);
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