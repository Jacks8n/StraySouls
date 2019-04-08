using System.Linq;

namespace StraySouls.Input
{
    public class CommandArgCollection<TCommand> where TCommand : class, ICommand
    {
        private readonly ICommandArg<TCommand>[] _commandArgs;

        public CommandArgCollection(params ICommandArg<TCommand>[] args)
        {
            _commandArgs = new ICommandArg<TCommand>[args.Length];
            args.CopyTo(_commandArgs, index: 0);
        }

        public void AppendArgsTo(TCommand command, string[] charArgs)
        {
            for (int i = 0; i < _commandArgs.Length; i++)
            {
                ICommandArg<TCommand> arg = _commandArgs[i];
                arg.GetCommandArg(command,
                    enabled: charArgs.Any(c => arg.TryEnable(c)));
            }
        }
    }
}
