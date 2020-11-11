using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StaffList
{
    public partial class excersize : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //    Label1.Text = ("比较两个字符串相等：" + string.Equals("abc", "abc").ToString());

            //    DateTime dt = DateTime.Now;
            //    Label3.Text = string.Format("{0:D}", dt);
            //    Label2.Text = dt.ToString();

            //string strA = "C#<从基础>到实战";
            //string[] splitstrings = strA.Split('<', '>');
            //if (splitstrings.Length>0)
            //{
            //    for (int i = 0; i < splitstrings.Length; i++)
            //    {
            //        Console.Write(splitstrings[i]);
            //    }
            //    Label1.Text = "第0项" + splitstrings[0];
            //    Label2.Text = "第1项" + splitstrings[1];
            //    Label3.Text = "第2项" + splitstrings[2];
            //}

            //string str1 = "编程";
            //string str2;
            //str2 = str1.Insert(0, "C#");
            //string str3 = str2.Insert(4,"词典");

            //string str1 = "*^_^*)";
            //string str2 = str1.PadLeft(7, '(');
            //string str3 = str2.PadRight(8, ')');
            //Label1.Text = "补充字符串之前：" + str1;
            //Label2.Text = "补充字符串之后：" + str3;

            //string str1 = "*^_^*)";
            //string str2 = str1.Remove(5);
            //string str3 = str1.Remove(5,1);
            //Label1.Text = str2;
            //Label2.Text = str3;

            //string strA = "纯JBNT";
            //string strB = string.Copy(strA);
            //Label1.Text = strB;

            //string str = "*^_^*";
            //char[] myChar = new char[100];
            //str.CopyTo(2, myChar, 0, 1);
            //Label1.Text = myChar[0].ToString();

            //string strA = "one world,onedream";
            //string strB = strA.Replace(',', '*');
            //Label1.Text = strB;
            //string strC = strA.Replace("one world", "One World");
            //Label2.Text = strC;

            //StringBuilder builderA = new StringBuilder("one world,one dream");
            //Label2.Text = builderA.Append("C#编程词典").ToString();
            //int num = 368;
            //builderA.Append("》C#编程词典");
            //builderA.AppendFormat("{0:C}", num);
            //builderA.Insert(0, "软件");
            //builderA.Remove(14, builderA.Length - 14);
            //builderA.Replace("软件", "软件工程师必备");


            #region 一维数组
            //type[] arratName
            //type: 数组存储数据的数据类型
            //arrayName 数组名称
            //int[] arr = new int[5] {0,1,2,3,4};
            //arr[0] = 1;
            //arr[1] = 2;
            //arr[2] = 3;
            //int[] arraylist = {1, 2, 3, 4, 5};
            //string[] arrStr = { "Sun","Mon","Tue","Wed","Thu","Fri","Sat" };

            //string text = "";
            //for (int i = 0; i < arrStr.Length; i++)
            //{
            //    text += "第" + (i + 1) + "项值" + arrStr[i];
            //}

            ////Label1.Text = text;

            //foreach (var item in arrStr)
            //{
            //    Label1.Text += item;
            //}
            #endregion

            #region 二维数组
            //int[,] arr = new int[2, 2] { { 1, 2 }, { 3, 4 } };
            //int[,] arr2 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };

            //Console.Write("数组的行数为:");
            //Console.Write(arr.GetLength(0));//获得数组的行数
            //Console.Write("数组的列数为:");
            //Console.Write(arr.GetLength(1));//获得数组的列数

            //string str = "";

            //for (int i = 0; i < arr2.GetLength(0); i++)
            //{
            //    for (int j = 0; j < arr.GetLength(1); j++)
            //    {
            //        str = Convert.ToString(arr[i, j] + "");
            //    }
            //}
            //Label1.Text = arr2[0,1].ToString();

            //cells行
            //
            //int[][] cells = { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 }, new int[] { 10, 11, 12 } };
            //for (int i = 0; i < cells.Length; i++)
            //{
            //    string sa = "<br/>第" + (i+1) + "行共有"+cells[i].Length+"个数<br/>";
            //    string zhi = "";
            //    foreach (int a in cells[i])
            //    {
            //        zhi += ("值:"+a.ToString()+"&nbsp;");
            //    }
            //    Label1.Text += sa + zhi;
            //}


            #endregion

            #region 一维数组合并
            //int[] arr1 = { 1, 2, 3, 4, 5 };
            //int[] arr2 = { 6, 7, 8, 9, 10 };
            //int n = arr1.Length + arr2.Length;
            //int[] arr3 = new int[n];
            //string sa = "";
            //for (int i = 0; i<arr3.Length; i++)
            //{
            //    if (i<arr1.Length)
            //    {
            //        arr3[i] = arr1[i];
            //    }
            //    else
            //    {
            //        arr3[i] = arr2[i - arr1.Length];
            //    }
            //    sa += arr3[i].ToString();
            //}
            //Label1.Text = ("合并后的一维数组:" + sa);
            #endregion

            #region 二维数组拆分
            //int[,] arr1 = new int[2,3]
            //{
            //    {1,3,5 },
            //    {2,4,6 }
            //};
            //int[] arr2 = new int[3];
            //int[] arr3 = new int[3];
            //for (int i = 0; i < 2; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        switch (i)
            //        {
            //            case 0:
            //                arr2[j] = arr1[0, j];
            //                break;
            //            case 1:
            //                arr3[j] = arr1[1, j];
            //                break;
            //        }
            //    }
            //}
            #endregion

        }
    }
}