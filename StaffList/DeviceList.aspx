<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DeviceList.aspx.cs" Inherits="StaffList.DeviceList" %>
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
        <table style="text-align: center; border: solid 1px #000000;">
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
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Insert" OnClick="LinkButton1_Click">添加</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <div>
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" HorizontalAlign="Center" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" PageSize="3" AlwaysShow="true" OnPageChanged="AspNetPager1_PageChanged" ></webdiyer:AspNetPager>
        </div>
    </div>
</asp:Content>


