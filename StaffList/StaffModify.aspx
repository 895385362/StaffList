<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffModify.aspx.cs" Inherits="StaffList.StaffModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .CancelTheStyle label
        {
            display:contents;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:HiddenField ID="StaffID" runat="server" Value="0" />

            
             <asp:GridView ID="GridView1" runat="server" ></asp:GridView>

            <label>员工头像：</label>
            <asp:Image ID="StaffAvatarImg" runat="server" />
            <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Button ID="BtnUpload" runat="server" OnClick="BtnUpload_Click" Text="上传" />
            <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
            <br />

            <label><span style ="color:red;">*</span> </label>
            <asp:Label ID="Label1" runat="server" Text="Label">
                员工号码:<br />
            <asp:TextBox ID="staffNum" runat="server"></asp:TextBox></asp:Label>
            <asp:Label ID="Label6" runat="server" Text="" ForeColor=""></asp:Label> <br />

            <label><span style ="color:red;">*</span> </label>
            <asp:Label ID="Label2" runat="server" Text="Label">
                员工姓名:<br />
            <asp:TextBox ID="staffName" runat="server"></asp:TextBox> </asp:Label> 
            <asp:Label ID="Label7" runat="server" Text="" ForeColor=""></asp:Label> <br />

            <label>员工性别:<br /></label>
            <asp:RadioButtonList CssClass="CancelTheStyle" ID="Sex_tb" runat="server" RepeatDirection ="Horizontal" RepeatLayout="Table">
                <asp:ListItem Selected ="true" Value="0">男</asp:ListItem>
                <asp:ListItem Value="1">女</asp:ListItem>
            </asp:RadioButtonList>

            <asp:Label ID="Label4" runat="server" Text="Label">
                员工年龄:<br />
                <asp:TextBox ID="staffAge" runat="server"></asp:TextBox></asp:Label>
            <asp:Label ID="Label9" runat="server" Text="" ForeColor=""></asp:Label> <br />

            <label><span style ="color:red;">*</span> </label>
            <asp:Label ID="Label5" runat="server" Text="Label">
                员工账号:<br />
                <asp:TextBox ID="staffMobile" runat="server"></asp:TextBox></asp:Label>
            <asp:Label ID="Label10" runat="server" Text="" ForeColor=""></asp:Label><br />

            <label><span style ="color:red;">*</span> </label>
            <asp:Label ID="Label12" runat="server" Text="Label">
                密码:<br />
                <asp:TextBox ID="staffPassword" runat="server"></asp:TextBox></asp:Label>
            <asp:Label ID="Label13" runat="server" Text="" ForeColor=""></asp:Label><br />
            
             省份:<br /><asp:DropDownList ID="ddlProlist" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProlist_SelectedIndexChanged">
                <asp:ListItem Value ="0">请选择省份</asp:ListItem>
                     </asp:DropDownList><br />
             城市:<br /><asp:DropDownList ID="ddlCitylist" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCitylist_SelectedIndexChanged">
                <asp:ListItem Value ="0">请选择城市</asp:ListItem>
                     </asp:DropDownList><br />
             区:<br /><asp:DropDownList ID="ddlDislist" runat="server" AutoPostBack="true">
                <asp:ListItem Value ="0">请选择地区</asp:ListItem>
                    </asp:DropDownList><br />

            <asp:Label ID="Label3" runat="server" Text="Label">
                详细地址:<br />
                <asp:TextBox ID="Address" runat="server"></asp:TextBox></asp:Label>
            <asp:Label ID="Label8" runat="server" Text="" ForeColor=""></asp:Label><br />

            <asp:Button ID="Button1" runat="server" Text="确认"  OnClick="Button1_Click" />  
            <br />
            <asp:Label ID="status" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
