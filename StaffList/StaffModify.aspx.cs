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
    public partial class StaffModify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 页面加载事件
            if (!IsPostBack)
            {
                getProlist();
                //判断是否取到了浏览器上的传值 取到了是更新 更新的时候需要先给文本框赋值
                var StaffID_Value =Request["staffID"];
                if (!String.IsNullOrEmpty(StaffID_Value))
                {
                    GetStaffDetail();
                }
            }
            #endregion
        }

        protected void ddlProlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 下拉框调用三联动方法
            getCitylist();
            #endregion
        }

        protected void ddlCitylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 下拉框调用三联动方法
            getDislist();
            #endregion
        }


        #region 如果是更新 查询并向文本框赋值
        public void GetStaffDetail()
        {
            var StaffID_Value = Request["staffID"];
            if (!String.IsNullOrEmpty(StaffID_Value))
            {
                DataSet StaffListByStaffID_Ds = OperareBase.getData("select * from Info_staff where staffID=" + StaffID_Value + "");
                //判断 容器中的数据条数是否 >0 大于0代表根据 StaffID查询到了数据 
                //Tables[0]第一张表  Rows[0]第一行 [""]代表第一行里的哪一个字段
                if (StaffListByStaffID_Ds.Tables[0].Rows.Count > 0)
                {
                    StaffID.Value = StaffListByStaffID_Ds.Tables[0].Rows[0]["staffID"].ToString();
                    StaffAvatarImg.ImageUrl = StaffListByStaffID_Ds.Tables[0].Rows[0]["staffAvatar"].ToString();
                    staffNum.Text = StaffListByStaffID_Ds.Tables[0].Rows[0]["staffNum"].ToString();
                    staffName.Text = StaffListByStaffID_Ds.Tables[0].Rows[0]["staffName"].ToString();
                    Sex_tb.SelectedValue = StaffListByStaffID_Ds.Tables[0].Rows[0]["staffSex"].ToString();
                    staffAge.Text = StaffListByStaffID_Ds.Tables[0].Rows[0]["staffAge"].ToString();
                    staffMobile.Text = StaffListByStaffID_Ds.Tables[0].Rows[0]["staffMobile"].ToString();
                    staffPassword.Text = StaffListByStaffID_Ds.Tables[0].Rows[0]["staffPassword"].ToString();
                    ddlProlist.SelectedValue = StaffListByStaffID_Ds.Tables[0].Rows[0]["ProvinceID"].ToString();
                    if (ddlCitylist.SelectedValue == "0")
                    {
                        ddlProlist_SelectedIndexChanged(null, null);
                    }
                    ddlCitylist.SelectedValue = StaffListByStaffID_Ds.Tables[0].Rows[0]["CityID"].ToString();
                    if (ddlCitylist.SelectedValue != "0")
                    {
                        ddlCitylist_SelectedIndexChanged(null, null);
                    }
                    ddlDislist.SelectedValue = StaffListByStaffID_Ds.Tables[0].Rows[0]["DistrictID"].ToString();
                    Address.Text = StaffListByStaffID_Ds.Tables[0].Rows[0]["Address"].ToString();
                }
            }
        }
        #endregion

        

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            #region 图片上传
            Label11.Text = "";
            String strName = FileUpload1.PostedFile.FileName;
            uploadModel newuploadModel = new uploadModel();//实例化实体
            newuploadModel = UploadHelper.Picture(strName, FileUpload1.HasFile);
            if (newuploadModel.state)
            {
                try
                {
                    FileUpload1.PostedFile.SaveAs(newuploadModel.newFileName);
                    StaffAvatarImg.ImageUrl = newuploadModel.fileName;
                    Label11.Text = newuploadModel.message;
                }
                catch (Exception)
                {
                    Label11.Text = newuploadModel.message;
                }

            }
            else
            {
                Label11.Text = newuploadModel.message;
            }
            #endregion
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                #region 取值
                var StaffID_Value = Request["staffID"];
                var StaffAvatar_Url = StaffAvatarImg.ImageUrl;//图片路径
                var StaffNum = staffNum.Text.Trim();//工号
                var StaffName = staffName.Text.Trim();// 姓名
                var Sex_Value = Sex_tb.SelectedValue;//性别
                int StaffAge =  Convert.ToInt32(staffAge.Text.Trim());//年龄
                var StaffMobile = staffMobile.Text.Trim();//手机号
                var StaffPassword = staffPassword.Text.Trim();//密码
                var address = Address.Text.Trim();//详细地址
                #endregion

                #region 判空
                Label6.Text = "";
                Label7.Text = "";
                Label10.Text = "";
                Label13.Text = "";

                if (string.IsNullOrEmpty(StaffNum))
                {
                    Label6.Text = "工号不可为空.";
                    Label6.ForeColor = Color.Red;
                    return;
                }
                else if (string.IsNullOrEmpty(StaffName))
                {
                    Label7.Text = "员工姓名不可为空.";
                    Label7.ForeColor = Color.Red;
                    return;
                }
                else if (string.IsNullOrEmpty(StaffMobile))
                {
                    Label10.Text = "手机号不可为空.";
                    Label10.ForeColor = Color.Red;
                    return;
                }
                else if (string.IsNullOrEmpty(StaffPassword))
                {
                    Label13.Text = "密码不可为空.";
                    Label13.ForeColor = Color.Red;
                    return;
                }
                //代表数据都通过了
                else
                {
                    Label6.Text = "√";
                    Label6.ForeColor = Color.Green;
                    Label7.Text = "√";
                    Label7.ForeColor = Color.Green;
                    Label10.Text = "√";
                    Label10.ForeColor = Color.Green;
                    Label13.Text = "√";
                    Label13.ForeColor = Color.Green;
                }
                #endregion

                #region 更新、添加
                //定义一个参数用于判断是添加还是更新 false 代表是添加 true 代表是更新
                bool ConfirmStatus = false;
                var Sql = string.Empty;
                //根据隐藏控件里的ID判断数据 
                //!=0 也就是不能与默认值时 代表  有数据， 即代表  更新
                if (StaffID_Value != "0")
                {
                    //根据ID 校验数据
                    #region 校验数据
                    DataSet StaffDetailByStaffID = OperareBase.getData("select * from Info_staff where staffID='" + StaffID_Value + "' and IsDelete=0");
                    //判断我是否有数据 根据ID查询 有数据的时候
                    if (StaffDetailByStaffID.Tables[0].Rows.Count > 0)
                    {
                        #region 工号不是我自己的工号
                        //工号不是我自己的工号
                        if (StaffNum != StaffDetailByStaffID.Tables[0].Rows[0]["staffNum"].ToString())
                        {
                            bool IsRepeatValue = IsRepeat(StaffNum, "");
                            if (!IsRepeatValue)
                                return;
                        }
                        #endregion

                        #region 手机号不是我自己的手机号
                        //手机号不是我自己的手机号
                        if (StaffMobile != StaffDetailByStaffID.Tables[0].Rows[0]["staffMobile"].ToString())
                        {
                            //手机号查询存不存在数据库中
                            bool IsRepeatValue = IsRepeat("", StaffMobile);
                            if (!IsRepeatValue)
                                return;
                        }
                        #endregion
                    }
                    else
                    {
                        Response.Write("数据异常，未查询到数据");
                        Response.End(); //类似return
                    }
                    #endregion

                    Sql = "update Info_staff set staffNum = '" + StaffNum + "',staffName='" + StaffName + "',staffAvatar='" + StaffAvatar_Url + "',staffSex=" + Sex_Value + ",staffAge=" + StaffAge + ",staffMobile='" + StaffMobile + "',staffPassword='" + StaffPassword + "',ProvinceName='" + (ddlProlist.SelectedValue == "0" ? "" : ddlProlist.SelectedItem.Text) + "',ProvinceID = " + ddlProlist.SelectedValue + ",CityName = '" + (ddlCitylist.SelectedValue == "0" ? "" : ddlCitylist.SelectedItem.Text) + "',CityID = " + ddlCitylist.SelectedValue + ",DistrictName='" + (ddlDislist.SelectedValue == "0" ? "" : ddlDislist.SelectedItem.Text) + "',DistrictID=" + ddlDislist.SelectedValue + ",Address = '"+address+"'where staffID='" + StaffID_Value+"'";
                    ConfirmStatus = true;//更新
                }
                //反之 添加
                else
                {
                    bool IsRepeatValue = IsRepeat(StaffNum, StaffMobile);
                    if (!IsRepeatValue)
                        return;
                    Sql = "insert into Info_staff (staffNum,staffName,staffAvatar,staffSex,staffAge,staffMobile,staffPassword,ProvinceName,ProvinceID,CityName, CityID,DistrictName,DistrictID,Address) Values('" + StaffNum + "','" + StaffName + "','" + StaffAvatarImg.ImageUrl + "'," + Sex_Value + " ," + StaffAge + ",'" + StaffMobile + "','" + StaffPassword + "','" + (ddlProlist.SelectedValue == "0" ? "" : ddlProlist.SelectedItem.Text) + "'," + ddlProlist.SelectedValue + ",'" + (ddlCitylist.SelectedValue == "0" ? "" : ddlCitylist.SelectedItem.Text) + "'," + ddlCitylist.SelectedValue + ",'" + (ddlDislist.SelectedValue == "0" ? "" : ddlDislist.Text) + "'," + ddlDislist.SelectedValue + ",'" + address + "')";
                    ConfirmStatus = false;//添加
                }

                if (!string.IsNullOrEmpty(Sql))
                {
                    //调用方法执行
                    int Result = OperareBase.CommanBySql(Sql);
                    string StatusText = ConfirmStatus == false ? "添加" : "更新";
                    if (Result > 0)
                    {
                        status.Text = StatusText + "成功.";
                        Response.Redirect("StaffList.aspx");
                    }
                    else
                        status.Text = StatusText + "失败.";
                }
                #endregion
            }
            catch (Exception ex)
            {
                #region 错误信息
                Response.Write(ex.Message);
                #endregion
            }
        }

        #region 三联动绑值

        private void getProlist(string sql ="")
        {
            if (string.IsNullOrEmpty(sql))
            { 
                sql = "select * from dbo.S_Province";
                DataSet ds = OperareBase.getData(sql);
                // 绑定下拉框
                ddlProlist.DataSource = ds;
                //绑定下拉框文字
                ddlProlist.DataTextField = "ProvinceName";
                //绑定下拉框值
                ddlProlist.DataValueField = "ProvinceID";
                ddlProlist.DataBind();
                ddlProlist.Items.Insert(0, new ListItem("请选择省份", "0"));
            }
        }

        private void getCitylist()
        {
            string ProvinceID = ddlProlist.SelectedValue;
            string sql = "select * from dbo.S_City where ProvinceID=" + ProvinceID + "";
            DataSet ds = OperareBase.getData(sql);
            ddlCitylist.DataSource = ds;
            ddlCitylist.DataTextField = "CityName";
            ddlCitylist.DataValueField = "CityID";
            ddlCitylist.DataBind();
            ddlCitylist.Items.Insert(0, new ListItem("请选择城市", "0"));
            ddlDislist.Items.Clear();
            ddlDislist.Items.Insert(0, new ListItem("请选择区/县", "0"));

        }

        private void getDislist()
        {
            string CityID = ddlCitylist.SelectedValue;
            string sql = "select * from dbo.S_District where CityID = " + CityID + "";
            DataSet ds = OperareBase.getData(sql);
            ddlDislist.DataSource = ds;
            ddlDislist.DataTextField = "DistrictName";
            ddlDislist.DataValueField = "DistrictID";
            ddlDislist.DataBind();
            ddlDislist.Items.Insert(0, new ListItem("请选择区/县", "0"));
        }
        #endregion

        #region 判断重复
        public bool IsRepeat(string StaffNum, string StaffMobile)
        {
            bool Result = true;
            Label6.Text = "";
            Label10.Text = "";
            if (!string.IsNullOrEmpty(StaffNum))
            {
                //查询工号不存在数据库中
                //判断重复
                DataSet StaffListByStudentNum = OperareBase.getData("select * from Info_staff where staffNum='" + StaffNum + "'");
                if (StaffListByStudentNum.Tables[0].Rows.Count > 0)
                {
                    Label6.Text = "工号不可重复";
                    Label6.ForeColor = Color.Green;
                    Result = false;
                }
            }

            if (!string.IsNullOrEmpty(StaffMobile))
            {
                //查询手机号存不存在数据库中
                DataSet StaffListByMobile = OperareBase.getData("select * from Info_staff where staffMobile='" + StaffMobile + "'");
                if (StaffListByMobile.Tables[0].Rows.Count > 0)
                {
                    Label10.Text = "手机号不可重复";
                    Label10.ForeColor = Color.Green;
                    Result = false;
                }
            }
            return Result;
        }
        #endregion
    }
}