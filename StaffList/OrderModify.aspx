<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderModify.aspx.cs" Inherits="StaffList.OrderModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <style type="text/css">
            label{
                width:100px;
                height:24px;
                display:block;
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <table>
            <tr>
                <td>
                    <label>订单编号:</label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>设备编号:</label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlDevicelist" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDevicelist_SelectedIndexChanged" ></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <label>订单设备数量:</label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>员工姓名:</label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="确定" CommandName="Insert" OnClick="Button1_Click"/>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="StaffID_Value" runat="server" />

                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
