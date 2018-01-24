<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Component00List.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.DataCenter.Component00List" %>

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
                    Title="配方资料" ShowBorder="true" ShowHeader="true" BodyPadding="5px">
                    <Toolbars>
                    <f:Toolbar ID="Toolbar1" runat="server">
                      <Items>
                      <f:Button ID="ButtonAdd" runat="server" Text="保存" Icon="Disk" OnClick="ButtonSave_Click"></f:Button>
                      <f:Button ID="ButtonNewRow" runat="server" Text="新增" Icon="Disk" onClick="ButtonNewRow_Clikc"></f:Button>
                      <f:Button ID="Button4" runat="server" Text="删除" OnClick="Grid1Delete_Click" ConfirmText="确认删除？"></f:Button>
                      </Items>
                      </f:Toolbar>
                    </Toolbars>
                    <Items>
                         <f:Grid ID="Grid1" Title="配方设定主表" EnableFrame="false" EnableCollapse="true"
                               PageSize="15" ShowBorder="true" ShowHeader="true" AllowPaging="true" runat="server"  DataKeyNames="Id" EnableColumnLines="true"
                               AllowCellEditing="true" ClicksToEdit="1" EnableRowClickEvent="true" OnRowClick="Grid1_RowClick" > <%-- EnableCheckBoxSelect="True" EnableRowClickEvent="true" OnRowClick="Grid1_RowClick"  AllowCellEditing="true" ClicksToEdit="1" --%>
                           <Columns>
                           <f:RowNumberField />
                           <f:BoundField Width="180px" DataField="COM00_ID" Hidden="true" />
                           <f:TemplateField ColumnID="rCOM00_ID" Width="60px" HeaderText="序号" Hidden="true">
                                <ItemTemplate>
                                    <asp:Label ID="aspCOM_ID" runat="server" Text='<%# Eval("COM00_ID") %>'></asp:Label>
                                </ItemTemplate>
                           </f:TemplateField>
                           <f:RenderField Width="150px" ColumnID="COM00_ID" DataField="COM00_ID" FieldType="String" Enabled="false"
                                HeaderText="配方编码">
                                <Editor>
                                    <f:TextBox ID="tCOM00_ID" runat="server" Enabled="false" Required="true" ShowRedStar="true">
                                    </f:TextBox>
                                </Editor>
                           </f:RenderField>
                           <f:RenderField Width="100px" ColumnID="COM00_PROD_ID" DataField="COM00_PROD_ID" FieldType="String" Enabled="false"
                                HeaderText="商品编码" >
                                <Editor>
                                    <f:TextBox ID="tCOM00_PROD_ID" runat="server" Required="true" ShowRedStar="true"></f:TextBox>
                                </Editor>
                           </f:RenderField>

                           <f:RenderField Width="100px" ColumnID="COM00_NAME1" DataField="COM00_NAME1" FieldType="String" Enabled="false"
                                HeaderText="商品名称" >
                                <Editor>
                                    <f:TextBox ID="tCOM00_PROD_NAME1" runat="server" Required="true" ShowRedStar="true" Enabled="false"></f:TextBox>
                                </Editor>
                           </f:RenderField>

                          <f:RenderField Width="100px" ColumnID="COM00_Num" DataField="COM00_Num" Enabled="true"
                                HeaderText="配方商品数量">
                                <Editor>
                                    <f:NumberBox ID="fCOM00_Num" runat="server" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderField Width="100px" ColumnID="COM00_WEIGHT" DataField="COM00_WEIGHT" Enabled="false"
                                HeaderText="总重量">
                                <Editor>
                                    <f:TextBox ID="nCOM00_WEIGHT" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                    </f:TextBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderCheckField ColumnID="COM00_DefaultCOM" DataField="COM00_DefaultCOM" Width="80px" HeaderText="默认配方" />

                           <f:RenderField Width="100px" ColumnID="COM00_QUAN1" DataField="COM00_QUAN1" FieldType="Int"
                                HeaderText="小缸标准数量">
                                <Editor>
                                    <f:NumberBox ID="nCOM00_QUAN1" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                           </f:RenderField>

                           <f:RenderField Width="100px" ColumnID="COM00_QUAN2" DataField="COM00_QUAN2" FieldType="Int"
                                HeaderText="大缸标准数量">
                                <Editor>
                                     <f:NumberBox ID="nCOM00_QUAN2" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                           </f:RenderField>

                           <f:RenderField Width="100px" ColumnID="COM00_DefQuan" DataField="COM00_DefQuan" FieldType="String" Enabled="false"
                                HeaderText="生产缸型" RendererFunction="renderCOM00_DefQuan">
                                <Editor>
                                    <f:DropDownList ID="ddlCOM00_DefQuan" runat="server" Required="true" ShowRedStar="true">
                                       <f:ListItem Value="0" Text="小缸" />
                                       <f:ListItem Value="1" Text="大缸" Selected="true" />
                                    </f:DropDownList>
                                </Editor>
                          </f:RenderField>
                          <f:RenderField Width="100px" ColumnID="COM00_BOM_Cost" DataField="COM00_BOM_Cost" FieldType="String" Enabled="false"
                                HeaderText="配方成本">
                                <Editor>
                                     <f:TextBox ID="nCOM00_BOM_Cost" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                    </f:TextBox>
                                </Editor>
                           </f:RenderField>

                           <f:RenderField Width="150px" ColumnID="COM00_ExpDateTime" DataField="COM00_ExpDateTime" FieldType="Date"
                               Renderer="Date" RendererArgument="yyyy-MM-dd" HeaderText="有效日期">
                                <Editor>
                                     <f:DatePicker runat="server" Required="true"
                                        ID="dpCOM00_ExpDateTim" ShowRedStar="True">
                                    </f:DatePicker>
                                </Editor>
                           </f:RenderField>

                         </Columns>
                         <Listeners>
                            <f:Listener Event="edit" Handler="onGridAfterEdit2" />
                        </Listeners>
                       </f:Grid>
                       <f:HiddenField runat="server" ID="hidCOM_ID" Text=""></f:HiddenField>
                    </Items>

                    <Items>
                       <f:Panel ID="Panel12" runat="server" Title="配方资料设定">
                        <Toolbars>
                            <f:Toolbar ID="Toolbar2" runat="server">
                                <Items>
                                    <f:Button ID="btnNew" runat="server" Text="添加" Icon="Add" OnClick="btnNewRow" ></f:Button>
                                    <f:Button ID="Button1" runat="server" Text="删除" OnClick="Grid2Delete_Click" ConfirmText="确认删除？"></f:Button>
                                </Items>
                            </f:Toolbar>
                        </Toolbars>
                        <Items>
                        <f:Grid ID="Grid2" Title="配方设定" EnableFrame="false" EnableCollapse="true"
                               PageSize="15" ShowBorder="true" ShowHeader="true" AllowPaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id" EnableColumnLines="true"
                               AllowCellEditing="true" ClicksToEdit="1"  EnableRowDoubleClickEvent="true" OnRowDoubleClick="Grid2_RowDoubleClick"> 
                            <%-- --%>
                           <Columns>
                           <f:RowNumberField />
                           <f:RenderField Width="100px" ColumnID="Id00" DataField="Id" FieldType="String" Enabled="false" Hidden="true"
                                HeaderText="编码">
                                <Editor>
                                    <f:TextBox ID="tbxId" runat="server" Enabled="false" Required="true" ShowRedStar="true">
                                    </f:TextBox>
                                </Editor>
                           </f:RenderField>
                           <f:RenderField Width="100px" ColumnID="COM_ID" DataField="COM_ID" FieldType="String" Enabled="false"
                                HeaderText="配方编码">
                                <Editor>
                                    <f:TextBox ID="tbxCOM_ID" runat="server" Enabled="false" Required="true" ShowRedStar="true">
                                    </f:TextBox>
                                </Editor>
                           </f:RenderField>
                           <f:RenderField Width="100px" ColumnID="DETAIL_ID" DataField="DETAIL_ID" FieldType="String" Enabled="false"
                                HeaderText="配方序号">
                                <Editor>
                                    <f:TextBox ID="tDETAIL_ID" runat="server" Enabled="false" Required="true" ShowRedStar="true">
                                    </f:TextBox>
                                </Editor>
                           </f:RenderField>
                           <f:RenderField Width="100px" ColumnID="PROD_ID" DataField="PROD_ID" FieldType="String"
                                HeaderText="商品编码" >
                                <Editor>
                                    <f:TextBox ID="ftPROD_ID" runat="server" Required="true" ShowRedStar="true"></f:TextBox>
                                </Editor>
                           </f:RenderField>

                           <f:RenderField Width="100px" ColumnID="PROD_NAME1" DataField="PROD_NAME1" FieldType="String" Enabled="false"
                                HeaderText="商品名称" >
                                <Editor>
                                    <f:TextBox ID="tPROD_NAME" runat="server" Required="true" ShowRedStar="true"></f:TextBox>
                                </Editor>
                           </f:RenderField>

                          <f:RenderField Width="100px" ColumnID="QUANTITY" DataField="QUANTITY" Enabled="false"
                                HeaderText="单个成品，半成品数量">
                                <Editor>
                                    <f:NumberBox ID="nQUANTITY" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true" Enabled="false">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>
                         <f:RenderField Width="100px" ColumnID="LQUANTITY" DataField="LQUANTITY" Enabled="true"
                                HeaderText="商品配方数量">
                                <Editor>
                                    <f:NumberBox ID="nLQUANTITY" runat="server" DecimalPrecision="6" Required="true" ShowRedStar="true">
                                    </f:NumberBox>
                                </Editor>
                         </f:RenderField>

                         <f:RenderField Width="100px" ColumnID="New_PROD_ID" DataField="New_PROD_ID" FieldType="String"
                                HeaderText="替代品编码">
                                <Editor>
                                    <f:TextBox ID="tNew_PROD_ID" runat="server">
                                    </f:TextBox>
                                </Editor>
                         </f:RenderField>

                         <f:RenderField Width="100px" ColumnID="New_PROD_NAME1" DataField="New_PROD_NAME1" FieldType="String" Enabled="false"
                                HeaderText="替代品名称">
                                <Editor>
                                    <f:TextBox ID="tNew_New_PROD_NAME" runat="server" Enabled="false">
                                    </f:TextBox>
                                </Editor>
                         </f:RenderField>
                         
                               
                        <f:RenderCheckField ColumnID="IsScales" DataField="IsScales" Width="80px" HeaderText="过称" />
                        <f:RenderCheckField ColumnID="PrtTag" DataField="PrtTag" Width="80px" HeaderText="打印标签" />
                        <f:RenderCheckField ColumnID="IsFlag" DataField="IsFlag" Width="80px" HeaderText="种面" />

                           <f:RenderField Width="100px" ColumnID="Memo" DataField="Memo" FieldType="String" Enabled="false"
                                HeaderText="备注">
                                <Editor>
                                    <f:TextBox ID="tMemo" runat="server" Enabled="false">
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
                       <f:TextBox runat="server" ID="Grid3Rowindex" Text="" Hidden="true" ></f:TextBox>
                    </Items>
                </f:Panel>

                <f:Panel runat="server" ID="panelLeftRegion" RegionPosition="Right" RegionSplit="true" EnableCollapse="true" Expanded="false"
                    Width="400px" Title="" ShowBorder="true" ShowHeader="true"  
                    BodyPadding="5px">
                    <Items>
                       <f:Tree ID="Tree1" ShowHeader="true" Title="配方列表" EnableCollapse="true" runat="server" OnNodeCommand="Tree1_NodeCommand"
                       AutoLeafIdentification="false"><%-- OnNodeCommand="Tree1_NodeCommand" OnNodeLazyLoad="Tree1_NodeLazyLoad"  --%>
                       </f:Tree>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <f:Window ID="Window2" Width="430px" Height="800px" Icon="TagBlue" Hidden="true" BodyPadding="10px"
            EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
            IsModal="false" CloseAction="HidePostBack" OnClose="Window2_Close" Layout="Fit">
            <Content>
                <f:Panel runat="server" ID="PanelA" RegionPosition="Right" RegionSplit="true" EnableCollapse="true" Expanded="true"
                    Width="400px" Title="商品资料" ShowBorder="true" ShowHeader="true"
                    BodyPadding="5px">
                    <Items>
                        <f:Button ID="ButtonSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="ButtonPRODSearch_Click" ></f:Button>
                        <f:TextBox runat="server" Label="商品编码" ID="cPROD_ID" Width="240px"  ></f:TextBox>
                        <f:TextBox runat="server" Label="商品名称1" ID="cPROD_NAME" Width="240px"></f:TextBox>
                        <f:TextBox runat="server" Label="商品首拼" ID="cPROD_NAME_SPELLING" Width="240px"></f:TextBox>
                        <f:DropDownList Label="商品性质" runat="server" ID="cPROD_KIND" Width="240px"></f:DropDownList>
                        <f:DropDownList Label="商品类别" runat="server" ID="cPROD_DEP" Width="240px" ></f:DropDownList>
                        <f:DropDownList Label="商品小类" runat="server" ID="cPROD_CATE" Width="240px" ></f:DropDownList>
                        <f:Button ID="BtnAddGrid2" runat="server" Text="添加" Icon="Magnifier" OnClick="btnNewRow2"  ></f:Button>
                    </Items>
                    <Items>
                       <f:Grid ID="Grid3" Title="商品资料" ShowHeader="false" ShowBorder="false" runat="server" DataKeyNames="Id"
                         EnableCheckBoxSelect="true" KeepCurrentSelection="true" PageSize="1000" AllowPaging="false"
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

        <f:Window ID="Window3" Width="430px" Height="800px" Icon="TagBlue" Hidden="true" BodyPadding="10px"
            EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
            IsModal="false" CloseAction="HidePostBack" OnClose="Window3_Close" Layout="Fit">
            <Toolbars>
                <f:Toolbar ID="tools" runat="server">
                    <Items>
                        <f:Button ID="ButtonSearchPROD1" runat="server" Text="查询" Icon="Magnifier" OnClick="ButtonPRODSearch2_Click" ></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Content>
                <f:Panel runat="server" ID="PanelGrid4" RegionPosition="Right" RegionSplit="true" EnableCollapse="true" Expanded="true"
                    Width="400px" Title="商品资料" ShowBorder="true" ShowHeader="true"
                    BodyPadding="5px">
                    <Items>
                        
                        <f:TextBox runat="server" Label="商品编码" ID="ccPROD_ID" Width="240px"  ></f:TextBox>
                        <f:TextBox runat="server" Label="商品名称1" ID="ccPROD_NAME" Width="240px"></f:TextBox>
                        <f:TextBox runat="server" Label="商品首拼" ID="ccPROD_NAME_SPELLING" Width="240px"></f:TextBox>
                        <f:DropDownList Label="商品性质" runat="server" ID="ccPROD_KIND" Width="240px"></f:DropDownList>
                        <f:DropDownList Label="商品类别" runat="server" ID="ccPROD_DEP" Width="240px" ></f:DropDownList>
                        <f:DropDownList Label="商品小类" runat="server" ID="ccPROD_CATE" Width="240px" ></f:DropDownList>
                        <f:Button ID="BtnEditBOM" runat="server" Text="确定" Icon="Magnifier" OnClick="btnEditBom"  ></f:Button>
                    </Items>
                    <Items>
                       <f:Grid ID="Grid4" Title="商品资料" ShowHeader="false" ShowBorder="false" runat="server" DataKeyNames="Id"
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
    <script>
        function renderCOM00_DefaultCOM(value) {
            return value == 1 ? '是' : '否';
        }
        function renderCOM00_DefQuan(value) {
            return value == 1 ? '大缸' : '小缸';
        }
        function renderIsScales(value) {
            return value == 1 ? '过称' : '不过称';
        }

        function renderPrtTag(value) {
            return value == 1 ? '打印' : '不打印';
        }

        function renderIsFlag(value) {
            return value == 1 ? '种面' : '不种面';
        }
        function onGridAfterEdit(editor, params) {
            var me = this, columnId = params.column.id, rowId = params.record.getId();
            var strCOM_ID = me.f_getCellValue(rowId, 'COM_ID');
            if(columnId === "PROD_ID")
            {
                var strPROD_ID = me.f_getCellValue(rowId, 'PROD_ID');
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
                        me.f_updateCellValue(rowId, 'PROD_NAME1', xmlhttp.responseText);
                    }
                }
                xmlhttp.open("GET", "Prodcut00Handler.ashx?opt=1&columnName=PROD_NAME1&PROD_ID=" + strPROD_ID, true);
                xmlhttp.send();
            }
            //me.f_updateCellValue(rowId, 'rCOM_ID', strCOM_ID);
        }

        function onGridAfterEdit2(editor, params) {
            var me = this, columnId = params.column.id, rowId = params.record.getId();
            var strCOM_ID = me.f_getCellValue(rowId, 'COM00_ID');
            me.f_updateCellValue(rowId, 'rCOM00_ID', strCOM_ID);
            //document.getElementById("btnGridClikc").value = strCOM_ID;
            //alert(document.getElementById("btnGridClick").value);
            //document.getElementById("btnGridClick").onclick();
        }
    </script>
</body>
</html>
