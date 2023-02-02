using CuarAuthentication.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;

namespace CuarAuthentication.Domain.Identity
{
    public class ApplicationUser : IdentityUser<int>, IDeletedEntity, IAuditEntity
    {
        public string RefreshToken { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
