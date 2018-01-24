using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution.Web.Managers.WebManage.Application;
using Solution.Logic.Managers;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using FineUI;

namespace Solution.Web.Managers.WebManage.Systems.Powers
{
 
    public partial class EditPwd : PageBase
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取ID值
               // hidId.Text = RequestHelper.GetInt0("Id") + "";

                 
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
           // int id = ConvertHelper.Cint0(hidId.Text);

            try
            {
                #region 数据验证

                if (string.IsNullOrEmpty(txtPwd.Text.Trim()))
                {
                    return txtPwd.Label + "不能为空！";
                }

                if (string.IsNullOrEmpty(txtPwd1.Text.Trim()))
                {
                    return txtPwd1.Label + "不能为空！";
                }

                if (txtPwd.Text.Trim() != txtPwd1.Text.Trim())
                {
                    return txtPwd.Label + "两次输入密码不一致！";
                }

                #endregion

                #region 赋值
                int managerId = OnlineUsersBll.GetInstence().GetManagerId();

                var model = Manager.SingleOrDefault(x=>x.Id == managerId);
                model.LoginPass = Encrypt.Md5(Encrypt.Md5(txtPwd.Text.Trim()));

               
                #endregion

                //----------------------------------------------------------
                //存储到数据库
                ManagerBll.GetInstence().Save(this, model);

                Alert.Show("修改成功!");
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