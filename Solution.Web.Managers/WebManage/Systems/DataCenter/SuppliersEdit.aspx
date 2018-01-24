<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuppliersEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.DataCenter.SuppliersEdit" %>

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
                    <f:Form ID="Form5" LabelAlign="Left"  BodyPadding="5px" LabelWidth="120px" 
                        runat="server" Title="表单" ShowBorder="true" ShowHeader="false"  >
                        <Rows>
                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                  <f:TextBox runat="server" Label="厂商编号" ID="SUP_ID" Required="true" ShowRedStar="true" Width="250px"></f:TextBox>
                                  <f:TextBox runat="server" Label="厂商名称" ID="SUP_NAME" ShowRedStar="true" Width="250px"></f:TextBox>
                                  <f:TextBox runat="server" Label="厂商简称" ID="SUP_NICKNAME" Width="250px"></f:TextBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                  <f:DropDownList ID="SUP_TYPE" Label="厂商类型" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                        <f:ListItem Text="一般厂商" Value="1" Selected="true"  />
                                        <f:ListItem Text="委托加工厂商" Value="2" />
                                  </f:DropDownList>
                                  <f:TextBox runat="server" Label="厂商地址" ID="SUP_ADD" ShowRedStar="true" Width="250px"></f:TextBox>
                                  <f:TextBox runat="server" Label="厂商电话" ID="SUP_TEL" Width="250px"></f:TextBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                  <f:TextBox runat="server" Label="厂商邮箱" ID="SUP_Email" Width="250px"></f:TextBox>
                                  <f:TextBox runat="server" Label="邮政编码" ID="SUP_ZIP" Width="250px"></f:TextBox>
                                  <f:TextBox runat="server" Label="厂商联系人" ID="SUP_Contact" Width="250px"></f:TextBox>
                                  <f:TextBox runat="server" Label="联系人手机" ID="SUP_Mobile" Width="250px"></f:TextBox>
                                </Items>
                            </f:FormRow>
                             <f:FormRow ColumnWidths="300px">
                                <Items>
                                  <f:TextBox runat="server" Label="统一社会信用代码" ID="SUP_CODE_ID" Width="250px"></f:TextBox>
                                  <f:TextBox runat="server" Label="银行名称" ID="SUP_BankName" Width="250px"></f:TextBox>
                                  <f:TextBox runat="server" Label="银行账户号码" ID="SUP_BankID" Width="250px"></f:TextBox>
                                  <f:TextBox runat="server" Label="厂商登陆账户密码" ID="SUP_PASSWORD" Width="250px" TextMode="Password"></f:TextBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ColumnWidths="300px">
                                <Items>
                                  <f:NumberBox ID="Send_DAY" runat="server" EmptyText="0" Label="送货周期(单位天)" Width="200px" Text=1
                                            NoDecimal="true" NoNegative="True">
                                  </f:NumberBox>
                                  <f:HiddenField runat="server" ID="hidId" Text="0"></f:HiddenField>
                                </Items>
                            </f:FormRow>
                        </Rows>
                    </f:Form>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    </form>
</body>
</html>
