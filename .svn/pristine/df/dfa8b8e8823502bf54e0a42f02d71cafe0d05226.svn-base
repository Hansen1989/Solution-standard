using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using DotNet.Utilities;
using Solution.Logic.Managers;
using Solution.DataAccess.DbHelper;
using Solution.Web.Managers.WebManage.Application;
using Solution.DataAccess.DataModel;

namespace Solution.Web.Managers.WebManage.Systems.DataCenter
{
    public partial class SuppliersEdit : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";
                //加载数据
                LoadData();
            }
        }

        public override void LoadData()
        {
            //关闭窗口
            ButtonCancel.OnClientClick = ActiveWindow.GetHideReference();
            int id = ConvertHelper.Cint0(hidId.Text);

            if (id != 0)
            {
                //获取指定ID的菜单内容，如果不存在，则创建一个菜单实体
                //缓存机制有点问题，改直接初始化数据
                var model = SUPPLIERSBll.GetInstence().GetModelForCache(x => x.Id == id);
                //var model = new PROD_UNIT(x => x.Id == id);
                if (model == null)
                {
                    return;
                }
                SUP_ID.Text = model.SUP_ID;
                SUP_ID.Readonly = true;
                SUP_NAME.Text = model.SUP_NAME;
                SUP_NICKNAME.Text = model.SUP_NICKNAME;
                SUP_TYPE.SelectedValue = model.SUP_TYPE + "";
                SUP_ADD.Text = model.SUP_ADD;
                SUP_TEL.Text = model.SUP_TEL;
                SUP_Email.Text = model.SUP_Email;
                SUP_ZIP.Text = model.SUP_ZIP;
                SUP_Contact.Text = model.SUP_Contact;
                SUP_Mobile.Text = model.SUP_Mobile;
                SUP_CODE_ID.Text = model.SUP_CODE_ID;
                SUP_BankName.Text = model.SUP_BankName;
                SUP_BankID.Text = model.SUP_BankID;
                SUP_PASSWORD.Text = model.SUP_PASSWORD;
                Send_DAY.Text = model.Send_DAY.ToString();
            }
        }

        public override void Init()
        {
            //throw new NotImplementedException();
        }


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
                if (string.IsNullOrEmpty(SUP_ID.Text.Trim()))
                {
                    return SUP_ID.Label + "不能为空！";
                }

                if (string.IsNullOrEmpty(SUP_NAME.Text.Trim()))
                {
                    return SUP_NAME.Label + "不能为空！";
                }

                if (string.IsNullOrEmpty(SUP_NICKNAME.Text.Trim()))
                {
                    return SUP_NICKNAME.Label + "不能为空！";
                }

                if (string.IsNullOrEmpty(SUP_TYPE.SelectedValue) || SUP_TYPE.SelectedValue == "0")
                {
                    return SUP_TYPE.Label + "不能为空！";
                }

                var sSUP_ID = StringHelper.Left(SUP_ID.Text, 50);
                if (SUPPLIERSBll.GetInstence().Exist(x => x.SUP_ID == sSUP_ID) && id == 0)
                {
                    return SUP_ID.Label + "已存在！请重新输入！";
                }

                var sSUP_NAME = StringHelper.Left(SUP_NAME.Text, 50);
                if (SUPPLIERSBll.GetInstence().Exist(x => x.SUP_NAME == sSUP_NAME) && id == 0)
                {
                    return SUP_NAME.Label + "已存在！请重新输入！";
                }

                //var sMeno = StringHelper.Left(UNIT_MENO.Text, 40);
                //if (UNIT_MENO.Text.Trim().Length > 40)
                //{
                //    return UNIT_MENO.Label + "超长！";
                //}

                #endregion

                #region 赋值

                var model = new SUPPLIERS(x => x.Id == id);
                //var OlUser = new OnlineUsers(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == OnlineUsersBll.GetInstence().GetUserHashKey());
                //var OlUser = OnlineUsers.SingleOrDefault(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                model.SUP_ID = sSUP_ID;
                model.SUP_NAME = sSUP_NAME;
                model.SUP_NICKNAME = SUP_NICKNAME.Text;
                model.SUP_TYPE = ConvertHelper.Cint(SUP_TYPE.SelectedValue);
                model.SUP_ADD = SUP_ADD.Text;
                model.SUP_TEL = SUP_TEL.Text;
                model.SUP_Email = SUP_Email.Text;
                model.SUP_ZIP = SUP_ZIP.Text;
                model.SUP_Contact = SUP_Contact.Text;
                model.SUP_Mobile = SUP_Mobile.Text;
                model.SUP_CODE_ID = SUP_CODE_ID.Text;
                model.SUP_BankName = SUP_BankName.Text;
                model.SUP_BankID = SUP_BankID.Text;
                model.SUP_PASSWORD = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(SUP_PASSWORD.Text, "MD5");
                model.Send_DAY =ConvertHelper.Cint(Send_DAY.Text);
                if (id == 0)
                {
                    model.CRT_DATETIME = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    model.CRT_USER_ID = OlUser.Manager_LoginName;
                }
                else
                {
                    model.CRT_DATETIME = model.CRT_DATETIME;
                    model.CRT_USER_ID = model.CRT_USER_ID;
                }
                //model.CRT_USER_ID = "";
                model.MOD_DATETIME = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                model.MOD_USER_ID = OlUser.Manager_LoginName;
                //model.MOD_USER_ID = "";
                model.LAST_UPDATE = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                #endregion
                ////----------------------------------------------------------
                ////存储到数据库
                SUPPLIERSBll.GetInstence().Save(this, model);
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