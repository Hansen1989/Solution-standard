<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupAreaEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.DataCenter.GroupAreaEdit" %>

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
                            <f:TextBox runat="server" Label="区域编号" ID="txtAREA_ID" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="区域名称" ID="txtAREA_NAME" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="区域地址" ID="txtAREA_ADD" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="区域电话" ID="txtAREA_TEL" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="区域邮箱" ID="txtAREA_EMAIL" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="区域负责人" ID="txtAREA_CONTECT" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="区域备注" ID="txtAREA_MEMO" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:DropDownList runat="server" ID="ddlAREA_STATUS" Label="区域状态" ShowRedStar ="true" Width="250px">
                                <f:ListItem Text="启用" Value="1"/>
                                <f:ListItem Text="停用" Value="0"/>
                            </f:DropDownList>
 

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
