﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopPriceAreaEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.DataCenter.ShopPriceAreaEdit" %>

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
                            <f:TextBox runat="server" Label="价格区编号" ID="PRCAREA_ID" ShowRedStar="true" Width="250px" EmptyText="价格区编号"></f:TextBox>
                            <f:TextBox runat="server" Label="价格区名称" ID="PRCAREA_NAME" ShowRedStar="true" Width="400px" EmptyText="价格区名称" ></f:TextBox>
                            <f:RadioButtonList ID="ENABLE" Label="有效" ColumnNumber="3" runat="server"
                                ShowRedStar="true" Required="true">
                                <f:RadioItem Text="无效" Value="0" />
                                <f:RadioItem Text="有效" Value="1" Selected="true" />
                            </f:RadioButtonList>
                            <f:TextBox runat="server" Label="备注" ID="PRCAREA_MEMO" Width="400px" EmptyText="备注" ></f:TextBox>
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
