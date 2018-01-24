<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersList1.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SupplyCenter.OrdersList1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

</head>
<body>
   <form id="form1" runat="server">
       <f:PageManager ID="PageManager1" runat="server"  AutoSizePanelID="panel1" ></f:PageManager>
    <%--<f:pagemanager id="PageManager1" runat="server" AutoSizePanelID="panel1" />--%>
            <f:Panel ID="panel1" runat="server" ShowBorder="false" ShowHeader="false" Layout="Region">
                <Items>
            <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="center" Layout="Fit" Title="订单信息" ShowBorder="true" ShowHeader="true" AutoScroll="true">
                    <Items>
         <f:Grid ID="Grid1" Title="订单中心" EnableFrame="false" EnableCollapse="true" AllowSorting="true"  AutoScroll="true"
            ShowBorder="false" ShowHeader="false" AllowPaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="ORDER_ID" EnableColumnLines="true"
           OnRowCommand="Grid1_RowCommand" OnPreRowDataBound="Grid1_PreRowDataBound" OnPageIndexChange="Grid1_PageIndexChange" 
           EnableMultiSelect="false" EnableRowSelectEvent="true" OnRowSelect="Grid1_RowSelect" >  <%--PageSize="15"    --%>  
               
                <toolbars>
                     <f:Toolbar ID="toolBar1" runat="server" >   <%--Position="Left"--%>
                       
                        <Items>
                          <f:Panel ID="panl1" runat="server" ShowHeader="false" ShowBorder="false" Width="800px" BodyStyle="background-color:transparent;">
                            <Toolbars>
                               <f:Toolbar ID="toolBar" runat="server" Width="800px"  >
                                   <Items>
                                         <f:Button ID="ButtonRefresh" runat="server" Text="刷新" Icon="ArrowRefresh" OnClick="ButtonRefresh_Click" CssClass="inline btnf"></f:Button>
                                        <f:Button ID="ButtonAdd" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click" CssClass="btnf"></f:Button>
                                        <f:Button ID="ButtonSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="ButtonSearch_Click" CssClass="btnf"></f:Button>
                                        <f:Button ID="ButtonEdit" runat="server" Text="编辑" Icon="BulletEdit" OnClick="ButtonEdit_Click" CssClass="btnf"
                                            OnClientClick="if(!F('panel1_panelCenterRegion_Grid1').getSelectionModel().hasSelection()|| F('panel1_panelCenterRegion_Grid1').getSelectionModel().getCount()>=2){F.alert('您没有选择编辑项或只能选择一项进行编辑！'); return false; }">
                                       </f:Button> 
                                       <%-- <f:Button ID="ButtonSaveAutoSort" runat="server" Text="自动排序" Icon="ArrowJoin" CssClass="btnf" OnClick="ButtonSaveAutoSort_Click" ConfirmTitle="自动排序提示" ConfirmText="是否对所有数据进行自动排序？"></f:Button>
                                        <f:Button ID="ButtonSaveSort" runat="server" Text="保存排序" Icon="Disk" OnClick="ButtonSaveSort_Click" CssClass="btnf"></f:Button>--%>
                                        <f:Button ID="ButtonDelete" runat="server" Text="删除" Icon="Delete" CssClass="btnf" OnClick="ButtonDelete_Click" ConfirmTitle="删除提示" ConfirmText="是否删除记录？" 
                                            OnClientClick="if (!F('Grid1').getSelectionModel().hasSelection() ) { F.alert('删除时必须选择一条将要删除的记录！'); return false; }  if (F('Grid1').getSelectionModel().getCount() >= 2) { F.alert('只能选择一条记录进行删除！');return false; }">
                                        </f:Button>

                           <%-- <f:Button ID="ButtonMenuInfo" runat="server" Text="菜单权限分配" Icon="LayoutSidebar" OnClick="ButtonMenuInfo_Click"></f:Button>
                            <f:Button ID="ButtonPagePower" runat="server" Text="页面权限分配" Icon="LayoutSidebar" OnClick="ButtonPagePower_Click"></f:Button>--%>
                             
                                   </Items>
                               
                               </f:Toolbar>
                            </Toolbars>
                             <%--<Items>
                             
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
                             
                             </Items>--%>
                          
                            </f:Panel>
                             
                        </Items>
                    </f:Toolbar>
                </toolbars>
     
                <Columns>
                  
                   <%-- <f:TemplateField HeaderText="排序" Width="100px">
                        <ItemTemplate>
                            <asp:TextBox ID="tbSort" runat="server" Width="50px" Text='<%# Eval("Sort") %>' AutoPostBack="false"></asp:TextBox>
                        </ItemTemplate>
                    </f:TemplateField>--%>
                     <f:BoundField Width="100px" DataField="ORDER_ID" DataFormatString="{0}" HeaderText="订单编号" />
                    <%--<f:BoundField Width="60px" ColumnID="SHOP_Name1" DataFormatString="{0}" HeaderText="" />--%>
                     <f:TemplateField HeaderText="分店名称" Width="130px">
                        <ItemTemplate>
                             <f:Label ID="SHOP_Name1" runat="server" />
                        </ItemTemplate>
                    </f:TemplateField>
                    <%--<f:BoundField Width="160px" DataField="INPUT_DATE" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="单据日期" />--%>
                    <%--<f:BoundField Width="50px" DataField="ORD_USER" DataFormatString="{0}" HeaderText="制单人员" />--%>
                    <f:BoundField Width="160px" DataField="EXPECT_DATE" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="期望日期" />
                    <f:BoundField Width="50px" DataField="STATUS" DataFormatString="{0}" HeaderText="单据状态" />
                    <f:BoundField Width="60px" DataField="SHOP_ID" DataFormatString="{0}" HeaderText="分店编号" />
                    <%--<f:BoundField Width="50px" DataField="ORD_TYPE" DataFormatString="{0}" HeaderText="订单类型" />
                    <f:BoundField Width="50px" DataField="OUT_SHOP" DataFormatString="{0}" HeaderText="供货分店" />
                    <f:BoundField Width="50px" DataField="EXPORTED_ID" DataFormatString="{0}" HeaderText="汇出单据" />
                    <f:BoundField Width="50px" DataField="EXPORTED" DataFormatString="{0}" HeaderText="汇出标记" />
                    <f:BoundField Width="50px" DataField="APP_USER" DataFormatString="{0}" HeaderText="核准人员" />
                    <f:BoundField Width="160px" DataField="APP_DATE" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="核准日期" />
                    <f:BoundField Width="50px" DataField="Memo" DataFormatString="{0}" HeaderText="备注" />
                    <f:BoundField Width="50px" DataField="LOCKED" DataFormatString="{0}" HeaderText="月结锁定" />
                    <f:BoundField Width="50px" DataField="ORD_DEP_ID" DataFormatString="{0}" HeaderText="订货部门" />
                    <f:BoundField Width="160px" DataField="CRT_DATETIME" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="建档日期" />
                    <f:BoundField Width="50px" DataField="CRT_USER_ID" DataFormatString="{0}" HeaderText="建档人员" />
                    <f:BoundField Width="160px" DataField="MOD_DATETIME" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="修改日期" />
                    <f:BoundField Width="50px" DataField="MOD_USER_ID" DataFormatString="{0}" HeaderText="修改人员" />
                    <f:BoundField Width="160px" DataField="LAST_UPDATE" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="最后异动时间" />
                    <f:BoundField Width="50px" DataField="Trans_STATUS" DataFormatString="{0}" HeaderText="传输状态" />--%>
                    
                    

                   <%-- <f:LinkButtonField HeaderText="是否显示" Icon="BulletCross" TextAlign="Center" ToolTip="点击修改是否显示" ColumnID="IsDisplay" CommandName="IsDisplay" />
                    <f:LinkButtonField HeaderText="是否页面" Icon="BulletCross" TextAlign="Center" ToolTip="点击修改是否页面" ColumnID="IsMenu" CommandName="IsMenu" />
                    <f:BoundField DataField="Depth" HeaderText="级别层次" TextAlign="Center" />
                    <f:LinkButtonField HeaderText="操作" TextAlign="Center" ToolTip="点击修改当前记录" ColumnID="ButtonEdit" CommandName="ButtonEdit" />--%>
                </Columns>
            </f:Grid>
                    </Items>
                </f:Panel>
                <f:Panel runat="server" ID="panelRightRegion" RegionPosition="Right" RegionSplit="true" EnableCollapse="true" Layout="Fit" Width="900px"
                    Title="商品信息" ShowBorder="true" ShowHeader="true" >  <%-- --%>
                    <Items>
                         <f:Grid ID="Grid2" Title="商品信息" EnableFrame="false" EnableCollapse="true" AutoScroll="true" 
            ShowBorder="false" ShowHeader="false" AllowPaging="true" AllowCellEditing="true" runat="server" EnableColumnLines="true" EnableRowSelectEvent="true" OnRowSelect="Grid2_RowSelect"
           >  <%--PageSize="15" DataKeyNames="SNo"   EnableCheckBoxSelect="True"   OnRowCommand="Grid1_RowCommand" OnPreRowDataBound="Grid1_PreRowDataBound" OnPageIndexChange="Grid1_PageIndexChange"--%>  
               
                <toolbars>
                     <f:Toolbar ID="toolBar2" runat="server" >   <%--Position="Left"--%>
                       
                        <Items>
                          <f:Panel ID="Panel2" runat="server" ShowHeader="false" ShowBorder="false" BodyStyle="background-color:transparent;">
                            <Toolbars>
                               <f:Toolbar ID="toolBar3" runat="server" Width="575px"  >
                                   <Items>
                                          
                                        <f:Button ID="btnAddProd" runat="server" Text="添加" Icon="Add" OnClick="btnAddProd_Click" CssClass="btnf"></f:Button>
                                        <f:Button ID="btnSearchProd" runat="server" Text="查询" Icon="Magnifier" OnClick="btnSearchProd_Click" CssClass="btnf"></f:Button>
                                        <f:Button ID="btnEditProd" runat="server" Text="编辑" Icon="BulletEdit" OnClick="btnEditProd_Click" CssClass="btnf"
                                            OnClientClick="if(!F('panel1_panelRightRegion_Grid2').getSelectionModel().hasSelection()|| F('panel1_panelRightRegion_Grid2').getSelectionModel().getCount()>=2){F.alert('您没有选择编辑项或只能选择一项进行编辑！'); return false; }">
                                       </f:Button> 
                                        
                                        <f:Button ID="btnDeleteProd" runat="server" Text="删除" Icon="Delete" CssClass="btnf" OnClick="btnDeleteProd_Click" ConfirmTitle="删除提示" ConfirmText="是否删除记录？" 
                                            OnClientClick="if (!F('panel1_panelRightRegion_Grid2').getSelectionModel().hasSelection() ) { F.alert('删除时必须选择一条将要删除的记录！'); return false; }  if (F('panel1_panelRightRegion_Grid2').getSelectionModel().getCount() >= 2) { F.alert('只能选择一条记录进行删除！');return false; }">
                                        </f:Button>

                           <%-- <f:Button ID="ButtonMenuInfo" runat="server" Text="菜单权限分配" Icon="LayoutSidebar" OnClick="ButtonMenuInfo_Click"></f:Button>
                            <f:Button ID="ButtonPagePower" runat="server" Text="页面权限分配" Icon="LayoutSidebar" OnClick="ButtonPagePower_Click"></f:Button>--%>
                             
                                   </Items>
                               
                               </f:Toolbar>
                            </Toolbars>
                             <Items>
                             
                                  <f:Form ID="Form2" LabelAlign="right"  LabelWidth="100px" Width="850px" BodyPadding="5px"
                                        runat="server" Title="表单" ShowBorder="false" ShowHeader="false"  >
                                      <Rows> <%----%> 
                                        <f:FormRow>
                                            <Items>
                            
                                                 <f:DropDownList ID="ddlPROD_NAME1" runat="server" Label="商品名称"  AutoPostBack="true" Required="true" Width="200px" OnSelectedIndexChanged="ddlPROD_NAME1_SelectedIndexChanged">
                                                  <%--OnSelectedIndexChanged="ddlPROD_NAME2_SelectedIndexChanged"--%>
                                                </f:DropDownList>
                
                                                <f:TextBox ID="txtPROD_ID" Required="true" runat="server" Label="商品编号" Enabled="false"  Width="200px">
                                                </f:TextBox>
                 
                                                <f:TextBox ID="txtPROD_SPEC" Required="true" runat="server" Label="商品规格" Enabled="false" Width="200px">
                                                </f:TextBox>
               
                                                <f:TextBox ID="txtPROD_UNIT" Required="true" runat="server" Label="商品单位" Enabled="false" Width="200px">
                                                </f:TextBox>
 
                                            </Items>
                                        </f:FormRow>
                                         <f:FormRow>
                                             <Items>
                                                    <f:TextBox ID="txtON_QUAN" Required="true" runat="server" Label="数量" AutoPostBack="true"  Width="200px" OnTextChanged="txtON_QUAN_TextChanged">
                                                    </f:TextBox>

                                                    <f:TextBox ID="txtU_Cost" Required="true" runat="server" Label="单价" Enabled="false"  Width="200px">
                                                    </f:TextBox>

                                                    <f:TextBox ID="txtTotal" Required="true" runat="server" Label="小计" Enabled="false" Width="200px">
                                                    </f:TextBox>
                 
                                                    <f:TextBox ID="txtOrder_QUAN" Required="true" runat="server" Label="最小订货量" Enabled="false"  Width="200px">
                                                    </f:TextBox>
              
                                                    
                                             
                                             </Items>
                                         </f:FormRow>
                                         <f:FormRow>
                                              <Items>
                                                  <f:TextBox ID="txtMemo" Required="true" runat="server" Label="备注" Width="200px">
                                                    </f:TextBox>
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
                    <%--/// SNo PROD_ID PROD_NAME2 PROD_SPEC PROD_UNIT U_Cost Order_QUAN Memo--%>
               <%-- <f:BoundField ColumnID="PROD_NAME2" DataField="PROD_NAME2" FieldType="String"
                    HeaderText="商品名称" />--%>
                <f:BoundField Width="100px" ColumnID="PROD_NAME2" DataField="PROD_NAME2" DataFormatString="{0}" HeaderText="姓名" />
                    <f:BoundField Width="40px" ColumnID="SNo" DataField="SNo" DataFormatString="{0}" HeaderText="序号" TextAlign="Center"/>

                    <f:BoundField Width="70px" ColumnID="PROD_ID" DataField="PROD_ID" DataFormatString="{0}" HeaderText="商品编码" TextAlign="Center"/>
                    <f:BoundField Width="100px" ColumnID="PROD_NAME1" DataField="PROD_NAME1" DataFormatString="{0}" HeaderText="商品名称" TextAlign="Center"/>
 
                    <f:BoundField Width="70px" ColumnID="PROD_SPEC" DataField="PROD_SPEC" DataFormatString="{0}" HeaderText="商品规格" TextAlign="Center"/>
                    <f:BoundField Width="60px" ColumnID="PROD_UNIT" DataField="PROD_UNIT" DataFormatString="{0}" HeaderText="单位" TextAlign="Center"/>
                    <f:BoundField Width="60px" ColumnID="ON_QUAN" DataField="ON_QUAN" DataFormatString="{0:F0}" HeaderText="数量" TextAlign="Center"/>
                    <f:BoundField Width="80px" ColumnID="Cost" DataField="Cost" DataFormatString="{0}" HeaderText="单价" TextAlign="Center"/>
                    <f:BoundField Width="80px" ColumnID="QUAN1" DataField="QUAN1" DataFormatString="{0}" HeaderText="小计" TextAlign="Center"/>
                    <f:BoundField Width="80px" ColumnID="Order_QUAN" DataField="Order_QUAN" DataFormatString="{0}" HeaderText="最小订货量" TextAlign="Center"/>
                    <f:BoundField Width="60px" ColumnID="PROD_MEMO" DataField="Memo" DataFormatString="{0}" HeaderText="备注" />
               
            
                </Columns>
            </f:Grid>
                    </Items>
                </f:Panel>
                
                
                </Items>
            
            
            </f:Panel>
      
           <%-- <f:Label runat="server" ID="lblSpendingTime" Text=""></f:Label>
            <f:HiddenField runat="server" ID="SortColumn" Text="Id"></f:HiddenField>--%>
       <f:HiddenField runat="server" ID="hidId" Text="0"></f:HiddenField>
       <f:HiddenField runat="server" ID="SNo" Text="0" AutoPostBack="true"></f:HiddenField>

    <f:window id="Window1" width="1000px" height="700px" icon="TagBlue" hidden="True" Title="" Target="Parent"
        enablemaximize="True" closeaction="HidePostBack" onclose="Window1_Close" enablecollapse="true" Enabled="true"
        runat="server" enableresize="true" bodypadding="5px" enableframe="True" iframeurl="about:blank"
        enableiframe="true" enableclose="true" ismodal="True" > <%-- --%>
    </f:window>

    <%--<f:window id="Window2" width="400px" height="500px" icon="TagBlue" hidden="True" Title="" Target="Parent"
        enablemaximize="True" closeaction="HidePostBack" onclose="Window1_Close" enablecollapse="true" Enabled="true"
        runat="server" enableresize="true" bodypadding="5px" enableframe="True" iframeurl="about:blank"
        enableiframe="true" enableclose="true" ismodal="True" >
    </f:window>--%>

    <f:Window ID="Window2" Width="400px" Height="500px" Icon="TagBlue" Hidden="true" 
            EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
            IsModal="false" CloseAction="HidePostBack" OnClose="Window2_Close" Layout="Fit">   <%--OnInit="Windows_Init"--%>
            <Toolbars>
                <f:Toolbar ID="toolbar4" runat="server">
                      <Items>
                         <f:Button ID="btnAdd" runat="server" Text="保存" Icon="Disk" OnClick="btnAdd_Click" ></f:Button>
                         <f:Button ID="btnCancel" runat="server" Text="取消" Icon="Cancel" OnClick="btnCancel_Click"></f:Button>
                      </Items>
                </f:Toolbar>
            </Toolbars>
            <Content>
                 <%--<f:Panel ID="panel1" runat="server" BoxConfigAlign="Center">
                    <Items>--%>
                         <f:DropDownList ID="ddlPROD_NAME1" runat="server" Label="商品名称" CssStyle="margin:10px auto 0 auto;" AutoPostBack="true" Required="true" OnSelectedIndexChanged="ddlPROD_NAME1_SelectedIndexChanged">
                    <%--OnSelectedIndexChanged="ddlPROD_NAME2_SelectedIndexChanged"--%>
                        </f:DropDownList>
                
                        <f:TextBox ID="txtPROD_ID" Required="true" runat="server" Label="商品编号" Enabled="false" CssStyle="margin:5px auto;">
                        </f:TextBox>
                 
                        <f:TextBox ID="txtPROD_SPEC" Required="true" runat="server" Label="商品规格" Enabled="false" CssStyle="margin:0 auto;">
                        </f:TextBox>
               
                        <f:TextBox ID="txtPROD_UNIT" Required="true" runat="server" Label="商品单位" Enabled="false" CssStyle="margin:5px auto;">
                        </f:TextBox>

                        <f:TextBox ID="txtON_QUAN" Required="true" runat="server" Label="数量" AutoPostBack="true" CssStyle="margin:0 auto;" OnTextChanged="txtON_QUAN_TextChanged">
                        </f:TextBox>

                        <f:TextBox ID="txtU_Cost" Required="true" runat="server" Label="单价" Enabled="false" CssStyle="margin:5px auto;">
                        </f:TextBox>

                        <f:TextBox ID="txtTotal" Required="true" runat="server" Label="小计" Enabled="false" CssStyle="margin:0 auto;">
                        </f:TextBox>
                 
                        <f:TextBox ID="txtOrder_QUAN" Required="true" runat="server" Label="最小订货量" Enabled="false" CssStyle="margin:5px auto;">
                        </f:TextBox>
              
                        <f:TextBox ID="txtMemo" Required="true" runat="server" Label="备注" CssStyle="margin:0 auto;">
                        </f:TextBox>
             
            </Content>
        </f:Window>


   <%-- plain="false" --%>

    </form>
</body>
</html>
