using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class NotesDbContext : DbContext
{
    public NotesDbContext(DbContextOptions<NotesDbContext> options)
        : base(options)
    {
        
    }
}
