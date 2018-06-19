using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solution.Web.Managers.WebManage.Systems.SettlementCenter
{
    public partial class Receivable : PageBase
    {
        /// <summary>
        /// 登录用户所属分店ID
        /// </summary>
        private string shopId = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 加载数据
        /// </summary>
        public override void LoadData()
        {

        }


        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        public override void Init()
        {
            //获取登录用户
            var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
            
            //获取用户所属shop
            shopId = OlUser.SHOP_ID;

            //绑定门店
            SHOP00Bll.GetInstence().BandDropDownListShowShop1(this, shopIdDropdown);

            
        }
        #endregion


        /// <summary>
        /// 更换分店事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void shopIdDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}