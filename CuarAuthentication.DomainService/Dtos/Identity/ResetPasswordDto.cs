using System;
using System.Collections.Generic;
using System.Text;

namespace CuarAuthentication.DomainService.Dtos
{
    public class ResetPasswordDto
    {
        public int UserId { get; set; }
        public string Password { get; set; }
    }
}
