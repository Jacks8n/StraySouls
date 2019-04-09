using System.Linq;
using SoulsFormats;
using StraySouls.Wrapper;

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

            string filePath = GamePath.GetMapStudioPath() + msbName;
            switch (game)
            {
                case Game.DS3:
                    MSB3 msb3 = MSB3.Read(filePath);
                    EnemyWrapper.Overwrite(Randomizer.Randomize(EnemyWrapper.Read(msb3.Parts.Enemies).ToList()), msb3.Parts.Enemies);
                    msb3.Write(filePath);
                    break;
                case Game.Sekiro:
                    MSBS msbs = MSBS.Read(filePath);
                    EnemyWrapper.Overwrite(Randomizer.Randomize(EnemyWrapper.Read(msbs.Parts.Enemies).ToList()), msbs.Parts.Enemies);
                    msbs.Write(filePath);
                    break;
            }
        }
    }
}
