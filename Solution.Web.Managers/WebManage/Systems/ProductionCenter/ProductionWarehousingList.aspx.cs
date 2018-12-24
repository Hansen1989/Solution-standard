using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution.Web.Managers.WebManage.Application;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using FineUI;
using DotNet.Utilities;

namespace Solution.Web.Managers.WebManage.Systems.ProductionCenter
{
   
      public partial class ProductionWarehousingList : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定下拉列表

               // BranchBll.GetInstence().BandDropDownListShowMenu(this, ddlParentId);

                LoadData();
            }
        }

        #region 加载数据
        /// <summary>读取数据override</summary>
        public override void LoadData()
        {
            //设置排序
            if (sortList == null)
            {
                Sort();
            }

            //string sql = "SELECT [Id],[Name],[Branch_Id],[Branch_Code],[Branch_Name],[PagePower],[ControlPower],[IsSetBranchPower],[SetBranchCode],[Manager_Id],[Manager_CName],[UpdateDate] FROM [SolutionDataBase].[dbo].[Position]";
            //Grid1.DataSource = DbHelperSQL.Query(sql);
            //Grid1.DataBind();

            conditionList = new List<ConditionFun.SqlqueryCondition>();
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "1", Comparison.Equals, "1", false, false));
            //bll.BindGrid(Grid1, 0, sortList);
            bll.BindGrid(Grid1, 0, 0, conditionList, sortList);

            //绑定Grid表格
           //  bll.BindGrid(Grid1, InquiryCondition(), sortList);
        }
        #endregion

        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private int InquiryCondition()
        {
            int value = 0;
 
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
            sortList.Add(TAKEIN00Table.Id + " asc");
            //  sortList.Add(MenuInfoTable.Sort + " asc");
        }
        #endregion

        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        public override void Init()
        {
            //逻辑对象赋值
            bll = TAKEIN00Bll.GetInstence();
            //表格对象赋值
            grid = Grid1;
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
           // Window1.IFrameUrl = "ProductionWarehousingEdit.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
          //  Window1.Hidden = false;
        }
        #endregion

        #region 编辑记录
        /// <summary>
        /// 编辑记录
        /// </summary>
        public override void Edit()
        {
            string id = GridViewHelper.GetSelectedKey(Grid1, true);

            //Window1.IFrameUrl = "ProductionWarehousingEdit.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id);
            //Window1.Hidden = false;
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

        protected void ButtonImport_Click(object sender, EventArgs e)
        {
            Window2.Hidden = false;
        }

        protected void btnCancel_Click(object sender,EventArgs e)
        {
            Window2.Hidden = true;
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {

            //判断
            FineUI.RadioButton RaddpUp_Date = Window2.FindControl("A").FindControl("RaddpUp_Date") as FineUI.RadioButton;
            FineUI.RadioButton RadEXPECT_DATE = Window2.FindControl("B").FindControl("RadEXPECT_DATE") as FineUI.RadioButton;

            if (RaddpUp_Date.Checked == false && RadEXPECT_DATE.Checked == false)
            {
                Alert.Show("请选择时间");
                return;

            }

            string Start_Time = "";
            string End_Time = "";
             
            //参数
            Random ran = new Random();
            string SHOP_ID = OnlineUsersBll.GetInstence().GetUserOnlineInfo("SHOP_ID").ToString();
            string COL_ID = SHOP_ID + "CL" + DateTime.Now.ToString("yyyy-MM-dd") + +ran.Next(1000, 9999);
            string manager_LoginName = OnlineUsersBll.GetInstence().GetUserOnlineInfo("Manager_LoginName").ToString();//登录名

            int IsTime = 1;
            if (RaddpUp_Date.Checked)
            {
                //获取时间
                DatePicker dpUp_DateBeg = Window2.FindControl("A").FindControl("dpUp_DateBeg") as DatePicker;
                DateTime dt_up_date_bg = ConvertHelper.StringToDatetime(dpUp_DateBeg.SelectedDate.ToString());

                DatePicker dpUp_DateEnd = Window2.FindControl("A").FindControl("dpUp_DateEnd") as DatePicker;
                DateTime dt_up_date_end = ConvertHelper.StringToDatetime(dpUp_DateEnd.SelectedDate.ToString());

                IsTime = 0;
                Start_Time = dt_up_date_bg.ToString();
                End_Time = dt_up_date_end.ToString();
            }

            if (RadEXPECT_DATE.Checked)
            {
                DatePicker dpEXPECT_DATEBeg = Window2.FindControl("B").FindControl("dpEXPECT_DATEBeg") as DatePicker;
                DateTime dt_expect_date_bg = ConvertHelper.StringToDatetime(dpEXPECT_DATEBeg.SelectedDate.ToString());

                DatePicker dpEXPECT_DATEEnd = Window2.FindControl("B").FindControl("dpEXPECT_DATEEnd") as DatePicker;
                DateTime dt_expect_date_end = ConvertHelper.StringToDatetime(dpEXPECT_DATEEnd.SelectedDate.ToString());

                IsTime = 1;
                Start_Time = dt_expect_date_bg.ToString();
                End_Time = dt_expect_date_end.ToString();
            }
 
            int ex_int = TAKEIN00Bll.GetInstence().LeadIntoProductPlanList(Start_Time,End_Time,IsTime.ToString(), SHOP_ID, manager_LoginName);
            
            if (ex_int == 0)
            {
                Alert.Show("引入成功！");

            }
            else
            {
                Alert.Show("引入失败！请重新引入！");
            }

            LoadData();

            

        }


    }
}