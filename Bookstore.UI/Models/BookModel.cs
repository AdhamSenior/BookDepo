using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookstore.UI.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please provide the name of the book.")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CoverImagePath { get; set; }

        [Required(ErrorMessage = "Please provide the name of the book's author.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please provide the book's description.")]
        public string Discription { get; set; }
        public string Condition { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string PublishYear { get; set; }
        public Nullable<bool> Status { get; set; }
        public string ISBN { get; set; }
    }
}