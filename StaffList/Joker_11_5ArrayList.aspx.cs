using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StaffList
{
    public partial class Joker_11_5ArrayList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////添加元素
            //ArrayList List = new ArrayList();
            //int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ////实例化
            //ArrayList list = new ArrayList(arr);
            ////把数组放进去转换为ArrayList集合
            //ArrayList list2 = new ArrayList(arr);
            ////用指定大小初始化内部的数组。构造器格式如下

            ////手动添加
            //ArrayList list3 = new ArrayList();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    list3.Add(arr[i]);
            //}

            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
            ArrayList List = new ArrayList(arr);
            Console.WriteLine("原ArrayList集合");

            for (int i = 1; i < 6; i++)
            {
                List.Add(i + arr.Length);
            }
            Console.WriteLine("使用Add方法添加");
            //Add末尾添加值
            List.Add(7);
            ////Insert 索引位 添加值
            //List.Insert(5, 8);
            ////删除所有元素为3的
            //List.Remove(3);
            ////删除索引位为3的
            //List.RemoveAt(3);
            ////删除从索引位为3开始的两个元素
            //List.RemoveRange(3, 2);
            ////清除全部
            //List.Clear();
            //Contains方法：用来确定元素是否在ArrayList集合中
            string[] arr2 = new string[] { "2", "2", "3", "33" };
            ArrayList List2 = new ArrayList(arr2);
            int sa = List2.IndexOf("2");
            int sa2 = List.LastIndexOf(3);
        }
    }
}