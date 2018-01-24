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

namespace Solution.Web.Managers.WebManage.Systems.DataCenter
{
    public partial class ProdUnitListEdit : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";

                //绑定下拉列表
                //MenuInfoBll.GetInstence().BandDropDownListShowMenu(this, ddlParentId);

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
                var model = PROD_UNITBll.GetInstence().GetModelForCache(x => x.Id == id);
                //var model = new PROD_UNIT(x => x.Id == id);
                if (model == null)
                {
                    return;
                }
                UNIT_ID.Text = model.UNIT_ID;
                UNIT_ID.Readonly = true;
                UNIT_NAME.Text = model.UNIT_NAME;
                UNIT_MENO.Text = model.UNIT_MEMO;
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
                if (string.IsNullOrEmpty(UNIT_ID.Text.Trim()))
                {
                    return UNIT_ID.Label + "不能为空！";
                }

                if (string.IsNullOrEmpty(UNIT_NAME.Text.Trim()))
                {
                    return UNIT_NAME.Label + "不能为空！";
                }

                var sName = StringHelper.Left(UNIT_NAME.Text, 50);
                if (PROD_UNITBll.GetInstence().Exist(x => x.UNIT_NAME == sName) && id == 0)
                {
                    return UNIT_NAME.Label + "已存在！请重新输入！";
                }

                var sUNIT_ID = StringHelper.Left(UNIT_ID.Text, 50);
                if (PROD_UNITBll.GetInstence().Exist(x => x.UNIT_ID == sUNIT_ID) && id == 0)
                {
                    return UNIT_ID.Label + "已存在！请重新输入！";
                }

                var sMeno = StringHelper.Left(UNIT_MENO.Text, 40);
                if (UNIT_MENO.Text.Trim().Length > 40)
                {
                    return UNIT_MENO.Label + "超长！";
                }

                #endregion

                #region 赋值

                var model = new PROD_UNIT(x => x.Id == id);
                //var OlUser = new OnlineUsers(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                //var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                var OlUser = OnlineUsers.SingleOrDefault(x => x.UserHashKey == OnlineUsersBll.GetInstence().GetUserHashKey());
                //设置名称
                model.UNIT_ID = UNIT_ID.Text;
                model.UNIT_NAME = sName;
                model.UNIT_MEMO = sMeno;
                model.CRT_DATETIME = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                model.CRT_USER_ID = OlUser.Manager_LoginName;
                //model.CRT_USER_ID = "";
                model.MOD_DATETIME = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                model.MOD_USER_ID = OlUser.Manager_LoginName;
                //model.MOD_USER_ID = "";
                model.LAST_UPDATE = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                model.STATUS = 0;
                #endregion
                //----------------------------------------------------------
                //存储到数据库
                PROD_UNITBll.GetInstence().Save(this, model);
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