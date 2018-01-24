<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grid_editor_cell_new_delete.aspx.cs"
    Inherits="Solution.Web.Managers.WebManage.Systems.SupplyCenter.grid_editor_cell_new_delete" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../res/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" />
    <f:Grid ID="Grid1" ShowBorder="true" ShowHeader="true" Title="表格" EnableFrame="false" EnableCollapse="true" Width="850px" Height="400px"
        runat="server" DataKeyNames="Id,Name" AllowCellEditing="true" ClicksToEdit="1" OnPreDataBound="Grid1_PreDataBound">
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
            <f:TemplateField ColumnID="Number" Width="60px">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                </ItemTemplate>
            </f:TemplateField>
            <f:RenderField Width="100px" ColumnID="Name" DataField="Name" FieldType="String"
                HeaderText="姓名">
                <Editor>
                    <f:TextBox ID="tbxEditorName" Required="true" runat="server">
                    </f:TextBox>
                </Editor>
            </f:RenderField>
            <f:RenderField Width="100px" ColumnID="Gender" DataField="Gender" FieldType="String"
                RendererFunction="renderGender" HeaderText="性别">
                <Editor>
                    <f:DropDownList ID="ddl" Required="true" runat="server">
                        <f:ListItem Text="男" Value="1" />
                        <f:ListItem Text="女" Value="0" />
                    </f:DropDownList>
                </Editor>
            </f:RenderField>
            <f:RenderField Width="100px" ColumnID="EntranceYear" DataField="EntranceYear" FieldType="Int"
                HeaderText="入学年份">
                <Editor>
                    <f:NumberBox ID="tbxEditorEntranceYear" NoDecimal="true" NoNegative="true" MinValue="2000"
                        MaxValue="2010" runat="server">
                    </f:NumberBox>
                </Editor>
            </f:RenderField>
            <f:RenderField Width="120px" ColumnID="EntranceDate" DataField="EntranceDate" FieldType="Date"
                Renderer="Date" RendererArgument="yyyy-MM-dd" HeaderText="入学日期">
                <Editor>
                    <f:DatePicker ID="DatePicker1" Required="true" runat="server">
                    </f:DatePicker>
                </Editor>
            </f:RenderField>
            <f:RenderCheckField Width="100px" ColumnID="AtSchool" DataField="AtSchool" HeaderText="是否在校" />
            <f:RenderField Width="100px" ColumnID="Major" DataField="Major" FieldType="String"
                ExpandUnusedSpace="true" HeaderText="所学专业">
                <Editor>
                    <f:TextBox ID="tbxEditorMajor" Required="true" runat="server">
                    </f:TextBox>
                </Editor>
            </f:RenderField>
            <f:LinkButtonField ColumnID="Delete" HeaderText="&nbsp;" Width="80px" EnablePostBack="false"
                Icon="Delete" />
        </Columns>
    </f:Grid>
    <br />
    <f:Button ID="Button2" runat="server" Text="保存数据" OnClick="Button2_Click">
    </f:Button>
    <br />
    <br />
    <f:Label ID="labResult" EncodeText="false" runat="server">
    </f:Label>
    <br />
    </form>
    <script>

        function renderGender(value) {
            return value === '1' ? '男' : '女';
        }



    </script>
</body>
</html>
