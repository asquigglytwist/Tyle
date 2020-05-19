using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Prefs
{
    #region TailedFileChangeType
    /// <summary>
    /// Enumeration of possible changes to the tailed file.
    /// </summary>
    public enum TailedFileChangeType
    {
        /// <summary>
        /// File's content has not changed; Most likely an attribute change.
        /// </summary>
        NoContentChange,
        /// <summary>
        /// File's content read and cached (again).
        /// </summary>
        InitialReadComplete,
        /// <summary>
        /// File created.
        /// </summary>
        //Created,  Skip this for now; Add back when nneed arises.
        /// <summary>
        /// New lines added.
        /// </summary>
        LinesAdded,
        /// <summary>
        /// The last line was edited; New lines may be added.
        /// </summary>
        LastLineExtended,
        /// <summary>
        /// File has shrunk; Requires a refresh / reset.
        /// </summary>
        Shrunk,
        /// <summary>
        /// File renamed.
        /// </summary>
        Renamed,
        /// <summary>
        /// File deleted.
        /// </summary>
        Deleted
    }
    #endregion
}
