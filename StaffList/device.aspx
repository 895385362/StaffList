<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="device.aspx.cs" Inherits="StaffList.device" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:HiddenField ID="DeviceID" runat="server" Value="0" />


            <label><span style ="color:red;">*</span> </label>
            <asp:Label ID="Label1" runat="server" Text="Label">
                设备号码:<br />
            <asp:TextBox ID="deviceNum" runat="server"></asp:TextBox></asp:Label>
            <asp:Label ID="Label6" runat="server" Text="" ForeColor=""></asp:Label> <br />

            <label><span style ="color:red;">*</span> </label>
            <asp:Label ID="Label2" runat="server" Text="Label">
                设备数量:<br />
            <asp:TextBox ID="deviceCount" runat="server"></asp:TextBox> </asp:Label> 
            <asp:Label ID="Label7" runat="server" Text="" ForeColor=""></asp:Label> <br />

            <asp:Button ID="Button1" runat="server" Text="确认"  OnClick="Button1_Click" />  
            <br />
            <asp:Label ID="status" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
