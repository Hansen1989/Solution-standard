using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution.Web.Managers.WebManage.Application;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using FineUI;
using DotNet.Utilities;
using System.Data;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Transactions;

namespace Solution.Web.Managers.WebManage.Systems.SupplyCenter
{


    public partial class OrdersList : PageBase
    {
        private bool AppendToEnd = false;
        // protected string shop_id = "0";
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //获取ID值
                    hidId.Text = RequestHelper.GetInt0("Id") + "";
                    SHOP_hidId.Text = OnlineUsersBll.GetInstence().GetUserOnlineInfo("SHOP_ID").ToString();
 
                    //加载数据
                    LoadData();

                    // 删除选中单元格的客户端脚本
                    string deleteScript = GetDeleteScript(Grid1);

                    // 删除选中行按钮
                    btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference("请至少选择一项！") + deleteScript;
                    //deleteScript;

                    //按钮
                    //ButtonApproval.Enabled = false;
                    //ButtonSave.Enabled = false;
                }
                catch (Exception e1)
                {
                    MessageBox.Show(this, e1.Message);
                }
                //  LoadData();

            }
        }
        #endregion

        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        public override void Init()
        {


        }
        #endregion

        #region 加载数据
        /// <summary>读取数据</summary>
        public override void LoadData()
        {
            string shop_id = SHOP_hidId.Text.Trim();
            int managerId = OnlineUsersBll.GetInstence().GetManagerId();//获取登录名

            //表头
            SHOP00Bll.GetInstence().BandDropDownListShowShop(this, ddlShop, shop_id); //分店名称

            SHOP00Bll.GetInstence().BandDropDownListShowShop1(this, ddlOUT_SHOP); //供货分店
           // ORDER_DEP00Bll.GetInstence().BandDropDownList(this, ddlORDER_DEP, shop_id);//订货部门
            BranchBll.GetInstence().BandDropDownList(this,ddlORDER_DEP);

            HiddenDep_Id.Text = ddlORDER_DEP.SelectedValue;

            string manager_LoginName = OnlineUsersBll.GetInstence().GetUserOnlineInfo("Manager_LoginName").ToString();//登录名
            txtCRT_USER_ID.Text = manager_LoginName;
            txtORD_USER.Text = manager_LoginName;
            txtAPP_USER.Text = manager_LoginName;
            txtMOD_USER_ID.Text = manager_LoginName;

            txtINPUT_DATE.SelectedDate = DateTime.Now; //单据时间
            txtManage.Text = manager_LoginName;


            ddlStatus.SelectedValue = "0";//状态

            ddlEXPECT_DATE.SelectedDate = DateTime.Now.AddDays(1);
            txtCRT_DATETIME.SelectedDate = DateTime.Now;
            txtMOD_DATETIME.SelectedDate = DateTime.Now;


            txtEXPORTED_ID.Text = "";
           
            txtMemo.Text = "";
           
            cbTrans_STATUS.Checked = false;

            DataTable table = GetSourceData("", "");
            Grid1.DataSource = table;
            Grid1.DataBind();

                ///grid2
                // string shop_id = OnlineUsersBll.GetInstence().GetUserOnlineInfo("SHOP_ID").ToString();
           // conditionList = new List<ConditionFun.SqlqueryCondition>();
           // conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, ORDER00Table.SHOP_ID, Comparison.Equals, shop_id, false, false));

               //  ORDER00Bll.GetInstence().BindGrid(Grid2, 0, sortList);
               // bll.BindGrid(Grid2, 0, sortList);
          //  ORDER00Bll.GetInstence().BindGrid(Grid2, 0, 0, conditionList, sortList);
               //------------------


        }

        #endregion

        public override void Add()
        {
            ddlShop.SelectedValue = SHOP_hidId.Text.Trim();

            txtORDER_ID.Text = "";
            ddlStatus.SelectedIndex = 0;

            txtEXPORTED_ID.Text = "";
            txtEXPORTED.Checked = false;

            txtCRT_DATETIME.Text = DateTime.Now.ToString();

            txtLAST_UPDATE.Text = DateTime.Now.ToString();
            txtMOD_DATETIME.Text = DateTime.Now.ToString();

            //设置不可更改
            txtINPUT_DATE.Enabled = true;
            ddlEXPECT_DATE.Enabled = true;
            ddlORDER_DEP.Enabled = true;
            ddlORD_TYPE.Enabled = true;
            ddlEXPECT_DATE.Enabled = true;
            ddlOUT_SHOP.Enabled = true;
            txtMemo.Enabled = true;

            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            Grid1.Enabled = true;
            Grid1.Rows.Clear();

            ButtonPowers();

            //  txtManage.Text = OnlineUsersBll.GetInstence().GetManager_LoginName(this, managerId, true);
        }

        #region 页面控件绑定  分店
        /// <summary>下拉列表改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlShop_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!ddlShop.SelectedValue.Equals("0"))
            {
                try
                {
                    // txtSHOP_ID.Text = ddlShop.SelectedValue;

                    Random ran = new Random();
                    txtORDER_ID.Text = ddlShop.SelectedValue + "OR" + DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "") + ran.Next(1000, 9999);

                    /////获取当前节点的父节点url
                    //  txtUrl.Text = MenuInfoBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(ddlParentId.SelectedValue), MenuInfoTable.Url) + "";
                }
                catch
                {
                }
            }
        }
        #endregion

        protected void btnNew_Click(object sender, EventArgs e)
        {
            //判断

            if (ddlShop.SelectedValue == "0")
            {

                Alert.Show("门店名称不能为空！");
                return;
            }

            if (ddlOUT_SHOP.SelectedValue == "0")
            {

                Alert.Show("供货分店不能为空！");
                return;
            }

            if (ddlORDER_DEP.SelectedValue == "0")
            {

                Alert.Show("订货部门不能为空！");
                return;
            }

            // 新增数据初始值
            JObject defaultObj = new JObject();

            defaultObj.Add("PROD_NAME1", "0");
            defaultObj.Add("PROD_ID", "0");
            defaultObj.Add("PROD_SPEC", "");
            defaultObj.Add("PROD_UNIT", "");

            defaultObj.Add("ON_QUAN", "");
            defaultObj.Add("STD_PRICE", "0.00");

            defaultObj.Add("QUAN1", 0);
            defaultObj.Add("Order_QUAN", 1);
            defaultObj.Add("PROD_MEMO", "");

            // defaultObj.Add("Delete", String.Format("<a href=\"javascript:;\" onclick=\"{0}\"><img src=\"{1}\"/></a>", deleteScript, IconHelper.GetResolvedIconUrl(Icon.Delete)));

            // 在第一行新增一条数据
            // btnNew.OnClientClick = Grid1.GetAddNewRecordReference(defaultObj, AppendToEnd);

            Grid1.AddNewRecord(defaultObj, AppendToEnd);


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
                //判断
                if (ddlShop.SelectedValue == "0")
                {

                    return ddlShop.Label + "不能为空！";
                }

                if (ddlOUT_SHOP.SelectedValue == "0")
                {

                    return ddlOUT_SHOP.Label + "不能为空！";
                }

                if (ddlORDER_DEP.SelectedValue == "0")
                {

                    return ddlORDER_DEP.Label + "不能为空！";
                }
 

                //订单编号
                if (txtORDER_ID.Text == "")
                {
                    Random ran = new Random();
                    txtORDER_ID.Text = ddlShop.SelectedValue + "OR" + DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "") + ran.Next(1000, 9999);
                }

                string manager_LoginName = OnlineUsersBll.GetInstence().GetUserOnlineInfo("Manager_LoginName").ToString();//登录名

                txtAPP_USER.Text = manager_LoginName;
                txtAPP_DATE.SelectedDate = DateTime.Now;

                string ORDER_ID = txtORDER_ID.Text; // GridViewHelper.GetSelectedKey(Grid2, true);

                //获取价格区域
                string shop_id = OnlineUsersBll.GetInstence().GetUserOnlineInfo("SHOP_ID").ToString();
                var model_SHOP = new SHOP00(x => x.SHOP_ID == shop_id);

                string prcarea_id = model_SHOP.SHOP_Price_Area;

                // 复制原始表格的结构
                DataTable newTable = GetSourceData(ORDER_ID, prcarea_id).Clone();
                DataRow newRow;

                JArray mergedData = Grid1.GetMergedData();

                int i = 0;
                foreach (JObject mergedRow in mergedData)
                {

                    string status = mergedRow.Value<string>("status");
                    int rowIndex = mergedRow.Value<int>("index");
                    JObject values = mergedRow.Value<JObject>("values");

                    i = i + 1;
                    newRow = newTable.NewRow();
                    newRow[0] = rowIndex;//i;////j;// rowIndex; // 将行标识符设置为行索引号
                    newRow[1] = values.Value<string>("PROD_NAME1");
                    newRow[2] = values.Value<string>("PROD_ID");
                    newRow[3] = values.Value<string>("PROD_SPEC");
                    newRow[4] = values.Value<string>("PROD_UNIT");
                    newRow[5] = values.Value<string>("ON_QUAN");
                    newRow[6] = values.Value<string>("STD_PRICE");
                    newRow[7] = values.Value<string>("QUAN1");
                    newTable.Rows.Add(newRow);

                }

                // 更新数据源
                Session[KEY_FOR_DATASOURCE_SESSION] = newTable;

                labResult.Text = "";// String.Format("用户修改的数据：<pre>{0}</pre>", Grid1.GetModifiedData().ToString(Newtonsoft.Json.Formatting.Indented));
                                    //   MessageBox.Show(this,String.Format("用户修改的数据：<pre>{0}</pre>", Grid1.GetModifiedData().ToString(Newtonsoft.Json.Formatting.Indented)));

                // DataTable table = GetSourceData();

                Grid1.DataSource = (DataTable)Session[KEY_FOR_DATASOURCE_SESSION];// table;
                Grid1.DataBind();

                #region 数据验证

                //判断列表
                DataTable dt = (DataTable)Session[KEY_FOR_DATASOURCE_SESSION];
                if (dt.Rows.Count <= 0 || Session[KEY_FOR_DATASOURCE_SESSION] == null)
                {
                    return "要货明细不能为空!";

                }

                #endregion

                //改变界面
                ddlStatus.SelectedValue = "1" + "";

                #region 赋值  主表

                var model = new ORDER00(x => x.ORDER_ID == ORDER_ID);

                model.SHOP_ID = ddlShop.SelectedValue;
                model.ORDER_ID = txtORDER_ID.Text;
                model.INPUT_DATE = DateTime.Now;// ConvertHelper.StringToDatetime(txtINPUT_DATE.Text);
                model.ORD_USER = txtORD_USER.Text;
                model.EXPECT_DATE = DateTime.Now;// ConvertHelper.StringToDatetime(txtEXPECT_DATE.Text);
                model.STATUS = 1;
                model.ORD_TYPE = ConvertHelper.Cint0(ddlORD_TYPE.SelectedValue);
                model.OUT_SHOP = ddlOUT_SHOP.SelectedValue;
                model.EXPORTED_ID = txtEXPORTED_ID.Text;
                model.EXPORTED = ConvertHelper.StringToByte(txtEXPORTED.Text);
                model.APP_USER = txtAPP_USER.Text;
                model.APP_DATE = DateTime.Now;//ConvertHelper.StringToDatetime(txtAPP_DATE.Text);
                model.Memo = txtMemo.Text;
                model.LOCKED = ConvertHelper.StringToByte(cbLOCKED.Checked.ToString());

                model.ORD_DEP_ID = ddlORDER_DEP.SelectedValue;
                model.CRT_DATETIME = DateTime.Now;//ConvertHelper.StringToDatetime(txtCRT_DATETIME.Text);
                model.CRT_USER_ID = txtCRT_USER_ID.Text;
                model.MOD_DATETIME = DateTime.Now;//ConvertHelper.StringToDatetime(txtMOD_DATETIME.Text);
                model.MOD_USER_ID = txtMOD_USER_ID.Text;
                model.LAST_UPDATE = DateTime.Now;//ConvertHelper.StringToDatetime(txtLAST_UPDATE.Text);
                model.Trans_STATUS = 0;

                #endregion

                //----------------------------------------------------------
                //存储到数据库
                ORDER00Bll.GetInstence().Save(this, model);

                //清空子表
                ORDER00Bll.GetInstence().Delete(model.ORDER_ID);

                #region 添加子表

                JArray mergedData1 = Grid1.GetMergedData();
                int f = mergedData.Count;

                int k = 0;
                foreach (JObject mergedRow in mergedData1)
                {

                    string status = mergedRow.Value<string>("status");
                    int rowIndex = mergedRow.Value<int>("index");
                    JObject values = mergedRow.Value<JObject>("values");

                    k = k + 1;

                    var model_1 = new ORDER01(x => x.SNo == k && x.ORDER_ID == txtORDER_ID.Text.Trim());
 
                    model_1.SNo = k;// rowIndex + 1;

                    model_1.SHOP_ID = ddlShop.SelectedValue;
                    model_1.ORDER_ID = txtORDER_ID.Text.Trim();

                    model_1.PROD_ID = values.Value<string>("PROD_ID");
                    model_1.QUANTITY = 0;
                    model_1.ON_QUAN = ConvertHelper.StringToDecimal(values.Value<string>("ON_QUAN"));
                    model_1.QUAN1 = ConvertHelper.StringToDecimal(values.Value<string>("QUAN1"));//小计
                    model_1.QUAN2 = 0;
                    model_1.COST_PRICE = ConvertHelper.StringToDecimal(values.Value<string>("STD_PRICE"));
                    model_1.STD_UNIT = values.Value<string>("PROD_UNIT");
                    model_1.STD_CONVERT = 0;
                    model_1.STD_QUAN = ConvertHelper.StringToDecimal(values.Value<string>("ON_QUAN"));
                    model_1.STD_PRICE = ConvertHelper.StringToDecimal(values.Value<string>("STD_PRICE"));
                    model_1.Memo = "";
                    model_1.CRT_DATETIME = DateTime.Now;
                    model_1.CRT_USER_ID = txtCRT_USER_ID.Text;
                    model_1.MOD_DATETIME = DateTime.Now;
                    model_1.MOD_USER_ID = txtMOD_USER_ID.Text;

                    model_1.STD_TYPE = "";

                    try {
                        ORDER01Bll.GetInstence().Save(this, model_1);
                    } catch (Exception ee) {
                        result = "保存失败！";
                        CommonBll.WriteLog(result + ":" + DateTime.Now.ToString(), ee );
                    }
                    //----------------------------------------------------------
                    //存储到数据库
                    
                }

                ///grid2

                conditionList = new List<ConditionFun.SqlqueryCondition>();
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, ORDER00Table.SHOP_ID, Comparison.Equals, shop_id, false, false));

                //  ORDER00Bll.GetInstence().BindGrid(Grid2, 0, sortList);
                // bll.BindGrid(Grid2, 0, sortList);
                ORDER00Bll.GetInstence().BindGrid(Grid2, 0, 0, conditionList, sortList);

                #endregion



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

        // 删除选中行的脚本
        private string GetDeleteScript()
        {
            return Confirm.GetShowReference("删除选中行？", String.Empty, MessageBoxIcon.Question, Grid1.GetDeleteSelectedRowsReference(), String.Empty);
        }


        #region Events

        protected void Grid1_PreDataBound(object sender, EventArgs e)
        {

            // 设置LinkButtonField的点击客户端事件
            // LinkButtonField deleteField = Grid1.FindColumn("Delete") as LinkButtonField;
            //  deleteField.OnClientClick = GetDeleteScript(Grid1);

            string SHOP_ID = OnlineUsersBll.GetInstence().GetUserOnlineInfo("SHOP_ID").ToString();
          //  string ORDER_DEP_VALUE = ddlORDER_DEP.SelectedValue;

            if (SHOP_ID != "0")
            {
                PRODUCT00Bll.GetInstence().BandDropDownListShowProductName_1(this, DropDownList1, SHOP_ID);  // (System.Web.UI.WebControls.DropDownList)
            }

            //DropDownList1.DataTextField = PRODUCT00Table.PROD_NAME1;
            //DropDownList1.DataValueField = PRODUCT00Table.PROD_ID;

            // DropDownList1.SelectedValue = ((System.Data.DataRowView)(row)).Row.Table.Rows[e.RowIndex][PRODUCT00Table.PROD_ID].ToString();
        }

        protected void Grid1_PreRowDataBound(object sender, GridPreRowEventArgs e)
        {
            // 如果绑定到 DataTable，那么这里的 DataItem 就是 DataRowView
            //  DataRowView row = e.DataItem as DataRowView;

            //    PRODUCT00Bll.GetInstence().BandDropDownListShowProductName_1(this, (System.Web.UI.WebControls.DropDownList)Grid1.Rows[e.RowIndex].FindControl("DropDownList1"));
            //    DropDownList1.SelectedValue = ((System.Data.DataRowView)(row)).Row.Table.Rows[e.RowIndex][PRODUCT00Table.PROD_ID].ToString();

            //PROD_KINDBll.GetInstence().BandDropDownListShowKind(this, (System.Web.UI.WebControls.DropDownList)Grid1.Rows[e.RowIndex].FindControl("DropDownList1"));
            //DropDownList1.SelectedValue = ((System.Data.DataRowView)(row)).Row.Table.Rows[e.RowIndex][PROD_DEPTable.KIND_ID].ToString();
        }


        #region 列表按键绑定——修改列表控件属性
        /// <summary>
        /// 列表按键绑定——修改列表控件属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid2_PreRowDataBound(object sender, FineUI.GridPreRowEventArgs e)
        {
            //绑定是否显示状态列
            int o = e.RowIndex;

            DataRowView row = e.DataItem as DataRowView;
            string shop_id = ((System.Data.DataRowView)(row)).Row.Table.Rows[e.RowIndex][ORDER00Table.SHOP_ID].ToString();

            var model = new SHOP00(x => x.SHOP_ID == shop_id);
            if (model != null)
            {
                // ((System.Data.DataRowView)(gr.DataItem)).Row[e.RowIndex]
                var tf = Grid2.FindColumn("SHOP_LINK") as FineUI.LinkButtonField;

                tf.Text = model.SHOP_NAME1;

            }

        }
        #endregion


        public override void Approval()
        {
            string manager_LoginName = OnlineUsersBll.GetInstence().GetUserOnlineInfo("Manager_LoginName").ToString();//登录名

            txtAPP_USER.Text = manager_LoginName;
            txtAPP_DATE.SelectedDate = DateTime.Now;
            ddlStatus.SelectedValue = "2";

            string ORDER_ID = txtORDER_ID.Text.Trim();

            var model = new ORDER00(x => x.ORDER_ID == ORDER_ID);

            model.APP_USER = txtAPP_USER.Text;
            model.APP_DATE = ConvertHelper.StringToDatetime(txtAPP_DATE.SelectedDate.ToString());
            model.STATUS = 2;

            ORDER00Bll.GetInstence().Save(this, model);

            ButtonPowers();
        }


        #endregion

        public void ButtonPowers()
        {
            //按钮权限
            int IsButtonEnadble = ConvertHelper.Cint0(ddlStatus.SelectedValue);

            if (IsButtonEnadble == 0)//无
            {
                ButtonAdd.Enabled = true;
                ButtonSave.Enabled = true;
                ButtonApproval.Enabled = true;
                ButtonBackApproval.Enabled = false;
            }

            if (IsButtonEnadble == 1) //存档
            {
                ButtonAdd.Enabled = true;
                ButtonSave.Enabled = true;
                ButtonApproval.Enabled = true;
                ButtonBackApproval.Enabled = false;
            }

            if (IsButtonEnadble == 2)//核准
            { 
                ButtonAdd.Enabled = true;
                ButtonSave.Enabled = false;
                ButtonApproval.Enabled = false;
                ButtonBackApproval.Enabled = true;

                //设置不可更改
                txtINPUT_DATE.Enabled = false;
                ddlEXPECT_DATE.Enabled = false;
                ddlORDER_DEP.Enabled = false;
                ddlORD_TYPE.Enabled = false;
                ddlEXPECT_DATE.Enabled = false;
                ddlOUT_SHOP.Enabled = false;
                txtMemo.Enabled = false;

                btnNew.Enabled = false;
                btnDelete.Enabled = false;
                Grid1.Enabled = false;
            }

            if (IsButtonEnadble == 3)//作废
            {
                ButtonAdd.Enabled = true;
                ButtonSave.Enabled = false;
                ButtonApproval.Enabled = false;
                ButtonBackApproval.Enabled = false;
            }

            if (IsButtonEnadble == 4)//已汇整
            {
                ButtonAdd.Enabled = true;
                ButtonSave.Enabled = false;
                ButtonApproval.Enabled = false;
                ButtonBackApproval.Enabled = false;

                //设置不可更改
                txtINPUT_DATE.Enabled = false;
                ddlEXPECT_DATE.Enabled = false;
                ddlORDER_DEP.Enabled = false;
                ddlORD_TYPE.Enabled = false;
                ddlEXPECT_DATE.Enabled = false;
                ddlOUT_SHOP.Enabled = false;
                txtMemo.Enabled = false;

                btnNew.Enabled = false;
                btnDelete.Enabled = false;
                Grid1.Enabled = false;

            }
        }


        #region Data

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "datatable_for_grid_editor_cell_updatecellvalue";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private DataTable GetSourceData(string order_id, string prcarea_id)
        {
            //  DataTable dt = (DataTable)Session[KEY_FOR_DATASOURCE_SESSION];

            //if (Session[KEY_FOR_DATASOURCE_SESSION] == null)
            //{
            Session[KEY_FOR_DATASOURCE_SESSION] = GetDataTable(order_id, prcarea_id);// DataSourceUtil.GetEmptyDataTable();
                                                                                     // }
            return (DataTable)Session[KEY_FOR_DATASOURCE_SESSION];
        }

        protected void Grid2_RowSelect(object sender, FineUI.GridRowSelectEventArgs e)
        {
            string ORDER_ID = GridViewHelper.GetSelectedKey(Grid2, true);

            if (ORDER_ID != "")
            {

                //获取指定ID的菜单内容，如果不存在，则创建一个菜单实体
                var model = ORDER00Bll.GetInstence().GetModelForCache(x => x.ORDER_ID == ORDER_ID);
                if (model == null)
                    return;

                //txtSHOP_ID.Text = model.SHOP_ID;
                ddlShop.SelectedValue = model.SHOP_ID + "";
                txtORDER_ID.Text = model.ORDER_ID;

                txtINPUT_DATE.SelectedDate = ConvertHelper.StringToDatetime(model.INPUT_DATE.ToString());

                txtORD_USER.Text = model.ORD_USER;
                ddlEXPECT_DATE.SelectedDate = model.EXPECT_DATE;

                ddlStatus.SelectedValue = model.STATUS + "";

                ddlORD_TYPE.SelectedValue = model.ORD_TYPE.ToString();

                ddlOUT_SHOP.Text = model.OUT_SHOP;
                txtEXPORTED_ID.Text = model.EXPORTED_ID.ToString();
                txtEXPORTED.Checked = ConvertHelper.IsFloat(model.EXPORTED.ToString());
                txtAPP_USER.Text = model.APP_USER;
                txtAPP_DATE.Text = model.APP_DATE.ToString();
                txtMemo.Text = model.Memo;
                cbLOCKED.Checked = ConvertHelper.IsInt(model.LOCKED);

                ddlORDER_DEP.SelectedValue = model.ORD_DEP_ID + "";

                txtCRT_DATETIME.SelectedDate = ConvertHelper.StringToDatetime(model.CRT_DATETIME.ToString());
                txtCRT_USER_ID.Text = model.CRT_USER_ID.ToString();
                txtMOD_DATETIME.SelectedDate = ConvertHelper.StringToDatetime(model.MOD_DATETIME.ToString());
                txtMOD_USER_ID.Text = model.MOD_USER_ID.ToString();
                txtLAST_UPDATE.Text = model.LAST_UPDATE.ToString();
                cbTrans_STATUS.Checked = model.Trans_STATUS == 0 ? false : true;

                //价格区域
                //var model_shop =new SHOP00(x => x.SHOP_ID == model.SHOP_ID);

                //string prcarea_id = model_shop.SHOP_Price_Area;
                DataTable table = GetSourceData(ORDER_ID, "0"); //获取订单下面所有的商品信息

                Grid1.DataSource = table;
                Grid1.DataBind();
            }



            //按钮权限
            ButtonPowers();

        }

        public DataTable GetDataTable(string ORDER_ID, string PRCAREA_ID)
        {
            DataSet ds = null;
            if (ORDER_ID != "" && PRCAREA_ID != "")
            {
                ds = ORDER00Bll.GetInstence().Get_ORDER01_PRODUCT00_PRODUCT01_(ORDER_ID, PRCAREA_ID);
            }


            DataTable table = new DataTable();
            // table.Columns.Add(new DataColumn("SNo", typeof(int)));
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            table.Columns.Add(new DataColumn("PROD_NAME1", typeof(String)));
            table.Columns.Add(new DataColumn("PROD_ID", typeof(String)));
            table.Columns.Add(new DataColumn("PROD_SPEC", typeof(String)));
            table.Columns.Add(new DataColumn("PROD_UNIT", typeof(String)));
            table.Columns.Add(new DataColumn("ON_QUAN", typeof(String)));
            table.Columns.Add(new DataColumn("STD_PRICE", typeof(String)));
            table.Columns.Add(new DataColumn("QUAN1", typeof(String)));
            table.Columns.Add(new DataColumn("Order_QUAN", typeof(String)));
            table.Columns.Add(new DataColumn("PROD_MEMO", typeof(String)));

            int i = 0;
            if (ds != null)
            {
                DataRow row;
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    i = i + 1;
                    row = table.NewRow();
                    row[0] = i;//int.Parse(item["SNo"].ToString()); //
                    row[1] = item["PROD_NAME1"].ToString();
                    row[2] = item["PROD_ID"].ToString();
                    row[3] = item["PROD_SPEC"].ToString();
                    row[4] = item["PROD_UNIT"].ToString();
                    row[5] = item["ON_QUAN"].ToString();
                    row[6] = item["STD_PRICE"].ToString();
                    row[7] = item["QUAN1"].ToString();
                    row[8] = item["Order_QUAN"].ToString();
                    row[9] = item["PROD_MEMO"].ToString();

                    table.Rows.Add(row);

                }

            }

            return table;

        }


        #endregion

        protected void ddlORDER_DEP_SelectedIndexChanged(object sender, EventArgs e)
        {
 
            JArray mergedData = Grid1.GetMergedData();
            int gridrowsCount = mergedData.Count;

            if (gridrowsCount > 0)
            {
                Window1.Hidden = false;
            }

            string SHOP_ID = OnlineUsersBll.GetInstence().GetUserOnlineInfo("SHOP_ID").ToString();
            string ORDER_DEP_VALUE = ddlORDER_DEP.SelectedValue;

            if (SHOP_ID != "0")
            {
                PRODUCT00Bll.GetInstence().BandDropDownListShowProductName_1(this, DropDownList1, SHOP_ID);  // (System.Web.UI.WebControls.DropDownList)
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //清空列表
            // Grid1.RejectChanges();
            HiddenDep_Id.Text = ddlORDER_DEP.SelectedValue;

            Session[KEY_FOR_DATASOURCE_SESSION] = null;
            // }
            Grid1.DataSource = (DataTable)Session[KEY_FOR_DATASOURCE_SESSION];
            Grid1.DataBind();

            Window1.Hidden = true;


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            ddlORDER_DEP.SelectedValue = HiddenDep_Id.Text.Trim();

            Window1.Hidden = true;
 
        }

        protected void ButtonSearch1_Click(object sender, EventArgs e)
        {

            // ddlORDER_DEP.SelectedValue = HiddenDep_Id.Text.Trim();
            LoadDate();

            Window2.Hidden = false;

        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {

            Grid2.Rows.Clear();

            //判断
            FineUI.RadioButton RaddpUp_Date = Window2.FindControl("A").FindControl("RaddpUp_Date") as FineUI.RadioButton;
            FineUI.RadioButton RadEXPECT_DATE = Window2.FindControl("B").FindControl("RadEXPECT_DATE") as FineUI.RadioButton;

            if (RaddpUp_Date.Checked == false && RadEXPECT_DATE.Checked == false)
            {
                Alert.Show("请选择时间");
                return;

            }

            string Start_Time = "";
            string End_Time = "";

            //获取时间
            DatePicker dpUp_DateBeg = Window2.FindControl("A").FindControl("dpUp_DateBeg") as DatePicker;
            DateTime dt_up_date_bg = ConvertHelper.StringToDatetime(DateTime.Parse(dpUp_DateBeg.SelectedDate.ToString()).ToString("yyyy-MM-dd 00:00:00"));

            DatePicker dpUp_DateEnd = Window2.FindControl("A").FindControl("dpUp_DateEnd") as DatePicker;
            DateTime dt_up_date_end = ConvertHelper.StringToDatetime(DateTime.Parse(dpUp_DateEnd.SelectedDate.ToString()).ToString("yyyy-MM-dd 23:59:59"));

            DatePicker dpEXPECT_DATEBeg = Window2.FindControl("B").FindControl("dpEXPECT_DATEBeg") as DatePicker;
            DateTime dt_expect_date_bg = ConvertHelper.StringToDatetime(DateTime.Parse(dpEXPECT_DATEBeg.SelectedDate.ToString()).ToString("yyyy-MM-dd 00:00:00"));

            DatePicker dpEXPECT_DATEEnd = Window2.FindControl("B").FindControl("dpEXPECT_DATEEnd") as DatePicker;
            DateTime dt_expect_date_end = ConvertHelper.StringToDatetime(DateTime.Parse(dpEXPECT_DATEEnd.SelectedDate.ToString()).ToString("yyyy-MM-dd 23:59:59"));


            int IsTime = 1;
            if (RaddpUp_Date.Checked)
            {
                IsTime = 0;
                Start_Time = dt_up_date_bg.ToString();
                End_Time = dt_up_date_end.ToString();
            }

            if (RadEXPECT_DATE.Checked)
            {
                IsTime = 1;
                Start_Time = dt_expect_date_bg.ToString();
                End_Time = dt_expect_date_end.ToString();
            }

            string shop_id = SHOP_hidId.Text.Trim();
            string shop_name = OnlineUsersBll.GetInstence().GetUserOnlineInfo("SHOP_NAME1").ToString();
            string shop_idStr = ORDER00Table.SHOP_ID;

            if (shop_name.Contains("区域中心"))
            {
                IsTime = -1;
            }

            Session["SerchPars_session_Orders"] = Session["SerchPars_session"] = IsTime + "," + Start_Time + "," + End_Time;

            BandGrid2(shop_name, shop_idStr, shop_id, Start_Time, End_Time, IsTime);

            Window2.Hidden = true;
 
        }

        protected void btnCancel1_Click(object sender, EventArgs e)
        { 
            Window1.Hidden = true;


        }

        protected void LoadDate()
        {
            DatePicker dpUp_DateBeg = Window2.FindControl("A").FindControl("dpUp_DateBeg") as DatePicker;
            dpUp_DateBeg.SelectedDate = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd 00:00:01"));
            DatePicker dpUp_DateEnd = Window2.FindControl("A").FindControl("dpUp_DateEnd") as DatePicker;
            dpUp_DateEnd.SelectedDate = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));

            DatePicker dpEXPECT_DATEBeg = Window2.FindControl("B").FindControl("dpEXPECT_DATEBeg") as DatePicker;
            dpEXPECT_DATEBeg.SelectedDate = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd 00:00:01"));
            DatePicker dpEXPECT_DATEEnd = Window2.FindControl("B").FindControl("dpEXPECT_DATEEnd") as DatePicker;
            dpEXPECT_DATEEnd.SelectedDate = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));

            Window2.Title = "查询";
            
        }

        public void BandGrid2(string shop_name, string shop_idStr, string shop_id, string begTime, string endTime, int chooseSign)
        {

            conditionList = new List<ConditionFun.SqlqueryCondition>();

            if (chooseSign == 0)
            {
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, ORDER00Table.SHOP_ID, Comparison.Equals, shop_id, false, false));
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, ORDER00Table.INPUT_DATE, Comparison.BetweenAnd, begTime, false, false));
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, ORDER00Table.INPUT_DATE, Comparison.BetweenAnd, endTime, false, false));
            }
            else if (chooseSign == 1)
            {
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, ORDER00Table.SHOP_ID, Comparison.Equals, shop_id, false, false));
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, ORDER00Table.EXPECT_DATE, Comparison.BetweenAnd, begTime, false, false));
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, ORDER00Table.EXPECT_DATE, Comparison.BetweenAnd, endTime, false, false));
            }
            else if (chooseSign == -1)
            {
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "1", Comparison.Equals, "1", false, false));
            }


            //  ORDER00Bll.GetInstence().BindGrid(Grid2, 0, sortList);
            // bll.BindGrid(Grid2, 0, sortList);
            ORDER00Bll.GetInstence().BindGrid(Grid2, 0, 0, conditionList, sortList);
            //------------------


        }


    }
}