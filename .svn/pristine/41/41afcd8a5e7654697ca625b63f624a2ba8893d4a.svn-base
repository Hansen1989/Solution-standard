<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product01Edit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.DataCenter.Product01Edit" %>

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
                    <f:Button ID="ButtonSave" runat="server" Text="保存" ValidateForms="SimpleForm1" Icon="Disk" OnClick="ButtonSave_Click" ></f:Button>
                    <f:Button ID="ButtonCancel" runat="server" Text="取消" Icon="Cancel" ></f:Button>
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:Panel ID="Panel2" Layout="HBox" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" ShowHeader="true" ShowBorder="False" Title="商品设定">
                <Items>
                    <f:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" 
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                           <f:Form ID="Form5" LabelAlign="left"  BodyPadding="5px" LabelWidth="100px" 
                            runat="server" Title="表单" ShowBorder="true" ShowHeader="false"  >
                                <Rows>
                                    <f:FormRow ColumnWidths="300px">
                                    <Items>
                                        <f:DropDownList ID="PRCAREA_ID" Label="价格区编号" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                        </f:DropDownList>
                                        <f:TextBox runat="server" Label="商品名称" Enabled="false" ID="PROD_NAME" Required="true" ShowRedStar="true" Width="250px" EmptyText="商品名称" ></f:TextBox>
                                        <f:DropDownList ID="SUP_ID" Label="厂商编号" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                        </f:DropDownList>
                                    </Items>
                                    </f:FormRow>
                                    <f:FormRow>
                                    <Items>
                                        <f:DropDownList ID="SEND_TYPE" Label="厂商送货方式" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="直送总部" Value="1" Selected="true"  />
                                            <f:ListItem Text="直送门市" Value="2" />
                                        </f:DropDownList>
                                        <f:DropDownList ID="TAX_TYPE" Label="税别" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="不含税" Value="0" Selected="true"  />
                                            <f:ListItem Text="内含税" Value="1" />
                                            <f:ListItem Text="外含税" Value="2" />
                                        </f:DropDownList>
                                        <f:NumberBox ID="Tax" runat="server" EmptyText="税率" Label="税率" Text="0"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                    </Items>
                                    </f:FormRow>
                                    <f:FormRow>
                                    <Items>
                                        <f:NumberBox ID="SUP_COST" runat="server" Label="厂商进价(最小单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:NumberBox ID="SUP_COST1" runat="server" Label="厂商进价(包装单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:NumberBox ID="SUP_COST2" runat="server" Label="厂商进价(外箱单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                        <f:NumberBox ID="SUP_Return" runat="server" Label="厂商退货价(最小单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:NumberBox ID="SUP_Return1" runat="server" Label="厂商退货价(包装单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:NumberBox ID="SUP_Return2" runat="server" Label="厂商退货价(外箱单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                        <f:NumberBox ID="U_Cost" runat="server" Label="直营店进价(最小单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:NumberBox ID="U_Cost1" runat="server" Label="直营店进价(包装单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:NumberBox ID="U_Cost2" runat="server" Label="直营店进价(外箱单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                        <f:NumberBox ID="U_Ret_COST" runat="server" Label="直营店退货价(最小单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:NumberBox ID="U_Ret_COST1" runat="server" Label="直营店退货价(包装单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:NumberBox ID="U_Ret_COST2" runat="server" Label="直营店退货价(外箱单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                        <f:NumberBox ID="T_COST" runat="server" Label="加盟店进价(最小单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:NumberBox ID="T_COST1" runat="server" Label="加盟店进价(包装单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:NumberBox ID="T_COST2" runat="server" Label="加盟店进价(外箱单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                        <f:NumberBox ID="T_Ret_COST" runat="server" Label="加盟店退货价(最小单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:NumberBox ID="T_Ret_COST1" runat="server" Label="加盟店退货价(包装单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:NumberBox ID="T_Ret_COST2" runat="server" Label="加盟店退货价(外箱单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                        <f:NumberBox ID="COST" runat="server" Label="商品成本价(最小单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:NumberBox ID="COST1" runat="server" Label="商品成本价(包装单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:NumberBox ID="COST2" runat="server" Label="商品成本价(外箱单位进价)" Text="0.000000"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                        <Items>
                                           <f:RadioButtonList ID="ENABLE" Label="是否有效" ColumnNumber="3" runat="server"
                                                ShowRedStar="true" Required="true" Width="300px">
                                                <f:RadioItem Text="无效" Value="0" />
                                                <f:RadioItem Text="有效" Value="1" Selected="true" />
                                           </f:RadioButtonList>
                                           <f:RadioButtonList ID="VISIBLE" Label="是否可见" ColumnNumber="3" runat="server"
                                                ShowRedStar="true" Required="true" Width="300px">
                                                <f:RadioItem Text="不可见" Value="0" />
                                                <f:RadioItem Text="可见" Value="1" Selected="true" />
                                           </f:RadioButtonList>
                                        </Items>
                                    </f:FormRow>

                                    <f:FormRow ColumnWidths="300px">
                                    <Items>
                                        <f:DropDownList ID="BOM_ID" Label="使用配方编码" AutoPostBack="true" CompareType="String" EnableEdit="true"
                                             EnableSimulateTree="true" runat="server" Width="250px" >
                                        </f:DropDownList>

                                        <f:Panel ID="Panel3" runat="server" Width="320px" Title="配方编码查询" EnableFrame="false" BodyPadding="10px" EnableCollapse="True" CssStyle="display:none" >
                                        <Items>
                                            <f:TextBox runat="server" Label="配方编码" ID="COM_ID2" EmptyText="商品编码"></f:TextBox>
                                            <f:TextBox runat="server" Label="配方名称" ID="COM_NAME2" EmptyText="商品名称"></f:TextBox>
                                            <f:Button ID="Button1" runat="server" Text="查询" Icon="Magnifier"></f:Button>
                                        </Items>
                                        <Items>
                                          <f:DropDownList ID="COM" Label="配方选择" AutoPostBack="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="300px" >
                                          </f:DropDownList>
                                          <f:Button ID="Button2" runat="server" Text="确定" Icon="UserGo"></f:Button>
                                        </Items>
                                        </f:Panel>
                                        <f:HiddenField runat="server" ID="hidId" Text="0"></f:HiddenField>
                                        <f:HiddenField runat="server" ID="hidPROD_ID" Text="0"></f:HiddenField>
                                    </Items>
                                    </f:FormRow>
                                    <f:FormRow>
                                    <Items>

                                    </Items>
                                    </f:FormRow>
                                    </Rows>
                            </f:Form>
                        </Items>
                    </f:SimpleForm>
                </Items>
            </f:Panel>
        </Items>
    </f:Panel>
    </form>
</body>
</html>
