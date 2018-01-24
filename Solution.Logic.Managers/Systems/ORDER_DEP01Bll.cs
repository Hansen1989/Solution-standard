using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using System.Data;

namespace Solution.Logic.Managers
{
    public partial class ORDER_DEP01Bll:LogicBase
    {
        #region 绑定菜单下拉列表
        /// <summary>
        /// 绑定菜单下拉列表——显示所有的数据
        /// </summary>
        public void BandGrid(Page page, FineUI.Grid Grid1,int ret,string orddep_id)
        {

            //在内存中筛选记录
            try
            {
                DataTable dt = (DataTable)SPs.Get_ORDER_DEP01_SHOP(ret,orddep_id).ExecuteDataTable();
                Grid1.DataSource = dt;
                Grid1.DataBind();
            }
            catch (Exception e)
            {
                // 记录日志
                CommonBll.WriteLog("", e);
            }
        }
        #endregion
    }
}
