using Treasure = SoulsFormats.MSB3.Event.Treasure;

namespace StraySouls
{
    public class TreasureRandomProperties : IRandomizedProperties<Treasure>
    {
        private int _ItemLot1,_ItemLot2;

        public void ApplyToEntry(Treasure entry)
        {
            entry.ItemLot1 = _ItemLot1;
            entry.ItemLot2 = _ItemLot2;
        }

        public void RecordProperty(Treasure entry)
        {
            _ItemLot1 = entry.ItemLot1;
            _ItemLot2 = entry.ItemLot2;
        }
    }
}
