using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using System.Linq.Expressions;

namespace Solution.Logic.Managers
{
    public partial class SUPPLIERSBll:LogicBase
    {
        #region 绑定菜单下拉列表
        /// <summary>
        /// 绑定菜单下拉列表——显示所有的数据
        /// </summary>
        public void BandDropDownListShowSup(Page page, FineUI.DropDownList ddl)
        {

            //在内存中筛选记录
            var dt = DataTableHelper.GetFilterData(GetDataTable(), "1", "1", SUPPLIERSTable.Id, " asc");

            try
            {
                //显示值
                ddl.DataTextField = SUPPLIERSTable.SUP_NAME;
                //显示key
                ddl.DataValueField = SUPPLIERSTable.SUP_ID;
                //数据层次
                //绑定数据源
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.SelectedIndex = 0;

                ddl.Items.Insert(0, new FineUI.ListItem("", ""));
                ddl.SelectedValue = "";
            }
            catch (Exception e)
            {
                // 记录日志
                CommonBll.WriteLog("", e);
            }
        }
        #endregion

        /// <summary>
        /// 读取某个固定字段的值
        /// </summary>
        /// <param name="conditionColName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetModelSingleValue(string colunm,Expression<Func<SUPPLIERS, bool>> expression)
        {
            var model = new SUPPLIERS(expression);
            string result="";
            switch(colunm)
            {
                case "SUP_ID":result=model.SUP_ID;break;
                case "SUP_NAME":result=model.SUP_NAME;break;
                case "SUP_NICKNAME":result=model.SUP_NICKNAME;break;
                case "SUP_TYPE":result=model.SUP_TYPE.ToString();break;
                case "SUP_ADD":result=model.SUP_ADD;break;
                case "SUP_TEL;":result=model.SUP_TEL;break;
                case "SUP_Email":result=model.SUP_Email;break;
                case "SUP_ZIP":result=model.SUP_ZIP;break;
                case "SUP_Contact":result=model.SUP_Contact;break;
                case "SUP_Mobile":result=model.SUP_Mobile;break;
                case "SUP_BankName":result=model.SUP_BankName;break;
                case "Send_DAY":result=model.Send_DAY.ToString();break;
                default :result="";break;
            }
            return result;
        }

        #region 绑定菜单下拉列表
        /// <summary>
        /// 绑定菜单下拉列表——显示所有的数据
        /// </summary>
        public void BandDropDownListShowSUP(Page page, System.Web.UI.WebControls.DropDownList ddl)
        {

            //在内存中筛选记录
            var dt = DataTableHelper.GetFilterData(GetDataTable(), "1", "1", SUPPLIERSTable.Id, " asc");

            try
            {
                //显示值
                ddl.DataTextField = SUPPLIERSTable.SUP_NAME;
                //显示key
                ddl.DataValueField = SUPPLIERSTable.SUP_ID;
                //数据层次
                //绑定数据源
                ddl.DataSource = dt;
                ddl.DataBind();


                //ddl.SelectedIndex = 0;

                //ddl.Items.Insert(0, new FineUI.ListItem("请选择大类", ""));
                //ddl.SelectedValue = "";
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
