using System;
using System.Collections.Generic;
using System.Text;

namespace CuarAuthentication.DomainService.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
    }
}
