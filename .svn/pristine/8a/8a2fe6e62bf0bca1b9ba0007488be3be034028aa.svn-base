using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution.Web.Managers.WebManage.Application;
using DotNet.Utilities;
using Solution.Logic.Managers;
using Solution.DataAccess.DataModel;
using FineUI;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;
using System.Data;

namespace Solution.Web.Managers.WebManage.Systems.SysAuthority
{
    public partial class PositionEdit : PageBase
    {
        public int menuInfoId = 0;
        public int menuInfoId_ {
            set { menuInfoId = value; }
            get { return menuInfoId; }
        }
        
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";

                //绑定下拉列表
                // PositionBll.GetInstence().BandDropDownList(this, ddlParentId);
                //   BranchBll.GetInstence().BandDropDownListShowMenu(this, ddlParentId);
              //  SHOP00Bll.GetInstence().BandDropDownListShowShop(this, ddlShop);
               // PositionBll.GetInstence().BandPagePowerSignPublicList(this, Grid4);

                //加载数据
                LoadData();
            }
        }
        #endregion

        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        public override void Init()
        {
            //逻辑对象赋值
            bll = PagePowerSignPublicBll.GetInstence();
         

            ////表格对象赋值
            grid = Grid4;
       
            //grid3 = Grid3;

        }
        #endregion

        #region 加载数据
        /// <summary>读取数据</summary>
        public override void LoadData()
        {
            //关闭窗口
            ButtonCancel.OnClientClick = ActiveWindow.GetHideReference();

            int id = ConvertHelper.Cint0(hidId.Text);

            if (id != 0)
            {
                Solution.DataAccess.Model.Position model = new DataAccess.Model.Position();
                //获取指定ID的菜单内容，如果不存在，则创建一个菜单实体
                model = PositionBll.GetInstence().GetModelForCache(x => x.Id == id);

                if (model == null)
                    return;

                txtPosition.Text = model.Name;

               // ddlParentId.SelectedValue = model.Branch_Id.ToString() + "";

                string pagepower = "";
                if(model.PagePower != null){
                      pagepower = model.PagePower.ToString().Substring(1);//
 
                      pagepower = pagepower.Substring(0, pagepower.Length - 1);
                }

                string str_pagepower = pagepower.Replace("|", "','");

                str_pagepower = "('" + str_pagepower + "')";

  
              //  bll1.BindGrid(Grid1, 0, 0, sqlwhereList, sortList1);

               // MenuInfoBll bk = new MenuInfoBll();
               
                    MenuInfoBll.GetInstence().BandDropDownListShowMenu1(this, Grid1, model.PagePower, model.ControlPower); //绑定菜单和页面权限
              
                MenuInfoBll.GetInstence().BandDropDownListShowMenu2(this, Grid2, model.PagePower, model.ControlPower); //绑定菜单和页面权限

                MenuInfoBll.GetInstence().BandDropDownListShowMenu3(this, Grid3, model.PagePower, model.ControlPower); //绑定菜单和页面权限

            }
            else {

                
             //   MenuInfoBll.GetInstence().BandDropDownListShowMenu(this, Grid1, Grid2,Grid3,"",""); //绑定菜单和页面权限
            
            }

           // bll.BindGrid(Grid4, InquiryCondition(), sortList);

          //  PositionBll.GetInstence().BandPagePowerSignPublicList(this, Grid4,sortList);
 
        }

        #endregion

        #region 排序
        /// <summary>
        /// 页面表格绑定排序
        /// </summary>
        public void Sort()
        {
            //设置排序
            sortList = new List<string>();
            sortList.Add(PagePowerSignPublicTable.Id + " asc");
        
        }
        #endregion
 
        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private int InquiryCondition()
        {
            int value = 0;

            ////选择菜单
            //if (ddlParentId.SelectedValue != "0")
            //{
            //    value = ConvertHelper.Cint0(ddlParentId.SelectedValue);
            //}
            return value;
        }


    
 
        protected void Grid3_OnRowClick(object sender, FineUI.GridRowClickEventArgs e)
        {
            Grid4.Rows.Clear();

           
            GridRow gr = Grid3.Rows[e.RowIndex];
            
            menuInfoId_ = int.Parse(gr.Values[0].ToString());

          // PositionBll.GetInstence().BandPagePowerSignPublicList(this, Grid4);

            
           // PositionBll.GetInstence().BandPagePowerSignList(this, Grid5, menuInfoId);

            //var list = PagePowerSignBll.GetInstence().GetList(false);

           // bll.BindGrid(Grid4, InquiryCondition(), sortList);


          //  conditionList = new List<ConditionFun.SqlqueryCondition>();
           // conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "1", Comparison.Equals, "1", false, false));
            //bll.BindGrid(Grid1, 0, sortList);
           // bll.BindGrid(Grid4, 0, 0, conditionList, sortList);

            PagePowerSignPublicBll.GetInstence().BandPagePowerSignPublicList(this,Grid4);
           

        }

        #region 列表按键绑定——修改列表控件属性
        /// <summary>
        /// 列表按键绑定——修改列表控件属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid4_PreRowDataBound(object sender, FineUI.GridPreRowEventArgs e)
        {

            int rowc = Grid4.Rows.Count;

            int id = ConvertHelper.Cint0(hidId.Text);//获取页面传值
            Solution.DataAccess.Model.Position model = new DataAccess.Model.Position();
            //获取指定ID的菜单内容，如果不存在，则创建一个菜单实体
            model = PositionBll.GetInstence().GetModelForCache(x => x.Id == id);

            GridRow gr1 = Grid3.Rows[Grid3.SelectedRowIndex];
            menuInfoId_ = int.Parse(gr1.Values[0].ToString());

            if (model == null)
                return;
            //绑定是否显示状态列
            if (menuInfoId_ != 0)
            {

                int o = e.RowIndex;
                DataRowView row = e.DataItem as DataRowView;

                string _ControlPower = model.ControlPower;// PositionBll.GetInstence().GetFieldValue(id, "ControlPower", true).ToString();

             //   GridRow gr = Grid4.Rows[o];

                string str = ((System.Data.DataRowView)(row)).Row.Table.Rows[e.RowIndex][0].ToString();
                string s = "," + menuInfoId_.ToString() + "|" + str + ",";

                if (_ControlPower.IndexOf("," + menuInfoId_.ToString() + "|" + str + ",") >= 0)
                {
                    var lbf = Grid4.FindColumn("IsOrNotLink") as LinkButtonField;
                    lbf.Icon = Icon.BulletTick;
                    lbf.CommandArgument = "0";
                }
                else
                {
                    var lbf = Grid4.FindColumn("IsOrNotLink") as LinkButtonField;
                    lbf.Icon = Icon.BulletCross;
                    lbf.CommandArgument = "1";
                }

            }
            
        }
        #endregion

         #region Grid点击事件
        /// <summary> 
        /// Grid点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid4_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            GridRow gr = Grid4.Rows[e.RowIndex];
            //获取当前点击列的主键ID
            int id_public = int.Parse(gr.DataKeys[0].ToString());
        
            switch (e.CommandName)
            {
                case "IsOrNotLink":
                    string id_menu = GridViewHelper.GetSelectedKey(Grid3, true); //获取未分配的 勾选的Id
                    if (Grid3.SelectedRowIndexArray.Length > 1 || Grid3.SelectedRowIndexArray.Length == 0)
                    {
                        Alert.Show("请选择一行！",MessageBoxIcon.Warning);
                        break;
                    }

                    //更新状态
                  //  MenuInfoBll.GetInstence().UpdateIsDisplay(this, ConvertHelper.Cint0(id), ConvertHelper.Cint0(e.CommandArgument));

                    if (e.CommandArgument == "0")
                    {
                        //删除PagePowerSign
                        if (Grid3.SelectedRowIndexArray.Length ==0) 
                        {
                            Alert.Show("请搜选菜单项!",MessageBoxIcon.Information);
                        }

                        GridRow gr1 = Grid3.Rows[Grid3.SelectedRowIndex];
                        menuInfoId_ = int.Parse(gr1.Values[0].ToString());

                      
                        var model1 = new Solution.DataAccess.DataModel.PagePowerSignPublic(x => x.Id == id_public);

                        var model_p = PagePowerSign.SingleOrDefault(x=>x.PagePowerSignPublic_Id == model1.Id && x.MenuInfo_Id == menuInfoId); // PagePowerSignBll.GetInstence().GetModel(model1.Id, menuInfoId_, true);  //获取PagePowerSign表
 
                        PagePowerSignBll.GetInstence().Delete(this, model_p.Id);
  
                        int id = ConvertHelper.Cint0(hidId.Text);//获取页面传值
                        var model = new DataAccess.Model.Position();
                        //获取指定ID的菜单内容，如果不存在，则创建一个菜单实体
                        model = PositionBll.GetInstence().GetModelForCache(x => x.Id == id);

                        string new_control = model.ControlPower.Replace(id_menu + "|" + id_public + ",", "");
                       // model.ControlPower = new_control;

                        PositionBll.GetInstence().UpdateValue(this, id, "ControlPower", new_control,"", true, false);    //.UpdateControlPower(this, id, new_control, false, false);
                      //  PositionBll.GetInstence().SetModelForCache(model);
                        

                    }
                    else { //添加PagePowerSign

                        //Solution.DataAccess.Model.PagePowerSign model = new DataAccess.Model.PagePowerSign();
                        //model.PagePowerSignPublic_Id = (int)id;
                        //model.CName = 

                        var model1 = new Solution.DataAccess.DataModel.PagePowerSignPublic(x => x.Id == id_public);
                     
                        Solution.DataAccess.DataModel.PagePowerSign pps = new DataAccess.DataModel.PagePowerSign();
                        pps.PagePowerSignPublic_Id = model1.Id;
                        pps.CName = model1.Cname;
                        pps.EName = model1.Ename;
                        pps.MenuInfo_Id = int.Parse(id_menu);

                        PagePowerSignBll.GetInstence().Save(this, pps);

                        int id = ConvertHelper.Cint0(hidId.Text);//获取页面传值
                        var model = new DataAccess.Model.Position();
                        //获取指定ID的菜单内容，如果不存在，则创建一个菜单实体
                        model = PositionBll.GetInstence().GetModelForCache(x => x.Id == id);

                        string new_control= model.ControlPower + id_menu + "|" + id_public + ",";
                        //model.ControlPower = new_control;

                        PositionBll.GetInstence().UpdateValue(this, id, "ControlPower", new_control, "", true, false);  
                        //PositionBll.GetInstence().UpdateControlPower(this, id, new_control, false, false);
                        //PositionBll.GetInstence().SetModelForCache(model);

                    }


                    //重新加载


                    conditionList = new List<ConditionFun.SqlqueryCondition>();
                   conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "1", Comparison.Equals, "1", false, false));
                   //bll.BindGrid(Grid1, 0, sortList);
                   bll.BindGrid(Grid4, 0, 0, conditionList, sortList);

                    break;
            }
        }

        #endregion

        public void BindGrid4_RowsData() {
         
        
        
        
        
        }


        protected void AddPagePowerSign_Click(object sender,EventArgs e) 
        {

            int positionId = ConvertHelper.Cint0(hidId.Text);//获取页面传值  positionId

            string id = GridViewHelper.GetSelectedKey(Grid1, true); //获取未分配的 勾选的Id

            string _PagePower = PositionBll.GetInstence().GetFieldValue("PagePower", string.Format("Id = {0}", positionId)).ToString();//获取已有的菜单权限

            string parentId = MenuInfoBll.GetInstence().GetFieldValue("ParentId", string.Format("Id = {0}", id)).ToString();//获取 父ID

            _PagePower += id + "|";

            //if (_PagePower.IndexOf("|" + parentId + "|") < 0)
            //{
            //    _PagePower += parentId + "|" + id + "|";
            //}
            //else {
            //    _PagePower += id + "|";

            //}

            PositionBll.GetInstence().UpdateValue(this, positionId, "PagePower", _PagePower, "", false, false);


            MenuInfoBll.GetInstence().BandDropDownListShowMenu1(this, Grid1, _PagePower, ""); //绑定菜单和页面权限

            MenuInfoBll.GetInstence().BandDropDownListShowMenu2(this, Grid2, _PagePower, ""); //绑定菜单和页面权限

            MenuInfoBll.GetInstence().BandDropDownListShowMenu3(this, Grid3, _PagePower, ""); //绑定菜单和页面权限


            //   LoadData();

        }

        protected void DelPagePowerSign_Click(object sender, EventArgs e)
        {

            int positionId = ConvertHelper.Cint0(hidId.Text);//获取页面传值  positionId

            string id = GridViewHelper.GetSelectedKey(Grid2, true); //获取未分配的 勾选的Id

            string _PagePower = PositionBll.GetInstence().GetFieldValue("PagePower", string.Format("Id = {0}", positionId)).ToString();//获取已有的菜单权限

            string parentId = MenuInfoBll.GetInstence().GetFieldValue("ParentId", string.Format("Id = {0}", id)).ToString();//获取 父ID

            string removeChar = "|" + id + "|";

            _PagePower = _PagePower.Replace(removeChar, "|");

            //if (_PagePower.IndexOf("|" + parentId + "|") < 0)
            //{
            //    _PagePower += parentId + "|" + id + "|";
            //}
            //else
            //{
            //    _PagePower += id + "|";

            //}

            PositionBll.GetInstence().UpdateValue(this, positionId, "PagePower", _PagePower, "", false, false);


            MenuInfoBll.GetInstence().BandDropDownListShowMenu1(this, Grid1, _PagePower, ""); //绑定菜单和页面权限

            MenuInfoBll.GetInstence().BandDropDownListShowMenu2(this, Grid2, _PagePower, ""); //绑定菜单和页面权限

            MenuInfoBll.GetInstence().BandDropDownListShowMenu3(this, Grid3, _PagePower, ""); //绑定菜单和页面权限
 
        }

        //#region 页面控件绑定
        ///// <summary>下拉列表改变事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void ddlParentId_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //初始化路径值

        //    //获取当前节点的父节点Id
        //   // txtParent.Text = ddlParentId.SelectedValue;
        //    if (!ddlParentId.SelectedValue.Equals("0"))
        //    {
        //        try
        //        {
        //            //获取当前节点的父节点url
        //            txtUrl.Text = MenuInfoBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(ddlParentId.SelectedValue), MenuInfoTable.Url) + "";
        //        }
        //        catch
        //        {
        //        }
        //    }
        //}
        //#endregion

        #region 保存
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <returns></returns>
        public override string Save()
        {
            string result = string.Empty;
            int id = ConvertHelper.Cint0(hidId.Text);
          //  int Branch_Id = int.Parse(ddlParentId.SelectedValue);

            try
            {
                #region 数据验证

                if (string.IsNullOrEmpty(txtPosition.Text.Trim()))
                {
                    return txtPosition.Label + "不能为空！";
                }

                if (txtPosition.Text.Trim() == "请选择菜单")
                {
                    return txtPosition.Label + "不能为请选择菜单！";
                }

          
                #endregion

                #region 赋值
                //读取指定部门资料
                var model = new Solution.DataAccess.DataModel.Position(x => x.Id == id);

                //设置名称
                model.Name = txtPosition.Text;
                //连接地址
                model.Branch_Id = 100;// int.Parse(ddlParentId.SelectedValue);
                model.Branch_Code = "0100";// +ddlParentId.SelectedValue;
                model.Branch_Name = ""; //ddlParentId.SelectedText;
                

                ////设定当前的深度与设定当前的层数级
                //if (model.ParentId == 0)
                //{
                //    //设定当前的层数级
                //    model.Depth = 0;
                //}
                //else
                //{
                //    try
                //    {
                //        //设定当前的层数级
                //        model.Depth = ConvertHelper.Cint0(MenuInfoBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(ddlParentId.SelectedValue), MenuInfoTable.Depth)) + 1;
                //    }
                //    catch
                //    {
                //        model.Depth = 0;
                //    }
                //}

                ////设置排序
                //if (txtSort.Text == "0")
                //{
                //    //model.Sort = ConvertHelper.Cint0(SPs.P_All_GetOrderId(MenuInfoTable.TableName, MenuInfoTable.ParentId, model.ParentId.ToString(), MenuInfoTable.Sort).ExecuteScalar()) + 1;
                //}
                //else
                //{
                //    model.Sort = ConvertHelper.Cint0(txtSort.Text);
                //}
                ////设定当前项属于菜单还是页面
                //model.IsMenu = ConvertHelper.StringToByte(rblIsMenu.SelectedValue);
                ////设定当前项是否显示
                //model.IsDisplay = ConvertHelper.StringToByte(rblIsDisplay.SelectedValue);
                #endregion

                //----------------------------------------------------------
                //存储到数据库
                PositionBll.GetInstence().Save(this, model);
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
    }
}