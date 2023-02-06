
namespace CuarAuthentication.Domain.Common
{
    public interface IDeletedEntity
    {
        bool IsDeleted { get; set; }
        DateTime? DeletionDate { get; set; }
    }
}
