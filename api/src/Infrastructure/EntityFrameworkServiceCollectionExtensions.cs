using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class EntityFrameworkServiceCollectionExtensions
{
    public static void AddNotesDbContext(this IServiceCollection serviceCollection, [NotNull] string connectionString)
        {
            serviceCollection.AddDbContext<NotesDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
                // Handle NpgSql Legacy Support for `timestamp without timezone` issue
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            });
        }
}
