using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solution.Web.Managers.WebManage.Systems.SupplyCenter
{
    public partial class TestAddRow : System.Web.UI.Page
    {


        private static List<Category> cateList;
        private ICategory iCate = IOC.R<ICategory>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGV(true);
            }
        }
        private void BindGV(bool refresh)
        {
            if (refresh || cateList == null)
            {
                cateList = iCate.List();
            }
            this.gv.DataSource = cateList;
            this.gv.DataBind();
        }
        protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv.EditIndex = e.NewEditIndex;
            BindGV(false);
            HiddenField hfIsEnable = (HiddenField)gv.Rows[e.NewEditIndex].FindControl("hfIsEnable");
            DropDownList ddlIsEnable = (DropDownList)gv.Rows[e.NewEditIndex].FindControl("ddlIsEnable");
            ddlIsEnable.SelectedValue = hfIsEnable.Value;
        }
        protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv.EditIndex = -1;
            BindGV(false);
        }
        //更新  
        protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            long id = Convert.ToInt32(gv.DataKeys[e.RowIndex].Values[0].ToString());
            string name = ((TextBox)gv.Rows[e.RowIndex].FindControl("txtName")).Text.Trim();
            bool isEnable = Convert.ToBoolean(((DropDownList)gv.Rows[e.RowIndex].FindControll("IsEnable")).SelectedValue);
            string txtOrder = ((TextBox)gv.Rows[e.RowIndex].FindControl("txtOrder")).Text;
            int order = string.IsNullOrEmpty(txtOrder) ? 0 : Convert.ToInt32(txtOrder);

            long newId = id;
            Category category = iCate.Get(id);
            if (category != null)//如果数据库已存在该条记录，则更新  
            {
                iCate.Update(id, c =>
                {
                    c.Name = name;
                    c.IsEnable = isEnable;
                    c.Order = order;
                });
            }
            else//新增   
            {
                Category cNew = new Category
                {
                    Name = name,
                    IsEnable = isEnable,
                    Order = order
                };
                iCate.Insert(cNew);
                newId = cNew.ID;
            }
            Category cate = cateList.Where(c => c.ID == id).ToList().SingleOrDefault();
            if (cate != null)
            {
                cate.ID = newId;
                cate.Name = name;
                cate.IsEnable = isEnable;
                cate.Order = order;
            }

            gv.EditIndex = -1;
            BindGV(false);
        }
        //删除  
        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            long id = Convert.ToInt64(gv.DataKeys[e.RowIndex].Values[0].ToString());
            Category cate = cateList.Where(c => c.ID == id).ToList().SingleOrDefault();
            if (cate != null)
            {
                cateList.Remove(cate);
            }
            iCate.Delete(id);
            this.BindGV(false);
        }
        //新增一行记录  
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            long maxId = cateList.Max(c => c.ID) + 1;
            Category cate = new Category()
            {
                ID = maxId,
                Name = "",
                Order = 0,
                IsEnable = true
            };
            cateList.Add(cate);
            this.gv.EditIndex = cateList.Count - 1;
            this.BindGV(false);
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btn = ((LinkButton)e.Row.Cells[3].Controls[2]);
                if (btn.Text == "删除")
                {
                    btn.Attributes.Add("onclick", "javascript:return confirm('您确信要删除吗!?')");
                }
            }
        }


    }

 
}