using LibraryManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities.Concrete
{
    public class Genre : IEntity
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
