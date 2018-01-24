using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solution.Web.Managers.WebManage.Systems.SystemParameter
{

    public partial class ParameterEdit : PageBase
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";

                //绑定下拉列表
                GROUPAREABll.GetInstence().BandDropDownList(this, ddlAREA);
               
                 
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
                
                var model = SYS_PARAMATERSBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                ddlAREA.SelectedValue = model.AREA_ID + "";
                ddlCOL_ORDER_TYPE.SelectedValue = model.COL_ORDER_TYPE + "";
                ddlORDER_PRICE_TYPE.SelectedValue = model.ORDER_PRICE_TYPE + "";
                ddlQUANTITY_TYPE.SelectedValue = model.QUANTITY_TYPE + "";
                ddlEXPECT_DATE_TYPE.SelectedValue = model.EXPECT_DATE_TYPE + "";
                ddlPALN_TYPE.SelectedValue = model.PALN_TYPE + "";

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
                
                if (ddlAREA.SelectedValue.Trim() == "0")
                {
                    return ddlAREA.Label + "不能为空！";
                }

                #endregion

                #region 赋值
                //读取指定部门资料
                
                var model = new SYS_PARAMATERS(x => x.Id == id);

                model.AREA_ID = ddlAREA.SelectedValue + "";
                model.COL_ORDER_TYPE = ConvertHelper.Cint0(ddlCOL_ORDER_TYPE.SelectedValue.ToString());
                model.ORDER_PRICE_TYPE = ConvertHelper.Cint0(ddlORDER_PRICE_TYPE.SelectedValue);
                model.QUANTITY_TYPE = ConvertHelper.Cint0(ddlQUANTITY_TYPE.SelectedValue);
                model.EXPECT_DATE_TYPE = ConvertHelper.Cint0(ddlEXPECT_DATE_TYPE.SelectedValue);
                model.PRD_BOM_TYPE = ConvertHelper.Cint0(ddlPRD_BOM_TYPE.SelectedValue);
                model.PALN_TYPE = ConvertHelper.Cint0(ddlPALN_TYPE.SelectedValue);
                model.CRT_DATETIME = DateTime.Now;
                model.CRT_USER_ID = "";
                model.MOD_DATETIME = DateTime.Now;
                model.MOD_USER_ID = "";
                model.LAST_UPDATE = DateTime.Now;
                model.MEMO = "";
               
                #endregion

                //----------------------------------------------------------
                //存储到数据库
                SYS_PARAMATERSBll.GetInstence().Save(this, model);
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