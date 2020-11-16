using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using DAL;

namespace StaffList
{
    public partial class BasePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OnInit(null);
        }

        public string LoginStaffID
        {
            get
            {
                if (string.IsNullOrEmpty(CurrentUser))
                {
                    if (Session["StaffID"]!=null)
                    {
                        return Session["StaffID"].ToString();
                    }
                    else
                    {
                        return"";
                    }
                }
                else
                {
                    return (string)CookieHelper.GetCookieValue("StaffID");
                }
            }
        }

        public string CurrentUser
        {
            get
            {
                return (string)CookieHelper.GetCookieValue("StaffID");
            }
            set
            {
                //给的默认值为空
            }
        }
        protected override void OnInit(EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentUser))
            {
                if (Session["StaffID"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                } 
            }
            base.OnInit(e);
        }
    }
}