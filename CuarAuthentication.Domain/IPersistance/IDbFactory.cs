

using CuarAuthentication.Domain.Context;

namespace CuarAuthentication.Domain.IPersistance
{
    public interface IDbFactory : IDisposable
    {
        CuraAuthDbContext Init();
    }
}
