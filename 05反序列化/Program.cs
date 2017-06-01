using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using _04二进制序列化;

namespace _05反序列化
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 反序列化步骤：

            //1.创建序列化器
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fsRead = File.OpenRead("person.bin"))
            {
                //反序列化的时候，需要创建原来被序列化的类型的对象，所以反序列化的时候需要引用被序列化的类型的对象。正是因为如此，所以在二进制序列化的时候，那些属性名、方法等根本不需要序列化，只需要把那些状态信息（数据→字段的值）序列化了就好了，对于那些方法等信息，在反序列化时，创建对象的时候会自动创建，然后根据序列化文件中的字段的值，进行赋值。这就是烦序列化。
                object obj = bf.Deserialize(fsRead);
                Person p = obj as Person;
                Console.WriteLine(obj.ToString());
                Console.WriteLine(p._height + "    " + p.Name + "   " + p.Email + "   " + p.Age);
                p.SayHello();
                p.SayHi();
            }
            Console.WriteLine("ok");
            Console.ReadKey();



            #endregion
        }
    }
}
