using DotNet.Utilities;
using DotNet.Utilities.Constants;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using Solution.DataAccess.Model.EnumObject;
using Solution.DataAccess.Model.ObjectEntity;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using SubSonic.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solution.Web.Managers.WebManage.Systems.SettlementCenter
{
    public partial class SettlementCenterPay : PageBase
    {
        /// <summary>
        /// 当前分店编号
        /// </summary>
        private string shopId;

        /// <summary>
        ///  供应商名称缓存
        /// </summary>
        private Dictionary<string, string> supDic = new Dictionary<string, string>();

        /// <summary>
        /// 当前登录用户
        /// </summary>
        private string userId;

        /// <summary>
        /// 
        /// </summary>
        private UpdateHelper updaterHelper = new UpdateHelper();

        /// <summary>
        /// 
        /// </summary>
        private SelectHelper selectHelper = new SelectHelper();

        /// <summary>
        /// 供应商列表
        /// </summary>
        private List<SHOP_SUPPLIER_RELATION> supList;

        /// <summary>
        /// 上次结余
        /// </summary>
        private decimal billLastLeftAmount = 0;

        /// <summary>
        /// 本次账单金额
        /// </summary>
        private decimal thisTimeBillAmount = 0;

        /// <summary>
        /// 登陆的店铺类型
        /// </summary>
        private ShopKind shopKind;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        public override void LoadData()
        {            
            switch (shopKind)
            {
                case ShopKind.Area:
                    LoadAread();
                    break;
                case ShopKind.DirectStore:
                case ShopKind.Franchisee:
                    LoadShopData();
                    break;
            }            
        }

        /// <summary>
        /// 加载区域中心的数据
        /// </summary>
        private void LoadAread()
        {
            int status = 0;
            if (billStatus.SelectedIndex > 0)
            {
                status = Convert.ToInt32(billStatus.SelectedValue);
            }

            List<ConditionFun.SqlqueryCondition> conditionList = new List<ConditionFun.SqlqueryCondition>();
            //分店编号
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "SHOP_ID", Comparison.Equals, shopId));

            //应付账单状态
            if (status > 0)
            {
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, "STATUS", Comparison.Equals, status));
            }

            //供应商
            if (supDropdown.SelectedIndex >= 0)
            {
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, "SUP_ID", Comparison.Equals, supDropdown.SelectedValue));
            }

            //进货单单号
            if (inId.Text.Trim().Length > 0)
            {
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, "TAKEIN_ID", Comparison.Like, inId.Text.Trim() + "%"));
            }

            //绑定查询
            DUE00Bll.GetInstence().BindGrid(resultGrid, 0, 2000, conditionList);
        }

        /// <summary>
        /// 加载店铺的数据
        /// </summary>
        private void LoadShopData()
        {

        }


        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        public override void Init()
        {
            var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());

            //获取用户所属shop
            shopId = OlUser.SHOP_ID;

            var shop = new SHOP00(x => x.SHOP_ID == shopId);
            shopKind = (ShopKind)shop.SHOP_KIND;
            switch (shopKind)
            {
                case ShopKind.Area:
                    InitArea();
                    break;
                case ShopKind.DirectStore:
                case ShopKind.Franchisee:
                    InitShop();
                    break;
            }

        }
        #endregion


        /// <summary>
        /// 门店初始化
        /// </summary>
        private void InitShop()
        {
            areaPanel.Hidden = true;
            directStorePanel.Hidden = false;
        }

        /// <summary>
        /// 区域中心初始化
        /// </summary>
        private void InitArea()
        {
            areaPanel.Hidden = false;
            directStorePanel.Hidden = true;
            List<ConditionFun.SqlqueryCondition> wheres = new List<ConditionFun.SqlqueryCondition>();
            wheres.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "SHOP_ID", Comparison.Equals, shopId, false, false));

            supList = selectHelper.Select<SHOP_SUPPLIER_RELATION>(false, 0, null, wheres).ExecuteTypedList<SHOP_SUPPLIER_RELATION>();

            if (supList != null && supList.Count > 0)
            {
                foreach (SHOP_SUPPLIER_RELATION ssr in supList)
                {
                    supDic[ssr.SUP_ID] = ssr.SUP_NAME;
                }
            }

            supDropdown.DataTextField = "SUP_NAME";
            supDropdown.DataValueField = "SUP_ID";
            supDropdown.DataSource = supList;
            supDropdown.DataBind();


            //初始化汇整日期
            DatePicker outStartDate = archiveWindow.FindControl("archiveDatePanel").FindControl("inStartDate") as DatePicker;
            outStartDate.SelectedDate = ConvertHelper.StringToDatetime(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd 00:00:00"));

            DatePicker outEndDate = archiveWindow.FindControl("archiveDatePanel").FindControl("inEndDate") as DatePicker;
            outEndDate.SelectedDate = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
        }

        /// <summary>
        /// 汇整进货单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ArchiveButton_Click(object sender, EventArgs e)
        {
            DatePicker dpStart = archiveWindow.FindControl("archiveDatePanel").FindControl("inStartDate") as DatePicker;
            DatePicker dpEnd = archiveWindow.FindControl("archiveDatePanel").FindControl("inEndDate") as DatePicker;

            //1.查询总部进货表TAKEIN10
            // 1)进货单状态为 2=核准
            // 2)进货单类型为一般进货 TAKEIN_TYPE=1
            // 3)SHOP_ID = 当前登录用户的总部编号
            // 4)在指定日期范围内
            //2.遍历结果
            //3.更新出货单状态为5=月结(关单)， 并且锁定出货单(LOCKED=1)
            //4.更新成功后查询出货单明细更新到应收明细表
            //5.保存应收主信息

            List<ConditionFun.SqlqueryCondition> wheres = QueryTakeinListCondition(shopId, dpStart.Text, dpEnd.Text);


            List<TAKEIN10> inList = selectHelper.Select<TAKEIN10>(false, 0, null, 1, 2000, wheres).ExecuteTypedList<TAKEIN10>();
            if (inList == null || inList.Count == 0)
            {
                Alert.Show("选定时间段未查询到数据!");
                return;
            }

            List<DueMain> payList = new List<DueMain>();
            
            //遍历进货单
            foreach (TAKEIN10 row in inList)
            {
                try
                {
                    //更新进货单
                    //int retValue = updaterHelper.Update(string.Format("update TAKEIN10 set STATUS = 5, LOCKED = 1 where Id = {0}", row.Id));
                    //更新成功 则汇整进入总店应付账单表

                    List<ConditionFun.SqlqueryCondition> conditions = new List<ConditionFun.SqlqueryCondition>();
                    conditions.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "SHOP_ID", Comparison.Equals, row.SHOP_ID, false, false));
                    conditions.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, "TAKEIN_ID", Comparison.Equals, row.TAKEIN_ID, false, false));
                    //查询进货单明细
                    List<TAKEIN11> itemList = selectHelper.Select<TAKEIN11>(false, 0, null, conditions).ExecuteTypedList<TAKEIN11>();
                    if (itemList == null || itemList.Count == 0)
                    {
                        CommonBll.WriteLog(string.Format("进货单{0}未查询到明细", row.TAKEIN_ID), null);
                        continue;
                    }

                    //采购总金额
                    decimal amount = 0;
                    //税额
                    decimal tax = 0;
                    //
                    foreach (TAKEIN11 item in itemList)
                    {
                        DUE01 payItem = new DUE01();
                        //批次号
                        payItem.BAT_NO = item.BAT_NO;
                        //采购金额
                        payItem.COST = item.STD_PRICE * item.STD_QUAN;

                        //税额
                        payItem.TAX = item.Tax;

                        //采购金额
                        amount += payItem.COST;
                        tax += payItem.TAX;
                    }

                    DueMain payMain = new DueMain();

                    payMain.Id = row.Id;

                    //进货单审核日期
                    payMain.APP_DATETIME = row.APP_DATETIME;
                    //进货单审核人
                    payMain.APP_USER = row.APP_USER;
                    //应付账单创建日期
                    payMain.CRT_DATETIME = DateTime.Now;
                    //应付账单创建人
                    payMain.CRT_USER_ID = userId;
                    //进货单日期
                    payMain.INPUT_DATE = row.INPUT_DATE;
                    //发票
                    payMain.INVOICE_ID = row.INVOICE_ID;
                    //应付账单最后修改日期
                    payMain.LAST_UPDATE = DateTime.Now;
                    //备注
                    payMain.Memo = row.Memo;
                    //更新时间
                    payMain.MOD_DATETIME = DateTime.Now;
                    //修改人
                    payMain.MOD_USER_ID = userId;
                    //预付款
                    payMain.PRE_PAY = row.PRE_PAY;
                    //预付款单号
                    payMain.PRE_PAY_ID = row.PRE_PAY_ID;
                    //关联ID
                    payMain.RELATE_ID = row.RELATE_ID;
                    //进货分店编号
                    payMain.SHOP_ID = row.SHOP_ID;
                    //待核准状态
                    payMain.STATUS = 1;
                    //供应商编号
                    payMain.SUP_ID = row.SUP_ID;
                    //进货单号
                    payMain.TAKEIN_ID = row.TAKEIN_ID;
                    //进货类型
                    payMain.TAKEIN_TYPE = 1; //一般进货
                                             //进货单金额
                    payMain.TOT_AMOUNT = amount;
                    //进货单数量
                    payMain.TOT_QTY = row.TOT_QTY;
                    //税额
                    payMain.TOT_TAX = tax;
                    payMain.USER_ID = userId;

                    //保存主信息
                    //payMain.Save();
                    payList.Add(payMain);

                    //供应商关系已经存在
                    if (supDic.ContainsKey(payMain.SUP_ID))
                    {
                        continue;
                    }
                    try
                    {
                        //查询供应商
                        var sup = selectHelper.SelectSingle<SUPPLIERS>(false, null,
                            new List<ConditionFun.SqlqueryCondition>() { new ConditionFun.SqlqueryCondition(ConstraintType.Where, "SUP_ID", Comparison.Equals, payMain.SUP_ID) });
                        if (sup != null)
                        {
                            //缓存供应商
                            supDic[sup.SUP_ID] = sup.SUP_NAME;
                            //分店和供应商关系
                            SHOP_SUPPLIER_RELATION relation = new SHOP_SUPPLIER_RELATION();
                            relation.CRT_DATETIME = DateTime.Now;
                            relation.MEMO = "来源汇整进货单";
                            relation.SHOP_ID = payMain.SHOP_ID;
                            relation.SUP_ID = sup.SUP_ID;
                            relation.SUP_NAME = sup.SUP_NAME;

                            //保存关联关系
                            relation.Save();

                            //
                            supList.Add(relation);

                            supDropdown.DataBind();
                        }
                    }
                    catch (Exception ex)
                    {
                        CommonBll.WriteLog("查询供应商出错", ex);
                    }
                    //

                }
                catch (Exception ex)
                {
                    CommonBll.WriteLog(string.Format("汇整进货单{0}发生异常", row.TAKEIN_ID), ex);
                }
            }

            Grid previewGrid = archivePreviewWindow.FindControl("previewDataPanel").FindControl("previewDataGrid") as Grid;
            previewGrid.DataSource = payList;
            previewGrid.DataBind();

            archivePreviewWindow.Hidden = false;
        }


        /// <summary>
        /// 拼接出货单查询条件
        /// </summary>
        /// <returns></returns>
        private List<ConditionFun.SqlqueryCondition> QueryTakeinListCondition(string shopId, string startTime, string endTime)
        {
            List<ConditionFun.SqlqueryCondition> conditionList = new List<ConditionFun.SqlqueryCondition>();
            //查询总店的所有进货单
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, TAKEIN10Table.SHOP_ID, Comparison.Equals, shopId, false, false));
            //进货单时间
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, TAKEIN10Table.INPUT_DATE, Comparison.GreaterOrEquals, startTime, false, false));
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, TAKEIN10Table.INPUT_DATE, Comparison.LessOrEquals, endTime, false, false));
            //进货单状态为2=核准
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, TAKEIN10Table.STATUS, Comparison.Equals, 2, false, false));
            //进货单类型 1=一般进货
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, TAKEIN10Table.TAKEIN_TYPE, Comparison.Equals, 1, false, false));
                
            return conditionList;
        }
              

        /// <summary>
        /// 显示行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void resultGrid_PreRowDataBound(object sender, GridPreRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;
            FineUI.BoundField supName = resultGrid.FindColumn("SUP_NAME") as FineUI.BoundField;
            supName.NullDisplayText = supDic[row["SUP_ID"].ToString()];
                        
            FineUI.BoundField status = resultGrid.FindColumn("STATUS_DESC") as FineUI.BoundField;
            switch (row["STATUS"].ToString())
            {
                case "1":
                    status.NullDisplayText = "存档";
                    break;
                case "2":
                    status.NullDisplayText = "核准";
                    break;
                case "3":
                    status.NullDisplayText = "作废";
                    break;
                case "4":
                    break;
                case "5":
                    status.NullDisplayText = "月结(关单)";
                    break;
            }
        }

        /// <summary>
        /// 核准
        /// </summary>
        public override void Approval()
        {
            GridRow row = resultGrid.SelectedRow;
            if (row == null)
            {
                Alert.Show("请选择需要核准的应付账单");
                return;
            }
            try
            {
                int Id = Convert.ToInt32(row.DataKeys[0].ToString());
                DUE00 due00 = selectHelper.SelectSingle<DUE00>(false, null, new List<ConditionFun.SqlqueryCondition>() { new ConditionFun.SqlqueryCondition(ConstraintType.Where, "Id", Comparison.Equals, Id, false, false) });
                if(due00 != null)
                {
                    if(due00.STATUS != SubsonicConstants.STATUS_NEW)
                    {
                        Alert.Show(string.Format("应付账单[{0}]不是存档状态无法核准"));
                        return;
                    }
                    var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());

                    int ret = updaterHelper.Update(string.Format("update DUE00 set status = 2  where status = 1 and id = {0}", Id));
                    if(ret == 1)
                    {
                        Alert.Show(string.Format("核准[{0}]成功", row.DataKeys[2].ToString()));
                    }else
                    {
                        Alert.Show(string.Format("核准[{0}]失败", row.DataKeys[2].ToString()));
                    }
                    //加载页面
                    LoadData();
                }
                else
                {
                    Alert.Show(string.Format("核准失败，未查询到应付账单[{0}]", row.DataKeys[1].ToString()));
                }
            }catch(Exception e)
            {
                CommonBll.WriteLog("核准应付账单发生错误", e);
                Alert.Show("核准失败,核准发生异常，详情请见日志");
            }
        }        

        /// <summary>
        /// 弹出汇整界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonArchiveOrders_Click(object sender, EventArgs e)
        {
            archiveWindow.Hidden = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSettlement_Click(object sender, EventArgs e)
        { 
            
            if(supDropdown.SelectedIndex < 0)
            {
                Alert.Show("请选择供应商");
                return;
            }

            //供应商ID
            string supId = supDropdown.SelectedValue;

            //设置供应商显示
            supName.Text = supDic[supId];

            List<ConditionFun.SqlqueryCondition> wheres = new List<ConditionFun.SqlqueryCondition>();
            //查询当前用户所属的分店编号
            wheres.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "SHOP_ID", Comparison.Equals, shopId, false, false));
            //查询已核准为支付的订单
            wheres.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, "STATUS", Comparison.Equals, "2", false, false));
            //供应商
            wheres.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, "SUP_ID", Comparison.Equals, supId, false, false));

            
            //查询未付账单的第一条数据
            List<DUE00> dueList = selectHelper.Select<DUE00>(false, 1, null, wheres, new List<string>() { "INPUT_DATE ASC" }).ExecuteTypedList<DUE00>();
            if(dueList == null || dueList.Count == 0)
            {
                Alert.Show("未查询到应付账单");
                return;
            }
            billDateStart.Text = dueList[0].INPUT_DATE.ToString("yyyy年MM月dd日");

            //查询最后一条应付账单
            dueList = selectHelper.Select<DUE00>(false, 1, null, wheres, new List<string>() { "INPUT_DATE DESC" }).ExecuteTypedList<DUE00>();
            billDateEnd.Text = dueList[0].INPUT_DATE.ToString("yyyy年MM月dd日");

            //应付总额
            decimal totalAmount = (decimal)selectHelper.ExecuteScalar(string.Format("select ISNULL(sum(TOT_AMOUNT),0) from DUE00 where SHOP_ID = '{0}' and SUP_ID = '{1}' and STATUS = 2", shopId, supId));            
            payTotal.Text = totalAmount.ToString();

            //总应付账单数
            int totalBills = (int)selectHelper.ExecuteScalar(string.Format("select count(1) from DUE00 where SHOP_ID = '{0}' and SUP_ID = '{1}' and STATUS = 2", shopId, supId));
            billNums.Text = totalBills.ToString();

            decimal lastLeftAmount = (decimal)selectHelper.ExecuteScalar(string.Format("select ISNULL(sum(AMOUNT),0) from HEAD_SHOP_ACCOUNT where SHOP_ID = '{0}' and SUP_ID = '{1}'", shopId, supId));

            //上次结余
            lastLeft.Text = lastLeftAmount.ToString();
            payLastLeft.Text = lastLeftAmount.ToString();
            billLastLeftAmount = lastLeftAmount;

            thisTimeBillAmount = totalAmount;


            //显示核对信息
            confirmPayWindow.Hidden = false;
        }

        /// <summary>
        /// 弹出付款界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonPay_Click(object sender, EventArgs e)
        {
            payWindow.Hidden = false;
            //上次剩余
            payLastLeft.Text = billLastLeftAmount.ToString();
            //本次应付
            payTotalThisTime.Text = thisTimeBillAmount.ToString();
            
        }

        /// <summary>
        /// 结账
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonCloseBill_Click(object sender, EventArgs e)
        {
            if(payMoney.Text.Trim().Length == 0)
            {
                Alert.Show("请输入付款金额");
                return;
            }
            decimal money = 0;
            try
            {
                money = Convert.ToDecimal(payMoney.Text);
            }
            catch(Exception ex)
            {
                CommonBll.WriteLog("付款金额不正确", ex);
                Alert.Show("付款金额不正确");
                return;
            }

            //更新数据库中未结账的记录
            Confirm.Show("确认结账", "", MessageBoxIcon.Question);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Preview_Ok_Click(object sender, EventArgs e)
        {
            //获取登录用户
            var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());

            //登录名
            string userId = OlUser.Manager_LoginName;

            Grid previewGrid = archivePreviewWindow.FindControl("previewDataPanel").FindControl("previewDataGrid") as Grid;

            int[] seelctedRows = previewGrid.SelectedRowIndexArray;
            if (seelctedRows == null || seelctedRows.Length == 0)
            {
                Alert.Show("请选择需要确认的账单!");
                return;
            }

            int total = 0;
            foreach (int rowIndex in seelctedRows)
            {
                long id = (long)previewGrid.DataKeys[rowIndex][0];
                try
                {
                    int retValue = updaterHelper.Update(string.Format("update TAKEIN10 set STATUS = 5, LOCKED = 1 where Id = {0}", id));
                    if(retValue == 1)
                    {
                        //查询进货单主信息
                        List<ConditionFun.SqlqueryCondition> where = new List<ConditionFun.SqlqueryCondition>();
                        where.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "Id", Comparison.Equals, id, false, false));
                        TAKEIN10 tAKEIN10 = selectHelper.SelectSingle<TAKEIN10>(true, null, where, null);
                        if(tAKEIN10 == null)
                        {
                            CommonBll.WriteLog("", null);
                            continue;
                        }
                        List<ConditionFun.SqlqueryCondition> condition = new List<ConditionFun.SqlqueryCondition>();
                        condition.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "TAKEIN_ID", Comparison.Equals, id, false, false));
                        List<TAKEIN11> itemList = selectHelper.Select<TAKEIN11>(false, 5000, null, 0, 5000, condition, null).ExecuteTypedList<TAKEIN11>();

                        decimal amount = 0;
                        decimal tax = 0;
                        //
                        foreach (TAKEIN11 item in itemList)
                        {
                            DUE01 payItem = new DUE01();
                            //批次号
                            payItem.BAT_NO = item.BAT_NO;
                            //采购金额
                            payItem.COST = item.STD_PRICE * item.STD_QUAN;

                            //税额
                            payItem.TAX = item.Tax;

                            //采购金额
                            amount += payItem.COST;
                            tax += payItem.TAX;
                        }

                        DUE00 payMain = new DUE00();                        

                        //进货单审核日期
                        payMain.APP_DATETIME = tAKEIN10.APP_DATETIME;
                        //进货单审核人
                        payMain.APP_USER = tAKEIN10.APP_USER;
                        //应付账单创建日期
                        payMain.CRT_DATETIME = DateTime.Now;
                        //应付账单创建人
                        payMain.CRT_USER_ID = userId;
                        //进货单日期
                        payMain.INPUT_DATE = tAKEIN10.INPUT_DATE;
                        //发票
                        payMain.INVOICE_ID = tAKEIN10.INVOICE_ID;
                        //应付账单最后修改日期
                        payMain.LAST_UPDATE = DateTime.Now;
                        //备注
                        payMain.Memo = tAKEIN10.Memo;
                        //更新时间
                        payMain.MOD_DATETIME = DateTime.Now;
                        //修改人
                        payMain.MOD_USER_ID = userId;
                        //预付款
                        payMain.PRE_PAY = tAKEIN10.PRE_PAY;
                        //预付款单号
                        payMain.PRE_PAY_ID = tAKEIN10.PRE_PAY_ID;
                        //关联ID
                        payMain.RELATE_ID = tAKEIN10.RELATE_ID;
                        //进货分店编号
                        payMain.SHOP_ID = tAKEIN10.SHOP_ID;
                        //待核准状态
                        payMain.STATUS = 1;
                        //供应商编号
                        payMain.SUP_ID = tAKEIN10.SUP_ID;
                        //进货单号
                        payMain.TAKEIN_ID = tAKEIN10.TAKEIN_ID;
                        //进货类型
                        payMain.TAKEIN_TYPE = 1; //一般进货
                                                 //进货单金额
                        payMain.TOT_AMOUNT = amount;
                        //进货单数量
                        payMain.TOT_QTY = tAKEIN10.TOT_QTY;
                        //税额
                        payMain.TOT_TAX = tax;
                        payMain.USER_ID = userId;

                        //保存主信息
                        payMain.Save();
                        total++;
                    }
                }
                catch(Exception ex)
                {
                    CommonBll.WriteLog(string.Format("处理进货单[{0}]发生异常", id), ex);
                }
                Alert.Show(string.Format("汇整完成，总共{0}条，成功{1}条", seelctedRows.Length, total));
            }
        }
    }
}