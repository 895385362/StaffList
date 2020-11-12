using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using DAL;

namespace StaffList
{
    public partial class OrderModify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 页面加载
            if (!IsPostBack)
            {
                // 锁定员工姓名
                GetStaffDetail();
                // 获取设备下拉列表
                GetDeviceList();
            }
            #endregion
        }
        private void GetStaffDetail()
        {
            #region 获取传递过来的员工ID操作(添加订单)
            string StaffID = Request["staffID"];
            if (!string.IsNullOrEmpty(StaffID))
            {
                DataSet ds = OperareBase.getData("select * from Info_staff where IsDelete = 0 and staffID=" + StaffID);
                // 如果查询到数据,给员工姓名textBox赋值,并向隐藏控件赋值id
                if (ds.Tables[0].Rows.Count > 0)
                {
                    TextBox4.Text = ds.Tables[0].Rows[0]["staffName"].ToString();
                    StaffID_Value.Value = ds.Tables[0].Rows[0]["staffID"].ToString();
                }
                // 查不到跳转到登录页面
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            #endregion
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            #region 添加订单(设备、库存)
            string OrderNum = TextBox1.Text;
            string DeviceNum = ddlDevicelist.SelectedValue;
            int count =  Convert.ToInt32(TextBox3.Text);

            bool NumResult = false;
            DataSet ds = OperareBase.getData("select * from dbo.Info_device where deviceID = '"+DeviceNum+"'and IsDelete = 0");
            if (ds.Tables[0].Rows.Count>0)
            {
                if (count> Convert.ToInt32(ds.Tables[0].Rows[0]["deviceCount"].ToString()))
                {
                    Response.Write("输入的数量大于剩余数量,剩余数量："+ Convert.ToInt32(ds.Tables[0].Rows[0]["deviceCount"].ToString()));
                    NumResult = true;
                }else if (count <= Convert.ToInt32(ds.Tables[0].Rows[0]["deviceCount"].ToString()))
                {
                    if (NumResult==false)
                    {
                        string sql = "insert into Info_order (orderNum,staffID,deviceID,Count)values('" + OrderNum + "','" + StaffID_Value.Value + "','" + DeviceNum + "'," + count + ")";
                        int num = OperareBase.CommanBySql(sql);
                        if (num > 0)
                        {
                            int DeviceCount = Convert.ToInt32(ds.Tables[0].Rows[0]["deviceCount"].ToString()) - count;
                            int update = OperareBase.CommanBySql("update Info_device set deviceCount =" + DeviceCount + ",Count = Count+"+count+"where deviceID="+ DeviceNum + "");
                            if (update > 0)
                            {
                                Response.Redirect("Login.aspx");
                            }
                        }
                    }
                }
            }
            #endregion
        }

        #region 选择设备
        private void GetDeviceList()
        {
            DataSet ds = OperareBase.getData("select * from dbo.Info_device where IsDelete = 0 order by deviceNum");  
            ddlDevicelist.DataSource = ds;
            ddlDevicelist.DataTextField = "deviceNum";
            ddlDevicelist.DataValueField = "deviceID";
            ddlDevicelist.DataBind();
            ddlDevicelist.Items.Insert(0, new ListItem("请选择设备ID", "0"));
        }
        #endregion
    }
}