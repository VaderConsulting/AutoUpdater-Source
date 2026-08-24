using System;

namespace AutoUpdaterDotNET
{
    internal static class UpdatePath
    {
        public static bool IsFilePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false;

            if (path.StartsWith(@"\\"))
                return true;

            Uri uri;
            return Uri.TryCreate(path, UriKind.Absolute, out uri) && uri.IsFile;
        }

        public static string GetFilePath(string path)
        {
            Uri uri;
            if (Uri.TryCreate(path, UriKind.Absolute, out uri) && uri.IsFile)
                return uri.LocalPath;

            return path;
        }
    }
}
