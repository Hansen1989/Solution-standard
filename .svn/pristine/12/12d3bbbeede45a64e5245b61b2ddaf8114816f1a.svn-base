<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersEditPro.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SupplyCenter.OrdersEditPro" %>

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
     <script src="../../Js/json2.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <f:Pagemanager id="PageManager1" runat="server" />
    <f:Panel ID="Panel1" runat="server" EnableFrame="false" BodyPadding="10px" EnableCollapse="True" ShowHeader="False">
        <Toolbars>
            <f:Toolbar ID="toolBar" runat="server">
                <Items>
                     <f:Button ID="Button1" runat="server" Text="新增" Icon="Disk" ></f:Button>
                     <f:Button ID="Button3" runat="server" Text="核定" Icon="Disk" ></f:Button>
                    <%--<f:Button ID="ButtonApproved" runat="server" Text="核准" Icon="Disk" OnClick="ButtonApproved_Click"></f:Button>--%>
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
            <f:Panel ID="Panel3" runat="server" EnableFrame="false" BodyPadding="5px" EnableCollapse="True" ShowHeader="False" ShowBorder="False">
                <Items>
          
                <%--<f:Grid ID="Grid1" Title="商品信息" EnableFrame="false" EnableCollapse="true" AllowSorting="true" SortField="Depth" SortDirection="ASC" 
            PageSize="15" ShowBorder="true" ShowHeader="true" AllowPaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id" EnableColumnLines="true" AllowCellEditing="true" ClicksToEdit="2" OnPreDataBound="Grid1_PreDataBound" 
            DataIDField="Id">--%>
             <f:Grid ID="Grid1" Title="表格" ShowBorder="false" ShowHeader="false" EnableCollapse="true" Width="850px"
            runat="server" DataKeyNames="SNo" AllowCellEditing="true" ClicksToEdit="1" OnPreDataBound="Grid1_PreDataBound" 
            DataIDField="SNo">   <%-- OnPreRowDataBound="Grid1_PreRowDataBound" --%>
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnNew" Text="新增" Icon="Add" EnablePostBack="false" runat="server">
                        </f:Button>
                        <f:Button ID="btnDelete" Text="删除" Icon="Delete" EnablePostBack="false" runat="server">
                        </f:Button>
                        <f:ToolbarFill ID="ToolbarFill1" runat="server">
                        </f:ToolbarFill>
                        <f:Button ID="btnReset" Text="重置表格数据" EnablePostBack="false" runat="server">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
               <%-- <f:TemplateField ColumnID="Number" Width="60px">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>--%>

                <f:TemplateField ColumnID="SNo" Width="60px" HeaderText="序号">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("SNo") %>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>

                <f:RenderField Width="100px" ColumnID="PROD_NAME1" DataField="PROD_NAME1"
                    HeaderText="商品名称">
                    <Editor>
                        <f:DropDownList ID="DropDownList1"  runat="server">
                        </f:DropDownList>
                    </Editor>
                </f:RenderField>

                <f:RenderField Width="100px" ColumnID="PROD_ID" DataField="PROD_ID" FieldType="String"
                    HeaderText="商品编号">
                    <Editor>
                        <f:TextBox ID="tbxPROD_ID" runat="server">
                        </f:TextBox>
                    </Editor>
                </f:RenderField>

               <%--<f:TemplateField HeaderText="商品名称">
                        <ItemTemplate>
                            <asp:DropDownList runat="server" ID="DropDownList1">
                            </asp:DropDownList>
                        </ItemTemplate>
               </f:TemplateField>--%>

                 

                
                <f:RenderField Width="100px" ColumnID="PROD_SPEC" DataField="PROD_SPEC" FieldType="String"
                    ExpandUnusedSpace="true" HeaderText="产品规格">
                    <Editor>
                        <f:TextBox ID="tbxPROD_SPEC" Required="true" runat="server">
                        </f:TextBox>
                    </Editor>
                </f:RenderField>
                <f:RenderField Width="100px" ColumnID="PROD_UNIT" DataField="PROD_UNIT" 
                    HeaderText="单位">  <%--FieldType="Int" NoDecimal="true" NoNegative="true" --%>
                    <Editor>
                        <f:NumberBox ID="txtPROD_UNIT" Required="true" runat="server">
                        </f:NumberBox>
                    </Editor>
                </f:RenderField>
                <f:RenderField Width="100px" ColumnID="ON_QUAN" DataField="ON_QUAN" FieldType="Int"
                    HeaderText="订货量">
                    <Editor>
                        <f:NumberBox ID="txtON_QUAN" NoDecimal="true" NoNegative="true" Required="true" runat="server">
                        </f:NumberBox>
                    </Editor>
                </f:RenderField>
                <f:RenderField Width="100px" ColumnID="COST" DataField="COST" 
                    HeaderText="单价"> <%--FieldType="Int"--%>
                    <Editor>
                        <f:NumberBox ID="txtCOST" NoDecimal="false" NoNegative="true" Required="true" runat="server">
                        </f:NumberBox>
                    </Editor>
                </f:RenderField>
                <f:RenderField Width="100px" ColumnID="QUAN1" DataField="QUAN1" FieldType="Int"
                    HeaderText="小计">
                    <Editor>
                        <f:NumberBox ID="txtQUAN1" NoDecimal="false" NoNegative="true" Required="true" runat="server">
                        </f:NumberBox>
                    </Editor>
                </f:RenderField>
                <f:LinkButtonField ColumnID="Delete" Width="80px" EnablePostBack="false"
                    Icon="Delete" />
            </Columns>
            <Listeners>
                <f:Listener Event="edit" Handler="onGridAfterEdit" />
            </Listeners>
        </f:Grid>
 
        <f:Button ID="Button2" runat="server" Text="保存数据" OnClick="Button2_Click">
        </f:Button>
   
      
    <f:Label ID="labResult" EncodeText="false" runat="server">
    </f:Label>


    </Items>
   </f:Panel>
        </Items>
        </f:Panel>
    </form>
    <script type="text/javascript">
        function renderGender(value) {
            return value == 1 ? '男' : '女';
        }

        // 注意：专业版中改事件名为：afteredit，开源版中为：edit
        function onGridAfterEdit(editor, params) {
            var me = this, columnId = params.column.id, rowId = params.record.getId();

            if (columnId === 'ON_QUAN' || columnId === 'COST') {
                var chineseScore = me.f_getCellValue(rowId, 'ON_QUAN');
                var mathScore = me.f_getCellValue(rowId, 'COST');
 
                me.f_updateCellValue(rowId, 'QUAN1', chineseScore * mathScore);
 
            }

            if (columnId === "PROD_NAME1") {
                var strvalue = me.f_getCellValue(rowId, 'PROD_NAME1');
                //  var ss = loadXMLDoc(strvalue);
               // var cc;
               // me.f_updateCellValue(rowId, 'PROD_ID', strvalue);

                var xmlhttp;
                if (window.XMLHttpRequest) {
                    //  IE7+, Firefox, Chrome, Opera, Safari 浏览器执行代码
                    xmlhttp = new XMLHttpRequest();
                }
                else {
                    // IE6, IE5 浏览器执行代码
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        var strResult = xmlhttp.responseText;
                        var obj = JSON.parse(strResult); ;

                        me.f_updateCellValue(rowId, 'PROD_NAME1', obj[0].PROD_NAME1);
                        me.f_updateCellValue(rowId, 'PROD_ID', obj[0].PROD_ID);
                        me.f_updateCellValue(rowId, 'PROD_SPEC', obj[0].PROD_SPEC);
                        me.f_updateCellValue(rowId, 'PROD_UNIT', obj[0].PROD_UNIT);
                        me.f_updateCellValue(rowId, 'ON_QUAN', 1);
                        me.f_updateCellValue(rowId, 'COST', obj[0].COST);

                        me.f_updateCellValue(rowId, 'QUAN1', obj[0].COST * 1);
                    }
                    else {
                        me.f_updateCellValue(rowId, 'PROD_NAME1', xmlhttp.responseText);
                        //return "失败了";
                    }
                }
                xmlhttp.open("GET", "OrdersListHandler.ashx?value=" + strvalue, true);
                xmlhttp.send();


            }
    
        }

        function loadXMLDoc(str) {
            var xmlhttp;
            if (window.XMLHttpRequest) {
                //  IE7+, Firefox, Chrome, Opera, Safari 浏览器执行代码
                xmlhttp = new XMLHttpRequest();
            }
            else {
                // IE6, IE5 浏览器执行代码
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    return xmlhttp.responseText;
                }
                else {
                    return "失败了";
                }
            }
            xmlhttp.open("GET", "OrdersListHandler.ashx?value=" + str, true);
            xmlhttp.send();
        }

    </script>

        


</body>
</html>
