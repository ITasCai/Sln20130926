using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace _04二进制序列化
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 二进制序列化


            Person person = new Person();
            person.Name = "张三";
            person.Age = 19;
            person.Email = "zhangsan@yahoo.com";
            person.MyCar = new Car() { Brand = "时风" };

            //二进制序列化步骤：
            //1.创建二进制序列化器
            BinaryFormatter bf = new BinaryFormatter();
            //我们希望将对象序列化到一个文件上，所以要创建一个文件流
            using (FileStream fsWrite = File.OpenWrite("person.bin"))
            {
                //开始执行二进制序列化
                bf.Serialize(fsWrite, person);
            }
            Console.WriteLine("序列化完毕！");
            Console.ReadKey();


            //二进制序列化要求：
            //1.被序列化的对象的类型必须标记为可序列化的。
            //2.二进制序列化会把属性对应的字段序列化到文件中，所以最好类型中不要使用自动属性（编译器会自动生成字段），而要自己写属性与字段
            //3.当序列化一个对象的时候，这个对象本身以及的所有父类都必须标记为可序列化的。\
            //4.类型中所有属性与字段的类型必须也标记为可序列化的。接口不需要。
            //5.通过[NonSerialized]把某个字段标记为不可序列化的。




            #endregion
        }
    }

    [Serializable]
    public class Car
    {
        private string _brand;

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }
    }



    [Serializable]
    public class Animal
    {

    }


    [Serializable] //特性，当为某个类加了该特性后，这个类就标记为了可序列化的了。
    public class Person : Animal
    {

        private Car _myCar;

        public Car MyCar
        {
            get { return _myCar; }
            set { _myCar = value; }
        }

        //[NonSerialized]//当前这个字段就不会被序列化了。
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }



        //[NonSerialized]
        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        //[NonSerialized]
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }




        private string _gender = "男";
        public int _height = 180;


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
