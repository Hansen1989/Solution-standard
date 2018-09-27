﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using System.Data;
using System.Xml.Linq;
using System.Linq.Expressions;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;

namespace Solution.Logic.Managers
{
    public partial class STOCKBll : LogicBase
    {
        #region 绑定菜单下拉列表
        /// <summary>
        /// 绑定菜单下拉列表——显示所有的数据
        /// </summary>
        public void BandDropDownListStock(Page page, FineUI.DropDownList ddl)
        {

            //在内存中筛选记录
            //在内存中筛选记录
            var dt = DataTableHelper.GetFilterData(GetDataTable(), "1", "1", STOCKTable.Id, " desc");

            try
            {
                //显示值
                ddl.DataTextField = STOCKTable.STOCK_NAME ;
                //显示key
                ddl.DataValueField = STOCKTable.STOCK_ID;
                //数据层次
                //绑定数据源
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.SelectedIndex = 0;

                //ddl.Items.Insert(0, new FineUI.ListItem("请选择分店", "0"));
                //ddl.SelectedValue = "0";
            }
            catch (Exception e)
            {
                // 记录日志
                CommonBll.WriteLog("", e);
            }
        }

        /// <summary>
        /// 绑定菜单下拉列表——显示所有的数据
        /// </summary>
        public void BandOnlineUserStock(Page page,string shop_id, FineUI.DropDownList ddl)
        {

            //在内存中筛选记录
            //在内存中筛选记录

            List<ConditionFun.SqlqueryCondition> shopCondit = new List<ConditionFun.SqlqueryCondition>();
            shopCondit.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, STOCKTable.SHOP_ID, Comparison.Equals, shop_id, false, false));
            var dt = DataTableHelper.GetFilterData(GetDataTable(false, 0, null, 0, 0, shopCondit, null), "1", "1", STOCKTable.Id, " desc");

            try
            {
                //显示值
                ddl.DataTextField = STOCKTable.STOCK_NAME;
                //显示key
                ddl.DataValueField = STOCKTable.STOCK_ID;
                //数据层次
                //绑定数据源
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.SelectedIndex = 0;

                //ddl.Items.Insert(0, new FineUI.ListItem("请选择分店", "0"));
                //ddl.SelectedValue = "0";
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
