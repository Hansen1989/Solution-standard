<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoresRequisition.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.StockCenter.StoresRequisition" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head2" runat="server">
    <title></title>
      <style type="text/css">
        .x-grid-item .x-grid-cell-SUP_QUAN0 {
            background-color:  #f8aba6;
            color: #fff;
        }

         .x-grid-item .x-grid-cell-SUP_QUAN1 {
            background-color: #f69c9f;
            color: #fff;
        }

         .x-grid-item .x-grid-cell-OUT_QUAN {
            background-color: #f58f98;
            color: #fff;
        }
 
        /*.x-grid-item .x-grid-cell-hlfMajor {
            background-color: #b200ff;
            color: #fff;
        }

        .x-grid-item .x-grid-cell-hlfMajor a,
        .x-grid-item .x-grid-cell-hlfMajor a:hover {
            color: #fff;
        }*/
    </style>

</head>
<body>
   <form id="form2" runat="server">
    <f:PageManager ID="PageManager2" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" ShowBorder="false" ShowHeader="false" Layout="Region">
            <Items>
                <f:Panel runat="server" ID="panelTopRegion" RegionPosition="Top" RegionSplit="true" EnableCollapse="false" Height="240px"
                    Title="顶部面板" ShowBorder="false" ShowHeader="false" BodyPadding="5px" AutoScroll="true">
                    <Items>
             <f:Grid ID="Grid1" Title="生产计划入库" EnableFrame="false" EnableCollapse="true" 
                 ShowBorder="false" ShowHeader="false" runat="server" EnableCheckBoxSelect="True" EnableColumnLines="true"
                 DataKeyNames="MA_ID"
                 EnableMultiSelect="false" EnableRowSelectEvent="true"  >  
                 <%--OnRowCommand="Grid1_RowCommand" OnPreRowDataBound="Grid1_PreRowDataBound" OnPageIndexChange="Grid1_PageIndexChange"--%>
                 <%--OnRowSelect="Grid1_RowSelect"--%>
               <%--OnRowCommand="Grid1_RowCommand" OnPreRowDataBound="Grid1_PreRowDataBound"--%>
                <toolbars>
                    <f:Toolbar ID="Toolbar2" runat="server"  >   <%--Position="Left"--%>
                       
                        <Items>
                          <f:Panel ID="Panel2" runat="server" ShowHeader="false" ShowBorder="false" Width="800px" BodyStyle="background-color:transparent;">
                            <Toolbars>
                               <f:Toolbar ID="toolBar3" runat="server" Width="800px"  >
                                   <Items>
                                       <f:Button ID="Button1" runat="server" Text="查询" Icon="Magnifier"  CssClass="btnf"></f:Button>
                                       <%-- <f:Button ID="ButtonArchiveOrders" runat="server" Text="汇整" Icon="Add" OnClick="ButtonArchiveOrders_Click" CssClass="inline btnf"></f:Button>
                                       <f:Button ID="ButtonBackArchiveOrders" runat="server" Text="反汇整" Icon="Delete" OnClick="ButtonBackArchiveOrders_Click" CssClass="inline btnf"></f:Button> --%>
                                       <f:Button ID="Button2" runat="server" Text="刷新" Icon="ArrowRefresh" CssClass="inline btnf"></f:Button>
                                        <%--<f:Button ID="ButtonAdd" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click" CssClass="btnf"></f:Button>--%>
                                        <f:Button ID="ButtonImport" runat="server" Text="引入" Icon="Add" OnClick="ButtonImport_Click" CssClass="btnf"></f:Button>
                                       <f:Button ID="ButtonApproval" runat="server" Text="核准" Icon="Disk" ConfirmTitle="核准提示" ConfirmText="是否核准此订单？" OnClick="ButtonApproval_Click" ></f:Button>
                                       <f:Button ID="ButtonBackApproval" runat="server" Text="反核准" Icon="Delete"  ></f:Button> 
                                     
                                        <f:Button ID="ButtonPrint" runat="server" Text="打印"  CssClass="btnf" Icon="Printer"
                                            OnClientClick="if(!F('Grid1').getSelectionModel().hasSelection()|| F('Grid1').getSelectionModel().getCount()>=2){F.alert('您没有选择编辑项或只能选择一项进行打印！'); return false; }">
                                       </f:Button> 
                                        <f:Button ID="Button3" runat="server" Text="自动排序" Icon="ArrowJoin" CssClass="btnf" ConfirmTitle="自动排序提示" ConfirmText="是否对所有数据进行自动排序？"></f:Button>
                                        <f:Button ID="Button4" runat="server" Text="保存排序" Icon="Disk" OnClick="ButtonSaveSort_Click" CssClass="btnf"></f:Button>
                                        <f:Button ID="Button5" runat="server" Text="删除" Icon="Delete" CssClass="btnf" ConfirmTitle="删除提示" ConfirmText="是否删除记录？" 
                                            OnClientClick="if (!F('Grid1').getSelectionModel().hasSelection() ) { F.alert('删除时必须选择一条将要删除的记录！'); return false; }  if (F('Grid1').getSelectionModel().getCount() >= 2) { F.alert('只能选择一条记录进行删除！');return false; }">
                                        </f:Button>
 
                                   </Items>
                               
                               </f:Toolbar>
                            </Toolbars>
                             
                          
                            </f:Panel>
                             
                        </Items>
                    </f:Toolbar>
                </toolbars>
     
                <Columns>
                    <f:RowNumberField Width="30px" />
                  
                   
                    <f:BoundField Width="180px" DataField="SHOP_ID" DataFormatString="{0}" HeaderText="分店编号" />
                    <f:BoundField Width="180px" DataField="MA_ID" DataFormatString="{0}" HeaderText="作业单号" />
                    <f:BoundField Width="180px" DataField="STATUS" DataFormatString="{0}" HeaderText="单据状态" />
                    <f:BoundField Width="180px" DataField="INPUT_DATE" DataFormatString="{0}" HeaderText="单据日期" />
                    <f:BoundField Width="180px" DataField="DIV_ID" DataFormatString="{0}" HeaderText="领用部门" />
                    <f:BoundField Width="180px" DataField="MAT_TYPE" DataFormatString="{0}" HeaderText="领用类型" />
                    <f:BoundField Width="180px" DataField="STOCK_ID" DataFormatString="{0}" HeaderText="仓库编号" />
                    <f:BoundField Width="180px" DataField="USER_ID" DataFormatString="{0}" HeaderText="制单人" />
                    <f:BoundField Width="180px" DataField="APP_USER" DataFormatString="{0}" HeaderText="审核人" />
                    <f:BoundField Width="180px" DataField="APP_DATETIME" DataFormatString="{0}" HeaderText="审核时间" />
                    <f:BoundField Width="180px" DataField="RELATE_ID" DataFormatString="{0}" HeaderText="关联单号" />
                    <f:BoundField Width="180px" DataField="Memo" DataFormatString="{0}" HeaderText="备注" />

                    <f:BoundField Width="180px" DataField="LOCKED" DataFormatString="{0}" HeaderText="月结锁定" />
                    <f:BoundField Width="180px" DataField="CRT_DATETIME" DataFormatString="{0}" HeaderText="建档日期" />
                    <f:BoundField Width="180px" DataField="CRT_USER_ID" DataFormatString="{0}" HeaderText="建档人员" />
                    <f:BoundField Width="180px" DataField="MOD_DATETIME" DataFormatString="{0}" HeaderText="修改日期" />
                    <f:BoundField Width="180px" DataField="MOD_USER_ID" DataFormatString="{0}" HeaderText="修改人员" />
                    <f:BoundField Width="180px" DataField="LAST_UPDATE" DataFormatString="{0}" HeaderText="最后异动时间" />
                    <f:BoundField Width="180px" DataField="Trans_STATUS" DataFormatString="{0}" HeaderText="传输状态" />
 
                </Columns>
            </f:Grid>
                        <f:HiddenField runat="server" ID="PPhidId" Text="0"></f:HiddenField>

                    </Items>
                </f:Panel>
                <f:Panel runat="server" ID="panelLeftRegion"  RegionSplit="true" EnableCollapse="false" AutoScroll="true"
                    Width="600px"  Title="左侧面板" ShowBorder="false" ShowHeader="false"
                   > <%--BodyPadding="5px" RegionPosition="Left"--%>
                    <Items>
                          <f:Grid ID="Grid3" EnableFrame="false" EnableCollapse="true" ShowBorder="false" ShowHeader="false" runat="server" 
                               DataKeyNames="PROD_ID" EnableColumnLines="true"
                              EnableMultiSelect="false" EnableRowSelectEvent="true" 
                                AllowSorting="true"  AllowPaging="true"   EnableCheckBoxSelect="True">  
                             <Columns>
                    <f:RowNumberField  />
                   
                   <%-- <f:TemplateField HeaderText="排序" Width="100px">
                        <ItemTemplate>
                            <asp:TextBox ID="tbSort" runat="server" Width="50px" Text='<%# Eval("Sort") %>' AutoPostBack="false"></asp:TextBox>
                        </ItemTemplate>
                    </f:TemplateField>--%>
                    <f:BoundField Width="180px" DataField="SHOP_ID" DataFormatString="{0}" HeaderText="分店编号" />
                    <f:BoundField Width="180px" DataField="TAKEIN_ID" DataFormatString="{0}" HeaderText="计划单号" />
                    <f:BoundField Width="180px" DataField="STATUS" DataFormatString="{0}" HeaderText="单据状态" />
                    <f:BoundField Width="180px" DataField="INPUT_DATE" DataFormatString="{0}" HeaderText="单据日期" />
                     <f:BoundField Width="180px" DataField="STOCK_ID" DataFormatString="{0}" HeaderText="仓库编号" />
                    <f:BoundField Width="180px" DataField="USER_ID" DataFormatString="{0}" HeaderText="制单人" />
                    <f:BoundField Width="180px" DataField="APP_USER" DataFormatString="{0}" HeaderText="审核人" />
                    <f:BoundField Width="180px" DataField="APP_DATETIME" DataFormatString="{0}" HeaderText="审核时间" />
                    <f:BoundField Width="180px" DataField="RELATE_ID" DataFormatString="{0}" HeaderText="关联单号" />
                    <f:BoundField Width="180px" DataField="Memo" DataFormatString="{0}" HeaderText="备注" />
                     
                    <f:BoundField Width="180px" DataField="LOCKED" DataFormatString="{0}" HeaderText="月结锁定" />
                    <f:BoundField Width="180px" DataField="CRT_DATETIME" DataFormatString="{0}" HeaderText="建档日期" />
                    <f:BoundField Width="180px" DataField="CRT_USER_ID" DataFormatString="{0}" HeaderText="建档人员" />
                    <f:BoundField Width="180px" DataField="MOD_DATETIME" DataFormatString="{0}" HeaderText="修改日期" />
                    <f:BoundField Width="180px" DataField="MOD_USER_ID" DataFormatString="{0}" HeaderText="修改人员" />
                    <f:BoundField Width="180px" DataField="LAST_UPDATE" DataFormatString="{0}" HeaderText="最后异动时间" />
                    <f:BoundField Width="180px" DataField="Trans_STATUS" DataFormatString="{0}" HeaderText="传输状态" />
           
                   
                </Columns>

                          </f:Grid>
                    </Items>
                </f:Panel>
                
                 
            </Items>
        </f:Panel>

 <f:Window ID="Window2" Width="500px" Height="200px" Icon="TagBlue" Hidden="true" BodyPadding="20px"
            EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
            IsModal="false" CloseAction="HidePostBack" OnClose="Window2_Close" Layout="Fit">   <%--OnInit="Windows_Init"--%>
            <Toolbars>
                <f:Toolbar ID="toolbar4" runat="server">
                      <Items>
                         <f:Button ID="btnArchive" runat="server" Text="引入" Icon="Disk" OnClick="btnImport_Click" ></f:Button>
                         <f:Button ID="btnCancel" runat="server" Text="取消" Icon="Cancel" OnClick="btnCancel_Click" ></f:Button>
                      </Items>
                </f:Toolbar>
            </Toolbars>
            <Content>
                <f:Panel ID="A" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="formitem" 
                    runat="server">
                    <Items>
                        <%--<f:Label ID="Label1" runat="server" Width="80px" CssClass="marginr" ShowLabel="false"
                            Text="提交时间：">
                        </f:Label> --%>
                        <f:RadioButton ID="RaddpUp_Date" runat="server" Text="提交时间：" GroupName="Rad_Time"></f:RadioButton>
                        <f:DatePicker runat="server" ShowLabel="false" Label="提交时间" ID="dpUp_DateBeg" Width="150px" ></f:DatePicker>
                        <f:Label ID="lab3" runat="server" Width="20px" ShowLabel="false" Text="至"/>
                        <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" ID="dpUp_DateEnd" CompareControl="dpUp_DateBeg" CompareOperator="GreaterThan"
                            CompareMessage="结束日期应该大于开始日期！" Width="150px" ShowLabel="false" ></f:DatePicker>
 
                    </Items>
                </f:Panel>
                <f:Panel ID="B" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="formitem"
                    runat="server">
                    <Items>
                       <%-- <f:Label ID="Label2" runat="server" Width="80px" CssClass="marginr" ShowLabel="false"
                            Text="期望日期："></f:Label> --%> 
                        <f:RadioButton ID="RadEXPECT_DATE" runat="server" Text="期望日期：" GroupName="Rad_Time"></f:RadioButton>
                        <f:DatePicker runat="server" ShowLabel="false" Label="期望开始日期"  ID="dpEXPECT_DATEBeg" Width="150px" ></f:DatePicker>
                        <f:Label ID="lb4" runat="server" Width="20px" ShowLabel="false" Text="至" />
                        
                        <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" ID="dpEXPECT_DATEEnd" CompareControl="dpEXPECT_DATEBeg" CompareOperator="GreaterThan"
                            CompareMessage="结束日期应该大于开始日期！"  Width="150px" ShowLabel="false" ></f:DatePicker>
                    </Items>
               </f:Panel>
             
            </Content>
        </f:Window>
    </form>


</body>

</html>
