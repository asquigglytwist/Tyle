using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Core.Code
{
    #region TailedStream
    public class TailedStream : IDisposable
    {
        #region Fields
        const int ItemNotFound = -1, DelayBeforeRaisingEvent = 2000;
        readonly int CRLFLength = Environment.NewLine.Length;
        StreamReader fileStream;
        List<string> lsLinesInFile;
        FileSystemWatcher fileWatcher;
        public delegate void TailedFileChangedHandler(object sender, TailedFileChangedArgs e);
        public event TailedFileChangedHandler OnTailedFileChanged;
        #endregion

        #region Constructor
        protected TailedStream(string filePath)
        {
            TailedFilePath = filePath;
            LongestLine = "---";
            lsLinesInFile = new List<string>();
        }

        public TailedStream(string filePath, TailedFileChangedHandler changeHandler)
            : this(filePath)
        {
            OnTailedFileChanged += changeHandler;
            InitTailing();
        }
        #endregion

        #region Functions
        #region Public
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (fileStream != null)
                {
                    fileStream.Dispose();
                }
                if (fileWatcher != null)
                {
                    fileWatcher.Dispose();
                }
            }
        }

        public int FindItem(string searchText, int searchStartIndex, bool wrapSearch)
        {
            int foundItemIndex = ItemNotFound;
            if (lsLinesInFile.Count > 0)
            {
                searchStartIndex %= lsLinesInFile.Count;
                foundItemIndex = lsLinesInFile.FindIndex(searchStartIndex, (line => (line.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) > -1)));
                if (foundItemIndex == ItemNotFound && searchStartIndex != 0 && wrapSearch)
                {
                    foundItemIndex = lsLinesInFile.FindIndex(0, (line => (line.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) > ItemNotFound)));
                }
            }
            return foundItemIndex;
        }
        #endregion

        #region FileReading
        protected bool InitTailing()
        {
            lsLinesInFile.Clear();
            if (File.Exists(TailedFilePath))
            {
                fileStream = new StreamReader(new FileStream(TailedFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                if (ReadLinesToEOF())
                {
                    WatchFileForChanges(true);
                    // [BIB]:  https://stackoverflow.com/a/34458726
                    Task.Delay(DelayBeforeRaisingEvent).ContinueWith(t => OnTailedFileChanged(this, new TailedFileChangedArgs(TailedFileChangeType.InitialReadComplete, lsLinesInFile.Count)));
                    //OnTailedFileChanged(this, new TailedFileChangedArgs(TailedFileChangeType.InitialReadComplete, lsLinesInFile.Count));
                    return true;
                }
                return false;
            }
            else
            {
                WatchFileForChanges(false);
                OnTailedFileChanged(this, new TailedFileChangedArgs(TailedFileChangeType.Deleted));
                return true;
            }
        }

        protected bool ReadLinesToEOF()
        {
            string temp;
            try
            {
                while ((temp = fileStream.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(temp))
                    {
                        continue;
                    }
                    temp = temp.Replace("\t", "    ");
                    LongestLine = (LongestLine.Length < temp.Length ? temp : LongestLine);
                    lsLinesInFile.Add(temp);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        protected bool TailToEOF(out bool lastLineExtended)
        {
            lastLineExtended = false;
            try
            {
                if (lsLinesInFile.Count > 0)
                {
                    string temp;
                    var lastKnownPosition = fileStream.BaseStream.Position;
                    if ((temp = fileStream.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(temp))
                        {
                            var charsRead = temp.Length;
                            var shiftInPosition = ((fileStream.BaseStream.Position - charsRead) - lastKnownPosition);
                            temp = temp.Replace("\t", "    ");
                            if (shiftInPosition < CRLFLength)
                            {
                                // TODO:  We should theoretically not be running into an IndexOutOfRange issue here; Check again though...
                                lsLinesInFile[lsLinesInFile.Count - 1] = lsLinesInFile[lsLinesInFile.Count - 1] + temp;
                                lastLineExtended = true;
                            }
                            else
                            {
                                // We've read the line; So we have to add it to the list...
                                lsLinesInFile.Add(temp);
                            }
                            LongestLine = (LongestLine.Length < temp.Length ? temp : LongestLine);
                        }
                    }
                }
                return ReadLinesToEOF();
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region FileMonitoring
        protected void WatchFileForChanges(bool fileExists)
        {
            if(fileWatcher != null)
            {
                // This way there is no need to verify if we are subscribed to events and subsequent need to unsubscribe.
                fileWatcher.Dispose();
            }
            TailedFilePath = Path.GetFullPath(TailedFilePath);
            // [BIB]:  https://stackoverflow.com/a/721743
            fileWatcher = new FileSystemWatcher();
            fileWatcher.Path = Path.GetDirectoryName(TailedFilePath);
            fileWatcher.Filter = Path.GetFileName(TailedFilePath);
            if (!fileExists)
            {
                fileWatcher.Created += new FileSystemEventHandler(OnFileCreated);
            }
            else
            {
                fileWatcher.NotifyFilter = (NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName);
                fileWatcher.Changed += new FileSystemEventHandler(OnFileChanged);
                fileWatcher.Deleted += new FileSystemEventHandler(OnFileChanged);
                fileWatcher.Renamed += new RenamedEventHandler(OnRenamed);
            }
            fileWatcher.EnableRaisingEvents = true;
        }

        private void OnFileCreated(object source, FileSystemEventArgs e)
        {
            InitTailing();
            var currentSize = new FileInfo(TailedFilePath).Length;
            if (currentSize > 0)
            {
                OnTailedFileChanged(this, new TailedFileChangedArgs(TailedFileChangeType.InitialReadComplete, lsLinesInFile.Count));
            }
        }

        private void OnFileChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Changed:
                    // [BIB]:  https://stackoverflow.com/a/3042963
                    var modTime = File.GetLastWriteTime(TailedFilePath);
                    if (modTime != LastModified)
                    {
                        LastModified = modTime;
                        TailedFileChangeType temp = TailedFileChangeType.NoContentChange;
                        int linesRead = lsLinesInFile.Count;
                        var currentSize = new FileInfo(TailedFilePath).Length;
                        if (currentSize > StreamSize)
                        {
                            if (TailToEOF(out bool lastLineExtended))
                            {
                                linesRead = lsLinesInFile.Count - linesRead;
                                if (lastLineExtended)
                                {
                                    temp = TailedFileChangeType.LastLineExtended;
                                }
                                else if (linesRead > 0)
                                {
                                    temp = TailedFileChangeType.LinesAdded;
                                }
                                else
                                {
                                    temp = TailedFileChangeType.Shrunk;
                                }
                            }
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
                            InitTailing();
                        }
                        // [BIB]:  https://stackoverflow.com/questions/33233161/how-to-ensure-that-streamreader-basestream-length-will-return-the-correct-value
                        // [BIB]:  https://stackoverflow.com/a/20863065
                        StreamSize = currentSize;
                        OnTailedFileChanged(this, new TailedFileChangedArgs(temp, linesRead));
                    }
                    break;
                case WatcherChangeTypes.Deleted:
                    fileStream.Close();
                    InitTailing();
                    OnTailedFileChanged(this, new TailedFileChangedArgs(TailedFileChangeType.Deleted));
                    break;
            }
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
            OnTailedFileChanged(this, new TailedFileChangedArgs(e.OldFullPath, e.FullPath));
        }
        #endregion
        #endregion

        #region Properties
        public string TailedFilePath { get; private set; }

        public int LineCount
        {
            get
            {
                return lsLinesInFile.Count;
            }
        }

        public long StreamSize { get; private set; }
        public DateTime LastModified { get; private set; }

        public string LongestLine { get; protected set; }
        #endregion

        #region Indexer
        public string this[int index]
        {
            get
            {
                return lsLinesInFile[index];
            }
        }
        #endregion
    }
    #endregion
}
