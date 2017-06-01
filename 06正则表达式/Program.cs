using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _06正则表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.正则表达式是对字符串的操作

            //2.正则表达式是一个用来描述字符串特征的表达式。
            //特征：必须出现的内容、可能出现的内容、不能出现的内容。


            //观察字符串规律，根据规律总结特征，然后根据特定字符串的特征来编写正则表达式。


            #region >10 and <=20 的所有数字字符串

            //Regex.IsMatch(); //判断是否匹配
            //Regex.Match();//提取某个（一个）匹配
            //Regex.Matches();//提取所有的匹配
            //Regex.Replace();//替换
            //Regex.Split();//分割






            ////1.写正则表达式第一步，观察字符串找规律，根据规律写正则

            //while (true)
            //{
            //    Console.WriteLine("请输入");
            //    string msg = Console.ReadLine();
            //    bool b = Regex.IsMatch(msg, "^(1[1-9]|20)$");
            //    Console.WriteLine(b);
            //}


            //===========================================================
            //while (true)
            //{
            //    Console.WriteLine("请输入");
            //    int n = Convert.ToInt32(Console.ReadLine());
            //    if (n>10 && n<=20)
            //    {
            //        Console.WriteLine("ok");
            //    }
            //    else
            //    {
            //        Console.WriteLine("输入不合法！！");
            //    }
            //}

            #endregion


            #region 正则案例

            //while (true)
            //{
            //    Console.WriteLine("请输入：");
            //    string msg = Console.ReadLine();

            //    //IsMatch()这个函数验证指定的字符串是否匹配指定的正则表达式，但是注意：
            //    //默认情况下，如果在整个字符串中只要有一部分匹配给定的字符串则返回true

            //    //要想验证完全匹配6位数字，则必须在正则表达式两端加开始^和结束$
            //    //一般情况下，当调用IsMatch()函数的时候都希望是完全匹配，所以在写正则的时候两边都要加^与$
            //    bool b=Regex.IsMatch(msg, "^[0-9]{6}$");

            //    // bool b=Regex.IsMatch(msg, "[0-9]{6}");
            //    Console.WriteLine(b);
            //}




            //while (true)
            //{
            //    Console.WriteLine("请输入");
            //    string msg = Console.ReadLine();
            //    //1. 这个正则表达式本身只匹配z或food
            //    //2. 但是由于正则两端没有加^和$，所以整个给定字符串中只要有任何一个部分与字符串z或food匹配，则返回true
            //    bool b = Regex.IsMatch(msg, "z|food");
            //    Console.WriteLine(b);
            //}




            //while (true)
            //{
            //    Console.WriteLine("请输入");
            //    string msg = Console.ReadLine();

            //    //因为这个正则表达式使用了|字符，所以该正则表达式
            //    //的意思是：^z  或  food$
            //    //即：所有以z开头的字符串  或者  所有以 food结尾的字符串。
            //    bool b = Regex.IsMatch(msg, "^z|food$");
            //    Console.WriteLine(b);
            //}





            //while (true)
            //{
            //    Console.WriteLine("请输入");
            //    string msg = Console.ReadLine();

            //    //  ^z$

            //    //  ^food$
            //    //所以这个正则表达式只能匹配 一个字母  z  或者一个单词 food
            //    bool b = Regex.IsMatch(msg, "^(z|food)$");
            //    Console.WriteLine(b);
            //}




            //while (true)
            //{
            //    Console.WriteLine("请输入");
            //    string msg = Console.ReadLine();
            //    //zood   food
            //    bool b = Regex.IsMatch(msg, "^(z|f)ood$");
            //    Console.WriteLine(b);
            //}


            //while (true)
            //{
            //    Console.WriteLine("请输入");
            //    string msg = Console.ReadLine();
            //    //这个只能匹配  字母 z 或者 单词 food
            //    //这个正则表达式等价于  ^(z|food)$
            //    bool b = Regex.IsMatch(msg, "(^z$)|(^food$)");
            //    Console.WriteLine(b);
            //}




            //while (true)
            //{
            //    Console.WriteLine("请输入邮政编码");
            //    string postcode = Console.ReadLine();
            //    //bool b = Regex.IsMatch(postcode, "^[0-9]{6}$");
            //    //bool b = Regex.IsMatch(postcode, "^\\d{6}$");

            //    //默认.net采用的是unicode字符匹配，所以中文的１２３４５６也是匹配的。
            //    //bool b = Regex.IsMatch(postcode, @"^\d{6}$");

            //    //指定RegexOptions.ECMAScript选项后，\d就只表示普通的数字，不在包含全角的字符了。
            //    bool b = Regex.IsMatch(postcode, @"^\d{6}$", RegexOptions.ECMAScript);

            //    Console.WriteLine(b);
            //}




            #endregion

            #region 验证身份证号码的正则表达式

            //while (true)
            //{
            //    Console.WriteLine("请输入");
            //    string id = Console.ReadLine();
            //    //bool b = Regex.IsMatch(id, "^([0-9]{15}|[0-9]{17}[0-9xX])$");
            //    //bool b = Regex.IsMatch(id, "^[0-9]{15}$|^[0-9]{17}[0-9xX]$");
            //    bool b = Regex.IsMatch(id, "^[0-9]{15}([0-9]{2}[0-9xX])?$");
            //    Console.WriteLine(b);
            //}
            #endregion


            #region 电话号码

            //while (true)
            //{
            //    Console.WriteLine("请输入");
            //    string phoneNumber = Console.ReadLine();
            //    bool b = Regex.IsMatch(phoneNumber, @"^(\d{3,4}\-?\d{7,8}|\d{5})$", RegexOptions.ECMAScript); 
            //    Console.WriteLine(b);
            //}
            #endregion



            #region 验证是否是合法的邮件地址
            //Console.WriteLine(Regex.IsMatch(email, "^a[x.]b$"));
            while (true)
            {

                //www.china-open.com
                //    .com.cn
                //    .com
                //    .163.com



                Console.WriteLine("请输入邮箱:");
                string email = Console.ReadLine();
                //fdsa    @   fdsafd  .com.cn
                //.出现在[]中，就表示一个普通的.可以不转义。
                //-出现在[]中的第一个位置的时候可以不转义。
                //bool b = Regex.IsMatch(email, @"^[-a-zA-Z0-9._]+@[-0-9a-zA-Z]+(\.[a-zA-Z0-9]+){1,}$");

                bool b = Regex.IsMatch(email, @"^\w+@\w+(\.\w+){1,}$", RegexOptions.ECMAScript);
                Console.WriteLine(b);
            }


            #endregion
        }
    }
}
