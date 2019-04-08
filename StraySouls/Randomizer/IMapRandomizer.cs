using System.Collections.Generic;
using StraySouls.Wrapper;

namespace StraySouls
{
    public interface IMapRandomizer<TEntry> where TEntry : ISFWrapper
    {
        void Randomize(List<TEntry> entries);
    }
}