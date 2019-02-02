using Entry = SoulsFormats.MSB3.Entry;

namespace StraySouls
{
    public interface ICommand
    {
        void Command(string msbName, char[] args);
    }

    public interface IRandomCommand<TEntry, TRandomizer> : ICommand where TEntry : Entry where TRandomizer : class, IMapRandomizer<TEntry>
    {
        TRandomizer Randomizer { get; }
    }
}