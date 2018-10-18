<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionPlanList.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.ProductionCenter.ProductionPlanList" %>

<!DOCTYPE html>

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
             <f:Grid ID="Grid1" Title="生产计划" EnableFrame="false" EnableCollapse="true" 
                 ShowBorder="false" ShowHeader="false" runat="server" EnableCheckBoxSelect="True" DataKeyNames="SHOP_ID,PLAN_ID" EnableColumnLines="true"
               
                 EnableMultiSelect="false" EnableRowSelectEvent="true" OnRowSelect="Grid1_RowSelect" >   
               <%--OnRowCommand="Grid1_RowCommand" OnPreRowDataBound="Grid1_PreRowDataBound"--%>
                <toolbars>
                    <f:Toolbar ID="Toolbar1" runat="server"  >   <%--Position="Left"--%>
                       
                        <Items>
                          <f:Panel ID="panl1" runat="server" ShowHeader="false" ShowBorder="false" Width="800px" BodyStyle="background-color:transparent;">
                            <Toolbars>
                               <f:Toolbar ID="toolBar" runat="server" Width="800px"  >
                                   <Items>
                                       <f:Button ID="ButtonSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="ButtonSearch_Click" CssClass="btnf"></f:Button>
                                       <%-- <f:Button ID="ButtonArchiveOrders" runat="server" Text="汇整" Icon="Add" OnClick="ButtonArchiveOrders_Click" CssClass="inline btnf"></f:Button>
                                       <f:Button ID="ButtonBackArchiveOrders" runat="server" Text="反汇整" Icon="Delete" OnClick="ButtonBackArchiveOrders_Click" CssClass="inline btnf"></f:Button> --%>
                                       <f:Button ID="ButtonRefresh" runat="server" Text="刷新" Icon="ArrowRefresh" OnClick="ButtonRefresh_Click" CssClass="inline btnf"></f:Button>
                                        <%--<f:Button ID="ButtonAdd" runat="server" Text="添加" Icon="Add" OnClick="ButtonAdd_Click" CssClass="btnf"></f:Button>--%>
                                        
                                       <f:Button ID="ButtonApproval" runat="server" Text="核准" Icon="Disk" OnClick="ButtonApproval_Click" ConfirmTitle="核准提示" ConfirmText="是否核准此订单？" ></f:Button>
                                       <f:Button ID="ButtonBackApproval" runat="server" Text="反核准" Icon="Delete"  ></f:Button> 
                                     
                                        <f:Button ID="ButtonPrint" runat="server" Text="打印"  CssClass="btnf"
                                            OnClientClick="if(!F('Grid1').getSelectionModel().hasSelection()|| F('Grid1').getSelectionModel().getCount()>=2){F.alert('您没有选择编辑项或只能选择一项进行打印！'); return false; }">
                                       </f:Button> 
                                        <f:Button ID="ButtonSaveAutoSort" runat="server" Text="自动排序" Icon="ArrowJoin" CssClass="btnf" OnClick="ButtonSaveAutoSort_Click" ConfirmTitle="自动排序提示" ConfirmText="是否对所有数据进行自动排序？"></f:Button>
                                        <f:Button ID="ButtonSaveSort" runat="server" Text="保存排序" Icon="Disk" OnClick="ButtonSaveSort_Click" CssClass="btnf"></f:Button>
                                        <f:Button ID="ButtonDelete" runat="server" Text="删除" Icon="Delete" CssClass="btnf" OnClick="ButtonDelete_Click" ConfirmTitle="删除提示" ConfirmText="是否删除记录？" 
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
                    <f:BoundField Width="180px" DataField="PLAN_ID" DataFormatString="{0}" HeaderText="计划单号" />
                    <f:BoundField Width="180px" DataField="STATUS" DataFormatString="{0}" HeaderText="单据状态" />
                    <f:BoundField Width="180px" DataField="INPUT_DATE" DataFormatString="{0}" HeaderText="单据日期" />
                    <f:BoundField Width="180px" DataField="USER_ID" DataFormatString="{0}" HeaderText="制单人" />
                    <f:BoundField Width="180px" DataField="APP_USER" DataFormatString="{0}" HeaderText="审核人" />
                    <f:BoundField Width="180px" DataField="APP_DATETIME" DataFormatString="{0}" HeaderText="审核时间" />
                    <f:BoundField Width="180px" DataField="EXPECT_DATE" DataFormatString="{0}" HeaderText="期望日期" />
                    <f:BoundField Width="180px" DataField="PREPARE_ID" DataFormatString="{0}" HeaderText="备料单号" />
                    <f:BoundField Width="180px" DataField="EXPORTED" DataFormatString="{0}" HeaderText="引入标记" />
                    <f:BoundField Width="180px" DataField="EXPORTED_ID" DataFormatString="{0}" HeaderText="引入单号" />
                    <f:BoundField Width="180px" DataField="DIV_ID" DataFormatString="{0}" HeaderText="生产部门" />
                    <f:BoundField Width="180px" DataField="STOCK_ID" DataFormatString="{0}" HeaderText="仓库编号" />
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
                <f:Panel runat="server" ID="panelLeftRegion" RegionPosition="Left" RegionSplit="true" EnableCollapse="false" AutoScroll="true"
                    Width="600px"  Title="左侧面板" ShowBorder="false" ShowHeader="false" > <%--BodyPadding="5px" --%>
                    <Items>
                          <f:Grid ID="Grid2" EnableFrame="false" EnableCollapse="true" ShowBorder="false" ShowHeader="false" runat="server" 
                               DataKeyNames="PROD_ID" EnableColumnLines="true"
                              EnableMultiSelect="false" EnableRowSelectEvent="true" >
                              <Columns>
                                  <f:RowNumberField />
                                  <f:BoundField Width="50px" DataField="SNo" DataFormatString="{0}" HeaderText="序号" />
                                  <f:BoundField Width="80px" DataField="SHOP_ID" DataFormatString="{0}" HeaderText="店铺编号" />
                                  <f:BoundField Width="100px" DataField="QUANTITY" DataFormatString="{0}" HeaderText="最小单位数量" />
                                  <f:BoundField Width="50px" DataField="STD_UNIT" DataFormatString="{0}" HeaderText="生产单位" />
                                  <f:BoundField Width="100px" DataField="STD_CONVERT" DataFormatString="{0}" HeaderText="标准转换量" />
                                  <f:BoundField Width="100px" DataField="STD_QUAN" DataFormatString="{0}" HeaderText="执行生产量" />
                                  <f:BoundField Width="100px" DataField="STD_QUAN" DataFormatString="{0}" HeaderText="标准转换量" />
                              </Columns>

                          </f:Grid>
                    </Items>
                </f:Panel>
                <f:Panel runat="server" ID="panelCenterRegion" RegionPosition="center"  EnableCollapse="false"  AutoScroll="true"
                    Title="右侧面板" ShowBorder="false" ShowHeader="false" > <%--BodyPadding="5px"  --%>
                    <Items><%--Width="650px" --%>
                        <f:Grid ID="Grid3" EnableFrame="false" EnableCollapse="true" ShowBorder="false" ShowHeader="false" 
                            runat="server"  DataKeyNames="Id" EnableColumnLines="true">
                              <Columns>
                                  <f:BoundField runat="server" DataField="SHOP_ID" DataFormatString="{0}" HeaderText="申请分店" />
                                  <f:BoundField runat="server" DataField="BATCH_SNo" DataFormatString="{0}" HeaderText="生产批次" />
                                  <f:BoundField runat="server" DataField="QUANTITY" DataFormatString="{0}" HeaderText="最小单位数量"/>          
                                  <f:BoundField runat="server" DataField="STD_UNIT"  DataFormatString="{0}" HeaderText="生产单位" />
                                  <f:BoundField runat="server" DataField="STD_CONVERT" DataFormatString="{0}"  HeaderText="标准转换量"/>
                                  <f:BoundField runat="server" DataField="STD_QUAN" DataFormatString="{0}"  HeaderText="执行生产量"/>
                                  <f:BoundField runat="server" DataField="STD_PRICE" DataFormatString="{0}"  HeaderText="计划单价"/>
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
                         <f:Button ID="btnSearch" runat="server" Text="查询" Icon="Disk" OnClick="btnSearch_Click" ></f:Button>
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
