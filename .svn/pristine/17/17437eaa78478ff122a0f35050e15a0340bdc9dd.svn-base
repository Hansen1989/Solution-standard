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
    public partial class Component00List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                //AddGrid2();
            }
        }

        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        public override void Init()
        {
            //逻辑对象赋值
            bll = COMPONENT00Bll.GetInstence();
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public override void LoadData()
        {
            COMPONENT00Bll.GetInstence().BandTreeListShowCOM(Tree1);
        }
        #endregion

        public override void SingleClick(GridRowClickEventArgs e)
        {
            hidCOM_ID.Text = "";
            int o = e.RowIndex;
            if (o >= 0)
            {
                int _Id = ConvertHelper.Cint(Grid1.DataKeys[o][0].ToString());
                var model = new COMPONENT00(x => x.Id == _Id);
                string result = SaveComponent01();
                if (!String.IsNullOrEmpty(result))
                {
                    FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
                }
                LoadData2(model.COM_ID);
                hidCOM_ID.Text = model.COM_ID;
            }
        }



        /// <summary>
        /// Grid1新增一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonNewRow_Clikc(object sender, EventArgs e)
        {
            string selectedId = Tree1.SelectedNodeID;
            TreeNode selectName = Tree1.SelectedNode;
            JObject defaultObj = new JObject();
            defaultObj.Add("rCOM00_ID", "0");
            defaultObj.Add("COM00_ID", "");
            defaultObj.Add("COM00_PROD_ID", selectedId.Substring(selectedId.IndexOf('_') + 1));
            defaultObj.Add("COM00_NAME1", selectName.Text);
            defaultObj.Add("COM00_Num", 1);
            defaultObj.Add("COM00_WEIGHT", "1.000000");
            defaultObj.Add("COM00_DefaultCOM", false);
            defaultObj.Add("COM00_QUAN1", 1);
            defaultObj.Add("COM00_QUAN2", 1);
            defaultObj.Add("COM00_DefQuan", 1);
            defaultObj.Add("IsFlag", 0);
            defaultObj.Add("COM00_BOM_Cost", "0.000000");
            string nowDate = DateTime.Now.AddYears(1).Date.ToString("yyyy-MM-dd");
            defaultObj.Add("COM00_ExpDateTime", nowDate);
            if (String.IsNullOrEmpty(selectedId))
            {
                FineUI.Alert.ShowInParent("请选择商品", FineUI.MessageBoxIcon.Information);
                return;
            }
            else
            {
                Grid1.AddNewRecord(defaultObj, true);
            }
        }

        /// <summary>
        /// Grid1删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1Delete_Click(object sender, EventArgs e)
        {
            string[] eCell = Grid1.SelectedCell;

            JArray upJson = Grid1.GetMergedData();
            DataTable da = new DataTable();
            for (int i = 0; i < upJson.Count; i++)
            {
                if (upJson[i]["status"].ToString() != "newadded" && upJson[i]["id"].ToString() == eCell[0].ToString())
                {
                    string _COM_ID = upJson[i]["values"]["COM00_ID"].ToString();
                    Grid1.DeleteSelectedRows();
                    COMPONENT00Bll.GetInstence().DeleteCOMPONENT00(_COM_ID);
                    hidCOM_ID.Text = "";
                    break;
                }
                else if (upJson[i]["status"].ToString() == "newadded" && upJson[i]["id"].ToString() == eCell[0].ToString())
                {
                    Grid1.DeleteSelectedRows();
                    hidCOM_ID.Text = "";
                    break;
                }
            }
            LoadData2("");
        }

        #region 配方界面数据加载
        /// <summary>
        /// 界面数据加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Tree1_NodeCommand(object sender, TreeCommandEventArgs e)
        {
            LoadCom(e.Node);
            string tTree_id = e.Node.NodeID.Substring(e.Node.NodeID.IndexOf('_') + 1);
            var model = new COMPONENT00(x => x.PROD_ID == tTree_id && x.DefaultCOM==1);
            if (String.IsNullOrEmpty(model.COM_ID))
            {
                LoadData2("");
                hidCOM_ID.Text ="";
                return;
            }
            LoadData2(model.COM_ID);
            DynamicAppendNode(e.Node);
            hidCOM_ID.Text = model.COM_ID.ToString();
        }

        //protected void Tree1_NodeLazyLoad(object sender, TreeNodeEventArgs e)
        //{
        //    LoadCom(e.Node);
        //    LoadData2("");
        //    DynamicAppendNode(e.Node);
        //    hidCOM_ID.Text = "";
        //}

        /// <summary>
        /// 动态加载子节点
        /// </summary>
        /// <param name="parentNode"></param>
        private void DynamicAppendNode(TreeNode parentNode)
        {
            parentNode.Expanded = true;
            //去除节点ID前面的内容
            string tTree_id = parentNode.NodeID.Substring(parentNode.NodeID.IndexOf('_') + 1);
            
            int i = tTree_id.IndexOf('_');
            DataTable daCom01 = COMPONENT01Bll.GetInstence().GetCOMPONENT01Table(tTree_id);
            TreeNode node = null;

            //Tree1.DataSource = null;
            //Tree1.DataBind();
            //COMPONENT00Bll.GetInstence().BandTreeListShowCOM(Tree1,tTree_id);
            //parentNode.Checked=true;
            parentNode.Nodes.Clear();
            foreach (DataRow dr in daCom01.Rows)
            {
                node = null;
                node = new TreeNode();
                node.Text = dr["TREE_NAME"].ToString();
                node.NodeID = dr["TREE_ID"].ToString();
                node.EnableClickEvent = true;
                //node.OnClientClick = "Tree1_NodeCommand";
                parentNode.Nodes.Add(node);
                //Tree1.NodeCommand += new EventHandler<TreeCommandEventArgs>(Tree1_NodeCommand);

            }
        }

        //加载配方
        public void LoadCom(TreeNode parentNode)
        {
            string tTree_id = parentNode.NodeID.Substring(parentNode.NodeID.IndexOf('_') + 1);
            var model = new COMPONENT00(x => x.PROD_ID == tTree_id);
            sortList = null;
            if (sortList == null)
            {
                sortList = new List<string>();
                sortList.Add(V_PRODUCT_COMPONENT00Table.COM00_DefQuan);
                sortList.Add(V_PRODUCT_COMPONENT00Table.COM00_ID);
                //Sort();
            }
            //Grid1.DataSource = null;
            //Grid1.DataBind();
            conditionList = null;
            //绑定Grid表格 这里要换成PROD_ID
            V_PRODUCT_COMPONENT00Bll.GetInstence().BindGrid(Grid1, 0, 0, InquiryCondition(tTree_id), sortList);
            //LoadData2(model.COM_ID);
        }

        /// <summary>
        /// 获取选中节点的所有父节点
        /// </summary>
        /// <param name="chilidNode"></param>
        /// <returns></returns>
        public List<string> GetParentNodeValue(TreeNode chilidNode)
        {
            List<string> parentList = new List<string>();
            parentList.Add(chilidNode.NodeID);
            //配方应该不会存在20个层次，所以当循环次数达到20时，就直接强制终止
            for (int i = 0; i <= 20; i++)
            {
                TreeNode parentNode = chilidNode.ParentNode;
                if (parentNode != null)
                {
                    parentList.Add(parentNode.NodeID);
                    chilidNode = chilidNode.ParentNode;
                }
                else
                {
                    break;
                }
            }
            return parentList;
        }

        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private List<ConditionFun.SqlqueryCondition> InquiryCondition(string id)
        {
            List<ConditionFun.SqlqueryCondition> conditionProdduct00List = new List<ConditionFun.SqlqueryCondition>();
            conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, V_PRODUCT_COMPONENT00Table.COM00_PROD_ID, Comparison.Equals, id, false, false));
            return conditionProdduct00List;
        }
        #endregion

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public override string Save()
        {

            //JArray upJson = Grid1.GetModifiedData();
            JArray upJson = Grid1.GetMergedData();
            string result = "";
            result = COMPONENT00Check(upJson);
            if (!String.IsNullOrEmpty(result))
            {
                return result;
            }
            //int i = aa.Count;
            for (int i = 0; i < upJson.Count; i++)
            {
                string upData = upJson[i]["values"].ToString();
                //newadded
                string upStatus = upJson[i]["status"].ToString();
                DataTable da = DotNet.Utilities.Json.JsonHelper.ToDataTable("[" + upData + "]");
                string sMessage = "";
                if (upStatus == "newadded")
                {
                    sMessage = Component00Save(da);
                }
                else if (upStatus == "modified")
                {
                    sMessage = Component00Update(da);
                }

                if (!String.IsNullOrEmpty(sMessage))
                {
                    result = result + "\r\n" + sMessage;
                    return result;
                }
            }
            //重新加载树节点
            TreeNode tn = Tree1.SelectedNode;
            LoadCom(tn);
            DynamicAppendNode(tn);
            //保存配方设定
            if (String.IsNullOrEmpty(hidCOM_ID.Text))
            {
                //return "";
            }
            else
            {
                result = SaveComponent01();
                string _PROD_ID = upJson[0]["values"]["COM00_PROD_ID"].ToString();
                var model = new COMPONENT00(x => x.PROD_ID == _PROD_ID && x.DefaultCOM == 1);
                hidCOM_ID.Text = model.COM_ID;
                if (String.IsNullOrEmpty(result))
                {
                    LoadData2(hidCOM_ID.Text);
                }
            }
            try
            {
                //COMPONENT00Bll.GetInstence().Save(this, model);
                //result = "保存成功";
            }
            catch (Exception err)
            {
                string errMesage = err.Message;
                result = "保存失败";
            }

            //保存GRID2
            //SaveComponent01();
            return result;
        }

        /// <summary>
        /// 配方数据效验
        /// </summary>
        /// <param name="upJson"></param>
        /// <returns></returns>
        public string COMPONENT00Check(JArray upJson)
        {
            
            int n=0;//默认配方的计数器
            for (int i = 0; i < upJson.Count; i++)
            {
                string upData = upJson[i]["values"].ToString();
                //newadded
                string upStatus = upJson[i]["status"].ToString();
                DataTable da = DotNet.Utilities.Json.JsonHelper.ToDataTable("[" + upData + "]");
                
                if (!String.IsNullOrEmpty(da.Rows[0]["COM00_Num"].ToString()))
                {
                    if (!ConvertHelper.IsNumeric(da.Rows[0]["COM00_Num"].ToString()))
                    {
                        return "配方商品数量必须为整数或者小数";
                    }
                }
                else
                {
                    return "配方商品数量不能为空";
                }

                if (!String.IsNullOrEmpty(da.Rows[0]["COM00_QUAN1"].ToString()))
                {
                    if (!ConvertHelper.IsNumeric(da.Rows[0]["COM00_QUAN1"].ToString()))
                    {
                        return "小缸数量必须为整数或者小数";
                    }
                }
                else
                {
                    return "小缸数量";
                }

                if (!String.IsNullOrEmpty(da.Rows[0]["COM00_QUAN2"].ToString()))
                {
                    if (!ConvertHelper.IsNumeric(da.Rows[0]["COM00_QUAN2"].ToString()))
                    {
                        return "大缸数量必须为整数或者小数";
                    }
                }
                else
                {
                    return "大缸数量";
                }

                if (da.Rows[0]["COM00_DefaultCOM"].ToString() == "True")
                {
                    n++;
                    if (n > 1)
                    {
                        return "默认配方只能有一个";
                    }
                }

                if (!String.IsNullOrEmpty(da.Rows[0]["COM00_ExpDateTime"].ToString()))
                {
                    string result="";
                    try
                    {
                        ConvertHelper.StringToDatetime(da.Rows[0]["COM00_ExpDateTime"].ToString() + " 00:00:00");
                    }
                    catch
                    {
                       result="有效日期必须为日期格式";
                    }
                    if (!String.IsNullOrEmpty(result))
                    {
                        return result;
                    }
                    
                }
                else
                {
                    return "有效日期不能为空";
                }

            }
            return "";
        }
        /// <summary>
        /// 配方保存
        /// </summary>
        /// <param name="da"></param>
        /// <returns></returns>
        public string Component00Save(DataTable da)
        {
            string result = "";
            try
            {
                var model = new COMPONENT00();
                model.COM_ID = TABLE_SEEDBll.GetInstence().GetTableSeed("COMPONENT00", DateTime.Now.Date.ToString("yyyyMMdd"), 4);
                if (da.Columns.Contains("COM00_PROD_ID"))
                {
                    if (!String.IsNullOrEmpty(da.Rows[0]["COM00_PROD_ID"].ToString()))
                    {
                        string daProd_id=da.Rows[0]["COM00_PROD_ID"].ToString();
                        string sPid = PRODUCT00Bll.GetInstence().GetModelSingleValue("PROD_ID", x => x.PROD_ID == daProd_id);
                        if (!String.IsNullOrEmpty(sPid))
                        {
                            model.PROD_ID = da.Rows[0]["COM00_PROD_ID"].ToString();
                        }
                        else
                        {
                            return "商品编码不存在，无法保存";
                        }
                    }
                    else
                    {
                        return "商品编码不能为空";
                    }
                }
                else
                {
                    return "商品编码不能为空";
                }

                if (da.Columns.Contains("COM00_Num"))
                {
                    model.Num = ConvertHelper.Cint(da.Rows[0]["COM00_Num"].ToString());
                }
                else
                {
                    model.Num = 1;
                }

                if (da.Columns.Contains("COM00_WEIGHT"))
                {
                    model.WEIGHT = ConvertHelper.StringToDecimal(da.Rows[0]["COM00_WEIGHT"].ToString());
                }
                else
                { 
                    model.WEIGHT=ConvertHelper.StringToDecimal("1.000000");
                }

                if (da.Columns.Contains("COM00_DefaultCOM"))
                {
                    if (da.Rows[0]["COM00_DefaultCOM"].ToString() == "True")
                    {
                        model.DefaultCOM = 1;
                    }
                    else
                    {
                        model.DefaultCOM = 0;
                    }
                }
                else
                {
                    model.DefaultCOM = 1;
                }

                if (da.Columns.Contains("COM00_QUAN1"))
                {
                    model.QUAN1 = ConvertHelper.Cint(da.Rows[0]["COM00_QUAN1"].ToString());
                }
                else
                {
                    model.QUAN1 = 1;
                }

                if (da.Columns.Contains("COM00_QUAN2"))
                {
                    model.QUAN2 = ConvertHelper.Cint(da.Rows[0]["COM00_QUAN2"].ToString());
                }
                else
                {
                    model.QUAN2 = 1;
                }

                if (da.Columns.Contains("COM00_DefQuan"))
                {
                    model.DefQuan = ConvertHelper.Cint(da.Rows[0]["COM00_DefQuan"].ToString());
                }
                else
                {
                    model.DefQuan = 1;
                }

                if (da.Columns.Contains("COM00_BOM_Cost"))
                {
                    model.BOM_Cost = ConvertHelper.Cint(da.Rows[0]["COM00_BOM_Cost"].ToString());
                }
                else
                {
                    model.BOM_Cost = ConvertHelper.StringToDecimal("0.000000");
                }

                if (da.Columns.Contains("COM00_ExpDateTime"))
                {
                    model.ExpDateTime = ConvertHelper.StringToDatetime(da.Rows[0]["COM00_ExpDateTime"].ToString()+" 00:00:00");
                }
                else
                {
                    model.ExpDateTime = DateTime.Now.AddYears(1);
                }

                var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());

                model.CRT_DATETIME = DateTime.Now;
                model.CRT_USER_ID = OlUser.Manager_LoginName;
                model.MOD_DATETIME = DateTime.Now;
                model.MOD_USER_ID = OlUser.Manager_LoginName;
                model.LAST_UPDATE = DateTime.Now;
                model.SetIsNew(true);
                COMPONENT00Bll.GetInstence().Save(this, model);
                result = "";
            }
            catch (Exception err)
            {
                result = "保存失败";

                //出现异常，保存出错日志信息
                CommonBll.WriteLog(result, err);
            }
            return result;
        }
        /// <summary>
        /// 配方更新
        /// </summary>
        /// <param name="da"></param>
        /// <returns></returns>
        public string Component00Update(DataTable da)
        {
            string result = "";
            try
            {
                string _COM_ID="";
                if (da.Columns.Contains("COM00_ID"))
                {
                    _COM_ID = da.Rows[0]["COM00_ID"].ToString();
                }
                else
                {
                    return "更新失败";
                }
                var model = new COMPONENT00(x=>x.COM_ID==_COM_ID);
                if (da.Columns.Contains("COM00_PROD_ID"))
                {
                    model.PROD_ID = da.Rows[0]["COM00_PROD_ID"].ToString();
                }

                if (da.Columns.Contains("COM00_Num"))
                {
                    model.Num = ConvertHelper.Cint(da.Rows[0]["COM00_Num"].ToString());
                }

                if (da.Columns.Contains("COM00_WEIGHT"))
                {
                    model.WEIGHT = ConvertHelper.StringToDecimal(da.Rows[0]["COM00_WEIGHT"].ToString());
                }

                if (da.Columns.Contains("COM00_DefaultCOM"))
                {
                    if (da.Rows[0]["COM00_DefaultCOM"].ToString() == "True")
                    {
                        model.DefaultCOM = 1;
                    }
                    else
                    {
                        model.DefaultCOM = 0;
                    }
                }

                if (da.Columns.Contains("COM00_QUAN1"))
                {
                    model.QUAN1 = ConvertHelper.Cint(da.Rows[0]["COM00_QUAN1"].ToString());
                }

                if (da.Columns.Contains("COM00_QUAN2"))
                {
                    model.QUAN2 = ConvertHelper.Cint(da.Rows[0]["COM00_QUAN2"].ToString());
                }

                if (da.Columns.Contains("COM00_DefQuan"))
                {
                    model.DefQuan = ConvertHelper.Cint(da.Rows[0]["COM00_DefQuan"].ToString());
                }

                if (da.Columns.Contains("COM00_BOM_Cost"))
                {
                    model.BOM_Cost = ConvertHelper.Cint(da.Rows[0]["COM00_BOM_Cost"].ToString());
                }

                if (da.Columns.Contains("COM00_ExpDateTime"))
                {
                    model.ExpDateTime = ConvertHelper.StringToDatetime(da.Rows[0]["COM00_ExpDateTime"].ToString());
                }

                var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());

                model.MOD_DATETIME = DateTime.Now;
                model.MOD_USER_ID = OlUser.Manager_LoginName;
                model.LAST_UPDATE = DateTime.Now;
                model.SetIsNew(false);
                COMPONENT00Bll.GetInstence().Save(this, model);
                result = "";
            }
            catch (Exception err)
            {
                result = "更新失败";

                //出现异常，保存出错日志信息
                CommonBll.WriteLog(result, err);
            }
            return result;
        }


        #region 配方设定
        /// <summary>
        /// 加载配方设定信息
        /// </summary>
        public void LoadData2(string _COM_ID)
        {
            sortList = null;
            if (sortList == null)
            {
                sortList = new List<string>();
                sortList.Add(COMPONENT01Table.DETAIL_ID);
                //Sort();
            }
            if (String.IsNullOrEmpty(_COM_ID))
            {
                Grid2.DataSource = null;
                Grid2.DataBind();
            }
            conditionList = null;
            //绑定Grid表格 这里要换成PROD_ID
            V_COMPONENT01_PRODUCT00Bll.GetInstence().BindGrid(Grid2, 0, 0, InquiryCondition2(_COM_ID), sortList);
        }
        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private List<ConditionFun.SqlqueryCondition> InquiryCondition2(string id)
        {
            List<ConditionFun.SqlqueryCondition> conditionProdduct00List = new List<ConditionFun.SqlqueryCondition>();
            conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, COMPONENT01Table.COM_ID, Comparison.Equals, id, false, false));
            return conditionProdduct00List;
        }
        #endregion

        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Grid2Delete_Click(object sender, EventArgs e)
        {
            string[] eCell = Grid2.SelectedCell;

            JArray upJson = Grid2.GetMergedData();
            DataTable da = new DataTable();
            for (int i = 0; i < upJson.Count; i++)
            {
                if (upJson[i]["status"].ToString() != "newadded" && upJson[i]["id"].ToString() == eCell[0].ToString())
                {
                    int _id = ConvertHelper.Cint(upJson[i]["values"]["Id00"].ToString());
                    FineUI.Alert.ShowInParent(_id.ToString(), FineUI.MessageBoxIcon.Information);
                    Grid2.DeleteSelectedRows();
                    COMPONENT01Bll.GetInstence().Delete(this, _id);
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

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        public string SaveComponent01()
        {
            //JArray upJson = Grid2.GetModifiedData();
            JArray upJson = Grid2.GetMergedData();
            string result = "";
            //int i = aa.Count;
            for (int i = 0; i < upJson.Count; i++)
            {
                string upData = upJson[i]["values"].ToString();
                //newadded
                string upStatus = upJson[i]["status"].ToString();
                DataTable da = DotNet.Utilities.Json.JsonHelper.ToDataTable("[" + upData + "]");
                string sMessage = "";
                sMessage=Component01Update(da);
                if (!String.IsNullOrEmpty(sMessage))
                {
                    result = result + "\r\n" + sMessage;
                }
            }
            return result;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="da"></param>
        /// <returns></returns>
        public string Component01Save(DataTable da)
        {
            string result="";
            try
            {
                COMPONENT01 model = new COMPONENT01();
                string _sCOM_ID = hidCOM_ID.Text;
                string _sDETAIL_ID = TABLE_SEEDBll.GetInstence().GetTableSeed("COMPONENT01", _sCOM_ID, 0);
                model.COM_ID = _sCOM_ID;
                if (_sDETAIL_ID == "0")
                {
                    return "配方资料设定序号出错";
                }
                else
                {
                    model.DETAIL_ID = ConvertHelper.Cint(_sDETAIL_ID.Replace(_sCOM_ID,""));
                }
                if (da.Columns.Contains("PROD_ID"))
                {
                    string _sPid = da.Rows[0]["PROD_ID"].ToString();
                    string pPid = PRODUCT00Bll.GetInstence().GetModelSingleValue("PROD_ID", x => x.PROD_ID == _sPid);
                    if (!String.IsNullOrEmpty(pPid))
                    {
                        model.PROD_ID = pPid;
                    }
                    else
                    {
                        return "配方设定无法查到商品资料";
                    }
                }
                else
                {
                    return "配方设定商品编码不能为空";
                }

                if (da.Columns.Contains("QUANTITY"))
                {
                    model.QUANTITY = ConvertHelper.StringToDecimal(da.Rows[0]["QUANTITY"].ToString());
                }

                if (da.Columns.Contains("LQUANTITY"))
                {
                    model.LQUANTITY = ConvertHelper.StringToDecimal(da.Rows[0]["LQUANTITY"].ToString());
                }
                else
                {
                    model.LQUANTITY = ConvertHelper.StringToDecimal("1.000000");
                }

                if (da.Columns.Contains("New_PROD_ID"))
                {
                    model.New_PROD_ID = da.Rows[0]["New_PROD_ID"].ToString().ToString();
                }

                if (da.Columns.Contains("IsScales"))
                {
                    if (da.Rows[0]["IsScales"].ToString() == "True")
                    {
                        model.IsScales = 1;
                    }
                    else
                    {
                        model.IsScales = 0;
                    }
                }
                else
                {
                    model.IsScales = 1;
                }
                if (da.Columns.Contains("PrtTag"))
                {
                    if (da.Rows[0]["PrtTag"].ToString() == "True")
                    {
                        model.PrtTag = 1;
                    }
                    else
                    {
                        model.PrtTag = 0;
                    }
                }
                else
                {
                    model.PrtTag = 1;
                }

                if (da.Columns.Contains("IsFlag"))
                {
                    if (da.Rows[0]["IsFlag"].ToString() == "True")
                    {
                        model.IsFlag = 1;
                    }
                    else
                    {
                        model.IsFlag = 0;
                    }
                }
                else
                {
                    model.IsFlag = 1;
                }

                if (da.Columns.Contains("Memo"))
                {
                    model.Memo = da.Rows[0]["Memo"].ToString();
                }
                var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());

                model.CRT_USER_ID = OlUser.Manager_LoginName;
                model.CRT_DATETIME = DateTime.Now;
                model.MOD_DATETIME = DateTime.Now;
                model.MOD_USER_ID = OlUser.Manager_LoginName;
                model.LAST_UPDATE = DateTime.Now;
                model.SetIsNew(true);
                COMPONENT01Bll.GetInstence().Save(this, model);
                result = "";
            }
            catch(Exception err)
            {
                result = "保存失败";
            }

            return result;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="da"></param>
        /// <returns></returns>
        public string Component01Update(DataTable da)
        {
            string result = "";
            try
            {
                string _sCOM_ID = da.Rows[0]["COM_ID"].ToString();
                int _detail_id = 0;
                bool isnew = false;
                
                if (da.Columns.Contains("DETAIL_ID"))
                {
                    _detail_id = ConvertHelper.Cint(da.Rows[0]["DETAIL_ID"].ToString());
                    if (_detail_id == 0)
                    {
                        _detail_id = ConvertHelper.Cint(TABLE_SEEDBll.GetInstence().GetTableSeed("COMPONENT01", _sCOM_ID, 0));
                        _detail_id=ConvertHelper.Cint(_detail_id.ToString().Replace(_sCOM_ID, ""));
                        isnew = true;
                    }
                }
                else
                {
                    return "更新失败";
                }
                COMPONENT01 model = new COMPONENT01(x=>x.COM_ID==_sCOM_ID && x.DETAIL_ID==_detail_id);
                //string _sDETAIL_ID = TABLE_SEEDBll.GetInstence().GetTableSeed("COMPONENT01", _sCOM_ID, 0);
                //model.COM_ID = _sCOM_ID;
                //model.DETAIL_ID = ConvertHelper.Cint(_sDETAIL_ID);
                if (isnew == true)
                {
                    model.DETAIL_ID = _detail_id;
                    model.SetIsNew(true);
                }
                else
                {
                    model.SetIsNew(false);
                }

                if (da.Columns.Contains("PROD_ID"))
                {
                    string _sPid = da.Rows[0]["PROD_ID"].ToString();
                    string pPid = PRODUCT00Bll.GetInstence().GetModelSingleValue("PROD_ID", x => x.PROD_ID == _sPid);
                    if (!String.IsNullOrEmpty(pPid))
                    {
                        model.PROD_ID = pPid;
                    }
                    else
                    {
                        return "配方设定无法查到商品资料";
                    }
                }
                else
                {
                    return "配方设定商品编码不能为空";
                }

                if (da.Columns.Contains("QUANTITY"))
                {
                    model.QUANTITY = ConvertHelper.StringToDecimal(da.Rows[0]["QUANTITY"].ToString());
                }

                if (da.Columns.Contains("LQUANTITY"))
                {
                    model.LQUANTITY = ConvertHelper.StringToDecimal(da.Rows[0]["LQUANTITY"].ToString());
                }

                if (da.Columns.Contains("New_PROD_ID"))
                {
                    model.New_PROD_ID = da.Rows[0]["New_PROD_ID"].ToString().ToString();
                }

                if (da.Columns.Contains("IsScales"))
                {
                    if (da.Rows[0]["IsScales"].ToString() == "True")
                    {
                        model.IsScales = 1;
                    }
                    else
                    {
                        model.IsScales = 0;
                    }
                }

                if (da.Columns.Contains("PrtTag"))
                {
                    if (da.Rows[0]["PrtTag"].ToString() == "True")
                    {
                        model.PrtTag = 1;
                    }
                    else
                    {
                        model.PrtTag = 0;
                    }
                }


                if (da.Columns.Contains("IsFlag"))
                {
                    if (da.Rows[0]["IsFlag"].ToString() == "True")
                    {
                        model.IsFlag = 1;
                    }
                    else
                    {
                        model.IsFlag = 0;
                    }
                }


                if (da.Columns.Contains("Memo"))
                {
                    model.Memo = da.Rows[0]["Memo"].ToString();
                }
                var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());

                model.MOD_DATETIME = DateTime.Now;
                model.MOD_USER_ID = OlUser.Manager_LoginName;
                model.LAST_UPDATE = DateTime.Now;
                model.SetIsNew(false);
                COMPONENT01Bll.GetInstence().Save(this, model);
                result = "";
            }
            catch (Exception err)
            {
                result = "更新失败";
            }

            return result;
        }

        /// <summary>
        /// 配方设定节点校验
        /// </summary>
        /// <returns></returns>
        public string CheckNodes(List<string> prodList,string strProd_id)
        {
            foreach (string prod in prodList)
            {
                //包含以下字符都是顶级节点，非商品，配方节点，直接过滤，避免匹配出错
                if (prod.Contains("PROD_DEP_") || prod.Contains("PROD_DEP_") || prod.Contains("PROD_DEP_"))
                {
                    continue;
                }
                if (strProd_id.Equals(prod.Substring(prod.IndexOf('_')+1)))
                {

                    return "商品编码无法嵌套插入";
                }
            }
            JArray upJson = Grid2.GetMergedData();
            for (int i = 0; i < upJson.Count; i++)
            {
                if (strProd_id.Equals(upJson[i]["values"]["PROD_ID"].ToString()))
                {
                    return "商品编码已存在无法插入";
                    break;
                }
            }
            return "";
        }



        #region window2 相关事件

        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid2_RowDoubleClick(object sender, GridRowClickEventArgs e)
        {
            int selections = e.RowIndex;
            string[] pCell = Grid2.SelectedCell;
            if (pCell[1].ToString() == "New_PROD_ID")
            {
                Grid3Rowindex.Text = selections.ToString();
                string ceshi = Grid3Rowindex.Text;
                Window3.Hidden = false;
                LoadList2();
            }
        }


        /// <summary>
        /// Grid2新增一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNewRow(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(hidCOM_ID.Text))
            {
                FineUI.Alert.ShowInParent("请选择配方", FineUI.MessageBoxIcon.Information);
                return;
            }
            else
            {
                FineUI.Grid Grid3 = Window2.FindControl("PanelA").FindControl("Grid3") as FineUI.Grid;
                Grid3.DataSource = null;
                Grid3.DataBind();
                Window2.Hidden = false;
                LoadList();
                //Grid2.AddNewRecord(defaultObj, true);
            }
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
        /// <summary>
        /// Grid2新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNewRow2(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(hidCOM_ID.Text))
            {
                FineUI.Alert.ShowInParent("请选择配方", FineUI.MessageBoxIcon.Information);
                return;
            }
            else
            {
                //Window2.Hidden = false;
                //LoadList();
                //Grid2.AddNewRecord(defaultObj, true);
            }
            FineUI.Grid Grid3 = Window2.FindControl("PanelA").FindControl("Grid3") as FineUI.Grid;
            TreeNode tn = Tree1.SelectedNode;
            List<string> prodList = GetParentNodeValue(tn);
            int[] selections = Grid3.SelectedRowIndexArray;
            string checkResult = "";
            foreach (int i in selections)
            {
                int _Id = ConvertHelper.Cint(Grid3.DataKeys[i][0].ToString());
                if (_Id > 0)
                {
                    JObject defaultObj = new JObject();
                    var model = new PRODUCT00(x => x.Id == _Id);
                    string _checkResult = CheckNodes(prodList, model.PROD_ID);
                    if (!String.IsNullOrEmpty(_checkResult))
                    {
                        checkResult = checkResult+_checkResult + Environment.NewLine;
                        continue;
                    }
                    var model2 = new COMPONENT01();
                    int _detail_id = ConvertHelper.Cint(TABLE_SEEDBll.GetInstence().GetTableSeed("COMPONENT01", hidCOM_ID.Text, 0).Replace(hidCOM_ID.Text, ""));
                    model2.COM_ID = hidCOM_ID.Text;
                    model2.DETAIL_ID = _detail_id;
                    model2.PROD_ID = model.PROD_ID;
                    model2.QUANTITY = ConvertHelper.StringToDecimal("1.000000");
                    model2.LQUANTITY = ConvertHelper.StringToDecimal("1.000000");
                    model2.New_PROD_ID = "";
                    model2.IsScales = 1;
                    model2.PrtTag = 1;
                    model2.IsFlag = 1;
                    model2.Memo="";
                    var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());

                    model2.CRT_USER_ID = OlUser.Manager_LoginName;
                    model2.CRT_DATETIME = DateTime.Now;
                    model2.MOD_DATETIME = DateTime.Now;
                    model2.MOD_USER_ID = OlUser.Manager_LoginName;
                    model2.LAST_UPDATE = DateTime.Now;
                    model2.SetIsNew(true);
                    COMPONENT01Bll.GetInstence().Save(this,model2);
                }
            }
            if (!String.IsNullOrEmpty(checkResult))
            {
                FineUI.Alert.ShowInParent(checkResult, FineUI.MessageBoxIcon.Information);
            }
            string result=SaveComponent01();
            LoadData2(hidCOM_ID.Text);
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
            FineUI.Grid Grid3 = Window2.FindControl("PanelA").FindControl("Grid3") as FineUI.Grid;
            PRODUCT00Bll.GetInstence().BindGrid(Grid3, 0, 0, InquiryCondition(), sortList);
        }
        /// <summary>
        /// 加载下拉列表
        /// </summary>
        public void LoadList()
        {
            FineUI.DropDownList cPROD_KIND = Window2.FindControl("PanelA").FindControl("cPROD_KIND") as FineUI.DropDownList;
            PROD_KINDBll.GetInstence().BandDropDownListShowKind(this, cPROD_KIND);
            FineUI.DropDownList cPROD_DEP = Window2.FindControl("PanelA").FindControl("cPROD_DEP") as FineUI.DropDownList;
            PROD_DEPBll.GetInstence().BandDropDownListShowDep(this, cPROD_DEP);
            FineUI.DropDownList cPROD_CATE = Window2.FindControl("PanelA").FindControl("cPROD_CATE") as FineUI.DropDownList;
            PROD_CateBll.GetInstence().BandDropDownListShowCate(this, cPROD_CATE);
        }
        /// <summary>
        /// GRID3检索的判断条件
        /// </summary>
        /// <returns></returns>
        private List<ConditionFun.SqlqueryCondition> InquiryCondition()
        {
            List<ConditionFun.SqlqueryCondition> conditionProdduct00List = new List<ConditionFun.SqlqueryCondition>();
            //conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "1", Comparison.Equals, "1", false, false));
            bool sFlag = true;
            FineUI.TextBox cPROD_ID = Window2.FindControl("PanelA").FindControl("cPROD_ID") as FineUI.TextBox;
            var _PROD_ID = cPROD_ID.Text;
            if (!String.IsNullOrEmpty(cPROD_ID.Text))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_ID, Comparison.Like, "%" + _PROD_ID + "%", false, false));
                sFlag = false;
            }

            FineUI.TextBox cPROD_NAME = Window2.FindControl("PanelA").FindControl("cPROD_NAME") as FineUI.TextBox;
            var _PROD_NAME = cPROD_NAME.Text;
            if (!String.IsNullOrEmpty(_PROD_NAME))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_NAME1, Comparison.Like, "%" + _PROD_NAME + "%", false, false));
                sFlag = false;
            }
            FineUI.TextBox cPROD_NAME_SPELLING = Window2.FindControl("PanelA").FindControl("cPROD_NAME_SPELLING") as FineUI.TextBox;
            var _PROD_NAME_SPELLING = cPROD_NAME_SPELLING.Text;
            if (!String.IsNullOrEmpty(_PROD_NAME_SPELLING))
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_NAME1_SPELLING, Comparison.Like, "%" + _PROD_NAME_SPELLING + "%", false, false));
                sFlag = false;
            }
            FineUI.DropDownList cPROD_DEP = Window2.FindControl("PanelA").FindControl("cPROD_DEP") as FineUI.DropDownList;
            var _PROD_DEP = cPROD_DEP.SelectedValue;
            if (!String.IsNullOrEmpty(_PROD_NAME) && _PROD_DEP != "0")
            {
                conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_DEP, Comparison.Equals, _PROD_DEP, false, false));
                sFlag = false;
            }
            FineUI.DropDownList cPROD_CATE = Window2.FindControl("PanelA").FindControl("cPROD_CATE") as FineUI.DropDownList;
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
        #endregion

        #region WINDOW3相关事件

        //override
        protected  void Window3_Close(object sender, WindowCloseEventArgs e)
        {
            FineUI.Grid Grid4 = Window3.FindControl("PanelGrid4").FindControl("Grid4") as FineUI.Grid;
            Grid4.DataSource = null;
            Grid4.DataBind();
            Window3.Hidden = true;
        }

        /// <summary>
        /// 加载下拉列表
        /// </summary>
        public void LoadList2()
        {
            FineUI.DropDownList ccPROD_KIND = Window3.FindControl("PanelGrid4").FindControl("ccPROD_KIND") as FineUI.DropDownList;
            PROD_KINDBll.GetInstence().BandDropDownListShowKind(this, ccPROD_KIND);
            FineUI.DropDownList ccPROD_DEP = Window3.FindControl("PanelGrid4").FindControl("ccPROD_DEP") as FineUI.DropDownList;
            PROD_DEPBll.GetInstence().BandDropDownListShowDep(this, ccPROD_DEP);
            FineUI.DropDownList ccPROD_CATE = Window3.FindControl("PanelGrid4").FindControl("ccPROD_CATE") as FineUI.DropDownList;
            PROD_CateBll.GetInstence().BandDropDownListShowCate(this, ccPROD_CATE);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ButtonPRODSearch2_Click(object sender, EventArgs e)
        {

            conditionList = null;
            conditionList = new List<ConditionFun.SqlqueryCondition>();
            //绑定Grid表格
            
            FineUI.Grid Grid4 = Window3.FindControl("PanelGrid4").FindControl("Grid4") as FineUI.Grid;
            PRODUCT00Bll.GetInstence().BindGrid(Grid4, 0, 0, InquiryCondition2(), sortList);
        }

        /// <summary>
        /// GRID4检索的判断条件
        /// </summary>
        /// <returns></returns>
        private List<ConditionFun.SqlqueryCondition> InquiryCondition2()
        {
            List<ConditionFun.SqlqueryCondition> conditionProdduct00List = new List<ConditionFun.SqlqueryCondition>();

            try
            {
                
                //conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "1", Comparison.Equals, "1", false, false));
                bool sFlag = true;
                FineUI.TextBox cPROD_ID = Window3.FindControl("PanelGrid4").FindControl("ccPROD_ID") as FineUI.TextBox;
                var _PROD_ID = cPROD_ID.Text;
                if (!String.IsNullOrEmpty(cPROD_ID.Text))
                {
                    conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_ID, Comparison.Like, "%" + _PROD_ID + "%", false, false));
                    sFlag = false;
                }

                FineUI.TextBox cPROD_NAME = Window3.FindControl("PanelGrid4").FindControl("ccPROD_NAME") as FineUI.TextBox;
                var _PROD_NAME = cPROD_NAME.Text;
                if (!String.IsNullOrEmpty(_PROD_NAME))
                {
                    conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_NAME1, Comparison.Like, "%" + _PROD_NAME + "%", false, false));
                    sFlag = false;
                }
                FineUI.TextBox cPROD_NAME_SPELLING = Window3.FindControl("PanelGrid4").FindControl("ccPROD_NAME_SPELLING") as FineUI.TextBox;
                var _PROD_NAME_SPELLING = cPROD_NAME_SPELLING.Text;
                if (!String.IsNullOrEmpty(_PROD_NAME_SPELLING))
                {
                    conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_NAME1_SPELLING, Comparison.Like, "%" + _PROD_NAME_SPELLING + "%", false, false));
                    sFlag = false;
                }
                FineUI.DropDownList cPROD_DEP = Window3.FindControl("PanelGrid4").FindControl("ccPROD_DEP") as FineUI.DropDownList;
                var _PROD_DEP = cPROD_DEP.SelectedValue;
                if (!String.IsNullOrEmpty(_PROD_NAME) && _PROD_DEP != "0")
                {
                    conditionProdduct00List.Add(new ConditionFun.SqlqueryCondition(WhereOrAnd(sFlag), PRODUCT00Table.PROD_DEP, Comparison.Equals, _PROD_DEP, false, false));
                    sFlag = false;
                }
                FineUI.DropDownList cPROD_CATE = Window3.FindControl("PanelGrid4").FindControl("ccPROD_CATE") as FineUI.DropDownList;
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
            }catch(Exception){}

            return conditionProdduct00List;
        }

        /// <summary>
        /// 添加替换品代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditBom(object sender, EventArgs e)
        {
            int Grid3RowIndex = ConvertHelper.Cint(Grid3Rowindex.Text);
            FineUI.Grid Grid4 = Window3.FindControl("PanelGrid4").FindControl("Grid4") as FineUI.Grid;
            int[] selections = Grid4.SelectedRowIndexArray;
            if (selections.Length == 0)
            {
                FineUI.Alert.ShowInParent("请选择一行", FineUI.MessageBoxIcon.Information);
                return ;
            }
            JArray arr = Grid2.GetMergedData();
            //var model = new PRODUCT00(x => x.Id == _Id);
           
            DataTable da2 = new DataTable();
            da2 = null;
            for (int i = 0; i < arr.Count; i++)
            {
                string upData = arr[i]["values"].ToString();
                DataTable da = DotNet.Utilities.Json.JsonHelper.ToDataTable("[" + upData + "]");
                string aa = arr[i]["index"].ToString();
                string bb = Grid3Rowindex.Text.ToString();
                if (arr[i]["index"].ToString() == Grid3Rowindex.Text.ToString())
                {
                    int _Id = ConvertHelper.Cint(Grid4.DataKeys[selections[0]][0].ToString());
                    if (_Id == 0)
                    {
                        FineUI.Alert.ShowInParent("未匹配到商品数据", FineUI.MessageBoxIcon.Information);
                        return;
                    }
                    var model = new PRODUCT00(x => x.Id == _Id);
                    da.Rows[0]["New_PROD_ID"] = model.PROD_ID;
                    da.Rows[0]["New_PROD_NAME1"] = model.PROD_NAME1;
                }
                //da2.Merge(da);
                if (da2 == null)
                {
                    da2 = da.Copy();
                }
                else
                {
                    da2.ImportRow(da.Rows[0]);
                }
            }
            Grid2.DataSource = da2;
            Grid2.DataBind();
            //SetNewBomName();
            Grid4.DataSource = null;
            Grid4.DataBind();
            Window3.Hidden = true;

            //int o = selections[0];
            ////int _Id = ConvertHelper.Cint(Grid2.DataKeys[o][0].ToString());
            //SetBomName(arr);
            //GridRow row = Grid2.Rows[o];
            //System.Web.UI.WebControls.TextBox asdf = (System.Web.UI.WebControls.TextBox)row.FindControl("tBOM_NAME123");
            //asdf.Text = "更改了";
            //asdf.Focus();
        }

        /// <summary>
        /// 循环更改asp控件
        /// </summary>
        /// <param name="arr"></param>
        public void SetNewBomName()
        {
            JArray arr = Grid2.GetMergedData();
            for (int i = 0; i < arr.Count; i++)
            {
                string upData = arr[i]["values"].ToString();
                //newadded
                string upStatus = arr[i]["status"].ToString();
                DataTable da = DotNet.Utilities.Json.JsonHelper.ToDataTable("[" + upData + "]");
                GridRow row = Grid2.Rows[ConvertHelper.Cint(arr[i]["index"].ToString())];
                //System.Web.UI.WebControls.TextBox asdf = (System.Web.UI.WebControls.TextBox)row.FindControl("tBOM_NAME123");
                //string ccc = asdf.Text;
                if (!String.IsNullOrEmpty(da.Rows[0]["New_PROD_ID"].ToString()))
                {
                    string _New_PROD_ID = da.Rows[0]["New_PROD_ID"].ToString();
                    var model = new PRODUCT00(x => x.PROD_ID == _New_PROD_ID);
                    if (model.Id > 0)
                    {
                        System.Web.UI.WebControls.Label tNew_New_PROD_NAME = (System.Web.UI.WebControls.Label)row.FindControl("tNew_New_PROD_NAME");
                        tNew_New_PROD_NAME.Text = model.PROD_NAME1;
                    }
                    //System.Web.UI.WebControls.TextBox asdf = (System.Web.UI.WebControls.TextBox)row.FindControl("tBOM_NAME123");
                    //asdf.Text = "更改了";
                }
            }
        }

        #endregion
    }
}