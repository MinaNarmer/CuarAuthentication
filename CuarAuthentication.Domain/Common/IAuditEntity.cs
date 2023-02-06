
namespace CuarAuthentication.Domain.Common
{
    public interface IAuditEntity
    {
        string CreationUser { get; set; }
        DateTime CreationDate { get; set; }
        string ModificationUser { get; set; }
        DateTime? ModificationDate { get; set; }
    }
}
