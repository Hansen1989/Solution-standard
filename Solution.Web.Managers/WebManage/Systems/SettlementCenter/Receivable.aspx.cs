using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using SubSonic.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            List<ConditionFun.SqlqueryCondition> shopCondition = new List<ConditionFun.SqlqueryCondition>();
            shopCondition.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "", Comparison.Equals, shopId, false, false));

            SHOP00Bll.GetInstence().GetDataTable(false, 0, null, 0, 0);

            //初始化时间
            DatePicker outStartDate = archiveWindow.FindControl("archiveDatePanel").FindControl("outStartDate") as DatePicker;
            outStartDate.SelectedDate = ConvertHelper.StringToDatetime(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd 00:00:00"));

            DatePicker outEndDate = archiveWindow.FindControl("archiveDatePanel").FindControl("outEndDate") as DatePicker;
            outEndDate.SelectedDate = ConvertHelper.StringToDatetime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
        }
        #endregion


        /// <summary>
        /// 更换分店事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void shopIdDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

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

            //拼接查询条件
            List<ConditionFun.SqlqueryCondition> conditionList = QueryOutListCondition(shopId, dpStart.Text, dpEnd.Text);

            //1.查询总部出货表
            // 1)出货单状态为 2=核准
            // 2)SHOP_ID = 当前登录用户的总部编号
            // 3)在指定日期范围内
            //2.遍历结果
            //3.更新出货单状态为5=月结(关单)， 并且锁定出货单(LOCKED=1)
            //4.更新成功后查询出货单明细更新到应收明细表
            //5.保存应收主信息
            //6.保存应收明细

            int total = 0;

            var updaterHelper = new UpdateHelper();

            var selectHelper = new SelectHelper();

            //循环查询
            while (true)
            {
                //1.查询满足条件的出货单    
                DataTable dataTable = OUT00Bll.GetInstence().GetDataTable(false, 100, null, 0, 100, conditionList, null);
                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    break;
                }                

                //2.遍历查询结果
                foreach (DataRow row in dataTable.Rows)
                {
                    try
                    {
                        //3.更新出货单状态为5=月结(关单)                       
                        int retValue = updaterHelper.Update(string.Format("update OUT00 set STATUS = 5, LOCKED = 1 where id = {0} and STATUS = 2", row["Id"]));

                        //更新成功 汇整出货单
                        if (retValue == 1)
                        {
                            //4.查询出货单明细
                            //明细查询条件
                            List<ConditionFun.SqlqueryCondition> itemConditionList = new List<ConditionFun.SqlqueryCondition>();
                            itemConditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.Where, "SHOP_ID", Comparison.Equals, row["SHOP_ID"], false, false));
                            itemConditionList.Add(new ConditionFun.SqlqueryCondition(ConstraintType.And, "OUT_ID", Comparison.Equals, row["OUT_ID"], false, false));

                            //执行查询
                            List<OUT01> outItemList = selectHelper.Select<OUT01>(false, 0, null, itemConditionList, new List<string>() { "SNo" }).ExecuteTypedList<OUT01>();

                            if(outItemList == null || outItemList.Count == 0)
                            {
                                CommonBll.WriteLog(string.Format("出货单{0}未查询到明细", row["OUT_ID"]), null);
                                continue;
                            }

                            //出货价格
                            decimal price = 0;
                            //出货成本
                            decimal cost = 0;
                            //遍历出货单明细插入
                            foreach(OUT01 item in outItemList)
                            {
                                //累加出货价
                                price += item.STD_PRICE;
                                //累加成本
                                cost += item.COST;

                                //应收明细
                                RECEIVABLES01 receiveItem = new RECEIVABLES01();
                                //出货批号
                                receiveItem.BAT_NO = item.BAT_NO;
                                //出货成本
                                receiveItem.COST = item.COST;
                                //明细备注
                                receiveItem.MEMO = item.MEMO;
                                //出货单ID
                                receiveItem.OUT_ID = item.OUT_ID;
                                //商品编号
                                receiveItem.PROD_ID = item.PROD_ID;
                                //验收量
                                receiveItem.QUAN1 = item.QUAN1;
                                //取消量
                                receiveItem.QUAN2 = item.QUAN2;
                                //总店编号
                                receiveItem.SHOP_ID = item.SHOP_ID;
                                //明细序号
                                receiveItem.SNo = item.SNo;
                                //出货价格
                                receiveItem.STD_PRICE = item.STD_PRICE;
                                //出货量
                                receiveItem.STD_QUAN = item.STD_QUAN;
                                //出货单位
                                receiveItem.STD_UNIT = item.STD_UNIT;

                                //6.保存明细
                                receiveItem.Save();
                            }

                            RECEIVABLES00 receiveMain = new RECEIVABLES00();
                            //receiveMain.APP_DATETIME
                            //receiveMain.APP_USER = "";
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
                            receiveMain.OUT_ID = row["OUT_ID"].ToString();
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

                            //5.保存应收账单                            
                            receiveMain.Save();
                            total++;
                        }
                    }
                    catch (Exception ex)
                    {
                        CommonBll.WriteLog(string.Format("汇整出货单{0}发生错误。", row["OUT_ID"]), ex);
                    }
                    
                }
                
                //已处理到最后一页
                if (dataTable.Rows.Count < 100)
                {
                    break;
                }
                //等待2秒
                Thread.Sleep(2000);
            }

            Thread.Sleep(5000);
            
            Alert.Show(string.Format("汇整完成，共汇整{0}条出货单.", total));
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
    }
}