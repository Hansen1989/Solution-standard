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
using System.Data;

namespace Solution.Web.Managers.WebManage.Systems.SupplyCenter
{
 
   public partial class OrdersList1 : PageBase
    {
         public bool IsEdit = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定下拉列表

                int Branch_Id = 2;
               // FineUI.DropDownList ddlPROD_NAME1 = Window2.FindControl("ddlPROD_NAME1") as FineUI.DropDownList;
                //绑定下拉列表
                //PRODUCT00Bll.GetInstence().BandDropDownListShowProductName1(this, ddlPROD_NAME1);
 
                LoadData();

                BindGrid2();


                InitProd();

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

            //grid1
            string shop_id = OnlineUsersBll.GetInstence().GetUserOnlineInfo("SHOP_ID").ToString() ;
            conditionList = new List<ConditionFun.SqlqueryCondition>();
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, ORDER00Table.SHOP_ID, Comparison.Equals, shop_id, false, false));
 
           // conditionList.Add(sh.ExcuSQLDataTable("sss"));
            bll.BindGrid(Grid1, 0, sortList);
            bll.BindGrid(Grid1, 0, 0, conditionList, sortList);
             
            //grid2
          //  Get_ORDER01_PRODUCT00_PRODUCT01_();
          

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
            sortList.Add(ORDER00Table.Id + " asc");
            //  sortList.Add(MenuInfoTable.Sort + " asc");
        }
        #endregion

        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        public override void Init()
        {
            //逻辑对象赋值
            bll = ORDER00Bll.GetInstence();
            //表格对象赋值
            grid = Grid1;
        }
        #endregion

        #region 列表属性绑定

        protected void Grid1_RowSelect(object sender, FineUI.GridRowSelectEventArgs e)
        {
            BindGrid2();

       
 
        }
        #endregion

        #region 列表属性绑定

        protected void Grid2_RowSelect(object sender, FineUI.GridRowSelectEventArgs e)
        {
            string sNos = GridViewHelper.GetSelectedKey(Grid2, true);

            Prod_Edit(sNos);

        }
        #endregion


 
        protected void BindGrid2()
        {


            DataSet ds = null;
            ds = ORDER00Bll.GetInstence().Get_ORDER01_PRODUCT00_PRODUCT01_("5","");

            Grid2.DataSource = ds;
            Grid2.DataBind();
        
        }

        protected void Grid2_RowClick(object sender, GridRowClickEventArgs e) 
        {
            SNo.Text = GridViewHelper.GetSelectedKey(Grid2, true);
        
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Window2.Hidden = true;
         }
        

        protected void btnAdd_Click(object sender, EventArgs e)
        {
              
            Save();
        }

         #region 页面控件绑定
        /// <summary>下拉列表改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPROD_NAME1_SelectedIndexChanged(object sender, EventArgs e)
        {

           // FineUI.DropDownList ddlPROD_NAME1 = Window2.FindControl("ddlPROD_NAME1") as FineUI.DropDownList;
           // string ttxtPROD_NAME1 = ddlPROD_NAME1.SelectedText;

           // FineUI.TextBox txtPROD_ID = Window2.FindControl("txtPROD_ID") as FineUI.TextBox;
          //  string ttxtPROD_ID = txtPROD_ID.Text;

            txtPROD_ID.Text = ddlPROD_NAME1.SelectedValue;
 
            var model = new PRODUCT00(x => x.PROD_ID == ddlPROD_NAME1.SelectedValue);// 读取商品主表
            var model_0 = new PRODUCT01(x => x.PROD_ID == ddlPROD_NAME1.SelectedValue);//读商品子表

           // FineUI.TextBox ttxtPROD_SPEC = Window2.FindControl("txtPROD_SPEC") as FineUI.TextBox;
            txtPROD_SPEC.Text = model.PROD_SPEC;

           // FineUI.TextBox ttxtPROD_UNIT = Window2.FindControl("txtPROD_UNIT") as FineUI.TextBox;
            txtPROD_UNIT.Text = model.PROD_UNIT;

          //  FineUI.TextBox ttxtU_Cost = Window2.FindControl("txtU_Cost") as FineUI.TextBox;
            txtU_Cost.Text = model_0.COST.ToString();

           // FineUI.TextBox ttxtOrder_QUAN = Window2.FindControl("txtOrder_QUAN") as FineUI.TextBox;
           // txtOrder_QUAN.Text = model.Order_QUAN.ToString();
             

        }
       #endregion

        protected void txtON_QUAN_TextChanged(object sender, EventArgs e)
        {
          //  FineUI.TextBox ttxtU_Cost = Window2.FindControl("txtU_Cost") as FineUI.TextBox;
           // FineUI.TextBox ttxtON_QUAN = Window2.FindControl("txtON_QUAN") as FineUI.TextBox;
          //  FineUI.TextBox ttxtTotal = Window2.FindControl("txtTotal") as FineUI.TextBox;
            
          //  string ss = ttxtU_Cost.Text.Trim();
            txtTotal.Text = (ConvertHelper.StringToDecimal(txtU_Cost.Text.Trim()) * ConvertHelper.Cint0(txtON_QUAN.Text.Trim())).ToString();


        }

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

            GridRow gr = Grid1.Rows[e.RowIndex];  // + 1
            string shop_id = ((System.Data.DataRowView)(gr.DataItem)).Row.Table.Rows[e.RowIndex][ORDER00Table.SHOP_ID].ToString();

            var model = new SHOP00(x => x.SHOP_ID == shop_id);
            if (model != null)
            {
               // ((System.Data.DataRowView)(gr.DataItem)).Row[e.RowIndex]

                var lbf = gr.FindControl("SHOP_Name1") as FineUI.Label;
                lbf.Text = model.SHOP_NAME1;
            }

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
 

        #region 添加新记录
        /// <summary>
        /// 添加新记录
        /// </summary>
        public override void Add()
        {
            Window1.Title = "添加";
            Window1.IFrameUrl = "OrdersEdit.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
       
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
            Window1.Title = "编辑";
            Window1.IFrameUrl = "OrdersEdit.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id);
            Window1.Hidden = false;
        }
        #endregion

        #region 添加新记录
        /// <summary>
        /// 添加新记录
        /// </summary>
        protected void btnAddProd_Click(object sender,EventArgs e)
        {
           // Window2.Title = "添加-商品信息";
            //string classId = Grid1.DataKeys[Grid1.SelectedRowIndex][0].ToString();
            //Window2.IFrameUrl = "Order_ProductEdit.aspx?ORDER_Id=" + classId + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(classId);
           
           // SNo.Text = GridViewHelper.GetSelectedKey(Grid2, true);
         //   Window2.Hidden = false;
            string order_id = hidId.Text;

            if (order_id == null || order_id == "" || order_id == "0")
            {
              //  MessageBox.Show(this, "请选定订单");
                Alert.Show("请选定订单");
                return;
                // return;
            }

            Save();

        }
        #endregion

        #region 编辑记录
        /// <summary>
        /// 编辑记录
        /// </summary>
        protected void btnEditProd_Click(object sender, EventArgs e)
        {
         //   string id = GridViewHelper.GetSelectedKey(Grid2, true);
          //  string classId = Grid1.DataKeys[Grid1.SelectedRowIndex][0].ToString();
          //  Window2.Title = "编辑-商品信息";
            SNo.Text = GridViewHelper.GetSelectedKey(Grid2, true);
           // Window2.IFrameUrl = "Order_ProductEdit.aspx?ORDER_Id=" + classId + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(classId) + "&Id=" + id;
           // Window2.Hidden = false;

          //  Window2.GetShowReference();

            if(SNo.Text.Trim() == "0"){
                Alert.Show("请选定一行!");
                return;
            }

            IsEdit = true;

            Save();

         //   Prod_Edit();

        }
        #endregion

        public void InitProd() {
            // model.SHOP_ID = model_0.SHOP_ID;//分店编号
            //FineUI.DropDownList ddlPROD_NAME1 = Window2.FindControl("ddlPROD_NAME1") as FineUI.DropDownList;

            //FineUI.TextBox ttxtPROD_ID = Window2.FindControl("txtPROD_ID") as FineUI.TextBox;
 
            //FineUI.TextBox ttxtPROD_SPEC = Window2.FindControl("txtPROD_SPEC") as FineUI.TextBox;
            //FineUI.TextBox ttxtON_QUAN = Window2.FindControl("txtON_QUAN") as FineUI.TextBox;

            //FineUI.TextBox ttxtPROD_UNIT = Window2.FindControl("txtPROD_UNIT") as FineUI.TextBox;

            //FineUI.TextBox ttxtU_Cost = Window2.FindControl("txtU_Cost") as FineUI.TextBox;
            //FineUI.TextBox ttxtTotal = Window2.FindControl("txtTotal") as FineUI.TextBox;
            //FineUI.TextBox ttxtOrder_QUAN = Window2.FindControl("txtOrder_QUAN") as FineUI.TextBox;
            //FineUI.TextBox ttxtMemo = Window2.FindControl("txtMemo") as FineUI.TextBox;



            ddlPROD_NAME1.SelectedValue = "0";
            txtPROD_ID.Text = "";
            txtPROD_SPEC.Text = "";
            txtON_QUAN.Text = "0";
            txtPROD_UNIT.Text = "";
            txtU_Cost.Text = "";
            txtTotal.Text = "";
            txtOrder_QUAN.Text = "";
            txtMemo.Text = "";

        
        }

        public void Prod_Edit(string SNos) 
        {

            string id = SNos + "";
            string order_id = hidId.Text;

            if (id != "0")
            {

                int id_ = ConvertHelper.Cint0(SNos);
                //读取资料
                var model_0 = new ORDER00(x => x.ORDER_ID == order_id);

                var model = new ORDER01(x => x.ORDER_ID == order_id && x.SNo == id_);

                // model.SHOP_ID = model_0.SHOP_ID;//分店编号
               // FineUI.DropDownList ddlPROD_NAME1 = Window2.FindControl("ddlPROD_NAME1") as FineUI.DropDownList;

               // FineUI.TextBox ttxtPROD_ID = Window2.FindControl("txtPROD_ID") as FineUI.TextBox;

                var model_ = new PRODUCT00(x => x.PROD_ID == model.PROD_ID);// 读取商品主表
                var model_0_ = new PRODUCT01(x => x.PROD_ID == model.PROD_ID);//读商品子表

              //  FineUI.TextBox ttxtPROD_SPEC = Window2.FindControl("txtPROD_SPEC") as FineUI.TextBox;
               // FineUI.TextBox ttxtON_QUAN = Window2.FindControl("txtON_QUAN") as FineUI.TextBox;

              //  FineUI.TextBox ttxtPROD_UNIT = Window2.FindControl("txtPROD_UNIT") as FineUI.TextBox;

              //  FineUI.TextBox ttxtU_Cost = Window2.FindControl("txtU_Cost") as FineUI.TextBox;
              //  FineUI.TextBox ttxtTotal = Window2.FindControl("txtTotal") as FineUI.TextBox;
              //  FineUI.TextBox ttxtOrder_QUAN = Window2.FindControl("txtOrder_QUAN") as FineUI.TextBox;
               // FineUI.TextBox ttxtMemo = Window2.FindControl("txtMemo") as FineUI.TextBox;


                ddlPROD_NAME1.SelectedValue = model.PROD_ID + "";
              //  ddlPROD_NAME1.SelectedItem.Text = model_.PROD_NAME1;

                txtPROD_SPEC.Text = model_.PROD_SPEC;
             //   txtOrder_QUAN.Text = model_.Order_QUAN.ToString();

                txtPROD_ID.Text = model.PROD_ID;

                txtON_QUAN.Text = ConvertHelper.Cint0(model.ON_QUAN.ToString()).ToString();
                txtTotal.Text = model.QUAN1.ToString();

                txtPROD_UNIT.Text = model.STD_UNIT;
                 
                txtU_Cost.Text = model.STD_PRICE.ToString();
                txtMemo.Text = model.Memo;



            }
         
        
        }



        protected void btnSearchProd_Click(object sender, EventArgs e)
        { 
        
        }

        protected void btnDeleteProd_Click(object sender, EventArgs e)
        {
            int SNo = ConvertHelper.Cint0(GridViewHelper.GetSelectedKey(Grid2, true));
            string order_id = hidId.Text;


        }

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

        #region 保存
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <returns></returns>
        public override string Save()
        {
            string result = string.Empty;
            string order_id = hidId.Text;

            try
            {
                #region 数据验证


              //  FineUI.DropDownList dddlPROD_NAME1 = Window2.FindControl("ddlPROD_NAME1") as FineUI.DropDownList;
                if (ddlPROD_NAME1.SelectedText == "请选择")
                {
                    return ddlPROD_NAME1.Label + "请选择！";
                }

              //  FineUI.TextBox ttxtPROD_ID = Window2.FindControl("txtPROD_ID") as FineUI.TextBox;
                if (string.IsNullOrEmpty(txtPROD_ID.Text.Trim()))
                {
                    return txtPROD_ID.Label + "不能为空！";
                }

               // FineUI.TextBox ttxtPROD_UNIT = Window2.FindControl("txtPROD_UNIT") as FineUI.TextBox;
                if (string.IsNullOrEmpty(txtPROD_UNIT.Text.Trim()))
                {
                    return txtPROD_UNIT.Label + "不能为空！";
                }

               // FineUI.TextBox ttxtTotal = Window2.FindControl("txtTotal") as FineUI.TextBox;
                if (string.IsNullOrEmpty(txtTotal.Text.Trim()))
                {
                    return txtTotal.Label + "不能为空！";
                }

               // FineUI.TextBox ttxtU_Cost = Window2.FindControl("txtU_Cost") as FineUI.TextBox;
                if (string.IsNullOrEmpty(txtU_Cost.Text.Trim()))
                {
                    return txtU_Cost.Label + "不能为空！";
                }

               // FineUI.TextBox ttxtOrder_QUAN = Window2.FindControl("txtOrder_QUAN") as FineUI.TextBox;
                if (string.IsNullOrEmpty(txtOrder_QUAN.Text.Trim()))
                {
                    return txtOrder_QUAN.Label + "不能为空！";
                }

              //  FineUI.TextBox ttxtON_QUAN = Window2.FindControl("txtON_QUAN") as FineUI.TextBox;
                if (string.IsNullOrEmpty(txtON_QUAN.Text.Trim()) || txtON_QUAN.Text == "0")
                {
                    return txtON_QUAN.Label + "不能为空或者0！";
                }

               
              //  FineUI.TextBox ttxtMemo = Window2.FindControl("txtMemo") as FineUI.TextBox;

                #endregion

                #region 赋值

                int id = ConvertHelper.Cint0(SNo.Text);
                //读取资料
                var model_0 = new ORDER00(x => x.ORDER_ID == order_id);

                //序号
                conditionList = new List<ConditionFun.SqlqueryCondition>();
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, ORDER01Table.ORDER_ID, Comparison.Equals, order_id, false, false));


                if (IsEdit)
                {
                    id = ConvertHelper.Cint0(GridViewHelper.GetSelectedKey(Grid2, true));
                }
                else {
                    id = ORDER01Bll.GetInstence().GetRecordCount(conditionList) + 1;
                }

                var model = new ORDER01(x => x.ORDER_ID == order_id && x.SNo == id);

                model.SHOP_ID = model_0.SHOP_ID;//分店编号
                model.SNo = id;
                

                model.PROD_ID = txtPROD_ID.Text.Trim();
                model.ORDER_ID = order_id;
                model.ON_QUAN = ConvertHelper.StringToDecimal(txtON_QUAN.Text.Trim());
                model.QUAN1 = ConvertHelper.StringToDecimal(txtTotal.Text);
                model.QUAN2 = 0;
                model.COST_PRICE = 0;
                model.STD_UNIT = txtPROD_UNIT.Text;
                model.STD_CONVERT = 0;

                model.QUANTITY = model.STD_QUAN * model.STD_CONVERT;

                model.STD_QUAN = ConvertHelper.StringToDecimal(txtON_QUAN.Text);
                model.STD_PRICE = ConvertHelper.StringToDecimal(txtU_Cost.Text);
                model.Memo = txtMemo.Text;

                model.CRT_DATETIME = DateTime.Now;
                model.CRT_USER_ID = OnlineUsersBll.GetInstence().GetManagerCName();
                model.MOD_DATETIME = DateTime.Now;
                model.MOD_USER_ID = OnlineUsersBll.GetInstence().GetManagerCName();


                #endregion

                //----------------------------------------------------------
                //存储到数据库
                ORDER01Bll.GetInstence().Save(this, model);

             //   Window2.Hidden = true;

                BindGrid2();
                MessageBox.Show(this, "保存成功!");

                //   PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());


            }
            catch (Exception e)
            {
                result = "保存失败！";

                //出现异常，保存出错日志信息
                //  CommonBll.WriteLog(result, e);
            }

            return result;
        }
        #endregion


    }
}