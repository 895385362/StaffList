using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class StaffModel
    {
        public StaffModel() { }
        public int staffID { get; set; }//ID
        public string staffNum { get; set; }//员工号码
        public string staffName { get; set; }//员工姓名
        public string staffAvatar { get; set; }//员工头像
        public int staffSex { get; set; }//员工性别
        public int staffAge { get; set; }//员工年龄
        public string staffMobile { get; set; }//员工账号(手机号)
        public string staffPassword { get; set; }//密码
        public int ProvinceID { get; set; }//省份ID
        public string ProvinceName { get; set; }//省份
        public int CityID { get; set; }//城市ID
        public string CityName { get; set; }//城市
        public int DistrictID { get; set; }//地区ID
        public string DistrictName { get; set; }//地区
        public string Address { get; set; }//详细地址
        public bool IsDelete { get; set; }//状态
    }
}