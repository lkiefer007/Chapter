using Chapter.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Chapter.Contexts
{
    public class ChapterContext : DbContext
    {
        public ChapterContext() { }
        public ChapterContext (DbContextOptions<ChapterContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-VCOS33J\\SQLEXPRESS ; Initial Catalog = Chapter; Integrated Security = True; Trust Server Certificate=true");
            }

           
        }
        public DbSet<Livro> Livros { get; set; }
        public object Livro { get; internal set; }
    }
}
