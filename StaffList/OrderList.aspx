<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="StaffList.OrderList" %>
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
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td>订单号码</td>
                        <td>订单日期</td>
                        <td>员工号码</td>
                        <td>设备号码</td>
                        <td>数量</td>
                        <td>状态</td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Insert" OnClick="LinkButton1_Click">添加</asp:LinkButton>
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("orderNum") %></td>
                        <td><%#Eval("orderDate")%></td>
                        <td><%#Eval("staffNum")%></td>
                        <td><%#Eval("deviceNum")%></td>
                        <td><%#Eval("Count")%></td>
                        <td><%#Eval("IsDelete").ToString()=="true" ? "已删除":"未删除"%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <div>
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" HorizontalAlign="Center" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" PageSize="3" AlwaysShow="true" OnPageChanged="AspNetPager1_PageChanged" ></webdiyer:AspNetPager>
        </div>
    </div>
</asp:Content>

