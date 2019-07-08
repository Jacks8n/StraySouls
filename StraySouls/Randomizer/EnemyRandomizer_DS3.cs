using SoulsFormats;
using StraySouls.Wrapper;

namespace StraySouls.Randomizer
{
    public class EnemyRandomizer_DS3 : EnemyRandomizerBase<MSB3.Part.Enemy, EnemyWrapper_DS3>
    {
        /// <summary>
        /// Frankly saying, I don't know what these are...
        /// </summary>
        private static readonly string[] ID_MUST_SKIP_DS3 = new string[]
        {
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

        public EnemyRandomizer_DS3()
        {
            SkipIDs.AddRange(ID_MUST_SKIP_DS3);
        }
    }
}
