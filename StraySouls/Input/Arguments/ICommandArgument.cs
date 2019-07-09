namespace StraySouls.Input.Arguments
{
    public interface ICommandArgument<in TCommand> where TCommand : class, ICommand
    {
        bool IsValidArgString(string arg);

        void ModifyCommand(TCommand command, bool enabled);
    }
}
