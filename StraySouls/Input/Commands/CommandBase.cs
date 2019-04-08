namespace StraySouls.Input
{
    public abstract class CommandBase<T> : ICommand where T : CommandBase<T>
    {
        protected virtual CommandArgCollection<T> Arguments { get => null; }

        public void Command(Game game, string filePath, string[] args)
        {
            if (Arguments != null)
                Arguments.AppendArgsTo(this as T, args);
            Execute(game, filePath);
        }

        protected abstract void Execute(Game game, string filePath);
    }
}
