using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;

/***********************************************************************
 *   作    者：AllEmpty（陈焕）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 术 群：327360708
 *  
 *   创建日期：2014-06-17
 *   文件名称：OnlineUsersBll.cs
 *   描    述：用户在线列表缓存管理逻辑类
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Logic.Managers
{
    /// <summary>
    /// OnlineUsersBll逻辑类
    /// </summary>
    public partial class OnlineUsersBll : LogicBase
    {
        /***********************************************************************
         * 自定义函数                                                          *
         ***********************************************************************/
        #region 自定义函数

        #region 加载数据库记录到缓存
        private static readonly object LockObject = new object();
        /// <summary>
        /// 加载数据库记录到缓存
        /// </summary>
        public void Load()
        {
            lock (LockObject)
            {
                //判断缓存中["OnlineUsers"]是否存在，不存在则尝试加载数据库中的在线表
                if (CacheHelper.GetCache("OnlineUsers") == null)
                {
                    //将当前用户信息添加到Hashtable中
                    var onlineUsers = new Hashtable();

                    //不存在则尝试加载数据库中的在线表到缓存中
                    var list = GetList();
                    if (list != null && list.Count > 0)
                    {
                        foreach (var model in list)
                        {
                            try
                            {
                                onlineUsers.Add(model.UserHashKey, model);
                            }
                            catch
                            {
                            }
                        }

                        //将在线列表（Hashtable）添中进系统缓存中
                        CacheHelper.SetCache("OnlineUsers", onlineUsers);
                    }
                }
            }
        }
        #endregion

        #region 获取在线用户表内容
        /// <summary>
        /// 根据字段名称，获取当前用户在线表中的内容
        /// </summary>
        /// <param name="colName">字段名<para/>
        /// 可选参数<para/>
        /// UserId : 当前用户的ID编号<para/>
        /// LoginDate : 登录时间<para/>
        /// OnlineTime : 在线时长<para/>
        /// LoginIp : 当前用户IP<para/>
        /// LoginName : 当前用户登陆名<para/>
        /// CName : 当前用户中文名<para/>
        /// Sex : 当前用户的性别<para/>
        /// BranchId : 部门自动ID<para/>
        /// BranchCode : 部门编码<para/>
        /// BranchName : 部门名称<para/>
        /// PositionInfoId : 职位ID<para/>
        /// PositionInfoName : 职位名称<para/>
        /// </param>
        /// <returns></returns>
        public object GetUserOnlineInfo(string colName)
        {
            return GetUserOnlineInfo(null, colName);
        }
        /// <summary>
        /// 根据字段名称，获取指定用户在线表中的内容
        /// </summary>
        /// <param name="userHashKey">用户在线列表的Key</param>
        /// <param name="colName">字段名<para/>
        /// userId : 当前用户的ID编号<para/>
        /// LoginDate : 登录时间<para/>
        /// OnlineTime : 在线时长<para/>
        /// LoginIp : 当前用户IP<para/>
        /// LoginName : 当前用户登陆名<para/>
        /// CName : 当前用户中文名<para/>
        /// Sex : 当前用户的性别<para/>
        /// BranchId : 部门自动ID<para/>
        /// BranchCode : 部门编码<para/>
        /// BranchName : 部门名称<para/>
        /// PositionInfoId : 职位ID<para/>
        /// PositionInfoName : 职位名称<para/>
        /// </param>
        /// <returns></returns>
        public object GetUserOnlineInfo(string userHashKey, string colName)
        {
            //由于GetUserHashKey有可能从

            try
            {
                if (colName == "")
                {
                    return null;
                }

                if (userHashKey == null)
                {
                    userHashKey = GetUserHashKey() + "";
                }

                //如果不存在在线表则退出
                if (HttpRuntime.Cache["OnlineUsers"] == null || userHashKey == "")
                    return null;

                //返回指定字段的内容
                var model = (DataAccess.Model.OnlineUsers)((Hashtable)CacheHelper.GetCache("OnlineUsers"))[userHashKey];

                return GetFieldValue(model, colName);
            }
            catch (Exception e)
            {
                //记录出错日志
                CommonBll.WriteLog("", e);
            }

            return null;
        }
        #endregion

        #region 更新在线用户信息
        /// <summary>
        /// 更新在线用户信息
        /// </summary>
        /// <param name="userHashKey">用户在线Hashtable Key</param>
        /// <param name="colName">要更新的字段名称</param>
        /// <param name="value">将要赋的值</param>
        public void UpdateUserOnlineInfo(string userHashKey, string colName, object value)
        {
            try
            {
                ((Dictionary<String, object>)((Hashtable)CacheHelper.GetCache("OnlineUsers"))[userHashKey])[colName] = value;
            }
            catch (Exception e)
            { //记录出错日志
                CommonBll.WriteLog("", e);
            }
        }
        #endregion

        #region 更新在线用户缓存表中最后在线时间
        /// <summary>
        /// 更新在线用户缓存表中最后在线时间
        /// </summary>
        public void UpdateTime()
        {
            try
            {
                //设置更新字段
                var dic = new Dictionary<string, object>();
                dic.Add(OnlineUsersTable.UpdateTime, DateTime.Now);
                //条件
                List<ConditionFun.SqlqueryCondition> wheres = null;
                wheres = new List<ConditionFun.SqlqueryCondition>();
                wheres.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, OnlineUsersTable.UserHashKey, Comparison.Equals, GetUserHashKey()));
                //更新
                UpdateValue(null, dic, wheres, "更新{0}最后在线时间");

                //修改在线缓存表中的用户最后在线时间
                UpdateUserOnlineInfo(GetUserHashKey(), OnlineUsersTable.UpdateTime, DateTime.Now);
            }
            catch (Exception e)
            {
                //记录出错日志
                CommonBll.WriteLog("", e);
            }
        }
        #endregion

        #region 获取在线人数
        /// <summary>
        /// 获取在线人数
        /// </summary>
        /// <returns></returns>
        public int GetUserOnlineCount()
        {
            var onlineUsers = CacheHelper.GetCache("OnlineUsers");
            if (onlineUsers != null)
            {
                return ((Hashtable)onlineUsers).Count;
            }
            return 0;
        }
        #endregion

        #region 更新在线人数
        /// <summary>
        /// 更新在线人数，将不在线人员删除
        /// </summary>
        public void UpdateUserOnlineCount()
        {
            //获取在线列表
            var onlineUsers = (Hashtable)CacheHelper.GetCache("OnlineUsers");

            //如果不存在在线表则退出
            if (onlineUsers == null)
                return;

            //初始化下线用户KEY存储数组
            var users = new string[onlineUsers.Count];
            int i = 0;

            //循环读取在线信息
            foreach (DictionaryEntry de in onlineUsers)
            {
                //判断该用户是否在线，不在线的话则将它暂停存储起来
                if (string.IsNullOrEmpty(GetUserHashKey()))
                {
                    users[i] = de.Key + "";
                    i++;
                }
            }

            //移除在线数据
            for (int j = 0; j < users.Length; j++)
            {
                if (users[j] == null)
                    break;

                //添加用户下线记录
                LoginLogBll.GetInstence().Save(users[j], "用户【{0}】退出系统！在线时间【{1}】");
                //将HashTable里存储的前一登陆帐户移除
                var userHashKey = users[j];
                Delete(null, x => x.UserHashKey == userHashKey);
                //移除在线用户
                RemoveUser(users[j]);
            }
        }
        #endregion

        #region 删除在线缓存中的用户
        /// <summary>
        /// 删除在线缓存中的用户
        /// </summary>
        /// <param name="userHashKey"></param>
        public void RemoveUser(string userHashKey)
        {
            //获取在线列表
            var onlineUsers = (Hashtable)CacheHelper.GetCache("OnlineUsers");

            //如果不存在在线表则退出
            if (onlineUsers == null)
                return;

            //移除在线用户
            onlineUsers.Remove(userHashKey);
        }
        #endregion

        #region 判断用户是否被强迫离线
        /// <summary>
        /// 判断用户是否被强迫离线[true是；false否]
        /// </summary>
        public bool IsOffline(Page page)
        {
            try
            {
                //获取当前用户Id
                var userinfoId = GetManagerId();

                //判断当前用户是否已经被系统清除
                if (userinfoId == 0)
                {
                    //通知用户
                    FineUI.Alert.Show("您太久没有操作已退出系统，请重新登录！", "检测通知", MessageBoxIcon.Information, "window.location.href='/WebManage/Login.aspx';");
                    return true;
                }
                else
                {
                    //判断在线用户的Md5与当前用户存储的Md5是否一致
                    if (GenerateMd5() != CookieHelper.GetCookieValue(OnlineUsersTable.Md5))
                    {
                        CommonBll.WriteLog("当前帐号已经下线，用户Id【" + userinfoId + "】");

                        //通知用户
                        FineUI.Alert.Show("您的账号已经在另一处登录，当前账号已经下线！", "检测通知", MessageBoxIcon.Information, "window.location.href='/WebManage/Login.aspx';");
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                CommonBll.WriteLog("Logic.Systems.Manager.CheckIsOffline出现异常", ex);

                FineUI.Alert.Show("系统已经开始更新维护，请稍后重新登录！", "检测通知", MessageBoxIcon.Information, "window.location.href='/WebManage/Login.aspx';");
                return true;
            }

        }
        #endregion

        #region 判断用户是否超时退出

        /// <summary>
        /// 判断用户是否超时退出（退出情况：1.系统更新，2.用户自动退出）
        /// </summary>
        public void IsTimeOut()
        {
            if (HttpContext.Current.Session == null || HttpRuntime.Cache["OnlineUsers"] == null || HttpContext.Current.Session[OnlineUsersTable.UserHashKey] == null)
            {
                try
                {
                    //不存在则表示Session失效了，重新从Cookies中加载
                    var userHashKey = CookieHelper.GetCookieValue(OnlineUsersTable.UserHashKey);
                    var md5 = CookieHelper.GetCookieValue(OnlineUsersTable.Md5);

                    //判断Cookies是否存在，存在则查询在线列表，重新获取用户信息
                    if (userHashKey.Length > 0 && md5.Length == 32)
                    {
                        //读取当前用户在线实体
                        var model = GetModelForCache(x => x.UserHashKey == userHashKey);
                        //当前用户存在在线列表中
                        if (model != null)
                        {
                            //计算用户md5值
                            var key = GenerateMd5(model);

                            //判断用户的md5值是否正确
                            if (md5 == key)
                            {
                                //将UserHashKey存储到缓存中
                                HttpContext.Current.Session[OnlineUsersTable.UserHashKey] = userHashKey;
                                //获取用户权限并存储到用户Session里
                                PositionBll.GetInstence().SetUserPower(model.Position_Id);
                                //更新用户当前SessionId到在线表中
                                //UpdateUserOnlineInfo(model.Id + "", OnlineUsersTable.SessionId, HttpContext.Current.Session.SessionID);

                                //当在线列表缓存不存在时，重新加载数据库记录到缓存中
                                if (HttpRuntime.Cache["OnlineUsers"] == null)
                                {
                                    Load();
                                }

                                //加载用户相关信息完毕，退出超时检查
                                return;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    //出现异常，保存出错日志信息
                    CommonBll.WriteLog("", e);
                }


                //用户不存在，直接退出
                FineUI.Alert.Show("当前用户登录已经过时或系统已更新,请重新登录！", "检测通知", MessageBoxIcon.Information, "top.location='Login.aspx'");
                //DotNet.Utilities.JsHelper.AlertAndParentUrl("当前用户登录已经过时或系统已更新,请重新登录！", "Login.aspx");
                HttpContext.Current.Response.End();
            }
        }
        #endregion

        #region 生成加密串——用户加密密钥计算
        /// <summary>
        /// 生成加密串——用户加密密钥计算
        /// </summary>
        /// <param name="model">在线实体</param>
        /// <returns></returns>
        public string GenerateMd5(DataAccess.Model.OnlineUsers model)
        {
            if (model == null)
            {
                return RandomHelper.GetRndKey();
            }
            else
            {
                //Md5(密钥+登陆帐号+密码+IP+密钥.Substring(6,8))
                return Encrypt.Md5(model.UserKey + model.Manager_LoginName + model.Manager_LoginPass +
                            IpHelper.GetUserIp() + model.UserKey.Substring(6, 8));
            }
        }

        /// <summary>
        /// 生成加密串——用户加密密钥计算，直接读取当前用户实体
        /// </summary>
        /// <returns></returns>
        public string GenerateMd5()
        {
            //获取用户Hashtable Key
            var userHashKey = GetUserHashKey();
            //读取当前用户实体
            var model = GetModelForCache(x => x.UserHashKey == userHashKey);
            return GenerateMd5(model);
        }
        #endregion

        #region 获取用户ID
        /// <summary>
        /// 从Session中读取用户ID,如果Session为Null时,返回0
        /// </summary>
        /// <returns></returns>
        public int GetManagerId()
        {
            return ConvertHelper.Cint0(GetUserOnlineInfo(OnlineUsersTable.Manager_Id));
        }
        #endregion

        #region 获取用户中文名称
        /// <summary>
        /// 从Session中读取用户中文名称,如果Session为Null时,返回""
        /// </summary>
        /// <returns></returns>
        public string GetManagerCName()
        {
            return GetUserOnlineInfo(OnlineUsersTable.Manager_CName) + "";
        }
        #endregion

        #region 获取用户UserHashKey
        /// <summary>
        /// 获取用户UserHashKey
        /// </summary>
        /// <returns></returns>
        public string GetUserHashKey()
        {
            //读取Session中存储的UserHashKey值
            var userHashKey = HttpContext.Current.Session[OnlineUsersTable.UserHashKey];
            //如果为null
            if (userHashKey == null)
            {
                //为null则表示用户Session过期了，所以要检查用户登陆，避免用户权限问题
                IsTimeOut();

                //从Cookies中读取
                userHashKey = CookieHelper.GetCookieValue(OnlineUsersTable.UserHashKey);
                //不为null时，重新存储到Session中
                if (userHashKey != null)
                {
                    HttpContext.Current.Session[OnlineUsersTable.UserHashKey] = userHashKey;
                }
            }
            return userHashKey + "";
        }
        #endregion

        #region 获取用户加密串——用户加密密钥Md5值
        /// <summary>
        /// 获取用户加密串——用户加密密钥Md5值
        /// </summary>
        /// <returns></returns>
        public string GetMd5()
        {
            //读取Session中存储的Md5值
            var md5 = HttpContext.Current.Session[OnlineUsersTable.Md5];
            //如果为null
            if (md5 == null)
            {
                //为null则表示用户Session过期了，所以要检查用户登陆，避免用户权限问题
                IsTimeOut();

                //从Cookies中读取
                md5 = CookieHelper.GetCookieValue(OnlineUsersTable.Md5);
                //不为null时，重新存储到Session中
                if (md5 != null)
                {
                    HttpContext.Current.Session[OnlineUsersTable.Md5] = md5;
                }
            }
            return md5 + "";
        }
        #endregion

        #region 获取用户页面操作权限
        /// <summary>
        /// 获取用户页面操作权限
        /// </summary>
        /// <returns></returns>
        public string GetPagePower()
        {
            //读取Session中存储的PagePower值
            var pagePower = HttpContext.Current.Session[PositionTable.PagePower];
            //如果为null
            if (pagePower == null)
            {
                //获取用户权限并存储到用户Session里
                PositionBll.GetInstence().SetUserPower(GetUserOnlineInfo(OnlineUsersTable.Position_Id) + "");
            }
            pagePower = HttpContext.Current.Session[PositionTable.PagePower];
            return pagePower + "";
        }
        #endregion

        #region 获取用户页面控件（按键）操作权限
        /// <summary>
        /// 获取用户页面控件（按键）操作权限
        /// </summary>
        /// <returns></returns>
        public string GetControlPower()
        {
            //读取Session中存储的ControlPower值
            var controlPower = HttpContext.Current.Session[PositionTable.ControlPower];
            //如果为null
            if (controlPower == null)
            {
                //获取用户权限并存储到用户Session里
                PositionBll.GetInstence().SetUserPower(GetUserOnlineInfo(OnlineUsersTable.Position_Id) + "");
            }
            controlPower = HttpContext.Current.Session[PositionTable.ControlPower];
            return controlPower + "";
        }
        #endregion

        #endregion 自定义函数
    }
}
