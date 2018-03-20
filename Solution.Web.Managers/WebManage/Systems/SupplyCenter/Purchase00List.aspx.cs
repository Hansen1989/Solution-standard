using System;
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
    public partial class Purchase00List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //这里更改了
            if (!IsPostBack)
            {
                DatePicker1.SelectedDate = DateTime.Now;
                DatePicker2.SelectedDate = DateTime.Now.AddDays(1);
                SHOP00Bll.GetInstence().BandDropDownListShowShop1(this, ddlSHOP_NAME);
                SUPPLIERSBll.GetInstence().BandDropDownListShowSup(this, ddlSUP_NAME);
                LoadList();
                LoadData();
                Purchase00Status(-1);
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {
            bll = Purchase00Bll.GetInstence();
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public override void LoadData()
        {
            int type = ConvertHelper.Cint(FilterDateRadio.SelectedValue);
            string st = "";
            string et = "";
            st = DatePicker1.Text;
            et = DatePicker2.Text;
            Purchase00Bll.GetInstence().BindPurchaesGrid(st, et, type, Grid1);
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Grid单机事件
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override void SingleClick(GridRowClickEventArgs e)
        {
            int _id = ConvertHelper.Cint0(GridViewHelper.GetSelectedKey(Grid1, true));
            hidId.Text = _id.ToString();
            tbxPurchase_ID.Enabled = false;
            if (_id != 0)
            {
                LoadPur();
                LoadDataPur01();
            }
        }

        /// <summary>
        /// 根据单据状态来设置界面内容
        /// </summary>
        public void Purchase00Status(int status)
        {
            //1:存档 2：核准 3：作废 4：已引入
            //新增：ButtonAdd 保存：ButtonSave 更新：ButtonUpdate 核准：ButtonCheck 作废：ButtonCancel
            //Pur02新增：ButtonPur02Add
            switch (status)
            {
                case 1:
                    ButtonSave.Enabled = false;
                    ButtonUpdate.Enabled = true;
                    ButtonCancel.Enabled = true;
                    ButtonCheck.Enabled = true;
                    ButtonCheck.Text = "核准";
                    ButtonCancel.Text = "作废";
                    ButtonPur02Add.Enabled = true;
                    Grid2.Enabled = true;
                    Grid2.AllowCellEditing = true; break;
                case 2:
                    ButtonSave.Enabled = false;
                    ButtonUpdate.Enabled = false;
                    ButtonCheck.Text = "反核准";
                    ButtonCancel.Text = "作废";
                    ButtonCancel.Enabled = false;
                    ButtonCheck.Enabled = true;
                    ButtonPur02Add.Enabled = false;
                    Grid2.Enabled = false; break;
                case 3:
                    ButtonSave.Enabled = false;
                    ButtonUpdate.Enabled = false;
                    ButtonCheck.Text = "核准";
                    ButtonCheck.Enabled = false;
                    ButtonCancel.Text = "取消作废";
                    ButtonCheck.Enabled = true;
                    Grid2.Enabled = false;
                    Grid2.AllowCellEditing = false; break;
                case 4:
                    ButtonSave.Enabled = false;
                    ButtonUpdate.Enabled = false;
                    ButtonCheck.Text = "反核准";
                    ButtonCancel.Text = "作废";
                    ButtonCancel.Enabled = false;
                    ButtonCheck.Enabled = false;
                    ButtonPur02Add.Enabled = false;
                    Grid2.Enabled = false;
                    Grid2.AllowCellEditing = false; break;
                default:
                    ButtonSave.Enabled = false;
                    ButtonUpdate.Enabled = false;
                    ButtonCheck.Text = "核准";
                    ButtonCancel.Text = "作废";
                    ButtonCancel.Enabled = false;
                    ButtonCheck.Enabled = false;
                    ButtonPur02Add.Enabled = false;
                    Grid2.AllowCellEditing = true; break;
            }
        }

        public void BtnSearchOrderDep_click(object sender, EventArgs e)
        {
            int type = ConvertHelper.Cint(FilterDateRadio.SelectedValue);
            string st = "";
            string et = "";
            st = DatePicker1.Text;
            et = DatePicker2.Text;
            Purchase00Bll.GetInstence().BindPurchaesGrid(st, et, type, Grid1);
        }
        /// <summary>
        /// 加载采购订单界面
        /// </summary>
        /// <param name="id"></param>
        public void LoadPur()
        {
            int id = ConvertHelper.Cint(hidId.Text);
            if (id == 0)
            {
                FineUI.Alert.ShowInParent("请重新选择采购单", FineUI.MessageBoxIcon.Error);
            }
            var model = Purchase00Bll.GetInstence().GetModel(id, false);
            if (model != null)
            {
                tbxPurchase_ID.Text = model.Purchase_ID;
                hidPurchase_ID.Text = model.Purchase_ID;
                string _shop_id = model.SHOP_ID;
                var shopModel = new SHOP00(x => x.SHOP_ID == model.SHOP_ID);
                //tbxSHOP_ID.Text = model.SHOP_ID;
                //tbxSHOP_NAME1.Text = shopModel.SHOP_NAME1;
                ddlSHOP_NAME.SelectedValue = shopModel.SHOP_ID;
                ddlStatus.SelectedValue = model.STATUS.ToString();
                dpINPUT_DATE.Text = model.INPUT_DATE.ToString("yyyy-MM-dd");
                dpEXPECT_DATE.Text = model.EXPECT_DATE.ToString("yyyy-MM-dd");
                ddlSUP_NAME.SelectedValue = model.SUP_ID.ToString();
                ddlPAY_STATUS.SelectedValue = model.PAY_STATUS.ToString();
                tbxUSER_ID.Text = model.USER_ID;
                tbxAPP_USER.Text = model.APP_USER;
                dpAPP_DATETIME.Text = model.APP_DATETIME.ToString("yyyy-MM-dd");
                numTOT_AMOUNT.Text = model.TOT_AMOUNT.ToString();
                numTOT_TAX.Text = model.TOT_TAX.ToString();
                numTOT_QTY.Text = model.TOT_QTY.ToString();
                numPRE_PAY.Text = model.PRE_PAY.ToString();
                tbxPRE_PAY_ID.Text = model.PRE_PAY_ID.ToString();
                ddlEXPORTED.SelectedValue = model.EXPORTED.ToString();
                tbxEXPORTED_ID.Text = model.EXPORTED_ID.ToString();
                if (model.LOCKED == 1)
                {
                    chxLOCKED.Checked = true;
                }
                else
                {
                    chxLOCKED.Checked = false;
                }
                tbxCRT_DATETIME.Text = model.CRT_DATETIME.ToString("yyyy-MM-dd");
                tbxCRT_USER_ID.Text = model.CRT_USER_ID;
                tbxMOD_DATETIME.Text = model.MOD_DATETIME.ToString("yyyy-MM-dd");
                tbxMOD_USER_ID.Text = model.MOD_USER_ID;
                tbxLAST_UPDATE.Text = model.LAST_UPDATE.ToString("yyyy-MM-dd");
                Purchase00Status(model.STATUS);
            }
        }


        public void LoackPur01()
        {
            ddlSHOP_NAME.Enabled = false;
            dpEXPECT_DATE.Enabled = false;
            ddlSUP_NAME.Enabled = false;
            ddlPAY_STATUS.Enabled = false;
            tbxPRE_PAY_ID.Enabled = false;
            chxLOCKED.Checked = false;
        }



        #region Purchase01事件
        /// <summary>
        /// 订单明细加载
        /// </summary>
        public void LoadDataPur01()
        {
            Purchase01Bll.GetInstence().BindGrid(Grid2, 0, 0, InquiryCondition(), null);
        }
        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private List<ConditionFun.SqlqueryCondition> InquiryCondition()
        {
            string _shop_id = ddlSHOP_NAME.SelectedValue;
            string _Purchase_ID = tbxPurchase_ID.Text;
            List<ConditionFun.SqlqueryCondition> condiList = new List<ConditionFun.SqlqueryCondition>();
            condiList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, Purchase01Table.SHOP_ID, Comparison.Equals, _shop_id, false, false));
            condiList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, Purchase01Table.Purchase_ID, Comparison.Equals, _Purchase_ID, false, false));
            return condiList;
        }

        /// <summary>
        /// 新增操作，可编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnPur01_Add(Object sender, EventArgs e)
        {
            //tbxPurchase_ID.Enabled = true;
            Purchase00Status(-1);
            ButtonSave.Enabled = true;
            hidId.Text = "";
            tbxPurchase_ID.Text = "";
            ddlSHOP_NAME.Enabled = true;
            ddlSHOP_NAME.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            dpINPUT_DATE.SelectedDate = DateTime.Now;
            dpEXPECT_DATE.Enabled = true;
            dpEXPECT_DATE.SelectedDate = DateTime.Now;
            ddlSUP_NAME.Enabled = true;
            ddlSUP_NAME.SelectedIndex = 0;
            ddlPAY_STATUS.Enabled = true;
            ddlPAY_STATUS.SelectedIndex = 0;
            tbxUSER_ID.Text = "";
            tbxAPP_USER.Text = "";
            dpAPP_DATETIME.Text = "";
            numTOT_AMOUNT.Text = "0";
            numTOT_TAX.Text = "0";
            numTOT_QTY.Text = "0";
            numPRE_PAY.Text = "0";
            tbxPRE_PAY_ID.Text = "";
            tbxPRE_PAY_ID.Enabled = true;
            ddlEXPORTED.SelectedValue = "1";
            tbxEXPORTED_ID.Text = "";
            chxLOCKED.Checked = false;
            tbxMemo.Text = "";
            tbxCRT_DATETIME.Text = "";
            tbxCRT_USER_ID.Text = "";
            tbxMOD_DATETIME.Text = "";
            tbxMOD_USER_ID.Text = "";
            tbxLAST_UPDATE.Text = "";
            Grid2.DataSource = null;
            Grid2.DataBind();
        }
        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnPur01_Save(Object sender, EventArgs e)
        {
            string result = Pur_Save();
            FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Error);

        }
        /// <summary>
        /// 更新按钮
        /// </summary>
        public void BtnPur01_Edit(Object sender, EventArgs e)
        {
            string result = Pur_Edit();
            FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Error);
        }
        /// <summary>
        /// 新增按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btn_Pur02Add(Object sender, EventArgs e)
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
        ///  替换按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btn_Replace(Object sender, EventArgs e)
        {
            string Pur_status = ddlStatus.SelectedValue;
            FineUI.Button B_BtnEditCon = Window3.FindControl("PanelGrid4").FindControl("tool_btn").FindControl("BtnEditCon") as FineUI.Button;
            B_BtnEditCon.Hidden = false;
            Window3.Hidden = false;
        }
        /// <summary>
        /// 核准按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnPur00_Approval(Object sender, EventArgs e)
        {
            string Pur00_ID = tbxPurchase_ID.Text.ToString();
            var model = Purchase00.SingleOrDefault(x => x.Purchase_ID == Pur00_ID);
            if (model == null)
            {
                FineUI.Alert.ShowInParent("订单单号不存在", FineUI.MessageBoxIcon.Information);
                return;
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
            var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
            model.MOD_DATETIME = DateTime.Now;
            model.LAST_UPDATE = DateTime.Now;
            model.MOD_USER_ID = OlUser.Manager_LoginName;
            string result = "";
            try
            {
                Purchase00Bll.GetInstence().Save(this, model);
            }
            catch (Exception err)
            {
                result = err.Message;
            }
            //BtnPur01_Edit(sender, e);
            //string result = Pur01_Edit();
            if (String.IsNullOrEmpty(result))
            {
                result = Pur_Edit();
            }
            LoadPur();
            LoadDataPur01();
            FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Error);
            //FineUI.Alert.ShowInParent("核准成功", FineUI.MessageBoxIcon.Information);
        }
        /// <summary>
        /// 作废按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnPur00_Cancel(Object sender, EventArgs e)
        {
            string Pur00_ID = tbxPurchase_ID.Text.ToString();
            var model = Purchase00.SingleOrDefault(x => x.Purchase_ID == Pur00_ID);
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
            var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
            model.MOD_DATETIME = DateTime.Now;
            model.LAST_UPDATE = DateTime.Now;
            model.MOD_USER_ID = OlUser.Manager_LoginName;
            string result = "";
            try
            {
                Purchase00Bll.GetInstence().Save(this, model);
            }
            catch (Exception err)
            {
                result = err.Message;
            }
            //BtnPur01_Edit(sender, e);
            //string result = Pur01_Edit();
            if (String.IsNullOrEmpty(result))
            {
                result = Pur_Edit();
            }
            LoadPur();
            LoadDataPur01();
            FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Error);
            //FineUI.Alert.ShowInParent("核准成功", FineUI.MessageBoxIcon.Information);
        }
        /// <summary>
        /// 采购主表保存
        /// </summary>
        /// <returns></returns>
        public string Pur_Save()
        {
            #region 校验数据
            string _SHOP_ID = ddlSHOP_NAME.SelectedValue;
            if (String.IsNullOrEmpty(_SHOP_ID))
            {
                //FineUI.Alert.ShowInParent("分店编码不允许为空", FineUI.MessageBoxIcon.Error);
                return "分店编码不允许为空";
            }
            //string _EXPECT_DATE = dpAPP_DATETIME.SelectedDate.ToString();
            //if (dpAPP_DATETIME.SelectedDate < DateTime.Now)
            //{
            //    //FineUI.Alert.ShowInParent("期望日期不能小于当前时间", FineUI.MessageBoxIcon.Error);
            //    return "期望日期不能小于当前时间";
            //}

            string _SUP_ID = ddlSHOP_NAME.SelectedValue;
            if (String.IsNullOrEmpty(_SUP_ID))
            {
                //FineUI.Alert.ShowInParent("厂商不能为空", FineUI.MessageBoxIcon.Error);
                return "厂商不能为空";
            }

            #endregion

            DataTable dt = null;
            dt = (DataTable)SPs.Get_Purchase00_SEED(_SHOP_ID).ExecuteDataTable();
            string _Pur00_id = tbxPurchase_ID.Text;
            var model = Purchase00.SingleOrDefault(x => x.Purchase_ID == _Pur00_id);
            if (model != null)
            {
                //FineUI.Alert.ShowInParent("采购单号已存在不允许添加", FineUI.MessageBoxIcon.Error);
                return "采购单号已存在不允许添加";
            }
            else
            {
                try
                {
                    var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                    model = new Purchase00();
                    model.Purchase_ID = dt.Rows[0]["PLANE_ID"].ToString();
                    model.SHOP_ID = _SHOP_ID;
                    model.STATUS = 1;
                    model.INPUT_DATE = DateTime.Now;
                    model.EXPECT_DATE = ConvertHelper.StringToDatetime(dpEXPECT_DATE.SelectedDate.ToString());
                    model.SUP_ID = ddlSUP_NAME.SelectedValue.ToString();
                    model.PAY_STATUS = ConvertHelper.Cint(ddlPAY_STATUS.SelectedValue);
                    model.USER_ID = OlUser.Manager_LoginName;
                    model.APP_USER = "";
                    model.APP_DATETIME = ConvertHelper.StringToDatetime("1900-01-01 00:00:00");
                    model.TOT_AMOUNT = 0;
                    model.TOT_TAX = ConvertHelper.StringToDecimal(numTOT_QTY.Text);
                    model.TOT_QTY = 0;
                    model.PRE_PAY = 0;
                    model.PRE_PAY_ID = "";
                    model.EXPORTED = 0;
                    model.EXPORTED_ID = "";
                    model.LOCKED = 0;
                    model.CRT_DATETIME = ConvertHelper.StringToDatetime(DateTime.Now.ToLongDateString());
                    model.CRT_USER_ID = OlUser.Manager_LoginName;
                    model.MOD_DATETIME = ConvertHelper.StringToDatetime(DateTime.Now.ToLongDateString());
                    model.MOD_USER_ID = OlUser.Manager_LoginName;
                    model.LAST_UPDATE = ConvertHelper.StringToDatetime(DateTime.Now.ToLongDateString());
                    model.SetIsNew(true);
                    Purchase00Bll.GetInstence().Save(this, model);
                    LoackPur01();
                    //FineUI.Alert.ShowInParent("保存成功", FineUI.MessageBoxIcon.Error);
                    return "保存成功";
                }
                catch (Exception err)
                {
                    return err.Message;
                }
            }
        }

        /// <summary>
        /// 采购主表更新
        /// </summary>
        /// <returns></returns>
        public string Pur01_Edit()
        {
            #region 校验数据
            string _SHOP_ID = ddlSHOP_NAME.SelectedValue;
            if (String.IsNullOrEmpty(_SHOP_ID))
            {
                //FineUI.Alert.ShowInParent("分店编码不允许为空", FineUI.MessageBoxIcon.Error);
                return "分店编码不允许为空";
            }
            //string _EXPECT_DATE = dpAPP_DATETIME.SelectedDate.ToString();
            //if (dpAPP_DATETIME.SelectedDate < DateTime.Now)
            //{
            //    //FineUI.Alert.ShowInParent("期望日期不能小于当前时间", FineUI.MessageBoxIcon.Error);
            //    return "期望日期不能小于当前时间";
            //}

            string _SUP_ID = ddlSHOP_NAME.SelectedValue;
            if (String.IsNullOrEmpty(_SUP_ID))
            {
                //FineUI.Alert.ShowInParent("厂商不能为空", FineUI.MessageBoxIcon.Error);
                return "厂商不能为空";
            }

            #endregion

            string _Pur00_id = tbxPurchase_ID.Text;
            var model = Purchase00.SingleOrDefault(x => x.Purchase_ID == _Pur00_id);
            if (model == null)
            {
                //FineUI.Alert.ShowInParent("采购单号已存在不允许添加", FineUI.MessageBoxIcon.Error);
                return "该订单不存在";
            }
            else
            {
                try
                {
                    var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                    //model = new Purchase00();

                    model.SHOP_ID = _SHOP_ID;
                    model.STATUS = 1;
                    model.INPUT_DATE = DateTime.Now;
                    model.EXPECT_DATE = ConvertHelper.StringToDatetime(dpEXPECT_DATE.SelectedDate.ToString());
                    model.SUP_ID = ddlSUP_NAME.SelectedValue.ToString();
                    model.PAY_STATUS = ConvertHelper.Cint(ddlPAY_STATUS.SelectedValue);
                    model.USER_ID = OlUser.Manager_LoginName;
                    model.APP_USER = "";
                    model.APP_DATETIME = ConvertHelper.StringToDatetime("1900-01-01 00:00:00");
                    model.TOT_AMOUNT = 0;
                    model.TOT_TAX = ConvertHelper.StringToDecimal(numTOT_QTY.Text);
                    model.TOT_QTY = 0;
                    model.PRE_PAY = 0;
                    model.PRE_PAY_ID = "";
                    model.EXPORTED = 0;
                    model.EXPORTED_ID = "";
                    model.LOCKED = 0;
                    model.CRT_DATETIME = ConvertHelper.StringToDatetime(DateTime.Now.ToLongDateString());
                    model.CRT_USER_ID = OlUser.Manager_LoginName;
                    model.MOD_DATETIME = ConvertHelper.StringToDatetime(DateTime.Now.ToLongDateString());
                    model.MOD_USER_ID = OlUser.Manager_LoginName;
                    model.LAST_UPDATE = ConvertHelper.StringToDatetime(DateTime.Now.ToLongDateString());
                    model.SetIsNew(false);
                    Purchase00Bll.GetInstence().Save(this, model);
                    LoackPur01();
                    //FineUI.Alert.ShowInParent("保存成功", FineUI.MessageBoxIcon.Error);
                    return "";
                }
                catch (Exception err)
                {
                    return err.Message;
                }
            }
        }
        /// <summary>
        /// 采购明细更新数据更新
        /// </summary>
        /// <returns></returns>
        public string Pur_Edit()
        {
            string Pur_status = ddlStatus.SelectedValue;
            JArray pJson = Grid2.GetMergedData();
            string result = "";

            for (int i = 0; i < pJson.Count; i++)
            {
                try
                {
                    int _id = ConvertHelper.Cint(pJson[i]["values"]["Id01"].ToString());
                    var model = new Purchase01(x => x.Id == _id);
                    model.SHOP_ID = pJson[i]["values"]["SHOP_ID01"].ToString();
                    model.Purchase_ID = pJson[i]["values"]["Purchase_ID01"].ToString();
                    model.SNo = ConvertHelper.Cint(pJson[i]["values"]["SNo01"].ToString());
                    model.PROD_ID = pJson[i]["values"]["PROD_ID01"].ToString();
                    model.QUANTITY = ConvertHelper.StringToDecimal(pJson[i]["values"]["QUANTITY01"].ToString());
                    model.STD_UNIT = pJson[i]["values"]["STD_UNIT01"].ToString();
                    model.STD_CONVERT = ConvertHelper.Cint(pJson[i]["values"]["STD_CONVERT01"].ToString());
                    model.STD_QUAN = ConvertHelper.StringToDecimal(pJson[i]["values"]["STD_QUAN01"].ToString());
                    model.STD_PRICE = ConvertHelper.StringToDecimal(pJson[i]["values"]["STD_PRICE01"].ToString());
                    model.Tax = ConvertHelper.StringToDecimal(pJson[i]["values"]["Tax01"].ToString());
                    model.QUAN1 = ConvertHelper.StringToDecimal(pJson[i]["values"]["QUAN101"].ToString());
                    model.QUAN2 = ConvertHelper.StringToDecimal(pJson[i]["values"]["QUAN201"].ToString());
                    model.Item_DISC_Amt = ConvertHelper.StringToDecimal(pJson[i]["values"]["Item_DISC_Amt01"].ToString());
                    model.MEMO = pJson[i]["values"]["MEMO"].ToString();
                    Purchase01Bll.GetInstence().Save(this, model);
                }
                catch (Exception err)
                {
                    result = result = err.Message + Environment.NewLine;
                    return result;
                }
            }
            //if (!String.IsNullOrEmpty(result))
            //{
            //    FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
            //}
            //else
            //{
            //    string _shop_id = ddlSHOP_NAME.SelectedValue;
            //    string _Pur_id = tbxPurchase_ID.Text;

            //    DataSet ds = (DataSet)SPs.Update_Purchase00_TOT(_shop_id, _Pur_id).ExecuteDataSet();
            //    //int _id = ConvertHelper.Cint0(GridViewHelper.GetSelectedKey(Grid1, true));
            //    LoadPur();
            //    FineUI.Alert.ShowInParent("保存成功", FineUI.MessageBoxIcon.Information);

            //}
            if (String.IsNullOrEmpty(result))
            {
                string _shop_id = ddlSHOP_NAME.SelectedValue;
                string _Pur_id = tbxPurchase_ID.Text;

                DataSet ds = (DataSet)SPs.Update_Purchase00_TOT(_shop_id, _Pur_id).ExecuteDataSet();
                //int _id = ConvertHelper.Cint0(GridViewHelper.GetSelectedKey(Grid1, true));
                LoadPur();
                result = "保存成功";
                //FineUI.Alert.ShowInParent("保存成功", FineUI.MessageBoxIcon.Information);
            }
            //LoadDataPur01();
            return result;
        }

        #endregion


        #region WINDOW3相关事件
        /// <summary>
        /// WINDOW3 关闭事件
        /// </summary>
        public void Window3_Close()
        {
            FineUI.Panel P_search = Window3.FindControl("PanelGrid4").FindControl("Panel_Search") as FineUI.Panel;
            P_search.Hidden = true;
            FineUI.Button B_BtnSearchCon = Window3.FindControl("PanelGrid4").FindControl("tool_btn").FindControl("BtnSearchCon") as FineUI.Button;
            FineUI.Button B_BtnAddCon = Window3.FindControl("PanelGrid4").FindControl("tool_btn").FindControl("BtnAddCon") as FineUI.Button;
            B_BtnSearchCon.Hidden = true;
            B_BtnAddCon.Hidden = true;
            FineUI.Button B_BtnEditCon = Window3.FindControl("PanelGrid4").FindControl("tool_btn").FindControl("BtnEditCon") as FineUI.Button;
            B_BtnEditCon.Hidden = true;
            Window3.Hidden = true;
        }
        #endregion
        /// <summary>
        /// 查询按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnSearchCon(Object sender, EventArgs e)
        {
            FineUI.Button B_BtnEditCon = Window3.FindControl("PanelGrid4").FindControl("tool_btn").FindControl("BtnEditCon") as FineUI.Button;
            B_BtnEditCon.Hidden = false;
            Window3.Hidden = false;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonPRODSearch_Click(object sender, EventArgs e)
        {

            conditionList = null;
            //conditionList = new List<ConditionFun.SqlqueryCondition>();
            //绑定Grid表格
            FineUI.Grid Grid4 = Window3.FindControl("PanelGrid4").FindControl("Grid4") as FineUI.Grid;
            V_Product01_PRCAREABll.GetInstence().BindGrid(Grid4, 0, 0, InquiryConditionProduct(), sortList);
        }
        /// <summary>
        /// 加载下拉列表
        /// </summary>
        public void LoadList()
        {
            FineUI.DropDownList ccPROD_KIND = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_KIND") as FineUI.DropDownList;
            PROD_KINDBll.GetInstence().BandDropDownListShowKind(this, ccPROD_KIND);
            FineUI.DropDownList ccPROD_DEP = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_DEP") as FineUI.DropDownList;
            PROD_DEPBll.GetInstence().BandDropDownListShowDep(this, ccPROD_DEP);
            FineUI.DropDownList ccPROD_CATE = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_CATE") as FineUI.DropDownList;
            PROD_CateBll.GetInstence().BandDropDownListShowCate(this, ccPROD_CATE);
        }
        /// <summary>
        /// GRID3检索的判断条件
        /// </summary>
        /// <returns></returns>
        private List<ConditionFun.SqlqueryCondition> InquiryConditionProduct()
        {
            string _shop_id = ddlSHOP_NAME.SelectedValue;
            var model = new SHOP00(x => x.SHOP_ID == _shop_id);
            List<ConditionFun.SqlqueryCondition> conditionProdduct00List = new List<ConditionFun.SqlqueryCondition>();
            bool sFlag = true;
            if (!String.IsNullOrEmpty(model.SHOP_Price_Area))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), V_Product01_PRCAREATable.PRCAREA_ID, Comparison.Like, model.SHOP_Price_Area, false, false));
                sFlag = false;
            }
            //conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "1", Comparison.Equals, "1", false, false));

            FineUI.TextBox cPROD_ID = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_ID") as FineUI.TextBox;
            var _PROD_ID = cPROD_ID.Text;
            if (!String.IsNullOrEmpty(cPROD_ID.Text))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), V_Product01_PRCAREATable.PROD_ID, Comparison.Like, "%" + _PROD_ID + "%", false, false));
                sFlag = false;
            }

            FineUI.TextBox cPROD_NAME = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_NAME") as FineUI.TextBox;
            var _PROD_NAME = cPROD_NAME.Text;
            if (!String.IsNullOrEmpty(_PROD_NAME))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), V_Product01_PRCAREATable.PROD_NAME1, Comparison.Like, "%" + _PROD_NAME + "%", false, false));
                sFlag = false;
            }
            FineUI.TextBox cPROD_NAME_SPELLING = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_NAME_SPELLING") as FineUI.TextBox;
            var _PROD_NAME_SPELLING = cPROD_NAME_SPELLING.Text;
            if (!String.IsNullOrEmpty(_PROD_NAME_SPELLING))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), V_Product01_PRCAREATable.PROD_NAME1_SPELLING, Comparison.Like, "%" + _PROD_NAME_SPELLING + "%", false, false));
                sFlag = false;
            }
            FineUI.DropDownList cPROD_KIND = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_KIND") as FineUI.DropDownList;
            var _cPROD_KIND = cPROD_KIND.SelectedValue;
            if (!String.IsNullOrEmpty(_cPROD_KIND) && _cPROD_KIND != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), V_Product01_PRCAREATable.PROD_KIND, Comparison.Equals, _cPROD_KIND, false, false));
                sFlag = false;
            }

            FineUI.DropDownList cPROD_DEP = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_DEP") as FineUI.DropDownList;
            var _PROD_DEP = cPROD_DEP.SelectedValue;
            if (!String.IsNullOrEmpty(_PROD_NAME) && _PROD_DEP != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), V_Product01_PRCAREATable.PROD_DEP, Comparison.Equals, _PROD_DEP, false, false));
                sFlag = false;
            }
            FineUI.DropDownList cPROD_CATE = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_CATE") as FineUI.DropDownList;
            var _PROD_CATE = cPROD_CATE.SelectedValue;
            if (!String.IsNullOrEmpty(_PROD_CATE) && _PROD_CATE != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), V_Product01_PRCAREATable.PROD_CATE, Comparison.Equals, _PROD_CATE, false, false));
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
        /// 添加商品，采购单位未完成，价格取值未完成，税额未完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonPRODAdd_Click(object sender, EventArgs e)
        {
            FineUI.Grid Grid4 = Window3.FindControl("PanelGrid4").FindControl("Grid4") as FineUI.Grid;

            int[] selections = Grid4.SelectedRowIndexArray;
            string _Pur00_ID = hidPurchase_ID.Text;
            string _Shop_ID = ddlSHOP_NAME.SelectedValue;
            string _Shop_Name = ddlSHOP_NAME.SelectedText;
            string result = "";
            var m_Shop = new SHOP00(x => x.SHOP_ID == _Shop_ID);
            string _priceArea_id = m_Shop.SHOP_Price_Area;
            if (!String.IsNullOrEmpty(_Pur00_ID))
            {
                foreach (int i in selections)
                {
                    string _Prod_ID = Grid4.DataKeys[i][0].ToString();
                    string _shop_id = ddlSHOP_NAME.SelectedValue;
                    var model = new V_Product01_PRCAREA(x => x.PROD_ID == _Prod_ID && x.PRCAREA_ID == _priceArea_id);
                    int rowCount = Grid2.Rows.Count;
                    JObject deObject = new JObject();
                    deObject.Add("Id01", "0");
                    deObject.Add("SHOP_ID01", _Shop_ID);
                    deObject.Add("SHOP_NAME01", _Shop_Name);
                    deObject.Add("Purchase_ID01", _Pur00_ID);
                    deObject.Add("SNo01", rowCount + 1);
                    deObject.Add("PROD_ID01", _Prod_ID);
                    deObject.Add("PROD_NAME01", model.PROD_NAME1);
                    deObject.Add("QUANTITY01", model.ORDER_QUAN);
                    deObject.Add("STD_UNIT01", model.Purchase_UNIT);
                    deObject.Add("STD_CONVERT01", model.PROD_CONVERT1);
                    deObject.Add("STD_QUAN01", model.Purchase_QUAN);
                    deObject.Add("STD_PRICE01", model.COST);
                    deObject.Add("Tax01", 0);
                    deObject.Add("QUAN101", 0);
                    deObject.Add("QUAN201", 0);
                    deObject.Add("Item_DISC_Amt01", 0);
                    deObject.Add("MEMO", "");
                    //var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                    //string lgname = OlUser.Manager_LoginName;
                    //deObject.Add("CRT_USER_ID1", lgname);
                    //deObject.Add("CRT_DATETIME1", DateTime.Now.ToString());
                    //deObject.Add("MOD_USER_ID1", OlUser.Manager_LoginName);
                    //deObject.Add("MOD_DATETIME1", DateTime.Now.ToString());
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
    }



}