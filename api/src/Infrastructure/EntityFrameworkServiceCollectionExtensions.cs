using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddAppDbContext(this IServiceCollection serviceCollection, [NotNull] string connectionString)
        {
            serviceCollection.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
                // Handle NpgSql Legacy Support for `timestamp without timezone` issue
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            });
        }
}
