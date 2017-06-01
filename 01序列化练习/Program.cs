using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace _01序列化练习
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>() { "上次吃饭的钱啥时候给我？", "不给也没关系", "反正去年我也没给你饭钱。" };


            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fsWrite = File.OpenWrite("words.bin"))
            {
                bf.Serialize(fsWrite, list);
            }
            Console.WriteLine("ok");
            Console.ReadKey();

        }
    }
}
