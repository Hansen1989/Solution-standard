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

namespace Solution.Web.Managers.WebManage.Systems.Powers
{
    public partial class PagePowerSignPublicEdit : PageBase
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";

                //绑定下拉列表
               // MenuInfoBll.GetInstence().BandDropDownListShowMenu(this, ddlParentId);

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
                var model = PagePowerSignPublicBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                //对页面窗体进行赋值
              //  txtId.Text = model.Id.ToString();
                txtCname.Text = model.Cname;
                txtEname.Text = model.Ename;
                
            }
        }

        #endregion

        //#region 页面控件绑定
        ///// <summary>下拉列表改变事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void ddlParentId_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //初始化路径值
        //    txtUrl.Text = string.Empty;
        //    //获取当前节点的父节点Id
        //    txtParent.Text = ddlParentId.SelectedValue;
        //    if (!ddlParentId.SelectedValue.Equals("0"))
        //    {
        //        try
        //        {
        //            //获取当前节点的父节点url
        //            txtUrl.Text = MenuInfoBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(ddlParentId.SelectedValue), MenuInfoTable.Url) + "";
        //        }
        //        catch
        //        {
        //        }
        //    }
        //}
        //#endregion

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

                if (string.IsNullOrEmpty(txtCname.Text.Trim()))
                {
                    return txtCname.Label + "不能为空！";
                }
                
                if (string.IsNullOrEmpty(txtEname.Text.Trim()))
                {
                    return txtEname.Label + "不能为空！";
                }
                
                #endregion

                #region 赋值
                //读取指定部门资料
                var model = new PagePowerSignPublic(x => x.Id == id);

                //设置名称
                model.Cname = txtCname.Text; ;
                //连接地址
                model.Ename = txtEname.Text; ;
                #endregion
                //----------------------------------------------------------
                //存储到数据库
                PagePowerSignPublicBll.GetInstence().Save(this, model);
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