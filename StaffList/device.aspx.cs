using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace StaffList
{
    public partial class device : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            #region 取值
            String DeviceNum = deviceNum.Text;
            var DeviceCount = deviceCount.Text;
            #endregion

            #region 判空
            Label6.Text = "";
            Label7.Text = "";
            if (string.IsNullOrEmpty(DeviceNum))
            {
                Label6.Text = "设备号码不可为空.";
                Label6.ForeColor = Color.Red;
                return;
            }
            else if (string.IsNullOrEmpty(DeviceCount))
            {
                Label7.Text = "设备数量不可为空.";
                Label7.ForeColor = Color.Red;
                return;
            }
            else
            {
                Label6.Text = "√.";
                Label6.ForeColor = Color.Green;
                Label7.Text = "√.";
                Label7.ForeColor = Color.Green;
            }
            #endregion

            #region 添加设备
            Label6.Text = "";
            Label7.Text = "";
            if (!string.IsNullOrEmpty(DeviceNum))
            {
                //查询工号不存在数据库中
                //判断重复
                DataSet StaffListByStudentNum = OperareBase.getData("select * from Info_device where deviceNum='" + DeviceNum + "'");
                if (StaffListByStudentNum.Tables[0].Rows.Count > 0)
                {
                    Label6.Text = "工号不可重复";
                    Label6.ForeColor = Color.Green;
                }
                else
                {
                   int result = OperareBase.CommanBySql("insert into Info_device(deviceNum,deviceCount)values('" + DeviceNum + "'," + DeviceCount + ")");
                    if (result > 0)
                    {
                        Response.Redirect("StaffList.aspx");
                    }
                }
            }
            #endregion
        }
    }
}