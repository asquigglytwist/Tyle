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

        protected TailedStream(string filePath) : base(filePath)
        {
        }

        public TailedStream(string filePath, TailedFileChangedHandler changeHandler)
            : this(filePath)
        {
            TailedFileChangedEventHandler += changeHandler;
        }

        protected void WatchFileForChanges(bool fileExists)
        {
            // This way there is no need to verify if we are subscribed to events and subsequent need to unsubscribe.
            fileWatcher?.Dispose();
            FilePath = Path.GetFullPath(FilePath);
            // [BIB]:  https://stackoverflow.com/a/721743
            fileWatcher = new FileSystemWatcher
            {
                Path = Path.GetDirectoryName(FilePath),
                Filter = FileName
            };
            if (fileExists)
            {
                fileWatcher.NotifyFilter = (NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName);
                fileWatcher.Changed += new FileSystemEventHandler(OnFileChanged);
                //fileWatcher.Deleted += new FileSystemEventHandler(OnFileChanged);
                //fileWatcher.Renamed += new RenamedEventHandler(OnRenamed);
            }
            else
            {
                //fileWatcher.Created += new FileSystemEventHandler(OnFileCreated);
            }
            fileWatcher.EnableRaisingEvents = true;
        }

        private void OnFileChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Changed:
                    // [BIB]:  https://stackoverflow.com/a/3042963
                    var modTime = File.GetLastWriteTime(FilePath);
                    if (modTime != LastModified)
                    {
                        LastModified = modTime;
                        TailedFileChangeType temp = TailedFileChangeType.NoContentChange;
                        int linesRead = LineCount;
                        var currentSize = new FileInfo(FilePath).Length;
                        if (currentSize > FileSize)
                        {
                            ReadLinesToEOF();
                        }
                        else
                        {
                            /**
                             * Treat both reduced file size and and unaltered file size as shrunk because we're not sure where
                             * the change has happened within the file; Hence a complete reset makes more sense.
                             */
                            temp = TailedFileChangeType.Shrunk;
                        }
                        if (temp == TailedFileChangeType.Shrunk)
                        {
                            fileStream.Close();
                            fileStream.Dispose();
                            ReInitTailing();
                        }
                        // [BIB]:  https://stackoverflow.com/questions/33233161/how-to-ensure-that-streamreader-basestream-length-will-return-the-correct-value
                        // [BIB]:  https://stackoverflow.com/a/20863065
                        LastKnownSize = currentSize;
                        TailedFileChangedEventHandler(this, new TailedFileChangedEventArgs(temp, linesRead));
                    }
                    break;
            }
        }

        public long LastKnownSize { get; private set; }

        public DateTime LastModified { get; private set; }
    }
}
