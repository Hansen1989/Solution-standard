﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using SubSonic.Query;
using Newtonsoft.Json.Linq;

namespace Solution.Web.Managers.WebManage.Systems.SupplyCenter
{
    public partial class IN_BACK00List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //123
                DatePicker1.SelectedDate = DateTime.Now.AddDays(-100);
                DatePicker2.SelectedDate = DateTime.Now.AddDays(1);
                SHOP00Bll.GetInstence().BandDropDownListShowShop1(this, ddlSHOP_NAME);
                SHOP00Bll.GetInstence().BandDropDownListShowShop1(this, ddlOUT_SHOP);
                LoadList();
                LoadData();
                OrderStatus(new IN_BACK00());
                TextBox3.Enabled = false;
            }
        }

        public override void LoadData()
        {
            SearchOrder();
        }

        /// <summary>
        /// 加载下拉列表
        /// </summary>
        public void LoadList()
        {
            var model = GetOnlineUserShop();
            SHOP00Bll.GetInstence().BindOnlineUser(this, model.SHOP_ID, ddlSHOP_NAME);
            STOCKBll.GetInstence().BandDropDownListStock(this, ddlSTOCK_ID);
            SHOP00Bll.GetInstence().GetShopList(this, model.SHOP_ID, ddlOUT_SHOP);
            //SHOP00Bll.GetInstence().BindOnlineUser(this, model.SHOP_ID, ddlSHOP_NAME1);
        }

        /// <summary>
        /// 根据当前账户，获取所属门店信息
        /// </summary>
        /// <returns></returns>
        public SHOP00 GetOnlineUserShop()
        {
            var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
            var shop_id = OlUser.SHOP_ID;
            var model = new SHOP00(x => x.SHOP_ID == shop_id);
            return model;
        }
        /// <summary>
        /// 按时间范围检索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnSearchOrder_click(object sender, EventArgs e)
        {
            SearchOrder();
        }

        public void SearchOrder()
        {
            //int type = ConvertHelper.Cint(FilterDateRadio.SelectedValue);
            IN_BACK00Bll.GetInstence().BindGrid(Grid1, 0, 0, InquiryCondition(), sortList);
            //TAKEIN10Bll.GetInstence().BindOrderGrid(st, et, type, Grid1);
        }

        /// <summary>
        /// 条件
        /// </summary>
        /// <returns></returns>
        private List<ConditionFun.SqlqueryCondition> InquiryCondition()
        {
            List<ConditionFun.SqlqueryCondition> conditionList = new List<ConditionFun.SqlqueryCondition>();
            //conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "1", Comparison.Equals, "1", false, false));
            bool sFlag = true;
            var model = GetOnlineUserShop();

            string st = DatePicker1.Text;
            string et = DatePicker2.Text;
            //string sn = ddlSHOP_NAME1.SelectedValue;
            string DateType = ddrDataType.SelectedValue;
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, IN_BACK00Table.SHOP_ID, Comparison.Equals, model.SHOP_ID, false, false));
            if (DateType.Equals("1"))
            {
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, IN_BACK00Table.INPUT_DATE, Comparison.LessOrEquals, et, false, false));
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, IN_BACK00Table.INPUT_DATE, Comparison.GreaterOrEquals, st, false, false));
            }
            else
            {
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, IN_BACK00Table.APP_DATETIME, Comparison.LessOrEquals, et, false, false));
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, IN_BACK00Table.APP_DATETIME, Comparison.GreaterOrEquals, st, false, false));
            }

            return conditionList;
        }


        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {
            bll = IN_BACK00Bll.GetInstence();
            //throw new NotImplementedException();
        }

        public override void SingleClick(GridRowClickEventArgs e)
        {
            string _tbxIB_ID = GridViewHelper.GetSelectedKey(Grid1, true);
            tbxIB_ID.Text = _tbxIB_ID;
            LoadMAIN();
            LoadDETAIL();
            //Alert.ShowInTop(String.Format("你点击了第 {0} 行（单击）", e.RowIndex + 1));
        }


        /// <summary>
        /// 加载主表明细数据
        /// </summary>
        public void LoadMAIN(string _tbxIB_ID="")
        {
            if (String.IsNullOrEmpty(_tbxIB_ID))
            {
                _tbxIB_ID = tbxIB_ID.Text;
            }
            if (!String.IsNullOrEmpty(_tbxIB_ID))
            {
                var model = new IN_BACK00(x => x.IB_ID == _tbxIB_ID);
                ddlSHOP_NAME.SelectedValue = model.SHOP_ID;
                dpINPUT_DATE.SelectedDate = model.INPUT_DATE;
                ddlStatus.SelectedValue = model.STATUS.ToString();
                ddlOUT_SHOP.SelectedValue = model.OUT_SHOP;
                ddlSTOCK_ID.SelectedValue = model.STOCK_ID;
                tbxUSER_ID.Text = model.USER_ID;
                tbxAPP_USER.Text = model.APP_USER;
                dpAPP_DATETIME.SelectedDate = model.APP_DATETIME;

                tbxRELATE_ID.Text = model.RELATE_ID;
                tbxMemo.Text = model.Memo;
                ckLOCKED.Checked = model.LOCKED == '0' ? false : true;
                if (!String.IsNullOrEmpty(model.RELATE_ID))
                {
                    ButtonYR.Enabled = false;
                }


                tbxCRT_DATETIME.Text = model.CRT_DATETIME.ToString();
                tbxCRT_USER_ID.Text = model.CRT_USER_ID;
                tbxMOD_DATETIME.Text = model.MOD_DATETIME.ToString();
                tbxMOD_USER_ID.Text = model.MOD_USER_ID;
                //tbxLAST_UPDATE.Text = model.LAST_UPDATE.ToString();
                OrderStatus(model);
            }
        }

        public void LoadDETAIL(string _tbxIB_ID="")
        {
            //先判断是否为空，为空则赋值
            if (String.IsNullOrEmpty(_tbxIB_ID))
            {
                _tbxIB_ID = tbxIB_ID.Text;
            }
            //再次判断tbxID的值是否为空
            if (!String.IsNullOrEmpty(_tbxIB_ID))
            {
                List<ConditionFun.SqlqueryCondition> conditiondetail = new List<ConditionFun.SqlqueryCondition>();
                conditiondetail.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, V_IN_BACK01_PRODUCT00Table.IB_ID, Comparison.Equals, _tbxIB_ID, false, false));
                V_IN_BACK01_PRODUCT00Bll.GetInstence().BindGrid(Grid2, 0, 0, conditiondetail, sortList);
            }
        }


        /// <summary>
        /// 状态位的判定
        /// </summary>
        /// <param name="status"></param>
        public void OrderStatus(IN_BACK00 model)
        {

            OrderStatus2(model);
        }
        public void OrderStatus2(IN_BACK00 model)
        { 
            //1:存档 2：核准 3：作废 4：已引入
            //新增：ButtonAdd 保存：ButtonSave 更新：ButtonUpdate 核准：ButtonCheck 作废：ButtonCancel
            //Pur02新增：ButtonPur02Add
            switch (model.STATUS)
            {
                case 1:
                    ButtonSave.Enabled = false;
                    ButtonEdit.Enabled = true;
                    ButtonCancel.Enabled = true;
                    ButtonCheck.Enabled = true;
                    ButtonYR.Enabled = true;
                    ButtonCheck.Text = "核准";
                    ButtonCancel.Text = "作废";
                    ButtonDetailAdd.Enabled = true;
                    Grid2.Enabled = true;
                    Grid2.AllowCellEditing = true; break;
                case 2:
                    ButtonSave.Enabled = false;
                    ButtonEdit.Enabled = false;
                    ButtonCheck.Text = "反核准";
                    ButtonYR.Enabled = false;
                    ButtonCancel.Text = "作废";
                    ButtonCancel.Enabled = false;
                    ButtonCheck.Enabled = true;
                    ButtonDetailAdd.Enabled = false;
                    Grid2.Enabled = false; break;
                case 3:
                    ButtonSave.Enabled = false;
                    ButtonEdit.Enabled = false;
                    ButtonCheck.Text = "核准";
                    ButtonYR.Enabled = false;
                    ButtonCheck.Enabled = false;
                    ButtonCancel.Text = "取消作废";
                    ButtonCancel.Enabled = true;
                    ButtonDetailAdd.Enabled = false;
                    Grid2.Enabled = false;
                    //Grid2.AllowCellEditing = false;
                    break;
                case 4:
                    ButtonSave.Enabled = false;
                    ButtonEdit.Enabled = false;
                    ButtonCheck.Text = "反核准";
                    ButtonYR.Enabled = false;
                    ButtonCancel.Text = "作废";
                    ButtonCancel.Enabled = false;
                    ButtonCheck.Enabled = false;
                    ButtonDetailAdd.Enabled = false;
                    Grid2.Enabled = false;
                    Grid2.AllowCellEditing = false; break;
                default:
                    ButtonSave.Enabled = false;
                    ButtonEdit.Enabled = false;
                    ButtonCheck.Text = "核准";
                    ButtonYR.Enabled = false;
                    ButtonCancel.Text = "作废";
                    ButtonCancel.Enabled = false;
                    ButtonCheck.Enabled = false;
                    ButtonDetailAdd.Enabled = false;
                    Grid2.AllowCellEditing = true; break;
            }
        }

        /// <summary>
        /// 新增数据，将数据清空，并可编辑
        /// </summary>
        public void BtnAdd_Click(Object sender, EventArgs e)
        {
            OrderStatus(new IN_BACK00());
            ButtonSave.Enabled = true;
            tbxIB_ID.Text = "";
            ddlSHOP_NAME.Enabled = true;
            ddlSHOP_NAME.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            dpINPUT_DATE.SelectedDate = DateTime.Now;

            ddlOUT_SHOP.Enabled = true;
            ddlOUT_SHOP.SelectedIndex = 0;
            ddlSTOCK_ID.Enabled = true;
            ddlSTOCK_ID.SelectedIndex = 0;
            tbxUSER_ID.Text = "";
            tbxAPP_USER.Text = "";
            dpAPP_DATETIME.SelectedDate = DateTime.Parse("1900-01-01 00:00:00");


            tbxRELATE_ID.Text = "";
            tbxMemo.Text = "";
            ckLOCKED.Checked = false;


            tbxCRT_DATETIME.Text = "";
            tbxCRT_USER_ID.Text = "";
            tbxMOD_DATETIME.Text = "";
            tbxMOD_USER_ID.Text = "";
            //tbxLAST_UPDATE.Text = "";

            Grid2.DataSource = null;
            Grid2.DataBind();
        }

        /// <summary>
        /// 引入按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnYR_Click(Object sender, EventArgs e)
        {
            FineUI.DatePicker wst = Window4.FindControl("PanelGrid5").FindControl("Panel_Search2").FindControl("dpSt") as FineUI.DatePicker;
            FineUI.DatePicker wet = Window4.FindControl("PanelGrid5").FindControl("Panel_Search2").FindControl("dpEt") as FineUI.DatePicker;
            wst.SelectedDate = DateTime.Now.Date.AddDays(-1);
            wet.SelectedDate = DateTime.Now.Date;
            Window4.Hidden = false;
            Window3.Hidden = true;
        }
        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnSave_Click(Object sender, EventArgs e)
        {
            string result = MAINEdit();
            if (String.IsNullOrEmpty(result))
            {
                FineUI.Alert.ShowInParent("保存成功", FineUI.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 修改按钮
        /// </summary>
        public void Btn_MainEdit(Object sender, EventArgs e)
        {
            string result = DetailEdit();
            if (String.IsNullOrEmpty(result))
            {
                result = MAINEdit();
            }
            if (!String.IsNullOrEmpty(result))
            {
                FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Error);
            }
            else
            {
                FineUI.Alert.ShowInParent("保存成功", FineUI.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 核准按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Btn_MainCheck(Object sender, EventArgs e)
        {
            string _IB_ID = tbxIB_ID.Text.ToString();
            var model = IN_BACK00.SingleOrDefault(x => x.IB_ID == _IB_ID);
            int in_status = model.STATUS;
            if (model == null)
            {
                FineUI.Alert.ShowInParent("订单单号不存在", FineUI.MessageBoxIcon.Information);
                return;
            }

            if (model.STATUS == 1)
            {

                DataTable dsCom = (DataTable)SPs.Get_MAX_Inventory_DATE().ExecuteDataTable();
                DateTime dtInput = DateTime.Parse(dsCom.Rows[0]["INPUT_DATE"].ToString());
                if (model.INPUT_DATE.CompareTo(dtInput) <= 0)
                {
                    FineUI.Alert.ShowInParent("单据小于盘点日期，不允许盘点。盘点日期为:" + dsCom.Rows[0]["INPUT_DATE"].ToString() + "", FineUI.MessageBoxIcon.Information);
                    return;
                }
            }

            //1 = 存档 2 = 核准 3 = 作废 4 = 已引入(供应商进货)
            switch (model.STATUS)
            {
                case 1: model.STATUS = 2; break;
                case 2: model.STATUS = 1; break;
                case 3: FineUI.Alert.ShowInParent("订单已作废，无法进行核准", FineUI.MessageBoxIcon.Information); return;
                case 4: FineUI.Alert.ShowInParent("订单已引入，无法进行核准", FineUI.MessageBoxIcon.Information); return;
                default: FineUI.Alert.ShowInParent("订单状态有误，无法核准", FineUI.MessageBoxIcon.Information); return;
            }

            ddlStatus.SelectedValue = model.STATUS.ToString();

            string result = DetailEdit();
            if (String.IsNullOrEmpty(result))
            {
                result = MAINEdit();
            }
            if (String.IsNullOrEmpty(result))
            {
                //dsCom = (DataSet)SPs.Get_Purchase00(st, et, type).ExecuteDataSet();
                if (in_status == 2)
                {
                    SPs.Update_in_back00_stock01(_IB_ID).Execute();
                }
                else
                {
                    SPs.Update_in_back00_stock01_cancel(_IB_ID).Execute();
                }
            }

            if (!String.IsNullOrEmpty(result))
            {
                FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Error);
            }
            else
            {
                FineUI.Alert.ShowInParent("保存成功", FineUI.MessageBoxIcon.Error);
            }

            LoadMAIN();
            LoadDETAIL();
            //FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Error);
            //FineUI.Alert.ShowInParent("核准成功", FineUI.MessageBoxIcon.Information);
        }

        /// <summary>
        /// 作废按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Btn_MainCancel(Object sender, EventArgs e)
        {
            string _IB_ID = tbxIB_ID.Text.ToString();
            var model = IN_BACK00.SingleOrDefault(x => x.IB_ID == _IB_ID);
            if (model == null)
            {
                FineUI.Alert.ShowInParent("订单单号不存在", FineUI.MessageBoxIcon.Information);
            }
            //1 = 存档 2 = 核准 3 = 作废 4 = 已引入(供应商进货)
            switch (model.STATUS)
            {
                case 1: model.STATUS = 3; break;
                case 2: FineUI.Alert.ShowInParent("订单已核准，无法进行作废", FineUI.MessageBoxIcon.Information); return;
                case 3: model.STATUS = 1; break;
                case 4: FineUI.Alert.ShowInParent("订单已引入，无法进行作废", FineUI.MessageBoxIcon.Information); return;
                default: FineUI.Alert.ShowInParent("订单状态有误，无法进行作废", FineUI.MessageBoxIcon.Information); return;
            }
            ddlStatus.SelectedValue = model.STATUS.ToString();

            string result = DetailEdit();
            if (String.IsNullOrEmpty(result))
            {
                result = MAINEdit();
            }
            if (!String.IsNullOrEmpty(result))
            {
                FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Error);
            }
            else
            {
                FineUI.Alert.ShowInParent("保存成功", FineUI.MessageBoxIcon.Error);
            }

            LoadMAIN();
            LoadDETAIL();
            //FineUI.Alert.ShowInParent("核准成功", FineUI.MessageBoxIcon.Information);
        }

        /// <summary>
        /// 主表保存
        /// </summary>
        /// <returns></returns>
        public string MAINEdit()
        {
            string _IB_ID = tbxIB_ID.Text;
            try
            {
                var model = new IN_BACK00(x => x.IB_ID == _IB_ID);
                var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                string _SHOP_ID = ddlSHOP_NAME.SelectedValue;
                if (String.IsNullOrEmpty(_IB_ID))
                {
                    model.SetIsNew(true);
                    model.CRT_DATETIME = DateTime.Now;
                    model.CRT_USER_ID = OlUser.Manager_LoginName;
                    DataTable dt = new DataTable();
                    dt = (DataTable)SPs.Get_ORDER_SEED(_SHOP_ID, "IN_BACK00").ExecuteDataTable();
                    _IB_ID = dt.Rows[0]["PLANE_ID"].ToString();
                    //var model = Purchase00.SingleOrDefault(x => x.Purchase_ID == _Pur00_id);
                    tbxIB_ID.Text = _IB_ID;
                }
                model.SHOP_ID = _SHOP_ID;
                model.IB_ID = _IB_ID.ToString();
                model.STATUS = ConvertHelper.Cint(ddlStatus.SelectedValue);
                model.INPUT_DATE = ConvertHelper.StringToDatetime(dpINPUT_DATE.SelectedDate.ToString());

                model.OUT_SHOP = ddlOUT_SHOP.SelectedValue;
                model.STOCK_ID = ddlSTOCK_ID.SelectedValue;
                model.USER_ID = OlUser.Manager_LoginName;
                model.APP_USER = OlUser.Manager_LoginName;
                model.APP_DATETIME = DateTime.Now;


                string _RELATE_ID = tbxRELATE_ID.Text;
                model.RELATE_ID = _RELATE_ID;
                if (!String.IsNullOrEmpty(_RELATE_ID))
                {
                    var modelOrder = new OUT_BACK00(x => x.BK_ID == _RELATE_ID);
                    modelOrder.Exported = 1;
                    modelOrder.Exported_ID = _IB_ID;
                    modelOrder.Save();
                }
                model.Memo = tbxMemo.Text;
                model.LOCKED = ConvertHelper.StringToByte(ckLOCKED.Checked ? "1" : "0");

                model.MOD_DATETIME = DateTime.Now;
                model.MOD_USER_ID = OlUser.Manager_LoginName;
                model.LAST_UPDATE = DateTime.Now;
                model.Trans_STATUS = 0;
                IN_BACK00Bll.GetInstence().Save(this, model);
            }
            catch (Exception err)
            {
                return err.Message;
            }
            LoadMAIN(_IB_ID);
            return "";
        }

        /// <summary>
        /// 子表保存
        /// </summary>
        /// <returns></returns>
        public string DetailEdit()
        {
            JArray jarr = Grid2.GetMergedData();
            string result = "";
            result=DetailChecked(jarr);
            if (!String.IsNullOrEmpty(result))
            {
                return result;
            }


            var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());

            int n = 0;
            for (int i = 0; i < jarr.Count; i++)
            {
                try
                {
                    var model2 = new IN_BACK01();
                    //string str = jarr[i]["status"].ToString();
                    if (jarr[i]["status"].ToString().Equals("modified"))
                    {
                        model2.SetIsNew(false);
                    }
                    else if (jarr[i]["status"].ToString().Equals("unchanged"))
                    {
                        continue;
                    }
                    else
                    {
                        model2.SetIsNew(true);
                    }
                    model2.SHOP_ID = jarr[i]["values"]["SHOP_ID01"].ToString();
                    if (!String.IsNullOrEmpty(jarr[i]["values"]["IB_ID01"].ToString()))
                    {
                        model2.IB_ID = jarr[i]["values"]["IB_ID01"].ToString();
                    }
                    else
                    {
                        return "保存失败";
                    }
                    model2.SNo = ConvertHelper.Cint(jarr[i]["values"]["SNo01"].ToString());
                    model2.PROD_ID = jarr[i]["values"]["PROD_ID01"].ToString();
                    model2.QUANTITY = ConvertHelper.StringToDecimal(jarr[i]["values"]["QUANTITY01"].ToString());
                    model2.STD_UNIT = jarr[i]["values"]["STD_UNIT01"].ToString();
                    model2.STD_CONVERT = ConvertHelper.Cint(jarr[i]["values"]["STD_CONVERT01"].ToString());
                    model2.STD_QUAN = ConvertHelper.StringToDecimal(jarr[i]["values"]["STD_QUAN01"].ToString());
                    model2.STD_PRICE = ConvertHelper.StringToDecimal(jarr[i]["values"]["STD_PRICE01"].ToString());
                    model2.COST = ConvertHelper.StringToDecimal(jarr[i]["values"]["COST01"].ToString());
                    model2.QUAN1 = ConvertHelper.StringToDecimal(jarr[i]["values"]["QUAN101"].ToString());
                    model2.QUAN2 = ConvertHelper.StringToDecimal(jarr[i]["values"]["QUAN201"].ToString());
                    model2.MEMO = jarr[i]["values"]["MEMO01"].ToString();
                    model2.BAT_NO = jarr[i]["values"]["BAT_NO"].ToString();
                    model2.Exp_DateTime = DateTime.Now;
                    IN_BACK01Bll.GetInstence().Save(this, model2);
                }
                catch (Exception err)
                {
                    n++;
                    result = "明细保存失败" + n + "条";
                }
            }
            LoadDETAIL("");
            return result;
        }

        public string DetailChecked(JArray pJson)
        {
            string result = "";
            for (int i = 0; i < pJson.Count; i++)
            {
                if (String.IsNullOrEmpty(pJson[i]["values"]["STD_QUAN01"].ToString()))
                {
                    result = pJson[i]["values"]["PROD_NAME101"].ToString() + "商品，入库量量不能为空并且数量大于0";
                }
            }
            return "";
        }

        #region window事件
        /// <summary>
        /// 新增按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btn_DetailAdd(Object sender, EventArgs e)
        {
            string Pur_status = ddlStatus.SelectedValue;
            FineUI.Panel P_search = Window3.FindControl("PanelGrid4").FindControl("Panel_Search") as FineUI.Panel;
            P_search.Hidden = false;
            FineUI.Button B_BtnSearchCon = Window3.FindControl("PanelGrid4").FindControl("tool_btn").FindControl("BtnSearchCon") as FineUI.Button;
            FineUI.Button B_BtnAddCon = Window3.FindControl("PanelGrid4").FindControl("tool_btn").FindControl("BtnAddCon") as FineUI.Button;
            B_BtnSearchCon.Hidden = false;
            B_BtnAddCon.Hidden = false;
            Window3.Hidden = false;
        }

        /// <summary>
        /// 商品查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonPRODSearch_Click(object sender, EventArgs e)
        {

            conditionList = null;
            //conditionList = new List<ConditionFun.SqlqueryCondition>();
            //绑定Grid表格
            FineUI.Grid Grid4 = Window3.FindControl("PanelGrid4").FindControl("Grid4") as FineUI.Grid;
            V_STOCK01_PRODUCT01Bll.GetInstence().BindGrid(Grid4, 0, 0, InquiryConditionProduct(), sortList);
        }

        /// <summary>
        /// GRID3(商品)检索的判断条件
        /// </summary>
        /// <returns></returns>
        private List<ConditionFun.SqlqueryCondition> InquiryConditionProduct()
        {
            string _shop_id = ddlOUT_SHOP.SelectedValue;
            List<ConditionFun.SqlqueryCondition> conditionProdduct00List = new List<ConditionFun.SqlqueryCondition>();
            bool sFlag = true;
            conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), V_STOCK01_PRODUCT01Table.SHOP_ID, Comparison.Equals, _shop_id, false, false));
            sFlag = false;
            //conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "1", Comparison.Equals, "1", false, false));

            FineUI.TextBox cPROD_ID = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_ID") as FineUI.TextBox;
            var _PROD_ID = cPROD_ID.Text;
            if (!String.IsNullOrEmpty(cPROD_ID.Text))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), V_STOCK01_PRODUCT01Table.PROD_ID, Comparison.Like, "%" + _PROD_ID + "%", false, false));
                sFlag = false;
            }

            FineUI.TextBox cPROD_NAME = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_NAME") as FineUI.TextBox;
            var _PROD_NAME = cPROD_NAME.Text;
            if (!String.IsNullOrEmpty(_PROD_NAME))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), V_STOCK01_PRODUCT01Table.PROD_NAME1, Comparison.Like, "%" + _PROD_NAME + "%", false, false));
                sFlag = false;
            }
            FineUI.TextBox cPROD_NAME_SPELLING = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_NAME_SPELLING") as FineUI.TextBox;
            var _PROD_NAME_SPELLING = cPROD_NAME_SPELLING.Text;
            if (!String.IsNullOrEmpty(_PROD_NAME_SPELLING))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), V_STOCK01_PRODUCT01Table.PROD_NAME1_SPELLING, Comparison.Like, "%" + _PROD_NAME_SPELLING + "%", false, false));
                sFlag = false;
            }
            FineUI.DropDownList cPROD_KIND = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_KIND") as FineUI.DropDownList;
            var _cPROD_KIND = cPROD_KIND.SelectedValue;
            if (!String.IsNullOrEmpty(_cPROD_KIND) && _cPROD_KIND != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), V_STOCK01_PRODUCT01Table.PROD_KIND, Comparison.Equals, _cPROD_KIND, false, false));
                sFlag = false;
            }

            FineUI.DropDownList cPROD_DEP = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_DEP") as FineUI.DropDownList;
            var _PROD_DEP = cPROD_DEP.SelectedValue;
            if (!String.IsNullOrEmpty(_PROD_NAME) && _PROD_DEP != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), V_STOCK01_PRODUCT01Table.PROD_DEP, Comparison.Equals, _PROD_DEP, false, false));
                sFlag = false;
            }
            FineUI.DropDownList cPROD_CATE = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_CATE") as FineUI.DropDownList;
            var _PROD_CATE = cPROD_CATE.SelectedValue;
            if (!String.IsNullOrEmpty(_PROD_CATE) && _PROD_CATE != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), V_STOCK01_PRODUCT01Table.PROD_CATE, Comparison.Equals, _PROD_CATE, false, false));
                sFlag = false;
            }

            if (sFlag)
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), "1", Comparison.Equals, "1", false, false));
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

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonPRODAdd_Click(object sender, EventArgs e)
        {
            FineUI.Grid Grid4 = Window3.FindControl("PanelGrid4").FindControl("Grid4") as FineUI.Grid;

            int[] selections = Grid4.SelectedRowIndexArray;
            string _IB_ID = tbxIB_ID.Text;
            string _Shop_ID = ddlOUT_SHOP.SelectedValue;
            string result = "";
            //var m_Shop = new SHOP00(x => x.SHOP_ID == _Shop_ID);
            //string _priceArea_id = m_Shop.SHOP_Price_Area;
            if (!String.IsNullOrEmpty(_IB_ID))
            {
                int rowCount = Grid2.Rows.Count;
                foreach (int i in selections)
                {
                    string _Prod_ID = Grid4.DataKeys[i][0].ToString();
                    string _prod_name = Grid4.DataKeys[i][1].ToString();
                    string _shop_id = ddlSHOP_NAME.SelectedValue;
                    string checkresult = ProdAddCheck(_Prod_ID, _prod_name);
                    if (!String.IsNullOrEmpty(checkresult))
                    {
                        result = result + "\r\n" + checkresult;
                        continue;
                    }

                    var model = new V_STOCK01_PRODUCT01(x => x.PROD_ID == _Prod_ID && x.SHOP_ID == _Shop_ID);
                    JObject deObject = new JObject();
                    deObject.Add("Id01", "0");
                    deObject.Add("SHOP_ID01", _Shop_ID);
                    deObject.Add("SHOP_NAME101", model.SHOP_NAME1);
                    deObject.Add("IB_ID01", _IB_ID);
                    deObject.Add("SNo01", rowCount + 1);
                    deObject.Add("PROD_ID01", _Prod_ID);
                    deObject.Add("PROD_NAME101", model.PROD_NAME1);
                    deObject.Add("QUANTITY01", model.ORDER_QUAN);
                    deObject.Add("STD_UNIT01", model.ORDER_UNIT);
                    deObject.Add("STD_QUAN01", model.ORDER_QUAN);
                    switch (model.ORDER_UNIT)
                    {
                        case 1:
                            deObject.Add("STD_PRICE01", model.S_Cost);
                            deObject.Add("COST01", model.COST);
                            deObject.Add("STD_CONVERT01", 1);
                            break;
                        case 2:
                            deObject.Add("STD_PRICE01", model.S_Cost1);
                            deObject.Add("COST01", model.COST1);
                            deObject.Add("STD_CONVERT01", model.PROD_CONVERT1);
                            break;
                        case 3:
                            deObject.Add("STD_PRICE01", model.S_Cost2);
                            deObject.Add("COST01", model.COST2);
                            deObject.Add("STD_CONVERT01", model.PROD_CONVERT2);
                            break;
                        default:
                            deObject.Add("STD_PRICE01", 0);
                            deObject.Add("COST01", 0);
                            deObject.Add("STD_CONVERT01", 1);
                            break;
                    }

                    deObject.Add("QUAN101", 0);
                    deObject.Add("QUAN201", 0);
                    deObject.Add("REASON_ID01", "");
                    deObject.Add("MEMO01", "");
                    deObject.Add("BAT_NO", "");

                    deObject.Add("STD_UNIT_NAME01", model.ORDER_NAME);
                    deObject.Add("UNIT_NAME01", model.UNIT_NAME);
                    deObject.Add("UNIT_NAME101", model.UNIT_NAME1);
                    deObject.Add("UNIT_NAME201", model.UNIT_NAME2);

                    deObject.Add("PROD_CONVERT101", model.PROD_CONVERT1);
                    deObject.Add("PROD_CONVERT201", model.PROD_CONVERT2);


                    deObject.Add("S_RET_COST01", model.S_Ret_Cost);
                    deObject.Add("S_RET_COST101", model.S_Ret_Cost1);
                    deObject.Add("S_RET_COST201", model.S_Ret_Cost2);

                    deObject.Add("R_COST01", model.COST);
                    deObject.Add("R_COST101", model.COST1);
                    deObject.Add("R_COST201", model.COST2);
                    rowCount++;
                    Grid2.AddNewRecord(deObject, true);
                }
            }
            else
            {
                FineUI.Alert.ShowInParent("未选中订单无法添加", FineUI.MessageBoxIcon.Information);
            }
            if (!String.IsNullOrEmpty(result.Trim()))
            {
                FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
            }
        }
        #endregion

        #region WINDOW4 引入出货订单
        protected void ButtonOrderSearch_Click(Object sender, EventArgs e)
        {
            FineUI.Grid grid4 = Window4.FindControl("PanelGrid5").FindControl("Grid4") as FineUI.Grid;
            V_OUT_BACK00_DETAILNAMEBll.GetInstence().BindGrid(grid4, 0, 0, OrderCondition(), null);
        }
        /// <summary>
        /// 检索条件
        /// </summary>
        /// <returns></returns>
        public List<ConditionFun.SqlqueryCondition> OrderCondition()
        {
            List<ConditionFun.SqlqueryCondition> orderCon = new List<ConditionFun.SqlqueryCondition>();
            FineUI.RadioButtonList datetype = Window4.FindControl("PanelGrid5").FindControl("Panel_Search2").FindControl("ddrDataType") as FineUI.RadioButtonList;
            string rValue = datetype.SelectedValue;
            FineUI.DatePicker wst = Window4.FindControl("PanelGrid5").FindControl("Panel_Search2").FindControl("dpSt") as FineUI.DatePicker;
            FineUI.DatePicker wet = Window4.FindControl("PanelGrid5").FindControl("Panel_Search2").FindControl("dpEt") as FineUI.DatePicker;
            string starttime = wst.Text;
            string endtime = wet.Text;
            string _shop_id = ddlOUT_SHOP.SelectedValue;
            orderCon.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, OUT_BACK00Table.SHOP_ID, Comparison.Equals, _shop_id, false, false));

            if (rValue == "1")
            {
                orderCon.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, OUT_BACK00Table.INPUT_DATE, Comparison.LessOrEquals, endtime, false, false));
                orderCon.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, OUT_BACK00Table.INPUT_DATE, Comparison.GreaterOrEquals, starttime, false, false));
            }
            //FineUI.DropDownList _ddlShopName = Window4.FindControl("PanelGrid5").FindControl("Panel_Search2").FindControl("w4_ddlSHOP_NAME") as FineUI.DropDownList;
            //string _shopid = _ddlShopName.SelectedValue;
            //if (!String.IsNullOrEmpty(_shopid))
            //{
            //    orderCon.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, ORDER00Table.SHOP_ID, Comparison.Equals, _shopid, false, false));
            //}
            return orderCon;
        }


        protected void ButtonOrderAdd_Click(Object sender, EventArgs e)
        {

            FineUI.Grid Grid4 = Window4.FindControl("PanelGrid5").FindControl("Grid4") as FineUI.Grid;
            int[] selections = Grid4.SelectedRowIndexArray;
            //tbxRELATE_ID.Text = Grid4.DataKeys[0][0].ToString();
            DataTable Inda = SPs.IN_OUTBACK01_INBACK01(Grid4.DataKeys[selections[0]][0].ToString(), tbxIB_ID.Text, ddlSHOP_NAME.SelectedValue).ExecuteDataTable();
            Grid2.DataSource = Inda;
            Grid2.DataBind();
            Toolbar21111.Enabled = false;

            //FineUI.Grid Grid4 = Window4.FindControl("PanelGrid5").FindControl("Grid4") as FineUI.Grid;
            //int[] selections = Grid4.SelectedRowIndexArray;
            //tbxRELATE_ID.Text = Grid4.DataKeys[0][0].ToString();
            //foreach (int i in selections)
            //{
            //    List<ConditionFun.SqlqueryCondition> order00con = new List<ConditionFun.SqlqueryCondition>();
            //    order00con.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, OUT_BACK01Table.BK_ID, Comparison.Equals, Grid4.DataKeys[i][0].ToString(), false, false));
            //    List<string> colList = new List<string>();
            //    colList.Add("SHOP_ID");
            //    colList.Add("PROD_ID");
            //    colList.Add("QUANTITY");
            //    colList.Add("STD_UNIT");
            //    colList.Add("STD_CONVERT");
            //    colList.Add("STD_QUAN");
            //    colList.Add("STD_PRICE");
            //    //colList.Add("COST_PRICE");
            //    //colList.Add("");预留采购单位类别
            //    DataTable da = OUT_BACK01Bll.GetInstence().GetDataTable(false, 0, colList, 0, 0, order00con, null);

            //    foreach (DataRow dr in da.Rows)
            //    {
            //        string _shopid = dr["SHOP_ID"].ToString();
            //        string _PROD_ID = dr["PROD_ID"].ToString();
            //        var model = new SHOP00(x => x.SHOP_ID == _shopid);
            //        var model2 = new PRODUCT00(x => x.PROD_ID == _PROD_ID);
            //        int rowCount = Grid2.Rows.Count;
            //        JObject deObject = new JObject();
            //        deObject.Add("Id01", "0");
            //        deObject.Add("SHOP_ID01", dr["SHOP_ID"].ToString());
            //        deObject.Add("SHOP_NAME01", model.SHOP_NAME1);
            //        deObject.Add("IB_ID01", tbxIB_ID.Text);
            //        deObject.Add("SNo01", rowCount + 1);
            //        deObject.Add("PROD_ID01", dr["PROD_ID"].ToString());
            //        deObject.Add("PROD_NAME01", model2.PROD_NAME1);
            //        deObject.Add("QUANTITY01", dr["QUANTITY"].ToString());
            //        deObject.Add("STD_TYPE01", dr["STD_UNIT"].ToString());
            //        deObject.Add("STD_UNIT01", dr["STD_UNIT"].ToString());
            //        deObject.Add("STD_CONVERT01", dr["STD_CONVERT"].ToString());
            //        deObject.Add("STD_QUAN01", dr["STD_QUAN"].ToString());
            //        deObject.Add("STD_PRICE01", dr["STD_PRICE"].ToString());
            //        deObject.Add("COST01", dr["STD_PRICE"].ToString());
            //        deObject.Add("QUAN101", dr["STD_QUAN"].ToString());
            //        deObject.Add("QUAN201", dr["STD_QUAN"].ToString());
            //        deObject.Add("MEMO01", "");
            //        deObject.Add("BAT_NO", "");
            //        Grid2.AddNewRecord(deObject, true);
            //    }


            //}
        }

        private string ProdAddCheck(string prod_id, string prod_name)
        {
            JArray pJson = Grid2.GetMergedData();
            string result = "";

            for (int i = 0; i < pJson.Count; i++)
            {
                if (prod_id == pJson[i]["values"]["PROD_ID01"].ToString())
                {
                    result = "商品:" + prod_name + "已存在，不允许添加";
                    break;
                }
            }

            return result;
        }
        #endregion
    }
}