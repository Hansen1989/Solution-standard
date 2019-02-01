<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchase00List.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SupplyCenter.Purchase00List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>菜单编辑</title>
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
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" ShowBorder="false" ShowHeader="false" Layout="Region">
            <Items>
                <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="Center"
                    Title="采购作业信息" ShowBorder="true" ShowHeader="true" AutoScroll="true">
                    <Toolbars>
                    <f:Toolbar ID="Toolbar1" runat="server">
                      <Items>
                          <f:Button ID="ButtonAdd" runat="server" Text="新增" Icon="Add" OnClick="BtnPur01_Add"></f:Button>
                          <f:Button ID="ButtonSave" runat="server" Text="保存" Icon="Disk" OnClick="BtnPur01_Save"></f:Button>
<%--                          <f:Button ID="ButtonUpdate" runat="server" Text="修改" Icon="Disk" OnClick="BtnPur01_Edit"></f:Button>--%>
                          <f:Button ID="ButtonCheck" runat="server" Text="核准" Icon="Disk" OnClick="BtnPur00_Approval"></f:Button>
                          <f:Button ID="ButtonCancel" runat="server" Text="作废" Icon="Disk"></f:Button>
                      </Items>
                      </f:Toolbar>
                    </Toolbars>
                    <Items>
                     <f:Form ID="Form5" LabelAlign="Right"  BodyPadding="5px" LabelWidth="100px" EnableCollapse="true"
                            runat="server" Title="表单" ShowBorder="false" ShowHeader="false">
                        <Rows>
                            <f:FormRow>
                                <Items>
                                    
                                </Items>
                            </f:FormRow>
                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                    <f:HiddenField runat="server" Label="采购单号" ID="hidPurchase_ID" Required="true" ShowRedStar="true" Enabled="false"></f:HiddenField>
                                    <f:HiddenField runat="server" Label="采购编码" ID="hidId" Required="true" ShowRedStar="true" Enabled="false"></f:HiddenField>
                                    <f:TextBox runat="server" Label="采购单号" ID="tbxPurchase_ID" Required="true" ShowRedStar="true" Enabled="false"></f:TextBox>
                                    <f:DropDownList runat="server" Label="分店名称" ID="ddlSHOP_NAME" Required="true" ShowRedStar="true" Enabled="false"></f:DropDownList> 
                                    <f:CheckBox runat="server" ID="chxLOCKED" Enabled="false" Label="月结锁定"></f:CheckBox>
                                </Items>
                            </f:FormRow>

                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                    <f:DropDownList runat="server" ID="ddlStatus" Required="true" Width="100px" ShowRedStar="true" Label="单据状态" Enabled="false">
                                        <f:ListItem Text="存档" Value="1" Selected="true" />
                                        <f:ListItem Text="核准" Value="2" />
                                        <f:ListItem Text="作废" Value="3" />
                                        <f:ListItem Text="已引入" Value="4" />
                                    </f:DropDownList>
                                    <f:DatePicker ID="dpINPUT_DATE" Label="单据日期" Required="true" Readonly="false" DateFormatString="yyyy-MM-dd" runat="server" ShowRedStar="True" Enabled="false">
                                    </f:DatePicker>
                                    <f:DatePicker ID="dpEXPECT_DATE" Label="期望日期" Required="true" Readonly="false" DateFormatString="yyyy-MM-dd" runat="server" ShowRedStar="True" Enabled="false">
                                    </f:DatePicker>
                                </Items>
                            </f:FormRow>

                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                    <f:DropDownList runat="server" Label="厂商名称" ID="ddlSUP_NAME" Required="true" ShowRedStar="true" Enabled="false"></f:DropDownList>
                                    <f:DropDownList runat="server" ID="ddlPAY_STATUS" Required="true" ShowRedStar="true" Label="付款状态" Enabled="false">
                                        <f:ListItem Text="预付" Value="1" Selected="true" />
                                        <f:ListItem Text="全付" Value="2" />
                                    </f:DropDownList>
                                    <f:TextBox runat="server" Label="制单人" ID="tbxUSER_ID" Required="true" ShowRedStar="true" Width="250px" Enabled="false"></f:TextBox>

                                    
                                </Items>
                            </f:FormRow>

                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                    <f:TextBox runat="server" Label="审核人" ID="tbxAPP_USER" Required="true" ShowRedStar="true" Width="250px" Enabled="false"></f:TextBox>
                                    <f:DatePicker ID="dpAPP_DATETIME" Label="审核时间" Required="true" Readonly="true" Enabled="false" DateFormatString="yyyy-MM-dd" runat="server">
                                    </f:DatePicker>
                                    <f:NumberBox ID="numTOT_AMOUNT" Label="采购总金额" runat="server" NoDecimal="false" DecimalPrecision="6" Enabled="false" ></f:NumberBox>
                                </Items>
                            </f:FormRow>


                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                    <f:NumberBox ID="numTOT_TAX" Label="采购总税额" runat="server" NoDecimal="false" DecimalPrecision="6" Enabled="false" ></f:NumberBox>
                                    <f:NumberBox ID="numTOT_QTY" Label="采购总数量" runat="server" NoDecimal="false" DecimalPrecision="6" Enabled="false" ></f:NumberBox>
                                    <f:NumberBox ID="numPRE_PAY" Label="采购预付款" runat="server" NoDecimal="false" DecimalPrecision="6" Enabled="false" ></f:NumberBox>
                                </Items>
                            </f:FormRow>

                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                    <f:TextBox runat="server" ID="tbxPRE_PAY_ID" Label="预付款单号" Enabled="false"></f:TextBox>
                                    <f:DropDownList runat="server" ID="ddlEXPORTED" Required="true" ShowRedStar="false" Label="付款状态" Enabled="false" >
                                       <f:ListItem Text="已引入" Value="0" Selected="true"/>
                                       <f:ListItem Text="未引入" Value="1" />
                                    </f:DropDownList>
                                    <f:TextBox runat="server" ID="tbxEXPORTED_ID" Label="引入单号" Enabled="false"></f:TextBox>
                                </Items>
                            </f:FormRow>

                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                    <f:TextBox runat="server" ID="tbxMemo" Label="备注" Enabled="true"></f:TextBox>
                                    <f:TextBox runat="server" ID="tbxCRT_DATETIME" Label="建档日期" Enabled="false"></f:TextBox>
                                    <f:TextBox runat="server" ID="tbxCRT_USER_ID" Label="建档人员" Enabled="false"></f:TextBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                    <f:TextBox runat="server" ID="tbxMOD_DATETIME" Label="修改日期" Enabled="false"></f:TextBox>
                                    <f:TextBox runat="server" ID="tbxMOD_USER_ID" Label="修改人员" Enabled="false"></f:TextBox>
                                    <f:TextBox runat="server" ID="tbxLAST_UPDATE" Label="最后异动时间" Enabled="false"></f:TextBox>
                                </Items>
                            </f:FormRow>
                        </Rows>
                     </f:Form>
                    </Items>

                    <Items>
                       <f:Panel ID="Panel12" runat="server" Title="商品设定">
                           <Toolbars>
                             <f:Toolbar ID="Toolbar21111" runat="server">
                               <Items>
                                  <f:Button ID="ButtonPur02Add" runat="server" Text="添加" Icon="Add" OnClick="btn_Pur02Add"></f:Button>
                                  <f:Button ID="ButtonPur02Delete" runat="server" Text="删除" Icon="Delete" OnClick="btn_Pur02Delete"></f:Button>
<%--                                  <f:Button ID="Button_Replace" runat="server" Text="替换" Icon="Add" OnClick="btn_Replace"></f:Button>--%>
                               </Items>
                             </f:Toolbar>
                           </Toolbars>
                           <Items>
                              <f:Grid ID="Grid2" Title="采购作业子表" EnableFrame="false" EnableCollapse="false" ShowHeader="false" runat="server" 
                                   DataKeyNames="Id" AllowPaging="false" EnableCheckBoxSelect="true" AllowCellEditing="true" ClicksToEdit="1" EnableColumnLines="true"
                                  > 
                                      <Columns>
                                        <f:RowNumberField />
                                        <f:RenderField Width="130px" ColumnID="Id01" DataField="Id" FieldType="String" Hidden="true"
                                                HeaderText="编码">
                                                <Editor>
                                                    <f:TextBox ID="tbxId" runat="server" Required="true" ShowRedStar="true">
                                                    </f:TextBox>
                                                </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="130px" ColumnID="SHOP_ID01" DataField="SHOP_ID" FieldType="String" Enabled="false" Hidden="true"
                                                HeaderText="采购分店编号">
                                                <Editor>
                                                    <f:TextBox ID="tbxSHOP_ID01" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="130px" ColumnID="SHOP_NAME01" DataField="SHOP_ID" FieldType="String" Enabled="false" Hidden="true"
                                                HeaderText="采购分店名称">
                                                <Editor>
                                                    <f:TextBox ID="TextBox2" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="130px" ColumnID="Purchase_ID01" DataField="Purchase_ID" FieldType="String" Enabled="false" Hidden="true"
                                                HeaderText=" 采购单号">
                                                <Editor>
                                                    <f:TextBox ID="tbxPurchase_ID01" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="130px" ColumnID="SNo01" DataField="SNo" FieldType="String" Enabled="false"
                                                HeaderText=" 序号">
                                                <Editor>
                                                    <f:TextBox ID="tbxSNo" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="PROD_ID01" DataField="PROD_ID" FieldType="String" Enabled="false" Hidden="true"
                                                HeaderText="商品编码">
                                                <Editor>
                                                    <f:TextBox ID="tbxPROD_ID" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                         </f:RenderField>
                                          <f:RenderField Width="130px" ColumnID="PROD_NAME01" DataField="PROD_NAME1" FieldType="String" Enabled="false"
                                                HeaderText="商品名称">
                                                <Editor>
                                                    <f:TextBox ID="TextBox1" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="QUANTITY01" DataField="QUANTITY" FieldType="Int" Hidden="false"
                                                HeaderText="最小单位数量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numQUANTITY" NoNegative="true" DecimalPrecision="6" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="STD_UNIT01" DataField="STD_UNIT" FieldType="String" Enabled="false" Hidden="true"
                                                HeaderText="采购单位类别" RendererFunction="renderSTD_UNIT0101">
                                                <Editor>
                                                    <f:DropDownList ID="ddlSTD_TYPE01" runat="server" Enabled="true">
                                                        <f:ListItem Text="最小单位" Value="1" />
                                                        <f:ListItem Text="包装单位" Value="2" />
                                                        <f:ListItem Text="外箱单位" Value="3" />
                                                    </f:DropDownList>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="STD_UNIT_NAME01" DataField="STD_UNIT_NAME" FieldType="String" Enabled="false"
                                                HeaderText="采购单位">
                                                <Editor>
                                                    <f:TextBox ID="tbxSTD_UNIT01" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="UNIT_NAME01" DataField="UNIT_NAME" FieldType="String" Enabled="false"
                                                HeaderText="最小单位" Hidden="true">
                                                <Editor>
                                                    <f:TextBox ID="TextBox3" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="UNIT_NAME101" DataField="UNIT_NAME1" FieldType="String" Enabled="false"
                                                HeaderText="包装单位" Hidden="true">
                                                <Editor>
                                                    <f:TextBox ID="TextBox4" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="UNIT_NAME201" DataField="UNIT_NAME2" FieldType="String" Enabled="false"
                                                HeaderText="外箱单位" Hidden="true">
                                                <Editor>
                                                    <f:TextBox ID="TextBox5" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="STD_CONVERT01" DataField="STD_CONVERT" FieldType="Int" Enabled="true" Hidden="true"
                                                HeaderText="标准转换量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numSTD_CONVERT" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="PROD_CONVERT101" DataField="PROD_CONVERT1" FieldType="Int" Enabled="true" Hidden="true"
                                                HeaderText="包装转换量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="NumberBox1" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="PROD_CONVERT201" DataField="PROD_CONVERT2" FieldType="Int" Enabled="true" Hidden="true"
                                                HeaderText="外箱转换量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="NumberBox2" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>

                                         <f:RenderField Width="130px" ColumnID="STD_QUAN01" DataField="STD_QUAN" FieldType="Float" Enabled="true"
                                                HeaderText="标准采购量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numSTD_QUAN" NoNegative="true" DecimalPrecision="6" Enabled="true"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="STD_PRICE01" DataField="STD_PRICE" FieldType="Float" Enabled="true"
                                                HeaderText="标准单价">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numSTD_PRICE" NoNegative="true" DecimalPrecision="6" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="SUP_COST01" DataField="SUP_COST" FieldType="Float" Enabled="true" Hidden="true"
                                                HeaderText="进价1">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="NumberBox3" NoNegative="true" DecimalPrecision="6" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                          <f:RenderField Width="130px" ColumnID="SUP_COST101" DataField="SUP_COST1" FieldType="Float" Enabled="true" Hidden="true"
                                                HeaderText="进价2">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="NumberBox4" NoNegative="true" DecimalPrecision="6" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                          <f:RenderField Width="130px" ColumnID="SUP_COST201" DataField="SUP_COST2" FieldType="Float" Enabled="true" Hidden="true"
                                                HeaderText="进价3">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="NumberBox5" NoNegative="true" DecimalPrecision="6" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="Tax01" DataField="Tax" FieldType="Float" Enabled="false"
                                                HeaderText="税额">
                                                <Editor>
                                                    <f:TextBox runat="server" ID="numTax" Enabled="false"></f:TextBox>
<%--                                                    <f:NumberBox runat="server" ID="numTax" DecimalPrecision="6" Enabled="false"></f:NumberBox>--%>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="Tax_Num01" DataField="Tax_Num" FieldType="Float" Enabled="false" Hidden="false"
                                                HeaderText="税率">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="NumberBox7" NoNegative="true" DecimalPrecision="6" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                          <f:RenderField Width="130px" ColumnID="Tax_Type01" DataField="Tax_Type" FieldType="Float" Enabled="false" Hidden="true"
                                                HeaderText="税率类别">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="NumberBox8" NoNegative="true" DecimalPrecision="6" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>

                                         <f:RenderField Width="130px" ColumnID="QUAN101" DataField="QUAN1" FieldType="Float" Enabled="false"
                                                HeaderText="验收量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numQUAN1" NoNegative="true" DecimalPrecision="6" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="QUAN201" DataField="QUAN2" FieldType="Float" Enabled="false"
                                                HeaderText="取消量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numQUAN2" NoNegative="true" DecimalPrecision="6" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="Item_DISC_Amt01" DataField="Item_DISC_Amt" FieldType="Float" Enabled="false"
                                                HeaderText="折价金额">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numItem_DISC_Amt" NoNegative="true" DecimalPrecision="6" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="MEMO" DataField="MEMO" FieldType="String" Enabled="True"
                                                HeaderText="备注">
                                                <Editor>
                                                    <f:TextBox ID="tbxMEMO01" runat="server" Required="true" ShowRedStar="true">
                                                    </f:TextBox>
                                                </Editor>
                                         </f:RenderField>
                                      </Columns>
                                      <Listeners>
                                        <f:Listener Event="edit" Handler="onGridAfterEdit" />
                                      </Listeners>
                              </f:Grid>
                           </Items>
                       </f:Panel>
                    </Items>
                </f:Panel>

                <f:Panel runat="server" ID="panelLeftRegion" EnableFrame="false" RegionPosition="Right" RegionSplit="true" EnableCollapse="true" Expanded="false"
                    Width="400px" Title="采购作业查询" ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                    <Items>
                        <f:RadioButtonList ID="FilterDateRadio" Label="日期" runat="server">
                            <f:RadioItem Text="单据日期" Value="1" Selected="true" />
                            <f:RadioItem Text="期望日期" Value="2"  />
                        </f:RadioButtonList>
                        <f:DatePicker runat="server" Required="true" Label="开始日期" DateFormatString="yyyy-MM-dd" EmptyText="请选择开始日期"
                            ID="DatePicker1" ShowRedStar="True">
                        </f:DatePicker>
                        <f:DatePicker ID="DatePicker2" Required="true" Readonly="false" CompareControl="DatePicker1" DateFormatString="yyyy-MM-dd"
                            CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期" Label="结束日期"
                            runat="server" ShowRedStar="True">
                        </f:DatePicker>
                        <f:Button ID="ButtonSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="BtnSearchOrderDep_click"></f:Button>
                    </Items>
                    <Items>
                       <f:Grid ID="Grid1" Title="采购作业列表" ShowHeader="false" ShowBorder="false" runat="server" DataKeyNames="Purchase_ID"
                         EnableCheckBoxSelect="true" KeepCurrentSelection="false" EnableMultiSelect="false" PageSize="15"
                         EnableRowClickEvent="true" OnRowClick="Grid1_RowClick" ><%-- --%>
                         <Columns>
                           <f:RowNumberField />
                           <f:BoundField Width="125px" DataField="Purchase_ID" HeaderText="采购单编码" />
                           <f:BoundField Width="125px" DataField="SHOP_ID" HeaderText="分店编码" ExpandUnusedSpace="true"  />
                           <f:BoundField Width="125px" DataField="SHOP_NAME1" HeaderText="分店名称" ExpandUnusedSpace="true"  />
                         </Columns>
                       </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <f:Window ID="Window3" Width="1000px" Height="800px" Icon="TagBlue" Hidden="true" BodyPadding="10px"
            EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
            IsModal="false" CloseAction="HidePostBack" OnClose="Window3_Close" Layout="Fit">
            <%--<Toolbars>
                <f:Toolbar ID="tools" runat="server">
                    <Items>
                        <f:Button ID="ButtonSearchPROD1" runat="server" Text="查询" Icon="Magnifier" </f:Button> OnClick="ButtonPRODSearch2_Click" >
                    </Items>
                </f:Toolbar>
            </Toolbars>--%>
            <Content>
                <f:Panel runat="server" ID="PanelGrid4" RegionPosition="Right" RegionSplit="true" EnableCollapse="true" Expanded="true"
                    Width="900px" Title="商品资料" ShowBorder="true" ShowHeader="true"
                    BodyPadding="5px">
                    <Items>
                        <f:Panel runat="server" ID="Panel_Search" Hidden="true">
                            <Items>
                                <f:TextBox runat="server" Label="商品编码" ID="ccPROD_ID" Width="240px"  ></f:TextBox>
                                <f:TextBox runat="server" Label="商品名称1" ID="ccPROD_NAME" Width="240px"></f:TextBox>
                                <f:TextBox runat="server" Label="商品首拼" ID="ccPROD_NAME_SPELLING" Width="240px"></f:TextBox>
                                <f:DropDownList Label="商品性质" runat="server" ID="ccPROD_KIND" Width="240px"></f:DropDownList>
                                <f:DropDownList Label="商品类别" runat="server" ID="ccPROD_DEP" Width="240px" ></f:DropDownList>
                                <f:DropDownList Label="商品小类" runat="server" ID="ccPROD_CATE" Width="240px" ></f:DropDownList>
                            </Items>
                        </f:Panel>
                    </Items>
                    <Items>
                        <f:Toolbar runat="server" ID="tool_btn">
                            <Items>
                                <f:Button ID="BtnSearchCon" runat="server" Text="查询" Icon="Add" Hidden="true" OnClick="ButtonPRODSearch_Click"></f:Button>
                                <f:Button ID="BtnAddCon" runat="server" Text="添加" Icon="Add" Hidden="true" OnClick="ButtonPRODAdd_Click"></f:Button>
                                <f:Button ID="BtnEditCon" runat="server" Text="确定" Icon="accept" Hidden="true" ></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Items>
                    <Items>
                       <f:Grid ID="Grid4" Title="商品资料" ShowHeader="false" ShowBorder="false" runat="server" DataKeyNames="PROD_ID,PROD_NAME1"
                         EnableCheckBoxSelect="true" KeepCurrentSelection="true" PageSize="1000"
                         ><%--EnableRowClickEvent="true" OnRowClick="Grid1_RowClick" --%>
                         <Columns>
                           <f:RowNumberField />
                           <f:BoundField Width="125px" DataField="PROD_ID" HeaderText="厂商编码" ExpandUnusedSpace="true"  />
                           <f:BoundField Width="125px" DataField="PROD_NAME1" HeaderText="厂商名称" ExpandUnusedSpace="true"  />
                           <f:BoundField Width="125px" DataField="PROD_ID" HeaderText="商品编号" ExpandUnusedSpace="true"  />
                           <f:BoundField Width="125px" DataField="PROD_NAME1" HeaderText="商品名称" ExpandUnusedSpace="true"  />
                           <f:BoundField Width="125px" DataField="COST" HeaderText="价格1" ExpandUnusedSpace="true"  />
                           <f:BoundField Width="125px" DataField="COST1" HeaderText="价格2" ExpandUnusedSpace="true"  />
                           <f:BoundField Width="125px" DataField="COST2" HeaderText="价格3" ExpandUnusedSpace="true"  />
                         </Columns>
                       </f:Grid>
                    </Items>
                 </f:Panel>
            </Content>
        </f:Window>
    </form>
    <script>
        function renderSTD_UNIT0101(value) {
            switch (value)
            {
                case '1': return "最小单位";
                case '2': return "包装单位";
                case '3': return "外箱单位";
            }
        }

        function onGridAfterEdit(editor, params) {
            var me = this, columnId = params.column.id, rowId = params.record.getId();
            var strSTD_TYPE01 = me.f_getCellValue(rowId, 'STD_UNIT01');
            var strUnit = me.f_getCellValue(rowId, 'UNIT_NAME01');
            var strUnit1 = me.f_getCellValue(rowId, 'UNIT_NAME101');
            var strUnit2 = me.f_getCellValue(rowId, 'UNIT_NAME201');

            var convert1 = me.f_getCellValue(rowId, 'PROD_CONVERT101');
            var convert2 = me.f_getCellValue(rowId, 'PROD_CONVERT201');

            var cost = me.f_getCellValue(rowId, 'SUP_COST01');
            var cost1 = me.f_getCellValue(rowId, 'SUP_COST101');
            var cost2 = me.f_getCellValue(rowId, 'SUP_COST201');

            var std_quan = me.f_getCellValue(rowId, 'STD_QUAN01');
            var tax_num = me.f_getCellValue(rowId, 'Tax_Num01');
            var tax_type = me.f_getCellValue(rowId, 'Tax_Type');
            var tax
            if (tax_type == 0) {
                tax = 0;
            }
            else {
                tax = tax_num.toFixed(4) * std_quan.toFixed(4);
            }
            if (columnId == 'STD_UNIT01') {
                switch (strSTD_TYPE01) {
                    case '1': me.f_updateCellValue(rowId, 'STD_UNIT_NAME01', strUnit);
                        me.f_updateCellValue(rowId, 'STD_CONVERT01', 0);
                        me.f_updateCellValue(rowId, 'STD_PRICE01', cost.toFixed(4));
                        me.f_updateCellValue(rowId, 'Tax01', cost.toFixed(4) * tax.toFixed(4) * 0.01);
                        return;
                    case '2': me.f_updateCellValue(rowId, 'STD_UNIT_NAME01', strUnit1);
                        me.f_updateCellValue(rowId, 'STD_CONVERT01', convert1);
                        me.f_updateCellValue(rowId, 'STD_PRICE01', cost1.toFixed(4));
                        me.f_updateCellValue(rowId, 'Tax01', cost1.toFixed(4) * tax.toFixed(4) * 0.01);
                        return;
                    case '3': me.f_updateCellValue(rowId, 'STD_UNIT_NAME01', strUnit2);
                        me.f_updateCellValue(rowId, 'STD_CONVERT01', convert2);
                        me.f_updateCellValue(rowId, 'STD_PRICE01', cost2.toFixed(4));
                        me.f_updateCellValue(rowId, 'Tax01', cost2.toFixed(4) * tax.toFixed(4) * 0.01);
                        return;
                }
            }

            if (columnId == 'STD_QUAN01')
            {
                if (std_quan == "0")
                {
                    //return false;
                }
                var std_price = me.f_getCellValue(rowId, 'STD_PRICE01');
                var sum_tax = std_price.toFixed(4) * tax.toFixed(4)*0.01;
                me.f_updateCellValue(rowId, 'Tax01', sum_tax.toFixed(4));
            }
        }

        

    </script>
</body>
</html>
