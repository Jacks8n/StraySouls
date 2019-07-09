using System;
using System.IO;

namespace StraySouls.Input
{
    public class RestoreCommand : CommandBase<RestoreCommand>
    {
        protected override  void Execute(string filePath,string fileName)
        {
            string backupPath = GamePath.GetBackupPath() + fileName;
            if (File.Exists(backupPath))
                File.Copy(backupPath, filePath, overwrite: true);
            else
                Console.WriteLine($"{backupPath} backup not found");
        }
    }
}
