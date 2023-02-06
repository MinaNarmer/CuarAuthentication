

namespace CuarAuthentication.DomainService.Dtos.UserFeature
{
    public class UserFeaturesAndRolesDto
    {
        public string RoleName { get; set; }
        public List<FeatureDto> UserFeatures { get; set; }
    }
}
