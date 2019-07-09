using System.Collections.Generic;

namespace StraySouls.Input
{
    public static partial class CommandInput
    {
        private static readonly Dictionary<string, ICommand> COMMAND_TABLE_DS3 = new Dictionary<string, ICommand>()
        {
            { "random", new EnemyRandomCommand_DS3() },
            { "backup", new BackupCommand() },
            { "restore", new RestoreCommand() }
        };

        private static readonly Dictionary<string, ICommand> COMMANDS_TABLE_SEKIRO = new Dictionary<string, ICommand>()
        {
            { "random", new EnemyRandomCommand_Sekiro() },
            { "backup", new BackupCommand() },
            { "restore", new RestoreCommand() }
        };

        private static readonly string[] LIST_FILE_RANDOM_DS3 = new string[]
        {
            "m30_00_00_00.msb.dcx",
            "m30_01_00_00.msb.dcx",
            "m31_00_00_00.msb.dcx",
            "m32_00_00_00.msb.dcx",
            "m33_00_00_00.msb.dcx",
            "m34_01_00_00.msb.dcx",
            "m35_00_00_00.msb.dcx",
            "m37_00_00_00.msb.dcx",
            "m38_00_00_00.msb.dcx",
            "m39_00_00_00.msb.dcx",
            "m40_00_00_00.msb.dcx",
            "m41_00_00_00.msb.dcx", //Firelink Shrine, Soul of Cinder
            "m45_00_00_00.msb.dcx",
            "m50_00_00_00.msb.dcx",
            "m51_00_00_00.msb.dcx",
            "m51_01_00_00.msb.dcx", //Filianore's Rest
        };

        private static readonly string[] LIST_FILE_RANDOM_SEKIRO = new string[]
        {
            "m10_00_00_00.msb.dcx",
            "m11_00_00_00.msb.dcx",
            "m11_01_00_00.msb.dcx",
            "m11_02_00_00.msb.dcx",
            "m13_00_00_00.msb.dcx",
            "m15_00_00_00.msb.dcx",
            "m17_00_00_00.msb.dcx",
            "m20_00_00_00.msb.dcx",
            "m25_00_00_00.msb.dcx",
            "m89_00_00_99.msb.dcx",
        };
    }
}
