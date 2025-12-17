using ecommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.Core.ServiceContracts
{
    public interface IUserService
    {
        Task<AuthenticationResponse?> Login(LoginRequest login);

        Task<AuthenticationResponse?> Register(RegisterRequest register);
    }
}
