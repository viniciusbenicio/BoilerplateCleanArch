using System;

namespace BoilerplateCleanArch.API.DTO.Token
{
    public class UserTokenDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
