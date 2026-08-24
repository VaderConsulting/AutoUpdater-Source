using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace Browser
{
    public static class Globals
    {
        public enum AssocF : int
        {
            NONE = 0x00000000,
            INIT_NOREMAPCLSID = 0x00000001,
            INIT_BYEXENAME = 0x00000002,
            OPEN_BYEXENAME = 0x00000002,
            INIT_DEFAULTTOSTAR = 0x00000004,
            INIT_DEFAULTTOFOLDER = 0x00000008,
            NOUSERSETTINGS = 0x00000010,
            NOTRUNCATE = 0x00000020,
            VERIFY = 0x00000040,
            REMAPRUNDLL = 0x00000080,
            NOFIXUPS = 0x00000100,
            IGNOREBASECLASS = 0x00000200,
            INIT_IGNOREUNKNOWN = 0x00000400,
            INIT_FIXED_PROGID = 0x00000800,
            IS_PROTOCOL = 0x00001000,
            INIT_FOR_FILE = 0x00002000
        }

        public enum AssocStr : int
        {
            ASSOCSTR_COMMAND = 1,
            ASSOCSTR_EXECUTABLE,
            ASSOCSTR_FRIENDLYDOCNAME,
            ASSOCSTR_FRIENDLYAPPNAME,
            ASSOCSTR_NOOPEN,
            ASSOCSTR_SHELLNEWVALUE,
            ASSOCSTR_DDECOMMAND,
            ASSOCSTR_DDEIFEXEC,
            ASSOCSTR_DDEAPPLICATION,
            ASSOCSTR_DDETOPIC,
            ASSOCSTR_INFOTIP,
            ASSOCSTR_QUICKTIP,
            ASSOCSTR_TILEINFO,
            ASSOCSTR_CONTENTTYPE,
            ASSOCSTR_DEFAULTICON,
            ASSOCSTR_SHELLEXTENSION,
            ASSOCSTR_DROPTARGET,
            ASSOCSTR_DELEGATEEXECUTE,
            ASSOCSTR_SUPPORTED_URI_PROTOCOLS,
            ASSOCSTR_MAX
        }

        [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode)]
        public static extern uint AssocQueryString(AssocF flags, AssocStr str, string pszAssoc, string pszExtra, [Out] StringBuilder pszOut, ref uint pcchOut);

        public static string PCLanguageSetting = "";

        public static void GetPCLanguageSetting()
        {
            PCLanguageSetting = Properties.Settings.Default.Language;

            if (System.IO.File.Exists("language.txt"))
            {
                try
                {
                    //StringBuilder sb = new StringBuilder();
                    using (StreamReader sr = new StreamReader("language.txt"))
                    {
                        // Read first line only
                        String line = sr.ReadLine();

                        if (line != null)
                        {
                            if (line.Length > 0)
                            {
                                PCLanguageSetting = line;
                            }
                        }
                    }
                }
                catch
                {

                }
            }
        }

        public static void SetPCLanguage(string LanguageToset)
        {
            PCLanguageSetting = LanguageToset;
        }

        public static string AssocQueryString(AssocStr association, string extension)
        {
            const int S_OK = 0;
            const int S_FALSE = 1;
            uint length = 0;
            uint ret = AssocQueryString(AssocF.NONE, association, extension, null, null, ref length);

            if (ret != S_FALSE)
            {
                return "";
                //throw new InvalidOperationException("Could not determine associated string");
            }

            var sb = new StringBuilder((int)length); // (length-1) will probably work too as the marshaller adds null termination
            ret = AssocQueryString(AssocF.NONE, association, extension, null, sb, ref length);
            if (ret != S_OK)
            {
                return "";
                //throw new InvalidOperationException("Could not determine associated string");
            }

            return sb.ToString();
        }

    }
}
