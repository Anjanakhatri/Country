using Microsoft.EntityFrameworkCore;

namespace WebAppNew.Models
{
    public class WebAppNewEntity : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<District> Districts { get; set; }
        public WebAppNewEntity(DbContextOptions option) : base(option)
        {
        }
    }
}
