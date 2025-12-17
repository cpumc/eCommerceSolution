using ecommerce.Core.RepositoryContracts;
using ecommerce.Infra.DbContext;
using ecommerce.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ecommerce.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IUSerRepository, UserRepository>();
        services.AddTransient<DapperDbContext>();
        return services; 
    }
}

