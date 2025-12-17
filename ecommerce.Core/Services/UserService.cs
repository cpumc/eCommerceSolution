using AutoMapper;
using ecommerce.Core.DTO;
using ecommerce.Core.Entities;
using ecommerce.Core.RepositoryContracts;
using ecommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IUSerRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUSerRepository uSerRepository, IMapper mapper)
        {
            _userRepository = uSerRepository;
            _mapper = mapper;
        }
        public async Task<AuthenticationResponse?> Login(LoginRequest login)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmailandPassword(login.Email, login.Password);

            if (user == null) { return null; }

            //return new AuthenticationResponse(user.UserId, user.Email, user.PersonName, user.Gender, Guid.NewGuid().ToString(), true);
            return _mapper.Map<AuthenticationResponse>(user) with { sucess = true, token = "token" };
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest register)
        {
            ApplicationUser user = new ApplicationUser()
            {
                PersonName = register.PersonName,
                Email = register.Email,
                Password = register.Password,
                Gender = register.Gender.ToString(),

            };
            ApplicationUser user1 = await _userRepository.AddUser(user);

            if (user1 == null) return null;
            return new AuthenticationResponse(user1.UserId, user1.Email, user1.PersonName, user1.Gender, Guid.NewGuid().ToString(), true)
;
        }
    }
}
