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
    public partial class OUT00List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //123
                DatePicker1.SelectedDate = DateTime.Now.AddMonths(-10);
                DatePicker2.SelectedDate = DateTime.Now.AddDays(1);
                LoadList();
                LoadData();
                OrderStatus(new OUT00());
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
            SHOP00Bll.GetInstence().GetShopList(this,model.SHOP_ID, ddlIN_SHOP);
            STOCKBll.GetInstence().BandOnlineUserStock(this,model.SHOP_ID,ddlSTOCK_ID);

        }

        /// <summary>
        /// 根据当前账户，获取所属门店信息
        /// </summary>
        /// <returns></returns>
        public SHOP00 GetOnlineUserShop()
        {
            var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
            var shop_id = OlUser.SHOP_ID;
            var model = new SHOP00(x=>x.SHOP_ID==shop_id);
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
            V_OUT00_SHOP00Bll.GetInstence().BindGrid(Grid1, 0, 0, InquiryCondition(), sortList);
            //TAKEIN10Bll.GetInstence().BindOrderGrid(st, et, type, Grid1);
        }

        /// <summary>
        /// 条件
        /// </summary>
        /// <returns></returns>
        private List<ConditionFun.SqlqueryCondition> InquiryCondition()
        {
            List<ConditionFun.SqlqueryCondition> conditionList = new List<ConditionFun.SqlqueryCondition>();
            var model = GetOnlineUserShop();
            string st = DatePicker1.Text;
            string et = DatePicker2.Text;
            //string sn = ddlSHOP_NAME1.SelectedValue;
            string DateType = ddrDataType.SelectedValue;

            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, OUT00Table.SHOP_ID, Comparison.Equals, model.SHOP_ID, false, false));
            if (DateType.Equals("1"))
            {
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, OUT00Table.INPUT_DATE, Comparison.LessOrEquals, et, false, false));
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, OUT00Table.INPUT_DATE, Comparison.GreaterOrEquals, st, false, false));
            }
            else
            {
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, OUT00Table.APP_DATETIME, Comparison.LessOrEquals, et, false, false));
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, OUT00Table.APP_DATETIME, Comparison.GreaterOrEquals, st, false, false));
            }

            //if (!sn.Equals("0") && !String.IsNullOrEmpty(sn))
            //{
            //    conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, OUT00Table.SHOP_ID, Comparison.Equals, sn, false, false));
            //}

            return conditionList;
        }


        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {
            bll = OUT00Bll.GetInstence();
            //throw new NotImplementedException();
        }

        public override void SingleClick(GridRowClickEventArgs e)
        {
            string _tbxOUT_ID = GridViewHelper.GetSelectedKey(Grid1, true);
            tbxOUT_ID.Text = _tbxOUT_ID;
            
            LoadMAIN();
            LoadDETAIL();
            //Alert.ShowInTop(String.Format("你点击了第 {0} 行（单击）", e.RowIndex + 1));
        }


        /// <summary>
        /// 加载主表明细数据
        /// </summary>
        public void LoadMAIN()
        {
            string _tbxOUT_ID = tbxOUT_ID.Text;
            if (!String.IsNullOrEmpty(_tbxOUT_ID))
            {
                var model = new OUT00(x => x.OUT_ID == _tbxOUT_ID);
                ddlSHOP_NAME.SelectedValue = model.SHOP_ID;
                dpINPUT_DATE.SelectedDate = model.INPUT_DATE;
                ddlStatus.SelectedValue = model.STATUS.ToString();
                ddlIN_SHOP.SelectedValue = model.IN_SHOP;
                ddlSTOCK_ID.SelectedValue = model.STOCK_ID;
                tbxUSER_ID.Text = model.USER_ID;
                tbxAPP_USER.Text = model.APP_USER;
                dpAPP_DATETIME.SelectedDate = model.APP_DATETIME;
                dpEXPECT_DATE.SelectedDate = model.EXPECT_DATE;

                cbExported.Checked = model.Exported == 1 ? true : false;
                tbxExported_ID.Text = model.Exported_ID;
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
                tbxLAST_UPDATE.Text = model.LAST_UPDATE.ToString();
                OrderStatus(model);
            }
        }

        public void LoadDETAIL()
        {
            string _tbxOUT_ID = tbxOUT_ID.Text;
            if (!String.IsNullOrEmpty(_tbxOUT_ID))
            {
                Grid2.DataSource = null;
                Grid2.DataBind();
                V_OUT01_PRODUCT00Bll.GetInstence().BindGrid(Grid2, 0, 0, InquiryConditionDetail(), new List<string> { "ID"});
                
            }
        }



        private List<ConditionFun.SqlqueryCondition> InquiryConditionDetail()
        {
            string _shop_id = ddlSHOP_NAME.SelectedValue;
            string _tbxOUT_ID = tbxOUT_ID.Text;
            List<ConditionFun.SqlqueryCondition> conditiondetail = new List<ConditionFun.SqlqueryCondition>();
            var model = new SHOP00(x => x.SHOP_ID == _shop_id);
            string _PRCAREA_ID = model.SHOP_Price_Area;
            //condiList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, V_Purchase01_PRODUCT00Table.SHOP_ID, Comparison.Equals, _shop_id, false, false));
            conditiondetail.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, V_OUT01_PRODUCT00Table.OUT_ID, Comparison.Equals, _tbxOUT_ID, false, false));
            conditiondetail.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, V_OUT01_PRODUCT00Table.PRCAREA_ID, Comparison.Equals, _PRCAREA_ID, false, false));
            return conditiondetail;
        }
        /// <summary>
        /// 状态位的判定
        /// </summary>
        /// <param name="status"></param>
        public void OrderStatus(OUT00 model)
        {
            OrderStatus2(model);
        }
        /// <summary>
        /// 判断出货订单是否已经引入要货单，如果已经引入，则子表按钮禁用
        /// </summary>
        /// <param name="model"></param>
        public void OrderStatus1(OUT00 model)
        {
            var _OUT_ID = model.OUT_ID;
            var model2 = new ORDER00(x => x.EXPORTED_ID == _OUT_ID);
            if (model2.Id > 0)
            {
                Toolbar21111.Enabled = false;
                return;
            }
            else
            {
                Toolbar21111.Enabled = true;
                return;
            }
        }

        /// <summary>
        /// Grid2字段可编辑权限判定
        /// </summary>
        /// <param name="status"></param>
        public void Grid2ColumnEdit(int status)
        {
            //Grid2控件权限判定
            if (status == 1)
            {
                ddlSTD_TYPE01.Enabled = true;
                numSTD_QUAN.Enabled = true;
                numQUAN1.Enabled = true;
                numQUAN2.Enabled = true;
            }
            else
            {
                ddlSTD_TYPE01.Enabled = false;
                numSTD_QUAN.Enabled = false;
                numQUAN1.Enabled = false;
                numQUAN2.Enabled = false;
            }
        }
        /// <summary>
        /// 订单为存档，核准，作废的状态判定
        /// </summary>
        /// <param name="model"></param>
        public void OrderStatus2(OUT00 model)
        {
            //如果该订单已被其他订单引入，则无法进行任何操作
            if (model.Exported == 1)
            {
                Grid2ColumnEdit(0);
                ButtonSave.Enabled = false;
                ButtonEdit.Enabled = false;
                ButtonCheck.Text = "反核准";
                ButtonYR.Enabled = false;
                ButtonCancel.Text = "作废";
                ButtonCancel.Enabled = false;
                ButtonCheck.Enabled = false;
                Toolbar21111.Enabled = false;
                return;
            }

            Grid2ColumnEdit(model.STATUS);

            //1:存档 2：核准 3：作废 4：已引入
            //新增：ButtonAdd 保存：ButtonSave 更新：ButtonUpdate 核准：ButtonCheck 作废：ButtonCancel
            //Pur02新增：ButtonPur02Add
            switch (model.STATUS)
            {
                case 1:
                    OrderStatus1(model);
                    ButtonSave.Enabled = false;
                    ButtonEdit.Enabled = true;
                    ButtonCancel.Enabled = true;
                    ButtonCheck.Enabled = true;
                    ButtonYR.Enabled = true;
                    ButtonCheck.Text = "核准";
                    ButtonCancel.Text = "作废"; break;
                case 2:
                    ButtonSave.Enabled = false;
                    ButtonEdit.Enabled = false;
                    ButtonCheck.Text = "反核准";
                    ButtonYR.Enabled = false;
                    ButtonCancel.Text = "作废";
                    ButtonCancel.Enabled = false;
                    ButtonCheck.Enabled = true;
                    Toolbar21111.Enabled = false;
                    break;
                case 3:
                    ButtonSave.Enabled = false;
                    ButtonEdit.Enabled = false;
                    ButtonCheck.Text = "核准";
                    ButtonYR.Enabled = false;
                    ButtonCheck.Enabled = false;
                    ButtonCancel.Text = "取消作废";
                    ButtonCancel.Enabled = true;
                    Toolbar21111.Enabled = false;
                    break;
                case 4:
                    ButtonSave.Enabled = false;
                    ButtonEdit.Enabled = false;
                    ButtonCheck.Text = "反核准";
                    ButtonYR.Enabled = false;
                    ButtonCancel.Text = "作废";
                    ButtonCancel.Enabled = false;
                    ButtonCheck.Enabled = false;
                    Toolbar21111.Enabled = false; break;
                case 5:
                    ButtonSave.Enabled = false;
                    ButtonEdit.Enabled = false;
                    ButtonCancel.Enabled = false;
                    ButtonCheck.Enabled = false;
                    ButtonYR.Enabled = false;
                    Grid2.Enabled = false;
                    Grid2.AllowCellEditing = false;
                    Toolbar21111.Enabled = false; break;
                default:
                    ButtonSave.Enabled = false;
                    ButtonEdit.Enabled = false;
                    ButtonCheck.Text = "核准";
                    ButtonYR.Enabled = false;
                    ButtonCancel.Text = "作废";
                    ButtonCancel.Enabled = false;
                    ButtonCheck.Enabled = false;
                    Toolbar21111.Enabled = false; break;
            }

            //判断子表是否已经产生数据，数据已经产生，则无法引入
            var model2 = new OUT01(x => x.OUT_ID == model.OUT_ID);
            
            if (!(model2 == null || String.IsNullOrEmpty(model2.OUT_ID)))
            {
                ButtonYR.Enabled = false;
            }
        }

        /// <summary>
        /// 新增数据，将数据清空，并可编辑
        /// </summary>
        public void BtnAdd_Click(Object sender, EventArgs e)
        {
            ClearConten();
        }

        public void ClearConten()
        {
            OrderStatus(new OUT00());
            ButtonSave.Enabled = true;
            tbxOUT_ID.Text = "";
            ddlSHOP_NAME.Enabled = true;
            ddlSHOP_NAME.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            dpINPUT_DATE.SelectedDate = DateTime.Now;

            ddlIN_SHOP.Enabled = true;
            ddlIN_SHOP.SelectedIndex = 0;
            ddlSTOCK_ID.Enabled = true;
            ddlSTOCK_ID.SelectedIndex = 0;
            tbxUSER_ID.Text = "";
            tbxAPP_USER.Text = "";
            dpAPP_DATETIME.SelectedDate = DateTime.Parse("1900-01-01 00:00:00");
            dpEXPECT_DATE.SelectedDate = DateTime.Now;

            cbExported.Checked = false;
            tbxExported_ID.Text = "";
            tbxRELATE_ID.Text = "";
            tbxMemo.Text = "";
            ckLOCKED.Checked = false;


            tbxCRT_DATETIME.Text = "";
            tbxCRT_USER_ID.Text = "";
            tbxMOD_DATETIME.Text = "";
            tbxMOD_USER_ID.Text = "";
            tbxLAST_UPDATE.Text = "";

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
            string _shopid = ddlIN_SHOP.SelectedValue;
            string _stock_id = ddlSTOCK_ID.SelectedValue;
            if (string.IsNullOrEmpty(_shopid))
            {
                FineUI.Alert.ShowInParent("到货分店不能为空", FineUI.MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(_stock_id))
            {
                FineUI.Alert.ShowInParent("到货分店不能为空", FineUI.MessageBoxIcon.Information);
                return;
            }
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
            //ClearConten();
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
            //ClearConten();
            //LoadMAIN();
            //LoadDETAIL();
        }

        /// <summary>
        /// 核准按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Btn_MainCheck(Object sender, EventArgs e)
        {
            string _OUT_ID = tbxOUT_ID.Text.ToString();
            var model = OUT00.SingleOrDefault(x => x.OUT_ID == _OUT_ID);
            int out_status = model.STATUS;
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

            DataTable stockDatatable = (DataTable)SPs.GET_OUT00_STOCK_INFO(_OUT_ID).ExecuteDataTable();
            if (stockDatatable.Rows.Count > 0)
            {
                FineUI.Alert.ShowInParent("库存不足,不允许核准", FineUI.MessageBoxIcon.Information);
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

            string result = DetailEdit();
            if (String.IsNullOrEmpty(result))
            {
                result = MAINEdit();
            }

            if (String.IsNullOrEmpty(result))
            {
                //dsCom = (DataSet)SPs.Get_Purchase00(st, et, type).ExecuteDataSet();
                //计算库存
                if (out_status == 2)
                {
                    SPs.Update_out00_stock01(_OUT_ID).Execute();
                }
                else
                {
                    SPs.Update_out00_stock01_cancel(_OUT_ID).Execute();
                }
            }

            if (!String.IsNullOrEmpty(result))
            {
                FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Error);
            }
            else
            {
                string alterMssage = ButtonCheck.Text;
                if (alterMssage == "反核准")
                {
                    FineUI.Alert.ShowInParent("核准成功", FineUI.MessageBoxIcon.Error);
                }
                else
                {
                    FineUI.Alert.ShowInParent("取消核准成功", FineUI.MessageBoxIcon.Error);
                }
            }



            //LoadMAIN();
            //LoadDETAIL();
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
            string _OUT_ID = tbxOUT_ID.Text.ToString();
            var model = OUT00.SingleOrDefault(x => x.OUT_ID == _OUT_ID);
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
                string alterMssage = ButtonCancel.Text;
                if (alterMssage == "取消作废")
                {
                    FineUI.Alert.ShowInParent("作废成功", FineUI.MessageBoxIcon.Error);
                }
                else
                {
                    FineUI.Alert.ShowInParent("取消作废成功", FineUI.MessageBoxIcon.Error);
                }
            }

            //LoadMAIN();
            //LoadDETAIL();
            //FineUI.Alert.ShowInParent("核准成功", FineUI.MessageBoxIcon.Information);
        }

        /// <summary>
        /// 主表保存
        /// </summary>
        /// <returns></returns>
        public string MAINEdit()
        {
            string _OUT_ID = tbxOUT_ID.Text;
            try
            {
                var model = new OUT00(x => x.OUT_ID == _OUT_ID);
                var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                string _SHOP_ID = ddlSHOP_NAME.SelectedValue;
                if (String.IsNullOrEmpty(_OUT_ID))
                {
                    model.SetIsNew(true);
                    model.CRT_DATETIME = DateTime.Now;
                    model.CRT_USER_ID = OlUser.Manager_LoginName;
                    DataTable dt = new DataTable();
                    dt = (DataTable)SPs.Get_ORDER_SEED(_SHOP_ID, "OUT00").ExecuteDataTable();
                    _OUT_ID = dt.Rows[0]["PLANE_ID"].ToString();
                    tbxOUT_ID.Text = _OUT_ID;
                    //var model = Purchase00.SingleOrDefault(x => x.Purchase_ID == _Pur00_id);

                }
                model.SHOP_ID = _SHOP_ID;
                model.OUT_ID = _OUT_ID.ToString();
                model.STATUS = ConvertHelper.Cint(ddlStatus.SelectedValue);
                model.INPUT_DATE = ConvertHelper.StringToDatetime(dpINPUT_DATE.SelectedDate.ToString());

                model.IN_SHOP = ddlIN_SHOP.SelectedValue;
                model.STOCK_ID = ddlSTOCK_ID.SelectedValue;
                model.USER_ID = OlUser.Manager_LoginName;
                model.APP_USER = OlUser.Manager_LoginName;
                model.APP_DATETIME = DateTime.Now;
                model.EXPECT_DATE = ConvertHelper.StringToDatetime(dpEXPECT_DATE.SelectedDate.ToString());

                model.Exported = ConvertHelper.StringToByte(cbExported.Checked ? "1" : "0");
                model.Exported_ID = tbxExported_ID.Text;
                string _RELATE_ID= tbxRELATE_ID.Text;
                model.RELATE_ID = _RELATE_ID;
                if (!String.IsNullOrEmpty(_RELATE_ID))
                {
                    var modelOrder = new ORDER00(x => x.ORDER_ID == _RELATE_ID);
                    modelOrder.EXPORTED =1;
                    modelOrder.Save();
                }
                model.Memo = tbxMemo.Text;
                model.LOCKED = ConvertHelper.StringToByte(ckLOCKED.Checked ? "1" : "0");

                model.MOD_DATETIME = DateTime.Now;
                model.MOD_USER_ID = OlUser.Manager_LoginName;
                model.LAST_UPDATE = DateTime.Now;
                model.Trans_STATUS = 0;
                OUT00Bll.GetInstence().Save(this, model);
                LoadMAIN();
            }
            catch (Exception err)
            {
                return err.Message;
            }
            return "";
        }

        /// <summary>
        /// 子表保存
        /// </summary>
        /// <returns></returns>
        public string DetailEdit()
        {
            JArray jarr = Grid2.GetMergedData();
            var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
            string result = "";
            int n = 0;
            for (int i = 0; i < jarr.Count; i++)
            {
                try
                {
                    var model2 = new OUT01();
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
                    if (!String.IsNullOrEmpty(jarr[i]["values"]["OUT_ID01"].ToString()))
                    {
                        model2.OUT_ID = jarr[i]["values"]["OUT_ID01"].ToString();
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
                    OUT01Bll.GetInstence().Save(this, model2);
                }
                catch (Exception err)
                {
                    n++;
                    result = "明细保存失败" + n + "条";
                }
            }
            LoadDETAIL();
            return result;
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
        /// 明细删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btn_DetailDelete(Object sender, EventArgs e)
        {
            string[] eCell = Grid2.SelectedCell;
            if (eCell == null)
            {
                FineUI.Alert.ShowInParent("请先选中一个删除项", FineUI.MessageBoxIcon.Information);
                return;
            }
            string a = Grid2.SelectedRowID;
            int iii = Grid2.SelectedRowIndex;

            JArray upJson = Grid2.GetMergedData();
            DataTable da = new DataTable();
            for (int i = 0; i < upJson.Count; i++)
            {

                if (upJson[i]["status"].ToString() != "newadded" && upJson[i]["id"].ToString() == eCell[0].ToString())
                {
                    int _id = ConvertHelper.Cint(upJson[i]["values"]["Id01"].ToString());
                    //FineUI.Alert.ShowInParent(_id.ToString(), FineUI.MessageBoxIcon.Information);
                    Grid2.DeleteSelectedRows();
                    OUT01Bll.GetInstence().Delete(this, _id);
                    //hidORDDEP_ID.Text = "";
                    break;
                }
                else if (upJson[i]["status"].ToString() == "newadded" && upJson[i]["id"].ToString() == eCell[0].ToString())
                {
                    Grid2.DeleteSelectedRows();
                    //hidORDDEP_ID.Text = "";
                    break;
                }
            }
        }

        /// <summary>
        /// 商品查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonPRODSearch_Click(object sender, EventArgs e)
        {
            string _shop_id = ddlSHOP_NAME.SelectedValue;
            string _stock_id = ddlSTOCK_ID.SelectedValue;
            if (String.IsNullOrEmpty(_shop_id))
            {
                FineUI.Alert.ShowInParent("到货商店未选择", FineUI.MessageBoxIcon.Information);
                return;
            }

            if (String.IsNullOrEmpty(_stock_id))
            {
                FineUI.Alert.ShowInParent("仓库未选择", FineUI.MessageBoxIcon.Information);
                return;
            }

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
            string _shop_id = ddlSHOP_NAME.SelectedValue;
            string _stock_id = ddlSTOCK_ID.SelectedValue;
            var model = new SHOP00(x => x.SHOP_ID == _shop_id);
            List<ConditionFun.SqlqueryCondition> conditionProdduct00List = new List<ConditionFun.SqlqueryCondition>();
            bool sFlag = true;
            conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, V_STOCK01_PRODUCT01Table.PRCAREA_ID, Comparison.Like, model.SHOP_Price_Area, false, false));
            conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, V_STOCK01_PRODUCT01Table.STOCK_ID, Comparison.Like, _stock_id, false, false));


            FineUI.TextBox cPROD_ID = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_ID") as FineUI.TextBox;
            var _PROD_ID = cPROD_ID.Text;
            if (!String.IsNullOrEmpty(cPROD_ID.Text))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, V_STOCK01_PRODUCT01Table.PROD_ID, Comparison.Like, "%" + _PROD_ID + "%", false, false));
                sFlag = false;
            }

            FineUI.TextBox cPROD_NAME = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_NAME") as FineUI.TextBox;
            var _PROD_NAME = cPROD_NAME.Text;
            if (!String.IsNullOrEmpty(_PROD_NAME))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, V_STOCK01_PRODUCT01Table.PROD_NAME1, Comparison.Like, "%" + _PROD_NAME + "%", false, false));
                sFlag = false;
            }
            FineUI.TextBox cPROD_NAME_SPELLING = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_NAME_SPELLING") as FineUI.TextBox;
            var _PROD_NAME_SPELLING = cPROD_NAME_SPELLING.Text;
            if (!String.IsNullOrEmpty(_PROD_NAME_SPELLING))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, V_STOCK01_PRODUCT01Table.PROD_NAME1_SPELLING, Comparison.Like, "%" + _PROD_NAME_SPELLING + "%", false, false));
                sFlag = false;
            }
            FineUI.DropDownList cPROD_KIND = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_KIND") as FineUI.DropDownList;
            var _cPROD_KIND = cPROD_KIND.SelectedValue;
            if (!String.IsNullOrEmpty(_cPROD_KIND) && _cPROD_KIND != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, V_STOCK01_PRODUCT01Table.PROD_KIND, Comparison.Equals, _cPROD_KIND, false, false));
                sFlag = false;
            }

            FineUI.DropDownList cPROD_DEP = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_DEP") as FineUI.DropDownList;
            var _PROD_DEP = cPROD_DEP.SelectedValue;
            if (!String.IsNullOrEmpty(_PROD_NAME) && _PROD_DEP != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, V_STOCK01_PRODUCT01Table.PROD_DEP, Comparison.Equals, _PROD_DEP, false, false));
                sFlag = false;
            }
            FineUI.DropDownList cPROD_CATE = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_CATE") as FineUI.DropDownList;
            var _PROD_CATE = cPROD_CATE.SelectedValue;
            if (!String.IsNullOrEmpty(_PROD_CATE) && _PROD_CATE != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, V_STOCK01_PRODUCT01Table.PROD_CATE, Comparison.Equals, _PROD_CATE, false, false));
                sFlag = false;
            }

            if (sFlag)
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, "1", Comparison.Equals, "1", false, false));
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
            string _OUT_ID = tbxOUT_ID.Text;
            string _Shop_ID = ddlIN_SHOP.SelectedValue;
            string _Shop_Name = ddlIN_SHOP.SelectedText;
            string result = "";
            var m_Shop = new SHOP00(x => x.SHOP_ID == _Shop_ID);
            string _priceArea_id = m_Shop.SHOP_Price_Area;
            int rowCount = Grid2.Rows.Count;
            if (!String.IsNullOrEmpty(_OUT_ID))
            {
                foreach (int i in selections)
                {
                    string _Prod_ID = Grid4.DataKeys[i][0].ToString();
                    string _shop_id = ddlSHOP_NAME.SelectedValue;
                    string _prod_name = Grid4.DataKeys[i][1].ToString();
                    string checkresult = ProdAddCheck(_Prod_ID, _prod_name);
                    if (!String.IsNullOrEmpty(checkresult))
                    {
                        result = result + "\r\n" + checkresult;
                        continue;
                    }
                    var model = new V_Product01_PRCAREA(x => x.PROD_ID == _Prod_ID && x.PRCAREA_ID == _priceArea_id);
                    JObject deObject = new JObject();
                    deObject.Add("Id01", "0");
                    deObject.Add("SHOP_ID01", _Shop_ID);
                    deObject.Add("SHOP_NAME101", _Shop_Name);
                    deObject.Add("OUT_ID01", _OUT_ID);
                    deObject.Add("SNo01", rowCount + 1);
                    deObject.Add("PROD_ID01", _Prod_ID);
                    deObject.Add("PROD_NAME01", model.PROD_NAME1);
                    deObject.Add("QUANTITY01", model.ORDER_QUAN);
                    deObject.Add("STD_UNIT01", model.ORDER_UNIT);
                    
                    string STD_PRICE01 = "";
                    string PROD_CONVERT = "";
                    //根据门店类型取进价
                    if (m_Shop.SHOP_KIND == 2)
                    {
                        switch (model.ORDER_UNIT)
                        {
                            case 1: STD_PRICE01 = model.T_COST.ToString();
                                PROD_CONVERT = "1"; break;
                            case 2: STD_PRICE01 = model.T_COST1.ToString();
                                PROD_CONVERT = model.PROD_CONVERT1.ToString(); break;
                            case 3: STD_PRICE01 = model.T_COST2.ToString();
                                PROD_CONVERT = model.PROD_CONVERT2.ToString(); break;
                            default: STD_PRICE01 = model.T_COST.ToString();
                                PROD_CONVERT = "1"; ; break;
                        }
                        deObject.Add("STD_PRICE101", model.T_COST);
                        deObject.Add("STD_PRICE201", model.T_COST1);
                        deObject.Add("STD_PRICE301", model.T_COST2);
                    }
                    else
                    {
                        switch (model.ORDER_UNIT)
                        {
                            case 1: STD_PRICE01 = model.U_Cost.ToString();
                                PROD_CONVERT = "1"; break;
                            case 2: STD_PRICE01 = model.U_Cost1.ToString();
                                PROD_CONVERT = model.PROD_CONVERT1.ToString(); break;
                            case 3: STD_PRICE01 = model.U_Cost2.ToString();
                                PROD_CONVERT = model.PROD_CONVERT1.ToString(); break;
                            default: STD_PRICE01 = model.U_Cost.ToString();
                                PROD_CONVERT = "1"; break;
                        }
                        deObject.Add("STD_PRICE101", model.U_Cost);
                        deObject.Add("STD_PRICE201", model.U_Cost1);
                        deObject.Add("STD_PRICE301", model.U_Cost2);
                    }
                    deObject.Add("STD_CONVERT01", PROD_CONVERT);
                    deObject.Add("STD_UNIT_NAME01", model.ORDER_NAME);
                    deObject.Add("STD_QUAN01", model.ORDER_UNIT);
                    deObject.Add("STD_PRICE01", STD_PRICE01);
                    deObject.Add("MIN_STD_QUAN01", model.ORDER_UNIT);
                    deObject.Add("COST01", model.COST);
                    deObject.Add("QUAN101", 0);
                    deObject.Add("QUAN201", 0);
                    deObject.Add("MEMO01", "");
                    deObject.Add("BAT_NO", "");

                    deObject.Add("UNIT_NAME01", model.UNIT_NAME);
                    deObject.Add("UNIT_NAME101", model.UNIT_NAME1);
                    deObject.Add("UNIT_NAME201", model.UNIT_NAME2);
                    deObject.Add("PROD_CONVERT101", model.PROD_CONVERT1);
                    deObject.Add("PROD_CONVERT201", model.PROD_CONVERT2);
                    deObject.Add("COST101", model.COST);
                    deObject.Add("COST201", model.COST1);
                    deObject.Add("COST301", model.COST2);
                    rowCount = rowCount + 1;
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
        /// <summary>
        /// 校验商品是否重复添加
        /// </summary>
        /// <param name="prod_id"></param>
        /// <param name="prod_name"></param>
        /// <returns></returns>
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

        #region WINDOW4 引入出货订单
        protected void ButtonOrderSearch_Click(Object sender, EventArgs e)
        {
            FineUI.Grid grid4 = Window4.FindControl("PanelGrid5").FindControl("Grid4") as FineUI.Grid;
            V_ORDER00_SHOP00Bll.GetInstence().BindGrid(grid4, 0, 0, OrderCondition(), null);
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

            string _shopid = ddlIN_SHOP.SelectedValue;
            orderCon.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, ORDER00Table.SHOP_ID, Comparison.Equals, _shopid, false, false));
            orderCon.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, ORDER00Table.STATUS, Comparison.GreaterOrEquals, "2", false, false));
            orderCon.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, ORDER00Table.EXPORTED, Comparison.GreaterOrEquals, "0", false, false));
            if (rValue == "1")
            {
                orderCon.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, ORDER00Table.INPUT_DATE, Comparison.LessOrEquals, endtime, false, false));
                orderCon.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, ORDER00Table.INPUT_DATE, Comparison.GreaterOrEquals, starttime, false, false));
            }
            else
            {
                orderCon.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, ORDER00Table.EXPECT_DATE, Comparison.LessOrEquals, endtime, false, false));
                orderCon.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, ORDER00Table.EXPECT_DATE, Comparison.GreaterOrEquals, starttime, false, false));
            }
            


            return orderCon;
        }


        protected void ButtonOrderAdd_Click(Object sender, EventArgs e)
        {
            FineUI.Grid Grid4 = Window4.FindControl("PanelGrid5").FindControl("Grid4") as FineUI.Grid;
            int[] selections = Grid4.SelectedRowIndexArray;
            
            string _Order_id = Grid4.DataKeys[selections[0]][0].ToString();
            //tbxRELATE_ID.Text = Grid4.DataKeys[0][0].ToString();
            //foreach (int i in selections)
            //{
                List<ConditionFun.SqlqueryCondition> order00con = new List<ConditionFun.SqlqueryCondition>();
                order00con.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, ORDER01Table.ORDER_ID, Comparison.Equals, _Order_id, false, false));
                List<string> colList = new List<string>();
                colList.Add("SHOP_ID");
                colList.Add("PROD_ID");
                colList.Add("QUANTITY");
                colList.Add("STD_UNIT");
                colList.Add("STD_CONVERT");
                colList.Add("STD_QUAN");
                colList.Add("STD_PRICE");
                colList.Add("COST_PRICE");
                colList.Add("PROD_NAME1");
                colList.Add("SHOP_NAME1");
                DataTable da = V_ORDER01_PRODUCT01Bll.GetInstence().GetDataTable(false, 0, colList, 0, 0, order00con, null);

                foreach (DataRow dr in da.Rows)
                {
                    int rowCount = Grid2.Rows.Count;
                    JObject deObject = new JObject();
                    deObject.Add("Id01", "0");
                    deObject.Add("SHOP_ID01", dr["SHOP_ID"].ToString());
                    deObject.Add("SHOP_NAME101", dr["SHOP_NAME1"].ToString());
                    deObject.Add("OUT_ID01", tbxOUT_ID.Text);
                    deObject.Add("SNo01", rowCount + 1);
                    deObject.Add("PROD_ID01", dr["PROD_ID"].ToString());
                    deObject.Add("PROD_NAME01", dr["SHOP_NAME1"].ToString());
                    deObject.Add("QUANTITY01", dr["QUANTITY"].ToString());
                    deObject.Add("STD_UNIT01", dr["STD_UNIT"].ToString());
                    deObject.Add("STD_CONVERT01", dr["STD_CONVERT"].ToString());
                    deObject.Add("STD_QUAN01", dr["STD_QUAN"].ToString());
                    deObject.Add("STD_PRICE01", dr["STD_PRICE"].ToString());
                    deObject.Add("COST01", dr["COST_PRICE"].ToString());
                    deObject.Add("QUAN101", dr["STD_QUAN"].ToString());
                    deObject.Add("QUAN201", dr["STD_QUAN"].ToString());
                    deObject.Add("MEMO01", "");
                    deObject.Add("BAT_NO", "");
                    Grid2.AddNewRecord(deObject, true);
                    rowCount = rowCount + 1;
                }
                var modelOrder = new ORDER00(x => x.ORDER_ID == _Order_id);
                modelOrder.EXPORTED_ID = tbxOUT_ID.Text;
                modelOrder.EXPORTED = 1;
                modelOrder.SetIsNew(false);
                ORDER00Bll.GetInstence().Save(this,modelOrder);

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
                    FineUI.Alert.ShowInParent("引入成功", FineUI.MessageBoxIcon.Error);
                }
            //}
        }
        #endregion

    }
}