using System.Collections.Generic;
using System.Linq;
using SoulsFormats;

namespace StraySouls
{
    public abstract class MapRandomizerBase<TEntry, TProperties> : IMapRandomizer<TEntry> where TEntry : MSB3.Entry where TProperties : IRandomizedProperties<TEntry>, new()
    {
        protected TEntry[] _randomizableEntries { get; private set; }
        protected TProperties[] _randomizeProperties { get; private set; }

        public void Randomize(ref List<TEntry> entries)
        {
            ModifyBeforeRandomize(entries);

            _randomizableEntries = entries.Where(CanBeRandomized).ToArray();
            _randomizeProperties = new TProperties[_randomizableEntries.Length];

            for (int i = 0; i < _randomizableEntries.Length; i++)
            {
                var properties = new TProperties();
                properties.RecordProperty(_randomizableEntries[i]);
                _randomizeProperties[i] = properties;
            }

            _randomizableEntries.Shuffle();
            for (int i = 0; i < _randomizableEntries.Length; i++)
                _randomizeProperties[i].ApplyToEntry(_randomizableEntries[i]);

            ModifyAfterRandomize(entries);
        }

        protected virtual void ModifyBeforeRandomize(List<TEntry> entries) { }

        protected virtual bool CanBeRandomized(TEntry item) => true;

        protected virtual void ModifyAfterRandomize(List<TEntry> entries) { }
    }
}
