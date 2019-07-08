namespace StraySouls.Wrapper
{
    public interface ISoulsFormatsEntryWrapper<T, TEntry> where T : ISoulsFormatsEntryWrapper<T, TEntry>
    {
        void AssignEntry(TEntry entry);

        void AssignWrapper(T wrapper);

        void ReadToEntry(TEntry result);
    }
}
