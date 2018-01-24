<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SHOP00Edit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.DataCenter.SHOP00Edit" %>

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
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Panel ID="Panel2" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" ShowHeader="False" ShowBorder="False">
                <Items>
                    <f:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <f:TextBox runat="server" Width="250px" ID="txtSHOP_ID" Label="分店ID" ShowRedStar="true" />
                            <f:TextBox runat="server" Width="250px" ID="txtSHOP_NAME1" Label="分店全称" ShowRedStar="true" />
                            <f:TextBox  runat="server" Width="250px" ID="txtSHOP_NAME2" Label="分店简称" ShowRedStar="true" />
                            <f:TextBox runat="server" Width="250px" ID="txtSHOP_KIND" Label="分店属性" ShowRedStar="true" />
                            <f:DropDownList Label="隶属区域" AutoPostBack="true" Required="true" CompareType="String"
                                EnableSimulateTree="true" runat="server" ID="txtSHOP_Area_ID" Width="250px"
                                >  <%--OnSelectedIndexChanged="ddlParentId_SelectedIndexChanged"--%>
                            </f:DropDownList>

                            
                           <%-- <f:TextBox runat="server" Width="250px" ID="txtSHOP_Price_Area" Label="分店价格区域" ShowRedStar="true"/>--%>
                             <f:DropDownList Label="价格区域" AutoPostBack="true" Required="true" CompareType="String"
                                EnableSimulateTree="true" runat="server" ID="ddlSHOP_Price_Area" Width="250px"
                                >   
                            </f:DropDownList>

                            <f:TextBox runat="server" Width="250px" ID="txtSHOP_ADD" Label="分店地址" ShowRedStar="true" />
                            <f:TextBox runat="server" Width="250px" ID="txtSHOP_TEL" Label="分店电话" ShowRedStar="true" />
                            <f:TextBox runat="server" Width="250px" ID="txtSHOP_EMAIL" Label="分店邮箱" ShowRedStar="true" />
                            <f:TextBox runat="server" Width="250px" ID="txtSHOP_CONTECT" Label="分店负责人" ShowRedStar="true"/>
                            <f:TextBox runat="server" Width="250px" ID="txtSHOP_MEMO" Label="分店备注" ShowRedStar="true" />
                            <f:TextBox runat="server" Width="250px" ID="txtSHOP_STATUS" Label="分店状态" ShowRedStar="true" />
                            <f:TextBox runat="server" Width="250px" ID="txtSHOP_Limited" Label="订货额度控管" ShowRedStar="true" />
                            <f:TextBox runat="server" Width="250px" ID="txtCRT_DATETIME" Label="建档日期" ShowRedStar="true" />
                            <f:TextBox runat="server" Width="250px" ID="txtCRT_USER_ID" Label="建档人员" ShowRedStar="true" />
                         
                            <f:TextBox runat="server" Width="250px" ID="txtMOD_USER_ID" Label="修改人员" ShowRedStar="true"/>
                            <f:TextBox runat="server" Width="250px" ID="txtMOD_DATETIME" Label="修改时间" ShowRedStar="true"/>
                            <f:TextBox runat="server" Width="250px" ID="txtLAST_UPDATE" Label="最后异动时间" ShowRedStar="true" />
                            <f:TextBox runat="server" Width="250px" ID="txtSTATUS" Label="手动传输状态" ShowRedStar="true"/>

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

