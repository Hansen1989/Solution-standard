<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArchiveOrdersEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SupplyCenter.ArchiveOrdersEdit" %>

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

                            <f:TextBox runat="server" Label="申请分店编号" ID="txtSHOP_ID" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="汇整单号" ID="txtCOL_ID" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="单据日期" ID="txtINPUT_DATE" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="制单人员" ID="txtORD_USER" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="期望日期" ID="txtEXPECT_DATE" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="单据状态" ID="txtSTATUS" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="产品类型" ID="txtPROD_TYPE" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="订单类型" ID="txtORD_TYPE" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="订货部门" ID="txtORD_DEP_ID" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="汇整起始日期" ID="txtCOL_BeginDate" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="汇整结束日期" ID="txtCOL_EndDate" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="核准人员" ID="txtAPP_USER" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="核准日期" ID="txtAPP_DATE" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="备注" ID="txtMemo" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="月结锁定" ID="txtLOCKED" ShowRedStar="true" Width="250px"></f:TextBox>

                           
                            <f:TextBox runat="server" Label="建档日期" ID="txtCRT_DATETIME" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="建档人员" ID="txtCRT_USER_ID" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="修改日期" ID="txtMOD_DATETIME" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="修改人员" ID="txtMOD_USER_ID" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="最后异动时间" ID="txtLAST_UPDATE" ShowRedStar="true" Width="250px"></f:TextBox>
                            <f:TextBox runat="server" Label="传输状态" ID="txtTrans_STATUS" ShowRedStar="true" Width="250px"></f:TextBox>
                             

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
