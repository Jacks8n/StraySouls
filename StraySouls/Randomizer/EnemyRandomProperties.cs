using StraySouls.Wrapper;

namespace StraySouls
{
    public struct EnemyRandomProperties : IRandomProperties<EnemyWrapper>
    {
        private string _modelName;

        private int _talkID;

        private int _NPCParamID;

        private int _charaInitID;

        private int _thinkParamID;

        private int _eventEntityID;

        private int _eventFlagID;

        private int _entityID;

        public EnemyRandomProperties(EnemyWrapper enemy)
        {
            _modelName = enemy.ModelName;
            _NPCParamID = enemy.NPCParamID;
            _thinkParamID = enemy.ThinkParamID;
            _eventEntityID = enemy.EventEntityID;
            _charaInitID = enemy.CharaInitID;
            _talkID = enemy.TalkID;
            _eventFlagID = enemy.EventFlagID;
            _entityID = enemy.EntityID;
        }

        public void RecordProperty(EnemyWrapper enemy)
        {
            _modelName = enemy.ModelName;
            _NPCParamID = enemy.NPCParamID;
            _thinkParamID = enemy.ThinkParamID;
            _eventEntityID = enemy.EventEntityID;
            _charaInitID = enemy.CharaInitID;
            _talkID = enemy.TalkID;
            _eventFlagID = enemy.EventFlagID;
            _entityID = enemy.EntityID;
        }

        public void ApplyToEntry(EnemyWrapper enemy)
        {
            enemy.ModelName = _modelName;
            enemy.NPCParamID = _NPCParamID;
            enemy.ThinkParamID = _thinkParamID;
            enemy.EventEntityID = _eventEntityID;
            enemy.CharaInitID = _charaInitID;
            enemy.TalkID = _talkID;
            enemy.EventFlagID = _eventFlagID;
            enemy.EntityID = _entityID;
        }
    }
}
