using Entry = SoulsFormats.MSB3.Entry;

namespace StraySouls.Input
{
    public interface ICommand
    {
        void Command(Game game, string filePath, string[] args);
    }

    public interface IRandomCommand<TEntry, TRandomizer> : ICommand where TEntry : Entry where TRandomizer : class, IMapRandomizer<TEntry>
    {
        TRandomizer Randomizer { get; }
    }
}