using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LibraryManagementSystem.Entities.Concrete;

namespace LibraryManagementSystem.DataAccess.Concrete
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() 
            : base("name = LibraryManagementSystem")
        {
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
