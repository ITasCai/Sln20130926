using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace _01压缩与解压
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 压缩
            //string source = "1.txt";
            //string target = "yasuo";

            ////压缩
            //Compress(source, target);

            //Console.WriteLine("ok");
            //Console.Read();

            #endregion


            #region 解压

            //string source = "yasuo";

            //string target = "2.txt";

            ////解压
            //DeCompress(source, target);

            //Console.WriteLine("ok");
            //Console.ReadKey();

            #endregion

        }

        //解压
        private static void DeCompress(string source, string target)
        {
            //先调用FileStream读取，读取到的就是压缩后的文件
            using (FileStream fsRead = File.OpenRead(source))
            {

                //创建一个压缩流，根据fsRead将内容解压
                //本来用fsRead读取到的内容是压缩内容，但是通过zip，再读取到的内容就是解压后的内容
                using (GZipStream zip = new GZipStream(fsRead, CompressionMode.Decompress))
                {
                    //要解压写到一个新文件中，所以需要一个写入文件的文件流
                    //创建一个写入文件的文件流
                    using (FileStream fsWrite = File.OpenWrite(target))
                    {
                        //对于这个写入流fsWrite来说，只知道把拿到的内容直接写入到磁盘，并不关心是什么内容
                        byte[] buffers = new byte[1024 * 1024];
                        //注意：读取的时候是通过压缩流来读取，这样读取到的才是解压后的内容
                        int byteCount = zip.Read(buffers, 0, buffers.Length);
                        while (byteCount > 0)
                        {
                            fsWrite.Write(buffers, 0, byteCount);
                            byteCount = zip.Read(buffers, 0, buffers.Length);
                        }
                    }
                }



            }
        }

        //压缩
        private static void Compress(string source, string target)
        {
            //1.读取原文件，读取到的原文件是未经压缩的。\
            using (FileStream fsRead = File.OpenRead(source))
            {
                //2.要将读取到的内容压缩，就是要写入到一个新的文件
                //所以创建一个新的写入文件的文件流
                using (FileStream fsWrite = File.OpenWrite(target))
                {
                    //3.因为在写入的时候要压缩后写入，所以在写入时，需要使用一个压缩流来写入
                    //所以要创建一个压缩流
                    using (GZipStream zip = new GZipStream(fsWrite, CompressionMode.Compress))
                    {
                        //循环读取，每次读取一部分，写入（压缩写入） 一部分
                        byte[] buffers = new byte[1024 * 1024];
                        int byteCount = fsRead.Read(buffers, 0, buffers.Length);
                        while (byteCount > 0)
                        {
                            //写入，用压缩流来写入，这样写入的才是压缩后的
                            zip.Write(buffers, 0, byteCount);
                            byteCount = fsRead.Read(buffers, 0, buffers.Length);
                        }
                    }
                }
            }
        }
    }
}
