using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution.Web.Managers.WebManage.Application;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
 

namespace Solution.Web.Managers.WebManage.Systems.DataCenter
{
    
     public partial class SHOP00Edit : PageBase
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";

                //绑定下拉列表
                GROUPAREABll.GetInstence().BandDropDownList(this, txtSHOP_Area_ID);

                SHOP_PRICE_AREABll.GetInstence().BandDropDownListShowArea(this, ddlSHOP_Price_Area);
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
            int id = ConvertHelper.Cint0(hidId.Text);

            if (id != 0)
            {
                //获取指定ID的菜单内容，如果不存在，则创建一个菜单实体
                var model = SHOP00Bll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;
                txtSHOP_ID.Text = model.SHOP_ID;
                txtSHOP_NAME1.Text = model.SHOP_NAME1;
                txtSHOP_NAME2.Text = model.SHOP_NAME2;
                txtSHOP_KIND.Text = model.SHOP_KIND.ToString();
                txtSHOP_Area_ID.SelectedValue = model.SHOP_Area_ID + "";
                ddlSHOP_Price_Area.SelectedValue = model.SHOP_Price_Area + "";
               
                txtSHOP_ADD.Text = model.SHOP_ADD;
                txtSHOP_TEL.Text = model.SHOP_TEL;
                txtSHOP_EMAIL.Text = model.SHOP_EMAIL;
                txtSHOP_CONTECT.Text = model.SHOP_CONTECT;
                txtSHOP_MEMO.Text = model.SHOP_MEMO;
                txtSHOP_STATUS.Text = model.SHOP_STATUS.ToString();
                txtSHOP_Limited.Text = model.SHOP_Limited.ToString();
                txtCRT_DATETIME.Text = model.CRT_DATETIME.ToString();
                txtCRT_USER_ID.Text = model.CRT_USER_ID.ToString();
                txtCRT_DATETIME.Text = model.CRT_DATETIME.ToString();
                txtMOD_USER_ID.Text = model.MOD_USER_ID.ToString();
                txtMOD_DATETIME.Text = model.MOD_DATETIME.ToString();
                txtLAST_UPDATE.Text = model.LAST_UPDATE.ToString();
                txtSTATUS.Text = model.STATUS.ToString();
 
            }else{
                txtSHOP_ID.Text = Guid.NewGuid().ToString().Replace("-","").Substring(0,10);
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

                if (string.IsNullOrEmpty(txtSHOP_NAME1.Text.Trim()))
                {
                    return txtSHOP_NAME1.Label + "不能为空！";
                }
                if (ddlSHOP_Price_Area.SelectedText.Trim() == "请选择价格区域")
                {
                    ddlSHOP_Price_Area.Label = "价格区域不能为空";
                }

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
                var model = new SHOP00(x => x.Id == id);

                model.SHOP_ID = txtSHOP_ID.Text;
                model.SHOP_NAME1 = txtSHOP_NAME1.Text;
                model.SHOP_NAME2 = txtSHOP_NAME2.Text;
                model.SHOP_KIND = ConvertHelper.Cint0(txtSHOP_KIND.Text.ToString());
                model.SHOP_Area_ID = ConvertHelper.Cint0(txtSHOP_Area_ID.SelectedValue.ToString());
                model.SHOP_Price_Area = ddlSHOP_Price_Area.SelectedValue.ToString();
                model.SHOP_ADD = txtSHOP_ADD.Text;
                model.SHOP_TEL = txtSHOP_TEL.Text;
                model.SHOP_EMAIL = txtSHOP_EMAIL.Text;
                model.SHOP_CONTECT = txtSHOP_CONTECT.Text;
                model.SHOP_MEMO = txtSHOP_MEMO.Text;
                model.SHOP_STATUS = ConvertHelper.StringToByte(txtSHOP_STATUS.Text);
                model.SHOP_Limited = ConvertHelper.Cint0(txtSHOP_Limited.Text);
                model.CRT_DATETIME = ConvertHelper.StringToDatetime(txtCRT_DATETIME.Text);
                model.CRT_USER_ID = txtCRT_USER_ID.Text;
                model.CRT_DATETIME = ConvertHelper.StringToDatetime(txtCRT_DATETIME.Text);
                model.MOD_USER_ID = txtMOD_USER_ID.Text;
                model.MOD_DATETIME = ConvertHelper.StringToDatetime(txtMOD_DATETIME.Text);
                model.LAST_UPDATE = ConvertHelper.StringToDatetime(txtLAST_UPDATE.Text);
                model.STATUS = ConvertHelper.StringToByte(txtSTATUS.Text);

 
                #endregion

                //----------------------------------------------------------
                //存储到数据库
                SHOP00Bll.GetInstence().Save(this, model);
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