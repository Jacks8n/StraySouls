using System;
using System.IO;

namespace StraySouls.Input
{
    public class RestoreCommand : CommandBase<RestoreCommand>
    {
        protected override  void Execute(Game game, string msbName)
        {
            string source = GamePath.GetMapStudioPath() + msbName;

            if (File.Exists(source))
                File.Copy(GamePath.GetBackupPath() + msbName, GamePath.GetMapStudioPath() + msbName, overwrite: true);
            else
                Console.WriteLine($"{source} backup not found");
        }
    }
}
