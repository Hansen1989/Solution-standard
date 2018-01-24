<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestAddRow.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SupplyCenter.TestAddRow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
    </div>
    <div>
        <div><asp:Button runat="server" ID="btnAdd" Text="新增" OnClick="btnAdd_Click" /></div>  
 <asp:GridView ID="gv" runat="server" AllowPaging="True" AllowSorting="True" DataKeyNames="id"
     AutoGenerateColumns="False" OnRowCancelingEdit="gv_RowCancelingEdit" OnRowEditing="gv_RowEditing"  
     OnRowUpdating="gv_RowUpdating" OnRowDeleting="gv_RowDeleting" OnRowDataBound="gv_RowDataBound">  
     <Columns>  
         <asp:TemplateField HeaderText="名称">  
             <EditItemTemplate>  
                 <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("txtName") %>'></asp:TextBox>  
                 <asp:RequiredFieldValidator runat="server" ID="rfvtxtName" ControlToValidate="txtName"  
                     Display="Dynamic" ErrorMessage="*不能为空" ForeColor="Red"></asp:RequiredFieldValidator>  
             </EditItemTemplate>  
             <ItemTemplate>  
                 <asp:Label ID="lblName" runat="server" Text='<%# Bind("txtName") %>'></asp:Label>  
             </ItemTemplate>  
             <ItemStyle HorizontalAlign="Center" />  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="状态">  
             <EditItemTemplate>  
                 <asp:DropDownList ID="ddlIsEnable" runat="server">  
                     <asp:ListItem Value="True">启用</asp:ListItem>  
                     <asp:ListItem Value="False">停用</asp:ListItem>  
                 </asp:DropDownList>  
                 <asp:HiddenField ID="hfIsEnable" runat="server" Value='<%# Eval("IsEnable")%>' />  
             </EditItemTemplate>  
             <ItemTemplate>  
                 <asp:Label ID="lblIsEnable" runat="server" Text='<%# Eval("IsEnable").ToString() == "True" ? "启用" : "停用" %>'></asp:Label>  
             </ItemTemplate>  
             <ItemStyle HorizontalAlign="Center" />  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="排序号">  
             <EditItemTemplate>  
                 <asp:TextBox ID="txtOrder" runat="server" Text='<%# Bind("Order") %>'></asp:TextBox>  
                 <asp:RegularExpressionValidator runat="server" ID="revOrder" ControlToValidate="txtOrder"  
                     ValidationExpression="\d+" Display="Dynamic" ErrorMessage="*必须为整数"></asp:RegularExpressionValidator>  
             </EditItemTemplate>  
             <ItemTemplate>  
                 <asp:Label ID="lblOrder" runat="server" Text='<%# Eval("Order") %>'></asp:Label>  
             </ItemTemplate>  
             <ItemStyle HorizontalAlign="Center" />  
         </asp:TemplateField>  
         <asp:CommandField ShowDeleteButton="true" ShowEditButton="true" EditText="编辑" DeleteText="删除"  
             CancelText="取消" HeaderText="操作" />  
     </Columns>  
     <EmptyDataTemplate>  
         没有您查询的数据  
     </EmptyDataTemplate>  
     <PagerSettings Visible="false" />  
 </asp:GridView>  


    </div>
    </form>
</body>
</html>
