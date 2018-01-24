<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProdUnitList.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.DataCenter.ProdUnitList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server" />
    <f:panel id="Panel1" runat="server" title="菜单(页面)列表" enableframe="false" bodypadding="10px"
        enablecollapse="True">
        <toolbars>
            <f:Toolbar ID="toolBar" runat="server">
                <Items>
                    <f:Button ID="ButtonRefresh" runat="server" Text="刷新" Icon="ArrowRefresh" OnClick="ButtonRefresh_Click" CssClass="inline"></f:Button>
                    <f:Button ID="ButtonAdd" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click"></f:Button>
                    <f:Button ID="ButtonSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="ButtonSearch_Click"></f:Button>
                    <f:Button ID="ButtonEdit" runat="server" Text="编辑" Icon="BulletEdit" OnClick="ButtonEdit_Click"
                         OnClientClick="if(!F('Panel1_Grid1').getSelectionModel().hasSelection()|| F('Panel1_Grid1').getSelectionModel().getCount()>=2){F.alert('您没有选择编辑项或只能选择一项进行编辑！'); return false; }">
                    </f:Button>
                    <f:Button ID="ButtonDelete" runat="server" Text="删除" Icon="Delete" OnClick="ButtonDelete_Click" ConfirmTitle="删除提示" ConfirmText="是否删除记录？" 
                        OnClientClick="if (!F('Panel1_Grid1').getSelectionModel().hasSelection() ) { F.alert('删除时必须选择一条将要删除的记录！'); return false; }  if (F('Panel1_Grid1').getSelectionModel().getCount() >= 2) { F.alert('只能选择一条记录进行删除！');return false; }">
                    </f:Button>
                </Items>
            </f:Toolbar>
        </toolbars>
        <items>
            <f:Grid ID="Grid1" Title="单位列表" EnableFrame="false" EnableCollapse="true" AllowSorting="true" SortField="Depth" SortDirection="ASC" 
            PageSize="15" ShowBorder="true" ShowHeader="true" AllowPaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id" EnableColumnLines="true"
            OnPageIndexChange="Grid1_PageIndexChange" OnRowCommand="Grid1_RowCommand" OnPreRowDataBound="Grid1_PreRowDataBound" > 
                <Columns>
                    <f:RowNumberField />
                    <f:BoundField Width="180px" DataField="UNIT_ID" HeaderText="单位编号" />
                    <f:BoundField Width="180px" DataField="UNIT_NAME" HeaderText="单位名称" />
                    <f:BoundField DataField="UNIT_MEMO" HeaderText="备注" ExpandUnusedSpace="true" />
                    
                    <f:LinkButtonField HeaderText="操作" TextAlign="Center" ToolTip="点击修改当前记录" ColumnID="ButtonEdit" CommandName="ButtonEdit" />
                </Columns>
            </f:Grid>
            <f:Label runat="server" ID="lblSpendingTime" Text=""></f:Label>
            <f:HiddenField runat="server" ID="SortColumn" Text="Id"></f:HiddenField>
        </items>
    </f:panel>
    <f:window id="Window1" width="480px" height="340px" icon="TagBlue" title="编辑" Target="Parent"
        enablemaximize="True" closeaction="HidePostBack" onclose="Window1_Close" enablecollapse="true" hidden="True" 
        runat="server" enableresize="true" bodypadding="5px" enableframe="True" iframeurl="about:blank"
        enableiframe="true" enableclose="true" ismodal="True">
    </f:window>

   <%-- --%>

    </form>
</body>
</html>
