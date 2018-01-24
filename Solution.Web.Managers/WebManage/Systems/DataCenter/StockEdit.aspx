<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.DataCenter.StockEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <f:pagemanager id="PageManager1" runat="server" />
    <f:Panel ID="Panel1" runat="server" EnableFrame="false" BodyPadding="10px" EnableCollapse="True" ShowHeader="False">
        <Toolbars>
            <f:Toolbar ID="toolBar" runat="server">
                <Items>
                    <f:Button ID="ButtonSave" runat="server" Text="保存" Icon="Disk"  OnClick="ButtonSave_Click" ></f:Button>
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
                            <f:DropDownList Label="分店名称" AutoPostBack="true" Required="true" CompareType="String"
                                EnableSimulateTree="true" runat="server" ID="SHOP_ID" Width="250px">
                            </f:DropDownList>
                            <f:TextBox runat="server" Label="仓库编号" ID="STOCK_ID" ShowRedStar="true" Width="400px" EmptyText="仓库编号" ></f:TextBox>
                            <f:TextBox runat="server" Label="仓库名称" ID="STOCK_NAME" ShowRedStar="true" Width="400px" EmptyText="仓库名称" ></f:TextBox>
                            <f:NumberBox ID="IsDefBill" runat="server" Label="单据默认仓库"  Width="200px" Text="0"
                                  NoDecimal="true" Required="True" ShowRedStar="True">
                            </f:NumberBox>
                            <f:TextBox runat="server" Label="备注" ID="Memo" Width="400px" EmptyText="备注" ></f:TextBox>
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
