using SoulsFormats;
using System.Collections.Generic;

namespace StraySouls.Wrapper
{
    public class EnemyWrapper : ISFWrapper
    {
        public string Name { get; set; }

        public string ModelName { get; set; }

        public int NPCParamID { get; set; }

        public int ThinkParamID { get; set; }

        public int EventEntityID { get; set; }

        public int CharaInitID { get; set; }

        public int TalkID { get; set; }

        public EnemyWrapper(EnemyWrapper clone)
        {
            Name = clone.Name;
            ModelName = clone.ModelName;
            NPCParamID = clone.NPCParamID;
            ThinkParamID = clone.ThinkParamID;
            EventEntityID = clone.EventEntityID;
            CharaInitID = clone.CharaInitID;
            TalkID = clone.TalkID;
        }

        public IEnumerable<EnemyWrapper> Read(List<MSB3.Part.Enemy> ds3Enemies)
        {
            yield return;
        }

        public IEnumerable<EnemyWrapper> Read(List<MSBN.Part> sekiroEnemy)
        {
            yield return;
        }
    }
}
