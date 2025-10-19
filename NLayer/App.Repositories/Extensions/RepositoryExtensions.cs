using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Repositories.Extensions;

public static class RepositoryExtensions
{
    //IServisCollection gibi  ASP.NET Core APIs in a class library internetden asagidaki eklenmeli
    /*
     *
       <ItemGroup>
         <FrameworkReference Include="Microsoft.AspNetCore.App" />
       </ItemGroup>
     */
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();
            // guvenli olarak model uzerinden connection string alinir
            options.UseSqlServer(connectionString!.SqlServer, //! ile null gelmicegi belirtilir
                builder => { builder.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName); });
            //assemly ile migrations yapilacagi yer belirtilir ornek birden fazla contect veya context orda olunmasi istenmiyor vs
        });
        return services;
    }
}