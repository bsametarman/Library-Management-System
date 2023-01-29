using LibraryManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities.Concrete
{
    public class Genre : IEntity
    {
        [Key]
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
