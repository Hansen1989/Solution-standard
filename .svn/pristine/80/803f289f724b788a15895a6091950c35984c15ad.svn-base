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
    public partial class Product00Edit : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";

                //绑定下拉列表
                PROD_KINDBll.GetInstence().BandDropDownListShowKind(this, PROD_KIND);
                PROD_DEPBll.GetInstence().BandDropDownListShowDep(this, PROD_DEP);
                PROD_CateBll.GetInstence().BandDropDownListShowCate(this, PROD_CATE);
                //隶属部门
                BranchBll.GetInstence().BandDropDownListShowMenu(this, DIV_ID);
                //单位
                PROD_UNITBll.GetInstence().BandDropDownListShowUnit(this, PROD_UNIT);
                PROD_UNITBll.GetInstence().BandDropDownListShowUnit(this, PROD_UNIT1);
                PROD_UNITBll.GetInstence().BandDropDownListShowUnit(this, PROD_UNIT2);
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
                var model = PRODUCT00Bll.GetInstence().GetModelForCache(x => x.Id == id);
                //var model = new PROD_UNIT(x => x.Id == id);
                if (model == null)
                {
                    return;
                }
                PROD_ID.Text = model.PROD_ID;
                PROD_NAME1.Text = model.PROD_NAME1;
                PROD_NAME2.Text = model.PROD_NAME2;
                PROD_KIND.SelectedValue = model.PROD_KIND;
                PROD_DEP.SelectedValue = model.PROD_DEP;
                PROD_CATE.SelectedValue = model.PROD_CATE;
                DIV_ID.SelectedValue = model.DIV_ID;
                PROD_TYPE.SelectedValue =model.PROD_TYPE.ToString();
                PROD_Source.SelectedValue = model.PROD_Source.ToString();
                INV_TYPE.SelectedValue = model.INV_TYPE.ToString();
                STOCK_TYPE.SelectedValue = model.STOCK_TYPE.ToString();
                BOM_TYPE.SelectedValue = model.BOM_TYPE.ToString();
                MarginControl.SelectedValue = model.MarginControl.ToString();
                PROD_RangTYPE.SelectedValue = model.PROD_RangTYPE.ToString();
                PROD_iRang.Text = model.PROD_iRang.ToString();
                PROD_SPEC.Text = model.PROD_SPEC;
                PROD_Margin.Text = model.PROD_Margin;
                PROD_BARCODE.Text = model.PROD_BARCODE;
                PROD_UNIT.SelectedValue = model.PROD_UNIT.ToString();
                PROD_CONVERT1.Text = model.PROD_CONVERT1.ToString();
                PROD_UNIT1.SelectedValue = model.PROD_UNIT1.ToString();
                PROD_CONVERT2.Text = model.PROD_CONVERT2.ToString();
                PROD_UNIT2.SelectedValue = model.PROD_UNIT2.ToString();
                Report_UNIT.SelectedValue = model.Report_UNIT.ToString();
                PROD_MEMO.Text = model.PROD_MEMO.ToString();
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
                var sPROD_ID = PROD_ID.Text.Trim();
                if (string.IsNullOrEmpty(PROD_ID.Text.Trim()))
                {
                    PROD_ID.ShowRedStar = true;
                    return PROD_ID.Label + "不能为空！";
                }

                if (string.IsNullOrEmpty(PROD_NAME1.Text.Trim()))
                {
                    return PROD_NAME1.Label + "不能为空！";
                }

                var sPROD_KIND = PROD_KIND.SelectedValue;
                if (string.IsNullOrEmpty(sPROD_KIND) || sPROD_KIND == "0")
                {
                    return PROD_KIND.Label + "不能为空！";
                }

                var sPROD_DEP = PROD_DEP.SelectedValue;
                if (string.IsNullOrEmpty(sPROD_DEP) || sPROD_DEP == "0")
                {
                    return PROD_DEP.Label + "不能为空！";
                }

                var sPROD_TYPE = PROD_TYPE.SelectedValue;
                if (string.IsNullOrEmpty(sPROD_DEP))
                {
                    return PROD_TYPE.Label + "不能为空！";
                }

                var sPROD_Source = PROD_Source.SelectedValue;
                if (string.IsNullOrEmpty(sPROD_Source))
                {
                    return PROD_Source.Label + "不能为空！";
                }

                var sINV_TYPE = INV_TYPE.SelectedValue;
                if (string.IsNullOrEmpty(sINV_TYPE) || sINV_TYPE == "0")
                {
                    return INV_TYPE.Label + "不能为空！";
                }

                var sSTOCK_TYPE = STOCK_TYPE.SelectedValue;
                if (string.IsNullOrEmpty(sSTOCK_TYPE) || sSTOCK_TYPE == "0")
                {
                    return STOCK_TYPE.Label + "不能为空！";
                }

                var sBOM_TYPE = BOM_TYPE.SelectedValue;
                if (string.IsNullOrEmpty(sBOM_TYPE) || sBOM_TYPE == "0")
                {
                    return BOM_TYPE.Label + "不能为空！";
                }

                var sMarginControl = MarginControl.SelectedValue;
                if (string.IsNullOrEmpty(sMarginControl) || sMarginControl == "0")
                {
                    return MarginControl.Label + "不能为空！";
                }

                var sPROD_RangTYPE = PROD_RangTYPE.SelectedValue;
                if (string.IsNullOrEmpty(sPROD_RangTYPE) || sPROD_RangTYPE == "0")
                {
                    return PROD_RangTYPE.Label + "不能为空！";
                }

                var sPROD_iRang = PROD_iRang.Text;
                if (string.IsNullOrEmpty(sPROD_iRang))
                {
                    return PROD_iRang.Label + "不能为空！";
                }

                if (!ConvertHelper.IsInt(sPROD_iRang))
                {
                    return PROD_iRang.Label + "必须为整数123！";
                }

                var sPROD_UNIT = PROD_UNIT.SelectedValue;
                if (string.IsNullOrEmpty(sPROD_UNIT) || sPROD_UNIT=="0")
                {
                    return PROD_UNIT.Label + "不能为空！";
                }

                var sPROD_CONVERT1 = PROD_CONVERT1.Text;
                if (string.IsNullOrEmpty(sPROD_CONVERT1))
                {
                    return PROD_CONVERT1.Label + "不能为空！";
                }

                if (!ConvertHelper.IsInt(sPROD_CONVERT1))
                {
                    return PROD_CONVERT1.Label + "必须为整数！";
                }

                var sPROD_UNIT1 = PROD_UNIT1.SelectedValue;
                if (string.IsNullOrEmpty(sPROD_UNIT1) || sPROD_UNIT1=="0")
                {
                    return "包装单位不能为空！";
                }


                var sPROD_CONVERT2 = PROD_CONVERT2.Text;
                if (string.IsNullOrEmpty(sPROD_CONVERT2))
                {
                    return PROD_CONVERT2.Label + "不能为空！";
                }
                if (!ConvertHelper.IsInt(sPROD_CONVERT2))
                {
                    return PROD_CONVERT2.Label + "必须为整数！";
                }

                var sPROD_UNIT2 = PROD_UNIT2.SelectedValue;
                if (string.IsNullOrEmpty(sPROD_UNIT2) || sPROD_UNIT2 == "0")
                {
                    return "外箱单位不能为空！";
                }

                var sReport_UNIT = Report_UNIT.SelectedValue;
                if (string.IsNullOrEmpty(sReport_UNIT) || sReport_UNIT=="0")
                {
                    return Report_UNIT.Label + "不能为空！";
                }

                var sOrder_UNIT = Order_UNIT.SelectedValue;
                if (string.IsNullOrEmpty(sOrder_UNIT) || sOrder_UNIT == "0")
                {
                    return Order_UNIT.Label + "不能为空！";
                }

                var sOrder_Quan = Order_QUAN.Text;
                if (string.IsNullOrEmpty(sOrder_Quan) || sOrder_Quan == "0")
                {
                    return Order_QUAN.Label + "不能为空！";
                }
                if (!ConvertHelper.IsInt(sOrder_Quan))
                {
                    return Order_QUAN.Label + "必须为整数！";
                }

                var sPurchase_UNIT = Purchase_UNIT.SelectedValue;
                if (string.IsNullOrEmpty(sPurchase_UNIT) || sPurchase_UNIT=="0")
                {
                    return Purchase_UNIT.Label + "不能为空！";
                }

                var sPurchase_QUAN = Purchase_QUAN.Text;
                if (string.IsNullOrEmpty(sPurchase_QUAN))
                {
                    return Purchase_QUAN.Label + "不能为空！";
                }
                if (!ConvertHelper.IsInt(sPurchase_QUAN))
                {
                    return Purchase_QUAN.Label + "必须为整数！";
                }

                var sSAFE_QUAN = SAFE_QUAN.Text;
                if (string.IsNullOrEmpty(sSAFE_QUAN))
                {
                    return SAFE_QUAN.Label + "不能为空！";
                }
                if (!ConvertHelper.IsInt(sSAFE_QUAN))
                {
                    return SAFE_QUAN.Label + "必须为整数！";
                }


                sPROD_ID = StringHelper.Left(sPROD_ID, 50);
                if (PRODUCT00Bll.GetInstence().Exist(x => x.PROD_ID == sPROD_ID) && id == 0)
                {
                    return PROD_ID.Label + "已存在！请重新输入！";
                }

                //var sMeno = StringHelper.Left(UNIT_MENO.Text, 40);
                //if (UNIT_MENO.Text.Trim().Length > 40)
                //{
                //    return UNIT_MENO.Label + "超长！";
                //}

                #endregion

                #region 赋值

                var model = new PRODUCT00(x => x.Id == id);
                var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());

                model.PROD_ID = sPROD_ID;
                model.PROD_NAME1 = PROD_NAME1.Text;
                model.PROD_NAME2 = PROD_NAME2.Text;
                model.PROD_KIND = sPROD_KIND;
                model.PROD_DEP = sPROD_DEP;
                model.PROD_CATE = PROD_CATE.SelectedValue;
                model.DIV_ID = DIV_ID.SelectedValue;
                model.INV_TYPE = ConvertHelper.Cint(sINV_TYPE);
                model.STOCK_TYPE = ConvertHelper.Cint(sSTOCK_TYPE);
                model.BOM_TYPE = ConvertHelper.Cint(sBOM_TYPE);
                model.MarginControl = ConvertHelper.Cint(sMarginControl);
                model.PROD_RangTYPE = ConvertHelper.Cint(sPROD_RangTYPE);
                model.PROD_iRang = ConvertHelper.Cint(sPROD_iRang);
                model.PROD_SPEC = PROD_SPEC.Text;
                model.PROD_Margin = PROD_Margin.Text;
                model.PROD_BARCODE = PROD_BARCODE.Text;
                model.PROD_UNIT = sPROD_UNIT;
                model.PROD_UNIT1 = sPROD_UNIT1;
                model.PROD_CONVERT1 = ConvertHelper.Cint(sPROD_CONVERT1);
                model.PROD_UNIT2 = sPROD_UNIT2;
                model.PROD_CONVERT2 = ConvertHelper.Cint(sPROD_CONVERT2);
                model.Report_UNIT = ConvertHelper.Cint(sReport_UNIT);
                model.PROD_MEMO = PROD_MEMO.Text;


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
                PRODUCT00Bll.GetInstence().Save(this, model);
            }
            catch (Exception e)
            {
                result = "保存失败！";

                //出现异常，保存出错日志信息
                CommonBll.WriteLog(result, e);
            }

            return result;
        }

        #region 最小单位选择事件
        /// <summary>
        /// 最小单位选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PROD_UNIT_SHOW.Text = PROD_UNIT.SelectedText;
            PROD_UNIT_SHOW2.Text = PROD_UNIT.SelectedText;
        }
        #endregion
        #endregion
    }
}