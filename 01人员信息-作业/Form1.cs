using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace _01人员信息_作业
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Person> list = new List<Person>();
        private void button1_Click(object sender, EventArgs e)
        {



            //listBox1.Items.Add("张三");


            //0.采集数据
            string name = txtName.Text.Trim();
            int age = Convert.ToInt32(txtAge.Text.Trim());



            //1.把采集到的数据保存到文本文件中
            //创建一个写入文本文件的文件流
            using (StreamWriter writer = new StreamWriter("renyuan.txt", true))
            {
                //执行追加
                writer.WriteLine(string.Format("{0},{1}", name, age));
            }




            //2.把采集到的数据的姓名，显示到ListBox中
            //listBox1.Items.Add(name);
            Person p = new Person();
            p.Name = name;
            p.Age = age;
            listBox1.Items.Add(p);
        }



        //窗体加载的时候读取renyuan.txt文本文件，将其加载到ListBox中
        private void Form1_Load(object sender, EventArgs e)
        {
            //1.读取文本文件
            using (StreamReader reader = new StreamReader("renyuan.txt", Encoding.UTF8))
            {
                //循环读取每一行
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    //只把人员的姓名增加到ListBox中
                    // listBox1.Items.Add(parts[0]);

                    //把每个人的对象（这个人的所有基本信息），增加到ListBox中的某个Item中
                    Person p = new Person();
                    p.Name = parts[0];
                    p.Age = Convert.ToInt32(parts[1]);
                    listBox1.Items.Add(p);
                }
            }


            //2.每读取一行就加载到ListBox中一行
        }

        //ListBox的Item选择项被改变的事件 
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取ListBox当前被选中的项
            Person p = listBox1.SelectedItem as Person;
            if (p != null)
            {
                txtName.Text = p.Name;
                txtAge.Text = p.Age.ToString();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //遍历集合，把集合中的每条数据写入到文本文件中。

        }
    }
}
