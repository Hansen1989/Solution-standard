<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SettlementCenterPay.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SettlementCenter.SettlementCenterPay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">        
        <f:Pagemanager id="PageManager1" runat="server" AutoSizePanelID="panel4" />
        <f:Panel ID="panel4" runat="server" ShowBorder="false" ShowHeader="false" Layout="Region">
            <Items>
                <f:Panel runat="server" ID="panelCenterRegion" Title="应付管理" ShowBorder="true" ShowHeader="true" AutoScroll="true"
                    RegionPosition="Top" RegionSplit="true" Height="500px">
                    <Items>
                        <%-- 查询面板 --%>                        
                        <f:Form runat="server" ID="queryForm" Title="查询表单" ShowHeader="false" ShowBorder="false" Width="780px" LabelWidth="100px" BodyPadding="5px" LabelAlign="Right" EnableCollapse="true">
                            <Rows>
                                <f:FormRow ColumnWidths="300px">
                                    <Items>
                                        <%-- 供应商编号--%>
                                        <f:DropDownList runat="server" ID="supDropdown" Label="供应商" Width="250px"></f:DropDownList>
                                        <%-- 出货单号--%>
                                        <f:TextBox runat="server" ID="inId" Label="进货单号" Width="250px"></f:TextBox>
                                        <%--账务状态--%>
                                        <f:DropDownList runat="server" Label="状态" ID="billStatus" Width="250px">
                                            <f:ListItem  Text="无" Value="0"/>
                                            <f:ListItem  Text="存档" Value="1"/>
                                            <f:ListItem  Text="核准" Value="2"/>
                                            <f:ListItem  Text="作废" Value="3"/>
                                            <f:ListItem  Text="月结(关单)" Value="5"/>
                                        </f:DropDownList>
                                    </Items>
                                </f:FormRow>                                        
                            </Rows>
                        </f:Form>                          
                    </Items>
                    <Items>
                        <f:Panel ID="Panel1" runat="server" EnableFrame="false" EnableCollapse="True" ShowHeader="False">                            
                            <Toolbars>                                    
                                <%-- 操作区 --%>
                                <f:Toolbar ID="toolBar" runat="server">
                                    <Items>
                                        <%-- 弹出汇整时间输入框 --%>
                                        <f:Button runat="server" Text="汇整" ID="ButtonArchiveOrders" OnClientClick="F('archiveWindow').show();" ToolTip="汇整应付账单" Icon="Accept" OnClick="ButtonArchiveOrders_Click"></f:Button>
                                        <f:Button runat="server" Text="查询" ID="ButtonSearch" OnClick="ButtonSearch_Click" ToolTip="查询应付账单" Icon="SystemSearch"></f:Button>
                                        <f:Button runat="server" Text="核准" ID="ButtonApproval" ToolTip="核准应付账单" Icon="Disk" OnClick="ButtonApproval_Click"></f:Button>
                                        <f:Button runat="server" Text="删除" ID="ButtonDelete" ToolTip="删除应付账单" Icon="Delete"></f:Button>
                                        <f:Button runat="server" Text="结算" ID="ButtonSettlement" ToolTip="门店完成付款" Icon="MoneyAdd" OnClientClick="F('confirmPayWindow').show();" OnClick="ButtonSettlement_Click"></f:Button>
                                    </Items>                                        
                                </f:Toolbar>
                            </Toolbars>
                            <Items>
                                <%-- 查询结果--%>
                                <f:Grid runat="server" ID="resultGrid" Title="总部应付账单" EnableMultiSelect="true" OnPreRowDataBound="resultGrid_PreRowDataBound"
                                    EnableCheckBoxSelect="True" DataKeyNames ="Id,SUP_ID,TAKEIN_ID,SHOP_ID"
                                    EnableRowClickEvent="true" OnRowClick="resultGrid_RowClick">
                                    <Columns>
                                        <f:RowNumberField Width="30px" />
                                        <f:BoundField runat="server" Width="180px" ColumnID="SUP_NAME" DataField="SUP_NAME" DataFormatString="{0}" HeaderText="供应商" />
                                        <f:BoundField runat="server" Width="200px" DataField="TAKEIN_ID" DataFormatString="{0}" HeaderText="进货单号"/>
                                        <f:BoundField runat="server" Width="180px" DataField="TOT_AMOUNT" DataFormatString="{0}" HeaderText="应付金额"/>
                                        <f:BoundField runat="server" Width="180px" ColumnID="STATUS_DESC" DataField="STATUS_DESC" DataFormatString="{0}" HeaderText="账单状态"/>
                                        <f:BoundField runat="server" Width="180px" DataField="INPUT_DATE" DataFormatString="{0}" HeaderText="单据日期"/>
                                        <f:BoundField runat="server" Width="180px" DataField="USER_ID" DataFormatString="{0}" HeaderText="制单人"/>
                                        <f:BoundField runat="server" Width="180px" DataField="APP_USER" DataFormatString="{0}" HeaderText="审核人"/>
                                        <f:BoundField runat="server" Width="180px" DataField="APP_DATETIME" DataFormatString="{0}" HeaderText="审核时间"/>
                                    </Columns>
                                </f:Grid>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:Panel>
                <f:Panel runat="server" RegionPosition="Center" ID="receivableDetail" Title="应收账单明细" ShowHeader="false" AutoScroll="true">
                    <Items>
                        <f:Panel runat="server" Title="应付明细" ShowHeader="false">
                            <Items>

                            </Items>
                            <Items>
                                <f:Grid runat="server" ID="itemGrid" Title="应付明细">
                                    <Columns>
                                        <f:BoundField runat="server" Width="180px" DataField="SNo" HeaderText="序号" DataFormatString="{0}"/>
                                        <f:BoundField runat="server" Width="180px" DataField="PROD_ID" HeaderText="商品编号" DataFormatString="{0}"/>
                                        <f:BoundField runat="server" Width="180px" DataField="STD_QUAN" HeaderText="数量" DataFormatString="{0}"/>
                                        <f:BoundField runat="server" Width="180px" DataField="STD_PRICE" HeaderText="单价" DataFormatString="{0}"/>
                                        <f:BoundField runat="server" Width="180px" DataField="COST" HeaderText="金额" DataFormatString="{0}"/>
                                        <f:BoundField runat="server" Width="180px" DataField="BAT_NO" HeaderText="批次号" DataFormatString="{0}"/>
                                    </Columns>
                                </f:Grid>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <%-- 汇整出货单 --%>
        <f:Window ID="archiveWindow" runat="server" enableresize="true" bodypadding="5px" enableframe="True" enableclose="true" IsModal="True" Width="525px"
            Hidden="true" Layout="Fit">
            <Toolbars>
                <f:Toolbar runat="server">
                    <Items>
                        <%-- 汇整操作 --%>
                        <f:Button runat="server" Text="汇整" Icon="Accept" ID="ArchiveButton" OnClick="ArchiveButton_Click" OnClientClick="F('archiveWindow').hide();" AjaxLoadingType="Mask" EnableAjaxLoading="true"></f:Button>
                        <f:Button runat="server" Text="取消" Icon="Cancel" OnClientClick="F('archiveWindow').hide();"></f:Button>
                    </Items>
                </f:Toolbar>                
            </Toolbars>
            <Content>
                <f:Panel runat="server" ID="archiveDatePanel" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="formitem" >
                    <Items>
                        <%-- 出货单时间 --%>
                        <f:Label runat="server" Width="140px" Text="进货单日期" ShowLabel="false"></f:Label>
                        <f:DatePicker runat="server" Label="进货单开始日期" ShowLabel="false" ID="inStartDate" CompareControl="inEndDate" CompareOperator="LessThanEqual"
                            CompareMessage="开始日期应小于等于结束日期"
                            ></f:DatePicker>
                        <f:Label runat="server" Text="至" ShowLabel="false"></f:Label>
                        <f:DatePicker runat="server" Label="进货单结束日期" ShowLabel="false" CompareControl="inStartDate" CompareOperator="GreaterThanEqual"
                            CompareMessage="结束日期应该大于等于开始日期！"  Width="150px" ID="inEndDate"></f:DatePicker>
                    </Items>
                </f:Panel>
            </Content>
        </f:Window>   
        <%-- 应付信息核对 --%>  
        <f:Window ID="confirmPayWindow" runat="server" enableresize="true" bodypadding="5px" enableframe="True" enableclose="true" IsModal="True" Width="525px"
            Hidden="true" Layout="Fit" Title="账单信息确认"> 
           <Toolbars>
                <f:Toolbar runat="server">
                    <Items>
                        <f:Button runat="server" ID="ButtonPay" Text="确定" Icon="Accept" OnClientClick="F('confirmPayWindow').hide();F('payWindow').show();" OnClick="ButtonPay_Click"></f:Button>
                        <f:Button runat="server" Text="取消" Icon="Cancel" OnClientClick ="F('confirmPayWindow').hide();"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Panel runat="server" Layout="VBox" BodyPadding="5px">
                    <Items>
                        <f:Label runat="server" Label="供应商" ID="supName" />
                        <f:Label runat="server" Label="账单开始时间" ID="billDateStart"/>
                        <f:Label runat="server" Label="账单结束时间" ID="billDateEnd" />
                        <f:Label runat="server" Label="应付总金额" ID="payTotal" />
                        <f:Label runat="server" Label="上次结余金额" ID="lastLeft" />
                        <f:Label runat="server" Label="应付账单数" ID="billNums" />
                    </Items>
                </f:Panel>
            </Items>                                               
        </f:Window> 
        <%-- 付款界面 --%>
        <f:Window runat="server" ID="payWindow" enableresize="true" bodypadding="5px" enableframe="True" enableclose="true" IsModal="True" Width="525px"
            Hidden="true" Layout="Fit" Title ="付款">
            <Toolbars>
                <f:Toolbar runat="server">
                    <Items>
                        <f:Button runat="server" ID="ButtonCloseBill" Text="确定" Icon="Accept" OnClick="ButtonCloseBill_Click"></f:Button>
                        <f:Button runat="server" Text="取消" Icon="Cancel" OnClientClick ="F('payWindow').hide();"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Panel runat="server" Layout="VBox" BodyPadding="10px">
                    <Items>
                        <f:Label runat="server" Label="上次结余" ID="payLastLeft"/>
                        <f:Label runat="server" Label="本次应付" ID="payTotalThisTime" />
                        <f:TextBox runat="server" ID="payMoney" Label="付款金额" MaxLength="16" Required="true"/>
                        <f:TextArea runat="server"  Label="备注:" ID="payMemo" />
                    </Items>
                </f:Panel>
            </Items>
        </f:Window>   
    </form>
</body>
</html>
