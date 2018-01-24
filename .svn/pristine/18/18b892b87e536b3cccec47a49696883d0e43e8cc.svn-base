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
    public partial class ShopPriceAreaEdit : PageBase
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
                var model = SHOP_PRICE_AREABll.GetInstence().GetModelForCache(x => x.Id == id);
                //var model = new PROD_UNIT(x => x.Id == id);
                if (model == null)
                {
                    return;
                }
                PRCAREA_ID.Text = model.PRCAREA_ID;
                PRCAREA_ID.Readonly = true;
                PRCAREA_NAME.Text = model.PRCAREA_NAME;
                PRCAREA_MEMO.Text = model.PRCAREA_MEMO;
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

                if (string.IsNullOrEmpty(PRCAREA_ID.Text.Trim()))
                {
                    return PRCAREA_ID.Label + "不能为空！";
                }
                if (string.IsNullOrEmpty(PRCAREA_NAME.Text.Trim()))
                {
                    return PRCAREA_NAME.Label + "不能为空！";
                }
                var sPcarea_id = StringHelper.Left(PRCAREA_ID.Text, 50);
                if (SHOP_PRICE_AREABll.GetInstence().Exist(x => x.PRCAREA_ID == sPcarea_id) && id == 0)
                {
                    return PRCAREA_ID.Label + "已存在！请重新输入！";
                }

                var sPcarea_name = StringHelper.Left(PRCAREA_NAME.Text, 50);
                if (SHOP_PRICE_AREABll.GetInstence().Exist(x => x.PRCAREA_NAME == sPcarea_name) && id == 0)
                {
                    return PRCAREA_NAME.Label + "已存在！请重新输入！";
                }

                //byte sEnable = ConvertHelper.StringToByte(ENABLE.SelectedValue);
                //if (sEnable == 0)
                //{
                //    return ENABLE.Label + "必须选择一个！";
                //}

                #endregion

                #region 赋值

                var model = new SHOP_PRICE_AREA(x => x.Id == id);
                //var OlUser = new OnlineUsers(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == OnlineUsersBll.GetInstence().GetUserHashKey());
                //var OlUser = OnlineUsers.SingleOrDefault(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                model.PRCAREA_ID = PRCAREA_ID.Text;
                model.PRCAREA_NAME = PRCAREA_NAME.Text;
                model.PRCAREA_MEMO = PRCAREA_MEMO.Text;
                model.ENABLE = ConvertHelper.StringToByte(ENABLE.SelectedValue);
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
                SHOP_PRICE_AREABll.GetInstence().Save(this, model);
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