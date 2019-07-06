﻿using System.Linq;
using SoulsFormats;
using StraySouls.Wrapper;

namespace StraySouls.Input
{
    public class EnemyRandomCommand : CommandBase<EnemyRandomCommand>, IDarkSoulsSpecific<EnemyRandomCommand>
    {
        public readonly EnemyRandomizer Randomizer = new EnemyRandomizer();

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
            EnemyWrapper.Overwrite(Randomizer.Randomize(EnemyWrapper.Read(msb3.Parts.Enemies).ToList()), msb3.Parts.Enemies);
            msb3.Write(filePath);
        }

        EnemyRandomCommand IGameSpecific<EnemyRandomCommand>.GetSpecified()
        {
            throw new System.NotImplementedException();
        }
    }
}
