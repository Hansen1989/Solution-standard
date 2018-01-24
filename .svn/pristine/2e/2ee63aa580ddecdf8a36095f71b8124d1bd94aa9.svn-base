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
using System.Linq.Expressions;

namespace Solution.Web.Managers.WebManage.Systems.DataCenter
{
   
    public partial class GroupAreaEdit : PageBase
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
                var model = GROUPAREABll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                txtAREA_ID.Text = model.AREA_ID.ToString();
                txtAREA_NAME.Text = model.AREA_NAME.ToString();
                txtAREA_ADD.Text = model.AREA_ADD.ToString();
                txtAREA_TEL.Text = model.AREA_TEL.ToString();
                txtAREA_EMAIL.Text = model.AREA_EMAIL.ToString();
                txtAREA_CONTECT.Text = model.AREA_CONTECT.ToString();
                txtAREA_MEMO.Text = model.AREA_MEMO.ToString();
                ddlAREA_STATUS.SelectedValue = model.AREA_STATUS.ToString() + "";
              
 
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

        /////
        /////取消
        //public override void Cancel()
        //{
            
        
        //}

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

                if (string.IsNullOrEmpty(txtAREA_NAME.Text.Trim()))
                {
                    return txtAREA_NAME.Label + "不能为空！";
                }

                if (string.IsNullOrEmpty(txtAREA_ID.Text.Trim()))
                {
                    return txtAREA_ID.Label + "不能为空！";
                }

                int area_id = ConvertHelper.Cint0(txtAREA_ID.Text.Trim());
                Expression<Func<DataAccess.Model.GROUPAREA, bool>> list = null;
                list = x => x.AREA_ID == area_id;

                if (GROUPAREABll.GetInstence().Exist(list))
                {
                    return txtAREA_ID.Label + "区域ID不能重复！";
                }

                //var sUrl = StringHelper.Left(txtUrl.Text, 400);
                //if (BranchBll.GetInstence().Exist(x => x.Url == sUrl && x.Id != id))
                //{
                //    return txtUrl.Label + "已存在！请重新输入！";
                //}

                #endregion

                int userId = OnlineUsersBll.GetInstence().GetManagerId();

                #region 赋值
                //读取资料
                var model = new GROUPAREA(x => x.Id == id);

                model.AREA_ID = ConvertHelper.Cint0(txtAREA_ID.Text);
                model.AREA_NAME = txtAREA_NAME.Text;
                model.AREA_ADD = txtAREA_ADD.Text;
                model.AREA_TEL = txtAREA_TEL.Text;
                model.AREA_EMAIL = txtAREA_EMAIL.Text;
                model.AREA_CONTECT = txtAREA_CONTECT.Text;
                model.AREA_MEMO = txtAREA_MEMO.Text;
                model.AREA_STATUS = ConvertHelper.StringToByte(ddlAREA_STATUS.SelectedValue);
                model.CRT_DATETIME = DateTime.Now.ToString();
                model.CRT_USER_ID = userId.ToString();
                model.MOD_DATETIME = DateTime.Now;
                model.MOD_USER_ID = userId.ToString();
                model.LAST_UPDATE = DateTime.Now;
                model.STATUS = 0;
                
                #endregion

                //----------------------------------------------------------
                //存储到数据库
                GROUPAREABll.GetInstence().Save(this, model);
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