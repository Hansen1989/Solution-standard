using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;

namespace Solution.Logic.Managers
{
    public partial class SHOP_PRICE_AREABll : LogicBase
    {
        #region 绑定菜单下拉列表
        /// <summary>
        /// 绑定菜单下拉列表——显示所有的数据
        /// </summary>
        public void BandDropDownListShowArea(Page page, FineUI.DropDownList ddl)
        {

            //在内存中筛选记录
            var dt = DataTableHelper.GetFilterData(GetDataTable(), "1", "1", SHOP_PRICE_AREATable.Id, " asc");

            try
            {
                //显示值
                ddl.DataTextField = SHOP_PRICE_AREATable.PRCAREA_NAME;
                //显示key
                ddl.DataValueField = SHOP_PRICE_AREATable.PRCAREA_ID;
                //数据层次
                //绑定数据源
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.SelectedIndex = 0;

                ddl.Items.Insert(0, new FineUI.ListItem("请选择价格区域", "0"));
                ddl.SelectedValue = "0";
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
