﻿using LibraryManagementSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities.Concrete
{
    public class Book : IEntity
    {
        [Key]
        public int BookId { get; set; }
        public int GenreId { get; set; }
        public int TranslatorId { get; set; }
        public string BookName { get; set; }
        public int AuthorId { get; set; }
        public virtual Author? Author { get; set; }
        public string ISBN { get; set; }
        public string ShelfNumber { get; set; }
        public bool AvailableState { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Publisher { get; set; }
        public string PublishedYear { get; set; }
        public string ShortSummary { get; set; }

    }
}
