using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace StaffList
{
    public partial class DeviceList : BasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            #region 页面加载
            if (!this.Page.IsPostBack)
            {
                Repeater2GetData();
            }
            #endregion
        }

        #region 将查询的数据绑定到控件显示
        private void Repeater2GetData(string sql = "")
        {
            if (string.IsNullOrEmpty(sql))
            {
                sql = "select Info_device.*,ISNULL(Outdevice.Outbase,0) as Outbase from Info_device left join(select deviceID, SUM(Count) as Outbase from Info_order group by deviceID) as Outdevice on Info_device.deviceID = Outdevice.deviceID";
            }
            DataSet device = OperareBase.getData(sql);
            List<DeviceModel> deviceList = new List<DeviceModel>();
            foreach (DataRow dr in device.Tables[0].Rows)
            {
                DeviceModel deviceModel  = new DeviceModel();
                foreach (DataColumn dc in device.Tables[0].Columns)
                {
                    switch (dc.ColumnName)
                    {
                        case "deviceID":
                            deviceModel.deviceID = Convert.ToInt32(dr["deviceID"].ToString());
                            break;
                        case "deviceNum":
                            deviceModel.deviceNum = dr["deviceNum"].ToString();
                            break;
                        case "deviceCount":
                            deviceModel.deviceCount = Convert.ToInt32(dr["deviceCount"].ToString());
                            break;
                        case "IsDelete":
                            deviceModel.IsDelete = Convert.ToBoolean(dr["IsDelete"]);
                            break;
                        case "Outbase":
                            deviceModel.Outbase = Convert.ToInt32(dr["Outbase"].ToString()); 
                            break;
                    }
                }
                deviceList.Add(deviceModel);
            }
            Repeater2.DataSource = device;
            Repeater2.DataBind();
        }
        #endregion
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            #region 跳页添加
            Response.Redirect("device.aspx");
            #endregion
        }
    }
    
}