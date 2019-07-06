using System.Linq;

namespace StraySouls.Input
{
    public class CommandArgCollection<TCommand> where TCommand : class, ICommand
    {
        private readonly ICommandArgument<TCommand>[] _commandArgs;

        public CommandArgCollection(params ICommandArgument<TCommand>[] args)
        {
            _commandArgs = args;
        }

        public void ApplyArguments(TCommand command, string[] args)
        {
            for (int i = 0; i < _commandArgs.Length; i++)
            {
                ICommandArgument<TCommand> arg = _commandArgs[i];
                arg.ModifyCommand(command, enabled: args.Any(c => arg.IsValidArgString(c)));
            }
        }
    }
}
