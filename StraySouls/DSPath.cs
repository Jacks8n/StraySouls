using System;
using System.IO;
using Microsoft.Win32;

namespace StraySouls
{
    public static class DSPath
    {
        private const string REG_PATH_STEAM = @"SOFTWARE\WOW6432Node\Valve\Steam";
        private const string REG_KEYNAME_INSTALL = "InstallPath";

        private const string FOLDER_PATH_DS3 = @"\steamapps\common\DARK SOULS III\";
        private const string FOLDER_PATH_MAPSTUDIO = @"Game\map\mapstudio\";

        public static string GetDS3MapStudioPath()
        {
            string ds3Path = string.Empty;
            try
            {
                RegistryKey regKey = Registry.LocalMachine.OpenSubKey(REG_PATH_STEAM);
                ds3Path = regKey.GetValue(REG_KEYNAME_INSTALL).ToString() + FOLDER_PATH_DS3 + FOLDER_PATH_MAPSTUDIO;
            }
            catch
            {
            }

            while (string.IsNullOrWhiteSpace(ds3Path) || !ds3Path.EndsWith(FOLDER_PATH_MAPSTUDIO) || !Directory.Exists(ds3Path))
            {
                Console.WriteLine("Can't find the folder of dark souls 3 mapstudio data.");
                Console.WriteLine("It looks like ..\\DARK SOULS III\\Game\\map\\mapstudio\\");
                Console.Write("Type the full path manually:");

                ds3Path = Console.ReadLine().Trim();

                if (ds3Path.StartsWith("\""))
                    ds3Path = ds3Path.Substring(1);
                if (ds3Path.EndsWith("\""))
                    ds3Path = ds3Path.Substring(0, ds3Path.Length - 1);

                if (!ds3Path.EndsWith("\\"))
                    ds3Path += "\\";
            }

            return ds3Path;
        }
    }
}
