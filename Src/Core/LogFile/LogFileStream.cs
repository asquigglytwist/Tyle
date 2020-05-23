using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Core.Prefs
{
    #region LogFileStream
    /// <summary>
    /// A LogFile, available in a Line-wise format
    /// </summary>
    public class LogFileStream : IDisposable
    {
        #region Fields
        protected StreamReader fileStream;
        protected List<LogEntry> rawLogEntries;
        protected List<FilteredLogEntry> filteredLogEntries;
        public const int ItemNotFound = -1;
        #endregion // Fields

        #region Constructor
        /// <summary>
        /// Constructs a <see cref="LogFileStream"/> from the file path provided in <paramref name="filePath"/>
        /// </summary>
        /// <param name="filePath">Full path to the log file</param>
        public LogFileStream(string filePath)
        {
            if (File.Exists(filePath))
            {
                fileStream = new StreamReader(
                    new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
            }
            else
            {
                throw new FileNotFoundException(filePath);
            }
            FilePath = filePath;
            FileName = Path.GetFileName(filePath);
            LongestLine = "---";
            rawLogEntries = new List<LogEntry>();
            ReadLinesToEOF();
        }
        #endregion // Constructor

        #region IDisposable
        /// <summary>
        /// Releases all resources held by this instance of <see cref="LogFileStream"/> and disposes it
        /// </summary>
        void IDisposable.Dispose()
        {
            fileStream.Close();
            fileStream.Dispose();
            rawLogEntries.Clear();
            filteredLogEntries.Clear();
        }
        #endregion // IDisposable

        #region Methods
        /// <summary>
        /// Read the file line-by-line until EOF
        /// </summary>
        /// <returns>True, if the read was successful; False, otherwise</returns>
        public bool ReadLinesToEOF()
        {
            try
            {
                string temp;
                while ((temp = fileStream.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(temp))
                    {
                        continue;
                    }
                    temp = temp.Replace("\t", "    ");
                    LongestLine = (LongestLine.Length < temp.Length ? temp : LongestLine);
                    rawLogEntries.Add(new LogEntry(temp));
                }
            }
            catch (Exception)
            {
                return false;
            }
            filteredLogEntries = RulesEngine.FilterLogEntries(rawLogEntries);
            return true;
        }

        /// <summary>
        /// Find <paramref name="searchText"/> in the LogFile's content (HayStack) and return the line number containing it
        /// </summary>
        /// <param name="searchText">The text to search for i.e., Needle</param>
        /// <param name="searchStartIndex">Line number to start searching from</param>
        /// <param name="wrapSearch">If true, the search wraps around to the first line if <paramref name="searchStartIndex"/> is not the default (0)</param>
        /// <returns>Line number where the <paramref name="searchText"/> was found; <see cref="ItemNotFound"/> if not found</returns>
        public int FindItem(string searchText, int searchStartIndex = 0, bool wrapSearch = true)
        {
            int foundItemIndex = ItemNotFound;
            if (filteredLogEntries.Count > 0)
            {
                searchStartIndex %= filteredLogEntries.Count;
                foundItemIndex = filteredLogEntries.FindIndex(searchStartIndex, (entry => (entry.Line.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) > -1)));
                if (foundItemIndex == ItemNotFound && searchStartIndex != 0 && wrapSearch)
                {
                    foundItemIndex = filteredLogEntries.FindIndex(0, (entry => (entry.Line.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) > ItemNotFound)));
                }
            }
            return foundItemIndex;
        }
        #endregion // Methods

        #region Properties
        /// <summary>
        /// Complete path to the LogFile
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// The LogFile's name
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Actual size of the file under <see cref="LogFileStream"/>, in a readable format
        /// </summary>
        public string FileSize
            => fileStream.BaseStream.Length.AsReadableFileSize();

        /// <summary>
        /// The number of Lines that are currently available for viewing
        /// </summary>
        public int FilteredLineCount
        {
            get
            {
                return filteredLogEntries.Count;
            }
        }

        /// <summary>
        /// Total number of Lines in the <see cref="LogFileStream"/>
        /// </summary>
        public int RawLineCount
        {
            get
            {
                return rawLogEntries.Count;
            }
        }

        /// <summary>
        /// The LongestLine within
        /// </summary>
        public string LongestLine { get; protected set; }
        #endregion // Properties

        #region Indexer
        /// <summary>
        /// Returns the <paramref name="index"/>'th line of the LogFile
        /// </summary>
        /// <param name="index">Line number to be retrieved</param>
        /// <returns>The <paramref name="index"/>'th line</returns>
        public string this[int index] => filteredLogEntries[index].Line;

        public int this[string needle, int startIndex = 0, bool wrapAround = true]
        {
            get
            {
                return FindItem(needle, startIndex, wrapAround);
            }
        }
        #endregion
    } // LogFileStream
    #endregion
}
