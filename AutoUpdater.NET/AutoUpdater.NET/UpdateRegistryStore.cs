using System;
using Microsoft.Win32;

namespace AutoUpdaterDotNET
{
    internal static class UpdateRegistryStore
    {
        public static RegistryKey Open(string registryLocation)
        {
            if (string.IsNullOrWhiteSpace(registryLocation))
                return null;

            return Registry.CurrentUser.OpenSubKey(registryLocation);
        }

        public static void SaveSkip(string registryLocation, Version version)
        {
            using (RegistryKey updateKey = Registry.CurrentUser.CreateSubKey(registryLocation))
            {
                updateKey.SetValue("version", version.ToString());
                updateKey.SetValue("skip", 1);
            }
        }

        public static void ResetSkip(string registryLocation, Version version)
        {
            using (RegistryKey updateKey = Registry.CurrentUser.CreateSubKey(registryLocation))
            {
                updateKey.SetValue("version", version.ToString());
                updateKey.SetValue("skip", 0);
            }
        }

        public static void SaveReminder(string registryLocation, Version version, DateTime remindLater)
        {
            using (RegistryKey updateKey = Registry.CurrentUser.CreateSubKey(registryLocation))
            {
                updateKey.SetValue("version", version.ToString());
                updateKey.SetValue("skip", 0);
                updateKey.SetValue("remindlater", remindLater);
            }
        }
    }
}
