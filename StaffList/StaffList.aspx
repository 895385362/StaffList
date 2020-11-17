<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StaffList.aspx.cs" Inherits="StaffList.StaffList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        table td {
            border: solid 1px #000000;
            width: 90px;
            height: 70px
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:DropDownList ID="Seach" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Seach_SelectedIndexChanged">
            <asp:ListItem Value="">请选择是否删除</asp:ListItem>
            <asp:ListItem Value="0">未删除</asp:ListItem>
            <asp:ListItem Value="1">已删除</asp:ListItem>
        </asp:DropDownList>
        <table style="text-align: center; border: solid 1px #000000;">
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
                        <td>操作+<asp:Button ID="Button1" runat="server" Text="注册" OnClick="Button1_Click" /></td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("staffAvatar")%>' Width="95px" Height="100px" /></td>
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
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("staffID") %>' />
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Enabled='<%#Eval("IsDelete").ToString() == "False"?true:false %>'>删除</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit">修改</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <div>
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" HorizontalAlign="Center" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" PageSize="3" AlwaysShow="true" OnPageChanged="AspNetPager1_PageChanged" ></webdiyer:AspNetPager>
        </div>
       <%-- 当前第[<asp:Label ID="Label_NowPage" runat="server" Text="1"></asp:Label>]页&nbsp;&nbsp;
            共[<asp:Label ID="Label_MaxPage" runat="server" Text="加载中..."></asp:Label>]&nbsp;&nbsp;
            <asp:LinkButton ID="btn_First" runat="server">首页</asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="btn_prev" runat="server">上一页</asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="btn_next" runat="server">下一页</asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="btn_last" runat="server">末页</asp:LinkButton>&nbsp;&nbsp;
            <asp:DropDownList ID="Pages" runat="server"></asp:DropDownList>&nbsp;&nbsp;
            <asp:Button ID="btn_go" runat="server" Text="跳转" />&nbsp;&nbsp;--%>

    </div>
</asp:Content>

