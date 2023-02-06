using CuarAuthentication.DomainService.Dtos.UserFeature;

namespace CuarAuthentication.DomainService.IServices
{
    public interface IRoleService
    {
        List<string> GetRoles();
        Task<List<UserFeaturesAndRolesDto>> GetUserRolesAndFeaturesAsync();
    }
}