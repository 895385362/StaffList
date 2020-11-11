using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaffList
{
    public class DeviceModel
    {
        public DeviceModel() { }
        public int deviceID { get; set; }//ID
        public string deviceNum { get; set; }//设备号码
        public int deviceCount { get; set; }//设备数量
        public bool IsDelete { get; set; }//状态
        public int Outbase { get; set; }//设备数量
    }
}