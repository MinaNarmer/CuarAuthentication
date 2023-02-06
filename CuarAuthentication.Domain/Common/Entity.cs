using System.ComponentModel.DataAnnotations;

namespace CuarAuthentication.Domain.Common
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
