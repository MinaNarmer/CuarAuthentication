using CuarAuthentication.Domain.Context;
using CuarAuthentication.Domain.IPersistance;
using Microsoft.EntityFrameworkCore;

namespace CuarAuthentication.Domain.Persistance
{
	public class DbFactory : Disposable, IDbFactory
	{
		DbContextOptions<CuraAuthDbContext> _options;
		public DbFactory(DbContextOptions<CuraAuthDbContext> options)
		{
			_options = options;
		}
        CuraAuthDbContext dbContext;

		public CuraAuthDbContext Init()
		{
			return dbContext ?? (dbContext = new CuraAuthDbContext(_options));
		}

		protected override void DisposeCore()
		{
			if (dbContext != null)
				dbContext.Dispose();
		}
	}
}
