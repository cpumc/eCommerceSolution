using ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.Core.RepositoryContracts
{
    public interface IUSerRepository
    {
        Task<ApplicationUser?> AddUser(ApplicationUser user);
        Task<ApplicationUser?> GetUserByEmailandPassword(string? email, string? password);
    }
}
