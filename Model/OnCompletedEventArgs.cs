using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OnCompletedEventArgs : EventArgs
    {
        public Uri Uri { get; private set; }
        public Int32 ThreadId { get; private set; }
        public String PageSource { get; private set; }
        public long Millseconds { get; private set; }

        public OnCompletedEventArgs(Uri uri,int threadId,long millseconds,string pageSource)
        {
            this.Uri = uri;
            this.ThreadId = threadId;
            this.Millseconds = millseconds;
            this.PageSource = pageSource;
        }

    }
}
