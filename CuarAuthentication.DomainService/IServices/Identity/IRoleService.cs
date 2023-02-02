using System.Collections.Generic;

namespace CuarAuthentication.DomainService.IServices
{
    public interface IRoleService
    {
        List<string> GetRoles();
    }
}