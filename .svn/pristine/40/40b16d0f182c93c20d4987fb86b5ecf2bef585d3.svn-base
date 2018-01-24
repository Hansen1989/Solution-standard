using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution.Web.Managers.WebManage.Application;
using DotNet.Utilities;
using Solution.Logic.Managers;
using FineUI;
using System.Data;
using Solution.DataAccess.DataModel;
using Newtonsoft.Json.Linq;
using System.Text;


namespace Solution.Web.Managers.WebManage.Systems.SupplyCenter
{
 
   public partial class OrdersEditPro : PageBase
    {
        private bool AppendToEnd = false;
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";

                //绑定下拉列表
               // BranchBll.GetInstence().BandDropDownList(this, ddlParentId);
 
                //加载数据
              //  LoadData();

                LoadData1();

                // 删除选中单元格的客户端脚本
                string deleteScript = GetDeleteScript(Grid1);

                //  SNo	PROD_ID	PROD_NAME1	PROD_SPEC	PROD_UNIT	ON_QUAN	Cost	QUAN1	Order_QUAN	PROD_MEMO

                // 新增数据初始值
                JObject defaultObj = new JObject();

                defaultObj.Add("SNo", 0);
                defaultObj.Add("PROD_NAME1", "0");
                defaultObj.Add("PROD_ID", "0");
                // defaultObj.Add("PROD_NAME1", "请选择");
                defaultObj.Add("PROD_SPEC", "");
                defaultObj.Add("PROD_UNIT", "");

                defaultObj.Add("ON_QUAN", 1);
                defaultObj.Add("Cost", 0);

                defaultObj.Add("QUAN1", 0);
                defaultObj.Add("Delete", String.Format("<a href=\"javascript:;\" onclick=\"{0}\"><img src=\"{1}\"/></a>", deleteScript, IconHelper.GetResolvedIconUrl(Icon.Delete)));

                // 在第一行新增一条数据
                btnNew.OnClientClick = Grid1.GetAddNewRecordReference(defaultObj, AppendToEnd);

                // 重置表格
                btnReset.OnClientClick = Confirm.GetShowReference("确定要重置表格数据？", String.Empty, Grid1.GetRejectChangesReference(), String.Empty);


                // 删除选中行按钮
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference("请至少选择一项！") + deleteScript;


                // 绑定表格
              //  BindGrid();



            }
        }
        #endregion

        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        public override void Init()
        {

        }
        #endregion

        public void LoadData1() 
        {
            DataTable table = GetSourceData();

            Grid1.DataSource = table;
            Grid1.DataBind();

        
        }

        #region 加载数据
        /// <summary>读取数据</summary>
        public override void LoadData()
        {
             


            int id = ConvertHelper.Cint0(hidId.Text);
            if (id != 0)
            {
                
                //获取指定ID的菜单内容，如果不存在，则创建一个菜单实体
                var model = ORDER00Bll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                txtSHOP_ID.Text = model.SHOP_ID;

                txtORDER_ID.Text = model.ORD_DEP_ID;

                txtINPUT_DATE.Text = model.INPUT_DATE.ToString();
                txtORD_USER.Text = model.ORD_USER;
                ddlEXPECT_DATE.SelectedDate = model.EXPECT_DATE;

                ddlStatus.SelectedValue = model.STATUS.ToString();

                ddlORD_TYPE.SelectedValue = model.ORD_TYPE.ToString();

                ddlOUT_SHOP.Text = model.OUT_SHOP;
                txtEXPORTED_ID.Text = model.EXPORTED_ID.ToString();
                txtEXPORTED.Text = model.EXPORTED.ToString();
                txtAPP_USER.Text = model.APP_USER;
                txtAPP_DATE.Text = model.APP_DATE.ToString();
                txtMemo.Text = model.Memo;
                cbLOCKED.Checked = ConvertHelper.IsInt(model.LOCKED);

                ddlBranch.SelectedValue = model.ORD_DEP_ID;

                txtCRT_DATETIME.Text = model.CRT_DATETIME.ToString();
                txtCRT_USER_ID.Text = model.CRT_USER_ID.ToString();
                txtMOD_DATETIME.Text = model.MOD_DATETIME.ToString();
                txtMOD_USER_ID.Text = model.MOD_USER_ID.ToString();
                txtLAST_UPDATE.Text = model.LAST_UPDATE.ToString();
                txtTrans_STATUS.Text = model.Trans_STATUS.ToString();


            }
            else { //添加

                //表头
                SHOP00Bll.GetInstence().BandDropDownListShowShop(this, ddlShop,""); //分店名称

                txtINPUT_DATE.SelectedDate = DateTime.Now; //单据时间

                ddlStatus.SelectedValue = "1";//状态

                ddlEXPECT_DATE.SelectedDate = DateTime.Now.AddDays(1);

                int managerId = OnlineUsersBll.GetInstence().GetManagerId();//获取登录名
                txtManage.Text = OnlineUsersBll.GetInstence().GetManager_LoginName(this,managerId,true);
 
             

            }

          //  FineUI.DropDownList dddlPROD_NAME2 = Window2.FindControl("ddlPROD_NAME2") as FineUI.DropDownList;

          //  PRODUCT00Bll.GetInstence().BandDropDownListShowProductName1(this, dddlPROD_NAME2);
         //   dddlPROD_NAME2.SelectedIndexChanged += new EventHandler(ddlPROD_NAME2_SelectedIndexChanged);
       
            // ddlPROD_NAME2
            
            DataTable table = GetSourceData();

            Grid1.DataSource = table;
            Grid1.DataBind();

 
        }

        #endregion

 
 

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
                    txtSHOP_ID.Text = ddlShop.SelectedValue;

                    Random ran=new Random();
                    txtORDER_ID.Text = txtSHOP_ID.Text + "OR" + DateTime.Now.ToString("YYYY-MM-DD") + ran.Next(1000, 9999);

                    //获取当前节点的父节点url
                  //  txtUrl.Text = MenuInfoBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(ddlParentId.SelectedValue), MenuInfoTable.Url) + "";
                }
                catch
                {
                }
            }
        }
        #endregion


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

                //if (string.IsNullOrEmpty(txtAREA_NAME.Text.Trim()))
                //{
                //    return txtAREA_NAME.Label + "不能为空！";
                //}
                //var sName = StringHelper.Left(txtName.Text, 50);
                //if (BranchBll.GetInstence().Exist(x => x.Name == sName && x.Id != id))
                //{
                //    return txtName.Label + "已存在！请重新输入！";
                //}
                //if (string.IsNullOrEmpty(txtId.Text.Trim()))
                //{
                //    return txtId.Label + "不能为空！";
                //}
                //var sUrl = StringHelper.Left(txtUrl.Text, 400);
                //if (BranchBll.GetInstence().Exist(x => x.Url == sUrl && x.Id != id))
                //{
                //    return txtUrl.Label + "已存在！请重新输入！";
                //}

                #endregion

                #region 赋值
                //读取资料
                var model = new ORDER00(x => x.Id == id);

                model.SHOP_ID = txtSHOP_ID.Text;
                model.ORDER_ID = txtORDER_ID.Text;
                model.INPUT_DATE = DateTime.Now;// ConvertHelper.StringToDatetime(txtINPUT_DATE.Text);
                model.ORD_USER = txtORD_USER.Text;
                model.EXPECT_DATE = DateTime.Now;// ConvertHelper.StringToDatetime(txtEXPECT_DATE.Text);
                model.STATUS = ConvertHelper.Cint0(ddlStatus.SelectedValue);
                model.ORD_TYPE = ConvertHelper.Cint0(ddlORD_TYPE.SelectedValue);
                model.OUT_SHOP = ddlOUT_SHOP.SelectedValue;
                model.EXPORTED_ID = txtEXPORTED_ID.Text;
                model.EXPORTED = ConvertHelper.StringToByte(txtEXPORTED.Text);
                model.APP_USER = txtAPP_USER.Text;
                model.APP_DATE = DateTime.Now;//ConvertHelper.StringToDatetime(txtAPP_DATE.Text);
                model.Memo = txtMemo.Text;
                model.LOCKED = ConvertHelper.StringToByte(cbLOCKED.Checked.ToString());

                model.ORD_DEP_ID = ddlBranch.SelectedValue;
                model.CRT_DATETIME = DateTime.Now;//ConvertHelper.StringToDatetime(txtCRT_DATETIME.Text);
                model.CRT_USER_ID = txtCRT_USER_ID.Text;
                model.MOD_DATETIME = DateTime.Now;//ConvertHelper.StringToDatetime(txtMOD_DATETIME.Text);
                model.MOD_USER_ID = txtMOD_USER_ID.Text;
                model.LAST_UPDATE = DateTime.Now;//ConvertHelper.StringToDatetime(txtLAST_UPDATE.Text);
                model.Trans_STATUS = ConvertHelper.StringToByte(txtTrans_STATUS.Text);

 
                #endregion

                //----------------------------------------------------------
                //存储到数据库
                ORDER00Bll.GetInstence().Save(this, model);
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

        protected void Windows2_Load(object sender, EventArgs e) 
        {
             
        
        }

        #region Events

        protected void Grid1_PreDataBound(object sender, EventArgs e)
        {

            // 设置LinkButtonField的点击客户端事件
            LinkButtonField deleteField = Grid1.FindColumn("Delete") as LinkButtonField;
            deleteField.OnClientClick = GetDeleteScript(Grid1);

            PRODUCT00Bll.GetInstence().BandDropDownListShowProductName_1(this, DropDownList1,"");  // (System.Web.UI.WebControls.DropDownList)
            //DropDownList1.DataTextField = PRODUCT00Table.PROD_NAME1;
            //DropDownList1.DataValueField = PRODUCT00Table.PROD_ID;

            // DropDownList1.SelectedValue = ((System.Data.DataRowView)(row)).Row.Table.Rows[e.RowIndex][PRODUCT00Table.PROD_ID].ToString();
        }

        protected void Grid1_PreRowDataBound(object sender, GridPreRowEventArgs e)
        {
            // 如果绑定到 DataTable，那么这里的 DataItem 就是 DataRowView
            DataRowView row = e.DataItem as DataRowView;
            int d = e.RowIndex;

            int j = Grid1.Rows.Count;

            PRODUCT00Bll.GetInstence().BandDropDownListShowProductName_1(this, (System.Web.UI.WebControls.DropDownList)Grid1.Rows[e.RowIndex].FindControl("DropDownList1"));
            DropDownList1.SelectedValue = ((System.Data.DataRowView)(row)).Row.Table.Rows[e.RowIndex][PRODUCT00Table.PROD_ID].ToString();

            //PROD_KINDBll.GetInstence().BandDropDownListShowKind(this, (System.Web.UI.WebControls.DropDownList)Grid1.Rows[e.RowIndex].FindControl("DropDownList1"));
            //DropDownList1.SelectedValue = ((System.Data.DataRowView)(row)).Row.Table.Rows[e.RowIndex][PROD_DEPTable.KIND_ID].ToString();
        }


        private DataRow CreateNewData(DataTable table, Dictionary<string, object> newAddedData)
        {
            DataRow rowData = table.NewRow();

            // 设置行ID（模拟数据库的自增长列）
            rowData["SNo"] = GetNextRowID();
            UpdateDataRow(newAddedData, rowData);

            return rowData;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // 修改的现有数据
            Dictionary<int, Dictionary<string, object>> modifiedDict = Grid1.GetModifiedDict();
            foreach (int rowIndex in modifiedDict.Keys)
            {
                int rowID = Convert.ToInt32(Grid1.DataKeys[rowIndex][0]);
                DataRow row = FindRowByID(rowID);

                UpdateDataRow(modifiedDict[rowIndex], row);
            }


            // 删除现有数据
            List<int> deletedRows = Grid1.GetDeletedList();
            foreach (int rowIndex in deletedRows)
            {
                int rowID = Convert.ToInt32(Grid1.DataKeys[rowIndex][0]);
                DeleteRowByID(rowID);
            }


            // 新增数据
            List<Dictionary<string, object>> newAddedList = Grid1.GetNewAddedList();
            DataTable table = GetSourceData();
            if (AppendToEnd)
            {
                for (int i = 0; i < newAddedList.Count; i++)
                {
                    DataRow rowData = CreateNewData(table, newAddedList[i]);
                    table.Rows.Add(rowData);
                }
            }
            else
            {
                for (int i = newAddedList.Count - 1; i >= 0; i--)
                {
                    DataRow rowData = CreateNewData(table, newAddedList[i]);
                    table.Rows.InsertAt(rowData, 0);
                }
            }


            labResult.Text = String.Format("用户修改的数据：<pre>{0}</pre>", Grid1.GetModifiedData().ToString(Newtonsoft.Json.Formatting.Indented));


            LoadData();

            ShowNotify("数据保存成功！（表格数据已重新绑定）");
        }

        private void UpdateDataRow(Dictionary<string, object> rowDict, DataRow rowData)
        {
            // 姓名
            UpdateDataRow("Name", rowDict, rowData);

            // 性别
            UpdateDataRow("Gender", rowDict, rowData);

            // 所学专业
            UpdateDataRow("Major", rowDict, rowData);

            // 语文成绩
            UpdateDataRow("ChineseScore", rowDict, rowData);

            // 数学成绩
            UpdateDataRow("MathScore", rowDict, rowData);

            // 总成绩
            UpdateDataRow("TotalScore", rowDict, rowData);

        }


        private void UpdateDataRow(string columnName, Dictionary<string, object> rowDict, DataRow rowData)
        {
            if (rowDict.ContainsKey(columnName))
            {
                rowData[columnName] = rowDict[columnName];
            }
        }

        #endregion

        #region Data

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "datatable_for_grid_editor_cell_updatecellvalue";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private DataTable GetSourceData()
        {
            DataSet ds = null;
            ds = ORDER00Bll.GetInstence().Get_ORDER01_PRODUCT00_PRODUCT01_("4","");

            if (Session[KEY_FOR_DATASOURCE_SESSION] == null)
            {
                Session[KEY_FOR_DATASOURCE_SESSION] = ds.Tables[0];// DataSourceUtil.GetEmptyDataTable();
            }
            return (DataTable)Session[KEY_FOR_DATASOURCE_SESSION];
        }

        // 根据行ID来获取行数据
        private DataRow FindRowByID(int rowID)
        {
            DataTable table = GetSourceData();
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["SNo"]) == rowID)
                {
                    return row;
                }
            }
            return null;
        }

        // 根据行ID来删除行数据
        private void DeleteRowByID(int rowID)
        {
            DataTable table = GetSourceData();

            DataRow found = FindRowByID(rowID);
            if (found != null)
            {
                table.Rows.Remove(found);
            }
        }

        // 模拟数据库的自增长列
        private int GetNextRowID()
        {
            int maxID = 0;
            DataTable table = GetSourceData();
            foreach (DataRow row in table.Rows)
            {
                int currentRowID = Convert.ToInt32(row["SNo"]);
                if (currentRowID > maxID)
                {
                    maxID = currentRowID;
                }
            }
            return maxID + 1;
        }

        #endregion

    }
}