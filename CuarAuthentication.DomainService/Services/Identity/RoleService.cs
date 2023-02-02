using CuarAuthentication.Domain.Constants;
using CuarAuthentication.DomainService.IServices;
using System.Collections.Generic;

namespace CuarAuthentication.DomainService.Services
{
    public class RoleService : IRoleService
    {
        public List<string> GetRoles()
        {
            return new List<string>() { RolesNames.Admin, RolesNames.Player };
        }

    }
}
