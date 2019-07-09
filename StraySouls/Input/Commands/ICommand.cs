namespace StraySouls.Input
{
    public interface ICommand
    {
        void Command(string filePath, string fileName, string[] args);
    }
}