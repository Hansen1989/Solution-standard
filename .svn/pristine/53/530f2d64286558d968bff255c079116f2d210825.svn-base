using System;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using FineUI;

 
namespace Solution.Web.Managers.WebManage.Systems.Powers
{
    public partial class MenuInfoEdit : PageBase
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";

                //绑定下拉列表
                MenuInfoBll.GetInstence().BandDropDownListShowMenu(this, ddlParentId);

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
                var model = MenuInfoBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                //对页面窗体进行赋值
                txtName.Text = model.Name;
                //设置下拉列表选择项
                ddlParentId.SelectedValue = model.ParentId + "";
                //设置页面URL
                txtUrl.Text = model.Url;
                //设置父ID
                txtParent.Text = model.ParentId + "";
                //设置排序
                txtSort.Text = model.Sort + "";
                //设置页面类型——菜单还是页面
                rblIsMenu.SelectedValue = model.IsMenu + "";
                //设置是否显示
                rblIsDisplay.SelectedValue = model.IsDisplay + "";
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
            //初始化路径值
            txtUrl.Text = string.Empty;
            //获取当前节点的父节点Id
            txtParent.Text = ddlParentId.SelectedValue;
            if (!ddlParentId.SelectedValue.Equals("0"))
            {
                try
                {
                    //获取当前节点的父节点url
                    txtUrl.Text = MenuInfoBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(ddlParentId.SelectedValue), MenuInfoTable.Url) + "";
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

                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    return txtName.Label + "不能为空！";
                }
                var sName = StringHelper.Left(txtName.Text, 50);
                if (MenuInfoBll.GetInstence().Exist(x => x.Name == sName && x.Id != id))
                {
                    return txtName.Label + "已存在！请重新输入！";
                }
                if (string.IsNullOrEmpty(txtUrl.Text.Trim()))
                {
                    return txtUrl.Label + "不能为空！";
                }
                var sUrl = StringHelper.Left(txtUrl.Text, 400);
                if (MenuInfoBll.GetInstence().Exist(x => x.Url == sUrl && x.Id != id))
                {
                    return txtUrl.Label + "已存在！请重新输入！";
                }

                #endregion

                #region 赋值
                //读取指定部门资料
                var model = new MenuInfo(x => x.Id == id);

                //设置名称
                model.Name = sName;
                //连接地址
                model.Url = sUrl;
                //对应的父类id
                model.ParentId = ConvertHelper.Cint0(txtParent.Text);

                //设定当前的深度与设定当前的层数级
                if (model.ParentId == 0)
                {
                    //设定当前的层数级
                    model.Depth = 0;
                }
                else
                {
                    try
                    {
                        //设定当前的层数级
                        model.Depth = ConvertHelper.Cint0(MenuInfoBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(ddlParentId.SelectedValue), MenuInfoTable.Depth)) + 1;
                    }
                    catch
                    {
                        model.Depth = 0;
                    }
                }

                //设置排序
                if (txtSort.Text == "0")
                {
                    //model.Sort = ConvertHelper.Cint0(SPs.P_All_GetOrderId(MenuInfoTable.TableName, MenuInfoTable.ParentId, model.ParentId.ToString(), MenuInfoTable.Sort).ExecuteScalar()) + 1;
                }
                else
                {
                    model.Sort = ConvertHelper.Cint0(txtSort.Text);
                }
                //设定当前项属于菜单还是页面
                model.IsMenu = ConvertHelper.StringToByte(rblIsMenu.SelectedValue);
                //设定当前项是否显示
                model.IsDisplay = ConvertHelper.StringToByte(rblIsDisplay.SelectedValue);
                #endregion

                //----------------------------------------------------------
                //存储到数据库
                MenuInfoBll.GetInstence().Save(this, model);
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