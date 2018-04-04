using Model;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NSoup;
using NSoup.Nodes;
using NSoup.Select;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrawlerWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Crawler_OnCompleted(object sender, OnCompletedEventArgs e)
        {

        }


        private void btnQDRead_Click(object sender, EventArgs e)
        {
            text.Text = string.Empty;
            webBrowser.Navigate(txtQDUrl.Text);
            timerBrower.Start();
            // webBrowser1.Navigate(txtQDUrl.Text);

        }
        TextBox text = new TextBox();
        private void timerBrower_Tick(object sender, EventArgs e)
        {
            if (webBrowser.StatusText == "完成")
            {

                timerBrower.Enabled = false;
                text.Text += webBrowser.Document.Body.OuterHtml;
                //QiDianCraw(text.Text);
                //页面加载完成,做一些其它的事
                //webBrowser1.DocumentText 注意不要用这个，这个和查看源文件一样的
            }
        }

        private void btnBQG_Click(object sender, EventArgs e)
        {
            BiQuGe(webBrowser.Document.Body.OuterHtml);
        }

        private void BiQuGe(string pageSource)
        {
            Document htmlDoc = NSoupClient.Parse(pageSource);

            var bookInfo = htmlDoc.GetElementById("info");
            var h1 = htmlDoc.GetElementById("info").GetElementsByTag("h1").Html();
            lblBookName.Text = bookInfo.GetElementsByTag("h1").Html();

            String author = bookInfo.GetElementsByTag("p")[0].Html();

            lblAuthor.Text = author.Split(new char[] { ':', '：' }, StringSplitOptions.RemoveEmptyEntries)[1];

            var imageUrl = htmlDoc.GetElementById("fmimg").GetElementsByTag("img").Attr("src");
            System.Net.WebRequest webreq = System.Net.WebRequest.Create("http://www.biquge.com.tw" + imageUrl);
            System.Net.WebResponse webres = webreq.GetResponse();
            using (System.IO.Stream stream = webres.GetResponseStream())
            {
                picImg.Image = Image.FromStream(stream);
                picImg.Tag = imageUrl.Substring(imageUrl.LastIndexOf('.'));
            }
            txtSummary.Text = htmlDoc.GetElementById("intro").GetElementsByTag("p").Html();

            var volumes = htmlDoc.GetElementById("list").GetElementsByTag("dd");
            lstBookItems.Items.Clear();
            foreach (var item in volumes)
            {
                var li = item.GetElementsByTag("a");

                var t = new ListViewItem(li.Text);
                t.Tag = " http://www.biquge.com.tw" + li.Attr("href");
                lstBookItems.Items.Add(t);
                //bookItems.Add(l.Text());
            }
        }


        private void ExportExcel()
        {
            if (lstBookItems.Items.Count == 0)
            {
                MessageBox.Show("请先解析数据!");
                return;
            }
            try
            {
                String imageFolder = ConfigurationManager.AppSettings["imgfile"].TrimEnd(new char[] { '\\', '/' });
                string spell = PingYinHelper.ConvertAllSpellLower(lblBookName.Text);
                String imagePath = String.Format("{0}/{1}{2}", imageFolder, spell, picImg.Tag);
                picImg.Image.Save(imagePath);

                String fileFolder = ConfigurationManager.AppSettings["file"].TrimEnd(new char[] { '\\', '/' });
                String excelPath = String.Format("{0}/{1}.xlsx", fileFolder, lblBookName.Text);
                using (FileStream fs = new FileStream(excelPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    IWorkbook workbook = new XSSFWorkbook();
                    SheetBookInfo("/files/bookimages/" + spell + picImg.Tag, workbook);
                    ISheet sheet = workbook.CreateSheet("bookitem");
                    Int32 rowIndex = 0;
                    IRow row = sheet.CreateRow(rowIndex);
                    SetCellValue(row, 0, "章节");
                    SetCellValue(row, 1, "书籍ID");
                    SetCellValue(row, 2, "数据源地址");
                    rowIndex++;
                    for (int i = 0; i < lstBookItems.Items.Count; i++)
                    {
                        row = sheet.CreateRow(rowIndex);
                        SetCellValue(row, 0, lstBookItems.Items[i].Text);
                        SetCellValue(row, 1);
                        SetCellValue(row, 2, lstBookItems.Items[i].Tag.ToString());
                        rowIndex++;
                    }
                    workbook.Write(fs);
                    workbook.Close();
                }
                MessageBox.Show("导出成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SheetBookInfo(string imagePath, IWorkbook workbook)
        {
            ISheet sheet = workbook.CreateSheet("book");
            IRow row = sheet.CreateRow(0);
            SetCellValue(row, 0, "小说名");
            SetCellValue(row, 1, "作者");
            SetCellValue(row, 2, "最后一次发布时间");
            SetCellValue(row, 3, "图片地址");
            SetCellValue(row, 4, "简介");
            SetCellValue(row, 5, "状态");

            row = sheet.CreateRow(1);
            SetCellValue(row, 0, lblBookName.Text.Trim());
            SetCellValue(row, 1, lblAuthor.Text.Trim());
            SetCellValue(row, 2, "");
            SetCellValue(row, 3, imagePath);
            SetCellValue(row, 4, txtSummary.Text);
            SetCellValue(row, 5, "0");
        }

        private void SetCellValue(IRow row, Int32 index, String Value = "")
        {
            row.CreateCell(index).SetCellValue(Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }
    }
}
