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

namespace Solution.Web.Managers.WebManage.Systems.DataCenter
{
    public partial class ContracT00List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                SUPPLIERSBll.GetInstence().BandDropDownListShowSup(this,tbxSECEND_PARTY);
            }
        }

        public override void Init()
        {
            //throw new NotImplementedException();
        }

        public override void LoadData()
        {
            CONTRACT00Bll.GetInstence().BindGrid(Grid1,0,0,null);
            //throw new NotImplementedException();
        }

        public override void SingleClick(GridRowClickEventArgs e)
        {
            //base.SingleClick(e);
            int _id = ConvertHelper.Cint(GridViewHelper.GetSelectedKey(Grid1, true));
            CONTRACT00 model = new CONTRACT00(x => x.Id == _id);
            LoadCONTRACTP00(model);
            LoadCONTRACT01(model.CONTRACT_ID);
        }

        #region CONTRACTP00相关事件

        /// <summary>
        /// 加载合同主表信息
        /// </summary>
        /// <param name="model"></param>
        public void LoadCONTRACTP00(CONTRACT00 model)
        {
            hidId.Text = model.Id.ToString();
            tbxCONTRACT_ID.Text = model.CONTRACT_ID;
            tbxCONTRACT_TITLE.Text = model.CONTRACT_TITLE;
            if (model.USABLE == 1)
            {
                cbxUSABLE.Checked = true;
            }
            else
            {
                cbxUSABLE.Checked = false;
            }

            if (model.LOCK == 1)
            {
                cbxLOCK.Checked = true;
            }
            else
            {
                cbxLOCK.Checked = false;
            }
            if (model == null || String.IsNullOrEmpty(model.CONTRACT_ID))
            {
                dpkCONTRACTP_SIGN.SelectedDate = DateTime.Now;
                dpkCONTRACTP_STARTTIME.SelectedDate = DateTime.Now;
                dpkCONTRACTP_ENDTIME.SelectedDate = DateTime.Now;
                tbxMOD_USER_DATE.Text = DateTime.Now.ToString();
                tbxCRT_DATETIME.Text = DateTime.Now.ToString();
            }
            else
            {
                dpkCONTRACTP_SIGN.SelectedDate = model.CONTRACTP_SIGN;
                dpkCONTRACTP_STARTTIME.SelectedDate = model.CONTRACTP_STARTTIME;
                dpkCONTRACTP_ENDTIME.SelectedDate = model.CONTRACTP_ENDTIME;
                tbxMOD_USER_DATE.Text = model.MOD_DATETIME.ToString();
                tbxCRT_DATETIME.Text = model.CRT_DATETIME.ToString();
            }

            tbxFIRST_PARTY.Text = model.FIRST_PARTY;
            tbxSECEND_PARTY.SelectedValue = model.SECEND_PARTY;
            tbxMeno.Text = model.Meno;
            tbxCRT_USER_ID.Text = model.CRT_USER_ID;
            tbxMOD_USER_ID.Text = model.CRT_USER_ID;

            
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSave_CONTRACTP00(Object sender, EventArgs e)
        {
            LoadCONTRACT01("");
            string result = "";
            result=Contract00Edit(true);
            if (!String.IsNullOrEmpty(result))
            {
                FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
            }
            else
            {
                FineUI.Alert.ShowInParent("保存成功", FineUI.MessageBoxIcon.Information);
            }
            CONTRACT00Bll.GetInstence().BindGrid(Grid1, 0, 0, null);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_CONTRACTP00(object sender, EventArgs e)
        {
            string result = "";
            result = Contract00Edit(false);
            int _id = ConvertHelper.Cint(GridViewHelper.GetSelectedKey(Grid1, true));
            if (_id < 1)
            {
                FineUI.Alert.ShowInParent("请先选中一个合同", FineUI.MessageBoxIcon.Information);
                return;
            }
            if (!String.IsNullOrEmpty(result))
            {
                FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
            }
            else
            {
                btnSaveCONTRACT01();
                FineUI.Alert.ShowInParent("更新成功", FineUI.MessageBoxIcon.Information);
                CONTRACT00Bll.GetInstence().BindGrid(Grid1, 0, 0, null);
                CONTRACT00 model = new CONTRACT00();
                LoadCONTRACTP00(model);
                LoadCONTRACT01(model.CONTRACT_ID);
            }

        }
        /// <summary>
        /// 校验数据
        /// </summary>
        /// <returns></returns>
        public string CheckContract00()
        {
            string result = "";
            if (String.IsNullOrEmpty(tbxCONTRACT_ID.Text.ToString()))
            {
                result = result + "合同编码不能为空" + Environment.NewLine;
            }
            if (String.IsNullOrEmpty(tbxCONTRACT_TITLE.Text.ToString()))
            {
                result = result + "合同标题不能为空" + Environment.NewLine;
            }
            if (String.IsNullOrEmpty(dpkCONTRACTP_SIGN.Text.ToString()))
            {
                result = result + "签约不能为空" + Environment.NewLine;
            }
            if (String.IsNullOrEmpty(dpkCONTRACTP_STARTTIME.SelectedDate.ToString()) || String.IsNullOrEmpty(dpkCONTRACTP_ENDTIME.SelectedDate.ToString()))
            {
                result = result + "合同开始时间或者结束时间不能为空" + Environment.NewLine;
            }
            else
            {
                if (dpkCONTRACTP_ENDTIME.SelectedDate.Value.CompareTo(dpkCONTRACTP_STARTTIME.SelectedDate) < 0)
                {
                    result = result + "开始时间不能晚于结束时间" + Environment.NewLine;
                }
            }
            if (String.IsNullOrEmpty(tbxFIRST_PARTY.Text.ToString()))
            {
                result = result + "甲方名称不能为空" + Environment.NewLine;
            }
            if (String.IsNullOrEmpty(tbxSECEND_PARTY.SelectedValue.ToString()))
            {
                result = result + "乙方名称不能为空" + Environment.NewLine;
            }
            return result;
        }
        /// <summary>
        /// Contract00保存与更新
        /// </summary>
        /// <param name="isNew"></param>
        /// <returns></returns>
        public string Contract00Edit(bool isNew)
        {
            string result = "";
            result = CheckContract00();
            if (!String.IsNullOrEmpty(result))
            {
                return result;
            }
            try
            {
                CONTRACT00 model = null;
                var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                if (isNew == true)
                {
                    model = new CONTRACT00();
                    model.SetIsNew(true);
                    model.CONTRACT_ID = tbxCONTRACT_ID.Text;
                    model.CRT_DATETIME = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    model.CRT_USER_ID = OlUser.Manager_LoginName;
                }
                else
                {
                    int _id = ConvertHelper.Cint(hidId.Text.ToString());
                    model = new CONTRACT00(x => x.Id == _id);
                    model.SetIsNew(false);
                    model.CONTRACT_ID = model.CONTRACT_ID;
                }

                model.MOD_DATETIME = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                model.MOD_USER_ID = OlUser.Manager_LoginName;
                model.CONTRACT_TITLE = tbxCONTRACT_TITLE.Text;
                if (cbxUSABLE.Checked == true)
                {
                    model.USABLE = 1;
                }
                else
                {
                    model.USABLE = 0;
                }
                if (cbxLOCK.Checked == true)
                {
                    model.LOCK = 1;
                }
                else
                {
                    model.LOCK = 0;
                }
                model.CONTRACTP_SIGN = ConvertHelper.StringToDatetime(dpkCONTRACTP_SIGN.Text.ToString());
                model.CONTRACTP_STARTTIME = ConvertHelper.StringToDatetime(dpkCONTRACTP_STARTTIME.Text.ToString());
                model.CONTRACTP_ENDTIME = ConvertHelper.StringToDatetime(dpkCONTRACTP_ENDTIME.Text.ToString());
                model.FIRST_PARTY = tbxFIRST_PARTY.Text;
                model.SECEND_PARTY = tbxSECEND_PARTY.SelectedValue.ToString();
                model.Meno = tbxMeno.Text;
                CONTRACT00Bll.GetInstence().Save(this, model);
                result = "";
            }
            catch (Exception err)
            {
                result = "保存失败";
            }
            return result;
        }
        #endregion

        #region
        /// <summary>
        /// 加载合同明细
        /// </summary>
        /// <param name="CONTRACT_ID"></param>
        public void LoadCONTRACT01(string CONTRACT_ID)
        {
            sortList = null;
            if (sortList == null)
            {
                sortList = new List<string>();
                sortList.Add(CONTRACT01Table.Id);
                //Sort();
            }
            if (String.IsNullOrEmpty(CONTRACT_ID))
            {
                Grid2.DataSource = null;
                Grid2.DataBind();
                return;
            }
            conditionList = null;
            //绑定Grid表格
            CONTRACT01Bll.GetInstence().BindGrid(Grid2, 0, 0, InquiryCondition2(CONTRACT_ID), sortList);
        }
        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="CONTRACT_ID"></param>
        /// <returns></returns>
        private List<ConditionFun.SqlqueryCondition> InquiryCondition2(string CONTRACT_ID)
        {
            List<ConditionFun.SqlqueryCondition> conditionProdduct00List = new List<ConditionFun.SqlqueryCondition>();
            conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where,  CONTRACT01Table.CONTRACT_ID, Comparison.Equals, CONTRACT_ID, false, false));
            return conditionProdduct00List;
        }

        public void btnSaveCONTRACT01()
        {
            JArray conJons = Grid2.GetMergedData();
            for (int i = 0; i < conJons.Count; i++)
            {
                CONTRACT01 model = null;
                var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                if (conJons[i]["values"]["Id01"].ToString() == "0" || conJons[i]["status"].ToString()== "newadded")
                {
                    model = new CONTRACT01();
                    model.CRT_DATETIME = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    model.CRT_USER_ID = OlUser.Manager_LoginName;
                }
                else
                {
                    int _id = ConvertHelper.Cint(conJons[i]["values"]["Id01"].ToString());
                    model = new CONTRACT01(x=>x.Id==_id);
                }
                model.MOD_DATETIME = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                model.LAST_UPDATE = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                model.MOD_USER_ID = OlUser.Manager_LoginName;
                model.CONTRACT_ID = conJons[i]["values"]["CONTRACT_ID01"].ToString();
                model.PROD_ID= conJons[i]["values"]["PROD_ID01"].ToString();
                model.CONTRACT_PRICE = ConvertHelper.StringToDecimal(conJons[i]["values"]["CONTRACT_PRICE01"].ToString());
                model.CONTRACT_PRICE1 = ConvertHelper.StringToDecimal(conJons[i]["values"]["CONTRACT_PRICE101"].ToString());
                model.CONTRACT_PRICE2 = ConvertHelper.StringToDecimal(conJons[i]["values"]["CONTRACT_PRICE201"].ToString());
                string a = conJons[i]["values"]["USABLE01"].ToString();
                if (conJons[i]["values"]["USABLE01"].ToString() == "True")
                {
                    model.USABLE = 1;
                }
                else
                {
                    model.USABLE = 0;
                }
                model.Meno = conJons[i]["values"]["Meno01"].ToString();
                CONTRACT01Bll.GetInstence().Save(this,model);
            }
        }
        public void btnAdd_CONTRACT01(Object sender, EventArgs e)
        {
            Window3.Hidden = false;
        }
        #endregion

        #region WINDOW相关事件

        public void Window3_Close(Object sender, EventArgs e)
        {
            Window3.Hidden = true;
        }

        public void ButtonPRODSearch2_Click(Object sender, EventArgs e)
        {
            conditionList = null;
            //conditionList = new List<ConditionFun.SqlqueryCondition>();
            //绑定Grid表格
            FineUI.Grid Grid4 = Window3.FindControl("PanelGrid4").FindControl("Grid4") as FineUI.Grid;
            PRODUCT00Bll.GetInstence().BindGrid(Grid4, 0, 0, InquiryCondition(), sortList);
        }
        /// <summary>
        /// GRID4检索的判断条件
        /// </summary>
        /// <returns></returns>
        private List<ConditionFun.SqlqueryCondition> InquiryCondition()
        {
            List<ConditionFun.SqlqueryCondition> conditionProdduct00List = new List<ConditionFun.SqlqueryCondition>();
            //conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "1", Comparison.Equals, "1", false, false));
            bool sFlag = true;
            FineUI.TextBox cPROD_ID = Window3.FindControl("PanelGrid4").FindControl("cPROD_ID") as FineUI.TextBox;
            var _PROD_ID = cPROD_ID.Text;
            if (!String.IsNullOrEmpty(cPROD_ID.Text))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_ID, Comparison.Like, "%" + _PROD_ID + "%", false, false));
                sFlag = false;
            }

            FineUI.TextBox cPROD_NAME = Window3.FindControl("PanelGrid4").FindControl("cPROD_NAME") as FineUI.TextBox;
            var _PROD_NAME = cPROD_NAME.Text;
            if (!String.IsNullOrEmpty(_PROD_NAME))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_NAME1, Comparison.Like, "%" + _PROD_NAME + "%", false, false));
                sFlag = false;
            }
            FineUI.TextBox cPROD_NAME_SPELLING = Window3.FindControl("PanelGrid4").FindControl("cPROD_NAME_SPELLING") as FineUI.TextBox;
            var _PROD_NAME_SPELLING = cPROD_NAME_SPELLING.Text;
            if (!String.IsNullOrEmpty(_PROD_NAME_SPELLING))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_NAME1_SPELLING, Comparison.Like, "%" + _PROD_NAME_SPELLING + "%", false, false));
                sFlag = false;
            }
            FineUI.DropDownList cPROD_DEP = Window3.FindControl("PanelGrid4").FindControl("cPROD_DEP") as FineUI.DropDownList;
            var _PROD_DEP = cPROD_DEP.SelectedValue;
            if (!String.IsNullOrEmpty(_PROD_NAME) && _PROD_DEP != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_DEP, Comparison.Equals, _PROD_DEP, false, false));
                sFlag = false;
            }
            FineUI.DropDownList cPROD_CATE = Window3.FindControl("PanelGrid4").FindControl("cPROD_CATE") as FineUI.DropDownList;
            var _PROD_CATE = cPROD_CATE.SelectedValue;
            if (!String.IsNullOrEmpty(_PROD_CATE) && _PROD_CATE != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_CATE, Comparison.Equals, _PROD_CATE, false, false));
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


        public void btnEditCon_Click(Object sender, EventArgs e)
        {
            try
            {
                //int Grid3RowIndex = ConvertHelper.Cint(Grid3Rowindex.Text);
                string _CONTRACT_ID = tbxCONTRACT_ID.Text.ToString();
                if (String.IsNullOrEmpty(_CONTRACT_ID))
                {
                    FineUI.Alert.ShowInParent("未选择商品", FineUI.MessageBoxIcon.Information);
                    return;
                }
                FineUI.Grid Grid4 = Window3.FindControl("PanelGrid4").FindControl("Grid4") as FineUI.Grid;
                int[] selections = Grid4.SelectedRowIndexArray;
                if (selections.Length == 0)
                {
                    FineUI.Alert.ShowInParent("请选择一行", FineUI.MessageBoxIcon.Information);
                    return;
                }
                foreach (int i in selections)
                {
                    int _Id = ConvertHelper.Cint(Grid4.DataKeys[i][0].ToString());
                    if (_Id > 0)
                    {
                        JObject defaultObj = new JObject();
                        var model = new PRODUCT00(x => x.Id == _Id);
                        //暂时保留后期可能优化
                        string _UserHashKey = Session[OnlineUsersTable.UserHashKey].ToString();
                        var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                        DataSet dsCom = (DataSet)SPs.Get_CONTRACT01_PRODUCT01(_UserHashKey,model.PROD_ID).ExecuteDataSet();
                        if (dsCom.Tables.Count > 0)
                        {
                            if (dsCom.Tables[0].Rows.Count > 0)
                            {
                                defaultObj.Add("Id01", 0);
                                defaultObj.Add("CONTRACT_ID01", _CONTRACT_ID);
                                defaultObj.Add("PROD_ID01", model.PROD_ID);
                                defaultObj.Add("PROD_NAME01", model.PROD_NAME1);
                                defaultObj.Add("CONTRACT_PRICE01", dsCom.Tables[0].Rows[0]["COST"].ToString());
                                defaultObj.Add("CONTRACT_PRICE101", dsCom.Tables[0].Rows[0]["COST1"].ToString());
                                defaultObj.Add("CONTRACT_PRICE201", dsCom.Tables[0].Rows[0]["COST2"].ToString());
                                defaultObj.Add("USABLE01", true);
                                defaultObj.Add("Meno01", "");
                                defaultObj.Add("CRT_USER_ID01", OlUser.Manager_LoginName);
                                defaultObj.Add("CRT_DATETIME01", DateTime.Now.ToString());
                                defaultObj.Add("MOD_USER_ID01", OlUser.Manager_LoginName);
                                defaultObj.Add("MOD_DATETIME01", DateTime.Now.ToString());
                                Grid2.AddNewRecord(defaultObj, true);
                            }
                            else
                            {
                                FineUI.Alert.ShowInParent("添加失败", FineUI.MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            FineUI.Alert.ShowInParent("添加失败", FineUI.MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                FineUI.Alert.ShowInParent("添加失败:"+err.Message, FineUI.MessageBoxIcon.Information);
            }
        }


        #endregion

    }
}