using DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase;

public class MusicSelectionDbContext : DbContext
{
    public MusicSelectionDbContext(DbContextOptions<MusicSelectionDbContext> options) : base(options)
    {
    }
    
    public DbSet<SongEntity> Songs { get; set; }
    
}