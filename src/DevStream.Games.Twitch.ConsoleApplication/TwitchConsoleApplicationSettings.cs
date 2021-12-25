using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStream.Games.Twitch.ConsoleApplication
{
    public class TwitchConsoleApplicationSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsShowData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsExport { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ExportType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ExportPath { get; set; }
    }
}
