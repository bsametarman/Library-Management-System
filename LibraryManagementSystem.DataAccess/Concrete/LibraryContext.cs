using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Entities.Concrete;
using System.Data.Entity;

namespace LibraryManagementSystem.DataAccess.Concrete
{
    public class LibraryContext : DbContext
    {

        public LibraryContext() : base("name=LibraryManagementSystemContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithRequired(b => b.Author)
                .HasForeignKey(b => b.AuthorId);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Translator> Translators { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
