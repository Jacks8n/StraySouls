using System;
using System.IO;
using Microsoft.Win32;

namespace StraySouls
{
    public static class GamePath
    {
        private const string REG_PATH_STEAM = @"SOFTWARE\WOW6432Node\Valve\Steam\";
        private const string REG_KEYNAME_INSTALL = "InstallPath";

        private const string FOLDER_PATH_STEAMGAME = @"steamapps\common\";
        private const string FOLDER_PATH_MAPSTUDIO = @"map\mapstudio\";
        private const string FOLDER_PATH_BACKUP = @"StraySouls_Backup\";

        private static string _mapstudioPath = string.Empty;

        private static string _backupPath = string.Empty;

        public static string GetMapStudioPath()
        {
            if (_mapstudioPath != string.Empty)
                return _mapstudioPath;

            _mapstudioPath = TryGetSteamGameRegistryPath();
            if (_mapstudioPath != string.Empty)
                _mapstudioPath += TargetGame.GetGameFolderPath() + FOLDER_PATH_MAPSTUDIO;
            else
                Console.WriteLine("Can't find the mapstudio folder automatically");

            while (!Directory.Exists(_mapstudioPath))
            {
                Console.WriteLine("Can't find " + _mapstudioPath);
                Console.WriteLine($"It looks like ..\\DARK SOULS III\\Game\\map\\mapstudio\\");
                Console.Write("Type the full path manually:");

                _mapstudioPath = TrimMapStudioPath(Console.ReadLine());
            }

            return _mapstudioPath;
        }

        public static string GetBackupPath()
        {
            if (_backupPath == string.Empty)
                _backupPath = GetMapStudioPath() + FOLDER_PATH_BACKUP;
            return _backupPath;
        }

        /// <summary>
        /// If failed, returns <see cref="string.Empty"/>
        /// </summary>
        private static string TryGetSteamGameRegistryPath()
        {
            try
            {
                return Registry.LocalMachine.OpenSubKey(REG_PATH_STEAM).GetValue(REG_KEYNAME_INSTALL).ToString() + "\\" + FOLDER_PATH_STEAMGAME;
            }
            catch
            {
                return string.Empty;
            }
        }

        private static string TrimMapStudioPath(string path)
        {
            path.Trim();

            if (path.StartsWith("\""))
                path = path.Substring(1);
            if (path.EndsWith("\""))
                path = path.Substring(0, path.Length - 1);
            if (!path.EndsWith("\\"))
                path += "\\";

            return path;
        }
    }
}
