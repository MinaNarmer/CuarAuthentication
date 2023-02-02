using CuarAuthentication.Domain.Context;
using CuarAuthentication.Domain.IPersistance;

namespace CuarAuthentication.Domain.Persistance
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IDbFactory _dbFactory;
		private CuraAuthDbContext _dbcontext;
		public UnitOfWork(IDbFactory dbFactory)
		{
			_dbFactory = dbFactory;
			_dbcontext = _dbcontext ?? (_dbcontext = dbFactory.Init());
		}
		public CuraAuthDbContext DbContext
		{
			get { return _dbcontext ?? (_dbcontext = _dbFactory.Init()); }

		}

		public void SaveChanges()
		{
			_dbcontext.SaveChanges();
		}

		public Task SaveChangesAsync()
		{
			return _dbcontext.SaveChangesAsync();
		}
	}
}
