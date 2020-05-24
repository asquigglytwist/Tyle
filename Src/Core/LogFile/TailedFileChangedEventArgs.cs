using System;
using System.Collections.Generic;
using System.Text;

namespace Core.LogFile
{
    #region TailedFileChangedEventArgs
    /// <summary>
    /// Provides data for the OnTailedFileChanged event.
    /// </summary>
    public class TailedFileChangedEventArgs : EventArgs
    {
        // [BIB]:  https://www.codeproject.com/Articles/9355/Creating-advanced-C-custom-events
        #region Constructors
        /// <summary>
        /// Initializes a new instance of TailedFileChangedEventArgs
        /// </summary>
        /// <param name="changeType">Indicates the type of change that has occured.</param>
        /// <param name="changedLinesCount">Number of lines that have changed.</param>
        public TailedFileChangedEventArgs(TailedFileChangeType changeType, int changedLinesCount = 0)
        {
            ChangeType = changeType;
            ChangedLinesCount = changedLinesCount;
        }

        /// <summary>
        /// Initializes a new instance of TailedFileChangedEventArgs when the file is renamed.
        /// </summary>
        /// <param name="oldPath">Fullpath of the file before renaming.</param>
        /// <param name="newPath">Fullpath of the file after renaming.</param>
        public TailedFileChangedEventArgs(string oldPath, string newPath)
            : this(TailedFileChangeType.Renamed)
        {
            OldFilePath = oldPath;
            NewFilePath = newPath;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Indicates the type of change that this instance of TailedFileChangedEventArgs represents.
        /// </summary>
        public TailedFileChangeType ChangeType { get; protected set; }
        /// <summary>
        /// Number of lines that have changed.
        /// </summary>
        public int ChangedLinesCount { get; protected set; }
        /// <summary>
        /// Fullpath of the file before renaming, if the file was renamed.
        /// </summary>
        public string OldFilePath { get; protected set; }
        /// <summary>
        /// Fullpath of the file after renaming, if the file was renamed.
        /// </summary>
        public string NewFilePath { get; protected set; }
        #endregion
    }
    #endregion
}
