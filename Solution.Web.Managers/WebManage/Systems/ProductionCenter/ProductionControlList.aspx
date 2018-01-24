<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionControlList.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.ProductionCenter.ProductionControlList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

</head>
<body>
   <form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server" AutoSizePanelID="Grid1" />

            <f:Grid ID="Grid1" Title="生产计划" EnableFrame="false" EnableCollapse="true" AllowSorting="true"  
            ShowBorder="false" ShowHeader="false" AllowPaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id" EnableColumnLines="true"
           OnRowCommand="Grid1_RowCommand" OnPreRowDataBound="Grid1_PreRowDataBound" OnPageIndexChange="Grid1_PageIndexChange">  <%--PageSize="15"    --%>  
               
                <toolbars>
                
                    <f:Toolbar ID="toolBar1" runat="server"  >   <%--Position="Left"--%>
                       
                        <Items>
                          <f:Panel ID="panl1" runat="server" ShowHeader="false" ShowBorder="false" Width="800px" BodyStyle="background-color:transparent;">
                            <Toolbars>
                               <f:Toolbar ID="toolBar" runat="server" Width="800px"  >
                                   <Items>
                                         <f:Button ID="ButtonRefresh" runat="server" Text="刷新" Icon="ArrowRefresh" OnClick="ButtonRefresh_Click" CssClass="inline btnf"></f:Button>
                                        <f:Button ID="ButtonAdd" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click" CssClass="btnf"></f:Button>
                                        <f:Button ID="ButtonSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="ButtonSearch_Click" CssClass="btnf"></f:Button>
                                        <f:Button ID="ButtonEdit" runat="server" Text="编辑" Icon="BulletEdit" OnClick="ButtonEdit_Click" CssClass="btnf"
                                            OnClientClick="if(!F('Grid1').getSelectionModel().hasSelection()|| F('Grid1').getSelectionModel().getCount()>=2){F.alert('您没有选择编辑项或只能选择一项进行编辑！'); return false; }">
                                       </f:Button> 
                                        <f:Button ID="ButtonSaveAutoSort" runat="server" Text="自动排序" Icon="ArrowJoin" CssClass="btnf" OnClick="ButtonSaveAutoSort_Click" ConfirmTitle="自动排序提示" ConfirmText="是否对所有数据进行自动排序？"></f:Button>
                                        <f:Button ID="ButtonSaveSort" runat="server" Text="保存排序" Icon="Disk" OnClick="ButtonSaveSort_Click" CssClass="btnf"></f:Button>
                                        <f:Button ID="ButtonDelete" runat="server" Text="删除" Icon="Delete" CssClass="btnf" OnClick="ButtonDelete_Click" ConfirmTitle="删除提示" ConfirmText="是否删除记录？" 
                                            OnClientClick="if (!F('Grid1').getSelectionModel().hasSelection() ) { F.alert('删除时必须选择一条将要删除的记录！'); return false; }  if (F('Grid1').getSelectionModel().getCount() >= 2) { F.alert('只能选择一条记录进行删除！');return false; }">
                                        </f:Button>

                           <%-- <f:Button ID="ButtonMenuInfo" runat="server" Text="菜单权限分配" Icon="LayoutSidebar" OnClick="ButtonMenuInfo_Click"></f:Button>
                            <f:Button ID="ButtonPagePower" runat="server" Text="页面权限分配" Icon="LayoutSidebar" OnClick="ButtonPagePower_Click"></f:Button>--%>
                             
                                   </Items>
                               
                               </f:Toolbar>
                            </Toolbars>
                             <Items>
                             
                                  <f:Form ID="Form5" LabelAlign="Left"  LabelWidth="70px" Width="700px" 
                                        runat="server" Title="表单" ShowBorder="false" ShowHeader="false"  >
                                      <Rows>
                                        <f:FormRow >
                                            <Items>
                                                <f:TextBox runat="server" Label="商品编码" ID="cPROD_ID" Width="250px"  ></f:TextBox>
                                                <f:TextBox runat="server" Label="商品名称" ID="cPROD_NAME" Width="250px" ></f:TextBox>
                                       
                                            </Items>
                                        </f:FormRow>
                                        <f:FormRow >
                                            <Items>
                                                    <f:DropDownList Label="商品小类" runat="server" ID="cPROD_CATE" Width="250px" ></f:DropDownList>
                                                    <f:DropDownList Label="隶属部门" runat="server" ID="cPROD_TYPE" Width="250px" ></f:DropDownList>
                                         
                                            </Items>
                                        </f:FormRow>
                                            <f:FormRow>
                                            <Items>
                                                    <f:DropDownList Label="商品类别" runat="server" ID="cPROD_DEP" Width="250px" ></f:DropDownList>
                                                    <f:DropDownList Label="商品性质" runat="server" ID="DropDownList1" Width="250px" ></f:DropDownList>
                                            </Items>
                                 
                                        </f:FormRow>

                                </Rows>
                                </f:Form>
                             
                             </Items>
                          
                            </f:Panel>
                             
                        </Items>
                    </f:Toolbar>
       
                </toolbars>
     
                <Columns>
                    <f:RowNumberField  />
                   
                   <%-- <f:TemplateField HeaderText="排序" Width="100px">
                        <ItemTemplate>
                            <asp:TextBox ID="tbSort" runat="server" Width="50px" Text='<%# Eval("Sort") %>' AutoPostBack="false"></asp:TextBox>
                        </ItemTemplate>
                    </f:TemplateField>--%>
                    <f:BoundField Width="180px" DataField="SHOP_ID" DataFormatString="{0}" HeaderText="分店编号" />
                    <f:BoundField Width="180px" DataField="PLAN_ID" DataFormatString="{0}" HeaderText="计划单号" />
                    <f:BoundField Width="180px" DataField="STATUS" DataFormatString="{0}" HeaderText="单据状态" />
                    <f:BoundField Width="180px" DataField="INPUT_DATE" DataFormatString="{0}" HeaderText="单据日期" />
                    <f:BoundField Width="180px" DataField="USER_ID" DataFormatString="{0}" HeaderText="制单人" />
                    <f:BoundField Width="180px" DataField="APP_USER" DataFormatString="{0}" HeaderText="审核人" />
                    <f:BoundField Width="180px" DataField="APP_DATETIME" DataFormatString="{0}" HeaderText="审核时间" />
                    <f:BoundField Width="180px" DataField="EXPECT_DATE" DataFormatString="{0}" HeaderText="期望日期" />
                    <f:BoundField Width="180px" DataField="PREPARE_ID" DataFormatString="{0}" HeaderText="备料单号" />
                    <f:BoundField Width="180px" DataField="EXPORTED" DataFormatString="{0}" HeaderText="引入标记" />
                    <f:BoundField Width="180px" DataField="EXPORTED_ID" DataFormatString="{0}" HeaderText="引入单号" />
                    <f:BoundField Width="180px" DataField="DIV_ID" DataFormatString="{0}" HeaderText="生产部门" />
                    <f:BoundField Width="180px" DataField="STOCK_ID" DataFormatString="{0}" HeaderText="仓库编号" />
                    <f:BoundField Width="180px" DataField="Memo" DataFormatString="{0}" HeaderText="备注" />

                    <f:BoundField Width="180px" DataField="LOCKED" DataFormatString="{0}" HeaderText="月结锁定" />
                    <f:BoundField Width="180px" DataField="CRT_DATETIME" DataFormatString="{0}" HeaderText="建档日期" />
                    <f:BoundField Width="180px" DataField="CRT_USER_ID" DataFormatString="{0}" HeaderText="建档人员" />
                    <f:BoundField Width="180px" DataField="MOD_DATETIME" DataFormatString="{0}" HeaderText="修改日期" />
                    <f:BoundField Width="180px" DataField="MOD_USER_ID" DataFormatString="{0}" HeaderText="修改人员" />
                    <f:BoundField Width="180px" DataField="LAST_UPDATE" DataFormatString="{0}" HeaderText="最后异动时间" />
                    <f:BoundField Width="180px" DataField="Trans_STATUS" DataFormatString="{0}" HeaderText="传输状态" />
           
                   <%-- <f:LinkButtonField HeaderText="是否显示" Icon="BulletCross" TextAlign="Center" ToolTip="点击修改是否显示" ColumnID="IsDisplay" CommandName="IsDisplay" />
                    <f:LinkButtonField HeaderText="是否页面" Icon="BulletCross" TextAlign="Center" ToolTip="点击修改是否页面" ColumnID="IsMenu" CommandName="IsMenu" />
                    <f:BoundField DataField="Depth" HeaderText="级别层次" TextAlign="Center" />
                    <f:LinkButtonField HeaderText="操作" TextAlign="Center" ToolTip="点击修改当前记录" ColumnID="ButtonEdit" CommandName="ButtonEdit" />--%>
                </Columns>
            </f:Grid>
           <%-- <f:Label runat="server" ID="lblSpendingTime" Text=""></f:Label>
            <f:HiddenField runat="server" ID="SortColumn" Text="Id"></f:HiddenField>--%>
  
    <f:window id="Window1" width="1200px" height="650px" icon="TagBlue" title="编辑" hidden="True" Target="Parent"
        enablemaximize="True" closeaction="HidePostBack" onclose="Window1_Close" enablecollapse="true"
        runat="server" enableresize="true" bodypadding="5px" enableframe="True" iframeurl="about:blank"
        enableiframe="true" enableclose="true" ismodal="True" >
    </f:window>

   <%-- plain="false" --%>

    </form>
</body>
</html>
