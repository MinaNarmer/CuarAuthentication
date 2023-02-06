using CuarAuthentication.Domain.Common;
using System;
using System.Collections.Generic;

namespace CuarAuthentication.Domain.Features
{
    public class Feature : Entity, IDeletedEntity, IAuditEntity
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModificationUser { get; set; }
        public DateTime? ModificationDate { get; set; }
        public List<UserFeature> UserFeatures { get; set; }
    }
}
