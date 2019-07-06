using System.Collections.Generic;
using System.Linq;
using StraySouls.Wrapper;

namespace StraySouls
{
    public abstract class MapRandomizerBase<TEntry, TProperties> : IMapRandomizer<TEntry> where TEntry : ISFWrapper where TProperties : IRandomProperties<TEntry>, new()
    {
        public delegate void EntryRandomDelegate(TEntry[] availableEntries, TProperties[] matchingProperties, List<TEntry> msbEntries);

        public event EntryRandomDelegate BeforeApplyRandomization;

        public event EntryRandomDelegate OnRandomizeEnd;

        protected TEntry[] RandomizedEntries { get; private set; }

        protected TProperties[] OriginalProperties { get; private set; }

        public List<TEntry> Randomize(List<TEntry> entries)
        {
            ModifyBeforeRandomize(entries);

            RandomizedEntries = entries.Where(CanBeRandomized).ToArray();
            OriginalProperties = new TProperties[RandomizedEntries.Length];

            for (int i = 0; i < RandomizedEntries.Length; i++)
            {
                TProperties properties = new TProperties();
                properties.RecordProperty(RandomizedEntries[i]);
                OriginalProperties[i] = properties;
            }

            RandomizedEntries.Shuffle();
            BeforeApplyRandomization?.Invoke(RandomizedEntries, OriginalProperties, entries);

            for (int i = 0; i < RandomizedEntries.Length; i++)
                OriginalProperties[i].ApplyToEntry(RandomizedEntries[i]);

            ModifyAfterApplyRandomization(entries);
            OnRandomizeEnd?.Invoke(RandomizedEntries, OriginalProperties, entries);

            return entries;
        }

        public virtual void Clear()
        {
            BeforeApplyRandomization = null;
            OnRandomizeEnd = null;
        }

        protected virtual void ModifyBeforeRandomize(List<TEntry> entries) { }

        protected virtual bool CanBeRandomized(TEntry item) => true;

        protected virtual void ModifyAfterApplyRandomization(List<TEntry> entries) { }
    }
}
