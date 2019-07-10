using System.Collections.Generic;

namespace StraySouls.Input.Arguments
{
    public abstract class SkipListModifierBase_DS3 : ICommandArgument<EnemyRandomCommand_DS3>
    {
        protected abstract IEnumerable<string> IDsToSkipOrDuplicateRandomize { get; }

        public abstract bool IsValidArgString(string argString);

        /// <param name="enabled">If this argument is enabled or not</param>
        public void ModifyCommand(EnemyRandomCommand_DS3 command, bool enabled)
        {
            command.Randomizer.SkipIDs.AddRange(IDsToSkipOrDuplicateRandomize);
            if (enabled)
                command.Randomizer.IDsToDuplicateAndRandomize.AddRange(IDsToSkipOrDuplicateRandomize);
        }
    }

    public abstract class SkipListModifierBase_Sekiro : ICommandArgument<EnemyRandomCommand_Sekiro>
    {
        protected abstract IEnumerable<string> IDsToSkipOrDuplicateRandomize { get; }

        protected virtual int Multiplier => 1;

        public abstract bool IsValidArgString(string argString);

        /// <param name="enabled">If this argument is enabled or not</param>
        public void ModifyCommand(EnemyRandomCommand_Sekiro command, bool enabled)
        {
            command.Randomizer.SkipIDs.AddRange(IDsToSkipOrDuplicateRandomize);
            if (enabled)
                command.Randomizer.IDsToDuplicateAndRandomize.AddRange(IDsToSkipOrDuplicateRandomize);
        }
    }
}
