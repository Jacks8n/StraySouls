using SoulsFormats;

namespace StraySouls
{
    public interface IRandomProperties<T> where T : MSB3.Entry
    {
        void RecordProperty(T entry);

        void ApplyToEntry(T entry);
    }
}
