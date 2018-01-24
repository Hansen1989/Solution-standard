using System;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;

/***********************************************************************
 *   作    者：AllEmpty（陈焕）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 术 群：327360708
 *  
 *   创建日期：2014-06-17
 *   文件名称：LoginLogBll.cs
 *   描    述：用户登陆日志逻辑类
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Logic.Managers
{
    /// <summary>
    /// LoginLog（用户登陆日志）逻辑类
    /// </summary>
    public partial class LoginLogBll : LogicBase
    {

        /***********************************************************************
         * 自定义函数                                                          *
         ***********************************************************************/
        #region 自定义函数

        #region 添加用户登陆日志
        /// <summary>
        /// 添加用户登陆日志
        /// </summary>
        /// <param name="userHashKey">登录用户在线列表的HashTable Key</param>
        /// <param name="notes">用户登录内容备注，{0}=用户名称，{1}=用户在线时间</param>
        public void Save(string userHashKey, string notes)
        {
            try
            {
                //创建登录日志对象，便于登录日志的添加
                var loginlog = new LoginLog();
                //记录登录时间
                loginlog.AddDate = DateTime.Now;
                //当前用户ID
                loginlog.Manager_Id = ConvertHelper.Cint0(OnlineUsersBll.GetInstence().GetUserOnlineInfo(userHashKey, OnlineUsersTable.Manager_Id));

                //当前用户名称
                loginlog.Manager_CName = OnlineUsersBll.GetInstence().GetUserOnlineInfo(userHashKey, OnlineUsersTable.Manager_CName) + "";
                //当前用户IP
                loginlog.Ip = OnlineUsersBll.GetInstence().GetUserOnlineInfo(userHashKey, OnlineUsersTable.LoginIp) + "";
                //日志记录说明
                loginlog.Notes = String.Format(notes, loginlog.Manager_CName, CommonBll.LoginDuration(OnlineUsersBll.GetInstence().GetUserOnlineInfo(userHashKey, OnlineUsersTable.LoginTime)));

                loginlog.Save();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 添加用户登陆日志
        /// </summary>
        /// <param name="managerId">登录用户ID</param>
        /// <param name="notes">用户登录内容备注</param>
        public void Save(int managerId, string notes)
        {
            try
            {
                //创建登录日志对象，便于登录日志的添加
                var loginlog = new LoginLog();
                //记录登录时间
                loginlog.AddDate = DateTime.Now;
                //当前用户ID
                loginlog.Manager_Id = managerId;

                //当前用户名称
                loginlog.Manager_CName = ManagerBll.GetInstence().GetCName(null, managerId);
                //当前用户IP
                loginlog.Ip = IpHelper.GetUserIp();
                //日志记录说明
                loginlog.Notes = notes;

                loginlog.Save();
            }
            catch (Exception) { }
        }
        #endregion

        #region 管理员退出系统
        /// <summary>
        /// 用户点击退出系统时，调用本函数，本函数将在在线用户表中删除当前用户，并添加用户退出日志
        /// </summary>
        public void UserExit()
        {
            try
            {
                //获取用户Hashtable Key
                var userHashKey = OnlineUsersBll.GetInstence().GetUserHashKey();
                //判断用户的Session["UserHashKey"]是否存在，即用户是否TimeOut退出了
                if (userHashKey != null)
                {
                    //添加用户退出日志
                    Save(userHashKey + "", "用户【{0}】退出系统！在线时间【{1}】");

                    //删除数据库记录与IIS缓存
                    OnlineUsersBll.GetInstence().Delete(null, OnlineUsersBll.GetInstence().GetManagerId());
                    //清除在线缓存Hashtable记录
                    OnlineUsersBll.GetInstence().RemoveUser(userHashKey + "");
                    //清空Session
                    SessionHelper.RemoveSession(PositionTable.PagePower);
                    SessionHelper.RemoveSession(PositionTable.ControlPower);
                    //删除Cookies
                    CookieHelper.ClearCookie(OnlineUsersTable.UserHashKey);
                    CookieHelper.ClearCookie(OnlineUsersTable.Md5);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 将指定用户踢下线，并添加用户退出日志
        /// </summary>
        public void UserExit(string userHashKey)
        {
            //添加用户退出日志
            Save(userHashKey, "用户【{0}】给管理员【" + OnlineUsersBll.GetInstence().GetManagerCName() + "】踢出系统！在线时间【{1}】");

            //删除数据库记录与IIS缓存
            OnlineUsersBll.GetInstence().Delete(null, ConvertHelper.Cint0(OnlineUsersBll.GetInstence().GetUserOnlineInfo(userHashKey, OnlineUsersTable.Manager_Id)));
            //清除在线缓存Hashtable记录
            OnlineUsersBll.GetInstence().RemoveUser(userHashKey + "");
        }

        #endregion

        #endregion 自定义函数

    }
}
