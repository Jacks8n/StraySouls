using System;
using Enemy = SoulsFormats.MSBS.Part.Enemy;

namespace StraySouls.Wrapper
{
    public class EnemyWrapper_Sekiro : ISoulsFormatsEntryWrapper<EnemyWrapper_Sekiro, Enemy>
    {
        public string ModelName;

        public int NPCParamID;

        public int CharaInitID;

        public int ThinkParamID;

        public int EntityID;

        public string Name;

        public int[] EntityGroupsIDs;

        public void AssignEntry(Enemy entry)
        {
            ModelName = entry.ModelName;
            NPCParamID = entry.NPCParamID;
            CharaInitID = entry.CharaInitID;
            ThinkParamID = entry.ThinkParamID;
            EntityID = entry.EntityID;
            Name = entry.Name;
            if (EntityGroupsIDs == null)
                EntityGroupsIDs = new int[entry.EntityGroupIDs.Length];
            else if (EntityGroupsIDs.Length != entry.EntityGroupIDs.Length)
                Array.Resize(ref EntityGroupsIDs, entry.EntityGroupIDs.Length);
            entry.EntityGroupIDs.CopyTo(EntityGroupsIDs, 0);
        }

        public void ReadToEntry(Enemy result)
        {
            result.ModelName = ModelName;
            result.NPCParamID = NPCParamID;
            result.CharaInitID = CharaInitID;
            result.ThinkParamID = ThinkParamID;
            result.EntityID = EntityID;
            result.Name = Name;
            EntityGroupsIDs.CopyTo(result.EntityGroupIDs, 0);
        }
    }
}