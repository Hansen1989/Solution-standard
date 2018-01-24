<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PositionEdit.aspx.cs" Inherits="Solution.Web.Managers.WebManage.Systems.SysAuthority.PositionEdit" %>

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
                         
                       <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="职位&部门" runat="server">
                            <Items>
                                <f:Panel ID="Panel3" Layout="HBox" BoxConfigAlign="Stretch" CssClass="formitem" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                         <f:TextBox runat="server" Label="职位" ID="txtPosition" ShowRedStar="true" Width="250px"></f:TextBox>
                            
                                    </Items>
                                    
                                </f:Panel>
                                
                            </Items>
                        </f:GroupPanel>

                         <f:Panel ID="All" runat="server" Layout="Anchor" Title="权限分配" > <%-- Title="权限分配"--%>
                              <Items>
                                  <f:GroupPanel ID="GroupPanel2" Title="菜单权限分配" runat="server" Layout="Column">
                            <Items>
                                <f:Panel ID="Panel5" Title="面板1" BoxFlex="1" runat="server" AutoScroll="true"
                                    BodyPadding="5px" ShowBorder="true" ShowHeader="false" Width="300px" Height="300px">
                                    <Items>
                                        <f:Grid ID="Grid1" Title="未分配" EnableFrame="false"  SortField="Depth" SortDirection="ASC"
                                          ShowBorder="true" ShowHeader="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id" EnableColumnLines="true">  
                                            <Columns>  <%--EnableCollapse="true"--%>
                                                    <f:BoundField DataField="Id" DataFormatString="{0}" HeaderText=" Id" runat="server" Width="60px"/>
                                                    <f:BoundField Width="180px" DataField="Name" DataSimulateTreeLevelField="Depth" DataFormatString="{0}" HeaderText="菜单" />
                                             </Columns>
                                         </f:Grid>
                                    </Items>
                                </f:Panel>
                                 <f:Panel ID="Panel7" Title="面板2" Width="70px"
                                    runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                                    <Items>
                                        <f:Label ID="Label3" runat="server" ></f:Label>
                                        <f:Button ID="AddPagePowerSign" runat="server" Text="转移>" OnClick="AddPagePowerSign_Click"/>
                                        <f:Button ID="DelPagePowerSign" runat="server" text="<移除" OnClick="DelPagePowerSign_Click"/>


                                    </Items>
                                </f:Panel>
                                <f:Panel ID="Panel6" Title="面板2" Width="300px" AutoScroll="true" Height="300px"
                                    runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                                    <Items>
                                         <f:Grid ID="Grid2" Title="已分配" EnableFrame="false"  SortField="Depth" SortDirection="ASC" 
                                          ShowBorder="true" ShowHeader="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="Id" EnableColumnLines="true">  
                                            <Columns>  <%--EnableCollapse="true"--%>
                                                    <f:BoundField ID="BoundField1" DataField="Id" DataFormatString="{0}" HeaderText=" Id" runat="server" Width="60px"/>
                                                    <f:BoundField Width="180px" DataField="Name" DataSimulateTreeLevelField="Depth" DataFormatString="{0}" HeaderText="菜单" />
                                             </Columns>
                                         </f:Grid>
                                    </Items>
                                </f:Panel>
                            </Items>
                        </f:GroupPanel>
                      
                        <f:GroupPanel ID="GroupPanel3" Title="页面权限分配" runat="server" Layout="Column">
                            <Items>
                                <f:Panel ID="Panel8" Title="面板1" BoxFlex="1" runat="server" AutoScroll="true"
                                    BodyPadding="5px" ShowBorder="true" ShowHeader="false" Width="300px" Height="300px">
                                    <Items>   <%--EnableCheckBoxSelect="True" --%>
                                        <f:Grid ID="Grid3" Title=" 页面" EnableFrame="false"  SortField="Depth" SortDirection="ASC" EnableCheckBoxSelect="true" OnRowClick="Grid3_OnRowClick" EnableRowClickEvent="true"
                                          ShowBorder="true" ShowHeader="true" runat="server" DataKeyNames="Id" EnableColumnLines="true">  
                                            <Columns>  <%--EnableCollapse="true"--%>
                                                   <f:BoundField ID="BoundField2" DataField="Id" DataFormatString="{0}" HeaderText=" Id" runat="server" Width="60px"/>
                                                   <f:BoundField Width="180px" DataField="Name" DataSimulateTreeLevelField="Depth" DataFormatString="{0}" HeaderText="页面" />
                                                    
                                             </Columns>
                                         </f:Grid>
                                    </Items>
                                </f:Panel>
                                 <%--<f:Panel ID="Panel9" Title="面板2" Width="70px"
                                    runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                                    <Items>
   
                                    </Items>
                                </f:Panel>--%>
                                <f:Panel ID="Panel10" Title="面板2" Width="300px"
                                    runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">
                                    
                                    <Items>
                                         <f:Grid ID="Grid4" Title="功能" EnableFrame="false"  OnRowCommand="Grid4_RowCommand"  OnPreRowDataBound="Grid4_PreRowDataBound"
                                          ShowBorder="true" ShowHeader="true" runat="server" DataKeyNames="Id" EnableColumnLines="true">  
                                            <Columns>  <%--EnableCollapse="true" EnableCheckBoxSelect="true"   OnPreRowDataBound="Grid4_PreRowDataBound" EnableCheckBoxSelect="True" CommandName="IsOrNotLink"--%>
                                                    <f:BoundField ID="Id" DataField="Id" DataFormatString="{0}" HeaderText="Id" runat="server" Width="60px"/>
                                                    <f:LinkButtonField runat="server" ColumnID="IsOrNotLink" Icon="BulletCross" CommandName="IsOrNotLink" HeaderText="是否有权限" />
                                                    <f:BoundField Width="180px" DataField="CName" DataFormatString="{0}" HeaderText="操作" />
                                             </Columns>
                                         </f:Grid>   <%-- --%>
                                       
                                    </Items>
                                </f:Panel>
                            </Items>
                        </f:GroupPanel>
                              
                              
                              </Items>
                             
                         </f:Panel>

 
                           <%-- <f:TextBox runat="server" Label="访问路径" ID="txtUrl" ShowRedStar="true" Width="400px" EmptyText="访问Url" ></f:TextBox>--%>
                          <%--  <f:TextBox Readonly="true" runat="server" ID="txtParent" Label="父Id" EmptyText="对应的父类Id" Width="200px" Text="0"></f:TextBox>
                            <f:TextBox runat="server" ID="txtSort" Label="排序" Width="200px" Text="0"></f:TextBox>--%>
                           <%-- <f:RadioButtonList ID="rblIsMenu" Label="是菜单/页面" ColumnNumber="3" runat="server"
                                ShowRedStar="true" Required="true">
                                <f:RadioItem Text="菜单" Value="0" Selected="true" />
                                <f:RadioItem Text="页面" Value="1" />
                            </f:RadioButtonList>--%>
                            <%--<f:RadioButtonList ID="rblIsDisplay" Label="是否显示" ColumnNumber="3" runat="server"
                                ShowRedStar="true" Required="true">
                                <f:RadioItem Text="显示" Value="1" Selected="true"/>
                                <f:RadioItem Text="不显示" Value="0" />
                            </f:RadioButtonList>--%>
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
