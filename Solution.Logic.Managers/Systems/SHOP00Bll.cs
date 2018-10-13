using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using DotNet.Utilities;

using System.Collections;
using System.Web;
using Solution.DataAccess.Model;
using Solution.DataAccess.DataModel;
using System.Data;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;


namespace Solution.Logic.Managers
{

    public partial class SHOP00Bll : LogicBase
    {
        /***********************************************************************
		 * 自定义函数                                                          *
		 ***********************************************************************/

        #region 自定义函数

        private const string const_CacheKey_Model = "Cache_SHOP00_AllModel";


        #region 清空缓存

        /// <summary>清空缓存</summary>
        public override void DelCache()
        {
            CacheHelper.RemoveOneCache(const_CacheKey_Model);
        }

        #endregion


        #region 检查页面权限

        /// <summary>
        /// 检查当前菜单或页面是否有权限访问
        /// </summary>
        /// <param name="menuId">菜单ID</param>
        /// <returns>真或假</returns>
        public bool CheckPagePower(string menuId)
        {
            var pagePower = OnlineUsersBll.GetInstence().GetPagePower();
            if (string.IsNullOrEmpty(pagePower) || menuId == "")
            {
                return false;
            }
            //检查是否有权限
            if (
                pagePower.IndexOf("," + menuId + ",") >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 页面访问加密--检查用户是否从正确的路径进入本页面

        /// <summary>
        /// 设置页面加密--用于检查用户是否从正确的路径进入本页面
        /// </summary>
        /// <param name="key">页面加密的Key</param>
        /// <returns>加密后的字符串</returns>
        public string SetPageEncrypt(string key)
        {
            //当前用户md5
            var md5 = OnlineUsersBll.GetInstence().GetMd5();
            //加密：md5+Key
            var encrypt = DotNet.Utilities.Encrypt.Md5(md5 + key);
            //再次加密：Key + Encrypt
            return Encrypt.Md5(key + encrypt);
        }

        /// <summary>
        /// 检查用户是否从正确的路径进入本页面，默认KEY为ID
        /// </summary>
        public void CheckPageEncrypt(Page page)
        {
            //当前用户md5
            var md5 = OnlineUsersBll.GetInstence().GetMd5();
            //Key，如果没有传递Key这个变量过来的，就读取id或ParentID做为Key使用
            var key = HttpContext.Current.Request["Id"];
            if (string.IsNullOrEmpty(key))
            {
                key = HttpContext.Current.Request["pid"];
            }
            if (string.IsNullOrEmpty(key))
            {
                key = HttpContext.Current.Request["ParentId"];
            }
            if (string.IsNullOrEmpty(key))
            {
                key = HttpContext.Current.Request["Key"];
            }
            //上一链接传过来的加密数据
            var keyEncrypt = HttpContext.Current.Request["KeyEncrypt"];

            //加密：md5+Key
            var encrypt = Encrypt.Md5(md5 + key);
            //再次加密：Key + Encrypt
            encrypt = Encrypt.Md5(key + encrypt);

            //检查是否有权限，没有权限的直接终止当前页面的运行
            if (keyEncrypt != encrypt || string.IsNullOrEmpty(key))
            {
                //添加用户访问记录
                UseLogBll.GetInstence().Save(page, "{0}没有权限访问【{1}】页面");

                HttpContext.Current.Response.Write("你从错误的路径进入当前页面！");
                HttpContext.Current.Response.End();
            }
        }

        /// <summary>
        /// 组成URL加密参数字符串
        /// </summary>
        /// <param name="key">页面加密的Key</param>
        /// <returns>组成URL加密参数字符串</returns>
        public string PageUrlEncryptString(string key)
        {
            return "KeyEncrypt=" + SetPageEncrypt(key) + "&Key=" + key;
        }

        /// <summary>
        /// 组成URL加密参数字符串，使用随机生成的Key，如果页面传的参数中包含有ID这个名称的，则不能使用本函数
        /// </summary>
        /// <returns>组成URL加密参数字符串</returns>
        public string PageUrlEncryptString()
        {
            var key = RandomHelper.GetRandomCode(null, 12);
            return "KeyEncrypt=" + SetPageEncrypt(key) + "&Id=" + key;
        }

        /// <summary>
        /// 组成URL加密参数字符串——返回不带Key的字符串
        /// </summary>
        /// <param name="key">页面加密的Key</param>
        /// <returns>组成URL加密参数字符串——不带Key</returns>
        public string PageUrlEncryptStringNoKey(string key)
        {
            return "KeyEncrypt=" + SetPageEncrypt(key);
        }

        /// <summary>和 PageBase.BtnSave_Click 对应，部分页面刷新后不关闭原页面，并要刷新的情况下使用</summary>
        /// <param name="url">跳转的url</param>
        /// <returns></returns>
        public string PageSaveReturnUrlFlash(string url)
        {
            url = DirFileHelper.GetFilePath(HttpContext.Current.Request.Path) + "/" + url;
            return "{url}" + url;
        }

        #endregion

        #region 从页面中找到放置按键控件的位置——获得一个控件组

        /// <summary>
        /// 从页面中找到放置按键控件的位置——获得一个控件组
        /// </summary>
        /// <param name="controls"></param>
        /// <returns></returns>
        public ControlCollection GetControls(ControlCollection controls, string id)
        {
            if (controls == null)
                return null;

            ControlCollection c = null;
            try
            {
                for (int i = 0; i < controls.Count; i++)
                {
                    if (controls[i].ID == id)
                    {
                        return controls[i].Controls;
                    }
                    c = GetControls(controls[i].Controls, id);
                    if (c != null)
                        return c;
                }
            }
            catch (Exception e)
            {
                // 记录日志
                CommonBll.WriteLog("", e);
            }

            return c;
        }

        /// <summary>
        /// 从页面中找到放置按键控件的位置
        /// </summary>
        /// <param name="controls"></param>
        /// <returns></returns>
        public object FindControl(ControlCollection controls, string id)
        {
            if (controls == null)
                return null;

            object c = null;
            try
            {
                for (int i = 0; i < controls.Count; i++)
                {
                    if (controls[i].ID == id)
                    {
                        return controls[i];
                    }
                    c = FindControl(controls[i].Controls, id);
                    if (c != null)
                        return c;
                }
            }
            catch (Exception e)
            {
                // 记录日志
                CommonBll.WriteLog("", e);
            }

            return c;
        }
        #endregion

        #region 绑定菜单下拉列表
        /// <summary>
        /// 绑定菜单下拉列表——显示所有的数据
        /// </summary>
        public void BandDropDownListShowShop(Page page, FineUI.DropDownList ddl, string shop_id)
        {

            //在内存中筛选记录
            var dt = DataTableHelper.GetFilterData(GetDataTable(), string.Format("{0} = '{1}'", SHOP00Table.SHOP_ID, shop_id), SHOP00Table.Id);

            try
            {
                //显示值
                ddl.DataTextField = SHOP00Table.SHOP_NAME1;
                //显示key
                ddl.DataValueField = SHOP00Table.SHOP_ID;
                //数据层次
                //绑定数据源
                ddl.DataSource = dt;
                ddl.DataBind();
                //   ddl.SelectedIndex = 0;

                //ddl.Items.Insert(0, new FineUI.ListItem("请选择分店", "0"));
                //ddl.SelectedValue = "0";
            }
            catch (Exception e)
            {
                // 记录日志
                CommonBll.WriteLog("", e);
            }
        }
        #endregion

        #region 绑定菜单下拉列表
        /// <summary>
        /// 绑定菜单下拉列表——显示所有的数据
        /// </summary>
        public void BandDropDownListShowShop1(Page page, FineUI.DropDownList ddl)
        {

            //在内存中筛选记录
            //在内存中筛选记录
            var dt = DataTableHelper.GetFilterData(GetDataTable(), "1", "1", SHOP00Table.Id, " desc");

            try
            {
                //显示值
                ddl.DataTextField = SHOP00Table.SHOP_NAME1;
                //显示key
                ddl.DataValueField = SHOP00Table.SHOP_ID;
                //数据层次
                //绑定数据源
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.SelectedIndex = 0;

                //ddl.Items.Insert(0, new FineUI.ListItem("请选择分店", "0"));
                //ddl.SelectedValue = "0";
            }
            catch (Exception e)
            {
                // 记录日志
                CommonBll.WriteLog("", e);
            }
        }
        #endregion

        /// <summary>
        /// 根据门店区域编码，获取该区域下所有的门店，包括自己,并绑定到DropList
        /// </summary>
        /// <returns></returns>
        public void GetShopList(Page page, string shop_id, FineUI.DropDownList ddl)
        {
            try
            {
                List<ConditionFun.SqlqueryCondition> shopCondit = new List<ConditionFun.SqlqueryCondition>();
                shopCondit.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, SHOP00Table.SHOP_Area_ID, Comparison.Equals, shop_id, false, false));
                shopCondit.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Or, SHOP00Table.SHOP_ID, Comparison.Equals, shop_id, false, false));
                var dt = DataTableHelper.GetFilterData(GetDataTable(false, 0, null, 0, 0, shopCondit, null), "1", "1", SHOP00Table.Id, " desc");
                //显示值
                ddl.DataTextField = SHOP00Table.SHOP_NAME1;
                //显示key
                ddl.DataValueField = SHOP00Table.SHOP_ID;
                //数据层次
                //绑定数据源
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.SelectedIndex = 0;

                //ddl.Items.Insert(0, new FineUI.ListItem("请选择分店", "0"));
                //ddl.SelectedValue = "0";
            }
            catch (Exception e)
            {
                // 记录日志
                CommonBll.WriteLog("", e);
            }
        }

        /// <summary>
        /// 下拉列表只绑定当前的用户,如果传入的是隶属区域则绑定到区域
        /// </summary>
        /// <param name="page"></param>
        /// <param name="shop_id"></param>
        /// <param name="ddl"></param>
        public void BindOnlineUser(Page page, string shop_id, FineUI.DropDownList ddl)
        {
            try
            {
                List<ConditionFun.SqlqueryCondition> shopCondit = new List<ConditionFun.SqlqueryCondition>();
                shopCondit.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Or, SHOP00Table.SHOP_ID, Comparison.Equals, shop_id, false, false));
                var dt = DataTableHelper.GetFilterData(GetDataTable(false, 0, null, 0, 0, shopCondit, null), "1", "1", SHOP00Table.Id, " desc");
                //显示值
                ddl.DataTextField = SHOP00Table.SHOP_NAME1;
                //显示key
                ddl.DataValueField = SHOP00Table.SHOP_ID;
                //数据层次
                //绑定数据源
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.SelectedIndex = 0;

                //ddl.Items.Insert(0, new FineUI.ListItem("请选择分店", "0"));
                //ddl.SelectedValue = "0";
            }
            catch (Exception e)
            {
                // 记录日志
                CommonBll.WriteLog("", e);
            }
        }


        #endregion 自定义函数
    }
}
