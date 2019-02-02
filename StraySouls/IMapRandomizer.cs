using System.Collections.Generic;
using SoulsFormats;

namespace StraySouls
{
    public interface IMapRandomizer<TEntry> where TEntry : MSB3.Entry
    {
        void Randomize(List<TEntry> entries);
    }
}
