using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using System.Data;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;
using System.Collections.Generic;


namespace Solution.Logic.Managers
{
    public partial class PROD_DEPBll : LogicBase
    {
        #region 绑定菜单下拉列表
        /// <summary>
        /// 绑定菜单下拉列表——显示所有的数据
        /// </summary>
        public void BandDropDownListShowDep(Page page, FineUI.DropDownList ddl)
        {

            //在内存中筛选记录
            //在内存中筛选记录
            var dt = DataTableHelper.GetFilterData(GetDataTable(), "1", "1", PROD_DEPTable.Id, " asc");

            try
            {
                //显示值
                ddl.DataTextField = PROD_DEPTable.DEP_NAME;
                //显示key
                ddl.DataValueField = PROD_DEPTable.DEP_ID;
                //数据层次
                //绑定数据源
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.SelectedIndex = 0;

                ddl.Items.Insert(0, new FineUI.ListItem("", "0"));
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
        public void BandDropDownListShowDep(Page page, System.Web.UI.WebControls.DropDownList ddl)
        {

            //在内存中筛选记录
            var dt = DataTableHelper.GetFilterData(GetDataTable(), "1", "1", PROD_DEPTable.Id, " asc");

            try
            {
                //显示值
                ddl.DataTextField = PROD_DEPTable.DEP_NAME;
                //显示key
                ddl.DataValueField = PROD_DEPTable.DEP_ID;
                //数据层次
                //绑定数据源
                ddl.DataSource = dt;
                ddl.DataBind();


                //ddl.SelectedIndex = 0;

                //ddl.Items.Insert(0, new FineUI.ListItem("请选择大类", ""));
                //ddl.SelectedValue = "";
            }
            catch (Exception e)
            {
                // 记录日志
                CommonBll.WriteLog("", e);
            }
        }
        #endregion

        public string GetProdDep(string DEP_ID)
        {
            List<ConditionFun.SqlqueryCondition> conditionProdduct00List = new List<ConditionFun.SqlqueryCondition>();
            conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, PROD_DEPTable.DEP_ID, Comparison.Equals, DEP_ID, false, false));
            DataTable da = PROD_DEPBll.GetInstence().GetDataTable(false, 0, null, 0, 0, conditionProdduct00List, null);
            string result=DotNet.Utilities.Json.JsonHelper.ToJson(da);
            return result;
        }
    }
}
