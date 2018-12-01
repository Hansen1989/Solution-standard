<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OUT00List.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SupplyCenter.OUT00List" %>

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
                <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="Center" AutoScroll="true"
                    Title="总部出货" ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                    <Toolbars>
                    <f:Toolbar ID="Toolbar1_1" runat="server">
                      <Items>
                          <f:Button ID="ButtonAdd" runat="server" Text="新增" Icon="Disk" OnClick="BtnAdd_Click"></f:Button>
                          <f:Button ID="ButtonSave" runat="server" Text="保存" Icon="Disk" OnClick="BtnSave_Click"></f:Button>
                          <f:Button ID="ButtonYR" runat="server" Text="引入" Icon="Disk" OnClick="BtnYR_Click"></f:Button>
                          <f:Button ID="ButtonEdit" runat="server" Text="修改" Icon="Disk" OnClick="Btn_MainEdit"></f:Button>
                          <f:Button ID="ButtonCheck" runat="server" Text="核准" Icon="Disk" OnClick="Btn_MainCheck"></f:Button>
                          <f:Button ID="ButtonCancel" runat="server" Text="作废" Icon="Disk" OnClick="Btn_MainCancel"></f:Button>
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
                                    <f:TextBox runat="server" Label="计划单号" ID="tbxOUT_ID" Required="true" ShowRedStar="true" Enabled="false"></f:TextBox>
                                    <f:DatePicker ID="dpINPUT_DATE" Label="单据日期" Required="true" Readonly="false" DateFormatString="yyyy-MM-dd" runat="server" ShowRedStar="True" Enabled="false">
                                    </f:DatePicker>
                                    <f:DropDownList runat="server" ID="ddlStatus" Required="true" ShowRedStar="true" Label="单据状态" Enabled="false">
                                        <f:ListItem Text="存档" Value="1" Selected="true" />
                                        <f:ListItem Text="核准" Value="2" />
                                        <f:ListItem Text="作废" Value="3" />
                                        <f:ListItem Text="已引入" Value="4" />
                                        <f:ListItem Text="关单" Value="5" />
                                    </f:DropDownList>                            
                                </Items>
                            </f:FormRow>

                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                    <f:TextBox runat="server" Label="制单人" ID="tbxUSER_ID" Required="true" ShowRedStar="true" Width="250px" Enabled="false"></f:TextBox>
                                    <f:TextBox runat="server" Label="审核人" ID="tbxAPP_USER" Required="true" ShowRedStar="true" Width="250px" Enabled="false"></f:TextBox>
                                    <f:DatePicker ID="dpAPP_DATETIME" Label="审核时间" Required="true" Readonly="false" DateFormatString="yyyy-MM-dd" runat="server" ShowRedStar="True" Enabled="false">
                                    </f:DatePicker>
                                    <f:DatePicker ID="dpEXPECT_DATE" Label="期望日期" Required="true" Readonly="false" DateFormatString="yyyy-MM-dd" runat="server" ShowRedStar="True" Enabled="false">
                                    </f:DatePicker>
                                </Items>
                            </f:FormRow>

                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                    <f:DropDownList runat="server" Label="到货分店" ID="ddlIN_SHOP" Required="true" ShowRedStar="true" Enabled="false"></f:DropDownList>
                                    <f:CheckBox ID="cbExported" Label="引入标记" runat="server" Enabled="false"></f:CheckBox>
                                    <f:TextBox ID="tbxExported_ID" Label="调入单号" runat="server"  Enabled="false" ></f:TextBox>
                                    <f:TextBox ID="tbxRELATE_ID" Label="关联单号" runat="server"  Enabled="false" ></f:TextBox>

                                </Items>
                            </f:FormRow>

                            <f:FormRow>
                                <Items>
                                    <f:DropDownList runat="server" Label="仓库名称" ID="ddlSTOCK_ID" Required="true" ShowRedStar="true" Enabled="false"></f:DropDownList> 
                                    <f:CheckBox ID="ckLOCKED" Label="月结锁定" runat="server" Enabled="false"></f:CheckBox>  
                                    <f:TextBox runat="server" ID="tbxMemo" Label="备注" Enabled="true"></f:TextBox>
                                    <f:TextBox runat="server" ID="tbxLAST_UPDATE" Label="最后异动时间" Enabled="false"></f:TextBox>
                                </Items>
                            </f:FormRow>

                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                    <f:TextBox runat="server" ID="tbxCRT_DATETIME" Label="建档日期" Enabled="false"></f:TextBox>
                                    <f:TextBox runat="server" ID="tbxCRT_USER_ID" Label="建档人员" Enabled="false"></f:TextBox>
                                    <f:TextBox runat="server" ID="tbxMOD_DATETIME" Label="修改日期" Enabled="false"></f:TextBox>
                                    <f:TextBox runat="server" ID="tbxMOD_USER_ID" Label="修改人员" Enabled="false"></f:TextBox>
                                </Items>
                            </f:FormRow>
                        </Rows>
                     </f:Form>
                    </Items>

                    <Items>
                       <f:Panel ID="Panel12" runat="server" Title="总部出货子表">
                           <Toolbars>
                             <f:Toolbar ID="Toolbar21111" runat="server">
                               <Items>
                                  <f:Button ID="ButtonDetailAdd" runat="server" Text="添加" Icon="Add" OnClick="btn_DetailAdd"></f:Button>
                                   <f:Button ID="ButtonDetailDelete" runat="server" Text="删除" Icon="Delete" OnClick="btn_DetailDelete"></f:Button>
                                  <%--<f:Button ID="Button_Replace" runat="server" Text="替换" Icon="Add"></f:Button>--%>
                               </Items>
                             </f:Toolbar>
                           </Toolbars>
                           <Items>
                              <f:Grid ID="Grid2" Title="验收子表" EnableFrame="false" EnableCollapse="true" ShowHeader="false" runat="server"
                                   DataKeyNames="Id" EnableColumnLines="true" EnableCheckBoxSelect="true" AllowCellEditing="true" ClicksToEdit="1"> 
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
                                        <f:RenderField Width="130px" ColumnID="SHOP_NAME101" DataField="SHOP_NAME1" FieldType="String" Enabled="false"
                                                HeaderText="分店名称">
                                                <Editor>
                                                    <f:TextBox ID="TextBox2" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="130px" ColumnID="OUT_ID01" DataField="OUT_ID" FieldType="String" Enabled="false"
                                                HeaderText=" 进货单号">
                                                <Editor>
                                                    <f:TextBox ID="tbxOUT_ID01" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="130px" ColumnID="SNo01" DataField="SNo" FieldType="String" Enabled="false" Hidden="false"
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
                                         <f:RenderField Width="130px" ColumnID="QUANTITY01" DataField="QUANTITY" FieldType="Int"
                                                HeaderText="最小单位数量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numQUANTITY" NoNegative="true" DecimalPrecision="6" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>

                                         <f:RenderField Width="130px" ColumnID="STD_UNIT01" DataField="STD_UNIT" FieldType="String" Enabled="false"
                                                HeaderText="出货单位类别" RendererFunction="renderSTD_UNIT0101">
                                                <Editor>
                                                    <f:DropDownList ID="ddlSTD_TYPE01" runat="server">
                                                        <f:ListItem Text="最小单位" Value="1" />
                                                        <f:ListItem Text="包装单位" Value="2" />
                                                        <f:ListItem Text="外箱单位" Value="3" />
                                                    </f:DropDownList>
                                                </Editor>
                                         </f:RenderField>

                                         <f:RenderField Width="130px" ColumnID="STD_UNIT_NAME01" DataField="STD_UNIT_NAME" FieldType="String" Enabled="false"
                                                HeaderText="出货单位">
                                                <Editor>
                                                    <f:TextBox ID="TextBox3" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                         </f:RenderField>
                                          <f:RenderField Width="130px" ColumnID="UNIT_NAME01" DataField="UNIT_NAME" FieldType="String" Enabled="false"
                                                HeaderText="最小单位" Hidden="true">
                                                <Editor>
                                                    <f:TextBox ID="TextBox4" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="UNIT_NAME101" DataField="UNIT_NAME1" FieldType="String" Enabled="false"
                                                HeaderText="包装单位" Hidden="true">
                                                <Editor>
                                                    <f:TextBox ID="TextBox5" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="UNIT_NAME201" DataField="UNIT_NAME2" FieldType="String" Enabled="false"
                                                HeaderText="外箱单位" Hidden="true">
                                                <Editor>
                                                    <f:TextBox ID="TextBox6" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                         </f:RenderField>

                                         <f:RenderField Width="130px" ColumnID="STD_CONVERT01" DataField="STD_CONVERT" FieldType="Int" Enabled="false" Hidden="false"
                                                HeaderText="标准转换量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numSTD_CONVERT"></f:NumberBox>
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

                                         <f:RenderField Width="130px" ColumnID="STD_QUAN01" DataField="STD_QUAN" FieldType="String" Enabled="false"
                                                HeaderText="出货量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numSTD_QUAN" NoNegative="true"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="MIN_STD_QUAN01" DataField="MIN_STD_QUAN" FieldType="String" Hidden="true" Enabled="false"
                                                HeaderText="最少出货量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="NumberBox6" NoNegative="true"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="STD_PRICE01" DataField="STD_PRICE" FieldType="String" Enabled="true"
                                                HeaderText="出货单价">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numSTD_PRICE" NoNegative="true" Enabled="true"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>

                                          <f:RenderField Width="130px" ColumnID="STD_PRICE101" DataField="STD_PRICE1" FieldType="String" Enabled="true" Hidden="true"
                                                HeaderText="出货价1">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="NumberBox3" NoNegative="true" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                          <f:RenderField Width="130px" ColumnID="STD_PRICE201" DataField="STD_PRICE2" FieldType="String" Enabled="true" Hidden="true"
                                                HeaderText="出货价2">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="NumberBox4" NoNegative="true" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                          <f:RenderField Width="130px" ColumnID="STD_PRICE301" DataField="STD_PRICE3" FieldType="String" Enabled="true" Hidden="true"
                                                HeaderText="出货价3">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="NumberBox5" NoNegative="true" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>


                                         <f:RenderField Width="130px" ColumnID="COST01" DataField="COST" FieldType="string" Enabled="false"
                                                HeaderText="出货成本">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numCOST" NoNegative="true" ></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>

                                          <f:RenderField Width="130px" ColumnID="COST101" DataField="COST1" FieldType="string" Enabled="true" Hidden="true"
                                                HeaderText="出货成本1">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="costnumbox" NoNegative="true" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                          <f:RenderField Width="130px" ColumnID="COST201" DataField="COST2" FieldType="string" Enabled="true" Hidden="true"
                                                HeaderText="出货成本2">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="NumberBox7" NoNegative="true" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                          <f:RenderField Width="130px" ColumnID="COST301" DataField="COST3" FieldType="string" Enabled="true" Hidden="true"
                                                HeaderText="出货成本3">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="NumberBox8" NoNegative="true" Enabled="false"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>

                                         <f:RenderField Width="130px" ColumnID="QUAN101" DataField="QUAN1" FieldType="Int" Enabled="true"
                                                HeaderText="验收量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numQUAN1" NoNegative="true" DecimalPrecision="6" Enabled="true"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="QUAN201" DataField="QUAN2" FieldType="Int" Enabled="true"
                                                HeaderText="取消量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numQUAN2" NoNegative="true" DecimalPrecision="6" Enabled="true"></f:NumberBox>
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
                                                    <f:TextBox ID="tbxBAT_NO" runat="server" Required="true" ShowRedStar="true">
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
                    Width="400px" Title="总部出货作业查询" ShowBorder="true" ShowHeader="true" BodyPadding="5px" >
                    <Items>
                        <f:RadioButtonList ID="ddrDataType" Label="日期" runat="server">
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
                        <%--<f:DropDownList runat="server" ID="ddlSHOP_NAME1" Required="true" ShowRedStar="true" Label="分店名称" Enabled="false">
                        </f:DropDownList>--%>
                        <f:Button ID="ButtonSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="BtnSearchOrder_click"></f:Button>
                    </Items>
                    <Items>
                       <f:Grid ID="Grid1" Title="总部出货作业列表" ShowHeader="false" ShowBorder="false" runat="server" DataKeyNames="OUT_ID"
                         EnableCheckBoxSelect="true" EnableMultiSelect="false" EnableRowClickEvent="true" OnRowClick="Grid1_RowClick" >
                         <Columns>
                           <f:RowNumberField />
                           <f:BoundField Width="125px" DataField="OUT_ID" HeaderText="进货单号" />
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
        <f:Window ID="Window4" Width="1000px" Height="800px" Icon="TagBlue" Hidden="true" BodyPadding="10px"
            EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
            IsModal="false" CloseAction="HidePostBack" OnClose="Window3_Close" Layout="Fit">
            <Content>
                <f:Panel runat="server" ID="PanelGrid5" RegionPosition="Right" RegionSplit="true" EnableCollapse="true" Expanded="true"
                    Width="900px" Title="要货单" ShowBorder="true" ShowHeader="true"
                    BodyPadding="5px">
                    <Items>
                        <f:Panel runat="server" ID="Panel_Search2" Hidden="false" >
                            <Items>
                                
                                <f:RadioButtonList ID="ddrDataType" Label="日期" runat="server">
                                    <f:RadioItem Text="单据日期" Value="1" Selected="true" />
                                    <f:RadioItem Text="期望日期" Value="2"  />
                                </f:RadioButtonList>
                                <f:DatePicker runat="server" Required="true" Label="开始日期" DateFormatString="yyyy-MM-dd" EmptyText="请选择开始日期"
                                    ID="dpSt" ShowRedStar="True">
                                </f:DatePicker>
                                <f:DatePicker ID="dpEt" Required="true" Readonly="false" CompareControl="DatePicker1" DateFormatString="yyyy-MM-dd"
                                     CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期" Label="结束日期"
                                     runat="server" ShowRedStar="True">
                                </f:DatePicker>
                                <f:DropDownList runat="server" Label="分店名称" ID="w4_ddlSHOP_NAME" Required="true" ShowRedStar="true" Enabled="true"></f:DropDownList>
                            </Items>
                        </f:Panel>
                    </Items>
                    <Items>
                        <f:Toolbar runat="server" ID="tool_btn2">
                            <Items>
                                <f:Button ID="BtnSearchCon" runat="server" Text="查询" Icon="Add" Hidden="false" OnClick="ButtonOrderSearch_Click"></f:Button>
                                <f:Button ID="BtnAddCon" runat="server" Text="确定" Icon="accept" Hidden="false" OnClick="ButtonOrderAdd_Click"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Items>
                    <Items>
                       <f:Grid ID="Grid4" Title="要货订单" ShowHeader="false" ShowBorder="false" runat="server" DataKeyNames="ORDER_ID"
                         EnableCheckBoxSelect="true" KeepCurrentSelection="true" PageSize="1000"
                         >
                         <Columns>
                           <f:RowNumberField />
                           <f:BoundField Width="125px" DataField="ORDER_ID" HeaderText="要货单号码" ExpandUnusedSpace="true"  />
                           <f:BoundField Width="125px" DataField="SHOP_ID" HeaderText="分店编码" ExpandUnusedSpace="true"  />
                           <f:BoundField Width="125px" DataField="SHOP_NAME" HeaderText="分店名称" ExpandUnusedSpace="true"  />
                           <f:BoundField Width="125px" DataField="INPUT_DATE" HeaderText="单据日期" ExpandUnusedSpace="true"  />
                           <f:BoundField Width="125px" DataField="EXPECT_DATE" HeaderText="期望日期" ExpandUnusedSpace="true"  />
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



            var cost = me.f_getCellValue(rowId, 'COST01');
            var cost1 = me.f_getCellValue(rowId, 'COST101');
            var cost2 = me.f_getCellValue(rowId, 'COST201');

            var std_price = me.f_getCellValue(rowId, 'STD_PRICE101');
            var std_price1 = me.f_getCellValue(rowId, 'STD_PRICE201');
            var std_price2 = me.f_getCellValue(rowId, 'STD_PRICE301');

            var std_quan = me.f_getCellValue(rowId, 'STD_QUAN01');

            if (columnId == 'STD_UNIT01') {
                switch (strSTD_TYPE01) {
                    case '1': me.f_updateCellValue(rowId, 'STD_UNIT_NAME01', strUnit);
                        me.f_updateCellValue(rowId, 'STD_CONVERT01', 0);
                        me.f_updateCellValue(rowId, 'STD_PRICE01', std_price);
                        me.f_updateCellValue(rowId, 'COST01', cost);
                        return;
                    case '2': me.f_updateCellValue(rowId, 'STD_UNIT_NAME01', strUnit1);
                        me.f_updateCellValue(rowId, 'STD_CONVERT01', convert1);
                        me.f_updateCellValue(rowId, 'STD_PRICE01', std_price1);
                        me.f_updateCellValue(rowId, 'COST01', cost1);
                        return;
                    case '3': me.f_updateCellValue(rowId, 'STD_UNIT_NAME01', strUnit2);
                        me.f_updateCellValue(rowId, 'STD_CONVERT01', convert2);
                        me.f_updateCellValue(rowId, 'STD_PRICE01', std_price2);
                        me.f_updateCellValue(rowId, 'COST01', cost2);
                        return;
                }
            }
        }

    </script>



</body>
</html>
