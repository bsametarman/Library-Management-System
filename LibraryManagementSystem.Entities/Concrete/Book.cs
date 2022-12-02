using LibraryManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities.Concrete
{
    public class Book : IEntity
    {
        public int BookId { get; set; }
        public List<int> GenreId { get; set; }
        public List<int> TranslatorId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string ShelfNumber { get; set; }
        public bool AvailableState { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Publisher { get; set; }
        public string PublishedYear { get; set; }
        public string ShortSummary { get; set; }

    }
}
