+






<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StaffList.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label><span style ="color:red;">*</span> </label>
            <asp:Label ID="Label1" runat="server" Text="Label">
                员工账号:<br />
            <asp:TextBox ID="staffMobile" runat="server"></asp:TextBox></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="" ForeColor=""></asp:Label><br />

            <label><span style ="color:red;">*</span> </label>
            <asp:Label ID="Label3" runat="server" Text="Label">
                密码:<br />
            <asp:TextBox ID="staffPassword" runat="server" value="" TextMode="Password"> </asp:TextBox></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="" ForeColor=""></asp:Label><br />
            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true"  Text="记住密码" OnCheckedChanged="CheckBox1_CheckedChanged" />
            <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="true"  Text ="自动登录" OnCheckedChanged="CheckBox2_CheckedChanged"/>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
