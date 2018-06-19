<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Receivable.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SettlementCenter.Receivable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:Pagemanager id="PageManager1" runat="server" AutoSizePanelID="panel4"/>
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
                                        <f:Button runat="server" Text="汇整" ID="ButtonArchive" ToolTip="汇整应收账单" Icon="Accept" ></f:Button>
                                        <f:Button runat="server" Text="查询" ID="ButtonQuery" ToolTip="查询应收账单" Icon="SystemSearch"></f:Button>
                                        <f:Button runat="server" Text="删除" ID="ButtonDelete" ToolTip="查询应收账单" Icon="Delete"></f:Button>
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
    </form>
</body>
</html>
