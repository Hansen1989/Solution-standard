//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;


namespace Solution.Logic.Managers
{
    public partial class PROD_KINDBll : LogicBase
    {
        #region 绑定菜单下拉列表
        /// <summary>
        /// 绑定菜单下拉列表——显示所有的数据
        /// </summary>
        public void BandDropDownListShowKind(Page page, FineUI.DropDownList ddl)
        {

            //在内存中筛选记录
            var dt = DataTableHelper.GetFilterData(GetDataTable(), "1", "1", PROD_KINDTable.Id, " asc");

            try
            {
                //显示值
                ddl.DataTextField = PROD_KINDTable.KIND_NAME;
                //显示key
                ddl.DataValueField = PROD_KINDTable.KIND_ID;
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
        public void BandDropDownListShowKind(Page page, System.Web.UI.WebControls.DropDownList ddl)
        {

            //在内存中筛选记录
            System.Collections.Generic.List<Solution.DataAccess.DbHelper.ConditionFun.SqlqueryCondition> conditionList = new System.Collections.Generic.List<Solution.DataAccess.DbHelper.ConditionFun.SqlqueryCondition>();
            conditionList.Add(new Solution.DataAccess.DbHelper.ConditionFun.SqlqueryCondition(SubSonic.Query.ConstraintType.Where, "1", SubSonic.Query.Comparison.Equals, "1", false, false));
            var dt = DataTableHelper.GetFilterData(GetDataTable(false, 0, null, 0, 0, conditionList, null), "1", "1", PROD_KINDTable.Id, " asc");

            try
            {
                //显示值
                ddl.DataTextField = PROD_KINDTable.KIND_NAME;
                //显示key
                ddl.DataValueField = PROD_KINDTable.KIND_ID;
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
    }
}
