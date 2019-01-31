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

        private static string _mapstudioPath = string.Empty;

        public static string GetDS3MapStudioPath()
        {
            if (_mapstudioPath != string.Empty)
                return _mapstudioPath;
            try
            {
                RegistryKey regKey = Registry.LocalMachine.OpenSubKey(REG_PATH_STEAM);
                _mapstudioPath = regKey.GetValue(REG_KEYNAME_INSTALL).ToString() + FOLDER_PATH_DS3 + FOLDER_PATH_MAPSTUDIO;
            }
            catch
            {
            }

            while (string.IsNullOrWhiteSpace(_mapstudioPath) || !_mapstudioPath.EndsWith(FOLDER_PATH_MAPSTUDIO) || !Directory.Exists(_mapstudioPath))
            {
                Console.WriteLine("Can't find the folder of dark souls 3 mapstudio data.");
                Console.WriteLine("It looks like ..\\DARK SOULS III\\Game\\map\\mapstudio\\");
                Console.Write("Type the full path manually:");

                _mapstudioPath = Console.ReadLine().Trim();

                if (_mapstudioPath.StartsWith("\""))
                    _mapstudioPath = _mapstudioPath.Substring(1);
                if (_mapstudioPath.EndsWith("\""))
                    _mapstudioPath = _mapstudioPath.Substring(0, _mapstudioPath.Length - 1);

                if (!_mapstudioPath.EndsWith("\\"))
                    _mapstudioPath += "\\";
            }

            return _mapstudioPath;
        }
    }
}
