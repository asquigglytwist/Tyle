using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.LogFile
{
    public class TailedStream : LogFileStream
    {
        FileSystemWatcher fileWatcher;
        public delegate void TailedFileChangedHandler(object sender, TailedFileChangedEventArgs e);
        public event TailedFileChangedHandler TailedFileChangedEventHandler;

        public TailedStream(string filePath) : base(filePath)
        {
        }
    }
}
