

namespace CuarAuthentication.Domain.IPersistance
{
	public interface IUnitOfWork
	{
		void SaveChanges();
		Task SaveChangesAsync();
	}
}
