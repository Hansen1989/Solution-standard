<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContracT00List.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.DataCenter.ContracT00List" %>

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
                    Title="合同详细资料" ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" runat="server">
                           <Items>
                              <f:Button ID="Button1" runat="server" Text="清空" Icon="ArrowRefresh"  CssClass="inline"></f:Button>
                              <f:Button ID="ButtonAdd" runat="server" Text="新增" Icon="Disk" OnClick="btnSave_CONTRACTP00" ></f:Button>
                              <f:Button ID="ButtonUpdate" runat="server" Text="修改" Icon="Disk" OnClick="btnUpdate_CONTRACTP00" ></f:Button>
                           </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Items>
                        <f:Form ID="Form5" LabelAlign="Left"  BodyPadding="5px" LabelWidth="90px" EnableCollapse="true"
                            runat="server" Title="表单" ShowBorder="true" ShowHeader="false">
                                <Rows>
                                    <f:FormRow ColumnWidths="300px">
                                    <Items>
                                        <f:HiddenField runat="server" ID="hidId"></f:HiddenField>
                                        <f:TextBox runat="server" Label="合同编码"  ID="tbxCONTRACT_ID" Required="true" ShowRedStar="true" Width="250px" EmptyText="合同编码" ></f:TextBox>
                                        <f:TextBox runat="server" Label="合同名称" ID="tbxCONTRACT_TITLE" Required="true" ShowRedStar="true" Width="250px" EmptyText="合同名称" ></f:TextBox>
                                        <f:CheckBox runat="server" Label="有效" ID="cbxUSABLE" Width="100px"></f:CheckBox>
                                        <f:CheckBox runat="server" Label="锁定" ID="cbxLOCK" Width="100px"></f:CheckBox>
                                    </Items>
                                    </f:FormRow>
                                    <f:FormRow ColumnWidths="300px">
                                    <Items>
                                        <f:DatePicker runat="server" ID="dpkCONTRACTP_SIGN" EnableEdit="false" Label="签订时间" DateFormatString="yyyy-MM-dd"></f:DatePicker>
                                        <f:DatePicker runat="server" ID="dpkCONTRACTP_STARTTIME" EnableEdit="false" Label="合同开始时间" DateFormatString="yyyy-MM-dd"></f:DatePicker>
                                        <f:DatePicker runat="server" ID="dpkCONTRACTP_ENDTIME" EnableEdit="false" Label="合同结束时间" CompareOperator="GreaterThan" DateFormatString="yyyy-MM-dd" CompareControl="dpkCONTRACTP_STARTTIME" CompareMessage="结束日期应该大于开始日期"></f:DatePicker>
                                    </Items>
                                    </f:FormRow>
                                    <f:FormRow ColumnWidths="300px">
                                    <Items>
                                        <f:TextBox runat="server" Label="甲方" ID="tbxFIRST_PARTY" Required="true" ShowRedStar="true" Width="250px"></f:TextBox>
                                        <f:DropDownList runat="server" Label="乙方" ID="tbxSECEND_PARTY" Required="true" ShowRedStar="true" Width="250px"></f:DropDownList>
                                        <f:TextBox runat="server" Label="备注" ID="tbxMeno" Width="250px"></f:TextBox>
                                    </Items>
                                    </f:FormRow>
                                    <f:FormRow>
                                    <Items>
                                         <f:TextBox runat="server" Label="创建者" ID="tbxCRT_USER_ID" Width="500px" EmptyText="创建者" Enabled="false"  ></f:TextBox>
                                         <f:TextBox runat="server" Label="创建日期" ID="tbxCRT_DATETIME" Width="500px" EmptyText="创建日期" Enabled="false" ></f:TextBox>
                                         <f:TextBox runat="server" Label="修改人" ID="tbxMOD_USER_ID" Width="500px" EmptyText="修改人" Enabled="false" ></f:TextBox>
                                         <f:TextBox runat="server" Label="修改日期" ID="tbxMOD_USER_DATE" Width="500px" EmptyText="修改日期" Enabled="false" ></f:TextBox>
                                    </Items>
                                    </f:FormRow>
                               </Rows>
                     </f:Form>
                    </Items>

                    <Items>
                       <f:Panel ID="Panel12" runat="server" Title="合同明细">
                            <Toolbars>
                                <f:Toolbar ID="Toolbar21111" runat="server">
                                  <Items>
                                       <f:Button ID="ButtonAddCon01" runat="server" Text="添加" Icon="Add" OnClick="btnAdd_CONTRACT01" ></f:Button>
                                  </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Items>
                                <f:Grid ID="Grid2" Title="合同明细" EnableFrame="false" EnableCollapse="true"
                                  ShowBorder="true" ShowHeader="true"  runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id" EnableColumnLines="true"
                                   AllowCellEditing="true" ClicksToEdit="1"> 
                                    <Columns>
                                        <f:RowNumberField />
                                        <f:RenderField Width="100px" ColumnID="Id01" DataField="Id" Enabled="true" Hidden="true"
                                            HeaderText="编码">
                                            <Editor>
                                                <f:TextBox runat="server" ID="tbxId01"></f:TextBox>
                                            </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="100px" ColumnID="CONTRACT_ID01" DataField="CONTRACT_ID" Enabled="true"
                                            HeaderText="合同编码">
                                            <Editor>
                                                <f:TextBox runat="server" ID="tbxCONTRACT_ID01"></f:TextBox>
                                            </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="100px" ColumnID="PROD_ID01" DataField="PROD_ID" Enabled="true"
                                            HeaderText="商品编码">
                                            <Editor>
                                                <f:TextBox runat="server" ID="tbxPROD_ID01"></f:TextBox>
                                            </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="100px" ColumnID="PROD_NAME01" DataField="PROD_NAME" Enabled="false"
                                            HeaderText="商品名称">
                                            <Editor>
                                                <f:TextBox runat="server" ID="tbxPROD_NAME01" Enabled="true"></f:TextBox>
                                            </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="100px" ColumnID="CONTRACT_PRICE01" DataField="CONTRACT_PRICE" Enabled="true"
                                            HeaderText="最小单位价格">
                                            <Editor>
                                                <f:NumberBox runat="server" ID="numCONTRACT_PRICE01" DecimalPrecision="6" ></f:NumberBox>
                                            </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="100px" ColumnID="CONTRACT_PRICE101" DataField="CONTRACT_PRICE1" Enabled="true"
                                            HeaderText="包装单位价格">
                                            <Editor>
                                                <f:NumberBox runat="server" ID="numCONTRACT_PRICE101" DecimalPrecision="6" ></f:NumberBox>
                                            </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="100px" ColumnID="CONTRACT_PRICE201" DataField="CONTRACT_PRICE2" Enabled="true"
                                            HeaderText="外箱单位价格">
                                            <Editor>
                                                <f:NumberBox runat="server" ID="numCONTRACT_PRICE201" DecimalPrecision="6" ></f:NumberBox>
                                            </Editor>
                                        </f:RenderField>
                                        <f:RenderCheckField ColumnID="USABLE01" DataField="USABLE" Width="80px" HeaderText="有效">
                                        </f:RenderCheckField>
                                         <f:RenderField Width="100px" ColumnID="Meno01" DataField="Meno" Enabled="true"
                                            HeaderText="备注">
                                            <Editor>
                                                <f:Textbox runat="server" ID="tbxMeno01" ></f:Textbox>
                                            </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="130px" ColumnID="CRT_USER_ID01" DataField="CRT_USER_ID" FieldType="String" Enabled="false"
                                                HeaderText="建档人员">
                                                <Editor>
                                                    <f:TextBox ID="tbxCRT_USER_ID01" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="130px" ColumnID="CRT_DATETIME01" DataField="CRT_DATETIME" FieldType="String" Enabled="false"
                                                HeaderText="建档日期">
                                                <Editor>
                                                    <f:TextBox ID="tbxCRT_DATETIME01" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="130px" ColumnID="MOD_USER_ID01" DataField="MOD_USER_ID" FieldType="String" Enabled="false"
                                                HeaderText="修改人员">
                                                <Editor>
                                                    <f:TextBox ID="tbxMOD_USER_ID01" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                        </f:RenderField>
                                        <f:RenderField Width="130px" ColumnID="MOD_DATETIME01" DataField="MOD_DATETIME" FieldType="String" Enabled="false"
                                                HeaderText="修改日期">
                                                <Editor>
                                                    <f:TextBox ID="tbxMOD_DATETIME01" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                        </f:RenderField>
                                    </Columns>
                                </f:Grid>
                            </Items>
                       </f:Panel>
                    </Items>
                </f:Panel>

                <f:Panel runat="server" ID="panelLeftRegion" RegionPosition="Right" RegionSplit="true" EnableCollapse="true" Expanded="false"
                    Width="400px" Title="合同列表" ShowBorder="true" ShowHeader="true" 
                    BodyPadding="5px">
                    <Items>
                       <f:Grid ID="Grid1" Title="商品资料" ShowHeader="false" ShowBorder="false" runat="server" DataKeyNames="Id"
                         EnableCheckBoxSelect="true" KeepCurrentSelection="true" EnableMultiSelect="false" PageSize="15" AllowPaging="true"
                         EnableRowClickEvent="true" OnRowClick="Grid1_RowClick">
                         <Columns>
                           <f:RowNumberField />
                           <f:BoundField Width="125px" DataField="CONTRACT_ID" HeaderText="合同编码" />
                           <f:BoundField Width="125px" DataField="CONTRACT_TITLE" HeaderText="合同名称" ExpandUnusedSpace="true"  />
                           <f:BoundField Width="125px" DataField="CONTRACTP_SIGN" HeaderText="签订时间" ExpandUnusedSpace="true"  />
                         </Columns>
                       </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <f:Window ID="Window3" Width="430px" Height="800px" Icon="TagBlue" Hidden="true" BodyPadding="10px"
            EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
            IsModal="false" CloseAction="HidePostBack" OnClose="Window3_Close" Layout="Fit">
            <Content>
                <f:Panel runat="server" ID="PanelGrid4" RegionPosition="Right" RegionSplit="true" EnableCollapse="true" Expanded="true"
                    Width="400px" Title="其他厂商" ShowBorder="true" ShowHeader="true"
                    BodyPadding="5px">
                    <Toolbars>
                        <f:Toolbar ID="tools" runat="server">
                           <Items>
                              <f:Button ID="ButtonSearchPROD1" runat="server" Text="查询" Icon="Magnifier" OnClick="ButtonPRODSearch2_Click" ></f:Button>
                           </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Items>
                        <f:TextBox runat="server" Label="商品编码" ID="cPROD_ID" Width="240px"  ></f:TextBox>
                        <f:TextBox runat="server" Label="商品名称1" ID="cPROD_NAME" Width="240px"></f:TextBox>
                        <f:TextBox runat="server" Label="商品首拼" ID="cPROD_NAME_SPELLING" Width="240px"></f:TextBox>
                        <f:DropDownList Label="商品性质" runat="server" ID="cPROD_KIND" Width="240px"></f:DropDownList>
                        <f:DropDownList Label="商品类别" runat="server" ID="cPROD_DEP" Width="240px" ></f:DropDownList>
                        <f:DropDownList Label="商品小类" runat="server" ID="cPROD_CATE" Width="240px" ></f:DropDownList>
                        <f:Button ID="BtnEditBOM" runat="server" Text="确定" Icon="Magnifier" OnClick="btnEditCon_Click"  ></f:Button>
                    </Items>
                    <Items>
                       <f:Grid ID="Grid4" Title="其他厂商" ShowHeader="false" ShowBorder="false" runat="server" DataKeyNames="Id"
                         EnableCheckBoxSelect="true" KeepCurrentSelection="false" PageSize="1000" AllowPaging="false"
                         ><%--EnableRowClickEvent="true" OnRowClick="Grid1_RowClick" --%>
                         <Columns>
                           <f:RowNumberField />
                           <f:BoundField Width="125px" DataField="PROD_ID" HeaderText="商品编号" ExpandUnusedSpace="true"  />
                           <f:BoundField Width="125px" DataField="PROD_NAME1" HeaderText="商品名称" ExpandUnusedSpace="true"  />
                         </Columns>
                       </f:Grid>
                    </Items>
                 </f:Panel>
            </Content>
        </f:Window>
    </form>
</body>
</html>
