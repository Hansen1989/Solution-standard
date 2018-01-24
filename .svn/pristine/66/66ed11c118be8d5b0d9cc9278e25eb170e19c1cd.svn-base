<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionWarehousingEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.ProductionCenter.ProductionWarehousingEdit" %>

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
                         
                            <f:TextBox runat="server" ID="txtSHOP_ID" ShowRedStar="true" Width="250px" Label="分店编号" />
                            <f:TextBox runat="server" ID="txtTAKEIN_ID" ShowRedStar="true" Width="250px" Label="计划单号" />
                            <f:TextBox runat="server" ID="txtSTATUS" ShowRedStar="true" Width="250px" Label="单据状态" />
                            <f:TextBox runat="server" ID="txtINPUT_DATE" ShowRedStar="true" Width="250px" Label="单据日期" />
                            <f:TextBox runat="server" ID="txtSTOCK_ID" ShowRedStar="true" Width="250px" Label="仓库编号" />
                            <f:TextBox runat="server" ID="txtUSER_ID" ShowRedStar="true" Width="250px" Label="制单人" />
                            <f:TextBox runat="server" ID="txtAPP_USER" ShowRedStar="true" Width="250px" Label="审核人" />
                            <f:TextBox runat="server" ID="txtAPP_DATETIME" ShowRedStar="true" Width="250px" Label="审核时间" />
                           
                            <f:TextBox runat="server" ID="txtRELATE_ID" ShowRedStar="true" Width="250px" Label="关联单号" />
                            <f:TextBox runat="server" ID="txtMemo" ShowRedStar="true" Width="250px" Label="备注" />

                            <f:TextBox runat="server" ID="txtLOCKED" ShowRedStar="true" Width="250px" Label="月结锁定" />
                            <f:TextBox runat="server" ID="txtCRT_DATETIME" ShowRedStar="true" Width="250px" Label="建档日期" />
                            <f:TextBox runat="server" ID="txtCRT_USER_ID" ShowRedStar="true" Width="250px" Label="建档人员" />
                            <f:TextBox runat="server" ID="txtMOD_DATETIME" ShowRedStar="true" Width="250px" Label="修改日期" />
                            <f:TextBox runat="server" ID="txtMOD_USER_ID" ShowRedStar="true" Width="250px" Label="修改人员" />
                            <f:TextBox runat="server" ID="txtLAST_UPDATE" ShowRedStar="true" Width="250px" Label="最后异动时间" />
                            <f:TextBox runat="server" ID="txtTrans_STATUS" ShowRedStar="true" Width="250px" Label="传输状态" />




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

