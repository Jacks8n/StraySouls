using System.IO;

namespace StraySouls
{
    public static partial class CommandInput
    {
        public class BackupCommand : ICommand
        {
            public void Command(string msbName, char[] args)
            {
                Directory.CreateDirectory(_backupFolderPath);

                string backupFilePath = _backupFolderPath + msbName;

                if (!File.Exists(backupFilePath))
                    File.Copy(_mapstudioPath + msbName, backupFilePath);
            }
        }
    }
}
