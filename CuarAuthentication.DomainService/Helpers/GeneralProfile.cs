using AutoMapper;
using CuarAuthentication.Domain.Features;
using CuarAuthentication.DomainService.Dtos.UserFeature;

namespace CuarAuthentication.DomainService.Helpers
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Feature, FeatureDto>().ReverseMap() ;
        }
    }
}
