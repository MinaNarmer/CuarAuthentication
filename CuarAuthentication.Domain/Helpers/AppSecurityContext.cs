using CuarAuthentication.Domain.Constants;
using CuarAuthentication.Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace CuarAuthentication.Domain.Helpers
{
    public static class AppSecurityContext
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static string UserName
        {
            get
            {
                if (_httpContextAccessor != null && _httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.User != null)
                {
                    var userName = _httpContextAccessor.HttpContext.User.FindFirst(ApplicationClaims.UserName)?.Value;
                    if (userName == null)
                        throw new NoClaimException(ApplicationClaims.UserName);
                    return userName;
                }

                throw new NoClaimException(ApplicationClaims.UserName);
            }
        }

        public static int UserId
        {
            get
            {
                if (_httpContextAccessor != null && _httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.User != null)
                {
                    var userId = _httpContextAccessor.HttpContext.User.FindFirst(ApplicationClaims.UserId)?.Value;
                    if (userId == null)
                        throw new NoClaimException(ApplicationClaims.UserId);
                    return int.Parse(userId);
                }

                throw new NoClaimException(ApplicationClaims.UserId);
            }
        }
    }
}
