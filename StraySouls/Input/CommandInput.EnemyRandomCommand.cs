using SoulsFormats;

using Enemy = SoulsFormats.MSB3.Part.Enemy;

namespace StraySouls
{
    public static partial class CommandInput
    {
        public class EnemyRandomCommand : IRandomCommand<Enemy, EnemyRandomizer>
        {
            private readonly static CommandArgCollection<EnemyRandomCommand> AVAILABLE_ARGS = new CommandArgCollection<EnemyRandomCommand>(
                new EnemyRandomArgs.RandomMainBoss(),
                new EnemyRandomArgs.RandomOptionalBoss(),
                new EnemyRandomArgs.RandomAggressiveNPC(),
                new EnemyRandomArgs.RandomFriendlyNPC(),
                new EnemyRandomArgs.MultiplyEnemies()
                );

            public EnemyRandomizer Randomizer { get; } = new EnemyRandomizer();

            private CommandArgCollection<EnemyRandomCommand> _availableArgs = new CommandArgCollection<EnemyRandomCommand>();

            public void Command(string msbName, char[] args)
            {
                Randomizer.Clear();

                string filePath = _mapstudioPath + msbName;
                MSB3 msb = MSB3.Read(filePath);

                AVAILABLE_ARGS.AppendArgsTo(this, args);

                Randomizer.Randomize(msb.Parts.Enemies);
                msb.Write(filePath);
            }
        }
    }
}
