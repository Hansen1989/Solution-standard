<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Receivable.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SettlementCenter.Receivable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
                <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="center" Title="应收管理" ShowBorder="true" ShowHeader="true" AutoScroll="true">
                    <Items>
                        <%-- 查询面板 --%>                        
                        <f:Form runat="server" ID="queryForm" Title="查询表单" ShowHeader="false" ShowBorder="false" Width="780px" LabelWidth="100px" BodyPadding="5px" LabelAlign="Right" EnableCollapse="true">
                            <Rows>
                                <f:FormRow ColumnWidths="300px">
                                    <Items>
                                        <%-- 分店编号--%>
                                        <f:DropDownList runat="server" ID="shopIdDropdown" AutoPostBack="true" Required="true" OnSelectedIndexChanged="shopIdDropdown_SelectedIndexChanged" Label="分店名称" Width="250px"></f:DropDownList>
                                        <%-- 出货单号--%>
                                        <f:TextBox runat="server" ID="outId" Label="出货单号" Width="250px"></f:TextBox>
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
                                        <f:Button runat="server" Text="汇整" ID="ButtonArchiveOrders" OnClientClick="F('archiveWindow').show();" ToolTip="汇整应收账单" Icon="Accept" OnClick="ButtonArchiveOrders_Click"></f:Button>
                                        <f:Button runat="server" Text="查询" ID="ButtonQuery" ToolTip="查询应收账单" Icon="SystemSearch" OnClick="ButtonQuery_Click"></f:Button>
                                        <f:Button runat="server" Text="删除" ID="ButtonDelete" ToolTip="查询应收账单" Icon="Delete"></f:Button>
                                        <f:Button runat="server" Text="结算" ID="ButtonSettlement" ToolTip="门店完成付款" Icon="MoneyAdd"></f:Button>
                                    </Items>                                        
                                </f:Toolbar>
                            </Toolbars>
                            <Items>
                                <%-- 查询结果--%>
                                <f:Grid runat="server" ID="resultGrid" Title="分店应付账单" EnableMultiSelect="true">
                                    <Columns>
                                        <f:RowNumberField Width="30px" />
                                        <f:BoundField runat="server" Width="180px" DataField="SHOP_NAME" DataFormatString="{0}" HeaderText="分店名称" />
                                        <f:BoundField Width="180px" DataField="OUT_ID" DataFormatString="{0}" HeaderText="出货单号"/>
                                        <f:BoundField Width="180px" DataField="BILL_AMOUNT" DataFormatString="{0}" HeaderText="应收金额"/>
                                        <f:BoundField runat="server" Width="180px" DataField="STATUS_DESC" DataFormatString="{0}" HeaderText="账单状态"/>
                                        <f:BoundField Width="180px" DataField="INPUT_DATE" DataFormatString="{0}" HeaderText="单据日期"/>
                                        <f:BoundField Width="180px" DataField="USER_ID" DataFormatString="{0}" HeaderText="制单人"/>
                                        <f:BoundField Width="180px" DataField="APP_USER" DataFormatString="{0}" HeaderText="审核人"/>
                                        <f:BoundField Width="180px" DataField="APP_DATETIME" DataFormatString="{0}" HeaderText="审核时间"/>
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
                        <f:Button runat="server" Text="汇整" Icon="Accept" OnClick="Archive_Click" OnClientClick="F('archiveWindow').hide();" AjaxLoadingType="Mask" EnableAjaxLoading="true"></f:Button>
                        <f:Button runat="server" Text="取消" Icon="Cancel" OnClick="CancelArchive_Click"></f:Button>
                    </Items>
                </f:Toolbar>                
            </Toolbars>
            <Content>
                <f:Panel runat="server" ID="archiveDatePanel" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="formitem">
                    <Items>
                        <%-- 出货单时间 --%>
                        <f:Label runat="server" Width="140px" Text="出货单时间" ShowLabel="false"></f:Label>
                        <f:DatePicker runat="server" Label="出货单开始时间" ShowLabel="false" ID="outStartDate" CompareControl="outEndDate" CompareOperator="LessThanEqual"
                            CompareMessage="开始日期应小于等于结束日期"
                            ></f:DatePicker>
                        <f:Label runat="server" Text="至" ShowLabel="false"></f:Label>
                        <f:DatePicker runat="server" Label="出货单结束时间" ShowLabel="false" CompareControl="outStartDate" CompareOperator="GreaterThanEqual"
                            CompareMessage="结束日期应该大于等于开始日期！"  Width="150px" ID="outEndDate"></f:DatePicker>
                    </Items>
                </f:Panel>
            </Content>
        </f:Window>                   
    </form>    
</body>    
</html>
