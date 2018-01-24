using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution.Web.Managers.WebManage.Application;
using DotNet.Utilities;
using Solution.Logic.Managers;
using Solution.DataAccess.DataModel;
using FineUI;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Collections;
using System.Text;

namespace Solution.Web.Managers.WebManage.Systems.SupplyCenter
{
   
    public partial class OrdersEdit : PageBase
    {
        private bool AppendToEnd = false;
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";

                //绑定下拉列表
               // BranchBll.GetInstence().BandDropDownList(this, ddlParentId);
 
                //加载数据
                LoadData();
 
            }
        }
        #endregion

        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        public override void Init()
        {

        }
        #endregion

        #region 加载数据
        /// <summary>读取数据</summary>
        public override void LoadData()
        {
            //绑定事件

         
            //关闭窗口
            ButtonCancel.OnClientClick = ActiveWindow.GetHideReference();


            string id = hidId.Text.Trim();
            if (id != "0")
            {
                
                //获取指定ID的菜单内容，如果不存在，则创建一个菜单实体
                var model = ORDER00Bll.GetInstence().GetModelForCache(x => x.ORDER_ID == id);
                if (model == null)
                    return;

                txtSHOP_ID.Text = model.SHOP_ID;

                txtORDER_ID.Text = model.ORD_DEP_ID;

                txtINPUT_DATE.Text = model.INPUT_DATE.ToString();
                txtORD_USER.Text = model.ORD_USER;
                ddlEXPECT_DATE.SelectedDate = model.EXPECT_DATE;

                ddlStatus.SelectedValue = model.STATUS.ToString();

                ddlORD_TYPE.SelectedValue = model.ORD_TYPE.ToString();

                ddlOUT_SHOP.Text = model.OUT_SHOP;
                txtEXPORTED_ID.Text = model.EXPORTED_ID.ToString();
                txtEXPORTED.Text = model.EXPORTED.ToString();
                txtAPP_USER.Text = model.APP_USER;
                txtAPP_DATE.Text = model.APP_DATE.ToString();
                txtMemo.Text = model.Memo;
                cbLOCKED.Checked = ConvertHelper.IsInt(model.LOCKED);

                ddlBranch.SelectedValue = model.ORD_DEP_ID;

                txtCRT_DATETIME.Text = model.CRT_DATETIME.ToString();
                txtCRT_USER_ID.Text = model.CRT_USER_ID.ToString();
                txtMOD_DATETIME.Text = model.MOD_DATETIME.ToString();
                txtMOD_USER_ID.Text = model.MOD_USER_ID.ToString();
                txtLAST_UPDATE.Text = model.LAST_UPDATE.ToString();
                txtTrans_STATUS.Text = model.Trans_STATUS.ToString();


            }
            else { //添加

                //表头
                SHOP00Bll.GetInstence().BandDropDownListShowShop(this, ddlShop,""); //分店名称

                txtINPUT_DATE.SelectedDate = DateTime.Now; //单据时间

                ddlStatus.SelectedValue = "1";//状态

                ddlEXPECT_DATE.SelectedDate = DateTime.Now.AddDays(1);

                int managerId = OnlineUsersBll.GetInstence().GetManagerId();//获取登录名
                txtManage.Text = OnlineUsersBll.GetInstence().GetManager_LoginName(this,managerId,true);
 
                //windows
                //Window2.Title = "添加";

            }

           // FineUI.DropDownList dddlPROD_NAME2 = Window2.FindControl("ddlPROD_NAME2") as FineUI.DropDownList;
 
 
        }

        #endregion

 
        #region 页面控件绑定
        /// <summary>下拉列表改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPROD_NAME2_SelectedIndexChanged(object sender, EventArgs e)
        {
             
           // FineUI.TextBox ddlw2 = (FineUI.TextBox)Window2.FindControl("txtPROD_ID");
          //  ddlw2.Text = "成功";

            


        }
        #endregion

        #region 页面控件绑定  分店
        /// <summary>下拉列表改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlShop_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (!ddlShop.SelectedValue.Equals("0"))
            {
                try
                {
                    txtSHOP_ID.Text = ddlShop.SelectedValue;

                    Random ran=new Random();
                    txtORDER_ID.Text = txtSHOP_ID.Text + "OR" + DateTime.Now.ToString("YYYY-MM-DD") + ran.Next(1000, 9999);

                    //获取当前节点的父节点url
                  //  txtUrl.Text = MenuInfoBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(ddlParentId.SelectedValue), MenuInfoTable.Url) + "";
                }
                catch
                {
                }
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
            int id = ConvertHelper.Cint0(hidId.Text);

            try
            {
                #region 数据验证

                //if (string.IsNullOrEmpty(txtAREA_NAME.Text.Trim()))
                //{
                //    return txtAREA_NAME.Label + "不能为空！";
                //}
                //var sName = StringHelper.Left(txtName.Text, 50);
                //if (BranchBll.GetInstence().Exist(x => x.Name == sName && x.Id != id))
                //{
                //    return txtName.Label + "已存在！请重新输入！";
                //}
                //if (string.IsNullOrEmpty(txtId.Text.Trim()))
                //{
                //    return txtId.Label + "不能为空！";
                //}
                //var sUrl = StringHelper.Left(txtUrl.Text, 400);
                //if (BranchBll.GetInstence().Exist(x => x.Url == sUrl && x.Id != id))
                //{
                //    return txtUrl.Label + "已存在！请重新输入！";
                //}

                #endregion

                #region 赋值
                //读取资料
                var model = new ORDER00(x => x.Id == id);

                model.SHOP_ID = txtSHOP_ID.Text;
                model.ORDER_ID = txtORDER_ID.Text;
                model.INPUT_DATE = DateTime.Now;// ConvertHelper.StringToDatetime(txtINPUT_DATE.Text);
                model.ORD_USER = txtORD_USER.Text;
                model.EXPECT_DATE = DateTime.Now;// ConvertHelper.StringToDatetime(txtEXPECT_DATE.Text);
                model.STATUS = ConvertHelper.Cint0(ddlStatus.SelectedValue);
                model.ORD_TYPE = ConvertHelper.Cint0(ddlORD_TYPE.SelectedValue);
                model.OUT_SHOP = ddlOUT_SHOP.SelectedValue;
                model.EXPORTED_ID = txtEXPORTED_ID.Text;
                model.EXPORTED = ConvertHelper.StringToByte(txtEXPORTED.Text);
                model.APP_USER = txtAPP_USER.Text;
                model.APP_DATE = DateTime.Now;//ConvertHelper.StringToDatetime(txtAPP_DATE.Text);
                model.Memo = txtMemo.Text;
                model.LOCKED = ConvertHelper.StringToByte(cbLOCKED.Checked.ToString());

                model.ORD_DEP_ID = ddlBranch.SelectedValue;
                model.CRT_DATETIME = DateTime.Now;//ConvertHelper.StringToDatetime(txtCRT_DATETIME.Text);
                model.CRT_USER_ID = txtCRT_USER_ID.Text;
                model.MOD_DATETIME = DateTime.Now;//ConvertHelper.StringToDatetime(txtMOD_DATETIME.Text);
                model.MOD_USER_ID = txtMOD_USER_ID.Text;
                model.LAST_UPDATE = DateTime.Now;//ConvertHelper.StringToDatetime(txtLAST_UPDATE.Text);
                model.Trans_STATUS = ConvertHelper.StringToByte(txtTrans_STATUS.Text);

 
                #endregion

                //----------------------------------------------------------
                //存储到数据库
                ORDER00Bll.GetInstence().Save(this, model);
            }
            catch (Exception e)
            {
                result = "保存失败！";

                //出现异常，保存出错日志信息
                CommonBll.WriteLog(result, e);
            }

            return result;
        }
        #endregion

        
        #region Events

        protected void Grid1_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
          //  System.Web.UI.WebControls.DropDownList ddlGender = (System.Web.UI.WebControls.DropDownList)Grid1.Rows[e.RowIndex].FindControl("ddlGender");
          //  System.Web.UI.WebControls.TextBox tbxGender = (System.Web.UI.WebControls.TextBox)Grid1.Rows[e.RowIndex].FindControl("tbxGender");
          //  System.Web.UI.WebControls.BoundField dd = (System.Web.UI.WebControls.BoundField)Grid1.Rows[e.RowIndex].FindControl("tbxGender");
 
        }

        protected void Grid1_PreRowDataBound(object sender, GridPreRowEventArgs e)
        {
            // 如果绑定到 DataTable，那么这里的 DataItem 就是 DataRowView
            DataRowView row = e.DataItem as DataRowView;
            int rowId = Convert.ToInt32(row["SNo"]);

          //  LinkButtonField editField = Grid1.FindColumn("Edit") as LinkButtonField;
           // editField.OnClientClick = String.Format("showEditWindow('{0}');", rowId);

            // 设置LinkButtonField的点击客户端事件
            //LinkButtonField deleteField2 = Grid1.FindColumn("Delete") as LinkButtonField;
            //deleteField2.OnClientClick = GetDeleteScript();

         
        }
 

        protected void btnAdd_Click(object sender, EventArgs e)
        {
             
        }

 

        protected void btnCancel_Click(object sender, EventArgs e)
        {
           // Window2.Hidden = true;
        }
 
        #endregion

       
    }
}