using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSoup.Nodes;

namespace Model
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://book.qidian.com/info/1006629321";

            var bookContent = new QiDianCrawler();

            bookContent.OnStart += (s, e) =>
            {
                Console.WriteLine("开始:" + e.Uri);
            };
            bookContent.OnError += (s, e) =>
            {
                Console.WriteLine("报错:" + e.Message);
            };

            //bookContent.OnCompleted += (s, e) =>
            //{
            //    Console.WriteLine("抓取完成!");
            //    Console.WriteLine("耗时:"+e.Millseconds);
            //    Console.WriteLine("线程:"+e.ThreadId);
            //    Console.WriteLine("地址:"+e.Uri);

            //};
            bookContent.Start(new Uri(url)).Wait();
            Console.ReadKey();

        }
    }
}
