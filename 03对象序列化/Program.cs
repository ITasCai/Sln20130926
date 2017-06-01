using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _03对象序列化
{
    class Program
    {
        static void Main(string[] args)
        {

            //序列化，就是把一个对象转换成另外一种格式的过程，转换成不同的格式就叫做不同的序列化，比如xml格式，叫做xml序列化。JavaScript的json格式，叫做JavaScript序列化。转换成二进制byte[]字节，叫做二进制序列化。

            //序列化质序列化那些属性（或者说是序列化了对象中的状态信息（字段、属性就是用来存储状态的）），而方法并没有序列化。

            //序列化后的目的，是为了把数据以另外一种格式来表示，方便存储与交换数据，所以序列化只序列化那些存储数据的成员，一般就是属性，不会序列化方法的。


            //有序列化，就有反序列化


            #region 对象序列化


            //=1=================================================
            List<Person> list = new List<Person>();
            list.Add(new Person() { Name = "余尚勇", Age = 19, Email = "ysh@yahoo.com" });
            list.Add(new Person() { Name = "宋文斌", Age = 29, Email = "swb@yahoo.com" });
            list.Add(new Person() { Name = "闫刘盘", Age = 16, Email = "ylp@yahoo.com" });




            ////二进制序列化
            //BinaryFormatter bf = new BinaryFormatter();
            //using (FileStream fsWrite = File.OpenWrite("list.bin"))
            //{
            //    bf.Serialize(fsWrite, list);
            //    //bf.Deserialize();//反序列化
            //}

            //Console.WriteLine("ok");
            //Console.ReadKey();










            ////xml序列化
            ////XmlSerializer xmlSerializer = new XmlSerializer(list.GetType());
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            //using (FileStream fsWrite = File.OpenWrite("list.xml"))
            //{
            //    xmlSerializer.Serialize(fsWrite, list);
            //    //xmlSerializer.Deserialize();//反序列化
            //}
            //Console.WriteLine("ok");
            //Console.ReadKey();







            ////使用JavaScript 序列化。
            //JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            //string str = jsSerializer.Serialize(list);
            ////jsSerializer.Deserialize();//反序列化
            //File.WriteAllText("list.txt", str);
            //Console.WriteLine(str);
            //Console.ReadKey();


            #endregion
        }
    }
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }


        public void SayHi()
        {
            Console.WriteLine("大家好，我叫：{0}", Name);
        }
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
}
