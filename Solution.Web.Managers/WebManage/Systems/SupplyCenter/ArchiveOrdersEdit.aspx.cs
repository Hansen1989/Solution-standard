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
 

namespace Solution.Web.Managers.WebManage.Systems.SupplyCenter
{
     
      public partial class ArchiveOrdersEdit : PageBase
    {

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
            //关闭窗口
            ButtonCancel.OnClientClick = ActiveWindow.GetHideReference();

            int id = ConvertHelper.Cint0(hidId.Text);

            if (id != 0)
            {
                //获取指定ID的菜单内容，如果不存在，则创建一个菜单实体
                var model = Col_Order00Bll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                 txtSHOP_ID.Text = model.SHOP_ID;
                 txtCOL_ID.Text = model.COL_ID;
                 txtINPUT_DATE.Text = model.INPUT_DATE.ToString();
                 txtORD_USER.Text = model.ORD_USER;
                 txtEXPECT_DATE.Text = model.EXPECT_DATE.ToString();
                 txtSTATUS.Text = model.STATUS.ToString();
                 txtPROD_TYPE.Text = model.PROD_TYPE.ToString();

                 txtORD_DEP_ID.Text = model.ORD_DEP_ID;
                 txtCOL_BeginDate.Text = model.COL_BeginDate.ToString();
                 txtCOL_EndDate.Text = model.COL_EndDate.ToString();
                 txtAPP_USER.Text = model.APP_USER;
                 txtAPP_DATE.Text = model.APP_DATE.ToString(); 
                 txtMemo.Text = model.Memo;
                 txtLOCKED.Text = model.LOCKED.ToString();
 
                 txtCRT_DATETIME.Text = model.CRT_DATETIME.ToString();
                 txtCRT_USER_ID.Text = model.CRT_USER_ID.ToString();
                 txtMOD_DATETIME.Text = model.MOD_DATETIME.ToString();
                 txtMOD_USER_ID.Text = model.MOD_USER_ID.ToString();
                 txtLAST_UPDATE.Text = model.LAST_UPDATE.ToString();
                 txtTrans_STATUS.Text = model.Trans_STATUS.ToString();

 
            }
        }

        #endregion

        #region 页面控件绑定
        /// <summary>下拉列表改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlParentId_SelectedIndexChanged(object sender, EventArgs e)
        {
           // //初始化路径值
           //// txtUrl.Text = string.Empty;
           // //获取当前节点的父节点Id
           // txtParent.Text = ddlParentId.SelectedValue;
           // if (!ddlParentId.SelectedValue.Equals("1"))
           // {
           //     try
           //     {
           //         //获取当前节点的父节点url
           //        // txtUrl.Text = BranchBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(ddlParentId.SelectedValue), MenuInfoTable.Url) + "";
           //         txtId.Text = BranchBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(ddlParentId.SelectedValue), BranchTable.Code) + "";
           //         txtParent.Text = BranchBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(ddlParentId.SelectedValue), BranchTable.ParentId) + "";
           //         txtSort.Text = BranchBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(ddlParentId.SelectedValue), BranchTable.Sort) + "";

           //     }
           //     catch
           //     {
           //     }
           // }
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
                var model = new Col_Order00(x => x.Id == id);

                model.SHOP_ID = txtSHOP_ID.Text;
                model.COL_ID = txtCOL_ID.Text;
                model.INPUT_DATE = DateTime.Now;// ConvertHelper.StringToDatetime(txtINPUT_DATE.Text);
                model.ORD_USER = txtORD_USER.Text;
                model.EXPECT_DATE = DateTime.Now;// ConvertHelper.StringToDatetime(txtEXPECT_DATE.Text);
                model.STATUS = ConvertHelper.Cint0(txtSTATUS.Text);
                model.PROD_TYPE =  ConvertHelper.Cint0(txtPROD_TYPE.Text);
                model.ORD_TYPE = ConvertHelper.Cint0(txtORD_TYPE.Text);
                model.ORD_DEP_ID = txtORD_DEP_ID.Text;
                model.COL_BeginDate = DateTime.Now;//ConvertHelper.StringToDatetime(txtCOL_BeginDate.Text);
                model.COL_EndDate = DateTime.Now;//ConvertHelper.StringToDatetime(txtCOL_EndDate.Text);

              
                model.APP_USER = txtAPP_USER.Text;
                model.APP_DATE = DateTime.Now;//ConvertHelper.StringToDatetime(txtAPP_DATE.Text);
                model.Memo = txtMemo.Text;
                model.LOCKED = ConvertHelper.StringToByte(txtLOCKED.Text);

               // model.ORD_DEP_ID = txtORD_DEP_ID.Text;
                model.CRT_DATETIME = DateTime.Now;//ConvertHelper.StringToDatetime(txtCRT_DATETIME.Text);
                model.CRT_USER_ID = txtCRT_USER_ID.Text;
                model.MOD_DATETIME = DateTime.Now;//ConvertHelper.StringToDatetime(txtMOD_DATETIME.Text);
                model.MOD_USER_ID = txtMOD_USER_ID.Text;
                model.LAST_UPDATE = DateTime.Now;//ConvertHelper.StringToDatetime(txtLAST_UPDATE.Text);
                model.Trans_STATUS = ConvertHelper.StringToByte(txtTrans_STATUS.Text);

 
                #endregion

                //----------------------------------------------------------
                //存储到数据库
                Col_Order00Bll.GetInstence().Save(this, model);
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
    }
}