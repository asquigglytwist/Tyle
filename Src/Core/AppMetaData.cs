namespace Tyle
{
    public static class AppMetaData
    {
        public const string BuildTimeStamp = "2020-05-09  12:39:14 UTC";
        public const string BuildMode = "WinForms";
#region AssemblyInfo
        public const string ApplicationName = "Tyle";
        public const string Description = "Tail Your Logs Efficiently...";
        public const string CompanyName = "ASquigglyTwist";
#if DEBUG
        public const string AssemblyConfiguration = "Debug";
#else
        public const string AssemblyConfiguration = "Release";
#endif
        public const string CopyRightYear = "2020";
        public const string CopyRight = "Copyright © " + CompanyName + ", " + CopyRightYear + "; All rights reserved.";
        public const string TradeMark = ApplicationName + ", " + CompanyName;
        // [BIB]:  https://stackoverflow.com/questions/64602/what-are-differences-between-assemblyversion-assemblyfileversion-and-assemblyin
        private const string major = "0";
        private const string minor = "2005";
        private const string build = "09";
        private const string revision = "1239";
        public const string ProductVersion = major + "." + minor + ".0.0";
        public const string AssemblyVersion = major + "." + minor + "." + build + ".0";
        // [BIB]:  https://stackoverflow.com/questions/17144355/how-can-i-replace-every-occurrence-of-a-string-in-a-file-with-powershell
        // [BIB]:  https://stackoverflow.com/questions/2249619/how-to-format-a-datetime-in-powershell
        public const string AssemblyFileVersion = major + "." + minor + "." + build + "." + revision;
#endregion //  AssemblyInfo
#region Git - Repo Details
        // [BIB]:  https://stackoverflow.com/questions/6245570/how-to-get-the-current-branch-name-in-git
        public const string RepoBranch = "master";
        // [BIB]:  https://stackoverflow.com/questions/5694389/get-the-short-git-version-hash
        public const string CommitHash = "ba757c9d5fd6efdf479fb5cd5eacae64f5f6fc71";
#endregion //  Git - Repo Details
    }
}
