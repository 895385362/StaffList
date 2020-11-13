<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffList.aspx.cs" Inherits="StaffList.StaffList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <style type="text/css">
             table td
             {
                   border:solid 1px #000000;
                   width:90px;
                   height:70px
             }
        </style>  
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

             <asp:DropDownList ID="Seach" runat="server" AutoPostBack ="true" OnSelectedIndexChanged="Seach_SelectedIndexChanged">
                <asp:ListItem Value="">请选择是否删除</asp:ListItem>
                <asp:ListItem Value="0">未删除</asp:ListItem>
                <asp:ListItem Value="1">已删除</asp:ListItem>
            </asp:DropDownList>
            <table style="text-align:center; border:solid 1px #000000;">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <tr>
                        <td>头像</td>
                        <td>员工号码</td>
                        <td>员工姓名</td>
                        <td>员工性别</td>
                        <td>员工年龄</td>
                        <td>员工账号</td>
                        <td>密码</td> 
                        <td>省份</td>
                        <td>城市</td>
                        <td>区/县</td>
                        <td>详细地址</td>
                        <td>状态</td>
                        <td>操作</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr>
                            <td><asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("staffAvatar")%>' Width="95px" Height="100px" /></td>
                            <td><%#Eval("staffNum")%></td>
                            <td><%#Eval("staffName")%></td>
                            <td><%#Eval("staffSex").ToString() == "0" ?"男":"女" %></td>
                            <td><%#Eval("staffAge")%></td>
                            <td><%#Eval("staffMobile")%></td>
                            <td><%#Eval("staffPassword")%></td>
                            <td><%#Eval("ProvinceName")%></td>
                            <td><%#Eval("CityName")%></td>
                            <td><%#Eval("DistrictName")%></td>
                            <td><%#Eval("Address")%></td>
                            <td><%#Eval("IsDelete").ToString()=="True" ? "已删除":"未删除"%></td>
                            <td>
                                <asp:HiddenField ID="HiddenField1" runat="server" value='<%#Eval("staffID") %>' />
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Enabled='<%#Eval("IsDelete").ToString() == "False"?true:false %>'>删除</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit">修改</asp:LinkButton>
                            </td>
                        </tr>
                </ItemTemplate>
             </asp:Repeater>
            </table>
            当前第[<asp:Label ID="Label_NowPage" runat="server" Text="1"></asp:Label>]页&nbsp;&nbsp;
            共[<asp:Label ID="Label_MaxPage" runat="server" Text="加载中..."></asp:Label>]&nbsp;&nbsp;
            <asp:LinkButton ID="btn_First" runat="server">首页</asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="btn_prev" runat="server">上一页</asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="btn_next" runat="server">下一页</asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="btn_last" runat="server">末页</asp:LinkButton>&nbsp;&nbsp;
            <asp:DropDownList ID="Pages" runat="server"></asp:DropDownList>&nbsp;&nbsp;
            <asp:Button ID="btn_go" runat="server" Text="跳转" />&nbsp;&nbsp;

        </div>
         <div>
            <asp:Button ID="Button1" runat="server" Text="注册" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
