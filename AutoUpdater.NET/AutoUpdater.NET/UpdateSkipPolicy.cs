using System;

namespace AutoUpdaterDotNET
{
    internal static class UpdateSkipPolicy
    {
        public static bool ShouldSkipUpdate(string skipValue, string skippedVersionValue, Version currentVersion, out bool resetSkip)
        {
            resetSkip = false;

            if (currentVersion == null || string.IsNullOrEmpty(skipValue) || string.IsNullOrEmpty(skippedVersionValue))
                return false;

            Version skippedVersion;
            if (!Version.TryParse(skippedVersionValue, out skippedVersion))
                return false;

            if (skipValue.Equals("1") && currentVersion <= skippedVersion)
                return true;

            if (currentVersion > skippedVersion)
                resetSkip = true;

            return false;
        }
    }
}
