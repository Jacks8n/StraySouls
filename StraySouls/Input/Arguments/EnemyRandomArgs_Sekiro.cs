using System.Collections.Generic;

namespace StraySouls.Input.Arguments
{
    public static class EnemyRandomArgs_Sekiro
    {
        public class RandomMainBoss : SkipListModifierBase_Sekiro
        {
            protected override IEnumerable<string> IDsToSkipOrDuplicateRandomize => ID_MAIN_BOSS;

            private static readonly string[] ID_MAIN_BOSS =
            {
            "c1130",    //Armoured Warrior (i.e. Roberrrttt!)
            "c1260",    //Folding Screen Monkeys
            "c1300",    //Mist Noble
            "c1370",    //Blazing Bull
            "c5000",    //Corrupted Monk
            "c5000",    //Corrupted Monk Illusion
            "c5010",    //Great Serpent
            "c5020",    //Chained Ogre
            "c5080",    //Gyoubu Masataka Oniwa
            "c5100",    //Guardian Ape
            "c5410",    //Isshin Ashina (???)
            "c5420",    //Isshin Ashina (???)
            "c5430",    //Isshin Ashina (Ending: Shura)
            "c7100",    //Genichiro Ashina
            "c7110",    //Genichiro Ashina (Lightning of Tomoe)
        };

            public override bool IsValidArgString(string argString)
            {
                return argString.Length == 1 && (argString[0] == 'm' || argString[0] == 'M');
            }
        }

        public class RandomFriendlyNPC : SkipListModifierBase_Sekiro
        {
            private static readonly string[] ID_FRIENDLY_NPC = new string[]
            {
            "c7200",    //The Divine Heir
            "c7210",    //The Divine Heir (3y ago)
            "c7010",    //The Sculptor
            "c7300",    //Divine Child of Rejuvenation
            "c7400",    //Emma
            "c7420",    //Anayama the Peddler
            };

            public override bool IsValidArgString(string argString)
            {
                return argString.Length == 1 && (argString[0] == 'f' || argString[0] == 'F');
            }

            protected override IEnumerable<string> IDsToSkipOrDuplicateRandomize => ID_FRIENDLY_NPC;
        }
    }
}