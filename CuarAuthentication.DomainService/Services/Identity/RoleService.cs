using MRS.Data.Constants;
using MRS.Services.Infrastructure.IServices;
using System.Collections.Generic;

namespace CuarAuthentication.DomainService.Services
{
    public class RoleService : IRoleService
    {
        public List<string> GetRoles()
        {
            return new List<string>() { RolesNames.Admin, RolesNames.User };
        }

    }
}
