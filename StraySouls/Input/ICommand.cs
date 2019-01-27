namespace StraySouls
{
    public interface ICommand
    {
        void Command(string msbName, char[] args);
    }
}