using LibraryManagementSystem.Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities.Concrete
{
    public class AppUser : IdentityUser, IEntity
    {
        //public List<int>? CurrentBookId { get; set; } = new List<int>();
        //public List<int>? PastBookId { get; set; } = new List<int>();
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string? Gender { get; set; }
        public string IdentityNumber { get; set; }
        public string BirthYear { get; set; }
        public string PhoneNumber { get; set; }
        public decimal? Debt { get; set; }
        public int? BorrowedBookNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public string UserRole { get; set; }

    }
}
