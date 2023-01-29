using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Entities.Abstract;

namespace LibraryManagementSystem.Entities.ComplexTypes
{
	public class BookDetail : IEntity
	{
		[Key]
		public int BookId { get; set; }
		public string BookName { get; set; }
		public string AuthorName { get; set; }
		public string AuthorEmail { get; set; }
		public int TranslatorId { get; set; }
		public string TranslatorName { get; set; }
		public string TranslatorEmail { get; set; }
		public int GenreId { get; set; }
		public string GenreName { get; set; }
		public string ISBN { get; set; }
		public string ShelfNumber { get; set; }
		public bool AvailableState { get; set; }
		public DateTime? ReturnDate { get; set; }
		public string Publisher { get; set; }
		public string PublishedYear { get; set; }
		public string ShortSummary { get; set; }
	}
}
