<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grid_editor_cell_updatecellvalue.aspx.cs"
    Inherits="Solution.Web.Managers.WebManage.Systems.SupplyCenter.grid_editor_cell_updatecellvalue" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Grid ID="Grid1" ShowBorder="true" ShowHeader="true" Title="表格（双击编辑）" EnableCollapse="true" Width="850px"
            runat="server" DataKeyNames="SNo" AllowCellEditing="true" ClicksToEdit="1" OnPreDataBound="Grid1_PreDataBound" 
            DataIDField="SNo">   <%-- OnPreRowDataBound="Grid1_PreRowDataBound" --%>
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnNew" Text="新增数据" Icon="Add" EnablePostBack="false" runat="server">
                        </f:Button>
                        <f:Button ID="btnDelete" Text="删除选中行" Icon="Delete" EnablePostBack="false" runat="server">
                        </f:Button>
                        <f:ToolbarFill runat="server">
                        </f:ToolbarFill>
                        <f:Button ID="btnReset" Text="重置表格数据" EnablePostBack="false" runat="server">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
               <%-- <f:TemplateField ColumnID="Number" Width="60px">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>--%>

                <f:TemplateField ColumnID="SNo" Width="60px" HeaderText="序号">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("SNo") %>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>

                <f:RenderField Width="100px" ColumnID="PROD_NAME1" DataField="PROD_NAME1"
                    HeaderText="商品名称">
                    <Editor>
                        <f:DropDownList ID="DropDownList1"  runat="server">
                        </f:DropDownList>
                    </Editor>
                </f:RenderField>

                <f:RenderField Width="100px" ColumnID="PROD_ID" DataField="PROD_ID" FieldType="String"
                    HeaderText="商品编号">
                    <Editor>
                        <f:TextBox ID="tbxPROD_ID" runat="server">
                        </f:TextBox>
                    </Editor>
                </f:RenderField>

               <%--<f:TemplateField HeaderText="商品名称">
                        <ItemTemplate>
                            <asp:DropDownList runat="server" ID="DropDownList1">
                            </asp:DropDownList>
                        </ItemTemplate>
               </f:TemplateField>--%>

                 

                
                <f:RenderField Width="100px" ColumnID="PROD_SPEC" DataField="PROD_SPEC" FieldType="String"
                    ExpandUnusedSpace="true" HeaderText="产品规格">
                    <Editor>
                        <f:TextBox ID="tbxPROD_SPEC" Required="true" runat="server">
                        </f:TextBox>
                    </Editor>
                </f:RenderField>
                <f:RenderField Width="100px" ColumnID="PROD_UNIT" DataField="PROD_UNIT" 
                    HeaderText="单位">  <%--FieldType="Int" NoDecimal="true" NoNegative="true" --%>
                    <Editor>
                        <f:NumberBox ID="txtPROD_UNIT" Required="true" runat="server">
                        </f:NumberBox>
                    </Editor>
                </f:RenderField>
                <f:RenderField Width="100px" ColumnID="ON_QUAN" DataField="ON_QUAN" FieldType="Int"
                    HeaderText="订货量">
                    <Editor>
                        <f:NumberBox ID="txtON_QUAN" NoDecimal="true" NoNegative="true" Required="true" runat="server">
                        </f:NumberBox>
                    </Editor>
                </f:RenderField>
                <f:RenderField Width="100px" ColumnID="Cost" DataField="Cost" 
                    HeaderText="单价"> <%--FieldType="Int"--%>
                    <Editor>
                        <f:NumberBox ID="txtCost" NoDecimal="false" NoNegative="true" Required="true" runat="server">
                        </f:NumberBox>
                    </Editor>
                </f:RenderField>
                <f:RenderField Width="100px" ColumnID="QUAN1" DataField="QUAN1" FieldType="Int"
                    HeaderText="小计">
                    <Editor>
                        <f:NumberBox ID="txtQUAN1" NoDecimal="false" NoNegative="true" Required="true" runat="server">
                        </f:NumberBox>
                    </Editor>
                </f:RenderField>
                <f:LinkButtonField ColumnID="Delete" Width="80px" EnablePostBack="false"
                    Icon="Delete" />
            </Columns>
            <Listeners>
                <f:Listener Event="edit" Handler="onGridAfterEdit" />
            </Listeners>
        </f:Grid>
        <br />
        <f:Button ID="Button2" runat="server" Text="保存数据" OnClick="Button2_Click">
        </f:Button>
        <br />
        <br />
        <f:Label ID="labResult" EncodeText="false" runat="server">
        </f:Label>
        <br />
        注：编辑[语文成绩]或者[数学成绩]时会同时更新[总成绩]。
    </form>
    <script>
        function renderGender(value) {
            return value == 1 ? '男' : '女';
        }

        // 注意：专业版中改事件名为：afteredit，开源版中为：edit
        function onGridAfterEdit(editor, params) {
            var me = this, columnId = params.column.id, rowId = params.record.getId();
            if (columnId === 'ON_QUAN' || columnId === 'Cost' || columnId === 'PROD_NAME1') {
                var chineseScore = me.f_getCellValue(rowId, 'ON_QUAN');
                var mathScore = me.f_getCellValue(rowId, 'Cost');
                var strvalue = me.f_getCellValue(rowId, 'PROD_NAME1');
                var cc;
                if (columnId === "PROD_NAME1") {
                    //var ss = loadXMLDoc(strvalue);
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
                        else {
                            me.f_updateCellValue(rowId, 'PROD_NAME1', xmlhttp.responseText);
                            //return "失败了";
                        }
                    }
                    xmlhttp.open("GET", "test.ashx?value=" + strvalue, true);
                    xmlhttp.send();
                }
                //alert(ss);
                //alert(sss);
                me.f_updateCellValue(rowId, 'QUAN1', chineseScore * mathScore);
                me.f_updateCellValue(rowId, 'PROD_ID', strvalue);
                
            }
        }
        function loadXMLDoc(str) {
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
                    return xmlhttp.responseText;
                }
                else {
                    return "失败了";
                }
            }
            xmlhttp.open("GET", "test.ashx", true);
            xmlhttp.send();
        }

    </script>
</body>
</html>
