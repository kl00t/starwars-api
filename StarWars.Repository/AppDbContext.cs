using Microsoft.EntityFrameworkCore;
using StarWars.Contracts.Data;

namespace StarWars.Repository;

public class AppDbContext : DbContext
{
    public DbSet<FilmDto> Films { get; set; }

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<FilmDto>(entity => entity.Property(p => p.Id).IsRequired());
	}
}