using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StaffList
{
    public partial class MyWorld : BasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            #region 页面加载
            if (!IsPostBack)
            {
                GetStaffDetail();
            }
            #endregion
        }

        #region 根据Cookie获取到ID赋值给文本框
        public void GetStaffDetail()
        {
            string StaffID = Session["StaffID"].ToString();
            if (StaffID != null)
            {
                if (!String.IsNullOrEmpty(StaffID))
                {
                    DataSet StaffListByStaffID_Ds = OperareBase.getData("select * from Info_staff where staffID=" + StaffID + "");
                    //判断 容器中的数据条数是否 >0 大于0代表根据 StaffID查询到了数据 
                    //Tables[0]第一张表  Rows[0]第一行 [""]代表第一行里的哪一个字段
                    if (StaffListByStaffID_Ds.Tables[0].Rows.Count > 0)
                    {
                        StaffID = StaffListByStaffID_Ds.Tables[0].Rows[0]["staffID"].ToString();
                        StaffAvatarImg.ImageUrl = StaffListByStaffID_Ds.Tables[0].Rows[0]["staffAvatar"].ToString();
                        staffNum.Text = StaffListByStaffID_Ds.Tables[0].Rows[0]["staffNum"].ToString();
                        staffName.Text = StaffListByStaffID_Ds.Tables[0].Rows[0]["staffName"].ToString();
                        Sex_tb.SelectedValue = StaffListByStaffID_Ds.Tables[0].Rows[0]["staffSex"].ToString();
                        staffAge.Text = StaffListByStaffID_Ds.Tables[0].Rows[0]["staffAge"].ToString();
                        staffMobile.Text = StaffListByStaffID_Ds.Tables[0].Rows[0]["staffMobile"].ToString();
                        staffPassword.Text = StaffListByStaffID_Ds.Tables[0].Rows[0]["staffPassword"].ToString();
                    }
                }
            }
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            #region 退出登录(将Cookie清空)
            CookieHelper.ClaeaCookie("StaffID");
            CookieHelper.ClaeaCookie("StaffNum");
            CookieHelper.ClaeaCookie("StaffMobile");
            CookieHelper.ClaeaCookie("StaffPassword");
            CookieHelper.ClaeaCookie("StaffName");
            CookieHelper.ClaeaCookie("AutoLogin");
            CookieHelper.ClaeaCookie("IsPwd");


            Response.Redirect("Login.aspx");
            #endregion
        }
    }
}