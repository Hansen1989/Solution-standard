<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventory00List.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SupplyCenter.Inventory00List" %>

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
                    Title="盘点作业" ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                    <Toolbars>
                    <f:Toolbar ID="Toolbar1_1" runat="server">
                      <Items>
                          <f:Button ID="ButtonAdd" runat="server" Text="新增" Icon="Disk" OnClick="BtnAdd_Click"></f:Button>
                          <f:Button ID="ButtonSave" runat="server" Text="保存" Icon="Disk" OnClick="BtnSave_Click"></f:Button>
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
                                    <f:TextBox runat="server" Label="盘点单号" ID="tbxINV_ID" Required="true" ShowRedStar="true" Enabled="false"></f:TextBox>
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
                                    <f:DropDownList runat="server" ID="ddlINV_TYPE" Required="true" ShowRedStar="true" Label="盘点类型" Enabled="false">
                                        <f:ListItem Text="日盘" Value="1" Selected="true" />
                                        <f:ListItem Text="周盘" Value="2" />
                                        <f:ListItem Text="月盘" Value="3" />
                                        <f:ListItem Text="全盘" Value="4" />
                                    </f:DropDownList> 
                                    <f:DropDownList runat="server" Label="仓库名称" ID="ddlSTOCK_ID" Required="true" ShowRedStar="true" Enabled="false"></f:DropDownList> 
                                    <f:TextBox runat="server" Label="制单人" ID="tbxUSER_ID" Required="true" ShowRedStar="true" Width="250px" Enabled="false"></f:TextBox>
                                    <f:TextBox runat="server" Label="审核人" ID="tbxAPP_USER" Required="true" ShowRedStar="true" Width="250px" Enabled="false"></f:TextBox>
                                    <f:DatePicker ID="dpAPP_DATETIME" Label="审核时间" Required="true" Readonly="false" DateFormatString="yyyy-MM-dd" runat="server" ShowRedStar="True" Enabled="false">
                                    </f:DatePicker>
                                </Items>
                            </f:FormRow>

                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                    <f:TextBox runat="server" ID="tbxMemo" Label="备注" Enabled="true"></f:TextBox>
                                    <f:CheckBox ID="ckLOCKED" Text="月结锁定" runat="server" Enabled="false"></f:CheckBox>  
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
                       <f:Panel ID="Panel12" runat="server" Title="盘点作业子表">
                           <Toolbars>
                             <f:Toolbar ID="Toolbar21111" runat="server" Hidden="false">
                               <Items>
                                   <f:Button ID="ButtonDetailAdd" runat="server" Text="添加" Icon="Add" OnClick="btn_DetailAdd"></f:Button>
                                   <f:Button ID="ButtonDetailDelete" runat="server" Text="添加" Icon="Delete"></f:Button>
                                  <%--<f:Button ID="Button_Replace" runat="server" Text="替换" Icon="Add"></f:Button>--%>
                               </Items>
                             </f:Toolbar>
                           </Toolbars>
                           <Items>
                              <f:Grid ID="Grid2" Title="盘点作业子表" EnableFrame="false" EnableCollapse="true" ShowHeader="false" runat="server" Height="600px"
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
                                        <f:RenderField Width="130px" ColumnID="SHOP_NAME101" DataField="SHOP_ID" FieldType="String" Enabled="false"
                                                HeaderText="分店名称">
                                                <Editor>
                                                    <f:TextBox ID="TextBox2" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="130px" ColumnID="INV_ID01" DataField="INV_ID" FieldType="String" Enabled="false"
                                                HeaderText=" 盘点单号">
                                                <Editor>
                                                    <f:TextBox ID="tbxDP_ID01" runat="server" Required="true" ShowRedStar="true" Enabled="false">
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
                                          <f:RenderField Width="130px" ColumnID="PROD_NAME101" DataField="PROD_NAME1" FieldType="String" Enabled="false"
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
                                         <f:RenderField Width="130px" ColumnID="QUAN01" DataField="QUAN" FieldType="String" Enabled="false"
                                                HeaderText="外箱单位数量">
                                                <Editor>
                                                    <f:NumberBox ID="numQUAN01" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="QUAN101" DataField="QUAN1" FieldType="Int" Enabled="false" Hidden="false"
                                                HeaderText="包装单位数量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numQUAN1"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="QUAN201" DataField="QUAN2" FieldType="Float" Enabled="false"
                                                HeaderText="零散量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numQUAN2" NoNegative="true" DecimalPrecision="6"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="QUAN_B01" DataField="QUAN_B" FieldType="Float" Enabled="false"
                                                HeaderText="盘点前量">
                                                <Editor>
                                                    <f:NumberBox runat="server" ID="numQUAN_B" NoNegative="true" DecimalPrecision="6"></f:NumberBox>
                                                </Editor>
                                         </f:RenderField>
                                         <f:RenderField Width="130px" ColumnID="MEMO01" DataField="MEMO" FieldType="String" Enabled="True"
                                                HeaderText="备注">
                                                <Editor>
                                                    <f:TextBox ID="tbxMEMO01" runat="server" Required="true" ShowRedStar="true">
                                                    </f:TextBox>
                                                </Editor>
                                         </f:RenderField>
                                      </Columns>
                              </f:Grid>
                           </Items>
                       </f:Panel>
                    </Items>
                </f:Panel>

                <f:Panel runat="server" ID="panelLeftRegion" EnableFrame="false" RegionPosition="Right" RegionSplit="true" EnableCollapse="true" Expanded="false"
                    Width="400px" Title="盘点单" ShowBorder="true" ShowHeader="true" BodyPadding="5px" >
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
                        <f:DropDownList runat="server" ID="ddlSTOCK_NAME1" Required="true" ShowRedStar="true" Label="仓库名称" Enabled="false">
                        </f:DropDownList>
                        <f:Button ID="ButtonSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="BtnSearchOrder_click"></f:Button>
                    </Items>
                    <Items>
                       <f:Grid ID="Grid1" Title="盘点作业列表" ShowHeader="false" ShowBorder="false" runat="server" DataKeyNames="INV_ID"
                         EnableCheckBoxSelect="true" KeepCurrentSelection="false" EnableMultiSelect="false" PageSize="15"
                         EnableRowClickEvent="true" OnRowClick="Grid1_RowClick" >
                         <Columns>
                           <f:RowNumberField />
                           <f:BoundField Width="125px" DataField="INPUT_DATE" HeaderText="单据日期" ExpandUnusedSpace="true"  />
                           <f:BoundField Width="125px" DataField="INV_ID" HeaderText="盘点单号" />
                           <f:BoundField Width="125px" DataField="STOCK_NAKE" HeaderText="仓库名称" ExpandUnusedSpace="true"  />
                         </Columns>
                       </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <f:Window ID="Window4" Width="400px" Height="200px" Icon="TagBlue" Hidden="true" BodyPadding="10px"
            EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true" Title="选择"
            IsModal="false" CloseAction="HidePostBack" OnClose="Window3_Close" Layout="Fit">
            <Content>
                <f:Panel runat="server" ID="PanelGrid4" RegionPosition="center" RegionSplit="true" EnableCollapse="false" Expanded="true"
                    Width="300px" Title="选择" ShowBorder="false" ShowHeader="false"
                    BodyPadding="5px">
                    <Items>
                        <f:Panel runat="server" ID="Panel_Search" Hidden="true">
                            <Items>
                               <f:DropDownList runat="server" ID="window_ddl_INV_TYPE" Required="true" ShowRedStar="true" Label="盘点类型" Enabled="true">
                                                <f:ListItem Text="日盘" Value="1" Selected="true" />
                                                <f:ListItem Text="周盘" Value="2" />
                                                <f:ListItem Text="月盘" Value="3" />
                                                <f:ListItem Text="全盘" Value="4" />
                               </f:DropDownList> 
                                <f:DropDownList runat="server" ID="window_ddl_Stock" Required="true" ShowRedStar="true" Label="盘点仓库" Enabled="true">
                               </f:DropDownList> 
                            </Items>
                        </f:Panel>
                    </Items>
                    <Items>
                        <f:Toolbar runat="server" ID="tool_btn">
                            <Items>
                                <f:Button ID="B_BtnAddCon" runat="server" Text="确定" Icon="Add" Hidden="false" OnClick="ButtonStockAdd_Click"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Items>
                 </f:Panel>
            </Content>
        </f:Window>  
    <f:Window ID="Window3" Width="1000px" Height="800px" Icon="TagBlue" Hidden="true" BodyPadding="10px"
            EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
            IsModal="false" CloseAction="HidePostBack" OnClose="Window3_Close" Layout="Fit">
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
</body>
</html>
