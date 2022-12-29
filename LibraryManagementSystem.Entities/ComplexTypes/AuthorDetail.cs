using LibraryManagementSystem.Entities.Abstract;
using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities.ComplexTypes
{
	public class AuthorDetail : IEntity
	{
		[Key]
		public int AuthorId { get; set; }
		public string AuthorName { get; set; }
		public string Gender { get; set; }
		public string BirthYear { get; set; }
		public string DeathYear { get; set; }
		public string InternetSite { get; set; }
		public string Email { get; set; }
		public int BookId { get; set; }
		public string BookName { get; set; }
	}
}
