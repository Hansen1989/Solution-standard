<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product00List.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.DataCenter.Product00List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" ShowBorder="false" ShowHeader="false" Layout="Region">
            <Items>
                <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="Center"
                    Title="商品详细资料" ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                    <Toolbars>
                    <f:Toolbar ID="Toolbar1" runat="server">
                      <Items>
                          <f:Button ID="Button1" runat="server" Text="清空" Icon="ArrowRefresh" OnClick="ButtonClear_Click"  CssClass="inline"></f:Button>
                          <f:Button ID="ButtonAdd" runat="server" Text="新增" Icon="Disk" OnClick="ButtonSave_Click" ></f:Button>
                          <f:Button ID="ButtonUpdate" runat="server" Text="修改" Icon="Disk" OnClick="ButtonUpdate_Click" ></f:Button>
                      </Items>
                      </f:Toolbar>
                    </Toolbars>
                    <Items>
                     <f:Form ID="Form5" LabelAlign="Left"  BodyPadding="5px" LabelWidth="90px" EnableCollapse="true"
                            runat="server" Title="表单" ShowBorder="true" ShowHeader="false">
                                <Rows>
                                    <f:FormRow ColumnWidths="300px">
                                    <Items>
                                        <f:TextBox runat="server" Label="商品编号"  ID="PROD_ID" Required="true" ShowRedStar="true" Width="250px" EmptyText="商品编号" AutoPostBack="true" OnTextChanged="PROD_ID_TextChanged"></f:TextBox>
                                        <f:TextBox runat="server" Label="商品名称1" ID="PROD_NAME1" Required="true" ShowRedStar="true" Width="250px" EmptyText="商品名称1" EnableBlurEvent="true" OnBlur="PROD_NAME1_Blur" ></f:TextBox>
                                        <f:TextBox runat="server" Label="商品首拼" ID="PROD_NAME1_SPELLING" Required="true" ShowRedStar="true" Width="250px" EmptyText="首拼" ></f:TextBox>
                                        <f:TextBox runat="server" Label="商品名称2" ID="PROD_NAME2" Required="true" Width="250px" EmptyText="商品名称2" ></f:TextBox>
                                    </Items>
                                    </f:FormRow>
                                    <f:FormRow>
                                    <Items>
                                        <f:DropDownList ID="PROD_KIND" Label="商品性质" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                        </f:DropDownList>
                                        <f:DropDownList ID="PROD_DEP" Label="商品类别" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                        </f:DropDownList>
                                        <f:DropDownList ID="PROD_CATE" Label="商品小类" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" >
                                        </f:DropDownList>
                                    </Items>
                                    </f:FormRow>
                                    <f:FormRow>
                                    <Items>
                                        <f:DropDownList ID="DIV_ID" Label="隶属部门" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" >
                                        </f:DropDownList>
                                        <f:DropDownList ID="PROD_TYPE" Label="商品属性" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="自产类" Value="0" Selected="true"  />
                                            <f:ListItem Text="供应类" Value="1" />
                                            <f:ListItem Text="委托加工类" Value="2" />
                                        </f:DropDownList>
                                        <f:DropDownList ID="PROD_Source" Label="商品来源" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="总部" Value="0" Selected="true" />
                                            <f:ListItem Text="分店" Value="1" />
                                        </f:DropDownList>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                        <f:DropDownList ID="INV_TYPE" Label="盘点类型" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="不盘" Value="0" />
                                            <f:ListItem Text="日盘" Value="1" />
                                            <f:ListItem Text="周盘" Value="2" />
                                            <f:ListItem Text="月盘" Value="3" Selected="true"  />
                                            <f:ListItem Text="全盘" Value="4" />
                                        </f:DropDownList>
                                        <f:DropDownList ID="STOCK_TYPE" Label="库存属性" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="不扣除" Value="0" />
                                            <f:ListItem Text="扣自身" Value="1" Selected="true" />
                                            <f:ListItem Text="扣配方" Value="2" />                                
                                        </f:DropDownList>
                                        <f:DropDownList ID="BOM_TYPE" Label="配方层次" AutoPostBack="true" Required="true" CompareType="String" Enabled="false"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="依配方层次拆解" Value="1" />
                                            <f:ListItem Text="依配方资料拆解" Value="2" />
                                        </f:DropDownList>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                        <f:DropDownList ID="MarginControl" Label="余量控制" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="大缸生产" Value="1" Selected="true" />
                                            <f:ListItem Text="余量生成" Value="2" />
                                        </f:DropDownList>
                                        <f:DropDownList ID="PROD_RangTYPE" Label="称重误差" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="百分比" Value="1" Selected="true" />
                                            <f:ListItem Text="固定数值" Value="2" />
                                        </f:DropDownList>
                                        <f:NumberBox ID="PROD_iRang" runat="server" EmptyText="最小单位数值，不能负数。" Label="称重误差数值" Text="0"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" Width="250px" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                        <f:TextBox runat="server" Label="商品规格" ID="PROD_SPEC" Width="250px" EmptyText="商品规格"></f:TextBox>
                                        <f:TextBox runat="server" Label="产地" ID="PROD_Margin" Width="250px" EmptyText="产地"></f:TextBox>
                                        <f:TextBox runat="server" Label="条码" ID="PROD_BARCODE" Width="250px" EmptyText="条码"></f:TextBox>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                     <f:Panel ID="convertPanel" Layout="HBox" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="0px" 
                                         RegionSplit="true" EnableCollapse="true">
                                     <Items>
                                        <f:DropDownList ID="PROD_UNIT" Label="最小单位" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        </f:DropDownList>
                                        <f:NumberBox ID="PROD_CONVERT1" runat="server" EmptyText="0" Label="包装设定" Width="200px"
                                            NoDecimal="true" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:Label ID="PROD_UNIT_SHOW" Text="个" runat="server">
                                        </f:Label>
                                        <f:Label ID="Label1" Text="= 1 " runat="server">
                                        </f:Label>
                                        <f:DropDownList ID="PROD_UNIT1" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="100px" ShowRedStar="true">
                                        </f:DropDownList>
                                        <f:NumberBox ID="PROD_CONVERT2" runat="server" EmptyText="0" Label="外箱设定"  Width="200px"
                                             NoDecimal="true" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:Label ID="PROD_UNIT_SHOW2" Text="个" runat="server">
                                        </f:Label>
                                        <f:Label ID="Label3" Text="= 1 " runat="server">
                                        </f:Label>
                                        <f:DropDownList ID="PROD_UNIT2" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="100px" ShowRedStar="true">
                                        </f:DropDownList>
                                        </Items>
                                        </f:Panel>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                        <f:DropDownList ID="Report_UNIT" Label="报表单位" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="最小单位" Value="1" Selected="true" />
                                            <f:ListItem Text="包装单位" Value="2" />
                                            <f:ListItem Text="外箱单位" Value="3" />
                                        </f:DropDownList>
                                            <f:TextBox runat="server" Label="备注" ID="PROD_MEMO" Width="500px" EmptyText="备注"></f:TextBox>
                                            <f:HiddenField runat="server" ID="hidId" Text="0"></f:HiddenField>
                                            <f:HiddenField runat="server" ID="hidPROD_Id" Text="0"></f:HiddenField>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                         <f:TextBox runat="server" Label="创建者" ID="CRT_USER_ID" Width="500px" EmptyText="创建者" Enabled="false"  ></f:TextBox>
                                         <f:TextBox runat="server" Label="创建日期" ID="CRT_DATETIME" Width="500px" EmptyText="创建日期" Enabled="false" ></f:TextBox>
                                         <f:TextBox runat="server" Label="修改人" ID="MOD_USER_ID" Width="500px" EmptyText="修改人" Enabled="false" ></f:TextBox>
                                         <f:TextBox runat="server" Label="修改日期" ID="MOD_USER_DATE" Width="500px" EmptyText="修改日期" Enabled="false" ></f:TextBox>
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
                      <f:Button ID="Button4123" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click" ></f:Button>
                      </Items>
                      </f:Toolbar>
                    </Toolbars>
                        <Items>
                        <f:Grid ID="Grid2" Title="商品设定" EnableFrame="false" EnableCollapse="true" AllowSorting="true" SortField="Depth" SortDirection="ASC" 
                               PageSize="15" ShowBorder="true" ShowHeader="true" AllowPaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id" EnableColumnLines="true"
                               AllowCellEditing="true" ClicksToEdit="1"> 
                           <Columns>
                            <f:TemplateField ColumnID="rPRCAREA_ID" Width="60px" HeaderText="序号" Hidden="true">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("PRCAREA_ID") %>'></asp:Label>
                                </ItemTemplate>
                           </f:TemplateField>
                           <%--<f:RowNumberField />--%>
                           <f:RenderField Width="100px" ColumnID="Id" DataField="Id" FieldType="String" Enabled="false"
                                HeaderText="商品编码" >
                                <Editor>
                                    <f:TextBox ID="ftId" runat="server" Required="true" ShowRedStar="true"></f:TextBox>
                                </Editor>
                           </f:RenderField>

                           <f:RenderField Width="100px" ColumnID="PROD_ID" DataField="PROD_ID" FieldType="String"
                                HeaderText="商品编码" >
                                <Editor>
                                    <f:TextBox ID="ftPROD_ID" runat="server" Required="true" ShowRedStar="true"></f:TextBox>
                                </Editor>
                           </f:RenderField>

                           <f:RenderField Width="100px" ColumnID="PRCAREA_ID" DataField="PRCAREA_ID" FieldType="String" Enabled="false"
                                HeaderText="价格区编码">
                                <Editor>
                                    <f:TextBox ID="tbxPRCAREA_ID" runat="server" Enabled="false" Required="true" ShowRedStar="true">
                                    </f:TextBox>
                                </Editor>
                           </f:RenderField>
                           <f:RenderField Width="100px" ColumnID="PRCAREA_NAME" DataField="PRCAREA_NAME" FieldType="String" Enabled="false"
                                HeaderText="价格区名称">
                                <Editor>
                                    <f:TextBox ID="tbxPRCAREA_NAME" runat="server" Enabled="false" Required="true" ShowRedStar="true">
                                    </f:TextBox>
                                </Editor>
                           </f:RenderField>
                          <f:RenderField Width="100px" ColumnID="SUP_ID" DataField="SUP_ID" FieldType="String"
                                HeaderText="厂商编码" >
                                <Editor>
                                     <f:DropDownList ID="ddlSUPID" runat="server">
                                    </f:DropDownList>
                                </Editor>
                           </f:RenderField>

                           <f:RenderField Width="100px" ColumnID="SEND_TYPE" DataField="SEND_TYPE" FieldType="Int"
                              RendererFunction="renderSENDTYPE" HeaderText="厂商送货形式">
                            <Editor>
                                <f:DropDownList ID="ddlSENDTYPE" Required="true" runat="server" ShowRedStar="true">
                                    <f:ListItem Text="直送总部" Value="1" />
                                    <f:ListItem Text="直送门店" Value="2" />
                                </f:DropDownList>
                            </Editor>
                         </f:RenderField>
                         <f:RenderField Width="100px" ColumnID="TAX_TYPE" DataField="TAX_TYPE" FieldType="Int"
                              RendererFunction="renderTAXTYPE" HeaderText="税别">
                            <Editor>
                                <f:DropDownList ID="ddlTAXTYPE" Required="true" runat="server" ShowRedStar="true">
                                    <f:ListItem Text="不含税" Value="0" />
                                    <f:ListItem Text="内含税" Value="1" />
                                    <f:ListItem Text="外加税" Value="2" />
                                </f:DropDownList>
                            </Editor>
                         </f:RenderField>
                        <f:RenderField Width="100px" ColumnID="Tax" DataField="Tax" Enabled="true"
                                HeaderText="税率">
                                <Editor>
                                    <f:NumberBox ID="numTAX" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>

                         <f:RenderField Width="100px" ColumnID="SUP_COST" DataField="SUP_COST" Enabled="true"
                                HeaderText="厂商进货价(最小单位)">
                                <Editor>
                                    <f:NumberBox ID="numSUPCOST" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderField Width="100px" ColumnID="SUP_COST1" DataField="SUP_COST1" Enabled="true"
                                HeaderText="厂商进货价（包装单位）">
                                <Editor>
                                    <f:NumberBox ID="numSUPCOST1" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderField Width="100px" ColumnID="SUP_COST2" DataField="SUP_COST2" Enabled="true"
                                HeaderText="厂商进货价(外箱单位)">
                                <Editor>
                                    <f:NumberBox ID="numSUPCOST2" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>

                         <f:RenderField Width="100px" ColumnID="SUP_Return" DataField="SUP_Return" Enabled="true"
                                HeaderText="厂商退货价(最小单位)">
                                <Editor>
                                    <f:NumberBox ID="numSUPRETURN" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderField Width="100px" ColumnID="SUP_Return1" DataField="SUP_Return2" Enabled="true"
                                HeaderText="厂商退货价(包装单位)">
                                <Editor>
                                    <f:NumberBox ID="numSUPRETURN1" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderField Width="100px" ColumnID="SUP_Return2" DataField="SUP_Return2" Enabled="true"
                                HeaderText="厂商退货价(外箱单位)">
                                <Editor>
                                    <f:NumberBox ID="numSUPRETURN2" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>

                         <f:RenderField Width="100px" ColumnID="U_COST" DataField="U_COST" Enabled="true"
                                HeaderText="直营店进价(最小单位)">
                                <Editor>
                                    <f:NumberBox ID="numUCOST" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderField Width="100px" ColumnID="U_COST1" DataField="U_COST1" Enabled="true"
                                HeaderText="直营店进价（包装单位）">
                                <Editor>
                                    <f:NumberBox ID="numUCOST1" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderField Width="100px" ColumnID="U_COST2" DataField="U_COST2" Enabled="true"
                                HeaderText="直营店进价(外箱单位)">
                                <Editor>
                                    <f:NumberBox ID="numUCOST2" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>

                         <f:RenderField Width="100px" ColumnID="U_Ret_COST" DataField="U_Ret_COST" Enabled="true"
                                HeaderText="直营店退货价(最小单位)">
                                <Editor>
                                    <f:NumberBox ID="numURETCOST" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderField Width="100px" ColumnID="U_Ret_COST1" DataField="U_Ret_COST1" Enabled="true"
                                HeaderText="直营店退货价(包装单位)">
                                <Editor>
                                    <f:NumberBox ID="numURETCOST1" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderField Width="100px" ColumnID="U_Ret_COST2" DataField="U_Ret_COST2" Enabled="true"
                                HeaderText="直营店退货价(外箱单位)">
                                <Editor>
                                    <f:NumberBox ID="numURETCOST2" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>

                         <f:RenderField Width="100px" ColumnID="T_COST" DataField="T_COST" Enabled="true"
                                HeaderText="加盟店进价(最小单位)">
                                <Editor>
                                    <f:NumberBox ID="numTCOST" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderField Width="100px" ColumnID="T_COST1" DataField="T_COST1" Enabled="true"
                                HeaderText="加盟店进价（包装单位）">
                                <Editor>
                                    <f:NumberBox ID="numTCOST1" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderField Width="100px" ColumnID="T_COST2" DataField="T_COST2" Enabled="true"
                                HeaderText="加盟店进价(外箱单位)">
                                <Editor>
                                    <f:NumberBox ID="numTCOST2" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>

                         <f:RenderField Width="100px" ColumnID="T_Ret_COST" DataField="T_Ret_COST" Enabled="true"
                                HeaderText="加盟店退货价(最小单位)">
                                <Editor>
                                    <f:NumberBox ID="numTRETCOST" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderField Width="100px" ColumnID="T_Ret_COST1" DataField="T_Ret_COST1" Enabled="true"
                                HeaderText="加盟店退货价(包装单位)">
                                <Editor>
                                    <f:NumberBox ID="numTRETCOST1" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderField Width="100px" ColumnID="T_Ret_COST2" DataField="T_Ret_COST2" Enabled="true"
                                HeaderText="加盟店退货价(外箱单位)">
                                <Editor>
                                    <f:NumberBox ID="numTRETCOST2" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>

                         <f:RenderField Width="100px" ColumnID="COST" DataField="COST" Enabled="true"
                                HeaderText="商品成本价(最小单位)">
                                <Editor>
                                    <f:NumberBox ID="COST" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderField Width="100px" ColumnID="COST1" DataField="COST1" Enabled="true"
                                HeaderText="商品成本价（包装单位）">
                                <Editor>
                                    <f:NumberBox ID="COST1" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderField Width="100px" ColumnID="COST2" DataField="COST2" Enabled="true"
                                HeaderText="商品成本价(外箱单位)">
                                <Editor>
                                    <f:NumberBox ID="COST2" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>

                         <f:RenderField Width="100px" ColumnID="ORDER_UNIT" DataField="ORDER_UNIT" FieldType="String"
                              RendererFunction="renderUNIT" HeaderText="订货单位">
                            <Editor>
                                <f:DropDownList ID="ddlOrder_UNIT" Required="true" runat="server" ShowRedStar="true">
                                    <f:ListItem Text="最小单位" Value="1" />
                                    <f:ListItem Text="包装单位" Value="2" />
                                    <f:ListItem Text="外箱单位" Value="3" />
                                </f:DropDownList>
                            </Editor>
                         </f:RenderField>

                         <f:RenderField Width="100px" ColumnID="ORDER_QUAN" DataField="ORDER_QUAN" Enabled="true"
                                HeaderText="最少订购数量">
                                <Editor>
                                    <f:NumberBox ID="nOrder_QUAN" runat="server" NoDecimal="true" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>

                         <f:RenderField Width="100px" ColumnID="Purchase_UNIT" DataField="Purchase_UNIT" FieldType="String"
                              RendererFunction="renderUNIT" HeaderText="采购单位">
                            <Editor>
                                <f:DropDownList ID="ddlPurchase_UNIT" Required="true" runat="server" ShowRedStar="true">
                                    <f:ListItem Text="最小单位" Value="1" />
                                    <f:ListItem Text="包装单位" Value="2" />
                                    <f:ListItem Text="外箱单位" Value="3" />
                                </f:DropDownList>
                            </Editor>
                         </f:RenderField>

                         <f:RenderField Width="100px" ColumnID="Purchase_QUAN" DataField="Purchase_QUAN" Enabled="true"
                                HeaderText="最少采购数量">
                                <Editor>
                                    <f:NumberBox ID="nPurchase_QUAN" runat="server" NoDecimal="true" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>

                        <f:RenderField Width="100px" ColumnID="SAFE_QUAN" DataField="SAFE_QUAN" Enabled="true"
                                HeaderText="库存安全量">
                                <Editor>
                                    <f:NumberBox ID="nSAFE_QUAN" runat="server" NoDecimal="true" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>

                         <f:RenderField Width="100px" ColumnID="PROD_PRICE" DataField="PROD_PRICE" Enabled="true"
                                HeaderText="商品售价">
                                <Editor>
                                    <f:NumberBox ID="nPROD_PRICE" runat="server" NoDecimal="false" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderCheckField ColumnID="ENABLE" DataField="ENABLE" Width="80px" HeaderText="是否有效" />
                         <f:RenderCheckField ColumnID="VISIBLE" DataField="VISIBLE" Width="80px" HeaderText="是否可见" />
                         <f:RenderField Width="130px" ColumnID="BOM_ID" DataField="BOM_ID" FieldType="String"
                               HeaderText="默认配方编码">
                            <Editor>
                                <%--<f:TextBox ID="tBOM_ID" runat="server" EnableBlurEvent="true"></f:TextBox>--%>
                               <f:DropDownList ID="ddlBOM_ID" Required="true" runat="server" ShowRedStar="true">
                                </f:DropDownList>
                            </Editor>
                         </f:RenderField>

                          <%--<f:TemplateField Width="60px" ColumnID="BOM_NAME" HeaderText="配方名称">
                                <ItemTemplate>
                                    <asp:TextBox ID="tBOM_NAME123" runat="server" BorderStyle="None" ></asp:TextBox>
                                </ItemTemplate>
                         </f:TemplateField>--%>
                         <%--<f:RenderField Width="100px"
                               HeaderText="配方名称">
                            <Editor>
                                <f:TextBox ID="tBOM_NAME123" runat="server"></f:TextBox>
                            </Editor>
                         </f:RenderField>--%>
                         <f:BoundField Width="125px" DataField="CRT_USER_ID" HeaderText="建档人员" Enabled="false" />
                         <f:BoundField Width="125px" DataField="CRT_DATETIME" HeaderText="建档日期" Enabled="false" />
                         <f:BoundField Width="125px" DataField="MOD_USER_ID" HeaderText="修改人员" Enabled="false" />
                         <f:BoundField Width="125px" DataField="MOD_DATETIME" HeaderText="修改日期" Enabled="false" />
                         </Columns>
                         <Listeners>
                            <f:Listener Event="edit" Handler="onGridAfterEdit" />
                        </Listeners>
                       </f:Grid>
                       </Items>
                       </f:Panel>
                    </Items>
                </f:Panel>

                <f:Panel runat="server" ID="panelLeftRegion" RegionPosition="Right" RegionSplit="true" EnableCollapse="true" Expanded="false"
                    Width="400px" Title="商品资料" ShowBorder="true" ShowHeader="true" 
                    BodyPadding="5px">
                    <Items>
                         <f:TextBox runat="server" Label="商品编码" ID="cPROD_ID" Width="240px"  ></f:TextBox>
                         <f:TextBox runat="server" Label="商品名称1" ID="cPROD_NAME" Width="240px"></f:TextBox>
                         <f:TextBox runat="server" Label="商品首拼" ID="cPROD_NAME_SPELLING" Width="240px"></f:TextBox>
                         <f:DropDownList Label="商品性质" runat="server" ID="cPROD_KIND" Width="240px"></f:DropDownList>
                         <f:DropDownList Label="商品类别" runat="server" ID="cPROD_DEP" Width="240px" ></f:DropDownList>
                         <f:DropDownList Label="商品小类" runat="server" ID="cPROD_CATE" Width="240px" ></f:DropDownList>
                         <f:DropDownList Label="隶属部门" runat="server" ID="cDIV_ID" Width="240px" ></f:DropDownList>
                         <f:Button ID="ButtonSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="ButtonSearch_Click" ></f:Button>
                    </Items>
                    <Items>
                       <f:Grid ID="Grid1" Title="商品资料" ShowHeader="false" ShowBorder="false" runat="server" DataKeyNames="Id"
                         EnableCheckBoxSelect="true" KeepCurrentSelection="true" EnableMultiSelect="false" PageSize="15" AllowPaging="true"
                         EnableRowClickEvent="true" OnRowClick="Grid1_RowClick">
                         <Columns>
                           <f:RowNumberField />
                           <f:BoundField Width="125px" DataField="PROD_ID" HeaderText="商品编码" />
                           <f:BoundField Width="125px" DataField="PROD_NAME1" HeaderText="商品名称" ExpandUnusedSpace="true"  />
                         </Columns>
                       </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <f:window id="Window1" width="900px" height="700px" icon="TagBlue" title="编辑" Target="Parent"
        enablemaximize="True" closeaction="HidePostBack"  enablecollapse="true" hidden="True" 
        runat="server" enableresize="true" bodypadding="5px" enableframe="True" iframeurl="about:blank"
        enableiframe="true" enableclose="true" ismodal="True">
        </f:window>
<%--        <f:Window ID="Window2" Width="500px" Height="200px" Icon="TagBlue" Hidden="true" BodyPadding="20px"
            EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
            IsModal="false" CloseAction="HidePostBack" OnClose="Window2_Close" Layout="Fit">
            <Content>
                <f:Panel ID="A" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="formitem" 
                    runat="server">
                    <Items>
                         <f:TextBox runat="server" Label="商品编码" ID="cPROD_ID" Width="240px"  ></f:TextBox>
                         <f:TextBox runat="server" Label="商品名称1" ID="cPROD_NAME" Width="240px"></f:TextBox>
                         <f:TextBox runat="server" Label="商品首拼" ID="cPROD_NAME_SPELLING" Width="240px"></f:TextBox>
                         <f:Button ID="ButtonSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="ButtonSearch_Click" ></f:Button>
                     </Items>
                </f:Panel>
                <f:Panel ID="B" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="formitem"
                    runat="server">
                    <Items>
                       <f:Grid ID="Grid3" Title="商品资料" ShowHeader="false" ShowBorder="false" runat="server" DataKeyNames="Id"
                         EnableCheckBoxSelect="true" KeepCurrentSelection="true" EnableMultiSelect="false" PageSize="15" AllowPaging="true"
                         >
                         <Columns>
                           <f:RowNumberField />
                           <f:BoundField Width="125px" DataField="PROD_ID" HeaderText="配方编码" />
                           <f:BoundField Width="125px" DataField="PROD_NAME1" HeaderText="配方名称" ExpandUnusedSpace="true"  />
                         </Columns>
                       </f:Grid>
                    </Items>
               </f:Panel>
             
            </Content>
        </f:Window>--%>
    </form>
    <script>
        function renderUNIT(value) {
            if (value == '1') {
                return '最小单位';
            }
            else if (value == '2') {
                return '包装单位';
            }
            else { 
                return '外箱单位';
            }
        }
        function renderENABLE(value) {
            return value == 1 ? '有效' : '无效';
        }

        function renderVISIBLE(value) {
            return value == 1 ? '可见' : '不可见';
        }

        function renderSENDTYPE(value) {
            return value == 1 ? '直送总部' : '直送门市';
        }

        function renderTAXTYPE(value) {
            var typevalue = "";
            if (value == 0) {
                typevalue = "不含税";
            }
            else if (value == 1) {
                typevalue = "内含税";
            } else if (value == 2) {
                typevalue = "外加税";
            }
            return typevalue;
        }
        function renderPRCAREANAME(vales) {
            //Cache_SUPPLIERS

//            var xmlhttp;
//            if (window.XMLHttpRequest) {
//                //  IE7+, Firefox, Chrome, Opera, Safari 浏览器执行代码
//                xmlhttp = new XMLHttpRequest();
//            }
//            else {
//                // IE6, IE5 浏览器执行代码
//                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
//            }
//            xmlhttp.onreadystatechange = function () {
//                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
//                    return xmlhttp.responseText;
//                }
//            }
//            xmlhttp.open("GET", "SUPPLIERSHander.ashx?opt=1&columnName=SUP_NAME&SUP_ID=" + vales, true);
//            xmlhttp.send();
        }

        function onGridAfterEdit(editor, params) {
            var me = this, columnId = params.column.id, rowId = params.record.getId();
            var strPRCAREA_ID = me.f_getCellValue(rowId, 'PRCAREA_ID');
            var strPROD_ID = me.f_getCellValue(rowId, 'PROD_ID');
            me.f_updateCellValue(rowId, 'rPRCAREA_ID', strPRCAREA_ID);
            var p_price;
            var p_unit;
            var p_column;
            var p_cotype;
            switch (columnId) {
                case "SUP_COST": p_cotype = 1; p_column = 'SUP'; p_price = me.f_getCellValue(rowId, 'SUP_COST'); p_unit = 1; break;
                case "SUP_COST1": p_cotype = 1; p_column = 'SUP'; p_price = me.f_getCellValue(rowId, 'SUP_COST1'); p_unit = 2; break;
                case "SUP_COST2": p_cotype = 1; p_column = 'SUP'; p_price = me.f_getCellValue(rowId, 'SUP_COST2'); p_unit = 3; break;
                case "SUP_Return": p_cotype = 1; p_column = 'SUP'; p_price = me.f_getCellValue(rowId, 'SUP_Return'); p_unit = 1; break;
                case "SUP_Return1": p_cotype = 1; p_column = 'SUP'; p_price = me.f_getCellValue(rowId, 'SUP_Return1'); p_unit = 2; break;
                case "SUP_Return2": p_cotype = 1; p_column = 'SUP'; p_price = me.f_getCellValue(rowId, 'SUP_Return2'); p_unit = 3; break;
                case "U_COST": p_cotype = 1; p_column = 'U'; p_price = me.f_getCellValue(rowId, 'U_COST'); p_unit = 1; break;
                case "U_COST1": p_cotype = 1; p_column = 'U'; p_price = me.f_getCellValue(rowId, 'U_COST1'); p_unit = 2; break;
                case "U_COST2": p_cotype = 1; p_column = 'U'; p_price = me.f_getCellValue(rowId, 'U_COST2'); p_unit = 3; break;
                case "U_Ret_COST": p_cotype = 1; p_column = 'U'; p_price = me.f_getCellValue(rowId, 'U_Ret_COST'); p_unit = 1; break;
                case "U_Ret_COST1": p_cotype = 1; p_column = 'U'; p_price = me.f_getCellValue(rowId, 'U_Ret_COST1'); p_unit = 2; break;
                case "U_Ret_COST2": p_cotype = 1; p_column = 'U'; p_price = me.f_getCellValue(rowId, 'U_Ret_COST2'); p_unit = 3; break;
                case "T_COST": p_cotype = 1; p_column = 'T'; p_price = me.f_getCellValue(rowId, 'T_COST'); p_unit = 1; break;
                case "T_COST1": p_cotype = 1; p_column = 'T'; p_price = me.f_getCellValue(rowId, 'T_COST1'); p_unit = 2; break;
                case "T_COST2": p_cotype = 1; p_column = 'T'; p_price = me.f_getCellValue(rowId, 'T_COST2'); p_unit = 3; break;
                case "T_Ret_COST": p_cotype = 1; p_column = 'T'; p_price = me.f_getCellValue(rowId, 'T_Ret_COST'); p_unit = 1; break;
                case "T_Ret_COST1": p_cotype = 1; p_column = 'T'; p_price = me.f_getCellValue(rowId, 'T_Ret_COST1'); p_unit = 2; break;
                case "T_Ret_COST2": p_cotype = 1; p_column = 'T'; p_price = me.f_getCellValue(rowId, 'T_Ret_COST2'); p_unit = 3; break;
                case "COST": p_cotype = 1; p_column = 'C'; p_price = me.f_getCellValue(rowId, 'COST'); p_unit = 1; break;
                case "COST1": p_cotype = 1; p_column = 'C'; p_price = me.f_getCellValue(rowId, 'COST1'); p_unit = 2; break;
                case "COST2": p_cotype = 1; p_column = 'C'; p_price = me.f_getCellValue(rowId, 'COST2'); p_unit = 3; break;
                case "BOM_ID": p_cotype = 2; break;
                default: p_price = ''; p_unit = ''; p_cotype = 0; break;
            }
            //配置配方编码
            if (p_cotype == 2) {
                
            }
            //设置价格
            else if ((p_price != '' && p_unit != '' && strPROD_ID != '') && p_cotype == 1) {
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
                        var jsonValue = xmlhttp.responseText;
                        var obj = JSON.parse(jsonValue);
                        var cost = obj[0].COST.toFixed(6);
                        var cost1 = obj[0].COST1.toFixed(6);
                        var cost2 = obj[0].COST2.toFixed(6);
                        switch (p_column) {
                            case 'SUP': me.f_updateCellValue(rowId, 'SUP_COST', cost);
                                me.f_updateCellValue(rowId, 'SUP_COST1', cost1);
                                me.f_updateCellValue(rowId, 'SUP_COST2', cost2);
                                me.f_updateCellValue(rowId, 'SUP_Return', cost);
                                me.f_updateCellValue(rowId, 'SUP_Return1', cost1);
                                me.f_updateCellValue(rowId, 'SUP_Return2', cost2);
                                break;
                            case 'U': me.f_updateCellValue(rowId, 'U_COST', obj[0].COST);
                                me.f_updateCellValue(rowId, 'U_COST1', obj[0].COST1);
                                me.f_updateCellValue(rowId, 'U_COST2', obj[0].COST2);
                                me.f_updateCellValue(rowId, 'U_Ret_COST', obj[0].COST);
                                me.f_updateCellValue(rowId, 'U_Ret_COST1', obj[0].COST1);
                                me.f_updateCellValue(rowId, 'U_Ret_COST2', obj[0].COST2); break;
                            case 'T': me.f_updateCellValue(rowId, 'T_COST', obj[0].COST);
                                me.f_updateCellValue(rowId, 'T_COST1', obj[0].COST1);
                                me.f_updateCellValue(rowId, 'T_COST2', obj[0].COST2);
                                me.f_updateCellValue(rowId, 'T_Ret_COST', obj[0].COST);
                                me.f_updateCellValue(rowId, 'T_Ret_COST1', obj[0].COST1);
                                me.f_updateCellValue(rowId, 'T_Ret_COST2', obj[0].COST2); break;
                            case 'C': me.f_updateCellValue(rowId, 'COST', obj[0].COST);
                                me.f_updateCellValue(rowId, 'COST1', obj[0].COST1);
                                me.f_updateCellValue(rowId, 'COST2', obj[0].COST2); break;
                            default: break;
                        }
                        //return xmlhttp.responseText;
                    }
                }
                xmlhttp.open("GET", "Prodcut00Handler.ashx?opt=2&PROD_ID=" + strPROD_ID + "&P_PRICE=" + p_price + "&UNIT_TYPE=" + p_unit, true);
                xmlhttp.send();
            }
        }

    </script>
</body>
</html>
