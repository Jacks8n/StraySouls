using SoulsFormats;
using StraySouls.Input.Arguments;
using StraySouls.Randomizer;

namespace StraySouls.Input
{
    public class EnemyRandomCommand_DS3 : CommandBase<EnemyRandomCommand_DS3>
    {
        public readonly EnemyRandomizer_DS3 Randomizer = new EnemyRandomizer_DS3();

        protected override CommandArgCollection<EnemyRandomCommand_DS3> AvailableArguments => AVAILABLE_ARGUMENTS;

        private static readonly CommandArgCollection<EnemyRandomCommand_DS3> AVAILABLE_ARGUMENTS = new CommandArgCollection<EnemyRandomCommand_DS3>(
        new EnemyRandomArgs_DS3.RandomMainBoss(),
        new EnemyRandomArgs_DS3.RandomOptionalBoss(),
        new EnemyRandomArgs_DS3.RandomAggressiveNPC(),
        new EnemyRandomArgs_DS3.RandomFriendlyNPC(),
        new MultiplyEnemies());

        protected override void Execute(string filePath, string fileName)
        {
            MSB3 msb3 = MSB3.Read(filePath);
            Randomizer.Randomize(msb3.Parts.Enemies);
            Randomizer.Clear();
            msb3.Write(filePath);
        }
    }
}
