
using CuarAuthentication.Domain.Features;
using CuarAuthentication.Domain.IPersistance;
using System.Diagnostics.Metrics;

namespace CuarAuthentication.Domain.IRepositories
{
    public interface IUserFeatureRepository : IRepository<UserFeature>
    {

    }
}
