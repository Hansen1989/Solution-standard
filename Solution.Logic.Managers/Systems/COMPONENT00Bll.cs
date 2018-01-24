using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using System.Data;
using System.Xml.Linq;
using System.Linq.Expressions;

namespace Solution.Logic.Managers
{
    public partial class COMPONENT00Bll : LogicBase
    {
        #region 绑定菜单下拉列表
        /// <summary>
        /// 绑定菜单下拉列表——显示所有的数据
        /// </summary>
        public void BandDropDownListShowCOM(Page page, FineUI.DropDownList ddl,string PROD_ID)
        {

            //在内存中筛选记录
            var dt = DataTableHelper.GetFilterData(GetDataTable(), PRODUCT00Table.PROD_ID, PROD_ID, COMPONENT00Table.Id, " asc");

            try
            {
                //显示值
                ddl.DataTextField = COMPONENT00Table.COM_ID;
                //显示key
                ddl.DataValueField = COMPONENT00Table.COM_ID;
                //数据层次
                //绑定数据源
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.SelectedIndex = 0;
                ddl.Items.Insert(0, new FineUI.ListItem("", "0"));
                ddl.SelectedValue = "0";

            }
            catch (Exception e)
            {
                // 记录日志
                CommonBll.WriteLog("", e);
            }
        }
        #endregion

        /// <summary>
        /// 绑定树节点
        /// </summary>
        /// <param name="Tree1"></param>
        public void BandTreeListShowCOM(FineUI.Tree Tree1)
        {
            // 模拟从数据库返回数据表
            DataTable table;

            DataSet dsCom = null;
            dsCom = (DataSet)SPs.Get_COMPONENT00List().ExecuteDataSet();
            if (dsCom.Tables.Count > 0)
            {
                table = dsCom.Tables[0].Copy();
            }
            else
            {
                table = new DataTable();
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            ds.Relations.Add("TreeRelation", ds.Tables[0].Columns["TREE_ID"], ds.Tables[0].Columns["PARENT_Id"],false);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row.IsNull("PARENT_Id"))
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = row["TREE_NAME"].ToString();
                    node.Expanded = false;
                    Tree1.Nodes.Add(node);
                    ResolveSubTree(row, node);
                }
            }
        }

        /// <summary>
        /// 绑定树节点2
        /// </summary>
        /// <param name="Tree1"></param>
        public void BandTreeListShowCOM(FineUI.Tree Tree1,string COM_ID)
        {
            // 模拟从数据库返回数据表
            DataTable table;

            DataSet dsCom = null;
            dsCom = (DataSet)SPs.Get_COMPONENT00List().ExecuteDataSet();
            DataTable daCom01 = COMPONENT01Bll.GetInstence().GetCOMPONENT01Table(COM_ID);
            if (dsCom.Tables.Count > 0)
            {
                table = dsCom.Tables[0].Copy();
                table.Merge(daCom01);
            }
            else
            {
                table = new DataTable();
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            ds.Relations.Add("TreeRelation", ds.Tables[0].Columns["TREE_ID"], ds.Tables[0].Columns["PARENT_Id"], false);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row.IsNull("PARENT_Id"))
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = row["TREE_NAME"].ToString();
                    node.Expanded = false;
                    Tree1.Nodes.Add(node);
                    ResolveSubTree(row, node);
                }
            }
        }

        //添加子节点
        public void ResolveSubTree(DataRow dataRow, FineUI.TreeNode treeNode)
        {
            DataRow[] rows = dataRow.GetChildRows("TreeRelation");
            if (rows.Length > 0)
            {
                treeNode.Expanded = true;
                foreach (DataRow row in rows)
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = row["TREE_NAME"].ToString();
                    node.NodeID = row["TREE_ID"].ToString();
                    if (row["TREE_ID"].ToString().Contains("PRODUCT00_"))
                    {
                        //node.EnableCheckEvent = true;
                        node.EnableClickEvent = true;
                        //node.OnClientClick = "";
                    }
                    treeNode.Nodes.Add(node);

                    ResolveSubTree(row, node);
                }
            }
        }

        /// <summary>
        /// 读取某个固定字段的值
        /// </summary>
        /// <param name="conditionColName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetModelSingleValue(string colunm, Expression<Func<V_PRODUCT_COMPONENT00, bool>> expression)
        {
            string result = "";
            try
            {
                var model = new V_PRODUCT_COMPONENT00(expression);
                switch (colunm)
                {
                    case "COM00_NAME1": result = model.COM00_NAME1; break;
                    case "COM00_ID": result = model.COM00_ID.ToString(); break;
                    default: result = ""; break;
                }
            }
            catch
            {
                result = "";
            }
            return result;
        }

        public string DeleteCOMPONENT00(string COM_ID)
        {
            string result = "";
            try
            {
                DataTable dt = (DataTable)SPs.Delete_COMPONENT00_01(COM_ID).ExecuteDataTable();
            }
            catch (Exception err)
            {
                result = err.Message;
            }
            return result;
        }
    }
}
