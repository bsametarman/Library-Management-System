using LibraryManagementSystem.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DataAccess.Concrete
{
    public class LibraryContext : DbContext
    {

        //public LibraryContext() : base("name=LibraryManagementSystemContext")
        //{
        //    this.Configuration.LazyLoadingEnabled = false;
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Configration for combining db tables(not being used anymore)


        //   modelBuilder.Entity<Author>()
        //       .HasMany(a => a.Books)
        //       .WithRequired(b => b.Author)
        //       .HasForeignKey(b => b.AuthorId);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = LibraryManagementSystem; Integrated Security = true;");
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
