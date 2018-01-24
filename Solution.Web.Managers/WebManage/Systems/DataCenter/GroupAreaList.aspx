﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupAreaList.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.DataCenter.GroupAreaList" %>

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
                    <f:Button ID="ButtonSaveAutoSort" runat="server" Text="自动排序" Icon="ArrowJoin" OnClick="ButtonSaveAutoSort_Click" ConfirmTitle="自动排序提示" ConfirmText="是否对所有数据进行自动排序？"></f:Button>
                    <f:Button ID="ButtonSaveSort" runat="server" Text="保存排序" Icon="Disk" OnClick="ButtonSaveSort_Click"></f:Button>
                    <f:Button ID="ButtonDelete" runat="server" Text="删除" Icon="Delete" OnClick="ButtonDelete_Click" ConfirmTitle="删除提示" ConfirmText="是否删除记录？" 
                        OnClientClick="if (!F('Panel1_Grid1').getSelectionModel().hasSelection() ) { F.alert('删除时必须选择一条将要删除的记录！'); return false; }  if (F('Panel1_Grid1').getSelectionModel().getCount() >= 2) { F.alert('只能选择一条记录进行删除！');return false; }">
                    </f:Button>

                   <%-- <f:Button ID="ButtonMenuInfo" runat="server" Text="菜单权限分配" Icon="LayoutSidebar" OnClick="ButtonMenuInfo_Click"></f:Button>
                    <f:Button ID="ButtonPagePower" runat="server" Text="页面权限分配" Icon="LayoutSidebar" OnClick="ButtonPagePower_Click"></f:Button>--%>

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
            <f:Grid ID="Grid1" Title="集团区域管理" EnableFrame="false" EnableCollapse="true" AllowSorting="true" SortField="Depth" SortDirection="ASC" 
            PageSize="15" ShowBorder="true" ShowHeader="true" AllowPaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id" EnableColumnLines="true"
           >  <%-- OnPageIndexChange="Grid1_PageIndexChange"  OnRowCommand="Grid1_RowCommand" OnPreRowDataBound="Grid1_PreRowDataBound"--%>  
                <Columns>
                    <f:RowNumberField />
                    <f:BoundField Width="180px" DataField="AREA_ID" DataFormatString="{0}" HeaderText="区域Id" />
                 
                   <%-- <f:TemplateField HeaderText="排序" Width="100px">
                        <ItemTemplate>
                            <asp:TextBox ID="tbSort" runat="server" Width="50px" Text='<%# Eval("Sort") %>' AutoPostBack="false"></asp:TextBox>
                        </ItemTemplate>
                    </f:TemplateField>--%>

                    <f:BoundField Width="180px" DataField="AREA_NAME" DataFormatString="{0}" HeaderText="区域名称" />
                    <f:BoundField Width="180px" DataField="AREA_ADD" DataFormatString="{0}" HeaderText="区域地址" />
                    <f:BoundField Width="180px" DataField="AREA_TEL" DataFormatString="{0}" HeaderText="区域电话" />
                    <f:BoundField Width="180px" DataField="AREA_EMAIL" DataFormatString="{0}" HeaderText="区域邮件" />
                    <f:BoundField Width="180px" DataField="AREA_CONTECT" DataFormatString="{0}" HeaderText="区域负责人" />
                    <f:BoundField Width="180px" DataField="AREA_MEMO" DataFormatString="{0}" HeaderText="区域备注" />
                    <f:BoundField Width="180px" DataField="AREA_STATUS" DataFormatString="{0}" HeaderText="区域状态" />
                    <f:BoundField Width="180px" DataField="CRT_DATETIME" DataFormatString="{0}" HeaderText="建档日期" />
                    <f:BoundField Width="180px" DataField="CRT_USER_ID" DataFormatString="{0}" HeaderText="建档人员" />
                    <f:BoundField Width="180px" DataField="MOD_DATETIME" DataFormatString="{0}" HeaderText="修改日期" />
                    <f:BoundField Width="180px" DataField="MOD_USER_ID" DataFormatString="{0}" HeaderText="修改人员" />
                    <f:BoundField Width="180px" DataField="LAST_UPDATE" DataFormatString="{0}" HeaderText="最后异动时间" />
                    <f:BoundField Width="180px" DataField="STATUS" DataFormatString="{0}" HeaderText="手动传输状态" />

           
                   <%-- <f:LinkButtonField HeaderText="是否显示" Icon="BulletCross" TextAlign="Center" ToolTip="点击修改是否显示" ColumnID="IsDisplay" CommandName="IsDisplay" />
                    <f:LinkButtonField HeaderText="是否页面" Icon="BulletCross" TextAlign="Center" ToolTip="点击修改是否页面" ColumnID="IsMenu" CommandName="IsMenu" />
                    <f:BoundField DataField="Depth" HeaderText="级别层次" TextAlign="Center" />
                    <f:LinkButtonField HeaderText="操作" TextAlign="Center" ToolTip="点击修改当前记录" ColumnID="ButtonEdit" CommandName="ButtonEdit" />--%>
                </Columns>
            </f:Grid>
           <%-- <f:Label runat="server" ID="lblSpendingTime" Text=""></f:Label>
            <f:HiddenField runat="server" ID="SortColumn" Text="Id"></f:HiddenField>--%>
        </items>
    </f:panel>
    <f:window id="Window1" width="1200px" height="650px" icon="TagBlue" title="编辑" hidden="True" Target="Parent"
        enablemaximize="True" closeaction="HidePostBack" onclose="Window1_Close" enablecollapse="true"
        runat="server" enableresize="true" bodypadding="5px" enableframe="True" iframeurl="about:blank"
        enableiframe="true" enableclose="true" ismodal="True" >
    </f:window>

   <%-- plain="false" --%>

    </form>
</body>
</html>
