using CuarAuthentication.Domain.Common;
using Microsoft.AspNetCore.Identity;


namespace CuarAuthentication.Domain.Identity
{
    public class ApplicationRole : IdentityRole<int>, IDeletedEntity, IAuditEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}