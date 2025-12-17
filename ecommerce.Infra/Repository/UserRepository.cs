
using Dapper;
using ecommerce.Core.DTO;
using ecommerce.Core.Entities;
using ecommerce.Core.RepositoryContracts;
using ecommerce.Infra.DbContext;

namespace ecommerce.Infra.Repository
{
    internal class UserRepository : IUSerRepository
    {
        private readonly DapperDbContext _dapperDbContext;

        public UserRepository(DapperDbContext dbContext)
        {
            _dapperDbContext = dbContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserId = Guid.NewGuid();

            string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";
           int rowaffected= await _dapperDbContext.DbConnection.ExecuteAsync(query,user);
            if (rowaffected > 0)
            {
                return user;
            }
            return null;
        }

        public async Task<ApplicationUser?> GetUserByEmailandPassword(string? email, string? password)
        {
            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
            var parameters = new { Email = email, Password = password };

            ApplicationUser? user = await _dapperDbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

            return user;
        }
    }
}
