using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using DAL;

namespace StaffList
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 页面加载
            var IsPwd_Value = CookieHelper.GetCookieValue("IsPwd");
            if (!string.IsNullOrEmpty(IsPwd_Value))
            {
                CheckBox1.Checked = true;
                string MobileValue_Cookie = CookieHelper.GetCookieValue("StaffMobile");
                if (!string.IsNullOrEmpty(MobileValue_Cookie))
                {
                    staffMobile.Text = MobileValue_Cookie;
                }

                string PasswordValue_Cookie = CookieHelper.GetCookieValue("StaffPassword");
                if (!string.IsNullOrEmpty(PasswordValue_Cookie))
                {
                    staffPassword.Attributes.Add("value", PasswordValue_Cookie);
                    staffPassword.Text = PasswordValue_Cookie;
                }
            }
            string AutoValue_Cookie = CookieHelper.GetCookieValue("AutoLogin");
            if (!string.IsNullOrEmpty(AutoValue_Cookie))
            {
                if (AutoValue_Cookie == "True")
                {
                    string NameValue_Cookie = CookieHelper.GetCookieValue("StaffName");

                    if (NameValue_Cookie == "纯jbNT时光如画梦如水")
                    {
                        //运用Session传递信息
                        //Session["staffID"] = ds.Tables[0].Rows[0]["staffID"];
                        //Response.Redirect("StaffList.aspx");
                        Response.Redirect("StaffList.aspx");

                    }
                    //如果是员工进入订单列表页
                    else
                    {
                        Response.Redirect("OrderList.aspx");
                    }
                }   
            }
            #endregion
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            #region 取值
            //获取输入手机号
            var StaffMobile = staffMobile.Text.Trim();
            //获取输入的密码
            var StaffPassword = staffPassword.Text.Trim();
            Label2.Text = "";
            Label4.Text = "";
            #endregion

            #region 判空
            //定义一个bool值用于判断是否跳出语句 不在继续向下执行
            bool EmptyResult = false;
            if (string.IsNullOrEmpty(StaffMobile))
            {
                Label2.Text = "账号不可为空.";
                Label2.ForeColor = Color.Red;
                return;
            }
            else if (string.IsNullOrEmpty(StaffPassword))
            {
                Label4.Text = "密码不可为空.";
                Label4.ForeColor = Color.Red;
                return;
            }
            if (EmptyResult)
            {
                return;
            }
            #endregion

            #region 根据输入的账号密码进行登录
            DataSet ds = OperareBase.getData("select * from dbo.Info_staff where staffMobile = '" + StaffMobile + "'and staffPassword = '" + StaffPassword + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                bool CheckBoxResult = CheckBox1.Checked;
                bool AutoLoginResult = CheckBox2.Checked;
                if (CheckBoxResult)
                {
                    CookieHelper.SetCookie("IsPwd", CheckBox1.Checked.ToString(), DateTime.Now.AddMinutes(10));
                    CookieHelper.SetCookie("AutoLogin", CheckBox2.Checked.ToString(), DateTime.Now.AddMinutes(10));
                    CookieHelper.SetCookie("StaffID", ds.Tables[0].Rows[0]["staffID"].ToString(), DateTime.Now.AddMinutes(10));
                    CookieHelper.SetCookie("StaffMobile", staffMobile.Text, DateTime.Now.AddMinutes(10));
                    CookieHelper.SetCookie("StaffPassword", staffPassword.Text, DateTime.Now.AddMinutes(10));
                    CookieHelper.SetCookie("StaffName", ds.Tables[0].Rows[0]["staffName"].ToString(), DateTime.Now.AddMinutes(10));
                    

                    //Response.Cookies["StaffID"].Value = ds.Tables[0].Rows[0]["staffID"].ToString();
                    //Response.Cookies["Time"].Expires = DateTime.Now.AddDays(3);
                    //Response.Cookies["StaffMobile"].Value = staffMobile.Text;
                    //Response.Cookies["StaffPassword"].Value = staffPassword.Text;
                    //Server.Transfer("StaffList.aspx");


                    //HttpCookie cookie = new HttpCookie("StaffID")

                    //{
                    //    Value = HttpUtility.UrlEncode(ds.Tables[0].Rows[0]["staffID"].ToString()),
                    //    Expires = DateTime.Now.AddDays(1)
                    //};
                    //HttpContext.Current.Response.Cookies.Add(cookie);
                    //HttpCookie cookieMob = new HttpCookie("StaffMobile")
                    //{
                    //    Value = HttpUtility.UrlEncode(staffMobile.Text),
                    //    Expires = DateTime.Now.AddDays(1)
                    //};
                    //HttpContext.Current.Response.Cookies.Add(cookieMob);
                    //HttpCookie cookiePwd = new HttpCookie("StaffPassword")
                    //{
                    //    Value = HttpUtility.UrlEncode(staffPassword.Text),
                    //    Expires = DateTime.Now.AddDays(1)
                    //};
                    //HttpContext.Current.Response.Cookies.Add(cookiePwd);
                }
                else
                {
                    //运用Session传递信息
                    Session["staffID"] = ds.Tables[0].Rows[0]["staffID"].ToString();
                }
                //如果账号为管理员进入员工列表页面
                if (ds.Tables[0].Rows[0]["staffMobile"].ToString() == "admin")
                {
                   
                    Response.Redirect("StaffList.aspx");

                }
                //如果是员工进入订单列表页
                else
                {
                    Response.Redirect("OrderList.aspx");
                }
            }
            else
            {
                Response.Write("登陆失败请检查账号或密码是否有误!");
            }
            #endregion
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            #region 忘记密码
            Response.Redirect("FindPassword.aspx");
            #endregion
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            var AutoLogin_Value = CheckBox2.Checked;
            if (AutoLogin_Value)
            {
                CheckBox1.Checked = true;
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            var IsPwd_Value = CheckBox1.Checked;
            if (!IsPwd_Value)
            {
                CheckBox2.Checked = false;
            }
        }
        protected void staffPassword_TextChanged(object sender, EventArgs e)
        {
            var PasswordValue_Cookie = staffPassword.Text.Trim();
            staffPassword.Attributes.Add("value", PasswordValue_Cookie);
            staffPassword.Text = PasswordValue_Cookie;
        }
    }
}