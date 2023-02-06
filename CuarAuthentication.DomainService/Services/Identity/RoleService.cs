using CuarAuthentication.Domain.Constants;
using CuarAuthentication.Domain.Identity;
using CuarAuthentication.DomainService.Dtos.UserFeature;
using CuarAuthentication.DomainService.IServices;
using Microsoft.AspNetCore.Identity;

namespace CuarAuthentication.DomainService.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public List<string> GetRoles()
        {
            return new List<string>() { RolesNames.Admin, RolesNames.Player };
        }

        public Task<List<UserFeaturesAndRolesDto>> GetUserRolesAndFeaturesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
