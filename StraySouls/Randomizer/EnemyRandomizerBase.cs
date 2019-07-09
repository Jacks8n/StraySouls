using SoulsFormats;
using System.Linq;
using System.Collections.Generic;
using StraySouls.Wrapper;

namespace StraySouls
{
    public abstract class EnemyRandomizerBase<TEntry, TWrapper> : EntryRandomizerBase<TEntry, TWrapper> where TEntry : class where TWrapper : ISoulsFormatsEntryWrapper<TWrapper, TEntry>, new()
    {
        public List<string> SkipIDs { get; } = new List<string>();

        public List<string> IDsToDuplicateAndRandomize { get; } = new List<string>();

        public EnemyRandomizerBase() { }

        public override void Clear()
        {
            base.Clear();
            SkipIDs.Clear();
            IDsToDuplicateAndRandomize.Clear();
        }

        protected override void AfterSelectRandomizableBeforeRandomize()
        {
            for (int i = OriginalEntries.Count - 1; i > -1; i--)
            {
                TEntry entry = OriginalEntries[i];
                if (IDsToDuplicateAndRandomize.Any((id) => entry.GetName().StartsWith(id)))
                {
                    TEntry clone = entry.Clone();
                    OriginalEntries.Add(clone);
                    RandomizableEntries.Add(clone);
                    AssociatedWrappers.Add(clone.GetWrapper<TWrapper, TEntry>());
                }
            }
        }

        protected override bool IsRandomizable(TEntry entry)
        {
            return !SkipIDs.Any((id) => entry.GetName().StartsWith(id));
        }
    }
}