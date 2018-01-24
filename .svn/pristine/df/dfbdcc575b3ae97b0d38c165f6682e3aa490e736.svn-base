<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order_ProductEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SupplyCenter.Order_ProductEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>菜单编辑</title>
    <style type="text/css">
        .photo
        {
            text-align: right;
        }
        .photo img
        {
            width: 200px;
        }
        .btn_Css_Readonly
        {
            background-color:#CCCCCC;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server" />
    <f:Panel ID="Panel1" runat="server" EnableFrame="false" BodyPadding="10px" EnableCollapse="True" ShowHeader="False">
        <Toolbars>
            <f:Toolbar ID="toolBar" runat="server">
                <Items>
                    <f:Button ID="ButtonSave" runat="server" Text="保存" Icon="Disk" OnClick="ButtonSave_Click"></f:Button>
                    <f:Button ID="ButtonCancel" runat="server" Text="取消" Icon="Cancel" ></f:Button>
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Panel ID="Panel2" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" ShowHeader="False" ShowBorder="False">
                <Items>
                    <f:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>

                        <f:DropDownList ID="ddlPROD_NAME1" runat="server" Label="商品名称" AutoPostBack="true" Required="true" OnSelectedIndexChanged="ddlPROD_NAME1_SelectedIndexChanged">
                    <%--OnSelectedIndexChanged="ddlPROD_NAME2_SelectedIndexChanged"--%>
                        </f:DropDownList>
                
                        <f:TextBox ID="txtPROD_ID" Required="true" runat="server" Label="商品编号" Enabled="false">
                        </f:TextBox>
                 
                        <f:TextBox ID="txtPROD_SPEC" Required="true" runat="server" Label="商品规格" Enabled="false" >
                        </f:TextBox>
               
                        <f:TextBox ID="txtPROD_UNIT" Required="true" runat="server" Label="商品单位" Enabled="false">
                        </f:TextBox>

                        <f:TextBox ID="txtON_QUAN" Required="true" runat="server" Label="数量" AutoPostBack="true" OnTextChanged="txtON_QUAN_TextChanged">
                        </f:TextBox>

                        <f:TextBox ID="txtU_Cost" Required="true" runat="server" Label="单价" Enabled="false">
                        </f:TextBox>

                        <f:TextBox ID="txtTotal" Required="true" runat="server" Label="小计" Enabled="false">
                        </f:TextBox>
                 
                        <f:TextBox ID="txtOrder_QUAN" Required="true" runat="server" Label="最小订货量" Enabled="false">
                        </f:TextBox>
              
                        <f:TextBox ID="txtMemo" Required="true" runat="server" Label="备注">
                        </f:TextBox>
                            
                             

                            <f:HiddenField runat="server" ID="hidId" Text="0"></f:HiddenField>
                        </Items>
                    </f:SimpleForm>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    </form>
</body>
</html>
