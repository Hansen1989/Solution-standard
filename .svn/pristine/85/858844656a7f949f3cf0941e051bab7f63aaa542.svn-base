<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArchiveOrdersList.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SupplyCenter.ArchiveOrdersList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
   <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" ShowBorder="false" ShowHeader="false" Layout="Region">
            <Items>
                <f:Panel runat="server" ID="panelTopRegion" RegionPosition="Top" RegionSplit="true" EnableCollapse="false" Height="240px"
                    Title="顶部面板" ShowBorder="false" ShowHeader="false" BodyPadding="5px" AutoScroll="true">
                    <Items>
             <f:Grid ID="Grid1" Title="汇整订单" EnableFrame="false" EnableCollapse="true" 
                 ShowBorder="false" ShowHeader="false" runat="server" EnableCheckBoxSelect="True" DataKeyNames="COL_ID,SHOP_ID" EnableColumnLines="true"
               OnRowCommand="Grid1_RowCommand" OnPreRowDataBound="Grid1_PreRowDataBound"
                 EnableMultiSelect="false" EnableRowSelectEvent="true" OnRowSelect="Grid1_RowSelect" >   
               
                <toolbars>
                    <f:Toolbar ID="Toolbar1" runat="server"  >   <%--Position="Left"--%>
                       
                        <Items>
                          <f:Panel ID="panl1" runat="server" ShowHeader="false" ShowBorder="false" Width="800px" BodyStyle="background-color:transparent;">
                            <Toolbars>
                               <f:Toolbar ID="toolBar" runat="server" Width="800px"  >
                                   <Items>
                                        <f:Button ID="ButtonArchiveOrders" runat="server" Text="汇整" Icon="Add" OnClick="ButtonArchiveOrders_Click" CssClass="inline btnf"></f:Button>
                                       <f:Button ID="ButtonBackArchiveOrders" runat="server" Text="反汇整" Icon="Delete" OnClick="ButtonBackArchiveOrders_Click" CssClass="inline btnf"></f:Button> 
                                       <f:Button ID="ButtonRefresh" runat="server" Text="刷新" Icon="ArrowRefresh" OnClick="ButtonRefresh_Click" CssClass="inline btnf"></f:Button>
                                        <%--<f:Button ID="ButtonAdd" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click" CssClass="btnf"></f:Button>--%>
                                        <f:Button ID="ButtonSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="ButtonSearch_Click" CssClass="btnf"></f:Button>
                                       <f:Button ID="ButtonApproval" runat="server" Text="核准" Icon="Disk" OnClick="ButtonApproval_Click" ConfirmTitle="核准提示" ConfirmText="是否核准此订单？" ></f:Button>
                                       <f:Button ID="ButtonBackApproval" runat="server" Text="反核准" Icon="Delete"  ></f:Button> 

                                       <%-- <f:Button ID="ButtonEdit" runat="server" Text="编辑" Icon="BulletEdit" OnClick="ButtonEdit_Click" CssClass="btnf"
                                            OnClientClick="if(!F('Grid1').getSelectionModel().hasSelection()|| F('Grid1').getSelectionModel().getCount()>=2){F.alert('您没有选择编辑项或只能选择一项进行编辑！'); return false; }">
                                       </f:Button> --%>
                                        <f:Button ID="ButtonSaveAutoSort" runat="server" Text="自动排序" Icon="ArrowJoin" CssClass="btnf" OnClick="ButtonSaveAutoSort_Click" ConfirmTitle="自动排序提示" ConfirmText="是否对所有数据进行自动排序？"></f:Button>
                                        <f:Button ID="ButtonSaveSort" runat="server" Text="保存排序" Icon="Disk" OnClick="ButtonSaveSort_Click" CssClass="btnf"></f:Button>
                                        <f:Button ID="ButtonDelete" runat="server" Text="删除" Icon="Delete" CssClass="btnf" OnClick="ButtonDelete_Click" ConfirmTitle="删除提示" ConfirmText="是否删除记录？" 
                                            OnClientClick="if (!F('Grid1').getSelectionModel().hasSelection() ) { F.alert('删除时必须选择一条将要删除的记录！'); return false; }  if (F('Grid1').getSelectionModel().getCount() >= 2) { F.alert('只能选择一条记录进行删除！');return false; }">
                                        </f:Button>

                           <%-- <f:Button ID="ButtonMenuInfo" runat="server" Text="菜单权限分配" Icon="LayoutSidebar" OnClick="ButtonMenuInfo_Click"></f:Button>
                            <f:Button ID="ButtonPagePower" runat="server" Text="页面权限分配" Icon="LayoutSidebar" OnClick="ButtonPagePower_Click"></f:Button>--%>
                             
                                   </Items>
                               
                               </f:Toolbar>
                            </Toolbars>
                             
                          
                            </f:Panel>
                             
                        </Items>
                    </f:Toolbar>
                </toolbars>
     
                <Columns>
                    <f:RowNumberField Width="30px" />
                  
                   <%-- <f:TemplateField HeaderText="排序" Width="100px">
                        <ItemTemplate>
                            <asp:TextBox ID="tbSort" runat="server" Width="50px" Text='<%# Eval("Sort") %>' AutoPostBack="false"></asp:TextBox>
                        </ItemTemplate>
                    </f:TemplateField>--%>
                    <f:LinkButtonField runat="server" ID="LIK_SHOP" HeaderText="分店名称"  Width="140px" ColumnID="SHOP_LIK"/>
                    <%--<f:BoundField Width="180px" DataField="SHOP_ID" DataFormatString="{0}" HeaderText="分店编号" />--%>
                    <f:BoundField Width="180px" DataField="COL_ID" DataFormatString="{0}" HeaderText="汇整单号" />
                    <f:BoundField Width="180px" DataField="INPUT_DATE" DataFormatString="{0}" HeaderText="单据日期" />
                    <%--<f:RenderField runat="server" ID="rendORD_TYPE" RendererFunction="renderORD_TYPE" DataField="PROD_TYPE" Width="180px" EnableColumnEdit="false" HeaderText="订单类型">
                        <Editor>
                             <f:DropDownList ID="ddlORD_TYPE"  runat="server">
                                  <f:ListItem Value="0" Text="自产型" />
                                  <f:ListItem Value="1" Text ="供应型" />
                                  <f:ListItem Value="2" Text ="委托加工型" />
                           </f:DropDownList>

                        </Editor>
                    </f:RenderField>--%>
                    <f:LinkButtonField runat="server" ID="ARCHIVEORDERS_TYPE" ColumnID="ARCHIVEORDERS_TYPE" HeaderText="汇整类型" />
                    <f:LinkButtonField runat="server" ID="ARCHIVEORDERS_STATUS" ColumnID="ARCHIVEORDERS_STATUS" HeaderText="单据状态" />
                    <f:BoundField Width="180px" DataField="ORD_USER" DataFormatString="{0}" HeaderText="制单人员" />
                    <f:BoundField Width="180px" DataField="EXPECT_DATE" DataFormatString="{0}" HeaderText="期望日期" />
                    
                    <%--<f:BoundField Width="180px" DataField="STATUS" DataFormatString="{0}" HeaderText="单据状态" />--%>
                    <%--<f:BoundField Width="180px" DataField="PROD_TYPE" DataFormatString="{0}" HeaderText="产品类型" />--%>
                    <f:BoundField Width="180px" DataField="ORD_TYPE" DataFormatString="{0}" HeaderText="订单类型" />
   
                    <f:BoundField Width="180px" DataField="ORD_DEP_ID" DataFormatString="{0}" HeaderText="订货部门" />
                    <f:BoundField Width="180px" DataField="COL_BeginDate" DataFormatString="{0}" HeaderText="汇整起始日期" />
                    <f:BoundField Width="180px" DataField="COL_EndDate" DataFormatString="{0}" HeaderText="汇整结束日期" />
                    <f:BoundField Width="180px" DataField="APP_USER" DataFormatString="{0}" HeaderText="核准人员" />
                    <f:BoundField Width="180px" DataField="APP_DATE" DataFormatString="{0}" HeaderText="核准时间" />
                    <f:BoundField Width="180px" DataField="Memo" DataFormatString="{0}" HeaderText="备注" />
                    <f:BoundField Width="180px" DataField="LOCKED" DataFormatString="{0}" HeaderText="月结锁定" />
                    <f:BoundField Width="180px" DataField="CRT_DATETIME" DataFormatString="{0}" HeaderText="建档日期" />
                    <f:BoundField Width="180px" DataField="CRT_USER_ID" DataFormatString="{0}" HeaderText="建档人员" />
                    <f:BoundField Width="180px" DataField="MOD_DATETIME" DataFormatString="{0}" HeaderText="修改日期" />
                    <f:BoundField Width="180px" DataField="MOD_USER_ID" DataFormatString="{0}" HeaderText="修改人员" />
                    <f:BoundField Width="180px" DataField="LAST_UPDATE" DataFormatString="{0}" HeaderText="最后异动时间" />
                    <f:BoundField Width="180px" DataField="Trans_STATUS" DataFormatString="{0}" HeaderText="传输状态" />
           
                   <%-- <f:LinkButtonField HeaderText="是否显示" Icon="BulletCross" TextAlign="Center" ToolTip="点击修改是否显示" ColumnID="IsDisplay" CommandName="IsDisplay" />
                    <f:LinkButtonField HeaderText="是否页面" Icon="BulletCross" TextAlign="Center" ToolTip="点击修改是否页面" ColumnID="IsMenu" CommandName="IsMenu" />
                    <f:BoundField DataField="Depth" HeaderText="级别层次" TextAlign="Center" />
                    <f:LinkButtonField HeaderText="操作" TextAlign="Center" ToolTip="点击修改当前记录" ColumnID="ButtonEdit" CommandName="ButtonEdit" />--%>
                </Columns>
            </f:Grid>
                        <f:HiddenField runat="server" ID="PPhidId" Text="0"></f:HiddenField>

                    </Items>
                </f:Panel>
                <f:Panel runat="server" ID="panelLeftRegion" RegionPosition="Left" RegionSplit="true" EnableCollapse="false" AutoScroll="true"
                    Width="600px"  Title="左侧面板" ShowBorder="false" ShowHeader="false" > <%--BodyPadding="5px" --%>
                    <Items>
                          <f:Grid ID="Grid2" EnableFrame="false" EnableCollapse="true" ShowBorder="false" ShowHeader="false" runat="server" 
                              EnableCheckBoxSelect="false" DataKeyNames="PROD_ID" EnableColumnLines="true"
                              EnableMultiSelect="false" EnableRowSelectEvent="true" OnRowSelect="Grid2_RowSelect">
                              <Columns>
                                  <f:RowNumberField />
                                  <%--<f:BoundField Width="50px" DataField="SNo" DataFormatString="{0}" HeaderText="序号" />--%>
                                  <f:BoundField Width="80px" DataField="PROD_ID" DataFormatString="{0}" HeaderText="商品编码" />
                                  <f:BoundField Width="100px" DataField="PROD_Name" DataFormatString="{0}" HeaderText="商品名称" />
                                  <f:BoundField Width="50px" DataField="STD_UNIT" DataFormatString="{0}" HeaderText="单位" />
                                  <f:BoundField Width="100px" DataField="STD_QUAN" DataFormatString="{0}" HeaderText="数量" />
                                  <f:BoundField Width="100px" DataField="SUM_QUAN" DataFormatString="{0}" HeaderText="总部库存量" />
 
                              </Columns>

                          </f:Grid>
                    </Items>
                </f:Panel>
                <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="center"  EnableCollapse="false"  AutoScroll="true"
                    Title="右侧面板" ShowBorder="false" ShowHeader="false" > <%--BodyPadding="5px"  --%>
                    <Items><%--Width="650px" --%>
                        <f:Grid ID="Grid3" EnableFrame="false" EnableCollapse="true" ShowBorder="false" ShowHeader="false" 
                            runat="server" EnableCheckBoxSelect="false" DataKeyNames="Id" EnableColumnLines="true"
                             AllowCellEditing="true" ClicksToEdit="1">
                              <Columns>
                                  <f:BoundField Width="120px" DataField="SHOP_NAME1" DataFormatString="{0}" HeaderText="申请分店" />
                                  <f:BoundField Width="80px" DataField="STD_QUAN" DataFormatString="{0}" HeaderText="申请量" />
                                  <f:RenderField runat="server" ColumnID="SUP_QUAN0" DataField="SUP_QUAN" Width="80px" HeaderText="生产量">
                                      <Editor>
                                          <f:TextBox ID="txtSTD_QUAN" runat="server" />
                                      </Editor>
                                  </f:RenderField>
                                  <f:RenderField runat="server" ColumnID="SUP_QUAN1" DataField="SUP_QUAN" Width="80px" HeaderText="采购量" >
                                      <Editor>
                                          <f:TextBox ID="txtSUP_QUAN" runat="server" />
                                      </Editor>
                                  </f:RenderField>
                                  <f:RenderField runat="server" ColumnID="OUT_QUAN" DataField="OUT_QUAN" Width="80px" HeaderText="调拨量">
                                      <Editor>
                                          <f:TextBox ID="txtOUT_QUAN" runat="server" />
                                      </Editor>
                                  </f:RenderField>
                                   <f:RenderField runat="server" ColumnID="STD_QUAN4" DataField="STD_QUAN4" Width="120px" HeaderText="即时订货量">
                                      <Editor>
                                          <f:TextBox ID="txtImmediate" runat="server" />
                                      </Editor>
                                  </f:RenderField>

                                  <%--<f:BoundField Width="80px" DataField="STD_QUAN" DataFormatString="{0}" HeaderText="生产量" />--%>
                                  <%--<f:BoundField Width="80px" DataField="STD_QUAN" DataFormatString="{0}" HeaderText="" />
                                  <f:BoundField Width="80px" DataField="STD_QUAN" DataFormatString="{0}" HeaderText="" />
                                  <f:BoundField Width="100px" DataField="QUAN" DataFormatString="{0}" HeaderText="" />--%>
                                   
                              </Columns>

                          </f:Grid>
 
                    </Items>
                </f:Panel>
                 
            </Items>
        </f:Panel>

 
    <f:window id="Window1" width="1200px" height="650px" icon="TagBlue" title="编辑" hidden="True" Target="Parent"
        enablemaximize="True" closeaction="HidePostBack" onclose="Window1_Close" enablecollapse="true"
        runat="server" enableresize="true" bodypadding="5px" enableframe="True" iframeurl="about:blank"
        enableiframe="true" enableclose="true" ismodal="True" >
    </f:window>

       <f:Window ID="Window2" Width="500px" Height="200px" Icon="TagBlue" Hidden="true" BodyPadding="20px"
            EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
            IsModal="false" CloseAction="HidePostBack" OnClose="Window2_Close" Layout="Fit">   <%--OnInit="Windows_Init"--%>
            <Toolbars>
                <f:Toolbar ID="toolbar4" runat="server">
                      <Items>
                         <f:Button ID="btnArchive" runat="server" Text="汇整" Icon="Disk" OnClick="btnArchive_Click" ></f:Button>
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

   <%-- plain="false" --%>

    </form>
    <script>

        function renderORD_TYPE(value) {
          
            if(value == 0){
              return value = '自产型';}

            if(value == 1){
              return value = '供应型';}

            if(value == 2){
              return value = '委托加工型';}

        }

    </script>

</body>
</html>

