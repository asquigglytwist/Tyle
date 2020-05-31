using System;
using System.Collections.Generic;
using System.Text;

namespace Core.LogFile
{
    public static class LogStreamFactory
    {
        public static LogFileStream GetStreamFor(string filePath,
            TailedStream.TailedFileChangedHandler tailedFileChanged = null)
        {
            if (tailedFileChanged == null)
            {
                return new LogFileStream(filePath);
            }
            return new TailedStream(filePath, tailedFileChanged);
        }
    }
}
