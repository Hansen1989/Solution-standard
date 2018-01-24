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
    public partial class Product01Edit : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";
                hidPROD_ID.Text = RequestHelper.GetQueryString("PROD_ID");

                //绑定下拉列表
                SHOP_PRICE_AREABll.GetInstence().BandDropDownListShowArea(this, PRCAREA_ID);

                SUPPLIERSBll.GetInstence().BandDropDownListShowSup(this,SUP_ID);

                //加载数据
                LoadData();
                if (String.IsNullOrEmpty(hidPROD_ID.Text))
                { 
                    FineUI.Alert.ShowInParent("商品编码未传递，请返回商品资料界面，请重新选择商品，否则数据无法保存", FineUI.MessageBoxIcon.Information);
                }
            }
        }

        public override void LoadData()
        {
            //关闭窗口
            ButtonCancel.OnClientClick = ActiveWindow.GetHideReference();
            int id = ConvertHelper.Cint0(hidId.Text);
            string prod_id = hidPROD_ID.Text;
            if(!String.IsNullOrEmpty(prod_id))
            {
               var prod_model = PRODUCT00Bll.GetInstence().GetModelForCache(x => x.PROD_ID == prod_id);
               if (prod_model != null)
               {
                   PROD_NAME.Text = prod_model.PROD_NAME1;
               }
               else
               {
                   return;
               }
            }

            if (id != 0)
            {
                //获取指定ID的菜单内容，如果不存在，则创建一个菜单实体
                //缓存机制有点问题，改直接初始化数据
                var model = PRODUCT01Bll.GetInstence().GetModelForCache(x => x.Id == id);
                //var model = new PROD_UNIT(x => x.Id == id);
                if (model == null)
                {
                    return;
                }
                #region 控件数据加载
                PRCAREA_ID.SelectedValue = model.PRCAREA_ID;
                SUP_ID.SelectedValue = model.SUP_ID;
                SEND_TYPE.SelectedValue = model.SEND_TYPE+"";
                TAX_TYPE.SelectedValue = model.TAX_TYPE+"";
                Tax.Text = model.Tax.ToString();
                SUP_COST.Text = model.SUP_COST.ToString();
                SUP_COST1.Text = model.SUP_COST1.ToString();
                SUP_COST2.Text = model.SUP_COST2.ToString();
                SUP_Return.Text = model.SUP_Return.ToString();
                SUP_Return1.Text = model.SUP_Return1.ToString();
                SUP_Return2.Text = model.SUP_Return2.ToString();
                U_Cost.Text = model.U_Cost.ToString();
                U_Cost1.Text = model.U_Cost1.ToString();
                U_Cost2.Text = model.U_Cost2.ToString();
                U_Ret_COST.Text = model.U_Ret_COST.ToString();
                U_Ret_COST1.Text = model.U_Ret_COST1.ToString();
                U_Ret_COST2.Text = model.U_Ret_COST2.ToString();
                T_COST.Text = model.T_COST.ToString();
                T_COST1.Text = model.T_COST1.ToString();
                T_COST2.Text = model.T_COST2.ToString();
                T_Ret_COST.Text = model.T_Ret_COST.ToString();
                T_Ret_COST1.Text = model.T_Ret_COST1.ToString();
                T_Ret_COST2.Text = model.T_Ret_COST2.ToString();
                COST.Text = model.COST.ToString();
                COST1.Text = model.COST1.ToString();
                COST2.Text = model.COST2.ToString();
                COST.Text = model.COST.ToString();
                COST1.Text = model.COST1.ToString();
                COST2.Text = model.COST2.ToString();
                ENABLE.SelectedValue = model.ENABLE+"";
                VISIBLE.SelectedValue = model.VISIBLE + "";
                #endregion
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
            string prod_id = hidPROD_ID.Text;
            if (!String.IsNullOrEmpty(prod_id))
            {
                try
                {
                    #region 数据验证
                    var sPRCAREA_ID = PRCAREA_ID.SelectedValue;
                    if (string.IsNullOrEmpty(sPRCAREA_ID) || sPRCAREA_ID == "0")
                    {
                        return PRCAREA_ID.Label + "不能为空！";
                    }

                    var sSUP_ID = SUP_ID.SelectedValue;
                    if (string.IsNullOrEmpty(sSUP_ID) || sSUP_ID == "0")
                    {
                        return SUP_ID.Label + "不能为空！";
                    }

                    var sTAX_TYPE = TAX_TYPE.SelectedValue;
                    if (string.IsNullOrEmpty(sTAX_TYPE))
                    {
                        return TAX_TYPE.Label + "不能为空！";
                    }

                    var sSEND_TYPE = SEND_TYPE.SelectedValue;
                    if (string.IsNullOrEmpty(sSEND_TYPE) || sSEND_TYPE == "0")
                    {
                        return SEND_TYPE.Label + "不能为空！";
                    }

                    var sTax = Tax.Text;
                    if (string.IsNullOrEmpty(sTax))
                    {
                        return Tax.Label + "不能为空！";
                    }

                    if (!ConvertHelper.IsInt(sTax))
                    {
                        return Tax.Label + "必须为整数！";
                    }

                    var sSUP_COST = SUP_COST.Text;
                    if (string.IsNullOrEmpty(sSUP_COST))
                    {
                        return SUP_COST.Label + "不能为空！";
                    }

                    if (!ConvertHelper.IsInt(sSUP_COST))
                    {
                        return SUP_COST.Label + "必须为整数！";
                    }

                    var sSUP_COST1 = SUP_COST1.Text;
                    if (string.IsNullOrEmpty(sSUP_COST1))
                    {
                        return SUP_COST1.Label + "不能为空！";
                    }

                    if (!ConvertHelper.IsInt(sSUP_COST1))
                    {
                        return SUP_COST1.Label + "必须为整数！";
                    }

                    var sSUP_COST2 = SUP_COST2.Text;
                    if (string.IsNullOrEmpty(sSUP_COST2))
                    {
                        return SUP_COST2.Label + "不能为空！";
                    }

                    if (!ConvertHelper.IsInt(sSUP_COST2))
                    {
                        return SUP_COST2.Label + "必须为整数！";
                    }

                    var sSUP_Return = SUP_Return.Text;
                    if (string.IsNullOrEmpty(sSUP_Return))
                    {
                        return SUP_Return.Label + "不能为空！";
                    }

                    if (!ConvertHelper.IsInt(sSUP_Return))
                    {
                        return SUP_Return.Label + "必须为整数！";
                    }

                    var sSUP_Return1 = SUP_Return1.Text;
                    if (string.IsNullOrEmpty(sSUP_Return1))
                    {
                        return SUP_Return1.Label + "不能为空！";
                    }

                    if (!ConvertHelper.IsInt(sSUP_Return1))
                    {
                        return SUP_Return1.Label + "必须为整数！";
                    }

                    var sSUP_Return2 = SUP_Return2.Text;
                    if (string.IsNullOrEmpty(sSUP_Return2))
                    {
                        return SUP_Return2.Label + "不能为空！";
                    }

                    if (!ConvertHelper.IsInt(sSUP_Return2))
                    {
                        return SUP_Return2.Label + "必须为整数！";
                    }

                    var sU_Cost = U_Cost.Text;
                    if (string.IsNullOrEmpty(sU_Cost))
                    {
                        return U_Cost.Label + "不能为空！";
                    }

                    if (!ConvertHelper.IsInt(sU_Cost))
                    {
                        return U_Cost.Label + "必须为整数！";
                    }

                    var sU_Cost1 = U_Cost1.Text;
                    if (string.IsNullOrEmpty(sU_Cost1))
                    {
                        return U_Cost1.Label + "不能为空！";
                    }

                    if (!ConvertHelper.IsInt(sU_Cost1))
                    {
                        return U_Cost1.Label + "必须为整数！";
                    }

                    var sU_Cost2 = U_Cost2.Text;
                    if (string.IsNullOrEmpty(sU_Cost2))
                    {
                        return U_Cost2.Label + "不能为空！";
                    }

                    if (!ConvertHelper.IsInt(sU_Cost2))
                    {
                        return U_Cost2.Label + "必须为整数！";
                    }

                    var sU_Ret_COST = U_Ret_COST.Text;
                    if (string.IsNullOrEmpty(sU_Ret_COST))
                    {
                        return U_Ret_COST.Label + "不能为空！";
                    }

                    if (!ConvertHelper.IsInt(sU_Ret_COST))
                    {
                        return U_Ret_COST.Label + "必须为整数！";
                    }

                    var sU_Ret_COST1 = U_Ret_COST1.Text;
                    if (string.IsNullOrEmpty(sU_Ret_COST1))
                    {
                        return U_Ret_COST1.Label + "不能为空！";
                    }

                    if (!ConvertHelper.IsInt(sU_Ret_COST1))
                    {
                        return U_Ret_COST1.Label + "必须为整数！";
                    }

                    var sU_Ret_COST2 = U_Ret_COST2.Text;
                    if (string.IsNullOrEmpty(sU_Ret_COST2))
                    {
                        return U_Ret_COST2.Label + "不能为空！";
                    }
                    if (!ConvertHelper.IsInt(sU_Ret_COST2))
                    {
                        return U_Ret_COST2.Label + "必须为整数！";
                    }

                    var sT_COST = T_COST.Text;
                    if (string.IsNullOrEmpty(sT_COST))
                    {
                        return T_COST.Label + "不能为空！";
                    }
                    if (!ConvertHelper.IsInt(sT_COST))
                    {
                        return T_COST.Label + "必须为整数！";
                    }

                    var sT_COST1 = T_COST1.Text;
                    if (string.IsNullOrEmpty(sT_COST1))
                    {
                        return T_COST1.Label + "不能为空！";
                    }
                    if (!ConvertHelper.IsInt(sT_COST1))
                    {
                        return T_COST1.Label + "必须为整数！";
                    }

                    var sT_COST2 = T_COST2.Text;
                    if (string.IsNullOrEmpty(sT_COST2))
                    {
                        return T_COST2.Label + "不能为空！";
                    }
                    if (!ConvertHelper.IsInt(sT_COST2))
                    {
                        return T_COST2.Label + "必须为整数！";
                    }

                    var sT_Ret_COST = T_Ret_COST.Text;
                    if (string.IsNullOrEmpty(sT_Ret_COST))
                    {
                        return T_Ret_COST.Label + "不能为空！";
                    }
                    if (!ConvertHelper.IsInt(sT_Ret_COST))
                    {
                        return T_Ret_COST.Label + "必须为整数！";
                    }

                    var sT_Ret_COST1 = T_Ret_COST1.Text;
                    if (string.IsNullOrEmpty(sT_Ret_COST1))
                    {
                        return T_Ret_COST1.Label + "不能为空！";
                    }
                    if (!ConvertHelper.IsInt(sT_Ret_COST1))
                    {
                        return T_Ret_COST1.Label + "必须为整数！";
                    }

                    var sT_Ret_COST2 = T_Ret_COST2.Text;
                    if (string.IsNullOrEmpty(sT_Ret_COST2))
                    {
                        return T_Ret_COST2.Label + "不能为空！";
                    }
                    if (!ConvertHelper.IsInt(sT_Ret_COST2))
                    {
                        return T_Ret_COST2.Label + "必须为整数！";
                    }

                    var sCOST = COST.Text;
                    if (string.IsNullOrEmpty(sCOST))
                    {
                        return COST.Label + "不能为空！";
                    }
                    if (!ConvertHelper.IsInt(sCOST))
                    {
                        return COST.Label + "必须为整数123！";
                    }

                    var sCOST1 = COST1.Text;
                    if (string.IsNullOrEmpty(sCOST1))
                    {
                        return COST1.Label + "不能为空！";
                    }
                    if (!ConvertHelper.IsInt(sCOST1))
                    {
                        return COST1.Label + "必须为整数！";
                    }

                    var sCOST2 = COST2.Text;
                    if (string.IsNullOrEmpty(sCOST2))
                    {
                        return COST2.Label + "不能为空！";
                    }
                    if (!ConvertHelper.IsInt(sCOST2))
                    {
                        return COST2.Label + "必须为整数！";
                    }

                    var sENABLE = ENABLE.SelectedValue;
                    if (string.IsNullOrEmpty(sENABLE))
                    {
                        return ENABLE.Label + "不能为空！";
                    }

                    var sVISIBLE = VISIBLE.SelectedValue;
                    if (string.IsNullOrEmpty(sVISIBLE))
                    {
                        return VISIBLE.Label + "不能为空！";
                    }
                    #endregion

                    if (PRODUCT01Bll.GetInstence().Exist(x => x.PRCAREA_ID == sPRCAREA_ID && x.PROD_ID==prod_id) && id == 0)
                    {
                        return PRCAREA_ID.Label + "已存在！请重新输入！";
                    }

                    #region 赋值

                    var model = new PRODUCT01(x => x.Id == id);
                    var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());

                    model.PRCAREA_ID = sPRCAREA_ID;
                    model.PROD_ID = prod_id;
                    model.SUP_ID = sSUP_ID;
                    model.SEND_TYPE = ConvertHelper.StringToByte(sSEND_TYPE);
                    model.TAX_TYPE = ConvertHelper.StringToByte(sTAX_TYPE);
                    model.Tax = ConvertHelper.Cint0(sTax);
                    model.SUP_COST = ConvertHelper.Cint0(sSUP_COST);
                    model.SUP_COST1 = ConvertHelper.Cint0(sSUP_COST1);
                    model.SUP_COST2 = ConvertHelper.Cint0(sSUP_COST2);
                    model.SUP_Return = ConvertHelper.Cint0(sSUP_Return);
                    model.SUP_Return1 = ConvertHelper.Cint0(sSUP_Return1);
                    model.SUP_Return2 = ConvertHelper.Cint0(sSUP_Return2);

                    model.U_Cost = ConvertHelper.Cint0(sU_Cost);
                    model.U_Cost1 = ConvertHelper.Cint0(sU_Cost1);
                    model.U_Cost2 = ConvertHelper.Cint0(sU_Cost2);

                    model.U_Ret_COST = ConvertHelper.Cint0(sU_Ret_COST);
                    model.U_Ret_COST1 = ConvertHelper.Cint0(sU_Ret_COST1);
                    model.U_Ret_COST2 = ConvertHelper.Cint0(sU_Ret_COST2);

                    model.T_COST = ConvertHelper.Cint0(sT_COST);
                    model.T_COST1 = ConvertHelper.Cint0(sT_COST1);
                    model.T_COST2 = ConvertHelper.Cint0(sT_COST2);

                    model.T_Ret_COST = ConvertHelper.Cint0(sT_Ret_COST);
                    model.T_Ret_COST1 = ConvertHelper.Cint0(sT_Ret_COST1);
                    model.T_Ret_COST2 = ConvertHelper.Cint0(sT_Ret_COST2);

                    model.COST = ConvertHelper.Cint0(sCOST);
                    model.COST1 = ConvertHelper.Cint0(sCOST1);
                    model.COST2 = ConvertHelper.Cint0(sCOST2);

                    model.VISIBLE = ConvertHelper.StringToByte(VISIBLE.SelectedValue);
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
                    PRODUCT01Bll.GetInstence().Save(this, model);
                }
                catch (Exception e)
                {
                    result = "保存失败！";

                    //出现异常，保存出错日志信息
                    CommonBll.WriteLog(result, e);
                }
            }
            else
            {
                result = "保存失败，商品编码为空";
            }

            return result;
        }
        #endregion
    }
}