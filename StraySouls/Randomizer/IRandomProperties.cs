using StraySouls.Wrapper;

namespace StraySouls
{
    public interface IRandomProperties<T> where T : ISFWrapper
    {
        void RecordProperty(T entry);

        void ApplyToEntry(T entry);
    }
}
