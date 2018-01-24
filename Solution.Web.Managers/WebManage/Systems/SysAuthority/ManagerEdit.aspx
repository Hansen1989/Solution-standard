<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SysAuthority.ManagerEdit" %>

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
                            <f:TextBox runat="server" Label="登录名" ID="txtLoginName" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="密码" ID="txtPwd" ShowRedStar="true" Width="250px" TextMode="Password"></f:TextBox>
                            <f:DropDownList Label="门店" AutoPostBack="true" Required="true" CompareType="String"
                               runat="server" ID="SHOPdll" Width="250px"
                               >
                            </f:DropDownList>

                            <f:RadioButtonList ID="rblIsMultiUser" Label="是否允许同时在线" ColumnNumber="3" runat="server"
                                ShowRedStar="true" Required="true">
                                <f:RadioItem Text="是" Value="1"  />
                                <f:RadioItem Text="否" Value="0" Selected="true"/>
                            </f:RadioButtonList>

                             <f:DropDownList Label="部门" AutoPostBack="true" Required="true" CompareType="String"
                                runat="server" ID="Brachddl" Width="250px"
                                OnSelectedIndexChanged="Brachddl_SelectedIndexChanged">
                            </f:DropDownList>
                            
                            
                            <f:DropDownList Label="职位" AutoPostBack="true" Required="true" CompareType="String"
                                EnableSimulateTree="true" runat="server" ID="Positionddl" Width="250px"
                                OnSelectedIndexChanged="Positionddl_SelectedIndexChanged">
                            </f:DropDownList>

                            <f:RadioButtonList ID="rblIsWork" Label="是否在职" ColumnNumber="3" runat="server"
                                ShowRedStar="true" Required="true">
                                <f:RadioItem Text="是" Value="1"  Selected="true"/>
                                <f:RadioItem Text="否" Value="0" />
                            </f:RadioButtonList>

                            <f:RadioButtonList ID="rblIsEnable" Label="账号是否启用" ColumnNumber="3" runat="server"
                                ShowRedStar="true" Required="true">
                                <f:RadioItem Text="是" Value="1"  Selected="true"/>
                                <f:RadioItem Text="否" Value="0" />
                            </f:RadioButtonList>


                            <f:TextBox runat="server" Label="中文名" ID="txtCName" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="英文名" ID="txtEName" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="照片" ID="txtPhoto" ShowRedStar="true" Width="250px"></f:TextBox>
                            
                            <f:RadioButtonList ID="rblSex" Label="性别" ColumnNumber="3" runat="server"
                                ShowRedStar="true" Required="true">
                                <f:RadioItem Text="男" Value="0"  Selected="true"/>
                                <f:RadioItem Text="女" Value="1" />
                            </f:RadioButtonList>

                            <f:DatePicker runat="server" Required="true" Label="生日" DateFormatString="yyyy-MM-dd" ID="Birthday" ShowRedStar="True" ></f:DatePicker>

                            <f:TextBox runat="server" Label="籍贯" ID="txtNativePlace" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="民族" ID="txtNationalName" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="学历" ID="txtRecord" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="毕业学校" ID="txtGraduateCollege" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="毕业专业" ID="txtGraduateSpecialty" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="座机" ID="txtTel" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="手机" ID="txtMobile" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="邮件" ID="txtEmail" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="QQ" ID="txtQq" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="住址" ID="txtAddress" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="备注" ID="txtContent" ShowRedStar="true" Width="250px"></f:TextBox>
                        
                            
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
