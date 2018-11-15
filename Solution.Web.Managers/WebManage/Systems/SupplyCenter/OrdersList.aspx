<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersList.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SupplyCenter.OrdersList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"> <%-- id="Head1" --%>
    <title>菜单编辑</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        .photo
        {
            text-align: right;
        }
        .photo img
        {
            width: 200px;
        }
        .textbackcolor {
          background-color:bisque !important;
          color:black;
        }

         /*.textbackcolor1 {
           opacity: .6 !important;
        }*/

    </style>
   
    <link href="../../../res/css/main.css" rel="stylesheet" type="text/css" />
     <script src="../../Js/json2.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <f:Pagemanager id="PageManager1" runat="server" AutoSizePanelID="panel4"/>  <%-- --%>
         <f:Panel ID="panel4" runat="server" ShowBorder="false" ShowHeader="false" Layout="Region">
                <Items>
                     <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="center" Layout="Fit" Title="要货明细" ShowBorder="true" ShowHeader="true" AutoScroll="true">
                    <Items>
                        <f:Panel ID="Panel1" runat="server" EnableFrame="false" EnableCollapse="True" ShowHeader="False">  <%----%>
         <Toolbars>
            <f:Toolbar ID="toolBar" runat="server" >
                <Items>
                     <f:Button ID="ButtonAdd" runat="server" Text="新增" Icon="Add" OnClick="ButtonAdd_Click"></f:Button>
                    <f:Button ID="ButtonSave" runat="server" Text="保存" Icon="Disk" OnClick="ButtonSave_Click"></f:Button>

                    <f:Button ID="ButtonApproval" runat="server" Text="核准" Icon="Disk"  OnClick="ButtonApproval_Click" ></f:Button>
                    <f:Button ID="ButtonBackApproval" runat="server" Text="反核准" Icon="Delete"  OnClick="ButtonApproval_Click" ></f:Button>
                    <%--<f:Button ID="ButtonApproved" runat="server" Text="核准" Icon="Disk" OnClick="ButtonApproved_Click"></f:Button>--%>
                    
                    <%--<f:Button ID="ButtonCancel" runat="server" Text="取消" Icon="Cancel" ></f:Button>--%>
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Panel ID="Panel2" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" ShowHeader="False" ShowBorder="False">
                <Items>
                    <f:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            
                            <f:Form ID="Form5" runat="server" Width="930px" LabelWidth="100px" BodyPadding="5px" LabelAlign="Right" Title="表单" ShowBorder="false" ShowHeader="false"  >
                                    <Rows>
                                    <f:FormRow ColumnWidths="300px">
                                        <Items><%-- --%>
                                            <f:DropDownList runat="server" AutoPostBack="true" Required="true" OnSelectedIndexChanged="ddlShop_SelectedIndexChanged" CssClass="textbackcolor1" 
                                                Label="分店名称" ID="ddlShop" Width="250px">
                                            </f:DropDownList>
                                            <%--OnSelectedIndexChanged="ddlShop_SelectedIndexChanged" --%>

                                            <%--  OnClientClick="if (F('Grid1').getStrore().getCount() >= 0) { F.alert('只能选择一条记录进行删除！');return false; }"--%>
                                            
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
                                                <f:DropDownList runat="server" Required="true"  ShowRedStar="True" Label="订货部门" ID="ddlORDER_DEP" Width="250px" CssClass="textbackcolor" OnSelectedIndexChanged="ddlORDER_DEP_SelectedIndexChanged" AutoPostBack="true" ></f:DropDownList> 
                                                
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
                            <f:HiddenField runat="server" ID="HiddenShop_Id" Text="0" ></f:HiddenField>
                            
                        </Items>
                    </f:SimpleForm>
                    
                </Items>
            </f:Panel>
            
            <f:Panel ID="Panel3" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" ShowHeader="False" ShowBorder="False">
                <Items>
               
             <f:Grid ID="Grid1" Title="表格" ShowBorder="false" ShowHeader="false" EnableCollapse="true" Width="930px"
            runat="server" DataKeyNames="ID,PROD_NAME1" AllowCellEditing="true" ClicksToEdit="1" OnPreDataBound="Grid1_PreDataBound" 
            DataIDField="ID" EnableCheckBoxSelect="true" EnableColumnLines="true" MaxHeight="300px" AutoScroll="true"> 
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server" >
                    <Items>
                        <f:Button ID="btnNew" Text="新增" Icon="Add" OnClick="btnNew_Click" runat="server"> <%--EnablePostBack="false"--%> 
                        </f:Button>
                        <f:Button ID="btnDelete" Text="删除" Icon="Delete" EnablePostBack="false" runat="server"> </f:Button>
                         
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:TemplateField ColumnID="Number" Width="50px" HeaderText="序号">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
               <f:RenderField Width="100px" ColumnID="PROD_ID" DataField="PROD_ID" TextAlign="Center"  FieldType="String"
                    HeaderText="商品编号" >
                        
                      <Editor>
                          <f:Label ID="txtPROD_ID" runat="server" />
                          
                      </Editor>
                </f:RenderField>
                <f:RenderField Width="200px" ColumnID="PROD_NAME1" DataField="PROD_NAME1" FieldType="String"
                    HeaderText="商品名称">
                     
                    <Editor>
                        <f:DropDownList ID="DropDownList1"  runat="server">                         
                        </f:DropDownList>
                    </Editor>
                </f:RenderField>
                 
                <f:RenderField  Width="100px" ColumnID="PROD_SPEC" DataField="PROD_SPEC" TextAlign="Center"  FieldType="String"
                    HeaderText="产品规格">
                      <Editor>
                        <f:Label ID="txtPROD_SPEC" runat="server" />
                      </Editor>
                </f:RenderField>
                <f:RenderField  Width="50px" ColumnID="PROD_UNIT" DataField="PROD_UNIT" TextAlign="Center"  FieldType="String"
                    HeaderText="单位">
                      <Editor>
                        <f:Label ID="txtPROD_UNIT" runat="server" />
                        </Editor>
                </f:RenderField>
                
                <f:RenderField Width="100px" ColumnID="ON_QUAN" DataField="ON_QUAN"  FieldType="String"
                    HeaderText="订货量"> <%--FieldType="Int"--%>
                    <Editor>
                        <f:NumberBox ID="txtON_QUAN" Required="true" runat="server" DecimalPrecision="2"> <%--NoDecimal="true" NoNegative="true" --%>
                        </f:NumberBox>
                    </Editor>
                </f:RenderField>
                <f:RenderField Width="80px" ColumnID="STD_PRICE" DataField="STD_PRICE"
                    HeaderText="单价"> <%--FieldType="Int"--%>
                    <Editor>
                        <f:NumberBox ID="txtCOST" Required="true" runat="server" DecimalPrecision="2"> <%--NoDecimal="false" NoNegative="true" --%>
                        </f:NumberBox>
                    </Editor>
                </f:RenderField>

                 <f:RenderField  Width="100px" ColumnID="QUAN1" DataField="QUAN1" TextAlign="Center"
                    HeaderText="小计">
                        <Editor>
                            <f:Label ID="txtQUAN1" runat="server" />
                        </Editor>
                </f:RenderField>
               <%-- <f:BoundField runat="server" ColumnID="Order_QUAN" DataField="Order_QUAN" TextAlign="Center" HeaderText="最小单位" />--%>
                 <f:RenderField Width="140px" ColumnID="PROD_MEMO" DataField="PROD_MEMO" TextAlign="Center"  FieldType="String" MinWidth="140px"
                    HeaderText="备注" >
                      <Editor>
                          <f:TextBox ID="txtPROD_MEMO" runat="server" />
                          
                      </Editor>
                </f:RenderField>


                <%--<f:LinkButtonField ColumnID="Delete" Width="80px" EnablePostBack="false"
                    Icon="Delete" />--%>
            </Columns>
             
            <Listeners>
                <f:Listener Event="edit" Handler="onGridAfterEdit" />
            </Listeners>
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
         <f:Grid ID="Grid2" Title="订单中心" EnableFrame="false" EnableCollapse="true" AutoScroll="true"
            ShowBorder="false" ShowHeader="false" AllowPaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="ORDER_ID" EnableColumnLines="true" OnPreRowDataBound="Grid2_PreRowDataBound"
           EnableMultiSelect="false" EnableRowSelectEvent="true" OnRowSelect="Grid2_RowSelect" >  <%-- OnRowCommand="Grid1_RowCommand"  OnPageIndexChange="Grid1_PageIndexChange" --%>  
               
                <toolbars>
                     <f:Toolbar ID="toolBar2" runat="server" >   <%--Position="Left"--%>
                       
                        <Items>
                          <f:Panel ID="panl1" runat="server" ShowHeader="false" ShowBorder="false" Width="500px" BodyStyle="background-color:transparent;">
                            <Toolbars>
                               <f:Toolbar ID="toolBar3" runat="server" Width="450px"  >
                                   <Items>
                                         <f:Button ID="ButtonRefresh" runat="server" Text="刷新" Icon="ArrowRefresh" OnClick="ButtonRefresh_Click" CssClass="inline btnf"></f:Button>
                                        <%--<f:Button ID="Button1" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click" CssClass="btnf"></f:Button>--%>
                                        <f:Button ID="ButtonSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="ButtonSearch1_Click" CssClass="btnf"></f:Button>
                                        <f:Button ID="ButtonEdit" runat="server" Text="编辑" Icon="BulletEdit" OnClick="ButtonEdit_Click" CssClass="btnf"
                                            OnClientClick="if(!F('panel1_panelCenterRegion_Grid1').getSelectionModel().hasSelection()|| F('panel1_panelCenterRegion_Grid1').getSelectionModel().getCount()>=2){F.alert('您没有选择编辑项或只能选择一项进行编辑！'); return false; }">
                                       </f:Button> 
                                       <%-- <f:Button ID="ButtonSaveAutoSort" runat="server" Text="自动排序" Icon="ArrowJoin" CssClass="btnf" OnClick="ButtonSaveAutoSort_Click" ConfirmTitle="自动排序提示" ConfirmText="是否对所有数据进行自动排序？"></f:Button>
                                        <f:Button ID="ButtonSaveSort" runat="server" Text="保存排序" Icon="Disk" OnClick="ButtonSaveSort_Click" CssClass="btnf"></f:Button>--%>
                                        <f:Button ID="ButtonDelete" runat="server" Text="删除" Icon="Delete" CssClass="btnf" OnClick="ButtonDelete_Click" ConfirmTitle="删除提示" ConfirmText="是否删除记录？" 
                                            OnClientClick="if (!F('Grid1').getSelectionModel().hasSelection() ) { F.alert('删除时必须选择一条将要删除的记录！'); return false; }  if (F('Grid1').getSelectionModel().getCount() >= 2) { F.alert('只能选择一条记录进行删除！');return false; }">
                                        </f:Button>
                                        
                                   </Items>
                               
                               </f:Toolbar>
                            </Toolbars>
                             
                            </f:Panel>
                             
                        </Items>
                    </f:Toolbar>
                </toolbars>
     
                <Columns>
                   
                     <f:BoundField Width="100px" DataField="ORDER_ID" DataFormatString="{0}" HeaderText="订单编号" />
                   
                    <f:LinkButtonField runat="server" ID="LIK_SHOP" ColumnID="SHOP_LINK" HeaderText="分店名称" Width="130px"></f:LinkButtonField>
                    <f:BoundField Width="160px" DataField="EXPECT_DATE" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="期望日期" />
                

                    <f:RenderField runat="server" ID="STATUS_ORD" ColumnID="ORD_STATUS" HeaderText="单据状态" Width="80px" DataField="STATUS" RendererFunction="renderSTATUS" >
                        <Editor>
                            <f:DropDownList runat="server" Enabled="false" Required="true" ID="DropDownList3"  >
                                <f:ListItem  Text="无" Value="0"/>
                                <f:ListItem  Text="存档" Value="1"/>
                                <f:ListItem  Text="核准" Value="2"/>
                                <f:ListItem  Text="作废" Value="3"/>
                                <f:ListItem  Text="已汇整" Value="4"/>
                            </f:DropDownList>

                        </Editor>

                    </f:RenderField>
             
                </Columns>
            </f:Grid>
                        </Items>
                    </f:Panel>
                </Items>
         </f:Panel>

        <f:Window ID="Window1" Width="500px" Height="200px" Icon="TagBlue" Hidden="true" BodyPadding="20px"
            EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true" Target="Parent" 
            IsModal="false" CloseAction="HidePostBack" OnClose="Window1_Close" Layout="Fit">   <%--OnInit="Windows_Init"--%>
            <Toolbars>
                <f:Toolbar ID="toolbar4" runat="server">
                      <Items>
                         <f:Button ID="btnSubmit" runat="server" Text="确认" Icon="Disk" OnClick="btnSubmit_Click" ></f:Button>
                         <f:Button ID="btnCancel" runat="server" Text="取消" Icon="Cancel" OnClick="btnCancel_Click" ></f:Button>
                      </Items>
                </f:Toolbar>
            </Toolbars>
            <Content>
                <f:Panel ID="A" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="formitem" 
                    runat="server">
                    <Items>
                          <f:Label runat="server" Text="订货门店更改？注：更改订货部门将清空订货明细！" />
                    </Items>
                </f:Panel>
                 
             
            </Content>
        </f:Window>
         <f:Window ID="Window2" Width="500px" Height="200px" Icon="TagBlue" Hidden="true" BodyPadding="20px"
            EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
            IsModal="false" CloseAction="HidePostBack" OnClose="Window1_Close" Layout="Fit">   <%--OnInit="Windows_Init"--%>
            <Toolbars>
                <f:Toolbar ID="toolbar5" runat="server">
                      <Items>
                          <f:Button ID="Button1" runat="server" Text="确认" Icon="Disk" OnClick="btnSubmit1_Click" ></f:Button>
                         <f:Button ID="Button2" runat="server" Text="取消" Icon="Cancel" OnClick="btnCancel1_Click" ></f:Button>
                      </Items>
                </f:Toolbar>
            </Toolbars>
            <Content>
                <f:Panel ID="A" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="formitem" 
                    runat="server">
                    <Items>
                        <%--<f:Label ID="Label1" runat="server" Width="80px" CssClass="marginr" ShowLabel="false"
                            Text="提交时间：">
                        </f:Label> --%>
                        <f:RadioButton ID="RaddpUp_Date" runat="server" Text="提交时间：" GroupName="Rad_Time"></f:RadioButton>
                        <f:DatePicker runat="server" ShowLabel="false" Label="提交时间" ID="dpUp_DateBeg" Width="150px"  ></f:DatePicker>
                        <f:Label ID="lab3" runat="server" Width="20px" ShowLabel="false" Text="至"/>
                        <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" ID="dpUp_DateEnd" CompareControl="dpUp_DateBeg" CompareOperator="GreaterThanEqual"
                            CompareMessage="结束日期应该大于开始日期！" Width="150px" ShowLabel="false" ></f:DatePicker>
 
                    </Items>
                </f:Panel>
                <f:Panel ID="B" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="formitem" Margin="10px 0"
                    runat="server">
                    <Items>
                       <%-- <f:Label ID="Label2" runat="server" Width="80px" CssClass="marginr" ShowLabel="false"
                            Text="期望日期："></f:Label> --%> 
                        <f:RadioButton ID="RadEXPECT_DATE" runat="server" Text="期望日期：" GroupName="Rad_Time"></f:RadioButton>
                        <f:DatePicker runat="server" ShowLabel="false" Label="期望开始日期"  ID="dpEXPECT_DATEBeg" Width="150px" ></f:DatePicker>
                        <f:Label ID="lb4" runat="server" Width="20px" ShowLabel="false" Text="至" />
                        
                        <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" ID="dpEXPECT_DATEEnd" CompareControl="dpEXPECT_DATEBeg" CompareOperator="GreaterThanEqual"
                            CompareMessage="结束日期应该大于开始日期！"  Width="150px" ShowLabel="false" ></f:DatePicker>
                    </Items>
               </f:Panel>
                 
             
            </Content>
        </f:Window>

         
    </form>

    <script type="text/javascript">
   
        function onOperation1Click() {
 
            Ext.MessageBox.show({
                msg: '切换部门，请先保存！',
                title: '确认切换？',
                buttons: Ext.Msg.YESNO,
                buttonText:
                {
                    yes: '确认',
                    no: '取消'
                },
                fn: function (btnId) {
                    if (btnId === 'yes') {
                        __doPostBack('', 'ConfirmOK');
                    } else {
                        __doPostBack('', 'ConfirmCancel');
                    }
                }
            });
        }
 
    
        function renderSTATUS(value) {
            if(value == 0){return '无';}  
            if (value == 1) { return '存档' }
            if (value == 2) { return '核准' }
            if (value == 3) { return '作废' }
            if (value == 4) { return '已汇整' }
 

        }

        // 注意：专业版中改事件名为：afteredit，开源版中为：edit
        function onGridAfterEdit(editor, params) {
            var me = this, columnId = params.column.id, rowId = params.record.getId();
             
            var shop_id = F('<%= ddlShop.ClientID %>').value;
            var ordep_id = F('<%= ddlORDER_DEP.ClientID %>').value;
           
            if (columnId === 'ON_QUAN' || columnId === 'STD_PRICE') {
                var chineseScore = me.f_getCellValue(rowId, 'ON_QUAN');
                var mathScore = me.f_getCellValue(rowId, 'STD_PRICE');

                me.f_updateCellValue(rowId, 'QUAN1', chineseScore * mathScore);

            }

            if (columnId === "PROD_NAME1") {
                var strvalue = me.f_getCellValue(rowId, 'PROD_NAME1');
                //  var ss = loadXMLDoc(strvalue);
                // var cc;
                // me.f_updateCellValue(rowId, 'PROD_ID', strvalue);
                if (strvalue == '' || strvalue == '0')
                {
                    me.f_updateCellValue(rowId, 'PROD_NAME1', '请选择');
                    return;
                }

                var xmlhttp;
                if (window.XMLHttpRequest) {
                    //  IE7+, Firefox, Chrome, Opera, Safari 浏览器执行代码
                    xmlhttp = new XMLHttpRequest();
                }
                else {
                    // IE6, IE5 浏览器执行代码
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        var strResult = xmlhttp.responseText;
                        var obj = JSON.parse(strResult);
                         
                        me.f_updateCellValue(rowId, 'PROD_ID', obj[0].PROD_ID);
                        me.f_updateCellValue(rowId, 'PROD_NAME1', obj[0].PROD_NAME1);
                        me.f_updateCellValue(rowId, 'PROD_SPEC', obj[0].PROD_SPEC);
                        me.f_updateCellValue(rowId, 'PROD_UNIT', obj[0].PROD_UNIT);
                        me.f_updateCellValue(rowId, 'ON_QUAN', obj[0].Order_QUAN);
                        me.f_updateCellValue(rowId, 'STD_PRICE', obj[0].STD_PRICE);

                        me.f_updateCellValue(rowId, 'QUAN1', obj[0].STD_PRICE * obj[0].Order_QUAN);
                        //me.f_updateCellValue(rowId, 'Order_QUAN', obj[0].Order_QUAN);
                        me.f_updateCellValue(rowId, 'PROD_MEMO', '');
                    }
                    else {
                        me.f_updateCellValue(rowId, 'PROD_NAME1', xmlhttp.responseText);
                        //return "失败了";
                    }
                }

               // xmlHttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8"); 
                xmlhttp.open("GET", "OrdersListHandler.ashx?value=" + strvalue + "&value1=" + shop_id + "&value2=" + ordep_id, true);
                
                xmlhttp.send();


            }

        }

        //function loadXMLDoc(str) {
        //    var xmlhttp;
        //    if (window.XMLHttpRequest) {
        //        //  IE7+, Firefox, Chrome, Opera, Safari 浏览器执行代码
        //        xmlhttp = new XMLHttpRequest();
        //    }
        //    else {
        //        // IE6, IE5 浏览器执行代码
        //        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        //    }
        //    xmlhttp.onreadystatechange = function () {
        //        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
        //            return xmlhttp.responseText;
        //        }
        //        else {
        //            return "失败了";
        //        }
        //    }
        //    xmlhttp.open("GET", "OrdersListHandler.ashx?value=" + str, true);
        //    xmlhttp.send();
        //}

    </script>

        


</body>
</html>