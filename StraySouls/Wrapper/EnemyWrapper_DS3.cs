using Enemy = SoulsFormats.MSB3.Part.Enemy;

namespace StraySouls.Wrapper
{
    public class EnemyWrapper_DS3 : ISoulsFormatsEntryWrapper<EnemyWrapper_DS3, Enemy>
    {
        public string ModelName;

        public int TalkID;

        public int NPCParamID;

        public int CharaInitID;

        public int ThinkParamID;

        public int EventEntityID;

        public string WalkRouteName;

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