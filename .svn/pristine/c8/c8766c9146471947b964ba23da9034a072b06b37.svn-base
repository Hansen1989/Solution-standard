using System;
using System.Web;
using DotNet.Utilities;
using System.Web.UI;
using Solution.DataAccess.DataModel;

/***********************************************************************
 *   作    者：AllEmpty（陈焕）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 术 群：327360708
 *  
 *   创建日期：2014-06-17
 *   文件名称：PositionBll.cs
 *   描    述：职位（角色）管理逻辑类
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Logic.Managers
{
    /// <summary>
    /// Position表逻辑类
    /// </summary>
    public partial class PositionBll : LogicBase
    {
        /***********************************************************************
         * 自定义函数                                                          *
         ***********************************************************************/
        #region 自定义函数

        #region 获取用户权限并记录到用户Session里
        /// <summary>
        /// 获取用户权限并存储到用户Session里
        /// </summary>
        /// <param name="positionId"></param>
        public void SetUserPower(string positionId)
        {
            if (!string.IsNullOrEmpty(positionId))
            {
                //因用户有的拥有多个职位，所以将用户职位取出并存入数组
                string[] arr = positionId.Split(new char[] { ',' });

                //循环读取用户职位权限
                for (int i = 0; i < arr.Length; i++)
                {
                    var id = ConvertHelper.Cint0(arr[i]);
                    //取得职位实体对象
                    var model = GetModelForCache(x => x.Id == id);
                    if (model != null)
                    {
                        //将用户权限记录到用户Session里
                        SetPagePower(model.PagePower);
                        SetControlPower(model.ControlPower);
                    }
                }
            }
        }

        /// <summary>
        /// 将用户的页面访问权限记录到Session["PagePower"]里
        /// </summary>
        /// <param name="pagePower">页面访问权限</param>
        private void SetPagePower(string pagePower)
        {
            //如果页面访问权限Session为空，则直接赋值
            if (HttpContext.Current.Session["PagePower"] == null)
            {
                HttpContext.Current.Session["PagePower"] = pagePower;
            }
            else
            {
                //从Session中读取出已存储的权限字串
                string spp = HttpContext.Current.Session["PagePower"] + "";

                //将传入的变量存入数组pp
                string[] pp = pagePower.Split(new char[] { ',' });
                //循环逐个判断权限是否存在
                for (int i = 0; i < pp.Length; i++)
                {
                    //权限不存在的，则加入该权限
                    if (spp.IndexOf("," + pp[i] + ",") < 0 && pp[i] != "")
                    {
                        spp += pp[i] + ",";
                    }
                }
                //将添加了其他职位权限后的权限字符串存入Session
                HttpContext.Current.Session["PagePower"] = spp;
            }
        }

        /// <summary>
        /// 将用户页面的控件访问权限记录到Session["ControlPower"]里
        /// </summary>
        /// <param name="controlPower">页面的控件访问权限</param>
        private void SetControlPower(string controlPower)
        {
            //如果页面访问权限Session为空，则直接赋值
            if (HttpContext.Current.Session["ControlPower"] == null)
            {
                HttpContext.Current.Session["ControlPower"] = controlPower;
            }
            else
            {
                //从Session中读取出已存储的权限字串
                string spp = Convert.ToString(HttpContext.Current.Session["ControlPower"]);

                //将传入的变量存入数组pp
                string[] pp = controlPower.Split(new char[] { '|' });
                //循环逐个判断权限是否存在
                for (int i = 0; i < pp.Length; i++)
                {
                    //权限不存在的，则加入该权限
                    if (spp.IndexOf("|" + pp[i] + "|") < 0 && pp[i] != "")
                    {
                        spp += pp[i] + "|";
                    }
                }
                //将添加了其他职位权限后的权限字符串存入Session
                HttpContext.Current.Session["ControlPower"] = spp;
            }
        }
        #endregion

        #region 绑定菜单下拉列表
        /// <summary>
        /// 绑定菜单下拉列表——只显示一级菜单
        /// </summary>
        public void BandDropDownList(Page page, FineUI.DropDownList ddl)
        {
            var dt = GetDataTable();// DataTableHelper.GetFilterData(GetDataTable(), PositionTable.ParentId, "1", PositionTable.Id, "desc");

            //显示值
            ddl.DataTextField = PositionTable.Name;
            //显示key
            ddl.DataValueField = PositionTable.Id;

            //绑定数据源
            ddl.DataSource = dt;
            ddl.DataBind();
            ddl.Items.Insert(0, new FineUI.ListItem("请选择菜单", "0"));
            ddl.SelectedValue = "0";
        }

        /// <summary>
        /// 绑定菜单下拉列表——只显示所有可以显示的菜单（IsMenu)
        /// </summary>
        public void BandDropDownListShowMenu(Page page, FineUI.DropDownList ddl)
        {
            //在内存中筛选记录   string.Format("{0}={1}", BranchTable.IsMenu, 0)
            var dt = DataTableHelper.GetFilterData(GetDataTable(), string.Format("{0} is not null", BranchTable.Id), BranchTable.Depth + ", " + BranchTable.Sort);

            try
            {
                //整理出有层次感的数据
                dt = DataTableHelper.DataTableTidyUp(dt, BranchTable.Id, BranchTable.ParentId, 0);

                ddl.EnableSimulateTree = true;

                //显示值
                ddl.DataTextField = BranchTable.Name;
                //显示key
                ddl.DataValueField = BranchTable.Id;
                //数据层次
                ddl.DataSimulateTreeLevelField = BranchTable.Depth;
                //绑定数据源
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.SelectedIndex = 0;

                ddl.Items.Insert(0, new FineUI.ListItem("请选择菜单", "0"));
                ddl.SelectedValue = "0";
            }
            catch (Exception e)
            {
                // 记录日志
                CommonBll.WriteLog("", e);
            }
        }
        #endregion

        

        #endregion 自定义函数

    }
}
