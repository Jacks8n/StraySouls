using System.Collections.Generic;
using System.Linq;
using StraySouls.Wrapper;

namespace StraySouls
{
    public abstract class MapRandomizerBase<TEntry, TProperties> : IMapRandomizer<TEntry> where TEntry : ISFWrapper where TProperties : IRandomProperties<TEntry>, new()
    {
        public delegate void EnemyRandomDelegate(TEntry[] availableEntries, TProperties[] matchingProperties, List<TEntry> msbEnemies);

        public event EnemyRandomDelegate BeforeApply;

        public event EnemyRandomDelegate OnRandomizeEnd;

        protected TEntry[] RandomizedEntries { get; private set; }

        protected TProperties[] RandomizeProperties { get; private set; }

        public List<TEntry> Randomize(List<TEntry> entries)
        {
            ModifyBeforeRandomize(entries);

            RandomizedEntries = entries.Where(CanBeRandomized).ToArray();
            RandomizeProperties = new TProperties[RandomizedEntries.Length];

            for (int i = 0; i < RandomizedEntries.Length; i++)
            {
                var properties = new TProperties();
                properties.RecordProperty(RandomizedEntries[i]);
                RandomizeProperties[i] = properties;
            }

            RandomizedEntries.Shuffle();
            BeforeApply?.Invoke(RandomizedEntries, RandomizeProperties, entries);
            for (int i = 0; i < RandomizedEntries.Length; i++)
                RandomizeProperties[i].ApplyToEntry(RandomizedEntries[i]);

            ModifyAfterRandomize(entries);
            OnRandomizeEnd?.Invoke(RandomizedEntries, RandomizeProperties, entries);

            Clear();
            return entries;
        }

        public virtual void Clear()
        {
            BeforeApply = null;
            OnRandomizeEnd = null;
            RandomizedEntries = null;
            RandomizeProperties = null;
        }

        protected virtual void ModifyBeforeRandomize(List<TEntry> entries) { }

        protected virtual bool CanBeRandomized(TEntry item) => true;

        protected virtual void ModifyAfterRandomize(List<TEntry> entries) { }
    }
}
