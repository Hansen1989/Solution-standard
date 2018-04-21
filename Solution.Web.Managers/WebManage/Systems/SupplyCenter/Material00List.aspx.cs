using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using SubSonic.Query;
using Newtonsoft.Json.Linq;

namespace Solution.Web.Managers.WebManage.Systems.SupplyCenter
{
    public partial class Material00List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void LoadData()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {
            bll = Material00Bll.GetInstence();
            //throw new NotImplementedException();
        }

        public override void Add()
        {

        }


        public void LoadIN00()
        {
            string _tbxMA_ID = tbxMA_ID.Text;
            if (!String.IsNullOrEmpty(_tbxMA_ID))
            {
                var model = new Material00(x => x.MA_ID == _tbxMA_ID);
                ddlSHOP_NAME.SelectedValue = model.SHOP_ID;
                dpINPUT_DATE.SelectedDate = model.INPUT_DATE;
                ddlStatus.SelectedValue = model.STATUS.ToString();
                ddlDIV_ID.SelectedValue = model.DIV_ID.ToString();
                ddlMAT_TYPE.SelectedValue = model.MAT_TYPE.ToString();
                ddlSTOCK_ID.SelectedValue = model.STOCK_ID;
                tbxUSER_ID.Text = model.USER_ID;
                tbxAPP_USER.Text = model.APP_USER;
                dpAPP_DATETIME.Text = model.APP_DATETIME.ToString();
                tbxRELATE_ID.Text = model.RELATE_ID.ToString();
                cbLOCKED.Checked = model.LOCKED == '0' ? false : true;

                tbxMemo.Text = model.Memo;
                tbxCRT_DATETIME.Text = model.CRT_DATETIME.ToString();
                tbxCRT_USER_ID.Text = model.CRT_USER_ID;
                tbxMOD_DATETIME.Text = model.MOD_DATETIME.ToString();
                tbxMOD_USER_ID.Text = model.MOD_USER_ID;
                tbxLAST_UPDATE.Text = model.LAST_UPDATE.ToString();
                IN00Status(model.STATUS);
            }
        }
        /// <summary>
        /// 状态位的判定
        /// </summary>
        /// <param name="status"></param>
        public void IN00Status(int status)
        {
            //1:存档 2：核准 3：作废 4：已引入
            //新增：ButtonAdd 保存：ButtonSave 更新：ButtonUpdate 核准：ButtonCheck 作废：ButtonCancel
            //Pur02新增：ButtonPur02Add
            switch (status)
            {
                case 1:
                    //ButtonSave.Enabled = false;
                    //ButtonUpdate.Enabled = true;
                    ButtonCancel.Enabled = true;
                    ButtonCheck.Enabled = true;
                    ButtonCheck.Text = "核准";
                    ButtonCancel.Text = "作废";
                    ButtonPur02Add.Enabled = true;
                    Grid2.Enabled = true;
                    Grid2.AllowCellEditing = true; break;
                case 2:
                    //ButtonSave.Enabled = false;
                    //ButtonUpdate.Enabled = false;
                    ButtonCheck.Text = "反核准";
                    ButtonCancel.Text = "作废";
                    ButtonCancel.Enabled = false;
                    ButtonCheck.Enabled = true;
                    ButtonPur02Add.Enabled = false;
                    Grid2.Enabled = false; break;
                case 3:
                    //ButtonSave.Enabled = false;
                    //ButtonUpdate.Enabled = false;
                    ButtonCheck.Text = "核准";
                    ButtonCheck.Enabled = false;
                    ButtonCancel.Text = "取消作废";
                    ButtonCheck.Enabled = true;
                    Grid2.Enabled = false;
                    Grid2.AllowCellEditing = false; break;
                case 4:
                    //ButtonSave.Enabled = false;
                    //ButtonUpdate.Enabled = false;
                    ButtonCheck.Text = "反核准";
                    ButtonCancel.Text = "作废";
                    ButtonCancel.Enabled = false;
                    ButtonCheck.Enabled = false;
                    ButtonPur02Add.Enabled = false;
                    Grid2.Enabled = false;
                    Grid2.AllowCellEditing = false; break;
                default:
                    //ButtonSave.Enabled = false;
                    //ButtonUpdate.Enabled = false;
                    ButtonCheck.Text = "核准";
                    ButtonCancel.Text = "作废";
                    ButtonCancel.Enabled = false;
                    ButtonCheck.Enabled = false;
                    ButtonPur02Add.Enabled = false;
                    Grid2.AllowCellEditing = true; break;
            }
        }


        /// <summary>
        /// 主表保存
        /// </summary>
        /// <returns></returns>
        public string TAKEN10Edit()
        {
            string _tbxMA_ID = tbxMA_ID.Text;
            try
            {
                var model = new Material00(x => x.MA_ID == _tbxMA_ID);
                var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
                if (String.IsNullOrEmpty(_tbxMA_ID))
                {
                    model.SetIsNew(true);
                    model.CRT_DATETIME = DateTime.Now;
                    model.CRT_USER_ID = OlUser.Manager_LoginName;
                }
                model.SHOP_ID = ddlSHOP_NAME.SelectedValue;
                model.MA_ID = tbxMA_ID.Text;
                model.INPUT_DATE = ConvertHelper.StringToDatetime(dpINPUT_DATE.SelectedDate.ToString());
                model.STATUS = ConvertHelper.Cint(ddlStatus.SelectedValue);
                model.DIV_ID = ddlDIV_ID.SelectedValue;
                model.STOCK_ID = ddlSTOCK_ID.SelectedValue;
                model.USER_ID = tbxUSER_ID.ToString();
                model.APP_USER = OlUser.Manager_LoginName;
                model.APP_DATETIME = ConvertHelper.StringToDatetime(dpAPP_DATETIME.Text);
                model.RELATE_ID = tbxRELATE_ID.Text;
                model.LOCKED = ConvertHelper.StringToByte(cbLOCKED.Checked ? "1" : "0");
                model.MOD_DATETIME = DateTime.Now;
                model.MOD_USER_ID = OlUser.Manager_LoginName;
                model.LAST_UPDATE = DateTime.Now;
                model.Trans_STATUS = 0;
                Material00Bll.GetInstence().Save(this, model);
            }
            catch (Exception err)
            {
                return err.Message;
            }
            return "";
        }

        /// <summary>
        /// 子表保存
        /// </summary>
        /// <returns></returns>
        public string OUT01Edit()
        {
            JArray jarr = Grid2.GetMergedData();
            var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
            string result = "";
            int n = 0;
            for (int i = 0; i < jarr.Count; i++)
            {
                try
                {
                    var model2 = new Material01();
                    if (jarr[i]["status"].ToString().Equals("modified"))
                    {
                        model2.SetIsNew(false);
                    }
                    else
                    {
                        model2.SetIsNew(true);
                    }
                    model2.Id = ConvertHelper.Cint(jarr[i]["values"]["ID01"].ToString());
                    model2.SHOP_ID = jarr[i]["values"]["SHOP_ID01"].ToString();
                    model2.MA_ID = jarr[i]["values"]["MA_ID01"].ToString();
                    model2.SNo = ConvertHelper.Cint(jarr[i]["values"]["SNo01"].ToString());
                    model2.PROD_ID = jarr[i]["values"]["PROD_ID01"].ToString();
                    model2.QUANTITY = ConvertHelper.StringToDecimal(jarr[i]["values"]["QUANTITY01"].ToString());
                    model2.STD_UNIT = jarr[i]["values"]["STD_UNIT01"].ToString();
                    model2.STD_CONVERT = ConvertHelper.Cint(jarr[i]["values"]["STD_CONVERT01"].ToString());
                    model2.STD_QUAN = ConvertHelper.StringToDecimal(jarr[i]["values"]["STD_QUAN01"].ToString());
                    model2.STD_PRICE = ConvertHelper.StringToDecimal(jarr[i]["values"]["STD_PRICE01"].ToString());
                    model2.COST = ConvertHelper.StringToDecimal(jarr[i]["values"]["COST01"].ToString());
                    model2.MEMO = jarr[i]["values"]["MEMO01"].ToString();
                    model2.BAT_NO = jarr[i]["values"]["BAT_NO01"].ToString();
                    model2.Exp_DateTime = ConvertHelper.StringToDatetime(jarr[i]["values"]["Exp_DateTime01"].ToString());
                    Material01Bll.GetInstence().Save(this, model2);
                }
                catch (Exception err)
                {
                    n++;
                    result = "明细保存失败" + n + "条";
                }
            }
            return result;
        }
    }
}