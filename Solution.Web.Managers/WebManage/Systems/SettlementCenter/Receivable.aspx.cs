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
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solution.Web.Managers.WebManage.Systems.SettlementCenter
{
    public partial class Receivable : PageBase
    {

        /// <summary>
        /// 分店编号和名称字典
        /// </summary>
        private Dictionary<string, string> shopDic = new Dictionary<string, string>();

        /// <summary>
        /// 登录用户所属分店ID
        /// </summary>
        private string shopId = "";

        /// <summary>
        /// 更新代理
        /// </summary>
        private UpdateHelper updaterHelper = new UpdateHelper();

        /// <summary>
        /// 查询代理
        /// </summary>
        private SelectHelper selectHelper = new SelectHelper();

        

        protected void Page_Load(object sender, EventArgs e)
        {
            //LoadData();
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        public override void LoadData()
        {
            //获取登录用户
            var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());

            //获取用户所属shop
            shopId = OlUser.SHOP_ID;

            //出货单号
            string outNo = outId.Text;

            //状态
            int status = 0;
            if(billStatus.SelectedIndex > 0)
            {
                status = Convert.ToInt32(billStatus.SelectedValue);
            }
            

            List<ConditionFun.SqlqueryCondition> conditionList = new List<ConditionFun.SqlqueryCondition>();
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "Id", Comparison.GreaterThan, 0, false, false));
            string selectedValue = shopIdDropdown.SelectedValue;

            //添加门店过滤
            if (selectedValue != null && !selectedValue.Equals(shopId))
            {                
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, "IN_SHOP", Comparison.Equals, selectedValue, false, false));
            }

            //出货单号过滤
            if(outNo != null && outNo.Trim().Length > 0)
            {
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, "OUT_ID", Comparison.Like, outNo + "%", false, false));
            }

            //添加状态过滤
            if(status > 0)
            {
                conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, "STATUS", Comparison.Equals, status, false, false));
            }

            RECEIVABLES00Bll.GetInstence().BindGrid(resultGrid, 0, 30, conditionList);
        }


        #region 接口函数，用于UI页面初始化，给逻辑层对象、列表等对象赋值
        public override void Init()
        {
            //获取登录用户
            var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());
            
            //获取用户所属shop
            shopId = OlUser.SHOP_ID;


            //绑定门店下拉列表
            //SHOP00Bll.GetInstence().BandDropDownListShowShop1(this, shopIdDropdown);

            //查询查询所有分店
            var shop = SHOP00Bll.GetInstence().GetModelForCache(s => s.SHOP_ID.Equals(shopId));



            List<ConditionFun.SqlqueryCondition> shopCondition = new List<ConditionFun.SqlqueryCondition>();
            shopCondition.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "SHOP_Area_ID", Comparison.Equals, shop.SHOP_Area_ID, false, false));

            List<SHOP00> shopList = selectHelper.Select<SHOP00>(false, 0, null, shopCondition, null).ExecuteTypedList<SHOP00>();

            shopIdDropdown.DataSource = shopList;
            shopIdDropdown.DataTextField = "SHOP_NAME1";
            shopIdDropdown.DataValueField = "SHOP_ID";
            shopIdDropdown.DataBind();

            foreach(SHOP00 shop00 in shopList)
            {
                shopDic[shop00.SHOP_ID] = shop00.SHOP_NAME1;
            }

            //初始化时间
            DatePicker outStartDate = archiveWindow.FindControl("archiveDatePanel").FindControl("outStartDate") as DatePicker;
            outStartDate.SelectedDate = ConvertHelper.StringToDatetime(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd 00:00:00"));

            DatePicker outEndDate = archiveWindow.FindControl("archiveDatePanel").FindControl("outEndDate") as DatePicker;
            outEndDate.SelectedDate = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
        }
        #endregion


        ///// <summary>
        ///// 更换分店事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void shopIdDropdown_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LoadData();
        //}

        /// <summary>
        /// 汇整出货单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Archive_Click(object sender, EventArgs e)
        {

            archiveWindow.Hidden = true;

            //获取登录用户
            var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());

            //登录名
            string userId = OlUser.Manager_LoginName;

            //获取用户所属shop
            shopId = OlUser.SHOP_ID;

            DatePicker dpStart = archiveWindow.FindControl("archiveDatePanel").FindControl("outStartDate") as DatePicker;
            DatePicker dpEnd = archiveWindow.FindControl("archiveDatePanel").FindControl("outEndDate") as DatePicker;

            List<ReceiveBillMain> previewList = new List<ReceiveBillMain>();

            //出货单
            List<ReceiveBillMain> tmpList = QueryOutBill(dpStart.Text, dpEnd.Text, userId);
            if(tmpList.Count > 0)
            {
                previewList.AddRange(tmpList);
            }
            
            //退货单
            tmpList = QueryBackBill(dpStart.Text, dpEnd.Text, userId);
            if (tmpList.Count > 0)
            {
                previewList.AddRange(tmpList);
            }

            //Alert.Show(string.Format("汇整完成，共汇整{0}条出货单.", total));
            previewWindow.Hidden = false;
            previewWindow.Top = 100;
            

            Grid previewGrid = previewWindow.FindControl("previewDataPanel").FindControl("previewDataGrid") as Grid;
            previewGrid.DataSource = previewList;
            previewGrid.DataBind();
        }

        /// <summary>
        /// 查询应收账单
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private List<ReceiveBillMain> QueryOutBill(string startDate, string endDate, string userId)
        {

            //拼接查询条件
            List<ConditionFun.SqlqueryCondition> conditionList = QueryOutListCondition(shopId, startDate, endDate);

            //1.查询总部出货表OUT00
            // 1)出货单状态为 2=核准
            // 2)SHOP_ID = 当前登录用户的总部编号
            // 3)在指定日期范围内            
            //2.遍历结果 计算成本和价格
            //3.显示预览界面           


            List<ReceiveBillMain> previewList = new List<ReceiveBillMain>();


            //1.查询满足条件的出货单    
            DataTable dataTable = OUT00Bll.GetInstence().GetDataTable(false, 5000, null, 0, 5000, conditionList, null);
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return previewList;
            }

            //2.遍历查询结果
            foreach (DataRow row in dataTable.Rows)
            {
                try
                {

                    //4.查询出货单明细
                    //明细查询条件
                    List<ConditionFun.SqlqueryCondition> itemConditionList = new List<ConditionFun.SqlqueryCondition>();
                    itemConditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "SHOP_ID", Comparison.Equals, row["SHOP_ID"], false, false));
                    itemConditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, "OUT_ID", Comparison.Equals, row["OUT_ID"], false, false));

                    //执行查询
                    List<OUT01> outItemList = selectHelper.Select<OUT01>(false, 0, null, itemConditionList, new List<string>() { "SNo" }).ExecuteTypedList<OUT01>();

                    if (outItemList == null || outItemList.Count == 0)
                    {
                        CommonBll.WriteLog(string.Format("出货单{0}未查询到明细", row["OUT_ID"]), null);
                        continue;
                    }

                    //出货价格
                    decimal price = 0;
                    //出货成本
                    decimal cost = 0;
                    //遍历出货单明细插入
                    foreach (OUT01 item in outItemList)
                    {
                        //累加出货价
                        price += item.STD_PRICE;
                        //累加成本
                        cost += item.COST;
                    }

                    ReceiveBillMain receiveMain = new ReceiveBillMain();

                    receiveMain.Id = Convert.ToInt32(row["Id"].ToString());
                    receiveMain.BILL_TYPE = (int)BillType.OutBill;
                    //建档时间
                    receiveMain.CRT_DATETIME = DateTime.Now;
                    //建档人员
                    receiveMain.CRT_USER_ID = userId;
                    //出货单日期
                    receiveMain.INPUT_DATE = (DateTime)row["INPUT_DATE"];
                    //分店编号
                    receiveMain.IN_SHOP = row["IN_SHOP"].ToString();
                    //最后修改日期
                    receiveMain.LAST_UPDATE = DateTime.Now;
                    //备注
                    receiveMain.MEMO = row["Memo"].ToString();
                    //修改时间
                    receiveMain.MOD_DATETIME = DateTime.Now;
                    //修改人
                    receiveMain.MOD_USER_ID = userId;
                    //出货单号
                    receiveMain.BILL_ID = row["OUT_ID"].ToString();
                    //总店编号
                    receiveMain.SHOP_ID = row["SHOP_ID"].ToString();
                    //新建存档状态
                    receiveMain.STATUS = 1;
                    //出货单的建单人  
                    receiveMain.USER_ID = row["USER_ID"].ToString();
                    //出货总价
                    receiveMain.BILL_AMOUNT = price;
                    //出货总成本
                    receiveMain.BILL_COST = cost;

                    previewList.Add(receiveMain);

                }
                catch (Exception ex)
                {
                    CommonBll.WriteLog(string.Format("汇整出货单{0}发生错误。", row["OUT_ID"]), ex);
                }

            }

            return previewList;
        }


        /// <summary>
        /// 查询退货账单
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private List<ReceiveBillMain> QueryBackBill(string startDate, string endDate, string userId)
        {
            List<ReceiveBillMain> previewList = new List<ReceiveBillMain>();
            List<ConditionFun.SqlqueryCondition> conditionList = new List<ConditionFun.SqlqueryCondition>();
            //查询总店的所有应收出货单
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, OUT00Table.SHOP_ID, Comparison.Equals, shopId, false, false));
            //退货单时间
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, OUT00Table.INPUT_DATE, Comparison.GreaterOrEquals, startDate, false, false));
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, OUT00Table.INPUT_DATE, Comparison.LessOrEquals, endDate, false, false));
            //退货单状态为2=核准
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, OUT00Table.STATUS, Comparison.Equals, 2, false, false));

            List<IN_BACK00> backList = selectHelper.Select<IN_BACK00>(true, 5000, null, 0, 5000, conditionList, new List<string>() { "SHOP_ID" }).ExecuteTypedList<IN_BACK00>();

            if(backList == null || backList.Count  == 0)
            {
                return previewList;
            }

            foreach(IN_BACK00 back00 in backList)
            {
                try
                {

                    //查询退货单明细
                    //明细查询条件
                    List<ConditionFun.SqlqueryCondition> itemConditionList = new List<ConditionFun.SqlqueryCondition>();
                    itemConditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "SHOP_ID", Comparison.Equals, back00.SHOP_ID, false, false));
                    itemConditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, "IB_ID", Comparison.Equals, back00.IB_ID, false, false));

                    //执行查询
                    List<IN_BACK01> outItemList = selectHelper.Select<IN_BACK01>(false, 0, null, itemConditionList, new List<string>() { "SNo" }).ExecuteTypedList<IN_BACK01>();

                    if (outItemList == null || outItemList.Count == 0)
                    {
                        CommonBll.WriteLog(string.Format("出货单{0}未查询到明细", back00.IB_ID, null));
                        continue;
                    }

                    //出货价格
                    decimal price = 0;
                    //出货成本
                    decimal cost = 0;
                    //遍历出货单明细插入
                    foreach (IN_BACK01 item in outItemList)
                    {
                        //累加出货价
                        price += item.STD_PRICE;
                        //累加成本
                        cost += item.COST;
                    }

                    ReceiveBillMain receiveMain = new ReceiveBillMain();
                    receiveMain.Id = back00.Id;
                    receiveMain.BILL_TYPE = (int)BillType.BackBill;
                    //建档时间
                    receiveMain.CRT_DATETIME = DateTime.Now;
                    //建档人员
                    receiveMain.CRT_USER_ID = userId;
                    //出货单日期
                    receiveMain.INPUT_DATE = back00.INPUT_DATE;
                    //分店编号
                    receiveMain.IN_SHOP = back00.SHOP_ID;
                    //最后修改日期
                    receiveMain.LAST_UPDATE = DateTime.Now;
                    //备注
                    receiveMain.MEMO = back00.Memo;
                    //修改时间
                    receiveMain.MOD_DATETIME = DateTime.Now;
                    //修改人
                    receiveMain.MOD_USER_ID = userId;
                    //退货单号
                    receiveMain.BILL_ID = back00.IB_ID;
                    //总店编号
                    receiveMain.SHOP_ID = back00.OUT_SHOP;
                    //新建存档状态
                    receiveMain.STATUS = 1;
                    //出货单的建单人  
                    receiveMain.USER_ID = back00.USER_ID;

                    //退货总价
                    receiveMain.BILL_AMOUNT = price;
                    //退货总成本
                    receiveMain.BILL_COST = cost;

                    previewList.Add(receiveMain);

                }
                catch (Exception ex)
                {
                    CommonBll.WriteLog(string.Format("汇整退货单{0}发生错误。", back00.IB_ID, ex));
                }
            }

            return previewList;
        }


        /// <summary>
        /// 拼接出货单查询条件
        /// </summary>
        /// <returns></returns>
        private List<ConditionFun.SqlqueryCondition> QueryOutListCondition(string shopId, string startTime, string endTime)
        {
            List<ConditionFun.SqlqueryCondition> conditionList = new List<ConditionFun.SqlqueryCondition>();
            //查询总店的所有应收出货单
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, OUT00Table.SHOP_ID, Comparison.Equals, shopId, false, false));
            //出货单时间
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, OUT00Table.INPUT_DATE, Comparison.GreaterOrEquals, startTime, false, false));
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, OUT00Table.INPUT_DATE, Comparison.LessOrEquals, endTime, false, false));
            //出货单状态为2=核准
            conditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, OUT00Table.STATUS, Comparison.Equals, 2, false, false));
            return conditionList;
        }

        /// <summary>
        /// 取消汇整
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CancelArchive_Click(object sender, EventArgs e)
        {
            archiveWindow.Hidden = true;
        }

        /// <summary>
        /// 主窗口汇整按钮
        /// 点击打开选择时间范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonArchiveOrders_Click(object sender, EventArgs e)
        {
            //汇整子窗口显示
            archiveWindow.Hidden = false;            
        }

        /// <summary>
        /// 点击查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonQuery_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// 行绑定事件，每行显示之前调用该方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void resultGrid_PreRowDataBound(object sender, GridPreRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;
            FineUI.BoundField shopName = resultGrid.FindColumn("SHOP_NAME") as FineUI.BoundField;
            shopName.NullDisplayText = shopDic[row["SHOP_ID"].ToString()];

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
            if(row == null)
            {
                Alert.Show("请选择需要核准的应付账单");
                return;
            }
            try
            {
                int id = Convert.ToInt32(row.DataKeys[0].ToString());
                RECEIVABLES00 pay = selectHelper.SelectSingle<RECEIVABLES00>(false, null, new List<ConditionFun.SqlqueryCondition>() { new ConditionFun.SqlqueryCondition(ConstraintType.Where, "Id", Comparison.Equals, id, false, false) });
                if (SubsonicConstants.STATUS_NEW ==  pay.STATUS)
                {
                    Alert.Show("应付账单状态不是存档状态，不能核准");
                    return;
                }
                else
                {
                    var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());

                    int ret = updaterHelper.Update(string.Format("update RECEIVABLES00 set status = 2  where status = 1 and id = {0}", id));
                    
                    //核准时间
                    pay.MOD_DATETIME = DateTime.Now;
                    //核准人
                    pay.MOD_USER_ID = OlUser.Manager_LoginName;
                    pay.Save();
                    if(ret == 1)
                    {
                        Alert.Show(string.Format("出货单号[{0}]核准成功", pay.BILL_ID));

                    }else
                    {
                        Alert.Show(string.Format("出货单号[{0}]核准失败", pay.BILL_ID));
                    }
                    LoadData();
                }
            }catch(Exception e)
            {
                CommonBll.WriteLog(string.Format("id:{0}核准失败", row.DataKeys[0]), e);
            }            
        }

        /// <summary>
        /// 单击行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void resultGrid_RowClick(object sender, GridRowClickEventArgs e)
        {
            
            GridRow row = resultGrid.Rows[e.RowIndex];
            //分店编号
            string shopId = row.DataKeys[1].ToString();
            //出货单号
            string outId = row.DataKeys[2].ToString();

            List<ConditionFun.SqlqueryCondition> wheres = new List<ConditionFun.SqlqueryCondition>();
            wheres.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "SHOP_ID", Comparison.Equals, shopId));
            wheres.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, "OUT_ID", Comparison.Equals, outId));                  
        }

        /// <summary>
        /// 点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Preview_Ok_Click(object sender, EventArgs e)
        {
            //获取登录用户
            var OlUser = OnlineUsersBll.GetInstence().GetModelForCache(x => x.UserHashKey == Session[OnlineUsersTable.UserHashKey].ToString());

            //登录名
            string userId = OlUser.Manager_LoginName;

            Grid previewGrid = previewWindow.FindControl("previewDataPanel").FindControl("previewDataGrid") as Grid;

            int[] seelctedRows = previewGrid.SelectedRowIndexArray;
            if(seelctedRows == null || seelctedRows.Length == 0)
            {
                Alert.Show("请选择需要确认的账单!");
                return;
            }
            StringBuilder sb = new StringBuilder();            
            int outTotal = 0;
            int backTotal = 0;
            foreach (int rowIndex in seelctedRows)
            {                
                long id = (long)previewGrid.DataKeys[rowIndex][0];
                BillType billType = (BillType)previewGrid.DataKeys[rowIndex][1];
                switch (billType)
                {
                    case BillType.OutBill:
                        //出货单
                        if (ProcessOutBill(id, userId))
                        {
                            outTotal++;
                        }
                        break;
                    case BillType.BackBill:
                        //退货单
                        if(ProcessBackBill(id, userId))
                        {
                            backTotal++;
                        }
                        break;
                }
            }
            if(backTotal > 0)
            {
                Alert.Show(string.Format("汇整完成, 出货单:{0}条，退货单:{1}条。", outTotal, backTotal));
            }
            else
            {
                Alert.Show(string.Format("汇整完成, 出货单:{0}条。", outTotal));
            }
            previewWindow.Hidden = true;
        }

        /// <summary>
        /// 出货单处理
        /// </summary>
        /// <param name="id">出货单id</param>
        /// <param name="userId">登陆用户id</param>
        /// <returns></returns>
        private bool ProcessOutBill(long id, string userId)
        {
            try
            {
                int retvalue = updaterHelper.Update(string.Format("update OUT00 set STATUS = 5, LOCKED = 1 where id = {0} and STATUS = 2", id));
                if (retvalue == 1)
                {
                    //账单更新成功
                    List<ConditionFun.SqlqueryCondition> outCondition = new List<ConditionFun.SqlqueryCondition>();
                    outCondition.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "Id", Comparison.Equals, id, false, false));

                    //根据id更新
                    OUT00 out00 = selectHelper.SelectSingle<OUT00>(false, null, outCondition);

                    if (out00 != null)
                    {
                        List<ConditionFun.SqlqueryCondition> itemConditionList = new List<ConditionFun.SqlqueryCondition>();
                        itemConditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "SHOP_ID", Comparison.Equals, out00.SHOP_ID, false, false));
                        itemConditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, "OUT_ID", Comparison.Equals, out00.OUT_ID, false, false));

                        //执行查询
                        List<OUT01> outItemList = selectHelper.Select<OUT01>(false, 0, null, itemConditionList, new List<string>() { "SNo" }).ExecuteTypedList<OUT01>();

                        if (outItemList == null || outItemList.Count == 0)
                        {
                            CommonBll.WriteLog(string.Format("出货单{0}未查询到明细", out00.OUT_ID), null);
                            return false;
                        }

                        //出货价格
                        decimal price = 0;
                        //出货成本
                        decimal cost = 0;
                        //遍历出货单明细插入
                        foreach (OUT01 item in outItemList)
                        {
                            //累加出货价
                            price += item.STD_PRICE;
                            //累加成本
                            cost += item.COST;
                        }

                        RECEIVABLES00 receiveMain = new RECEIVABLES00();
                        
                        receiveMain.BILL_TYPE = (int)BillType.OutBill;
                        //建档时间
                        receiveMain.CRT_DATETIME = DateTime.Now;
                        //建档人员
                        receiveMain.CRT_USER_ID = userId;
                        //出货单日期
                        receiveMain.INPUT_DATE = out00.INPUT_DATE;
                        //分店编号
                        receiveMain.IN_SHOP = out00.IN_SHOP;
                        //最后修改日期
                        receiveMain.LAST_UPDATE = DateTime.Now;
                        //备注
                        receiveMain.MEMO = out00.Memo;
                        //修改时间
                        receiveMain.MOD_DATETIME = DateTime.Now;
                        //修改人
                        receiveMain.MOD_USER_ID = userId;
                        //出货单号
                        receiveMain.BILL_ID = out00.OUT_ID;
                        //总店编号
                        receiveMain.SHOP_ID = out00.SHOP_ID;
                        //新建存档状态
                        receiveMain.STATUS = 1;
                        //出货单的建单人  
                        receiveMain.USER_ID = out00.USER_ID;
                        //出货总价
                        receiveMain.BILL_AMOUNT = price;
                        //出货总成本
                        receiveMain.BILL_COST = cost;

                        //5.保存应收账单                            
                        receiveMain.Save();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonBll.WriteLog(string.Format("更新账单发生异常，账单id:{0}", id), ex);
            }
            return false;
        }

        /// <summary>
        /// 退货单处理
        /// </summary>
        /// <param name="id">退货单id</param>
        /// <param name="userId">登陆用户id</param>
        /// <returns></returns>
        private bool ProcessBackBill(long id, string userId)
        {
            try
            {
                //更新核准状态的退货单
                int retvalue = updaterHelper.Update(string.Format("update IN_BACK00 set STATUS = 5, LOCKED = 1 where id = {0} and STATUS = 2", id));
                if (retvalue == 1)
                {
                    //账单更新成功
                    List<ConditionFun.SqlqueryCondition> backCondition = new List<ConditionFun.SqlqueryCondition>();
                    backCondition.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "Id", Comparison.Equals, id, false, false));

                    //根据id更新
                    IN_BACK00 back00 = selectHelper.SelectSingle<IN_BACK00>(false, null, backCondition);

                    if (back00 != null)
                    {
                        List<ConditionFun.SqlqueryCondition> itemConditionList = new List<ConditionFun.SqlqueryCondition>();
                        itemConditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "SHOP_ID", Comparison.Equals, back00.SHOP_ID, false, false));
                        itemConditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, "IB_ID", Comparison.Equals, back00.IB_ID, false, false));

                        //执行查询
                        List<IN_BACK01> backItemList = selectHelper.Select<IN_BACK01>(false, 0, null, itemConditionList, new List<string>() { "SNo" }).ExecuteTypedList<IN_BACK01>();

                        if (backItemList == null || backItemList.Count == 0)
                        {
                            CommonBll.WriteLog(string.Format("退货单{0}未查询到明细", back00.IB_ID), null);
                            return false;
                        }

                        //出货价格
                        decimal price = 0;
                        //出货成本
                        decimal cost = 0;
                        //遍历出货单明细插入
                        foreach (IN_BACK01 item in backItemList)
                        {
                            //累加出货价
                            price += item.STD_PRICE;
                            //累加成本
                            cost += item.COST;
                        }

                        RECEIVABLES00 receiveMain = new RECEIVABLES00();

                        receiveMain.BILL_TYPE = (int)BillType.BackBill;
                        //建档时间
                        receiveMain.CRT_DATETIME = DateTime.Now;
                        //建档人员
                        receiveMain.CRT_USER_ID = userId;
                        //出货单日期
                        receiveMain.INPUT_DATE = back00.INPUT_DATE;
                        //分店编号
                        receiveMain.IN_SHOP = back00.SHOP_ID;
                        //最后修改日期
                        receiveMain.LAST_UPDATE = DateTime.Now;
                        //备注
                        receiveMain.MEMO = back00.Memo;
                        //修改时间
                        receiveMain.MOD_DATETIME = DateTime.Now;
                        //修改人
                        receiveMain.MOD_USER_ID = userId;
                        //出货单号
                        receiveMain.BILL_ID = back00.IB_ID;
                        //总店编号
                        receiveMain.SHOP_ID = back00.OUT_SHOP;
                        //新建存档状态
                        receiveMain.STATUS = 1;
                        //出货单的建单人  
                        receiveMain.USER_ID = back00.USER_ID;
                        //出货总价
                        receiveMain.BILL_AMOUNT = price;
                        //出货总成本
                        receiveMain.BILL_COST = cost;

                        //5.保存应收账单                            
                        receiveMain.Save();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonBll.WriteLog(string.Format("更新账单发生异常，账单id:{0}", id), ex);
            }
            return false;
        }
    }
}