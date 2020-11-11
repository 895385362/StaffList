using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StaffList
{
    public partial class StaffList : BasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            #region 页面加载
            if (!IsPostBack)
            {
                RepeaterGetData();
            }
            #endregion
        }

            #region 将查询到的数据用Repeater控件显示
        private void RepeaterGetData(string sql="")
        {
            if (string.IsNullOrEmpty(sql))
            {
                sql = "select * from dbo.Info_staff";
            }
            DataSet ds = OperareBase.getData(sql);

            #region (三层不用控件时用这个方法)
            List<StaffModel> staffList = new List<StaffModel>();
            //循环行
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                StaffModel staffModel = new StaffModel();
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    switch (dc.ColumnName)
                    {
                        case "staffID":
                            staffModel.staffID = Convert.ToInt32(dr["staffID"].ToString());
                            break;
                        case "staffNum":
                            staffModel.staffNum = dr["staffNum"].ToString();
                            break;
                        case "staffName":
                            staffModel.staffName = dr["staffName"].ToString();
                            break;
                        case "staffAvatar":
                            staffModel.staffAvatar = dr["staffAvatar"].ToString();
                            break;
                        case "staffSex":
                            staffModel.staffSex = Convert.ToInt32(dr["staffSex"].ToString());
                            break;
                        case "staffAge":
                            staffModel.staffAge = Convert.ToInt32(dr["staffAge"].ToString());
                            break;
                        case "staffMobile":
                            staffModel.staffMobile = dr["staffMobile"].ToString();
                            break;
                        case "staffPassword":
                            staffModel.staffPassword = dr["staffPassword"].ToString();
                            break;
                        case "ProvinceID":
                            staffModel.ProvinceID = Convert.ToInt32(dr["ProvinceID"].ToString());
                            break;
                        case "ProvinceName":
                            staffModel.ProvinceName = dr["ProvinceName"].ToString();
                            break;
                        case "CityID":
                            staffModel.CityID = Convert.ToInt32(dr["CityID"].ToString());
                            break;
                        case "CityName":
                            staffModel.CityName = dr["CityName"].ToString();
                            break;
                        case "DistrictID":
                            staffModel.DistrictID = Convert.ToInt32(dr["DistrictID"].ToString());
                            break;
                        case "DistrictName":
                            staffModel.DistrictName = dr["DistrictName"].ToString();
                            break;
                        case "Address":
                            staffModel.Address = dr["Address"].ToString();
                            break;
                        case "IsDelete":
                            staffModel.IsDelete = Convert.ToBoolean(dr["IsDelete"]);
                            break;
                    }
                }
                staffList.Add(staffModel);
            }
            #endregion
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
        #endregion

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            #region 操作(根据ID删除，跳页修改)
            int StaffID_Value = Convert.ToInt32(((HiddenField)e.Item.FindControl("HiddenField1")).Value);
            if (StaffID_Value>0)
            {
                //当LinkButton的CommandName为Delete时进行删除操作
                if (e.CommandName == "Delete")
                {
                    String update = "update dbo.Info_staff set IsDelete = 1 where staffID = " + StaffID_Value + "";
                    int flag = OperareBase.CommanBySql(update);
                    if (flag > 0)
                    {
                        Response.Write("成功删除:" + flag + "条数据)");
                        RepeaterGetData("select * from dbo.Info_staff where IsDelete = 0 ");
                    }
                }
                //当LinkButton的CommandName为Edit时跳转到修改页面并传递该数据ID
                if (e.CommandName == "Edit")
                {
                    Response.Redirect("StaffModify.aspx?staffID=" + StaffID_Value + "");
                }
            }
            else
            {
                Response.Write("未获取到ID");
            }
            #endregion
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            #region 更新(点击添加按钮时跳页添加)
            Response.Redirect("StaffModify.aspx");
            #endregion
        }

        protected void Seach_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 当前列表进行下拉选择查看已删除、删除的数据
            String IsDelete_value = Seach.SelectedValue;
            if (!string.IsNullOrEmpty(IsDelete_value))
            {
                RepeaterGetData("select * from dbo.Info_staff where IsDelete = " + IsDelete_value + " ");
            }
            else
            {
                RepeaterGetData("select * from dbo.Info_staff ");
            }
            #endregion
        }
    }
}