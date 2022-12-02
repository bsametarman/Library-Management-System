using LibraryManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities.Concrete
{
    public class Translator : IEntity
    {
        public int TranslatorId { get; set; }
        public List<int> BookId { get; set; }
        public string TranslatorName { get; set; }
        public string Gender { get; set; }
        public string BirthYear { get; set; }
        public string DeathYear { get; set; }
        public string InternetSite { get; set; }
        public string Email { get; set; }
    }
}
