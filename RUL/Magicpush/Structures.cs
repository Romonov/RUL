using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RUL.Magicpush
{
    public class Structures
    {
        public struct Notice
        {
            public int ID;
            public string Title;
            public string Detail;
            public string Date;
            public string Time;
            public string Link;
            public int ColorR;
            public int ColorG;
            public int ColorB;
        }

        public struct Update
        {
            public int ID;
            public string Project;
            public string UpdateLog;
            public string Date;
            public string Time;
            public string DetailLink;
            public string DownloadLink;
            public int ColorR;
            public int ColorG;
            public int ColorB;
        }
    }
}
