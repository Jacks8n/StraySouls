using System.Collections.Generic;
using StraySouls.Wrapper;

namespace StraySouls
{
    public interface IMapRandomizer<TEntry> where TEntry : ISFWrapper
    {
        List<TEntry> Randomize(List<TEntry> entries);
    }
}