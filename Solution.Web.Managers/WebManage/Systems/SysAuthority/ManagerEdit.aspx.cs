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

namespace Solution.Web.Managers.WebManage.Systems.SysAuthority
{
   
     public partial class ManagerEdit : PageBase
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";

                SHOP00Bll.GetInstence().BandDropDownListShowShop1(this, SHOPdll);

                //绑定下拉列表 部门
                BranchBll.GetInstence().BandDropDownList(this, Brachddl);

                //绑定下拉列表 职位
                PositionBll.GetInstence().BandDropDownList(this, Positionddl);

               
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
                var model = ManagerBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                txtLoginName.Text = model.LoginName;
                txtPwd.Text = model.LoginPass;
                SHOPdll.SelectedValue = model.SHOP_ID + "";
                rblIsMultiUser.SelectedValue = model.IsMultiUser + "";
                rblIsWork.SelectedValue = model.IsWork + "";
                rblIsEnable.SelectedValue = model.IsEnable + "";

                txtCName.Text = model.CName;
                txtEName.Text = model.EName;
                rblSex.SelectedValue = model.Sex + "";

                Brachddl.SelectedValue = model.Branch_Id.ToString();
                Positionddl.SelectedValue = model.Position_Id;

                Birthday.SelectedDate = DateTime.Parse(model.Birthday == "" ? DateTime.Now.ToString() : model.Birthday);

                txtNativePlace.Text = model.NativePlace;
                txtNationalName.Text = model.NationalName;
                txtRecord.Text = model.Record;
                txtGraduateCollege.Text = model.GraduateCollege;
                txtGraduateSpecialty.Text = model.GraduateSpecialty;
                txtTel.Text = model.Tel;
                txtMobile.Text = model.Tel;
                txtEmail.Text = model.Email;
                txtQq.Text = model.Qq;
                txtAddress.Text = model.Address;
                txtContent.Text = model.Content;



                     
            }
        }

        #endregion

        #region 页面控件绑定
        /// <summary>下拉列表改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Brachddl_SelectedIndexChanged(object sender, EventArgs e)
        {
             
            if (!Brachddl.SelectedValue.Equals("1"))
            {
                try
                {

                    Positionddl.Text = PositionBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(Brachddl.SelectedValue), PositionTable.Branch_Id) + "";
                   
                }
                catch
                {
                }
            }
        }
        #endregion


        #region 页面控件绑定
        /// <summary>下拉列表改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Positionddl_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!Positionddl.SelectedValue.Equals("1"))
            {
                try
                {

                    Brachddl.Text = PositionBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(Positionddl.SelectedValue), PositionTable.Branch_Id) + "";

                }
                catch
                {
                }
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

                if (string.IsNullOrEmpty(txtLoginName.Text.Trim()))
                {
                    return txtLoginName.Label + "不能为空！";
                }

                if (SHOPdll.SelectedText.Trim() == "请选择分店")
                {
                    return SHOPdll.Label + "不能为空！";
                }

                var sName = StringHelper.Left(txtLoginName.Text, 50);
                if (ManagerBll.GetInstence().Exist(x => x.LoginName == sName && x.Id != id))
                {
                    return txtLoginName.Label + "已存在！请重新输入！";
                }
               
                 if (string.IsNullOrEmpty(txtPwd.Text.Trim()))
                {
                    return txtPwd.Label + "不能为空！";
                }

               
                #endregion

                #region 赋值
                //读取指定部门资料
                var model = new Manager(x => x.Id == id);

                model.LoginName =  txtLoginName.Text;
                model.LoginPass = model.LoginPass == txtPwd.Text.Trim()?model.LoginPass: Encrypt.Md5(Encrypt.Md5(txtPwd.Text));//:model.LoginPass;  model.LoginPass == null?
                model.LoginTime = DateTime.Now;
                model.LoginIp = "1::";
                model.LoginCount = 1;
                model.CreateTime = DateTime.Now;
                model.UpdateTime = DateTime.Now;

                int branch_id = ConvertHelper.Cint0(Brachddl.SelectedValue);

                var model_b = BranchBll.GetInstence().GetModelForCache(x => x.Id == branch_id);

                model.Branch_Id = model_b.Id;
                model.Branch_Code = model_b.Code;
                model.Branch_Name = model_b.Name;

                model.IsMultiUser = ConvertHelper.StringToByte(rblIsMultiUser.SelectedValue.ToString());
                model.IsWork = ConvertHelper.StringToByte(rblIsWork.SelectedValue);
                model.IsEnable = ConvertHelper.StringToByte(rblIsEnable.SelectedValue);

                var model_p = PositionBll.GetInstence().GetModelForCache(x => x.Id == ConvertHelper.Cint0(Positionddl.SelectedValue));

                model.Position_Id = model_p.Id.ToString();
                model.Position_Name = model_p.Name;
                 

                model.CName = txtCName.Text;
                model.EName = txtEName.Text;
                model.Sex = rblSex.SelectedValue.ToString();
                model.PhotoImg = "";
                model.Birthday = Birthday.SelectedDate.ToString();

                model.NativePlace = txtNativePlace.Text;
                model.NationalName = txtNationalName.Text;
                model.Record = txtRecord.Text;
                model.GraduateCollege = txtGraduateCollege.Text;
                model.GraduateSpecialty = txtGraduateSpecialty.Text;
                model.Tel = txtTel.Text;
                model.Tel = txtMobile.Text;
                model.Email = txtEmail.Text;
                model.Qq = txtQq.Text;
                model.Msn = "";
                model.Address = txtAddress.Text;
                model.Content = txtContent.Text;
                model.Manager_Id = OnlineUsersBll.GetInstence().GetManagerId();
                model.Manager_CName = OnlineUsersBll.GetInstence().GetManagerCName();

                model.SHOP_ID = SHOPdll.SelectedValue;
                model.SHOP_NAME1 = SHOPdll.SelectedText;

                #endregion

                //----------------------------------------------------------
                //存储到数据库
                ManagerBll.GetInstence().Save(this, model);

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