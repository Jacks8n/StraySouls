using System.Collections.Generic;
using SoulsFormats;

namespace StraySouls
{
    public interface IMapRandomizer<T> where T : MSB3.Entry
    {
        void Randomize(IEnumerable<T> entries);
    }
}
