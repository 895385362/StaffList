using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace StaffList
{
    public partial class BasePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OnInit(null);
        }

       

        public string CurrentUser
        {
            get
            {
                string sa = string.Empty;
               
                 sa = (string)CookieHelper.GetCookieValue("StaffID");
                return sa;
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