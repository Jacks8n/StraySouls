using Enemy = SoulsFormats.MSB3.Part.Enemy;

namespace StraySouls.Wrapper
{
    public class EnemyWrapper_DS3 : ISoulsFormatsEntryWrapper<EnemyWrapper_DS3, Enemy>
    {
        public string ModelName { get; private set; }

        public int TalkID { get; private set; }

        public int NPCParamID { get; private set; }

        public int CharaInitID { get; private set; }

        public int ThinkParamID { get; private set; }

        public int EventEntityID { get; private set; }

        public int EventFlagID { get; private set; }

        public string WalkRouteName { get; private set; }

        public string EntryName { get => _enemy.Name; set => _enemy.Name = value; }

        private Enemy _enemy;

        public void AssignEntry(Enemy entry)
        {
            _enemy = entry;
            TalkID = entry.TalkID;
            NPCParamID = entry.NPCParamID;
            CharaInitID = entry.CharaInitID;
            ThinkParamID = entry.ThinkParamID;
            EventEntityID = entry.EventEntityID;
            EventFlagID = entry.EventEntityID;
            WalkRouteName = entry.WalkRouteName;
        }

        public void AssignWrapper(EnemyWrapper_DS3 wrapper)
        {
            AssignEntry(wrapper._enemy);
            _enemy = null;
        }

        public void ReadToEntry(Enemy result)
        {
            TalkID = result.TalkID;
            NPCParamID = result.NPCParamID;
            CharaInitID = result.CharaInitID;
            ThinkParamID = result.ThinkParamID;
            EventEntityID = result.EventEntityID;
            EventFlagID = result.EventEntityID;
            WalkRouteName = result.WalkRouteName;
        }
    }
}