using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace _02反序列化
{
    class Program
    {
        static void Main(string[] args)
        {
            //反序列化
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fsRead = File.OpenRead("words.bin"))
            {
                object obj = bf.Deserialize(fsRead);
                List<string> list = obj as List<string>;
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadKey();

        }
    }
}
