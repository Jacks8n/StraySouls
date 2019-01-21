using System;
using System.IO;
using Microsoft.Win32;

namespace StraySouls
{
    public static class DSPath
    {
        private const string REG_PATH_STEAM = @"SOFTWARE\WOW6432Node\Valve\Steam";
        private const string REG_KEYNAME_INSTALL = "InstallPath";
        private const string FOLDER_PATH_DS3 = @"\steamapps\common\DARK SOULS III\Game\map\mapstudio\";
        
        public static string GetDS3MapStudioPath()
        {
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey(REG_PATH_STEAM);
            string ds3Path = regKey.GetValue(REG_KEYNAME_INSTALL).ToString() + FOLDER_PATH_DS3;

            while (!Directory.Exists(ds3Path))
            {
                Console.WriteLine("Can't find the folder of dark souls 3 map data.");
                Console.Write("Type here manually:");

                ds3Path = Console.ReadLine();
            }

            return ds3Path;
        }
    }
}
