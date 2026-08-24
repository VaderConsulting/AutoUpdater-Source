using System;

namespace AutoUpdaterDotNET
{
    internal static class UpdateUrlPolicy
    {
        public static void ValidateAppCastUrl(string updateUrl)
        {
            if (string.IsNullOrWhiteSpace(updateUrl))
                throw new ArgumentException("Update appcast URL is empty.", nameof(updateUrl));

            if (UpdatePath.IsFilePath(updateUrl))
                return;

            Uri uri;
            if (!Uri.TryCreate(updateUrl, UriKind.Absolute, out uri))
                throw new ArgumentException("Update appcast URL is not valid.", nameof(updateUrl));

            if (uri.Scheme == Uri.UriSchemeHttps)
                return;

            if (uri.Scheme == Uri.UriSchemeHttp && uri.IsLoopback)
                return;

            throw new ArgumentException("Update appcast URL must use HTTPS, loopback HTTP, or a file path.", nameof(updateUrl));
        }
    }
}
