<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MyWorld.aspx.cs" Inherits="StaffList.MyWorld" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
            <label>员工头像：</label>
            <asp:Image ID="StaffAvatarImg" runat="server"  />
            <br />

           
            <asp:Label ID="Label1" runat="server" Text="Label">
                员工号码:<br />
            <asp:TextBox ID="staffNum" runat="server" Enabled="false"></asp:TextBox></asp:Label>
            <asp:Label ID="Label6" runat="server" Text="" ForeColor=""></asp:Label> <br />

           
            <asp:Label ID="Label2" runat="server" Text="Label">
                员工姓名:<br />
            <asp:TextBox ID="staffName" runat="server" Enabled="false"></asp:TextBox> </asp:Label> 
            <asp:Label ID="Label7" runat="server" Text="" ForeColor=""></asp:Label> <br />

            <label>员工性别:<br /></label>
            <asp:RadioButtonList CssClass="CancelTheStyle" ID="Sex_tb" runat="server" RepeatDirection ="Horizontal" RepeatLayout="Table" Enabled="false">
                <asp:ListItem Selected ="true" Value="0">男</asp:ListItem>
                <asp:ListItem Value="1">女</asp:ListItem>
            </asp:RadioButtonList>

            <asp:Label ID="Label4" runat="server" Text="Label">
                员工年龄:<br />
                <asp:TextBox ID="staffAge" runat="server" Enabled="false"></asp:TextBox></asp:Label>
            <asp:Label ID="Label9" runat="server" Text="" ForeColor=""></asp:Label><br />

          
            <asp:Label ID="Label5" runat="server" Text="Label">
                员工账号:<br />
                <asp:TextBox ID="staffMobile" runat="server"  Enabled="false"></asp:TextBox></asp:Label>
            <asp:Label ID="Label10" runat="server" Text="" ForeColor=""></asp:Label><br />

          
            <asp:Label ID="Label12" runat="server" Text="Label">
                密码:<br />
                <asp:TextBox ID="staffPassword" runat="server"  Enabled="false"></asp:TextBox></asp:Label>
            <asp:Label ID="Label13" runat="server" Text="" ForeColor=""></asp:Label><br />

            <asp:Button ID="Button1" runat="server" Text="退出登录" OnClick="Button1_Click" />
        </div>
</asp:Content>

