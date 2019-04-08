namespace StraySouls.Input
{
    public interface ICommandArg<in TCommand> where TCommand : class, ICommand
    {
        bool TryEnable(string argChar);

        void GetCommandArg(TCommand command, bool enabled);
    }
}
