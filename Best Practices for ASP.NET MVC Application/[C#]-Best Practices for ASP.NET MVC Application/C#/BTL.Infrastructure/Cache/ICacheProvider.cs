namespace BTL.Infrastructure.Cache
{
    public interface ICacheProvider
    {
        IExCache Instance { get; }
    }
}