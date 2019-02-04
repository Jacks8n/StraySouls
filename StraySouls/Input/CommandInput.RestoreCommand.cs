using System;
using System.IO;

namespace StraySouls
{
    public static partial class CommandInput
    {
        public class RestoreCommand : ICommand
        {
            public void Command(string msbName, char[] args)
            {
                string source = _backupFolderPath + msbName;

                if (File.Exists(source))
                    File.Copy(_backupFolderPath + msbName, _mapstudioPath + msbName, overwrite: true);
                else
                    Console.WriteLine($"{source} backup not found");
            }
        }
    }
}
