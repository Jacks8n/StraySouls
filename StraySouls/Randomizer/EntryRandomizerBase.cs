using System;
using System.Collections.Generic;
using System.Linq;
using StraySouls.Wrapper;

namespace StraySouls
{
    public abstract class EntryRandomizerBase<TEntry, TWrapper> : IEntryRandomizer<TEntry, TWrapper> where TWrapper : ISoulsFormatsEntryWrapper<TWrapper, TEntry>, new()
    {
        public delegate void RandomizerAction(List<TEntry> originalEntries, List<TEntry> randomizableEntries, List<TWrapper> associatedWrappers);

        public event RandomizerAction OnAfterSelectRandomizableBeforeRandomize;

        protected List<TEntry> OriginalEntries { get; private set; }

        /// <summary>
        /// The list to be randomized and written to files
        /// </summary>
        protected List<TEntry> RandomizableEntries { get; } = new List<TEntry>();

        /// <summary>
        /// Wrappers for <see cref="RandomizableEntries"/>, keeping the original order
        /// </summary>
        protected List<TWrapper> AssociatedWrappers { get; } = new List<TWrapper>();

        /// <summary>
        /// Returns randomized entries, the returned list is a new object rather than <paramref name="entries"/>
        /// </summary>
        public void Randomize(List<TEntry> entries)
        {
            OriginalEntries = entries;
            BeforeEverything();

            RandomizableEntries.AddRange(entries.Where(IsRandomizable));
            AssociatedWrappers.AddRange(RandomizableEntries.Select((entry) =>
            {
                TWrapper wrapper = new TWrapper();
                wrapper.AssignEntry(entry);
                return wrapper;
            }));

            AfterSelectRandomizableBeforeRandomize();
            if (RandomizableEntries.Count != AssociatedWrappers.Count)
                throw new Exception("Ensure that RandomizableEntries and AssociatedWrappers always have equal counts");

            RandomizableEntries.Shuffle();
            for (int i = 0; i < RandomizableEntries.Count; i++)
                AssociatedWrappers[i].ReadToEntry(RandomizableEntries[i]);
        }

        public virtual void Clear()
        {
            OriginalEntries = null;
            RandomizableEntries.Clear();
            AssociatedWrappers.Clear();
        }

        protected virtual void BeforeEverything() { }

        protected virtual bool IsRandomizable(TEntry entry) => true;

        protected virtual void AfterSelectRandomizableBeforeRandomize() { }
    }
}
