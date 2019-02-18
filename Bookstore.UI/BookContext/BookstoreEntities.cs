using Bookstore.UI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bookstore.UI.BookContext
{
    public class BookstoreEntities : DbContext
    {

        public BookstoreEntities() : base("DefaultConnection")
        {
        }

        public DbSet<BookModel> Book { get; set; }

    }
}