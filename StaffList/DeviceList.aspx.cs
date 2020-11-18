using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using Common;

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
            //List<DeviceModel> deviceList = new List<DeviceModel>();
            //foreach (DataRow dr in device.Tables[0].Rows)
            //{
            //    DeviceModel deviceModel  = new DeviceModel();
            //    foreach (DataColumn dc in device.Tables[0].Columns)
            //    {
            //        switch (dc.ColumnName)
            //        {
            //            case "deviceID":
            //                deviceModel.deviceID = Convert.ToInt32(dr["deviceID"].ToString());
            //                break;
            //            case "deviceNum":
            //                deviceModel.deviceNum = dr["deviceNum"].ToString();
            //                break;
            //            case "deviceCount":
            //                deviceModel.deviceCount = Convert.ToInt32(dr["deviceCount"].ToString());
            //                break;
            //            case "IsDelete":
            //                deviceModel.IsDelete = Convert.ToBoolean(dr["IsDelete"]);
            //                break;
            //            case "Outbase":
            //                deviceModel.Outbase = Convert.ToInt32(dr["Outbase"].ToString()); 
            //                break;
            //        }
            //    }
            //    deviceList.Add(deviceModel);
            //}

            Repeater2.DataSource = this.GetPage(device);
            Repeater2.DataBind();
        }
        #endregion

        #region 分页方法
        public PagedDataSource GetPage(DataSet ds)
        {
            this.AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = ds.Tables[0].DefaultView;
            //是否启用分页
            pds.AllowPaging = true;
            //当前页是多少页
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            //显示多少条数据
            pds.PageSize = AspNetPager1.PageSize;
            return pds;
        }
        #endregion

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            #region 跳页添加
            Response.Redirect("device.aspx");
            #endregion
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            #region 分页点击
            this.Repeater2GetData();
            #endregion
        }
    }
    
}