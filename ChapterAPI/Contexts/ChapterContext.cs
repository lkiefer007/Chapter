using ChapterAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ChapterAPI.Contexts
{
    public class ChapterContext : DbContext
    {
        public ChapterContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!OptionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-VCOS33J;initial catalog = Chapter; Integrated Security = true");
            }
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }    
      
    }
}
