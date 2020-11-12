using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class uploadModel
    {
        public uploadModel() { }
        public string newFileName { get; set; }//绝对路径用来上传图片
        public string fileName { get; set; }//相对路径
        public string message { get; set; }//错误信息
        public bool state { get; set; }//状态
    }
}