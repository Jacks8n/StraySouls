using SoulsFormats;

namespace StraySouls.Input
{
    public class EnemyRandomCommand : CommandBase<EnemyRandomCommand>
    {
        public readonly EnemyRandomizer Randomizer = new EnemyRandomizer();

        protected override CommandArgCollection<EnemyRandomCommand> Arguments => ARGUMENTS_AVAILABLE;

        private static readonly CommandArgCollection<EnemyRandomCommand> ARGUMENTS_AVAILABLE = new CommandArgCollection<EnemyRandomCommand>(
        new EnemyRandomArgs.RandomMainBoss(),
        new EnemyRandomArgs.RandomOptionalBoss(),
        new EnemyRandomArgs.RandomAggressiveNPC(),
        new EnemyRandomArgs.RandomFriendlyNPC(),
        new EnemyRandomArgs.MultiplyEnemies()
        );

        protected override void Execute(Game game, string msbName)
        {
            Randomizer.Clear();

            //TODO
            string filePath = GamePath.GetMapStudioPath() + msbName;
            switch (game)
            {
                case Game.DS3:
                    MSB3 msb3 = MSB3.Read(filePath);
                    Randomizer.Randomize(msb3.Parts.Enemies);
                    msb3.Write(filePath);
                    break;
                case Game.Sekiro:
                    MSBN msbn = MSBN.Read(filePath);

                    msbn.Write(filePath);
                    break;
            }
        }
    }
}
