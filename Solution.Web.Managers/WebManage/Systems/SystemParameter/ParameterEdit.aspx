<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParameterEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SystemParameter.ParameterEdit" %>

<!DOCTYPE html>

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
                             
                            <f:DropDownList runat="server" ID="ddlAREA" Label="区域" Width="250px"></f:DropDownList>
                            <f:Label runat="server" Text="KEY"></f:Label>
                            <f:TextBox runat="server" ID ="txt_key"></f:TextBox>
                            <f:Label runat="server" Text="VALUE"></f:Label>
                            <f:DropDownList runat="server" ID="value_droplist">
                                <f:ListItem Value="0"/>
                                <f:ListItem Value="1"/>
                                <f:ListItem Value="2"/>
                                <f:ListItem Value="3"/>
                            </f:DropDownList>
                             <f:Label runat="server" Text="KEY_CN"></f:Label>
                            <f:TextBox runat="server" ID ="key_cn"></f:TextBox>
                              <f:Label runat="server" Text="MEMO"></f:Label>
                            <f:TextBox runat="server" ID ="txt_memo"></f:TextBox>

                            <%--<f:DropDownList runat="server" ID="ddlCOL_ORDER_TYPE" Label="汇整类型" Width="250px">
                                <f:ListItem Text="产品类型" Value="0"/>
                                <f:ListItem Text="订单类别" Value="1"/>
                            </f:DropDownList>
                            <f:DropDownList runat="server" ID="ddlORDER_PRICE_TYPE" Label="售价单价参数" Width="250px">
                                <f:ListItem Text="维护价" Value="0"/>
                                <f:ListItem Text="合同价" Value="1"/>
                            </f:DropDownList>
                            <f:DropDownList runat="server" ID="ddlQUANTITY_TYPE" Label="订货量参数" Width="250px">
                                <f:ListItem Text="订货量" Value="0"/>
                                <f:ListItem Text="最低倍数" Value="1"/>
                            </f:DropDownList>
                            <f:DropDownList runat="server" ID="ddlEXPECT_DATE_TYPE" Label="期望日期参数" Width="250px">
                                <f:ListItem Text="0" Value="0"/>
                                <f:ListItem Text="1" Value="1"/>
                                <f:ListItem Text="2" Value="2"/>
                                <f:ListItem Text="3" Value="3"/>
                                <f:ListItem Text="4" Value="4"/>

                            </f:DropDownList>
                            <f:DropDownList runat="server" ID="ddlPRD_BOM_TYPE" Label="配方层次拆解" Width="250px">
                                <f:ListItem Text="配方资料拆解" Value="0" />
                                <f:ListItem Text="配方层次" Value="1" />
                            </f:DropDownList>
                            <f:DropDownList runat="server" ID="ddlPALN_TYPE" Label="生产计划参数" Width="250px">
                                <f:ListItem Text="部门" Value="0" />
                                <f:ListItem Text="商品" Value="1" />
                            </f:DropDownList>--%>

                   <%-- <f:BoundField Width="250px" DataField="CRT_DATETIME" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="建档时间" />
                    <f:BoundField Width="250px" DataField="CRT_USER_ID" DataFormatString="{0}" HeaderText="创建人" />
                    <f:BoundField Width="250px" DataField="MOD_DATETIME" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="修改时间" />
                    <f:BoundField Width="250px" DataField="MOD_USER_ID" DataFormatString="{0}" HeaderText="修改人" />
                    <f:BoundField Width="250px" DataField="LAST_UPDATE" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="最后异动时间" />--%>


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
