using System.Collections.Generic;
using System.Linq;
using SoulsFormats;

namespace StraySouls
{
    public abstract class MapRandomizerBase<TEntry, TProperties> : IMapRandomizer<TEntry> where TEntry : MSB3.Entry where TProperties : IRandomProperties<TEntry>, new()
    {
        public delegate void EnemyRandomDelegate(TEntry[] availableEntries, TProperties[] matchingProperties, List<TEntry> msbEnemies);

        public event EnemyRandomDelegate BeforeApply;
        public event EnemyRandomDelegate OnRandomizeEnd;

        protected TEntry[] _randomizedEntries { get; private set; }
        protected TProperties[] _randomizeProperties { get; private set; }

        public void Randomize(List<TEntry> entries)
        {
            ModifyBeforeRandomize(entries);

            _randomizedEntries = entries.Where(CanBeRandomized).ToArray();
            _randomizeProperties = new TProperties[_randomizedEntries.Length];

            for (int i = 0; i < _randomizedEntries.Length; i++)
            {
                var properties = new TProperties();
                properties.RecordProperty(_randomizedEntries[i]);
                _randomizeProperties[i] = properties;
            }

            _randomizedEntries.Shuffle();
            BeforeApply?.Invoke(_randomizedEntries, _randomizeProperties, entries);
            for (int i = 0; i < _randomizedEntries.Length; i++)
                _randomizeProperties[i].ApplyToEntry(_randomizedEntries[i]);

            ModifyAfterRandomize(entries);
            OnRandomizeEnd?.Invoke(_randomizedEntries, _randomizeProperties, entries);

            Clear();
        }

        public virtual void Clear()
        {
            BeforeApply = null;
            OnRandomizeEnd = null;
            _randomizedEntries = null;
            _randomizeProperties = null;
        }

        protected virtual void ModifyBeforeRandomize(List<TEntry> entries) { }

        protected virtual bool CanBeRandomized(TEntry item) => true;

        protected virtual void ModifyAfterRandomize(List<TEntry> entries) { }
    }
}
