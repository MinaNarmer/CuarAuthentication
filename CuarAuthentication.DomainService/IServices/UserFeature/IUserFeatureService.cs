using CuarAuthentication.DomainService.Dtos.UserFeature;

namespace CuarAuthentication.DomainService.IServices.UserFeature
{
    public interface IUserFeatureService
    {
        Task<List<FeatureDto>> GetFeaturesListByUserId(int userId);
    }
}
