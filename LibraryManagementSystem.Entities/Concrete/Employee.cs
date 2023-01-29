using LibraryManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities.Concrete
{
    public class Employee : IEntity
    {
        [Key]
        public int EmployeeId { get; set; }
        //public List<int> CurrentBookId { get; set; }
        //public List<int> PastBookId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string IdentityNumber { get; set; }
        public string BirthYear { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int BorrowedBookNumber { get; set; }

    }
}
