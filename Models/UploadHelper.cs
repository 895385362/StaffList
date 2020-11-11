

using System;
using System.IO;
using System.Linq;
using System.Web;

namespace StaffList
{
    public class UploadHelper
    {
        #region 图片上传方法
        public UploadHelper()
        {

        }

        public static uploadModel Picture(string strName, bool hasFile)
        {
            uploadModel newuploadModel = new uploadModel();
            newuploadModel.state = false;
            newuploadModel.message = "文件名不存在";
            if (!string.IsNullOrEmpty(strName))
            {
                bool fileOK = false;//判断文件是否OK

                int i = strName.LastIndexOf(".");
                string kzm = strName.Substring(i);
                string newName = Guid.NewGuid().ToString();//生成新的文件名，保证唯一性。！！！！！Guid全局唯一标识符 
                string xiangdui = @"\images\";//设置文件相对网站根目录的保存路径，`号表示当前目录，在此表示根目录下的图片文件夹
                string juedui = HttpContext.Current.Server.MapPath("~\\images\\");
                string newFileName = juedui + newName + kzm;//绝对路径+新文件名+后缀名=新文件名称
                if (hasFile)
                {
                    String[] allowedExtensions = { ".gif", ".png", ".bmp", ".jpg", "txt" };
                    if (allowedExtensions.Contains(kzm))
                    {

                        fileOK = true;
                    }

                }
                if (fileOK)
                {
                    try
                    {
                        if (!Directory.Exists(juedui))
                        {
                            Directory.CreateDirectory(juedui);
                        }
                        newuploadModel.newFileName = newFileName;
                        newuploadModel.fileName = xiangdui + newName + kzm;
                        newuploadModel.state = true;
                        newuploadModel.message = "上传成功";
                    }
                    catch (Exception)
                    {
                        newuploadModel.message = "图片上传失败";

                    }
                }
                else
                {
                    newuploadModel.message = "只能够上传图片文件";
                }

            }
            return newuploadModel;
        }
        #endregion
    }
}
