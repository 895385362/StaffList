using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StaffList
{
    public partial class OrderList : BasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            #region 页面加载
            if (!IsPostBack)
            {
                GetOrderList();
            }
            #endregion
        }

        #region 将根据ID查询到的数据用控件显示
        public void GetOrderList()
        {
            string IDValue_Cookie = CookieHelper.GetCookieValue("StaffID");
            if (!string.IsNullOrEmpty(IDValue_Cookie))
            {
                DataSet ds = OperareBase.getData("select * from V_o_s_d where staffID = "+ IDValue_Cookie);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
            }
        }
        #endregion

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            #region 添加时根据Cookie获取的ID传参
            string IDValue_Cookie = CookieHelper.GetCookieValue("StaffID");
            if (!string.IsNullOrEmpty(IDValue_Cookie))
            {
                // 跳转到订单详情页 当前登录人的id传过去
                Response.Redirect("OrderModify.aspx?staffID=" + IDValue_Cookie);
            }
            else
            {
                // 登录信息失效,需要重新登陆
                //Session.Clear();
                Response.Redirect("Login.aspx");
            }
            #endregion
        }
    }
}