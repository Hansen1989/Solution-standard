﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>零售供应链采购管理平台</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="Css/login.css" />
    <script type="text/javascript">
        function Random(n) { return (Math.floor(Math.random() * n)); };

        function AjaxRnd() { return new Date().getTime() + '' + Random(10000); };

        function ShowKey() {
            document.getElementById("img_verifycode").src = "Application/Vcode.ashx?a=" + AjaxRnd();
        };
    </script>
</head>
<body>
    <!--CENTER开始-->
    <div class="login-container">
        <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server">
                </f:PageManager>
        <div class="login-header">
            <h3>
                采购供应链管理平台</h3>
        </div>
        <div id="login-content" class="clearfix">
            <div style="float:left; height:230px; width:345px;">
              <img src="Css/loginback.jpg" height="230px;" style="border-radius: 5px"/>
            </div>
            <div style="float:right; width:245px; height:230px;">
                
                <label>
                    用户名</label>
                <div>
                    <asp:TextBox runat="server" ID="txtusername" CssClass="input w92" />
                </div>
                <label>
                    密码</label>
                <div>
                    <asp:TextBox runat="server" ID="txtpass" CssClass="input w92" TextMode="Password" />
                </div>
                <%--<label>
                    验证码</label>--%>
                <%--<div>
                    <asp:TextBox runat="server" ID="txtcode" CssClass="input w100 fl" />
                    <asp:Image ID="img_verifycode" runat="server" onclick="ShowKey();" ToolTip="更换验证码"
                        ImageUrl="Application/Vcode.ashx" />
                    <div class="fc"></div>
                </div>--%>
                <div >
                  <asp:Button ID="BtnLogin" CssClass="btn" runat="server" OnClick="BtnLogin_Click"
                    Text="登陆" />
                </div>
                
            </div>
            <div>
                
            </div>
        </div>
        </form>
    </div>
    <!--CENTER结束-->
</body>
</html>
