using System.Collections.Generic;
using System.Linq;

using Enemy = SoulsFormats.MSB3.Part.Enemy;

namespace StraySouls
{
    public class EnemyRandomizer : MapRandomizerBase<Enemy, EnemyRandomProperties>
    {
        private static readonly string[] ID_MUST_SKIP = new string[]
        {
            //These might be bonfires and etc.I haven't tested
            "c0100_0000","c0100_0001","c0100_0002","c0100_0003","c0100_0004",
            "c0100_0005","c0100_0006","c0100_0007","c0100_0009","c0100_0010",
            "c0100_0011","c0100_0012","c0100_0013","c0100_0014","c0100_0015",
            "c0100_0016","c0100_0017","c1000_0000","c1000_0001","c1000_0002",
            "c1000_0003","c1000_0004","c1000_0005","c1000_0006","c1000_0007",
            "c1000_0008","c1000_0009","c1000_0010","c1000_0011","c1000_0012",
            "c1000_0013","c1000_0014","c1000_0015","c1000_0016","c1000_0017",
            "c1000_0018","c5020_0000","c5021_0000","c5022_0000","c5022_0001",
            "c5022_0002","c5022_0003","c5250_0000",
        };

        private const string POSTFIX_CLONE = "_CL";

        private readonly List<string> _skipIDs = new List<string>();

        private readonly List<string> _additionIDs = new List<string>();

        private readonly List<EnemyRandomProperties> _additionEnemies = new List<EnemyRandomProperties>();

        public EnemyRandomizer()
        {
            _skipIDs.AddRange(ID_MUST_SKIP);
        }

        public override void Clear()
        {
            base.Clear();
            _skipIDs.Clear();
            _additionIDs.Clear();
            _additionEnemies.Clear();
        }

        public void AddSkipIDs(IEnumerable<string> IDs, bool asAddition)
        {
            _skipIDs.AddRange(IDs);
            if (asAddition)
                _additionIDs.AddRange(IDs);
        }
        
        protected override void ModifyBeforeRandomize(List<Enemy> entries)
        {
            _additionEnemies.Clear();

            foreach (var item in entries)
            {
                string name = item.Name;
                if (_additionIDs.Contains(name))
                    _additionEnemies.Add(new EnemyRandomProperties(item));
            }
        }

        protected override bool CanBeRandomized(Enemy item)
        {
            string name = item.Name;
            return !(ID_MUST_SKIP.Contains(name) || _skipIDs.FindIndex(str => name.StartsWith(str)) > -1);
        }

        protected override void ModifyAfterRandomize(List<Enemy> entries)
        {
            for (int i = 0; i < _randomizableEntries.Length && i < _additionEnemies.Count; i++)
            {
                var clone = new Enemy(_randomizableEntries[i]);
                _additionEnemies[i].ApplyToEntry(clone);
                clone.Name += POSTFIX_CLONE;
                entries.Add(clone);
            }
        }
    }
}