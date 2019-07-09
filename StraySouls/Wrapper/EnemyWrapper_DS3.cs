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

        public string WalkRouteName { get; private set; }

        public void AssignEntry(Enemy entry)
        {
            ModelName = entry.ModelName;
            TalkID = entry.TalkID;
            NPCParamID = entry.NPCParamID;
            CharaInitID = entry.CharaInitID;
            ThinkParamID = entry.ThinkParamID;
            EventEntityID = entry.EventEntityID;
            WalkRouteName = entry.WalkRouteName;
        }

        public void ReadToEntry(Enemy result)
        {
            result.ModelName = ModelName;
            result.TalkID = TalkID;
            result.NPCParamID = NPCParamID;
            result.CharaInitID = CharaInitID;
            result.ThinkParamID = ThinkParamID;
            result.EventEntityID = EventEntityID;
            result.WalkRouteName = WalkRouteName;
        }
    }
}