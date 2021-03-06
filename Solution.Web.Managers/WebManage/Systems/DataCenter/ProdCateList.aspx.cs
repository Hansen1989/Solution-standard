﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using DotNet.Utilities;
using Solution.Logic.Managers;
using Solution.DataAccess.DbHelper;
using Solution.Web.Managers.WebManage.Application;
using Solution.DataAccess.DataModel;
using SubSonic.Query;
using System.Data;


namespace Solution.Web.Managers.WebManage.Systems.DataCenter
{
    public partial class ProdCateList : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        public override void Init()
        {
            //逻辑对象赋值
            bll = V_PROD_CATEBll.GetInstence();

            ////表格对象赋值
            grid = Grid1;
        }
        #endregion

        #region 加载数据
        /// <summary>读取数据</summary>
        public override void LoadData()
        {
            //设置排序
            if (sortList == null)
            {
                Sort();
            }
            conditionList = null;
            conditionList = new List<ConditionFun.SqlqueryCondition>();
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "1", Comparison.Equals, "1", false, false));
            //绑定Grid表格
            bll.BindGrid(Grid1, 0, 0, conditionList, sortList);


        }


        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private int InquiryCondition()
        {
            int value = 0;

            //选择菜单
            //if (ddlParentId.SelectedValue != "0")
            //{
            //    value = ConvertHelper.Cint0(ddlParentId.SelectedValue);
            //}
            return value;
        }



        #region 排序
        /// <summary>
        /// 页面表格绑定排序
        /// </summary>
        public void Sort()
        {
            //设置排序
            sortList = new List<string>();
            sortList.Add(PROD_CateTable.Id);

        }
        #endregion

        #endregion

        #region 列表按键绑定——修改列表控件属性
        /// <summary>
        /// 列表按键绑定——修改列表控件属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_PreRowDataBound(object sender, FineUI.GridPreRowEventArgs e)
        {
            int o = e.RowIndex;

            //GridRow gr = Grid1.Rows[e.RowIndex];  // + 1
            DataRowView row = e.DataItem as DataRowView;

            //PROD_DEPBll.GetInstence().BandDropDownListShowDep(this, (System.Web.UI.WebControls.DropDownList)Grid1.Rows[e.RowIndex].FindControl("DEP_NAME"));
            //DEP_NAME.SelectedValue = ((System.Data.DataRowView)(gr.DataItem)).Row.Table.Rows[e.RowIndex][PROD_CateTable.DEP_ID].ToString();
            //DEP_NAME.Enabled = false;

            if ((row).Row.Table.Rows[e.RowIndex][PROD_DEPTable.ENABLE].ToString() == "0")
            {
                var lbf = Grid1.FindColumn("ENABLE") as LinkButtonField;
                lbf.Icon = Icon.BulletCross;
                lbf.CommandArgument = "1";
            }
            else
            {
                var lbf = Grid1.FindColumn("ENABLE") as LinkButtonField;
                lbf.Icon = Icon.BulletTick;
                lbf.CommandArgument = "0";
            }
            //绑定是否编辑列
            var lbfEdit = Grid1.FindColumn("ButtonEdit") as LinkButtonField;
            lbfEdit.Text = "编辑";
            lbfEdit.Enabled = MenuInfoBll.GetInstence().CheckControlPower(this, "ButtonEdit");

        }
        #endregion

        #region 添加新记录
        /// <summary>
        /// 添加新记录
        /// </summary>
        public override void Add()
        {
            Window1.IFrameUrl = "ProdCateEdit.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
            Window1.Hidden = false;
        }
        #endregion

        #region 编辑记录
        /// <summary>
        /// 编辑记录
        /// </summary>
        public override void Edit()
        {
            string id = GridViewHelper.GetSelectedKey(Grid1, true);

            Window1.IFrameUrl = "ProdCateEdit.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id);
            Window1.Hidden = false;
        }
        #endregion

        #region 删除记录
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <returns></returns>
        public override string Delete()
        {
            //获取要删除的ID
            int id = ConvertHelper.Cint0(GridViewHelper.GetSelectedKey(Grid1, true));

            //如果没有选择记录，则直接退出
            if (id == 0)
            {
                return "请选择要删除的记录。";
            }

            try
            {
                //删除记录
                bll.Delete(this, id);

                return "删除编号ID为[" + id + "]的数据记录成功。";
            }
            catch (Exception e)
            {
                string result = "尝试删除编号ID为[" + id + "]的数据记录失败！";

                //出现异常，保存出错日志信息
                CommonBll.WriteLog(result, e);

                return result;
            }
        }
        #endregion

        #region Grid点击事件
        /// <summary> 
        /// Grid点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            GridRow gr = Grid1.Rows[e.RowIndex];
            //获取当前点击列的主键ID
            object id = gr.DataKeys[0];


            //因为要记录修改人，修改时间跟最后更新时间，所以将单字段更新换成多字段更新
            switch (e.CommandName)
            {
                case "ENABLE":
                    try
                    {
                        var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == OnlineUsersBll.GetInstence().GetUserHashKey());
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        dic.Add("ENABLE", ConvertHelper.StringToByte(e.CommandArgument));
                        dic.Add("MOD_DATETIME", ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")));
                        dic.Add("MOD_USER_ID", OlUser.Manager_LoginName);
                        dic.Add("LAST_UPDATE", ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")));
                        if (ConvertHelper.Cint0(id) > 0)
                        {
                            PROD_CateBll.GetInstence().UpdateValue(this, ConvertHelper.Cint0(id), dic);
                        }
                        LoadData();
                        //PROD_KINDBll.GetInstence().Save(this, model);
                    }
                    catch (Exception err)
                    {
                        //出现异常，保存出错日志信息
                        CommonBll.WriteLog("保存失败", err);
                    }
                    //更新状态
                    //PROD_KINDBll.GetInstence().UpdateENABLE(this, ConvertHelper.Cint0(id), ConvertHelper.Cint0(e.CommandArgument));
                    //重新加载
                    //LoadData();

                    break;
                case "ButtonEdit":
                    //打开编辑窗口
                    Window1.IFrameUrl = "ProdCateEdit.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id + "");
                    Window1.Hidden = false;

                    break;
            }
        }
        #endregion
    }
}