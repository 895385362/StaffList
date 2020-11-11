using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaffList
{
    public class OrderModel
    {
        public OrderModel() { }
        public int orderID { get; set; }//订单ID
        public string orderNum { get; set; }//订单号码
        public string orderDate { get; set; }//订单日期
        public string staffID { get; set; }//员工ID
        public string deviceID { get; set; }//设备ID
        public int Count { get; set; }//订单数量
        public bool IsDelete { get; set; }//状态
    }
}