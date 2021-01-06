using Microsoft.EntityFrameworkCore;

namespace BOTW.Models
{
  public class BOTWContext : DbContext
  {
    public DbSet<Character> Characters { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Style> Styles { get; set; }
    public DbSet<CharacterLocationStyle> CharacterLocationStyle { get; set; }
    public BOTWContext(DbContextOptions options) : base(options) { }
  }
}