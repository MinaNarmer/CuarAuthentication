
using CuarAuthentication.Domain.Features;
using CuarAuthentication.Domain.IPersistance;
using CuarAuthentication.Domain.IRepositories;
using CuarAuthentication.Domain.Persistance;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;

namespace CuarAuthentication.Domain.Repositories
{
    public class UserFeatureRepository : RepositoryBase<UserFeature>, IUserFeatureRepository
    {
        public UserFeatureRepository(IDbFactory dbFactory)
           : base(dbFactory) { }
    }
}
