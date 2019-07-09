using SoulsFormats;
using StraySouls.Input.Arguments;
using StraySouls.Randomizer;

namespace StraySouls.Input
{
    public class EnemyRandomCommand_Sekiro : CommandBase<EnemyRandomCommand_Sekiro>
    {
        public readonly EnemyRandomizer_Sekiro Randomizer = new EnemyRandomizer_Sekiro();

        protected override CommandArgCollection<EnemyRandomCommand_Sekiro> AvailableArguments => AVAILABLE_ARGUMENTS;

        private static readonly CommandArgCollection<EnemyRandomCommand_Sekiro> AVAILABLE_ARGUMENTS = new CommandArgCollection<EnemyRandomCommand_Sekiro>(
            new EnemyRandomArgs_Sekiro.RandomMainBoss(),
            new EnemyRandomArgs_Sekiro.RandomFriendlyNPC(),
            new MultiplyEnemies());

        protected override void Execute(string filePath, string fileName)
        {
            MSBS msbs = MSBS.Read(filePath);
            Randomizer.Randomize(msbs.Parts.Enemies);
            Randomizer.Clear();
            msbs.Write(filePath);
        }
    }
}