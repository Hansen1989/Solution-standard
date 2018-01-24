using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using System.Data;

namespace Solution.Logic.Managers
{
    public partial class ORDER_DEP00Bll:LogicBase
    {
        public string DeleteOrderDep00(int id)
        {
            string result = "";
            try
            {
                DataTable dt = (DataTable)SPs.Delete_ORDER_DOP00_01_02(id).ExecuteDataTable();
            }
            catch (Exception err)
            {
                result = err.Message;
            }
            return result;
        }

        public void BandDropDownList(Page page, FineUI.DropDownList ddl,string shop_id)
        {
          
            //在内存中筛选记录
            var dt = (DataTable)SPs.GET_ORDER_DEP00_ORDER_DEP01_LIST(shop_id).ExecuteDataTable();

            try
            {
                //显示值
                ddl.DataTextField = ORDER_DEP00Table.ORDDEP_NAME; //SHOP00Table.SHOP_NAME1;
                //显示key
                ddl.DataValueField = ORDER_DEP00Table.ORDDEP_ID;
                //数据层次
                //绑定数据源
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.SelectedIndex = 0;

                 
            }
            catch (Exception e)
            {
                // 记录日志
                CommonBll.WriteLog("", e);
            }


        }


    }
}
