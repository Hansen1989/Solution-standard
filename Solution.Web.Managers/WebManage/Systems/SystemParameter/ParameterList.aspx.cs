using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using SubSonic.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solution.Web.Managers.WebManage.Systems.SystemParameter
{
   
    public partial class ParameterList : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定下拉列表

                GROUPAREABll.GetInstence().BandDropDownList(this, ddlParentId);

                LoadData();
            }
        }


        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        public override void Init()
        {
             
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
            conditionList = new List<ConditionFun.SqlqueryCondition>();
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "1", Comparison.Equals, "1", false, false));
            PARAMETERBll.GetInstence().BindGrid(Grid1, 0, 0, conditionList, sortList);
            // bll.BindGrid(Grid1, InquiryCondition(), sortList);
        }
        #endregion

        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private int InquiryCondition()
        {
            int value = 1;

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
            // sortList.Add(BranchTable.Id + " asc");
            // sortList.Add(BranchTable.Sort + " asc");
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

            DataRowView row = e.DataItem as DataRowView;

            
            string AREA_ID = ((System.Data.DataRowView)(row)).Row.Table.Rows[e.RowIndex][GROUPAREATable.AREA_ID].ToString();
            var model = new GROUPAREA(x => x.AREA_ID == AREA_ID);
            if (model != null)
            {
                // ((System.Data.DataRowView)(gr.DataItem)).Row[e.RowIndex]
                var tf = Grid1.FindColumn("Area_Id") as FineUI.LinkButtonField;
                tf.Text = model.AREA_NAME;

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
            Window1.IFrameUrl = "ParameterEdit.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
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

            Window1.IFrameUrl = "ParameterEdit.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id);
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
                if (MenuInfoBll.GetInstence().Exist(x => x.ParentId == id))
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