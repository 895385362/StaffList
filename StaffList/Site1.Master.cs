using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StaffList
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            BasePage basePage = new BasePage();
            if (!string.IsNullOrEmpty(basePage.LoginStaffID))
            {
                if(basePage.LoginStaffID != "2")
                {
                    if(e.Item.Text == "员工列表" || e.Item.Text == "设备列表")
                    {
                        Response.Write("<script type='text/javascript'>alert('无权限访问该列表');history.go(-1);</script>");
                        Response.End();
                    }
                }
                switch (e.Item.Text)
                {
                    case "订单列表":
                        Response.Redirect("~/OrderList.aspx");
                        break;
                    case "员工列表":
                        Response.Redirect("~/StaffList.aspx");
                        break;
                    case "设备列表":
                        Response.Redirect("~/DeviceList.aspx");
                        break;
                    case "个人信息":
                        Response.Redirect("~/MyWorld.aspx");
                        break;
                }
                #region 二选一
                //switch (e.Item.Text)
                //{
                //    case "订单列表":
                //        e.Item.NavigateUrl="~/OrderList.aspx";
                //        break;
                //    case "员工列表":
                //        e.Item.NavigateUrl="~/StaffList.aspx";
                //        break;
                //    case "设备列表":
                //        e.Item.NavigateUrl="~/DeviceList.aspx";
                //        break;
                //    case "个人信息":
                //        e.Item.NavigateUrl="~/MyWorld.aspx";
                //        break;
                //}
                //Response.Redirect(e.Item.NavigateUrl);
                #endregion
            }
        }
    }
}