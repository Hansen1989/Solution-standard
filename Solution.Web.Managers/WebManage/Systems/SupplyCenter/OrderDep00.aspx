<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDep00.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SupplyCenter.OrderDep00" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Panel ID="Panel3" Title="订货部门设定" runat="server" Width="900px" Height="900px" EnableCollapse="true" 
            BodyPadding="5px" ShowBorder="True" ShowHeader="True">
            <Items>
                <f:Toolbar ID="toolGrid1" runat="server">
                    <Items>
                       <f:Button ID="btnNewRow" runat="server" Text="新增一行" OnClick="ButtonOrderDepNewRow_Clikc"></f:Button>
                       <f:Button ID="Button1" runat="server" Text="保存" OnClick="ButtonSave_Click"></f:Button>
                       <f:Button ID="Button3" runat="server" Text="删除" OnClick="BtnDelete_Click" ConfirmText="确认删除？"></f:Button>
                    </Items>
                </f:Toolbar>
                <f:Grid ID="Grid1" Title="维护" EnableCollapse="true" ShowHeader="false" runat="server" Height="600px" DataKeyNames="Id"
                     EnableCheckBoxSelect="true" AllowCellEditing="true" ClicksToEdit="1" EnableRowClickEvent="true" OnRowClick="Grid1_RowClick"> 
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField Width="130px" ColumnID="Id" DataField="Id" FieldType="String" Hidden="true"
                                HeaderText="编码">
                                <Editor>
                                    <f:TextBox ID="tbxId" runat="server" Required="true" ShowRedStar="true">
                                    </f:TextBox>
                                </Editor>
                           </f:RenderField>
                        <f:RenderField Width="130px" ColumnID="ORDDEP_ID" DataField="ORDDEP_ID" FieldType="String" Enabled="false"
                                HeaderText="订货部门编码">
                                <Editor>
                                    <f:TextBox ID="tbxORDDEP_ID" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                    </f:TextBox>
                                </Editor>
                           </f:RenderField>
                        <f:RenderField Width="130px" ColumnID="ORDDEP_NAME" DataField="ORDDEP_NAME" FieldType="String"
                                HeaderText="订货部门名称">
                                <Editor>
                                    <f:TextBox ID="tbxORDDEP_NAME" runat="server" Required="true" ShowRedStar="true">
                                    </f:TextBox>
                                </Editor>
                           </f:RenderField>
                        <f:RenderField Width="130px" ColumnID="ORDER_WEEK" DataField="ORDER_WEEK" FieldType="String" 
                                HeaderText="工作日" RendererFunction="renderORDDEP_WEEK" >
                                <Editor>
                                    <f:DropDownList ID="ddlORDDEP_WEEK" runat="server" EnableEdit="true" AutoSelectFirstItem="false">
                                        <f:ListItem Value="Mon" Text="星期一" />
                                        <f:ListItem Value="Tues" Text="星期二" />
                                        <f:ListItem Value="Wed" Text="星期三" />
                                        <f:ListItem Value="Thur" Text="星期四" />
                                        <f:ListItem Value="Fri" Text="星期五" />
                                        <f:ListItem Value="Sat" Text="星期六" />
                                        <f:ListItem Value="Sun" Text="星期天" />
                                    </f:DropDownList>
                                </Editor>
                           </f:RenderField>
                        <f:RenderCheckField ColumnID="USABLE" DataField="USABLE" Width="80px" HeaderText="启用" />
                        <f:RenderField Width="130px" ColumnID="CRT_USER_ID" DataField="CRT_USER_ID" FieldType="String" Enabled="false"
                                HeaderText="建档人员">
                                <Editor>
                                    <f:TextBox ID="tbxCRT_USER_ID" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                    </f:TextBox>
                                </Editor>
                           </f:RenderField>
                        <f:RenderField Width="130px" ColumnID="CRT_DATETIME" DataField="CRT_DATETIME" FieldType="String" Enabled="false"
                                HeaderText="建档日期">
                                <Editor>
                                    <f:TextBox ID="tbxCRT_DATETIME" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                    </f:TextBox>
                                </Editor>
                           </f:RenderField>
                        <f:RenderField Width="130px" ColumnID="MOD_USER_ID" DataField="MOD_USER_ID" FieldType="String" Enabled="false"
                                HeaderText="修改人员">
                                <Editor>
                                    <f:TextBox ID="tbxMOD_USER_ID" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                    </f:TextBox>
                                </Editor>
                           </f:RenderField>
                        <f:RenderField Width="130px" ColumnID="MOD_DATETIME" DataField="MOD_DATETIME" FieldType="String" Enabled="false"
                                HeaderText="修改日期">
                                <Editor>
                                    <f:TextBox ID="tbxMOD_DATETIME" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                    </f:TextBox>
                                </Editor>
                           </f:RenderField>
                    </Columns>
                </f:Grid>
                <f:HiddenField ID="hidORDDEP_ID" runat="server"></f:HiddenField>
            </Items>
            <Items>
                <f:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                        <Tabs>
                            <f:Tab ID="Tab1" Title="订货类别" Layout="VBox" Icon="House" runat="server">
                                <Items>
                                     <f:Grid ID="Grid2" Title="订货类别" EnableCollapse="true" ShowHeader="false" runat="server" DataKeyNames="Id" EnableColumnLines="true"
                                        AllowCellEditing="true" ClicksToEdit="1"  OnPreDataBound="Grid2_PreDataBound"> 
                                      <Columns>
                                          <f:RowNumberField />
                                          <f:RenderField Width="130px" ColumnID="Id1" DataField="Id" FieldType="String" Hidden="true"
                                            HeaderText="编码">
                                            <Editor>
                                                <f:TextBox ID="tbxId1" runat="server" Required="true" ShowRedStar="true">
                                                </f:TextBox>
                                            </Editor>
                                          </f:RenderField>
                                          <f:RenderField Width="130px" ColumnID="ORDDEP_ID1" DataField="ORDDEP_ID" FieldType="String" Hidden="true"
                                            HeaderText="订货部门编码">
                                            <Editor>
                                                <f:TextBox ID="tbxORDDEP_ID1" runat="server" Required="true" ShowRedStar="true">
                                                </f:TextBox>
                                            </Editor>
                                          </f:RenderField>
                                          <f:RenderField Width="130px" ColumnID="DEP_ID1" DataField="DEP_ID" FieldType="String" Enabled="false"
                                            HeaderText="中类编码">
                                            <Editor>
                                                <f:TextBox ID="tbxDEP_ID" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                </f:TextBox>
                                            </Editor>
                                          </f:RenderField>
                                          
                                          <f:RenderField Width="130px" ColumnID="DEP_NAME1" DataField="DEP_NAME"
                                            HeaderText="中类名称">
                                            <Editor>
                                                <f:DropDownList ID="ddlDEP_NAME" runat="server">
                                                </f:DropDownList>
                                            </Editor>
                                          </f:RenderField>
                                          <f:RenderField Width="130px" ColumnID="Meno1" DataField="Meno"
                                            HeaderText="备注">
                                            <Editor>
                                                <f:TextBox ID="tbxMeno" runat="server" Required="true" ShowRedStar="true" Text="" Enabled="true">
                                                </f:TextBox>
                                            </Editor>
                                          </f:RenderField>
                                          <f:RenderCheckField ColumnID="USABLE1" DataField="USABLE" Width="80px" HeaderText="启用" />
                                           <f:RenderField Width="130px" ColumnID="CRT_USER_ID1" DataField="CRT_USER_ID" FieldType="String" Enabled="false"
                                                HeaderText="建档人员">
                                                <Editor>
                                                    <f:TextBox ID="tbxCRT_USER_ID1" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                           </f:RenderField>
                                           <f:RenderField Width="130px" ColumnID="CRT_DATETIME1" DataField="CRT_DATETIME" FieldType="String" Enabled="false"
                                                HeaderText="建档日期">
                                                <Editor>
                                                    <f:TextBox ID="tbxCRT_DATETIME1" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                           </f:RenderField>
                                           <f:RenderField Width="130px" ColumnID="MOD_USER_ID1" DataField="MOD_USER_ID" FieldType="String" Enabled="false"
                                                HeaderText="修改人员">
                                                <Editor>
                                                    <f:TextBox ID="tbxMOD_USER_ID1" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                           </f:RenderField>
                                           <f:RenderField Width="130px" ColumnID="MOD_DATETIME1" DataField="MOD_DATETIME" FieldType="String" Enabled="false"
                                                HeaderText="修改日期">
                                                <Editor>
                                                    <f:TextBox ID="tbxMOD_DATETIME1" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                    </f:TextBox>
                                                </Editor>
                                           </f:RenderField>
                                      </Columns>
                                       <Listeners>
                                           <f:Listener Event="edit" Handler="onGridAfterEdit" />
                                      </Listeners>
                                   </f:Grid>
                                </Items>
                                <Items>
                                    <f:Toolbar runat="server" ID="toolBarGrid2">
                                        <Items>
                                            <f:Button ID="Button2" runat="server" Width="80px" Text="新增" OnClick="Grid2Add_Click"></f:Button>
                                            <f:Button ID="Button4" runat="server" Text="删除" OnClick="Grid2Delete_Click" ConfirmText="确认删除？"></f:Button>
                                        </Items>
                                    </f:Toolbar>
                                </Items>
                            </f:Tab>
                            <f:Tab ID="Tab2" Title="可用分店" runat="server" Layout="HBox">
                                <Items>
                                    <f:Panel ID="PanelLeft" runat="server">
                                        <Items>
                                             <f:Grid ID="Grid4" Title="可选分店清单" ShowBorder="false" Width="300px" EnableCollapse="true" ShowHeader="false" runat="server" DataKeyNames="Id"> 
                                                <Columns>
                                                    <f:RowNumberField />
                                                    <f:RenderField Width="130px" ColumnID="SHOP_ID1" DataField="SHOP_ID" FieldType="String" Enabled="false"
                                                    HeaderText="分店编码">
                                                    <Editor>
                                                        <f:TextBox ID="tbxSHOP_ID1" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                        </f:TextBox>
                                                    </Editor>
                                                    </f:RenderField>
                                                    <f:RenderField Width="130px" ColumnID="SHOP_NAME1" DataField="SHOP_NAME1" FieldType="String" Enabled="false"
                                                    HeaderText="分店名称">
                                                    <Editor>
                                                        <f:TextBox ID="tbxSHOP_NAME1" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                        </f:TextBox>
                                                    </Editor>
                                                    </f:RenderField>
                                                </Columns>
                                            </f:Grid>
                                        </Items>
                                    </f:Panel>
                                    <f:Panel ID="PanelCenter" runat="server" Layout="VBox">
                                        <Items>
                                            <f:Button Text="<添加" Height="40px" runat="server" OnClick="MoveToLeft"></f:Button>
                                            <f:Button Text="<<全部添加" Height="40px" runat="server" OnClick="MoveAllToLeft"></f:Button>
                                            <f:Button Text="移除>" Height="40px" runat="server" OnClick="MoveToRight"></f:Button>
                                            <f:Button Text="全部移除>>" Height="40px" runat="server" OnClick="MoveAllToRight"></f:Button>
                                        </Items>
                                    </f:Panel>

                                    <f:Panel ID="PanelRight" runat="server">
                                        <Items>
                                            <f:Grid ID="Grid5" Title="可用分店" Width="300px" ShowBorder="false" EnableCollapse="true" ShowHeader="false" runat="server" 
                                                DataKeyNames="Id,SHOP_ID"> 
                                                <Columns>
                                                    <f:RowNumberField />
                                                    <f:RenderField Width="130px" ColumnID="SHOP_ID2" DataField="SHOP_ID" FieldType="String" Enabled="false"
                                                    HeaderText="分店编码" >
                                                    <Editor>
                                                        <f:TextBox ID="TextBox3" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                        </f:TextBox>
                                                    </Editor>
                                                    </f:RenderField>
                                                    <f:RenderField Width="130px" ColumnID="SHOP_NAME2" DataField="SHOP_NAME1" FieldType="String" Enabled="false"
                                                    HeaderText="分店名称">
                                                    <Editor>
                                                        <f:TextBox ID="TextBox4" runat="server" Required="true" ShowRedStar="true" Enabled="false">
                                                        </f:TextBox>
                                                    </Editor>
                                                    </f:RenderField>
                                                </Columns>
                                            </f:Grid>
                                        </Items>
                                    </f:Panel>
                                </Items>
                            </f:Tab>
                        </Tabs>
                  </f:TabStrip>
            </Items>
        </f:Panel>

    </form>
    <f:Window ID="Window2" Width="430px" Height="800px" Icon="TagBlue" Hidden="true" BodyPadding="10px"
        EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
        IsModal="false" CloseAction="HidePostBack" OnClose="Window2_Close" Layout="Fit">
        <Content>
            <f:Panel runat="server" ID="PanelA" RegionPosition="Right" RegionSplit="true" EnableCollapse="true" Expanded="true"
                Width="400px" Title="商品中类" ShowBorder="true" ShowHeader="true"
                BodyPadding="5px">
                <Items>
                    <f:Button ID="BtnAddGrid2" runat="server" Text="确定" Icon="Magnifier" OnClick="Grid2AddNewRow_Click"  ></f:Button>
                </Items>
                <Items>
                    <f:Grid ID="Grid3" Title="商品中类" ShowHeader="false" ShowBorder="false" runat="server" DataKeyNames="Id"
                        EnableCheckBoxSelect="true" KeepCurrentSelection="true" PageSize="1000" AllowPaging="false"
                        ><%--EnableRowClickEvent="true" OnRowClick="Grid1_RowClick" --%>
                        <Columns>
                        <f:RowNumberField />
                        <f:BoundField Width="125px" DataField="DEP_ID" HeaderText="中类编码" ExpandUnusedSpace="true"  />
                        <f:BoundField Width="125px" DataField="DEP_NAME" HeaderText="中类名称" ExpandUnusedSpace="true"  />
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Panel>
        </Content>
    </f:Window>
    <script>

        function onGridAfterEdit(editor, params) {
            var me = this, columnId = params.column.id, rowId = params.record.getId();
            if (columnId == "DEP_NAME1")
            {
                var strDEP_ID = me.f_getCellValue(rowId, 'DEP_NAME1');
                var strDEP_ID2 = me.f_getCellValue(rowId, 'DEP_ID1');
                if (strDEP_ID == ""||strDEP_ID==null)
                {
                    strDEP_ID = strDEP_ID2;
                }
                me.f_updateCellValue(rowId, 'DEP_ID1', strDEP_ID);
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
                        //alert(strResult);
                        var obj = JSON.parse(strResult);
                        //alert(strResult);
                        me.f_updateCellValue(rowId, 'DEP_NAME1', obj[0].DEP_NAME);
                        
                    }
                    else {
                        //alert(xmlhttp.responseText);
                        //me.f_updateCellValue(rowId, 'PROD_NAME1', xmlhttp.responseText);
                        //return "失败了";
                    }
                }
                xmlhttp.open("GET", "../DataCenter/ProdDepHandler.ashx?opt=1&dep_id=" + strDEP_ID + "", false);
                xmlhttp.send();

            }
        }
        function renderORDDEP_WEEK(value) {
            switch (value)
            {
                case "Mon": return "星期一"; break;
                case "Tues": return "星期二"; break;
                case "Wed": return "星期三" ;break;
                case "Thur": return "星期四"; break;
                case "Fri": return "星期五" ;break;
                case "Sat": return "星期六" ;break;
                case "Sun": return "星期日";break;
                default: return "";break;
            }
        }
    </script>
</body>
</html>
