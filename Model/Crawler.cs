using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Crawler
    {
        public event EventHandler<OnStartEventArgs> OnStart;
        public event EventHandler<OnCompletedEventArgs> OnCompleted;
        public event EventHandler<Exception> OnError;

        public CookieContainer CookieContainer { get; set; }

        public Task<string> Start(Uri uri, WebProxy webProxy = null)
        {
            return Task.Run(() =>
           {

               var pageSource = string.Empty;

               try
               {
                   if (this.OnStart != null)
                   {
                       this.OnStart(this, new OnStartEventArgs(uri));
                   }
                   var wacth = new Stopwatch();
                   wacth.Start();
                   var request = (HttpWebRequest)WebRequest.Create(uri);
                   request.Accept = "*";
                   request.ContentType = "application/x-www-form-urlencoded";
                   request.AllowAutoRedirect = false;

                   request.UserAgent = "5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Safari/537.36";
                   request.Timeout = 5000;
                   request.KeepAlive = true;
                   request.Method = "GET";
                   if (webProxy != null)
                   {
                       request.Proxy = webProxy;
                   }
                   request.CookieContainer = this.CookieContainer;
                   request.ServicePoint.ConnectionLimit = int.MaxValue;
                   var response = (HttpWebResponse)request.GetResponse();
                   var stream = response.GetResponseStream();
                   var reader = new StreamReader(stream, Encoding.UTF8);
                   pageSource = reader.ReadToEnd();
                   wacth.Stop();
                   var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                   var millseconds = wacth.ElapsedMilliseconds;
                   reader.Close();
                   stream.Close();
                   request.Abort();
                   response.Close();
                   if (this.OnCompleted != null)
                   {
                       this.OnCompleted(this, new OnCompletedEventArgs(uri, threadId, millseconds, pageSource));
                   }
               }
               catch (Exception ex)
               {
                   if (this.OnError != null)
                   {
                       this.OnError(this, ex);
                   }
               }

               return pageSource;
           });
        }


        public string StartUrl(Uri uri, WebProxy webProxy = null)
        {
            var pageSource = string.Empty;

            try
            {
                if (this.OnStart != null)
                {
                    this.OnStart(this, new OnStartEventArgs(uri));
                }
                var wacth = new Stopwatch();
                wacth.Start();
                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.Accept = "*";
                request.ContentType = "application/x-www-form-urlencoded";
                request.AllowAutoRedirect = false;

                request.UserAgent = "5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Safari/537.36";
                request.Timeout = 5000;
                request.KeepAlive = true;
                request.Method = "GET";
                if (webProxy != null)
                {
                    request.Proxy = webProxy;
                }
                request.CookieContainer = this.CookieContainer;
                request.ServicePoint.ConnectionLimit = int.MaxValue;
                var response = (HttpWebResponse)request.GetResponse();
                var stream = response.GetResponseStream();
                var reader = new StreamReader(stream, Encoding.UTF8);
                pageSource = reader.ReadToEnd();
                wacth.Stop();
                var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                var millseconds = wacth.ElapsedMilliseconds;
                reader.Close();
                stream.Close();
                request.Abort();
                response.Close();
                if (this.OnCompleted != null)
                {
                    this.OnCompleted(this, new OnCompletedEventArgs(uri, threadId, millseconds, pageSource));
                }
            }
            catch (Exception ex)
            {
                if (this.OnError != null)
                {
                    this.OnError(this, ex);
                }
            }
            return pageSource;
        }
    }
}
