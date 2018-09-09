<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionPlanList.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.ProductionCenter.ProductionPlanList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

</head>
<body>
   <form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server" AutoSizePanelID="panel4" />
           
         <f:Panel ID="panel4" runat="server" ShowBorder="false" ShowHeader="false" Layout="Region">
             <Items>
                 <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="center" Layout="Fit" Title="要货明细" ShowBorder="true" ShowHeader="true" AutoScroll="true">
                    <Items>
                        <f:Panel ID="Panel1" runat="server" EnableFrame="false" EnableCollapse="True" ShowHeader="False">  <%----%>
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
                              
                            </f:Panel>
                             
                        </Items>
                    </f:Toolbar>
       
                </toolbars>
        <Items>
            <f:Panel ID="Panel2" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" ShowHeader="False" ShowBorder="False">
                <Items>
                    <f:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            
                            <f:Form ID="Form5" runat="server" Width="780px" LabelWidth="100px" BodyPadding="5px" LabelAlign="Right" Title="表单" ShowBorder="false" ShowHeader="false"  >
                                    <Rows>
                                    <f:FormRow ColumnWidths="300px">
                                        <Items><%--OnSelectedIndexChanged="ddlShop_SelectedIndexChanged"  --%>
                                            <f:DropDownList runat="server" AutoPostBack="true" Enabled="false" Required="true" CssClass="textbackcolor1" Label="分店名称" ID="ddlShop" Width="250px"></f:DropDownList>
                                            <f:TextBox runat="server" Label="订单编号" ID="txtORDER_ID" Enabled="false" Width="250px"></f:TextBox>
                                            
                                            <f:DropDownList runat="server" Enabled="false" Label="状态" ID="ddlStatus" Width="250px">
                                                <f:ListItem  Text="无" Value="0"/>
                                                <f:ListItem  Text="存档" Value="1"/>
                                                <f:ListItem  Text="核准" Value="2"/>
                                                <f:ListItem  Text="作废" Value="3"/>
                                                <f:ListItem  Text="已汇整" Value="4"/>
                                            </f:DropDownList>
                                              
                                        </Items>
                                    </f:FormRow>
                                    <f:FormRow ColumnWidths="300px">
                                        <Items>
                                                       
                                                <f:DatePicker EnableEdit="false" runat="server" Required="true" Label="申请日期" DateFormatString="yyyy-MM-dd" ID="txtINPUT_DATE" CssClass="textbackcolor" ShowRedStar="True" Width="250px" ></f:DatePicker>
                                                <f:DropDownList runat="server" Required="true"  ShowRedStar="True" Label="订货部门" ID="ddlORDER_DEP" Width="250px" CssClass="textbackcolor" AutoPostBack="true" ></f:DropDownList>  <%--OnSelectedIndexChanged="ddlORDER_DEP_SelectedIndexChanged"--%>
                                                
                                                <f:DropDownList runat="server" AutoPostBack="true" Required="true"  ShowRedStar="True" Label="订单类型" ID="ddlORD_TYPE" Width="250px" CssClass="textbackcolor">
                                                             
                                                    <f:ListItem  Text="普通订货" Value="1"/>
                                                    <f:ListItem  Text="客户订货" Value="2"/>
                                            </f:DropDownList> 
                                        </Items>
                                    </f:FormRow >
                                        <f:FormRow ColumnWidths="300px">
                                        <Items>
                                            <f:DatePicker EnableEdit="false" runat="server" Required="true" Label="期望日期" DateFormatString="yyyy-MM-dd" ID="ddlEXPECT_DATE"  ShowRedStar="True" Width="250px" CssClass="textbackcolor"></f:DatePicker>
                                            <f:DropDownList runat="server" Required="true" Label="供货分店" ShowRedStar="True" ID="ddlOUT_SHOP" Width="250px" CssClass="textbackcolor"></f:DropDownList>
                                            <f:TextBox runat="server" Label="负责人员" ID="txtManage" Width="250px" Readonly="true" Enabled="false"></f:TextBox> <%-- ShowRedStar="true"--%>             
                                        </Items>
                                 
                                    </f:FormRow>
                                    <f:FormRow ColumnWidths="300px">
                                        <Items>
                                            
                                            <f:TextBox runat="server" Label="汇出单据" ID="txtEXPORTED_ID" Width="250px" Enabled="false"></f:TextBox>
                                            <f:CheckBox runat="server" Label="汇出标记" ID="txtEXPORTED" Width="250px" Enabled="false"></f:CheckBox>        
                                            <f:CheckBox runat="server" Label="月结锁定" ID="cbLOCKED" Enabled="false" CssStyle=" width:250px !important;"/>
          
                                        </Items>
                                                
                                    </f:FormRow>
                                    <f:FormRow ColumnWidths="300px">
                                        <Items>
                                            <f:DatePicker Enabled ="false" runat="server" Label="建档日期" DateFormatString="yyyy-MM-dd" ID="txtCRT_DATETIME" Readonly="true" Width="250px" ></f:DatePicker>
                                            <f:DatePicker Enabled ="false" runat="server" Label="核准日期" DateFormatString="yyyy-MM-dd" ID="txtAPP_DATE" Readonly="true" Width="250px" ></f:DatePicker>
                                     
                                            <f:TextBox runat="server" Enabled="false" Label="最后异动时间" ID="txtLAST_UPDATE" Width="250px"></f:TextBox>
                                           
                                        </Items>
                                    </f:FormRow>
                                    <f:FormRow ColumnWidths="300px">
                                        <Items>
                                            <f:TextBox runat="server" Enabled="false" Label="建档人员" ID="txtCRT_USER_ID" Width="250px"></f:TextBox>
                                            <f:TextBox runat="server" Enabled="false" Label="制单人员" ID="txtORD_USER" Width="250px"></f:TextBox>
                                            <f:TextBox runat="server" Enabled="false" Label="核准人员" ID="txtAPP_USER" Width="250px"></f:TextBox>
                                                         
                                        </Items>
                                                
                                    </f:FormRow>
                                    <f:FormRow ColumnWidths="300px">
                                        <Items>
                                             
                                            <%--<f:TextBox runat="server" Enabled="false" Label="传输状态" ID="txtTrans_STATUS" Width="250px"></f:TextBox>--%>
                                            <f:CheckBox runat="server" ID="cbTrans_STATUS"  Enabled="false" Label="传输状态" Width="250px"></f:CheckBox>
                                            <f:DatePicker Enabled="false" runat="server" Required="true" Label="修改日期" DateFormatString="yyyy-MM-dd" ID="txtMOD_DATETIME" Width="250px" ></f:DatePicker>
                                      
                                            <f:TextBox runat="server" Enabled="false" Label="修改人员" ID="txtMOD_USER_ID" Width="250px"></f:TextBox>
                                        </Items>
                                    </f:FormRow>
                                    <f:FormRow ColumnWidths="300px" >
                                            <Items>
                                              
                                             <f:TextBox runat="server" Label="备注" ID="txtMemo" CssStyle=" width:250px !important;"></f:TextBox>            
                                             <f:Label runat="server" Label="" ID="TextBox1" CssStyle=" width:250px !important;"></f:Label> 
                                            </Items>
                                    </f:FormRow>

                            </Rows>
                            </f:Form>
                         
                            <f:HiddenField runat="server" ID="hidId" Text="0"></f:HiddenField>
                            <f:HiddenField runat="server" ID="SHOP_hidId" Text="0" ></f:HiddenField>
                            <f:HiddenField runat="server" ID="HiddenDep_Id" Text="0" ></f:HiddenField>
                            
                        </Items>
                    </f:SimpleForm>
                    
                </Items>
            </f:Panel>
            
            <f:Panel ID="Panel3" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" ShowHeader="False" ShowBorder="False">
                <Items>
                     <f:Grid ID="Grid1" Title="生产计划" EnableFrame="false" EnableCollapse="true" AllowSorting="true"  ShowBorder="false" ShowHeader="false" Width="900px"
                    AllowPaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id" EnableColumnLines="true"
                  >  <%--PageSize="15"    OnRowCommand="Grid1_RowCommand" OnPreRowDataBound="Grid1_PreRowDataBound" OnPageIndexChange="Grid1_PageIndexChange"  --%>  
                
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
                  
                 <f:Label ID="labResult" EncodeText="false" runat="server">  </f:Label>
    
                </Items>
               </f:Panel>
                    </Items>
                    </f:Panel>

                    </Items>
                    </f:Panel>
                    <f:Panel runat="server" ID="panelRightRegion" RegionPosition="Right" RegionSplit="true" EnableCollapse="true" Layout="Fit" Width="500px" Expanded="false"
                                Title="要货清单" ShowBorder="true" ShowHeader="true" >
                        <Items>
                             <f:Panel ID="Panel5" runat="server" ShowHeader="false" ShowBorder="false" Width="500px" BodyStyle="background-color:transparent;">
                            <Toolbars>
                               <f:Toolbar ID="toolBar3" runat="server" Width="450px"  >
                                   <Items>
                                         <f:Button ID="Button1" runat="server" Text="刷新" Icon="ArrowRefresh" OnClick="ButtonRefresh_Click" CssClass="inline btnf"></f:Button>
                                        <%--<f:Button ID="Button1" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click" CssClass="btnf"></f:Button>--%>
                                        <f:Button ID="Button2" runat="server" Text="查询" Icon="Magnifier" CssClass="btnf"></f:Button>
                                        <%--OnClick="ButtonSearch1_Click"--%> 
                                       
                                   </Items>
                               
                               </f:Toolbar>
                            </Toolbars>
                             
                            </f:Panel>
                        </Items>
                    </f:Panel>
                  
             </Items>
         </f:Panel>
            
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