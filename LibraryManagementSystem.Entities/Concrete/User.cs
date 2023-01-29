using LibraryManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities.Concrete
{
    public class User : IEntity
    {
        [Key]
        public int UserId { get; set; }
        //public List<int>? CurrentBookId { get; set; } = new List<int>();
        //public List<int>? PastBookId { get; set; } = new List<int>();
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Password { get; set; }
        public string? Gender { get; set; }
        public string IdentityNumber { get; set; }
        public string BirthYear { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal? Debt { get; set; }
        public int? BorrowedBookNumber { get; set; }

    }
}
