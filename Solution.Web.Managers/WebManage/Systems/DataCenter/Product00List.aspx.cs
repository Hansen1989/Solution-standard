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
using SubSonic.Query;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Reflection;


namespace Solution.Web.Managers.WebManage.Systems.DataCenter
{
    public partial class Product00List : PageBase
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                LoadList();
                //LoadData();

            }
            PROD_ID.Enabled = true;
        }
        #endregion


        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        public override void Init()
        {
            //逻辑对象赋值
            bll = PRODUCT00Bll.GetInstence();

            ////表格对象赋值
            grid = Grid1;
        }
        #endregion

        #region 加载数据
        /// <summary>读取数据</summary>
        public override void LoadData()
        {
            hidId.Text = "";
            //设置排序
            if (sortList == null)
            {
                Sort();
            }
            conditionList = null;
            //conditionList = new List<ConditionFun.SqlqueryCondition>();
            //绑定Grid表格
            bll.BindGrid(Grid1, 0, 0, InquiryCondition(), sortList);
            Grid1.SelectedRowIndexArray = new int[] { 0 };
            SingleClick();
            LoadData2(PROD_ID.Text);


        }

        /// <summary>
        /// 加载下拉列表
        /// </summary>
        public void LoadList()
        {
            PROD_KINDBll.GetInstence().BandDropDownListShowKind(this, cPROD_KIND);
            PROD_DEPBll.GetInstence().BandDropDownListShowDep(this, cPROD_DEP);
            PROD_CateBll.GetInstence().BandDropDownListShowCate(this, cPROD_CATE);
            //隶属部门
            BranchBll.GetInstence().BandDropDownListShowMenu(this, cDIV_ID);

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

            SUPPLIERSBll.GetInstence().BandDropDownListShowSup(this, ddlSUPID);
        }

        /// <summary>
        /// 生成简拼事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PROD_NAME1_Blur(object sender, EventArgs e)
        {
            string _sPROD_NAME = PROD_NAME1.Text;
            PROD_NAME1_SPELLING.Text = DotNet.Utilities.PinYin.GetCodstring(_sPROD_NAME);
        }

        #region Grid1检索条件
        /// <summary>
        /// 条件
        /// </summary>
        /// <returns></returns>
        private List<ConditionFun.SqlqueryCondition> InquiryCondition()
        {
            List<ConditionFun.SqlqueryCondition> conditionProdduct00List = new List<ConditionFun.SqlqueryCondition>();
            //conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "1", Comparison.Equals, "1", false, false));
            bool sFlag = true;

            var _PROD_ID = cPROD_ID.Text;
            if (!String.IsNullOrEmpty(cPROD_ID.Text))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_ID, Comparison.Like, "%" + _PROD_ID + "%", false, false));
                sFlag = false;
            }

            var _PROD_NAME = cPROD_NAME.Text;
            if (!String.IsNullOrEmpty(_PROD_NAME))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_NAME1, Comparison.Like, "%" + _PROD_NAME + "%", false, false));
                sFlag = false;
            }
            var _PROD_NAME_SPELLING = cPROD_NAME_SPELLING.Text;
            if (!String.IsNullOrEmpty(_PROD_NAME_SPELLING))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_NAME1_SPELLING, Comparison.Like, "%" + _PROD_NAME_SPELLING + "%", false, false));
                sFlag = false;
            }

            var _PROD_DEP = cPROD_DEP.SelectedValue;
            if (!String.IsNullOrEmpty(_PROD_NAME) && _PROD_DEP != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_DEP, Comparison.Equals, _PROD_DEP, false, false));
                sFlag = false;
            }

            var _PROD_CATE = cPROD_CATE.SelectedValue;
            if (!String.IsNullOrEmpty(_PROD_CATE) && _PROD_CATE != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_CATE, Comparison.Equals, _PROD_CATE, false, false));
                sFlag = false;
            }

            var _DIV_ID = cDIV_ID.SelectedValue;
            if (!String.IsNullOrEmpty(_DIV_ID) && _DIV_ID != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.DIV_ID, Comparison.Equals, _DIV_ID, false, false));
                sFlag = false;
            }

            var _PROD_KIND = cPROD_KIND.SelectedValue;
            if (!String.IsNullOrEmpty(_PROD_KIND) && _PROD_KIND != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_KIND, Comparison.Equals, _PROD_KIND, false, false));
                sFlag = false;
            }

            if (sFlag)
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag),"1", Comparison.Equals, "1", false, false));
            }

            return conditionProdduct00List;
        }

        /// <summary>
        /// 判断条件第一个是否添加where还是and
        /// </summary>
        /// <param name="sFlag"></param>
        /// <returns></returns>
        public ConstraintType WhereOrAnd(bool sFlag)
        {
            if (sFlag)
            {
                return ConstraintType.Where;
            }
            else
            {
                return ConstraintType.And;
            }
        }
        #endregion

        #region 排序
        /// <summary>
        /// 页面表格绑定排序
        /// </summary>
        public void Sort()
        {
            //设置排序
            sortList = new List<string>();
            sortList.Add(PRODUCT00Table.Id);
        }
        #endregion
        #endregion

        #region Grid1 事件和函数

        /// <summary>
        /// Grid1单击事件
        /// </summary>
        /// <param name="e"></param>
        public override void SingleClick(GridRowClickEventArgs e)
        {
            SingleClick();
            #region 注释
                //PROD_ID.Text = model.PROD_ID;
                //hidPROD_Id.Text = model.PROD_ID;
                //PROD_NAME1.Text = model.PROD_NAME1;
                //PROD_NAME2.Text = model.PROD_NAME2;
                //PROD_KIND.SelectedValue = model.PROD_KIND;
                //PROD_DEP.SelectedValue = model.PROD_DEP;
                //PROD_CATE.SelectedValue = model.PROD_CATE;
                //DIV_ID.SelectedValue = model.DIV_ID;
                //PROD_TYPE.SelectedValue = model.PROD_TYPE.ToString();
                //PROD_Source.SelectedValue = model.PROD_Source.ToString();
                //INV_TYPE.SelectedValue = model.INV_TYPE.ToString();
                //STOCK_TYPE.SelectedValue = model.STOCK_TYPE.ToString();
                //BOM_TYPE.SelectedValue = model.BOM_TYPE.ToString();
                //MarginControl.SelectedValue = model.MarginControl.ToString();
                //PROD_RangTYPE.SelectedValue = model.PROD_RangTYPE.ToString();
                //PROD_iRang.Text = model.PROD_iRang.ToString();
                //PROD_SPEC.Text = model.PROD_SPEC;
                //PROD_Margin.Text = model.PROD_Margin;
                //PROD_BARCODE.Text = model.PROD_BARCODE;
                //PROD_UNIT.SelectedValue = model.PROD_UNIT.ToString();
                //PROD_CONVERT1.Text = model.PROD_CONVERT1.ToString();
                //PROD_UNIT1.SelectedValue = model.PROD_UNIT1.ToString();
                //PROD_CONVERT2.Text = model.PROD_CONVERT2.ToString();
                //PROD_UNIT2.SelectedValue = model.PROD_UNIT2.ToString();
                //Report_UNIT.SelectedValue = model.Report_UNIT.ToString();
                //Order_UNIT.SelectedValue = model.Order_UNIT.ToString();
                //Order_QUAN.Text = model.Order_QUAN.ToString();
                //Purchase_UNIT.SelectedValue = model.Purchase_UNIT.ToString();
                //Purchase_QUAN.Text = model.Purchase_QUAN.ToString();
                //SAFE_QUAN.Text = model.SAFE_QUAN.ToString();
                //PROD_MEMO.Text = model.PROD_MEMO.ToString();
                #endregion
        }
        /// <summary>
        /// 单击事件
        /// </summary>
        public void SingleClick()
        { 
            string _id = GridViewHelper.GetSelectedKey(Grid1, true);
            
            int id = ConvertHelper.Cint0(_id);

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
                LoadProduct(model);
                LoadData2(model.PROD_ID);

            }
        }
        /// <summary>
        /// 页面控件加载
        /// </summary>
        /// <param name="model"></param>
        public void LoadProduct(DataAccess.Model.PRODUCT00 model)
        {
            hidPROD_Id.Text = model.PROD_ID;
            hidId.Text = model.Id.ToString();

            PROD_ID.Text = model.PROD_ID;
            PROD_NAME1.Text = model.PROD_NAME1;
            PROD_NAME1_SPELLING.Text = model.PROD_NAME1_SPELLING;
            PROD_NAME2.Text = model.PROD_NAME2;
            PROD_KIND.SelectedValue = model.PROD_KIND;
            PROD_DEP.SelectedValue = model.PROD_DEP;
            PROD_CATE.SelectedValue = model.PROD_CATE;
            DIV_ID.SelectedValue = model.DIV_ID;
            PROD_TYPE.SelectedValue = model.PROD_TYPE.ToString();
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
            CRT_USER_ID.Text = model.CRT_USER_ID;
            CRT_DATETIME.Text = model.CRT_DATETIME.ToString();
            MOD_USER_ID.Text = model.MOD_USER_ID;
            MOD_USER_DATE.Text = model.MOD_DATETIME.ToString();
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ButtonClear_Click(object sender, EventArgs e)
        {
            hidId.Text = "";
            hidPROD_Id.Text = "";
            LoadProduct(new DataAccess.Model.PRODUCT00());
            LoadData();
            Grid2.DataSource = null;
        }

        /// <summary>
        /// 商品编码编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PROD_ID_TextChanged(object sender, EventArgs e)
        {

            Grid2.DataSource = null;
            Grid2.DataBind();
            hidId.Text = "";
            hidPROD_Id.Text = "";
        }

        #region 添加新记录
        /// <summary>
        /// 添加新记录
        /// </summary>
        public override string Save()
        {
            string result = "0";
            string _id = GridViewHelper.GetSelectedKey(Grid1, true);


            int id = ConvertHelper.Cint0(_id);

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
                    return PROD_iRang.Label + "必须为整数";
                }

                var sPROD_UNIT = PROD_UNIT.SelectedValue;
                if (string.IsNullOrEmpty(sPROD_UNIT) || sPROD_UNIT == "0")
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
                if (string.IsNullOrEmpty(sPROD_UNIT1) || sPROD_UNIT1 == "0")
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
                if (string.IsNullOrEmpty(sReport_UNIT) || sReport_UNIT == "0")
                {
                    return Report_UNIT.Label + "不能为空！";
                }


                sPROD_ID = StringHelper.Left(sPROD_ID, 50);
                if (PRODUCT00Bll.GetInstence().Exist(x => x.PROD_ID == sPROD_ID))
                {
                    return PROD_ID.Label + "已存在！请重新输入！";
                }

                string sPROD_NAME1 = StringHelper.Left(PROD_NAME1.Text.Trim(), 50);
                if (PRODUCT00Bll.GetInstence().Exist(x => x.PROD_ID == sPROD_NAME1))
                {
                    return PROD_NAME1.Label + "已存在！请重新输入！";
                }

                #endregion

                #region 赋值



                var model = new PRODUCT00(x => x.Id == id);
                var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                if (model.PROD_ID == sPROD_ID)
                {
                    //model.SetIsNew(false);
                }
                else
                {
                    model.SetIsNew(true);
                }
                model.PROD_ID = sPROD_ID;
                model.PROD_NAME1 = PROD_NAME1.Text;
                model.PROD_NAME1_SPELLING = PROD_NAME1_SPELLING.Text;
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
                //model.SetIsNew(false);
                PRODUCT00Bll.GetInstence().Save(this, model);
                PRODUCT00Bll.GetInstence().Insert_PRODUCT01(sPROD_ID, model.CRT_USER_ID);
                result = "保存成功";
                LoadData2(sPROD_ID);
                LoadData();

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
        #region 更新记录
        public void  ButtonUpdate_Click(object sender, EventArgs e)
        {
            string result = Product00Update();
            FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        public string Product00Update()
        {
            string result = "0";
            string _id = GridViewHelper.GetSelectedKey(Grid1, true);


            int id = ConvertHelper.Cint0(_id);

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
                if (string.IsNullOrEmpty(sPROD_UNIT) || sPROD_UNIT == "0")
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
                if (string.IsNullOrEmpty(sPROD_UNIT1) || sPROD_UNIT1 == "0")
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
                if (string.IsNullOrEmpty(sReport_UNIT) || sReport_UNIT == "0")
                {
                    return Report_UNIT.Label + "不能为空！";
                }


                sPROD_ID = StringHelper.Left(sPROD_ID, 50);
                if (!PRODUCT00Bll.GetInstence().Exist(x => x.PROD_ID == sPROD_ID) && id != 0)
                {
                    return PROD_ID.Label + "不存在！请重新输入！";
                }
                string sPROD_NAME1 = PROD_NAME1.Text.Trim();
                if (PRODUCT00Bll.GetInstence().Exist(x => x.PROD_NAME1 == sPROD_NAME1 && x.PROD_ID!=sPROD_ID) && id != 0)
                {
                    return PROD_NAME1.Label + "与其他商品重复！请重新输入！";
                }

                #endregion

                #region 赋值



                var model = new PRODUCT00(x => x.PROD_ID == sPROD_ID);
                var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                //if (model.PROD_ID == sPROD_ID)
                //{
                //    model.SetIsNew(false);
                //}
                //else
                //{
                //    model.SetIsNew(true);
                //}
                model.PROD_ID = sPROD_ID;
                model.PROD_NAME1 = PROD_NAME1.Text;
                model.PROD_NAME1_SPELLING = PROD_NAME1_SPELLING.Text;
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
                model.SetIsNew(false);
                //PRODUCT00Bll.GetInstence().Save(this, model, null, false, true);
                result = result + "\r\n" + Product01Update();
                if (!String.IsNullOrEmpty(result))
                {
                    PRODUCT00Bll.GetInstence().Save(this, model);
                    PRODUCT00Bll.GetInstence().Insert_PRODUCT01(sPROD_ID, model.CRT_USER_ID);
                    result = "商品资料更新成功";
                    LoadData();
                    LoadData2(sPROD_ID);
                }

            }
            catch (Exception e)
            {
                result = "更新失败！";

                //出现异常，保存出错日志信息
                CommonBll.WriteLog(result, e);
            }
            return result;
        }
        #endregion



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

        #region Grid2 相关事件

        /// <summary>
        /// 数据加载
        /// </summary>
        /// <param name="_PROD_ID"></param>
        public void LoadData2(string _PROD_ID)
        {
            COMPONENT00Bll.GetInstence().BandDropDownListShowCOM(this, ddlBOM_ID, PROD_ID.Text);
            if (sortList == null)
            {
                Sort();
            }
            conditionList = null;
            //绑定Grid表格 这里要换成PROD_ID
            V_Product01_PRCAREABll.GetInstence().BindGrid(Grid2, 0, 0, InquiryCondition2(_PROD_ID), sortList);

            //int o = 0;
            //int _Id = ConvertHelper.Cint(Grid2.DataKeys[o][0].ToString());
            //GridRow row = Grid2.Rows[o];
            //System.Web.UI.WebControls.DropDownList a = (System.Web.UI.WebControls.DropDownList)row.FindControl("dddllllKIND_NAME");
            //a.SelectedValue = "3";
        }
        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private List<ConditionFun.SqlqueryCondition> InquiryCondition2(string id)
        {
            List<ConditionFun.SqlqueryCondition> conditionProdduct00List = new List<ConditionFun.SqlqueryCondition>();
            conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, PRODUCT01Table.PROD_ID, Comparison.Equals, id, false, false));
            return conditionProdduct00List;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        public string Product01Update()
        {
            //JArray upJson = Grid2.GetModifiedData();
            JArray upJson = Grid2.GetMergedData();
            string result="";
            //int i = aa.Count;
            for (int i = 0; i < upJson.Count; i++)
            {
                if (upJson[i]["status"].ToString() == "modified")
                {
                    string upData = upJson[i]["values"].ToString();
                    DataTable da = DotNet.Utilities.Json.JsonHelper.ToDataTable("[" + upData + "]");
                    string sMessage = Product01Update(da);
                    if (!String.IsNullOrEmpty(sMessage))
                    {
                        result = result + "\r\n" + Product01Update(da);
                    }
                }
            }
            return result;
        }
        public string Product01Update(DataTable da)
        {
            string sPROD_ID = PROD_ID.Text.ToString();
            string sPRCAREA_ID = "";
            try
            {
                if (da.Columns.Contains("PRCAREA_ID"))
                {
                    sPRCAREA_ID = da.Rows[0]["PRCAREA_ID"].ToString();
                }
                else
                {
                    return "价格区域编号" + da.Rows[0]["PRCAREA_ID"].ToString() + "更新失败";
                }
                var model = new PRODUCT01(x => x.PROD_ID == sPROD_ID && x.PRCAREA_ID == sPRCAREA_ID);
                if (model.Id > 0)
                {
                    if (model.PROD_ID != sPROD_ID || model.PRCAREA_ID != sPRCAREA_ID)
                    { 
                        return "价格区域编号" + da.Rows[0]["PRCAREA_ID"].ToString() + "更新失败";
                    }
                    var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                    if (da.Columns.Contains("SUP_ID"))
                    {
                        model.SUP_ID = da.Rows[0]["SUP_ID"].ToString();
                    }
                    if (da.Columns.Contains("SEND_TYPE"))
                    {
                        model.SEND_TYPE = ConvertHelper.StringToByte(da.Rows[0]["SEND_TYPE"].ToString());
                    }
                    if (da.Columns.Contains("TAX_TYPE"))
                    {
                        model.TAX_TYPE = ConvertHelper.StringToByte(da.Rows[0]["TAX_TYPE"].ToString());
                    }
                    if (da.Columns.Contains("Tax"))
                    {
                        model.Tax = ConvertHelper.Cint(da.Rows[0]["Tax"].ToString());
                    }
                    if (da.Columns.Contains("SUP_COST"))
                    {
                        model.SUP_COST = ConvertHelper.StringToDecimal(da.Rows[0]["SUP_COST"].ToString());
                    }
                    if (da.Columns.Contains("SUP_COST1"))
                    {
                        model.SUP_COST1 = ConvertHelper.StringToDecimal(da.Rows[0]["SUP_COST1"].ToString());
                    }
                    if (da.Columns.Contains("SUP_COST2"))
                    {
                        model.SUP_COST2 = ConvertHelper.StringToDecimal(da.Rows[0]["SUP_COST2"].ToString());
                    }
                    if (da.Columns.Contains("SUP_Return"))
                    {
                        model.SUP_Return = ConvertHelper.StringToDecimal(da.Rows[0]["SUP_Return"].ToString());
                    }
                    if (da.Columns.Contains("SUP_Return1"))
                    {
                        model.SUP_Return1 = ConvertHelper.StringToDecimal(da.Rows[0]["SUP_Return1"].ToString());
                    }
                    if (da.Columns.Contains("SUP_Return2"))
                    {
                        model.SUP_Return2 = ConvertHelper.StringToDecimal(da.Rows[0]["SUP_Return2"].ToString());
                    }

                    if (da.Columns.Contains("U_Cost"))
                    {
                        model.U_Cost = ConvertHelper.StringToDecimal(da.Rows[0]["U_Cost"].ToString());
                    }
                    if (da.Columns.Contains("U_Cost1"))
                    {
                        model.U_Cost1 = ConvertHelper.StringToDecimal(da.Rows[0]["U_Cost1"].ToString());
                    }
                    if (da.Columns.Contains("U_Cost2"))
                    {
                        model.U_Cost2 = ConvertHelper.StringToDecimal(da.Rows[0]["U_Cost2"].ToString());
                    }
                    if (da.Columns.Contains("U_Ret_COST"))
                    {
                        model.U_Ret_COST = ConvertHelper.StringToDecimal(da.Rows[0]["U_Ret_COST"].ToString());
                    }
                    if (da.Columns.Contains("U_Ret_COST1"))
                    {
                        model.U_Ret_COST1 = ConvertHelper.StringToDecimal(da.Rows[0]["U_Ret_COST1"].ToString());
                    }
                    if (da.Columns.Contains("U_Ret_COST2"))
                    {
                        model.U_Ret_COST2 = ConvertHelper.StringToDecimal(da.Rows[0]["U_Ret_COST2"].ToString());
                    }

                    if (da.Columns.Contains("T_COST"))
                    {
                        model.T_COST = ConvertHelper.StringToDecimal(da.Rows[0]["T_COST"].ToString());
                    }
                    if (da.Columns.Contains("T_COST1"))
                    {
                        model.T_COST1 = ConvertHelper.StringToDecimal(da.Rows[0]["T_COST1"].ToString());
                    }
                    if (da.Columns.Contains("T_COST2"))
                    {
                        model.T_COST2 = ConvertHelper.StringToDecimal(da.Rows[0]["T_COST2"].ToString());
                    }
                    if (da.Columns.Contains("T_Ret_COST"))
                    {
                        model.T_Ret_COST = ConvertHelper.StringToDecimal(da.Rows[0]["T_Ret_COST"].ToString());
                    }
                    if (da.Columns.Contains("T_Ret_COST1"))
                    {
                        model.T_Ret_COST1 = ConvertHelper.StringToDecimal(da.Rows[0]["T_Ret_COST1"].ToString());
                    }
                    if (da.Columns.Contains("T_Ret_COST2"))
                    {
                        model.T_Ret_COST2 = ConvertHelper.StringToDecimal(da.Rows[0]["T_Ret_COST2"].ToString());
                    }

                    if (da.Columns.Contains("COST"))
                    {
                        model.COST = ConvertHelper.StringToDecimal(da.Rows[0]["COST"].ToString());
                    }
                    if (da.Columns.Contains("COST1"))
                    {
                        model.COST1 = ConvertHelper.StringToDecimal(da.Rows[0]["COST1"].ToString());
                    }
                    if (da.Columns.Contains("COST2"))
                    {
                        model.COST2 = ConvertHelper.StringToDecimal(da.Rows[0]["COST2"].ToString());
                    }
                    if (da.Columns.Contains("ENABLE"))
                    {
                        if (da.Rows[0]["ENABLE"].ToString() == "True")
                        {
                            model.ENABLE = 1;
                        }
                        else
                        {
                            model.ENABLE = 0;
                        }

                    }
                    if (da.Columns.Contains("VISIBLE"))
                    {
                        if (da.Rows[0]["VISIBLE"].ToString() == "True")
                        {
                            model.VISIBLE = 1;
                        }
                        else
                        {
                            model.VISIBLE = 0;
                        }
                    }
                    if (da.Columns.Contains("BOM_ID"))
                    {
                        model.BOM_ID = da.Rows[0]["BOM_ID"].ToString();
                        //if (!String.IsNullOrEmpty(da.Rows[0]["BOM_ID"].ToString()))
                        //{
                        //    model.BOM_ID = da.Rows[0]["BOM_ID"].ToString();
                        //}
                        //else
                        //{
                        //    return "默认配方编码出错，更新失败";
                        //}
                    }

                    if (da.Columns.Contains("ORDER_UNIT"))
                    {
                        model.ORDER_UNIT = ConvertHelper.StringToByte(da.Rows[0]["ORDER_UNIT"].ToString());
                    }

                    if (da.Columns.Contains("ORDER_QUAN"))
                    {
                        model.ORDER_QUAN = ConvertHelper.StringToByte(da.Rows[0]["ORDER_QUAN"].ToString());
                    }

                    if (da.Columns.Contains("Purchase_UNIT"))
                    {
                        model.Purchase_UNIT = ConvertHelper.StringToByte(da.Rows[0]["Purchase_UNIT"].ToString());
                    }

                    if (da.Columns.Contains("Purchase_QUAN"))
                    {
                        model.Purchase_QUAN = ConvertHelper.StringToByte(da.Rows[0]["Purchase_QUAN"].ToString());
                    }

                    if (da.Columns.Contains("SAFE_QUAN"))
                    {
                        model.SAFE_QUAN = ConvertHelper.StringToByte(da.Rows[0]["SAFE_QUAN"].ToString());
                    }

                    if (da.Columns.Contains("PROD_PRICE"))
                    {
                        model.PROD_PRICE = ConvertHelper.StringToByte(da.Rows[0]["PROD_PRICE"].ToString());
                    }

                    model.MOD_DATETIME = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    model.MOD_USER_ID = OlUser.Manager_LoginName;
                    model.SetIsNew(false);
                    PRODUCT01Bll.GetInstence().Save(this, model);
                    return "";
                }
                else
                {
                    return "价格区域编号" + da.Rows[0]["rPRCAREA_ID"].ToString() + "更新失败";
                }
            }
            catch (Exception err)
            { 
               return "价格区域编号" + da.Rows[0]["rPRCAREA_ID"].ToString() + "更新失败!失败原因："+err.Message;
            }
        }

        #region 注释，当确定没用后，删除所有代码
        //public void Grid2_RowDoubleClick(object sender, GridRowClickEventArgs e)
        //{
        //    JArray arr = Grid2.GetMergedData();
        //    DataTable da2 = new DataTable();
        //    da2 = null;
        //    int selections = e.RowIndex;
        //    string[] sss = Grid2.SelectedCell;
        //    for (int i = 0; i < arr.Count; i++)
        //    {
        //        string upData = arr[i]["values"].ToString();
        //        //newadded
        //        string upStatus = arr[i]["status"].ToString();
        //        DataTable da = DotNet.Utilities.Json.JsonHelper.ToDataTable("[" + upData + "]");
        //        //da2.Merge(da);
        //        if (da2 == null)
        //        {
        //            da2 = da.Copy();
        //        }
        //        else
        //        {
        //            da2.ImportRow(da.Rows[0]);
        //        }

        //    }
        //    Grid2.DataSource = da2;
        //    Grid2.DataBind();

        //    int o = selections;
        //    //int _Id = ConvertHelper.Cint(Grid2.DataKeys[o][0].ToString());
        //    SetBomName(arr);
        //    GridRow row = Grid2.Rows[o];
        //    System.Web.UI.WebControls.TextBox asdf = (System.Web.UI.WebControls.TextBox)row.FindControl("tBOM_NAME123");
        //    asdf.Text = "更改了";
        //    asdf.Focus();

        //    //System.Web.UI.WebControls.DropDownList a = (System.Web.UI.WebControls.DropDownList)row.FindControl("dddllllKIND_NAME");
        //    //PROD_DEPBll.GetInstence().BandDropDownListShowDep(this, a);
        //}

        //public void SetBomName(JArray arr)
        //{
        //    DataTable da2 = new DataTable();
        //    for (int i = 0; i < arr.Count; i++)
        //    {
        //        string upData = arr[i]["values"].ToString();
        //        //newadded
        //        string upStatus = arr[i]["status"].ToString();
        //        DataTable da = DotNet.Utilities.Json.JsonHelper.ToDataTable("[" + upData + "]");
        //        GridRow row = Grid2.Rows[ConvertHelper.Cint(arr[i]["index"].ToString())];
        //        System.Web.UI.WebControls.TextBox asdf = (System.Web.UI.WebControls.TextBox)row.FindControl("tBOM_NAME123");
        //        string ccc = asdf.Text;
        //        if (!String.IsNullOrEmpty(da.Rows[0]["BOM_ID"].ToString()) || !String.IsNullOrEmpty(ccc))
        //        {
        //            //System.Web.UI.WebControls.TextBox asdf = (System.Web.UI.WebControls.TextBox)row.FindControl("tBOM_NAME123");
        //            asdf.Text = "更改了";
        //        }
        //    }

        //}

        //public void eddddd(object sender, EventArgs e)
        //{
        //    //LoadData2("001");
        //    //JArray abc = Grid2.GetModifiedData();
        //    //Grid2.DataSource = abc;
        //    //Grid2.DataBind();
        //    JArray arr=Grid2.GetMergedData();
        //    DataTable da2 = new DataTable();
        //    da2 = null;
        //    //int selections = Grid2.SelectedRowIndex;
        //    for (int i = 0; i < arr.Count; i++)
        //    {
        //        string upData = arr[i]["values"].ToString();
        //        //newadded
        //        string upStatus = arr[i]["status"].ToString();
        //        DataTable da = DotNet.Utilities.Json.JsonHelper.ToDataTable("[" + upData + "]");
        //        //da2.Merge(da);
        //        if (da2 == null)
        //        {
        //            da2 = da.Copy();
        //        }
        //        da2.ImportRow(da.Rows[0]);
        //    }
        //    string dddd = da2.Rows[0][2].ToString();
        //    Grid2.DataSource = da2;
        //    Grid2.DataBind();

        //    int o = 0;
        //    //int _Id = ConvertHelper.Cint(Grid2.DataKeys[o][0].ToString());
        //    GridRow row = Grid2.Rows[o];

        //    System.Web.UI.WebControls.TextBox asdf = (System.Web.UI.WebControls.TextBox)row.FindControl("tBOM_NAME123");
            
        //    asdf.Text = "更改了";
        //    asdf.Focus();

        //    System.Web.UI.WebControls.DropDownList a = (System.Web.UI.WebControls.DropDownList)row.FindControl("dddllllKIND_NAME");
        //    PROD_DEPBll.GetInstence().BandDropDownListShowDep(this, a);
        //    //a.SelectedValue = "3";
        //}

        #endregion

        #endregion
    }
}