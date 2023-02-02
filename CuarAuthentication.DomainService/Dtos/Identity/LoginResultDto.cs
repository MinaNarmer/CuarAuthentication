using System;

namespace CuarAuthentication.DomainService.Dtos
{
    public class LoginResultDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
    }
}
