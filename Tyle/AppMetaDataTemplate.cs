namespace Tyle
{
    public static class AppMetaData
    {
        public const string ApplicationName = "Tyle";
        public const string Description = "Tail Your Logs Efficiently...";
        public const string CompanyName = "LS";
        public const string CopyRight = "Copyright © " + CompanyName + ", 2017; All rights reserved.";
        public const string TradeMark = ApplicationName + ", " + CompanyName;
        // [BIB]:  https://stackoverflow.com/questions/64602/what-are-differences-between-assemblyversion-assemblyfileversion-and-assemblyin
        private const string major = "0";
        private const string minor = "1";
        private const string build = "0";
        private const string revision = "0";
        public const string ProductVersion = major + "." + minor + ".0.0";
        public const string AssemblyVersion = major + "." + minor + "." + build + "." + revision;
        // [BIB]:  https://stackoverflow.com/questions/17144355/how-can-i-replace-every-occurrence-of-a-string-in-a-file-with-powershell
        // [BIB]:  https://stackoverflow.com/questions/2249619/how-to-format-a-datetime-in-powershell
        public const string AssemblyFileVersion = major + "." + minor + "." + "[PS_Stub_Date].[PS_Stub_Time]";
    }
}
