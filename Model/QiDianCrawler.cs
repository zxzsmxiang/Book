using NSoup.Nodes;
using NSoup;
using NSoup.Select;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class QiDianCrawler : Crawler
    {
        public QiDianCrawler()
        {
            this.OnCompleted += QiDianCrawler_OnCompleted;
        }

        private void QiDianCrawler_OnCompleted(object sender, OnCompletedEventArgs e)
        {
            Document htmlDoc = NSoupClient.Parse(e.PageSource);
            Elements bookInfos = htmlDoc.GetElementsByClass("book-info");
            var bookInfo = bookInfos[0];
            var h1 = bookInfo.Children.FirstOrDefault(n => n.TagName() == "h1");
            BookValue bookValue = new BookValue();
            bookValue.BookName = h1.GetElementsByTag("em").Text;
            bookValue.BookAuthor = h1.GetElementsByTag("span")[0].GetElementsByTag("a").Text;
            bookValue.BookImage = bookInfo.GetElementsByClass("J-getJumpUrl")[0].Attr("href");
            bookValue.BookSummary = htmlDoc.GetElementsByClass("book-intro")[0].GetElementsByTag("p").Html();

            List<string> bookItems = new List<string>();
            var volumes = htmlDoc.GetElementsByClass("volume");
            foreach (var item in volumes)
            {
                var li = item.GetElementsByClass("cf")[0].GetElementsByTag("li") ;
                foreach (var l in li)
                {
                    bookItems.Add(l.Text());
                }
            }
        }
    }
}
