using System;

namespace BoilerplateCleanArch.API.DTO
{
    public class UserTokenDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
