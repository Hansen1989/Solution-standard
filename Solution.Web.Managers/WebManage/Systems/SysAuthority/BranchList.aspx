﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BranchList.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SysAuthority.BranchList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                    <f:Button ID="ButtonSaveAutoSort" runat="server" Text="自动排序" Icon="ArrowJoin" OnClick="ButtonSaveAutoSort_Click" ConfirmTitle="自动排序提示" ConfirmText="是否对所有数据进行自动排序？"></f:Button>
                    <f:Button ID="ButtonSaveSort" runat="server" Text="保存排序" Icon="Disk" OnClick="ButtonSaveSort_Click"></f:Button>
                    <f:Button ID="ButtonDelete" runat="server" Text="删除" Icon="Delete" OnClick="ButtonDelete_Click" ConfirmTitle="删除提示" ConfirmText="是否删除记录？" 
                        OnClientClick="if (!F('Panel1_Grid1').getSelectionModel().hasSelection() ) { F.alert('删除时必须选择一条将要删除的记录！'); return false; }  if (F('Panel1_Grid1').getSelectionModel().getCount() >= 2) { F.alert('只能选择一条记录进行删除！');return false; }">
                    </f:Button>
                </Items>
            </f:Toolbar>
        </toolbars>
        <items>
             <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" EnableFrame="false" EnableCollapse="true"
                ShowBorder="True" ShowHeader="False">
                <Items>
                    <f:DropDownList Label="菜单选择" runat="server" ID="ddlParentId" Width="250px"></f:DropDownList>
                </Items>
            </f:SimpleForm>
            <f:Grid ID="Grid1" Title="部门设置" EnableFrame="false" EnableCollapse="true" AllowSorting="true" SortField="Depth" SortDirection="ASC" 
            PageSize="15" ShowBorder="true" ShowHeader="true" AllowPaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id" EnableColumnLines="true"
           OnPageIndexChange="Grid1_PageIndexChange"  OnRowCommand="Grid1_RowCommand" OnPreRowDataBound="Grid1_PreRowDataBound">  <%-- --%>  
                <Columns>
                    <f:RowNumberField />
                    <f:BoundField Width="80px" DataField="Code" DataFormatString="{0}" HeaderText="部门ID" />
                    
                    <%--<f:TemplateField HeaderText="排序" Width="100px">
                        <ItemTemplate>
                            <asp:TextBox ID="tbSort" runat="server" Width="50px" Text='<%# Eval("Sort") %>' AutoPostBack="false"></asp:TextBox>
                        </ItemTemplate>
                    </f:TemplateField>--%>
                    <f:BoundField Width="180px" DataField="Name" DataFormatString="{0}" DataSimulateTreeLevelField="Depth" HeaderText="部门名称" />
                    <%--<f:BoundField Width="180px" DataField="Name" DataFormatString="{0}" HeaderText="" />--%>
                    <f:BoundField Width="180px" DataField="ParentId" DataFormatString="{0}" HeaderText="父ID" />
                    <f:BoundField Width="180px" DataField="Sort" DataFormatString="{0}" HeaderText="排序" />
                    <f:BoundField Width="180px" DataField="Depth" DataFormatString="{0}" HeaderText="深度" />
                    <f:BoundField Width="180px" DataField="Manager_Id" DataFormatString="{0}" HeaderText="修改人" />
                    <f:BoundField Width="180px" DataField="Manager_CName" DataFormatString="{0}" HeaderText="修改人姓名" />
                    <f:BoundField Width="180px" DataField="UpdateDate" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="更新时间" />

                   <%-- <f:LinkButtonField HeaderText="是否显示" Icon="BulletCross" TextAlign="Center" ToolTip="点击修改是否显示" ColumnID="IsDisplay" CommandName="IsDisplay" />
                    <f:LinkButtonField HeaderText="是否页面" Icon="BulletCross" TextAlign="Center" ToolTip="点击修改是否页面" ColumnID="IsMenu" CommandName="IsMenu" />
                    <f:BoundField DataField="Depth" HeaderText="级别层次" TextAlign="Center" />
                    <f:LinkButtonField HeaderText="操作" TextAlign="Center" ToolTip="点击修改当前记录" ColumnID="ButtonEdit" CommandName="ButtonEdit" />--%>
                </Columns>
            </f:Grid>
            <f:Label runat="server" ID="lblSpendingTime" Text=""></f:Label>
            <f:HiddenField runat="server" ID="SortColumn" Text="Id"></f:HiddenField>
        </items>
    </f:panel>
    <f:window id="Window1" width="480px" height="340px" icon="TagBlue" title="编辑" hidden="True" Target="Parent"
        enablemaximize="True" closeaction="HidePostBack" onclose="Window1_Close" enablecollapse="true"
        runat="server" enableresize="true" bodypadding="5px" enableframe="True" iframeurl="about:blank"
        enableiframe="true" enableclose="true" ismodal="True" >
    </f:window>

   <%-- plain="false" --%>

    </form>
</body>
</html>
