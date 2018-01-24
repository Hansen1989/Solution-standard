using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution.Web.Managers.WebManage.Application;
using DotNet.Utilities;
using FineUI;
using Solution.Logic.Managers;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;
 
 

namespace Solution.Web.Managers.WebManage.Systems.SupplyCenter
{
     
    public partial class Order_ProductEdit : PageBase
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取ID值
                hidId.Text = RequestHelper.GetQueryString("ORDER_Id") + "";

                //部门
                int Branch_Id = ConvertHelper.Cint0(OnlineUsersBll.GetInstence().GetUserOnlineInfo("Branch_Id").ToString());

                //绑定下拉列表
                PRODUCT00Bll.GetInstence().BandDropDownListShowProductName1(this, ddlPROD_NAME1);

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
                //var model = Col_Order00Bll.GetInstence().GetModelForCache(x => x.Id == id);
                //if (model == null)
                //    return;

                // txtSHOP_ID.Text = model.SHOP_ID;
                // txtCOL_ID.Text = model.COL_ID;
                // txtINPUT_DATE.Text = model.INPUT_DATE.ToString();
                // txtORD_USER.Text = model.ORD_USER;
                // txtEXPECT_DATE.Text = model.EXPECT_DATE.ToString();
                // txtSTATUS.Text = model.STATUS.ToString();
                // txtPROD_TYPE.Text = model.PROD_TYPE.ToString();

                // txtORD_DEP_ID.Text = model.ORD_DEP_ID;
                // txtCOL_BeginDate.Text = model.COL_BeginDate.ToString();
                // txtCOL_EndDate.Text = model.COL_EndDate.ToString();
                // txtAPP_USER.Text = model.APP_USER;
                // txtAPP_DATE.Text = model.APP_DATE.ToString(); 
       
            }





        }

        #endregion

        #region 页面控件绑定
        /// <summary>下拉列表改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPROD_NAME1_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtPROD_ID.Text = ddlPROD_NAME1.SelectedValue;

            var model = new PRODUCT00(x => x.PROD_ID == ddlPROD_NAME1.SelectedValue);// 读取商品主表
            var model_0 = new PRODUCT01(x => x.PROD_ID == ddlPROD_NAME1.SelectedValue);//读商品子表


            txtPROD_SPEC.Text = model.PROD_SPEC;
            txtPROD_UNIT.Text = model.PROD_UNIT;
            txtU_Cost.Text = model_0.COST.ToString();
          //  txtOrder_QUAN.Text = model.Order_QUAN.ToString();
             

        }
        #endregion

        protected void txtON_QUAN_TextChanged(object sender, EventArgs e)
        {
            string ss = txtON_QUAN.Text.Trim();
            txtTotal.Text = (ConvertHelper.StringToDecimal(txtU_Cost.Text.Trim()) * ConvertHelper.Cint0(txtON_QUAN.Text.Trim())).ToString();


        }


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
            string order_id = hidId.Text;

            try
            {
                #region 数据验证

                if (ddlPROD_NAME1.Text.Trim() == "请选择商品名称")
                {
                    return ddlPROD_NAME1.Label + "请选择商品名称！";
                }
 
                if (string.IsNullOrEmpty(txtPROD_ID.Text.Trim()))
                {
                    return txtPROD_ID.Label + "不能为空！";
                }

                if (string.IsNullOrEmpty(txtPROD_UNIT.Text.Trim()))
                {
                    return txtPROD_UNIT.Label + "不能为空！";
                }

                if (string.IsNullOrEmpty(txtU_Cost.Text.Trim()))
                {
                    return txtU_Cost.Label + "不能为空！";
                }

                if (string.IsNullOrEmpty(txtOrder_QUAN.Text.Trim()))
                {
                    return txtOrder_QUAN.Label + "不能为空！";
                }

                #endregion

                #region 赋值

                int id = ConvertHelper.Cint0(RequestHelper.GetQueryString("Id")); 
                //读取资料
                var model_0 = new ORDER00(x => x.ORDER_ID == order_id);
 
                var model = new ORDER01(x => x.ORDER_ID == order_id && x.Id == id);
              
                model.SHOP_ID = model_0.SHOP_ID;//分店编号

                //序号
                conditionList = new List<ConditionFun.SqlqueryCondition>();
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, ORDER01Table.ORDER_ID, Comparison.Equals, order_id, false, false));
                model.SNo = ORDER01Bll.GetInstence().GetRecordCount(conditionList) + 1;

                model.PROD_ID = txtPROD_ID.Text.Trim();
                model.ORDER_ID = order_id;
                model.ON_QUAN = ConvertHelper.StringToDecimal(txtON_QUAN.Text.Trim());
                model.QUAN1 = 0;
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