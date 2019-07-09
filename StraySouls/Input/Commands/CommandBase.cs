using StraySouls.Input.Arguments;

namespace StraySouls.Input
{
    public abstract class CommandBase<T> : ICommand where T : CommandBase<T>
    {
        protected virtual CommandArgCollection<T> AvailableArguments { get => null; }

        public void Command(string filePath, string fileName, string[] args)
        {
            if (AvailableArguments != null)
                AvailableArguments.ApplyArguments(this as T, args);
            Execute(filePath, fileName);
        }

        protected abstract void Execute(string filePath, string fileName);
    }
}
