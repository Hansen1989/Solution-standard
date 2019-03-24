using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using System.Data;
using System.Linq.Expressions;
using SubSonic.Query;
using Solution.DataAccess.DbHelper;


namespace Solution.Logic.Managers
{
    public partial class PRODUCT00Bll : LogicBase
    {
        #region 绑定菜单下拉列表
        /// <summary>
        /// 绑定菜单下拉列表——显示所有的数据
        /// </summary>
       public void BandDropDownListShowProductName1(Page page, FineUI.DropDownList ddl)
        {
          
            
            //在内存中筛选记录
            var dt = DataTableHelper.GetFilterData(GetDataTable(),"1" , "1", PRODUCT00Table.Id,"");

            try
            {
                //显示值
               // ddl.DataTextField = PRODUCT00Table.PROD_NAME1;
                //显示key
               // ddl.DataValueField = PRODUCT00Table.PROD_ID;
                //数据层次
                //绑定数据源
                //绑定数据源

                ddl.DataTextField = PRODUCT00Table.PROD_NAME1;
                ddl.DataValueField = PRODUCT00Table.PROD_ID;

                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.SelectedIndex = 0;
 
                ddl.Items.Insert(0, new FineUI.ListItem("请选择", "0"));
                ddl.SelectedValue = "0";

            }
            catch (Exception e)
            {
                // 记录日志
                CommonBll.WriteLog("", e);
            }
        }
       #endregion

       #region 绑定菜单下拉列表
       /// <summary>
       /// 绑定菜单下拉列表——显示所有的数据
       /// </summary>
       public void BandDropDownListShowProductName_1(Page page, System.Web.UI.WebControls.DropDownList ddl)
       {


           //在内存中筛选记录
           var dt = DataTableHelper.GetFilterData(GetDataTable(), "1", "1", PRODUCT00Table.Id, "");

           try
           {
               //显示值
               // ddl.DataTextField = PRODUCT00Table.PROD_NAME1;
               //显示key
               // ddl.DataValueField = PRODUCT00Table.PROD_ID;
               //数据层次
               //绑定数据源
               //绑定数据源
               //ddl.DataSource = dt;
               //ddl.DataBind();

               ddl.DataTextField = PRODUCT00Table.PROD_NAME1;
               ddl.DataValueField = PRODUCT00Table.PROD_ID;

               ddl.DataSource = dt;
               ddl.DataBind();
               
               //ddl.Items.Insert(0, new FineUI.ListItem("请选择", "0"));
               //ddl.SelectedValue = "0";

           }
           catch (Exception e)
           {
               // 记录日志
               CommonBll.WriteLog("", e);
           }
       }

        #endregion

       #region 绑定菜单下拉列表
       /// <summary>
       /// 绑定菜单下拉列表——显示所有的数据
       /// </summary>
       public DataTable BandDropDownListShowProductName_1(Page page,FineUI.DropDownList ddl,string shop_id)
       {


           //在内存中筛选记录
           var dt = GET_PRODUCT00_PRODUCT01_LIST_("0",shop_id);// DataTableHelper.GetFilterData(GetDataTable(), "1", "1", PRODUCT00Table.Id, "");

           try
           {
               ddl.DataTextField = PRODUCT00Table.PROD_NAME1;
               ddl.DataValueField = PRODUCT00Table.PROD_NAME1;

               ddl.DataSource = dt;
               ddl.DataBind();
               ddl.SelectedIndex = 0;

                ddl.Items.Insert(0, new FineUI.ListItem("请选择", "0"));
                ddl.SelectedValue = "0";

            }
           catch (Exception e)
           {
               // 记录日志
               CommonBll.WriteLog("", e);
           }

           return dt;
       }

       #endregion

       public DataTable GET_PRODUCT00_PRODUCT01_LIST_(string prod_id,string shop_id) 
       {
           DataTable dt = null;
           dt = (DataTable)SPs.GET_PRODUCT00_PRODUCT01_LIST(prod_id, shop_id).ExecuteDataTable();

           return dt;
       
       }

       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prod_id"></param>
        /// <returns></returns>
        public DataTable Insert_PRODUCT01(string prod_id, string crt_user_id)
       {
           DataTable dt = null;
           dt = (DataTable)SPs.Insert_PRODUCT01(prod_id, crt_user_id).ExecuteDataTable();

           return dt;

       }

        
       /// <summary>
       /// 读取某个固定字段的值
       /// </summary>
       /// <param name="conditionColName"></param>
       /// <param name="value"></param>
       /// <returns></returns>
       public string GetModelSingleValue(string colunm, Expression<Func<PRODUCT00, bool>> expression)
       {
           string result = "";
           try
           {
               var model = new PRODUCT00(expression);
               switch (colunm)
               {
                   case "PROD_ID": result = model.PROD_ID; break;
                   case "PROD_NAME1": result = model.PROD_NAME1.ToString(); break;
                   case "PROD_NAME2;": result = model.PROD_NAME2; break;
                   default: result = ""; break;
               }
           }
           catch
           {
               result = "";
           }
           return result;
       }


       /// <summary>
       /// 转换价格
       /// </summary>
       /// <param name="PROD_ID">商品编码</param>
       /// <param name="P_PRICE">价格</param>
       /// <param name="UNIT_TYPE">单位类型</param>
       /// <returns></returns>
       public string Tran_PRICE_UNIT(string PROD_ID, string P_PRICE, string UNIT_TYPE)
       {
           DataTable dt = new DataTable();
           dt = (DataTable)SPs.Tran_PRICE_UNIT(PROD_ID,ConvertHelper.StringToDecimal(P_PRICE),ConvertHelper.Cint(UNIT_TYPE)).ExecuteDataTable();
           string a = dt.Rows[0][0].ToString();
           string b = dt.Rows[0][1].ToString();
           string c = dt.Rows[0][2].ToString();
           string jsonData = DotNet.Utilities.ConvertJson.ToJson(dt);
           return jsonData;
       }
    }
}
