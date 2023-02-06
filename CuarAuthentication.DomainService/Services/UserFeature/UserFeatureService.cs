using AutoMapper;
using CuarAuthentication.Domain.IPersistance;
using CuarAuthentication.Domain.IRepositories;
using CuarAuthentication.DomainService.Dtos.UserFeature;
using CuarAuthentication.DomainService.Helpers;
using CuarAuthentication.DomainService.IServices.UserFeature;
using Microsoft.EntityFrameworkCore;

namespace CuarAuthentication.DomainService.Services.UserFeature
{
    public class UserFeatureService : BaseService, IUserFeatureService
    {
        private readonly IUserFeatureRepository _repo;
        public UserFeatureService(IMapper mapper, IUnitOfWork unitOfWork
            , IUserFeatureRepository repo)
            : base(mapper, unitOfWork)
        {
            _repo = repo;
        }

        public async Task<List<FeatureDto>> GetFeaturesListByUserId(int userId)
        {
            var features = await _repo.GetAll()
                .Where(x => x.ApplicationUserId == userId)
                .Select(x => x.Feature)
                .ToListAsync();
            return _mapper.Map<List<FeatureDto>>(features);
        }
    }
}
