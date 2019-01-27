using System.IO;

namespace StraySouls
{
    public static partial class CommandInput
    {
        private class RestoreCommand : ICommand
        {
            public void Command(string msbName, char[] args)
            {
                File.Copy(_backupFolderPath + msbName, _mapstudioPath + msbName, overwrite: true);
            }
        }
    }
}
