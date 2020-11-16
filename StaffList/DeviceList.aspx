<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeviceList.aspx.cs" Inherits="StaffList.DeviceList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
                <Items>
                    <asp:MenuItem NavigateUrl ="~/OrderList.aspx" Text="订单列表" Value="订单列表"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl ="~/StaffList.aspx" Text="员工列表" Value="员工列表"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl ="~/DeviceList.aspx" Text="设备列表" Value="设备列表"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl ="~/MyWorld.aspx" Text="个人信息" Value="个人信息"></asp:MenuItem>
                </Items>
            </asp:Menu>
            <table style="text-align:center; border:solid 1px #000000;">
            <asp:Repeater ID="Repeater2" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td>设备号码</td>
                        <td>剩余设备数量</td>
                        <td>订单设备数量</td>
                        <td>状态</td>
                        <td>操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr>
                            <td><%#Eval("deviceNum") %></td>   
                            <td><%#Eval("deviceCount")%></td>
                            <td><%#Eval("Outbase") %></td>
                            <td><%#Eval("IsDelete").ToString()=="true" ? "已删除":"未删除"%></td>
                             <td>
                                  <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Insert" OnClick ="LinkButton1_Click">添加</asp:LinkButton>
                            </td>
                        </tr>
                </ItemTemplate>
             </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>
