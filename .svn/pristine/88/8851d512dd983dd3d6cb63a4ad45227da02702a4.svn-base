<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product00Edit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.DataCenter.Product00Edit" %>

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
            <f:Panel ID="Panel2" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" ShowHeader="true" ShowBorder="False" Title="商品资料">
                <Items>
                    <f:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                           <f:Form ID="Form5" LabelAlign="Right"  BodyPadding="5px" LabelWidth="100px" 
                            runat="server" Title="表单" ShowBorder="true" ShowHeader="false"  >
                                <Rows>
                                    <f:FormRow ColumnWidths="300px">
                                    <Items>
                                        <f:TextBox runat="server" Label="商品编号" ID="PROD_ID" Required="true" ShowRedStar="true" Width="250px" EmptyText="商品编号"></f:TextBox>
                                        <f:TextBox runat="server" Label="商品名称1" ID="PROD_NAME1" Required="true" ShowRedStar="true" Width="250px" EmptyText="商品名称1" ></f:TextBox>
                                        <f:TextBox runat="server" Label="商品名称2" ID="PROD_NAME2" Required="true" Width="250px" EmptyText="商品名称2" ></f:TextBox>
                                    </Items>
                                    </f:FormRow>
                                    <f:FormRow>
                                    <Items>
                                        <f:DropDownList ID="PROD_KIND" Label="商品性质" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                        </f:DropDownList>
                                        <f:DropDownList ID="PROD_DEP" Label="商品类别" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                        </f:DropDownList>
                                        <f:DropDownList ID="PROD_CATE" Label="商品小类" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" >
                                        </f:DropDownList>
                                    </Items>
                                    </f:FormRow>
                                    <f:FormRow>
                                    <Items>
                                        <f:DropDownList ID="DIV_ID" Label="隶属部门" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" >
                                        </f:DropDownList>
                                        <f:DropDownList ID="PROD_TYPE" Label="商品属性" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="自产类" Value="0" Selected="true"  />
                                            <f:ListItem Text="供应类" Value="1" />
                                            <f:ListItem Text="委托加工类" Value="2" />
                                        </f:DropDownList>
                                        <f:DropDownList ID="PROD_Source" Label="商品来源" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="总部" Value="0" Selected="true" />
                                            <f:ListItem Text="分店" Value="1" />
                                        </f:DropDownList>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                        <f:DropDownList ID="INV_TYPE" Label="盘点类型" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="不盘" Value="0" />
                                            <f:ListItem Text="日盘" Value="1" />
                                            <f:ListItem Text="周盘" Value="2" />
                                            <f:ListItem Text="月盘" Value="3" Selected="true"  />
                                            <f:ListItem Text="全盘" Value="4" />
                                        </f:DropDownList>
                                        <f:DropDownList ID="STOCK_TYPE" Label="库存属性" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="不扣除" Value="0" />
                                            <f:ListItem Text="扣自身" Value="1" Selected="true" />
                                            <f:ListItem Text="扣配方" Value="2" />                                
                                        </f:DropDownList>
                                        <f:DropDownList ID="BOM_TYPE" Label="配方层次" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="依配方层次拆解" Value="1" />
                                            <f:ListItem Text="依配方资料拆解" Value="2" />
                                        </f:DropDownList>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                        <f:DropDownList ID="MarginControl" Label="余量控制" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="大缸生产" Value="1" Selected="true" />
                                            <f:ListItem Text="余量生成" Value="2" />
                                        </f:DropDownList>
                                        <f:DropDownList ID="PROD_RangTYPE" Label="称重误差" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="百分比" Value="1" Selected="true" />
                                            <f:ListItem Text="固定数值" Value="2" />
                                        </f:DropDownList>
                                        <f:NumberBox ID="PROD_iRang" runat="server" EmptyText="最小单位数值，不能负数。" Label="称重误差数值" Text="0"
                                            MaxValue="10000000" MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                        <f:TextBox runat="server" Label="商品规格" ID="PROD_SPEC" Width="250px" EmptyText="商品规格"></f:TextBox>
                                        <f:TextBox runat="server" Label="产地" ID="PROD_Margin" Width="250px" EmptyText="产地"></f:TextBox>
                                        <f:TextBox runat="server" Label="条码" ID="PROD_BARCODE" Width="250px" EmptyText="条码"></f:TextBox>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                        <f:DropDownList ID="PROD_UNIT" Label="最小单位" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
                                        </f:DropDownList>
                                        <f:NumberBox ID="PROD_CONVERT1" runat="server" EmptyText="0" Label="包装设定" Width="200px"
                                            NoDecimal="true" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:Label ID="PROD_UNIT_SHOW" Text="个" runat="server">
                                        </f:Label>
                                        <f:Label ID="Label1" Text="= 1 " runat="server">
                                        </f:Label>
                                        <f:DropDownList ID="PROD_UNIT1" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="100px" ShowRedStar="true">
                                        </f:DropDownList>
                                        <f:NumberBox ID="PROD_CONVERT2" runat="server" EmptyText="0" Label="外箱设定"  Width="200px"
                                             NoDecimal="true" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:Label ID="PROD_UNIT_SHOW2" Text="个" runat="server">
                                        </f:Label>
                                        <f:Label ID="Label3" Text="= 1 " runat="server">
                                        </f:Label>
                                        <f:DropDownList ID="PROD_UNIT2" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="100px" ShowRedStar="true">
                                        </f:DropDownList>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                        <f:DropDownList ID="Report_UNIT" Label="报表单位" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="最小单位" Value="1" Selected="true" />
                                            <f:ListItem Text="包装单位" Value="2" />
                                            <f:ListItem Text="外箱单位" Value="3" />
                                        </f:DropDownList>
                                        <f:DropDownList ID="Order_UNIT" Label="订货单位" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="最小单位" Value="1" Selected="true" />
                                            <f:ListItem Text="包装单位" Value="2" />
                                            <f:ListItem Text="外箱单位" Value="3" />
                                        </f:DropDownList>
                                        <f:NumberBox ID="Order_QUAN" runat="server" EmptyText="0" Label="最少订货量"  Width="200px"
                                             NoDecimal="true" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                        <f:DropDownList ID="Purchase_UNIT" Label="采购单位" AutoPostBack="true" Required="true" CompareType="String"
                                             EnableSimulateTree="true" runat="server" Width="250px" ShowRedStar="true">
                                            <f:ListItem Text="最小单位" Value="1" Selected="true" />
                                            <f:ListItem Text="包装单位" Value="2" />
                                            <f:ListItem Text="外箱单位" Value="3" />
                                        </f:DropDownList>
                                        <f:NumberBox ID="Purchase_QUAN" runat="server" EmptyText="0" Label="最少采购量"  Width="200px"
                                             NoDecimal="true" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                        <f:NumberBox ID="SAFE_QUAN" runat="server" EmptyText="0" Label="库存安全量"  Width="200px"
                                             NoDecimal="true" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                                        </f:NumberBox>
                                    </Items>
                                    </f:FormRow>

                                    <f:FormRow>
                                    <Items>
                                        <f:TextBox runat="server" Label="备注" ID="PROD_MEMO" Width="500px" EmptyText="备注"></f:TextBox>
                                        <f:HiddenField runat="server" ID="hidId" Text="0"></f:HiddenField>
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
