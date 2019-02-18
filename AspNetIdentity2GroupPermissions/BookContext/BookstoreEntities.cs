using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentitySample.BookContext
{
    public class BookstoreEntities : DbContext
    {

        public BookstoreEntities() : base("BookstoreEntities")
        {
        }

        public DbSet<BookModel> Book { get; set; }

    }
}