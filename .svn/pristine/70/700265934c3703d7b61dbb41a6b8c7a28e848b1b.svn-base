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
using FineUI;

namespace Solution.Web.Managers.WebManage.Systems.ProductionCenter
{
   
   public partial class ProductionWarehousingEdit : PageBase
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
                var model = TAKEIN00Bll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                    txtSHOP_ID.Text = model.SHOP_ID; //分店编号 
                    txtTAKEIN_ID.Text = model.TAKEIN_ID; //计划单号 
                    txtSTATUS.Text = model.STATUS.ToString(); //单据状态 
                    txtINPUT_DATE.Text = model.INPUT_DATE.ToString(); //单据日期 
                    txtSTOCK_ID.Text = model.STOCK_ID.ToString();
                    txtUSER_ID.Text = model.USER_ID;//制单人 
                    txtAPP_USER.Text = model.APP_USER;//审核人 
                    txtAPP_DATETIME.Text = model.APP_DATETIME.ToString();//审核时间 

                    txtRELATE_ID.Text = model.RELATE_ID;//关联单号 
                   
                    txtMemo.Text = model.Memo.ToString();//备注 

                   // txtLOCKED.Text = model.LOCKED.ToString();//月结锁定 
                    txtCRT_DATETIME.Text = model.CRT_DATETIME.ToString();//建档日期 
                    txtCRT_USER_ID.Text = model.CRT_USER_ID;//建档人员 
                    txtMOD_DATETIME.Text = model.MOD_USER_ID;//修改日期 
                    txtMOD_USER_ID.Text = model.MOD_DATETIME.ToString();//修改人员 
                    txtLAST_UPDATE.Text = model.LAST_UPDATE.ToString();//最后异动时间 
                    txtTrans_STATUS.Text = model.Trans_STATUS.ToString();//传输状态 

                 
 
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

                if (string.IsNullOrEmpty(txtSHOP_ID.Text.Trim()))
                {
                    return txtSHOP_ID.Label + "不能为空！";
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
                var model = new TAKEIN00(x => x.Id == id);

                model.SHOP_ID = txtSHOP_ID.Text; //分店编号 
                model.TAKEIN_ID = txtTAKEIN_ID.Text; //计划单号 
                model.STATUS = ConvertHelper.Cint0(txtSTATUS.Text.ToString()); //单据状态 
                model.INPUT_DATE = DateTime.Now;// ConvertHelper.StringToDatetime(txtINPUT_DATE.Text.ToString()); //单据日期 
                model.STOCK_ID = txtSTOCK_ID.Text.ToString();
                model.USER_ID = txtUSER_ID.Text;//制单人 
                model.APP_USER = txtAPP_USER.Text;//审核人 
                model.APP_DATETIME = DateTime.Now;//ConvertHelper.StringToDatetime(txtAPP_DATETIME.Text.ToString());//审核时间 

                model.RELATE_ID = txtRELATE_ID.Text;//关联单号 

                model.Memo = ConvertHelper.StringToByte(txtMemo.Text.ToString());//备注 

                // txtLOCKED.Text = model.LOCKED.ToString();//月结锁定 
                model.CRT_DATETIME = DateTime.Now;//ConvertHelper.StringToDatetime(txtCRT_DATETIME.Text.ToString());//建档日期 
                model.CRT_USER_ID = txtCRT_USER_ID.Text;//建档人员 
                model.MOD_USER_ID = txtMOD_USER_ID.Text;//修改日期 
                model.MOD_DATETIME = DateTime.Now;//ConvertHelper.StringToDatetime(txtMOD_DATETIME.Text.ToString());//修改人员 
                model.LAST_UPDATE = DateTime.Now;//ConvertHelper.StringToDatetime(txtLAST_UPDATE.Text.ToString());//最后异动时间 
                model.Trans_STATUS = ConvertHelper.StringToByte(txtTrans_STATUS.Text.ToString());//传输状态 
                
                #endregion

                //----------------------------------------------------------
                //存储到数据库
                TAKEIN00Bll.GetInstence().Save(this, model);
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