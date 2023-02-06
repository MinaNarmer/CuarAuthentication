
using CuarAuthentication.Domain.Common;
using CuarAuthentication.Domain.Identity;

namespace CuarAuthentication.Domain.Features
{
    public class UserFeature : Entity, IDeletedEntity, IAuditEntity
    {
        public int FeatureId { get; set; }
        public int ApplicationUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime? ModificationDate { get; set; }

        public ApplicationUser User { get; set; }
        public Feature Feature { get; set; }
    }
}
