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
    public partial class OrderDep00 : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                //AddGrid2();
            }
        }

        /// <summary>
        /// 初始化对象
        /// </summary>
        public override void Init()
        {
            bll = ORDER_DEP00Bll.GetInstence();
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public override void LoadData()
        {
            //throw new NotImplementedException();.
            bll.BindGrid(Grid1, 0, 0, conditionList, sortList);
        }
        public void BtnDelete_Click(object sender, EventArgs e)
        {
            int id = ConvertHelper.Cint(GridViewHelper.GetSelectedKey(Grid1, true));
            string[] eCell = Grid1.SelectedCell;

            JArray upJson = Grid1.GetMergedData();
            DataTable da = new DataTable();
            for (int i = 0; i < upJson.Count; i++)
            {
                if (upJson[i]["status"].ToString() != "newadded" && upJson[i]["id"].ToString() == eCell[0].ToString())
                {
                    int _id = ConvertHelper.Cint(upJson[i]["values"]["Id"].ToString());
                    Grid1.DeleteSelectedRows();
                    ORDER_DEP00Bll.GetInstence().DeleteOrderDep00(_id);
                    hidORDDEP_ID.Text = "";
                    break;
                }
                else if(upJson[i]["status"].ToString() == "newadded" && upJson[i]["id"].ToString() == eCell[0].ToString())
                {
                    Grid1.DeleteSelectedRows();
                    hidORDDEP_ID.Text = "";
                    break;
                }
            }
            LoadData2("");
            LoadDepData();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public override string Save()
        {
            string result = "";
            JArray upJson = Grid1.GetMergedData();
            //result = COMPONENT00Check(upJson);
            //效验数据
            if (upJson.Count<1)
            {
                return "数据表为空，保存失败";
            }
            result = CheckOrderDop00(upJson);
            if (!String.IsNullOrEmpty(result))
            {
                return result;
            }
            //保存数据
            result = OrderDep00Save(upJson);
            if (!String.IsNullOrEmpty(result))
            {
                return result;
            }
            result = OrderDep02Save();
            LoadData();
            LoadData2("");
            LoadOrderDep01("");
            return result;
        }

        #region OrderDep00相关事件

        /// <summary>
        /// 订货部门新增一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonOrderDepNewRow_Clikc(object sender, EventArgs e)
        {
            JObject deObject = new JObject();
            deObject.Add("Id", "0");
            deObject.Add("ORDDEP_ID", "");
            deObject.Add("ORDDEP_NAME", "");
            deObject.Add("ORDER_WEEK", "");
            deObject.Add("USABLE", true);
            var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
            string lgname = OlUser.Manager_LoginName;
            deObject.Add("CRT_USER_ID", lgname);
            deObject.Add("CRT_DATETIME", DateTime.Now.ToString());
            deObject.Add("MOD_USER_ID", OlUser.Manager_LoginName);
            deObject.Add("MOD_DATETIME", DateTime.Now.ToString());
            Grid1.AddNewRecord(deObject, true);
        }
        /// <summary>
        /// OrderDep00保存
        /// </summary>
        /// <returns></returns>
        public string OrderDep00Save(JArray upJson)
        {
            string result = "";
            for (int i = 0; i < upJson.Count; i++)
            {
                try
                {
                    int _Id = ConvertHelper.Cint(upJson[i]["values"]["Id"].ToString());
                    var model = new ORDER_DEP00(x => x.Id == _Id);
                    if (upJson[i]["status"].ToString() == "newadded")
                    {
                        model.ORDDEP_ID = TABLE_SEEDBll.GetInstence().GetTableSeed("ORDER_DEP00", "", 0);
                    }
                    else
                    {
                        model.ORDDEP_ID = upJson[i]["values"]["ORDDEP_ID"].ToString();
                    }
                    model.ORDDEP_NAME = upJson[i]["values"]["ORDDEP_NAME"].ToString();
                    model.ORDER_WEEK = upJson[i]["values"]["ORDER_WEEK"].ToString();
                    //string a = upJson[i]["values"]["USABLE"].ToString();
                    if (upJson[i]["values"]["USABLE"].ToString() == "True")
                    { model.USABLE = 1; }
                    else
                    { model.USABLE = 0; }

                    model.CRT_USER_ID = upJson[i]["values"]["CRT_USER_ID"].ToString();
                    model.CRT_DATETIME = DateTime.Now;
                    var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                    model.MOD_DATETIME = DateTime.Now;
                    model.MOD_USER_ID = OlUser.Manager_LoginName;
                    ORDER_DEP00Bll.GetInstence().Save(this, model);
                }
                catch (Exception err)
                {
                    result = result + upJson[i]["values"]["ORDDEP_NAME"].ToString() + "相关数据保存失败" + Environment.NewLine;
                }

            }
            if (String.IsNullOrEmpty(result))
            {
                result = "";
            }
            //int i = aa.Count;

            return result;
        }
        /// <summary>
        /// 校验数据的完整性
        /// </summary>
        /// <param name="da"></param>
        /// <returns></returns>
        public string CheckOrderDop00(JArray upJson)
        {
            string result = "";
            DataTable depDa = new DataTable();
            for (int i = 0; i < upJson.Count; i++)
            {
                string upData = upJson[i]["values"].ToString();
                DataTable da = DotNet.Utilities.Json.JsonHelper.ToDataTable("[" + upData + "]");
                //upJson[i]["values"].ToString();
                if (depDa == null || depDa.Rows.Count == 0)
                {
                    depDa = da.Copy();
                }
                else
                {
                    depDa.Merge(da);
                }
                //if (String.IsNullOrEmpty(upJson[i]["values"]["ORDDEP_ID"].ToString()))
                //{
                //    result = result + "第" + (ConvertHelper.Cint(upJson[i]["index"]) + 1).ToString() + "行订货部门编码不能为空" + Environment.NewLine;
                //}
                if (String.IsNullOrEmpty(upJson[i]["values"]["ORDDEP_NAME"].ToString()))
                {
                    result = result + "第" + (ConvertHelper.Cint(upJson[i]["index"]) + 1).ToString() + "行订货部门名称不能为空" + Environment.NewLine;
                }
            }

            foreach (DataRow dr in depDa.Rows)
            {
                //DataRow[] arrId = depDa.Select("ORDDEP_ID='" + dr["ORDDEP_ID"].ToString() + "'");
                //if (arrId.Length > 1)
                //{
                //    result = result + "订货部门编码" + dr["ORDDEP_ID"].ToString() + "重复" + Environment.NewLine;
                //}
                DataRow[] arrName = depDa.Select("ORDDEP_NAME='" + dr["ORDDEP_NAME"].ToString() + "'");
                if (arrName.Length > 1)
                {
                    result = result + "订货部门名称：" + dr["ORDDEP_NAME"].ToString() + "重复" + Environment.NewLine;
                }
            }

            return result;
        }
        /// <summary>
        /// Grid1点击事件
        /// </summary>
        /// <param name="e"></param>
        public override void SingleClick(GridRowClickEventArgs e)
        {
            int o = e.RowIndex;
            string[] eCell = Grid1.SelectedCell;
            //string aa = Grid1.SelectedRowID;
            //int cc = Grid1.SelectedRowIndex;
            JArray upJson = Grid1.GetMergedData();
            JArray upJson2 = Grid2.GetMergedData();

            //(Grid1.FindColumn("ORDDEP_NAME").FindControl("tbxORDDEP_ID") as TextBox).Enabled = true;
            if (o >= 0)
            {

                int dataIndex = 0;
                ///通过点击得行数，找到数据
                for (int i = 0; i < upJson.Count; i++)
                {
                    if (upJson[i]["id"].ToString() == eCell[0].ToString())
                    {
                        dataIndex = i;
                        break;
                    }
                }
                hidORDDEP_ID.Text = upJson[dataIndex]["values"]["ORDDEP_ID"].ToString();
                if (upJson.Count > 0 && upJson2.Count > 0)
                {
                    if (upJson[dataIndex]["values"]["ORDDEP_ID"].ToString() != upJson2[0]["values"]["ORDDEP_ID1"].ToString())
                    {
                        string result = OrderDep02Save();
                        if (!String.IsNullOrEmpty(result))
                        {
                            FineUI.Alert.ShowInParent("订货类别保存失败:" + result, FineUI.MessageBoxIcon.Information);
                        }
                        int _Id = ConvertHelper.Cint(Grid1.DataKeys[dataIndex][0].ToString());
                        var model = new ORDER_DEP00(x => x.Id == _Id);
                        LoadData2(model.ORDDEP_ID);
                        LoadOrderDep01(model.ORDDEP_ID);
                    }
                }
                else
                {
                    int _Id = ConvertHelper.Cint(Grid1.DataKeys[o][0].ToString());
                    var model = new ORDER_DEP00(x => x.Id == _Id);
                    LoadData2(model.ORDDEP_ID);
                    LoadOrderDep01(model.ORDDEP_ID);
                    //LoadData2(model.COM_ID);
                    //hidCOM_ID.Text = model.COM_ID;
                }
            }
            else
            {
                hidORDDEP_ID.Text = "";
                LoadData2("");
                LoadOrderDep01("");
            }
        }
        #endregion

        #region OrderDep02相关事件
        public void LoadData2(string ORDDEP_ID)
        {
            //ORDER_DEP02Bll.GetInstence().BindGrid(Grid2, 0, 0, InquiryCondition(ORDDEP_ID), null);
            if (String.IsNullOrEmpty(ORDDEP_ID))
            {
                Grid2.DataSource = null;
                Grid2.DataBind();
                return;
            }
            V_ORDERDEP02_PRODDEPBll.GetInstence().BindGrid(Grid2, 0, 0, InquiryCondition(ORDDEP_ID), null);
        }

        private List<ConditionFun.SqlqueryCondition> InquiryCondition(string ORDDEP_ID)
        {
            List<ConditionFun.SqlqueryCondition> conditionProdduct00List = new List<ConditionFun.SqlqueryCondition>();
            conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, ORDER_DEP02Table.ORDDEP_ID, Comparison.Equals, ORDDEP_ID, false, false));
            return conditionProdduct00List;
        }
        protected void Grid2_PreDataBound(object sender, EventArgs e)
        {
            PROD_DEPBll.GetInstence().BandDropDownListShowDep(this, ddlDEP_NAME);
            //ddlDEP_NAME.SelectedValue = "001";
        }


        /// <summary>
        /// OrderDep02保存
        /// </summary>
        /// <returns></returns>
        public string OrderDep02Save()
        {
            JArray upJson = Grid2.GetMergedData();
            string result = "";
            if (upJson.Count < 1)
            {
                return "";
            }
            result = CheckOrderDop02(upJson);
            if (!String.IsNullOrEmpty(result))
            {
                return result;
            }

            for (int i = 0; i < upJson.Count; i++)
            {
                try
                {
                    int _Id = ConvertHelper.Cint(upJson[i]["values"]["Id1"].ToString());
                    var model = new ORDER_DEP02(x => x.Id == _Id);
                    model.ORDDEP_ID = upJson[i]["values"]["ORDDEP_ID1"].ToString();
                    model.DEP_ID = upJson[i]["values"]["DEP_ID1"].ToString();
                    if (upJson[i]["values"]["USABLE1"].ToString() == "True")
                    {
                        model.USABLE = 1;
                    }
                    else
                    {
                        model.USABLE = 0;
                    }
                    if (upJson[i]["values"]["Meno1"] == null)
                    {
                        model.Meno = "";
                    }
                    else
                    {
                        model.Meno = upJson[i]["values"]["Meno1"].ToString();
                    }
                    model.CRT_USER_ID = upJson[i]["values"]["CRT_USER_ID1"].ToString();
                    model.CRT_DATETIME = DateTime.Now;
                    var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                    model.MOD_DATETIME = DateTime.Now;
                    model.MOD_USER_ID = OlUser.Manager_LoginName;
                    ORDER_DEP02Bll.GetInstence().Save(this, model);
                }
                catch (Exception err)
                {
                    result = result + upJson[i]["values"]["DEP_NAME1"].ToString() + "相关数据保存失败" + Environment.NewLine;
                }

            }
            if (String.IsNullOrEmpty(result))
            {
                result = "";
            }

            //int i = aa.Count;

            return result;
        }

        /// <summary>
        /// 校验数据的完整性
        /// </summary>
        /// <param name="da"></param>
        /// <returns></returns>
        public string CheckOrderDop02(JArray upJson)
        {
            string result = "";
            DataTable depDa = new DataTable();
            if (upJson.Count < 1)
            {
                return "";
            }
            for (int i = 0; i < upJson.Count; i++)
            {
                string upData = upJson[i]["values"].ToString();
                DataTable da = DotNet.Utilities.Json.JsonHelper.ToDataTable("[" + upData + "]");
                //upJson[i]["values"].ToString();
                if (depDa == null || depDa.Rows.Count == 0)
                {
                    depDa = da.Copy();
                }
                else
                {
                    depDa.Merge(da);
                }
                if (String.IsNullOrEmpty(upJson[i]["values"]["ORDDEP_ID1"].ToString()))
                {
                    result = result + "订货类别:第" + (ConvertHelper.Cint(upJson[i]["index"]) + 1).ToString() + "行订货部门编码不能为空" + Environment.NewLine;
                }
            }

            foreach (DataRow dr in depDa.Rows)
            {
                DataRow[] arrName = depDa.Select("DEP_ID1='" + dr["DEP_ID1"].ToString() + "'");
                if (arrName.Length > 1)
                {
                    result = result + "订货类别：中类编码:" + dr["DEP_ID1"].ToString() + "重复" + Environment.NewLine;
                }
            }

            return result;
        }

        protected void Grid2Add_Click(object sender, EventArgs e)
        {
            FineUI.Alert.ShowInParent(hidORDDEP_ID.Text, FineUI.MessageBoxIcon.Information);
            if (!String.IsNullOrEmpty(hidORDDEP_ID.Text))
            {
                Window2.Hidden = false;
                LoadDepData();
            }
            else
            {
                FineUI.Alert.ShowInParent("请选中一个订货部门或者订货部门未保存", FineUI.MessageBoxIcon.Information);
            }
        }

        public void Grid2Delete_Click(object sender, EventArgs e)
        {
            int id = ConvertHelper.Cint(GridViewHelper.GetSelectedKey(Grid2, true));
            string[] eCell = Grid2.SelectedCell;

            JArray upJson = Grid2.GetMergedData();
            DataTable da = new DataTable();
            for (int i = 0; i < upJson.Count; i++)
            {
                if (upJson[i]["status"].ToString() != "newadded" && upJson[i]["id"].ToString() == eCell[0].ToString())
                {
                    int _id = ConvertHelper.Cint(upJson[i]["values"]["Id1"].ToString());
                    Grid2.DeleteSelectedRows();
                    ORDER_DEP02Bll.GetInstence().Delete(this,_id);
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
            //LoadData2("");
            //LoadDepData();
        }
        #endregion

        #region
        public void LoadOrderDep01(string ORDDER_ID)
        {
            if (String.IsNullOrEmpty(ORDDER_ID))
            {
                Grid4.DataSource = null;
                Grid5.DataSource = null;
                Grid4.DataBind();
                Grid5.DataBind();
            }
            ORDER_DEP01Bll.GetInstence().BandGrid(this, Grid4, 1, ORDDER_ID);
            ORDER_DEP01Bll.GetInstence().BandGrid(this, Grid5, 2, ORDDER_ID);
        }
        /// <summary>
        /// 添加可选分店清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MoveToLeft(object sender, EventArgs e)
        {
            //string[] a=Grid5.SelectedRowID;
            string[] id = GridViewHelper.GetSelectedKey(Grid5, true).Split(',');
            int _id = ConvertHelper.Cint(id[0]);
            var model = new SHOP00(x => x.Id == _id);
            string ordder_id = hidORDDEP_ID.Text;
            string result = SaveOrderDep01(model.SHOP_ID, ordder_id);
            if (!String.IsNullOrEmpty(result))
            {
                FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
            }
            LoadOrderDep01(ordder_id);
        }

        /// <summary>
        /// 添加全部可选分店清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MoveAllToLeft(object sender, EventArgs e)
        {
            string result = "";
            //Grid5.SelectAllRows();
            string ordder_id = hidORDDEP_ID.Text;
            //object[] rowDataKeys = Grid5.DataKeys[];
            for (int i = 0; i < Grid5.Rows.Count; i++)
            {
                Object[] rowDataKeys = Grid5.DataKeys[i];
                result = SaveOrderDep01(rowDataKeys[1].ToString(), ordder_id);
            }
            if (!String.IsNullOrEmpty(result))
            {
                FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
            }
            LoadOrderDep01(ordder_id);
        }

        /// <summary>
        /// 保存OrderDep01
        /// </summary>
        /// <param name="SHOP_ID"></param>
        /// <param name="ordder_id"></param>
        /// <returns></returns>
        public string SaveOrderDep01(string SHOP_ID, string ordder_id)
        {
            string result = "";
            try
            {
                var orddep01Model = new ORDER_DEP01();
                orddep01Model.ORDDEP_ID = ordder_id;
                orddep01Model.SHOP_ID = SHOP_ID;
                orddep01Model.USABLE = 1;
                orddep01Model.Meno = "";

                var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                orddep01Model.MOD_DATETIME = DateTime.Now;
                orddep01Model.MOD_USER_ID = OlUser.Manager_LoginName;
                orddep01Model.CRT_USER_ID = OlUser.Manager_LoginName;
                orddep01Model.CRT_DATETIME = DateTime.Now;
                orddep01Model.LAST_UPDATE = DateTime.Now;
                ORDER_DEP01Bll.GetInstence().Save(this, orddep01Model);
            }
            catch (Exception err)
            {
                result = "报错出错:"+err.Message+ Environment.NewLine;
            }

            return result;
        }


        /// <summary>
        /// 移除全部可选分店清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MoveAllToRight(object sender, EventArgs e)
        {
            string ordder_id = hidORDDEP_ID.Text;
            //string result = "";
            for (int i = 0; i < Grid4.Rows.Count; i++)
            {
                try
                {
                    Object[] rowDataKeys = Grid4.DataKeys[i];
                    int Id = ConvertHelper.Cint(rowDataKeys[0].ToString());
                    ORDER_DEP01Bll.GetInstence().Delete(this, Id);
                }
                catch (Exception err)
                {
                    continue;
                }
            }
            LoadOrderDep01(ordder_id);
        }

        /// <summary>
        /// 移除可选分店清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MoveToRight(object sender, EventArgs e)
        {
            string ordder_id = hidORDDEP_ID.Text;
            int id = ConvertHelper.Cint(GridViewHelper.GetSelectedKey(Grid4, true));
            try
            {

                //删除记录
                ORDER_DEP01Bll.GetInstence().Delete(this, id);
            }
            catch (Exception err)
            {
                FineUI.Alert.ShowInParent("删除失败：" + err.Message, FineUI.MessageBoxIcon.Information);
            }
            LoadOrderDep01(ordder_id);
        }
        #endregion

        #region WINDOW2 相关时间
        public void LoadDepData()
        {
            FineUI.Grid Grid3 = Window2.FindControl("PanelA").FindControl("Grid3") as FineUI.Grid;
            PROD_DEPBll.GetInstence().BindGrid(Grid3, 0, 0, null, null);
        }

        protected void Grid2AddNewRow_Click(object sender, EventArgs e)
        {
            FineUI.Grid Grid3 = Window2.FindControl("PanelA").FindControl("Grid3") as FineUI.Grid;

            int[] selections = Grid3.SelectedRowIndexArray;
            string _ORDDEP_ID = hidORDDEP_ID.Text.ToString();
            string result = "";
            if (!String.IsNullOrEmpty(_ORDDEP_ID))
            {
                foreach (int i in selections)
                {
                    int _Id = ConvertHelper.Cint(Grid3.DataKeys[i][0].ToString());
                    var model = new PROD_DEP(x => x.Id == _Id);
                    string checkResult = CheckDataAddDep(model.DEP_ID);
                    if (!String.IsNullOrEmpty(checkResult))
                    {
                        result = result + checkResult + Environment.NewLine;
                        continue;
                    }
                    
                    JObject deObject = new JObject();
                    deObject.Add("Id1", "0");
                    deObject.Add("ORDDEP_ID1", _ORDDEP_ID);
                    deObject.Add("DEP_ID1", model.DEP_ID);
                    deObject.Add("DEP_NAME1", model.DEP_NAME);
                    deObject.Add("Meno", " ");
                    deObject.Add("USABLE1", true);
                    var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                    string lgname = OlUser.Manager_LoginName;
                    deObject.Add("CRT_USER_ID1", lgname);
                    deObject.Add("CRT_DATETIME1", DateTime.Now.ToString());
                    deObject.Add("MOD_USER_ID1", OlUser.Manager_LoginName);
                    deObject.Add("MOD_DATETIME1", DateTime.Now.ToString());
                    Grid2.AddNewRecord(deObject, true);
                }
            }
            if (!String.IsNullOrEmpty(result.Trim()))
            {
                FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
            }
        }


        public string CheckDataAddDep(string dep_id)
        {
            JArray upJson = Grid2.GetMergedData();
            string result = "";
            if (upJson.Count > 0)
            {
                for (int i = 0; i < upJson.Count; i++)
                {
                    if (dep_id == upJson[i]["values"]["DEP_ID1"].ToString())
                    {
                        return "中类编码" + dep_id + "已存在无法添加";
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 关闭子窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Window2_Close(object sender, WindowCloseEventArgs e)
        {
            Window2.Hidden = true;
        }

        #endregion
    }
}