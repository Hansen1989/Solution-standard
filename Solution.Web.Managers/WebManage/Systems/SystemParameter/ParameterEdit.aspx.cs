﻿using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solution.Web.Managers.WebManage.Systems.SystemParameter
{

    public partial class ParameterEdit : PageBase
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";

                //绑定下拉列表
                GROUPAREABll.GetInstence().BandDropDownList(this, ddlAREA);
               
                 
                //加载数据
                LoadData();
            }
        }
        #endregion

        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        public override void Init()
        {

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
                //获取指定ID的菜单内容，如果不存在，则创建一个菜单实体
                
                var model = PARAMETERBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                ddlAREA.SelectedValue = model.Area_Id + "";
                txt_key.Text = model.KEY;
                value_droplist.SelectedValue = model.VALUE;
                key_cn.Text = model.KEY_CN;
                txt_memo.Text = model.MEMO;


            }
        }

        #endregion

        
        #region 保存
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <returns></returns>
        public override string Save()
        {
            string result = string.Empty;
            int id = ConvertHelper.Cint0(hidId.Text);

            try
            {
                #region 数据验证
                
                if (ddlAREA.SelectedValue.Trim() == "0")
                {
                    return ddlAREA.Label + "不能为空！";
                }

                #endregion

                #region 赋值
                //读取指定部门资料
                
                var model = new PARAMETER(x => x.Id == id);

                model.Area_Id = ddlAREA.SelectedValue + "";

                model.KEY = txt_key.Text;
                model.VALUE = value_droplist.SelectedValue;
                model.KEY_CN = key_cn.Text;
                model.MEMO = txt_memo.Text;
                //model.CRT_DATETIME = DateTime.Now;
                //model.CRT_USER_ID = "";
                //model.MOD_DATETIME = DateTime.Now;
                //model.MOD_USER_ID = "";
                //model.LAST_UPDATE = DateTime.Now;
                //model.MEMO = "";

                #endregion

                //----------------------------------------------------------
                //存储到数据库
                PARAMETERBll.GetInstence().Save(this, model);
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