<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IN00List.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SupplyCenter.IN00List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" ShowBorder="false" ShowHeader="false" Layout="Region">
            <Items>
                <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="Center"
                    Title="总部进货作业信息" ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                    <Toolbars>
                    <f:Toolbar ID="Toolbar1" runat="server">
                      <Items>
                          <f:Button ID="ButtonCheck" runat="server" Text="核准" Icon="Disk"></f:Button>
                          <f:Button ID="ButtonCancel" runat="server" Text="作废" Icon="Disk"></f:Button>
                      </Items>
                      </f:Toolbar>
                    </Toolbars>
                    <Items>
                     <f:Form ID="Form5" LabelAlign="Left"  BodyPadding="5px" LabelWidth="90px" EnableCollapse="true"
                            runat="server" Title="表单" ShowBorder="true" ShowHeader="false">
                        <Rows>
                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                    <f:DropDownList runat="server" Label="分店名称" ID="ddlSHOP_NAME" Required="true" ShowRedStar="true" Enabled="false"></f:DropDownList> 
                                    <f:TextBox runat="server" Label="计划单号" ID="tbxIN_ID" Required="true" ShowRedStar="true" Enabled="false"></f:TextBox>
                                    <f:DatePicker ID="dpINPUT_DATE" Label="单据日期" Required="true" Readonly="false" DateFormatString="yyyy-MM-dd" runat="server" ShowRedStar="True" Enabled="false">
                                    </f:DatePicker>
                                    <f:DropDownList runat="server" ID="ddlStatus" Required="true" ShowRedStar="true" Label="单据状态" Enabled="false">
                                        <f:ListItem Text="存档" Value="1" Selected="true" />
                                        <f:ListItem Text="核准" Value="2" />
                                        <f:ListItem Text="作废" Value="3" />
                                        <f:ListItem Text="关单" Value="5" />
                                    </f:DropDownList>                            
                                </Items>
                            </f:FormRow>

                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                    <f:DropDownList runat="server" Label="出货分店" ID="ddlOUT_SHOP" Required="true" ShowRedStar="true" Enabled="false"></f:DropDownList> 
                                    <f:DropDownList runat="server" Label="仓库名称" ID="ddlSTOCK_ID" Required="true" ShowRedStar="true" Enabled="false"></f:DropDownList>
                                    <f:TextBox runat="server" Label="制单人" ID="tbxUSER_ID" Required="true" ShowRedStar="true" Width="250px" Enabled="false"></f:TextBox>
                                    <f:TextBox runat="server" Label="审核人" ID="tbxAPP_USER" Required="true" ShowRedStar="true" Width="250px" Enabled="false"></f:TextBox>
                                    <f:DatePicker ID="dpAPP_DATETIME" Label="审核时间" Required="true" Readonly="false" DateFormatString="yyyy-MM-dd" runat="server" ShowRedStar="True" Enabled="false">
                                    </f:DatePicker>
                                </Items>
                            </f:FormRow>

                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                    <f:TextBox ID="tbxRELATE_ID" Label="关联单号" runat="server"  Enabled="false" ></f:TextBox>
                                    <f:CheckBox ID="cbLOCKED" Text="月结锁定" runat="server" Enabled="false"></f:CheckBox> 
                                    <f:TextBox runat="server" ID="tbxMemo" Label="备注" Enabled="true"></f:TextBox> 
                                </Items>
                            </f:FormRow>
                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                    <f:TextBox runat="server" ID="tbxCRT_DATETIME" Label="建档日期" Enabled="false"></f:TextBox>
                                    <f:TextBox runat="server" ID="tbxCRT_USER_ID" Label="建档人员" Enabled="false"></f:TextBox>
                                    <f:TextBox runat="server" ID="tbxMOD_DATETIME" Label="修改日期" Enabled="false"></f:TextBox>
                                    <f:TextBox runat="server" ID="tbxMOD_USER_ID" Label="修改人员" Enabled="false"></f:TextBox>
                                    <f:TextBox runat="server" ID="tbxLAST_UPDATE" Label="最后异动时间" Enabled="false"></f:TextBox>
                                </Items>
                            </f:FormRow>
                        </Rows>
                     </f:Form>
                    </Items>

                    <Items>
                       <f:Panel ID="Panel12" runat="server" Title="出货作业字表">
                           <Toolbars>
                             <f:Toolbar ID="Toolbar21111" runat="server">
                               <Items>
                                  <f:Button ID="ButtonPur02Add" runat="server" Text="添加" Icon="Add"></f:Button>
                                  <f:Button ID="Button_Replace" runat="server" Text="替换" Icon="Add"></f:Button>
                               </Items>
                             </f:Toolbar>
                           </Toolbars>
                           <Items>
                              <f:Grid ID="Grid2" Title="进货子表" EnableFrame="false" EnableCollapse="true" ShowHeader="false" runat="server" Height="600px"
                                   DataKeyNames="Id" EnableColumnLines="true" AllowPaging="true"
                                    EnableCheckBoxSelect="true" AllowCellEditing="true" ClicksToEdit="1"> 
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
                                                HeaderText="分店编号">
                                                <Editor>
                                                    <f:TextBox ID="tbxSHOP_ID01" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="130px" ColumnID="SHOP_NAME01" DataField="SHOP_NAME" FieldType="String" Enabled="false"
                                                HeaderText="分店名称">
                                                <Editor>
                                                    <f:TextBox ID="TextBox2" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="130px" ColumnID="IN_ID01" DataField="IN_ID" FieldType="String" Enabled="false"
                                                HeaderText=" 进货单号">
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
                                          <f:RenderField Width="130px" ColumnID="PROD_NAME01" DataField="PROD_NAME" FieldType="String" Enabled="false"
                                                HeaderText="商品名称">
                                                <Editor>
                                                    <f:TextBox ID="TextBox1" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="QUANTITY01" DataField="QUANTITY" FieldType="Int"
                                                HeaderText="最小单位数量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numQUANTITY" NoNegative="true" DecimalPrecision="6" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="STD_UNIT01" DataField="STD_UNIT" FieldType="String" Enabled="false"
                                                HeaderText="入库单位">
                                                <Editor>
                                                    <f:TextBox ID="tbxSTD_UNIT01" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="STD_CONVERT01" DataField="STD_CONVERT" FieldType="Int" Enabled="false" Hidden="false"
                                                HeaderText="标准转换量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numSTD_CONVERT"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="STD_QUAN01" DataField="STD_QUAN" FieldType="Float" Enabled="false"
                                                HeaderText="入库量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numSTD_QUAN" NoNegative="true" DecimalPrecision="6"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="STD_PRICE01" DataField="STD_PRICE" FieldType="Float" Enabled="false"
                                                HeaderText="入库单价">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numSTD_PRICE" NoNegative="true" DecimalPrecision="6"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="COST01" DataField="COST" FieldType="Int" Enabled="false"
                                                HeaderText="入库成本">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numTax" NoNegative="true" DecimalPrecision="6"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="QUAN101" DataField="QUAN1" FieldType="Int" Enabled="false"
                                                HeaderText="验出货量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numQUAN1" NoNegative="true" DecimalPrecision="6" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="QUAN201" DataField="QUAN2" FieldType="Int" Enabled="false"
                                                HeaderText="取消量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numQUAN2" NoNegative="true" DecimalPrecision="6" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="MEMO01" DataField="MEMO" FieldType="String" Enabled="True"
                                                HeaderText="备注">
                                                <Editor>
                                                    <f:TextBox ID="tbxMEMO01" runat="server" Required="true" ShowRedStar="true">
                                                    </f:TextBox>
                                                </Editor>
                                         </f:RenderField>
                                          <f:RenderField Width="130px" ColumnID="BAT_NO" DataField="BAT_NO" FieldType="String" Enabled="True"
                                                HeaderText="批号">
                                                <Editor>
                                                    <f:TextBox ID="TextBox3" runat="server" Required="true" ShowRedStar="true">
                                                    </f:TextBox>
                                                </Editor>
                                         </f:RenderField>
                                          <f:RenderField Width="130px" ColumnID="Exp_DateTime01" DataField="Exp_DateTime" FieldType="String" Enabled="True"
                                                HeaderText="有效日期">
                                                <Editor>
                                                    <f:DatePicker ID="dpExp_DateTime01" Required="true" Readonly="false" DateFormatString="yyyy-MM-dd" runat="server" ShowRedStar="True" Enabled="false">
                                                    </f:DatePicker>
                                                </Editor>
                                         </f:RenderField>
                                      </Columns>
                              </f:Grid>
                           </Items>
                       </f:Panel>
                    </Items>
                </f:Panel>

                <f:Panel runat="server" ID="panelLeftRegion" EnableFrame="false" RegionPosition="Right" RegionSplit="true" EnableCollapse="true" Expanded="false"
                    Width="400px" Title="验收作业查询" ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                    <Items>
                        <f:RadioButtonList ID="FilterDateRadio" Label="日期" runat="server">
                            <f:RadioItem Text="单据日期" Value="1" Selected="true" />
                            <f:RadioItem Text="审核时间" Value="2"  />
                        </f:RadioButtonList>
                        <f:DatePicker runat="server" Required="true" Label="开始日期" DateFormatString="yyyy-MM-dd" EmptyText="请选择开始日期"
                            ID="DatePicker1" ShowRedStar="True">
                        </f:DatePicker>
                        <f:DatePicker ID="DatePicker2" Required="true" Readonly="false" CompareControl="DatePicker1" DateFormatString="yyyy-MM-dd"
                            CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期" Label="结束日期"
                            runat="server" ShowRedStar="True">
                        </f:DatePicker>
                        <f:DropDownList runat="server" ID="ddlSHOP_NAME1" Required="true" ShowRedStar="true" Label="分店名称" Enabled="false">
                        </f:DropDownList>
                        <f:Button ID="ButtonSearch" runat="server" Text="查询" Icon="Magnifier"></f:Button>
                    </Items>
                    <Items>
                       <f:Grid ID="Grid1" Title="验收作业列表" ShowHeader="false" ShowBorder="false" runat="server" DataKeyNames="Id"
                         EnableCheckBoxSelect="true" KeepCurrentSelection="false" EnableMultiSelect="false" PageSize="15"
                         EnableRowClickEvent="true"  ><%--OnRowClick="Grid1_RowClick" --%>
                         <Columns>
                           <f:RowNumberField />
                           <f:BoundField Width="125px" DataField="Purchase_ID" HeaderText="进货单号" />
                           <f:BoundField Width="125px" DataField="SHOP_ID" HeaderText="分店编码" ExpandUnusedSpace="true"  />
                           <f:BoundField Width="125px" DataField="SHOP_NAME1" HeaderText="分店名称" ExpandUnusedSpace="true"  />
                         </Columns>
                       </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
