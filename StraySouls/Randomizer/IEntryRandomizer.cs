using System.Collections.Generic;
using StraySouls.Wrapper;

namespace StraySouls
{
    public interface IEntryRandomizer<TEntry, TWrapper> where TWrapper : ISoulsFormatsEntryWrapper<TWrapper, TEntry>
    {
        void Randomize(List<TEntry> entries);
    }
}