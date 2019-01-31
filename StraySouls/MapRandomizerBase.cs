using System.Collections.Generic;
using System.Linq;
using SoulsFormats;

namespace StraySouls
{
    public abstract class MapRandomizerBase<TEntry, TProperties> : IMapRandomizer<TEntry> where TEntry : MSB3.Entry where TProperties : IRandomizedProperties<TEntry>, new()
    {
        public void Randomize(ref List<TEntry> entries)
        {
            ModifyBeforeRandomize(entries);

            var randomTargets = entries.Where(CanBeRandomized).ToArray();
            var randomProperties = new TProperties[randomTargets.Length];

            for (int i = 0; i < randomTargets.Length; i++)
            {
                var properties = new TProperties();
                properties.RecordProperty(randomTargets[i]);
                randomProperties[i] = properties;
            }

            randomTargets.Shuffle();
            for (int i = 0; i < randomTargets.Length; i++)
                randomProperties[i].ApplyToEntry(randomTargets[i]);
        }

        protected virtual void ModifyBeforeRandomize(List<TEntry> entries) { }

        protected virtual bool CanBeRandomized(TEntry item) => true;
    }
}
