using SoulsFormats;
using StraySouls.Randomizer;

namespace StraySouls.Input
{
    public class EnemyRandomCommand : CommandBase<EnemyRandomCommand>
    {
        public readonly EnemyRandomizer_DS3 Randomizer = new EnemyRandomizer_DS3();

        protected override CommandArgCollection<EnemyRandomCommand> AvailableArguments => AVAILABLE_ARGUMENTS;

        private static readonly CommandArgCollection<EnemyRandomCommand> AVAILABLE_ARGUMENTS = new CommandArgCollection<EnemyRandomCommand>(
        new EnemyRandomArgs.RandomMainBoss(),
        new EnemyRandomArgs.RandomOptionalBoss(),
        new EnemyRandomArgs.RandomAggressiveNPC(),
        new EnemyRandomArgs.RandomFriendlyNPC(),
        new EnemyRandomArgs.MultiplyEnemies()
        );

        protected override void Execute(string msbName)
        {
            Randomizer.Clear();

            string filePath = GamePath.GetMapStudioPath() + msbName;
            MSB3 msb3 = MSB3.Read(filePath);
            Randomizer.Randomize(msb3.Parts.Enemies);
            msb3.Write(filePath);
        }
    }
}
