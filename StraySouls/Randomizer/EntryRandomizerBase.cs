using System;
using System.Collections.Generic;
using System.Linq;
using StraySouls.Wrapper;

namespace StraySouls.Randomizer
{
    public abstract class EntryRandomizerBase<TEntry, TWrapper> : IEntryRandomizer<TEntry, TWrapper> where TWrapper : ISoulsFormatsEntryWrapper<TWrapper, TEntry>, new()
    {
        public delegate void RandomizerAction<T0, T1, T2>(List<T0> originalEntries, List<T1> randomizableEntries, List<T2> associatedWrappers);

        public event RandomizerAction<TEntry, TEntry, TWrapper> OnAfterSelectRandomizableBeforeRandomize;

        public event RandomizerAction<TEntry, TEntry, TWrapper> OnAfterEverything;

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
            AssociatedWrappers.AddRange(RandomizableEntries.Select((entry) => entry.GetWrapper<TWrapper, TEntry>()));

            OnAfterSelectRandomizableBeforeRandomize?.Invoke(OriginalEntries, RandomizableEntries, AssociatedWrappers);
            AfterSelectRandomizableBeforeRandomize();
            if (RandomizableEntries.Count != AssociatedWrappers.Count)
                throw new Exception("Ensure that RandomizableEntries and AssociatedWrappers always have equal counts");

            RandomizableEntries.Shuffle();
            for (int i = 0; i < RandomizableEntries.Count; i++)
                AssociatedWrappers[i].ReadToEntry(RandomizableEntries[i]);

            OnAfterEverything?.Invoke(OriginalEntries, RandomizableEntries, AssociatedWrappers);
        }

        public virtual void Clear()
        {
            OriginalEntries = null;
            RandomizableEntries.Clear();
            AssociatedWrappers.Clear();
            OnAfterSelectRandomizableBeforeRandomize = null;
            OnAfterEverything = null;
        }

        protected virtual void BeforeEverything() { }

        protected virtual bool IsRandomizable(TEntry entry) => true;

        protected virtual void AfterSelectRandomizableBeforeRandomize() { }
    }
}
