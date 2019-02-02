namespace StraySouls
{
    public interface ICommandArg<in TCommand> where TCommand : class, ICommand
    {
        bool TryEnable(char argChar);

        void GetCommandArg(TCommand command, bool enabled);
    }
}
