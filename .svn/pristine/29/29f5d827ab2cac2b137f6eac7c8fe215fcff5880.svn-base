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
    public partial class ProdDepEdit : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";

                //绑定下拉列表
                PROD_KINDBll.GetInstence().BandDropDownListShowKind(this, KIND_ID);

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
                var model = PROD_DEPBll.GetInstence().GetModelForCache(x => x.Id == id);
                //var model = new PROD_UNIT(x => x.Id == id);
                if (model == null)
                {
                    return;
                }
                DEP_ID.Text = model.DEP_ID;
                DEP_ID.Readonly = true;
                DEP_NAME.Text = model.DEP_NAME;
                DEP_MEMO.Text = model.DEP_MEMO;
                KIND_ID.SelectedValue = model.KIND_ID + "";
                ENABLE.SelectedValue = model.ENABLE + "";
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
                if (string.IsNullOrEmpty(DEP_NAME.Text.Trim()))
                {
                    return DEP_NAME.Label + "不能为空！";
                }

                if (string.IsNullOrEmpty(KIND_ID.SelectedValue) || KIND_ID.SelectedValue=="0")
                {
                    return KIND_ID.Label + "不能为空！";
                }

                var sDEP_id = StringHelper.Left(DEP_ID.Text, 50);
                if (PROD_DEPBll.GetInstence().Exist(x => x.DEP_ID == sDEP_id) && id == 0)
                {
                    return KIND_ID.Label + "已存在！请重新输入！";
                }

                //var sMeno = StringHelper.Left(UNIT_MENO.Text, 40);
                //if (UNIT_MENO.Text.Trim().Length > 40)
                //{
                //    return UNIT_MENO.Label + "超长！";
                //}

                #endregion

                #region 赋值

                var model = new PROD_DEP(x => x.Id == id);
                //var OlUser = new OnlineUsers(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                //var OlUser = OnlineUsers.SingleOrDefault(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                model.DEP_ID = DEP_ID.Text;
                model.DEP_NAME = DEP_NAME.Text;
                model.DEP_MEMO = DEP_MEMO.Text;
                model.ENABLE = ConvertHelper.StringToByte(ENABLE.SelectedValue);
                model.KIND_ID = KIND_ID.SelectedValue;
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
                model.STATUS = 0;
                #endregion
                ////----------------------------------------------------------
                ////存储到数据库
                PROD_DEPBll.GetInstence().Save(this, model);
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