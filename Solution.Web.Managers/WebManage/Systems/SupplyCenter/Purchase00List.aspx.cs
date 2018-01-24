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
            if (!IsPostBack)
            {
                DatePicker1.SelectedDate = DateTime.Now;
                DatePicker2.SelectedDate = DateTime.Now.AddDays(1);
                LoadData();
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
            if (_id != 0)
            {
                LoadPur(_id);
                LoadDataPur01();
            }
        }

        /// <summary>
        /// 根据单据状态来设置界面内容
        /// </summary>
        public void Purchase00Status(int status)
        {
            switch (status)
            {
                case 1: ButtonCancel.Enabled = true; ButtonCheck.Enabled = true; ButtonCheck.Text = "核准"; ButtonCheck.Text = "作废"; Grid2.AllowCellEditing = true; break;
                case 2: ButtonCheck.Text = "反核准"; ButtonCancel.Text = "作废"; ButtonCancel.Enabled = false; ButtonCheck.Enabled = true; Grid2.AllowCellEditing = false; break;
                case 3: ButtonCancel.Text = "取消作废"; ButtonCheck.Enabled = false; Grid2.AllowCellEditing = false; break;
                case 4: ButtonCancel.Enabled = false; ButtonCheck.Enabled = false; ButtonCheck.Text = "核准"; ButtonCheck.Text = "作废"; Grid2.AllowCellEditing = false; break;
                default: ButtonCancel.Enabled = true; ButtonCheck.Enabled = true; ButtonCheck.Text = "核准"; ButtonCheck.Text = "作废"; Grid2.AllowCellEditing = true; break;
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
        public void LoadPur(int id)
        {
            var model = Purchase00Bll.GetInstence().GetModel(id,false);
            if (model.Id > 0)
            {
                tbxPurchase_ID.Text = model.Purchase_ID;

                string _shop_id = model.SHOP_ID;
                var shopModel = new SHOP00(x => x.SHOP_ID == model.SHOP_ID);
                tbxSHOP_ID.Text = model.SHOP_ID;
                tbxSHOP_NAME1.Text = shopModel.SHOP_NAME1;
                ddlStatus.SelectedValue = model.STATUS.ToString();
                dpINPUT_DATE.Text = model.INPUT_DATE.ToString("yyyy-MM-dd");
                dpEXPECT_DATE.Text = model.EXPECT_DATE.ToString("yyyy-MM-dd");
                ddlSUP_ID.SelectedValue = model.SUP_ID.ToString();
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
            string _shop_id = tbxSHOP_ID.Text;
            string _Purchase_ID = tbxPurchase_ID.Text;
            List<ConditionFun.SqlqueryCondition> condiList = new List<ConditionFun.SqlqueryCondition>();
            condiList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, Purchase01Table.SHOP_ID, Comparison.Equals, _shop_id, false, false));
            condiList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, Purchase01Table.Purchase_ID, Comparison.Equals, _Purchase_ID, false, false));
            return condiList;
        }

        /// <summary>
        /// 保存与更新
        /// </summary>
        public void BtnPur01_Save(Object sender,EventArgs e)
        {
            JArray pJson = Grid2.GetMergedData();
            string result = "";
            
            for (int i = 0; i < pJson.Count; i++)
            {
                try
                {
                    int _id = ConvertHelper.Cint(pJson[i]["values"]["Id"].ToString());
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
                }
            }
            if (!String.IsNullOrEmpty(result))
            {
                FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
            }
            else
            {
                string _shop_id = tbxSHOP_ID.Text;
                string _Pur_id = tbxPurchase_ID.Text;
                
                DataSet ds=(DataSet)SPs.Update_Purchase00_TOT(_shop_id, _Pur_id).ExecuteDataSet();
                int _id = ConvertHelper.Cint0(GridViewHelper.GetSelectedKey(Grid1, true));
                LoadPur(_id);
                FineUI.Alert.ShowInParent("保存成功", FineUI.MessageBoxIcon.Information);

            }
            LoadDataPur01();
        }

        public void btn_Replace(Object sender, EventArgs e)
        {
            Window3.Hidden = false;
        }

        public void Window3_Close()
        {
            Window3.Hidden = true;
        }
        #endregion
    }



}