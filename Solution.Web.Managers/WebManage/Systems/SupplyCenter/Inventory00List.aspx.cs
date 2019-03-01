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
    public partial class Inventory00List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DatePicker1.SelectedDate = DateTime.Now;
                DatePicker2.SelectedDate = DateTime.Now.AddDays(1);
                SHOP00Bll.GetInstence().BandDropDownListShowShop1(this, ddlSHOP_NAME);
                //SHOP00Bll.GetInstence().BandDropDownListShowShop1(this, ddlDIV_ID);
                LoadList();
                LoadData();
                OrderStatus(new Inventory00());
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

            SHOP00Bll.GetInstence().BindOnlineUser(this, model.SHOP_ID,ddlSHOP_NAME);
            STOCKBll.GetInstence().BandOnlineUserStock(this,model.SHOP_ID, ddlSTOCK_ID);
            STOCKBll.GetInstence().BandOnlineUserStock(this, model.SHOP_ID, ddlSTOCK_NAME1);
            FineUI.DropDownList ccPROD_KIND = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_KIND") as FineUI.DropDownList;
            PROD_KINDBll.GetInstence().BandDropDownListShowKind(this, ccPROD_KIND);
            FineUI.DropDownList ccPROD_DEP = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_DEP") as FineUI.DropDownList;
            PROD_DEPBll.GetInstence().BandDropDownListShowDep(this, ccPROD_DEP);
            FineUI.DropDownList ccPROD_CATE = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_CATE") as FineUI.DropDownList;
            PROD_CateBll.GetInstence().BandDropDownListShowCate(this, ccPROD_CATE);
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
            V_Inventory00_SHOP00Bll.GetInstence().BindGrid(Grid1, 0, 0, InquiryCondition(), sortList);
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


            string st = DatePicker1.Text;
            string et = DatePicker2.Text;
            string sn = ddlSTOCK_NAME1.SelectedValue;
            string DateType = ddrDataType.SelectedValue;
            if (DateType.Equals("1"))
            {
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, Inventory00Table.INPUT_DATE, Comparison.LessOrEquals, et, false, false));
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, Inventory00Table.INPUT_DATE, Comparison.GreaterOrEquals, st, false, false));
            }
            else
            {
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, Inventory00Table.APP_DATETIME, Comparison.LessOrEquals, et, false, false));
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, Inventory00Table.APP_DATETIME, Comparison.GreaterOrEquals, st, false, false));
            }

            if (!sn.Equals("0") && !String.IsNullOrEmpty(sn))
            {
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, Inventory00Table.STOCK_ID, Comparison.Equals, sn, false, false));
            }

            return conditionList;
        }


        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {
            //bll = Dispose00Bll.GetInstence();
            //throw new NotImplementedException();
        }

        public override void SingleClick(GridRowClickEventArgs e)
        {
            string _tbxINV_ID = GridViewHelper.GetSelectedKey(Grid1, true);
            tbxINV_ID.Text = _tbxINV_ID;
            LoadMAIN();
            LoadDETAIL();
            //Alert.ShowInTop(String.Format("你点击了第 {0} 行（单击）", e.RowIndex + 1));
        }


        /// <summary>
        /// 加载主表明细数据
        /// </summary>
        public void LoadMAIN()
        {
            string _tbxINV_ID = tbxINV_ID.Text;
            if (!String.IsNullOrEmpty(_tbxINV_ID))
            {
                var model = new Inventory00(x => x.INV_ID == _tbxINV_ID);
                ddlSHOP_NAME.SelectedValue = model.SHOP_ID;
                dpINPUT_DATE.SelectedDate = model.INPUT_DATE;
                ddlStatus.SelectedValue = model.STATUS.ToString();
                ddlINV_TYPE.SelectedValue = model.INV_TYPE.ToString();
                ddlSTOCK_ID.SelectedValue = model.STOCK_ID;
                tbxUSER_ID.Text = model.USER_ID;
                tbxAPP_USER.Text = model.APP_USER;
                dpAPP_DATETIME.SelectedDate = model.APP_DATETIME;

                tbxMemo.Text = model.Memo;
                ckLOCKED.Checked = model.LOCKED == '0' ? false : true;

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
            string _tbxINV_ID = tbxINV_ID.Text;
            if (!String.IsNullOrEmpty(_tbxINV_ID))
            {
                List<ConditionFun.SqlqueryCondition> conditiondetail = new List<ConditionFun.SqlqueryCondition>();
                conditiondetail.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, Inventory01Table.INV_ID, Comparison.Equals, _tbxINV_ID, false, false));
                conditiondetail.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, Inventory01Table.Hidden, Comparison.Equals, 0, false, false));
                V_Inventory01_PRODUCT00Bll.GetInstence().BindGrid(Grid2, 0, 0, conditiondetail, sortList);
            }
        }

        /// <summary>
        /// Grid2编辑字段判断
        /// </summary>
        /// <param name="status"></param>
        public void Grid2ColumnEdit(int status)
        {
            if (status == 1)
            {
                numQUANTITY.Enabled = true;
                numQUAN01.Enabled = true;
                numQUAN1.Enabled = true;
                numQUAN2.Enabled = true;
                numQUAN_B.Enabled = true;
                tbxMEMO01.Enabled = true;
            }
            else
            {
                numQUANTITY.Enabled = false;
                numQUAN01.Enabled = false;
                numQUAN1.Enabled = false;
                numQUAN2.Enabled = false;
                numQUAN_B.Enabled = false;
                tbxMEMO01.Enabled = false;
            }
        }
        /// <summary>
        /// 状态位的判定
        /// </summary>
        /// <param name="status"></param>
        public void OrderStatus(Inventory00 model)
        {
            //1:存档 2：核准 3：作废 4：已引入
            //新增：ButtonAdd 保存：ButtonSave 更新：ButtonUpdate 核准：ButtonCheck 作废：ButtonCancel
            //Pur02新增：ButtonPur02Add
            Grid2ColumnEdit(model.STATUS);
            switch (model.STATUS)
            {
                case 1:
                    ButtonSave.Enabled = true;
                    ButtonCancel.Enabled = true;
                    ButtonCheck.Enabled = true;
                    ButtonCheck.Text = "核准";
                    ButtonCancel.Text = "作废";
                    Toolbar21111.Enabled = true;
                    break;
                case 2:
                    ButtonSave.Enabled = false;
                    ButtonCheck.Text = "反核准";
                    ButtonCancel.Text = "作废";
                    ButtonCancel.Enabled = false;
                    ButtonCheck.Enabled = false;
                    Toolbar21111.Enabled = false;
                    break;
                case 3:
                    ButtonSave.Enabled = false;
                    ButtonCheck.Text = "核准";
                    ButtonCheck.Enabled = false;
                    ButtonCancel.Text = "取消作废";
                    ButtonCancel.Enabled = true;
                    Toolbar21111.Enabled = false;
                    break;
                case 4:
                    ButtonSave.Enabled = false;
                    ButtonCheck.Text = "反核准";
                    ButtonCancel.Text = "作废";
                    ButtonCancel.Enabled = false;
                    ButtonCheck.Enabled = false;
                    Toolbar21111.Enabled = false;
                    break;
                default:
                    ButtonSave.Enabled = false;
                    ButtonCheck.Text = "核准";
                    ButtonCancel.Text = "作废";
                    ButtonCancel.Enabled = false;
                    ButtonCheck.Enabled = false;
                    Toolbar21111.Enabled = false;
                    break;
            }
            if (model.INV_TYPE == 4)
            {
                Toolbar21111.Enabled = true;
            }
        }

        /// <summary>
        /// 新增数据，将数据清空，并可编辑
        /// </summary>
        public void BtnAdd_Click(Object sender, EventArgs e)
        {
            OrderStatus(new Inventory00());
            ButtonSave.Enabled = true;
            tbxINV_ID.Text = "";
            ddlSHOP_NAME.Enabled = true;
            ddlSHOP_NAME.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            dpINPUT_DATE.SelectedDate = DateTime.Now;

            tbxUSER_ID.Text = "";
            tbxAPP_USER.Text = "";
            dpAPP_DATETIME.SelectedDate = DateTime.Parse("1900-01-01 00:00:00");

            tbxMemo.Text = "";
            ckLOCKED.Checked = false;


            tbxCRT_DATETIME.Text = "";
            tbxCRT_USER_ID.Text = "";
            tbxMOD_DATETIME.Text = "";
            tbxMOD_USER_ID.Text = "";
            tbxLAST_UPDATE.Text = "";

            Grid2.DataSource = null;
            Grid2.DataBind();
            btn_DetailAdd2();
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
                result = DetailEdit();
                if (String.IsNullOrEmpty(result))
                {
                    FineUI.Alert.ShowInParent("保存成功", FineUI.MessageBoxIcon.Error);
                }
                else
                {
                    FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Error);
                }
            }
            else
            {
                FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 核准按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Btn_MainCheck(Object sender, EventArgs e)
        {
            string _INV_ID = tbxINV_ID.Text.ToString();
            var model = Inventory00.SingleOrDefault(x => x.INV_ID == _INV_ID);
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
            string _INV_ID = tbxINV_ID.Text.ToString();
            var model = Inventory00.SingleOrDefault(x => x.INV_ID == _INV_ID);
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
            //FineUI.Alert.ShowInParent("核准成功", FineUI.MessageBoxIcon.Information);
        }

        /// <summary>
        /// 主表保存
        /// </summary>
        /// <returns></returns>
        public string MAINEdit()
        {
            string _INV_ID = tbxINV_ID.Text.ToString();
            try
            {
                var model = new Inventory00(x => x.INV_ID == _INV_ID);
                var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                string _SHOP_ID = ddlSHOP_NAME.SelectedValue;
                if (String.IsNullOrEmpty(_INV_ID))
                {
                    model.SetIsNew(true);
                    model.CRT_DATETIME = DateTime.Now;
                    model.CRT_USER_ID = OlUser.Manager_LoginName;
                    DataTable dt = new DataTable();
                    dt = (DataTable)SPs.Get_ORDER_SEED(_SHOP_ID, "Inventory00").ExecuteDataTable();
                    _INV_ID = dt.Rows[0]["PLANE_ID"].ToString();
                    //var model = Purchase00.SingleOrDefault(x => x.Purchase_ID == _Pur00_id);

                }
                model.SHOP_ID = _SHOP_ID;
                model.INV_ID = _INV_ID.ToString();
                model.STATUS = ConvertHelper.Cint(ddlStatus.SelectedValue);
                model.INPUT_DATE = ConvertHelper.StringToDatetime(dpINPUT_DATE.SelectedDate.ToString());

                model.INV_TYPE = ConvertHelper.Cint(ddlINV_TYPE.SelectedValue);
                model.STOCK_ID = ddlSTOCK_ID.SelectedValue;
                model.USER_ID = OlUser.Manager_LoginName;
                model.APP_USER = OlUser.Manager_LoginName;
                model.APP_DATETIME = DateTime.Now;

                model.Memo = tbxMemo.Text;
                model.LOCKED = ConvertHelper.StringToByte(ckLOCKED.Checked ? "1" : "0");

                model.MOD_DATETIME = DateTime.Now;
                model.MOD_USER_ID = OlUser.Manager_LoginName;
                model.LAST_UPDATE = DateTime.Now;
                model.Trans_STATUS = 0;
                Inventory00Bll.GetInstence().Save(this, model);
                tbxINV_ID.Text = model.INV_ID;
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
                    int id = ConvertHelper.Cint(jarr[i]["values"]["Id01"].ToString());
                    var model2 = new Inventory01(x=>x.Id==id);
                    //string str = jarr[i]["status"].ToString();
                    if (jarr[i]["status"].ToString().Equals("modified"))
                    {
                        model2.SetIsNew(false);
                    }
                    //else if (jarr[i]["status"].ToString().Equals("unchanged"))
                    //{
                    //    continue;
                    //}
                    else
                    {
                        model2.SetIsNew(true);
                    }
                    model2.SHOP_ID = jarr[i]["values"]["SHOP_ID01"].ToString();
                    if (!String.IsNullOrEmpty(tbxINV_ID.Text))
                    {
                        model2.INV_ID = tbxINV_ID.Text;
                    }
                    else
                    {
                        return "保存失败";
                    }
                    model2.SNo = ConvertHelper.Cint(jarr[i]["values"]["SNo01"].ToString());
                    model2.PROD_ID = jarr[i]["values"]["PROD_ID01"].ToString();
                    model2.QUANTITY = ConvertHelper.Cdbl(jarr[i]["values"]["QUANTITY01"].ToString());
                    model2.QUAN = ConvertHelper.Cdbl(jarr[i]["values"]["QUAN01"].ToString());
                    model2.QUAN1 = ConvertHelper.Cint(jarr[i]["values"]["QUAN101"].ToString());
                    model2.QUAN2 = ConvertHelper.Cdbl(jarr[i]["values"]["QUAN201"].ToString());
                    model2.QUAN_B = ConvertHelper.Cdbl(jarr[i]["values"]["QUAN_B01"].ToString());
                    model2.MEMO = jarr[i]["values"]["MEMO01"].ToString();
                    Inventory01Bll.GetInstence().Save(this, model2);
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
        /// 子表添加商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btn_DetailAdd(Object sender, EventArgs e)
        {
            //string Pur_status = ddlStatus.SelectedValue;
            FineUI.Panel P_search = Window3.FindControl("PanelGrid4").FindControl("Panel_Search") as FineUI.Panel;
            P_search.Hidden = false;
            FineUI.DropDownList ddlstock = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("window_ddl_Stock") as FineUI.DropDownList;
            STOCKBll.GetInstence().BandDropDownListStock(this, ddlstock);
            Window3.Hidden = false;
            FineUI.Grid Grid4 = Window3.FindControl("PanelGrid4").FindControl("Grid4") as FineUI.Grid;
            Grid4.DataSource = null;
            Grid4.DataBind();
        }

        /// <summary>
        /// 新增仓库的商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btn_DetailAdd2()
        {
            //string Pur_status = ddlStatus.SelectedValue;
            FineUI.Panel P_search = Window4.FindControl("PanelGrid4").FindControl("Panel_Search") as FineUI.Panel;
            P_search.Hidden = false;
            FineUI.DropDownList ddlstock = Window4.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("window_ddl_Stock") as FineUI.DropDownList;
            STOCKBll.GetInstence().BandDropDownListStock(this, ddlstock);
            Window4.Hidden = false;
        }


        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonStockAdd_Click(object sender, EventArgs e)
        {
            FineUI.DropDownList ddlstock = Window4.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("window_ddl_Stock") as FineUI.DropDownList;
            FineUI.DropDownList _window_ddl_INV_TYPE = Window4.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("window_ddl_INV_TYPE") as FineUI.DropDownList;
            FineUI.DropDownList _window_ddl_Stock = Window4.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("window_ddl_Stock") as FineUI.DropDownList;
            string invType= _window_ddl_INV_TYPE.SelectedValue;
            string invStock = _window_ddl_Stock.SelectedValue;

            ddlINV_TYPE.SelectedValue = invType;
            ddlstock.SelectedValue = invStock;
            string _SHOP_ID = ddlSHOP_NAME.SelectedValue;
            if (invType == "4")
            {
                Grid2.DataSource = null;
                Grid2.DataBind();
                Toolbar21111.Enabled = true;
            }
            else
            {
                DataTable dt = new DataTable();
                dt = (DataTable)SPs.GET_STOCK01_PROD(invStock, "", _SHOP_ID, invType).ExecuteDataTable();
                Grid2.DataSource = dt;
                Grid2.DataBind();
                Toolbar21111.Enabled = false;
            }
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
            PRODUCT00Bll.GetInstence().BindGrid(Grid4, 0, 0, InquiryConditionProduct(), sortList);
        }
        /// <summary>
        /// GRID3检索的判断条件
        /// </summary>
        /// <returns></returns>
        private List<ConditionFun.SqlqueryCondition> InquiryConditionProduct()
        {
            List<ConditionFun.SqlqueryCondition> conditionProdduct00List = new List<ConditionFun.SqlqueryCondition>();
            bool sFlag = true;
            //conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "1", Comparison.Equals, "1", false, false));

            FineUI.TextBox cPROD_ID = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_ID") as FineUI.TextBox;
            var _PROD_ID = cPROD_ID.Text;
            if (!String.IsNullOrEmpty(cPROD_ID.Text))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_ID, Comparison.Like, "%" + _PROD_ID + "%", false, false));
                sFlag = false;
            }

            FineUI.TextBox cPROD_NAME = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_NAME") as FineUI.TextBox;
            var _PROD_NAME = cPROD_NAME.Text;
            if (!String.IsNullOrEmpty(_PROD_NAME))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_NAME1, Comparison.Like, "%" + _PROD_NAME + "%", false, false));
                sFlag = false;
            }
            FineUI.TextBox cPROD_NAME_SPELLING = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_NAME_SPELLING") as FineUI.TextBox;
            var _PROD_NAME_SPELLING = cPROD_NAME_SPELLING.Text;
            if (!String.IsNullOrEmpty(_PROD_NAME_SPELLING))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_NAME1_SPELLING, Comparison.Like, "%" + _PROD_NAME_SPELLING + "%", false, false));
                sFlag = false;
            }
            FineUI.DropDownList cPROD_KIND = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_KIND") as FineUI.DropDownList;
            var _cPROD_KIND = cPROD_KIND.SelectedValue;
            if (!String.IsNullOrEmpty(_cPROD_KIND) && _cPROD_KIND != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_KIND, Comparison.Equals, _cPROD_KIND, false, false));
                sFlag = false;
            }

            FineUI.DropDownList cPROD_DEP = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_DEP") as FineUI.DropDownList;
            var _PROD_DEP = cPROD_DEP.SelectedValue;
            if (!String.IsNullOrEmpty(_PROD_NAME) && _PROD_DEP != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_DEP, Comparison.Equals, _PROD_DEP, false, false));
                sFlag = false;
            }
            FineUI.DropDownList cPROD_CATE = Window3.FindControl("PanelGrid4").FindControl("Panel_Search").FindControl("ccPROD_CATE") as FineUI.DropDownList;
            var _PROD_CATE = cPROD_CATE.SelectedValue;
            if (!String.IsNullOrEmpty(_PROD_CATE) && _PROD_CATE != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_CATE, Comparison.Equals, _PROD_CATE, false, false));
                sFlag = false;
            }


            conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.INV_TYPE, Comparison.NotEquals, "0", false, false));
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
            string _INV_ID = tbxINV_ID.Text;
            string _Shop_ID = ddlSHOP_NAME.SelectedValue;
            string _Shop_Name = ddlSHOP_NAME.SelectedText;
            string result = "";
            var m_Shop = new SHOP00(x => x.SHOP_ID == _Shop_ID);
            string _priceArea_id = m_Shop.SHOP_Price_Area;
            if (!String.IsNullOrEmpty(_INV_ID))
            {
                foreach (int i in selections)
                {
                    string _Prod_ID = Grid4.DataKeys[i][0].ToString();
                    string _prod_name = Grid4.DataKeys[i][1].ToString();
                    string checkresult = ProdAddCheck(_Prod_ID, _prod_name);
                    if (!String.IsNullOrEmpty(checkresult))
                    {
                        result = result + "\r\n" + checkresult;
                        continue;
                    }
                    string _shop_id = ddlSHOP_NAME.SelectedValue;
                    var model = new V_Product01_PRCAREA(x => x.PROD_ID == _Prod_ID && x.PRCAREA_ID == _priceArea_id);
                    int rowCount = Grid2.Rows.Count;
                    JObject deObject = new JObject();
                    deObject.Add("Id01", "0");
                    deObject.Add("SHOP_ID01", _Shop_ID);
                    deObject.Add("SHOP_NAME101", _Shop_Name);
                    deObject.Add("INV_ID01", _INV_ID);
                    deObject.Add("SNo01", rowCount + 1);
                    deObject.Add("PROD_ID01", _Prod_ID);
                    deObject.Add("PROD_NAME01", model.PROD_NAME1);
                    deObject.Add("QUANTITY01", model.SAFE_QUAN);
                    deObject.Add("QUAN01", 0);
                    deObject.Add("QUAN101", 0);
                    deObject.Add("QUAN201", 0);
                    deObject.Add("QUAN_B01", 0);
                    deObject.Add("MEMO01", 0);
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