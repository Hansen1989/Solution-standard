using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution.Web.Managers.WebManage.Application;
using Solution.Logic.Managers;
using Solution.DataAccess.DataModel;
using FineUI;
using DotNet.Utilities;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;

namespace Solution.Web.Managers.WebManage.Systems.Powers
{
    public partial class PagePowerSignPublicList : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定下拉列表

               // MenuInfoBll.GetInstence().BandDropDownListShowMenu(this, ddlParentId);
                //ddlParentId.Items.Insert(0, new FineUI.ListItem("请选择菜单", "0"));
                //ddlParentId.SelectedValue = "0";

                LoadData();
            }
        }


        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        public override void Init()
        {
            //逻辑对象赋值
            bll = PagePowerSignPublicBll.GetInstence();
            //表格对象赋值
            grid = Grid1;
        }
        #endregion

        #region 加载数据
        /// <summary>读取数据override</summary>
        public override void LoadData()
        {
            //设置排序
            if (sortList == null)
            {
                Sort();
            }


            //绑定Grid表格
            //绑定Grid表格
            conditionList = new List<ConditionFun.SqlqueryCondition>();
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "1", Comparison.Equals, "1", false, false));
            bll.BindGrid(Grid1, 0, 0, conditionList, sortList);
           // bll.BindGrid(Grid1, InquiryCondition(),sortList);

            ////赋值DropdownList
            //string result ="";
            //DataSet ds =null;
            //Grid1.DataSource = PagePowerSignBll.GetInstence().GetListForPagePowers(ds, out result, ddlParentId.SelectedValue);
            //Grid1.DataBind();

            //DataSet ds1=null;
            //ds1 = PagePowerSignBll.GetInstence().GetMenuInfoNameList(ds1, out result, ddlParentId.SelectedValue);

            //int i = 0;
            //    if(ds1 !=null){
            //    foreach(DataRow item in ds1.Tables[0].Rows){

            //        i++;
            //        ddlParentId.Items.Insert(i, new FineUI.ListItem(item[1].ToString(), item[0].ToString()));
            //    }
            //}

            
        }
        #endregion


        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private int InquiryCondition()
        {
            int value = 0;

            ////选择菜单
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
            sortList.Add(PagePowerSignPublicTable.Id + " asc");
          //  sortList.Add(MenuInfoTable.Sort + " asc");
        }
        #endregion


        #region 列表属性绑定

        #region 列表按键绑定——修改列表控件属性
        /// <summary>
        /// 列表按键绑定——修改列表控件属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_PreRowDataBound(object sender, FineUI.GridPreRowEventArgs e)
        {
            //绑定是否显示状态列
            int o = e.RowIndex;

            //GridRow gr = Grid1.Rows[e.RowIndex];  // + 1
            //if (((System.Data.DataRowView)(gr.DataItem)).Row.Table.Rows[e.RowIndex][MenuInfoTable.IsDisplay].ToString() == "0")
            //{
            //    var lbf = Grid1.FindColumn("IsDisplay") as LinkButtonField;
            //    lbf.Icon = Icon.BulletCross;
            //    lbf.CommandArgument = "1";
            //}
            //else
            //{
            //    var lbf = Grid1.FindColumn("IsDisplay") as LinkButtonField;
            //    lbf.Icon = Icon.BulletTick;
            //    lbf.CommandArgument = "0";
            //}

            ////绑定是否菜单列
            //if (((System.Data.DataRowView)(gr.DataItem)).Row.Table.Rows[e.RowIndex][MenuInfoTable.IsMenu].ToString() == "0")
            //{
            //    var lbf = Grid1.FindColumn("IsMenu") as LinkButtonField;
            //    lbf.Icon = Icon.BulletCross;
            //    lbf.CommandArgument = "1";
            //}
            //else
            //{
            //    var lbf = Grid1.FindColumn("IsMenu") as LinkButtonField;
            //    lbf.Icon = Icon.BulletTick;
            //    lbf.CommandArgument = "0";
            //}

            //绑定是否编辑列
            //var lbfEdit = Grid1.FindColumn("ButtonEdit") as LinkButtonField;
            //lbfEdit.Text = "编辑";
            //lbfEdit.Enabled = MenuInfoBll.GetInstence().CheckControlPower(this, "ButtonEdit");


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

            //switch (e.CommandName)
            //{
            //    case "IsDisplay":
            //        //更新状态
            //        MenuInfoBll.GetInstence().UpdateIsDisplay(this, ConvertHelper.Cint0(id), ConvertHelper.Cint0(e.CommandArgument));
            //        //重新加载
            //        LoadData();

            //        break;
            //    case "IsMenu":
            //        //更新状态
            //        MenuInfoBll.GetInstence().UpdateIsMenu(this, ConvertHelper.Cint0(id), ConvertHelper.Cint0(e.CommandArgument));
            //        //重新加载
            //        LoadData();

            //        break;
            //    case "ButtonEdit":
            //        //打开编辑窗口
            //        Window1.IFrameUrl = "MenuInfoEdit.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id + "");
            //        Window1.Hidden = false;

            //        break;
            //}
        }
        #endregion

        #endregion

        #region 添加新记录
        /// <summary>
        /// 添加新记录
        /// </summary>
        public override void Add()
        {
            Window1.IFrameUrl = "PagePowerSignPublicEdit.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
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

            Window1.IFrameUrl = "PagePowerSignPublicEdit.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id);
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
                //删除前判断一下
                if (PagePowerSignBll.GetInstence().Exist(x => x.Id == id))
                {
                    return "删除失败，本菜单下面存在子菜单，不能直接删除！";
                }
                //删除前判断一下
                if (PagePowerSignBll.GetInstence().Exist(x => x.MenuInfo_Id == id))
                {
                    return "删除失败，本菜单已绑定有页面控件权限标志，不能直接删除！";
                }

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

    }

}