<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SupplyCenter.OrdersEdit" %>

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

    <link href="../../../res/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <f:Pagemanager id="PageManager1" runat="server" />
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
                            
                            <f:Form ID="Form5" runat="server" Width="780px" LabelWidth="100px" BodyPadding="5px" LabelAlign="Right" Title="表单" ShowBorder="false" ShowHeader="false"  >
                                    <Rows>
                                    <f:FormRow ColumnWidths="300px">
                                        <Items>
                                            <f:TextBox runat="server" Label="分店编号" ID="txtSHOP_ID" ShowRedStar="true" Width="250px"  Readonly="true"></f:TextBox>
                                            <f:DropDownList runat="server" AutoPostBack="true" Required="true" OnSelectedIndexChanged="ddlShop_SelectedIndexChanged" Label="分店名称" ID="ddlShop" Width="250px"></f:DropDownList>
                                            <f:DropDownList runat="server" Label="状态" ID="ddlStatus" Width="250px">
                                                <f:ListItem  Text="无" Value="0"/>
                                                <f:ListItem  Text="存档" Value="1"/>
                                                <f:ListItem  Text="核准" Value="2"/>
                                                <f:ListItem  Text="作废" Value="3"/>
                                                <f:ListItem  Text="已汇整" Value="4"/>
                                            </f:DropDownList>
                                              
                                        </Items>
                                    </f:FormRow>
                                    <f:FormRow ColumnWidths="300px">
                                        <Items>
                                            <%--<f:TextBox runat="server" Label="订单编号" ID="txtORDER_ID" ShowRedStar="true" Width="250px"></f:TextBox>--%>
                                                        
                                            <f:DatePicker runat="server" Required="true" Label="申请日期" DateFormatString="yyyy-MM-dd" ID="txtINPUT_DATE" Readonly="true" ShowRedStar="True" Width="250px" ></f:DatePicker>
                                                <f:TextBox runat="server" Label="负责人员" ID="txtManage" ShowRedStar="true" Width="250px"></f:TextBox>
   
                                                <f:DropDownList runat="server" AutoPostBack="true" Required="true"  Label="订单类型" ID="ddlORD_TYPE" Width="250px">
                                                             
                                                <f:ListItem  Text="普通订货" Value="1"/>
                                                <f:ListItem  Text="客户订货" Value="2"/>
                                            </f:DropDownList>
                                                        
                                                        
                                        </Items>
                                    </f:FormRow >
                                        <f:FormRow ColumnWidths="300px">
                                        <Items>
                                            <f:DatePicker runat="server" Required="true" Label="期望日期" DateFormatString="yyyy-MM-dd" ID="ddlEXPECT_DATE" Readonly="true" ShowRedStar="True" Width="250px" ></f:DatePicker>
                                            <f:DropDownList runat="server" Required="true" Label="供货分店" ID="ddlOUT_SHOP" Width="250px"></f:DropDownList>
                                            <f:DropDownList runat="server" Required="true" Label="订货部门" ID="ddlBranch" Width="250px"></f:DropDownList>

                                                         
                                        </Items>
                                 
                                    </f:FormRow>
                                    <f:FormRow ColumnWidths="300px">
                                        <Items>
                                            <f:TextBox runat="server" Label="汇出单据" ID="txtEXPORTED_ID" ShowRedStar="true" Width="250px"></f:TextBox>
                                                       
                                            <f:CheckBox runat="server" Label="月结锁定" ID="cbLOCKED" ShowRedStar="true" Width="250px" Checked="true" />
                                            <f:TextBox runat="server" Label="备注" ID="txtMemo" ShowRedStar="true" Width="250px"></f:TextBox>
                                                       
                                        </Items>
                                                
                                    </f:FormRow>
                                    <f:FormRow ColumnWidths="300px">
                                        <Items>
                                            <f:TextBox runat="server" Label="建档日期" ID="txtCRT_DATETIME" ShowRedStar="true" Width="250px"></f:TextBox>
                                            <f:TextBox runat="server" Label="核准日期" ID="txtAPP_DATE" ShowRedStar="true" Width="250px"></f:TextBox>
                                            <f:TextBox runat="server" Label="最后异动时间" ID="txtLAST_UPDATE" ShowRedStar="true" Width="250px"></f:TextBox>
                                           
                                        </Items>
                                    </f:FormRow>
                                    <f:FormRow ColumnWidths="300px">
                                        <Items>
                                            <f:TextBox runat="server" Label="建档人员" ID="txtCRT_USER_ID" ShowRedStar="true" Width="250px"></f:TextBox>
                                            <f:TextBox runat="server" Label="制单人员" ID="txtORD_USER" ShowRedStar="true" Width="250px"></f:TextBox>
                                            <f:TextBox runat="server" Label="核准人员" ID="txtAPP_USER" ShowRedStar="true" Width="250px"></f:TextBox>
                                                         
                                        </Items>
                                                
                                    </f:FormRow>
                                    <f:FormRow ColumnWidths="300px">
                                        <Items>
                                            <f:TextBox runat="server" Label="订单编号" ID="txtORDER_ID" ShowRedStar="true" Width="250px"></f:TextBox>
                                            <f:TextBox runat="server" Label="汇出标记" ID="txtEXPORTED" ShowRedStar="true" Width="250px"></f:TextBox>
                                                <f:TextBox runat="server" Label="传输状态" ID="txtTrans_STATUS" ShowRedStar="true" Width="250px"></f:TextBox>
                                        </Items>
                                    </f:FormRow>
                                    <f:FormRow ColumnWidths="300px">
                                            <Items>
                                            <f:TextBox runat="server" Label="修改日期" ID="txtMOD_DATETIME" ShowRedStar="true" Width="250px"></f:TextBox>
                                            <f:TextBox runat="server" Label="修改人员" ID="txtMOD_USER_ID" ShowRedStar="true" Width="250px"></f:TextBox>
                                                        
                                                       
                                            </Items>
                                    </f:FormRow>

                            </Rows>
                            </f:Form>
                         
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
