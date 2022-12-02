using LibraryManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities.Concrete
{
    public class Publisher : IEntity
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string InternetSite { get; set; }
        public string Email { get; set; }
    }
}
