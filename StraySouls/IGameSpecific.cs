namespace StraySouls
{
    public interface IGameSpecific<T> where T : IGameSpecific<T>
    {
        T GetSpecified();
    }

    public interface IDarkSoulsSpecific<T> : IGameSpecific<T> where T : IDarkSoulsSpecific<T> { }

    public interface ISekiroSpecific<T> : IGameSpecific<T> where T : ISekiroSpecific<T> { }
}
