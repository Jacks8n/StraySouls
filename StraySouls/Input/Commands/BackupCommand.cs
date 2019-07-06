using System.IO;

namespace StraySouls.Input
{
    public class BackupCommand : CommandBase<BackupCommand>
    {
        protected override void Execute(string msbName)
        {
            string _backupFolderPath = GamePath.GetBackupPath();
            Directory.CreateDirectory(_backupFolderPath);

            string backupFilePath = _backupFolderPath + msbName;

            if (!File.Exists(backupFilePath))
                File.Copy(GamePath.GetMapStudioPath() + msbName, backupFilePath);
        }
    }
}
