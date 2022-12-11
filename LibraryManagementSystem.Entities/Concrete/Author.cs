using LibraryManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities.Concrete
{
    public class Author : IEntity
    {
        [Key]
        public int AuthorId { get; set; }
        [JsonIgnore]
        public virtual ICollection<Book>? Books { get; set; }
        public string AuthorName { get; set; }
        public string Gender { get; set; }
        public string BirthYear { get; set; }
        public string DeathYear { get; set; }
        public string InternetSite { get; set; }
        public string Email { get; set; }
    }
}
