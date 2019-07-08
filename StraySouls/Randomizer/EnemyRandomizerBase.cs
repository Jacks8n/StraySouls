using System.Linq;
using System.Collections.Generic;
using StraySouls.Wrapper;

namespace StraySouls
{
    public abstract class EnemyRandomizerBase<TEntry, TWrapper> : EntryRandomizerBase<TEntry, TWrapper> where TEntry : class where TWrapper : ISoulsFormatsEntryWrapper<TWrapper, TEntry>, new()
    {
        public List<string> SkipIDs { get; } = new List<string>();

        public List<string> IDsToDuplicateAndRandomize { get; } = new List<string>();

        private const string POSTFIX_CLONE = "_CL";

        public override void Clear()
        {
            base.Clear();
            SkipIDs.Clear();
            IDsToDuplicateAndRandomize.Clear();
        }

        protected override void AfterSelectRandomizableBeforeRandomize()
        {
            string name;
            for (int i = AssociatedWrappers.Count - 1; i > -1; i--)
            {
                TWrapper wrapper = AssociatedWrappers[i];
                if (IDsToDuplicateAndRandomize.Contains(name = wrapper.GetName()))
                {
                    AssociatedWrappers.Add(wrapper.CloneWrapper<TWrapper, TEntry>());
                    RandomizableEntries.Add(RandomizableEntries[i].Clone());
                }
            }
        }

        protected override bool IsRandomizable(TEntry entry)
        {
            return !SkipIDs.Any((id) => entry.GetName().StartsWith(id));
        }
    }
}