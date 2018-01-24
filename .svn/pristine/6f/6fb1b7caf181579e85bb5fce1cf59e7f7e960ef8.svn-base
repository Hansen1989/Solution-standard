using System;
using System.Collections.Generic;
using System.Web.UI;
using DotNet.Utilities;
using FineUI;
using Solution.Logic.Managers;
using Solution.Logic.Managers.Application;
using Solution.DataAccess.DbHelper;
using System.ComponentModel;
 

namespace Solution.Web.Managers.WebManage.Application
{
    /// <summary>
    /// Web层页面父类
    /// </summary>
    public abstract class PageBase : System.Web.UI.Page, IPageBase
    {
        #region 定义对象
        //逻辑层接口对象
        protected ILogicBase bll = null;
 
        //定义列表对象
        protected FineUI.Grid grid = null;
 
        //页面排序容器
        protected List<string> sortList = null;

        protected List<ConditionFun.SqlqueryCondition> conditionList = null;
        #endregion

        //页面sql容器
        protected List<ConditionFun.SqlqueryCondition> sqlwhereList = null;

        #region 初始化函数
        protected override void OnInit(EventArgs e)
        {

            base.OnInit(e);

            //检测用户是否超时退出
            OnlineUsersBll.GetInstence().IsTimeOut();

            if (!IsPostBack)
            {
                //检测当前页面是否有访问权限
                //MenuInfoBll.GetInstence().CheckPagePower(this);

                #region 设置页面按键权限
                try
                {
                    //定义按键控件
                    Control btnControl = null;
                    //找到页面放置按键控件的位置
                    ControlCollection controls = MenuInfoBll.GetInstence().GetControls(this.Controls, "toolBar");
                    //逐个读取出来
                    if (controls != null)
                    {
                        for (int i = 0; i < controls.Count; i++)
                        {
                            //取出控件
                            btnControl = controls[i];
                            //判断是否除了刷新、查询和关闭以外的按键  btnControl.ID != "ButtonAdd" && btnControl.ID != "ButtonEdit" && btnControl.ID != "ButtonDelete" &&  && btnControl.ID != "ButtonReset"
                            if (btnControl.ID != "ButtonRefresh" && btnControl.ID != "ButtonSearch" && btnControl.ID != "ButtonClose" && btnControl.ID != "ButtonCancel")
                            {
                                //是的话检查该按键当前用户是否有控件权限，没有的话则禁用该按键
                                ((FineUI.Button)btnControl).Enabled = MenuInfoBll.GetInstence().CheckControlPower(this, btnControl.ID);
                            }
                        }
                    }
                }
                catch (Exception) { }
                #endregion

                //记录用户当前所在的页面位置
                CommonBll.UserRecord(this);
            }

            //运行UI页面初始化函数，子类继承后需要重写本函数，以提供给本初始化函数调用
            Init();
        }


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            if (grid != null)
            {
                grid.PageIndex = e.NewPageIndex;

                //LoadData();
            }
        }

        /// <summary>
        /// 对页面或其控件的内容进行最后更改
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            //利用反射的方式给页面控件赋值
            //查找指定名称控件
            var control = MenuInfoBll.GetInstence().FindControl(this.Controls, "lblSpendingTime");
            if (control != null)
            {
                //判断是否是FineUI.HiddenField类型
                var type = control.GetType();
                if (type.FullName == "FineUI.Label")
                {
                    //存储排序列字段名称
                    ((FineUI.Label)control).Text = "执行耗时：" + Session["SpendingTime"] + "秒";
                }
            }
            
            base.OnPreRender(e);
        }
        #endregion

        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值

        /// <summary>
        /// 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        /// </summary>
        public abstract void Init();

        #endregion

        #region 页面各种按键事件

        /// <summary>
        /// 刷新按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonRefresh_Click(object sender, EventArgs e)
        {
            FineUI.PageContext.RegisterStartupScript("window.location.reload()");
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());

        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }
 
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            //执行删除操作，返回删除结果
            string result = Delete();

            if (string.IsNullOrEmpty(result))
                return;
            //弹出提示框
            FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);

            //重新加载页面表格
            LoadData();
        }

        ///核准
        ///
        /// 
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonApproval_Click(object sender, EventArgs e)
        {
            Approval();
        }
 
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            //执行保存操作，返回保存结果
            string result = Save();

            if (string.IsNullOrEmpty(result))
            {
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
                FineUI.Alert.ShowInParent("保存成功", FineUI.MessageBoxIcon.Information);
            }
            else
            {
                //by july，部分页面保存后，必须刷新原页面的，把返回的值用 "{url}" + 跳转地址的方式传过来
                if (StringHelper.Left(result, 5) == "{url}")
                {
                    string url = result.Trim().Substring(6);
                    FineUI.Alert.ShowInParent("保存成功", "", FineUI.MessageBoxIcon.Information, "self.location='" + url + "'");
                }
                else
                {
                    FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>保存排序</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSaveSort_Click(object sender, EventArgs e)
        {
            SaveSort();
        }

        /// <summary>自动排序</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSaveAutoSort_Click(object sender, EventArgs e)
        {
            //默认使用多级分类
            SaveAutoSort();
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            //生成排序关键字
            Sort(e);
            //刷新列表
            LoadData();
        }

        /// <summary>
        /// 单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_RowClick(object sender, GridRowClickEventArgs e)
        {
            SingleClick(e);
        }

        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_RowDoubleClick(object sender, GridRowClickEventArgs e)
        {
            DoubleClick(e);
        }

        

        /// <summary>
        /// 关闭子窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// 关闭子窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Window2_Close(object sender, WindowCloseEventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// 关闭子窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Window3_Close(object sender, WindowCloseEventArgs e)
        {
            LoadData();
        }
        #endregion

        #region 虚函数，主要给页面各种按键事件调用，子类需要使用到相关功能时必须将它实现

        /// <summary>
        /// 加载事件
        /// </summary>
        public abstract void LoadData();

        /// <summary>
        /// 添加记录
        /// </summary>
        public virtual void Add() { }

        /// <summary>
        /// 修改记录
        /// </summary>
        public virtual void Edit() { }

        /// <summary>
        /// 取消
        /// </summary>
        public virtual void Cancel() { }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <returns>返回删除结果</returns>
        public virtual string Delete()
        {
            return null;
        }

        ///
        public virtual void Approval(){}

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns>返回保存结果</returns>
        public virtual string Save()
        {
            return "";
        }


        /// <summary>
        /// 保存排序
        /// </summary>
        /// <returns>返回保存结果</returns>
        public virtual void SaveSort()
        {
            //保存排序
            if (grid != null && bll != null)
            {
                //更新排序
                if (bll.UpdateSort(this, grid, "tbSort"))
                {
                    //重新加载列表
                    LoadData();

                    Alert.ShowInParent("操作成功", "保存排序成功", "window.location.reload();");
                }
                else
                {
                    Alert.ShowInParent("操作成失败", "保存排序失败");
                }
            }
        }

        /// <summary>
        /// 保存自动排序
        /// </summary>
        public virtual void SaveAutoSort()
        {
            if (bll == null)
            {
                Alert.ShowInParent("保存失败", "逻辑层对象为null，请联系开发人员给当前页面的逻辑层对象赋值");
                return;
            }

            if (bll.UpdateAutoSort(this, "", true))
            {
                Alert.ShowInParent("保存成功", "保存自动排序成功", "window.location.reload();");
            }
            else
            {
                Alert.ShowInParent("保存失败", "保存自动排序失败");
            }
        }

        /// <summary>
        /// 生成排序关键字
        /// </summary>
        /// <param name="e"></param>
        public virtual void Sort(FineUI.GridSortEventArgs e)
        {
            //处理排序
            sortList = null;
            sortList = new List<string>();
            //排序列字段名称
            string sortName = "";

            if (e != null && e.SortField.Length > 0)
            {
                //判断是升序还是降序
                if (e.SortDirection != null && e.SortDirection.ToUpper() == "DESC")
                {
                    sortList.Add(e.SortField + " desc");
                }
                else
                {
                    sortList.Add(e.SortField + " asc");
                }
                sortName = e.SortField;
            }
            else
            {
                //使用默认排序——主键列降序排序
                sortList.Add("Id desc");
                sortName = "Id";
            }

            //利用反射的方式给页面控件赋值
            //查找指定名称控件
            var control = MenuInfoBll.GetInstence().FindControl(this.Controls, "SortColumn");
            if (control != null)
            {
                //判断是否是FineUI.HiddenField类型
                var type = control.GetType();
                if (type.FullName == "FineUI.HiddenField")
                {
                    //存储排序列字段名称
                    ((FineUI.HiddenField)control).Text = sortName;
                }
            }
        }

        /// <summary>
        /// 单击
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public virtual void SingleClick(GridRowClickEventArgs e)
        {
            
        }

        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public virtual void DoubleClick(GridRowClickEventArgs e)
        {
            
        }



        #endregion


        #region GetDeleteSelectedRowsScript

        /// <summary>
        /// 删除表格选中行（FineUI v6.0更新：必须加上延迟，否则弹出框会阻止事件向上传播，导致不能选中单元格！！）
        /// </summary>
        /// <param name="grid1"></param>
        /// <returns></returns>
        protected string GetDeleteScript(Grid grid1)
        {
            string confirmScript = Confirm.GetShowReference("删除选中行？", String.Empty, MessageBoxIcon.Question, grid1.GetDeleteSelectedRowsReference(), String.Empty);

            return String.Format("F.defer(function(){{{0}}},100);", confirmScript);
        }

        #endregion

        /// <summary>
        /// 删除选中行（或者单元格）
        /// </summary>
        [Obsolete("请使用DeleteSelectedRows")]
        public void DeleteSelected()
        {
            PageContext.RegisterStartupScript(GetDeleteSelectedRowsReference());
        }


        /// <summary>
        /// 获取删除选中行（或者单元格）的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        [Obsolete("请使用GetDeleteSelectedRowsReference")]
        public string GetDeleteSelectedReference()
        {
            return GetDeleteSelectedRowsReference();
        }


        /// <summary>
        /// 删除选中行（或者单元格）
        /// </summary>
        public void DeleteSelectedRows()
        {
            PageContext.RegisterStartupScript(GetDeleteSelectedRowsReference());
        }

        /// <summary>
        /// 获取删除选中行（或者单元格）的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetDeleteSelectedRowsReference()
        {
            return String.Format("{0}.f_deleteSelectedRows();", ScriptID);
        }

        /// <summary>
        /// 获取控件实例的JavaScript代码（比如：F('RegionPanel1_Button1')）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string ScriptID
        {
            get
            {
                return String.Format("F('{0}')", ClientID);
            }
        }

        /// <summary>
        /// 显示通知对话框
        /// </summary>
        /// <param name="message"></param>
        public void ShowNotify(string message)
        {
            Alert.Show(message);
        }

  
    }
}