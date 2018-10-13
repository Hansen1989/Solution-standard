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

namespace Solution.Web.Managers.WebManage.Systems.ProductionCenter
{

    public partial class ProductionPlanList : PageBase
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


            conditionList = new List<ConditionFun.SqlqueryCondition>();
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "1", Comparison.Equals, "1", false, false));

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
            sortList.Add(PLAN00Table.Id + " asc");
            //  sortList.Add(MenuInfoTable.Sort + " asc");
        }
        #endregion

        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        public override void Init()
        {
            //逻辑对象赋值
            bll = PLAN00Bll.GetInstence();
            //表格对象赋值
            grid = Grid1;
        }
        #endregion

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            DatePicker dpUp_DateBeg = Window2.FindControl("A").FindControl("dpUp_DateBeg") as DatePicker;
            dpUp_DateBeg.SelectedDate = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
            DatePicker dpUp_DateEnd = Window2.FindControl("A").FindControl("dpUp_DateEnd") as DatePicker;
            dpUp_DateEnd.SelectedDate = ConvertHelper.StringToDatetime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));

            DatePicker dpEXPECT_DATEBeg = Window2.FindControl("B").FindControl("dpEXPECT_DATEBeg") as DatePicker;
            dpEXPECT_DATEBeg.SelectedDate = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
            DatePicker dpEXPECT_DATEEnd = Window2.FindControl("B").FindControl("dpEXPECT_DATEEnd") as DatePicker;
            dpEXPECT_DATEEnd.SelectedDate = ConvertHelper.StringToDatetime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));

            Window2.Title = "汇整订单";
            Window2.Hidden = false;
 
        }

        /// <summary>
        /// 反汇整
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonBackArchiveOrders_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 核准
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Approval()
        {
            string str = GridViewHelper.GetSelectedKey(Grid1, true);
            string[] col_id_shop_id = str.Split(',');
            string col_id = col_id_shop_id[0];
            string shop_id = col_id_shop_id[1];

            int ispp = ConvertHelper.Cint0(PPhidId.Text.Trim());
            string user_id = OnlineUsersBll.GetInstence().GetManagerId().ToString();

            int result = Col_Order00Bll.GetInstence().ADD_PLAN_PURCHASE(col_id, shop_id, user_id, ispp);

            if (result == 0)
            {
                Alert.Show("核准成功！");
            }
            else
            {
                Alert.Show("核准失败！请重新汇整");
            }

        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Window2.Hidden = true;
        }

        /// <summary>
        /// 汇整
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
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

            //获取时间
            DatePicker dpUp_DateBeg = Window2.FindControl("A").FindControl("dpUp_DateBeg") as DatePicker;
            DateTime dt_up_date_bg = ConvertHelper.StringToDatetime(dpUp_DateBeg.SelectedDate.ToString());

            DatePicker dpUp_DateEnd = Window2.FindControl("A").FindControl("dpUp_DateEnd") as DatePicker;
            DateTime dt_up_date_end = ConvertHelper.StringToDatetime(dpUp_DateEnd.SelectedDate.ToString());

            DatePicker dpEXPECT_DATEBeg = Window2.FindControl("B").FindControl("dpEXPECT_DATEBeg") as DatePicker;
            DateTime dt_expect_date_bg = ConvertHelper.StringToDatetime(dpEXPECT_DATEBeg.SelectedDate.ToString());

            DatePicker dpEXPECT_DATEEnd = Window2.FindControl("B").FindControl("dpEXPECT_DATEEnd") as DatePicker;
            DateTime dt_expect_date_end = ConvertHelper.StringToDatetime(dpEXPECT_DATEEnd.SelectedDate.ToString());

            //参数
            Random ran = new Random();
            string SHOP_ID = OnlineUsersBll.GetInstence().GetUserOnlineInfo("SHOP_ID").ToString(); ;
            string COL_ID = SHOP_ID + "CL" + DateTime.Now.ToString("yyyy-MM-dd") + +ran.Next(1000, 9999);
            string manager_LoginName = OnlineUsersBll.GetInstence().GetUserOnlineInfo("Manager_LoginName").ToString();//登录名

            conditionList = new List<ConditionFun.SqlqueryCondition>();

            int IsTime = 1;
            if (RaddpUp_Date.Checked)
            {
                IsTime = 0;
                Start_Time = dt_up_date_bg.ToString();
                End_Time = dt_up_date_end.ToString();

                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, PLAN00Table.INPUT_DATE,Comparison.BetweenAnd, Start_Time, false, false));
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, PLAN00Table.INPUT_DATE, Comparison.BetweenAnd, End_Time, false, false));
            }

            if (RadEXPECT_DATE.Checked)
            {
                IsTime = 1;
                Start_Time = dt_expect_date_bg.ToString();
                End_Time = dt_expect_date_end.ToString();

                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, PLAN00Table.EXPECT_DATE, Comparison.BetweenAnd, Start_Time, false, false));
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, PLAN00Table.EXPECT_DATE, Comparison.BetweenAnd, End_Time, false, false));
            }

            Window2.Hidden = true;

            bll.BindGrid(Grid1, 0, 0, conditionList, sortList);
             
        }

        protected void ButtonApproval_Click(object sender, EventArgs e)
        {
            string str = GridViewHelper.GetSelectedKey(Grid1, true);
            string[] col_id_shop_id = str.Split(',');
            string shop_id = col_id_shop_id[1];
            string col_id = col_id_shop_id[0];

            int ex_int = OUT00Bll.GetInstence().SplitOrders(col_id);

            if (ex_int == 1)
            {
                Alert.Show("核准失败，请重新核准！");
            }
            else
            {
                Alert.Show("核准成功！");
            }

        }



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
            string shop_id = ((System.Data.DataRowView)(row)).Row.Table.Rows[e.RowIndex][Col_Order00Table.SHOP_ID].ToString();

            var model = new SHOP00(x => x.SHOP_ID == shop_id);
            if (model != null)
            {
                // ((System.Data.DataRowView)(gr.DataItem)).Row[e.RowIndex]
                var tf = Grid1.FindColumn("SHOP_LIK") as FineUI.LinkButtonField;
                tf.Text = model.SHOP_NAME1;

            }

            string col_id = ((System.Data.DataRowView)(row)).Row.Table.Rows[e.RowIndex][Col_Order00Table.COL_ID].ToString();
            var model_ARCHIVEORDERS = new Col_Order00(x => x.COL_ID == col_id);
            var model_SHOP = new SHOP00(x => x.SHOP_ID == shop_id);
            string area_id = model_SHOP.SHOP_Area_ID.ToString();

            var model_SYS_PARAMATERS = new SYS_PARAMATERS(x => x.AREA_ID == area_id);
            string type = "";


            if (model_SYS_PARAMATERS != null)
            {
                var a_type = Grid1.FindColumn("ARCHIVEORDERS_TYPE") as FineUI.LinkButtonField;

                if (model_SYS_PARAMATERS.COL_ORDER_TYPE == 0) //产品类型汇整
                {
                    if (model_ARCHIVEORDERS.PROD_TYPE == 0) { type = "自产型"; }
                    if (model_ARCHIVEORDERS.PROD_TYPE == 1) { type = "供应型"; }
                    if (model_ARCHIVEORDERS.PROD_TYPE == 2) { type = "委托加工型"; }
                }

                if (model_SYS_PARAMATERS.COL_ORDER_TYPE == 1) //产品类型汇整
                {
                    if (model_ARCHIVEORDERS.PROD_TYPE == 1) { type = "普通订货"; }
                    if (model_ARCHIVEORDERS.PROD_TYPE == 2) { type = "客户订货"; }

                }

                a_type.Text = type;

                //1=存档 2=已核准 3=作废 4=已汇整 [缺省值=0]
                string status = ((System.Data.DataRowView)(row)).Row.Table.Rows[e.RowIndex][Col_Order00Table.STATUS].ToString();
                var astatus = Grid1.FindColumn("ARCHIVEORDERS_STATUS") as FineUI.LinkButtonField;
                if (status == "1")
                {
                    astatus.Text = "存档";
                }

                if (status == "2")
                {
                    astatus.Text = "已核准";
                }

                if (status == "3")
                {
                    astatus.Text = "作废";
                }

                if (status == "4")
                {
                    astatus.Text = "已汇整";
                }


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

        protected void Grid1_RowSelect(object sender, FineUI.GridRowSelectEventArgs e)
        {
            string str = GridViewHelper.GetSelectedKey(Grid1, true);
            string[] plan_id_shop_id = str.Split(',');
            string plan_id = plan_id_shop_id[1];
            string shop_id = plan_id_shop_id[0];

            DataTable dt_left = null;
            dt_left = PLAN00Bll.GetInstence().GET_PLAN_LEFT_LIST(plan_id);// Get_PLAN_Left_List(plan_id);

            Grid2.DataSource = dt_left;
            Grid2.DataBind();

            Grid2.SelectedRowIndex = 0;
            string prod_id = GridViewHelper.GetSelectedKey(Grid2, true);

            DataTable dt_right = null;
            dt_right = PLAN00Bll.GetInstence().GET_PLAN_RIGHT_LIST(plan_id);

            Grid3.DataSource = dt_right;
            Grid3.DataBind();

            

        }

        protected void Grid2_RowSelect(object sender, FineUI.GridRowSelectEventArgs e)
        {
            string str = GridViewHelper.GetSelectedKey(Grid1, true);
            string[] col_id_shop_id = str.Split(',');
            string shop_id = col_id_shop_id[1];
            string col_id = col_id_shop_id[0];

            string prod_id = GridViewHelper.GetSelectedKey(Grid2, true);

            DataTable dt_right = null;
            dt_right = Col_Order00Bll.GetInstence().GET_ARCHIVEORDERS_RIGHT_LIST(shop_id, prod_id, col_id);

            Grid3.DataSource = dt_right;
            Grid3.DataBind();
        }




        #region 添加新记录
        /// <summary>
        /// 添加新记录
        /// </summary>
        public override void Add()
        {
            Window1.IFrameUrl = "ArchiveOrdersEdit.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
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

            Window1.IFrameUrl = "ArchiveOrdersEdit.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id);
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
                if (SHOP00Bll.GetInstence().Exist(x => x.Id == id))
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