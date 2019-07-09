using System.IO;

namespace StraySouls.Input
{
    public class BackupCommand : CommandBase<BackupCommand>
    {
        protected override void Execute(string filePath, string fileName)
        {
            string _backupFolderPath = GamePath.GetBackupPath();
            Directory.CreateDirectory(_backupFolderPath);

            string backupFilePath = _backupFolderPath + fileName;
            if (!File.Exists(backupFilePath))
                File.Copy(filePath, backupFilePath);
        }
    }
}
