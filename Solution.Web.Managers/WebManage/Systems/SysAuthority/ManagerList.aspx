<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerList.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SysAuthority.ManagerList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <style type="text/css">
        .grid-scroll{
                  overflow-x:scroll;
                     
                     }
    
    
    </style>

</head>
<body>
   <form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server" AutoSizePanelID="Grid1"/>  <%-- --%>

 
    <%--<f:panel id="Panel1" runat="server" title="用户管理" enableframe="false" bodypadding="10px"
        enablecollapse="True">
         
        <items>--%>
             <%--<f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" EnableFrame="false" EnableCollapse="true"
                ShowBorder="True" ShowHeader="False">
                <Items>
                    <f:DropDownList Label="菜单选择" runat="server" ID="ddlParentId" Width="250px"></f:DropDownList>
                </Items>
            </f:SimpleForm>--%>
            <f:Grid ID="Grid1" Title="用户管理" EnableFrame="false" EnableCollapse="true" AllowSorting="true" SortField="Depth" SortDirection="ASC" 
            PageSize="15" ShowBorder="true" ShowHeader="true" AllowPaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id" EnableColumnLines="true"
           OnPageIndexChange="Grid1_PageIndexChange"  OnRowCommand="Grid1_RowCommand" OnPreRowDataBound="Grid1_PreRowDataBound">  <%-- --%>  
                <Toolbars>
                    <f:Toolbar ID="toolBar" runat="server">
                    <Items>
                        <f:Button ID="ButtonRefresh" runat="server" Text="刷新" Icon="ArrowRefresh" OnClick="ButtonRefresh_Click" CssClass="inline"></f:Button>
                        <f:Button ID="ButtonAdd" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click"></f:Button>
                        <f:Button ID="ButtonSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="ButtonSearch_Click"></f:Button>
                        <f:Button ID="ButtonEdit" runat="server" Text="编辑" Icon="BulletEdit" OnClick="ButtonEdit_Click"
                            OnClientClick="if(!F('Grid1').getSelectionModel().hasSelection()|| F('Grid1').getSelectionModel().getCount()>=2){F.alert('您没有选择编辑项或只能选择一项进行编辑！'); return false; }">
                       </f:Button>   <%--Panel1_  Panel1_--%>
                        <f:Button ID="ButtonSaveAutoSort" runat="server" Text="自动排序" Icon="ArrowJoin" OnClick="ButtonSaveAutoSort_Click" ConfirmTitle="自动排序提示" ConfirmText="是否对所有数据进行自动排序？"></f:Button>
                        <f:Button ID="ButtonSaveSort" runat="server" Text="保存排序" Icon="Disk" OnClick="ButtonSaveSort_Click"></f:Button>
                        <f:Button ID="ButtonDelete" runat="server" Text="删除" Icon="Delete" OnClick="ButtonDelete_Click" ConfirmTitle="删除提示" ConfirmText="是否删除记录？" 
                            OnClientClick="if (!F('Panel1_Grid1').getSelectionModel().hasSelection() ) { F.alert('删除时必须选择一条将要删除的记录！'); return false; }  if (F('Panel1_Grid1').getSelectionModel().getCount() >= 2) { F.alert('只能选择一条记录进行删除！');return false; }">
                        </f:Button>

                          <f:Label runat="server" ID="lblSpendingTime" Text=""></f:Label>
                         <f:HiddenField runat="server" ID="SortColumn" Text="Id"></f:HiddenField>
                  </Items>
              </f:Toolbar>
                </Toolbars>
                <Columns>
                    <f:RowNumberField />
                     
                    <%--<f:TemplateField HeaderText="排序" Width="100px">
                        <ItemTemplate>
                            <asp:TextBox ID="tbSort" runat="server" Width="50px" Text='<%# Eval("Sort") %>' AutoPostBack="false"></asp:TextBox>
                        </ItemTemplate>
                    </f:TemplateField>--%>
                    <f:BoundField Width="180px" DataField="LoginName" DataFormatString="{0}" HeaderText="登陆名称" />
                    <f:BoundField Width="180px" DataField="SHOP_ID" DataFormatString="{0}" HeaderText="部门编码" />
                    <f:BoundField Width="180px" DataField="SHOP_NAME1" DataFormatString="{0}" HeaderText="部门名称" />
                    <%--<f:BoundField Width="180px" DataField="Name" DataFormatString="{0}" HeaderText="" />--%>
                    <f:BoundField Width="180px" DataField="LoginTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="登陆时间" />
                    <f:BoundField Width="180px" DataField="LoginIp" DataFormatString="{0}" HeaderText="登陆IP" />
                    <f:BoundField Width="180px" DataField="LoginCount" DataFormatString="{0}" HeaderText="登陆次数" />
                    <f:BoundField Width="180px" DataField="CreateTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="创建时间" />
                    <f:BoundField Width="180px" DataField="UpdateTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="更新时间" />
                    <f:BoundField Width="180px" DataField="IsMultiUser" DataFormatString="{0}" HeaderText="是否同登陆" />

                     <f:BoundField Width="180px" DataField="Branch_Name" DataFormatString="{0}" HeaderText="部门名称" />
                     <f:BoundField Width="180px" DataField="Position_Name" DataFormatString="{0}" HeaderText="职位名称" />
                     <f:BoundField Width="180px" DataField="IsWork" DataFormatString="{0}" HeaderText="是否在职" />
                     <f:BoundField Width="180px" DataField="IsEnable" DataFormatString="{0}" HeaderText="是否启用" />
                     <f:BoundField Width="180px" DataField="CName" DataFormatString="{0}" HeaderText="中文名称" />
                     <f:BoundField Width="180px" DataField="EName" DataFormatString="{0}" HeaderText="英文名称" />
                     <f:BoundField Width="180px" DataField="PhotoImg" DataFormatString="{0}" HeaderText="照片" />
                     <f:BoundField Width="180px" DataField="Sex" DataFormatString="{0}" HeaderText="性别" />
                     <f:BoundField Width="180px" DataField="Birthday" DataFormatString="{0}" HeaderText="生日" />
                     <f:BoundField Width="180px" DataField="NativePlace" DataFormatString="{0}" HeaderText="籍贯" />
                     <f:BoundField Width="180px" DataField="NationalName" DataFormatString="{0}" HeaderText="民族" />
                     <f:BoundField Width="180px" DataField="Record" DataFormatString="{0}" HeaderText="学历" />
                     <f:BoundField Width="180px" DataField="GraduateCollege" DataFormatString="{0}" HeaderText="毕业" />
                     <f:BoundField Width="180px" DataField="GraduateSpecialty" DataFormatString="{0}" HeaderText="专业" />
                     <f:BoundField Width="180px" DataField="Tel" DataFormatString="{0}" HeaderText="座机" />
                     <f:BoundField Width="180px" DataField="Mobile" DataFormatString="{0}" HeaderText="手机" />
                     <f:BoundField Width="180px" DataField="Email" DataFormatString="{0}" HeaderText="邮件" />
                     <f:BoundField Width="180px" DataField="Qq" DataFormatString="{0}" HeaderText="QQ" />
                     <f:BoundField Width="180px" DataField="Address" DataFormatString="{0}" HeaderText="地址" />
                     <f:BoundField Width="180px" DataField="Manager_CName" DataFormatString="{0}" HeaderText="修改人" />
                      

                   <%-- <f:LinkButtonField HeaderText="是否显示" Icon="BulletCross" TextAlign="Center" ToolTip="点击修改是否显示" ColumnID="IsDisplay" CommandName="IsDisplay" />
                    <f:LinkButtonField HeaderText="是否页面" Icon="BulletCross" TextAlign="Center" ToolTip="点击修改是否页面" ColumnID="IsMenu" CommandName="IsMenu" />
                    <f:BoundField DataField="Depth" HeaderText="级别层次" TextAlign="Center" />
                    <f:LinkButtonField HeaderText="操作" TextAlign="Center" ToolTip="点击修改当前记录" ColumnID="ButtonEdit" CommandName="ButtonEdit" />--%>
                </Columns>
                
                
            </f:Grid>
  <%--         
        </items>
    </f:panel>--%>

 

 


    <f:window id="Window1" width="530px" height="700px" icon="TagBlue" title="编辑" hidden="True" Target="Parent"
        enablemaximize="True" closeaction="HidePostBack" onclose="Window1_Close" enablecollapse="true"
        runat="server" enableresize="true" bodypadding="5px" enableframe="True" iframeurl="about:blank"
        enableiframe="true" enableclose="true" ismodal="True" >
    </f:window>

   <%-- plain="false" --%>

    </form>
</body>
</html>
