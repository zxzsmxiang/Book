using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 爬虫启动事件
    /// </summary>
    public class OnStartEventArgs:EventArgs
    {
        public Uri Uri { get; }

        public OnStartEventArgs(Uri uri)
        {
            this.Uri = uri;
        }
    }
}
