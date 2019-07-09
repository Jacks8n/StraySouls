using SoulsFormats;
using StraySouls.Wrapper;

namespace StraySouls.Randomizer
{
    public class EnemyRandomizer_Sekiro : EnemyRandomizerBase<MSBS.Part.Enemy, EnemyWrapper_Sekiro>
    {
        private static readonly string[] ID_MUST_SKIP_Sekiro = new string[]
        {
            "c1001",    //Sculptor's Idol
        };

        protected override void BeforeEverything()
        {
            SkipIDs.AddRange(ID_MUST_SKIP_Sekiro);
        }
    }
}
